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

	#region Class: MLPredictionSchema

	/// <exclude/>
	public class MLPredictionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLPredictionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLPredictionSchema(MLPredictionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLPredictionSchema(MLPredictionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06");
			RealUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06");
			Name = "MLPrediction";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("686a618b-d912-4657-aaee-25a80d9dc262")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("e5bdbbdb-3a9f-4c69-b5ad-42421d2e4abd")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("4d5ab0b0-27a6-4f0d-a44f-3f0e676301d6")) == null) {
				Columns.Add(CreateProbabilityColumn());
			}
			if (Columns.FindByUId(new Guid("4c453313-56de-4548-b921-071657efca4f")) == null) {
				Columns.Add(CreateModelInstanceUIdColumn());
			}
			if (Columns.FindByUId(new Guid("0f46eb66-f538-454d-91e2-82751422e1f7")) == null) {
				Columns.Add(CreateModelColumn());
			}
			if (Columns.FindByUId(new Guid("5e98f787-96e9-4883-896f-4e94f1d8b18f")) == null) {
				Columns.Add(CreateFeatureContributionsColumn());
			}
			if (Columns.FindByUId(new Guid("84e52fc1-575a-4f52-bc86-2769b4ff761f")) == null) {
				Columns.Add(CreateBiasColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06");
			return column;
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("686a618b-d912-4657-aaee-25a80d9dc262"),
				Name = @"Key",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e5bdbbdb-3a9f-4c69-b5ad-42421d2e4abd"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12")
			};
		}

		protected virtual EntitySchemaColumn CreateProbabilityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("4d5ab0b0-27a6-4f0d-a44f-3f0e676301d6"),
				Name = @"Probability",
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12")
			};
		}

		protected virtual EntitySchemaColumn CreateModelInstanceUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4c453313-56de-4548-b921-071657efca4f"),
				Name = @"ModelInstanceUId",
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12")
			};
		}

		protected virtual EntitySchemaColumn CreateModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f46eb66-f538-454d-91e2-82751422e1f7"),
				Name = @"Model",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("10e294ac-851a-4b19-b311-15fba1867b12")
			};
		}

		protected virtual EntitySchemaColumn CreateFeatureContributionsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5e98f787-96e9-4883-896f-4e94f1d8b18f"),
				Name = @"FeatureContributions",
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateBiasColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("84e52fc1-575a-4f52-bc86-2769b4ff761f"),
				Name = @"Bias",
				CreatedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				ModifiedInSchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLPrediction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLPrediction_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLPredictionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLPredictionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06"));
		}

		#endregion

	}

	#endregion

	#region Class: MLPrediction

	/// <summary>
	/// ML model prediction result.
	/// </summary>
	public class MLPrediction : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLPrediction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLPrediction";
		}

		public MLPrediction(MLPrediction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Predicted entity Id.
		/// </summary>
		public Guid Key {
			get {
				return GetTypedColumnValue<Guid>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Predicted value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <summary>
		/// Predicted value probability.
		/// </summary>
		public Decimal Probability {
			get {
				return GetTypedColumnValue<Decimal>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// Model instance Id.
		/// </summary>
		public Guid ModelInstanceUId {
			get {
				return GetTypedColumnValue<Guid>("ModelInstanceUId");
			}
			set {
				SetColumnValue("ModelInstanceUId", value);
			}
		}

		/// <exclude/>
		public Guid ModelId {
			get {
				return GetTypedColumnValue<Guid>("ModelId");
			}
			set {
				SetColumnValue("ModelId", value);
				_model = null;
			}
		}

		/// <exclude/>
		public string ModelName {
			get {
				return GetTypedColumnValue<string>("ModelName");
			}
			set {
				SetColumnValue("ModelName", value);
				if (_model != null) {
					_model.Name = value;
				}
			}
		}

		private MLModel _model;
		/// <summary>
		/// Model class.
		/// </summary>
		public MLModel Model {
			get {
				return _model ??
					(_model = LookupColumnEntities.GetEntity("Model") as MLModel);
			}
		}

		/// <summary>
		/// FeatureContributions.
		/// </summary>
		public string FeatureContributions {
			get {
				return GetTypedColumnValue<string>("FeatureContributions");
			}
			set {
				SetColumnValue("FeatureContributions", value);
			}
		}

		/// <summary>
		/// Bias.
		/// </summary>
		public Decimal Bias {
			get {
				return GetTypedColumnValue<Decimal>("Bias");
			}
			set {
				SetColumnValue("Bias", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLPrediction_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLPredictionDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLPrediction(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLPrediction_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLPrediction_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLPrediction
	{

		public MLPrediction_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLPrediction_MLBaseEventsProcess";
			SchemaUId = new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("224ad954-5350-45b9-8dfd-8dcfa8ad8e06");
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

	#region Class: MLPrediction_MLBaseEventsProcess

	/// <exclude/>
	public class MLPrediction_MLBaseEventsProcess : MLPrediction_MLBaseEventsProcess<MLPrediction>
	{

		public MLPrediction_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLPrediction_MLBaseEventsProcess

	public partial class MLPrediction_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLPredictionEventsProcess

	/// <exclude/>
	public class MLPredictionEventsProcess : MLPrediction_MLBaseEventsProcess
	{

		public MLPredictionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

