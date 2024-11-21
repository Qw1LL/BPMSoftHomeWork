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
	/// Get operators for chat.
	/// </summary>
	public class ForEveryoneOperatorRoutingRule: BaseOperatorRoutingRule
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="ForEveryoneOperatorRoutingRule"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public ForEveryoneOperatorRoutingRule(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Methods: Private

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="BaseOperatorRoutingRule.PickUpFreeQueueOperators(Guid, Guid)"/>
		protected override List<Guid> PickUpFreeQueueOperators(Guid chatId, Guid queueId) {
			return SessionRepository
				.GetAllActiveOperators()
				.Where(o => (o.ChatQueues.Contains(queueId) && !IsChatLimitExceeded(o))
					|| o.DirectedChats.Contains(chatId)
				)
				.Select(o => o.UserId).ToList();
		}

		/// <inheritdoc cref="BaseOperatorRoutingRule.GetChatOperator(Guid)"/>
		protected override Guid GetChatOperator(Guid chatId) {
			Guid operatorId = (new Select(UserConnection)
				.Column("OperatorId")
			.From("OmniChat", "oc")
			.Where("oc", "Id").IsEqual(Column.Parameter(chatId))
			as Select).ExecuteScalar<Guid>();
			return operatorId;
		}

		#endregion

	}

	#endregion
} 
