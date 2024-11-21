namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Messaging.Common;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: ActualizeOpportunityManagementMethodsWrapper

	/// <exclude/>
	public class ActualizeOpportunityManagementMethodsWrapper : ProcessModel
	{

		public ActualizeOpportunityManagementMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			UserConnection userConnection = Get<UserConnection>("UserConnection");
			string useOldProcessFeatureCode = "UseOldOpportunityManagementProcess";
			bool useOldVersion = Get<bool>("UseOldOpportunityManagement");
			bool forceUpdateUsageState = Get<bool>("ForceUpdateUsageState");
			bool useOldVersionFeatureEnabled = userConnection.GetIsFeatureEnabled(useOldProcessFeatureCode);
			if (forceUpdateUsageState && useOldVersionFeatureEnabled != useOldVersion) {
				var newState = useOldVersion ? FeatureState.Enabled : FeatureState.Disabled;
				userConnection.SetFeatureState(useOldProcessFeatureCode, (int)newState);
			}
			global::Common.Logging.ILog _logger = global::Common.Logging.LogManager.GetLogger("Process");
			StoredProcedure storedProcedure = new StoredProcedure(userConnection,
				"tsp_ActualizeOpportunityManagementProcess");
			storedProcedure.WithParameter("fetchProcessesInfo", true);
			Dictionary<Guid, bool> processSchemasInfos = new Dictionary<Guid, bool>();
			using (var executor = userConnection.EnsureDBConnection()) {
				using (var reader = storedProcedure.ExecuteReader(executor)) {
					while (reader.Read()) {
						var schemaName = reader.GetValue<string>("SchemaName");
						var schemaId = reader.GetValue<Guid>("SchemaId");
						var toBeEnabled = reader.GetValue<bool>("ToBeEnabled");
						_logger.InfoFormat("Process {0}({1}) will be set to enabled state = {2}", schemaName,
							schemaId, toBeEnabled);
						processSchemasInfos[schemaId] = toBeEnabled;
					}
				}
			}
			var processSchemaManager = userConnection.ProcessSchemaManager;
			foreach (var processSchemaInfo in processSchemasInfos) {
				if (processSchemaInfo.Value) {
					processSchemaManager.EnableProcess(userConnection, processSchemaInfo.Key);
				} else {
					processSchemaManager.DisableProcess(userConnection, processSchemaInfo.Key);
				}
			}
			return true;
		}

		#endregion

	}

	#endregion

}

