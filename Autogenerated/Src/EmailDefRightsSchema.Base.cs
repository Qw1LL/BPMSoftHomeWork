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

	#region Class: EmailDefRightsSchema

	/// <exclude/>
	public class EmailDefRightsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmailDefRightsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmailDefRightsSchema(EmailDefRightsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmailDefRightsSchema(EmailDefRightsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772");
			RealUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772");
			Name = "EmailDefRights";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateRecordColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("135b33a9-3f7e-447e-ae40-2d6da568af2a")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("906a10ad-6fd7-4798-ae13-755787c12c51")) == null) {
				Columns.Add(CreateOperationColumn());
			}
			if (Columns.FindByUId(new Guid("999da532-1ae6-4ec6-9b13-3c84dadf8184")) == null) {
				Columns.Add(CreateRightLevelColumn());
			}
			if (Columns.FindByUId(new Guid("2cc071e1-d694-43ce-acdf-a57d5494e3b6")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("135b33a9-3f7e-447e-ae40-2d6da568af2a"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				ModifiedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateOperationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("906a10ad-6fd7-4798-ae13-755787c12c51"),
				Name = @"Operation",
				CreatedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				ModifiedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateRightLevelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("999da532-1ae6-4ec6-9b13-3c84dadf8184"),
				Name = @"RightLevel",
				CreatedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				ModifiedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6d2f7417-e66c-4a99-bf16-46ffb8880985"),
				Name = @"Record",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				ModifiedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2cc071e1-d694-43ce-acdf-a57d5494e3b6"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				ModifiedInSchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
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
			return new EmailDefRights(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmailDefRights_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmailDefRightsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmailDefRightsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772"));
		}

		#endregion

	}

	#endregion

	#region Class: EmailDefRights

	/// <summary>
	/// EmailDefRights.
	/// </summary>
	public class EmailDefRights : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EmailDefRights(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailDefRights";
		}

		public EmailDefRights(EmailDefRights source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Operation.
		/// </summary>
		public int Operation {
			get {
				return GetTypedColumnValue<int>("Operation");
			}
			set {
				SetColumnValue("Operation", value);
			}
		}

		/// <summary>
		/// RightLevel.
		/// </summary>
		public int RightLevel {
			get {
				return GetTypedColumnValue<int>("RightLevel");
			}
			set {
				SetColumnValue("RightLevel", value);
			}
		}

		/// <exclude/>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
				_record = null;
			}
		}

		/// <exclude/>
		public string RecordUserName {
			get {
				return GetTypedColumnValue<string>("RecordUserName");
			}
			set {
				SetColumnValue("RecordUserName", value);
				if (_record != null) {
					_record.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _record;
		/// <summary>
		/// MailboxSyncSettings.
		/// </summary>
		public MailboxSyncSettings Record {
			get {
				return _record ??
					(_record = LookupColumnEntities.GetEntity("Record") as MailboxSyncSettings);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmailDefRights_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmailDefRightsDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmailDefRights(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmailDefRights_BaseEventsProcess

	/// <exclude/>
	public partial class EmailDefRights_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EmailDefRights
	{

		public EmailDefRights_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmailDefRights_BaseEventsProcess";
			SchemaUId = new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53f20fd1-b1bf-44b1-a0ee-891fc53a9772");
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

	#region Class: EmailDefRights_BaseEventsProcess

	/// <exclude/>
	public class EmailDefRights_BaseEventsProcess : EmailDefRights_BaseEventsProcess<EmailDefRights>
	{

		public EmailDefRights_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmailDefRights_BaseEventsProcess

	public partial class EmailDefRights_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmailDefRightsEventsProcess

	/// <exclude/>
	public class EmailDefRightsEventsProcess : EmailDefRights_BaseEventsProcess
	{

		public EmailDefRightsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

