namespace BPMSoft.Configuration
{

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

	#region Class: MktgActivityInFolderSchema

	/// <exclude/>
	public class MktgActivityInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public MktgActivityInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivityInFolderSchema(MktgActivityInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivityInFolderSchema(MktgActivityInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174");
			RealUId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174");
			Name = "MktgActivityInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0c59a099-afa6-4ddd-8b1c-d166a91a11ff")) == null) {
				Columns.Add(CreateMktgActivityColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("5866b16d-b894-4fa0-b45b-5f4a9ada89a9");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMktgActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0c59a099-afa6-4ddd-8b1c-d166a91a11ff"),
				Name = @"MktgActivity",
				ReferenceSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174"),
				ModifiedInSchemaUId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MktgActivityInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivityInFolder_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivityInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivityInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b84a13ad-3745-4a71-a070-d7792cb50174"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityInFolder

	/// <summary>
	/// Маркетинговая активность в группе.
	/// </summary>
	public class MktgActivityInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public MktgActivityInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivityInFolder";
		}

		public MktgActivityInFolder(MktgActivityInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MktgActivityId {
			get {
				return GetTypedColumnValue<Guid>("MktgActivityId");
			}
			set {
				SetColumnValue("MktgActivityId", value);
				_mktgActivity = null;
			}
		}

		/// <exclude/>
		public string MktgActivityName {
			get {
				return GetTypedColumnValue<string>("MktgActivityName");
			}
			set {
				SetColumnValue("MktgActivityName", value);
				if (_mktgActivity != null) {
					_mktgActivity.Name = value;
				}
			}
		}

		private MktgActivity _mktgActivity;
		/// <summary>
		/// MarketingActivities.
		/// </summary>
		public MktgActivity MktgActivity {
			get {
				return _mktgActivity ??
					(_mktgActivity = LookupColumnEntities.GetEntity("MktgActivity") as MktgActivity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MktgActivityInFolder_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivityInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("MktgActivityInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivityInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityInFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class MktgActivityInFolder_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : MktgActivityInFolder
	{

		public MktgActivityInFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivityInFolder_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("b84a13ad-3745-4a71-a070-d7792cb50174");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b84a13ad-3745-4a71-a070-d7792cb50174");
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

	#region Class: MktgActivityInFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class MktgActivityInFolder_CampaignPlannerNewEventsProcess : MktgActivityInFolder_CampaignPlannerNewEventsProcess<MktgActivityInFolder>
	{

		public MktgActivityInFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivityInFolder_CampaignPlannerNewEventsProcess

	public partial class MktgActivityInFolder_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MktgActivityInFolderEventsProcess

	/// <exclude/>
	public class MktgActivityInFolderEventsProcess : MktgActivityInFolder_CampaignPlannerNewEventsProcess
	{

		public MktgActivityInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

