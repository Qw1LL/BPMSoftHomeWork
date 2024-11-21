namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: BaseQueueMessageNotifier

	/// <summary>
	/// Queue message processing notifier.
	/// </summary>
	public abstract class BaseQueueMessageNotifier
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BaseQueueMessageNotifier"/> class.
		/// </summary>
		/// <param name="userConnection"></param>
		public BaseQueueMessageNotifier(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Name of the current notifier.
		/// </summary>
		protected abstract string NotifierName { get; }

		/// <summary>
		/// Name of the reminding entity schema.
		/// </summary>
		protected abstract string RemindingSchemaName { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="UserConnection"/> class.
		/// </summary>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// An instance of <see cref="RemindingUtilities"/> class to create remindings.
		/// </summary>
		private RemindingUtilities _remindingUtilities;
		public RemindingUtilities RemindingUtilities {
			get => _remindingUtilities ?? (_remindingUtilities = ClassFactory.Get<RemindingUtilities>());
			set => _remindingUtilities = value;
		}

		#endregion

		#region Methods: Private

		private void CreateReminding(Guid subjectId, Guid contactId, string description) {
			var entitySchemaUId = UserConnection.EntitySchemaManager.GetItemByName(RemindingSchemaName).UId;
			var currentContactId = UserConnection.CurrentUser.ContactId;
			var remindingConfig = new RemindingConfig(entitySchemaUId) {
				AuthorId = currentContactId,
				ContactId = contactId,
				SubjectId = subjectId,
				Description = description
			};
			RemindingUtilities.CreateReminding(UserConnection, remindingConfig);
		}

		#endregion

		#region Methods: Protected

		protected abstract Guid GetSubjectId(BaseTaskQueueMessage message);

		protected abstract string GetNotificationDescription(BaseTaskQueueMessage message, string operationResult);

		protected virtual void NotifyWithReminding(BaseTaskQueueMessage message, string operationResult) {
			var subjectId = GetSubjectId(message);
			var description = GetNotificationDescription(message, operationResult);
			CreateReminding(subjectId, message.UserId, description);
		}

		protected virtual void SendWebSocketMessage(BaseTaskQueueMessage message) {
			var socketMessage = message.ToString();
			MsgChannelUtilities.PostMessageToAll(NotifierName, socketMessage);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Notifies about queue message processing result.
		/// </summary>
		/// <param name="message">Instance of <see cref="BaseTaskQueueMessage"/> for notification.</param>
		/// <param name="result">Processed operation result text.</param>
		public virtual void Notify(BaseTaskQueueMessage message, QueueMessageProcessResult result) {
			if (!result.Silent) {
				NotifyWithReminding(message, result.OperationResult);
			}
			SendWebSocketMessage(message);
		}

		#endregion

	}

	#endregion

}

