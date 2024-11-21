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

	#region Class: ActivityTypeStatusEntrySchema

	/// <exclude/>
	public class ActivityTypeStatusEntrySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActivityTypeStatusEntrySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityTypeStatusEntrySchema(ActivityTypeStatusEntrySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityTypeStatusEntrySchema(ActivityTypeStatusEntrySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d617331d-0076-472f-9db7-8cb3271de803");
			RealUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803");
			Name = "ActivityTypeStatusEntry";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8e73d2b9-3991-4244-abb2-da5056c33197")) == null) {
				Columns.Add(CreateActivityTypeColumn());
			}
			if (Columns.FindByUId(new Guid("334f18d3-ac4d-4ca3-8c35-93b96b07916d")) == null) {
				Columns.Add(CreateActivityStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActivityTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e73d2b9-3991-4244-abb2-da5056c33197"),
				Name = @"ActivityType",
				ReferenceSchemaUId = new Guid("75b4d39b-55dc-4bd6-8d10-3f49a58d96c7"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803"),
				ModifiedInSchemaUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActivityStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("334f18d3-ac4d-4ca3-8c35-93b96b07916d"),
				Name = @"ActivityStatus",
				ReferenceSchemaUId = new Guid("805aace4-8604-40e7-a9eb-0f54174593c0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803"),
				ModifiedInSchemaUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803"),
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
			return new ActivityTypeStatusEntry(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityTypeStatusEntry_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityTypeStatusEntrySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityTypeStatusEntrySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d617331d-0076-472f-9db7-8cb3271de803"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityTypeStatusEntry

	/// <summary>
	/// Activity status by type.
	/// </summary>
	public class ActivityTypeStatusEntry : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActivityTypeStatusEntry(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityTypeStatusEntry";
		}

		public ActivityTypeStatusEntry(ActivityTypeStatusEntry source)
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

		/// <exclude/>
		public Guid ActivityStatusId {
			get {
				return GetTypedColumnValue<Guid>("ActivityStatusId");
			}
			set {
				SetColumnValue("ActivityStatusId", value);
				_activityStatus = null;
			}
		}

		/// <exclude/>
		public string ActivityStatusName {
			get {
				return GetTypedColumnValue<string>("ActivityStatusName");
			}
			set {
				SetColumnValue("ActivityStatusName", value);
				if (_activityStatus != null) {
					_activityStatus.Name = value;
				}
			}
		}

		private ActivityStatus _activityStatus;
		/// <summary>
		/// Activity status.
		/// </summary>
		public ActivityStatus ActivityStatus {
			get {
				return _activityStatus ??
					(_activityStatus = LookupColumnEntities.GetEntity("ActivityStatus") as ActivityStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityTypeStatusEntry_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityTypeStatusEntryDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityTypeStatusEntryDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityTypeStatusEntryInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityTypeStatusEntryInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityTypeStatusEntrySaved", e);
			Saving += (s, e) => ThrowEvent("ActivityTypeStatusEntrySaving", e);
			Validating += (s, e) => ThrowEvent("ActivityTypeStatusEntryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityTypeStatusEntry(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityTypeStatusEntry_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityTypeStatusEntry_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ActivityTypeStatusEntry
	{

		public ActivityTypeStatusEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityTypeStatusEntry_BaseEventsProcess";
			SchemaUId = new Guid("d617331d-0076-472f-9db7-8cb3271de803");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d617331d-0076-472f-9db7-8cb3271de803");
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

	#region Class: ActivityTypeStatusEntry_BaseEventsProcess

	/// <exclude/>
	public class ActivityTypeStatusEntry_BaseEventsProcess : ActivityTypeStatusEntry_BaseEventsProcess<ActivityTypeStatusEntry>
	{

		public ActivityTypeStatusEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityTypeStatusEntry_BaseEventsProcess

	public partial class ActivityTypeStatusEntry_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityTypeStatusEntryEventsProcess

	/// <exclude/>
	public class ActivityTypeStatusEntryEventsProcess : ActivityTypeStatusEntry_BaseEventsProcess
	{

		public ActivityTypeStatusEntryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

