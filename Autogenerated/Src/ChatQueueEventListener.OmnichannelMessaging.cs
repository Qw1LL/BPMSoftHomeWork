namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Omnichannel.Messaging;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Store;

	#region Class: ChatQueueEventListener

	/// <summary>
	/// Listener for 'ChatQueue' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "ChatQueue")]
	public class ChatQueueEventListener : BaseEntityEventListener
	{

		#region Constants: Public

		public const string OperatorRoutingRuleColumnName = "OperatorRoutingRuleId";

		#endregion

		#region Methods: Private

		private bool IsOperatorRoutingRuleChanged(EntityEventAsyncOperationArgs arguments) {
			var operatorRuleId = arguments.EntityColumnValues.GetTypedValue<Guid>(OperatorRoutingRuleColumnName);
			var oldoperatorRuleId = arguments.OldEntityColumnValues.GetTypedValue<Guid>(OperatorRoutingRuleColumnName);
			return operatorRuleId != oldoperatorRuleId &&
				operatorRuleId != Guid.Empty &&
				oldoperatorRuleId != Guid.Empty;
		}

		private void ResetCache(Entity chatQueue) {
			var id = chatQueue.GetTypedColumnValue<Guid>("Id");
			var key = string.Format(OmnichannelMessagingConsts.ChatQueueCacheKeyMask, id);
			chatQueue.UserConnection.ApplicationCache.SetOrRemoveValue(key, null);
		}

		private void QueueDistribute(UserConnection uc, Guid chatQueueId) {
			var queueDistribution = new ChatQueueDistributor(uc);
			queueDistribution.Distribute(chatQueueId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var chatQueue = (Entity)sender;
			var operationArgs = new EntityOwnerEventAsyncOperationArgs(chatQueue, e);
			if (IsOperatorRoutingRuleChanged(operationArgs)) {
				chatQueue.UserConnection.ApplicationCache.WithLocalCaching()
					.SetOrRemoveValue(OmnichannelMessagingConsts.QueueOperatorRoutingRulesCacheKey, null);
			}
			ResetCache(chatQueue);
			if (e.ModifiedColumnValues.Any(ccv => ccv.Name == "SimultaneousChats" || ccv.Name == "OperatorRoutingRuleId")) {
				QueueDistribute(chatQueue.UserConnection, chatQueue.PrimaryColumnValue);
			}
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Entity chatQueue = (Entity)sender;
			chatQueue.UserConnection.ApplicationCache.WithLocalCaching()
				.SetOrRemoveValue(OmnichannelMessagingConsts.QueueOperatorRoutingRulesCacheKey, null);
			ResetCache(chatQueue);
		}

		#endregion

	}

	#endregion

}

