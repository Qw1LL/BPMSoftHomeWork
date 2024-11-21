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

	#region Class: AccountAnnualRevenueSchema

	/// <exclude/>
	public class AccountAnnualRevenueSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public AccountAnnualRevenueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountAnnualRevenueSchema(AccountAnnualRevenueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountAnnualRevenueSchema(AccountAnnualRevenueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9");
			RealUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9");
			Name = "AccountAnnualRevenue";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateFromBaseCurrencyColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("94a2ebc5-c110-4929-94b4-baaafee43d7d")) == null) {
				Columns.Add(CreateToBaseCurrencyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateFromBaseCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("633ed4cd-fe02-423a-a4d4-062cae2a2ec4"),
				Name = @"FromBaseCurrency",
				CreatedInSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				ModifiedInSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateToBaseCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("94a2ebc5-c110-4929-94b4-baaafee43d7d"),
				Name = @"ToBaseCurrency",
				CreatedInSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				ModifiedInSchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountAnnualRevenue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountAnnualRevenue_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountAnnualRevenueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountAnnualRevenueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountAnnualRevenue

	/// <summary>
	/// Annual revenue of account.
	/// </summary>
	public class AccountAnnualRevenue : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public AccountAnnualRevenue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountAnnualRevenue";
		}

		public AccountAnnualRevenue(AccountAnnualRevenue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// From, base currency.
		/// </summary>
		public int FromBaseCurrency {
			get {
				return GetTypedColumnValue<int>("FromBaseCurrency");
			}
			set {
				SetColumnValue("FromBaseCurrency", value);
			}
		}

		/// <summary>
		/// To, base currency.
		/// </summary>
		public int ToBaseCurrency {
			get {
				return GetTypedColumnValue<int>("ToBaseCurrency");
			}
			set {
				SetColumnValue("ToBaseCurrency", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountAnnualRevenue_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountAnnualRevenueDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountAnnualRevenueDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountAnnualRevenueInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountAnnualRevenueInserting", e);
			Saved += (s, e) => ThrowEvent("AccountAnnualRevenueSaved", e);
			Saving += (s, e) => ThrowEvent("AccountAnnualRevenueSaving", e);
			Validating += (s, e) => ThrowEvent("AccountAnnualRevenueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountAnnualRevenue(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAnnualRevenue_BaseEventsProcess

	/// <exclude/>
	public partial class AccountAnnualRevenue_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : AccountAnnualRevenue
	{

		public AccountAnnualRevenue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountAnnualRevenue_BaseEventsProcess";
			SchemaUId = new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("24d201f8-5f03-47f3-9e7b-1c967c11d7b9");
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

	#region Class: AccountAnnualRevenue_BaseEventsProcess

	/// <exclude/>
	public class AccountAnnualRevenue_BaseEventsProcess : AccountAnnualRevenue_BaseEventsProcess<AccountAnnualRevenue>
	{

		public AccountAnnualRevenue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountAnnualRevenue_BaseEventsProcess

	public partial class AccountAnnualRevenue_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountAnnualRevenueEventsProcess

	/// <exclude/>
	public class AccountAnnualRevenueEventsProcess : AccountAnnualRevenue_BaseEventsProcess
	{

		public AccountAnnualRevenueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

