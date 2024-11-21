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

	#region Class: MainParamLczOldSchema

	/// <exclude/>
	public class MainParamLczOldSchema : BPMSoft.Configuration.BaseLczEntitySchema
	{

		#region Constructors: Public

		public MainParamLczOldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MainParamLczOldSchema(MainParamLczOldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MainParamLczOldSchema(MainParamLczOldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			RealUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			Name = "MainParamLczOld";
			ParentSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateRecordColumn() {
			EntitySchemaColumn column = base.CreateRecordColumn();
			column.ReferenceSchemaUId = new Guid("28f7da1a-3f4d-4f2d-9d25-75c965cded5d");
			column.ColumnValueName = @"RecordId";
			column.DisplayColumnValueName = @"RecordName";
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateColumnUIdColumn() {
			EntitySchemaColumn column = base.CreateColumnUIdColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateSysCultureColumn() {
			EntitySchemaColumn column = base.CreateSysCultureColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override EntitySchemaColumn CreateValueColumn() {
			EntitySchemaColumn column = base.CreateValueColumn();
			column.ModifiedInSchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			column.CreatedInPackageId = new Guid("5af8fc1f-99e6-4265-b65c-5e9401c4c7dd");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MainParamLczOld(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MainParamLczOld_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MainParamLczOldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MainParamLczOldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b"));
		}

		#endregion

	}

	#endregion

	#region Class: MainParamLczOld

	/// <summary>
	/// MainParam localization table.
	/// </summary>
	public class MainParamLczOld : BPMSoft.Configuration.BaseLczEntity
	{

		#region Constructors: Public

		public MainParamLczOld(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MainParamLczOld";
		}

		public MainParamLczOld(MainParamLczOld source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MainParamLczOld_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MainParamLczOldDeleted", e);
			Inserting += (s, e) => ThrowEvent("MainParamLczOldInserting", e);
			Validating += (s, e) => ThrowEvent("MainParamLczOldValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MainParamLczOld(this);
		}

		#endregion

	}

	#endregion

	#region Class: MainParamLczOld_NUIEventsProcess

	/// <exclude/>
	public partial class MainParamLczOld_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseLczEntity_BaseEventsProcess<TEntity> where TEntity : MainParamLczOld
	{

		public MainParamLczOld_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MainParamLczOld_NUIEventsProcess";
			SchemaUId = new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("24164caf-0471-406d-b77c-f47b1b4abc1b");
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

	#region Class: MainParamLczOld_NUIEventsProcess

	/// <exclude/>
	public class MainParamLczOld_NUIEventsProcess : MainParamLczOld_NUIEventsProcess<MainParamLczOld>
	{

		public MainParamLczOld_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MainParamLczOld_NUIEventsProcess

	public partial class MainParamLczOld_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MainParamLczOldEventsProcess

	/// <exclude/>
	public class MainParamLczOldEventsProcess : MainParamLczOld_NUIEventsProcess
	{

		public MainParamLczOldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

