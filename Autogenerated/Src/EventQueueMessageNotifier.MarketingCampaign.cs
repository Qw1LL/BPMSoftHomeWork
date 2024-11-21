namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: EventQueueMessageNotifier

	/// <summary>
	/// Event message processing notifier.
	/// </summary>
	public class EventQueueMessageNotifier : BaseQueueMessageNotifier
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="EventQueueMessageNotifier"/> class.
		/// </summary>
		/// <param name="userConnection"></param>
		public EventQueueMessageNotifier(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Name of the current notifier.
		/// </summary>
		protected override string NotifierName { get => GetType().Name; }

		/// <summary>
		/// Name of the reminding entity schema.
		/// </summary>
		protected override string RemindingSchemaName { get => nameof(Event); }

		#endregion

		#region Methods: Private

		private string GetEventName(Guid eventId) {
			var select = new Select(UserConnection)
				.Column("Name")
				.From(nameof(Event))
				.Where("Id").IsEqual(Column.Parameter(eventId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<string>();
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override Guid GetSubjectId(BaseTaskQueueMessage message) {
			return (message as EventQueueMessage).EventId;
		}

		/// <inheritdoc />
		protected override string GetNotificationDescription(BaseTaskQueueMessage message, string operationResult) {
			var subjectId = GetSubjectId(message);
			var eventName = GetEventName(subjectId);
			var notificationPattern = UserConnection.GetLocalizableString(nameof(EventQueueMessageNotifier),
				"BaseNotificationText");
			return string.Format(notificationPattern, eventName, operationResult);
		}

		#endregion

	}

	#endregion

}

