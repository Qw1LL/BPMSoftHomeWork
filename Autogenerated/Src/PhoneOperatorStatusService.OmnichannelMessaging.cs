namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Messaging.Common;

	/// <summary>
	/// Класс для установки статуса телефонии в кеш
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class PhoneOperatorStatusService : BaseService
	{	
		/// <summary>
		/// Менеджер кеша.
		/// </summary>
        private CacheManager _cacheManager;
		
		/// <summary>
		/// Пользовательское соединение.
		/// </summary>
		private UserConnection _userConnection;
		
		/// <summary>
		/// Название ключа в кеше.
		/// </summary>
        private readonly string _tokenName = "TelephonyOperatorStatus";
		
		/// <summary>
		/// Название отправителя.
		/// </summary>
		private const string PhoneOperatorStateChangedSender = "PhoneOperatorStateChanged";
		
		/// <summary>
		/// Менеджер отправителя.
		/// </summary>
		private readonly IMsgChannelManager _channelManager = MsgChannelManager.Instance;

		public PhoneOperatorStatusService() : base() 
        {
			_userConnection = UserConnection;
            _cacheManager = new CacheManager(_userConnection, _tokenName);
		}

		public PhoneOperatorStatusService(UserConnection userConnection) : base(userConnection) 
        {
			_userConnection = userConnection;
            _cacheManager = new CacheManager(_userConnection, _tokenName);
		}
		
		/// <summary>
		/// Смена статуса в кеше.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ChangeState(string state, bool available) 
        {
			var response = new ConfigurationServiceResponse();
			// to do... проблема с сериализацией.
			var data = new PhoneOperatorData
			{
				State = state,
				IsAvailable = available
			};
			
			try 
			{
				_cacheManager.SetTokenToCache(data);
				var currentUser = _userConnection.CurrentUser.Id;
				Notify(currentUser, PhoneOperatorStateChangedSender, data);
				return response;
			}
           	catch (Exception ex) 
			{
				response.Exception = ex;
				return response;
			}
        }
		
		/// <summary>
		/// Получение статуса из кеша.
		/// </summary>
        [OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public PhoneOperatorData GetState() 
        {
			return _cacheManager.GetTokenFromCache();
        }
		
		/// <summary>
		/// Формирование сообщения для веб-сокета.
		/// </summary>
		private IMsg GetChannelMessage(Guid sysAdminUnit, string sender, string data) {
			return new SimpleMessage {
				Id = sysAdminUnit,
				Body = data,
				Header = {
					Sender = sender,
					BodyTypeName = "BPMSoft.Configuration.Omnichannel.Messaging.PhoneOperatorData"
				}
			};
		}
		
		/// <summary>
		/// Отправка сообщения по веб-сокету.
		/// </summary>
		private void Notify(Guid sysAdminUnit, string sender, PhoneOperatorData data) {
			IMsgChannel channel = _channelManager.FindItemByUId(sysAdminUnit);
			if (channel == null) {
				Console.WriteLine($"Empty channel for '{sysAdminUnit}'");
				return;
			}
			IMsg message =
				GetChannelMessage(sysAdminUnit, sender, GetChannelMessageData(data));
				//throw new Exception(data.State + GetChannelMessageData(data));
			channel.PostMessage(message);
		}
		
		/// <summary>
		/// Сериализация данных сообщения.
		/// </summary>
		private string GetChannelMessageData(PhoneOperatorData data) {
			return Newtonsoft.Json.JsonConvert.SerializeObject(data);
		}
	}
	
	/// <summary>
	/// Кеш менеджер.
	/// </summary>
	public class CacheManager
	{
        /// <summary>
        /// Пользовательское соединение.
        /// </summary>
        UserConnection _userConnection { get; set; }

        /// <summary>
        /// Имя ключа.
        /// </summary>
        string _tokenCacheName { get; set; }

        public CacheManager (UserConnection userConnection, string tokenCacheName)
		{
            _userConnection = userConnection;
            _tokenCacheName = tokenCacheName;
        }
		 
        /// <summary>
        /// Метод получения токена из кеша.
        /// </summary>
        /// <returns>Удалось ли получить токен</returns>
        public PhoneOperatorData GetTokenFromCache()
        {
			var value = new PhoneOperatorData {
				State = "",
				IsAvailable = false
				
			};
            var serializeValueFromCache = (string)_userConnection.SessionCache[_tokenCacheName];
			
            if (serializeValueFromCache != null)
            {
				return Newtonsoft.Json.JsonConvert.DeserializeObject<PhoneOperatorData>(serializeValueFromCache);
            }
            return value;
        }

        /// <summary>
        /// Метод установки токена в кеш.
        /// </summary>
        public void SetTokenToCache(PhoneOperatorData value)
        {
			
            _userConnection.SessionCache[_tokenCacheName] = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Метод удаления токена из кеша.
        /// </summary>
        private void RemoveTokenFromCache()
        {
            _userConnection.SessionCache.Remove(_tokenCacheName);
        }
    }
	
	/// <summary>
    /// Доступность оператора
    /// </summary>
	[DataContract]
	public class PhoneOperatorData
	{
		/// <summary>
        /// Статус оператора
        /// </summary>
		[DataMember]
		public string State { get; set; }
		
		/// <summary>
        /// Доступность оператора
        /// </summary>
		[DataMember]
		public bool IsAvailable { get; set; }
	}
	
}
