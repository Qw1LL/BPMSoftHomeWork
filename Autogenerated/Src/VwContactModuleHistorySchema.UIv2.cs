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

	#region Class: VwContactModuleHistorySchema

	/// <exclude/>
	public class VwContactModuleHistorySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwContactModuleHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwContactModuleHistorySchema(VwContactModuleHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwContactModuleHistorySchema(VwContactModuleHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			RealUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			Name = "VwContactModuleHistory";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("59152be0-65ec-4e43-b6a5-97a915c11273")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("7dc47acd-cfe7-401a-a13e-2a89842b965b")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("4aa9817a-2188-40db-aa80-e6b8fa6b7681")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("4e6bcc15-1230-4f21-9b99-a0374d32324e")) == null) {
				Columns.Add(CreateSysEntityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			column.CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("59152be0-65ec-4e43-b6a5-97a915c11273"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7dc47acd-cfe7-401a-a13e-2a89842b965b"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4aa9817a-2188-40db-aa80-e6b8fa6b7681"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4e6bcc15-1230-4f21-9b99-a0374d32324e"),
				Name = @"SysEntity",
				ReferenceSchemaUId = new Guid("a2d407a1-cda4-4344-ac71-88a4e2bf9c28"),
				CreatedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				ModifiedInSchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"),
				CreatedInPackageId = new Guid("62195e1c-47bf-4dbd-b7fc-67d37beb217a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwContactModuleHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwContactModuleHistory_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwContactModuleHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwContactModuleHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1"));
		}

		#endregion

	}

	#endregion

	#region Class: VwContactModuleHistory

	/// <summary>
	/// Contacts section history (view).
	/// </summary>
	public class VwContactModuleHistory : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwContactModuleHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwContactModuleHistory";
		}

		public VwContactModuleHistory(VwContactModuleHistory source)
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
			var process = new VwContactModuleHistory_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwContactModuleHistoryDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwContactModuleHistoryInserting", e);
			Validating += (s, e) => ThrowEvent("VwContactModuleHistoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwContactModuleHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwContactModuleHistory_UIv2EventsProcess

	/// <exclude/>
	public partial class VwContactModuleHistory_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwContactModuleHistory
	{

		public VwContactModuleHistory_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwContactModuleHistory_UIv2EventsProcess";
			SchemaUId = new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b2df669b-ebc2-4e72-913c-bf68895c27a1");
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

	#region Class: VwContactModuleHistory_UIv2EventsProcess

	/// <exclude/>
	public class VwContactModuleHistory_UIv2EventsProcess : VwContactModuleHistory_UIv2EventsProcess<VwContactModuleHistory>
	{

		public VwContactModuleHistory_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwContactModuleHistory_UIv2EventsProcess

	public partial class VwContactModuleHistory_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwContactModuleHistoryEventsProcess

	/// <exclude/>
	public class VwContactModuleHistoryEventsProcess : VwContactModuleHistory_UIv2EventsProcess
	{

		public VwContactModuleHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

