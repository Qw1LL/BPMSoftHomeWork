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

	#region Class: SysModuleDetailSchema

	/// <exclude/>
	public class SysModuleDetailSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleDetailSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleDetailSchema(SysModuleDetailSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleDetailSchema(SysModuleDetailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675");
			RealUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675");
			Name = "SysModuleDetail";
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
			if (Columns.FindByUId(new Guid("f9ca8dd6-d2e3-4aee-b150-adff370afc22")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("8905fbc3-3962-4925-aab1-cdcf3f7c7acb")) == null) {
				Columns.Add(CreateSysModuleGridColumn());
			}
			if (Columns.FindByUId(new Guid("4eec92e2-97d0-4f92-baf7-af8b2dee04be")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("0595ba17-d826-4989-a9fc-8c7c0a4c7858")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("27165c5b-f3c0-453c-b2d5-1802d624cfd1"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				ModifiedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f9ca8dd6-d2e3-4aee-b150-adff370afc22"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				ModifiedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8905fbc3-3962-4925-aab1-cdcf3f7c7acb"),
				Name = @"SysModuleGrid",
				ReferenceSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				ModifiedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4eec92e2-97d0-4f92-baf7-af8b2dee04be"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				ModifiedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0595ba17-d826-4989-a9fc-8c7c0a4c7858"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				ModifiedInSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleDetail(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleDetail_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleDetailSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleDetailSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fac3d18a-97ac-4d97-8997-31241d391675"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDetail

	/// <summary>
	/// Detail.
	/// </summary>
	public class SysModuleDetail : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleDetail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleDetail";
		}

		public SysModuleDetail(SysModuleDetail source)
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
			var process = new SysModuleDetail_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleDetailDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleDetailDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleDetailInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleDetailInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleDetailSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleDetailSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleDetailValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleDetail(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDetail_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleDetail_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleDetail
	{

		public SysModuleDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleDetail_BaseEventsProcess";
			SchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fac3d18a-97ac-4d97-8997-31241d391675");
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

	#region Class: SysModuleDetail_BaseEventsProcess

	/// <exclude/>
	public class SysModuleDetail_BaseEventsProcess : SysModuleDetail_BaseEventsProcess<SysModuleDetail>
	{

		public SysModuleDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleDetail_BaseEventsProcess

	public partial class SysModuleDetail_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleDetailEventsProcess

	/// <exclude/>
	public class SysModuleDetailEventsProcess : SysModuleDetail_BaseEventsProcess
	{

		public SysModuleDetailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

