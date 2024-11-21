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

	#region Class: SysModuleReportLczOldSchema

	/// <exclude/>
	public class SysModuleReportLczOldSchema : BPMSoft.Configuration.BaseLczEntitySchema
	{

		#region Constructors: Public

		public SysModuleReportLczOldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleReportLczOldSchema(SysModuleReportLczOldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleReportLczOldSchema(SysModuleReportLczOldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695");
			RealUId = new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695");
			Name = "SysModuleReportLczOld";
			ParentSchemaUId = new Guid("b7cd8e8f-a017-4f73-b1fe-efb9e938e1d2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateRecordColumn() {
			EntitySchemaColumn column = base.CreateRecordColumn();
			column.ReferenceSchemaUId = new Guid("0a62cd3d-6541-4c5c-903f-e5b0fc665297");
			column.ColumnValueName = @"RecordId";
			column.DisplayColumnValueName = @"RecordCaption";
			column.ModifiedInSchemaUId = new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleReportLczOld(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleReportLczOld_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleReportLczOldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleReportLczOldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportLczOld

	/// <summary>
	/// SysModuleReport localization table.
	/// </summary>
	public class SysModuleReportLczOld : BPMSoft.Configuration.BaseLczEntity
	{

		#region Constructors: Public

		public SysModuleReportLczOld(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportLczOld";
		}

		public SysModuleReportLczOld(SysModuleReportLczOld source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleReportLczOld_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleReportLczOldDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleReportLczOldInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleReportLczOldValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleReportLczOld(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportLczOld_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleReportLczOld_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLczEntity_BaseEventsProcess<TEntity> where TEntity : SysModuleReportLczOld
	{

		public SysModuleReportLczOld_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleReportLczOld_BaseEventsProcess";
			SchemaUId = new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f92f7ed4-6682-4428-b25f-4995e7dc4695");
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

	#region Class: SysModuleReportLczOld_BaseEventsProcess

	/// <exclude/>
	public class SysModuleReportLczOld_BaseEventsProcess : SysModuleReportLczOld_BaseEventsProcess<SysModuleReportLczOld>
	{

		public SysModuleReportLczOld_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleReportLczOld_BaseEventsProcess

	public partial class SysModuleReportLczOld_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleReportLczOldEventsProcess

	/// <exclude/>
	public class SysModuleReportLczOldEventsProcess : SysModuleReportLczOld_BaseEventsProcess
	{

		public SysModuleReportLczOldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

