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

	#region Class: SysModuleLczOldSchema

	/// <exclude/>
	public class SysModuleLczOldSchema : BPMSoft.Configuration.BaseLczEntitySchema
	{

		#region Constructors: Public

		public SysModuleLczOldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleLczOldSchema(SysModuleLczOldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleLczOldSchema(SysModuleLczOldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a665c53-5089-415c-8119-55ba054b0892");
			RealUId = new Guid("7a665c53-5089-415c-8119-55ba054b0892");
			Name = "SysModuleLczOld";
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
			column.ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			column.ColumnValueName = @"RecordId";
			column.DisplayColumnValueName = @"RecordCaption";
			column.ModifiedInSchemaUId = new Guid("7a665c53-5089-415c-8119-55ba054b0892");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleLczOld(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleLczOld_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleLczOldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleLczOldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a665c53-5089-415c-8119-55ba054b0892"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleLczOld

	/// <summary>
	/// SysModule localization table.
	/// </summary>
	public class SysModuleLczOld : BPMSoft.Configuration.BaseLczEntity
	{

		#region Constructors: Public

		public SysModuleLczOld(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleLczOld";
		}

		public SysModuleLczOld(SysModuleLczOld source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleLczOld_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleLczOldDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleLczOldInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleLczOldValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleLczOld(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleLczOld_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleLczOld_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLczEntity_BaseEventsProcess<TEntity> where TEntity : SysModuleLczOld
	{

		public SysModuleLczOld_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleLczOld_BaseEventsProcess";
			SchemaUId = new Guid("7a665c53-5089-415c-8119-55ba054b0892");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a665c53-5089-415c-8119-55ba054b0892");
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

	#region Class: SysModuleLczOld_BaseEventsProcess

	/// <exclude/>
	public class SysModuleLczOld_BaseEventsProcess : SysModuleLczOld_BaseEventsProcess<SysModuleLczOld>
	{

		public SysModuleLczOld_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleLczOld_BaseEventsProcess

	public partial class SysModuleLczOld_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleLczOldEventsProcess

	/// <exclude/>
	public class SysModuleLczOldEventsProcess : SysModuleLczOld_BaseEventsProcess
	{

		public SysModuleLczOldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

