namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Tasks;

	#region Class: BulkEmailFacade

	/// <summary>
	/// Manages command processing for bulk emails.
	/// </summary>
	public class BulkEmailFacade
	{

		#region Fields: Private

		private int _fastTaskAudienceLimit = 100;

		private int _qrtzJobPeriod = 60;

		#endregion

		#region Constructors: Public

		public BulkEmailFacade(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of <see cref="BulkEmailStateManager"/> class.
		/// </summary>
		private BulkEmailStateManager _stateManager;
		public BulkEmailStateManager StateManager {
			get => _stateManager ?? (_stateManager = new BulkEmailStateManager(UserConnection));
			set => _stateManager = value;
		}

		/// <summary>
		/// An instance of <see cref="BulkEmailQueueManager"/> class.
		/// </summary>
		private BulkEmailQueueManager _queueManager;
		public BulkEmailQueueManager QueueManager {
			get => _queueManager ?? (_queueManager = new BulkEmailQueueManager(UserConnection));
			set => _queueManager = value;
		}

		/// <summary>
		/// Instance of BulkEmailEventLogger. 
		/// </summary>
		private BulkEmailEventLogger _bulkEmailEventLogger;
		public BulkEmailEventLogger BulkEmailEventLogger =>
			_bulkEmailEventLogger ?? (_bulkEmailEventLogger = new BulkEmailEventLogger(UserConnection));

		#endregion

		#region Methods: Private

		private void ExtendMessagesWithUserInfo(IEnumerable<BulkEmailQueueMessage> messages) {
			var userId = UserConnection.CurrentUser.ContactId;
			var userContext = ClassFactory.Get<ICustomContextExecutor>().GetUserContext(UserConnection);
			foreach (var message in messages) {
				message.UserId = userId;
				message.UserContext = userContext;
			}
		}

		private IEnumerable<BulkEmailQueueMessage> GetMessagesToAdd(BulkEmailAudienceImportModel audienceModel) {
			var messages = default(IEnumerable<BulkEmailQueueMessage>);
			var bulkEmailId = audienceModel.BulkEmailId;
			switch (audienceModel.SourceType) {
				case AudienceSourceType.Entity:
					messages = AddAudienceByListQueueMessage.Create(bulkEmailId, audienceModel.SourceCollection);
					break;
				case AudienceSourceType.Folder:
					var folderId = audienceModel.SourceCollection.FirstOrDefault();
					messages = new[] {
						new AddAudienceByFolderQueueMessage(bulkEmailId, folderId) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
				case AudienceSourceType.Filter:
					messages = new[] {
						new AddAudienceByFilterQueueMessage(bulkEmailId, audienceModel.EsqSerialized) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
			}
			ExtendMessagesWithUserInfo(messages);
			return messages;
		}

		private IEnumerable<BulkEmailQueueMessage> GetMessagesToRemove(
				BulkEmailAudienceRemoveModel audienceModel) {
			var messages = default(IEnumerable<BulkEmailQueueMessage>);
			var bulkEmailId = audienceModel.BulkEmailId;
			switch (audienceModel.SourceType) {
				case AudienceSourceType.Audience:
					messages = new[] {
						new RemoveAllAudienceQueueMessage(bulkEmailId) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
				case AudienceSourceType.Entity:
					messages = RemoveAudienceByListQueueMessage.Create(bulkEmailId,
						audienceModel.SourceCollection);
					break;
				case AudienceSourceType.Filter:
					messages = new[] {
						new RemoveAudienceByFilterQueueMessage(bulkEmailId, audienceModel.EsqSerialized,
								audienceModel.DuplicateType) {
							EstimatedRowsCount = audienceModel.EstimatedEntitiesCount
						}
					};
					break;
			}
			ExtendMessagesWithUserInfo(messages);
			return messages;
		}

		private string GetLczStringValue(string lczName) {
			var localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, GetType().Name, localizableStringName);
			var value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private bool CanStartFastTask(BulkEmailAudienceModel model) {
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

		private void ProcessMessages(IEnumerable<BulkEmailQueueMessage> messages,
				BulkEmailAudienceModel audienceModel) {
			if (!messages.Any()) {
				return;
			}
			var message = messages.FirstOrDefault();
			if (CanStartFastTask(audienceModel)) {
				Task.StartNewWithUserConnection<BulkEmailAudienceTask, BulkEmailQueueMessage>(message);
			} else {
				QueueManager.Enqueue(messages);
			}
			var estimatedRowsCount = messages.Sum(m => m.EstimatedRowsCount);
			BulkEmailEventLogger.LogInfo(message.BulkEmailId, DateTime.UtcNow, GetLczStringValue("TaskCreated"),
				GetLczStringValue("TaskCreatedDescription"), UserConnection.CurrentUser.ContactId,
				message.Type, estimatedRowsCount);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Fills audience of the bulk email.
		/// </summary>
		/// <param name="audienceModel">Model of audience of the bulk email.
		/// Instance of <see cref="BulkEmailAudienceImportModel"/> class.</param>
		public void AddAudience(BulkEmailAudienceImportModel audienceModel) {
			AddAudience(audienceModel, default(Guid));
		}

		/// <summary>
		/// Fills audience of the bulk email.
		/// </summary>
		/// <param name="audienceModel">Model of audience of the bulk email.
		/// Instance of <see cref="BulkEmailAudienceImportModel"/> class.</param>
		/// <param name="sessionId">Unique identifier of trigger email session.</param>
		public void AddAudience(BulkEmailAudienceImportModel audienceModel, Guid sessionId) {
			StateManager.BulkEmailId = audienceModel.BulkEmailId;
			if (!StateManager.TrySetAudienceSchema(audienceModel.AudienceSchemaId)) {
				throw new Exception("Unable to import audience due to inappropriate " +
					$"audience schema {audienceModel.AudienceSchemaId} for BulkEmail {audienceModel.BulkEmailId}.");
			}
			if (!StateManager.CanAddAudience()) {
				throw new Exception("Unable to import audience due to inappropriate status " +
					$"of BulkEmail {audienceModel.BulkEmailId}.");
			}
			var messages = GetMessagesToAdd(audienceModel);
			if (sessionId.IsNotEmpty()) {
				messages.ForEach(m => m.TriggerEmailSessionId = sessionId);
			}
			ProcessMessages(messages, audienceModel);
		}

		/// <summary>
		/// Creates message for sending of the trigger email.
		/// </summary>
		/// <param name="bulkEmailId">Identifier of the bulk email.</param>
		/// <param name="sessionId">Identifier of the sending session.</param>
		public void SendTriggerEmail(Guid bulkEmailId, Guid sessionId) {
			StateManager.BulkEmailId = bulkEmailId;
			var message = new SendTriggerEmailQueueMessage(bulkEmailId) {
				TriggerEmailSessionId = sessionId,
				MaxRetryCount = 5
			};
			QueueManager.Enqueue(new[] { message });
		}

		/// <summary>
		/// Removes audience from the bulk email.
		/// </summary>
		/// <param name="audienceModel">Model of audience of the bulk email.
		/// Instance of <see cref="BulkEmailAudienceRemoveModel"/> class.</param>
		public void RemoveAudience(BulkEmailAudienceRemoveModel audienceModel) {
			StateManager.BulkEmailId = audienceModel.BulkEmailId;
			if (!StateManager.CanRemoveAudience()) {
				throw new Exception(GetLczStringValue("AudienceRemoveException"));
			}
			var messages = GetMessagesToRemove(audienceModel);
			ProcessMessages(messages, audienceModel);
		}

		/// <summary>
		/// Checks tasks in bulk email queue.
		/// </summary>
		/// <param name="bulkEmailId">Identifier of the bulk email.</param>
		/// <returns>True when queue contains tasks for bulk email.</returns>
		public bool HasIncompleteTask(Guid bulkEmailId) {
			return QueueManager.CheckMessagesExist(bulkEmailId);
		}

		/// <summary>
		/// Returns estimation for current bulk email queue tasks execution.
		/// </summary>
		/// <param name="bulkEmailId">Identifier of the bulk email.</param>
		/// <returns>Estimation model of last task execution.</returns>
		public BulkEmailQueueEstimation EstimateTaskExecution(Guid bulkEmailId) {
			var estimatedData = QueueManager.GetEstimationForRecord(bulkEmailId);
			return new BulkEmailQueueEstimation(bulkEmailId) { 
				Position = estimatedData.position,
				EstimatedTime = estimatedData.eta != 0
					? _qrtzJobPeriod + estimatedData.eta
					: 0
			};
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceTask

	/// <summary>
	/// Background task for audience processing.
	/// </summary>
	public class BulkEmailAudienceTask : IBackgroundTask<BulkEmailQueueMessage>, IUserConnectionRequired
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Methods: Public

		public void Run(BulkEmailQueueMessage message) {
			if (message == null) {
				return;
			}
			var messageProcessor = new BulkEmailQueueMessageProcessor(_userConnection);
			messageProcessor.Process(message);
		}

		public void SetUserConnection(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailQueueEstimation

	/// <summary>
	/// Class to represent bulk email queue task execution.
	/// </summary>
	public class BulkEmailQueueEstimation
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BulkEmailQueueEstimation"/>.
		/// </summary>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		public BulkEmailQueueEstimation(Guid bulkEmailId) {
			BulkEmailId = bulkEmailId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Bulk email unique identifier.
		/// </summary>
		public Guid BulkEmailId { get; }

		/// <summary>
		/// Position of last message in queue for specified bulk email.
		/// </summary>
		public int Position { get; set; }

		/// <summary>
		/// Estimated time of last queued task execution for specified bulk email.
		/// </summary>
		public int EstimatedTime { get; set; }

		#endregion

	}

	#endregion

}

