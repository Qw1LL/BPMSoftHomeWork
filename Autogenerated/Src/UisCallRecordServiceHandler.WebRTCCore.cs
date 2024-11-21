using Common.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Store;

namespace BPMSoft.Configuration.TelephonyCallRecordService
{
    #region Interfaces

    /// <summary>
    /// Шаблон базовых параметров запроса.
    /// </summary>
    public interface IRequest
    {
		/// <summary>
        /// Версия Api.
        /// </summary>
        string Version { get; set; }
		
		/// <summary>
        /// Id запроса.
        /// </summary>
        string Id { get; set; }
		
		/// <summary>
        /// Метод Api.
        /// </summary>
        string Method { get; set; }
		
		/// <summary>
        /// Параметры запроса.
        /// </summary>
        IRequestParameters Parameters { get; set; }
    }

    /// <summary>
    /// Шаблон данных запроса.
    /// </summary>
    public interface IRequestParameters { }

    /// <summary>
    /// Шаблон данных ответа.
    /// </summary>
    public interface IResponseParameters { }
    #endregion

    #region UisServiceHandler

    /// <summary>
    /// Коннектор к серверу Uis.
    /// </summary>
    public class UisServiceHandler : TelephonyHandler
    {
        /// <summary>
        /// Версия API.
        /// </summary>
        private readonly string _version = "2.0";

        /// <summary>
        /// Ключ для хранения токена в кеше.
        /// </summary>
        private const string CacheTokenName = "UisAuthToken";

        /// <summary>
        /// 
        /// </summary>
        private const string CacheTokenLifeTimeName = "UisAuthTokenGetTime";

        /// <summary>
        /// Временной сдвиг времени начала звонка.
        /// </summary>
        private int _startTimeShift { get; set; }

        /// <summary>
        /// Временной сдвиг времени завершения звонка.
        /// </summary>
        private int _endTimeShift { get; set; }

        private Guid _callDirection { get; set; }
		
		/// <summary>
        /// Расширенные колонки интеграционных настроек.
        /// </summary>
		private readonly string[] _configColumns = { "UisCallStartTimeShift.Code", "UisCallEndTimeShift.Code" };

        /// <summary>
        /// Дополнительные колонки данных звонка.
        /// </summary>
        private readonly string[] _callDataColums = { "Direction.Id" };

        /// <summary>
        /// Объект для блокировки потока.
        /// </summary>
        private readonly SemaphoreSlim lockObject = new SemaphoreSlim(1);

        /// <summary>
        /// Менеджер кеша.
        /// </summary>
        private CacheManager _cacheManager { get; set; }

        public UisServiceHandler()
        {
            SysMsgLibId = IntegrationLibraryIdentificator.UIS;
            AddConfigColums();
        }
		
		/// <summary>
        /// Метод установки параметров конфига коннектора.
        /// </summary>
		/// <param name="config">интеграцинной конфиг</param>
        public override void SetConnectionConfig(TelephonyIntegration config)
		{ 
            if (String.IsNullOrEmpty(config.WebServiceUrl)) 
            {
				var errorMessage = new LocalizableString(
						UserConnection.Workspace.ResourceStorage,
						"UisCallRecordServiceHandler",
						"LocalizableStrings.WebServerLinkNotFoundError.Value");
                throw new Exception(errorMessage);
            }
            _serverAddress = new Uri(config.WebServiceUrl);        
            _login = config.Login;
            _password = config.Password;
            _token = config.Token;
            Log = config.Log;
            AuthTypeMethod = config.AuthType;
            UserConnection = config.UserConnection;
            _startTimeShift = (int)ExtendedIntegrationColumnConfig["UisCallStartTimeShift.Code"].ColumnValue;
            _endTimeShift = (int)ExtendedIntegrationColumnConfig["UisCallEndTimeShift.Code"].ColumnValue;
            _callDirection = (Guid)ExtendedCallDataColumnnConfig["Direction.Id"].ColumnValue;
            _cacheManager = new CacheManager(UserConnection, CacheTokenName, CacheTokenLifeTimeName);
        }

        /// <summary>
        /// Метод получения ссылки на звонок.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="contactNumber"> Номер телефона кому звонили</param>
        public override void GetRecordLink(CancellationToken cancellationToken, RecordData record)
        {
            Task.Run(async () =>
            {
                await Auth(cancellationToken);
                await GetCallData(cancellationToken, record);
            }).Wait();
        }

        /// <summary>
        /// Метод получения данных о звонке из Api.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="record">Данные звонка</param>
        private async Task GetCallData (CancellationToken cancellationToken, RecordData record)
		{
            try
            {
                if (!String.IsNullOrEmpty(LastErrorMessage))
                {
                    throw new Exception(LastErrorMessage);
                }
                var targetCallNumber = GetTargetCallNumber(record);
                var requestFilter = new RequestFilter
                {
                    Field = "contact_phone_number",
                    Operator = "=",
                    Value = targetCallNumber
                };

                var requestParameters = new CallDataRequestParameters
                {
                    Filter = requestFilter,
                    Token = _token,
                    DateFrom = record.StartDate.AddMinutes(-_startTimeShift).ToString("yyyy-MM-dd HH:mm:ss"),
                    DateTill = record.EndDate.AddMinutes(_endTimeShift).ToString("yyyy-MM-dd HH:mm:ss"),
                    Fields = new string[] { "full_record_file_link" }
                };

                var requestData = GetBaseRequestData<Request>(requestParameters, MethodName.CallData);
                Log.Debug(JsonConvert.SerializeObject(requestData));
                var request = GetRequest(requestData);
                var response = await base.SendAsync(request, cancellationToken);
                var result = await ReadResponseAsync<CallDataResponseParametersCollection>(response);
                Log.Debug(JsonConvert.SerializeObject(result));
                if (result.Error != null)
				{
                    throw new Exception(result.Error.Message);
				}

                if (result.Result != null && result.Result.Data.Count > 0)
                {
                    RecordFileLink = result.Result.Data.First().RecordFileLink;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                LastErrorMessage = ex.Message;
            }
        }
		
		/// <summary>
        /// Метод авторизации.
        /// </summary>
		/// <param name="cancellationToken"></param>
        private async Task Auth(CancellationToken cancellationToken)
        {
            switch (AuthTypeMethod)
            {
                case AuthType.Basic:
                    {
                        await BasicAuth(cancellationToken);
                        break;
                    }
                case AuthType.Token:
                    break;

                default: 
				var errorMessage = new LocalizableString(
						UserConnection.Workspace.ResourceStorage,
						"UisCallRecordServiceHandler",
						"LocalizableStrings.AuthTypeMethodNotFoundError.Value");
				throw new Exception(errorMessage);
            }
        }

        /// <summary>
        /// Метод базовой авторизации.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task BasicAuth(CancellationToken cancellationToken)
        {
            try
            {
                await lockObject.WaitAsync();
                if (_cacheManager.GetTokenFromCache(ref _token, 50))
                {
                    return;
                }

                var authParams = new RequestBasicAuthParameters
                {
                    Login = _login,
                    Password = _password
                };
                var requestData = GetBaseRequestData<Request>(authParams, MethodName.Auth);
                Log.Debug(JsonConvert.SerializeObject(requestData));
                var request = GetRequest(requestData);
                var response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                var result = await ReadResponseAsync<AuthDataResponseParameters>(response);
                Log.Debug(JsonConvert.SerializeObject(result));
                if (result.Error != null)
                {
                    throw new Exception(result.Error.Message);
                }
                _token = result.Result.Data.Token;
                _cacheManager.SetTokenToCache(_token);
                
            }
            catch (Exception ex)
            {
                LastErrorMessage = ex.Message;
                Log.Error(ex.Message);
            }
            finally
            {
                lockObject.Release();
            }
        }
        
        /// <summary>
        /// Метод десериализации ответа.
        /// </summary>
        /// <typeparam name="TData"> Конкретный класс для десериализации ответа</typeparam>
        /// <param name="response"> Десериализованный ответ</param>
        /// <returns>десериализованный ответ</returns>
        private async Task<Response<TData>> ReadResponseAsync<TData>(HttpResponseMessage response) where TData : IResponseParameters
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        using (var jsonTextReader = new JsonTextReader(streamReader))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            return serializer.Deserialize<Response<TData>>(jsonTextReader);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                LastErrorMessage = ex.Message;
                throw;
            }
        }

        /// <summary>
        /// Метод конвертации номера телефона для Api.
        /// </summary>
        /// <param name="record">Данные звонка</param>
        /// <returns>Сконвертированный номер</returns>
        private string GetTargetCallNumber(RecordData record)
		{
            var number = "";
            switch (_callDirection.ToString().ToUpper())
			{
                case CallDirection.Incoming:
                    number = record.Caller;
                    break;

                case CallDirection.Outgoing:
                    number = record.Called;
                    break;

                default:
                    return number;
            }
            return ConvertNumberToApiFormat(number);
        }

        /// <summary>
        /// Метод конвертации номера телефона для Api.
        /// </summary>
        /// <param name="number">>Номер</param>
        /// <returns>>Сконвертированный номер</returns>
        private string ConvertNumberToApiFormat (string number)
		{
            
            if (number.Length == 11 && number.StartsWith("8"))
			{
                return "7" + number.Remove(0, 1);
            }
            return number;
        }

        /// <summary>
        /// Метод добавления дополнительных колонок.
        /// </summary>
        private void AddConfigColums()
        {
            foreach (var column in _configColumns)
            {
                ExtendedIntegrationColumnConfig.Add(column, new ExtandedConfigColumn());
            }

            foreach (var column in _callDataColums)
            {
                ExtendedCallDataColumnnConfig.Add(column, new ExtandedConfigColumn());
            }
        }

        // <summary>
        /// Метод получения данных запроса.
        /// </summary>
        /// <typeparam name="TData"> Конкретный класс запроса</typeparam>
        /// <param name="parameters"> Параметры запроса</param>
        /// <param name="method"> Название метода</param>
        /// <returns>Базовы запрос</returns>
        private TData GetBaseRequestData<TData>(IRequestParameters parameters, string method) where TData : IRequest, new()
        {
            Random random = new Random();
            var id = random.Next(100000, 999999);
            return new TData
            {
                Version = _version,
                Method = method,
                Id = id.ToString(),
                Parameters = parameters
            };
        }

        /// <summary>
        /// Метод получения запроса.
        /// </summary>
        /// <param name="data"> Данные запроса</param>
        /// <returns>Запрос</returns>
        private HttpRequestMessage GetRequest(IRequest data)
        {
            return new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"),
                RequestUri = _serverAddress
            };
        }
		
    }

    /// <summary>
    /// Менеджер  для работы с кешем.
    /// </summary>
    public  class CacheManager
	{
        /// <summary>
        /// Пользовательское соединение.
        /// </summary>
        UserConnection _userConnection { get; set; }

        /// <summary>
        /// Имя переменной.
        /// </summary>
        string _tokenCacheName { get; set; }

        /// <summary>
        /// Имя переменной для время ее действия.
        /// </summary>
        string _tokenLifeTimeCacheName { get; set; }

        public CacheManager (UserConnection userConnection, string tokenCacheName, string tokenLifeTimeCacheName)
		{
            _userConnection = userConnection;
            _tokenCacheName = tokenCacheName;
            _tokenLifeTimeCacheName = tokenLifeTimeCacheName;
        }
        /// <summary>
        /// Метод получения токена из кеша.
        /// </summary>
        /// <returns>Удалось ли получить токен</returns>
        public bool GetTokenFromCache(ref string value, int timeInMinutes)
        {
            var isTokenOverdue = true;
            var timeValueFromCache = _userConnection.ApplicationCache[_tokenLifeTimeCacheName];

            if (timeValueFromCache != null)
            {
                isTokenOverdue = (DateTime.Now - (DateTime)timeValueFromCache).TotalMinutes > timeInMinutes;
            }

            if (isTokenOverdue)
            {
                RemoveTokenFromCache();
                return false;
            }

            var valueFromCache = _userConnection.ApplicationCache[_tokenCacheName];
            if (valueFromCache != null)
            {
                value = (string)valueFromCache;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод установки токена в кеш.
        /// </summary>
        public void SetTokenToCache(string value)
        {
            _userConnection.ApplicationCache[_tokenLifeTimeCacheName] = DateTime.Now;
            _userConnection.ApplicationCache[_tokenCacheName] = value;
        }

        /// <summary>
        /// Метод удаления токена из кеша.
        /// </summary>
        private void RemoveTokenFromCache()
        {
            _userConnection.ApplicationCache.Remove(_tokenLifeTimeCacheName);
            _userConnection.ApplicationCache.Remove(_tokenCacheName);
        }
    }
    #endregion

     #region JsonParseClasses
    /// <summary>
    /// Класс запроса.
    /// </summary>
    [JsonObject]
    public class Request : IRequest
    {
        /// <summary>
        /// Версия API
        /// </summary>
        [JsonProperty(PropertyName = "jsonrpc")]
        public string Version { get; set; }

        /// <summary>
        /// Id запроса.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Название метода для обращения к API.
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        /// <summary>
        /// Параметры запроса.
        /// </summary>
        [JsonProperty(PropertyName = "params")]
        IRequestParameters IRequest.Parameters { get; set; }
    }


    /// <summary>
    /// Класс параметров запроса для базовой авторизации.
    /// </summary>
    [JsonObject]
    public class RequestBasicAuthParameters : IRequestParameters
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Класс параметров запроса для получения отчета о звонках.
    /// </summary>
    [JsonObject]
    public class CallDataRequestParameters : IRequestParameters
    {
        /// <summary>
        /// Фильтр данных.
        /// </summary>
        [JsonProperty(PropertyName = "filter")]
        public RequestFilter Filter { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        [JsonProperty(PropertyName = "date_from")]
        public string DateFrom { get; set; }

        /// <summary>
        /// Дата завершения.
        /// </summary>
        [JsonProperty(PropertyName = "date_till")]
        public string DateTill { get; set; }

        /// <summary>
        /// Токен авторизации
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        /// <summary>
        /// Список полей для ответа.
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public string[] Fields { get; set; }
    }

    /// <summary>
    /// Класс фильтров запросов.
    /// </summary>
    [JsonObject]
    public class RequestFilter
    {
        /// <summary>
        /// Поле.
        /// </summary>
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }

        /// <summary>
        /// Оператор.
        /// </summary>
        [JsonProperty(PropertyName = "operator")]
        public string Operator { get; set; }

        /// <summary>
        /// Значение поля.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Класс ответа.
    /// </summary>
    /// <typeparam name="TData">Параметры ответа</typeparam>
    [JsonObject]
    public class Response<TData> where TData : IResponseParameters
    {
        /// <summary>
        /// Версия API.
        /// </summary>
        [JsonProperty(PropertyName = "jsonrpc")]
        public string Version { get; set; }

        /// <summary>
        /// Id запроса.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Данные ответа.
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public ResponseParametersResult<TData> Result { get; set; }

        /// <summary>
        /// Ошибки.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }
    }

    /// <summary>
    /// Класс параметров ответа.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    [JsonObject]
    public class ResponseParametersResult<TData> where TData : IResponseParameters
    {
        /// <summary>
        /// Данные ответа.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public TData Data { get; set; }
    }

    /// <summary>
    /// Класс параметров ответа при запросе на авторизацию.
    /// </summary>
    [JsonObject]
    public class AuthDataResponseParameters : IResponseParameters
    {
        /// <summary>
        /// Токен авторизации.
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }
    }

    /// <summary>
    /// Вспомогательный класс для работы с коллекциями ответа.
    /// </summary>
    public class CallDataResponseParametersCollection : List<CallDataResponseParameters>, IResponseParameters { }

    /// <summary>
    /// Класс параметров ответа при получении отчета о звонках
    /// </summary>
    [JsonObject]
    public class CallDataResponseParameters : IResponseParameters
    {
        [JsonProperty(PropertyName = "full_record_file_link")]
        public string RecordFileLink { get; set; }
    }

    /// <summary>
    /// Класс ошибок ответа.
    /// </summary>
    [JsonObject]
    public class Error
    {
        [JsonProperty(PropertyName = "Code")]
        public int Code { get; set; }
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
    #endregion

    #region Constants
    /// <summary>
    /// Класс для типа запроса.
    /// </summary>
    public static class MethodName
    {
        /// <summary>
        /// Метод авторизации
        /// </summary>
        public static readonly string Auth = "login.user";

        /// <summary>
        /// Метод получения данных о звонке.
        /// </summary>
        public static readonly string CallData = "get.calls_report";
    }

    #endregion
}
