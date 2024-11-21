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

	#region Class: InvoiceVisaSchema

	/// <exclude/>
	public class InvoiceVisaSchema : BPMSoft.Configuration.BaseVisaSchema
	{

		#region Constructors: Public

		public InvoiceVisaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceVisaSchema(InvoiceVisaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceVisaSchema(InvoiceVisaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ec034d19-5185-497d-9066-29f2973037f1");
			RealUId = new Guid("ec034d19-5185-497d-9066-29f2973037f1");
			Name = "InvoiceVisa";
			ParentSchemaUId = new Guid("5fa90d0d-64eb-4f52-8d3d-c51fa6443b66");
			ExtendParent = false;
			CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a77a54ba-d2b3-4ddb-b195-2c2d14a375b6")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a77a54ba-d2b3-4ddb-b195-2c2d14a375b6"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ec034d19-5185-497d-9066-29f2973037f1"),
				ModifiedInSchemaUId = new Guid("ec034d19-5185-497d-9066-29f2973037f1"),
				CreatedInPackageId = new Guid("30bec7d4-5068-42a2-ab31-4d4a3fc4e524")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceVisa(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceVisa_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceVisaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceVisaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ec034d19-5185-497d-9066-29f2973037f1"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceVisa

	/// <summary>
	/// Виза счета .
	/// </summary>
	public class InvoiceVisa : BPMSoft.Configuration.BaseVisa
	{

		#region Constructors: Public

		public InvoiceVisa(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceVisa";
		}

		public InvoiceVisa(InvoiceVisa source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = LookupColumnEntities.GetEntity("Invoice") as Invoice);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceVisa_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserted += (s, e) => ThrowEvent("InvoiceVisaInserted", e);
			Inserting += (s, e) => ThrowEvent("InvoiceVisaInserting", e);
			Saved += (s, e) => ThrowEvent("InvoiceVisaSaved", e);
			Saving += (s, e) => ThrowEvent("InvoiceVisaSaving", e);
			Validating += (s, e) => ThrowEvent("InvoiceVisaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceVisa(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceVisa_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceVisa_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseVisa_NUIEventsProcess<TEntity> where TEntity : InvoiceVisa
	{

		public InvoiceVisa_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceVisa_InvoiceEventsProcess";
			SchemaUId = new Guid("ec034d19-5185-497d-9066-29f2973037f1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ec034d19-5185-497d-9066-29f2973037f1");
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

	#region Class: InvoiceVisa_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceVisa_InvoiceEventsProcess : InvoiceVisa_InvoiceEventsProcess<InvoiceVisa>
	{

		public InvoiceVisa_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceVisa_InvoiceEventsProcess

	public partial class InvoiceVisa_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override List<string> GetVisaTemplateSchemaQueryColumns() {
			List<string> columns = base.GetVisaTemplateSchemaQueryColumns();
			columns.AddRange( new string[] {
				"Invoice.Number",
				"Invoice.StartDate",
				"Invoice.Currency.ShortName",
				"Invoice.Amount",
				"Invoice.Owner.Name",
				"Invoice.Contact.Name",
				"Invoice.Account.Name"
			});
			return columns;
		}

		public override INotificationInfo GetNotificationInfo() {
			Entity.Invoice.FetchFromDB(Entity.InvoiceId);
			var invoice = Entity.Invoice;
			var invoiceDate = invoice.StartDate.ToString(PopupBodyDateFormat);
			var accountName = invoice.AccountName;
			var contactName = invoice.ContactName;
			var accountContactString = string.Join(", ", new[] {accountName, contactName}.Where(s => s.IsNotEmpty()));
			var body = string.Format(PopupBodyTemplate, invoice.Number, invoiceDate, accountContactString);
			var notificationInfo = base.GetNotificationInfo();
			notificationInfo.EntityId = invoice.Id;
			notificationInfo.Body = body;
			return notificationInfo;
		}

		#endregion

	}

	#endregion


	#region Class: InvoiceVisaEventsProcess

	/// <exclude/>
	public class InvoiceVisaEventsProcess : InvoiceVisa_InvoiceEventsProcess
	{

		public InvoiceVisaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

