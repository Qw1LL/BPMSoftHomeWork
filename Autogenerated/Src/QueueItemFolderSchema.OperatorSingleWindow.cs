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

	#region Class: QueueItemFolderSchema

	/// <exclude/>
	public class QueueItemFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public QueueItemFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueItemFolderSchema(QueueItemFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueItemFolderSchema(QueueItemFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05");
			RealUId = new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05");
			Name = "QueueItemFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("da9d27e8-fcb8-44f6-85d5-e52d7912ab44");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("aadf2fcd-684b-4414-8317-bf9879e97569");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentCaption";
			column.IsWeakReference = true;
			column.IsCascade = false;
			column.ModifiedInSchemaUId = new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueItemFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueItemFolder_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueItemFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueItemFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueItemFolder

	/// <summary>
	/// Группа элемента очереди.
	/// </summary>
	public class QueueItemFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public QueueItemFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueItemFolder";
		}

		public QueueItemFolder(QueueItemFolder source)
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
		public string ParentCaption {
			get {
				return GetTypedColumnValue<string>("ParentCaption");
			}
			set {
				SetColumnValue("ParentCaption", value);
				if (_parent != null) {
					_parent.Caption = value;
				}
			}
		}

		private VwQueueItem _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public VwQueueItem Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as VwQueueItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueItemFolder_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueItemFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueItemFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueItemFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueItemFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueItemFolder_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : QueueItemFolder
	{

		public QueueItemFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueItemFolder_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c6276b54-7c7c-4042-b4a1-bc9d649aec05");
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

	#region Class: QueueItemFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueItemFolder_OperatorSingleWindowEventsProcess : QueueItemFolder_OperatorSingleWindowEventsProcess<QueueItemFolder>
	{

		public QueueItemFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueItemFolder_OperatorSingleWindowEventsProcess

	public partial class QueueItemFolder_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueItemFolderEventsProcess

	/// <exclude/>
	public class QueueItemFolderEventsProcess : QueueItemFolder_OperatorSingleWindowEventsProcess
	{

		public QueueItemFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

