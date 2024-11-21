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

	#region Class: VwOpportInStageForAnalysisSchema

	/// <exclude/>
	public class VwOpportInStageForAnalysisSchema : BPMSoft.Configuration.OpportunityInStageSchema
	{

		#region Constructors: Public

		public VwOpportInStageForAnalysisSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwOpportInStageForAnalysisSchema(VwOpportInStageForAnalysisSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwOpportInStageForAnalysisSchema(VwOpportInStageForAnalysisSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755");
			RealUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755");
			Name = "VwOpportInStageForAnalysis";
			ParentSchemaUId = new Guid("670a893d-5eed-421d-b5d9-1db15b5d9ab6");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			IsDBView = true;
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
			if (Columns.FindByUId(new Guid("ce9dbb21-fd5d-4609-8a63-70ccf20deb8c")) == null) {
				Columns.Add(CreateDaysInStageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDaysInStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ce9dbb21-fd5d-4609-8a63-70ccf20deb8c"),
				Name = @"DaysInStage",
				CreatedInSchemaUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755"),
				ModifiedInSchemaUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755"),
				CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("10bbec0c-239b-4597-8408-d3e25205c5bf"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755"),
				ModifiedInSchemaUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755"),
				CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwOpportInStageForAnalysis(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwOpportInStageForAnalysis_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwOpportInStageForAnalysisSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwOpportInStageForAnalysisSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755"));
		}

		#endregion

	}

	#endregion

	#region Class: VwOpportInStageForAnalysis

	/// <summary>
	/// Представление для анализа продаж по стадиям.
	/// </summary>
	public class VwOpportInStageForAnalysis : BPMSoft.Configuration.OpportunityInStage
	{

		#region Constructors: Public

		public VwOpportInStageForAnalysis(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwOpportInStageForAnalysis";
		}

		public VwOpportInStageForAnalysis(VwOpportInStageForAnalysis source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Количество дней в стадии.
		/// </summary>
		public int DaysInStage {
			get {
				return GetTypedColumnValue<int>("DaysInStage");
			}
			set {
				SetColumnValue("DaysInStage", value);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwOpportInStageForAnalysis_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwOpportInStageForAnalysisDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwOpportInStageForAnalysis(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwOpportInStageForAnalysis_OpportunityEventsProcess

	/// <exclude/>
	public partial class VwOpportInStageForAnalysis_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityInStage_PRMPortalEventsProcess<TEntity> where TEntity : VwOpportInStageForAnalysis
	{

		public VwOpportInStageForAnalysis_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwOpportInStageForAnalysis_OpportunityEventsProcess";
			SchemaUId = new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd2400bc-3cb0-448d-81ee-32d9662c9755");
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

	#region Class: VwOpportInStageForAnalysis_OpportunityEventsProcess

	/// <exclude/>
	public class VwOpportInStageForAnalysis_OpportunityEventsProcess : VwOpportInStageForAnalysis_OpportunityEventsProcess<VwOpportInStageForAnalysis>
	{

		public VwOpportInStageForAnalysis_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwOpportInStageForAnalysis_OpportunityEventsProcess

	public partial class VwOpportInStageForAnalysis_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwOpportInStageForAnalysisEventsProcess

	/// <exclude/>
	public class VwOpportInStageForAnalysisEventsProcess : VwOpportInStageForAnalysis_OpportunityEventsProcess
	{

		public VwOpportInStageForAnalysisEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

