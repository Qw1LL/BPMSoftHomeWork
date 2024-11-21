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

	#region Class: VwModuleHistorySchema

	/// <exclude/>
	public class VwModuleHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwModuleHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwModuleHistorySchema(VwModuleHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwModuleHistorySchema(VwModuleHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			RealUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			Name = "VwModuleHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("68d20231-e613-4dbe-806e-cb2bebdb096f")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("d9dbb8ce-84a5-4851-9806-042885620255")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("73271643-4190-4ed3-a2b0-d1ea087588f5")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("aeed4f7f-b0ea-4690-a1e7-1a7d61dec417")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("02915273-9857-4c34-ac60-941cb2756900")) == null) {
				Columns.Add(CreateSysEntityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			column.CreatedInPackageId = new Guid("17937c72-ba9e-4db7-8de3-91b1651ce621");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("68d20231-e613-4dbe-806e-cb2bebdb096f"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("d9dbb8ce-84a5-4851-9806-042885620255"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("73271643-4190-4ed3-a2b0-d1ea087588f5"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("aeed4f7f-b0ea-4690-a1e7-1a7d61dec417"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("02915273-9857-4c34-ac60-941cb2756900"),
				Name = @"SysEntity",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				CreatedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				ModifiedInSchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwModuleHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwModuleHistory_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwModuleHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwModuleHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1"));
		}

		#endregion

	}

	#endregion

	#region Class: VwModuleHistory

	/// <summary>
	/// Section history (view).
	/// </summary>
	public class VwModuleHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwModuleHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwModuleHistory";
		}

		public VwModuleHistory(VwModuleHistory source)
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
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
			var process = new VwModuleHistory_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwModuleHistoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwModuleHistoryInserting", e);
			Validating += (s, e) => ThrowEvent("VwModuleHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwModuleHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwModuleHistory_BaseEventsProcess

	/// <exclude/>
	public partial class VwModuleHistory_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwModuleHistory
	{

		public VwModuleHistory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwModuleHistory_BaseEventsProcess";
			SchemaUId = new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2b1c75be-117a-42fb-aa1d-58ce1ec4cba1");
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

	#region Class: VwModuleHistory_BaseEventsProcess

	/// <exclude/>
	public class VwModuleHistory_BaseEventsProcess : VwModuleHistory_BaseEventsProcess<VwModuleHistory>
	{

		public VwModuleHistory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwModuleHistory_BaseEventsProcess

	public partial class VwModuleHistory_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwModuleHistoryEventsProcess

	/// <exclude/>
	public class VwModuleHistoryEventsProcess : VwModuleHistory_BaseEventsProcess
	{

		public VwModuleHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

