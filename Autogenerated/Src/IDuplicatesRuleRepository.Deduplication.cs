namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Store;

	#region Interface: IDuplicatesRepository

	/// <summary>
	/// Duplicates rule entity repository interface.
	/// </summary>
	public interface IDuplicatesRuleRepository
	{

		#region Methods: Public

		/// <summary>
		/// Returns list of duplicates rules.
		/// </summary>
		/// <param name="userConnection">User connection for request.</param>
		/// <param name="cacheStore">Request cache store.</param>
		/// <returns>List of duplication rules dto.</returns>
		IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(UserConnection userConnection,
				ICacheStore cacheStore);

		/// <summary>
		/// Returns single duplicates rule by uid.
		/// </summary>
		/// <param name="userConnection">User connection for request</param>
		/// <param name="id">Rule id.</param>
		/// <returns>Duplicates rule.</returns>
		DuplicatesRuleDTO Get(UserConnection userConnection, Guid id);

		/// <summary>
		/// Saves 
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		bool Update(DuplicatesRuleDTO dto);

		#endregion

	}

	#endregion

}
