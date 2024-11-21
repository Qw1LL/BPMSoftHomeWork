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

	#region Class: QueueFolderSchema

	/// <exclude/>
	public class QueueFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public QueueFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueFolderSchema(QueueFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueFolderSchema(QueueFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			RealUId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			Name = "QueueFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("25b08bcb-ee5d-457f-8102-417af7e7aab3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueFolder_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueFolder

	/// <summary>
	/// Группа очереди.
	/// </summary>
	public class QueueFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public QueueFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueFolder";
		}

		public QueueFolder(QueueFolder source)
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

		private QueueFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public QueueFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as QueueFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueFolder_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueFolder_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : QueueFolder
	{

		public QueueFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueFolder_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
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

	#region Class: QueueFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueFolder_OperatorSingleWindowEventsProcess : QueueFolder_OperatorSingleWindowEventsProcess<QueueFolder>
	{

		public QueueFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueFolder_OperatorSingleWindowEventsProcess

	public partial class QueueFolder_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: QueueFolderEventsProcess

	/// <exclude/>
	public class QueueFolderEventsProcess : QueueFolder_OperatorSingleWindowEventsProcess
	{

		public QueueFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

