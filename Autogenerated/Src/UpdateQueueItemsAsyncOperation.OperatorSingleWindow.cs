namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Core;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Factories;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Class: UpdateQueueItemsAsyncOperation

	/// <summary>
	/// Class updates queue items using <see cref="IEntityEventAsyncOperation"/> implementation.
	/// </summary>
	public class UpdateQueueItemsAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		/// <inheritdoc cref="IEntityEventAsyncOperation.Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments)"/>
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var queueArguments = (QueueEntityEventAsyncOperationArgs)arguments;
			ICacheStore applicationCache = userConnection.ApplicationCache;
			Guid entityId = arguments.EntityId;
			object store = applicationCache[entityId.ToString()];
			if (store != null) {
				var storeValue = (KeyValuePair<Guid, DateTime>)store;
				if (storeValue.Key != queueArguments.OperationId) {
					return;
				}
			}
			IEnumerable<Entity> queues = queueArguments.Queues;
			foreach (Entity queue in queues) {
				Guid queueId = queue.PrimaryColumnValue;
				string queueName = queue.PrimaryDisplayColumnValue;
				string filterData = queue.GetTypedColumnValue<string>("FilterEditData");
				string entitySchemaName = arguments.EntitySchemaName;
				string action = queueArguments.Action;
				var queuesUpdateUtilities = ClassFactory.Get<QueuesUpdateUtilities>(new[] {
					new ConstructorArgument("userConnection", userConnection)
				});
				queuesUpdateUtilities.ProcessEntityQueueItemEvent(queueName, queueId, entitySchemaName, entityId, action, filterData);
			}
			applicationCache.Remove(entityId.ToString());
		}

		#endregion

	}

	#endregion

}

