namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using Newtonsoft.Json;
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

	#region Class: OmnichannelOperatorService

	/// <summary>
	/// Provides a service for working with omnichannel operators.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class OmnichannelOperatorService : BaseService
	{
		#region Class: OmnichannelOperatorStateResponse

		/// <summary>
		/// Represents operator state response.
		/// </summary>
		[DataContract]
		public class OmnichannelOperatorStateResponse : ConfigurationServiceResponse
		{
			[DataMember]
			public string CurrentStateCode {
				get; set;
			}
		}

		#endregion

		#region Class: OmnichannelOperatorCacheResponse

		/// <summary>
		/// Represents operator cache response.
		/// </summary>
		[DataContract]
		public class OmnichannelOperatorCacheResponse
		{
			[DataMember]
			public Guid UserId { get; set; }

			[DataMember]
			public int ActiveChatsCount { get; set; }

			[DataMember]
			public List<Guid> DirectedChats { get; set; }

			[DataMember]
			public string LastChatAcceptedDate { get; set; }

			[DataMember]
			public string CurrentStateCode { get; set; }
		}

		#endregion

		#region Fields: Private

		private OperatorManager _operatorManager;
		private OperatorSessionRepository _operatorSessionRepository;

		#endregion

		#region Properties: Private

		private OperatorManager OperatorManager {
			get {
				return _operatorManager = _operatorManager ?? new OperatorManager(UserConnection);
			}
		}

		private OperatorSessionRepository OperatorSessionRepository {
			get {
				return _operatorSessionRepository = _operatorSessionRepository ?? new OperatorSessionRepository(UserConnection);
			}
		}

		#endregion

		#region Methods: Private

		private void QueuesDistribute(string newState, Guid currentUserId) {
			if (newState == OmnichannelMessagingConsts.OperatorState.Active.Code) {
				var queueDistribution = new ChatQueueDistributor(UserConnection);
				var chatQueueIds = OperatorManager.GetQueuesByOperator(currentUserId);
				foreach (var chatQueueId in chatQueueIds) {
					queueDistribution.Distribute(chatQueueId);
				}
			}
		}

		#endregion
		
		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ChatTransferService"/>.
		/// </summary>
		public OmnichannelOperatorService() : base() {
		}

		/// <summary>
		/// Initializes new instance of <see cref="ChatTransferService"/>.
		/// <param name="userConnection">User connection.</param>
		/// </summary>
		public OmnichannelOperatorService(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Getting operator status of the current user.
		/// </summary>
		/// <returns><see cref="OmnichannelOperatorStateResponse"/> operator state for current user.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelOperatorStateResponse GetCurrentState() {
			var response = new OmnichannelOperatorStateResponse();
			try {
				var currentUserId = UserConnection.CurrentUser.Id;
				var userIsOperator = OperatorManager.IsOperatorExistsInChatQueue(currentUserId);
				if (userIsOperator) {
					response.CurrentStateCode = OperatorManager.GetOperatorStateCode(currentUserId);
				}
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Change the operator status of the current user.
		/// </summary>
		/// <param name="newState">New state code for operator.</param>
		/// <returns><see cref="OmnichannelOperatorStateResponse"/> new operator state for current user.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public OmnichannelOperatorStateResponse ChangeState(string newState) {
			var response = new OmnichannelOperatorStateResponse();
			try {
				var currentUserId = UserConnection.CurrentUser.Id;
				OperatorManager.ChangeOperatorState(currentUserId, newState);
				response.CurrentStateCode = newState;
				QueuesDistribute(newState, currentUserId);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Gets active cached operators info.
		/// </summary>
		/// <returns>Cached operators.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public List<OmnichannelOperatorCacheResponse> GetActiveOperatorsCache() {
			var operators = OperatorSessionRepository.GetAllActiveOperators();
			var result = new List<OmnichannelOperatorCacheResponse>();
			foreach (var op in operators) {
				result.Add(new OmnichannelOperatorCacheResponse() {
					ActiveChatsCount = op.ActiveChatsCount,
					CurrentStateCode = op.State.Code,
					DirectedChats = op.DirectedChats,
					UserId = op.UserId,
					LastChatAcceptedDate = op.LastChatAcceptedDate.ToString()
				});
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
	ResponseFormat = WebMessageFormat.Json)]
		public string GetOmnichatCacheDebugData() {
			StringBuilder result = new StringBuilder();
			var keys = new[] { "OmnichannelQueueOperatorRoutingRules", "OmnichannelContactsByChannelAndIdentifier", "TelegramChannelsList"};
			foreach (var key in keys) {
				var value = UserConnection.ApplicationCache[key];
				result.Append($"{key}: ").Append(JsonConvert.SerializeObject(value));
			}
			return result.ToString();
		}

		#endregion

	}

	#endregion

}
