namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: UsrTransportRequestsInFolderSchema

	/// <exclude/>
	public class UsrTransportRequestsInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public UsrTransportRequestsInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsInFolderSchema(UsrTransportRequestsInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsInFolderSchema(UsrTransportRequestsInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e");
			RealUId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e");
			Name = "UsrTransportRequestsInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f5e75c2c-0e8e-4985-b74f-1b81f80cb53d")) == null) {
				Columns.Add(CreateUsrTransportRequestsColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUsrTransportRequestsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f5e75c2c-0e8e-4985-b74f-1b81f80cb53d"),
				Name = @"UsrTransportRequests",
				ReferenceSchemaUId = new Guid("ce3557cf-4e38-45eb-aa71-502879d15cd5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e"),
				ModifiedInSchemaUId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e"),
				CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrTransportRequestsInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsInFolder

	/// <summary>
	/// Заявки на транспорт в группе.
	/// </summary>
	public class UsrTransportRequestsInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public UsrTransportRequestsInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsInFolder";
		}

		public UsrTransportRequestsInFolder(UsrTransportRequestsInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid UsrTransportRequestsId {
			get {
				return GetTypedColumnValue<Guid>("UsrTransportRequestsId");
			}
			set {
				SetColumnValue("UsrTransportRequestsId", value);
				_usrTransportRequests = null;
			}
		}

		/// <exclude/>
		public string UsrTransportRequestsUsrName {
			get {
				return GetTypedColumnValue<string>("UsrTransportRequestsUsrName");
			}
			set {
				SetColumnValue("UsrTransportRequestsUsrName", value);
				if (_usrTransportRequests != null) {
					_usrTransportRequests.UsrName = value;
				}
			}
		}

		private UsrTransportRequests _usrTransportRequests;
		/// <summary>
		/// Заявки на транспорт.
		/// </summary>
		public UsrTransportRequests UsrTransportRequests {
			get {
				return _usrTransportRequests ??
					(_usrTransportRequests = LookupColumnEntities.GetEntity("UsrTransportRequests") as UsrTransportRequests);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrTransportRequestsInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : UsrTransportRequestsInFolder
	{

		public UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffe5641f-3d06-452e-93f2-9aa69450bc9e");
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

	#region Class: UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess : UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess<UsrTransportRequestsInFolder>
	{

		public UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsInFolderEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsInFolderEventsProcess : UsrTransportRequestsInFolder_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

