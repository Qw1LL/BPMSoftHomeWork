namespace BPMSoft.Configuration.Deduplication
{
	using BPMSoft.Core;

	/// <summary>
	/// Provides method for managing deduplication remindings.
	/// </summary>
	public interface IDeduplicationRemindingRepository
	{
		/// <summary>
		/// Creates reminging by given reminding description, subject and deduplication
		/// schema name.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="remindingDescription">Reminding description.</param>
		/// <param name="remindingSubject">Reminding subject.</param>
		/// <param name="schemaName">Schema name.</param>
		void CreateReminding(UserConnection userConnection, string remindingDescription, string remindingSubject,
			string schemaName);
	}

}
