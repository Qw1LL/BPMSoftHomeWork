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

	#region Class: StageLogBaseSchema

	/// <exclude/>
	[IsVirtual]
	public class StageLogBaseSchema : BPMSoft.Configuration.SysSchemaPropertySchema
	{

		#region Constructors: Public

		public StageLogBaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public StageLogBaseSchema(StageLogBaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public StageLogBaseSchema(StageLogBaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e");
			RealUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e");
			Name = "StageLogBase";
			ParentSchemaUId = new Guid("477e2c73-d48b-4a5d-9a46-d1ee851f1bde");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7320f200-b563-4711-a597-53bba810bd7b")) == null) {
				Columns.Add(CreateRootEntityColumn());
			}
			if (Columns.FindByUId(new Guid("0ccb40bd-781c-410f-a2b1-8454c1c0d112")) == null) {
				Columns.Add(CreateStageColumn());
			}
			if (Columns.FindByUId(new Guid("73563dd9-6ecd-4c9e-ab15-d2029cb3852c")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("a98f7382-4fd9-475e-8534-951eb325cd5b")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("07570ba7-9860-40f9-9270-46d4e1b487eb")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("18fafc11-2e6f-4874-8173-bb65967c4f90")) == null) {
				Columns.Add(CreateHistoricalColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRootEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7320f200-b563-4711-a597-53bba810bd7b"),
				Name = @"RootEntity",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0ccb40bd-781c-410f-a2b1-8454c1c0d112"),
				Name = @"Stage",
				ReferenceSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("73563dd9-6ecd-4c9e-ab15-d2029cb3852c"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("a98f7382-4fd9-475e-8534-951eb325cd5b"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("07570ba7-9860-40f9-9270-46d4e1b487eb"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected virtual EntitySchemaColumn CreateHistoricalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("18fafc11-2e6f-4874-8173-bb65967c4f90"),
				Name = @"Historical",
				CreatedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				ModifiedInSchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"),
				CreatedInPackageId = new Guid("7e406f3f-0514-4d14-a20b-c3a59a45194f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new StageLogBase(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new StageLogBase_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new StageLogBaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new StageLogBaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e"));
		}

		#endregion

	}

	#endregion

	#region Class: StageLogBase

	/// <summary>
	/// Stage log base.
	/// </summary>
	public class StageLogBase : BPMSoft.Configuration.SysSchemaProperty
	{

		#region Constructors: Public

		public StageLogBase(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "StageLogBase";
		}

		public StageLogBase(StageLogBase source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid RootEntityId {
			get {
				return GetTypedColumnValue<Guid>("RootEntityId");
			}
			set {
				SetColumnValue("RootEntityId", value);
				_rootEntity = null;
			}
		}

		/// <exclude/>
		public string RootEntityName {
			get {
				return GetTypedColumnValue<string>("RootEntityName");
			}
			set {
				SetColumnValue("RootEntityName", value);
				if (_rootEntity != null) {
					_rootEntity.Name = value;
				}
			}
		}

		private Lookup _rootEntity;
		/// <summary>
		/// Logged object.
		/// </summary>
		public Lookup RootEntity {
			get {
				return _rootEntity ??
					(_rootEntity = LookupColumnEntities.GetEntity("RootEntity") as Lookup);
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private Lookup _stage;
		/// <summary>
		/// Stage.
		/// </summary>
		public Lookup Stage {
			get {
				return _stage ??
					(_stage = LookupColumnEntities.GetEntity("Stage") as Lookup);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Due date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Is historical.
		/// </summary>
		public bool Historical {
			get {
				return GetTypedColumnValue<bool>("Historical");
			}
			set {
				SetColumnValue("Historical", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new StageLogBase_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("StageLogBaseDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new StageLogBase(this);
		}

		#endregion

	}

	#endregion

	#region Class: StageLogBase_BaseEventsProcess

	/// <exclude/>
	public partial class StageLogBase_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysSchemaProperty_BaseEventsProcess<TEntity> where TEntity : StageLogBase
	{

		public StageLogBase_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StageLogBase_BaseEventsProcess";
			SchemaUId = new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f57bf9d0-7c37-49a9-843f-c0f5125de77e");
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

	#region Class: StageLogBase_BaseEventsProcess

	/// <exclude/>
	public class StageLogBase_BaseEventsProcess : StageLogBase_BaseEventsProcess<StageLogBase>
	{

		public StageLogBase_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: StageLogBase_BaseEventsProcess

	public partial class StageLogBase_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: StageLogBaseEventsProcess

	/// <exclude/>
	public class StageLogBaseEventsProcess : StageLogBase_BaseEventsProcess
	{

		public StageLogBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

