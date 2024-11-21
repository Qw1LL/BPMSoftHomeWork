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

	#region Class: ChangePrioritySchema

	/// <exclude/>
	public class ChangePrioritySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChangePrioritySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangePrioritySchema(ChangePrioritySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangePrioritySchema(ChangePrioritySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			RealUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			Name = "ChangePriority";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ChangePriority(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangePriority_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangePrioritySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangePrioritySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6138a110-3724-4428-9c3c-cb1930f0811a"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangePriority

	/// <summary>
	/// Приоритет изменения.
	/// </summary>
	public class ChangePriority : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChangePriority(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangePriority";
		}

		public ChangePriority(ChangePriority source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangePriority_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangePriorityDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangePriorityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangePriority(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangePriority_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangePriority_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChangePriority
	{

		public ChangePriority_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangePriority_ChangeEventsProcess";
			SchemaUId = new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6138a110-3724-4428-9c3c-cb1930f0811a");
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

	#region Class: ChangePriority_ChangeEventsProcess

	/// <exclude/>
	public class ChangePriority_ChangeEventsProcess : ChangePriority_ChangeEventsProcess<ChangePriority>
	{

		public ChangePriority_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangePriority_ChangeEventsProcess

	public partial class ChangePriority_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangePriorityEventsProcess

	/// <exclude/>
	public class ChangePriorityEventsProcess : ChangePriority_ChangeEventsProcess
	{

		public ChangePriorityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

