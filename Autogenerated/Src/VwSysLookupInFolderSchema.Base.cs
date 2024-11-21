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

	#region Class: VwSysLookupInFolderSchema

	/// <exclude/>
	public class VwSysLookupInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public VwSysLookupInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysLookupInFolderSchema(VwSysLookupInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysLookupInFolderSchema(VwSysLookupInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533");
			RealUId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533");
			Name = "VwSysLookupInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b8e82469-336b-4300-8a0a-13bf9799d39d")) == null) {
				Columns.Add(CreateVwSysLookupColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("5403f977-1005-41a3-99a1-5ff37806bbbf");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533");
			return column;
		}

		protected virtual EntitySchemaColumn CreateVwSysLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b8e82469-336b-4300-8a0a-13bf9799d39d"),
				Name = @"VwSysLookup",
				ReferenceSchemaUId = new Guid("aa3cc352-3095-43c9-ace8-6301f50a0a80"),
				CreatedInSchemaUId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533"),
				ModifiedInSchemaUId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysLookupInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysLookupInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysLookupInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysLookupInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f7029804-00f9-4f74-aaca-0d9a93921533"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysLookupInFolder

	/// <summary>
	/// Lookup in folder (view).
	/// </summary>
	public class VwSysLookupInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public VwSysLookupInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysLookupInFolder";
		}

		public VwSysLookupInFolder(VwSysLookupInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid VwSysLookupId {
			get {
				return GetTypedColumnValue<Guid>("VwSysLookupId");
			}
			set {
				SetColumnValue("VwSysLookupId", value);
				_vwSysLookup = null;
			}
		}

		/// <exclude/>
		public string VwSysLookupName {
			get {
				return GetTypedColumnValue<string>("VwSysLookupName");
			}
			set {
				SetColumnValue("VwSysLookupName", value);
				if (_vwSysLookup != null) {
					_vwSysLookup.Name = value;
				}
			}
		}

		private SysLookup _vwSysLookup;
		/// <summary>
		/// Lookup.
		/// </summary>
		public SysLookup VwSysLookup {
			get {
				return _vwSysLookup ??
					(_vwSysLookup = LookupColumnEntities.GetEntity("VwSysLookup") as SysLookup);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysLookupInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysLookupInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysLookupInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysLookupInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysLookupInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysLookupInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysLookupInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysLookupInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysLookupInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysLookupInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysLookupInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : VwSysLookupInFolder
	{

		public VwSysLookupInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysLookupInFolder_BaseEventsProcess";
			SchemaUId = new Guid("f7029804-00f9-4f74-aaca-0d9a93921533");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f7029804-00f9-4f74-aaca-0d9a93921533");
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

	#region Class: VwSysLookupInFolder_BaseEventsProcess

	/// <exclude/>
	public class VwSysLookupInFolder_BaseEventsProcess : VwSysLookupInFolder_BaseEventsProcess<VwSysLookupInFolder>
	{

		public VwSysLookupInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysLookupInFolder_BaseEventsProcess

	public partial class VwSysLookupInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysLookupInFolderEventsProcess

	/// <exclude/>
	public class VwSysLookupInFolderEventsProcess : VwSysLookupInFolder_BaseEventsProcess
	{

		public VwSysLookupInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

