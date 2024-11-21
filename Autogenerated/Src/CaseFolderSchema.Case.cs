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

	#region Class: CaseFolderSchema

	/// <exclude/>
	public class CaseFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public CaseFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseFolderSchema(CaseFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseFolderSchema(CaseFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			RealUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			Name = "CaseFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseFolder_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseFolder

	/// <summary>
	/// Группа раздела "Обращения".
	/// </summary>
	public class CaseFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public CaseFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseFolder";
		}

		public CaseFolder(CaseFolder source)
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

		private CaseFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public CaseFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as CaseFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseFolder_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseFolderDeleted", e);
			Inserting += (s, e) => ThrowEvent("CaseFolderInserting", e);
			Validating += (s, e) => ThrowEvent("CaseFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseFolder_CaseEventsProcess

	/// <exclude/>
	public partial class CaseFolder_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : CaseFolder
	{

		public CaseFolder_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseFolder_CaseEventsProcess";
			SchemaUId = new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("08dcf69a-4cdb-4910-a699-b217a1ebd8c2");
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

	#region Class: CaseFolder_CaseEventsProcess

	/// <exclude/>
	public class CaseFolder_CaseEventsProcess : CaseFolder_CaseEventsProcess<CaseFolder>
	{

		public CaseFolder_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseFolder_CaseEventsProcess

	public partial class CaseFolder_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: CaseFolderEventsProcess

	/// <exclude/>
	public class CaseFolderEventsProcess : CaseFolder_CaseEventsProcess
	{

		public CaseFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

