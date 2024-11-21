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

	#region Class: ReleaseInFolderSchema

	/// <exclude/>
	public class ReleaseInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ReleaseInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseInFolderSchema(ReleaseInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseInFolderSchema(ReleaseInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			RealUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			Name = "ReleaseInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4a9409f5-742d-4523-a8f8-0ed724456aa1")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("a044ac8f-94b8-49db-a205-1c8beedae220");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4a9409f5-742d-4523-a8f8-0ed724456aa1"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce"),
				ModifiedInSchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseInFolder_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseInFolder

	/// <summary>
	/// Объект "Релизы" в группе.
	/// </summary>
	public class ReleaseInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ReleaseInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseInFolder";
		}

		public ReleaseInFolder(ReleaseInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релизы .
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseInFolder_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseInFolder_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseInFolder_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ReleaseInFolder
	{

		public ReleaseInFolder_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseInFolder_ReleaseEventsProcess";
			SchemaUId = new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cec6ab4e-8abe-4765-86a7-b812406617ce");
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

	#region Class: ReleaseInFolder_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseInFolder_ReleaseEventsProcess : ReleaseInFolder_ReleaseEventsProcess<ReleaseInFolder>
	{

		public ReleaseInFolder_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseInFolder_ReleaseEventsProcess

	public partial class ReleaseInFolder_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseInFolderEventsProcess

	/// <exclude/>
	public class ReleaseInFolderEventsProcess : ReleaseInFolder_ReleaseEventsProcess
	{

		public ReleaseInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

