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

	#region Class: BulkEmailStatusSchema

	/// <exclude/>
	public class BulkEmailStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailStatusSchema(BulkEmailStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailStatusSchema(BulkEmailStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			RealUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			Name = "BulkEmailStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8b0d48e2-5fa5-4728-a348-a42dc2af0dea")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8b0d48e2-5fa5-4728-a348-a42dc2af0dea"),
				Name = @"IsActive",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3"),
				ModifiedInSchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3"),
				CreatedInPackageId = new Guid("d6fec08a-2746-46b6-a96c-0a31e271957f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailStatus_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailStatus

	/// <summary>
	/// Состояние email.
	/// </summary>
	public class BulkEmailStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailStatus";
		}

		public BulkEmailStatus(BulkEmailStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Активное состояние.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailStatus_BulkEmailEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailStatusDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailStatusInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailStatus_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailStatus_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailStatus
	{

		public BulkEmailStatus_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailStatus_BulkEmailEventsProcess";
			SchemaUId = new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6018ff01-89b1-4826-9173-9b38cb29b6f3");
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

	#region Class: BulkEmailStatus_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailStatus_BulkEmailEventsProcess : BulkEmailStatus_BulkEmailEventsProcess<BulkEmailStatus>
	{

		public BulkEmailStatus_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailStatus_BulkEmailEventsProcess

	public partial class BulkEmailStatus_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailStatusEventsProcess

	/// <exclude/>
	public class BulkEmailStatusEventsProcess : BulkEmailStatus_BulkEmailEventsProcess
	{

		public BulkEmailStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

