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

	#region Class: RawMandrillEventSchema

	/// <exclude/>
	public class RawMandrillEventSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public RawMandrillEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RawMandrillEventSchema(RawMandrillEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RawMandrillEventSchema(RawMandrillEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc");
			RealUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc");
			Name = "RawMandrillEvent";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
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
			if (Columns.FindByUId(new Guid("e05e8c5a-ccee-466c-9970-cffee53d9667")) == null) {
				Columns.Add(CreateJsonDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f271f2ab-e555-4ca7-b2a6-2afba1c7425a"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc"),
				ModifiedInSchemaUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected virtual EntitySchemaColumn CreateJsonDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("File")) {
				UId = new Guid("e05e8c5a-ccee-466c-9970-cffee53d9667"),
				Name = @"JsonData",
				CreatedInSchemaUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc"),
				ModifiedInSchemaUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RawMandrillEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RawMandrillEvent_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RawMandrillEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RawMandrillEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc"));
		}

		#endregion

	}

	#endregion

	#region Class: RawMandrillEvent

	/// <summary>
	/// Предобработаные события Mandrill.
	/// </summary>
	public class RawMandrillEvent : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RawMandrillEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RawMandrillEvent";
		}

		public RawMandrillEvent(RawMandrillEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RawMandrillEvent_MarketingCampaignEventsProcess(UserConnection);
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
			return new RawMandrillEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: RawMandrillEvent_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class RawMandrillEvent_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : RawMandrillEvent
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

		public RawMandrillEvent_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RawMandrillEvent_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0806fb23-ad70-4e20-86cc-f48306bf4bcc");
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

	#region Class: RawMandrillEvent_MarketingCampaignEventsProcess

	/// <exclude/>
	public class RawMandrillEvent_MarketingCampaignEventsProcess : RawMandrillEvent_MarketingCampaignEventsProcess<RawMandrillEvent>
	{

		public RawMandrillEvent_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RawMandrillEvent_MarketingCampaignEventsProcess

	public partial class RawMandrillEvent_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RawMandrillEventEventsProcess

	/// <exclude/>
	public class RawMandrillEventEventsProcess : RawMandrillEvent_MarketingCampaignEventsProcess
	{

		public RawMandrillEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

