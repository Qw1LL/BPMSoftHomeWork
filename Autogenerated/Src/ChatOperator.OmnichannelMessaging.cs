namespace BPMSoft.Configuration.Omnichannel.Messaging 
{
	using System;
	using System.Collections.Generic;

	#region Class: ChatOperator

	[Serializable]
	public class ChatOperator
	{

		#region Fields: Public

		/// <summary>
		/// System user identifier.
		/// </summary>
		public readonly Guid UserId;

		#endregion

		#region Constructors: Public

		public ChatOperator(Guid userId) {
			UserId = userId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Operator state.
		/// <seealso cref="OperatorState"/>
		/// </summary>
		public OperatorState State { get; set; } = new OperatorState { 
			Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
			Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
			OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
		};

		/// <summary>
		/// Is operator active flag.
		/// </summary>
		public bool Active => State.OperatorAvailable;

		/// <summary>
		/// Operator current accepted chats count.
		/// </summary>
		public int ActiveChatsCount { get; set; } = 0;

		/// <summary>
		/// Operator directed chats identifiers.
		/// </summary>
		public List<Guid> DirectedChats { get; set; } = new List<Guid>();

		/// <summary>
		/// Operator current directed chats count.
		/// </summary>
		public int DirectedChatsCount {
			get {
				return DirectedChats.Count;
			}
		}

		/// <summary>
		/// Last time when operator accepted chat (in UTC)
		/// </summary>
		public DateTime LastChatAcceptedDate { get; set; } = DateTime.MinValue;

		/// <summary>
		/// Operator active channel queues identifiers.
		/// </summary>
		public List<Guid> ChatQueues { get; set; } = new List<Guid>();

		#endregion

	}

	#endregion

	#region Class: OperatorState

	[Serializable]
	public class OperatorState {

		#region Properties: Public

		/// <summary>
		/// State identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// State code.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Is operator avaliable in this state flag.
		/// </summary>
		public bool OperatorAvailable { get; set; }

		#endregion

	}

	#endregion

}
