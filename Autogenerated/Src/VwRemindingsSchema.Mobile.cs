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

	#region Class: VwRemindingsSchema

	/// <exclude/>
	public class VwRemindingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwRemindingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwRemindingsSchema(VwRemindingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwRemindingsSchema(VwRemindingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71");
			RealUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71");
			Name = "VwRemindings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSubjectCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6c9806b7-b828-4c39-8669-3f658a4a3ad9")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("0a71ab58-3ef3-4586-b242-42a240ce0ddb")) == null) {
				Columns.Add(CreateRemindTimeColumn());
			}
			if (Columns.FindByUId(new Guid("eb350498-e740-4ea6-903e-3594053f70ca")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("7d750350-ae76-4ced-a908-9dd00cda6299")) == null) {
				Columns.Add(CreateSysEntitySchemaIdColumn());
			}
			if (Columns.FindByUId(new Guid("b2b3b857-f90a-43c8-a0f5-6c19925c7e15")) == null) {
				Columns.Add(CreateSubjectIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6c9806b7-b828-4c39-8669-3f658a4a3ad9"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("0a71ab58-3ef3-4586-b242-42a240ce0ddb"),
				Name = @"RemindTime",
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("eb350498-e740-4ea6-903e-3594053f70ca"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7d750350-ae76-4ced-a908-9dd00cda6299"),
				Name = @"SysEntitySchemaId",
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("26932511-b06a-483d-8d17-712ebc9dffab"),
				Name = @"SubjectCaption",
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b2b3b857-f90a-43c8-a0f5-6c19925c7e15"),
				Name = @"SubjectId",
				CreatedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				ModifiedInSchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71"),
				CreatedInPackageId = new Guid("03471644-00c7-4a31-9ef3-75f255a23c85")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwRemindings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwRemindings_MobileEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwRemindingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwRemindingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e350f30-bb86-4705-953c-b9782d674a71"));
		}

		#endregion

	}

	#endregion

	#region Class: VwRemindings

	/// <summary>
	/// Напоминания (представление).
	/// </summary>
	public class VwRemindings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwRemindings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRemindings";
		}

		public VwRemindings(VwRemindings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Время напоминания.
		/// </summary>
		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор объекта.
		/// </summary>
		public Guid SysEntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaId");
			}
			set {
				SetColumnValue("SysEntitySchemaId", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string SubjectCaption {
			get {
				return GetTypedColumnValue<string>("SubjectCaption");
			}
			set {
				SetColumnValue("SubjectCaption", value);
			}
		}

		/// <summary>
		/// Уникальный идентификатор заголовка.
		/// </summary>
		public Guid SubjectId {
			get {
				return GetTypedColumnValue<Guid>("SubjectId");
			}
			set {
				SetColumnValue("SubjectId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwRemindings_MobileEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwRemindingsDeleted", e);
			Validating += (s, e) => ThrowEvent("VwRemindingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwRemindings(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwRemindings_MobileEventsProcess

	/// <exclude/>
	public partial class VwRemindings_MobileEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwRemindings
	{

		public VwRemindings_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwRemindings_MobileEventsProcess";
			SchemaUId = new Guid("9e350f30-bb86-4705-953c-b9782d674a71");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9e350f30-bb86-4705-953c-b9782d674a71");
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

	#region Class: VwRemindings_MobileEventsProcess

	/// <exclude/>
	public class VwRemindings_MobileEventsProcess : VwRemindings_MobileEventsProcess<VwRemindings>
	{

		public VwRemindings_MobileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwRemindings_MobileEventsProcess

	public partial class VwRemindings_MobileEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwRemindingsEventsProcess

	/// <exclude/>
	public class VwRemindingsEventsProcess : VwRemindings_MobileEventsProcess
	{

		public VwRemindingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

