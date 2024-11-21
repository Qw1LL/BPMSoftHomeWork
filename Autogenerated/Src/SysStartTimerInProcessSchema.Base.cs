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

	#region Class: SysStartTimerInProcessSchema

	/// <exclude/>
	public class SysStartTimerInProcessSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysStartTimerInProcessSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysStartTimerInProcessSchema(SysStartTimerInProcessSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysStartTimerInProcessSchema(SysStartTimerInProcessSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77");
			RealUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77");
			Name = "SysStartTimerInProcess";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c7d6aeee-7704-4255-afb9-8edf10fdc6c5")) == null) {
				Columns.Add(CreateProcessUIdColumn());
			}
			if (Columns.FindByUId(new Guid("2067d409-40de-4fd6-9091-8e25f4f36409")) == null) {
				Columns.Add(CreateExpressionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("47eddb1e-6105-429a-8985-378b14346061")) == null) {
				Columns.Add(CreateProcessElementUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateProcessUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c7d6aeee-7704-4255-afb9-8edf10fdc6c5"),
				Name = @"ProcessUId",
				CreatedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				ModifiedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateExpressionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2067d409-40de-4fd6-9091-8e25f4f36409"),
				Name = @"ExpressionType",
				CreatedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				ModifiedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("47eddb1e-6105-429a-8985-378b14346061"),
				Name = @"ProcessElementUId",
				CreatedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				ModifiedInSchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysStartTimerInProcess(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysStartTimerInProcess_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysStartTimerInProcessSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysStartTimerInProcessSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77"));
		}

		#endregion

	}

	#endregion

	#region Class: SysStartTimerInProcess

	/// <summary>
	/// Start timer in process.
	/// </summary>
	public class SysStartTimerInProcess : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysStartTimerInProcess(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysStartTimerInProcess";
		}

		public SysStartTimerInProcess(SysStartTimerInProcess source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Process uId.
		/// </summary>
		public Guid ProcessUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessUId");
			}
			set {
				SetColumnValue("ProcessUId", value);
			}
		}

		/// <summary>
		/// Cron expression type.
		/// </summary>
		public int ExpressionType {
			get {
				return GetTypedColumnValue<int>("ExpressionType");
			}
			set {
				SetColumnValue("ExpressionType", value);
			}
		}

		/// <summary>
		/// Process element uId.
		/// </summary>
		public Guid ProcessElementUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessElementUId");
			}
			set {
				SetColumnValue("ProcessElementUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysStartTimerInProcess_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysStartTimerInProcessDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysStartTimerInProcess(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysStartTimerInProcess_BaseEventsProcess

	/// <exclude/>
	public partial class SysStartTimerInProcess_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysStartTimerInProcess
	{

		public SysStartTimerInProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysStartTimerInProcess_BaseEventsProcess";
			SchemaUId = new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1aa43bbf-3a27-4c04-a7a3-ec66532e5e77");
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

	#region Class: SysStartTimerInProcess_BaseEventsProcess

	/// <exclude/>
	public class SysStartTimerInProcess_BaseEventsProcess : SysStartTimerInProcess_BaseEventsProcess<SysStartTimerInProcess>
	{

		public SysStartTimerInProcess_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysStartTimerInProcess_BaseEventsProcess

	public partial class SysStartTimerInProcess_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysStartTimerInProcessEventsProcess

	/// <exclude/>
	public class SysStartTimerInProcessEventsProcess : SysStartTimerInProcess_BaseEventsProcess
	{

		public SysStartTimerInProcessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

