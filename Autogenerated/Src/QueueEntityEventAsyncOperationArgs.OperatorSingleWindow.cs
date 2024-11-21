namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;

	#region Class: QueueEntityEventAsyncOperationArgs

	/// <summary>
	/// Class represents <see cref="EntityEventAsyncOperationArgs"/> inheritor for use in <see cref="QueueItemsEventListener"/>.
	/// </summary>
	public class QueueEntityEventAsyncOperationArgs : EntityEventAsyncOperationArgs
	{

		#region Constructors: Public

		public QueueEntityEventAsyncOperationArgs(Entity entity, EventArgs eventArgs) : base(entity, eventArgs) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// <see cref="Queue"/> instance collection.
		/// </summary>
		public IEnumerable<Entity> Queues {
			get; set;
		}


		/// <summary>
		/// <see cref="Entity"/> instance action.
		/// </summary>
		public string Action {
			get; set;
		}

		/// <summary>
		/// <see cref="Entity"/> instance operation identifier.
		/// </summary>
		public Guid OperationId {
			get; set;
		}

		#endregion

	}

	#endregion

}
