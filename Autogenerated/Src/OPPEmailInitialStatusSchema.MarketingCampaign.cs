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

	#region Class: OPPEmailInitialStatusSchema

	/// <exclude/>
	public class OPPEmailInitialStatusSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public OPPEmailInitialStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OPPEmailInitialStatusSchema(OPPEmailInitialStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OPPEmailInitialStatusSchema(OPPEmailInitialStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375");
			RealUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375");
			Name = "OPPEmailInitialStatus";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateMandrillIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8112402a-a09e-4e26-9a73-992b9d473215")) == null) {
				Columns.Add(CreateBulkEmailIdColumn());
			}
			if (Columns.FindByUId(new Guid("9474523f-be27-443c-b923-8dd08d0b9de8")) == null) {
				Columns.Add(CreateEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("0839acab-38e4-46ec-b67d-ed88966266c0")) == null) {
				Columns.Add(CreateEmailResponseIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8112402a-a09e-4e26-9a73-992b9d473215"),
				Name = @"BulkEmailId",
				CreatedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				ModifiedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9474523f-be27-443c-b923-8dd08d0b9de8"),
				Name = @"EmailAddress",
				CreatedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				ModifiedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateMandrillIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0d048bc0-ced3-41e0-b8a9-ce13b005812b"),
				Name = @"MandrillId",
				CreatedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				ModifiedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailResponseIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0839acab-38e4-46ec-b67d-ed88966266c0"),
				Name = @"EmailResponseId",
				CreatedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				ModifiedInSchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OPPEmailInitialStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OPPEmailInitialStatus_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OPPEmailInitialStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OPPEmailInitialStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375"));
		}

		#endregion

	}

	#endregion

	#region Class: OPPEmailInitialStatus

	/// <summary>
	/// Начальное состояние получателя рассылки Email.
	/// </summary>
	public class OPPEmailInitialStatus : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OPPEmailInitialStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OPPEmailInitialStatus";
		}

		public OPPEmailInitialStatus(OPPEmailInitialStatus source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// BulkEmailId.
		/// </summary>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
			}
		}

		/// <summary>
		/// EmailAddress.
		/// </summary>
		public string EmailAddress {
			get {
				return GetTypedColumnValue<string>("EmailAddress");
			}
			set {
				SetColumnValue("EmailAddress", value);
			}
		}

		/// <summary>
		/// MandrillId.
		/// </summary>
		public Guid MandrillId {
			get {
				return GetTypedColumnValue<Guid>("MandrillId");
			}
			set {
				SetColumnValue("MandrillId", value);
			}
		}

		/// <summary>
		/// EmailResponseId.
		/// </summary>
		public Guid EmailResponseId {
			get {
				return GetTypedColumnValue<Guid>("EmailResponseId");
			}
			set {
				SetColumnValue("EmailResponseId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OPPEmailInitialStatus_MarketingCampaignEventsProcess(UserConnection);
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
			return new OPPEmailInitialStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: OPPEmailInitialStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class OPPEmailInitialStatus_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : OPPEmailInitialStatus
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

		public OPPEmailInitialStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OPPEmailInitialStatus_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("73e2e6b7-6cb4-44cd-87c2-574a1db70375");
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

	#region Class: OPPEmailInitialStatus_MarketingCampaignEventsProcess

	/// <exclude/>
	public class OPPEmailInitialStatus_MarketingCampaignEventsProcess : OPPEmailInitialStatus_MarketingCampaignEventsProcess<OPPEmailInitialStatus>
	{

		public OPPEmailInitialStatus_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OPPEmailInitialStatus_MarketingCampaignEventsProcess

	public partial class OPPEmailInitialStatus_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OPPEmailInitialStatusEventsProcess

	/// <exclude/>
	public class OPPEmailInitialStatusEventsProcess : OPPEmailInitialStatus_MarketingCampaignEventsProcess
	{

		public OPPEmailInitialStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

