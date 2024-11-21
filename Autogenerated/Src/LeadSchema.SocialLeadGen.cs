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

	#region Class: Lead_SocialLeadGen_BPMSoftSchema

	/// <exclude/>
	public class Lead_SocialLeadGen_BPMSoftSchema : BPMSoft.Configuration.Lead_PRMPortal_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_SocialLeadGen_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_SocialLeadGen_BPMSoftSchema(Lead_SocialLeadGen_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_SocialLeadGen_BPMSoftSchema(Lead_SocialLeadGen_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_LeadNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3f62f3-5d38-4031-a648-58b036f8f19d");
			index.Name = "IDX_LeadName";
			index.CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			EntitySchemaIndexColumn leadNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2c3ed9bd-ff44-447d-b4af-c6a4e4090a5a"),
				ColumnUId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leadNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700");
			Name = "Lead_SocialLeadGen_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a6468ddc-9b5d-4416-4e74-06965d13566b")) == null) {
				Columns.Add(CreateLeadGenExtendedLeadInfoColumn());
			}
			if (Columns.FindByUId(new Guid("f7875c95-5490-e1f3-b1de-68c7f9cef845")) == null) {
				Columns.Add(CreateSocialMetadataColumn());
			}
		}

		protected override EntitySchemaColumn CreateLeadTypeStatusColumn() {
			EntitySchemaColumn column = base.CreateLeadTypeStatusColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"5b3d1046-fc16-45c8-a5a1-298dfc857546"
			};
			column.ModifiedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700");
			return column;
		}

		protected override EntitySchemaColumn CreateQualifyStatusColumn() {
			EntitySchemaColumn column = base.CreateQualifyStatusColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"d790a45d-03ff-4ddb-9dea-8087722c582c"
			};
			column.ModifiedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700");
			return column;
		}

		protected override EntitySchemaColumn CreateRegisterMethodColumn() {
			EntitySchemaColumn column = base.CreateRegisterMethodColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"240ab9c6-4d7c-4688-b380-af44dd147d7a"
			};
			column.ModifiedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700");
			return column;
		}

		protected virtual EntitySchemaColumn CreateLeadGenExtendedLeadInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a6468ddc-9b5d-4416-4e74-06965d13566b"),
				Name = @"LeadGenExtendedLeadInfo",
				ReferenceSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700"),
				ModifiedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMetadataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f7875c95-5490-e1f3-b1de-68c7f9cef845"),
				Name = @"SocialMetadata",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700"),
				ModifiedInSchemaUId = new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_LeadNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Lead_SocialLeadGen_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_SocialLeadGen_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_SocialLeadGen_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_SocialLeadGen_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_SocialLeadGen_BPMSoft : BPMSoft.Configuration.Lead_PRMPortal_BPMSoft
	{

		#region Constructors: Public

		public Lead_SocialLeadGen_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_SocialLeadGen_BPMSoft";
		}

		public Lead_SocialLeadGen_BPMSoft(Lead_SocialLeadGen_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadGenExtendedLeadInfoId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenExtendedLeadInfoId");
			}
			set {
				SetColumnValue("LeadGenExtendedLeadInfoId", value);
				_leadGenExtendedLeadInfo = null;
			}
		}

		private LeadGenExtendedLeadInformation _leadGenExtendedLeadInfo;
		/// <summary>
		/// Расширенная информация о лиде.
		/// </summary>
		public LeadGenExtendedLeadInformation LeadGenExtendedLeadInfo {
			get {
				return _leadGenExtendedLeadInfo ??
					(_leadGenExtendedLeadInfo = LookupColumnEntities.GetEntity("LeadGenExtendedLeadInfo") as LeadGenExtendedLeadInformation);
			}
		}

		/// <summary>
		/// Социальные метаданные.
		/// </summary>
		public string SocialMetadata {
			get {
				return GetTypedColumnValue<string>("SocialMetadata");
			}
			set {
				SetColumnValue("SocialMetadata", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_SocialLeadGenEventsProcess(UserConnection);
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
			return new Lead_SocialLeadGen_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class Lead_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.Lead_PRMPortalEventsProcess<TEntity> where TEntity : Lead_SocialLeadGen_BPMSoft
	{

		public Lead_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_SocialLeadGenEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7e8cb16-15e2-b2ad-bfdc-208093ffd700");
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

	#region Class: Lead_SocialLeadGenEventsProcess

	/// <exclude/>
	public class Lead_SocialLeadGenEventsProcess : Lead_SocialLeadGenEventsProcess<Lead_SocialLeadGen_BPMSoft>
	{

		public Lead_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Lead_SocialLeadGenEventsProcess

	public partial class Lead_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

