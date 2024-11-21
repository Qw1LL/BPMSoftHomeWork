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

	#region Class: SysModuleDetailParentAsscSchema

	/// <exclude/>
	public class SysModuleDetailParentAsscSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleDetailParentAsscSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleDetailParentAsscSchema(SysModuleDetailParentAsscSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleDetailParentAsscSchema(SysModuleDetailParentAsscSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a");
			RealUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a");
			Name = "SysModuleDetailParentAssc";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("409a4029-8e03-4311-abff-2e90e67f1278")) == null) {
				Columns.Add(CreateSysModuleDetailColumn());
			}
			if (Columns.FindByUId(new Guid("5b8011d0-ab25-4bd3-af7f-324de8bdcb9d")) == null) {
				Columns.Add(CreateColumnMetaPathColumn());
			}
			if (Columns.FindByUId(new Guid("d4ba8734-5856-4590-9c08-bc69c0045e80")) == null) {
				Columns.Add(CreateParentColumnMetaPathColumn());
			}
			if (Columns.FindByUId(new Guid("532f9d91-9e4d-4529-87fe-e3134b350613")) == null) {
				Columns.Add(CreateSysParentAssociationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d3fc50dc-6e97-4d26-99b7-8ecbb1b5cdca")) == null) {
				Columns.Add(CreateColumnCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("4410aff7-71fb-49e9-9a60-13f48da30bc9")) == null) {
				Columns.Add(CreateParentColumnCaptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysModuleDetailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("409a4029-8e03-4311-abff-2e90e67f1278"),
				Name = @"SysModuleDetail",
				ReferenceSchemaUId = new Guid("fac3d18a-97ac-4d97-8997-31241d391675"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnMetaPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5b8011d0-ab25-4bd3-af7f-324de8bdcb9d"),
				Name = @"ColumnMetaPath",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumnMetaPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d4ba8734-5856-4590-9c08-bc69c0045e80"),
				Name = @"ParentColumnMetaPath",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateSysParentAssociationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("532f9d91-9e4d-4529-87fe-e3134b350613"),
				Name = @"SysParentAssociationType",
				ReferenceSchemaUId = new Guid("4e846bca-f751-4fd9-9059-1707707b9d9d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d3fc50dc-6e97-4d26-99b7-8ecbb1b5cdca"),
				Name = @"ColumnCaption",
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4410aff7-71fb-49e9-9a60-13f48da30bc9"),
				Name = @"ParentColumnCaption",
				CreatedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
				ModifiedInSchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"),
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
			return new SysModuleDetailParentAssc(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleDetailParentAssc_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleDetailParentAsscSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleDetailParentAsscSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDetailParentAssc

	/// <summary>
	/// Detail parent connection.
	/// </summary>
	public class SysModuleDetailParentAssc : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleDetailParentAssc(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleDetailParentAssc";
		}

		public SysModuleDetailParentAssc(SysModuleDetailParentAssc source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleDetailId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleDetailId");
			}
			set {
				SetColumnValue("SysModuleDetailId", value);
				_sysModuleDetail = null;
			}
		}

		/// <exclude/>
		public string SysModuleDetailCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleDetailCaption");
			}
			set {
				SetColumnValue("SysModuleDetailCaption", value);
				if (_sysModuleDetail != null) {
					_sysModuleDetail.Caption = value;
				}
			}
		}

		private SysModuleDetail _sysModuleDetail;
		/// <summary>
		/// Detail.
		/// </summary>
		public SysModuleDetail SysModuleDetail {
			get {
				return _sysModuleDetail ??
					(_sysModuleDetail = LookupColumnEntities.GetEntity("SysModuleDetail") as SysModuleDetail);
			}
		}

		/// <summary>
		/// Column path.
		/// </summary>
		public string ColumnMetaPath {
			get {
				return GetTypedColumnValue<string>("ColumnMetaPath");
			}
			set {
				SetColumnValue("ColumnMetaPath", value);
			}
		}

		/// <summary>
		/// Path to parent column.
		/// </summary>
		public string ParentColumnMetaPath {
			get {
				return GetTypedColumnValue<string>("ParentColumnMetaPath");
			}
			set {
				SetColumnValue("ParentColumnMetaPath", value);
			}
		}

		/// <exclude/>
		public Guid SysParentAssociationTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysParentAssociationTypeId");
			}
			set {
				SetColumnValue("SysParentAssociationTypeId", value);
				_sysParentAssociationType = null;
			}
		}

		/// <exclude/>
		public string SysParentAssociationTypeName {
			get {
				return GetTypedColumnValue<string>("SysParentAssociationTypeName");
			}
			set {
				SetColumnValue("SysParentAssociationTypeName", value);
				if (_sysParentAssociationType != null) {
					_sysParentAssociationType.Name = value;
				}
			}
		}

		private SysParentAssociationType _sysParentAssociationType;
		/// <summary>
		/// Parent connection type.
		/// </summary>
		public SysParentAssociationType SysParentAssociationType {
			get {
				return _sysParentAssociationType ??
					(_sysParentAssociationType = LookupColumnEntities.GetEntity("SysParentAssociationType") as SysParentAssociationType);
			}
		}

		/// <summary>
		/// Detail column.
		/// </summary>
		public string ColumnCaption {
			get {
				return GetTypedColumnValue<string>("ColumnCaption");
			}
			set {
				SetColumnValue("ColumnCaption", value);
			}
		}

		/// <summary>
		/// Parent object column.
		/// </summary>
		public string ParentColumnCaption {
			get {
				return GetTypedColumnValue<string>("ParentColumnCaption");
			}
			set {
				SetColumnValue("ParentColumnCaption", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleDetailParentAssc_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleDetailParentAsscDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleDetailParentAsscDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleDetailParentAsscInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleDetailParentAsscInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleDetailParentAsscSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleDetailParentAsscSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleDetailParentAsscValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleDetailParentAssc(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDetailParentAssc_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleDetailParentAssc_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleDetailParentAssc
	{

		public SysModuleDetailParentAssc_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleDetailParentAssc_BaseEventsProcess";
			SchemaUId = new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d6facb3e-bfdd-42b0-84ad-0b6fc4efcc4a");
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

	#region Class: SysModuleDetailParentAssc_BaseEventsProcess

	/// <exclude/>
	public class SysModuleDetailParentAssc_BaseEventsProcess : SysModuleDetailParentAssc_BaseEventsProcess<SysModuleDetailParentAssc>
	{

		public SysModuleDetailParentAssc_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleDetailParentAssc_BaseEventsProcess

	public partial class SysModuleDetailParentAssc_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleDetailParentAsscEventsProcess

	/// <exclude/>
	public class SysModuleDetailParentAsscEventsProcess : SysModuleDetailParentAssc_BaseEventsProcess
	{

		public SysModuleDetailParentAsscEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

