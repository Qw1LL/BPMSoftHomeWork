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

	#region Class: DelayedNotificationSchema

	/// <exclude/>
	public class DelayedNotificationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public DelayedNotificationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DelayedNotificationSchema(DelayedNotificationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DelayedNotificationSchema(DelayedNotificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5");
			RealUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5");
			Name = "DelayedNotification";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2048a62b-8d61-41be-b497-6d7cd54de9f1")) == null) {
				Columns.Add(CreateCaseColumn());
			}
			if (Columns.FindByUId(new Guid("e19fe873-1dd9-415c-ae62-493afb3c8eda")) == null) {
				Columns.Add(CreateEmailTemplateIdColumn());
			}
			if (Columns.FindByUId(new Guid("66a0c0f7-e346-4f7d-9fce-421fd4d335bc")) == null) {
				Columns.Add(CreateSendDateColumn());
			}
			if (Columns.FindByUId(new Guid("66724952-a182-4adb-b149-87660e94fd5e")) == null) {
				Columns.Add(CreateActualSendDateColumn());
			}
			if (Columns.FindByUId(new Guid("cb4e796d-2aef-49e6-9423-0c841b3e4fb6")) == null) {
				Columns.Add(CreateErrorColumn());
			}
			if (Columns.FindByUId(new Guid("f254b071-50f6-4503-8407-c5e6b46fe3d5")) == null) {
				Columns.Add(CreateDelayColumn());
			}
			if (Columns.FindByUId(new Guid("aebe2ac0-14aa-4539-9073-7624c2a83132")) == null) {
				Columns.Add(CreateAssemblyQualifiedManagerNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2048a62b-8d61-41be-b497-6d7cd54de9f1"),
				Name = @"Case",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailTemplateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e19fe873-1dd9-415c-ae62-493afb3c8eda"),
				Name = @"EmailTemplateId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected virtual EntitySchemaColumn CreateSendDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("66a0c0f7-e346-4f7d-9fce-421fd4d335bc"),
				Name = @"SendDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected virtual EntitySchemaColumn CreateActualSendDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("66724952-a182-4adb-b149-87660e94fd5e"),
				Name = @"ActualSendDate",
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("cb4e796d-2aef-49e6-9423-0c841b3e4fb6"),
				Name = @"Error",
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateDelayColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f254b071-50f6-4503-8407-c5e6b46fe3d5"),
				Name = @"Delay",
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56")
			};
		}

		protected virtual EntitySchemaColumn CreateAssemblyQualifiedManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("aebe2ac0-14aa-4539-9073-7624c2a83132"),
				Name = @"AssemblyQualifiedManagerName",
				CreatedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				ModifiedInSchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"),
				CreatedInPackageId = new Guid("77fa8847-960e-4748-ad77-e37bb90e03a0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DelayedNotification(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DelayedNotification_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DelayedNotificationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DelayedNotificationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5"));
		}

		#endregion

	}

	#endregion

	#region Class: DelayedNotification

	/// <summary>
	/// Отложенное уведомление.
	/// </summary>
	public class DelayedNotification : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public DelayedNotification(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DelayedNotification";
		}

		public DelayedNotification(DelayedNotification source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CaseId {
			get {
				return GetTypedColumnValue<Guid>("CaseId");
			}
			set {
				SetColumnValue("CaseId", value);
				_case = null;
			}
		}

		/// <exclude/>
		public string CaseNumber {
			get {
				return GetTypedColumnValue<string>("CaseNumber");
			}
			set {
				SetColumnValue("CaseNumber", value);
				if (_case != null) {
					_case.Number = value;
				}
			}
		}

		private Case _case;
		/// <summary>
		/// Обращение.
		/// </summary>
		public Case Case {
			get {
				return _case ??
					(_case = LookupColumnEntities.GetEntity("Case") as Case);
			}
		}

		/// <summary>
		/// Шаблон e-mail сообщения.
		/// </summary>
		public Guid EmailTemplateId {
			get {
				return GetTypedColumnValue<Guid>("EmailTemplateId");
			}
			set {
				SetColumnValue("EmailTemplateId", value);
			}
		}

		/// <summary>
		/// Когда отправится.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		/// <summary>
		/// Фактическая дата отправки.
		/// </summary>
		public DateTime ActualSendDate {
			get {
				return GetTypedColumnValue<DateTime>("ActualSendDate");
			}
			set {
				SetColumnValue("ActualSendDate", value);
			}
		}

		/// <summary>
		/// Ошибка.
		/// </summary>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// Задержка.
		/// </summary>
		public int Delay {
			get {
				return GetTypedColumnValue<int>("Delay");
			}
			set {
				SetColumnValue("Delay", value);
			}
		}

		/// <summary>
		/// Assembly Qualified Manager Name.
		/// </summary>
		public string AssemblyQualifiedManagerName {
			get {
				return GetTypedColumnValue<string>("AssemblyQualifiedManagerName");
			}
			set {
				SetColumnValue("AssemblyQualifiedManagerName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DelayedNotification_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DelayedNotificationDeleted", e);
			Validating += (s, e) => ThrowEvent("DelayedNotificationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DelayedNotification(this);
		}

		#endregion

	}

	#endregion

	#region Class: DelayedNotification_CaseServiceEventsProcess

	/// <exclude/>
	public partial class DelayedNotification_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : DelayedNotification
	{

		public DelayedNotification_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DelayedNotification_CaseServiceEventsProcess";
			SchemaUId = new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d0a968b-8809-40b1-b8a6-cff1a57942f5");
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

	#region Class: DelayedNotification_CaseServiceEventsProcess

	/// <exclude/>
	public class DelayedNotification_CaseServiceEventsProcess : DelayedNotification_CaseServiceEventsProcess<DelayedNotification>
	{

		public DelayedNotification_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DelayedNotification_CaseServiceEventsProcess

	public partial class DelayedNotification_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DelayedNotificationEventsProcess

	/// <exclude/>
	public class DelayedNotificationEventsProcess : DelayedNotification_CaseServiceEventsProcess
	{

		public DelayedNotificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

