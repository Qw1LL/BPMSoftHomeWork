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

	#region Class: SysProcessUserTaskFolderSchema

	/// <exclude/>
	public class SysProcessUserTaskFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public SysProcessUserTaskFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessUserTaskFolderSchema(SysProcessUserTaskFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessUserTaskFolderSchema(SysProcessUserTaskFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			RealUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			Name = "SysProcessUserTaskFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateSearchDataColumn() {
			EntitySchemaColumn column = base.CreateSearchDataColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessUserTaskFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessUserTaskFolder_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessUserTaskFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessUserTaskFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTaskFolder

	/// <summary>
	/// Section folder - "Process user tasks".
	/// </summary>
	public class SysProcessUserTaskFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public SysProcessUserTaskFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessUserTaskFolder";
		}

		public SysProcessUserTaskFolder(SysProcessUserTaskFolder source)
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

		private SysProcessUserTaskFolder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysProcessUserTaskFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysProcessUserTaskFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessUserTaskFolder_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessUserTaskFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SysProcessUserTaskFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessUserTaskFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTaskFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class SysProcessUserTaskFolder_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : SysProcessUserTaskFolder
	{

		public SysProcessUserTaskFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessUserTaskFolder_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
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

	#region Class: SysProcessUserTaskFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public class SysProcessUserTaskFolder_ProcessLibraryEventsProcess : SysProcessUserTaskFolder_ProcessLibraryEventsProcess<SysProcessUserTaskFolder>
	{

		public SysProcessUserTaskFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessUserTaskFolder_ProcessLibraryEventsProcess

	public partial class SysProcessUserTaskFolder_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: SysProcessUserTaskFolderEventsProcess

	/// <exclude/>
	public class SysProcessUserTaskFolderEventsProcess : SysProcessUserTaskFolder_ProcessLibraryEventsProcess
	{

		public SysProcessUserTaskFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

