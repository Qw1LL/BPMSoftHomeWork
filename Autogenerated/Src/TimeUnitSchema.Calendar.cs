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

	#region Class: TimeUnit_Calendar_BPMSoftSchema

	/// <exclude/>
	public class TimeUnit_Calendar_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public TimeUnit_Calendar_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimeUnit_Calendar_BPMSoftSchema(TimeUnit_Calendar_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimeUnit_Calendar_BPMSoftSchema(TimeUnit_Calendar_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			RealUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			Name = "TimeUnit_Calendar_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2b3c1291-4d08-4b99-a502-7e56ee71b11c")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("810c4a3d-f457-4f97-b2ff-8a419339189f")) == null) {
				Columns.Add(CreateCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2b3c1291-4d08-4b99-a502-7e56ee71b11c"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("810c4a3d-f457-4f97-b2ff-8a419339189f"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				ModifiedInSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"),
				CreatedInPackageId = new Guid("761f835c-6644-4753-9a3e-2c2ccab7b4d0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TimeUnit_Calendar_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimeUnit_CalendarEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimeUnit_Calendar_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimeUnit_Calendar_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab"));
		}

		#endregion

	}

	#endregion

	#region Class: TimeUnit_Calendar_BPMSoft

	/// <summary>
	/// Time unit.
	/// </summary>
	public class TimeUnit_Calendar_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public TimeUnit_Calendar_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimeUnit_Calendar_BPMSoft";
		}

		public TimeUnit_Calendar_BPMSoft(TimeUnit_Calendar_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimeUnit_CalendarEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("TimeUnit_Calendar_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("TimeUnit_Calendar_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("TimeUnit_Calendar_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new TimeUnit_Calendar_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimeUnit_CalendarEventsProcess

	/// <exclude/>
	public partial class TimeUnit_CalendarEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : TimeUnit_Calendar_BPMSoft
	{

		public TimeUnit_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimeUnit_CalendarEventsProcess";
			SchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
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

	#region Class: TimeUnit_CalendarEventsProcess

	/// <exclude/>
	public class TimeUnit_CalendarEventsProcess : TimeUnit_CalendarEventsProcess<TimeUnit_Calendar_BPMSoft>
	{

		public TimeUnit_CalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimeUnit_CalendarEventsProcess

	public partial class TimeUnit_CalendarEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

