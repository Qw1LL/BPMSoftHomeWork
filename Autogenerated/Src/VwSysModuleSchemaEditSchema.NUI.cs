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

	#region Class: VwSysModuleSchemaEditSchema

	/// <exclude/>
	public class VwSysModuleSchemaEditSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysModuleSchemaEditSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysModuleSchemaEditSchema(VwSysModuleSchemaEditSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysModuleSchemaEditSchema(VwSysModuleSchemaEditSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			RealUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			Name = "VwSysModuleSchemaEdit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateEditPageCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f8a2b023-2592-4094-9e4a-247674999f2a")) == null) {
				Columns.Add(CreatePageCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("22ecd305-5150-4848-aea1-1d57314ef1d6")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("93ac5869-937f-4811-894a-cbcf73473496")) == null) {
				Columns.Add(CreateSysModuleEntityColumn());
			}
			if (Columns.FindByUId(new Guid("778e1217-88af-46f9-b9a8-848f5627f0f0")) == null) {
				Columns.Add(CreateEditPageNameColumn());
			}
			if (Columns.FindByUId(new Guid("23595ba5-36c0-4beb-9a71-8c3138296c8e")) == null) {
				Columns.Add(CreateMiniPageSchemaUIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePageCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f8a2b023-2592-4094-9e4a-247674999f2a"),
				Name = @"PageCaption",
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("22ecd305-5150-4848-aea1-1d57314ef1d6"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("93ac5869-937f-4811-894a-cbcf73473496"),
				Name = @"SysModuleEntity",
				ReferenceSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateEditPageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("778e1217-88af-46f9-b9a8-848f5627f0f0"),
				Name = @"EditPageName",
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateEditPageCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9792a8d9-506e-47a0-808e-bec0ca818f10"),
				Name = @"EditPageCaption",
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreateMiniPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("23595ba5-36c0-4beb-9a71-8c3138296c8e"),
				Name = @"MiniPageSchemaUId",
				CreatedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				ModifiedInSchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"),
				CreatedInPackageId = new Guid("69cade40-6336-4bd8-ae4c-995a74dfddfe")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysModuleSchemaEdit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysModuleSchemaEdit_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysModuleSchemaEditSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysModuleSchemaEditSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("779469a1-c8de-4e31-8151-768ee43b50a3"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleSchemaEdit

	/// <summary>
	/// Section schema card (view).
	/// </summary>
	public class VwSysModuleSchemaEdit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysModuleSchemaEdit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysModuleSchemaEdit";
		}

		public VwSysModuleSchemaEdit(VwSysModuleSchemaEdit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string PageCaption {
			get {
				return GetTypedColumnValue<string>("PageCaption");
			}
			set {
				SetColumnValue("PageCaption", value);
			}
		}

		/// <summary>
		/// Type column value.
		/// </summary>
		public string TypeColumnValue {
			get {
				return GetTypedColumnValue<string>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// SysModuleEntityId.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = LookupColumnEntities.GetEntity("SysModuleEntity") as SysModuleEntity);
			}
		}

		/// <summary>
		/// Edit page name.
		/// </summary>
		public string EditPageName {
			get {
				return GetTypedColumnValue<string>("EditPageName");
			}
			set {
				SetColumnValue("EditPageName", value);
			}
		}

		/// <summary>
		/// Edit page.
		/// </summary>
		public string EditPageCaption {
			get {
				return GetTypedColumnValue<string>("EditPageCaption");
			}
			set {
				SetColumnValue("EditPageCaption", value);
			}
		}

		/// <summary>
		/// Mini page schema UId.
		/// </summary>
		public Guid MiniPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("MiniPageSchemaUId");
			}
			set {
				SetColumnValue("MiniPageSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysModuleSchemaEdit_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysModuleSchemaEditDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysModuleSchemaEditInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysModuleSchemaEditValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysModuleSchemaEdit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysModuleSchemaEdit_NUIEventsProcess

	/// <exclude/>
	public partial class VwSysModuleSchemaEdit_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysModuleSchemaEdit
	{

		public VwSysModuleSchemaEdit_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysModuleSchemaEdit_NUIEventsProcess";
			SchemaUId = new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("779469a1-c8de-4e31-8151-768ee43b50a3");
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

	#region Class: VwSysModuleSchemaEdit_NUIEventsProcess

	/// <exclude/>
	public class VwSysModuleSchemaEdit_NUIEventsProcess : VwSysModuleSchemaEdit_NUIEventsProcess<VwSysModuleSchemaEdit>
	{

		public VwSysModuleSchemaEdit_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysModuleSchemaEdit_NUIEventsProcess

	public partial class VwSysModuleSchemaEdit_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysModuleSchemaEditEventsProcess

	/// <exclude/>
	public class VwSysModuleSchemaEditEventsProcess : VwSysModuleSchemaEdit_NUIEventsProcess
	{

		public VwSysModuleSchemaEditEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

