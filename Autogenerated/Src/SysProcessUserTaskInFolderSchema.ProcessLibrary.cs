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

	#region Class: SysProcessUserTaskInFolderSchema

	/// <exclude/>
	public class SysProcessUserTaskInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public SysProcessUserTaskInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessUserTaskInFolderSchema(SysProcessUserTaskInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessUserTaskInFolderSchema(SysProcessUserTaskInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			RealUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			Name = "SysProcessUserTaskInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
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
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("4c0db497-99a8-4b79-a43e-ba17a2abf951");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			column.CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
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
			return new SysProcessUserTaskInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessUserTaskInFolder_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessUserTaskInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessUserTaskInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTaskInFolder

	/// <summary>
	/// "Process user task" object in folder.
	/// </summary>
	public class SysProcessUserTaskInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public SysProcessUserTaskInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessUserTaskInFolder";
		}

		public SysProcessUserTaskInFolder(SysProcessUserTaskInFolder source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessUserTaskInFolder_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessUserTaskInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("SysProcessUserTaskInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessUserTaskInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessUserTaskInFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class SysProcessUserTaskInFolder_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : SysProcessUserTaskInFolder
	{

		public SysProcessUserTaskInFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessUserTaskInFolder_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7cf00d13-3a5d-4de5-a8c2-3be1c6d824ac");
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

	#region Class: SysProcessUserTaskInFolder_ProcessLibraryEventsProcess

	/// <exclude/>
	public class SysProcessUserTaskInFolder_ProcessLibraryEventsProcess : SysProcessUserTaskInFolder_ProcessLibraryEventsProcess<SysProcessUserTaskInFolder>
	{

		public SysProcessUserTaskInFolder_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessUserTaskInFolder_ProcessLibraryEventsProcess

	public partial class SysProcessUserTaskInFolder_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessUserTaskInFolderEventsProcess

	/// <exclude/>
	public class SysProcessUserTaskInFolderEventsProcess : SysProcessUserTaskInFolder_ProcessLibraryEventsProcess
	{

		public SysProcessUserTaskInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

