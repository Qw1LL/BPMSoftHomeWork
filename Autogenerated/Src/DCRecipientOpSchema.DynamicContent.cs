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

	#region Class: DCRecipientOpSchema

	/// <exclude/>
	public class DCRecipientOpSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public DCRecipientOpSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DCRecipientOpSchema(DCRecipientOpSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DCRecipientOpSchema(DCRecipientOpSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b");
			RealUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b");
			Name = "DCRecipientOp";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e");
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

		protected override void InitializeCreatedOnColumn() {
			base.InitializeCreatedOnColumn();
			CreatedOnColumn = CreateCreatedOnColumn();
			if (Columns.FindByUId(CreatedOnColumn.UId) == null) {
				Columns.Add(CreatedOnColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0271e50d-07a0-4739-9048-02b00541f2d7")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("2fc35ef9-598b-4ecb-8044-1634f1ee6b89")) == null) {
				Columns.Add(CreateGroupIndexColumn());
			}
			if (Columns.FindByUId(new Guid("c3ff036e-fe55-40cf-a601-3846630e8472")) == null) {
				Columns.Add(CreateBlockIndexColumn());
			}
			if (Columns.FindByUId(new Guid("9b0e1c58-6390-4d11-adb2-9ec34dbce770")) == null) {
				Columns.Add(CreateSessionIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fad90b97-1ecf-4ad6-ab7d-a015c610cc80"),
				Name = @"Id",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0271e50d-07a0-4739-9048-02b00541f2d7"),
				Name = @"EntityId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateGroupIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2fc35ef9-598b-4ecb-8044-1634f1ee6b89"),
				Name = @"GroupIndex",
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateBlockIndexColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c3ff036e-fe55-40cf-a601-3846630e8472"),
				Name = @"BlockIndex",
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ff5c7938-0b69-41c1-9f48-12e2f2845432"),
				Name = @"CreatedOn",
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9b0e1c58-6390-4d11-adb2-9ec34dbce770"),
				Name = @"SessionId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				ModifiedInSchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"),
				CreatedInPackageId = new Guid("6814f243-a95c-4904-a4a6-be6dfa209a4e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DCRecipientOp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DCRecipientOp_DynamicContentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DCRecipientOpSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DCRecipientOpSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b"));
		}

		#endregion

	}

	#endregion

	#region Class: DCRecipientOp

	/// <summary>
	/// DCRecipientOp.
	/// </summary>
	public class DCRecipientOp : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DCRecipientOp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DCRecipientOp";
		}

		public DCRecipientOp(DCRecipientOp source)
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

		/// <summary>
		/// EntityId.
		/// </summary>
		/// <remarks>
		/// An identifier of recipient.
		/// </remarks>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// GroupIndex.
		/// </summary>
		public int GroupIndex {
			get {
				return GetTypedColumnValue<int>("GroupIndex");
			}
			set {
				SetColumnValue("GroupIndex", value);
			}
		}

		/// <summary>
		/// BlockIndex.
		/// </summary>
		public int BlockIndex {
			get {
				return GetTypedColumnValue<int>("BlockIndex");
			}
			set {
				SetColumnValue("BlockIndex", value);
			}
		}

		/// <summary>
		/// CreatedOn.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// SessionId.
		/// </summary>
		/// <remarks>
		/// An identifier of the segmentation session.
		/// </remarks>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DCRecipientOp_DynamicContentEventsProcess(UserConnection);
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
			return new DCRecipientOp(this);
		}

		#endregion

	}

	#endregion

	#region Class: DCRecipientOp_DynamicContentEventsProcess

	/// <exclude/>
	public partial class DCRecipientOp_DynamicContentEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : DCRecipientOp
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

		public DCRecipientOp_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DCRecipientOp_DynamicContentEventsProcess";
			SchemaUId = new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0da6b6d7-362d-4135-a5d9-7a7884ca328b");
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

	#region Class: DCRecipientOp_DynamicContentEventsProcess

	/// <exclude/>
	public class DCRecipientOp_DynamicContentEventsProcess : DCRecipientOp_DynamicContentEventsProcess<DCRecipientOp>
	{

		public DCRecipientOp_DynamicContentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DCRecipientOp_DynamicContentEventsProcess

	public partial class DCRecipientOp_DynamicContentEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DCRecipientOpEventsProcess

	/// <exclude/>
	public class DCRecipientOpEventsProcess : DCRecipientOp_DynamicContentEventsProcess
	{

		public DCRecipientOpEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

