namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: BulkEmailNotifier

	/// <summary>
	/// Bulk email message processing notifier.
	/// </summary>
	public class BulkEmailNotifier : BaseQueueMessageNotifier
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BulkEmailNotifier"/> class.
		/// </summary>
		/// <param name="userConnection"></param>
		public BulkEmailNotifier(UserConnection userConnection) : base(userConnection) {
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
		protected override string RemindingSchemaName { get => nameof(BulkEmail); }

		#endregion

		#region Methods: Private

		private string GetBulkEmailName(Guid bulkEmailId) {
			var select = new Select(UserConnection)
				.Column("Name")
				.From(nameof(BulkEmail))
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<string>();
		}

		#endregion

		#region Methods: Protected

		protected override Guid GetSubjectId(BaseTaskQueueMessage message) {
			return (message as BulkEmailQueueMessage).BulkEmailId;
		}

		protected override string GetNotificationDescription(BaseTaskQueueMessage message, string operationResult) {
			var subjectId = GetSubjectId(message);
			var bulkEmailName = GetBulkEmailName(subjectId);
			var notificationPattern = UserConnection.GetLocalizableString(nameof(BulkEmailNotifier),
				"BaseNotificationText");
			return string.Format(notificationPattern, bulkEmailName, operationResult);
		}

		#endregion

	}

	#endregion

}

