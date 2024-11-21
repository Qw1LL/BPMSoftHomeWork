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

	#region Class: CampaignStepRouteSchema

	/// <exclude/>
	public class CampaignStepRouteSchema : BPMSoft.Configuration.DiagramElementSchema
	{

		#region Constructors: Public

		public CampaignStepRouteSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignStepRouteSchema(CampaignStepRouteSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignStepRouteSchema(CampaignStepRouteSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40");
			RealUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40");
			Name = "CampaignStepRoute";
			ParentSchemaUId = new Guid("e1b5b3fc-bd8e-4cba-b470-5c2e909dab3e");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a7e4d09c-bcf9-4eb2-bf56-8b82dc4e3be2")) == null) {
				Columns.Add(CreateSourceStepColumn());
			}
			if (Columns.FindByUId(new Guid("a13110b0-abc0-4447-b1c3-f259e8a190d4")) == null) {
				Columns.Add(CreateTargetStepColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("aa25c329-6b1d-4f32-a1f4-9334f24acac4"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				ModifiedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceStepColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a7e4d09c-bcf9-4eb2-bf56-8b82dc4e3be2"),
				Name = @"SourceStep",
				ReferenceSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				ModifiedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected virtual EntitySchemaColumn CreateTargetStepColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a13110b0-abc0-4447-b1c3-f259e8a190d4"),
				Name = @"TargetStep",
				ReferenceSchemaUId = new Guid("1c6cda37-90f0-4b88-a13c-af0b11cc464f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				ModifiedInSchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"),
				CreatedInPackageId = new Guid("5ef8c1cb-e12d-44bb-94fb-8751249ccc2c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignStepRoute(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignStepRoute_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignStepRouteSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignStepRouteSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStepRoute

	/// <summary>
	/// Маршрут шага кампании.
	/// </summary>
	public class CampaignStepRoute : BPMSoft.Configuration.DiagramElement
	{

		#region Constructors: Public

		public CampaignStepRoute(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignStepRoute";
		}

		public CampaignStepRoute(CampaignStepRoute source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid SourceStepId {
			get {
				return GetTypedColumnValue<Guid>("SourceStepId");
			}
			set {
				SetColumnValue("SourceStepId", value);
				_sourceStep = null;
			}
		}

		/// <exclude/>
		public string SourceStepTitle {
			get {
				return GetTypedColumnValue<string>("SourceStepTitle");
			}
			set {
				SetColumnValue("SourceStepTitle", value);
				if (_sourceStep != null) {
					_sourceStep.Title = value;
				}
			}
		}

		private CampaignStep _sourceStep;
		/// <summary>
		/// Исходный шаг.
		/// </summary>
		public CampaignStep SourceStep {
			get {
				return _sourceStep ??
					(_sourceStep = LookupColumnEntities.GetEntity("SourceStep") as CampaignStep);
			}
		}

		/// <exclude/>
		public Guid TargetStepId {
			get {
				return GetTypedColumnValue<Guid>("TargetStepId");
			}
			set {
				SetColumnValue("TargetStepId", value);
				_targetStep = null;
			}
		}

		/// <exclude/>
		public string TargetStepTitle {
			get {
				return GetTypedColumnValue<string>("TargetStepTitle");
			}
			set {
				SetColumnValue("TargetStepTitle", value);
				if (_targetStep != null) {
					_targetStep.Title = value;
				}
			}
		}

		private CampaignStep _targetStep;
		/// <summary>
		/// Конечный шаг.
		/// </summary>
		public CampaignStep TargetStep {
			get {
				return _targetStep ??
					(_targetStep = LookupColumnEntities.GetEntity("TargetStep") as CampaignStep);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignStepRoute_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignStepRouteDeleted", e);
			Loaded += (s, e) => ThrowEvent("CampaignStepRouteLoaded", e);
			Saving += (s, e) => ThrowEvent("CampaignStepRouteSaving", e);
			Validating += (s, e) => ThrowEvent("CampaignStepRouteValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignStepRoute(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignStepRoute_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignStepRoute_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.DiagramElement_ProcessLibraryEventsProcess<TEntity> where TEntity : CampaignStepRoute
	{

		public CampaignStepRoute_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignStepRoute_CampaignsEventsProcess";
			SchemaUId = new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_supportedProperties = () => {{ return "offsetX,offsetY"; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6191b3fe-c2d9-4283-964b-cba62823bc40");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<string> _supportedProperties;
		public override string SupportedProperties {
			get {
				return (_supportedProperties ?? (_supportedProperties = () => null)).Invoke();
			}
			set {
				_supportedProperties = () => { return value; };
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

	#region Class: CampaignStepRoute_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignStepRoute_CampaignsEventsProcess : CampaignStepRoute_CampaignsEventsProcess<CampaignStepRoute>
	{

		public CampaignStepRoute_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignStepRoute_CampaignsEventsProcess

	public partial class CampaignStepRoute_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignStepRouteEventsProcess

	/// <exclude/>
	public class CampaignStepRouteEventsProcess : CampaignStepRoute_CampaignsEventsProcess
	{

		public CampaignStepRouteEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

