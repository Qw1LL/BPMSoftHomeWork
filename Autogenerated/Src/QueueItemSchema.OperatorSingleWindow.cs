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

	#region Class: QueueItemSchema

	/// <exclude/>
	public class QueueItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QueueItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueItemSchema(QueueItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueItemSchema(QueueItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIQueueItemEntityRecordIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("509862e6-feb8-4d86-8181-3734686e5c1f");
			index.Name = "IQueueItemEntityRecordId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn entityRecordIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2bdc98e1-62f3-48a6-9fc0-74cce71d2f69"),
				ColumnUId = new Guid("c4b1d2f2-528c-4e66-9440-67125f0707dd"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(entityRecordIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIQueueItemSysProcessDataIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5fba2821-bfcc-43cc-a324-ba78d4885aa2");
			index.Name = "IQueueItemSysProcessDataId";
			index.CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			index.CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7");
			EntitySchemaIndexColumn sysProcessDataIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ed385332-3853-404c-aaeb-879761c31bae"),
				ColumnUId = new Guid("96eca8e1-84f2-4c9d-8b05-8c0d852211bf"),
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysProcessDataIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			RealUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			Name = "QueueItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("abcbbc92-a450-468f-8de0-7d1a067a9dfb")) == null) {
				Columns.Add(CreateQueueColumn());
			}
			if (Columns.FindByUId(new Guid("c4b1d2f2-528c-4e66-9440-67125f0707dd")) == null) {
				Columns.Add(CreateEntityRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("96eca8e1-84f2-4c9d-8b05-8c0d852211bf")) == null) {
				Columns.Add(CreateSysProcessDataIdColumn());
			}
			if (Columns.FindByUId(new Guid("55238bd8-7854-4777-b834-fe5df5b1f93b")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("e8f8b431-b576-4bdf-b4c0-3f8e996eb152")) == null) {
				Columns.Add(CreateOperatorColumn());
			}
			if (Columns.FindByUId(new Guid("3f39d201-f351-4b7d-85e4-4fd9b5c98276")) == null) {
				Columns.Add(CreateNextProcessingDateColumn());
			}
			if (Columns.FindByUId(new Guid("07ddc779-6d74-4ecc-ba07-7856ece4a869")) == null) {
				Columns.Add(CreatePostponesCountColumn());
			}
			if (Columns.FindByUId(new Guid("7c89df9b-ab26-4c93-a7a4-afe029892586")) == null) {
				Columns.Add(CreateNextProcessingDateOrderColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("abcbbc92-a450-468f-8de0-7d1a067a9dfb"),
				Name = @"Queue",
				ReferenceSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c4b1d2f2-528c-4e66-9440-67125f0707dd"),
				Name = @"EntityRecordId",
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessDataIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("96eca8e1-84f2-4c9d-8b05-8c0d852211bf"),
				Name = @"SysProcessDataId",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("b37272aa-ca79-4db2-9717-1c02e42cc793")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("55238bd8-7854-4777-b834-fe5df5b1f93b"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2b341a1d-6fa1-4960-9c85-fef60d1bbcc4"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOperatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e8f8b431-b576-4bdf-b4c0-3f8e996eb152"),
				Name = @"Operator",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4")
			};
		}

		protected virtual EntitySchemaColumn CreateNextProcessingDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("3f39d201-f351-4b7d-85e4-4fd9b5c98276"),
				Name = @"NextProcessingDate",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("b37272aa-ca79-4db2-9717-1c02e42cc793")
			};
		}

		protected virtual EntitySchemaColumn CreatePostponesCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("07ddc779-6d74-4ecc-ba07-7856ece4a869"),
				Name = @"PostponesCount",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("17d3ccf0-1ef7-49ce-9023-b1aec1bd39b7")
			};
		}

		protected virtual EntitySchemaColumn CreateNextProcessingDateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7c89df9b-ab26-4c93-a7a4-afe029892586"),
				Name = @"NextProcessingDateOrder",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("cbb457cb-1ef4-428e-937c-db6aedb72e75")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2569b65f-95d2-44e2-9934-212b07a1c7fe"),
				Name = @"Caption",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				ModifiedInSchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"),
				CreatedInPackageId = new Guid("63f413ca-9930-4bfd-b41c-141316c68227"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"Queue item"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIQueueItemEntityRecordIdIndex());
			Indexes.Add(CreateIQueueItemSysProcessDataIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueItem_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueItem

	/// <summary>
	/// Элемент очереди единого окна.
	/// </summary>
	public class QueueItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QueueItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueItem";
		}

		public QueueItem(QueueItem source)
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

		/// <summary>
		/// Идентификатор записи связанного объекта.
		/// </summary>
		public Guid EntityRecordId {
			get {
				return GetTypedColumnValue<Guid>("EntityRecordId");
			}
			set {
				SetColumnValue("EntityRecordId", value);
			}
		}

		/// <summary>
		/// Экземпляр запущенного процесса.
		/// </summary>
		public Guid SysProcessDataId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessDataId");
			}
			set {
				SetColumnValue("SysProcessDataId", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private QueueItemStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public QueueItemStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as QueueItemStatus);
			}
		}

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

		/// <summary>
		/// Дата следующей обработки.
		/// </summary>
		public DateTime NextProcessingDate {
			get {
				return GetTypedColumnValue<DateTime>("NextProcessingDate");
			}
			set {
				SetColumnValue("NextProcessingDate", value);
			}
		}

		/// <summary>
		/// Количество переносов.
		/// </summary>
		public int PostponesCount {
			get {
				return GetTypedColumnValue<int>("PostponesCount");
			}
			set {
				SetColumnValue("PostponesCount", value);
			}
		}

		/// <summary>
		/// Порядок сортировки по дате обработки.
		/// </summary>
		public int NextProcessingDateOrder {
			get {
				return GetTypedColumnValue<int>("NextProcessingDateOrder");
			}
			set {
				SetColumnValue("NextProcessingDateOrder", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueItem_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueItemDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueItem_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueItem_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QueueItem
	{

		public QueueItem_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueItem_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5baf4f89-16e6-43f8-a27f-930d372576fb");
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

	#region Class: QueueItem_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueItem_OperatorSingleWindowEventsProcess : QueueItem_OperatorSingleWindowEventsProcess<QueueItem>
	{

		public QueueItem_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueItem_OperatorSingleWindowEventsProcess

	public partial class QueueItem_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueItemEventsProcess

	/// <exclude/>
	public class QueueItemEventsProcess : QueueItem_OperatorSingleWindowEventsProcess
	{

		public QueueItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

