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

	#region Class: ForecastSheetSchema

	/// <exclude/>
	public class ForecastSheetSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastSheetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastSheetSchema(ForecastSheetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastSheetSchema(ForecastSheetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0");
			RealUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0");
			Name = "ForecastSheet";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39");
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
			if (Columns.FindByUId(new Guid("b1851766-fc4e-478a-a7fc-b25a5c9c25b7")) == null) {
				Columns.Add(CreatePeriodTypeColumn());
			}
			if (Columns.FindByUId(new Guid("495329fc-5ca5-46b5-9dc1-68587bf681c1")) == null) {
				Columns.Add(CreateForecastEntityColumn());
			}
			if (Columns.FindByUId(new Guid("0393df71-4fb9-4678-9514-fffafa34225c")) == null) {
				Columns.Add(CreateForecastEntityInCellUIdColumn());
			}
			if (Columns.FindByUId(new Guid("0e84188f-0eb2-49e1-879c-582f2db767f3")) == null) {
				Columns.Add(CreateSettingColumn());
			}
			if (Columns.FindByUId(new Guid("b7807cad-82e0-453e-82e9-3067d097eba1")) == null) {
				Columns.Add(CreateLastCalculationDateTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f502f4f8-f2e1-49ee-8768-8b93f970867c"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b1851766-fc4e-478a-a7fc-b25a5c9c25b7"),
				Name = @"PeriodType",
				ReferenceSchemaUId = new Guid("3608a0e4-0235-4936-9c0e-99620e73940c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("495329fc-5ca5-46b5-9dc1-68587bf681c1"),
				Name = @"ForecastEntity",
				ReferenceSchemaUId = new Guid("c82db13a-7f77-4085-b3ef-91c5420fd417"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastEntityInCellUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0393df71-4fb9-4678-9514-fffafa34225c"),
				Name = @"ForecastEntityInCellUId",
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateSettingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0e84188f-0eb2-49e1-879c-582f2db767f3"),
				Name = @"Setting",
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected virtual EntitySchemaColumn CreateLastCalculationDateTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("b7807cad-82e0-453e-82e9-3067d097eba1"),
				Name = @"LastCalculationDateTime",
				CreatedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				ModifiedInSchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"),
				CreatedInPackageId = new Guid("e0b9d996-6f7e-4520-a678-da960c79be39")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ForecastSheet(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastSheet_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastSheetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastSheetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastSheet

	/// <summary>
	/// Лист планирования.
	/// </summary>
	public class ForecastSheet : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastSheet(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastSheet";
		}

		public ForecastSheet(ForecastSheet source)
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
		public Guid PeriodTypeId {
			get {
				return GetTypedColumnValue<Guid>("PeriodTypeId");
			}
			set {
				SetColumnValue("PeriodTypeId", value);
				_periodType = null;
			}
		}

		/// <exclude/>
		public string PeriodTypeName {
			get {
				return GetTypedColumnValue<string>("PeriodTypeName");
			}
			set {
				SetColumnValue("PeriodTypeName", value);
				if (_periodType != null) {
					_periodType.Name = value;
				}
			}
		}

		private PeriodType _periodType;
		/// <summary>
		/// Тип периода.
		/// </summary>
		public PeriodType PeriodType {
			get {
				return _periodType ??
					(_periodType = LookupColumnEntities.GetEntity("PeriodType") as PeriodType);
			}
		}

		/// <exclude/>
		public Guid ForecastEntityId {
			get {
				return GetTypedColumnValue<Guid>("ForecastEntityId");
			}
			set {
				SetColumnValue("ForecastEntityId", value);
				_forecastEntity = null;
			}
		}

		/// <exclude/>
		public string ForecastEntityTitle {
			get {
				return GetTypedColumnValue<string>("ForecastEntityTitle");
			}
			set {
				SetColumnValue("ForecastEntityTitle", value);
				if (_forecastEntity != null) {
					_forecastEntity.Title = value;
				}
			}
		}

		private VwEntityObjects _forecastEntity;
		/// <summary>
		/// Объект планирования.
		/// </summary>
		public VwEntityObjects ForecastEntity {
			get {
				return _forecastEntity ??
					(_forecastEntity = LookupColumnEntities.GetEntity("ForecastEntity") as VwEntityObjects);
			}
		}

		/// <summary>
		/// Идентификатор схемы хранения данных планирования.
		/// </summary>
		public Guid ForecastEntityInCellUId {
			get {
				return GetTypedColumnValue<Guid>("ForecastEntityInCellUId");
			}
			set {
				SetColumnValue("ForecastEntityInCellUId", value);
			}
		}

		/// <summary>
		/// Параметры планирования.
		/// </summary>
		public string Setting {
			get {
				return GetTypedColumnValue<string>("Setting");
			}
			set {
				SetColumnValue("Setting", value);
			}
		}

		/// <summary>
		/// Дата и время последнего расчета.
		/// </summary>
		public DateTime LastCalculationDateTime {
			get {
				return GetTypedColumnValue<DateTime>("LastCalculationDateTime");
			}
			set {
				SetColumnValue("LastCalculationDateTime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastSheet_CoreForecastEventsProcess(UserConnection);
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
			return new ForecastSheet(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastSheet_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastSheet_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastSheet
	{

		public ForecastSheet_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastSheet_CoreForecastEventsProcess";
			SchemaUId = new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f97c7d7a-e614-4850-8ec4-98d8af22b3d0");
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

	#region Class: ForecastSheet_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastSheet_CoreForecastEventsProcess : ForecastSheet_CoreForecastEventsProcess<ForecastSheet>
	{

		public ForecastSheet_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastSheet_CoreForecastEventsProcess

	public partial class ForecastSheet_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastSheetEventsProcess

	/// <exclude/>
	public class ForecastSheetEventsProcess : ForecastSheet_CoreForecastEventsProcess
	{

		public ForecastSheetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

