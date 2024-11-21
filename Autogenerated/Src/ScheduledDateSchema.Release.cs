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

	#region Class: ScheduledDateSchema

	/// <exclude/>
	public class ScheduledDateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ScheduledDateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ScheduledDateSchema(ScheduledDateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ScheduledDateSchema(ScheduledDateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			RealUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			Name = "ScheduledDate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9f64cee6-77b3-4b33-9771-858ec507ea6f")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("46804bca-4b18-4c46-8b61-8882e99edca1")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("9efd24af-be57-41c2-ad67-efc9b6594928")) == null) {
				Columns.Add(CreateEndDateColumn());
			}
			if (Columns.FindByUId(new Guid("bfb9d4e1-530b-42fd-8aa5-e2bdbdf13978")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9f64cee6-77b3-4b33-9771-858ec507ea6f"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("46804bca-4b18-4c46-8b61-8882e99edca1"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3")
			};
		}

		protected virtual EntitySchemaColumn CreateEndDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("9efd24af-be57-41c2-ad67-efc9b6594928"),
				Name = @"EndDate",
				CreatedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3")
			};
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bfb9d4e1-530b-42fd-8aa5-e2bdbdf13978"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				ModifiedInSchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ScheduledDate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ScheduledDate_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ScheduledDateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ScheduledDateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116"));
		}

		#endregion

	}

	#endregion

	#region Class: ScheduledDate

	/// <summary>
	/// Плановые сроки.
	/// </summary>
	public class ScheduledDate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ScheduledDate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ScheduledDate";
		}

		public ScheduledDate(ScheduledDate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private ReleaseStatus _status;
		/// <summary>
		/// Этап.
		/// </summary>
		public ReleaseStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ReleaseStatus);
			}
		}

		/// <summary>
		/// Начало.
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
		/// Завершение.
		/// </summary>
		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
			}
		}

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релиз.
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ScheduledDate_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ScheduledDateDeleted", e);
			Validating += (s, e) => ThrowEvent("ScheduledDateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ScheduledDate(this);
		}

		#endregion

	}

	#endregion

	#region Class: ScheduledDate_ReleaseEventsProcess

	/// <exclude/>
	public partial class ScheduledDate_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ScheduledDate
	{

		public ScheduledDate_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ScheduledDate_ReleaseEventsProcess";
			SchemaUId = new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f79569c3-1f2a-4702-922c-0e1ea99a8116");
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

	#region Class: ScheduledDate_ReleaseEventsProcess

	/// <exclude/>
	public class ScheduledDate_ReleaseEventsProcess : ScheduledDate_ReleaseEventsProcess<ScheduledDate>
	{

		public ScheduledDate_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ScheduledDate_ReleaseEventsProcess

	public partial class ScheduledDate_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ScheduledDateEventsProcess

	/// <exclude/>
	public class ScheduledDateEventsProcess : ScheduledDate_ReleaseEventsProcess
	{

		public ScheduledDateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

