namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class : AsyncAddingFolderQueueItemsExecutor

	/// <summary>
	/// Represents a asynchronous adding queue items for selected groups job.
	/// </summary>
	public class AsyncAddingFolderQueueItemsExecutor : IJobExecutor {

		#region Methods : Public

		/// <summary>
		/// Execute job of adding queue items for selected groups.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="parameters">Parameters.</param>
		public virtual void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			if (parameters == null) {
				throw new ArgumentNullOrEmptyException("parameters can't be null");
			}
			string entitySchemaName = parameters.GetValue("entitySchemaName", string.Empty);
			List<object> folderIds = parameters.GetValue<List<object>>("folderIds", null);
			Guid queueId = parameters.GetValue("queueId", Guid.Empty);
			var folderUtilities = ClassFactory.Get<QueuesFolderUtilities>(new[] {
				new ConstructorArgument("userConnection", userConnection)
			});
			folderUtilities.AddQueueItems(folderIds, entitySchemaName, queueId);
		}

		#endregion

	}

	#endregion

}
