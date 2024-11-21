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

	#region Class: ActiveUsersStatisticsSchema

	/// <exclude/>
	public class ActiveUsersStatisticsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActiveUsersStatisticsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActiveUsersStatisticsSchema(ActiveUsersStatisticsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActiveUsersStatisticsSchema(ActiveUsersStatisticsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("823d5bcd-4182-4861-8aae-79e161488314");
			RealUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314");
			Name = "ActiveUsersStatistics";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9bc31d68-ab77-9f2a-327a-766c151e7248")) == null) {
				Columns.Add(CreateDateValueColumn());
			}
			if (Columns.FindByUId(new Guid("6c2f0fa6-1c78-e7ed-b981-d87f185bf87d")) == null) {
				Columns.Add(CreateSessionCountColumn());
			}
			if (Columns.FindByUId(new Guid("376c2715-af57-af9c-c4e9-de71bfe1e701")) == null) {
				Columns.Add(CreateSysUserCountColumn());
			}
			if (Columns.FindByUId(new Guid("2834c8a2-01f7-a1e9-6bc8-35e633d17fe3")) == null) {
				Columns.Add(CreatePortalUserCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9bc31d68-ab77-9f2a-327a-766c151e7248"),
				Name = @"DateValue",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				ModifiedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSessionCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6c2f0fa6-1c78-e7ed-b981-d87f185bf87d"),
				Name = @"SessionCount",
				CreatedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				ModifiedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("376c2715-af57-af9c-c4e9-de71bfe1e701"),
				Name = @"SysUserCount",
				CreatedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				ModifiedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreatePortalUserCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2834c8a2-01f7-a1e9-6bc8-35e633d17fe3"),
				Name = @"PortalUserCount",
				CreatedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
				ModifiedInSchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314"),
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
			return new ActiveUsersStatistics(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActiveUsersStatistics_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActiveUsersStatisticsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActiveUsersStatisticsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("823d5bcd-4182-4861-8aae-79e161488314"));
		}

		#endregion

	}

	#endregion

	#region Class: ActiveUsersStatistics

	/// <summary>
	/// Active users statistics.
	/// </summary>
	public class ActiveUsersStatistics : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActiveUsersStatistics(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActiveUsersStatistics";
		}

		public ActiveUsersStatistics(ActiveUsersStatistics source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Date/Time.
		/// </summary>
		public DateTime DateValue {
			get {
				return GetTypedColumnValue<DateTime>("DateValue");
			}
			set {
				SetColumnValue("DateValue", value);
			}
		}

		/// <summary>
		/// Session count.
		/// </summary>
		public int SessionCount {
			get {
				return GetTypedColumnValue<int>("SessionCount");
			}
			set {
				SetColumnValue("SessionCount", value);
			}
		}

		/// <summary>
		/// System user count.
		/// </summary>
		public int SysUserCount {
			get {
				return GetTypedColumnValue<int>("SysUserCount");
			}
			set {
				SetColumnValue("SysUserCount", value);
			}
		}

		/// <summary>
		/// Portal user count.
		/// </summary>
		public int PortalUserCount {
			get {
				return GetTypedColumnValue<int>("PortalUserCount");
			}
			set {
				SetColumnValue("PortalUserCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActiveUsersStatistics_BaseEventsProcess(UserConnection);
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
			return new ActiveUsersStatistics(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActiveUsersStatistics_BaseEventsProcess

	/// <exclude/>
	public partial class ActiveUsersStatistics_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ActiveUsersStatistics
	{

		public ActiveUsersStatistics_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActiveUsersStatistics_BaseEventsProcess";
			SchemaUId = new Guid("823d5bcd-4182-4861-8aae-79e161488314");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("823d5bcd-4182-4861-8aae-79e161488314");
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

	#region Class: ActiveUsersStatistics_BaseEventsProcess

	/// <exclude/>
	public class ActiveUsersStatistics_BaseEventsProcess : ActiveUsersStatistics_BaseEventsProcess<ActiveUsersStatistics>
	{

		public ActiveUsersStatistics_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActiveUsersStatistics_BaseEventsProcess

	public partial class ActiveUsersStatistics_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActiveUsersStatisticsEventsProcess

	/// <exclude/>
	public class ActiveUsersStatisticsEventsProcess : ActiveUsersStatistics_BaseEventsProcess
	{

		public ActiveUsersStatisticsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

