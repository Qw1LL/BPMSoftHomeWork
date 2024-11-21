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

	#region Class: MLSimilarCaseSchema

	/// <exclude/>
	public class MLSimilarCaseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLSimilarCaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLSimilarCaseSchema(MLSimilarCaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLSimilarCaseSchema(MLSimilarCaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be");
			RealUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be");
			Name = "MLSimilarCase";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c369279c-93e1-06fb-c931-93749605231a")) == null) {
				Columns.Add(CreatePredictionQualityColumn());
			}
			if (Columns.FindByUId(new Guid("64bbb652-a85b-5e12-5072-8535d377cb7f")) == null) {
				Columns.Add(CreateScoreColumn());
			}
			if (Columns.FindByUId(new Guid("d84b4aaa-d1bf-c69b-9987-c8453a36bf5c")) == null) {
				Columns.Add(CreatePredictionDateColumn());
			}
			if (Columns.FindByUId(new Guid("e709bc42-a654-c7fd-cccf-0b349bd63b43")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
			if (Columns.FindByUId(new Guid("6f1637aa-79e8-8dff-e529-4eee74d7e52c")) == null) {
				Columns.Add(CreateSimilarCaseColumn());
			}
			if (Columns.FindByUId(new Guid("33d44497-c431-4f89-6b9a-6ef9f3465463")) == null) {
				Columns.Add(CreateParentCaseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePredictionQualityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c369279c-93e1-06fb-c931-93749605231a"),
				Name = @"PredictionQuality",
				ReferenceSchemaUId = new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"50cd941e-4bb0-4239-8bc4-99ebcf40a43d"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("64bbb652-a85b-5e12-5072-8535d377cb7f"),
				Name = @"Score",
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957")
			};
		}

		protected virtual EntitySchemaColumn CreatePredictionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d84b4aaa-d1bf-c69b-9987-c8453a36bf5c"),
				Name = @"PredictionDate",
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957")
			};
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e709bc42-a654-c7fd-cccf-0b349bd63b43"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957")
			};
		}

		protected virtual EntitySchemaColumn CreateSimilarCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f1637aa-79e8-8dff-e529-4eee74d7e52c"),
				Name = @"SimilarCase",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957")
			};
		}

		protected virtual EntitySchemaColumn CreateParentCaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33d44497-c431-4f89-6b9a-6ef9f3465463"),
				Name = @"ParentCase",
				ReferenceSchemaUId = new Guid("117d32f9-8275-4534-8411-1c66115ce9cd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				ModifiedInSchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"),
				CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLSimilarCase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLSimilarCase_MLSimilarCaseSearchEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLSimilarCaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLSimilarCaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be"));
		}

		#endregion

	}

	#endregion

	#region Class: MLSimilarCase

	/// <summary>
	/// Похожее обращение.
	/// </summary>
	public class MLSimilarCase : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLSimilarCase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLSimilarCase";
		}

		public MLSimilarCase(MLSimilarCase source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PredictionQualityId {
			get {
				return GetTypedColumnValue<Guid>("PredictionQualityId");
			}
			set {
				SetColumnValue("PredictionQualityId", value);
				_predictionQuality = null;
			}
		}

		/// <exclude/>
		public string PredictionQualityName {
			get {
				return GetTypedColumnValue<string>("PredictionQualityName");
			}
			set {
				SetColumnValue("PredictionQualityName", value);
				if (_predictionQuality != null) {
					_predictionQuality.Name = value;
				}
			}
		}

		private MLPredictionQuality _predictionQuality;
		/// <summary>
		/// Качество прогноза.
		/// </summary>
		public MLPredictionQuality PredictionQuality {
			get {
				return _predictionQuality ??
					(_predictionQuality = LookupColumnEntities.GetEntity("PredictionQuality") as MLPredictionQuality);
			}
		}

		/// <summary>
		/// Оценка похожести.
		/// </summary>
		public Decimal Score {
			get {
				return GetTypedColumnValue<Decimal>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <summary>
		/// Дата прогноза.
		/// </summary>
		public DateTime PredictionDate {
			get {
				return GetTypedColumnValue<DateTime>("PredictionDate");
			}
			set {
				SetColumnValue("PredictionDate", value);
			}
		}

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
		/// Модель машинного обучения.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = LookupColumnEntities.GetEntity("MLModel") as MLModel);
			}
		}

		/// <exclude/>
		public Guid SimilarCaseId {
			get {
				return GetTypedColumnValue<Guid>("SimilarCaseId");
			}
			set {
				SetColumnValue("SimilarCaseId", value);
				_similarCase = null;
			}
		}

		/// <exclude/>
		public string SimilarCaseNumber {
			get {
				return GetTypedColumnValue<string>("SimilarCaseNumber");
			}
			set {
				SetColumnValue("SimilarCaseNumber", value);
				if (_similarCase != null) {
					_similarCase.Number = value;
				}
			}
		}

		private Case _similarCase;
		/// <summary>
		/// Похожее обращение.
		/// </summary>
		public Case SimilarCase {
			get {
				return _similarCase ??
					(_similarCase = LookupColumnEntities.GetEntity("SimilarCase") as Case);
			}
		}

		/// <exclude/>
		public Guid ParentCaseId {
			get {
				return GetTypedColumnValue<Guid>("ParentCaseId");
			}
			set {
				SetColumnValue("ParentCaseId", value);
				_parentCase = null;
			}
		}

		/// <exclude/>
		public string ParentCaseNumber {
			get {
				return GetTypedColumnValue<string>("ParentCaseNumber");
			}
			set {
				SetColumnValue("ParentCaseNumber", value);
				if (_parentCase != null) {
					_parentCase.Number = value;
				}
			}
		}

		private Case _parentCase;
		/// <summary>
		/// Родительское обращение.
		/// </summary>
		public Case ParentCase {
			get {
				return _parentCase ??
					(_parentCase = LookupColumnEntities.GetEntity("ParentCase") as Case);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLSimilarCase_MLSimilarCaseSearchEventsProcess(UserConnection);
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
			return new MLSimilarCase(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLSimilarCase_MLSimilarCaseSearchEventsProcess

	/// <exclude/>
	public partial class MLSimilarCase_MLSimilarCaseSearchEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLSimilarCase
	{

		public MLSimilarCase_MLSimilarCaseSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLSimilarCase_MLSimilarCaseSearchEventsProcess";
			SchemaUId = new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("44bb92b4-4d75-34f2-8554-4c11b85272be");
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

	#region Class: MLSimilarCase_MLSimilarCaseSearchEventsProcess

	/// <exclude/>
	public class MLSimilarCase_MLSimilarCaseSearchEventsProcess : MLSimilarCase_MLSimilarCaseSearchEventsProcess<MLSimilarCase>
	{

		public MLSimilarCase_MLSimilarCaseSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLSimilarCase_MLSimilarCaseSearchEventsProcess

	public partial class MLSimilarCase_MLSimilarCaseSearchEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: MLSimilarCaseEventsProcess

	/// <exclude/>
	public class MLSimilarCaseEventsProcess : MLSimilarCase_MLSimilarCaseSearchEventsProcess
	{

		public MLSimilarCaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

