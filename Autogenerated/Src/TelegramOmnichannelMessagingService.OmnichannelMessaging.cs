namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging.Telegram;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.Models;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Web.Http.Abstractions;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: TelegramChannelRegistrationResponse

	[DataContract]
	public class TelegramChannelRegistrationResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// Identifies that Telegram token is valid.
		/// </summary>
		[DataMember]
		public bool IsTokenValid { get; set; } = false;

		/// <summary>
		/// Identifies that Telegram token is exist.
		/// </summary>
		[DataMember]
		public bool IsTokenExist { get; set; } = false;

		/// <summary>
		/// Identifier of Telegram channel settings.
		/// </summary>
		[DataMember]
		public Guid SettingsId { get; set; }

		/// <summary>
		/// Represents name of Telegram channel.
		/// </summary>
		[DataMember]
		public string ChannelName { get; set; }

		/// <summary>
		/// Identifier of channel in Telegram.
		/// </summary>
		[DataMember]
		public string TelegramId { get; set; }

		#endregion

	}

	#endregion

	#region Class: TelegramOmnichannelMessagingService

	/// <summary>
	/// Service for sending and receiving messages from Telegram messenger.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class TelegramOmnichannelMessagingService : OmnichannelMessagingService
	{

		#region Properties: Protected

		private TelegramRepository _repository;
		protected TelegramRepository Repository {
			get {
				return _repository = _repository ?? new TelegramRepository(UserConnection);
			}
		}

		#endregion

		#region Constructors: Public

		public TelegramOmnichannelMessagingService() : base() {
		}


		/// <summary>
		/// Initializes new instance of <see cref="TelegramOmnichannelMessagingService"/>.
		/// </summary>
		public TelegramOmnichannelMessagingService(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private void CheckSysSettingSiteUrlAndFillValueIfItIsNeeded() {
			var siteUrl = SystemSettings.GetValue(UserConnection, "SiteUrl", string.Empty);
			if (string.IsNullOrEmpty(siteUrl)) {
				HttpContext httpContext = HttpContextAccessor.GetInstance();
				siteUrl = WebUtilities.GetBaseApplicationUrl(httpContext.Request);
				SystemSettings.SetDefValue(UserConnection, "SiteUrl", siteUrl);
				TelegramIncomeMessageWorker.SiteUrl = siteUrl;
			}
		}

		private void FillChannelId(string source, MessagingMessage message) {
			Select channelSelect = new Select(UserConnection)
				.Top(1)
					.Column("Id")
				.From("Channel")
				.Where("Source").IsEqual(Column.Parameter(source))
					.And("IsActive").IsEqual(Column.Parameter(true)) as Select;
			channelSelect.ExecuteReader(reader => {
				message.ChannelId = reader.GetColumnValue<Guid>("Id").ToString();
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers Telegram messaging channel.
		/// </summary>
		/// <param name="token"></param>
		/// <returns>Result of channel registration.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public TelegramChannelRegistrationResponse RegisterChannel(string token) {
			CheckSysSettingSiteUrlAndFillValueIfItIsNeeded();
			var response = new TelegramChannelRegistrationResponse();
			if (token.IsNotNullOrEmpty()) {
				try {
					TelegramChannelInfo channel;
					RegisterChannelStatus status = TelegramClientFactory.Instance.RegisterChannel(token, out channel);
					Log.DebugFormat("The register status is {0}. Channel ID: {1}", status.ToString(), channel?.Id);
					switch (status) {
						case RegisterChannelStatus.Success:
							response.IsTokenValid = true;
							response.SettingsId = channel.SettingsId;
							response.ChannelName = channel.FirstName;
							response.TelegramId = channel.Id;
							break;
						case RegisterChannelStatus.NotValidToken:
							response.IsTokenValid = false;
							break;
						case RegisterChannelStatus.TokenIsExists:
							response.IsTokenValid = true;
							response.IsTokenExist = true;
							break;
						default:
							break;
					}
				} catch (Exception ex) {
					response.Exception = ex;
					Log.ErrorFormat("Error while registering Telegram channel. Error info: {0}", ex, ex.Message);
					return response;
				}
			} else {
				response.Exception = new ArgumentNullOrEmptyException("token");
			}
			return response;
		}
		
		/// <summary>
		/// Removes telegram channel.
		/// </summary>
		/// <param name="telegramId">Identifier of telegram msg settings.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public void RemoveChannel(string telegramId) {
			TelegramClientFactory.Instance.UnregisterChannel(telegramId);
		}

		/// <summary>
		/// Returns userName of Telegram channel.
		/// </summary>
		/// <param name="settingsId">Identifier of Telegram channel settings.</param>
		/// <returns>Telegram userName.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public string GetUserName(Guid settingsId) {
			return Repository.GetUserName(settingsId);
		}

		/// <summary>
		/// Receives messages from integration api.
		/// </summary>
		/// <param name="message">Unified message.</param>
		[OperationContract]
		[WebInvoke(UriTemplate = "receive", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public void ReceiveMessage(UnifiedMessage message) {
			MessagingMessage messagingMessage = new MessagingMessage(message);
			FillChannelId(message.Recipient, messagingMessage);
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
