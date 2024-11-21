namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Mail;
	using BPMSoft.Messaging.Common;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;

	#region Class: ContractVisaSchema

	/// <exclude/>
	public class ContractVisaSchema : BPMSoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public ContractVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContractVisaSchema(ContractVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContractVisaSchema(ContractVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
			RealUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
			Name = "ContractVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fe0dfac8-c69e-4744-b030-d6998935c904")) == null) {
				Columns.Add(CreateContractColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContractColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fe0dfac8-c69e-4744-b030-d6998935c904"),
				Name = @"Contract",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				ModifiedInSchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"),
				CreatedInPackageId = new Guid("26258d2f-5eb6-4391-98b9-20659e44f505")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContractVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContractVisa_CoreContractsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContractVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContractVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5"));
		}

		#endregion

	}

	#endregion

	#region Class: ContractVisa

	/// <summary>
	/// Виза договора.
	/// </summary>
	public class ContractVisa : BPMSoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public ContractVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContractVisa";
		}

		public ContractVisa(ContractVisa source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = LookupColumnEntities.GetEntity("Contract") as Contract);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContractVisa_CoreContractsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("ContractVisaInserted", e);
			Inserting += (s, e) => ThrowEvent("ContractVisaInserting", e);
			Saved += (s, e) => ThrowEvent("ContractVisaSaved", e);
			Saving += (s, e) => ThrowEvent("ContractVisaSaving", e);
			Validating += (s, e) => ThrowEvent("ContractVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContractVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContractVisa_CoreContractsEventsProcess

	/// <exclude/>
	public partial class ContractVisa_CoreContractsEventsProcess<TEntity> : BPMSoft.Configuration.BaseVisa_NUIEventsProcess<TEntity> where TEntity : ContractVisa
	{

		public ContractVisa_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContractVisa_CoreContractsEventsProcess";
			SchemaUId = new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e2edcaf0-4bec-418f-9c13-b1e07e7244c5");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private LocalizableString _popupBodyTemplateWithoutDate;
		public LocalizableString PopupBodyTemplateWithoutDate {
			get {
				return _popupBodyTemplateWithoutDate ?? (_popupBodyTemplateWithoutDate = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.PopupBodyTemplateWithoutDate.Value"));
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

	#region Class: ContractVisa_CoreContractsEventsProcess

	/// <exclude/>
	public class ContractVisa_CoreContractsEventsProcess : ContractVisa_CoreContractsEventsProcess<ContractVisa>
	{

		public ContractVisa_CoreContractsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContractVisa_CoreContractsEventsProcess

	public partial class ContractVisa_CoreContractsEventsProcess<TEntity>
	{

		#region Methods: Public

		public override INotificationInfo GetNotificationInfo() {
			Entity.Contract.FetchFromDB(Entity.ContractId);
			var contract = Entity.Contract;
			var contractDateString = contract.StartDate == default(DateTime) 
				? string.Empty
				: contract.StartDate.ToString(PopupBodyDateFormat);
			var accountName = contract.AccountName;
			var contactName = contract.ContactName;
			var accountContactString = string.Join(", ", new[] {accountName, contactName}.Where(s => s.IsNotEmpty()));
			var body = contractDateString.IsNullOrEmpty()
				? string.Format(PopupBodyTemplateWithoutDate, contract.Number, accountContactString)
				: string.Format(PopupBodyTemplate, contract.Number, contractDateString, accountContactString);
			var notificationInfo = base.GetNotificationInfo();
			notificationInfo.EntityId = contract.Id;
			notificationInfo.Body = body;
			return notificationInfo;
		}

		#endregion

	}

	#endregion


	#region Class: ContractVisaEventsProcess

	/// <exclude/>
	public class ContractVisaEventsProcess : ContractVisa_CoreContractsEventsProcess
	{

		public ContractVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

