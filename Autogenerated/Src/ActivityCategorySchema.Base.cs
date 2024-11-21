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

	#region Class: ActivityCategorySchema

	/// <exclude/>
	public class ActivityCategorySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ActivityCategorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityCategorySchema(ActivityCategorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityCategorySchema(ActivityCategorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
			RealUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
			Name = "ActivityCategory";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ca94a324-e7f1-44ab-b1b7-98cdfabd9c11")) == null) {
				Columns.Add(CreateActivityTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateActivityTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ca94a324-e7f1-44ab-b1b7-98cdfabd9c11"),
				Name = @"ActivityType",
				ReferenceSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
				ModifiedInSchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"),
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
			return new ActivityCategory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityCategory_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityCategorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityCategorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityCategory

	/// <summary>
	/// Activity category.
	/// </summary>
	public class ActivityCategory : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ActivityCategory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityCategory";
		}

		public ActivityCategory(ActivityCategory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ActivityTypeId {
			get {
				return GetTypedColumnValue<Guid>("ActivityTypeId");
			}
			set {
				SetColumnValue("ActivityTypeId", value);
				_activityType = null;
			}
		}

		/// <exclude/>
		public string ActivityTypeName {
			get {
				return GetTypedColumnValue<string>("ActivityTypeName");
			}
			set {
				SetColumnValue("ActivityTypeName", value);
				if (_activityType != null) {
					_activityType.Name = value;
				}
			}
		}

		private ActivityType _activityType;
		/// <summary>
		/// Activity type.
		/// </summary>
		public ActivityType ActivityType {
			get {
				return _activityType ??
					(_activityType = LookupColumnEntities.GetEntity("ActivityType") as ActivityType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityCategory_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityCategoryDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityCategoryDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityCategoryInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityCategoryInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityCategorySaved", e);
			Saving += (s, e) => ThrowEvent("ActivityCategorySaving", e);
			Validating += (s, e) => ThrowEvent("ActivityCategoryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityCategory(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityCategory_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityCategory_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ActivityCategory
	{

		public ActivityCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityCategory_BaseEventsProcess";
			SchemaUId = new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("961e2086-a12b-4d27-b095-40b1e64d6cc0");
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

	#region Class: ActivityCategory_BaseEventsProcess

	/// <exclude/>
	public class ActivityCategory_BaseEventsProcess : ActivityCategory_BaseEventsProcess<ActivityCategory>
	{

		public ActivityCategory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityCategory_BaseEventsProcess

	public partial class ActivityCategory_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityCategoryEventsProcess

	/// <exclude/>
	public class ActivityCategoryEventsProcess : ActivityCategory_BaseEventsProcess
	{

		public ActivityCategoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

