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

	#region Class: VwSysLookupSchema

	/// <exclude/>
	public class VwSysLookupSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwSysLookupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysLookupSchema(VwSysLookupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysLookupSchema(VwSysLookupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
			RealUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
			Name = "VwSysLookup";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9ac36be4-1445-4efb-9045-587e6bb8e227")) == null) {
				Columns.Add(CreateSysFolderColumn());
			}
			if (Columns.FindByUId(new Guid("2d6de8c4-3d7f-4a80-84f2-d4a29ede4103")) == null) {
				Columns.Add(CreateIsSimpleColumn());
			}
			if (Columns.FindByUId(new Guid("599a1372-11a5-4327-a342-072bdbb4b38e")) == null) {
				Columns.Add(CreateIsSystemColumn());
			}
			if (Columns.FindByUId(new Guid("d2f7d553-0292-4a39-bb17-6f6ba26a3ae1")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("7c81b883-a2fd-4152-af5a-b30c128aefb0")) == null) {
				Columns.Add(CreateSysEditPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9290f7c4-590b-4a35-8e87-61685eb8752e")) == null) {
				Columns.Add(CreateSysGridPageSchemaUColumn());
			}
			if (Columns.FindByUId(new Guid("d50e7964-0111-4cad-8cc3-eae56078533e")) == null) {
				Columns.Add(CreateSysEntitySchemaUColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ac36be4-1445-4efb-9045-587e6bb8e227"),
				Name = @"SysFolder",
				ReferenceSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf"),
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSimpleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2d6de8c4-3d7f-4a80-84f2-d4a29ede4103"),
				Name = @"IsSimple",
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSystemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("599a1372-11a5-4327-a342-072bdbb4b38e"),
				Name = @"IsSystem",
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d2f7d553-0292-4a39-bb17-6f6ba26a3ae1"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEditPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7c81b883-a2fd-4152-af5a-b30c128aefb0"),
				Name = @"SysEditPageSchemaUId",
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysGridPageSchemaUColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9290f7c4-590b-4a35-8e87-61685eb8752e"),
				Name = @"SysGridPageSchemaU",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d50e7964-0111-4cad-8cc3-eae56078533e"),
				Name = @"SysEntitySchemaU",
				ReferenceSchemaUId = new Guid("90fa6d02-3e93-45d6-a72b-58dcffa411ae"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				ModifiedInSchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysLookup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysLookup_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysLookupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysLookupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysLookup

	/// <summary>
	/// User lookup (view).
	/// </summary>
	public class VwSysLookup : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwSysLookup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysLookup";
		}

		public VwSysLookup(VwSysLookup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysLookupFolder _sysFolder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SysLookupFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = LookupColumnEntities.GetEntity("SysFolder") as SysLookupFolder);
			}
		}

		/// <summary>
		/// Simple.
		/// </summary>
		public bool IsSimple {
			get {
				return GetTypedColumnValue<bool>("IsSimple");
			}
			set {
				SetColumnValue("IsSimple", value);
			}
		}

		/// <summary>
		/// System.
		/// </summary>
		public bool IsSystem {
			get {
				return GetTypedColumnValue<bool>("IsSystem");
			}
			set {
				SetColumnValue("IsSystem", value);
			}
		}

		/// <exclude/>
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// User workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		/// <summary>
		/// Unique identifier of edit page.
		/// </summary>
		public Guid SysEditPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEditPageSchemaUId");
			}
			set {
				SetColumnValue("SysEditPageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid SysGridPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageSchemaUId");
			}
			set {
				SetColumnValue("SysGridPageSchemaUId", value);
				_sysGridPageSchemaU = null;
			}
		}

		/// <exclude/>
		public string SysGridPageSchemaUCaption {
			get {
				return GetTypedColumnValue<string>("SysGridPageSchemaUCaption");
			}
			set {
				SetColumnValue("SysGridPageSchemaUCaption", value);
				if (_sysGridPageSchemaU != null) {
					_sysGridPageSchemaU.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _sysGridPageSchemaU;
		/// <summary>
		/// Unique identifier of list page.
		/// </summary>
		public VwSysSchemaInfo SysGridPageSchemaU {
			get {
				return _sysGridPageSchemaU ??
					(_sysGridPageSchemaU = LookupColumnEntities.GetEntity("SysGridPageSchemaU") as VwSysSchemaInfo);
			}
		}

		/// <exclude/>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
				_sysEntitySchemaU = null;
			}
		}

		/// <exclude/>
		public string SysEntitySchemaUCaption {
			get {
				return GetTypedColumnValue<string>("SysEntitySchemaUCaption");
			}
			set {
				SetColumnValue("SysEntitySchemaUCaption", value);
				if (_sysEntitySchemaU != null) {
					_sysEntitySchemaU.Caption = value;
				}
			}
		}

		private VwSysSchemaInfo _sysEntitySchemaU;
		/// <summary>
		/// Unique identifier of object.
		/// </summary>
		public VwSysSchemaInfo SysEntitySchemaU {
			get {
				return _sysEntitySchemaU ??
					(_sysEntitySchemaU = LookupColumnEntities.GetEntity("SysEntitySchemaU") as VwSysSchemaInfo);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysLookup_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysLookupDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysLookupDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysLookupInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysLookupInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysLookupSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysLookupSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysLookupValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysLookup(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysLookup_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysLookup_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwSysLookup
	{

		public VwSysLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysLookup_BaseEventsProcess";
			SchemaUId = new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffee71d2-1485-4c86-9cdb-3d74ea091dd1");
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

	#region Class: VwSysLookup_BaseEventsProcess

	/// <exclude/>
	public class VwSysLookup_BaseEventsProcess : VwSysLookup_BaseEventsProcess<VwSysLookup>
	{

		public VwSysLookup_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysLookup_BaseEventsProcess

	public partial class VwSysLookup_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysLookupEventsProcess

	/// <exclude/>
	public class VwSysLookupEventsProcess : VwSysLookup_BaseEventsProcess
	{

		public VwSysLookupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

