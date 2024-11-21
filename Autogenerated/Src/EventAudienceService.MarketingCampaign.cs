namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;
	using System.Linq;
	using BPMSoft.Core.Tasks;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core;

	#region Class: EventAudienceService

	/// <summary>
	/// Manages audience of events.
	/// </summary>
	[ServiceContract(Name = "EventAudience")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EventAudienceService : BaseService
	{

		#region Fields: Private

		private int _fastTaskAudienceLimit = 20;

		private int _qrtzJobPeriod = 60;

		#endregion

		#region Constructors: Public

		public EventAudienceService() : base() {
		}

		public EventAudienceService(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of <see cref="MarketingEventQueueManager"/> class.
		/// </summary>
		private MarketingEventQueueManager _queueManager;
		public MarketingEventQueueManager QueueManager {
			get => _queueManager ?? (_queueManager = new MarketingEventQueueManager(UserConnection));
			set => _queueManager = value;
		}

		#endregion

		#region Methods: Private

		private void ExtendMessagesWithUserInfo(IEnumerable<EventQueueMessage> messages) {
			var userId = UserConnection.CurrentUser.ContactId;
			var userContext = ClassFactory.Get<ICustomContextExecutor>().GetUserContext(UserConnection);
			foreach (var message in messages) {
				message.UserId = userId;
				message.UserContext = userContext;
			}
		}

		private IEnumerable<EventQueueMessage> GetMessagesToAdd(EventAudienceModel audienceModel) {
			var messages = default(IEnumerable<EventQueueMessage>);
			var eventId = audienceModel.EventId;
			switch (audienceModel.SourceType) {
				case AudienceSourceType.Entity:
					messages = AddEventAudienceByListQueueMessage.Create(eventId, audienceModel.SourceCollection);
					break;
				case AudienceSourceType.Folder:
					var folderId = audienceModel.SourceCollection.FirstOrDefault();
					messages = new[] {
						new AddEventAudienceByFolderQueueMessage(eventId, folderId) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
				case AudienceSourceType.Filter:
					messages = new[] {
						new AddEventAudienceByFilterQueueMessage(eventId, audienceModel.EsqSerialized) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
			}
			ExtendMessagesWithUserInfo(messages);
			return messages;
		}

		private void AddAudience(EventAudienceModel audienceModel) {
			var messages = GetMessagesToAdd(audienceModel);
			ProcessMessages(messages, audienceModel);
		}

		private IEnumerable<EventQueueMessage> GetMessagesToRemove(EventAudienceModel audienceModel) {
			var messages = default(IEnumerable<EventQueueMessage>);
			var eventId = audienceModel.EventId;
			switch (audienceModel.SourceType) {
				case AudienceSourceType.Audience:
					messages = new[] {
						new RemoveAllEventAudienceQueueMessage(eventId) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
				case AudienceSourceType.Entity:
					messages = RemoveEventAudienceByListQueueMessage.Create(eventId, audienceModel.SourceCollection);
					break;
				case AudienceSourceType.Filter:
					messages = new[] {
						new RemoveEventAudienceByFilterQueueMessage(eventId, audienceModel.EsqSerialized) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
			}
			ExtendMessagesWithUserInfo(messages);
			return messages;
		}

		private void RemoveAudience(EventAudienceModel audienceModel) {
			var messages = GetMessagesToRemove(audienceModel);
			ProcessMessages(messages, audienceModel);
		}

		private bool CanStartFastTask(EventAudienceModel model) {
			switch (model.SourceType) {
				case AudienceSourceType.Entity:
					return model.SourceCollection.Count <= _fastTaskAudienceLimit;
				case AudienceSourceType.Folder:
				case AudienceSourceType.Filter:
				case AudienceSourceType.Audience:
					return model.EstimatedEntitiesCount > 0 && model.EstimatedEntitiesCount <= _fastTaskAudienceLimit;
				default:
					return false;
			}
		}

		private void ProcessMessages(IEnumerable<EventQueueMessage> messages, EventAudienceModel audienceModel) {
			if (!messages.Any()) {
				return;
			}
			var message = messages.FirstOrDefault();
			if (CanStartFastTask(audienceModel)) {
				Task.StartNewWithUserConnection<EventAudienceTask, EventQueueMessage>(message);
			} else {
				QueueManager.Enqueue(messages);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Imports event audience by the list of entities or folders.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AudienceServiceResponse Import(EventAudienceModel audienceModel) {
			try {
				AddAudience(audienceModel);
			} catch (Exception e) {
				return new AudienceServiceResponse {
					Success = false,
					Message = e.Message
				};
			}
			return new AudienceServiceResponse();
		}

		/// <summary>
		/// Removes event audience by the list of entities or folders.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AudienceServiceResponse Remove(EventAudienceModel audienceModel) {
			try {
				RemoveAudience(audienceModel);
			} catch (Exception e) {
				return new AudienceServiceResponse {
					Success = false,
					Message = e.Message
				};
			}
			return new AudienceServiceResponse();
		}

		/// <summary>
		/// Estimates event queue tasks' execution for specified event.
		/// </summary>
		/// <param name="eventId">Unique identifier of the event.</param>
		/// <returns>Response with estimated tasks.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public QueueTaskEstimationResponse EstimateTaskExecution(Guid eventId) {
			var estimatedData = QueueManager.GetEstimationForRecord(eventId);
			return new QueueTaskEstimationResponse {
				Position = estimatedData.position,
				EstimatedTime = estimatedData.eta != 0
					? _qrtzJobPeriod + estimatedData.eta
					: 0
			};
		}

		#endregion

	}

	#endregion

	#region Class: EventAudienceModel

	/// <summary>
	/// Data model for <see cref="EventAudienceModel"/>.
	/// </summary>
	[DataContract]
	public class EventAudienceModel : BaseAudienceServiceDataModel
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of event.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid EventId { get; set; }

		#endregion

	}

	#endregion

	#region Class: EventAudienceTask

	/// <summary>
	/// Background task for audience processing.
	/// </summary>
	public class EventAudienceTask : IBackgroundTask<EventQueueMessage>, IUserConnectionRequired
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Public

		public void Run(EventQueueMessage message) {
			if (message == null) {
				return;
			}
			var messageProcessor = new EventQueueMessageProcessor(_userConnection);
			messageProcessor.Process(message);
		}

		public void SetUserConnection(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

	}

	#endregion

}

