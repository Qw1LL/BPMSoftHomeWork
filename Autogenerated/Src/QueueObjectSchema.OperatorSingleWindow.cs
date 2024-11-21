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

	#region Class: QueueObjectSchema

	/// <exclude/>
	public class QueueObjectSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QueueObjectSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueObjectSchema(QueueObjectSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueObjectSchema(QueueObjectSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997");
			RealUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997");
			Name = "QueueObject";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEntitySchemaCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3d9651ba-a619-4e15-bea4-88c03f624f40")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4bbc9bbf-2d29-4b8f-a9b2-a57deb7f4587")) == null) {
				Columns.Add(CreateIsClosedQueueColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3d9651ba-a619-4e15-bea4-88c03f624f40"),
				Name = @"EntitySchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				ModifiedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("744e6a8f-4792-4153-a7af-d913c8aab620"),
				Name = @"EntitySchemaCaption",
				CreatedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				ModifiedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateIsClosedQueueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4bbc9bbf-2d29-4b8f-a9b2-a57deb7f4587"),
				Name = @"IsClosedQueue",
				CreatedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				ModifiedInSchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"),
				CreatedInPackageId = new Guid("ac7b57d1-4018-44a2-bf70-c6c0ac8d5a0d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueObject(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueObject_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueObjectSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueObjectSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3117ccf2-594f-437b-8ce9-2a97314af997"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueObject

	/// <summary>
	/// Объект очереди.
	/// </summary>
	public class QueueObject : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QueueObject(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueObject";
		}

		public QueueObject(QueueObject source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Схема.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string EntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("EntitySchemaCaption");
			}
			set {
				SetColumnValue("EntitySchemaCaption", value);
			}
		}

		/// <summary>
		/// Закрытая очередь.
		/// </summary>
		public bool IsClosedQueue {
			get {
				return GetTypedColumnValue<bool>("IsClosedQueue");
			}
			set {
				SetColumnValue("IsClosedQueue", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QueueObject_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueObjectDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueObjectValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueObject(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueObject_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueObject_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QueueObject
	{

		public QueueObject_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueObject_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("3117ccf2-594f-437b-8ce9-2a97314af997");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3117ccf2-594f-437b-8ce9-2a97314af997");
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

	#region Class: QueueObject_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueObject_OperatorSingleWindowEventsProcess : QueueObject_OperatorSingleWindowEventsProcess<QueueObject>
	{

		public QueueObject_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueObject_OperatorSingleWindowEventsProcess

	public partial class QueueObject_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueObjectEventsProcess

	/// <exclude/>
	public class QueueObjectEventsProcess : QueueObject_OperatorSingleWindowEventsProcess
	{

		public QueueObjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

