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

	#region Class: Lead_CoreLead_BPMSoftSchema

	/// <exclude/>
	public class Lead_CoreLead_BPMSoftSchema : BPMSoft.Configuration.Lead_MLLeadScoring_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_CoreLead_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_CoreLead_BPMSoftSchema(Lead_CoreLead_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_CoreLead_BPMSoftSchema(Lead_CoreLead_BPMSoftSchema source)
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
			RealUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b");
			Name = "Lead_CoreLead_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("bd9461a8-7d2e-4f51-8bb4-ed05869380df");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a40a64fa-a0ea-40e6-9476-a59c1dfbb93f")) == null) {
				Columns.Add(CreateOpportunityDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("7dc3ed3f-ce06-4a75-8d38-9e0badcece6e")) == null) {
				Columns.Add(CreateIdentificationPassedColumn());
			}
			if (Columns.FindByUId(new Guid("ad34e929-02a6-4baf-88b5-4efbf982c577")) == null) {
				Columns.Add(CreateStartLeadManagementProcessColumn());
			}
			if (Columns.FindByUId(new Guid("bca817e3-756d-4098-8804-859940310d68")) == null) {
				Columns.Add(CreateSaleTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7c4d10e3-5ace-4362-8b9c-73b858ba9fec")) == null) {
				Columns.Add(CreateScoreColumn());
			}
			if (Columns.FindByUId(new Guid("d46a1b66-17a7-4603-b1ce-49313701da31")) == null) {
				Columns.Add(CreateQualificationPassedColumn());
			}
		}

		protected override EntitySchemaColumn CreateStatusColumn() {
			EntitySchemaColumn column = base.CreateStatusColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b");
			column.CreatedInPackageId = new Guid("bd9461a8-7d2e-4f51-8bb4-ed05869380df");
			return column;
		}

		protected override EntitySchemaColumn CreateRemindToOwnerColumn() {
			EntitySchemaColumn column = base.CreateRemindToOwnerColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b");
			column.CreatedInPackageId = new Guid("bd9461a8-7d2e-4f51-8bb4-ed05869380df");
			return column;
		}

		protected virtual EntitySchemaColumn CreateOpportunityDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a40a64fa-a0ea-40e6-9476-a59c1dfbb93f"),
				Name = @"OpportunityDepartment",
				ReferenceSchemaUId = new Guid("5d8456b4-15e0-4de5-b0e5-afb10f6795c0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("bd9461a8-7d2e-4f51-8bb4-ed05869380df")
			};
		}

		protected virtual EntitySchemaColumn CreateIdentificationPassedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7dc3ed3f-ce06-4a75-8d38-9e0badcece6e"),
				Name = @"IdentificationPassed",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("04f45b48-2ba7-4a99-b9aa-9685581b63b8")
			};
		}

		protected virtual EntitySchemaColumn CreateStartLeadManagementProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ad34e929-02a6-4baf-88b5-4efbf982c577"),
				Name = @"StartLeadManagementProcess",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("72a81799-379a-47fd-98a2-863474ed2379"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSaleTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("bca817e3-756d-4098-8804-859940310d68"),
				Name = @"SaleType",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("00276668-9718-4e94-8d54-1a9582a96ad4")
			};
		}

		protected virtual EntitySchemaColumn CreateScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("7c4d10e3-5ace-4362-8b9c-73b858ba9fec"),
				Name = @"Score",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("4e68d131-e539-48a2-90eb-6b4a80171550")
			};
		}

		protected virtual EntitySchemaColumn CreateQualificationPassedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d46a1b66-17a7-4603-b1ce-49313701da31"),
				Name = @"QualificationPassed",
				CreatedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				ModifiedInSchemaUId = new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"),
				CreatedInPackageId = new Guid("720d23f3-8251-42b3-a7b6-da9abd6ef059")
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
			return new Lead_CoreLead_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_CoreLeadEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_CoreLead_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_CoreLead_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_CoreLead_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_CoreLead_BPMSoft : BPMSoft.Configuration.Lead_MLLeadScoring_BPMSoft
	{

		#region Constructors: Public

		public Lead_CoreLead_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_CoreLead_BPMSoft";
		}

		public Lead_CoreLead_BPMSoft(Lead_CoreLead_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityDepartmentId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityDepartmentId");
			}
			set {
				SetColumnValue("OpportunityDepartmentId", value);
				_opportunityDepartment = null;
			}
		}

		/// <exclude/>
		public string OpportunityDepartmentName {
			get {
				return GetTypedColumnValue<string>("OpportunityDepartmentName");
			}
			set {
				SetColumnValue("OpportunityDepartmentName", value);
				if (_opportunityDepartment != null) {
					_opportunityDepartment.Name = value;
				}
			}
		}

		private OpportunityDepartment _opportunityDepartment;
		/// <summary>
		/// Направление продажи.
		/// </summary>
		public OpportunityDepartment OpportunityDepartment {
			get {
				return _opportunityDepartment ??
					(_opportunityDepartment = LookupColumnEntities.GetEntity("OpportunityDepartment") as OpportunityDepartment);
			}
		}

		/// <summary>
		/// Идентификация пройдена.
		/// </summary>
		public bool IdentificationPassed {
			get {
				return GetTypedColumnValue<bool>("IdentificationPassed");
			}
			set {
				SetColumnValue("IdentificationPassed", value);
			}
		}

		/// <summary>
		/// Запускать процесс при создании лида.
		/// </summary>
		public bool StartLeadManagementProcess {
			get {
				return GetTypedColumnValue<bool>("StartLeadManagementProcess");
			}
			set {
				SetColumnValue("StartLeadManagementProcess", value);
			}
		}

		/// <summary>
		/// Тип продажи.
		/// </summary>
		public string SaleType {
			get {
				return GetTypedColumnValue<string>("SaleType");
			}
			set {
				SetColumnValue("SaleType", value);
			}
		}

		/// <summary>
		/// Рейтинг.
		/// </summary>
		public Decimal Score {
			get {
				return GetTypedColumnValue<Decimal>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <summary>
		/// Квалификация пройдена.
		/// </summary>
		public bool QualificationPassed {
			get {
				return GetTypedColumnValue<bool>("QualificationPassed");
			}
			set {
				SetColumnValue("QualificationPassed", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Lead_CoreLeadEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Lead_CoreLead_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lead_CoreLead_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_CoreLeadEventsProcess

	/// <exclude/>
	public partial class Lead_CoreLeadEventsProcess<TEntity> : BPMSoft.Configuration.Lead_MLLeadScoringEventsProcess<TEntity> where TEntity : Lead_CoreLead_BPMSoft
	{

		public Lead_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_CoreLeadEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("94590c6d-2e61-422b-ab3b-033c95aa663b");
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

	#region Class: Lead_CoreLeadEventsProcess

	/// <exclude/>
	public class Lead_CoreLeadEventsProcess : Lead_CoreLeadEventsProcess<Lead_CoreLead_BPMSoft>
	{

		public Lead_CoreLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

