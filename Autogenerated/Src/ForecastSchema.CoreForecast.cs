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

	#region Class: ForecastSchema

	/// <exclude/>
	public class ForecastSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastSchema(ForecastSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastSchema(ForecastSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9");
			RealUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9");
			Name = "Forecast";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
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
			if (Columns.FindByUId(new Guid("c319c5f3-ef2b-4b23-ad58-bfdfc2a08837")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("fa05dc91-1467-4da7-a00c-88d04cc07862")) == null) {
				Columns.Add(CreateEntitySchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("df1b82da-c0c7-4c4a-8b3b-7400bedcb1b5")) == null) {
				Columns.Add(CreatePeriodTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("53c2c11f-aa29-4a64-af0a-41e2ec83971c"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				ModifiedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c319c5f3-ef2b-4b23-ad58-bfdfc2a08837"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				ModifiedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("fa05dc91-1467-4da7-a00c-88d04cc07862"),
				Name = @"EntitySchemaName",
				CreatedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				ModifiedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("df1b82da-c0c7-4c4a-8b3b-7400bedcb1b5"),
				Name = @"PeriodType",
				ReferenceSchemaUId = new Guid("3608a0e4-0235-4936-9c0e-99620e73940c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				ModifiedInSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2"),
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
			return new Forecast(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Forecast_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"));
		}

		#endregion

	}

	#endregion

	#region Class: Forecast

	/// <summary>
	/// Планирование.
	/// </summary>
	public class Forecast : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Forecast(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Forecast";
		}

		public Forecast(Forecast source)
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

		/// <summary>
		/// Схема объекта.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Название объекта.
		/// </summary>
		public string EntitySchemaName {
			get {
				return GetTypedColumnValue<string>("EntitySchemaName");
			}
			set {
				SetColumnValue("EntitySchemaName", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Forecast_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ForecastDeleted", e);
			Validating += (s, e) => ThrowEvent("ForecastValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Forecast(this);
		}

		#endregion

	}

	#endregion

	#region Class: Forecast_CoreForecastEventsProcess

	/// <exclude/>
	public partial class Forecast_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Forecast
	{

		public Forecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Forecast_CoreForecastEventsProcess";
			SchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9");
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

	#region Class: Forecast_CoreForecastEventsProcess

	/// <exclude/>
	public class Forecast_CoreForecastEventsProcess : Forecast_CoreForecastEventsProcess<Forecast>
	{

		public Forecast_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Forecast_CoreForecastEventsProcess

	public partial class Forecast_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastEventsProcess

	/// <exclude/>
	public class ForecastEventsProcess : Forecast_CoreForecastEventsProcess
	{

		public ForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

