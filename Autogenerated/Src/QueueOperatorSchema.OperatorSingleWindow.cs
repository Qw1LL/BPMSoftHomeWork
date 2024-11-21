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

	#region Class: QueueOperatorSchema

	/// <exclude/>
	public class QueueOperatorSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QueueOperatorSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueOperatorSchema(QueueOperatorSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueOperatorSchema(QueueOperatorSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977");
			RealUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977");
			Name = "QueueOperator";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("061e567f-d9ce-4c51-b780-0aded3f9626e")) == null) {
				Columns.Add(CreateOperatorColumn());
			}
			if (Columns.FindByUId(new Guid("aa0c38ea-9824-416c-b710-6aebc1579492")) == null) {
				Columns.Add(CreateQueueColumn());
			}
			if (Columns.FindByUId(new Guid("dd12e0fb-301f-49e2-a98e-52e16f30dfcd")) == null) {
				Columns.Add(CreateActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("061e567f-d9ce-4c51-b780-0aded3f9626e"),
				Name = @"Operator",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				ModifiedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("aa0c38ea-9824-416c-b710-6aebc1579492"),
				Name = @"Queue",
				ReferenceSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				ModifiedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("dd12e0fb-301f-49e2-a98e-52e16f30dfcd"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				ModifiedInSchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueOperator(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueOperator_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueOperatorSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueOperatorSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e205d6a1-401c-4219-bc5d-390efd220977"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueOperator

	/// <summary>
	/// Оператор очереди.
	/// </summary>
	public class QueueOperator : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QueueOperator(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueOperator";
		}

		public QueueOperator(QueueOperator source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OperatorId {
			get {
				return GetTypedColumnValue<Guid>("OperatorId");
			}
			set {
				SetColumnValue("OperatorId", value);
				_operator = null;
			}
		}

		/// <exclude/>
		public string OperatorName {
			get {
				return GetTypedColumnValue<string>("OperatorName");
			}
			set {
				SetColumnValue("OperatorName", value);
				if (_operator != null) {
					_operator.Name = value;
				}
			}
		}

		private Contact _operator;
		/// <summary>
		/// Оператор.
		/// </summary>
		public Contact Operator {
			get {
				return _operator ??
					(_operator = LookupColumnEntities.GetEntity("Operator") as Contact);
			}
		}

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

		/// <summary>
		/// Активный.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueOperator_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueOperatorDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueOperatorValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueOperator(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueOperator_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueOperator_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QueueOperator
	{

		public QueueOperator_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueOperator_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("e205d6a1-401c-4219-bc5d-390efd220977");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e205d6a1-401c-4219-bc5d-390efd220977");
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

	#region Class: QueueOperator_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueOperator_OperatorSingleWindowEventsProcess : QueueOperator_OperatorSingleWindowEventsProcess<QueueOperator>
	{

		public QueueOperator_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueOperator_OperatorSingleWindowEventsProcess

	public partial class QueueOperator_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueOperatorEventsProcess

	/// <exclude/>
	public class QueueOperatorEventsProcess : QueueOperator_OperatorSingleWindowEventsProcess
	{

		public QueueOperatorEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

