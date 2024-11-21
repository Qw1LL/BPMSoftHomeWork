namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: ForEveryoneOperatorRoutingRule

	/// <summary>
	/// Routes chat for free operator.
	/// </summary>
	public class ForFreeOperatorRoutingRule : BaseOperatorRoutingRule
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ForFreeOperatorRoutingRule"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public ForFreeOperatorRoutingRule(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Properties: Public

		/// <inheritdoc cref="BaseOperatorRoutingRule.IsChatDistributedToAllOperators"/>
		public override bool IsChatDistributedToAllOperators => false;

		#endregion

		#region Methods: Private

		private void SetChatDirectedOperator(Guid chatId, Guid? directedOperatorId = null) {
			ChatOperatorCache.RemoveDirectedChat(chatId);
			var update = new Update(UserConnection, "OmniChat")
				.Set("DirectedOperatorId", Column.Parameter(directedOperatorId, "Guid"))
 	 			.Where("Id").IsEqual(Column.Parameter(chatId));
			update.Execute();
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="BaseOperatorRoutingRule.PickUpFreeQueueOperators(Guid, Guid)"/>
		protected override List<Guid> PickUpFreeQueueOperators(Guid chatId, Guid queueId) {
			var freeOperators = SessionRepository.GetAllActiveOperators().Where(ca => ca.ChatQueues.Contains(queueId)
				&& !IsChatLimitExceeded(ca));
			if (!freeOperators.Any()) {
				SetChatDirectedOperator(chatId);
				return new List<Guid>();
			}
			var freeActiveOperator = freeOperators
				.OrderBy(ca => ca.DirectedChatsCount + ca.ActiveChatsCount)
				.ThenBy(o => o.LastChatAcceptedDate)
				.FirstOrDefault();
			SetChatDirectedOperator(chatId, freeActiveOperator.UserId);
			return new List<Guid>() { freeActiveOperator.UserId };
		}

		/// <inheritdoc cref="BaseOperatorRoutingRule.GetChatOperator(Guid)"/>
		protected override Guid GetChatOperator(Guid chatId) {
			var select = new Select(UserConnection)
				.Column("OperatorId")
				.Column("DirectedOperatorId")
			.From("OmniChat")
			.Where("Id").IsEqual(Column.Parameter(chatId)) as Select;
			var chatOperatorId = Guid.Empty;
			select.ExecuteReader(reader => {
				Guid operatorId = reader.GetColumnValue<Guid>("OperatorId");
				Guid directedOperatorId = reader.GetColumnValue<Guid>("DirectedOperatorId");
				if (operatorId.IsNotEmpty()) {
					chatOperatorId = operatorId;
				} else if (directedOperatorId.IsNotEmpty() && IsOperatorActive(directedOperatorId)) {
					chatOperatorId = directedOperatorId;
				}
			});
			return chatOperatorId;
		}

		#endregion

	}

	#endregion

}
