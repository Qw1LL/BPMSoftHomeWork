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

	#region Class: VwSysModuleEditSchema

	/// <exclude/>
	public class VwSysModuleEditSchema : BPMSoft.Configuration.SysModuleEditSchema
	{

		#region Constructors: Public

		public VwSysModuleEditSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysModuleEditSchema(VwSysModuleEditSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysModuleEditSchema(VwSysModuleEditSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb");
			RealUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb");
			Name = "VwSysModuleEdit";
			ParentSchemaUId = new Guid("24666f2d-049f-4867-ae2c-db681c40c001");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("011f15ec-018b-488c-8c6f-99158f82b08a")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("cab746bc-e566-4366-a425-c2b643e628f9")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
		}

		protected override EntitySchemaColumn CreateUseModuleDetailsColumn() {
			EntitySchemaColumn column = base.CreateUseModuleDetailsColumn();
			column.ModifiedInSchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("011f15ec-018b-488c-8c6f-99158f82b08a"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb"),
				ModifiedInSchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cab746bc-e566-4366-a425-c2b643e628f9"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb"),
				ModifiedInSchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb"),
				CreatedInPackageId = new Guid("65bb0ec4-b99c-481e-863d-c86d16d50733")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysModuleEdit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysModuleEdit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysModuleEditSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysModuleEditSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleEdit

	/// <summary>
	/// Section card (view).
	/// </summary>
	public class VwSysModuleEdit : BPMSoft.Configuration.SysModuleEdit
	{

		#region Constructors: Public

		public VwSysModuleEdit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysModuleEdit";
		}

		public VwSysModuleEdit(VwSysModuleEdit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
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
		/// Workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysModuleEdit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysModuleEditDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysModuleEditDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysModuleEditInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysModuleEditInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysModuleEditSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysModuleEditSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysModuleEditValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysModuleEdit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleEdit_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysModuleEdit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysModuleEdit_BaseEventsProcess<TEntity> where TEntity : VwSysModuleEdit
	{

		public VwSysModuleEdit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysModuleEdit_BaseEventsProcess";
			SchemaUId = new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("af1d238e-f551-4878-b4c3-d52aa8495adb");
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

	#region Class: VwSysModuleEdit_BaseEventsProcess

	/// <exclude/>
	public class VwSysModuleEdit_BaseEventsProcess : VwSysModuleEdit_BaseEventsProcess<VwSysModuleEdit>
	{

		public VwSysModuleEdit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysModuleEdit_BaseEventsProcess

	public partial class VwSysModuleEdit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysModuleEditEventsProcess

	/// <exclude/>
	public class VwSysModuleEditEventsProcess : VwSysModuleEdit_BaseEventsProcess
	{

		public VwSysModuleEditEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

