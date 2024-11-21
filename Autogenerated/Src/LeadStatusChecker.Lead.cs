namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: LeadStatusChecker


	public class LeadStatusChecker
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public LeadStatusChecker(UserConnection userConnection) {
			this._userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Indicates if lead in final status.
		/// </summary>
		/// <param name="leadStatusId">Lead status identifier.</param>
		/// <returns>True if status is final.</returns>
		public bool IsLeadInFinalStatus(Guid leadStatusId) {
			EntitySchema qualifyStatusSchema = _userConnection.EntitySchemaManager.GetInstanceByName("QualifyStatus");
			Entity qualifyStatusEntity = qualifyStatusSchema.CreateEntity(_userConnection);
			qualifyStatusEntity.PrimaryColumnValue = leadStatusId;
			qualifyStatusEntity.FetchFromDB(new List<string> { "IsFinal" }, false);
			return qualifyStatusEntity.GetTypedColumnValue<bool>("IsFinal");
		}

		#endregion
	}

	#endregion

}

