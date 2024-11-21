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
	using BPMSoft.Core.OperationLog;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using BPMSoft.Web.Common;
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

	#region Class: SysUserInRoleSchema

	/// <exclude/>
	public class SysUserInRoleSchema : BPMSoft.Configuration.SysUserInRole_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysUserInRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUserInRoleSchema(SysUserInRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUserInRoleSchema(SysUserInRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("1ea0be86-c964-41da-822d-4dfafe084e31");
			Name = "SysUserInRole";
			ParentSchemaUId = new Guid("4b27f502-c296-47cf-af5d-3197d54e0d2a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("efb6fc64-47cd-46f8-840c-96c0bb0b6306");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysUserInRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUserInRole_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUserInRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUserInRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ea0be86-c964-41da-822d-4dfafe084e31"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUserInRole

	/// <summary>
	/// User in roles.
	/// </summary>
	public class SysUserInRole : BPMSoft.Configuration.SysUserInRole_Base_BPMSoft
	{

		#region Constructors: Public

		public SysUserInRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUserInRole";
		}

		public SysUserInRole(SysUserInRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUserInRole_UIv2EventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysUserInRoleDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysUserInRoleDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysUserInRoleInserted", e);
			Validating += (s, e) => ThrowEvent("SysUserInRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysUserInRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUserInRole_UIv2EventsProcess

	/// <exclude/>
	public partial class SysUserInRole_UIv2EventsProcess<TEntity> : BPMSoft.Configuration.SysUserInRole_BaseEventsProcess<TEntity> where TEntity : SysUserInRole
	{

		public SysUserInRole_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUserInRole_UIv2EventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1ea0be86-c964-41da-822d-4dfafe084e31");
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

	#region Class: SysUserInRole_UIv2EventsProcess

	/// <exclude/>
	public class SysUserInRole_UIv2EventsProcess : SysUserInRole_UIv2EventsProcess<SysUserInRole>
	{

		public SysUserInRole_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUserInRole_UIv2EventsProcess

	public partial class SysUserInRole_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUserInRoleEventsProcess

	/// <exclude/>
	public class SysUserInRoleEventsProcess : SysUserInRole_UIv2EventsProcess
	{

		public SysUserInRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

