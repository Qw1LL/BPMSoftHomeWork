namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using global::Common.Logging;

	#region Class: EventQueueMessageProcessor

	/// <summary>
	/// Processes all messages from <see cref="EventQueue"/>.
	/// </summary>
	public class EventQueueMessageProcessor
	{

		#region Class: BaseEventQueueMessageProcessor

		private abstract class BaseEventQueueMessageProcessor : BaseQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="BaseEventQueueMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Provider of the notification methods.</param>
			public BaseEventQueueMessageProcessor(UserConnection userConnection, ILog logger,
					EventQueueMessageNotifier notifier) : base(userConnection, logger, notifier) {
				InitStrategy();
			}

			#endregion

			#region Properties: Protected

			protected Dictionary<EventQueueMessageType, Func<EventQueueMessage, int>> Strategy;

			#endregion

			#region Methods: Protected

			/// <summary>
			/// Initializes strategies.
			/// </summary>
			protected abstract void InitStrategy();

			protected override int ProcessMessage(BaseTaskQueueMessage message) {
				var msg = message as EventQueueMessage;
				return Strategy[msg.Type].Invoke(msg);
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// Defines if class can process message of some type.
			/// </summary>
			/// <param name="message">Instance of <see cref="EventQueueMessage"/>.</param>
			/// <returns></returns>
			public bool CanProcessMessage(EventQueueMessage message) => Strategy.ContainsKey(message.Type);

			#endregion

		}

		#endregion

		#region Class: AddAudienceMessageProcessor

		private class AddAudienceMessageProcessor : BaseEventQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="AddAudienceMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Message processing notifier.</param>
			/// <param name="repository">Audience repository of the event.</param>
			public AddAudienceMessageProcessor(UserConnection userConnection, ILog logger,
					EventQueueMessageNotifier notifier, EventAudienceRepository repository)
					: base(userConnection, logger, notifier) {
				AudienceRepository = repository;
			}

			#endregion

			#region Properties: Protected

			protected EventAudienceRepository AudienceRepository { get; set; }

			#endregion

			#region Methods: Protected

			///<inheritdoc />
			protected override string GetOperationSuccessText(BaseTaskQueueMessage message, int count) {
				var text = UserConnection.GetLocalizableString(nameof(EventQueueMessageProcessor),
					"AddAudienceSuccessNotificationText");
				return string.Format(text, count);
			}

			///<inheritdoc />
			protected override string GetOperationFailedText(BaseTaskQueueMessage message) {
				return UserConnection.GetLocalizableString(nameof(EventQueueMessageProcessor),
					"AddAudienceFailedNotificationText");
			}

			/// <inheritdoc cref="BaseEventQueueMessageProcessor"/>
			/// <summary>
			/// Initializes strategy for adding audience messages' processing.
			/// </summary>
			protected override void InitStrategy() {
				Strategy = new Dictionary<EventQueueMessageType, Func<EventQueueMessage, int>> {
					[EventQueueMessageType.AddAudienceByFilter] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddEventAudienceByFilterQueueMessage;
						return AudienceRepository.ImportByFilter(message.EsqSerialized, message.EventId);
					}),
					[EventQueueMessageType.AddAudienceByFolderId] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddEventAudienceByFolderQueueMessage;
						return AudienceRepository.ImportByFolder(message.FolderId, message.EventId);
					}),
					[EventQueueMessageType.AddAudienceByList] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as AddEventAudienceByListQueueMessage;
						return AudienceRepository.ImportById(message.SourceEntityList, message.EventId);
					})
				};
			}

			#endregion

		}

		#endregion

		#region Class: RemoveAudienceMessageProcessor

		private class RemoveAudienceMessageProcessor : BaseEventQueueMessageProcessor
		{

			#region Constructors: Public

			/// <summary>
			/// Initializes a new instance of the <see cref="RemoveAudienceMessageProcessor"/> class.
			/// </summary>
			/// <param name="userConnection">Current user connection.</param>
			/// <param name="logger">Provider of the logging methods.</param>
			/// <param name="notifier">Message processing notifier.</param>
			/// <param name="repository">Audience repository of the event.</param>
			public RemoveAudienceMessageProcessor(UserConnection userConnection, ILog logger,
					EventQueueMessageNotifier notifier, EventAudienceRepository repository)
					: base(userConnection, logger, notifier) {
				AudienceRepository = repository;
			}

			#endregion

			#region Properties: Protected

			protected EventAudienceRepository AudienceRepository { get; set; }

			#endregion

			#region Methods: Protected

			/// <inheritdoc cref="BaseEventQueueMessageProcessor"/>
			/// <summary>
			/// Initializes strategy for removing audience messages' processing.
			/// </summary>
			protected override void InitStrategy() {
				Strategy = new Dictionary<EventQueueMessageType, Func<EventQueueMessage, int>> {
					[EventQueueMessageType.RemoveAllAudience] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveAllEventAudienceQueueMessage;
						return AudienceRepository.DeleteAll(message.EventId);
					}),
					[EventQueueMessageType.RemoveAudienceByFilter] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveEventAudienceByFilterQueueMessage;
						return AudienceRepository.DeleteByFilter(message.EsqSerialized, message.EventId);
					}),
					[EventQueueMessageType.RemoveAudienceByList] = new Func<EventQueueMessage, int>((baseMessage) => {
						var message = baseMessage as RemoveEventAudienceByListQueueMessage;
						return AudienceRepository.DeleteById(message.SourceEntityList, message.EventId);
					})
				};
			}

			///<inheritdoc />
			protected override string GetOperationSuccessText(BaseTaskQueueMessage message, int count) {
				var text = UserConnection.GetLocalizableString(nameof(EventQueueMessageProcessor),
					"RemoveAudienceSuccessNotificationText");
				return string.Format(text, count);
			}

			///<inheritdoc />
			protected override string GetOperationFailedText(BaseTaskQueueMessage message) {
				return UserConnection.GetLocalizableString(nameof(EventQueueMessageProcessor),
					"RemoveAudienceFailedNotificationText");
			}

			#endregion

		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		public EventQueueMessageProcessor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private IEnumerable<BaseEventQueueMessageProcessor> MessageProcessorsChain {
			get {
				yield return new AddAudienceMessageProcessor(this.UserConnection, Logger, EventQueueNotifier,
					AudienceRepository);
				yield return new RemoveAudienceMessageProcessor(this.UserConnection, Logger, EventQueueNotifier,
					AudienceRepository);
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
			get => _logger ?? (_logger = LogManager.GetLogger("EventLogger"));
			set => _logger = value;
		}

		/// <summary>
		/// Serves CRUD operations for audience of the event.
		/// </summary>
		private EventAudienceRepository _audienceRepository;
		public EventAudienceRepository AudienceRepository {
			get => _audienceRepository ??
				(_audienceRepository = new EventAudienceRepository(UserConnection));
			set => _audienceRepository = value;
		}

		/// <summary>
		/// An instance of <see cref="EventQueueMessageNotifier"/> class to notify about processing.
		/// </summary>
		private EventQueueMessageNotifier _eventQueueNotifier;
		public EventQueueMessageNotifier EventQueueNotifier {
			get => _eventQueueNotifier ?? (_eventQueueNotifier = new EventQueueMessageNotifier(UserConnection));
			set => _eventQueueNotifier = value;
		}

		#endregion

		#region Methods: Private

		private void InternalProcess(EventQueueMessage message, UserConnection messageUserConnection = null) {
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
		/// <param name="message">Instance of <see cref="EventQueueMessage"/>.</param>
		/// <exception cref="ArgumentNullOrEmptyException">In case of <paramref name="message"/> is null.</exception>
		public virtual void Process(EventQueueMessage message) {
			message.CheckArgumentNull("message");
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

