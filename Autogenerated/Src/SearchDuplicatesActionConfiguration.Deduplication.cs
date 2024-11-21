namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core.Process;

	#region Class: SearchDuplicatesActionConfiguration

	/// <summary>
	/// Provides search duplicates action configuration.
	/// </summary>
	public class SearchDuplicatesActionConfiguration
	{

		#region Properties: Public

		/// <summary>
		/// Entity Id.
		/// </summary>
		public Guid EntityId { get; set; }

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public Guid EntitySchemaId { get; set; }

		/// <summary>
		/// List of rules.
		/// </summary>
		public List<Guid> RulesList { get; set; }

		#endregion

	}

	#endregion

}
