namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.Nui.ServiceModel.WebService;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
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

	#region Class: CampaignSchema

	/// <exclude/>
	public class CampaignSchema : BPMSoft.Configuration.Campaign_Campaigns_BPMSoftSchema
	{

		#region Constructors: Public

		public CampaignSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignSchema(CampaignSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignSchema(CampaignSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e8e4458b-88d2-45c6-ae36-6c77ebe6d6dc");
			Name = "Campaign";
			ParentSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8");
			ExtendParent = true;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Campaign(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Campaign_CustomEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8e4458b-88d2-45c6-ae36-6c77ebe6d6dc"));
		}

		#endregion

	}

	#endregion

	#region Class: Campaign

	/// <summary>
	/// Кампания.
	/// </summary>
	public class Campaign : BPMSoft.Configuration.Campaign_Campaigns_BPMSoft
	{

		#region Constructors: Public

		public Campaign(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Campaign";
		}

		public Campaign(Campaign source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Campaign_CustomEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Campaign(this);
		}

		#endregion

	}

	#endregion

	#region Class: Campaign_CustomEventsProcess

	/// <exclude/>
	public partial class Campaign_CustomEventsProcess<TEntity> : BPMSoft.Configuration.Campaign_CampaignsEventsProcess<TEntity> where TEntity : Campaign
	{

		public Campaign_CustomEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Campaign_CustomEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8e4458b-88d2-45c6-ae36-6c77ebe6d6dc");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Campaign_CustomEventsProcess

	/// <exclude/>
	public class Campaign_CustomEventsProcess : Campaign_CustomEventsProcess<Campaign>
	{

		public Campaign_CustomEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Campaign_CustomEventsProcess

	public partial class Campaign_CustomEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool DiagramSavedMethod(ProcessExecutingContext  context) {
			if (GetCampaignType() == CampaignConsts.OldCampaignTypeId) {
				return base.DiagramSavedMethod(context);
			}
			return true;
		}

		public override void SaveDiagram() {
			if (!Entity.Schema.Columns.Any(column => column.Name == DiagramStorageColumnName)) {
				return;
			}
			string json = Entity.GetTypedColumnValue<string>(DiagramStorageColumnName);
			Guid recordId = Entity.PrimaryColumnValue;
			JObject diagram = JObject.Parse(json);
			JToken nodes = diagram["nodes"];
			JToken connectors = diagram["connectors"];
			var map = new DiagramElementMap(string.Empty, new DiagramElementMapPointer[] {});
			string leadStepType = CampaignConsts.CreateLeadCampaignStepTypeId.ToString();
			string emailStepType = CampaignConsts.BulkEmailCampaignStepTypeId.ToString();
			Dictionary<string, Guid> recordsToCheck = new Dictionary<string, Guid>();
			foreach (JToken connector in connectors) {
				string sourceNodeName = map.GetJTokenValueByPath(connector, "sourceNode");
				JToken sourceNode = FindItemByProperty(nodes, "name", sourceNodeName, map);
				if (sourceNode == null) {
					continue;
				}
				string sourceNodeType = map.GetJTokenValueByPath(sourceNode, "stepType");
				if (sourceNodeType == leadStepType) {
					continue;
				}
				JToken targetNode = FindTargetNode(nodes, connectors, connector);
				if (targetNode == null) {
					continue;
				}
				string targetNodeType = map.GetJTokenValueByPath(targetNode, "stepType");
				if (targetNodeType == emailStepType) {
					string targetNodeRecord = map.GetJTokenValueByPath(targetNode, "addInfo.RecordId");
					Guid targetNodeRecordId = Guid.Empty;
					Guid.TryParse(targetNodeRecord, out targetNodeRecordId);
					if (!targetNodeRecordId.IsEmpty()) {
						string connectorName = map.GetJTokenValueByPath(connector, "name");
						recordsToCheck[connectorName] = targetNodeRecordId;
						string launchOption = map.GetJTokenValueByPath(connector, "addInfo.LaunchOptionRadio");
						string startDate = map.GetJTokenValueByPath(connector, "addInfo.StartDate");
						UpdateBulkEmail(targetNodeRecordId, launchOption, startDate);
					}
				}
			}
			//check recordsToCheck.Vaues
			/*List<string> checkedConnectors = GetCheckedConnectors(recordsToCheck);
			foreach (JToken connector in connectors) {
				//reset all unchecked connectors to -1
				string connectorName = map.GetJTokenValueByPath(connector, "name");
				if (!checkedConnectors.Contains(connectorName)) {
					map.SetJObjectValueByPath(connector, "addInfo.DayTransitionCount", -1);
				}
			}*/
			SaveNodes(recordId, nodes);
			SaveConnectors(recordId, connectors);
		}

		public override void SaveNodes(Guid parentId, JToken nodes) {
			DiagramElementMap nodesMap = GetNodesMap();
			List<Guid> records = SaveItems(parentId, nodes, nodesMap);
			UpdateReferences("Event", parentId, records);
			UpdateReferences("BulkEmail", parentId, records);
			if (records.Count > 0) {
				new Delete(UserConnection)
					.From(nodesMap.SchemaName)
					.Where("Id").Not().In(Column.Parameters(records))
					.And(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
					.Execute();
			} else {
				new Delete(UserConnection)
					.From(nodesMap.SchemaName)
					.Where(nodesMap.ReferenceColumnValueName + "Id").IsEqual(Column.Parameter(parentId))
					.Execute();
			}
		}

		public override DiagramElementMap GetConnectorsMap() {
			return new DiagramElementMap(ConnectorsSchemaName, new DiagramElementMapPointer[] {
				new DiagramElementMapPointer("labels..text", "Title", typeof(String)),
				new DiagramElementMapPointer("sourceNode", "SourceStepId", typeof(Guid)),
				new DiagramElementMapPointer("targetNode", "TargetStepId", typeof(Guid))
			});
		}

		public override DiagramElementMap GetNodesMap() {
			return new DiagramElementMap(NodesSchemaName, new DiagramElementMapPointer[] {
				new DiagramElementMapPointer("labels..text", "Title", typeof(String)),
				new DiagramElementMapPointer("stepType", "TypeId", typeof(Guid)),
				new DiagramElementMapPointer("addInfo.RecordId", "RecordId", typeof(Guid))
			}, "Campaign");
		}

		public override bool DiagramLoadedMethod(ProcessExecutingContext  context) {
			if (GetCampaignType() == CampaignConsts.OldCampaignTypeId) {
				return base.DiagramLoadedMethod(context);
			}
			return true;
		}

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: CampaignEventsProcess

	/// <exclude/>
	public class CampaignEventsProcess : Campaign_CustomEventsProcess
	{

		public CampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

