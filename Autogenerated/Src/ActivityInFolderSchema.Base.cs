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

	#region Class: ActivityInFolderSchema

	/// <exclude/>
	public class ActivityInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ActivityInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityInFolderSchema(ActivityInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityInFolderSchema(ActivityInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			RealUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			Name = "ActivityInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2c83ad63-8725-45fe-b692-bd54f4dae4b0")) == null) {
				Columns.Add(CreateActivityColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("31464792-6754-447f-83ae-90a1b468c29f");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2c83ad63-8725-45fe-b692-bd54f4dae4b0"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27"),
				ModifiedInSchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivityInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityInFolder

	/// <summary>
	/// Activity in folder.
	/// </summary>
	public class ActivityInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ActivityInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityInFolder";
		}

		public ActivityInFolder(ActivityInFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("ActivityInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("ActivityInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ActivityInFolder
	{

		public ActivityInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityInFolder_BaseEventsProcess";
			SchemaUId = new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9e69f458-e886-40b6-8bc6-e2db311efe27");
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

	#region Class: ActivityInFolder_BaseEventsProcess

	/// <exclude/>
	public class ActivityInFolder_BaseEventsProcess : ActivityInFolder_BaseEventsProcess<ActivityInFolder>
	{

		public ActivityInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityInFolder_BaseEventsProcess

	public partial class ActivityInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityInFolderEventsProcess

	/// <exclude/>
	public class ActivityInFolderEventsProcess : ActivityInFolder_BaseEventsProcess
	{

		public ActivityInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

