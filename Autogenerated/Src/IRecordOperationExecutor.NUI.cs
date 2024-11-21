namespace BPMSoft.Configuration {
	using BPMSoft.Core.Entities;

	#region Interface: IRecordOperationExecutor

	/// <summary>
	/// Interface of the operation executor for record.
	/// </summary>
	public interface IRecordOperationExecutor {

		#region Methods: Public

		/// <summary>
		/// Executes the operation for entity.
		/// </summary>
		/// <param name="item">Entity of the operation.</param>
		void Execute(Entity item);

		#endregion

	}

	#endregion

}

