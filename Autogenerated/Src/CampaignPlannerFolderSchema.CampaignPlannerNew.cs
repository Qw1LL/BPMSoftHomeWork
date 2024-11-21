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

	#region Class: CampaignPlannerFolderSchema

	/// <exclude/>
	public class CampaignPlannerFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public CampaignPlannerFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerFolderSchema(CampaignPlannerFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerFolderSchema(CampaignPlannerFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			RealUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			Name = "CampaignPlannerFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignPlannerFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerFolder_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de533fca-952a-442f-90c3-21d8f5654d90"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerFolder

	/// <summary>
	/// Группа раздела "Маркетинговые планы".
	/// </summary>
	public class CampaignPlannerFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public CampaignPlannerFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerFolder";
		}

		public CampaignPlannerFolder(CampaignPlannerFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private CampaignPlannerFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public CampaignPlannerFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as CampaignPlannerFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerFolder_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerFolder_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : CampaignPlannerFolder
	{

		public CampaignPlannerFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerFolder_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("de533fca-952a-442f-90c3-21d8f5654d90");
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

	#region Class: CampaignPlannerFolder_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerFolder_CampaignPlannerNewEventsProcess : CampaignPlannerFolder_CampaignPlannerNewEventsProcess<CampaignPlannerFolder>
	{

		public CampaignPlannerFolder_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerFolder_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerFolder_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLookups");
		}

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerFolderEventsProcess

	/// <exclude/>
	public class CampaignPlannerFolderEventsProcess : CampaignPlannerFolder_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

