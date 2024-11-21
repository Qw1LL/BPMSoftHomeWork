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

	#region Class: SysModuleEditDetailSchema

	/// <exclude/>
	public class SysModuleEditDetailSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleEditDetailSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleEditDetailSchema(SysModuleEditDetailSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleEditDetailSchema(SysModuleEditDetailSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d");
			RealUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d");
			Name = "SysModuleEditDetail";
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
			if (Columns.FindByUId(new Guid("62ca3788-1388-4db8-976c-91ba8930672a")) == null) {
				Columns.Add(CreateSysModuleEditColumn());
			}
			if (Columns.FindByUId(new Guid("1af37555-5e0e-4a99-99e0-472a65641527")) == null) {
				Columns.Add(CreateSysModuleGridColumn());
			}
			if (Columns.FindByUId(new Guid("3ea6606a-f53a-4d8e-8bbb-90eda75e4509")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("e283aff8-751f-4bf5-9798-e3dd6b9f58d1")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1e0bc741-7c86-4512-955d-6948f9273acc"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				ModifiedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEditColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("62ca3788-1388-4db8-976c-91ba8930672a"),
				Name = @"SysModuleEdit",
				ReferenceSchemaUId = new Guid("24666f2d-049f-4867-ae2c-db681c40c001"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				ModifiedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleGridColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1af37555-5e0e-4a99-99e0-472a65641527"),
				Name = @"SysModuleGrid",
				ReferenceSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				ModifiedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3ea6606a-f53a-4d8e-8bbb-90eda75e4509"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				ModifiedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e283aff8-751f-4bf5-9798-e3dd6b9f58d1"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
				ModifiedInSchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d"),
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
			return new SysModuleEditDetail(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleEditDetail_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleEditDetailSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleEditDetailSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("86442450-82a2-4f99-8f51-670bcffd214d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEditDetail

	/// <summary>
	/// Section card detail.
	/// </summary>
	public class SysModuleEditDetail : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleEditDetail(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEditDetail";
		}

		public SysModuleEditDetail(SysModuleEditDetail source)
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
		public Guid SysModuleEditId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEditId");
			}
			set {
				SetColumnValue("SysModuleEditId", value);
				_sysModuleEdit = null;
			}
		}

		/// <exclude/>
		public string SysModuleEditPageCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleEditPageCaption");
			}
			set {
				SetColumnValue("SysModuleEditPageCaption", value);
				if (_sysModuleEdit != null) {
					_sysModuleEdit.PageCaption = value;
				}
			}
		}

		private SysModuleEdit _sysModuleEdit;
		/// <summary>
		/// Section card.
		/// </summary>
		public SysModuleEdit SysModuleEdit {
			get {
				return _sysModuleEdit ??
					(_sysModuleEdit = LookupColumnEntities.GetEntity("SysModuleEdit") as SysModuleEdit);
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
			var process = new SysModuleEditDetail_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleEditDetailDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleEditDetailDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleEditDetailInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleEditDetailInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleEditDetailSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleEditDetailSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleEditDetailValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleEditDetail(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEditDetail_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleEditDetail_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleEditDetail
	{

		public SysModuleEditDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleEditDetail_BaseEventsProcess";
			SchemaUId = new Guid("86442450-82a2-4f99-8f51-670bcffd214d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("86442450-82a2-4f99-8f51-670bcffd214d");
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

	#region Class: SysModuleEditDetail_BaseEventsProcess

	/// <exclude/>
	public class SysModuleEditDetail_BaseEventsProcess : SysModuleEditDetail_BaseEventsProcess<SysModuleEditDetail>
	{

		public SysModuleEditDetail_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleEditDetail_BaseEventsProcess

	public partial class SysModuleEditDetail_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleEditDetailEventsProcess

	/// <exclude/>
	public class SysModuleEditDetailEventsProcess : SysModuleEditDetail_BaseEventsProcess
	{

		public SysModuleEditDetailEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

