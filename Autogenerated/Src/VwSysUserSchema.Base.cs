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

	#region Class: VwSysUserSchema

	/// <exclude/>
	public class VwSysUserSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwSysUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysUserSchema(VwSysUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysUserSchema(VwSysUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
			RealUId = new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
			Name = "VwSysUser";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("007e35de-a16f-46c9-8e07-22ead3f1a8d9");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysUser_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9c16d882-1168-4064-8e37-145afb9369ea"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysUser

	/// <summary>
	/// Users (view).
	/// </summary>
	public class VwSysUser : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwSysUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysUser";
		}

		public VwSysUser(VwSysUser source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysUser_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysUserDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysUser_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysUser_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwSysUser
	{

		public VwSysUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysUser_BaseEventsProcess";
			SchemaUId = new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9c16d882-1168-4064-8e37-145afb9369ea");
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

	#region Class: VwSysUser_BaseEventsProcess

	/// <exclude/>
	public class VwSysUser_BaseEventsProcess : VwSysUser_BaseEventsProcess<VwSysUser>
	{

		public VwSysUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysUser_BaseEventsProcess

	public partial class VwSysUser_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysUserEventsProcess

	/// <exclude/>
	public class VwSysUserEventsProcess : VwSysUser_BaseEventsProcess
	{

		public VwSysUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

