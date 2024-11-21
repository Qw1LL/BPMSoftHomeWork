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

	#region Class: UsrTransportRequestsFolderSchema

	/// <exclude/>
	public class UsrTransportRequestsFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public UsrTransportRequestsFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UsrTransportRequestsFolderSchema(UsrTransportRequestsFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UsrTransportRequestsFolderSchema(UsrTransportRequestsFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			RealUId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			Name = "UsrTransportRequestsFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c4d067d-156b-4f1a-95fd-baa9da73b631");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UsrTransportRequestsFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UsrTransportRequestsFolder_UsrHomeWorkEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UsrTransportRequestsFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UsrTransportRequestsFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7"));
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsFolder

	/// <summary>
	/// Группа Заявки на транспорт.
	/// </summary>
	public class UsrTransportRequestsFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public UsrTransportRequestsFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UsrTransportRequestsFolder";
		}

		public UsrTransportRequestsFolder(UsrTransportRequestsFolder source)
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

		private UsrTransportRequestsFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public UsrTransportRequestsFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as UsrTransportRequestsFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UsrTransportRequestsFolder_UsrHomeWorkEventsProcess(UserConnection);
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
			return new UsrTransportRequestsFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: UsrTransportRequestsFolder_UsrHomeWorkEventsProcess

	/// <exclude/>
	public partial class UsrTransportRequestsFolder_UsrHomeWorkEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : UsrTransportRequestsFolder
	{

		public UsrTransportRequestsFolder_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UsrTransportRequestsFolder_UsrHomeWorkEventsProcess";
			SchemaUId = new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eebf91b6-23b7-4be1-aa4e-eea3db3edec7");
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

	#region Class: UsrTransportRequestsFolder_UsrHomeWorkEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsFolder_UsrHomeWorkEventsProcess : UsrTransportRequestsFolder_UsrHomeWorkEventsProcess<UsrTransportRequestsFolder>
	{

		public UsrTransportRequestsFolder_UsrHomeWorkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UsrTransportRequestsFolder_UsrHomeWorkEventsProcess

	public partial class UsrTransportRequestsFolder_UsrHomeWorkEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UsrTransportRequestsFolderEventsProcess

	/// <exclude/>
	public class UsrTransportRequestsFolderEventsProcess : UsrTransportRequestsFolder_UsrHomeWorkEventsProcess
	{

		public UsrTransportRequestsFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

