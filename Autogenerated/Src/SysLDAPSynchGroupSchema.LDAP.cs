namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: SysLDAPSynchGroupSchema

	/// <exclude/>
	public class SysLDAPSynchGroupSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public SysLDAPSynchGroupSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLDAPSynchGroupSchema(SysLDAPSynchGroupSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLDAPSynchGroupSchema(SysLDAPSynchGroupSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27");
			RealUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27");
			Name = "SysLDAPSynchGroup";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateRecordIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d507c7f5-0b4f-4047-8390-3d5a45e44978")) == null) {
				Columns.Add(CreateIdColumn());
			}
			if (Columns.FindByUId(new Guid("89d40f75-400a-488c-a964-3e7646fac78f")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("7df0b36a-4cd9-4de2-9149-df57708b2535")) == null) {
				Columns.Add(CreateDnColumn());
			}
			if (Columns.FindByUId(new Guid("97beaab9-f711-4646-b723-284f63a8bf77")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("35c00167-a658-e3c2-c1b4-0949a0aab983")) == null) {
				Columns.Add(CreateLdapSyncIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2c496268-390a-457a-9eb5-6eb0f2b53f50"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d507c7f5-0b4f-4047-8390-3d5a45e44978"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("89d40f75-400a-488c-a964-3e7646fac78f"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateDnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("7df0b36a-4cd9-4de2-9149-df57708b2535"),
				Name = @"Dn",
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("97beaab9-f711-4646-b723-284f63a8bf77"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateLdapSyncIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("35c00167-a658-e3c2-c1b4-0949a0aab983"),
				Name = @"LdapSyncId",
				CreatedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				ModifiedInSchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"),
				CreatedInPackageId = new Guid("7c904ad4-e292-4453-b17c-60a3882c9384")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLDAPSynchGroup(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLDAPSynchGroup_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLDAPSynchGroupSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLDAPSynchGroupSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLDAPSynchGroup

	/// <summary>
	/// SysLDAPSynchGroup.
	/// </summary>
	public class SysLDAPSynchGroup : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLDAPSynchGroup(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLDAPSynchGroup";
		}

		public SysLDAPSynchGroup(SysLDAPSynchGroup source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record Id.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public string Id {
			get {
				return GetTypedColumnValue<string>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Dn.
		/// </summary>
		public string Dn {
			get {
				return GetTypedColumnValue<string>("Dn");
			}
			set {
				SetColumnValue("Dn", value);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Synchronization identifier.
		/// </summary>
		public Guid LdapSyncId {
			get {
				return GetTypedColumnValue<Guid>("LdapSyncId");
			}
			set {
				SetColumnValue("LdapSyncId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLDAPSynchGroup_LDAPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLDAPSynchGroup(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLDAPSynchGroup_LDAPEventsProcess

	/// <exclude/>
	public partial class SysLDAPSynchGroup_LDAPEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : SysLDAPSynchGroup
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public SysLDAPSynchGroup_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLDAPSynchGroup_LDAPEventsProcess";
			SchemaUId = new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3b4b2253-8bfd-4e68-8843-adcc2d61bb27");
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

	#region Class: SysLDAPSynchGroup_LDAPEventsProcess

	/// <exclude/>
	public class SysLDAPSynchGroup_LDAPEventsProcess : SysLDAPSynchGroup_LDAPEventsProcess<SysLDAPSynchGroup>
	{

		public SysLDAPSynchGroup_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLDAPSynchGroup_LDAPEventsProcess

	public partial class SysLDAPSynchGroup_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLDAPSynchGroupEventsProcess

	/// <exclude/>
	public class SysLDAPSynchGroupEventsProcess : SysLDAPSynchGroup_LDAPEventsProcess
	{

		public SysLDAPSynchGroupEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

