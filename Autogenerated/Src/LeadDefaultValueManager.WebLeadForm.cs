namespace BPMSoft.Configuration.GeneratedWebFormService
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: LeadDefaultValueManager

	/// <summary>
	/// Returns default values for given landing and entity.
	/// </summary>
	public class LeadDefaultValueManager : ObjectDefaultValueManager
	{
		/// <summary>
		/// Lead register method - landing page.
		/// </summary>
		private readonly Guid LeadRegisterMethodCode = new Guid("BA097C3A-31CF-48A7-A196-84FAD50EFE8D");
		private readonly string RegisterMethodColumn = "RegisterMethodId";

		protected override string SourceDefaultsSchemaName {
			get { return "LandingLeadDefaults"; }
		}

		#region Methods: Public

		/// <summary>
		/// Returns default values for given landing.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="webFormId">Identifier of landing.</param>
		/// <returns>Dictionary with column name as key and column value as value.</returns>
		public override Dictionary<string, object> GetValues(Guid webFormId, UserConnection userConnection) {
			var result = base.GetValues(webFormId, userConnection);
			var leadDefaultValues = new Dictionary<string, object>() {
				{ "WebFormId", webFormId }
			};
			if (!result.ContainsKey(RegisterMethodColumn)) {
				leadDefaultValues.Add(RegisterMethodColumn, LeadRegisterMethodCode);
			}
			MergeColumnValuesWithOverwrite(leadDefaultValues, result);
			return result;
		}

		#endregion
	}

	#endregion
}

