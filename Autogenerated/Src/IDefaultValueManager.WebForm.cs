namespace BPMSoft.Configuration.GeneratedWebFormService
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	
	/// <summary>
	/// Returns default values for given landing and entity.
	/// </summary>
	public interface IDefaultValueManager
	{
		/// <summary>
		/// Set default values for entity.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="webFormId">Identifier of landing.</param>
		Dictionary<string, object> GetValues(Guid webFormId, UserConnection userConnection);
	}
}

