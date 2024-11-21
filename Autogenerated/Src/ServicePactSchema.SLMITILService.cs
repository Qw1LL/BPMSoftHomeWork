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

	#region Class: ServicePactSchema

	/// <exclude/>
	public class ServicePactSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServicePactSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServicePactSchema(ServicePactSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServicePactSchema(ServicePactSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23");
			RealUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23");
			Name = "ServicePact";
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
			if (Columns.FindByUId(new Guid("ce3b4314-00be-4920-9ee0-3bb4f0652b51")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("19311286-f48f-42bf-899e-21d226188460")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("fab73b77-a8b5-4c05-9270-000e459d33b5")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("e3cb3b18-d001-4c28-b408-86fb78d38573")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("2e1d09da-730a-4c37-a832-e3a92b54e21b")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("927232c7-2ca3-42bf-9c41-3c14efd2da8b")) == null) {
				Columns.Add(CreateNumberColumn());
			}
			if (Columns.FindByUId(new Guid("78d2c742-05a5-4445-8381-e107f47f1a1e")) == null) {
				Columns.Add(CreateServiceProviderColumn());
			}
			if (Columns.FindByUId(new Guid("89919b88-1bdf-4580-ba77-03d1741c115d")) == null) {
				Columns.Add(CreateServiceProviderContactColumn());
			}
			if (Columns.FindByUId(new Guid("fd684436-25f5-4b6b-b3aa-0bb8768ad058")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("caccdc0e-ba0e-4c14-a142-cd85e7abe724")) == null) {
				Columns.Add(CreateCalendarColumn());
			}
			if (Columns.FindByUId(new Guid("f10fb434-46cb-407f-8999-b9ddde0bef61")) == null) {
				Columns.Add(CreateSupportLevelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("962a5845-b220-499d-abeb-32024cc6b626"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ce3b4314-00be-4920-9ee0-3bb4f0652b51"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("ada4cb8a-7b7d-48ae-96c0-fedfa6de3c78"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ServicePactStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("19311286-f48f-42bf-899e-21d226188460"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("fab73b77-a8b5-4c05-9270-000e459d33b5"),
				Name = @"EndDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e3cb3b18-d001-4c28-b408-86fb78d38573"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2e1d09da-730a-4c37-a832-e3a92b54e21b"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("bcc32cb6-68a0-4730-b290-2b04e96d92bc"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ServicePactTypeDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("927232c7-2ca3-42bf-9c41-3c14efd2da8b"),
				Name = @"Number",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceProviderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("78d2c742-05a5-4445-8381-e107f47f1a1e"),
				Name = @"ServiceProvider",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateServiceProviderContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("89919b88-1bdf-4580-ba77-03d1741c115d"),
				Name = @"ServiceProviderContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fd684436-25f5-4b6b-b3aa-0bb8768ad058"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("caccdc0e-ba0e-4c14-a142-cd85e7abe724"),
				Name = @"Calendar",
				ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"BaseCalendar"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSupportLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f10fb434-46cb-407f-8999-b9ddde0bef61"),
				Name = @"SupportLevel",
				ReferenceSchemaUId = new Guid("c30bd3d7-e9ea-4165-bedd-a23be5d59050"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				ModifiedInSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				CreatedInPackageId = new Guid("ad5b74fb-5a18-4ed5-aefb-d72c560aee61")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServicePact(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServicePact_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServicePactSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServicePactSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"));
		}

		#endregion

	}

	#endregion

	#region Class: ServicePact

	/// <summary>
	/// Сервисный договор.
	/// </summary>
	public class ServicePact : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServicePact(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServicePact";
		}

		public ServicePact(ServicePact source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
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

		private ServicePactStatus _status;
		/// <summary>
		/// Статус.
		/// </summary>
		public ServicePactStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ServicePactStatus);
			}
		}

		/// <summary>
		/// Дата начала.
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
		/// Дата окончания.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
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
		/// Создатель.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ServicePactType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ServicePactType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ServicePactType);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <exclude/>
		public Guid ServiceProviderId {
			get {
				return GetTypedColumnValue<Guid>("ServiceProviderId");
			}
			set {
				SetColumnValue("ServiceProviderId", value);
				_serviceProvider = null;
			}
		}

		/// <exclude/>
		public string ServiceProviderName {
			get {
				return GetTypedColumnValue<string>("ServiceProviderName");
			}
			set {
				SetColumnValue("ServiceProviderName", value);
				if (_serviceProvider != null) {
					_serviceProvider.Name = value;
				}
			}
		}

		private Account _serviceProvider;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account ServiceProvider {
			get {
				return _serviceProvider ??
					(_serviceProvider = LookupColumnEntities.GetEntity("ServiceProvider") as Account);
			}
		}

		/// <exclude/>
		public Guid ServiceProviderContactId {
			get {
				return GetTypedColumnValue<Guid>("ServiceProviderContactId");
			}
			set {
				SetColumnValue("ServiceProviderContactId", value);
				_serviceProviderContact = null;
			}
		}

		/// <exclude/>
		public string ServiceProviderContactName {
			get {
				return GetTypedColumnValue<string>("ServiceProviderContactName");
			}
			set {
				SetColumnValue("ServiceProviderContactName", value);
				if (_serviceProviderContact != null) {
					_serviceProviderContact.Name = value;
				}
			}
		}

		private Contact _serviceProviderContact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact ServiceProviderContact {
			get {
				return _serviceProviderContact ??
					(_serviceProviderContact = LookupColumnEntities.GetEntity("ServiceProviderContact") as Contact);
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

		/// <exclude/>
		public Guid SupportLevelId {
			get {
				return GetTypedColumnValue<Guid>("SupportLevelId");
			}
			set {
				SetColumnValue("SupportLevelId", value);
				_supportLevel = null;
			}
		}

		/// <exclude/>
		public string SupportLevelName {
			get {
				return GetTypedColumnValue<string>("SupportLevelName");
			}
			set {
				SetColumnValue("SupportLevelName", value);
				if (_supportLevel != null) {
					_supportLevel.Name = value;
				}
			}
		}

		private SupportLevel _supportLevel;
		/// <summary>
		/// Уровень поддержки.
		/// </summary>
		public SupportLevel SupportLevel {
			get {
				return _supportLevel ??
					(_supportLevel = LookupColumnEntities.GetEntity("SupportLevel") as SupportLevel);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServicePact_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServicePactDeleted", e);
			Validating += (s, e) => ThrowEvent("ServicePactValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServicePact(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServicePact_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class ServicePact_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServicePact
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, ServicePact_SLMITILServiceEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("e3d4eecc-2982-42bb-9b9b-6a3af9f1edff");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public ServicePact_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServicePact_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23");
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
					SchemaElementUId = new Guid("7adb0003-2d2f-4ee6-97ec-8cc1ced4be78"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("42d94e59-81a8-4f75-935e-2dbdd2add3ee"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("21ee310e-6404-41ad-9c40-c70270838791"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("54e8e503-cf84-42de-9e91-1aacba1e5abb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		private ProcessFlowElement _servicePactSavingStartMessage;
		public ProcessFlowElement ServicePactSavingStartMessage {
			get {
				return _servicePactSavingStartMessage ?? (_servicePactSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ServicePactSavingStartMessage",
					SchemaElementUId = new Guid("8e24f235-92d6-4f4c-bc0d-e263932b8b6f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("22c5002a-64b3-48e0-8c59-36e3e3f80eb4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("660e6c96-6586-4bda-afa9-a5568264a611"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
			FlowElements[ServicePactSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ServicePactSavingStartMessage };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "Terminate1":
						break;
					case "ScriptTask2":
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "ServicePactSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("ScriptTask1");
							break;
						}
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ServicePactSavingStartMessage");
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
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
				case "ServicePactSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ServicePactSavingStartMessage";
					result = ServicePactSavingStartMessage.Execute(context);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			var update = new Update(UserConnection, Entity.Schema.Name)
				.Set("Number", Column.Parameter(code))
				.Where("Id").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
			update.Execute();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ServicePactSaved":
							if (ActivatedEventElements.Contains("ServicePactSavingStartMessage")) {
							context.QueueTasks.Enqueue("ServicePactSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ServicePact_SLMITILServiceEventsProcess

	/// <exclude/>
	public class ServicePact_SLMITILServiceEventsProcess : ServicePact_SLMITILServiceEventsProcess<ServicePact>
	{

		public ServicePact_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServicePact_SLMITILServiceEventsProcess

	public partial class ServicePact_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ServicePactEventsProcess

	/// <exclude/>
	public class ServicePactEventsProcess : ServicePact_SLMITILServiceEventsProcess
	{

		public ServicePactEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

