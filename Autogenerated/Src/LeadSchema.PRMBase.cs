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

	#region Class: Lead_PRMBase_BPMSoftSchema

	/// <exclude/>
	public class Lead_PRMBase_BPMSoftSchema : BPMSoft.Configuration.Lead_CoreLeadOpportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_PRMBase_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_PRMBase_BPMSoftSchema(Lead_PRMBase_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_PRMBase_BPMSoftSchema(Lead_PRMBase_BPMSoftSchema source)
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
			RealUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406");
			Name = "Lead_PRMBase_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("de8ae9a8-a9a7-4323-ba50-b61a787183b3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("693f56bf-b9bb-4f39-bca2-1b307f60cca5")) == null) {
				Columns.Add(CreatePartnerColumn());
			}
			if (Columns.FindByUId(new Guid("becf8a84-8327-4864-97d3-209b2a7dc67e")) == null) {
				Columns.Add(CreatePartnerOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("215eb46b-7973-42c0-bb8f-8b011a8fbd67")) == null) {
				Columns.Add(CreatePartnerTypeColumn());
			}
			if (Columns.FindByUId(new Guid("33cf5522-8fdc-4d80-ae7a-07c96cefebca")) == null) {
				Columns.Add(CreateSalesChannelColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePartnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("693f56bf-b9bb-4f39-bca2-1b307f60cca5"),
				Name = @"Partner",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				ModifiedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				CreatedInPackageId = new Guid("de8ae9a8-a9a7-4323-ba50-b61a787183b3")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("becf8a84-8327-4864-97d3-209b2a7dc67e"),
				Name = @"PartnerOwner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				ModifiedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				CreatedInPackageId = new Guid("de8ae9a8-a9a7-4323-ba50-b61a787183b3")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnerTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("215eb46b-7973-42c0-bb8f-8b011a8fbd67"),
				Name = @"PartnerType",
				ReferenceSchemaUId = new Guid("43cadf79-8d33-4697-8344-ec24fa905332"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				ModifiedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				CreatedInPackageId = new Guid("c753c9c2-3fc1-46be-9c9c-b15f50a19487")
			};
		}

		protected virtual EntitySchemaColumn CreateSalesChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("33cf5522-8fdc-4d80-ae7a-07c96cefebca"),
				Name = @"SalesChannel",
				ReferenceSchemaUId = new Guid("85fe0df7-a970-4717-8f7b-8caba783906b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				ModifiedInSchemaUId = new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"),
				CreatedInPackageId = new Guid("ee0be05f-9653-462f-890a-39e216314520"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"3c3865f2-ada4-480c-ac91-e2d39c5bbaf9"
				}
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
			return new Lead_PRMBase_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_PRMBase_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_PRMBase_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_PRMBase_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_PRMBase_BPMSoft : BPMSoft.Configuration.Lead_CoreLeadOpportunity_BPMSoft
	{

		#region Constructors: Public

		public Lead_PRMBase_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_PRMBase_BPMSoft";
		}

		public Lead_PRMBase_BPMSoft(Lead_PRMBase_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = LookupColumnEntities.GetEntity("Partner") as Account);
			}
		}

		/// <exclude/>
		public Guid PartnerOwnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerOwnerId");
			}
			set {
				SetColumnValue("PartnerOwnerId", value);
				_partnerOwner = null;
			}
		}

		/// <exclude/>
		public string PartnerOwnerName {
			get {
				return GetTypedColumnValue<string>("PartnerOwnerName");
			}
			set {
				SetColumnValue("PartnerOwnerName", value);
				if (_partnerOwner != null) {
					_partnerOwner.Name = value;
				}
			}
		}

		private Contact _partnerOwner;
		/// <summary>
		/// Ответственный партнера за сделку.
		/// </summary>
		public Contact PartnerOwner {
			get {
				return _partnerOwner ??
					(_partnerOwner = LookupColumnEntities.GetEntity("PartnerOwner") as Contact);
			}
		}

		/// <exclude/>
		public Guid PartnerTypeId {
			get {
				return GetTypedColumnValue<Guid>("PartnerTypeId");
			}
			set {
				SetColumnValue("PartnerTypeId", value);
				_partnerType = null;
			}
		}

		/// <exclude/>
		public string PartnerTypeName {
			get {
				return GetTypedColumnValue<string>("PartnerTypeName");
			}
			set {
				SetColumnValue("PartnerTypeName", value);
				if (_partnerType != null) {
					_partnerType.Name = value;
				}
			}
		}

		private PartnerType _partnerType;
		/// <summary>
		/// Тип партнера.
		/// </summary>
		public PartnerType PartnerType {
			get {
				return _partnerType ??
					(_partnerType = LookupColumnEntities.GetEntity("PartnerType") as PartnerType);
			}
		}

		/// <exclude/>
		public Guid SalesChannelId {
			get {
				return GetTypedColumnValue<Guid>("SalesChannelId");
			}
			set {
				SetColumnValue("SalesChannelId", value);
				_salesChannel = null;
			}
		}

		/// <exclude/>
		public string SalesChannelName {
			get {
				return GetTypedColumnValue<string>("SalesChannelName");
			}
			set {
				SetColumnValue("SalesChannelName", value);
				if (_salesChannel != null) {
					_salesChannel.Name = value;
				}
			}
		}

		private OpportunityType _salesChannel;
		/// <summary>
		/// Канал продажи.
		/// </summary>
		public OpportunityType SalesChannel {
			get {
				return _salesChannel ??
					(_salesChannel = LookupColumnEntities.GetEntity("SalesChannel") as OpportunityType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Lead_PRMBase_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lead_PRMBase_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_PRMBaseEventsProcess

	/// <exclude/>
	public partial class Lead_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.Lead_CoreLeadOpportunityEventsProcess<TEntity> where TEntity : Lead_PRMBase_BPMSoft
	{

		public Lead_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_PRMBaseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("55020fdb-b605-40c2-ac32-4aa3e46c5406");
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

	#region Class: Lead_PRMBaseEventsProcess

	/// <exclude/>
	public class Lead_PRMBaseEventsProcess : Lead_PRMBaseEventsProcess<Lead_PRMBase_BPMSoft>
	{

		public Lead_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

