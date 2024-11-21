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

	#region Class: ServiceInServicePactSchema

	/// <exclude/>
	public class ServiceInServicePactSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ServiceInServicePactSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceInServicePactSchema(ServiceInServicePactSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceInServicePactSchema(ServiceInServicePactSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			RealUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			Name = "ServiceInServicePact";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateConcatNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("73bba5cd-b107-4ae3-a065-9b9eb56cca89")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
			if (Columns.FindByUId(new Guid("a533502e-52b0-4824-9af7-9d62aaabdd96")) == null) {
				Columns.Add(CreateServicePactColumn());
			}
			if (Columns.FindByUId(new Guid("00c2bb07-f824-475c-88ae-6eee6e5fdd4c")) == null) {
				Columns.Add(CreateReactionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("ca97e260-8487-40a3-8ae1-cbf99852eb86")) == null) {
				Columns.Add(CreateReactionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("f9b77e37-01b7-4c8b-9298-5e6da858b3a2")) == null) {
				Columns.Add(CreateSolutionTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("b4b2684c-d092-4ebb-b0f2-38c76dd70fe1")) == null) {
				Columns.Add(CreateSolutionTimeUnitColumn());
			}
			if (Columns.FindByUId(new Guid("088918cb-b8d4-4c12-a1eb-18fdd3ea9a69")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("9f68699f-3e58-4b1f-a1db-0bc70316b1db")) == null) {
				Columns.Add(CreateCalendarColumn());
			}
			if (Columns.FindByUId(new Guid("061013ea-f57e-4057-b3ab-3f7468100b79")) == null) {
				Columns.Add(CreateReactionTimeColumn());
			}
			if (Columns.FindByUId(new Guid("32599881-5e55-4180-aadb-9a1e8dfaf5c4")) == null) {
				Columns.Add(CreateSolutionTimeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("73bba5cd-b107-4ae3-a065-9b9eb56cca89"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateServicePactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a533502e-52b0-4824-9af7-9d62aaabdd96"),
				Name = @"ServicePact",
				ReferenceSchemaUId = new Guid("595ddbda-31ce-4cca-9bdd-862257ceaf23"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("00c2bb07-f824-475c-88ae-6eee6e5fdd4c"),
				Name = @"ReactionTimeValue",
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ca97e260-8487-40a3-8ae1-cbf99852eb86"),
				Name = @"ReactionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f9b77e37-01b7-4c8b-9298-5e6da858b3a2"),
				Name = @"SolutionTimeValue",
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b4b2684c-d092-4ebb-b0f2-38c76dd70fe1"),
				Name = @"SolutionTimeUnit",
				ReferenceSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("088918cb-b8d4-4c12-a1eb-18fdd3ea9a69"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("4fcd6c56-2c34-4f37-9c39-35dd78cc6c0a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateCalendarColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f68699f-3e58-4b1f-a1db-0bc70316b1db"),
				Name = @"Calendar",
				ReferenceSchemaUId = new Guid("3788dc9f-10e3-41a1-ac1b-bccc768afb64"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateReactionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("061013ea-f57e-4057-b3ab-3f7468100b79"),
				Name = @"ReactionTime",
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateSolutionTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("32599881-5e55-4180-aadb-9a1e8dfaf5c4"),
				Name = @"SolutionTime",
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected virtual EntitySchemaColumn CreateConcatNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("aa82d8fc-c4d5-4cfe-9659-565656f5e80a"),
				Name = @"ConcatName",
				CreatedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
				ModifiedInSchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"),
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
			return new ServiceInServicePact(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceInServicePact_SLMITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceInServicePactSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceInServicePactSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceInServicePact

	/// <summary>
	/// Сервис в сервисном договоре.
	/// </summary>
	public class ServiceInServicePact : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ServiceInServicePact(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceInServicePact";
		}

		public ServiceInServicePact(ServiceInServicePact source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервис.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = LookupColumnEntities.GetEntity("ServiceItem") as ServiceItem);
			}
		}

		/// <exclude/>
		public Guid ServicePactId {
			get {
				return GetTypedColumnValue<Guid>("ServicePactId");
			}
			set {
				SetColumnValue("ServicePactId", value);
				_servicePact = null;
			}
		}

		/// <exclude/>
		public string ServicePactName {
			get {
				return GetTypedColumnValue<string>("ServicePactName");
			}
			set {
				SetColumnValue("ServicePactName", value);
				if (_servicePact != null) {
					_servicePact.Name = value;
				}
			}
		}

		private ServicePact _servicePact;
		/// <summary>
		/// Сервисный договор.
		/// </summary>
		public ServicePact ServicePact {
			get {
				return _servicePact ??
					(_servicePact = LookupColumnEntities.GetEntity("ServicePact") as ServicePact);
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

		/// <summary>
		/// Имя сервиса и сервиса в сервисном договоре.
		/// </summary>
		public string ConcatName {
			get {
				return GetTypedColumnValue<string>("ConcatName");
			}
			set {
				SetColumnValue("ConcatName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceInServicePact_SLMITILServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceInServicePactDeleted", e);
			Inserting += (s, e) => ThrowEvent("ServiceInServicePactInserting", e);
			Saving += (s, e) => ThrowEvent("ServiceInServicePactSaving", e);
			Validating += (s, e) => ThrowEvent("ServiceInServicePactValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceInServicePact(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceInServicePact_SLMITILServiceEventsProcess

	/// <exclude/>
	public partial class ServiceInServicePact_SLMITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ServiceInServicePact
	{

		public ServiceInServicePact_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceInServicePact_SLMITILServiceEventsProcess";
			SchemaUId = new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d01c9dd6-2cb2-41d6-8fcd-29b86ed70b1b");
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
					SchemaElementUId = new Guid("54bfb749-41ec-4a98-8235-1e7a66a2c479"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _serviceInServicePactInsertingStartMessage;
		public ProcessFlowElement ServiceInServicePactInsertingStartMessage {
			get {
				return _serviceInServicePactInsertingStartMessage ?? (_serviceInServicePactInsertingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ServiceInServicePactInsertingStartMessage",
					SchemaElementUId = new Guid("46560a4b-9cde-4a4f-98aa-9a589efc3141"),
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
					SchemaElementUId = new Guid("ef6e1e54-ef85-4ab3-939d-18261f6c9435"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessFlowElement _serviceInServicePactSavingStartMessage;
		public ProcessFlowElement ServiceInServicePactSavingStartMessage {
			get {
				return _serviceInServicePactSavingStartMessage ?? (_serviceInServicePactSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ServiceInServicePactSavingStartMessage",
					SchemaElementUId = new Guid("c8f05092-832a-4f9c-b78a-3c8c6efde1ba"),
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
					SchemaElementUId = new Guid("45fc7f27-4316-4cd2-b43a-1b6c19af4e6c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ServiceInServicePactInsertingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ServiceInServicePactInsertingStartMessage };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[ServiceInServicePactSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ServiceInServicePactSavingStartMessage };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ServiceInServicePactInsertingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
					case "ServiceInServicePactSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ScriptTask2":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ServiceInServicePactInsertingStartMessage");
			ActivatedEventElements.Add("ServiceInServicePactSavingStartMessage");
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
				case "ServiceInServicePactInsertingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ServiceInServicePactInsertingStartMessage";
					result = ServiceInServicePactInsertingStartMessage.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "ServiceInServicePactSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ServiceInServicePactSavingStartMessage";
					result = ServiceInServicePactSavingStartMessage.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
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
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceItem");
			var idColumnName = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName()); 
			var reactionTimeValueColumnName = esq.AddColumn("ReactionTimeValue").Name;
			var reactionTimeUnitColumnName = esq.AddColumn("ReactionTimeUnit.Id").Name;
			var reactionTimeColumnName = esq.AddColumn("ReactionTime").Name;
			var solutionTimeValueColumnName = esq.AddColumn("SolutionTimeValue").Name;
			var solutionTimeUnitColumnName = esq.AddColumn("SolutionTimeUnit.Id").Name;
			var solutionTimeColumnName = esq.AddColumn("SolutionTime").Name;
			var statusColumnName = esq.AddColumn("Status.Id").Name;
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", 
					Entity.GetTypedColumnValue<Guid>("ServiceItemId"));
			esq.Filters.Add(filter);
			string serviceItemName = GetServiceItemName();
			string servicePactName = GetServicePactName();
			var entityCollection = esq.GetEntityCollection(UserConnection);
			foreach(var entity in entityCollection) {
				Entity.SetColumnValue("ReactionTimeValue", entity.GetTypedColumnValue<int>(reactionTimeValueColumnName));
				Entity.SetColumnValue("ReactionTimeUnitId", entity.GetTypedColumnValue<Guid>(reactionTimeUnitColumnName));
				Entity.SetColumnValue("ReactionTime", entity.GetTypedColumnValue<string>(reactionTimeColumnName));
				Entity.SetColumnValue("SolutionTimeValue", entity.GetTypedColumnValue<int>(solutionTimeValueColumnName));
				Entity.SetColumnValue("SolutionTimeUnitId", entity.GetTypedColumnValue<Guid>(solutionTimeUnitColumnName));
				Entity.SetColumnValue("SolutionTime", entity.GetTypedColumnValue<string>(solutionTimeColumnName));
				Entity.SetColumnValue("StatusId", entity.GetTypedColumnValue<Guid>(statusColumnName));
				if(serviceItemName != null && servicePactName != null) {
					string concatName = serviceItemName + " " + servicePactName;
					concatName = concatName.Length > 500 ? concatName.Substring(0, 500) : concatName;
					Entity.SetColumnValue("ConcatName", concatName);
				} else {
					Entity.SetColumnValue("ConcatName", "Default name");
				}
			} 
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TimeUnit");
			esq.AddColumn("Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", Entity.GetTypedColumnValue<Guid>("ReactionTimeUnitId")));
			var entityCollection = esq.GetEntityCollection(UserConnection);
			if(entityCollection.Count > 0) {
				Entity.SetColumnValue("ReactionTime",Entity.GetTypedColumnValue<int>("ReactionTimeValue").ToString()+" "+entityCollection[0].GetTypedColumnValue<string>("Name"));
			}
			esq.Filters.Clear();
			esq.ResetSelectQuery();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", Entity.GetTypedColumnValue<Guid>("SolutionTimeUnitId")));
			entityCollection = esq.GetEntityCollection(UserConnection);
			if(entityCollection.Count > 0) {
				Entity.SetColumnValue("SolutionTime",Entity.GetTypedColumnValue<int>("SolutionTimeValue").ToString()+" "+entityCollection[0].GetTypedColumnValue<string>("Name"));
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ServiceInServicePactInserting":
							if (ActivatedEventElements.Contains("ServiceInServicePactInsertingStartMessage")) {
							context.QueueTasks.Enqueue("ServiceInServicePactInsertingStartMessage");
						}
						break;
					case "ServiceInServicePactSaving":
							if (ActivatedEventElements.Contains("ServiceInServicePactSavingStartMessage")) {
							context.QueueTasks.Enqueue("ServiceInServicePactSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceInServicePact_SLMITILServiceEventsProcess

	/// <exclude/>
	public class ServiceInServicePact_SLMITILServiceEventsProcess : ServiceInServicePact_SLMITILServiceEventsProcess<ServiceInServicePact>
	{

		public ServiceInServicePact_SLMITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceInServicePact_SLMITILServiceEventsProcess

	public partial class ServiceInServicePact_SLMITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		public virtual string GetServiceItemName() {
			var serviceItemId = Entity.GetTypedColumnValue<Guid>("ServiceItemId");
			var serviceItemNameSelect = new Select(UserConnection)
					.Column("Name")
					.From("ServiceItem")
					.Where("Id").IsEqual(Column.Parameter(serviceItemId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = serviceItemNameSelect.ExecuteReader(dbExecutor)) {
					if(dr.Read()){
						return dr.GetColumnValue<string>("Name");
					} else {
						return null;
					}
				}
			}
		}

		public virtual string GetServicePactName() {
			var servicePactId = Entity.GetTypedColumnValue<Guid>("ServicePactId");
			var servicePactNameSelect = new Select(UserConnection)
					.Column("Name")
					.From("ServicePact")
					.Where("Id").IsEqual(Column.Parameter(servicePactId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dr = servicePactNameSelect.ExecuteReader(dbExecutor)) {
					if(dr.Read()){
						return dr.GetColumnValue<string>("Name");
					} else {
						return null;
					}
				}
			}
		}

		#endregion

	}

	#endregion


	#region Class: ServiceInServicePactEventsProcess

	/// <exclude/>
	public class ServiceInServicePactEventsProcess : ServiceInServicePact_SLMITILServiceEventsProcess
	{

		public ServiceInServicePactEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

