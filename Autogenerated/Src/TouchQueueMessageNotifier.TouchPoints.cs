namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;

	#region Class: TouchQueueMessageNotifier

	/// <summary>
	/// Class to notify about touch queue message processing results.
	/// </summary>
	public class TouchQueueMessageNotifier : BaseQueueMessageNotifier
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="TouchQueueMessageNotifier"/> class.
		/// </summary>
		/// <param name="userConnection"></param>
		public TouchQueueMessageNotifier(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Protected: Public

		/// <inheritdoc/>
		protected override string NotifierName => "TouchPoints";

		/// <inheritdoc/>
		protected override string RemindingSchemaName => nameof(Touch);

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		protected override Guid GetSubjectId(BaseTaskQueueMessage message) {
			return Guid.Empty;
		}

		/// <inheritdoc/>
		protected override string GetNotificationDescription(BaseTaskQueueMessage message, string operationResult) {
			return operationResult;
		}

		#endregion

	}

	#endregion

}

