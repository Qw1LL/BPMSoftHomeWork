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

	#region Class: ForecastItemValueSchema

	/// <exclude/>
	public class ForecastItemValueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastItemValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastItemValueSchema(ForecastItemValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastItemValueSchema(ForecastItemValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2");
			RealUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2");
			Name = "ForecastItemValue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("54762015-49f3-475d-ba2e-c50e9d21e023")) == null) {
				Columns.Add(CreateForecastIndicatorColumn());
			}
			if (Columns.FindByUId(new Guid("2c01f2de-73da-408d-81bf-2de963faf235")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("582133cf-0719-4f0f-a59e-981133880692")) == null) {
				Columns.Add(CreatePeriodColumn());
			}
			if (Columns.FindByUId(new Guid("a41ceccf-40d0-4b53-b5ea-8fc2930f1383")) == null) {
				Columns.Add(CreateForecastItemColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateForecastIndicatorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("54762015-49f3-475d-ba2e-c50e9d21e023"),
				Name = @"ForecastIndicator",
				ReferenceSchemaUId = new Guid("e0b448d7-44a9-465c-8de0-2f79c3415fba"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				ModifiedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("2c01f2de-73da-408d-81bf-2de963faf235"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				ModifiedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("582133cf-0719-4f0f-a59e-981133880692"),
				Name = @"Period",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				ModifiedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a41ceccf-40d0-4b53-b5ea-8fc2930f1383"),
				Name = @"ForecastItem",
				ReferenceSchemaUId = new Guid("03d3b337-cda2-4993-ab53-d0bdf2c4bd43"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				ModifiedInSchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ForecastItemValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastItemValue_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastItemValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastItemValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastItemValue

	/// <summary>
	/// Значение элемента планирования (не используется).
	/// </summary>
	public class ForecastItemValue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastItemValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastItemValue";
		}

		public ForecastItemValue(ForecastItemValue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ForecastIndicatorId {
			get {
				return GetTypedColumnValue<Guid>("ForecastIndicatorId");
			}
			set {
				SetColumnValue("ForecastIndicatorId", value);
				_forecastIndicator = null;
			}
		}

		/// <exclude/>
		public string ForecastIndicatorName {
			get {
				return GetTypedColumnValue<string>("ForecastIndicatorName");
			}
			set {
				SetColumnValue("ForecastIndicatorName", value);
				if (_forecastIndicator != null) {
					_forecastIndicator.Name = value;
				}
			}
		}

		private ForecastIndicator _forecastIndicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator ForecastIndicator {
			get {
				return _forecastIndicator ??
					(_forecastIndicator = LookupColumnEntities.GetEntity("ForecastIndicator") as ForecastIndicator);
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public Decimal Value {
			get {
				return GetTypedColumnValue<Decimal>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid PeriodId {
			get {
				return GetTypedColumnValue<Guid>("PeriodId");
			}
			set {
				SetColumnValue("PeriodId", value);
				_period = null;
			}
		}

		/// <exclude/>
		public string PeriodName {
			get {
				return GetTypedColumnValue<string>("PeriodName");
			}
			set {
				SetColumnValue("PeriodName", value);
				if (_period != null) {
					_period.Name = value;
				}
			}
		}

		private Period _period;
		/// <summary>
		/// Период.
		/// </summary>
		public Period Period {
			get {
				return _period ??
					(_period = LookupColumnEntities.GetEntity("Period") as Period);
			}
		}

		/// <exclude/>
		public Guid ForecastItemId {
			get {
				return GetTypedColumnValue<Guid>("ForecastItemId");
			}
			set {
				SetColumnValue("ForecastItemId", value);
				_forecastItem = null;
			}
		}

		private ForecastItem _forecastItem;
		/// <summary>
		/// Элемент планирования.
		/// </summary>
		public ForecastItem ForecastItem {
			get {
				return _forecastItem ??
					(_forecastItem = LookupColumnEntities.GetEntity("ForecastItem") as ForecastItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastItemValue_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ForecastItemValueDeleted", e);
			Validating += (s, e) => ThrowEvent("ForecastItemValueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ForecastItemValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastItemValue_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastItemValue_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastItemValue
	{

		public ForecastItemValue_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastItemValue_CoreForecastEventsProcess";
			SchemaUId = new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fd29bf52-6353-4e5a-a20c-5ce6de91c2a2");
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

	#region Class: ForecastItemValue_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastItemValue_CoreForecastEventsProcess : ForecastItemValue_CoreForecastEventsProcess<ForecastItemValue>
	{

		public ForecastItemValue_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastItemValue_CoreForecastEventsProcess

	public partial class ForecastItemValue_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastItemValueEventsProcess

	/// <exclude/>
	public class ForecastItemValueEventsProcess : ForecastItemValue_CoreForecastEventsProcess
	{

		public ForecastItemValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

