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

	#region Class: MaintenanceWindowSchema

	/// <exclude/>
	public class MaintenanceWindowSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MaintenanceWindowSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MaintenanceWindowSchema(MaintenanceWindowSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MaintenanceWindowSchema(MaintenanceWindowSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIMtnceWndDayOfWeekIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("e6090da7-a02a-4861-b3d9-249346bdaa1b");
			index.Name = "IMtnceWndDayOfWeek";
			index.CreatedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
			index.ModifiedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
			index.CreatedInPackageId = new Guid("5bd8b3f2-ea32-4921-a7e4-a80db761448b");
			EntitySchemaIndexColumn dayOfWeekIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5c232e79-0904-4fb4-8b9d-22af34b3ba94"),
				ColumnUId = new Guid("8c613c26-cf75-488f-b17d-593ee545692f"),
				CreatedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				ModifiedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				CreatedInPackageId = new Guid("5bd8b3f2-ea32-4921-a7e4-a80db761448b"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(dayOfWeekIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
			RealUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
			Name = "MaintenanceWindow";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("90e8157f-4651-4349-83a7-f0455fc70915");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8c613c26-cf75-488f-b17d-593ee545692f")) == null) {
				Columns.Add(CreateDayOfWeekColumn());
			}
			if (Columns.FindByUId(new Guid("b2a6002c-d5d4-49de-9f0b-796576c02aab")) == null) {
				Columns.Add(CreateStartTimeColumn());
			}
			if (Columns.FindByUId(new Guid("b6127cf7-2b95-4630-b118-f1935132a7b9")) == null) {
				Columns.Add(CreateEndTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDayOfWeekColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c613c26-cf75-488f-b17d-593ee545692f"),
				Name = @"DayOfWeek",
				ReferenceSchemaUId = new Guid("95592cd1-f2aa-4d34-a109-aa046cd5bbd5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				ModifiedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				CreatedInPackageId = new Guid("5bd8b3f2-ea32-4921-a7e4-a80db761448b"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateStartTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("b2a6002c-d5d4-49de-9f0b-796576c02aab"),
				Name = @"StartTime",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				ModifiedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				CreatedInPackageId = new Guid("5bd8b3f2-ea32-4921-a7e4-a80db761448b")
			};
		}

		protected virtual EntitySchemaColumn CreateEndTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Time")) {
				UId = new Guid("b6127cf7-2b95-4630-b118-f1935132a7b9"),
				Name = @"EndTime",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				ModifiedInSchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"),
				CreatedInPackageId = new Guid("5bd8b3f2-ea32-4921-a7e4-a80db761448b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIMtnceWndDayOfWeekIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MaintenanceWindow(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MaintenanceWindow_CalendarBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MaintenanceWindowSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MaintenanceWindowSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a"));
		}

		#endregion

	}

	#endregion

	#region Class: MaintenanceWindow

	/// <summary>
	/// Maintenance period.
	/// </summary>
	public class MaintenanceWindow : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MaintenanceWindow(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MaintenanceWindow";
		}

		public MaintenanceWindow(MaintenanceWindow source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DayOfWeekId {
			get {
				return GetTypedColumnValue<Guid>("DayOfWeekId");
			}
			set {
				SetColumnValue("DayOfWeekId", value);
				_dayOfWeek = null;
			}
		}

		/// <exclude/>
		public string DayOfWeekName {
			get {
				return GetTypedColumnValue<string>("DayOfWeekName");
			}
			set {
				SetColumnValue("DayOfWeekName", value);
				if (_dayOfWeek != null) {
					_dayOfWeek.Name = value;
				}
			}
		}

		private DayOfWeek _dayOfWeek;
		/// <summary>
		/// Day of the week.
		/// </summary>
		public DayOfWeek DayOfWeek {
			get {
				return _dayOfWeek ??
					(_dayOfWeek = LookupColumnEntities.GetEntity("DayOfWeek") as DayOfWeek);
			}
		}

		/// <summary>
		/// Start time (UTC).
		/// </summary>
		public DateTime StartTime {
			get {
				return GetTypedColumnValue<DateTime>("StartTime");
			}
			set {
				SetColumnValue("StartTime", value);
			}
		}

		/// <summary>
		/// End time (UTC).
		/// </summary>
		public DateTime EndTime {
			get {
				return GetTypedColumnValue<DateTime>("EndTime");
			}
			set {
				SetColumnValue("EndTime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MaintenanceWindow_CalendarBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MaintenanceWindowDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MaintenanceWindow(this);
		}

		#endregion

	}

	#endregion

	#region Class: MaintenanceWindow_CalendarBaseEventsProcess

	/// <exclude/>
	public partial class MaintenanceWindow_CalendarBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MaintenanceWindow
	{

		public MaintenanceWindow_CalendarBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MaintenanceWindow_CalendarBaseEventsProcess";
			SchemaUId = new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("067014b3-8727-46f0-8453-c2aaa60e4e6a");
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

	#region Class: MaintenanceWindow_CalendarBaseEventsProcess

	/// <exclude/>
	public class MaintenanceWindow_CalendarBaseEventsProcess : MaintenanceWindow_CalendarBaseEventsProcess<MaintenanceWindow>
	{

		public MaintenanceWindow_CalendarBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MaintenanceWindow_CalendarBaseEventsProcess

	public partial class MaintenanceWindow_CalendarBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MaintenanceWindowEventsProcess

	/// <exclude/>
	public class MaintenanceWindowEventsProcess : MaintenanceWindow_CalendarBaseEventsProcess
	{

		public MaintenanceWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

