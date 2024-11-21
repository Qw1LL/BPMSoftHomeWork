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

	#region Class: MLClassificationResultSchema

	/// <exclude/>
	public class MLClassificationResultSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MLClassificationResultSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLClassificationResultSchema(MLClassificationResultSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLClassificationResultSchema(MLClassificationResultSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038");
			RealUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038");
			Name = "MLClassificationResult";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cd67e23b-5993-4489-a1b3-4a0fad7a42f2")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("4be7ff50-ceea-441e-8ead-e3dc7be9cfd0")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("f25ca1b2-d263-43ea-a678-1221f61a83e8")) == null) {
				Columns.Add(CreateProbabilityColumn());
			}
			if (Columns.FindByUId(new Guid("d388881d-4c6e-4927-8860-993ddf38d2df")) == null) {
				Columns.Add(CreateModelInstanceUIdColumn());
			}
			if (Columns.FindByUId(new Guid("252c5182-d67f-4539-ab8f-383131e7ff76")) == null) {
				Columns.Add(CreateModelColumn());
			}
			if (Columns.FindByUId(new Guid("c0f86107-b541-43a5-9443-f91c05f3bec7")) == null) {
				Columns.Add(CreateSignificanceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cd67e23b-5993-4489-a1b3-4a0fad7a42f2"),
				Name = @"Key",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4be7ff50-ceea-441e-8ead-e3dc7be9cfd0"),
				Name = @"Value",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected virtual EntitySchemaColumn CreateProbabilityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("f25ca1b2-d263-43ea-a678-1221f61a83e8"),
				Name = @"Probability",
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected virtual EntitySchemaColumn CreateModelInstanceUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d388881d-4c6e-4927-8860-993ddf38d2df"),
				Name = @"ModelInstanceUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected virtual EntitySchemaColumn CreateModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("252c5182-d67f-4539-ab8f-383131e7ff76"),
				Name = @"Model",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				CreatedInPackageId = new Guid("62fdb191-1544-4399-9d20-c308d8466eaa")
			};
		}

		protected virtual EntitySchemaColumn CreateSignificanceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("c0f86107-b541-43a5-9443-f91c05f3bec7"),
				Name = @"Significance",
				CreatedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
				ModifiedInSchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038"),
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
			return new MLClassificationResult(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLClassificationResult_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLClassificationResultSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLClassificationResultSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("010231dd-f848-4edf-88a4-6480c73c9038"));
		}

		#endregion

	}

	#endregion

	#region Class: MLClassificationResult

	/// <summary>
	/// ML model classification result.
	/// </summary>
	public class MLClassificationResult : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MLClassificationResult(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLClassificationResult";
		}

		public MLClassificationResult(MLClassificationResult source)
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
		public Guid Value {
			get {
				return GetTypedColumnValue<Guid>("Value");
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
		/// ML service model identifier.
		/// </summary>
		/// <remarks>
		/// Model instance Id.
		/// </remarks>
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
		/// ML model.
		/// </summary>
		public MLModel Model {
			get {
				return _model ??
					(_model = LookupColumnEntities.GetEntity("Model") as MLModel);
			}
		}

		/// <summary>
		/// Prediction significance.
		/// </summary>
		public string Significance {
			get {
				return GetTypedColumnValue<string>("Significance");
			}
			set {
				SetColumnValue("Significance", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLClassificationResult_MLBaseEventsProcess(UserConnection);
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
			return new MLClassificationResult(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLClassificationResult_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLClassificationResult_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MLClassificationResult
	{

		public MLClassificationResult_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLClassificationResult_MLBaseEventsProcess";
			SchemaUId = new Guid("010231dd-f848-4edf-88a4-6480c73c9038");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("010231dd-f848-4edf-88a4-6480c73c9038");
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

	#region Class: MLClassificationResult_MLBaseEventsProcess

	/// <exclude/>
	public class MLClassificationResult_MLBaseEventsProcess : MLClassificationResult_MLBaseEventsProcess<MLClassificationResult>
	{

		public MLClassificationResult_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLClassificationResult_MLBaseEventsProcess

	public partial class MLClassificationResult_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLClassificationResultEventsProcess

	/// <exclude/>
	public class MLClassificationResultEventsProcess : MLClassificationResult_MLBaseEventsProcess
	{

		public MLClassificationResultEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

