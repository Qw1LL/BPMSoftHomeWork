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

	#region Class: QueueItemStatusSchema

	/// <exclude/>
	public class QueueItemStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public QueueItemStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueItemStatusSchema(QueueItemStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueItemStatusSchema(QueueItemStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c");
			RealUId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c");
			Name = "QueueItemStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8832800a-1147-4236-bf13-1e3431125107")) == null) {
				Columns.Add(CreateIsFinalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsFinalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8832800a-1147-4236-bf13-1e3431125107"),
				Name = @"IsFinal",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c"),
				ModifiedInSchemaUId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c"),
				CreatedInPackageId = new Guid("b37272aa-ca79-4db2-9717-1c02e42cc793")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QueueItemStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QueueItemStatus_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueItemStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueItemStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c"));
		}

		#endregion

	}

	#endregion

	#region Class: QueueItemStatus

	/// <summary>
	/// Состояние элемента в очереди единого окна.
	/// </summary>
	public class QueueItemStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public QueueItemStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueItemStatus";
		}

		public QueueItemStatus(QueueItemStatus source)
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
			var process = new QueueItemStatus_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueItemStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("QueueItemStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QueueItemStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: QueueItemStatus_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class QueueItemStatus_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : QueueItemStatus
	{

		public QueueItemStatus_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QueueItemStatus_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a4b5e242-0a9b-413d-a7cc-0faca45c3c2c");
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

	#region Class: QueueItemStatus_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class QueueItemStatus_OperatorSingleWindowEventsProcess : QueueItemStatus_OperatorSingleWindowEventsProcess<QueueItemStatus>
	{

		public QueueItemStatus_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QueueItemStatus_OperatorSingleWindowEventsProcess

	public partial class QueueItemStatus_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QueueItemStatusEventsProcess

	/// <exclude/>
	public class QueueItemStatusEventsProcess : QueueItemStatus_OperatorSingleWindowEventsProcess
	{

		public QueueItemStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

