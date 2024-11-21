namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: ChangeChatSettingsEventListener

	/// <summary>
	/// Class provides ChatQueueOperator entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "ChatQueueOperator")]
	[EntityEventListener(SchemaName = "Channel")]
	public class ChangeChatSettingsEventListener : BaseEntityEventListener
	{

		#region Methods: Protected

		/// <summary>
		/// Clears chat operators repository <see cref="ICacheStore"/> instance.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		protected void ClearOperatorsCache(UserConnection uc) {
			var cache = new ChatOperatorCache(uc);
			cache.ClearCache();
			new ChatOperatorTransferStore(uc).ClearCache();
		}

		/// <summary>
		/// Distribute chats to operators by chat queue.
		/// </summary>
		/// <param name="uc"><see cref="UserConnection"/> instance.</param>
		/// <param name="chatQueueId">Chat queueu identifier.</param>
		protected void QueueDistribute(UserConnection uc, Guid chatQueueId) {
			var queueDistribution = new ChatQueueDistributor(uc);
			queueDistribution.Distribute(chatQueueId);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnInserted"/>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ClearOperatorsCache(entity.UserConnection);
			QueueDistribute(entity.UserConnection, entity.GetTypedColumnValue<Guid>("ChatQueueId"));
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			var entity = (Entity)sender;
			if (entity.SchemaName == "Channel" && entity.GetChangedColumnValues().Any(ccv => ccv.Name == "IsActive")) {
				ClearOperatorsCache(entity.UserConnection);
			}
			if (entity.SchemaName == "Channel" && entity.GetChangedColumnValues()
					.Any(ccv => ccv.Name == "ChatQueueId" || (ccv.Name == "IsActive" && (bool)ccv.Value))) {
				QueueDistribute(entity.UserConnection, entity.GetTypedColumnValue<Guid>("ChatQueueId"));
			}
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			ClearOperatorsCache(userConnection);
			QueueDistribute(userConnection, entity.GetTypedColumnValue<Guid>("ChatQueueId"));
		}

		#endregion

	}
	#endregion

}
