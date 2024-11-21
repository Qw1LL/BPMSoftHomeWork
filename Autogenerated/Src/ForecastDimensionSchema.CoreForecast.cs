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

	#region Class: ForecastDimensionSchema

	/// <exclude/>
	public class ForecastDimensionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ForecastDimensionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ForecastDimensionSchema(ForecastDimensionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ForecastDimensionSchema(ForecastDimensionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d");
			RealUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d");
			Name = "ForecastDimension";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e8663296-266f-43ab-99ca-500dc0f4df99")) == null) {
				Columns.Add(CreateLevelColumn());
			}
			if (Columns.FindByUId(new Guid("686e5fcf-d4d5-498e-864a-6dabd5e62e29")) == null) {
				Columns.Add(CreateDimensionColumn());
			}
			if (Columns.FindByUId(new Guid("f000aea4-ef77-4981-833c-07d409872721")) == null) {
				Columns.Add(CreateForecastColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e8663296-266f-43ab-99ca-500dc0f4df99"),
				Name = @"Level",
				CreatedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				ModifiedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateDimensionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("686e5fcf-d4d5-498e-864a-6dabd5e62e29"),
				Name = @"Dimension",
				ReferenceSchemaUId = new Guid("488f25fa-5d1c-49d4-b2f0-8d6c2a5eab19"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				ModifiedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				CreatedInPackageId = new Guid("7c408f6d-0911-41c7-b495-80ace275c6f2")
			};
		}

		protected virtual EntitySchemaColumn CreateForecastColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f000aea4-ef77-4981-833c-07d409872721"),
				Name = @"Forecast",
				ReferenceSchemaUId = new Guid("ba399098-a520-4a1b-9ab2-2ec7ea8d97c9"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
				ModifiedInSchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"),
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
			return new ForecastDimension(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ForecastDimension_CoreForecastEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ForecastDimensionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ForecastDimensionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c83de6c5-e072-4faf-9401-3092055fe96d"));
		}

		#endregion

	}

	#endregion

	#region Class: ForecastDimension

	/// <summary>
	/// Срез планирования.
	/// </summary>
	public class ForecastDimension : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ForecastDimension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastDimension";
		}

		public ForecastDimension(ForecastDimension source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Уровень.
		/// </summary>
		public int Level {
			get {
				return GetTypedColumnValue<int>("Level");
			}
			set {
				SetColumnValue("Level", value);
			}
		}

		/// <exclude/>
		public Guid DimensionId {
			get {
				return GetTypedColumnValue<Guid>("DimensionId");
			}
			set {
				SetColumnValue("DimensionId", value);
				_dimension = null;
			}
		}

		/// <exclude/>
		public string DimensionName {
			get {
				return GetTypedColumnValue<string>("DimensionName");
			}
			set {
				SetColumnValue("DimensionName", value);
				if (_dimension != null) {
					_dimension.Name = value;
				}
			}
		}

		private Dimension _dimension;
		/// <summary>
		/// Измерение.
		/// </summary>
		public Dimension Dimension {
			get {
				return _dimension ??
					(_dimension = LookupColumnEntities.GetEntity("Dimension") as Dimension);
			}
		}

		/// <exclude/>
		public Guid ForecastId {
			get {
				return GetTypedColumnValue<Guid>("ForecastId");
			}
			set {
				SetColumnValue("ForecastId", value);
				_forecast = null;
			}
		}

		/// <exclude/>
		public string ForecastName {
			get {
				return GetTypedColumnValue<string>("ForecastName");
			}
			set {
				SetColumnValue("ForecastName", value);
				if (_forecast != null) {
					_forecast.Name = value;
				}
			}
		}

		private Forecast _forecast;
		/// <summary>
		/// Планирование.
		/// </summary>
		public Forecast Forecast {
			get {
				return _forecast ??
					(_forecast = LookupColumnEntities.GetEntity("Forecast") as Forecast);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ForecastDimension_CoreForecastEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ForecastDimensionDeleted", e);
			Validating += (s, e) => ThrowEvent("ForecastDimensionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ForecastDimension(this);
		}

		#endregion

	}

	#endregion

	#region Class: ForecastDimension_CoreForecastEventsProcess

	/// <exclude/>
	public partial class ForecastDimension_CoreForecastEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ForecastDimension
	{

		public ForecastDimension_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ForecastDimension_CoreForecastEventsProcess";
			SchemaUId = new Guid("c83de6c5-e072-4faf-9401-3092055fe96d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c83de6c5-e072-4faf-9401-3092055fe96d");
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

	#region Class: ForecastDimension_CoreForecastEventsProcess

	/// <exclude/>
	public class ForecastDimension_CoreForecastEventsProcess : ForecastDimension_CoreForecastEventsProcess<ForecastDimension>
	{

		public ForecastDimension_CoreForecastEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ForecastDimension_CoreForecastEventsProcess

	public partial class ForecastDimension_CoreForecastEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ForecastDimensionEventsProcess

	/// <exclude/>
	public class ForecastDimensionEventsProcess : ForecastDimension_CoreForecastEventsProcess
	{

		public ForecastDimensionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

