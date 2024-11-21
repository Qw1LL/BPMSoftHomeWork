namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: StartOpportunityManagementProcessUserTask

	/// <exclude/>
	public partial class StartOpportunityManagementProcessUserTask
	{

		#region Methods: Private

		private void RunProcess(ProcessSchema processSchema, Dictionary<string, string> parameterValues) {
			IProcessEngine processEngine = UserConnection.ProcessEngine;
			IProcessExecutor processExecutor = processEngine.ProcessExecutor;
			if (processSchema.Enabled) {
				processExecutor.Execute(processSchema.UId, parameterValues);
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			ProcessSchemaManager processSchemaManager = UserConnection.ProcessSchemaManager;
			Guid uid = ProcessSchemaUId;
			if (processSchemaManager.FindItemByUId(ProcessSchemaUId) == null) {
				uid = ((Select)new Select(UserConnection).Top(1)
					.Column("UId")
					.From("SysSchema")
					.Where("Id").IsEqual(Column.Parameter(ProcessSchemaUId)))
					.ExecuteScalar<Guid>();
			}
			ProcessSchema processSchema = GetProcessSchema(uid);
			if (!processSchema.Enabled) {
				return true;
			}
			Dictionary<string, string> parameterValues = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(CustomPropertyValues)) {
				parameterValues = Common.Json.Json.Deserialize<Dictionary<string, string>>(CustomPropertyValues);
			}
			parameterValues["OpportunityId"] = OpportunityId.ToString();
			RunProcess(processSchema, parameterValues);
			return true;
		}

		#endregion

		#region Methods: Public

		public override string GetExecutionData() {
			return string.Empty;
		}

		public virtual ProcessSchema GetProcessSchema(Guid uid) {
			return UserConnection.ProcessSchemaManager.GetInstanceByUId(uid);
		}

		#endregion

	}

	#endregion

}

