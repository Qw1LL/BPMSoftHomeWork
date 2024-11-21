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

	#region Class: InvoiceInFolderSchema

	/// <exclude/>
	public class InvoiceInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public InvoiceInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceInFolderSchema(InvoiceInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceInFolderSchema(InvoiceInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791");
			RealUId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791");
			Name = "InvoiceInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("749fc410-4470-40e0-a861-0fbe485ed0b8")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791");
			return column;
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("749fc410-4470-40e0-a861-0fbe485ed0b8"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791"),
				ModifiedInSchemaUId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791"),
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
			return new InvoiceInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceInFolder_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceInFolder

	/// <summary>
	/// Счет в группе.
	/// </summary>
	public class InvoiceInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public InvoiceInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceInFolder";
		}

		public InvoiceInFolder(InvoiceInFolder source)
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
			var process = new InvoiceInFolder_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("InvoiceInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("InvoiceInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("InvoiceInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("InvoiceInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("InvoiceInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("InvoiceInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("InvoiceInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceInFolder_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceInFolder_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : InvoiceInFolder
	{

		public InvoiceInFolder_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceInFolder_InvoiceEventsProcess";
			SchemaUId = new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2b0637bd-a7a5-4cb3-bbf4-64ad4f42e791");
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

	#region Class: InvoiceInFolder_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceInFolder_InvoiceEventsProcess : InvoiceInFolder_InvoiceEventsProcess<InvoiceInFolder>
	{

		public InvoiceInFolder_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceInFolder_InvoiceEventsProcess

	public partial class InvoiceInFolder_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: InvoiceInFolderEventsProcess

	/// <exclude/>
	public class InvoiceInFolderEventsProcess : InvoiceInFolder_InvoiceEventsProcess
	{

		public InvoiceInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

