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

	#region Class: SysModulePrimaryGridSchema

	/// <exclude/>
	public class SysModulePrimaryGridSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModulePrimaryGridSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModulePrimaryGridSchema(SysModulePrimaryGridSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModulePrimaryGridSchema(SysModulePrimaryGridSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b");
			RealUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b");
			Name = "SysModulePrimaryGrid";
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
			if (Columns.FindByUId(new Guid("d79b74a7-51f5-43a9-a84d-59ba26573a45")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("82e59008-cb5c-449d-8cb9-5d5f5d599467")) == null) {
				Columns.Add(CreateSysModuleGridColumn());
			}
			if (Columns.FindByUId(new Guid("66c9b1e3-02af-4dcc-a65b-aef6b8ff9ea6")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("a21aecf5-aaf2-4940-9015-cb40c72e374a")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("945b1337-7de3-46a1-9f2b-4a21c69c1a19"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				ModifiedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d79b74a7-51f5-43a9-a84d-59ba26573a45"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				ModifiedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("82e59008-cb5c-449d-8cb9-5d5f5d599467"),
				Name = @"SysModuleGrid",
				ReferenceSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				ModifiedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("66c9b1e3-02af-4dcc-a65b-aef6b8ff9ea6"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				ModifiedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a21aecf5-aaf2-4940-9015-cb40c72e374a"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
				ModifiedInSchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"),
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
			return new SysModulePrimaryGrid(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModulePrimaryGrid_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModulePrimaryGridSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModulePrimaryGridSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModulePrimaryGrid

	/// <summary>
	/// Main list of section.
	/// </summary>
	public class SysModulePrimaryGrid : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModulePrimaryGrid(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModulePrimaryGrid";
		}

		public SysModulePrimaryGrid(SysModulePrimaryGrid source)
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
		public Guid SysModuleId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleId");
			}
			set {
				SetColumnValue("SysModuleId", value);
				_sysModule = null;
			}
		}

		/// <exclude/>
		public string SysModuleCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleCaption");
			}
			set {
				SetColumnValue("SysModuleCaption", value);
				if (_sysModule != null) {
					_sysModule.Caption = value;
				}
			}
		}

		private SysModule _sysModule;
		/// <summary>
		/// Section.
		/// </summary>
		public SysModule SysModule {
			get {
				return _sysModule ??
					(_sysModule = LookupColumnEntities.GetEntity("SysModule") as SysModule);
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
		/// Contextual help Id.
		/// </summary>
		public string HelpContextId {
			get {
				return GetTypedColumnValue<string>("HelpContextId");
			}
			set {
				SetColumnValue("HelpContextId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModulePrimaryGrid_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModulePrimaryGridDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModulePrimaryGridDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModulePrimaryGridInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModulePrimaryGridInserting", e);
			Saved += (s, e) => ThrowEvent("SysModulePrimaryGridSaved", e);
			Saving += (s, e) => ThrowEvent("SysModulePrimaryGridSaving", e);
			Validating += (s, e) => ThrowEvent("SysModulePrimaryGridValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModulePrimaryGrid(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModulePrimaryGrid_BaseEventsProcess

	/// <exclude/>
	public partial class SysModulePrimaryGrid_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModulePrimaryGrid
	{

		public SysModulePrimaryGrid_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModulePrimaryGrid_BaseEventsProcess";
			SchemaUId = new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("50abd653-3e4f-43d0-86ad-b0537d4ba42b");
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

	#region Class: SysModulePrimaryGrid_BaseEventsProcess

	/// <exclude/>
	public class SysModulePrimaryGrid_BaseEventsProcess : SysModulePrimaryGrid_BaseEventsProcess<SysModulePrimaryGrid>
	{

		public SysModulePrimaryGrid_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModulePrimaryGrid_BaseEventsProcess

	public partial class SysModulePrimaryGrid_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModulePrimaryGridEventsProcess

	/// <exclude/>
	public class SysModulePrimaryGridEventsProcess : SysModulePrimaryGrid_BaseEventsProcess
	{

		public SysModulePrimaryGridEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

