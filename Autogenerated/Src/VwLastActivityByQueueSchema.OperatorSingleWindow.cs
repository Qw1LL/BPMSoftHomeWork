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

	#region Class: VwLastActivityByQueueSchema

	/// <exclude/>
	public class VwLastActivityByQueueSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwLastActivityByQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwLastActivityByQueueSchema(VwLastActivityByQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwLastActivityByQueueSchema(VwLastActivityByQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce66001d-bc56-490b-af77-c72b17362148");
			RealUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148");
			Name = "VwLastActivityByQueue";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5e667a77-85ba-48fd-906c-e2f7f26b8e6d");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9138b068-e0ae-4301-a68b-b65f541196a2")) == null) {
				Columns.Add(CreateActivityColumn());
			}
			if (Columns.FindByUId(new Guid("856864eb-3844-4f76-8dfe-0e3e7602f881")) == null) {
				Columns.Add(CreateQueueItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("76d60c1c-d6ad-4cc3-947a-a3aa95ebc5e4"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				ModifiedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				CreatedInPackageId = new Guid("5e667a77-85ba-48fd-906c-e2f7f26b8e6d")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9138b068-e0ae-4301-a68b-b65f541196a2"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				ModifiedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				CreatedInPackageId = new Guid("5e667a77-85ba-48fd-906c-e2f7f26b8e6d")
			};
		}

		protected virtual EntitySchemaColumn CreateQueueItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("856864eb-3844-4f76-8dfe-0e3e7602f881"),
				Name = @"QueueItem",
				ReferenceSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				ModifiedInSchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148"),
				CreatedInPackageId = new Guid("5e667a77-85ba-48fd-906c-e2f7f26b8e6d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwLastActivityByQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwLastActivityByQueue_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwLastActivityByQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwLastActivityByQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce66001d-bc56-490b-af77-c72b17362148"));
		}

		#endregion

	}

	#endregion

	#region Class: VwLastActivityByQueue

	/// <summary>
	/// Последняя активность по элементу очереди (obsolete, see VwQueueItem).
	/// </summary>
	public class VwLastActivityByQueue : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwLastActivityByQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwLastActivityByQueue";
		}

		public VwLastActivityByQueue(VwLastActivityByQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Активность.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		/// <exclude/>
		public Guid QueueItemId {
			get {
				return GetTypedColumnValue<Guid>("QueueItemId");
			}
			set {
				SetColumnValue("QueueItemId", value);
				_queueItem = null;
			}
		}

		/// <exclude/>
		public string QueueItemCaption {
			get {
				return GetTypedColumnValue<string>("QueueItemCaption");
			}
			set {
				SetColumnValue("QueueItemCaption", value);
				if (_queueItem != null) {
					_queueItem.Caption = value;
				}
			}
		}

		private QueueItem _queueItem;
		/// <summary>
		/// Элемент очереди единого окна.
		/// </summary>
		public QueueItem QueueItem {
			get {
				return _queueItem ??
					(_queueItem = LookupColumnEntities.GetEntity("QueueItem") as QueueItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwLastActivityByQueue_OperatorSingleWindowEventsProcess(UserConnection);
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
			return new VwLastActivityByQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwLastActivityByQueue_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class VwLastActivityByQueue_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwLastActivityByQueue
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwLastActivityByQueue_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwLastActivityByQueue_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("ce66001d-bc56-490b-af77-c72b17362148");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce66001d-bc56-490b-af77-c72b17362148");
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

	#region Class: VwLastActivityByQueue_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class VwLastActivityByQueue_OperatorSingleWindowEventsProcess : VwLastActivityByQueue_OperatorSingleWindowEventsProcess<VwLastActivityByQueue>
	{

		public VwLastActivityByQueue_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwLastActivityByQueue_OperatorSingleWindowEventsProcess

	public partial class VwLastActivityByQueue_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwLastActivityByQueueEventsProcess

	/// <exclude/>
	public class VwLastActivityByQueueEventsProcess : VwLastActivityByQueue_OperatorSingleWindowEventsProcess
	{

		public VwLastActivityByQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

