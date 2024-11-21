namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: OpportunityFile_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityFile_Opportunity_BPMSoftSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public OpportunityFile_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityFile_Opportunity_BPMSoftSchema(OpportunityFile_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityFile_Opportunity_BPMSoftSchema(OpportunityFile_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
			RealUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
			Name = "OpportunityFile_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5e3c0aab-bd70-4f36-bf97-aea890d392a3")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5e3c0aab-bd70-4f36-bf97-aea890d392a3"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b"),
				ModifiedInSchemaUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityFile_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityFile_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityFile_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityFile_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4135a9ba-5936-438f-9795-40fbc090c07b"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFile_Opportunity_BPMSoft

	/// <summary>
	/// Файл и ссылка продажи.
	/// </summary>
	public class OpportunityFile_Opportunity_BPMSoft : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public OpportunityFile_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityFile_Opportunity_BPMSoft";
		}

		public OpportunityFile_Opportunity_BPMSoft(OpportunityFile_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityFile_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityFile_Opportunity_BPMSoftDeleted", e);
			Updated += (s, e) => ThrowEvent("OpportunityFile_Opportunity_BPMSoftUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityFile_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFile_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityFile_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : OpportunityFile_Opportunity_BPMSoft
	{

		public OpportunityFile_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityFile_OpportunityEventsProcess";
			SchemaUId = new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4135a9ba-5936-438f-9795-40fbc090c07b");
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

	#region Class: OpportunityFile_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityFile_OpportunityEventsProcess : OpportunityFile_OpportunityEventsProcess<OpportunityFile_Opportunity_BPMSoft>
	{

		public OpportunityFile_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityFile_OpportunityEventsProcess

	public partial class OpportunityFile_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void OnFileSaved() {
			base.OnFileSaved();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				var url = Entity.GetTypedColumnValue<string>("Name").Trim();
				if (IsURLValid(url)) {
					LinkPreview linkPreview = new LinkPreview();
					LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
					if (linkPreviewInfo != null) {
						LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
						linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
					}
				}
			}
		}

		public override void OnFileDeleted() {
			base.OnFileDeleted();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public override void OnFileUpdated() {
			base.OnFileUpdated();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			string oldUrl = (string)Entity.GetColumnOldValue("Name");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId && IsURLValid(oldUrl)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion

}

