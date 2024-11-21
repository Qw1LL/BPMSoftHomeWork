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

	#region Class: VwSysSchemaInfoForLookupsSchema

	/// <exclude/>
	public class VwSysSchemaInfoForLookupsSchema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwSysSchemaInfoForLookupsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaInfoForLookupsSchema(VwSysSchemaInfoForLookupsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaInfoForLookupsSchema(VwSysSchemaInfoForLookupsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b361fd6-9f0d-45a7-b302-c4f8b129adf9");
			RealUId = new Guid("7b361fd6-9f0d-45a7-b302-c4f8b129adf9");
			Name = "VwSysSchemaInfoForLookups";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
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
			return new VwSysSchemaInfoForLookups(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaInfoForLookups_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaInfoForLookupsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaInfoForLookupsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b361fd6-9f0d-45a7-b302-c4f8b129adf9"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInfoForLookups

	/// <summary>
	/// Workspace item (view).
	/// </summary>
	public class VwSysSchemaInfoForLookups : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwSysSchemaInfoForLookups(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaInfoForLookups";
		}

		public VwSysSchemaInfoForLookups(VwSysSchemaInfoForLookups source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaInfoForLookups_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysSchemaInfoForLookupsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSchemaInfoForLookups(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInfoForLookups_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaInfoForLookups_BaseEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwSysSchemaInfoForLookups
	{

		public VwSysSchemaInfoForLookups_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaInfoForLookups_BaseEventsProcess";
			SchemaUId = new Guid("7b361fd6-9f0d-45a7-b302-c4f8b129adf9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b361fd6-9f0d-45a7-b302-c4f8b129adf9");
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

	#region Class: VwSysSchemaInfoForLookups_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaInfoForLookups_BaseEventsProcess : VwSysSchemaInfoForLookups_BaseEventsProcess<VwSysSchemaInfoForLookups>
	{

		public VwSysSchemaInfoForLookups_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaInfoForLookups_BaseEventsProcess

	public partial class VwSysSchemaInfoForLookups_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaInfoForLookupsEventsProcess

	/// <exclude/>
	public class VwSysSchemaInfoForLookupsEventsProcess : VwSysSchemaInfoForLookups_BaseEventsProcess
	{

		public VwSysSchemaInfoForLookupsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

