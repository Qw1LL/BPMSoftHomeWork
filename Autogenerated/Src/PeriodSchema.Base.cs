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

	#region Class: PeriodSchema

	/// <exclude/>
	public class PeriodSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public PeriodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PeriodSchema(PeriodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PeriodSchema(PeriodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2");
			RealUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2");
			Name = "Period";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateStartDateColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("30b7698a-7531-4fc5-ad6b-db64e289b477")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("28325522-3317-4110-a881-cf22df0f5dba")) == null) {
				Columns.Add(CreatePeriodTypeColumn());
			}
			if (Columns.FindByUId(new Guid("47036bbd-4d29-4cef-8a9c-2ffbbcde06af")) == null) {
				Columns.Add(CreateYearColumn());
			}
			if (Columns.FindByUId(new Guid("cd0f614a-b891-4c75-9f44-c3ebfab8ac35")) == null) {
				Columns.Add(CreateQuarterColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("5ee4ad02-c1b8-4938-955e-a930224e3093"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("30b7698a-7531-4fc5-ad6b-db64e289b477"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376")
			};
		}

		protected virtual EntitySchemaColumn CreatePeriodTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("28325522-3317-4110-a881-cf22df0f5dba"),
				Name = @"PeriodType",
				ReferenceSchemaUId = new Guid("3608a0e4-0235-4936-9c0e-99620e73940c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376")
			};
		}

		protected virtual EntitySchemaColumn CreateYearColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("47036bbd-4d29-4cef-8a9c-2ffbbcde06af"),
				Name = @"Year",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376")
			};
		}

		protected virtual EntitySchemaColumn CreateQuarterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cd0f614a-b891-4c75-9f44-c3ebfab8ac35"),
				Name = @"Quarter",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("bb5b13b5-8833-41e4-a262-01f88b33e376")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a02e67d6-cf4c-46d8-a7de-9f5e98792e39"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				ModifiedInSchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"),
				CreatedInPackageId = new Guid("2592f426-913e-4c44-9831-81952215683c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Period(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Period_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PeriodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PeriodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2"));
		}

		#endregion

	}

	#endregion

	#region Class: Period

	/// <summary>
	/// Period.
	/// </summary>
	public class Period : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Period(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Period";
		}

		public Period(Period source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Period end date.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid PeriodTypeId {
			get {
				return GetTypedColumnValue<Guid>("PeriodTypeId");
			}
			set {
				SetColumnValue("PeriodTypeId", value);
				_periodType = null;
			}
		}

		/// <exclude/>
		public string PeriodTypeName {
			get {
				return GetTypedColumnValue<string>("PeriodTypeName");
			}
			set {
				SetColumnValue("PeriodTypeName", value);
				if (_periodType != null) {
					_periodType.Name = value;
				}
			}
		}

		private PeriodType _periodType;
		/// <summary>
		/// Period type.
		/// </summary>
		public PeriodType PeriodType {
			get {
				return _periodType ??
					(_periodType = LookupColumnEntities.GetEntity("PeriodType") as PeriodType);
			}
		}

		/// <exclude/>
		public Guid YearId {
			get {
				return GetTypedColumnValue<Guid>("YearId");
			}
			set {
				SetColumnValue("YearId", value);
				_year = null;
			}
		}

		/// <exclude/>
		public string YearName {
			get {
				return GetTypedColumnValue<string>("YearName");
			}
			set {
				SetColumnValue("YearName", value);
				if (_year != null) {
					_year.Name = value;
				}
			}
		}

		private Period _year;
		/// <summary>
		/// Year.
		/// </summary>
		public Period Year {
			get {
				return _year ??
					(_year = LookupColumnEntities.GetEntity("Year") as Period);
			}
		}

		/// <exclude/>
		public Guid QuarterId {
			get {
				return GetTypedColumnValue<Guid>("QuarterId");
			}
			set {
				SetColumnValue("QuarterId", value);
				_quarter = null;
			}
		}

		/// <exclude/>
		public string QuarterName {
			get {
				return GetTypedColumnValue<string>("QuarterName");
			}
			set {
				SetColumnValue("QuarterName", value);
				if (_quarter != null) {
					_quarter.Name = value;
				}
			}
		}

		private Period _quarter;
		/// <summary>
		/// Quarter.
		/// </summary>
		public Period Quarter {
			get {
				return _quarter ??
					(_quarter = LookupColumnEntities.GetEntity("Quarter") as Period);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Period _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public Period Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as Period);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Period_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PeriodDeleted", e);
			Validating += (s, e) => ThrowEvent("PeriodValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Period(this);
		}

		#endregion

	}

	#endregion

	#region Class: Period_BaseEventsProcess

	/// <exclude/>
	public partial class Period_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Period
	{

		public Period_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Period_BaseEventsProcess";
			SchemaUId = new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b473ba3-604c-41d6-b25d-032754dad4d2");
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

	#region Class: Period_BaseEventsProcess

	/// <exclude/>
	public class Period_BaseEventsProcess : Period_BaseEventsProcess<Period>
	{

		public Period_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Period_BaseEventsProcess

	public partial class Period_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PeriodEventsProcess

	/// <exclude/>
	public class PeriodEventsProcess : Period_BaseEventsProcess
	{

		public PeriodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

