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

	#region Class: ServiceItem_SLM_BPMSoftSchema

	/// <exclude/>
	public class ServiceItem_SLM_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServiceItem_SLM_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceItem_SLM_BPMSoftSchema(ServiceItem_SLM_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceItem_SLM_BPMSoftSchema(ServiceItem_SLM_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			RealUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			Name = "ServiceItem_SLM_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
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
			if (Columns.FindByUId(new Guid("08272f0d-1d32-40fb-93fa-8f26e83f065f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("96b666c6-1aee-4a64-bbd8-3e0784e98ad7")) == null) {
				Columns.Add(CreateReactionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("0f639a8f-2578-4559-9241-2b3fb8c3e25c")) == null) {
				Columns.Add(CreateReactionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("0442e7ab-87f5-4110-840b-885efd5cc394")) == null) {
				Columns.Add(CreateSolutionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("bdb8cb94-0dc8-402d-91e2-566c26baf6d8")) == null) {
				Columns.Add(CreateSolutionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("6d363bd0-0b58-4887-921c-a1506b3d27dc")) == null) {
				Columns.Add(CreateCaseCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("2bdaed40-2269-4558-98d9-c7b7332c62fa")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("c9da4510-b44e-4d90-8027-57f08c93daa1")) == null) {
				Columns.Add(CreateReactionTimeColumn());
			}
			if (Columns.FindByUId(new Guid("d80d5977-22ac-4c50-b1aa-a93b4d7ec652")) == null) {
				Columns.Add(CreateSolutionTimeColumn());
			}
			if (Columns.FindByUId(new Guid("97852225-890c-4eba-ab9e-12de2129863a")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("ecba8517-ce27-4d3a-b8f1-27acf4774fc3")) == null) {
				Columns.Add(CreateCalendarColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("58aa36e4-8c91-4f2d-abdf-bc0b293db336"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("08272f0d-1d32-40fb-93fa-8f26e83f065f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("4fcd6c56-2c34-4f37-9c39-35dd78cc6c0a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ServiceItemStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("96b666c6-1aee-4a64-bbd8-3e0784e98ad7"),
				Name = @"ReactionTimeValue",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f639a8f-2578-4559-9241-2b3fb8c3e25c"),
				Name = @"ReactionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0442e7ab-87f5-4110-840b-885efd5cc394"),
				Name = @"SolutionTimeValue",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bdb8cb94-0dc8-402d-91e2-566c26baf6d8"),
				Name = @"SolutionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateCaseCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6d363bd0-0b58-4887-921c-a1506b3d27dc"),
				Name = @"CaseCategory",
				ReferenceSchemaUId = new Guid("63fec14d-0309-43b0-99c5-b085abf0c314"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("2bdaed40-2269-4558-98d9-c7b7332c62fa"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c9da4510-b44e-4d90-8027-57f08c93daa1"),
				Name = @"ReactionTime",
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d80d5977-22ac-4c50-b1aa-a93b4d7ec652"),
				Name = @"SolutionTime",
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("97852225-890c-4eba-ab9e-12de2129863a"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("af2f4ac9-4bf5-4cc5-9c73-7ee909501027")
			};
		}

		protected virtual EntitySchemaColumn CreateCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ecba8517-ce27-4d3a-b8f1-27acf4774fc3"),
				Name = @"Calendar",
				ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				ModifiedInSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceItem_SLM_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceItem_SLMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceItem_SLM_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceItem_SLM_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItem_SLM_BPMSoft

	/// <summary>
	/// Сервис.
	/// </summary>
	public class ServiceItem_SLM_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServiceItem_SLM_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceItem_SLM_BPMSoft";
		}

		public ServiceItem_SLM_BPMSoft(ServiceItem_SLM_BPMSoft source)
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

		private ServiceStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ServiceStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ServiceStatus);
			}
		}

		/// <summary>
		/// Значение времени реакции.
		/// </summary>
		public int ReactionTimeValue {
			get {
				return GetTypedColumnValue<int>("ReactionTimeValue");
			}
			set {
				SetColumnValue("ReactionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid ReactionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("ReactionTimeUnitId");
			}
			set {
				SetColumnValue("ReactionTimeUnitId", value);
				_reactionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string ReactionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("ReactionTimeUnitName");
			}
			set {
				SetColumnValue("ReactionTimeUnitName", value);
				if (_reactionTimeUnit != null) {
					_reactionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _reactionTimeUnit;
		/// <summary>
		/// Единица времени реакции.
		/// </summary>
		public TimeUnit ReactionTimeUnit {
			get {
				return _reactionTimeUnit ??
					(_reactionTimeUnit = LookupColumnEntities.GetEntity("ReactionTimeUnit") as TimeUnit);
			}
		}

		/// <summary>
		/// Значение времени разрешения.
		/// </summary>
		public int SolutionTimeValue {
			get {
				return GetTypedColumnValue<int>("SolutionTimeValue");
			}
			set {
				SetColumnValue("SolutionTimeValue", value);
			}
		}

		/// <exclude/>
		public Guid SolutionTimeUnitId {
			get {
				return GetTypedColumnValue<Guid>("SolutionTimeUnitId");
			}
			set {
				SetColumnValue("SolutionTimeUnitId", value);
				_solutionTimeUnit = null;
			}
		}

		/// <exclude/>
		public string SolutionTimeUnitName {
			get {
				return GetTypedColumnValue<string>("SolutionTimeUnitName");
			}
			set {
				SetColumnValue("SolutionTimeUnitName", value);
				if (_solutionTimeUnit != null) {
					_solutionTimeUnit.Name = value;
				}
			}
		}

		private TimeUnit _solutionTimeUnit;
		/// <summary>
		/// Единица времени разрешения.
		/// </summary>
		public TimeUnit SolutionTimeUnit {
			get {
				return _solutionTimeUnit ??
					(_solutionTimeUnit = LookupColumnEntities.GetEntity("SolutionTimeUnit") as TimeUnit);
			}
		}

		/// <exclude/>
		public Guid CaseCategoryId {
			get {
				return GetTypedColumnValue<Guid>("CaseCategoryId");
			}
			set {
				SetColumnValue("CaseCategoryId", value);
				_caseCategory = null;
			}
		}

		/// <exclude/>
		public string CaseCategoryName {
			get {
				return GetTypedColumnValue<string>("CaseCategoryName");
			}
			set {
				SetColumnValue("CaseCategoryName", value);
				if (_caseCategory != null) {
					_caseCategory.Name = value;
				}
			}
		}

		private CaseCategory _caseCategory;
		/// <summary>
		/// Категория обращения.
		/// </summary>
		public CaseCategory CaseCategory {
			get {
				return _caseCategory ??
					(_caseCategory = LookupColumnEntities.GetEntity("CaseCategory") as CaseCategory);
			}
		}

		/// <summary>
		/// Примечания.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// Время реакции.
		/// </summary>
		public string ReactionTime {
			get {
				return GetTypedColumnValue<string>("ReactionTime");
			}
			set {
				SetColumnValue("ReactionTime", value);
			}
		}

		/// <summary>
		/// Время разрешения.
		/// </summary>
		public string SolutionTime {
			get {
				return GetTypedColumnValue<string>("SolutionTime");
			}
			set {
				SetColumnValue("SolutionTime", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Владелец.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid CalendarId {
			get {
				return GetTypedColumnValue<Guid>("CalendarId");
			}
			set {
				SetColumnValue("CalendarId", value);
				_calendar = null;
			}
		}

		/// <exclude/>
		public string CalendarName {
			get {
				return GetTypedColumnValue<string>("CalendarName");
			}
			set {
				SetColumnValue("CalendarName", value);
				if (_calendar != null) {
					_calendar.Name = value;
				}
			}
		}

		private Calendar _calendar;
		/// <summary>
		/// Календарь.
		/// </summary>
		public Calendar Calendar {
			get {
				return _calendar ??
					(_calendar = LookupColumnEntities.GetEntity("Calendar") as Calendar);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceItem_SLMEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceItem_SLM_BPMSoftDeleted", e);
			Saving += (s, e) => ThrowEvent("ServiceItem_SLM_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("ServiceItem_SLM_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceItem_SLM_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItem_SLMEventsProcess

	/// <exclude/>
	public partial class ServiceItem_SLMEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServiceItem_SLM_BPMSoft
	{

		public ServiceItem_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceItem_SLMEventsProcess";
			SchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("2b6c7d79-85fd-468e-8c1d-389484fecad0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _serviceItemSavingStartMessage;
		public ProcessFlowElement ServiceItemSavingStartMessage {
			get {
				return _serviceItemSavingStartMessage ?? (_serviceItemSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ServiceItemSavingStartMessage",
					SchemaElementUId = new Guid("974c36b2-34fb-41c3-aafd-e58e479c2be2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _serviceItemSavingScriptTask;
		public ProcessScriptTask ServiceItemSavingScriptTask {
			get {
				return _serviceItemSavingScriptTask ?? (_serviceItemSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ServiceItemSavingScriptTask",
					SchemaElementUId = new Guid("825523e6-0515-4441-bb43-b08b96db9fac"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ServiceItemSavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ServiceItemSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ServiceItemSavingStartMessage };
			FlowElements[ServiceItemSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ServiceItemSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ServiceItemSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ServiceItemSavingScriptTask");
						break;
					case "ServiceItemSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ServiceItemSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ServiceItemSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ServiceItemSavingStartMessage";
					result = ServiceItemSavingStartMessage.Execute(context);
					break;
				case "ServiceItemSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ServiceItemSavingScriptTask";
					result = ServiceItemSavingScriptTask.Execute(context, ServiceItemSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ServiceItemSavingScriptTaskExecute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TimeUnit");
			esq.AddColumn("Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", Entity.GetTypedColumnValue<Guid>("ReactionTimeUnitId")));
			var entityCollection = esq.GetEntityCollection(UserConnection);
			Entity.SetColumnValue("ReactionTime", entityCollection[0].GetTypedColumnValue<string>("Name") +": "+ Entity.GetTypedColumnValue<int>("ReactionTimeValue").ToString());
			
			esq.Filters.Clear();
			esq.ResetSelectQuery();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", Entity.GetTypedColumnValue<Guid>("SolutionTimeUnitId")));
			entityCollection = esq.GetEntityCollection(UserConnection);
			entityCollection[0].GetTypedColumnValue<string>("Name");
			Entity.SetColumnValue("SolutionTime", entityCollection[0].GetTypedColumnValue<string>("Name") +": "+ Entity.GetTypedColumnValue<int>("SolutionTimeValue").ToString());
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ServiceItem_SLM_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ServiceItemSavingStartMessage")) {
							context.QueueTasks.Enqueue("ServiceItemSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItem_SLMEventsProcess

	/// <exclude/>
	public class ServiceItem_SLMEventsProcess : ServiceItem_SLMEventsProcess<ServiceItem_SLM_BPMSoft>
	{

		public ServiceItem_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceItem_SLMEventsProcess

	public partial class ServiceItem_SLMEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion

}

