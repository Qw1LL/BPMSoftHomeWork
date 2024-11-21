namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging.Domain.Entities;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.FacebookProvider.Domain.Entities;
	using OmnichannelProviders.MessageConverters;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Web.Http.Abstractions;
	using Column = BPMSoft.Core.DB.Column;

	#region Class: RegisterChannelResponse

	[DataContract]
	public class RegisterChannelResponse : BaseResponse
	{

		#region Properties: Public

		/// <summary>
		/// Id in settings repo.
		/// </summary>
		[DataMember]
		public string SettingsId { get; set; }

		#endregion

	}

	#endregion
	
	#region Class: FacebookErrorKeysGenerator

	public class FacebookErrorKeysKeysGenerator : ErrorKeysGenerator
	{
		private class FacebookErrorResponse
		{
			public class Error
			{
				public string message { get; set; }
				public int code { get; set; }
				public int error_subcode { get; set; }
			}

			public Error error { get; set; }
		}
		
		/// <summary>
		/// Formats sending error key
		/// </summary>
		/// <param name="errorJson">Service response as JSON object</param>
		/// <returns>Response, depends on errorJson</returns>
		public override string GetSendingErrorKey(string errorJson = null) {
			string errorKey = "SendError";
			if (!string.IsNullOrEmpty(errorJson)) {
				FacebookErrorResponse response = JsonConvert.DeserializeObject<FacebookErrorResponse>(errorJson);
				switch (response.error?.error_subcode) {
					case 2018001:
						return "ChatClosedByUser";
				}
			}

			return errorKey;
		} 
	}

	#endregion

	#region Class: FacebookMessengerInfoResponse

	public class FacebookMessengerInfoResponse : OmnichannelMessagingService.OmnichannelMessagingServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Facebook application Id.
		/// </summary>
		public string AppId { get; set; }

		#endregion

	}

	#endregion
	
	#region Class: FacebookOmnichannelMessagingService

	/// <summary>
	/// Service for sending and receiving messages from messaging integration api.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class FacebookOmnichannelMessagingService : OmnichannelMessagingService
	{
		#region Properties: Protected

		protected override string MessageReceiverUrl { get { return "/ServiceModel/FacebookOmnichannelMessagingService.svc/receive/"; } }

		protected override string MessageRouterUrl { get { return "/api/facebook/messenger/"; } }

		#endregion

		#region Constructors: Public

		public FacebookOmnichannelMessagingService() : base() {
		}


		/// <summary>
		/// Initializes new instance of <see cref="FacebookOmnichannelMessagingService"/>.
		/// </summary>
		public FacebookOmnichannelMessagingService(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private Guid GetFacebookChannelId(Guid SettingsId) {
			Select channelSelect = new Select(UserConnection)
				.Top(1).Column("Id")
				.From("Channel")
				.Where("MsgSettingsId").IsEqual(Column.Parameter(SettingsId)) as Select;
			return channelSelect.ExecuteScalar<Guid>();
		}

		private Guid GetMsgSettingsIdBySource(string source) {
			Select channelSelect = new Select(UserConnection)
				.Top(1).Column("MsgSettingsId")
				.From("Channel")
				.Where("Source").IsEqual(Column.Parameter(source)) as Select;
			return channelSelect.ExecuteScalar<Guid>();
		}

		private bool CheckIsMessageSupported(MessagingMessage messagingMessage) {
			return (messagingMessage.Message.IsNotNullOrEmpty() || messagingMessage.Attachments != null) && messagingMessage.Sender.IsNotNullOrEmpty() &&
				messagingMessage.Recipient.IsNotNullOrEmpty();
		}
		
		private void PutMessageToQueue(FacebookIncomingMessage message, string facebookId) {
			Log.Info($"Put message to queue. Facebook ID: {facebookId}");
			MessagingMessage msg = new MessagingMessage();
			GetChannelAndQueueBySettingsId(Guid.Parse(facebookId), msg);
			var senderId = message.entry.FirstOrDefault().messaging.FirstOrDefault().sender.id;
			TransferMessageToQueue(Guid.Parse(msg.ChannelId), senderId);
		}

		private void CreateContactIfNeeded(MessagingMessage message, string facebookId) {
			Log.Info($"Try to create new contact for {message.SenderIfEcho}");
			GetChannelAndQueueBySettingsId(Guid.Parse(facebookId), message);
			if (message.ChannelId.IsNotNullOrEmpty()) {
				ContactIdentifier.CreateGuestContactIdentity(message);
			}
		}

		private void ReceiveMessage(MessagingMessage message, string facebookId) {
			GetChannelAndQueueBySettingsId(Guid.Parse(facebookId), message);
			if (message.ChannelId.IsNotNullOrEmpty()) {
				InternalReceive(message);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Check if token and identifier exists.
		/// </summary>
		/// <param name="facebookId">Identifier if facebook channel in our system.</param>
		[OperationContract]
		[WebGet(UriTemplate = "receive/{facebookId}", BodyStyle = WebMessageBodyStyle.Bare)]
		public void VerifyToken(string facebookId) {
			HttpContext httpContext = HttpContextAccessor.GetInstance();
#if !NETSTANDARD2_0
			WebOperationContext.Current.OutgoingResponse.ContentType = "text/html; charset=utf-8";
#else
				  {
					HttpResponse response = httpContext.Response;
					response.ContentType = "text/html; charset=utf-8";
				  }
#endif
			string token = httpContext.Request.QueryString["hub.verify_token"];
			string challenge = httpContext.Request.QueryString["hub.challenge"];
			var facebookChannelId = GetFacebookChannelId(Guid.Parse(facebookId)).ToString();
			bool isVerified = MessageManager.VerifyToken(facebookChannelId, token, ChannelType.Facebook.ToString());
			if (isVerified) {
				httpContext.Response.Write(challenge);
			}
		}

		/// <summary>
		/// Register facebook channel in BPMStudio.
		/// </summary>
		/// <param name="token">Facebook token.</param>
		/// <param name="source">Facebook page source.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public RegisterChannelResponse Register(string token, string source) {
			RegisterAccountIfNotExists();
			var additionalParameters = new Dictionary<string, object>();
			additionalParameters.Add("token", token);
			var msgSettingId = GetMsgSettingsIdBySource(source);
			var resp = new RegisterChannelResponse();
			if (msgSettingId != default(Guid)) {
				additionalParameters.Add("msgSettingsId", msgSettingId);
				resp.Success = false;
				resp.ErrorInfo = new ErrorInfo() { Message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
				"FacebookOmnichannelMessagingService", "LocalizableStrings.ChannelAlreadyExist.Value").ToString() };
			}
			var registrationData = new MessengerRegistrationData {
				Messenger = ChannelType.Facebook.ToString(),
				MessengerId = source,
				Token = token,
				MessageReceiverUrl = GetMessageReceiverUrl(),
				MessageRouterUrl = GetMessageRouterUrl("channel/register"),
				AdditionalParameters = additionalParameters,
				IdentityToken = GetIdentityToken()
			};
			var registerResult = MessageManager.Register(registrationData);
			resp.SettingsId = registerResult.SettingsId;
			return resp;
		}

		/// <summary>
		/// Removes facebook channel.
		/// </summary>
		/// <param name="facebookId">Identifier of facebook.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void RemoveChannel(string facebookId) {
			var deletionData = new MessengerDeletionData {
				ChannelId = facebookId,
				MessageRouterUrl = GetMessageRouterUrl("channel/remove"),
				Messenger = ChannelType.Facebook.ToString(),
				IdentityToken = GetIdentityToken()
			};
			MessageManager.RemoveChannel(deletionData);
		}

		/// <summary>
		/// Receives messages from integration api.
		/// </summary>
		/// <param name="message">Facebook message.</param>
		/// <param name="facebookId">Id if facebook channel in our system.</param>
		[OperationContract]
		[WebInvoke(UriTemplate = "receive/{facebookId}", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public void ReceiveMessage(FacebookIncomingMessage message, string facebookId) {
			if (FacebookIncomingMessageConverter.IsPassThreadControlMessage(message)) {
				PutMessageToQueue(message, facebookId);
				return;
			}
			MessagingMessage messagingMessage = new MessagingMessage(FacebookIncomingMessageConverter.Convert(message));
			if (CheckIsMessageSupported(messagingMessage)) {
				ReceiveMessage(messagingMessage, facebookId);
			} else if (messagingMessage.IsGuestUser) {
				CreateContactIfNeeded(messagingMessage, facebookId);
			}
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "GetCurrentFacebookAppId", Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public string GetCurrentFacebookAppId() {
			var url = GetMessageRouterUrl("GetCurrentFacebookAppId");
			var response = SendRequestWithToken<FacebookMessengerInfoResponse>(RestSharp.Method.GET, url);
			if (response.ErrorMessage.IsNullOrEmpty() && response.AppId.IsNotNullOrEmpty()) {
				return response.AppId;
			}
			Log.ErrorFormat("Could not get Facebook AppId");
			return string.Empty;
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "ping", Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public string Ping() {
			return "Pong";
		}

		#endregion

	}

	#endregion

}
