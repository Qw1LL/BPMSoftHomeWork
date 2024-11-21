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

	#region Class: QueueObjectColumnSchema

	/// <exclude/>
	public class QueueObjectColumnSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QueueObjectColumnSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueObjectColumnSchema(QueueObjectColumnSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueObjectColumnSchema(QueueObjectColumnSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b");
			RealUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b");
			Name = "QueueObjectColumn";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3222ab43-8455-4fa2-acae-0b760089364a")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("530ff1cb-3a2d-440d-9e7e-f18b163aa2d4")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("f4b3c5c2-f8ed-4bf6-96c0-a96c436daa12")) == null) {
				Columns.Add(CreateOrderDirectionColumn());
			}
			if (Columns.FindByUId(new Guid("2b3b281f-718b-43f4-a604-45ab2cb8cece")) == null) {
				Columns.Add(CreateQueueObjectColumn());
			}
			if (Columns.FindByUId(new Guid("e7c637f7-b666-48c3-b787-1bfe974ff55a")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3222ab43-8455-4fa2-acae-0b760089364a"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				ModifiedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("530ff1cb-3a2d-440d-9e7e-f18b163aa2d4"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				ModifiedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderDirectionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f4b3c5c2-f8ed-4bf6-96c0-a96c436daa12"),
				Name = @"OrderDirection",
				ReferenceSchemaUId = new Guid("a1198732-ee72-49a0-b9e7-2b61461f6122"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				ModifiedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateQueueObjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2b3b281f-718b-43f4-a604-45ab2cb8cece"),
				Name = @"QueueObject",
				ReferenceSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				ModifiedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e7c637f7-b666-48c3-b787-1bfe974ff55a"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
				ModifiedInSchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"),
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
			return new QueueObjectColumn(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueObjectColumn_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueObjectColumnSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueObjectColumnSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueObjectColumn

	/// <summary>
	/// Колонка объекта очереди.
	/// </summary>
	public class QueueObjectColumn : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QueueObjectColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueObjectColumn";
		}

		public QueueObjectColumn(QueueObjectColumn source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid OrderDirectionId {
			get {
				return GetTypedColumnValue<Guid>("OrderDirectionId");
			}
			set {
				SetColumnValue("OrderDirectionId", value);
				_orderDirection = null;
			}
		}

		/// <exclude/>
		public string OrderDirectionName {
			get {
				return GetTypedColumnValue<string>("OrderDirectionName");
			}
			set {
				SetColumnValue("OrderDirectionName", value);
				if (_orderDirection != null) {
					_orderDirection.Name = value;
				}
			}
		}

		private SysOrderDirection _orderDirection;
		/// <summary>
		/// Направление сортировки.
		/// </summary>
		public SysOrderDirection OrderDirection {
			get {
				return _orderDirection ??
					(_orderDirection = LookupColumnEntities.GetEntity("OrderDirection") as SysOrderDirection);
			}
		}

		/// <exclude/>
		public Guid QueueObjectId {
			get {
				return GetTypedColumnValue<Guid>("QueueObjectId");
			}
			set {
				SetColumnValue("QueueObjectId", value);
				_queueObject = null;
			}
		}

		/// <exclude/>
		public string QueueObjectEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("QueueObjectEntitySchemaCaption");
			}
			set {
				SetColumnValue("QueueObjectEntitySchemaCaption", value);
				if (_queueObject != null) {
					_queueObject.EntitySchemaCaption = value;
				}
			}
		}

		private QueueObject _queueObject;
		/// <summary>
		/// Объект очереди.
		/// </summary>
		public QueueObject QueueObject {
			get {
				return _queueObject ??
					(_queueObject = LookupColumnEntities.GetEntity("QueueObject") as QueueObject);
			}
		}

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueObjectColumn_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueObjectColumnDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueObjectColumnValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueObjectColumn(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueObjectColumn_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueObjectColumn_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QueueObjectColumn
	{

		public QueueObjectColumn_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueObjectColumn_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("68bf7df2-6f74-431a-9122-e2cf5edf283b");
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

	#region Class: QueueObjectColumn_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueObjectColumn_OperatorSingleWindowEventsProcess : QueueObjectColumn_OperatorSingleWindowEventsProcess<QueueObjectColumn>
	{

		public QueueObjectColumn_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueObjectColumn_OperatorSingleWindowEventsProcess

	public partial class QueueObjectColumn_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueObjectColumnEventsProcess

	/// <exclude/>
	public class QueueObjectColumnEventsProcess : QueueObjectColumn_OperatorSingleWindowEventsProcess
	{

		public QueueObjectColumnEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

