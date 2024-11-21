namespace BPMSoft.Configuration
{
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core.Store;

	#region Class: QueueItemsEventListener

	/// <summary>
	/// Class starts queue items updating for all entities using <see cref="BaseEntityEventListener"/> implementation.
	/// </summary>
	[EntityEventListener(IsGlobal = true)]
	public class QueueItemsEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ProcessEntity(object sender, EntityAfterEventArgs e) {
			var entity = (Entity)sender;
			UserConnection userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("QueueItemsEventListenerEnabled")) {
				return;
			}
			ICacheStore applicationCache = userConnection.ApplicationCache;
			object store = applicationCache[entity.PrimaryColumnValue.ToString()];
			if (store != null) {
				var storeValue = (KeyValuePair<Guid, DateTime>)store;
				if (storeValue.Value >= entity.GetTypedColumnValue<DateTime>("ModifiedOn")) {
					return;
				}
			}
			Guid operationId = Guid.NewGuid();
			applicationCache[entity.PrimaryColumnValue.ToString()] =
				new KeyValuePair<Guid, DateTime>(operationId, entity.GetTypedColumnValue<DateTime>("ModifiedOn"));
			var queuesUpdateUtilities = ClassFactory.Get<QueuesUpdateUtilities>(new[] {
				new ConstructorArgument("userConnection", userConnection)
			});
			var queues = queuesUpdateUtilities.GetQueueIdEntityMap(Guid.Empty);
			var entityQueues = queues.Select(q => q.Value)
				.Where(q => q.GetTypedColumnValue<Guid>("QueueEntitySchemaId") == entity.Schema.UId);
			ExecuteQueuesUpdateUtilitiesAsyncOperation(e, entity, entityQueues, operationId);
		}

		private static void ExecuteQueuesUpdateUtilitiesAsyncOperation(EntityAfterEventArgs e, Entity entity, IEnumerable<Entity> entityQueues, Guid operationId) {
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			var operationArgs = new QueueEntityEventAsyncOperationArgs(entity, e);
			operationArgs.Queues = entityQueues;
			operationArgs.Action = GetEntityAction(entity);
			operationArgs.OperationId = operationId;
			asyncExecutor.ExecuteAsync<UpdateQueueItemsAsyncOperation>(operationArgs);
		}

		private static string GetEntityAction(Entity entity) {
			string action = string.Empty;
			if (entity.IsInInserted) {
				action = "Inserted";
			}
			if (entity.IsInUpdated) {
				action = "Updated";
			}
			if (entity.IsInDeleted) {
				action = "Deleted";
			}
			return action;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing  event data.
		/// </param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			ProcessEntity(sender, e);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing  event data.
		/// </param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ProcessEntity(sender, e);
		}

		/// <summary>
		/// Handles entity Updated event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e"><see cref="EntityAfterEventArgs"/> instance containing  event data.
		/// </param>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			ProcessEntity(sender, e);
		}

		#endregion

	}

	#endregion
	
}

