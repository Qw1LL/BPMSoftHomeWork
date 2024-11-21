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

	#region Class: OpportunityCompetitor_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityCompetitor_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityCompetitor_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityCompetitor_Opportunity_BPMSoftSchema(OpportunityCompetitor_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityCompetitor_Opportunity_BPMSoftSchema(OpportunityCompetitor_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("60631073-00cf-469f-b99b-8078eceb345b");
			RealUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b");
			Name = "OpportunityCompetitor_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a7997ccf-7474-4456-9f66-8119ce1211bf")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("c296bd96-22a5-4cb0-95bc-66ff808055b4")) == null) {
				Columns.Add(CreateCompetitorColumn());
			}
			if (Columns.FindByUId(new Guid("2f2dc07f-85f0-49e3-8351-60af95139874")) == null) {
				Columns.Add(CreateWeaknessColumn());
			}
			if (Columns.FindByUId(new Guid("51284b53-a6f6-457f-bb2f-31232cfc57e3")) == null) {
				Columns.Add(CreateStrengthsColumn());
			}
			if (Columns.FindByUId(new Guid("a3d6b036-d259-4040-9634-0cce1f08e686")) == null) {
				Columns.Add(CreateCompetitorProductColumn());
			}
			if (Columns.FindByUId(new Guid("110996ff-1738-44b8-b18d-a69e1f1f44f8")) == null) {
				Columns.Add(CreateCompetitorAmountColumn());
			}
			if (Columns.FindByUId(new Guid("de694946-ec43-48ac-ab5e-10a9c6ac2a27")) == null) {
				Columns.Add(CreateIsWinnerColumn());
			}
			if (Columns.FindByUId(new Guid("29c447b1-0a38-4d4b-ba03-746c05526659")) == null) {
				Columns.Add(CreateSupplierColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a7997ccf-7474-4456-9f66-8119ce1211bf"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCompetitorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c296bd96-22a5-4cb0-95bc-66ff808055b4"),
				Name = @"Competitor",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateWeaknessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2f2dc07f-85f0-49e3-8351-60af95139874"),
				Name = @"Weakness",
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStrengthsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("51284b53-a6f6-457f-bb2f-31232cfc57e3"),
				Name = @"Strengths",
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCompetitorProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a3d6b036-d259-4040-9634-0cce1f08e686"),
				Name = @"CompetitorProduct",
				ReferenceSchemaUId = new Guid("a90cf5af-917c-4b33-8eee-832906dbe6d5"),
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCompetitorAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("110996ff-1738-44b8-b18d-a69e1f1f44f8"),
				Name = @"CompetitorAmount",
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected virtual EntitySchemaColumn CreateIsWinnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("de694946-ec43-48ac-ab5e-10a9c6ac2a27"),
				Name = @"IsWinner",
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("00444c93-d7ec-4107-babc-79df871f5d21")
			};
		}

		protected virtual EntitySchemaColumn CreateSupplierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("29c447b1-0a38-4d4b-ba03-746c05526659"),
				Name = @"Supplier",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				ModifiedInSchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b"),
				CreatedInPackageId = new Guid("d5fd37cc-1f9c-4f35-91fb-f2d079cb26f9")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityCompetitor_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityCompetitor_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityCompetitor_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityCompetitor_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("60631073-00cf-469f-b99b-8078eceb345b"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCompetitor_Opportunity_BPMSoft

	/// <summary>
	/// Конкурент в продаже.
	/// </summary>
	public class OpportunityCompetitor_Opportunity_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityCompetitor_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityCompetitor_Opportunity_BPMSoft";
		}

		public OpportunityCompetitor_Opportunity_BPMSoft(OpportunityCompetitor_Opportunity_BPMSoft source)
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

		/// <exclude/>
		public Guid CompetitorId {
			get {
				return GetTypedColumnValue<Guid>("CompetitorId");
			}
			set {
				SetColumnValue("CompetitorId", value);
				_competitor = null;
			}
		}

		/// <exclude/>
		public string CompetitorName {
			get {
				return GetTypedColumnValue<string>("CompetitorName");
			}
			set {
				SetColumnValue("CompetitorName", value);
				if (_competitor != null) {
					_competitor.Name = value;
				}
			}
		}

		private Account _competitor;
		/// <summary>
		/// Производитель.
		/// </summary>
		public Account Competitor {
			get {
				return _competitor ??
					(_competitor = LookupColumnEntities.GetEntity("Competitor") as Account);
			}
		}

		/// <summary>
		/// Слабые стороны.
		/// </summary>
		public string Weakness {
			get {
				return GetTypedColumnValue<string>("Weakness");
			}
			set {
				SetColumnValue("Weakness", value);
			}
		}

		/// <summary>
		/// Сильные стороны.
		/// </summary>
		public string Strengths {
			get {
				return GetTypedColumnValue<string>("Strengths");
			}
			set {
				SetColumnValue("Strengths", value);
			}
		}

		/// <exclude/>
		public Guid CompetitorProductId {
			get {
				return GetTypedColumnValue<Guid>("CompetitorProductId");
			}
			set {
				SetColumnValue("CompetitorProductId", value);
				_competitorProduct = null;
			}
		}

		/// <exclude/>
		public string CompetitorProductName {
			get {
				return GetTypedColumnValue<string>("CompetitorProductName");
			}
			set {
				SetColumnValue("CompetitorProductName", value);
				if (_competitorProduct != null) {
					_competitorProduct.Name = value;
				}
			}
		}

		private CompetitorProduct _competitorProduct;
		/// <summary>
		/// Продукт конкурента.
		/// </summary>
		public CompetitorProduct CompetitorProduct {
			get {
				return _competitorProduct ??
					(_competitorProduct = LookupColumnEntities.GetEntity("CompetitorProduct") as CompetitorProduct);
			}
		}

		/// <summary>
		/// Сумма предложения.
		/// </summary>
		public Decimal CompetitorAmount {
			get {
				return GetTypedColumnValue<Decimal>("CompetitorAmount");
			}
			set {
				SetColumnValue("CompetitorAmount", value);
			}
		}

		/// <summary>
		/// Победитель.
		/// </summary>
		public bool IsWinner {
			get {
				return GetTypedColumnValue<bool>("IsWinner");
			}
			set {
				SetColumnValue("IsWinner", value);
			}
		}

		/// <exclude/>
		public Guid SupplierId {
			get {
				return GetTypedColumnValue<Guid>("SupplierId");
			}
			set {
				SetColumnValue("SupplierId", value);
				_supplier = null;
			}
		}

		/// <exclude/>
		public string SupplierName {
			get {
				return GetTypedColumnValue<string>("SupplierName");
			}
			set {
				SetColumnValue("SupplierName", value);
				if (_supplier != null) {
					_supplier.Name = value;
				}
			}
		}

		private Account _supplier;
		/// <summary>
		/// Поставщик.
		/// </summary>
		public Account Supplier {
			get {
				return _supplier ??
					(_supplier = LookupColumnEntities.GetEntity("Supplier") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityCompetitor_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityCompetitor_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityCompetitor_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityCompetitor_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityCompetitor_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityCompetitor_Opportunity_BPMSoft
	{

		public OpportunityCompetitor_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityCompetitor_OpportunityEventsProcess";
			SchemaUId = new Guid("60631073-00cf-469f-b99b-8078eceb345b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("60631073-00cf-469f-b99b-8078eceb345b");
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

	#region Class: OpportunityCompetitor_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityCompetitor_OpportunityEventsProcess : OpportunityCompetitor_OpportunityEventsProcess<OpportunityCompetitor_Opportunity_BPMSoft>
	{

		public OpportunityCompetitor_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityCompetitor_OpportunityEventsProcess

	public partial class OpportunityCompetitor_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

