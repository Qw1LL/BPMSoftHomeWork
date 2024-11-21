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

	#region Class: VwSysSchemaExtendingSchema

	/// <exclude/>
	public class VwSysSchemaExtendingSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysSchemaExtendingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaExtendingSchema(VwSysSchemaExtendingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaExtendingSchema(VwSysSchemaExtendingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67");
			RealUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67");
			Name = "VwSysSchemaExtending";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateBaseSchemaIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTopExtendingCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cb598230-8d89-ed49-124d-8f280990999d")) == null) {
				Columns.Add(CreateTopExtendingSchemaIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTopExtendingSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cb598230-8d89-ed49-124d-8f280990999d"),
				Name = @"TopExtendingSchemaId",
				CreatedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				ModifiedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateBaseSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("049ee76b-194a-cf70-0f0e-a2c670fc254d"),
				Name = @"BaseSchemaId",
				CreatedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				ModifiedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateTopExtendingCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("579906fb-fbe4-cd29-6c45-1c867ca8a2cd"),
				Name = @"TopExtendingCaption",
				CreatedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				ModifiedInSchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSchemaExtending(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaExtending_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaExtendingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaExtendingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("58474b1f-f909-42bc-8663-5dc081875a67"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaExtending

	/// <summary>
	/// VwSysSchemaExtending (View).
	/// </summary>
	public class VwSysSchemaExtending : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysSchemaExtending(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaExtending";
		}

		public VwSysSchemaExtending(VwSysSchemaExtending source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TopExtendingSchemaId.
		/// </summary>
		public Guid TopExtendingSchemaId {
			get {
				return GetTypedColumnValue<Guid>("TopExtendingSchemaId");
			}
			set {
				SetColumnValue("TopExtendingSchemaId", value);
			}
		}

		/// <summary>
		/// BaseSchemaId.
		/// </summary>
		public Guid BaseSchemaId {
			get {
				return GetTypedColumnValue<Guid>("BaseSchemaId");
			}
			set {
				SetColumnValue("BaseSchemaId", value);
			}
		}

		/// <summary>
		/// TopExtendingCaption.
		/// </summary>
		public string TopExtendingCaption {
			get {
				return GetTypedColumnValue<string>("TopExtendingCaption");
			}
			set {
				SetColumnValue("TopExtendingCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaExtending_BaseEventsProcess(UserConnection);
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
			return new VwSysSchemaExtending(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaExtending_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaExtending_BaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwSysSchemaExtending
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

		public VwSysSchemaExtending_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaExtending_BaseEventsProcess";
			SchemaUId = new Guid("58474b1f-f909-42bc-8663-5dc081875a67");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("58474b1f-f909-42bc-8663-5dc081875a67");
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

	#region Class: VwSysSchemaExtending_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaExtending_BaseEventsProcess : VwSysSchemaExtending_BaseEventsProcess<VwSysSchemaExtending>
	{

		public VwSysSchemaExtending_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaExtending_BaseEventsProcess

	public partial class VwSysSchemaExtending_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaExtendingEventsProcess

	/// <exclude/>
	public class VwSysSchemaExtendingEventsProcess : VwSysSchemaExtending_BaseEventsProcess
	{

		public VwSysSchemaExtendingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

