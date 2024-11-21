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

	#region Class: WSysAccountRoleSchema

	/// <exclude/>
	public class WSysAccountRoleSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public WSysAccountRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSysAccountRoleSchema(WSysAccountRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSysAccountRoleSchema(WSysAccountRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			RealUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			Name = "WSysAccountRole";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSysAccountRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSysAccountRole_WbCollaborationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSysAccountRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSysAccountRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9"));
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountRole

	/// <summary>
	/// Wb user role.
	/// </summary>
	public class WSysAccountRole : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public WSysAccountRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSysAccountRole";
		}

		public WSysAccountRole(WSysAccountRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSysAccountRole_WbCollaborationsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSysAccountRoleDeleted", e);
			Inserting += (s, e) => ThrowEvent("WSysAccountRoleInserting", e);
			Validating += (s, e) => ThrowEvent("WSysAccountRoleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSysAccountRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccountRole_WbCollaborationsEventsProcess

	/// <exclude/>
	public partial class WSysAccountRole_WbCollaborationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : WSysAccountRole
	{

		public WSysAccountRole_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSysAccountRole_WbCollaborationsEventsProcess";
			SchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9");
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

	#region Class: WSysAccountRole_WbCollaborationsEventsProcess

	/// <exclude/>
	public class WSysAccountRole_WbCollaborationsEventsProcess : WSysAccountRole_WbCollaborationsEventsProcess<WSysAccountRole>
	{

		public WSysAccountRole_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSysAccountRole_WbCollaborationsEventsProcess

	public partial class WSysAccountRole_WbCollaborationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSysAccountRoleEventsProcess

	/// <exclude/>
	public class WSysAccountRoleEventsProcess : WSysAccountRole_WbCollaborationsEventsProcess
	{

		public WSysAccountRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

