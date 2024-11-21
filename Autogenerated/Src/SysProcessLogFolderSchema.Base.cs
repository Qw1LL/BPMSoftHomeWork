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

	#region Class: SysProcessLogFolderSchema

	/// <exclude/>
	public class SysProcessLogFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysProcessLogFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessLogFolderSchema(SysProcessLogFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessLogFolderSchema(SysProcessLogFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			RealUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			Name = "SysProcessLogFolder";
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
			column.ModifiedInSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessLogFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessLogFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessLogFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessLogFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLogFolder

	/// <summary>
	/// Process log folder.
	/// </summary>
	public class SysProcessLogFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysProcessLogFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessLogFolder";
		}

		public SysProcessLogFolder(SysProcessLogFolder source)
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

		private SysProcessLogFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysProcessLogFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysProcessLogFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessLogFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessLogFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessLogFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessLogFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessLogFolderInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessLogFolderSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessLogFolderSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessLogFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessLogFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLogFolder_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessLogFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SysProcessLogFolder
	{

		public SysProcessLogFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessLogFolder_BaseEventsProcess";
			SchemaUId = new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ff2bf4c6-00c1-4e2e-a44e-388074afd013");
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

	#region Class: SysProcessLogFolder_BaseEventsProcess

	/// <exclude/>
	public class SysProcessLogFolder_BaseEventsProcess : SysProcessLogFolder_BaseEventsProcess<SysProcessLogFolder>
	{

		public SysProcessLogFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessLogFolder_BaseEventsProcess

	public partial class SysProcessLogFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: SysProcessLogFolderEventsProcess

	/// <exclude/>
	public class SysProcessLogFolderEventsProcess : SysProcessLogFolder_BaseEventsProcess
	{

		public SysProcessLogFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

