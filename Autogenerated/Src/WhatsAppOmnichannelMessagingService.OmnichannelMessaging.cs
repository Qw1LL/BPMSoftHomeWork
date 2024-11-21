namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging;
	using OmnichannelMessaging.Domain.Entities;
	using OmnichannelMessaging.WhatsApp;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.MessageConverters;
	using OmnichannelProviders.WhatsAppProvider.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: WhatsAppRegistrationResponse

	[DataContract]
	public class WhatsAppRegistrationResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		/// <summary>
		/// Identifier of whatsapp settings repository
		/// </summary>
		[DataMember]
		public string SettingsId { get; set; }

		/// <summary>
		/// Is channel valid.
		/// </summary>
		[DataMember]
		public bool IsConnectionSuccess { get; set; }

		#endregion
	}

	#endregion

	#region Class: WhatsAppRegistrationRequest

	[DataContract]
	public class WhatsAppRegistrationRequest
	{
		#region Properties: Public

		[DataMember(Name = "token")]
		public string Token { get; set; }

		[DataMember(Name = "appId")]
		public string AppId { get; set; }

		[DataMember(Name = "integrationPhoneNumber")]
		public string IntegrationPhoneNumber { get; set; }

		[DataMember(Name = "channelPhoneNumber")]
		public string ChannelPhoneNumber { get; set; }

		#endregion
	}

	#endregion

	#region Class: WhatsAppOmnichannelMessagingService

	/// <summary>
	/// Service for sending and receiving messages from whatsapp api.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class WhatsAppOmnichannelMessagingService : OmnichannelMessagingService
	{

		#region Properties: Protected

		protected override string MessageReceiverUrl {
			get {
				return "/ServiceModel/WhatsAppOmnichannelMessagingService.svc/receive/";
			}
		}

		protected override string MessageRouterUrl {
			get {
				return "/api/whatsapp/messenger/";
			}
		}

		#endregion

		#region Methods: Private

		private string WrapPhoneNumber(string phoneNumber) {
			return $"whatsapp:{phoneNumber}";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers whatsapp channel in BPMStudio.
		/// </summary>
		/// <param name="request">Whatsapp registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public WhatsAppRegistrationResponse RegisterChannel(WhatsAppRegistrationRequest request) {
			try {
				RegisterAccountIfNotExists();
				var additionalParameters = new Dictionary<string, object>();
				additionalParameters.Add("appId", request.AppId);
				var registrationData = new MessengerRegistrationData {
					Messenger = ChannelType.WhatsApp.ToString(),
					MessengerId = WrapPhoneNumber(request.ChannelPhoneNumber),
					Token = request.Token,
					MessageReceiverUrl = GetMessageReceiverUrl(),
					MessageRouterUrl = GetMessageRouterUrl("channel/register"),
					AdditionalParameters = additionalParameters,
					IdentityToken = GetIdentityToken()
				};
				var registerResult = MessageManager.Register(registrationData);
				return new WhatsAppRegistrationResponse {
					SettingsId = registerResult.SettingsId
				};
			} catch (Exception ex) {
				return new WhatsAppRegistrationResponse {
					IsConnectionSuccess = false,
					Exception = ex
				};
			}
		}

		/// <summary>
		/// Validates whatsapp registration data.
		/// </summary>
		/// <param name="request">Whatsapp registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public WhatsAppRegistrationResponse Validate(WhatsAppRegistrationRequest request) {
			try {
				var sender = new WhatsAppMessageSender(UserConnection);
				var result = sender.Validate(
					new MessagingMessage {
						Sender = WrapPhoneNumber(request.ChannelPhoneNumber),
						Recipient = WrapPhoneNumber(request.IntegrationPhoneNumber),
						Message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
							"WhatsAppOmnichannelMessagingService", "LocalizableStrings.WhatsAppValidationTestMessage.Value")
					},
					new WhatsAppSettings {
						AppId = request.AppId,
						Token = request.Token
					});
				return new WhatsAppRegistrationResponse {
					IsConnectionSuccess = true
				};
			} catch (Exception ex) {
				return new WhatsAppRegistrationResponse {
					IsConnectionSuccess = false,
					Exception = ex
				};
			}

		}

		/// <summary>
		/// Removes WhatsApp channel.
		/// </summary>
		/// <param name="whatsAppId">Identifier of WhatsApp.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void RemoveChannel(string whatsAppId) {
			var deletionData = new MessengerDeletionData {
				ChannelId = whatsAppId,
				MessageRouterUrl = GetMessageRouterUrl("channel/remove"),
				Messenger = ChannelType.WhatsApp.ToString(),
				IdentityToken = GetIdentityToken()
			};
			MessageManager.RemoveChannel(deletionData);
		}

		/// <summary>
		/// Receives messages from integration api.
		/// </summary>
		/// <param name="message">WhatsApp form message.</param>
		/// <param name="whatsAppId">Identifier of whatsAppId channel.</param>
		[OperationContract]
		[WebInvoke(UriTemplate = "receive/{whatsAppId}", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public void ReceiveMessage(WhatsAppIncomingMessage message, string whatsAppId) {
			MessagingMessage messagingMessage = new MessagingMessage(WhatsAppIncomingMessageConverter.Convert(message));
			GetChannelAndQueueBySettingsId(Guid.Parse(whatsAppId), messagingMessage);
			if (messagingMessage.ChannelId.IsNotNullOrEmpty()) {
				InternalReceive(messagingMessage);
			}
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

