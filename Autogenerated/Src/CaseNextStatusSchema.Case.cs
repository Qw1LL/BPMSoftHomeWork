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

	#region Class: CaseNextStatusSchema

	/// <exclude/>
	public class CaseNextStatusSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CaseNextStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CaseNextStatusSchema(CaseNextStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CaseNextStatusSchema(CaseNextStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			RealUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			Name = "CaseNextStatus";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4ae71ddd-d8a1-4a88-8e05-068a24d34eb3")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("85863593-1a81-4909-8eed-62ce3f43b196")) == null) {
				Columns.Add(CreateNextStatusColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			column.CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4ae71ddd-d8a1-4a88-8e05-068a24d34eb3"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateNextStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("85863593-1a81-4909-8eed-62ce3f43b196"),
				Name = @"NextStatus",
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				CreatedInPackageId = new Guid("305fcfca-4160-4398-90a9-d5e84be0ae12")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0f55b2b9-4502-4409-990c-2f8e5edcc70d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				ModifiedInSchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"),
				CreatedInPackageId = new Guid("a7919973-994c-4956-b846-530c9ef3b289"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CaseNextStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CaseNextStatus_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CaseNextStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CaseNextStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00"));
		}

		#endregion

	}

	#endregion

	#region Class: CaseNextStatus

	/// <summary>
	/// Действия при смене состояния обращений.
	/// </summary>
	public class CaseNextStatus : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CaseNextStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CaseNextStatus";
		}

		public CaseNextStatus(CaseNextStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private CaseStatus _status;
		/// <summary>
		/// Предыдущее состояние.
		/// </summary>
		public CaseStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CaseStatus);
			}
		}

		/// <exclude/>
		public Guid NextStatusId {
			get {
				return GetTypedColumnValue<Guid>("NextStatusId");
			}
			set {
				SetColumnValue("NextStatusId", value);
				_nextStatus = null;
			}
		}

		/// <exclude/>
		public string NextStatusName {
			get {
				return GetTypedColumnValue<string>("NextStatusName");
			}
			set {
				SetColumnValue("NextStatusName", value);
				if (_nextStatus != null) {
					_nextStatus.Name = value;
				}
			}
		}

		private CaseStatus _nextStatus;
		/// <summary>
		/// Текущее состояние.
		/// </summary>
		public CaseStatus NextStatus {
			get {
				return _nextStatus ??
					(_nextStatus = LookupColumnEntities.GetEntity("NextStatus") as CaseStatus);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CaseNextStatus_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CaseNextStatusDeleted", e);
			Inserting += (s, e) => ThrowEvent("CaseNextStatusInserting", e);
			Validating += (s, e) => ThrowEvent("CaseNextStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CaseNextStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: CaseNextStatus_CaseEventsProcess

	/// <exclude/>
	public partial class CaseNextStatus_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CaseNextStatus
	{

		public CaseNextStatus_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CaseNextStatus_CaseEventsProcess";
			SchemaUId = new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e43e673d-fdd2-45d5-8672-a2bca1a14f00");
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

	#region Class: CaseNextStatus_CaseEventsProcess

	/// <exclude/>
	public class CaseNextStatus_CaseEventsProcess : CaseNextStatus_CaseEventsProcess<CaseNextStatus>
	{

		public CaseNextStatus_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CaseNextStatus_CaseEventsProcess

	public partial class CaseNextStatus_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CaseNextStatusEventsProcess

	/// <exclude/>
	public class CaseNextStatusEventsProcess : CaseNextStatus_CaseEventsProcess
	{

		public CaseNextStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

