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

	#region Class: AccountSchema

	/// <exclude/>
	public class AccountSchema : BPMSoft.Configuration.Account_SSP_BPMSoftSchema
	{

		#region Constructors: Public

		public AccountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountSchema(AccountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountSchema(AccountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("8c66b865-7ff1-489f-9224-abf8776f841f");
			Name = "Account";
			ParentSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d4cfcde0-bd2a-4719-a4df-63ed38689467");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fa768c13-2032-4055-9f11-4f0607f993b3")) == null) {
				Columns.Add(CreatePriceListColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePriceListColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fa768c13-2032-4055-9f11-4f0607f993b3"),
				Name = @"PriceList",
				ReferenceSchemaUId = new Guid("036f6f5b-838d-4187-9749-b54c8539c076"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8c66b865-7ff1-489f-9224-abf8776f841f"),
				ModifiedInSchemaUId = new Guid("8c66b865-7ff1-489f-9224-abf8776f841f"),
				CreatedInPackageId = new Guid("83aec5f3-91bc-4b2e-a086-2456f94ef5bb")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Account(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Account_ProductCatalogueEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8c66b865-7ff1-489f-9224-abf8776f841f"));
		}

		#endregion

	}

	#endregion

	#region Class: Account

	/// <summary>
	/// Контрагент.
	/// </summary>
	public class Account : BPMSoft.Configuration.Account_SSP_BPMSoft
	{

		#region Constructors: Public

		public Account(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Account";
		}

		public Account(Account source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid PriceListId {
			get {
				return GetTypedColumnValue<Guid>("PriceListId");
			}
			set {
				SetColumnValue("PriceListId", value);
				_priceList = null;
			}
		}

		/// <exclude/>
		public string PriceListName {
			get {
				return GetTypedColumnValue<string>("PriceListName");
			}
			set {
				SetColumnValue("PriceListName", value);
				if (_priceList != null) {
					_priceList.Name = value;
				}
			}
		}

		private Pricelist _priceList;
		/// <summary>
		/// Прайс-лист.
		/// </summary>
		public Pricelist PriceList {
			get {
				return _priceList ??
					(_priceList = LookupColumnEntities.GetEntity("PriceList") as Pricelist);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Account_ProductCatalogueEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountDeleted", e);
			Inserting += (s, e) => ThrowEvent("AccountInserting", e);
			Saving += (s, e) => ThrowEvent("AccountSaving", e);
			Validating += (s, e) => ThrowEvent("AccountValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Account(this);
		}

		#endregion

	}

	#endregion

	#region Class: Account_ProductCatalogueEventsProcess

	/// <exclude/>
	public partial class Account_ProductCatalogueEventsProcess<TEntity> : BPMSoft.Configuration.Account_SSPEventsProcess<TEntity> where TEntity : Account
	{

		public Account_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Account_ProductCatalogueEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8c66b865-7ff1-489f-9224-abf8776f841f");
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

	#region Class: Account_ProductCatalogueEventsProcess

	/// <exclude/>
	public class Account_ProductCatalogueEventsProcess : Account_ProductCatalogueEventsProcess<Account>
	{

		public Account_ProductCatalogueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Account_ProductCatalogueEventsProcess

	public partial class Account_ProductCatalogueEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountEventsProcess

	/// <exclude/>
	public class AccountEventsProcess : Account_ProductCatalogueEventsProcess
	{

		public AccountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

