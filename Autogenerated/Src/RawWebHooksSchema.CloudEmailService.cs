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

	#region Class: RawWebHooksSchema

	/// <exclude/>
	public class RawWebHooksSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public RawWebHooksSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RawWebHooksSchema(RawWebHooksSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RawWebHooksSchema(RawWebHooksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b");
			RealUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b");
			Name = "RawWebHooks";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("06435d27-8c1b-4953-b634-242d1f4c8b8a");
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
			if (Columns.FindByUId(new Guid("37a2ab22-0f14-4561-bd10-7233260dd44c")) == null) {
				Columns.Add(CreateJsonDataColumn());
			}
			if (Columns.FindByUId(new Guid("045d0116-1d9b-4c2e-b60e-4a1e86c22d87")) == null) {
				Columns.Add(CreateFailedColumn());
			}
			if (Columns.FindByUId(new Guid("bf271238-15f0-4f48-8ab5-7883fb44ae5f")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1159d54c-8b38-485c-b956-6338af9a1cd6"),
				Name = @"Id",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				ModifiedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				CreatedInPackageId = new Guid("06435d27-8c1b-4953-b634-242d1f4c8b8a")
			};
		}

		protected virtual EntitySchemaColumn CreateJsonDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("File")) {
				UId = new Guid("37a2ab22-0f14-4561-bd10-7233260dd44c"),
				Name = @"JsonData",
				CreatedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				ModifiedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				CreatedInPackageId = new Guid("06435d27-8c1b-4953-b634-242d1f4c8b8a")
			};
		}

		protected virtual EntitySchemaColumn CreateFailedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("045d0116-1d9b-4c2e-b60e-4a1e86c22d87"),
				Name = @"Failed",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				ModifiedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				CreatedInPackageId = new Guid("457f57e6-ba32-4a54-a8b9-9eba8360aae2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("bf271238-15f0-4f48-8ab5-7883fb44ae5f"),
				Name = @"Type",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				ModifiedInSchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"),
				CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new RawWebHooks(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RawWebHooks_CloudEmailServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RawWebHooksSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RawWebHooksSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b"));
		}

		#endregion

	}

	#endregion

	#region Class: RawWebHooks

	/// <summary>
	/// Необработанные WebHooks.
	/// </summary>
	public class RawWebHooks : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public RawWebHooks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RawWebHooks";
		}

		public RawWebHooks(RawWebHooks source)
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
		/// Failed.
		/// </summary>
		public bool Failed {
			get {
				return GetTypedColumnValue<bool>("Failed");
			}
			set {
				SetColumnValue("Failed", value);
			}
		}

		/// <summary>
		/// Тип.
		/// </summary>
		public int Type {
			get {
				return GetTypedColumnValue<int>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RawWebHooks_CloudEmailServiceEventsProcess(UserConnection);
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
			return new RawWebHooks(this);
		}

		#endregion

	}

	#endregion

	#region Class: RawWebHooks_CloudEmailServiceEventsProcess

	/// <exclude/>
	public partial class RawWebHooks_CloudEmailServiceEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : RawWebHooks
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

		public RawWebHooks_CloudEmailServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RawWebHooks_CloudEmailServiceEventsProcess";
			SchemaUId = new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cc25f38e-a08b-41eb-95a9-57c6acbee09b");
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

	#region Class: RawWebHooks_CloudEmailServiceEventsProcess

	/// <exclude/>
	public class RawWebHooks_CloudEmailServiceEventsProcess : RawWebHooks_CloudEmailServiceEventsProcess<RawWebHooks>
	{

		public RawWebHooks_CloudEmailServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RawWebHooks_CloudEmailServiceEventsProcess

	public partial class RawWebHooks_CloudEmailServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RawWebHooksEventsProcess

	/// <exclude/>
	public class RawWebHooksEventsProcess : RawWebHooks_CloudEmailServiceEventsProcess
	{

		public RawWebHooksEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

