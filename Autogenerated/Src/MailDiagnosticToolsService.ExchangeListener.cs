namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.IO;
	using System.Net;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Web.Common;
	using IntegrationApi.Interfaces;
	using IntegrationApi.MailboxDomain.Interfaces;
	using IntegrationApi.MailboxDomain.Model;
	using EmailContract.DTO;
	using BaseResponse = Core.ServiceModelContract.BaseResponse;
	using ErrorInfo = Core.ServiceModelContract.ErrorInfo;

	#region Class: MailDiagnosticToolsService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MailDiagnosticToolsService : BaseService
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="IMailboxService"/> implementation instance.
		/// </summary>
		private readonly IMailboxService _mailboxService;

		/// <summary>
		/// <see cref="IExchangeListenerManager"/> implementation instance.
		/// </summary>
		private readonly IExchangeListenerManager _exchangeListenerManager;

		/// <summary>
		/// <see cref="IHttpWebRequestFactory"/> implementation instance.
		/// </summary>
		private readonly IHttpWebRequestFactory _requestFactory;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// ctor.
		/// </summary>
		public MailDiagnosticToolsService() : base() {
			_mailboxService =
				ClassFactory.Get<IMailboxService>(new ConstructorArgument("uc", UserConnection));
			_exchangeListenerManager = GetExchangeListenerManager();
			_requestFactory = ClassFactory.Get<IHttpWebRequestFactory>();
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Creates <see cref="ExchangeListenerManager"/> instance.
		/// </summary>
		private IExchangeListenerManager GetExchangeListenerManager() {
			var managerFactory = ClassFactory.Get<IListenerManagerFactory>();
			return managerFactory.GetExchangeListenerManager(UserConnection);
		}

		/// <summary>
		/// Get mailboxes Ids.
		/// </summary>
		/// <param name="mailboxes">List of mailboxes.</param>
		/// <returns>Mailboxes id.</returns>
		private Guid[] GetMailboxIds(List<Mailbox> mailboxes) {
			return mailboxes.Select(x => x.Id).ToArray<Guid>();
		}

		/// <summary>
		/// Get subscribers from ExchangeListener.
		/// </summary>
		/// <returns>Subscribers info from ExchangeListener.</returns>
		private Dictionary<string, string> GetSubscribers() {
			var mailboxes = _mailboxService.GetAllMailboxes();
			var subscriptionsState = _exchangeListenerManager.GetSubscriptionsStatuses(GetMailboxIds(mailboxes));
			var subscriptionsInfo = new Dictionary<string, string> ();
			mailboxes.ForEach(m => {
				if (subscriptionsState.ContainsKey(m.Id)) {
					subscriptionsInfo.Add(m.SenderEmailAddress, subscriptionsState[m.Id]);
				}
			});
			return subscriptionsInfo;
		}

		/// <summary>
		/// ExchangeListener status request.
		/// </summary>
		/// <returns><see cref="ExchangeListenerStatusResponse"/> instance.</returns>
		private ExchangeListenerStatusResponse GetExchangeListenerStatusRequestResult() {
			string serviceUri = ExchangeListenerActions.GetActionUrl(UserConnection, ExchangeListenerActions.Status);
			WebRequest request = _requestFactory.Create(serviceUri);
			request.ContentType = "application/json; charset=utf-8";
			request.Timeout = 5 * 60 * 1000;
			WebResponse webResponse = request.GetResponse();
			using (Stream dataStream = webResponse.GetResponseStream()) {
				StreamReader reader = new StreamReader(dataStream);
				return Json.Deserialize<ExchangeListenerStatusResponse>(reader.ReadToEnd());
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates mailbox settings.
		/// </summary>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="sendTestMessage">Send test emails allowed for mailbox.</param>
		/// <returns>Error message if it occurs.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse ValidateMailbox(string senderEmailAddress, bool sendTestMessage = false) {
			var response = new BaseResponse {
				Success = true,
				ErrorInfo = new ErrorInfo()
			};
			try {
				Mailbox mailbox = _mailboxService.GetMailboxBySenderEmailAddress(senderEmailAddress);
				mailbox.SetAllowEmailSend(sendTestMessage);
				mailbox.SetAllowSynchronization(true);
				CredentialsValidationInfo validationInfo = mailbox.Validate(UserConnection);
				if (!validationInfo.IsValid) {
					response.Success = false;
					response.ErrorInfo.Message = validationInfo.Message;
				}
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo.Message = e.Message;
				response.ErrorInfo.StackTrace = e.StackTrace;
			}
			return response;
		}

		/// <summary>
		/// Checks that ExchangeListener service avaliable.
		/// </summary>
		/// <returns><c>True</c> if exchange listeners service avaliable. Otherwise returns <c>false</c>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		public bool GetIsExchangeListenerAvaliable() {
			return _exchangeListenerManager.GetIsServiceAvaliable();
		}

		/// <summary>
		/// Get ExchangeListener status info.
		/// </summary>
		/// <returns><see cref="DiagnosticResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		public DiagnosticResponse GetExchangeListenerStatus() {
			var response = new DiagnosticResponse {
				Success = true,
				ErrorInfo = new ErrorInfo()
			};
			try {
				var exchangeListenerStatus = GetExchangeListenerStatusRequestResult();
				response.ResultValues = new Dictionary<string, string> {
					{ "Status", exchangeListenerStatus.ServiceStatus },
					{ "Version", exchangeListenerStatus.Version }
				};
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo.Message = e.Message;
				response.ErrorInfo.StackTrace = e.StackTrace;
			}
			return response;
		}

		/// <summary>
		/// Get ExchangeListener subscribers info.
		/// </summary>
		/// <returns><see cref="DiagnosticResponse"/> instance.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
		public DiagnosticResponse GetSubscribersInfo() {
			try {
				return new DiagnosticResponse {
					Success = true,
					ResultValues = GetSubscribers()
				};
			} catch (Exception e) {
				throw new WebFaultException<DiagnosticResponse>(
					new DiagnosticResponse {
						Success = false,
						ErrorInfo = new ErrorInfo {
							Message = e.Message,
							StackTrace = e.StackTrace
						}
					},
					HttpStatusCode.InternalServerError);
			}
		}

		#endregion

		#region Class: DiagnosticResponse

		/// <summary>
		/// Response to bpmstudio.
		/// </summary>
		[DataContract]
		public class DiagnosticResponse : BaseResponse {
			/// <summary>
			/// Subscribers result.
			/// </summary>
			[DataMember(Name = "result")]
			public Dictionary<string, string> ResultValues {
				get;
				set;
			}
		}

		#endregion

		#region Class: ExchangeListenerStatusResponse

		/// <summary>
		/// ExchangeListener status info.
		/// </summary>
		private class ExchangeListenerStatusResponse {
			/// <summary>
			/// Service work status.
			/// </summary>
			public string ServiceStatus {
				get;
				set;
			}
			/// <summary>
			/// Service version.
			/// </summary>
			public string Version {
				get;
				set;
			}
		}

		#endregion

	}

	#endregion
}
