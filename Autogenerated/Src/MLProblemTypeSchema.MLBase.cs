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

	#region Class: MLProblemTypeSchema

	/// <exclude/>
	public class MLProblemTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MLProblemTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLProblemTypeSchema(MLProblemTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLProblemTypeSchema(MLProblemTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03");
			RealUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03");
			Name = "MLProblemType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3e9edcdb-49d1-42f1-a12e-8a785812a474");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5e87c380-8c1d-4af8-88a3-326d58e4d7a7")) == null) {
				Columns.Add(CreateServiceUrlColumn());
			}
			if (Columns.FindByUId(new Guid("d4f51f31-d76c-4ed8-a4f1-5f7ba2ef6530")) == null) {
				Columns.Add(CreateTrainingEndpointColumn());
			}
			if (Columns.FindByUId(new Guid("a6705175-f308-4c94-8209-9dc62e54ef9b")) == null) {
				Columns.Add(CreatePredictionEndpointColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateServiceUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5e87c380-8c1d-4af8-88a3-326d58e4d7a7"),
				Name = @"ServiceUrl",
				CreatedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				ModifiedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				CreatedInPackageId = new Guid("3e9edcdb-49d1-42f1-a12e-8a785812a474")
			};
		}

		protected virtual EntitySchemaColumn CreateTrainingEndpointColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d4f51f31-d76c-4ed8-a4f1-5f7ba2ef6530"),
				Name = @"TrainingEndpoint",
				CreatedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				ModifiedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				CreatedInPackageId = new Guid("3e9edcdb-49d1-42f1-a12e-8a785812a474")
			};
		}

		protected virtual EntitySchemaColumn CreatePredictionEndpointColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a6705175-f308-4c94-8209-9dc62e54ef9b"),
				Name = @"PredictionEndpoint",
				CreatedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				ModifiedInSchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"),
				CreatedInPackageId = new Guid("3e9edcdb-49d1-42f1-a12e-8a785812a474")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLProblemType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLProblemType_MLBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLProblemTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLProblemTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03"));
		}

		#endregion

	}

	#endregion

	#region Class: MLProblemType

	/// <summary>
	/// ML problem type.
	/// </summary>
	public class MLProblemType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MLProblemType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLProblemType";
		}

		public MLProblemType(MLProblemType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Service endpoint Url.
		/// </summary>
		public string ServiceUrl {
			get {
				return GetTypedColumnValue<string>("ServiceUrl");
			}
			set {
				SetColumnValue("ServiceUrl", value);
			}
		}

		/// <summary>
		/// Training endpoint.
		/// </summary>
		public string TrainingEndpoint {
			get {
				return GetTypedColumnValue<string>("TrainingEndpoint");
			}
			set {
				SetColumnValue("TrainingEndpoint", value);
			}
		}

		/// <summary>
		/// Prediction endpoint.
		/// </summary>
		public string PredictionEndpoint {
			get {
				return GetTypedColumnValue<string>("PredictionEndpoint");
			}
			set {
				SetColumnValue("PredictionEndpoint", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLProblemType_MLBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MLProblemTypeDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MLProblemType(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLProblemType_MLBaseEventsProcess

	/// <exclude/>
	public partial class MLProblemType_MLBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MLProblemType
	{

		public MLProblemType_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLProblemType_MLBaseEventsProcess";
			SchemaUId = new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb5f6c84-15e9-4a53-b3cd-f42c0d364b03");
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

	#region Class: MLProblemType_MLBaseEventsProcess

	/// <exclude/>
	public class MLProblemType_MLBaseEventsProcess : MLProblemType_MLBaseEventsProcess<MLProblemType>
	{

		public MLProblemType_MLBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLProblemType_MLBaseEventsProcess

	public partial class MLProblemType_MLBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MLProblemTypeEventsProcess

	/// <exclude/>
	public class MLProblemTypeEventsProcess : MLProblemType_MLBaseEventsProcess
	{

		public MLProblemTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

