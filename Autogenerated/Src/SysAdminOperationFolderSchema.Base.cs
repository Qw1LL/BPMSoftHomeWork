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

	#region Class: SysAdminOperationFolderSchema

	/// <exclude/>
	public class SysAdminOperationFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysAdminOperationFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAdminOperationFolderSchema(SysAdminOperationFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAdminOperationFolderSchema(SysAdminOperationFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			RealUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			Name = "SysAdminOperationFolder";
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

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAdminOperationFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAdminOperationFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAdminOperationFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAdminOperationFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationFolder

	/// <summary>
	/// Operations folder.
	/// </summary>
	public class SysAdminOperationFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysAdminOperationFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAdminOperationFolder";
		}

		public SysAdminOperationFolder(SysAdminOperationFolder source)
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

		private SysAdminOperationFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysAdminOperationFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysAdminOperationFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAdminOperationFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysAdminOperationFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysAdminOperationFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysAdminOperationFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysAdminOperationFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysAdminOperationFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysAdminOperationFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysAdminOperationFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysAdminOperationFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAdminOperationFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysAdminOperationFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SysAdminOperationFolder
	{

		public SysAdminOperationFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAdminOperationFolder_BaseEventsProcess";
			SchemaUId = new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a3421ccc-16ab-4ef5-a941-a868bba1aefd");
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

	#region Class: SysAdminOperationFolder_BaseEventsProcess

	/// <exclude/>
	public class SysAdminOperationFolder_BaseEventsProcess : SysAdminOperationFolder_BaseEventsProcess<SysAdminOperationFolder>
	{

		public SysAdminOperationFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAdminOperationFolder_BaseEventsProcess

	public partial class SysAdminOperationFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: SysAdminOperationFolderEventsProcess

	/// <exclude/>
	public class SysAdminOperationFolderEventsProcess : SysAdminOperationFolder_BaseEventsProcess
	{

		public SysAdminOperationFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

