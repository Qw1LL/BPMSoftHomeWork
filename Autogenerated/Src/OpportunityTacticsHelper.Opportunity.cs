namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Store;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region Class: OpportunityTacticsHelper

	public class OpportunityTacticsHelper
	{

		#region Class: Tactic

		private class Tactic
		{
			public string TacticValue { 
				get; 
				set; 
			}
			public DateTime? CheckDate { 
				get; 
				set; 
			}
			public Guid OpportunityId { 
				get; 
				set; 
			}
		}

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get { return _userConnection; }
		}

		#endregion

		#region Constructors: Public

		public OpportunityTacticsHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private
		
		private void SaveOpportunityTactic(Tactic tactic) {
			var entitySchemaManager = UserConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var opportunityTacticHist = entitySchemaManager
				.GetInstanceByName("OpportunityTacticHist")
				.CreateEntity(UserConnection);
			opportunityTacticHist.SetDefColumnValues();
			opportunityTacticHist.SetColumnValue("Tactics", tactic.TacticValue);
			opportunityTacticHist.SetColumnValue("CheckDate", tactic.CheckDate);
			opportunityTacticHist.SetColumnValue("ModifyDate", DateTime.Now);
			opportunityTacticHist.SetColumnValue("OpportunityId", tactic.OpportunityId);
			opportunityTacticHist.Save(false);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles opportunity tactics history update.
		/// </summary>
		/// <param name="oppEntity">Current opportunity entity</param>
		public void UpdateOpportunityTacticHistory(Entity oppEntity) {
			if (!oppEntity.GetIsColumnValueLoaded("Tactic") || !oppEntity.GetIsColumnValueLoaded("CheckDate")) {
				oppEntity.FetchFromDB(oppEntity.PrimaryColumnValue);
			}
			var tacticValue = oppEntity.GetTypedColumnValue<string>("Tactic");
			object checkDateobj = oppEntity.GetColumnValue("CheckDate");
			if (tacticValue.IsNullOrEmpty() && checkDateobj == null) {
				return;
			}
			var tactic = new Tactic() {
				TacticValue = tacticValue,
				OpportunityId = oppEntity.GetTypedColumnValue<Guid>("Id"),
			};
			if (checkDateobj != null) {
				var checkDate = Convert.ToDateTime(checkDateobj);
				tactic.CheckDate = checkDate;
			}
			SaveOpportunityTactic(tactic);
		}

		#endregion

	}

	#endregion

}

