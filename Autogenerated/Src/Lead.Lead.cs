namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: Lead_LeadEventsProcess

	public partial class Lead_LeadEventsProcess<TEntity>
	{

		#region Methods: Private

		private bool GetCanRunProcess(Guid processSchemaUId) {
			ProcessSchemaManager processSchemaManager = UserConnection.ProcessSchemaManager;
			ISchemaManagerItem<ProcessSchema> managerItem = processSchemaManager.FindItemByUId(processSchemaUId);
			if (managerItem == null) {
				return false;
			}
			return managerItem.Instance.Enabled;
		}

		#endregion

		#region Methods: protected

		protected void RunProcess(Guid processSchemaUId, Dictionary<string, string> parameterValues) {
			if (GetCanRunProcess(processSchemaUId)) {
				var processEngine = UserConnection.ProcessEngine;
				var processExecutor = processEngine.ProcessExecutor;
				processExecutor.Execute(processSchemaUId, parameterValues);
			}
		}

		#endregion

		#region Methods: Public

		public virtual void LeadSaved() {
			UpdateLeadName();
		}

		public virtual void UpdateLeadName() {
			var esq = new EntitySchemaQuery(Entity.Schema);
			esq.AddColumn("Account");
			esq.AddColumn("Contact");
			esq.AddColumn("QualifiedContact.Name");
			esq.AddColumn("QualifiedAccount.Name");
			esq.AddColumn("LeadType.Name");
			var leadEntity = esq. GetEntity(UserConnection, Entity.PrimaryColumnValue);
			if (leadEntity != null) {
				var columnAccount = leadEntity.GetTypedColumnValue<string>("Account");
				var columnContact = leadEntity.GetTypedColumnValue<string>("Contact");
				var columnQualifiedContact = leadEntity.GetTypedColumnValue<string>("QualifiedContact_Name");
				var columnQualifiedAccount = leadEntity.GetTypedColumnValue<string>("QualifiedAccount_Name");
				var columnLeadType = leadEntity.GetTypedColumnValue<string>("LeadType_Name");
			
				string contactName = !string.IsNullOrEmpty(columnQualifiedContact) ? columnQualifiedContact : columnContact;
				string accountName = !string.IsNullOrEmpty(columnQualifiedAccount) ? columnQualifiedAccount : columnAccount;
			
				string additionalLeadName = StringUtilities.ConcatIfNotEmpty(new[] { contactName, accountName }, ", ");
				string leadName = StringUtilities.ConcatIfNotEmpty(new[] { columnLeadType, additionalLeadName }, " / ");
				if (!string.IsNullOrEmpty(leadName) && leadName.Length >= 500) {
					leadName = leadName.Substring(0, 500);
				}
				if (!String.IsNullOrEmpty(leadName)) {
					Update updateLeadQuery = new Update(UserConnection, Entity.Schema.Name);
					updateLeadQuery.Set("LeadName", Column.Parameter(leadName));
					updateLeadQuery.Where("Id").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
					updateLeadQuery.Execute();
				}
			}
		}

		public virtual void LeadInserted() {
		}

		public virtual void LeadSavingMethod() {
			string meetingDateColumnName = "MeetingDate";
			if (Entity.IsColumnValueLoaded(meetingDateColumnName)) {
				var meetingDate = Entity.GetTypedColumnValue<DateTime>(Entity.Schema.Columns.GetByName(meetingDateColumnName).ColumnValueName);
				if (meetingDate.Year == DateTime.MinValue.Year) {
					Entity.SetColumnValue(meetingDateColumnName, null);
				}
			}
			string decisionDateColumnName = "DecisionDate";
			if (Entity.IsColumnValueLoaded(decisionDateColumnName)) {
				var decisionDate = Entity.GetTypedColumnValue<DateTime>(Entity.Schema.Columns.GetByName(decisionDateColumnName).ColumnValueName);
				if (decisionDate.Year == DateTime.MinValue.Year) {
					Entity.SetColumnValue(decisionDateColumnName, null);
				}
			}
		}

		public virtual void LeadInserting() {
		}

		#endregion

	}

	#endregion

}

