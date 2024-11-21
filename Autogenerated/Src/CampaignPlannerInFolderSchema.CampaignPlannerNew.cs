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

	#region Class: CampaignPlannerInFolderSchema

	/// <exclude/>
	public class CampaignPlannerInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public CampaignPlannerInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerInFolderSchema(CampaignPlannerInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerInFolderSchema(CampaignPlannerInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220");
			RealUId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220");
			Name = "CampaignPlannerInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("218e3ace-8712-4632-bc75-835dee6d65da")) == null) {
				Columns.Add(CreateCampaignPlannerColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCampaignPlannerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("218e3ace-8712-4632-bc75-835dee6d65da"),
				Name = @"CampaignPlanner",
				ReferenceSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220"),
				ModifiedInSchemaUId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220"),
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
			return new CampaignPlannerInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerInFolder_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerInFolder

	/// <summary>
	/// Маркетинговый план в группе.
	/// </summary>
	public class CampaignPlannerInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public CampaignPlannerInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerInFolder";
		}

		public CampaignPlannerInFolder(CampaignPlannerInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CampaignPlannerId {
			get {
				return GetTypedColumnValue<Guid>("CampaignPlannerId");
			}
			set {
				SetColumnValue("CampaignPlannerId", value);
				_campaignPlanner = null;
			}
		}

		/// <exclude/>
		public string CampaignPlannerName {
			get {
				return GetTypedColumnValue<string>("CampaignPlannerName");
			}
			set {
				SetColumnValue("CampaignPlannerName", value);
				if (_campaignPlanner != null) {
					_campaignPlanner.Name = value;
				}
			}
		}

		private CampaignPlanner _campaignPlanner;
		/// <summary>
		/// Campaigns.
		/// </summary>
		public CampaignPlanner CampaignPlanner {
			get {
				return _campaignPlanner ??
					(_campaignPlanner = LookupColumnEntities.GetEntity("CampaignPlanner") as CampaignPlanner);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerInFolder_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerInFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerInFolder_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : CampaignPlannerInFolder
	{

		public CampaignPlannerInFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerInFolder_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("795474aa-9b4d-44d6-bd48-ba887ed48220");
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

	#region Class: CampaignPlannerInFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerInFolder_CampaignPlannerNewEventsProcess : CampaignPlannerInFolder_CampaignPlannerNewEventsProcess<CampaignPlannerInFolder>
	{

		public CampaignPlannerInFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerInFolder_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerInFolder_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerInFolderEventsProcess

	/// <exclude/>
	public class CampaignPlannerInFolderEventsProcess : CampaignPlannerInFolder_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

