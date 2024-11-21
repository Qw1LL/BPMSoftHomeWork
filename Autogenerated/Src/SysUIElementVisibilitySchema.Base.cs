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

	#region Class: SysUIElementVisibilitySchema

	/// <exclude/>
	public class SysUIElementVisibilitySchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysUIElementVisibilitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysUIElementVisibilitySchema(SysUIElementVisibilitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysUIElementVisibilitySchema(SysUIElementVisibilitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3b67de92-bebb-4973-bb74-2f7c5951930b");
			RealUId = new Guid("3b67de92-bebb-4973-bb74-2f7c5951930b");
			Name = "SysUIElementVisibility";
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
			return new SysUIElementVisibility(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysUIElementVisibility_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysUIElementVisibilitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysUIElementVisibilitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3b67de92-bebb-4973-bb74-2f7c5951930b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysUIElementVisibility

	/// <summary>
	/// Item Visability.
	/// </summary>
	public class SysUIElementVisibility : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysUIElementVisibility(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysUIElementVisibility";
		}

		public SysUIElementVisibility(SysUIElementVisibility source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysUIElementVisibility_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysUIElementVisibilityDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysUIElementVisibilityDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysUIElementVisibilityInserted", e);
			Inserting += (s, e) => ThrowEvent("SysUIElementVisibilityInserting", e);
			Saved += (s, e) => ThrowEvent("SysUIElementVisibilitySaved", e);
			Saving += (s, e) => ThrowEvent("SysUIElementVisibilitySaving", e);
			Validating += (s, e) => ThrowEvent("SysUIElementVisibilityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysUIElementVisibility(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysUIElementVisibility_BaseEventsProcess

	/// <exclude/>
	public partial class SysUIElementVisibility_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysUIElementVisibility
	{

		public SysUIElementVisibility_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysUIElementVisibility_BaseEventsProcess";
			SchemaUId = new Guid("3b67de92-bebb-4973-bb74-2f7c5951930b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3b67de92-bebb-4973-bb74-2f7c5951930b");
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

	#region Class: SysUIElementVisibility_BaseEventsProcess

	/// <exclude/>
	public class SysUIElementVisibility_BaseEventsProcess : SysUIElementVisibility_BaseEventsProcess<SysUIElementVisibility>
	{

		public SysUIElementVisibility_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysUIElementVisibility_BaseEventsProcess

	public partial class SysUIElementVisibility_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysUIElementVisibilityEventsProcess

	/// <exclude/>
	public class SysUIElementVisibilityEventsProcess : SysUIElementVisibility_BaseEventsProcess
	{

		public SysUIElementVisibilityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

