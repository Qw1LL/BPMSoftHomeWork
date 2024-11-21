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

	#region Class: SysModuleAnalyticsReportSchema

	/// <exclude/>
	public class SysModuleAnalyticsReportSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleAnalyticsReportSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleAnalyticsReportSchema(SysModuleAnalyticsReportSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleAnalyticsReportSchema(SysModuleAnalyticsReportSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8");
			RealUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8");
			Name = "SysModuleAnalyticsReport";
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

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateLogoColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("705d2f24-dd9a-4d29-935e-d13c911d4233")) == null) {
				Columns.Add(CreateSysModuleColumn());
			}
			if (Columns.FindByUId(new Guid("145a977a-c422-4449-adf8-bf3694ea171a")) == null) {
				Columns.Add(CreateAutoPreviewColumn());
			}
			if (Columns.FindByUId(new Guid("0f81c5e2-2e36-493f-9add-110863d49195")) == null) {
				Columns.Add(CreateHelpContextIdColumn());
			}
			if (Columns.FindByUId(new Guid("adce3240-530c-4ead-843f-180aa6a17211")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("ff4acce7-a5b8-4e03-96a5-97dfb98b73c4")) == null) {
				Columns.Add(CreateSysOptionsPageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("e7bb6171-61fa-4040-98d3-eea55accfe76")) == null) {
				Columns.Add(CreateModuleSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("e59b71b1-d43c-4805-8841-5cbb1c6c444a")) == null) {
				Columns.Add(CreateTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("97421dcc-ce64-40b1-bfe2-d9b4bc906ac1"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("705d2f24-dd9a-4d29-935e-d13c911d4233"),
				Name = @"SysModule",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAutoPreviewColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("145a977a-c422-4449-adf8-bf3694ea171a"),
				Name = @"AutoPreview",
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHelpContextIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0f81c5e2-2e36-493f-9add-110863d49195"),
				Name = @"HelpContextId",
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("adce3240-530c-4ead-843f-180aa6a17211"),
				Name = @"SysSchemaUId",
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysOptionsPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ff4acce7-a5b8-4e03-96a5-97dfb98b73c4"),
				Name = @"SysOptionsPageSchemaUId",
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e7bb6171-61fa-4040-98d3-eea55accfe76"),
				Name = @"ModuleSchemaName",
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("d45dc8b6-924a-4c74-b50c-49a315ef60ce")
			};
		}

		protected virtual EntitySchemaColumn CreateLogoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("5fb3c079-8875-4697-bd76-0e38219b5c33"),
				Name = @"Logo",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("d45dc8b6-924a-4c74-b50c-49a315ef60ce")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e59b71b1-d43c-4805-8841-5cbb1c6c444a"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("0349fa8b-b851-4301-bc18-2c36e3d8bc0d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				ModifiedInSchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleAnalyticsReport(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleAnalyticsReport_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleAnalyticsReportSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleAnalyticsReportSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4198031e-41e4-461d-b124-f3ba771757c8"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleAnalyticsReport

	/// <summary>
	/// Analytics.
	/// </summary>
	public class SysModuleAnalyticsReport : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleAnalyticsReport(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleAnalyticsReport";
		}

		public SysModuleAnalyticsReport(SysModuleAnalyticsReport source)
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

		/// <summary>
		/// Automatic preview.
		/// </summary>
		public bool AutoPreview {
			get {
				return GetTypedColumnValue<bool>("AutoPreview");
			}
			set {
				SetColumnValue("AutoPreview", value);
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

		/// <summary>
		/// Unique identifier of report.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		/// <summary>
		/// Unique identifier of analytics setup.
		/// </summary>
		public Guid SysOptionsPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysOptionsPageSchemaUId");
			}
			set {
				SetColumnValue("SysOptionsPageSchemaUId", value);
			}
		}

		/// <summary>
		/// Section object name.
		/// </summary>
		public string ModuleSchemaName {
			get {
				return GetTypedColumnValue<string>("ModuleSchemaName");
			}
			set {
				SetColumnValue("ModuleSchemaName", value);
			}
		}

		/// <exclude/>
		public Guid LogoId {
			get {
				return GetTypedColumnValue<Guid>("LogoId");
			}
			set {
				SetColumnValue("LogoId", value);
				_logo = null;
			}
		}

		/// <exclude/>
		public string LogoName {
			get {
				return GetTypedColumnValue<string>("LogoName");
			}
			set {
				SetColumnValue("LogoName", value);
				if (_logo != null) {
					_logo.Name = value;
				}
			}
		}

		private SysImage _logo;
		/// <summary>
		/// Logo.
		/// </summary>
		public SysImage Logo {
			get {
				return _logo ??
					(_logo = LookupColumnEntities.GetEntity("Logo") as SysImage);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysModuleReportType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public SysModuleReportType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysModuleReportType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleAnalyticsReport_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleAnalyticsReportDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleAnalyticsReportDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleAnalyticsReportInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleAnalyticsReportInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleAnalyticsReportSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleAnalyticsReportSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleAnalyticsReportValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleAnalyticsReport(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleAnalyticsReport_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleAnalyticsReport_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleAnalyticsReport
	{

		public SysModuleAnalyticsReport_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleAnalyticsReport_BaseEventsProcess";
			SchemaUId = new Guid("4198031e-41e4-461d-b124-f3ba771757c8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4198031e-41e4-461d-b124-f3ba771757c8");
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

	#region Class: SysModuleAnalyticsReport_BaseEventsProcess

	/// <exclude/>
	public class SysModuleAnalyticsReport_BaseEventsProcess : SysModuleAnalyticsReport_BaseEventsProcess<SysModuleAnalyticsReport>
	{

		public SysModuleAnalyticsReport_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleAnalyticsReport_BaseEventsProcess

	public partial class SysModuleAnalyticsReport_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleAnalyticsReportEventsProcess

	/// <exclude/>
	public class SysModuleAnalyticsReportEventsProcess : SysModuleAnalyticsReport_BaseEventsProcess
	{

		public SysModuleAnalyticsReportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

