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

	#region Class: BaseFolderSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseFolderSchema : BPMSoft.Configuration.BaseHierarchicalLookupSchema
	{

		#region Constructors: Public

		public BaseFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseFolderSchema(BaseFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseFolderSchema(BaseFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			RealUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			Name = "BaseFolder";
			ParentSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e44c8807-bc0e-4415-b41c-2272c8fbdf42")) == null) {
				Columns.Add(CreateFolderTypeColumn());
			}
			if (Columns.FindByUId(new Guid("4d5be702-fa8a-4b6b-97d0-f666b99f108e")) == null) {
				Columns.Add(CreateSearchDataColumn());
			}
			if (Columns.FindByUId(new Guid("7194c633-a5a9-48cf-a96c-d8b548878b2f")) == null) {
				Columns.Add(CreateOptimizationTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFolderTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e44c8807-bc0e-4415-b41c-2272c8fbdf42"),
				Name = @"FolderType",
				ReferenceSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				ModifiedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSearchDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("4d5be702-fa8a-4b6b-97d0-f666b99f108e"),
				Name = @"SearchData",
				CreatedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				ModifiedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateOptimizationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7194c633-a5a9-48cf-a96c-d8b548878b2f"),
				Name = @"OptimizationType",
				CreatedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				ModifiedInSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseFolder

	/// <summary>
	/// Base folder.
	/// </summary>
	public class BaseFolder : BPMSoft.Configuration.BaseHierarchicalLookup
	{

		#region Constructors: Public

		public BaseFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseFolder";
		}

		public BaseFolder(BaseFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid FolderTypeId {
			get {
				return GetTypedColumnValue<Guid>("FolderTypeId");
			}
			set {
				SetColumnValue("FolderTypeId", value);
				_folderType = null;
			}
		}

		/// <exclude/>
		public string FolderTypeName {
			get {
				return GetTypedColumnValue<string>("FolderTypeName");
			}
			set {
				SetColumnValue("FolderTypeName", value);
				if (_folderType != null) {
					_folderType.Name = value;
				}
			}
		}

		private FolderType _folderType;
		/// <summary>
		/// Folder type.
		/// </summary>
		public FolderType FolderType {
			get {
				return _folderType ??
					(_folderType = LookupColumnEntities.GetEntity("FolderType") as FolderType);
			}
		}

		/// <summary>
		/// Optimization type.
		/// </summary>
		public int OptimizationType {
			get {
				return GetTypedColumnValue<int>("OptimizationType");
			}
			set {
				SetColumnValue("OptimizationType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseFolderInserting", e);
			Saved += (s, e) => ThrowEvent("BaseFolderSaved", e);
			Saving += (s, e) => ThrowEvent("BaseFolderSaving", e);
			Validating += (s, e) => ThrowEvent("BaseFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseFolder_BaseEventsProcess

	/// <exclude/>
	public partial class BaseFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseHierarchicalLookup_BaseEventsProcess<TEntity> where TEntity : BaseFolder
	{

		public BaseFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseFolder_BaseEventsProcess";
			SchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
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

	#region Class: BaseFolder_BaseEventsProcess

	/// <exclude/>
	public class BaseFolder_BaseEventsProcess : BaseFolder_BaseEventsProcess<BaseFolder>
	{

		public BaseFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseFolder_BaseEventsProcess

	public partial class BaseFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: BaseFolderEventsProcess

	/// <exclude/>
	public class BaseFolderEventsProcess : BaseFolder_BaseEventsProcess
	{

		public BaseFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

