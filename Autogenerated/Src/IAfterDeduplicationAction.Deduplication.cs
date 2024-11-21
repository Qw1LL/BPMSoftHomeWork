namespace BPMSoft.Configuration.Deduplication
{
	using BPMSoft.Core.Entities;

	#region Interface: IAfterDeduplicationAction

	/// <summary>
	/// Represents a handler executed after deduplication complete.
	/// </summary>
	public interface IAfterDeduplicationAction
	{

		#region Methods: Public

		/// <summary>
		/// Deduplication complete handler.
		/// </summary>
		/// <param name="mergedEntity">Merged result entity.</param>
		void Execute(Entity mergedEntity);

		#endregion

	}

	#endregion
}

