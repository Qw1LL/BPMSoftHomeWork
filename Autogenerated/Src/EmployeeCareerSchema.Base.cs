namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.EntitySynchronization;
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

	#region Class: EmployeeCareerSchema

	/// <exclude/>
	public class EmployeeCareerSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmployeeCareerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeCareerSchema(EmployeeCareerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeCareerSchema(EmployeeCareerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738");
			RealUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738");
			Name = "EmployeeCareer";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("10b4c663-af0f-45ba-83fb-f1357581f2c9")) == null) {
				Columns.Add(CreateEmployeeColumn());
			}
			if (Columns.FindByUId(new Guid("cfcc24ef-4b62-4d40-bdd8-2ea802b9b1ba")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("96999841-abaf-443b-9f61-bbe15a5a77d3")) == null) {
				Columns.Add(CreateOrgStructureUnitColumn());
			}
			if (Columns.FindByUId(new Guid("24e53dfb-546c-46be-89b0-e258928bb694")) == null) {
				Columns.Add(CreateEmployeeJobColumn());
			}
			if (Columns.FindByUId(new Guid("b4946cf5-1b3e-4580-a8fc-a416accd6524")) == null) {
				Columns.Add(CreateFullJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("11899472-7e69-44b8-9ef9-1242e562b269")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("ff98adaf-5bb0-4d34-83f5-6bcb57ce8f22")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("25543607-7543-4a60-9ca5-cba0edc1affe")) == null) {
				Columns.Add(CreateIsCurrentColumn());
			}
			if (Columns.FindByUId(new Guid("778c9d14-dfa3-4e73-9176-231545aae84a")) == null) {
				Columns.Add(CreateProbationDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("e164a462-4b52-4e50-b766-16fa1912624c")) == null) {
				Columns.Add(CreateReasonForDismissalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEmployeeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10b4c663-af0f-45ba-83fb-f1357581f2c9"),
				Name = @"Employee",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cfcc24ef-4b62-4d40-bdd8-2ea802b9b1ba"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOrgStructureUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("96999841-abaf-443b-9f61-bbe15a5a77d3"),
				Name = @"OrgStructureUnit",
				ReferenceSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateEmployeeJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("24e53dfb-546c-46be-89b0-e258928bb694"),
				Name = @"EmployeeJob",
				ReferenceSchemaUId = new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateFullJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b4946cf5-1b3e-4580-a8fc-a416accd6524"),
				Name = @"FullJobTitle",
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("11899472-7e69-44b8-9ef9-1242e562b269"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ff98adaf-5bb0-4d34-83f5-6bcb57ce8f22"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCurrentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("25543607-7543-4a60-9ca5-cba0edc1affe"),
				Name = @"IsCurrent",
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateProbationDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("778c9d14-dfa3-4e73-9176-231545aae84a"),
				Name = @"ProbationDueDate",
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateReasonForDismissalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e164a462-4b52-4e50-b766-16fa1912624c"),
				Name = @"ReasonForDismissal",
				ReferenceSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				ModifiedInSchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmployeeCareer(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmployeeCareer_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeCareerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeCareerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738"));
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeCareer

	/// <summary>
	/// Employee career in our company.
	/// </summary>
	public class EmployeeCareer : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmployeeCareer(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeCareer";
		}

		public EmployeeCareer(EmployeeCareer source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EmployeeId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeId");
			}
			set {
				SetColumnValue("EmployeeId", value);
				_employee = null;
			}
		}

		/// <exclude/>
		public string EmployeeName {
			get {
				return GetTypedColumnValue<string>("EmployeeName");
			}
			set {
				SetColumnValue("EmployeeName", value);
				if (_employee != null) {
					_employee.Name = value;
				}
			}
		}

		private Employee _employee;
		/// <summary>
		/// Employee.
		/// </summary>
		public Employee Employee {
			get {
				return _employee ??
					(_employee = LookupColumnEntities.GetEntity("Employee") as Employee);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid OrgStructureUnitId {
			get {
				return GetTypedColumnValue<Guid>("OrgStructureUnitId");
			}
			set {
				SetColumnValue("OrgStructureUnitId", value);
				_orgStructureUnit = null;
			}
		}

		/// <exclude/>
		public string OrgStructureUnitName {
			get {
				return GetTypedColumnValue<string>("OrgStructureUnitName");
			}
			set {
				SetColumnValue("OrgStructureUnitName", value);
				if (_orgStructureUnit != null) {
					_orgStructureUnit.Name = value;
				}
			}
		}

		private OrgStructureUnit _orgStructureUnit;
		/// <summary>
		/// Organization structure item.
		/// </summary>
		public OrgStructureUnit OrgStructureUnit {
			get {
				return _orgStructureUnit ??
					(_orgStructureUnit = LookupColumnEntities.GetEntity("OrgStructureUnit") as OrgStructureUnit);
			}
		}

		/// <exclude/>
		public Guid EmployeeJobId {
			get {
				return GetTypedColumnValue<Guid>("EmployeeJobId");
			}
			set {
				SetColumnValue("EmployeeJobId", value);
				_employeeJob = null;
			}
		}

		/// <exclude/>
		public string EmployeeJobName {
			get {
				return GetTypedColumnValue<string>("EmployeeJobName");
			}
			set {
				SetColumnValue("EmployeeJobName", value);
				if (_employeeJob != null) {
					_employeeJob.Name = value;
				}
			}
		}

		private EmployeeJob _employeeJob;
		/// <summary>
		/// Job title.
		/// </summary>
		public EmployeeJob EmployeeJob {
			get {
				return _employeeJob ??
					(_employeeJob = LookupColumnEntities.GetEntity("EmployeeJob") as EmployeeJob);
			}
		}

		/// <summary>
		/// Full job title.
		/// </summary>
		public string FullJobTitle {
			get {
				return GetTypedColumnValue<string>("FullJobTitle");
			}
			set {
				SetColumnValue("FullJobTitle", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Due date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Current.
		/// </summary>
		public bool IsCurrent {
			get {
				return GetTypedColumnValue<bool>("IsCurrent");
			}
			set {
				SetColumnValue("IsCurrent", value);
			}
		}

		/// <summary>
		/// Probation ends.
		/// </summary>
		public DateTime ProbationDueDate {
			get {
				return GetTypedColumnValue<DateTime>("ProbationDueDate");
			}
			set {
				SetColumnValue("ProbationDueDate", value);
			}
		}

		/// <exclude/>
		public Guid ReasonForDismissalId {
			get {
				return GetTypedColumnValue<Guid>("ReasonForDismissalId");
			}
			set {
				SetColumnValue("ReasonForDismissalId", value);
				_reasonForDismissal = null;
			}
		}

		/// <exclude/>
		public string ReasonForDismissalName {
			get {
				return GetTypedColumnValue<string>("ReasonForDismissalName");
			}
			set {
				SetColumnValue("ReasonForDismissalName", value);
				if (_reasonForDismissal != null) {
					_reasonForDismissal.Name = value;
				}
			}
		}

		private ReasonForLeaving _reasonForDismissal;
		/// <summary>
		/// Reason for job change.
		/// </summary>
		public ReasonForLeaving ReasonForDismissal {
			get {
				return _reasonForDismissal ??
					(_reasonForDismissal = LookupColumnEntities.GetEntity("ReasonForDismissal") as ReasonForLeaving);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmployeeCareer_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeCareerDeleted", e);
			Saved += (s, e) => ThrowEvent("EmployeeCareerSaved", e);
			Saving += (s, e) => ThrowEvent("EmployeeCareerSaving", e);
			Validating += (s, e) => ThrowEvent("EmployeeCareerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmployeeCareer(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeCareer_BaseEventsProcess

	/// <exclude/>
	public partial class EmployeeCareer_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmployeeCareer
	{

		public EmployeeCareer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmployeeCareer_BaseEventsProcess";
			SchemaUId = new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae722ecf-3686-4a24-a3b6-0c2d798df738");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool CurrentColumnOldValue {
			get;
			set;
		}

		private ProcessFlowElement _employeeCareerSavedSubProcess;
		public ProcessFlowElement EmployeeCareerSavedSubProcess {
			get {
				return _employeeCareerSavedSubProcess ?? (_employeeCareerSavedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmployeeCareerSavedSubProcess",
					SchemaElementUId = new Guid("0a5283f1-f802-4f3a-b5c9-da23cbbcb437"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _employeeCareerSavedMessage;
		public ProcessFlowElement EmployeeCareerSavedMessage {
			get {
				return _employeeCareerSavedMessage ?? (_employeeCareerSavedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmployeeCareerSavedMessage",
					SchemaElementUId = new Guid("d75b9d4b-919f-4059-8248-c2eaca0d02ec"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeCareerSavedScriptTask;
		public ProcessScriptTask EmployeeCareerSavedScriptTask {
			get {
				return _employeeCareerSavedScriptTask ?? (_employeeCareerSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeCareerSavedScriptTask",
					SchemaElementUId = new Guid("404c5511-5c03-4ab4-be43-f1e0491200a1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeCareerSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _employeeCareerDeletedSubProcess;
		public ProcessFlowElement EmployeeCareerDeletedSubProcess {
			get {
				return _employeeCareerDeletedSubProcess ?? (_employeeCareerDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmployeeCareerDeletedSubProcess",
					SchemaElementUId = new Guid("22905abb-fcd6-49f0-b865-fa64734b607b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _employeeCareerDeletedMessage;
		public ProcessFlowElement EmployeeCareerDeletedMessage {
			get {
				return _employeeCareerDeletedMessage ?? (_employeeCareerDeletedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmployeeCareerDeletedMessage",
					SchemaElementUId = new Guid("9b3a3736-9c12-4f92-bd66-122b12bfc8eb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeCareerDeletedScriptTask;
		public ProcessScriptTask EmployeeCareerDeletedScriptTask {
			get {
				return _employeeCareerDeletedScriptTask ?? (_employeeCareerDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeCareerDeletedScriptTask",
					SchemaElementUId = new Guid("e3a8b115-d331-42ef-b770-2a21d38d3746"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeCareerDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _employeeCareerSavingSubProcess;
		public ProcessFlowElement EmployeeCareerSavingSubProcess {
			get {
				return _employeeCareerSavingSubProcess ?? (_employeeCareerSavingSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmployeeCareerSavingSubProcess",
					SchemaElementUId = new Guid("b5b8e3db-df14-4fdf-a6be-555b3d642589"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _employeeCareerSavingMessage;
		public ProcessFlowElement EmployeeCareerSavingMessage {
			get {
				return _employeeCareerSavingMessage ?? (_employeeCareerSavingMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmployeeCareerSavingMessage",
					SchemaElementUId = new Guid("f374721a-8d5a-4c22-b5c3-87c69e0d9b46"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeCareerSavingScriptTask;
		public ProcessScriptTask EmployeeCareerSavingScriptTask {
			get {
				return _employeeCareerSavingScriptTask ?? (_employeeCareerSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeCareerSavingScriptTask",
					SchemaElementUId = new Guid("0002caf6-310f-424b-b68c-60e3ead42a96"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeCareerSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EmployeeCareerSavedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavedSubProcess };
			FlowElements[EmployeeCareerSavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavedMessage };
			FlowElements[EmployeeCareerSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavedScriptTask };
			FlowElements[EmployeeCareerDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerDeletedSubProcess };
			FlowElements[EmployeeCareerDeletedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerDeletedMessage };
			FlowElements[EmployeeCareerDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerDeletedScriptTask };
			FlowElements[EmployeeCareerSavingSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavingSubProcess };
			FlowElements[EmployeeCareerSavingMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavingMessage };
			FlowElements[EmployeeCareerSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeCareerSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EmployeeCareerSavedSubProcess":
						break;
					case "EmployeeCareerSavedMessage":
						e.Context.QueueTasks.Enqueue("EmployeeCareerSavedScriptTask");
						break;
					case "EmployeeCareerSavedScriptTask":
						break;
					case "EmployeeCareerDeletedSubProcess":
						break;
					case "EmployeeCareerDeletedMessage":
						e.Context.QueueTasks.Enqueue("EmployeeCareerDeletedScriptTask");
						break;
					case "EmployeeCareerDeletedScriptTask":
						break;
					case "EmployeeCareerSavingSubProcess":
						break;
					case "EmployeeCareerSavingMessage":
						e.Context.QueueTasks.Enqueue("EmployeeCareerSavingScriptTask");
						break;
					case "EmployeeCareerSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EmployeeCareerSavedMessage");
			ActivatedEventElements.Add("EmployeeCareerDeletedMessage");
			ActivatedEventElements.Add("EmployeeCareerSavingMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EmployeeCareerSavedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EmployeeCareerSavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerSavedMessage";
					result = EmployeeCareerSavedMessage.Execute(context);
					break;
				case "EmployeeCareerSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerSavedScriptTask";
					result = EmployeeCareerSavedScriptTask.Execute(context, EmployeeCareerSavedScriptTaskExecute);
					break;
				case "EmployeeCareerDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EmployeeCareerDeletedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerDeletedMessage";
					result = EmployeeCareerDeletedMessage.Execute(context);
					break;
				case "EmployeeCareerDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerDeletedScriptTask";
					result = EmployeeCareerDeletedScriptTask.Execute(context, EmployeeCareerDeletedScriptTaskExecute);
					break;
				case "EmployeeCareerSavingSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EmployeeCareerSavingMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerSavingMessage";
					result = EmployeeCareerSavingMessage.Execute(context);
					break;
				case "EmployeeCareerSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeCareerSavingScriptTask";
					result = EmployeeCareerSavingScriptTask.Execute(context, EmployeeCareerSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool EmployeeCareerSavedScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeCareerSaved();
			return true;
		}

		public virtual bool EmployeeCareerDeletedScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeCareerDeleted();
			return true;
		}

		public virtual bool EmployeeCareerSavingScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeCareerSaving();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EmployeeCareerSaved":
							if (ActivatedEventElements.Contains("EmployeeCareerSavedMessage")) {
							context.QueueTasks.Enqueue("EmployeeCareerSavedMessage");
						}
						break;
					case "EmployeeCareerDeleted":
							if (ActivatedEventElements.Contains("EmployeeCareerDeletedMessage")) {
							context.QueueTasks.Enqueue("EmployeeCareerDeletedMessage");
						}
						break;
					case "EmployeeCareerSaving":
							if (ActivatedEventElements.Contains("EmployeeCareerSavingMessage")) {
							context.QueueTasks.Enqueue("EmployeeCareerSavingMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeCareer_BaseEventsProcess

	/// <exclude/>
	public class EmployeeCareer_BaseEventsProcess : EmployeeCareer_BaseEventsProcess<EmployeeCareer>
	{

		public EmployeeCareer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmployeeCareer_BaseEventsProcess

	public partial class EmployeeCareer_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void OnEmployeeCareerSaved() {
			bool isCurrent = Entity.GetTypedColumnValue<bool>("IsCurrent");
			if (isCurrent) {
				ResetOldEmployment();
				SynchronizeEmployeeCareerAndEmployee();
			} else if (!isCurrent && CurrentColumnOldValue) {
				SynchronizeEmployeeCareerAndEmployee();
			}
		}

		public virtual void SynchronizeEmployeeCareerAndEmployee() {
			IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
			Entity employee = provider.FindEntity("Employee", new Dictionary<string, object> {
				{"Id", Entity.GetTypedColumnValue<Guid>("EmployeeId")}
			});
			if (employee != null) {
				ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
				IColumnValuesSynchronizer synchronizer = CreateColumnValuesSynchronizer();
				synchronizer.SynchronizeEntities(Entity, employee, columnMappings);
				employee.Save();
			}
		}

		public virtual void ResetOldEmployment() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmployeeCareer");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddAllSchemaColumns(true);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, esq.RootSchema.PrimaryColumn.Name,
				Entity.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Employee",
				Entity.GetTypedColumnValue<Guid>("EmployeeId")));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCurrent", true));
			EntityCollection careers = esq.GetEntityCollection(UserConnection);
			careers.ForEach(ResetOldCareer);
		}

		public virtual IColumnValuesSynchronizer CreateColumnValuesSynchronizer() {
			return ClassFactory.Get<ColumnValuesSynchronizer>();
		}

		public virtual IEntitySynchronizationProvider CreateEntitySynchronizationProvider() {
			return ClassFactory.Get<EntitySynchronizationProvider>(new ConstructorArgument("userConnection", UserConnection));
		}

		public virtual ICollection<SynchronizationColumnMapping> GetSynchronizationColumnMappings() {
			IEqualComparatorProvider provider = CreateEqualComparatorProvider();
			SynchronizationColumnComparator dateEqualComparator = provider.GetDateEqualComparator();
			SynchronizationColumnComparator stringEqualComparator = provider.GetStringEqualComparator();
			return new List<SynchronizationColumnMapping> {
				new SynchronizationColumnMapping {
					SourceColumnName = "AccountId",
					DestinationColumnName = "AccountId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "OrgStructureUnitId",
					DestinationColumnName = "OrgStructureUnitId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "EmployeeJobId",
					DestinationColumnName = "JobId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "FullJobTitle",
					DestinationColumnName = "FullJobTitle",
					Comparator = stringEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "StartDate",
					DestinationColumnName = "CareerStartDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "DueDate",
					DestinationColumnName = "CareerDueDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "ProbationDueDate",
					DestinationColumnName = "ProbationDueDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "ReasonForDismissalId",
					DestinationColumnName = "ReasonForDismissalId"
				}
			};
		}

		public virtual void OnEmployeeCareerDeleted() {
			if (Entity.GetTypedColumnValue<bool>("IsCurrent") || GetIsEmployeeCareerHistoryEmpty()) {
				ClearEmployeeCareerInformation();
			}
		}

		public virtual bool GetIsEmployeeCareerHistoryEmpty() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmployeeCareer");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.PrimaryQueryColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem employeeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Employee",
				Entity.GetTypedColumnValue<Guid>("EmployeeId"));
			esq.Filters.Add(employeeFilter);
			Entity summaryEntity = esq.GetSummaryEntity(UserConnection);
			return summaryEntity.GetTypedColumnValue<int>(esq.PrimaryQueryColumn.Name) <= 0;
		}

		public virtual void ClearEmployeeCareerInformation() {
			IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
			Entity employee = provider.FindEntity("Employee", new Dictionary<string, object> {
				{"Id", Entity.GetTypedColumnValue<Guid>("EmployeeId")}
			});
			ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
			foreach(SynchronizationColumnMapping columnMapping in columnMappings) {
				employee.SetColumnValue(columnMapping.DestinationColumnName, null);
			}
			employee.Save();
		}

		public virtual void OnEmployeeCareerSaving() {
			CurrentColumnOldValue = Entity.GetTypedOldColumnValue<bool>("IsCurrent");
		}

		public virtual IEqualComparatorProvider CreateEqualComparatorProvider() {
			return ClassFactory.Get<EqualComparatorProvider>();
		}

		public virtual void ResetOldCareer(Entity career) {
			var isNeedToCheckRequiredFields = GetIsNeedToCheckRequiredFields();
			career.SetColumnValue("IsCurrent", false);
			career.Save(isNeedToCheckRequiredFields);
		}

		public virtual bool GetIsNeedToCheckRequiredFields() {
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: EmployeeCareerEventsProcess

	/// <exclude/>
	public class EmployeeCareerEventsProcess : EmployeeCareer_BaseEventsProcess
	{

		public EmployeeCareerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

