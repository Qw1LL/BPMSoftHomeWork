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

	#region Class: VwAccountModuleHistorySchema

	/// <exclude/>
	public class VwAccountModuleHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwAccountModuleHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwAccountModuleHistorySchema(VwAccountModuleHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwAccountModuleHistorySchema(VwAccountModuleHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			RealUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			Name = "VwAccountModuleHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("df766449-7368-4cfc-87a6-66128b0fec5d")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("f2ea1756-4f7e-4f5f-a25f-1a4831271584")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("2173c17b-4777-4f1c-b8e4-ba856325e547")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("adb0d247-4e4f-4a00-bbe4-69e5ecda3f58")) == null) {
				Columns.Add(CreateSysEntityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			column.CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("df766449-7368-4cfc-87a6-66128b0fec5d"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("f2ea1756-4f7e-4f5f-a25f-1a4831271584"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2173c17b-4777-4f1c-b8e4-ba856325e547"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("adb0d247-4e4f-4a00-bbe4-69e5ecda3f58"),
				Name = @"SysEntity",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				CreatedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				ModifiedInSchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"),
				CreatedInPackageId = new Guid("d7e96410-af1c-4102-bba2-1d76e4d371aa")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwAccountModuleHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwAccountModuleHistory_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwAccountModuleHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwAccountModuleHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e"));
		}

		#endregion

	}

	#endregion

	#region Class: VwAccountModuleHistory

	/// <summary>
	/// Accounts section history (view).
	/// </summary>
	public class VwAccountModuleHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwAccountModuleHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwAccountModuleHistory";
		}

		public VwAccountModuleHistory(VwAccountModuleHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid SysEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysEntityId");
			}
			set {
				SetColumnValue("SysEntityId", value);
				_sysEntity = null;
			}
		}

		/// <exclude/>
		public string SysEntityName {
			get {
				return GetTypedColumnValue<string>("SysEntityName");
			}
			set {
				SetColumnValue("SysEntityName", value);
				if (_sysEntity != null) {
					_sysEntity.Name = value;
				}
			}
		}

		private VwSysModuleEntity _sysEntity;
		/// <summary>
		/// Object.
		/// </summary>
		public VwSysModuleEntity SysEntity {
			get {
				return _sysEntity ??
					(_sysEntity = LookupColumnEntities.GetEntity("SysEntity") as VwSysModuleEntity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwAccountModuleHistory_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwAccountModuleHistoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwAccountModuleHistoryInserting", e);
			Validating += (s, e) => ThrowEvent("VwAccountModuleHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwAccountModuleHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwAccountModuleHistory_UIv2EventsProcess

	/// <exclude/>
	public partial class VwAccountModuleHistory_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwAccountModuleHistory
	{

		public VwAccountModuleHistory_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwAccountModuleHistory_UIv2EventsProcess";
			SchemaUId = new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("96e6243d-dc48-462a-aa5f-c75d4471c39e");
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

	#region Class: VwAccountModuleHistory_UIv2EventsProcess

	/// <exclude/>
	public class VwAccountModuleHistory_UIv2EventsProcess : VwAccountModuleHistory_UIv2EventsProcess<VwAccountModuleHistory>
	{

		public VwAccountModuleHistory_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwAccountModuleHistory_UIv2EventsProcess

	public partial class VwAccountModuleHistory_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwAccountModuleHistoryEventsProcess

	/// <exclude/>
	public class VwAccountModuleHistoryEventsProcess : VwAccountModuleHistory_UIv2EventsProcess
	{

		public VwAccountModuleHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

