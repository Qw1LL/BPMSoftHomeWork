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

	#region Class: ChangeInFolderSchema

	/// <exclude/>
	public class ChangeInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ChangeInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeInFolderSchema(ChangeInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeInFolderSchema(ChangeInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			RealUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			Name = "ChangeInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f6ba6099-7e99-4338-a2b8-768cc7b3de87")) == null) {
				Columns.Add(CreateChangeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("9462f63e-d284-49cf-a2de-c12911657493");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateChangeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f6ba6099-7e99-4338-a2b8-768cc7b3de87"),
				Name = @"Change",
				ReferenceSchemaUId = new Guid("de5c8d59-d372-407d-8c09-f0523e057e40"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d"),
				ModifiedInSchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d"),
				CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChangeInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangeInFolder_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("310fea8e-590e-4da9-b7b0-6079487db57d"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeInFolder

	/// <summary>
	/// Объект "Изменения" в группе.
	/// </summary>
	public class ChangeInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ChangeInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangeInFolder";
		}

		public ChangeInFolder(ChangeInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ChangeId {
			get {
				return GetTypedColumnValue<Guid>("ChangeId");
			}
			set {
				SetColumnValue("ChangeId", value);
				_change = null;
			}
		}

		/// <exclude/>
		public string ChangeNumber {
			get {
				return GetTypedColumnValue<string>("ChangeNumber");
			}
			set {
				SetColumnValue("ChangeNumber", value);
				if (_change != null) {
					_change.Number = value;
				}
			}
		}

		private Change _change;
		/// <summary>
		/// Изменения.
		/// </summary>
		public Change Change {
			get {
				return _change ??
					(_change = LookupColumnEntities.GetEntity("Change") as Change);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangeInFolder_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangeInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangeInFolder_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangeInFolder_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ChangeInFolder
	{

		public ChangeInFolder_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeInFolder_ChangeEventsProcess";
			SchemaUId = new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("310fea8e-590e-4da9-b7b0-6079487db57d");
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

	#region Class: ChangeInFolder_ChangeEventsProcess

	/// <exclude/>
	public class ChangeInFolder_ChangeEventsProcess : ChangeInFolder_ChangeEventsProcess<ChangeInFolder>
	{

		public ChangeInFolder_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangeInFolder_ChangeEventsProcess

	public partial class ChangeInFolder_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeInFolderEventsProcess

	/// <exclude/>
	public class ChangeInFolderEventsProcess : ChangeInFolder_ChangeEventsProcess
	{

		public ChangeInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

