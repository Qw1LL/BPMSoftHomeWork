namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;

	#region Class: EntityOwnerEventAsyncOperationArgs

	/// <summary>
	/// Additional owner arguments to pass into executor.
	/// </summary>
	public class EntityOwnerEventAsyncOperationArgs: EntityEventAsyncOperationArgs
	{

		#region Properties: Public

		/// <summary>
		/// Name of entity owner column.
		/// </summary>
		public string OwnerColumnName { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="EntityOwnerEventAsyncOperationArgs"/>
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="eventArgs">Info about argument events.</param>
		public EntityOwnerEventAsyncOperationArgs(Entity entity, EventArgs eventArgs) : base(entity, eventArgs) {
		}

		#endregion

	}

	#endregion
	
}
