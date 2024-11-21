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

	#region Class: CmpgnPrtcpntEmailTargetOpSchema

	/// <exclude/>
	public class CmpgnPrtcpntEmailTargetOpSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public CmpgnPrtcpntEmailTargetOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CmpgnPrtcpntEmailTargetOpSchema(CmpgnPrtcpntEmailTargetOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CmpgnPrtcpntEmailTargetOpSchema(CmpgnPrtcpntEmailTargetOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61");
			RealUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61");
			Name = "CmpgnPrtcpntEmailTargetOp";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateMandrillRecipientUIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateMandrillRecipientUIdColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0c270820-432a-47af-9840-4b0496b336db")) == null) {
				Columns.Add(CreateCampaignParticipantIdColumn());
			}
			if (Columns.FindByUId(new Guid("729e0fb9-50c9-41f5-98b1-db1f0b1e8435")) == null) {
				Columns.Add(CreateBulkEmailIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMandrillRecipientUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("84ad9018-b52d-454d-821a-d30ed2a3d98d"),
				Name = @"MandrillRecipientUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				ModifiedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignParticipantIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0c270820-432a-47af-9840-4b0496b336db"),
				Name = @"CampaignParticipantId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				ModifiedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("729e0fb9-50c9-41f5-98b1-db1f0b1e8435"),
				Name = @"BulkEmailId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				ModifiedInSchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CmpgnPrtcpntEmailTargetOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CmpgnPrtcpntEmailTargetOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CmpgnPrtcpntEmailTargetOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61"));
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnPrtcpntEmailTargetOp

	/// <summary>
	/// Сущность для связи операционных участников кампании и получателей рассылки.
	/// </summary>
	public class CmpgnPrtcpntEmailTargetOp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CmpgnPrtcpntEmailTargetOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnPrtcpntEmailTargetOp";
		}

		public CmpgnPrtcpntEmailTargetOp(CmpgnPrtcpntEmailTargetOp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// MandrillRecipientUId.
		/// </summary>
		public Guid MandrillRecipientUId {
			get {
				return GetTypedColumnValue<Guid>("MandrillRecipientUId");
			}
			set {
				SetColumnValue("MandrillRecipientUId", value);
			}
		}

		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
			}
		}

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess(UserConnection);
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
			return new CmpgnPrtcpntEmailTargetOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess

	/// <exclude/>
	public partial class CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : CmpgnPrtcpntEmailTargetOp
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

		public CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess";
			SchemaUId = new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("db6ddc59-17bc-4017-984b-55d8c7895d61");
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

	#region Class: CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess

	/// <exclude/>
	public class CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess : CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess<CmpgnPrtcpntEmailTargetOp>
	{

		public CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess

	public partial class CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CmpgnPrtcpntEmailTargetOpEventsProcess

	/// <exclude/>
	public class CmpgnPrtcpntEmailTargetOpEventsProcess : CmpgnPrtcpntEmailTargetOp_CampaignsEventsProcess
	{

		public CmpgnPrtcpntEmailTargetOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

