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

	#region Class: RemindingSourceSchema

	/// <exclude/>
	public class RemindingSourceSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public RemindingSourceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RemindingSourceSchema(RemindingSourceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RemindingSourceSchema(RemindingSourceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5");
			RealUId = new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5");
			Name = "RemindingSource";
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
			return new RemindingSource(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new RemindingSource_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RemindingSourceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RemindingSourceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5"));
		}

		#endregion

	}

	#endregion

	#region Class: RemindingSource

	/// <summary>
	/// Notification Source.
	/// </summary>
	public class RemindingSource : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public RemindingSource(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "RemindingSource";
		}

		public RemindingSource(RemindingSource source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new RemindingSource_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("RemindingSourceDeleted", e);
			Deleting += (s, e) => ThrowEvent("RemindingSourceDeleting", e);
			Inserted += (s, e) => ThrowEvent("RemindingSourceInserted", e);
			Inserting += (s, e) => ThrowEvent("RemindingSourceInserting", e);
			Saved += (s, e) => ThrowEvent("RemindingSourceSaved", e);
			Saving += (s, e) => ThrowEvent("RemindingSourceSaving", e);
			Validating += (s, e) => ThrowEvent("RemindingSourceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new RemindingSource(this);
		}

		#endregion

	}

	#endregion

	#region Class: RemindingSource_BaseEventsProcess

	/// <exclude/>
	public partial class RemindingSource_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : RemindingSource
	{

		public RemindingSource_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "RemindingSource_BaseEventsProcess";
			SchemaUId = new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dccbeb85-5abb-489e-9ffe-1daaacba1ad5");
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

	#region Class: RemindingSource_BaseEventsProcess

	/// <exclude/>
	public class RemindingSource_BaseEventsProcess : RemindingSource_BaseEventsProcess<RemindingSource>
	{

		public RemindingSource_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: RemindingSource_BaseEventsProcess

	public partial class RemindingSource_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RemindingSourceEventsProcess

	/// <exclude/>
	public class RemindingSourceEventsProcess : RemindingSource_BaseEventsProcess
	{

		public RemindingSourceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

