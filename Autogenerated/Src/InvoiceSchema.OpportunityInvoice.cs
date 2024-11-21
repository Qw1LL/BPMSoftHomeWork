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

	#region Class: Invoice_OpportunityInvoice_BPMSoftSchema

	/// <exclude/>
	public class Invoice_OpportunityInvoice_BPMSoftSchema : BPMSoft.Configuration.Invoice_PRMPortal_BPMSoftSchema
	{

		#region Constructors: Public

		public Invoice_OpportunityInvoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_OpportunityInvoice_BPMSoftSchema(Invoice_OpportunityInvoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_OpportunityInvoice_BPMSoftSchema(Invoice_OpportunityInvoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c6db0f6f-90d6-4108-9123-69731551db81");
			Name = "Invoice_OpportunityInvoice_BPMSoft";
			ParentSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			ExtendParent = true;
			CreatedInPackageId = new Guid("799efff9-f266-416d-bc26-c9f1f14c064c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4566ed19-07f2-4836-9fda-eb24b2112208")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4566ed19-07f2-4836-9fda-eb24b2112208"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6db0f6f-90d6-4108-9123-69731551db81"),
				ModifiedInSchemaUId = new Guid("c6db0f6f-90d6-4108-9123-69731551db81"),
				CreatedInPackageId = new Guid("799efff9-f266-416d-bc26-c9f1f14c064c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_OpportunityInvoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_OpportunityInvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_OpportunityInvoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_OpportunityInvoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6db0f6f-90d6-4108-9123-69731551db81"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_OpportunityInvoice_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_OpportunityInvoice_BPMSoft : BPMSoft.Configuration.Invoice_PRMPortal_BPMSoft
	{

		#region Constructors: Public

		public Invoice_OpportunityInvoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_OpportunityInvoice_BPMSoft";
		}

		public Invoice_OpportunityInvoice_BPMSoft(Invoice_OpportunityInvoice_BPMSoft source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Invoice_OpportunityInvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Invoice_OpportunityInvoice_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Invoice_OpportunityInvoice_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Invoice_OpportunityInvoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_OpportunityInvoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_OpportunityInvoiceEventsProcess

	/// <exclude/>
	public partial class Invoice_OpportunityInvoiceEventsProcess<TEntity> : BPMSoft.Configuration.Invoice_PRMPortalEventsProcess<TEntity> where TEntity : Invoice_OpportunityInvoice_BPMSoft
	{

		public Invoice_OpportunityInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_OpportunityInvoiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c6db0f6f-90d6-4108-9123-69731551db81");
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

	#region Class: Invoice_OpportunityInvoiceEventsProcess

	/// <exclude/>
	public class Invoice_OpportunityInvoiceEventsProcess : Invoice_OpportunityInvoiceEventsProcess<Invoice_OpportunityInvoice_BPMSoft>
	{

		public Invoice_OpportunityInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_OpportunityInvoiceEventsProcess

	public partial class Invoice_OpportunityInvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

