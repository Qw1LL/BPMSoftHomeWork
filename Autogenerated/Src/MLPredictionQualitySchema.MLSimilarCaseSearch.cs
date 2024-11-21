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

	#region Class: MLPredictionQualitySchema

	/// <exclude/>
	public class MLPredictionQualitySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MLPredictionQualitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MLPredictionQualitySchema(MLPredictionQualitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MLPredictionQualitySchema(MLPredictionQualitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb");
			RealUId = new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb");
			Name = "MLPredictionQuality";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d3d1aca1-b719-4f75-92c6-8c70a7268957");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MLPredictionQuality(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MLPredictionQuality_MLSimilarCaseSearchEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MLPredictionQualitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MLPredictionQualitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb"));
		}

		#endregion

	}

	#endregion

	#region Class: MLPredictionQuality

	/// <summary>
	/// Качество прогноза.
	/// </summary>
	public class MLPredictionQuality : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MLPredictionQuality(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MLPredictionQuality";
		}

		public MLPredictionQuality(MLPredictionQuality source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MLPredictionQuality_MLSimilarCaseSearchEventsProcess(UserConnection);
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
			return new MLPredictionQuality(this);
		}

		#endregion

	}

	#endregion

	#region Class: MLPredictionQuality_MLSimilarCaseSearchEventsProcess

	/// <exclude/>
	public partial class MLPredictionQuality_MLSimilarCaseSearchEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MLPredictionQuality
	{

		public MLPredictionQuality_MLSimilarCaseSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MLPredictionQuality_MLSimilarCaseSearchEventsProcess";
			SchemaUId = new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c2e0f3d5-2043-7308-e3d8-b294677bdfdb");
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

	#region Class: MLPredictionQuality_MLSimilarCaseSearchEventsProcess

	/// <exclude/>
	public class MLPredictionQuality_MLSimilarCaseSearchEventsProcess : MLPredictionQuality_MLSimilarCaseSearchEventsProcess<MLPredictionQuality>
	{

		public MLPredictionQuality_MLSimilarCaseSearchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MLPredictionQuality_MLSimilarCaseSearchEventsProcess

	public partial class MLPredictionQuality_MLSimilarCaseSearchEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: MLPredictionQualityEventsProcess

	/// <exclude/>
	public class MLPredictionQualityEventsProcess : MLPredictionQuality_MLSimilarCaseSearchEventsProcess
	{

		public MLPredictionQualityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

