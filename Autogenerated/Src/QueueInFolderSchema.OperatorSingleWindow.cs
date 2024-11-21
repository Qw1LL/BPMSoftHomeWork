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

	#region Class: QueueInFolderSchema

	/// <exclude/>
	public class QueueInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public QueueInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueInFolderSchema(QueueInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueInFolderSchema(QueueInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53");
			RealUId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53");
			Name = "QueueInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("25b08bcb-ee5d-457f-8102-417af7e7aab3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bf03d660-9bfe-4d6c-8643-dc78565ba88d")) == null) {
				Columns.Add(CreateQueueColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("c05c1e5c-f5e1-4c0d-b2f9-fcf4bb0450e1");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53");
			return column;
		}

		protected virtual EntitySchemaColumn CreateQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bf03d660-9bfe-4d6c-8643-dc78565ba88d"),
				Name = @"Queue",
				ReferenceSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53"),
				ModifiedInSchemaUId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53"),
				CreatedInPackageId = new Guid("25b08bcb-ee5d-457f-8102-417af7e7aab3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueInFolder_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b616055f-dee1-459b-86f7-37c313c85b53"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueInFolder

	/// <summary>
	/// Очередь в группе.
	/// </summary>
	public class QueueInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public QueueInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueInFolder";
		}

		public QueueInFolder(QueueInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid QueueId {
			get {
				return GetTypedColumnValue<Guid>("QueueId");
			}
			set {
				SetColumnValue("QueueId", value);
				_queue = null;
			}
		}

		/// <exclude/>
		public string QueueName {
			get {
				return GetTypedColumnValue<string>("QueueName");
			}
			set {
				SetColumnValue("QueueName", value);
				if (_queue != null) {
					_queue.Name = value;
				}
			}
		}

		private Queue _queue;
		/// <summary>
		/// Очередь.
		/// </summary>
		public Queue Queue {
			get {
				return _queue ??
					(_queue = LookupColumnEntities.GetEntity("Queue") as Queue);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueInFolder_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueInFolderDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueInFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueInFolder_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : QueueInFolder
	{

		public QueueInFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueInFolder_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("b616055f-dee1-459b-86f7-37c313c85b53");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b616055f-dee1-459b-86f7-37c313c85b53");
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

	#region Class: QueueInFolder_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueInFolder_OperatorSingleWindowEventsProcess : QueueInFolder_OperatorSingleWindowEventsProcess<QueueInFolder>
	{

		public QueueInFolder_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueInFolder_OperatorSingleWindowEventsProcess

	public partial class QueueInFolder_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueInFolderEventsProcess

	/// <exclude/>
	public class QueueInFolderEventsProcess : QueueInFolder_OperatorSingleWindowEventsProcess
	{

		public QueueInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

