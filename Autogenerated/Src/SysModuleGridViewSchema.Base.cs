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

	#region Class: SysModuleGridViewSchema

	/// <exclude/>
	public class SysModuleGridViewSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleGridViewSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleGridViewSchema(SysModuleGridViewSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleGridViewSchema(SysModuleGridViewSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba");
			RealUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba");
			Name = "SysModuleGridView";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("75f6db16-d739-4670-9d33-55d2043aecc8")) == null) {
				Columns.Add(CreateSysModuleGridColumn());
			}
			if (Columns.FindByUId(new Guid("0693687b-7a22-4758-9566-21dfea5ba92e")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("0735b684-41cb-4039-95cb-2fc464322d3e")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("3c36c689-6adb-464a-9070-d8d5a095e49c")) == null) {
				Columns.Add(CreateSearchDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9feb4c17-4fe8-4425-82cb-f085fb52e60d"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				ModifiedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("75f6db16-d739-4670-9d33-55d2043aecc8"),
				Name = @"SysModuleGrid",
				ReferenceSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				ModifiedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0693687b-7a22-4758-9566-21dfea5ba92e"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				ModifiedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0735b684-41cb-4039-95cb-2fc464322d3e"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				ModifiedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSearchDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("3c36c689-6adb-464a-9070-d8d5a095e49c"),
				Name = @"SearchData",
				CreatedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				ModifiedInSchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleGridView(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleGridView_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleGridViewSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleGridViewSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGridView

	/// <summary>
	/// List view.
	/// </summary>
	public class SysModuleGridView : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleGridView(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleGridView";
		}

		public SysModuleGridView(SysModuleGridView source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleGridId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleGridId");
			}
			set {
				SetColumnValue("SysModuleGridId", value);
				_sysModuleGrid = null;
			}
		}

		private SysModuleGrid _sysModuleGrid;
		/// <summary>
		/// Section list.
		/// </summary>
		public SysModuleGrid SysModuleGrid {
			get {
				return _sysModuleGrid ??
					(_sysModuleGrid = LookupColumnEntities.GetEntity("SysModuleGrid") as SysModuleGrid);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleGridView_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleGridViewDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleGridViewDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleGridViewInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleGridViewInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleGridViewSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleGridViewSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleGridViewValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleGridView(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGridView_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleGridView_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleGridView
	{

		public SysModuleGridView_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleGridView_BaseEventsProcess";
			SchemaUId = new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c3c3a3a9-d956-4bc7-a498-aa3ccdaf5fba");
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

	#region Class: SysModuleGridView_BaseEventsProcess

	/// <exclude/>
	public class SysModuleGridView_BaseEventsProcess : SysModuleGridView_BaseEventsProcess<SysModuleGridView>
	{

		public SysModuleGridView_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleGridView_BaseEventsProcess

	public partial class SysModuleGridView_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleGridViewEventsProcess

	/// <exclude/>
	public class SysModuleGridViewEventsProcess : SysModuleGridView_BaseEventsProcess
	{

		public SysModuleGridViewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

