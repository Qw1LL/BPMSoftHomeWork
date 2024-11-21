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

	#region Class: MailingProviderInfoSchema

	/// <exclude/>
	[IsVirtual]
	public class MailingProviderInfoSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public MailingProviderInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MailingProviderInfoSchema(MailingProviderInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MailingProviderInfoSchema(MailingProviderInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb");
			RealUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb");
			Name = "MailingProviderInfo";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("62424342-b7fc-3e33-3ac5-584aff09b5cf")) == null) {
				Columns.Add(CreateIsDefaultColumn());
			}
			if (Columns.FindByUId(new Guid("720b0633-97e0-5610-11e4-1069e9372018")) == null) {
				Columns.Add(CreateProviderNameColumn());
			}
			if (Columns.FindByUId(new Guid("3ac88923-16c1-5cff-274f-e9087988ee56")) == null) {
				Columns.Add(CreateIsConnectedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsDefaultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("62424342-b7fc-3e33-3ac5-584aff09b5cf"),
				Name = @"IsDefault",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				ModifiedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("abd5e6e0-a4dc-b6d0-db8a-77df664ba511"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				ModifiedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateProviderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("720b0633-97e0-5610-11e4-1069e9372018"),
				Name = @"ProviderName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				ModifiedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5")
			};
		}

		protected virtual EntitySchemaColumn CreateIsConnectedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3ac88923-16c1-5cff-274f-e9087988ee56"),
				Name = @"IsConnected",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				ModifiedInSchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"),
				CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MailingProviderInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MailingProviderInfo_BpCloudIntegrationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MailingProviderInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MailingProviderInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb"));
		}

		#endregion

	}

	#endregion

	#region Class: MailingProviderInfo

	/// <summary>
	/// MailingProviderInfo.
	/// </summary>
	public class MailingProviderInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public MailingProviderInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MailingProviderInfo";
		}

		public MailingProviderInfo(MailingProviderInfo source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Is default.
		/// </summary>
		public bool IsDefault {
			get {
				return GetTypedColumnValue<bool>("IsDefault");
			}
			set {
				SetColumnValue("IsDefault", value);
			}
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Email provider.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		/// <summary>
		/// Is connected.
		/// </summary>
		public string IsConnected {
			get {
				return GetTypedColumnValue<string>("IsConnected");
			}
			set {
				SetColumnValue("IsConnected", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MailingProviderInfo_BpCloudIntegrationEventsProcess(UserConnection);
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
			return new MailingProviderInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: MailingProviderInfo_BpCloudIntegrationEventsProcess

	/// <exclude/>
	public partial class MailingProviderInfo_BpCloudIntegrationEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : MailingProviderInfo
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

		public MailingProviderInfo_BpCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MailingProviderInfo_BpCloudIntegrationEventsProcess";
			SchemaUId = new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e048d9e5-0fbb-43cd-9930-3bfd1c1c9acb");
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

	#region Class: MailingProviderInfo_BpCloudIntegrationEventsProcess

	/// <exclude/>
	public class MailingProviderInfo_BpCloudIntegrationEventsProcess : MailingProviderInfo_BpCloudIntegrationEventsProcess<MailingProviderInfo>
	{

		public MailingProviderInfo_BpCloudIntegrationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MailingProviderInfo_BpCloudIntegrationEventsProcess

	public partial class MailingProviderInfo_BpCloudIntegrationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MailingProviderInfoEventsProcess

	/// <exclude/>
	public class MailingProviderInfoEventsProcess : MailingProviderInfo_BpCloudIntegrationEventsProcess
	{

		public MailingProviderInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

