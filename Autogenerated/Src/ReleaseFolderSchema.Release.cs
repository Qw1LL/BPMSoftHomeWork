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

	#region Class: ReleaseFolderSchema

	/// <exclude/>
	public class ReleaseFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public ReleaseFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseFolderSchema(ReleaseFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseFolderSchema(ReleaseFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			RealUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			Name = "ReleaseFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseFolder_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a044ac8f-94b8-49db-a205-1c8beedae220"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseFolder

	/// <summary>
	/// Группа раздела "Релизы".
	/// </summary>
	public class ReleaseFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public ReleaseFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseFolder";
		}

		public ReleaseFolder(ReleaseFolder source)
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

		private ReleaseFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public ReleaseFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as ReleaseFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseFolder_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseFolder_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseFolder_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : ReleaseFolder
	{

		public ReleaseFolder_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseFolder_ReleaseEventsProcess";
			SchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
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

	#region Class: ReleaseFolder_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseFolder_ReleaseEventsProcess : ReleaseFolder_ReleaseEventsProcess<ReleaseFolder>
	{

		public ReleaseFolder_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseFolder_ReleaseEventsProcess

	public partial class ReleaseFolder_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseFolderEventsProcess

	/// <exclude/>
	public class ReleaseFolderEventsProcess : ReleaseFolder_ReleaseEventsProcess
	{

		public ReleaseFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

