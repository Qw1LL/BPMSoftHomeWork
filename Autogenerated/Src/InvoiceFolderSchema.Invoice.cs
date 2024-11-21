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

	#region Class: InvoiceFolderSchema

	/// <exclude/>
	public class InvoiceFolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public InvoiceFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceFolderSchema(InvoiceFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceFolderSchema(InvoiceFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			RealUId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			Name = "InvoiceFolder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceFolder_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceFolder

	/// <summary>
	/// Группа счета.
	/// </summary>
	public class InvoiceFolder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public InvoiceFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceFolder";
		}

		public InvoiceFolder(InvoiceFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private InvoiceFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public InvoiceFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as InvoiceFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceFolder_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("InvoiceFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("InvoiceFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("InvoiceFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("InvoiceFolderInserting", e);
			Saved += (s, e) => ThrowEvent("InvoiceFolderSaved", e);
			Saving += (s, e) => ThrowEvent("InvoiceFolderSaving", e);
			Validating += (s, e) => ThrowEvent("InvoiceFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceFolder_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceFolder_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : InvoiceFolder
	{

		public InvoiceFolder_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceFolder_InvoiceEventsProcess";
			SchemaUId = new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("23fef840-9ef8-4a5b-b558-7dae5b7ff672");
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

	#region Class: InvoiceFolder_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceFolder_InvoiceEventsProcess : InvoiceFolder_InvoiceEventsProcess<InvoiceFolder>
	{

		public InvoiceFolder_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceFolder_InvoiceEventsProcess

	public partial class InvoiceFolder_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion


	#region Class: InvoiceFolderEventsProcess

	/// <exclude/>
	public class InvoiceFolderEventsProcess : InvoiceFolder_InvoiceEventsProcess
	{

		public InvoiceFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

