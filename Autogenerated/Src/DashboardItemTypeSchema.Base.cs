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

	#region Class: DashboardItemTypeSchema

	/// <exclude/>
	public class DashboardItemTypeSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public DashboardItemTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DashboardItemTypeSchema(DashboardItemTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DashboardItemTypeSchema(DashboardItemTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dff289fe-2593-479d-8f6d-6de59196b245");
			RealUId = new Guid("dff289fe-2593-479d-8f6d-6de59196b245");
			Name = "DashboardItemType";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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
			return new DashboardItemType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DashboardItemType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DashboardItemTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DashboardItemTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dff289fe-2593-479d-8f6d-6de59196b245"));
		}

		#endregion

	}

	#endregion

	#region Class: DashboardItemType

	/// <summary>
	/// Type of Dashboard Item.
	/// </summary>
	public class DashboardItemType : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public DashboardItemType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DashboardItemType";
		}

		public DashboardItemType(DashboardItemType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DashboardItemType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DashboardItemTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("DashboardItemTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("DashboardItemTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("DashboardItemTypeInserting", e);
			Saved += (s, e) => ThrowEvent("DashboardItemTypeSaved", e);
			Saving += (s, e) => ThrowEvent("DashboardItemTypeSaving", e);
			Validating += (s, e) => ThrowEvent("DashboardItemTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DashboardItemType(this);
		}

		#endregion

	}

	#endregion

	#region Class: DashboardItemType_BaseEventsProcess

	/// <exclude/>
	public partial class DashboardItemType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : DashboardItemType
	{

		public DashboardItemType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DashboardItemType_BaseEventsProcess";
			SchemaUId = new Guid("dff289fe-2593-479d-8f6d-6de59196b245");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dff289fe-2593-479d-8f6d-6de59196b245");
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

	#region Class: DashboardItemType_BaseEventsProcess

	/// <exclude/>
	public class DashboardItemType_BaseEventsProcess : DashboardItemType_BaseEventsProcess<DashboardItemType>
	{

		public DashboardItemType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DashboardItemType_BaseEventsProcess

	public partial class DashboardItemType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DashboardItemTypeEventsProcess

	/// <exclude/>
	public class DashboardItemTypeEventsProcess : DashboardItemType_BaseEventsProcess
	{

		public DashboardItemTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

