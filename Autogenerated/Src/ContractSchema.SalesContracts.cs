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

	#region Class: Contract_SalesContracts_BPMSoftSchema

	/// <exclude/>
	public class Contract_SalesContracts_BPMSoftSchema : BPMSoft.Configuration.Contract_CoreContracts_BPMSoftSchema
	{

		#region Constructors: Public

		public Contract_SalesContracts_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Contract_SalesContracts_BPMSoftSchema(Contract_SalesContracts_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Contract_SalesContracts_BPMSoftSchema(Contract_SalesContracts_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1");
			Name = "Contract_SalesContracts_BPMSoft";
			ParentSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810");
			ExtendParent = true;
			CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0561563f-b671-4042-9e2e-4feb3f3fcb53")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("bc319d17-d7a1-4aeb-8f1e-36ec18941db0")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
			if (Columns.FindByUId(new Guid("5ff95d4a-7286-4bac-9a51-d9cd908e2bfe")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("a58b9876-0419-47ba-aa66-4f487ba132d0")) == null) {
				Columns.Add(CreatePrimaryAmountColumn());
			}
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0561563f-b671-4042-9e2e-4feb3f3fcb53"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				ModifiedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("bc319d17-d7a1-4aeb-8f1e-36ec18941db0"),
				Name = @"CurrencyRate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				ModifiedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("5ff95d4a-7286-4bac-9a51-d9cd908e2bfe"),
				Name = @"Amount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				ModifiedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("a58b9876-0419-47ba-aa66-4f487ba132d0"),
				Name = @"PrimaryAmount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				ModifiedInSchemaUId = new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"),
				CreatedInPackageId = new Guid("8fca2d52-b411-4398-ba35-ffd14745bc94")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Contract_SalesContracts_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Contract_SalesContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Contract_SalesContracts_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Contract_SalesContracts_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1"));
		}

		#endregion

	}

	#endregion

	#region Class: Contract_SalesContracts_BPMSoft

	/// <summary>
	/// Договор.
	/// </summary>
	public class Contract_SalesContracts_BPMSoft : BPMSoft.Configuration.Contract_CoreContracts_BPMSoft
	{

		#region Constructors: Public

		public Contract_SalesContracts_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Contract_SalesContracts_BPMSoft";
		}

		public Contract_SalesContracts_BPMSoft(Contract_SalesContracts_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		/// <summary>
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Сумма, б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Contract_SalesContractsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Contract_SalesContracts_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Contract_SalesContracts_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Contract_SalesContracts_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Contract_SalesContractsEventsProcess

	/// <exclude/>
	public partial class Contract_SalesContractsEventsProcess<TEntity> : BPMSoft.Configuration.Contract_CoreContractsEventsProcess<TEntity> where TEntity : Contract_SalesContracts_BPMSoft
	{

		public Contract_SalesContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Contract_SalesContractsEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("463a2ce9-85a4-4b8c-9ac2-a98b80ac08c1");
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

	#region Class: Contract_SalesContractsEventsProcess

	/// <exclude/>
	public class Contract_SalesContractsEventsProcess : Contract_SalesContractsEventsProcess<Contract_SalesContracts_BPMSoft>
	{

		public Contract_SalesContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Contract_SalesContractsEventsProcess

	public partial class Contract_SalesContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

