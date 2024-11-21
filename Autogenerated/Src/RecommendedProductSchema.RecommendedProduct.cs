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

	#region Class: RecommendedProductSchema

	/// <exclude/>
	public class RecommendedProductSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public RecommendedProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RecommendedProductSchema(RecommendedProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RecommendedProductSchema(RecommendedProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27768536-c14c-423d-be05-70844e74352a");
			RealUId = new Guid("27768536-c14c-423d-be05-70844e74352a");
			Name = "RecommendedProduct";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b8cdb8d8-1452-4fcd-b717-01f61c1a9dd9")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("94319fc6-2693-4dc3-8439-3ed106391f54")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("5ba2e2ac-e10e-4598-bd50-70a8781ed9cf")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("4e5136b3-7e47-4996-9823-4a62cec63502")) == null) {
				Columns.Add(CreateScoreColumn());
			}
			if (Columns.FindByUId(new Guid("9122c65c-385e-4203-9dd3-c856c23ccc3e")) == null) {
				Columns.Add(CreateMLModelColumn());
			}
			if (Columns.FindByUId(new Guid("76e07203-5faf-43b1-882a-bbb03b04a186")) == null) {
				Columns.Add(CreatePredictionDateColumn());
			}
			if (Columns.FindByUId(new Guid("b7930881-5ad9-54c6-fc99-952d782c8a9f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("1d06990a-80c4-cb76-47be-08cf92cf12ca")) == null) {
				Columns.Add(CreateResultDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b8cdb8d8-1452-4fcd-b717-01f61c1a9dd9"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("94319fc6-2693-4dc3-8439-3ed106391f54"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5ba2e2ac-e10e-4598-bd50-70a8781ed9cf"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreateScoreColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("4e5136b3-7e47-4996-9823-4a62cec63502"),
				Name = @"Score",
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreateMLModelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9122c65c-385e-4203-9dd3-c856c23ccc3e"),
				Name = @"MLModel",
				ReferenceSchemaUId = new Guid("f0d58f4a-303d-477c-8cf9-d00eaf04f32b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreatePredictionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("76e07203-5faf-43b1-882a-bbb03b04a186"),
				Name = @"PredictionDate",
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("3ebd15ee-8e75-421b-9a5c-0671b1bbeef2")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b7930881-5ad9-54c6-fc99-952d782c8a9f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("51c10720-9723-446f-b9da-c6b2278536f0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("71f4d1a5-c473-436e-a8c5-51ffc5f2dc8e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"86946840-7b2c-4be0-892c-5a51fc8c9970"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateResultDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1d06990a-80c4-cb76-47be-08cf92cf12ca"),
				Name = @"ResultDescription",
				CreatedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				ModifiedInSchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a"),
				CreatedInPackageId = new Guid("daf2b27f-f7d0-455f-ad83-ba91c45815fb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RecommendedProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RecommendedProduct_RecommendedProductEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RecommendedProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RecommendedProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27768536-c14c-423d-be05-70844e74352a"));
		}

		#endregion

	}

	#endregion

	#region Class: RecommendedProduct

	/// <summary>
	/// Рекомендации продуктов.
	/// </summary>
	public class RecommendedProduct : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public RecommendedProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RecommendedProduct";
		}

		public RecommendedProduct(RecommendedProduct source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <summary>
		/// Балл рекомендации.
		/// </summary>
		public Decimal Score {
			get {
				return GetTypedColumnValue<Decimal>("Score");
			}
			set {
				SetColumnValue("Score", value);
			}
		}

		/// <exclude/>
		public Guid MLModelId {
			get {
				return GetTypedColumnValue<Guid>("MLModelId");
			}
			set {
				SetColumnValue("MLModelId", value);
				_mLModel = null;
			}
		}

		/// <exclude/>
		public string MLModelName {
			get {
				return GetTypedColumnValue<string>("MLModelName");
			}
			set {
				SetColumnValue("MLModelName", value);
				if (_mLModel != null) {
					_mLModel.Name = value;
				}
			}
		}

		private MLModel _mLModel;
		/// <summary>
		/// Рекомендационная модель.
		/// </summary>
		public MLModel MLModel {
			get {
				return _mLModel ??
					(_mLModel = LookupColumnEntities.GetEntity("MLModel") as MLModel);
			}
		}

		/// <summary>
		/// Дата прогноза.
		/// </summary>
		public DateTime PredictionDate {
			get {
				return GetTypedColumnValue<DateTime>("PredictionDate");
			}
			set {
				SetColumnValue("PredictionDate", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private RecommendProductStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public RecommendProductStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as RecommendProductStatus);
			}
		}

		/// <summary>
		/// Описание результата.
		/// </summary>
		public string ResultDescription {
			get {
				return GetTypedColumnValue<string>("ResultDescription");
			}
			set {
				SetColumnValue("ResultDescription", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RecommendedProduct_RecommendedProductEventsProcess(UserConnection);
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
			return new RecommendedProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: RecommendedProduct_RecommendedProductEventsProcess

	/// <exclude/>
	public partial class RecommendedProduct_RecommendedProductEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : RecommendedProduct
	{

		public RecommendedProduct_RecommendedProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RecommendedProduct_RecommendedProductEventsProcess";
			SchemaUId = new Guid("27768536-c14c-423d-be05-70844e74352a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("27768536-c14c-423d-be05-70844e74352a");
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

	#region Class: RecommendedProduct_RecommendedProductEventsProcess

	/// <exclude/>
	public class RecommendedProduct_RecommendedProductEventsProcess : RecommendedProduct_RecommendedProductEventsProcess<RecommendedProduct>
	{

		public RecommendedProduct_RecommendedProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RecommendedProduct_RecommendedProductEventsProcess

	public partial class RecommendedProduct_RecommendedProductEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RecommendedProductEventsProcess

	/// <exclude/>
	public class RecommendedProductEventsProcess : RecommendedProduct_RecommendedProductEventsProcess
	{

		public RecommendedProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

