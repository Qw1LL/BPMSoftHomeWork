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

	#region Class: CampaignElementTemplateSchema

	/// <exclude/>
	public class CampaignElementTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignElementTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignElementTemplateSchema(CampaignElementTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignElementTemplateSchema(CampaignElementTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50");
			RealUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50");
			Name = "CampaignElementTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("119e3feb-c272-4d8b-b291-c4ee68498e16");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("79c0a762-f36b-1114-08e3-0aa1b01418ac")) == null) {
				Columns.Add(CreateElementConfigColumn());
			}
			if (Columns.FindByUId(new Guid("04bcf9f8-3867-ba1e-5cfb-e01e543bb70e")) == null) {
				Columns.Add(CreateElementTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateElementConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("79c0a762-f36b-1114-08e3-0aa1b01418ac"),
				Name = @"ElementConfig",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				ModifiedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				CreatedInPackageId = new Guid("119e3feb-c272-4d8b-b291-c4ee68498e16")
			};
		}

		protected virtual EntitySchemaColumn CreateElementTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("04bcf9f8-3867-ba1e-5cfb-e01e543bb70e"),
				Name = @"ElementType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				ModifiedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				CreatedInPackageId = new Guid("119e3feb-c272-4d8b-b291-c4ee68498e16")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ed72cec8-22bc-f734-2607-d752e660f65c"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				ModifiedInSchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"),
				CreatedInPackageId = new Guid("119e3feb-c272-4d8b-b291-c4ee68498e16")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignElementTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignElementTemplate_CampaignDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignElementTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignElementTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignElementTemplate

	/// <summary>
	/// Шаблон элемента кампании.
	/// </summary>
	public class CampaignElementTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignElementTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignElementTemplate";
		}

		public CampaignElementTemplate(CampaignElementTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конфиг элемента.
		/// </summary>
		public string ElementConfig {
			get {
				return GetTypedColumnValue<string>("ElementConfig");
			}
			set {
				SetColumnValue("ElementConfig", value);
			}
		}

		/// <summary>
		/// Тип элемента.
		/// </summary>
		public string ElementType {
			get {
				return GetTypedColumnValue<string>("ElementType");
			}
			set {
				SetColumnValue("ElementType", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignElementTemplate_CampaignDesignerEventsProcess(UserConnection);
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
			return new CampaignElementTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignElementTemplate_CampaignDesignerEventsProcess

	/// <exclude/>
	public partial class CampaignElementTemplate_CampaignDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignElementTemplate
	{

		public CampaignElementTemplate_CampaignDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignElementTemplate_CampaignDesignerEventsProcess";
			SchemaUId = new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("867c8f46-64ec-4233-99b7-b6d185d66c50");
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

	#region Class: CampaignElementTemplate_CampaignDesignerEventsProcess

	/// <exclude/>
	public class CampaignElementTemplate_CampaignDesignerEventsProcess : CampaignElementTemplate_CampaignDesignerEventsProcess<CampaignElementTemplate>
	{

		public CampaignElementTemplate_CampaignDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignElementTemplate_CampaignDesignerEventsProcess

	public partial class CampaignElementTemplate_CampaignDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignElementTemplateEventsProcess

	/// <exclude/>
	public class CampaignElementTemplateEventsProcess : CampaignElementTemplate_CampaignDesignerEventsProcess
	{

		public CampaignElementTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

