using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BPMSoft.Configuration.TelephonyCallRecordService
{
	/// <summary>
    /// Шаблон класса обработчика для интеграции с сервером телефонии.
    /// </summary>
    public abstract class TelephonyHandler: HttpClientHandler
    {
		/// <summary>
        /// Адрес сервера.
        /// </summary>
        protected Uri _serverAddress { get; set; }
		
		/// <summary>
        /// Логин.
        /// </summary>
        protected string _login = "";
		
		/// <summary>
        /// Пароль.
        /// </summary>
        protected string _password = "";
		
		/// <summary>
        /// Токен.
        /// </summary>
        protected string _token = "";
		
		/// <summary>
        /// Id библиотеки обмена сообщениями.
        /// </summary>
        public Guid SysMsgLibId { get; set; }
		
		/// <summary>
        /// Тип метода авторизации.
        /// </summary>
        public string AuthTypeMethod { get; set; }
		
		/// <summary>
        /// Ссылка на запись.
        /// </summary>
        public string RecordFileLink = "";
		
		/// <summary>
        /// Текст последней ошибки.
        /// </summary>
        public string LastErrorMessage = "";
		
		/// <summary>
        /// Лог.
        /// </summary>
        public ILog Log { get; set; }
		
		/// <summary>
        /// Пользовательское соединение.
        /// </summary>
        public UserConnection UserConnection { get; set; }
		
		/// <summary>
        /// Расширенные колонки конфига (TelephonyIntegration).
        /// </summary>
        public Dictionary<string, ExtandedConfigColumn> ExtendedIntegrationColumnConfig = new Dictionary<string, ExtandedConfigColumn>();
		
		/// <summary>
        /// Расширенные колонки данных о звонке (Call).
        /// </summary>
		public Dictionary<string, ExtandedConfigColumn> ExtendedCallDataColumnnConfig = new Dictionary<string, ExtandedConfigColumn>();
		
		/// <summary>
        /// Метод установки параметров конфига коннектора.
        /// </summary>
		public abstract void SetConnectionConfig(TelephonyIntegration config);
		
		/// <summary>
        /// Метод получения ссылки на звонок.
        /// </summary>
        public abstract void GetRecordLink(CancellationToken token, RecordData data);  
    }
	
	/// <summary>
    /// Помощник сервиса получения записи звонка.
    /// </summary>
    public class TelephonyCallRecordServiceHelper 
    {
	   /// <summary>
       /// Экземпляр коннектора.
       /// </summary>
       private TelephonyHandler _telephonyHandler { get; set; }
	   
	   /// <summary>
       /// Пользовательское соединение.
       /// </summary>
       private UserConnection _userConnection { get; set; }
		
	   /// <summary>
       /// Лог.
       /// </summary>
	   private ILog _log;
		
	   /// <summary>
       /// Лог.
       /// </summary>
       public ILog Log
       {
           get
           {
               return _log ?? (_log = LogManager.GetLogger("TelephonyCallRecordServiceHelper"));
           }
       }

       public TelephonyCallRecordServiceHelper(TelephonyHandler handler, UserConnection userConnection)
       {
            _telephonyHandler = handler;
            _userConnection = userConnection;
       }
		
	   /// <summary>
       /// Метод получения записи звонка.
       /// </summary>
	   /// <param name="integrationId">Интеграционный Id звонка</param>
	   /// <returns> Объект ссылки на запись звонка</returns>
       public RecordLinkResult GetRecordLink(Guid integrationId)
       {
            try
            {
                var callData = GetCallData(integrationId);
                if (CheckExistRecordLink(callData))
                {
					return new RecordLinkResult
                    {
                        ErrorLastMessage = "",
                        CallRecordLink = callData.RecordLink,
                    };
                }

                var config = GetTelephonyIntegrationConfig();

                if (config.EnableCallRecordingFeature == false)
                {
					var errorMessage = new LocalizableString(
						_userConnection.Workspace.ResourceStorage,
						"TelephonyCallRecordServiceHelper",
						"LocalizableStrings.IntegrationSettingNotFoundError.Value");

                    throw new Exception(errorMessage);
                }
                _telephonyHandler.SetConnectionConfig(config);
				callData.StartDate = callData.StartDate.AddHours(config.TimeZoneOffset);
				callData.EndDate = callData.EndDate.AddHours(config.TimeZoneOffset);
                _telephonyHandler.GetRecordLink(new CancellationToken(), callData);

				if (!String.IsNullOrEmpty(_telephonyHandler.RecordFileLink))
				{
					SaveRecordLink(callData.Id);
				}
				
                return new RecordLinkResult
                {
                    ErrorLastMessage = _telephonyHandler.LastErrorMessage,
                    CallRecordLink = _telephonyHandler.RecordFileLink
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return new RecordLinkResult
                {
                    ErrorLastMessage = ex.Message
                };
            }
       }
		
	   /// <summary>
       /// Метод получения данных звонка.
       /// </summary>
	   /// <param name="integrationId">Интеграционный Id звонка</param>
	   /// <returns>Данные о звонке</returns>
	   private RecordData GetCallData(Guid integrationId) 
       {
            var recordEntity = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Call");
            var columnId = recordEntity.AddColumn("Id");
            recordEntity.AddColumn("CallerId");
            recordEntity.AddColumn("CalledId");
            recordEntity.AddColumn("StartDate");
            recordEntity.AddColumn("EndDate");
            recordEntity.AddColumn("CallRecordLink");
			AddExtendedColumn(_telephonyHandler.ExtendedCallDataColumnnConfig, ref recordEntity);

			var integrationFilter = recordEntity
                .CreateFilterWithParameters(
                FilterComparisonType.Equal, "IntegrationId", integrationId);
            recordEntity.Filters.Add(integrationFilter);

            var offSet = _userConnection.CurrentUser.TimeZone.BaseUtcOffset.TotalHours;

            var entities = recordEntity.GetEntityCollection(_userConnection);

            if (entities.Count > 0)
            {
                var entity = entities[0];
                AddExtendedColumnValues(_telephonyHandler.ExtendedCallDataColumnnConfig, entity);
                return new RecordData
                {
                    Id = entity.GetTypedColumnValue<Guid>(columnId.Name),
                    Caller = entity.GetTypedColumnValue<String>("CallerId"),
                    Called = entity.GetTypedColumnValue<String>("CalledId"),
                    StartDate = entity.GetTypedColumnValue<DateTime>("StartDate").AddHours(-offSet),
                    EndDate = entity.GetTypedColumnValue<DateTime>("EndDate").AddHours(-offSet),
                    RecordLink = entity.GetTypedColumnValue<string>("CallRecordLink")
                };
            }
            else
            {
                Log.Error("Test");
                var errorMessage = new LocalizableString(
                       _userConnection.Workspace.ResourceStorage,
                       "TelephonyCallRecordServiceHelper",
                       "LocalizableStrings.CallDataNotFoundError.Value");

                throw new Exception(errorMessage);
            }
        }
		
	   /// <summary>
       /// Метод получения интеграционных настроек.
       /// </summary>
	   /// <returns>Настройки интеграции</returns>
       private TelephonyIntegration GetTelephonyIntegrationConfig()
       {
            try
            {
                var recordEntity = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "TelephonyIntegration");
                recordEntity.AddColumn("WebServiceURL");
                recordEntity.AddColumn("TelephonyAuthType");
                var loginColumn = recordEntity.AddColumn("Login.Code");
                var passwordColumn = recordEntity.AddColumn("Password.Code");
                recordEntity.AddColumn("EnableCallRecordingFeature");
                var tokenColumn = recordEntity.AddColumn("Token.Code");
                var UrlPatternColumn = recordEntity.AddColumn("CallRecordLinkUrlTemplate");
                var timeZoneColumn = recordEntity.AddColumn("TelephonyServerTimeZone.Code");

				AddExtendedColumn(_telephonyHandler.ExtendedIntegrationColumnConfig, ref recordEntity);

                recordEntity.CacheItemName = "TelephonyIntegrationConfig";

                recordEntity.UseAdminRights = true;

                var sysMsgLibFilter = recordEntity
                       .CreateFilterWithParameters(
                       FilterComparisonType.Equal, "SysMsgLib.Id", _telephonyHandler.SysMsgLibId);
                recordEntity.Filters.Add(sysMsgLibFilter);
                var entities = recordEntity.GetEntityCollection(_userConnection);
                
                if (entities.Count > 0)
                {
                    var entity = entities[0];
                    AddExtendedColumnSysSettingValues(_telephonyHandler.ExtendedIntegrationColumnConfig, entity);
                    return new TelephonyIntegration()
                    {
                        WebServiceUrl = entity.GetTypedColumnValue<string>("WebServiceURL"),
                        AuthType = entity.GetTypedColumnValue<Guid>("TelephonyAuthTypeId").ToString().ToUpper(),
                        EnableCallRecordingFeature = entity.GetTypedColumnValue<bool>("EnableCallRecordingFeature"),
                        Log = Log,
                        Login = GetSysSettingValue(
                           entity.GetTypedColumnValue<string>(loginColumn.Name)).ToString(),
                        Password = GetSysSettingValue(
                           entity.GetTypedColumnValue<string>(passwordColumn.Name)).ToString(),
                        Token = GetSysSettingValue(
                        entity.GetTypedColumnValue<string>(tokenColumn.Name)).ToString(),
                        UserConnection = _userConnection,
                        CallRecordLinkPattern = entity.GetTypedColumnValue<string>(UrlPatternColumn.Name),
                        TimeZoneOffset = GetTimeZoneSysSettingValue(entity.GetTypedColumnValue<string>(timeZoneColumn.Name))
                    };
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return new TelephonyIntegration()
                {
                    EnableCallRecordingFeature = false
                };
            }
       }
	   /// <summary>
       /// Метод проверки наличия ссылки на запись звонка.
       /// </summary>
	   /// <param name="callData">Данные о звонке</param>
	   /// <returns>Существования ссылки в базе</returns>
	   private bool CheckExistRecordLink(RecordData callData) => !string.IsNullOrEmpty(callData.RecordLink);
		
	   /// <summary>
       /// Метод сохранения ссылки на звонок.
       /// </summary>
       /// <param name="Id">Id звонка</param>
       private bool SaveRecordLink (Guid Id)
       {
           var esm = _userConnection.EntitySchemaManager.GetInstanceByName("Call");
           var entity = esm.CreateEntity(_userConnection);
           entity.FetchFromDB("Id", Id);
           entity.SetColumnValue("CallRecordLink", _telephonyHandler.RecordFileLink);
           return entity.Save(false);
       }
	   
	   /// <summary>
       /// Метод получения сдвига часового пояса.
       /// </summary>
	   /// <param name="settingId">Id системной настройки</param>
		/// <returns>Количество часов сдвига часового пояса</returns>
       private int GetTimeZoneSysSettingValue(string settingCode)
       {
           var timeZoneValue = (Guid)GetSysSettingValue(settingCode);
           var esm = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "TimeZone");
           esm.AddColumn("Offset");
           esm.CacheItemName = "TimeZone_" + timeZoneValue.ToString();
           var nameFilter = esm
                      .CreateFilterWithParameters(
                      FilterComparisonType.Equal, "Id", timeZoneValue);
           esm.Filters.Add(nameFilter);
           var entities = esm.GetEntityCollection(_userConnection);
           if (entities.Count == 0)
           {
               return 0;
           }
            var offset = entities[0].GetTypedColumnValue<string>("Offset");
            return ConvertOffset(offset);
       }
        
	   /// <summary>
       /// Конвертирует часовой сдвиг в формат числа.
       /// </summary>
	   /// <param name="offsset">Значение часового пояса</param>
	   /// <returns>Количество часов сдвига часового пояса</returns>
       private int ConvertOffset(string offsset)
       {
           if (String.IsNullOrEmpty(offsset))
           {
               return 0;
           }
           offsset = offsset.Replace("GMT", "");
           if (offsset.Length == 0)
           {
               return 0;
           }
           int.TryParse(offsset.Replace(":00", ""), out int result);
           return result;
       }
	   
	   /// <summary>
       /// Метод получения значения системной настройки.
       /// </summary>
	   /// <param name="settingId">Id системной настройки</param>
	   /// <returns>Значение системной настройки</returns>
       private object GetSysSettingValue(string settingCode)
       {
           if (String.IsNullOrEmpty(settingCode))
           {
               return new object();
           }
           if (BPMSoft.Core.Configuration.SysSettings.
               TryGetValue(_userConnection, settingCode, out object result))
           {
				return result;
           }
           return new object();
       }

	   /// <summary>
       /// Метод добавления дополнительных колонок настроек интеграции.
       /// </summary>
	   /// <param name="extendedColumns">Коллекция дополнительных колонок</param>
	   /// <param name="query">Запрос</param>
       private void AddExtendedColumn (Dictionary<string, ExtandedConfigColumn> extendedColumns, ref EntitySchemaQuery query)
       {
           if (extendedColumns.Count > 0)
           {
               foreach (var columnConfig in extendedColumns)
               {
                	var column = query.AddColumn(columnConfig.Key);
					extendedColumns[columnConfig.Key].ColumnName = column.Name;
               }
           }
       }
	   /// <summary>
       /// Метод получения значений дополнительных колонок настроек интеграции.
       /// </summary>
	   /// <param name="extendedColumns">Коллекция дополнительных колонок</param>
	   /// <param name="query">Сущность</param>
       private void AddExtendedColumnSysSettingValues(Dictionary<string, ExtandedConfigColumn> extendedColumns, Entity entity)
       {
			if (extendedColumns.Count > 0)
			{
				foreach (var column in extendedColumns)
				{
					extendedColumns[column.Key].ColumnValue = GetSysSettingValue(entity.GetTypedColumnValue<string>(column.Value.ColumnName));
				}
			}
       }

        /// <summary>
        /// Метод получения значений дополнительных колонок настроек интеграции.
        /// </summary>
        /// <param name="extendedColumns">Коллекция дополнительных колонок</param>
        /// <param name="query">Сущность</param>
        private void AddExtendedColumnValues(Dictionary<string, ExtandedConfigColumn> extendedColumns, Entity entity)
        {
            if (extendedColumns.Count > 0)
            {
                foreach (var column in extendedColumns)
                {
                    extendedColumns[column.Key].ColumnValue = (entity.GetTypedColumnValue<object>(column.Value.ColumnName));
                }
            }
        }
    }

	/// <summary>
    /// Интеграция с телефонией.
    /// </summary>
    public class TelephonyIntegration
    {
		/// <summary>
    	/// Адрес сервера.
    	/// </summary>
        public string WebServiceUrl { get; set; }
		
		/// <summary>
    	/// Тип авторизации.
    	/// </summary>
        public string AuthType { get; set; }
		
		/// <summary>
    	/// Функция получения записи звонка.
    	/// </summary>
        public bool EnableCallRecordingFeature { get; set; }
		
		/// <summary>
    	/// Логин.
    	/// </summary>
        public string Login { get; set; }
		
		/// <summary>
    	/// Пароль.
    	/// </summary>
        public string Password { get; set; }
		
		/// <summary>
    	/// Токен.
    	/// </summary>
        public string Token { get; set; }
		
		/// <summary>
    	/// Шаблон ссылки на запись.
    	/// </summary>
        public string CallRecordLinkPattern { get; set; }
		
		/// <summary>
    	/// Лог.
   		/// </summary>
        public ILog Log { get; set; }
		
		/// <summary>
    	/// Пользовательское соединение.
    	/// </summary>
        public UserConnection UserConnection { get; set; }
		
		/// <summary>
    	/// Временной сдвиг часового пояса
   		/// </summary>
        public int TimeZoneOffset { get; set; }
    }
	
	/// <summary>
    /// Данные о звонке
    /// </summary>
    public class RecordData
    {
		/// <summary>
    	/// Инициатор звонка.
    	/// </summary>
        public string Caller { get; set; }
		
		/// <summary>
    	/// Кому звонили.
    	/// </summary>
        public string Called { get; set; }
		
		/// <summary>
    	/// Время начала звонка.
    	/// </summary>
        public DateTime StartDate { get; set; }
		
		/// <summary>
    	/// Время завершения звонка.
    	/// </summary>
        public DateTime EndDate { get; set; }

		
		/// <summary>
    	/// Id звонка
    	/// </summary>
        public Guid Id  { get; set; }
		
		/// <summary>
    	/// Ссылка на запись звонка.
    	/// </summary>
        public string RecordLink { get; set; }
    }

	/// <summary>
    /// Результат получения записи звонка.
    /// </summary>
    public class RecordLinkResult 
    {
		
		/// <summary>
    	/// Последняя ошибка.
    	/// </summary>
        public string ErrorLastMessage { get; set; }
		
		/// <summary>
    	/// Ссылка на запись звонка.
    	/// </summary>
        public string CallRecordLink { get; set; }
    }
	
	/// <summary>
    /// Конфиг для получения дополнительных колонок.
    /// </summary>
    public class ExtandedConfigColumn
    {
		
		/// <summary>
   		/// Имя колонки.
    	/// </summary>
        public string ColumnName { get; set; }
		
		/// <summary>
    	/// Значение колонки.
    	/// </summary>
        public object ColumnValue { get; set; }
    }
}
