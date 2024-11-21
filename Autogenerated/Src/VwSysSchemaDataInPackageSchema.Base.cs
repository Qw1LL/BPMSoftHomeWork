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

	#region Class: VwSysSchemaDataInPackageSchema

	/// <exclude/>
	public class VwSysSchemaDataInPackageSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysSchemaDataInPackageSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaDataInPackageSchema(VwSysSchemaDataInPackageSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaDataInPackageSchema(VwSysSchemaDataInPackageSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			RealUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			Name = "VwSysSchemaDataInPackage";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("16008da7-8afe-4ea8-861b-4ddce12edb94")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("233a9217-e97b-4e4e-98d7-1f7c31dd5621")) == null) {
				Columns.Add(CreateInstallTypeColumn());
			}
			if (Columns.FindByUId(new Guid("fcf77d40-2964-4f5a-98ee-04ca14da3630")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("4df4842e-a9a8-4393-8725-01782e311cde")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("a846a203-2c60-4d9f-b388-720f1ba7096b")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
			if (Columns.FindByUId(new Guid("19c31e83-044d-4392-a083-80c5d9057b12")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("d900439b-a84f-424d-88fc-9ab45a1eb0ca")) == null) {
				Columns.Add(CreateNeedInstallColumn());
			}
			if (Columns.FindByUId(new Guid("0bb3534c-5d07-4b94-aca7-1f6632cae4de")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			column.CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16008da7-8afe-4ea8-861b-4ddce12edb94"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ValueList")) {
				UId = new Guid("233a9217-e97b-4e4e-98d7-1f7c31dd5621"),
				Name = @"InstallType",
				ReferenceValueListSchemaUId = new Guid("8598c861-bf61-4e11-a7d8-4f8b030ea0f6"),
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fcf77d40-2964-4f5a-98ee-04ca14da3630"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4df4842e-a9a8-4393-8725-01782e311cde"),
				Name = @"IsChanged",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a846a203-2c60-4d9f-b388-720f1ba7096b"),
				Name = @"IsLocked",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("19c31e83-044d-4392-a083-80c5d9057b12"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedInstallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d900439b-a84f-424d-88fc-9ab45a1eb0ca"),
				Name = @"NeedInstall",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("0bb3534c-5d07-4b94-aca7-1f6632cae4de"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				ModifiedInSchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSchemaDataInPackage(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaDataInPackage_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaDataInPackageSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaDataInPackageSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaDataInPackage

	/// <summary>
	/// Data of package schema (view).
	/// </summary>
	public class VwSysSchemaDataInPackage : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysSchemaDataInPackage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaDataInPackage";
		}

		public VwSysSchemaDataInPackage(VwSysSchemaDataInPackage source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		/// <summary>
		/// Data installation type.
		/// </summary>
		public SysPackageSchemaDataInstallType? InstallType {
			get {
				return GetTypedColumnValue<SysPackageSchemaDataInstallType>("InstallType");
			}
			set {
				SetColumnValue("InstallType", value);
			}
		}

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Modified.
		/// </summary>
		public bool IsChanged {
			get {
				return GetTypedColumnValue<bool>("IsChanged");
			}
			set {
				SetColumnValue("IsChanged", value);
			}
		}

		/// <summary>
		/// Locked.
		/// </summary>
		public bool IsLocked {
			get {
				return GetTypedColumnValue<bool>("IsLocked");
			}
			set {
				SetColumnValue("IsLocked", value);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Needs to be installed in database.
		/// </summary>
		public bool NeedInstall {
			get {
				return GetTypedColumnValue<bool>("NeedInstall");
			}
			set {
				SetColumnValue("NeedInstall", value);
			}
		}

		/// <summary>
		/// Last error message text.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaDataInPackage_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSchemaDataInPackageDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSchemaDataInPackageInserting", e);
			Validating += (s, e) => ThrowEvent("VwSysSchemaDataInPackageValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSchemaDataInPackage(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaDataInPackage_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaDataInPackage_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysSchemaDataInPackage
	{

		public VwSysSchemaDataInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaDataInPackage_BaseEventsProcess";
			SchemaUId = new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("58e1ea45-0642-4e35-b0cc-5c00627529d7");
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

	#region Class: VwSysSchemaDataInPackage_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaDataInPackage_BaseEventsProcess : VwSysSchemaDataInPackage_BaseEventsProcess<VwSysSchemaDataInPackage>
	{

		public VwSysSchemaDataInPackage_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaDataInPackage_BaseEventsProcess

	public partial class VwSysSchemaDataInPackage_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaDataInPackageEventsProcess

	/// <exclude/>
	public class VwSysSchemaDataInPackageEventsProcess : VwSysSchemaDataInPackage_BaseEventsProcess
	{

		public VwSysSchemaDataInPackageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

