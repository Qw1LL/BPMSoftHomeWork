namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwOpportFunnelDataSchema

	/// <exclude/>
	public class VwOpportFunnelDataSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwOpportFunnelDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwOpportFunnelDataSchema(VwOpportFunnelDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwOpportFunnelDataSchema(VwOpportFunnelDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa");
			RealUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa");
			Name = "VwOpportFunnelData";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362");
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
			if (Columns.FindByUId(new Guid("9d57f132-3483-4f5b-804a-79abfa449807")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("1e4dd6eb-af77-465a-9afc-4d3085c22bda")) == null) {
				Columns.Add(CreatefStageColumn());
			}
			if (Columns.FindByUId(new Guid("50b3e0e1-f768-4766-bcc0-455aac0c92c8")) == null) {
				Columns.Add(CreatefStageNumberColumn());
			}
			if (Columns.FindByUId(new Guid("7967257c-cbce-4268-ad0c-e9f7b4b9f22d")) == null) {
				Columns.Add(CreatefStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("c7e5f584-2086-4582-a156-35319170a4dc")) == null) {
				Columns.Add(CreatefDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("51df5b33-d238-4c5d-83b7-a0014b95ac13")) == null) {
				Columns.Add(CreatefCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("88cac6ef-d24d-4056-a5bb-bfde1bf947cd")) == null) {
				Columns.Add(CreatelStageColumn());
			}
			if (Columns.FindByUId(new Guid("916a303a-3a9e-419f-af95-7252e31eed21")) == null) {
				Columns.Add(CreatelStageNumberColumn());
			}
			if (Columns.FindByUId(new Guid("f4f332d1-d5ea-4db6-af91-d3cbdb133aec")) == null) {
				Columns.Add(CreatelStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("9577abd6-c30d-475f-a3c8-218b37fd752b")) == null) {
				Columns.Add(CreatelDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("ecc69141-66a8-481e-85d1-379c63b1605f")) == null) {
				Columns.Add(CreatelCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("ac495622-592c-4259-a9f2-e6bda7f59cee")) == null) {
				Columns.Add(CreateIsInStageConversionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cbd8ed42-0210-476f-b65d-9397658b1076"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9d57f132-3483-4f5b-804a-79abfa449807"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatefStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1e4dd6eb-af77-465a-9afc-4d3085c22bda"),
				Name = @"fStage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatefStageNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("50b3e0e1-f768-4766-bcc0-455aac0c92c8"),
				Name = @"fStageNumber",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatefStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7967257c-cbce-4268-ad0c-e9f7b4b9f22d"),
				Name = @"fStartDate",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatefDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("c7e5f584-2086-4582-a156-35319170a4dc"),
				Name = @"fDueDate",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatefCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("51df5b33-d238-4c5d-83b7-a0014b95ac13"),
				Name = @"fCreatedOn",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatelStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("88cac6ef-d24d-4056-a5bb-bfde1bf947cd"),
				Name = @"lStage",
				ReferenceSchemaUId = new Guid("ccf7d813-fc83-47ad-be61-8f3b3b98a54f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatelStageNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("916a303a-3a9e-419f-af95-7252e31eed21"),
				Name = @"lStageNumber",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatelStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("f4f332d1-d5ea-4db6-af91-d3cbdb133aec"),
				Name = @"lStartDate",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatelDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("9577abd6-c30d-475f-a3c8-218b37fd752b"),
				Name = @"lDueDate",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreatelCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ecc69141-66a8-481e-85d1-379c63b1605f"),
				Name = @"lCreatedOn",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected virtual EntitySchemaColumn CreateIsInStageConversionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ac495622-592c-4259-a9f2-e6bda7f59cee"),
				Name = @"IsInStageConversion",
				CreatedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				ModifiedInSchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"),
				CreatedInPackageId = new Guid("8957ea5b-97f7-4bd3-945c-7e13b0567362")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwOpportFunnelData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwOpportFunnelData_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwOpportFunnelDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwOpportFunnelDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa"));
		}

		#endregion

	}

	#endregion

	#region Class: VwOpportFunnelData

	/// <summary>
	/// Представление данных для воронки продаж.
	/// </summary>
	public class VwOpportFunnelData : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwOpportFunnelData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwOpportFunnelData";
		}

		public VwOpportFunnelData(VwOpportFunnelData source)
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
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		/// <exclude/>
		public Guid fStageId {
			get {
				return GetTypedColumnValue<Guid>("fStageId");
			}
			set {
				SetColumnValue("fStageId", value);
				_fStage = null;
			}
		}

		/// <exclude/>
		public string fStageName {
			get {
				return GetTypedColumnValue<string>("fStageName");
			}
			set {
				SetColumnValue("fStageName", value);
				if (_fStage != null) {
					_fStage.Name = value;
				}
			}
		}

		private OpportunityStage _fStage;
		/// <summary>
		/// Предыдущая стадия.
		/// </summary>
		public OpportunityStage fStage {
			get {
				return _fStage ??
					(_fStage = LookupColumnEntities.GetEntity("fStage") as OpportunityStage);
			}
		}

		/// <summary>
		/// Номер предыдущей стадии.
		/// </summary>
		public int fStageNumber {
			get {
				return GetTypedColumnValue<int>("fStageNumber");
			}
			set {
				SetColumnValue("fStageNumber", value);
			}
		}

		/// <summary>
		/// Дата начала предыдущей стадии.
		/// </summary>
		public DateTime fStartDate {
			get {
				return GetTypedColumnValue<DateTime>("fStartDate");
			}
			set {
				SetColumnValue("fStartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения предыдущей стадии.
		/// </summary>
		public DateTime fDueDate {
			get {
				return GetTypedColumnValue<DateTime>("fDueDate");
			}
			set {
				SetColumnValue("fDueDate", value);
			}
		}

		/// <summary>
		/// Дата создания предыдущей стадии.
		/// </summary>
		public DateTime fCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("fCreatedOn");
			}
			set {
				SetColumnValue("fCreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid lStageId {
			get {
				return GetTypedColumnValue<Guid>("lStageId");
			}
			set {
				SetColumnValue("lStageId", value);
				_lStage = null;
			}
		}

		/// <exclude/>
		public string lStageName {
			get {
				return GetTypedColumnValue<string>("lStageName");
			}
			set {
				SetColumnValue("lStageName", value);
				if (_lStage != null) {
					_lStage.Name = value;
				}
			}
		}

		private OpportunityStage _lStage;
		/// <summary>
		/// Следующая стадия.
		/// </summary>
		public OpportunityStage lStage {
			get {
				return _lStage ??
					(_lStage = LookupColumnEntities.GetEntity("lStage") as OpportunityStage);
			}
		}

		/// <summary>
		/// Номер следующей стадии.
		/// </summary>
		public int lStageNumber {
			get {
				return GetTypedColumnValue<int>("lStageNumber");
			}
			set {
				SetColumnValue("lStageNumber", value);
			}
		}

		/// <summary>
		/// Дата начала следующей стадии.
		/// </summary>
		public DateTime lStartDate {
			get {
				return GetTypedColumnValue<DateTime>("lStartDate");
			}
			set {
				SetColumnValue("lStartDate", value);
			}
		}

		/// <summary>
		/// Дата завершения следующей стадии.
		/// </summary>
		public DateTime lDueDate {
			get {
				return GetTypedColumnValue<DateTime>("lDueDate");
			}
			set {
				SetColumnValue("lDueDate", value);
			}
		}

		/// <summary>
		/// Дата создания следующей стадии.
		/// </summary>
		public DateTime lCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("lCreatedOn");
			}
			set {
				SetColumnValue("lCreatedOn", value);
			}
		}

		/// <summary>
		/// Признак попадания в конверсию по стадиям.
		/// </summary>
		public int IsInStageConversion {
			get {
				return GetTypedColumnValue<int>("IsInStageConversion");
			}
			set {
				SetColumnValue("IsInStageConversion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwOpportFunnelData_OpportunityEventsProcess(UserConnection);
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
			return new VwOpportFunnelData(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwOpportFunnelData_OpportunityEventsProcess

	/// <exclude/>
	public partial class VwOpportFunnelData_OpportunityEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwOpportFunnelData
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

		public VwOpportFunnelData_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwOpportFunnelData_OpportunityEventsProcess";
			SchemaUId = new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba736afe-2a21-4117-b8f7-e90b25388daa");
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

	#region Class: VwOpportFunnelData_OpportunityEventsProcess

	/// <exclude/>
	public class VwOpportFunnelData_OpportunityEventsProcess : VwOpportFunnelData_OpportunityEventsProcess<VwOpportFunnelData>
	{

		public VwOpportFunnelData_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwOpportFunnelData_OpportunityEventsProcess

	public partial class VwOpportFunnelData_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwOpportFunnelDataEventsProcess

	/// <exclude/>
	public class VwOpportFunnelDataEventsProcess : VwOpportFunnelData_OpportunityEventsProcess
	{

		public VwOpportFunnelDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

