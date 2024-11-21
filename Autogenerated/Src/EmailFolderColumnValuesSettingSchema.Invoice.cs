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

	#region Class: EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema(EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema(EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("75a2d8b1-b9f5-4d66-a1a1-c16330027696");
			Name = "EmailFolderColumnValuesSetting_Invoice_BPMSoft";
			ParentSchemaUId = new Guid("77ffb765-d7ad-4f91-9027-92cdf97b4c1f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("afbb269b-fc54-494c-b1eb-1fd3a323385c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f06bf4d6-d855-4a73-99f6-2f8ebd6d63f2")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f06bf4d6-d855-4a73-99f6-2f8ebd6d63f2"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("75a2d8b1-b9f5-4d66-a1a1-c16330027696"),
				ModifiedInSchemaUId = new Guid("75a2d8b1-b9f5-4d66-a1a1-c16330027696"),
				CreatedInPackageId = new Guid("eceefca3-5a45-46fe-8b09-e72ef0cd9d7e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_Invoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailFolderColumnValuesSetting_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailFolderColumnValuesSetting_Invoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("75a2d8b1-b9f5-4d66-a1a1-c16330027696"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_Invoice_BPMSoft

	/// <summary>
	/// Настройка значений полей в группе e-mail.
	/// </summary>
	public class EmailFolderColumnValuesSetting_Invoice_BPMSoft : BPMSoft.Configuration.EmailFolderColumnValuesSetting_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public EmailFolderColumnValuesSetting_Invoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailFolderColumnValuesSetting_Invoice_BPMSoft";
		}

		public EmailFolderColumnValuesSetting_Invoice_BPMSoft(EmailFolderColumnValuesSetting_Invoice_BPMSoft source)
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
			var process = new EmailFolderColumnValuesSetting_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Invoice_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Invoice_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("EmailFolderColumnValuesSetting_Invoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailFolderColumnValuesSetting_Invoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_InvoiceEventsProcess

	/// <exclude/>
	public partial class EmailFolderColumnValuesSetting_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.EmailFolderColumnValuesSetting_OpportunityEventsProcess<TEntity> where TEntity : EmailFolderColumnValuesSetting_Invoice_BPMSoft
	{

		public EmailFolderColumnValuesSetting_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailFolderColumnValuesSetting_InvoiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("75a2d8b1-b9f5-4d66-a1a1-c16330027696");
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

	#region Class: EmailFolderColumnValuesSetting_InvoiceEventsProcess

	/// <exclude/>
	public class EmailFolderColumnValuesSetting_InvoiceEventsProcess : EmailFolderColumnValuesSetting_InvoiceEventsProcess<EmailFolderColumnValuesSetting_Invoice_BPMSoft>
	{

		public EmailFolderColumnValuesSetting_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailFolderColumnValuesSetting_InvoiceEventsProcess

	public partial class EmailFolderColumnValuesSetting_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

