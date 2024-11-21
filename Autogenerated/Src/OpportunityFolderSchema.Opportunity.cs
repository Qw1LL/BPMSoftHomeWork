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

	#region Class: OpportunityFolder_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OpportunityFolder_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public OpportunityFolder_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityFolder_Opportunity_BPMSoftSchema(OpportunityFolder_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityFolder_Opportunity_BPMSoftSchema(OpportunityFolder_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			RealUId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			Name = "OpportunityFolder_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityFolder_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityFolder_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityFolder_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityFolder_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba431b60-ce67-4198-9281-6571b6920f70"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFolder_Opportunity_BPMSoft

	/// <summary>
	/// Группа продажи.
	/// </summary>
	public class OpportunityFolder_Opportunity_BPMSoft : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public OpportunityFolder_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityFolder_Opportunity_BPMSoft";
		}

		public OpportunityFolder_Opportunity_BPMSoft(OpportunityFolder_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private OpportunityFolder _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public OpportunityFolder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as OpportunityFolder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityFolder_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityFolder_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityFolder_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityFolder_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityFolder_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : OpportunityFolder_Opportunity_BPMSoft
	{

		public OpportunityFolder_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityFolder_OpportunityEventsProcess";
			SchemaUId = new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba431b60-ce67-4198-9281-6571b6920f70");
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

	#region Class: OpportunityFolder_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityFolder_OpportunityEventsProcess : OpportunityFolder_OpportunityEventsProcess<OpportunityFolder_Opportunity_BPMSoft>
	{

		public OpportunityFolder_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityFolder_OpportunityEventsProcess

	public partial class OpportunityFolder_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
			return;
		}

		#endregion

	}

	#endregion

}

