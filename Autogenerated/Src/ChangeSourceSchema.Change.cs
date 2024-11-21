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

	#region Class: ChangeSourceSchema

	/// <exclude/>
	public class ChangeSourceSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChangeSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChangeSourceSchema(ChangeSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChangeSourceSchema(ChangeSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			RealUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			Name = "ChangeSource";
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
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			column.CreatedInPackageId = new Guid("2496861e-1f72-4434-ab9e-c42503decf6d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
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
			return new ChangeSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChangeSource_ChangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChangeSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChangeSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42"));
		}

		#endregion

	}

	#endregion

	#region Class: ChangeSource

	/// <summary>
	/// Источник изменения.
	/// </summary>
	public class ChangeSource : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChangeSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChangeSource";
		}

		public ChangeSource(ChangeSource source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChangeSource_ChangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChangeSourceDeleted", e);
			Validating += (s, e) => ThrowEvent("ChangeSourceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChangeSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChangeSource_ChangeEventsProcess

	/// <exclude/>
	public partial class ChangeSource_ChangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChangeSource
	{

		public ChangeSource_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChangeSource_ChangeEventsProcess";
			SchemaUId = new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8e7dbfee-4575-4f1f-ad08-e77dea794a42");
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

	#region Class: ChangeSource_ChangeEventsProcess

	/// <exclude/>
	public class ChangeSource_ChangeEventsProcess : ChangeSource_ChangeEventsProcess<ChangeSource>
	{

		public ChangeSource_ChangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChangeSource_ChangeEventsProcess

	public partial class ChangeSource_ChangeEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ChangeSourceEventsProcess

	/// <exclude/>
	public class ChangeSourceEventsProcess : ChangeSource_ChangeEventsProcess
	{

		public ChangeSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

