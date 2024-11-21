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

	#region Class: MLTrainSessionSchema

	/// <exclude/>
	public class MLTrainSessionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLTrainSessionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLTrainSessionSchema(MLTrainSessionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLTrainSessionSchema(MLTrainSessionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841");
			RealUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841");
			Name = "MLTrainSession";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ab69353e-097f-4ae5-8487-d2b8dea7e6e3")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
			if (Columns.FindByUId(new Guid("024b70b5-aae8-4fd6-8b58-06724a1ef3d0")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("24cfe166-850a-4015-9a53-b98641ebce11")) == null) {
				Columns.Add(CreateInUseColumn());
			}
			if (Columns.FindByUId(new Guid("915e3530-e76d-4689-9ec7-6b895411bce4")) == null) {
				Columns.Add(CreateErrorColumn());
			}
			if (Columns.FindByUId(new Guid("2110c3a1-3066-4622-a8d5-19ec57eb34dd")) == null) {
				Columns.Add(CreateTrainedOnColumn());
			}
			if (Columns.FindByUId(new Guid("b9515ea5-ae59-4bc2-b680-2af2306db31f")) == null) {
				Columns.Add(CreateTrainSetSizeColumn());
			}
			if (Columns.FindByUId(new Guid("8dc69e3b-d749-4458-89ea-aa431194f98e")) == null) {
				Columns.Add(CreateInstanceMetricColumn());
			}
			if (Columns.FindByUId(new Guid("fdbedcd2-4e1f-4b69-bec2-dfa4e3075597")) == null) {
				Columns.Add(CreateTrainingTimeMinutesColumn());
			}
			if (Columns.FindByUId(new Guid("2c68f9b3-b19e-48cd-bc2f-0648f8f8154c")) == null) {
				Columns.Add(CreateIgnoreMetricThresholdColumn());
			}
			if (Columns.FindByUId(new Guid("0892c988-7771-46b6-bdc4-159597eb3869")) == null) {
				Columns.Add(CreateFeatureImportancesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ab69353e-097f-4ae5-8487-d2b8dea7e6e3"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("024b70b5-aae8-4fd6-8b58-06724a1ef3d0"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("83a4b85c-3c8f-45c5-bb2c-ee6a45ba8cdc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateInUseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("24cfe166-850a-4015-9a53-b98641ebce11"),
				Name = @"InUse",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("915e3530-e76d-4689-9ec7-6b895411bce4"),
				Name = @"Error",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateTrainedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("2110c3a1-3066-4622-a8d5-19ec57eb34dd"),
				Name = @"TrainedOn",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateTrainSetSizeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b9515ea5-ae59-4bc2-b680-2af2306db31f"),
				Name = @"TrainSetSize",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateInstanceMetricColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("8dc69e3b-d749-4458-89ea-aa431194f98e"),
				Name = @"InstanceMetric",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateTrainingTimeMinutesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fdbedcd2-4e1f-4b69-bec2-dfa4e3075597"),
				Name = @"TrainingTimeMinutes",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("7e80e3e9-e3bc-4e71-8b35-80232abfe92e")
			};
		}

		protected virtual EntitySchemaColumn CreateIgnoreMetricThresholdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2c68f9b3-b19e-48cd-bc2f-0648f8f8154c"),
				Name = @"IgnoreMetricThreshold",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("8bab9e12-6ef4-4d97-ae92-182a028c5592")
			};
		}

		protected virtual EntitySchemaColumn CreateFeatureImportancesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0892c988-7771-46b6-bdc4-159597eb3869"),
				Name = @"FeatureImportances",
				CreatedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				ModifiedInSchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"),
				CreatedInPackageId = new Guid("8bab9e12-6ef4-4d97-ae92-182a028c5592"),
				IsMultiLineText = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"{ }"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLTrainSession(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLTrainSession_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLTrainSessionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLTrainSessionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841"));
		}

		#endregion

	}

	#endregion

	#region Class: MLTrainSession

	/// <summary>
	/// ML train session.
	/// </summary>
	public class MLTrainSession : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLTrainSession(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLTrainSession";
		}

		public MLTrainSession(MLTrainSession source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// Model.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = LookupColumnEntities.GetEntity("MLModel") as MLModel);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private MLModelState _state;
		/// <summary>
		/// Status.
		/// </summary>
		public MLModelState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as MLModelState);
			}
		}

		/// <summary>
		/// Model in use.
		/// </summary>
		public bool InUse {
			get {
				return GetTypedColumnValue<bool>("InUse");
			}
			set {
				SetColumnValue("InUse", value);
			}
		}

		/// <summary>
		/// Error message text.
		/// </summary>
		public string Error {
			get {
				return GetTypedColumnValue<string>("Error");
			}
			set {
				SetColumnValue("Error", value);
			}
		}

		/// <summary>
		/// Trained on.
		/// </summary>
		public DateTime TrainedOn {
			get {
				return GetTypedColumnValue<DateTime>("TrainedOn");
			}
			set {
				SetColumnValue("TrainedOn", value);
			}
		}

		/// <summary>
		/// Train set size.
		/// </summary>
		public int TrainSetSize {
			get {
				return GetTypedColumnValue<int>("TrainSetSize");
			}
			set {
				SetColumnValue("TrainSetSize", value);
			}
		}

		/// <summary>
		/// Evaluation metric.
		/// </summary>
		public Decimal InstanceMetric {
			get {
				return GetTypedColumnValue<Decimal>("InstanceMetric");
			}
			set {
				SetColumnValue("InstanceMetric", value);
			}
		}

		/// <summary>
		/// Training time (min.).
		/// </summary>
		public int TrainingTimeMinutes {
			get {
				return GetTypedColumnValue<int>("TrainingTimeMinutes");
			}
			set {
				SetColumnValue("TrainingTimeMinutes", value);
			}
		}

		/// <summary>
		/// Ignore metric threshold mode.
		/// </summary>
		public bool IgnoreMetricThreshold {
			get {
				return GetTypedColumnValue<bool>("IgnoreMetricThreshold");
			}
			set {
				SetColumnValue("IgnoreMetricThreshold", value);
			}
		}

		/// <summary>
		/// Importance of model input columns.
		/// </summary>
		public string FeatureImportances {
			get {
				return GetTypedColumnValue<string>("FeatureImportances");
			}
			set {
				SetColumnValue("FeatureImportances", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLTrainSession_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLTrainSessionDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLTrainSession(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLTrainSession_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLTrainSession_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLTrainSession
	{

		public MLTrainSession_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLTrainSession_MLBaseEventsProcess";
			SchemaUId = new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9e22a1b5-8cc6-4b5a-abc8-19e2b5b06841");
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

	#region Class: MLTrainSession_MLBaseEventsProcess

	/// <exclude/>
	public class MLTrainSession_MLBaseEventsProcess : MLTrainSession_MLBaseEventsProcess<MLTrainSession>
	{

		public MLTrainSession_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLTrainSession_MLBaseEventsProcess

	public partial class MLTrainSession_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLTrainSessionEventsProcess

	/// <exclude/>
	public class MLTrainSessionEventsProcess : MLTrainSession_MLBaseEventsProcess
	{

		public MLTrainSessionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

