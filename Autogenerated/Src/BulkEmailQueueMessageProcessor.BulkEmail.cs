namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using global::Common.Logging;

	#region Class: BulkEmailQueueMessageProcessor

	/// <summary>
	/// Processes all messages from <see cref="BulkEmailQueue"/>.
	/// </summary>
	public class BulkEmailQueueMessageProcessor
	{

		#region Class: BaseBulkEmailQueueMessageProcessor

		private abstract class BaseBulkEmailQueueMessageProcessor: BaseQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="BaseBulkEmailQueueMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="stateManager">State manager initialized with BulkEmailId.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Provider of the notification methods.</param>
			public BaseBulkEmailQueueMessageProcessor(UserConnection userConnection, BulkEmailStateManager stateManager,
					ILog logger, BulkEmailNotifier notifier) : base(userConnection, logger, notifier) {
				StateManager = stateManager;
				InitStrategy();
			}

			#endregion

			#region Properties: Protected

			protected BulkEmailStateManager StateManager { get; set; }

			protected Dictionary<BulkEmailQueueMessageType, Func<BulkEmailQueueMessage, int>> Strategy;

			#endregion

			#region Methods: Protected

			protected void LogSkipReason(string actionName) {
				var msg = $"{GetType().Name} unable to process ({actionName}) job due to inappropriate state. Skipped.";
				Logger.Error(msg);
			}

			/// <summary>
			/// Initializes strategies.
			/// </summary>
			protected abstract void InitStrategy();

			/// <summary>
			/// Defines if email is in correct state.
			/// </summary>
			/// <param name="message">Bulk email queue message instance.</param>
			/// <returns>True if bulk email state is valid.</returns>
			protected abstract bool IsValidState();

			protected override int ProcessMessage(BaseTaskQueueMessage message) {
				var msg = message as BulkEmailQueueMessage;
				return Strategy[msg.Type].Invoke(msg);
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// Defines if class can process message of some type.
			/// </summary>
			/// <param name="message">Instance of <see cref="BulkEmailQueueMessage"/>.</param>
			/// <returns></returns>
			public bool CanProcessMessage(BulkEmailQueueMessage message) => Strategy.ContainsKey(message.Type);

			/// <summary>
			/// Executes logic.
			/// </summary>
			public void Process(BulkEmailQueueMessage message) {
				if (!IsValidState()) {
					LogSkipReason(message.Type.ToString());
					return;
				}
				base.Process(message);
			}

			#endregion

		}

		#endregion

		#region Class: AddAudienceMessageProcessor

		private class AddAudienceMessageProcessor : BaseBulkEmailQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="AddAudienceMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="stateManager">State manager initialized with BulkEmailId.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Message processing notifier.</param>
			/// <param name="repository">Audience repository of the bulk email.</param>
			public AddAudienceMessageProcessor(UserConnection userConnection, BulkEmailStateManager stateManager,
					ILog logger, BulkEmailNotifier notifier, BulkEmailAudienceRepository repository)
					: base(userConnection, stateManager, logger, notifier) {
				AudienceRepository = repository;
			}

			#endregion

			#region Properties: Protected

			protected BulkEmailAudienceRepository AudienceRepository { get; set; }

			#endregion

			#region Methods: Protected

			///<inheritdoc />
			protected override bool IsValidState() => StateManager.CanAddAudience();

			///<inheritdoc />
			protected override string GetOperationSuccessText(BaseTaskQueueMessage message, int count) {
				var text = UserConnection.GetLocalizableString(nameof(BulkEmailQueueMessageProcessor),
					"AddAudienceSuccessNotificationText");
				return string.Format(text, count);
			}

			///<inheritdoc />
			protected override string GetOperationFailedText(BaseTaskQueueMessage message) {
				return UserConnection.GetLocalizableString(nameof(BulkEmailQueueMessageProcessor),
					"AddAudienceFailedNotificationText");
			}

			/// <inheritdoc cref="BaseBulkEmailQueueMessageProcessor"/>
			/// <summary>
			/// Initializes strategy for adding audience messages' processing.
			/// </summary>
			protected override void InitStrategy() {
				Strategy = new Dictionary<BulkEmailQueueMessageType, Func<BulkEmailQueueMessage, int>> {
					[BulkEmailQueueMessageType.AddAudienceByFilter] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddAudienceByFilterQueueMessage;
						return AudienceRepository.ImportByFilter(message.EsqSerialized, message.BulkEmailId,
							message.TriggerEmailSessionId);
					}),
					[BulkEmailQueueMessageType.AddAudienceByFolderId] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddAudienceByFolderQueueMessage;
						return AudienceRepository.ImportEntityFolder(message.FolderId, message.BulkEmailId,
							message.TriggerEmailSessionId);
					}),
					[BulkEmailQueueMessageType.AddAudienceByList] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddAudienceByListQueueMessage;
						return AudienceRepository.ImportEntities(message.SourceEntityList, message.BulkEmailId,
							message.TriggerEmailSessionId);
					})
				};
			}

			#endregion

		}

		#endregion

		#region Class: RemoveAudienceMessageProcessor

		private class RemoveAudienceMessageProcessor : BaseBulkEmailQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="RemoveAudienceMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="stateManager">State manager initialized with BulkEmailId.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Message processing notifier.</param>
			/// <param name="repository">Audience repository of the bulk email.</param>
			public RemoveAudienceMessageProcessor(UserConnection userConnection, BulkEmailStateManager stateManager,
					ILog logger, BulkEmailNotifier notifier, BulkEmailAudienceRepository repository)
					: base(userConnection, stateManager, logger, notifier) {
				AudienceRepository = repository;
			}

			#endregion

			#region Properties: Protected

			protected BulkEmailAudienceRepository AudienceRepository { get; set; }

			#endregion

			#region Methods: Protected

			/// <inheritdoc cref="BaseBulkEmailQueueMessageProcessor"/>
			/// <summary>
			/// Initializes strategy for removing audience messages' processing.
			/// </summary>
			protected override void InitStrategy() {
				Strategy = new Dictionary<BulkEmailQueueMessageType, Func<BulkEmailQueueMessage, int>> {
					[BulkEmailQueueMessageType.RemoveAllAudience] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveAllAudienceQueueMessage;
						return AudienceRepository.DeleteAll(message.BulkEmailId);
					}),
					[BulkEmailQueueMessageType.RemoveAudienceByFilter] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveAudienceByFilterQueueMessage;
						return AudienceRepository.DeleteByFilter(message.EsqSerialized, message.DuplicateType,
							message.BulkEmailId);
					}),
					[BulkEmailQueueMessageType.RemoveAudienceByList] = new Func<BulkEmailQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveAudienceByListQueueMessage;
						return AudienceRepository.Delete(message.SourceEntityList, message.BulkEmailId);
					})
				};
			}

			///<inheritdoc />
			protected override bool IsValidState() => StateManager.CanRemoveAudience();

			///<inheritdoc />
			protected override string GetOperationSuccessText(BaseTaskQueueMessage message, int count) {
				var text = UserConnection.GetLocalizableString(nameof(BulkEmailQueueMessageProcessor),
					"RemoveAudienceSuccessNotificationText");
				return string.Format(text, count);
			}

			///<inheritdoc />
			protected override string GetOperationFailedText(BaseTaskQueueMessage message) {
				return UserConnection.GetLocalizableString(nameof(BulkEmailQueueMessageProcessor),
					"RemoveAudienceFailedNotificationText");
			}

			#endregion

		}

		#endregion

		#region Class: SendTriggerEmailMessageProcessor

		private class SendTriggerEmailMessageProcessor : BaseBulkEmailQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="SendTriggerEmailMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="stateManager">State manager initialized with BulkEmailId.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			public SendTriggerEmailMessageProcessor(UserConnection userConnection, BulkEmailStateManager stateManager,
				ILog logger, BulkEmailNotifier notifier)
					: base(userConnection, stateManager, logger, notifier) {
			}

			#endregion

			#region Properties: Protected

			///<inheritdoc />
			protected override bool CanNotify => false;

			#endregion

			#region Methods: Protected

			/// <inheritdoc cref="BaseBulkEmailQueueMessageProcessor"/>
			/// <summary>
			/// Initializes strategy for sending triggered email messages' processing.
			/// </summary>
			protected override void InitStrategy() {
				Strategy = new Dictionary<BulkEmailQueueMessageType, Func<BulkEmailQueueMessage, int>> {
					[BulkEmailQueueMessageType.SendTriggerEmail] = new Func<BulkEmailQueueMessage, int>((message) => {
						var service =
							ClassFactory.Get<MailingService>(new ConstructorArgument("userConnection", UserConnection));
						var result = service.SendSessionedMessage(message.BulkEmailId, message.TriggerEmailSessionId, true,
							string.Empty);
						return result.Success ? 1 : 0;
					})
				};
			}

			///<inheritdoc />
			protected override bool IsValidState() => StateManager.CanStartSending();

			#endregion

		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		public BulkEmailQueueMessageProcessor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private IEnumerable<BaseBulkEmailQueueMessageProcessor> MessageProcessorsChain {
			get {
				yield return new AddAudienceMessageProcessor(this.UserConnection, StateManager, Logger,
					BulkEmailNotifier, AudienceRepository);
				yield return new RemoveAudienceMessageProcessor(this.UserConnection, StateManager, Logger,
					BulkEmailNotifier, AudienceRepository);
				yield return new SendTriggerEmailMessageProcessor(this.UserConnection, StateManager, Logger,
					BulkEmailNotifier);
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="UserConnection"/> class.
		/// </summary>
		public virtual UserConnection UserConnection { get; set; }

		/// <summary>
		/// Logger.
		/// </summary>
		private ILog _logger;
		public ILog Logger {
			get => _logger ?? (_logger = MailingUtilities.Log);
			set => _logger = value;
		}

		/// <summary>
		/// An instance of <see cref="BulkEmailStateManager"/> class.
		/// </summary>
		private BulkEmailStateManager _stateManager;
		public virtual BulkEmailStateManager StateManager {
			get => _stateManager ?? (_stateManager = new BulkEmailStateManager(UserConnection));
			set => _stateManager = value;
		}

		/// <summary>
		/// Serves CRUD operations for audience of the bulk email.
		/// </summary>
		private BulkEmailAudienceRepository _audienceRepository;
		public BulkEmailAudienceRepository AudienceRepository {
			get => _audienceRepository ??
				(_audienceRepository = new BulkEmailAudienceRepository(UserConnection));
			set => _audienceRepository = value;
		}

		/// <summary>
		/// An instance of <see cref="BulkEmailNotifier"/> class to notify about processing.
		/// </summary>
		private BulkEmailNotifier _bulkEmailNotifier;
		public BulkEmailNotifier BulkEmailNotifier {
			get => _bulkEmailNotifier ?? (_bulkEmailNotifier = new BulkEmailNotifier(UserConnection));
			set => _bulkEmailNotifier = value;
		}

		#endregion

		#region Methods: Private

		private void InternalProcess(BulkEmailQueueMessage message, UserConnection messageUserConnection = null) {
			AudienceRepository.UserConnection = messageUserConnection ?? this.UserConnection;
			foreach (var processor in MessageProcessorsChain) {
				if (processor.CanProcessMessage(message)) {
					processor.Process(message);
					return;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Tries to process message or skipps it with detailed logging.
		/// </summary>
		/// <param name="message">Instance of <see cref="BulkEmailQueueMessage"/>.</param>
		/// <exception cref="ArgumentNullOrEmptyException">In case of <paramref name="message"/> is null.</exception>
		public virtual void Process(BulkEmailQueueMessage message) {
			message.CheckArgumentNull("message");
			StateManager.BulkEmailId = message.BulkEmailId;
			if (string.IsNullOrWhiteSpace(message.UserContext)) {
				InternalProcess(message);
			} else {
				ClassFactory.Get<ICustomContextExecutor>().Execute(message.UserContext, (userConnection) => {
					InternalProcess(message, userConnection);
				});
			}
		}

		#endregion

	}

	#endregion

}
