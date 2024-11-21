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

	#region Class: BulkEmailResponseSchema

	/// <exclude/>
	public class BulkEmailResponseSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public BulkEmailResponseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailResponseSchema(BulkEmailResponseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailResponseSchema(BulkEmailResponseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			RealUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			Name = "BulkEmailResponse";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6e9d600a-7a03-456c-a90e-670d259f649f")) == null) {
				Columns.Add(CreateIsFinalStateColumn());
			}
			if (Columns.FindByUId(new Guid("1dfbb13d-9111-4888-a85d-e7046b5f1cdc")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("5f5d1316-1f34-41d6-b0e2-879135c47c28")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("93847270-7738-4ad6-86c3-33c05b9ff18d")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsFinalStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6e9d600a-7a03-456c-a90e-670d259f649f"),
				Name = @"IsFinalState",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1dfbb13d-9111-4888-a85d-e7046b5f1cdc"),
				Name = @"Category",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				CreatedInPackageId = new Guid("2c3183e7-3de0-4a25-b7f0-d9d1c3360565")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("5f5d1316-1f34-41d6-b0e2-879135c47c28"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				CreatedInPackageId = new Guid("bf106969-ca59-4591-8fd8-1964385773cf")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("93847270-7738-4ad6-86c3-33c05b9ff18d"),
				Name = @"Priority",
				CreatedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				ModifiedInSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailResponse(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailResponse_BulkEmailEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailResponseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailResponseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailResponse

	/// <summary>
	/// Отклик участника рассылки email.
	/// </summary>
	public class BulkEmailResponse : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public BulkEmailResponse(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailResponse";
		}

		public BulkEmailResponse(BulkEmailResponse source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное состояние.
		/// </summary>
		public bool IsFinalState {
			get {
				return GetTypedColumnValue<bool>("IsFinalState");
			}
			set {
				SetColumnValue("IsFinalState", value);
			}
		}

		/// <summary>
		/// Категория.
		/// </summary>
		public int Category {
			get {
				return GetTypedColumnValue<int>("Category");
			}
			set {
				SetColumnValue("Category", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public int Code {
			get {
				return GetTypedColumnValue<int>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority {
			get {
				return GetTypedColumnValue<int>("Priority");
			}
			set {
				SetColumnValue("Priority", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailResponse_BulkEmailEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailResponseDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailResponseInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailResponseValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailResponse(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailResponse_BulkEmailEventsProcess

	/// <exclude/>
	public partial class BulkEmailResponse_BulkEmailEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : BulkEmailResponse
	{

		public BulkEmailResponse_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailResponse_BulkEmailEventsProcess";
			SchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed");
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

	#region Class: BulkEmailResponse_BulkEmailEventsProcess

	/// <exclude/>
	public class BulkEmailResponse_BulkEmailEventsProcess : BulkEmailResponse_BulkEmailEventsProcess<BulkEmailResponse>
	{

		public BulkEmailResponse_BulkEmailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailResponse_BulkEmailEventsProcess

	public partial class BulkEmailResponse_BulkEmailEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailResponseEventsProcess

	/// <exclude/>
	public class BulkEmailResponseEventsProcess : BulkEmailResponse_BulkEmailEventsProcess
	{

		public BulkEmailResponseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

