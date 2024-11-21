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

	#region Class: ReleaseTeamSchema

	/// <exclude/>
	public class ReleaseTeamSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ReleaseTeamSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseTeamSchema(ReleaseTeamSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseTeamSchema(ReleaseTeamSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			RealUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			Name = "ReleaseTeam";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f7d0868f-17c4-48bc-87b1-2130cf66a9bf")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("0c7c7aa6-9948-460f-8cdc-8427669f0ab5")) == null) {
				Columns.Add(CreateResponsibleColumn());
			}
			if (Columns.FindByUId(new Guid("38cdfeea-ca86-4489-8a72-52fa3bc3f70b")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			column.CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7d0868f-17c4-48bc-87b1-2130cf66a9bf"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
				ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateResponsibleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0c7c7aa6-9948-460f-8cdc-8427669f0ab5"),
				Name = @"Responsible",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
				ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
				CreatedInPackageId = new Guid("485eb89f-9ee2-4473-81ec-293d7fe1a9d3")
			};
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("38cdfeea-ca86-4489-8a72-52fa3bc3f70b"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
				ModifiedInSchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"),
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
			return new ReleaseTeam(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseTeam_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseTeamSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseTeamSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseTeam

	/// <summary>
	/// Команда.
	/// </summary>
	public class ReleaseTeam : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ReleaseTeam(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseTeam";
		}

		public ReleaseTeam(ReleaseTeam source)
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

		/// <exclude/>
		public Guid ResponsibleId {
			get {
				return GetTypedColumnValue<Guid>("ResponsibleId");
			}
			set {
				SetColumnValue("ResponsibleId", value);
				_responsible = null;
			}
		}

		/// <exclude/>
		public string ResponsibleName {
			get {
				return GetTypedColumnValue<string>("ResponsibleName");
			}
			set {
				SetColumnValue("ResponsibleName", value);
				if (_responsible != null) {
					_responsible.Name = value;
				}
			}
		}

		private SysAdminUnit _responsible;
		/// <summary>
		/// Ответственный / Группа.
		/// </summary>
		public SysAdminUnit Responsible {
			get {
				return _responsible ??
					(_responsible = LookupColumnEntities.GetEntity("Responsible") as SysAdminUnit);
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
			var process = new ReleaseTeam_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseTeamDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseTeamValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseTeam(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseTeam_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseTeam_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ReleaseTeam
	{

		public ReleaseTeam_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseTeam_ReleaseEventsProcess";
			SchemaUId = new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e0cf8e90-5727-48de-82f7-1eb15ecbadd0");
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

	#region Class: ReleaseTeam_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseTeam_ReleaseEventsProcess : ReleaseTeam_ReleaseEventsProcess<ReleaseTeam>
	{

		public ReleaseTeam_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseTeam_ReleaseEventsProcess

	public partial class ReleaseTeam_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseTeamEventsProcess

	/// <exclude/>
	public class ReleaseTeamEventsProcess : ReleaseTeam_ReleaseEventsProcess
	{

		public ReleaseTeamEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

