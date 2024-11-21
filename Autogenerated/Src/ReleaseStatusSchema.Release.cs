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

	#region Class: ReleaseStatusSchema

	/// <exclude/>
	public class ReleaseStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ReleaseStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseStatusSchema(ReleaseStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseStatusSchema(ReleaseStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			RealUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			Name = "ReleaseStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e3ebb763-df72-42a8-a2f6-10d0b74b66e3")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e3ebb763-df72-42a8-a2f6-10d0b74b66e3"),
				Name = @"IsFinal",
				CreatedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb"),
				ModifiedInSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseStatus_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("597097ce-243d-49d2-90de-14bdf30391fb"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseStatus

	/// <summary>
	/// Состояние релиза.
	/// </summary>
	public class ReleaseStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ReleaseStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseStatus";
		}

		public ReleaseStatus(ReleaseStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное.
		/// </summary>
		public bool IsFinal {
			get {
				return GetTypedColumnValue<bool>("IsFinal");
			}
			set {
				SetColumnValue("IsFinal", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseStatus_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseStatus_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseStatus_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ReleaseStatus
	{

		public ReleaseStatus_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseStatus_ReleaseEventsProcess";
			SchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("597097ce-243d-49d2-90de-14bdf30391fb");
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

	#region Class: ReleaseStatus_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseStatus_ReleaseEventsProcess : ReleaseStatus_ReleaseEventsProcess<ReleaseStatus>
	{

		public ReleaseStatus_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseStatus_ReleaseEventsProcess

	public partial class ReleaseStatus_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseStatusEventsProcess

	/// <exclude/>
	public class ReleaseStatusEventsProcess : ReleaseStatus_ReleaseEventsProcess
	{

		public ReleaseStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

