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

	#region Class: ChangePurposeSchema

	/// <exclude/>
	public class ChangePurposeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChangePurposeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangePurposeSchema(ChangePurposeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangePurposeSchema(ChangePurposeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			RealUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			Name = "ChangePurpose";
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
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
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
			return new ChangePurpose(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangePurpose_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangePurposeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangePurposeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangePurpose

	/// <summary>
	/// Цель изменения.
	/// </summary>
	public class ChangePurpose : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChangePurpose(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangePurpose";
		}

		public ChangePurpose(ChangePurpose source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangePurpose_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangePurposeDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangePurposeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangePurpose(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangePurpose_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangePurpose_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChangePurpose
	{

		public ChangePurpose_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangePurpose_ChangeEventsProcess";
			SchemaUId = new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9877f383-7ab3-4fd9-b0d1-30e0480fae61");
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

	#region Class: ChangePurpose_ChangeEventsProcess

	/// <exclude/>
	public class ChangePurpose_ChangeEventsProcess : ChangePurpose_ChangeEventsProcess<ChangePurpose>
	{

		public ChangePurpose_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangePurpose_ChangeEventsProcess

	public partial class ChangePurpose_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangePurposeEventsProcess

	/// <exclude/>
	public class ChangePurposeEventsProcess : ChangePurpose_ChangeEventsProcess
	{

		public ChangePurposeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

