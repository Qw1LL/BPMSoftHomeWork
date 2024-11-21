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

	#region Class: GlobalDuplicateSearchStatusSchema

	/// <exclude/>
	public class GlobalDuplicateSearchStatusSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public GlobalDuplicateSearchStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public GlobalDuplicateSearchStatusSchema(GlobalDuplicateSearchStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public GlobalDuplicateSearchStatusSchema(GlobalDuplicateSearchStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1792d230-c5c1-4c80-917d-857bf9681e7a");
			RealUId = new Guid("1792d230-c5c1-4c80-917d-857bf9681e7a");
			Name = "GlobalDuplicateSearchStatus";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			DesignLocalizationSchemaName = @"SysGlobalDuplSearchStatusLcz";
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
			return new GlobalDuplicateSearchStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new GlobalDuplicateSearchStatus_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new GlobalDuplicateSearchStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new GlobalDuplicateSearchStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1792d230-c5c1-4c80-917d-857bf9681e7a"));
		}

		#endregion

	}

	#endregion

	#region Class: GlobalDuplicateSearchStatus

	/// <summary>
	/// Global Duplicates Search Status.
	/// </summary>
	public class GlobalDuplicateSearchStatus : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public GlobalDuplicateSearchStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "GlobalDuplicateSearchStatus";
		}

		public GlobalDuplicateSearchStatus(GlobalDuplicateSearchStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new GlobalDuplicateSearchStatus_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusDeleted", e);
			Deleting += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusDeleting", e);
			Inserted += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusInserted", e);
			Inserting += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusInserting", e);
			Saved += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusSaved", e);
			Saving += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusSaving", e);
			Validating += (s, e) => ThrowEvent("GlobalDuplicateSearchStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new GlobalDuplicateSearchStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: GlobalDuplicateSearchStatus_BaseEventsProcess

	/// <exclude/>
	public partial class GlobalDuplicateSearchStatus_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : GlobalDuplicateSearchStatus
	{

		public GlobalDuplicateSearchStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "GlobalDuplicateSearchStatus_BaseEventsProcess";
			SchemaUId = new Guid("1792d230-c5c1-4c80-917d-857bf9681e7a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1792d230-c5c1-4c80-917d-857bf9681e7a");
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

	#region Class: GlobalDuplicateSearchStatus_BaseEventsProcess

	/// <exclude/>
	public class GlobalDuplicateSearchStatus_BaseEventsProcess : GlobalDuplicateSearchStatus_BaseEventsProcess<GlobalDuplicateSearchStatus>
	{

		public GlobalDuplicateSearchStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: GlobalDuplicateSearchStatus_BaseEventsProcess

	public partial class GlobalDuplicateSearchStatus_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: GlobalDuplicateSearchStatusEventsProcess

	/// <exclude/>
	public class GlobalDuplicateSearchStatusEventsProcess : GlobalDuplicateSearchStatus_BaseEventsProcess
	{

		public GlobalDuplicateSearchStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

