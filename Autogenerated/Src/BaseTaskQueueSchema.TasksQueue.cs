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

	#region Class: BaseTaskQueueSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseTaskQueueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseTaskQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseTaskQueueSchema(BaseTaskQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseTaskQueueSchema(BaseTaskQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1");
			RealUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1");
			Name = "BaseTaskQueue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7681a7e0-8c03-e479-7666-e3f11f902c55")) == null) {
				Columns.Add(CreateMaxRetryCountColumn());
			}
			if (Columns.FindByUId(new Guid("25bf5acb-18c9-5346-fed5-d3627fd1c35c")) == null) {
				Columns.Add(CreateMessageTypeColumn());
			}
			if (Columns.FindByUId(new Guid("621fc329-92ca-1b76-c441-47dfea925ca1")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("2048c5bf-02c1-32b6-6973-8b2d2bbb1019")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMaxRetryCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7681a7e0-8c03-e479-7666-e3f11f902c55"),
				Name = @"MaxRetryCount",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				ModifiedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMessageTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("25bf5acb-18c9-5346-fed5-d3627fd1c35c"),
				Name = @"MessageType",
				CreatedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				ModifiedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("621fc329-92ca-1b76-c441-47dfea925ca1"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				ModifiedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2048c5bf-02c1-32b6-6973-8b2d2bbb1019"),
				Name = @"Priority",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				ModifiedInSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"),
				CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseTaskQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseTaskQueue_TasksQueueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseTaskQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseTaskQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseTaskQueue

	/// <summary>
	/// Base entity for tasks queue.
	/// </summary>
	public class BaseTaskQueue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseTaskQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseTaskQueue";
		}

		public BaseTaskQueue(BaseTaskQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Max retry count for message.
		/// </summary>
		public int MaxRetryCount {
			get {
				return GetTypedColumnValue<int>("MaxRetryCount");
			}
			set {
				SetColumnValue("MaxRetryCount", value);
			}
		}

		/// <summary>
		/// Message type.
		/// </summary>
		public int MessageType {
			get {
				return GetTypedColumnValue<int>("MessageType");
			}
			set {
				SetColumnValue("MessageType", value);
			}
		}

		/// <summary>
		/// Message in JSON format.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// Priority.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseTaskQueue_TasksQueueEventsProcess(UserConnection);
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
			return new BaseTaskQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseTaskQueue_TasksQueueEventsProcess

	/// <exclude/>
	public partial class BaseTaskQueue_TasksQueueEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseTaskQueue
	{

		public BaseTaskQueue_TasksQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseTaskQueue_TasksQueueEventsProcess";
			SchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1");
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

	#region Class: BaseTaskQueue_TasksQueueEventsProcess

	/// <exclude/>
	public class BaseTaskQueue_TasksQueueEventsProcess : BaseTaskQueue_TasksQueueEventsProcess<BaseTaskQueue>
	{

		public BaseTaskQueue_TasksQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseTaskQueue_TasksQueueEventsProcess

	public partial class BaseTaskQueue_TasksQueueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BaseTaskQueueEventsProcess

	/// <exclude/>
	public class BaseTaskQueueEventsProcess : BaseTaskQueue_TasksQueueEventsProcess
	{

		public BaseTaskQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

