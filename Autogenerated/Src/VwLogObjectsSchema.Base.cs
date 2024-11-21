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

	#region Class: VwLogObjectsSchema

	/// <exclude/>
	public class VwLogObjectsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwLogObjectsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwLogObjectsSchema(VwLogObjectsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwLogObjectsSchema(VwLogObjectsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4");
			RealUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4");
			Name = "VwLogObjects";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e977d7d1-6a05-4f31-954d-cc4147716f87")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("ff3565e6-4608-4766-a7f3-3ad5b79dc252")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("f6ec002d-6240-4984-a452-7f364518c703")) == null) {
				Columns.Add(CreateUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("e977d7d1-6a05-4f31-954d-cc4147716f87"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				ModifiedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ff3565e6-4608-4766-a7f3-3ad5b79dc252"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				ModifiedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f6ec002d-6240-4984-a452-7f364518c703"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				ModifiedInSchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwLogObjects(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwLogObjects_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwLogObjectsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwLogObjectsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4"));
		}

		#endregion

	}

	#endregion

	#region Class: VwLogObjects

	/// <summary>
	/// Logged objects.
	/// </summary>
	public class VwLogObjects : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwLogObjects(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwLogObjects";
		}

		public VwLogObjects(VwLogObjects source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
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
		/// User workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		/// <summary>
		/// Schema UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwLogObjects_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwLogObjectsDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwLogObjectsDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwLogObjectsInserted", e);
			Inserting += (s, e) => ThrowEvent("VwLogObjectsInserting", e);
			Saved += (s, e) => ThrowEvent("VwLogObjectsSaved", e);
			Saving += (s, e) => ThrowEvent("VwLogObjectsSaving", e);
			Validating += (s, e) => ThrowEvent("VwLogObjectsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwLogObjects(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwLogObjects_BaseEventsProcess

	/// <exclude/>
	public partial class VwLogObjects_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwLogObjects
	{

		public VwLogObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwLogObjects_BaseEventsProcess";
			SchemaUId = new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4adfed7d-3076-4f2a-9ec0-f3c01da99db4");
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

	#region Class: VwLogObjects_BaseEventsProcess

	/// <exclude/>
	public class VwLogObjects_BaseEventsProcess : VwLogObjects_BaseEventsProcess<VwLogObjects>
	{

		public VwLogObjects_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwLogObjects_BaseEventsProcess

	public partial class VwLogObjects_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwLogObjectsEventsProcess

	/// <exclude/>
	public class VwLogObjectsEventsProcess : VwLogObjects_BaseEventsProcess
	{

		public VwLogObjectsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

