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

	#region Class: Invoice_PRMPortal_BPMSoftSchema

	/// <exclude/>
	public class Invoice_PRMPortal_BPMSoftSchema : BPMSoft.Configuration.Invoice_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public Invoice_PRMPortal_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_PRMPortal_BPMSoftSchema(Invoice_PRMPortal_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_PRMPortal_BPMSoftSchema(Invoice_PRMPortal_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ee2e8e67-a932-4897-9f22-53b8bcdaf300");
			Name = "Invoice_PRMPortal_BPMSoft";
			ParentSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_PRMPortal_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_PRMPortal_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_PRMPortal_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ee2e8e67-a932-4897-9f22-53b8bcdaf300"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_PRMPortal_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_PRMPortal_BPMSoft : BPMSoft.Configuration.Invoice_Passport_BPMSoft
	{

		#region Constructors: Public

		public Invoice_PRMPortal_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_PRMPortal_BPMSoft";
		}

		public Invoice_PRMPortal_BPMSoft(Invoice_PRMPortal_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Invoice_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("Invoice_PRMPortal_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Invoice_PRMPortal_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Invoice_PRMPortal_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Invoice_PRMPortal_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Invoice_PRMPortal_BPMSoftSaving", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_PRMPortal_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_PRMPortalEventsProcess

	/// <exclude/>
	public partial class Invoice_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.Invoice_PassportEventsProcess<TEntity> where TEntity : Invoice_PRMPortal_BPMSoft
	{

		public Invoice_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ee2e8e67-a932-4897-9f22-53b8bcdaf300");
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

	#region Class: Invoice_PRMPortalEventsProcess

	/// <exclude/>
	public class Invoice_PRMPortalEventsProcess : Invoice_PRMPortalEventsProcess<Invoice_PRMPortal_BPMSoft>
	{

		public Invoice_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_PRMPortalEventsProcess

	public partial class Invoice_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

