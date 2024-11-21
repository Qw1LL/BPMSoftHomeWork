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

	#region Class: ScoringRuleSchema

	/// <exclude/>
	public class ScoringRuleSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ScoringRuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ScoringRuleSchema(ScoringRuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ScoringRuleSchema(ScoringRuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85");
			RealUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85");
			Name = "ScoringRule";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1");
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
			if (Columns.FindByUId(new Guid("c1a837b6-00f6-422e-a657-42b5eb5f53c1")) == null) {
				Columns.Add(CreateScoringModelColumn());
			}
			if (Columns.FindByUId(new Guid("c334f0d3-732f-4d3a-ad3a-4bd4da1e3874")) == null) {
				Columns.Add(CreateFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("af32b496-b372-4f2a-96bb-5fe5c824c913")) == null) {
				Columns.Add(CreateScoringCountColumn());
			}
			if (Columns.FindByUId(new Guid("6c1fada8-2146-44df-ae01-f078c276724c")) == null) {
				Columns.Add(CreateScoringPointsColumn());
			}
			if (Columns.FindByUId(new Guid("fa1b00ad-e47f-41ca-bcbe-785167a4fc72")) == null) {
				Columns.Add(CreateDurationColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b2fd743d-292c-4c0f-93b1-69dd045bf617"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateScoringModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c1a837b6-00f6-422e-a657-42b5eb5f53c1"),
				Name = @"ScoringModel",
				ReferenceSchemaUId = new Guid("3dfc230a-58bc-4ab3-9dbe-7eb8225edfa0"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c334f0d3-732f-4d3a-ad3a-4bd4da1e3874"),
				Name = @"FilterData",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateScoringCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("af32b496-b372-4f2a-96bb-5fe5c824c913"),
				Name = @"ScoringCount",
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateScoringPointsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("6c1fada8-2146-44df-ae01-f078c276724c"),
				Name = @"ScoringPoints",
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fa1b00ad-e47f-41ca-bcbe-785167a4fc72"),
				Name = @"Duration",
				CreatedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				ModifiedInSchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"),
				CreatedInPackageId = new Guid("2172ffdc-40f1-4f25-9efc-3451f9e465a1"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
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
			return new ScoringRule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ScoringRule_BaseScoringEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ScoringRuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ScoringRuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85"));
		}

		#endregion

	}

	#endregion

	#region Class: ScoringRule

	/// <summary>
	/// Scoring rule.
	/// </summary>
	public class ScoringRule : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ScoringRule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ScoringRule";
		}

		public ScoringRule(ScoringRule source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Rule name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid ScoringModelId {
			get {
				return GetTypedColumnValue<Guid>("ScoringModelId");
			}
			set {
				SetColumnValue("ScoringModelId", value);
				_scoringModel = null;
			}
		}

		/// <exclude/>
		public string ScoringModelName {
			get {
				return GetTypedColumnValue<string>("ScoringModelName");
			}
			set {
				SetColumnValue("ScoringModelName", value);
				if (_scoringModel != null) {
					_scoringModel.Name = value;
				}
			}
		}

		private ScoringModel _scoringModel;
		/// <summary>
		/// Scoring model.
		/// </summary>
		public ScoringModel ScoringModel {
			get {
				return _scoringModel ??
					(_scoringModel = LookupColumnEntities.GetEntity("ScoringModel") as ScoringModel);
			}
		}

		/// <summary>
		/// Filter.
		/// </summary>
		public string FilterData {
			get {
				return GetTypedColumnValue<string>("FilterData");
			}
			set {
				SetColumnValue("FilterData", value);
			}
		}

		/// <summary>
		/// Number of times applied.
		/// </summary>
		public int ScoringCount {
			get {
				return GetTypedColumnValue<int>("ScoringCount");
			}
			set {
				SetColumnValue("ScoringCount", value);
			}
		}

		/// <summary>
		/// Scoring points.
		/// </summary>
		public Decimal ScoringPoints {
			get {
				return GetTypedColumnValue<Decimal>("ScoringPoints");
			}
			set {
				SetColumnValue("ScoringPoints", value);
			}
		}

		/// <summary>
		/// Effective for, days.
		/// </summary>
		public int Duration {
			get {
				return GetTypedColumnValue<int>("Duration");
			}
			set {
				SetColumnValue("Duration", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ScoringRule_BaseScoringEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ScoringRuleDeleted", e);
			Validating += (s, e) => ThrowEvent("ScoringRuleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ScoringRule(this);
		}

		#endregion

	}

	#endregion

	#region Class: ScoringRule_BaseScoringEventsProcess

	/// <exclude/>
	public partial class ScoringRule_BaseScoringEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ScoringRule
	{

		public ScoringRule_BaseScoringEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ScoringRule_BaseScoringEventsProcess";
			SchemaUId = new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b0122734-10d9-4a5b-9364-e8fd3ceccf85");
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

	#region Class: ScoringRule_BaseScoringEventsProcess

	/// <exclude/>
	public class ScoringRule_BaseScoringEventsProcess : ScoringRule_BaseScoringEventsProcess<ScoringRule>
	{

		public ScoringRule_BaseScoringEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ScoringRule_BaseScoringEventsProcess

	public partial class ScoringRule_BaseScoringEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ScoringRuleEventsProcess

	/// <exclude/>
	public class ScoringRuleEventsProcess : ScoringRule_BaseScoringEventsProcess
	{

		public ScoringRuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

