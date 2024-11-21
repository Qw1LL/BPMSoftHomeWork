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

	#region Class: ResolvedLookupConflictSchema

	/// <exclude/>
	public class ResolvedLookupConflictSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ResolvedLookupConflictSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ResolvedLookupConflictSchema(ResolvedLookupConflictSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ResolvedLookupConflictSchema(ResolvedLookupConflictSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1");
			RealUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1");
			Name = "ResolvedLookupConflict";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("195198da-c54f-41e1-8cf4-9efb8d00c356")) == null) {
				Columns.Add(CreateLookupSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("4d5682e7-3503-4589-93b5-a59a72ee4c8d")) == null) {
				Columns.Add(CreateLookupSchemaDisplayColumnNameColumn());
			}
			if (Columns.FindByUId(new Guid("243f4869-376f-41e2-b894-d9ad3c6b43b6")) == null) {
				Columns.Add(CreateLookupSchemaDisplayColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("8e5bea57-d29e-42a0-a67f-a4ffbfd4e581")) == null) {
				Columns.Add(CreateLookupRecordIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("195198da-c54f-41e1-8cf4-9efb8d00c356"),
				Name = @"LookupSchemaName",
				CreatedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				ModifiedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaDisplayColumnNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4d5682e7-3503-4589-93b5-a59a72ee4c8d"),
				Name = @"LookupSchemaDisplayColumnName",
				CreatedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				ModifiedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupSchemaDisplayColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("243f4869-376f-41e2-b894-d9ad3c6b43b6"),
				Name = @"LookupSchemaDisplayColumnValue",
				CreatedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				ModifiedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLookupRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8e5bea57-d29e-42a0-a67f-a4ffbfd4e581"),
				Name = @"LookupRecordId",
				CreatedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
				ModifiedInSchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"),
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
			return new ResolvedLookupConflict(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ResolvedLookupConflict_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ResolvedLookupConflictSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ResolvedLookupConflictSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1"));
		}

		#endregion

	}

	#endregion

	#region Class: ResolvedLookupConflict

	/// <summary>
	/// Lookup values confirmed by user.
	/// </summary>
	public class ResolvedLookupConflict : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ResolvedLookupConflict(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ResolvedLookupConflict";
		}

		public ResolvedLookupConflict(ResolvedLookupConflict source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Lookup name.
		/// </summary>
		public string LookupSchemaName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaName");
			}
			set {
				SetColumnValue("LookupSchemaName", value);
			}
		}

		/// <summary>
		/// Displayed lookup value column.
		/// </summary>
		public string LookupSchemaDisplayColumnName {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnName");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnName", value);
			}
		}

		/// <summary>
		/// Estimated value of lookup displayed column.
		/// </summary>
		public string LookupSchemaDisplayColumnValue {
			get {
				return GetTypedColumnValue<string>("LookupSchemaDisplayColumnValue");
			}
			set {
				SetColumnValue("LookupSchemaDisplayColumnValue", value);
			}
		}

		/// <summary>
		/// Lookup value Id.
		/// </summary>
		public Guid LookupRecordId {
			get {
				return GetTypedColumnValue<Guid>("LookupRecordId");
			}
			set {
				SetColumnValue("LookupRecordId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ResolvedLookupConflict_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ResolvedLookupConflictDeleted", e);
			Inserting += (s, e) => ThrowEvent("ResolvedLookupConflictInserting", e);
			Validating += (s, e) => ThrowEvent("ResolvedLookupConflictValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ResolvedLookupConflict(this);
		}

		#endregion

	}

	#endregion

	#region Class: ResolvedLookupConflict_BaseEventsProcess

	/// <exclude/>
	public partial class ResolvedLookupConflict_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ResolvedLookupConflict
	{

		public ResolvedLookupConflict_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ResolvedLookupConflict_BaseEventsProcess";
			SchemaUId = new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("61034f65-8c6f-4717-b1ea-d3fc6fc32bd1");
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

	#region Class: ResolvedLookupConflict_BaseEventsProcess

	/// <exclude/>
	public class ResolvedLookupConflict_BaseEventsProcess : ResolvedLookupConflict_BaseEventsProcess<ResolvedLookupConflict>
	{

		public ResolvedLookupConflict_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ResolvedLookupConflict_BaseEventsProcess

	public partial class ResolvedLookupConflict_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ResolvedLookupConflictEventsProcess

	/// <exclude/>
	public class ResolvedLookupConflictEventsProcess : ResolvedLookupConflict_BaseEventsProcess
	{

		public ResolvedLookupConflictEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

