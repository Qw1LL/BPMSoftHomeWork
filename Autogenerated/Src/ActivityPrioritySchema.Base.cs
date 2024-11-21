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

	#region Class: ActivityPrioritySchema

	/// <exclude/>
	public class ActivityPrioritySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ActivityPrioritySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityPrioritySchema(ActivityPrioritySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityPrioritySchema(ActivityPrioritySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
			RealUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
			Name = "ActivityPriority";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("887c15af-c2cc-4b29-8af6-6f3bde17eb3d")) == null) {
				Columns.Add(CreateImgColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateImgColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Image")) {
				UId = new Guid("887c15af-c2cc-4b29-8af6-6f3bde17eb3d"),
				Name = @"Img",
				CreatedInSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				ModifiedInSchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityPriority(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityPriority_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityPrioritySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityPrioritySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityPriority

	/// <summary>
	/// Activity priority.
	/// </summary>
	public class ActivityPriority : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ActivityPriority(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityPriority";
		}

		public ActivityPriority(ActivityPriority source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityPriority_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityPriorityDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityPriorityDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityPriorityInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityPriorityInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityPrioritySaved", e);
			Saving += (s, e) => ThrowEvent("ActivityPrioritySaving", e);
			Validating += (s, e) => ThrowEvent("ActivityPriorityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityPriority(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityPriority_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityPriority_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ActivityPriority
	{

		public ActivityPriority_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityPriority_BaseEventsProcess";
			SchemaUId = new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b934f48c-5dea-49b9-bde3-697cb4be5d8b");
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

	#region Class: ActivityPriority_BaseEventsProcess

	/// <exclude/>
	public class ActivityPriority_BaseEventsProcess : ActivityPriority_BaseEventsProcess<ActivityPriority>
	{

		public ActivityPriority_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityPriority_BaseEventsProcess

	public partial class ActivityPriority_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityPriorityEventsProcess

	/// <exclude/>
	public class ActivityPriorityEventsProcess : ActivityPriority_BaseEventsProcess
	{

		public ActivityPriorityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

