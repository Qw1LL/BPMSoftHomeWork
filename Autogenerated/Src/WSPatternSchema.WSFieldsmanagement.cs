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

	#region Class: WSPatternSchema

	/// <exclude/>
	public class WSPatternSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WSPatternSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSPatternSchema(WSPatternSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSPatternSchema(WSPatternSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			RealUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			Name = "WSPattern";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateWSNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1e934738-240a-4c57-a047-89ed776cbf5a")) == null) {
				Columns.Add(CreateWSNotesColumn());
			}
			if (Columns.FindByUId(new Guid("ebac6d2d-53a0-47bc-8e28-8e1ff731bafc")) == null) {
				Columns.Add(CreateWSFolderColumn());
			}
			if (Columns.FindByUId(new Guid("93c2c6e6-3106-4062-bd1c-7a74cd25f994")) == null) {
				Columns.Add(CreateWSColumnCodeColumn());
			}
			if (Columns.FindByUId(new Guid("d0de83ec-824a-4335-b5d3-a046742b49a0")) == null) {
				Columns.Add(CreateWSColumnColumn());
			}
			if (Columns.FindByUId(new Guid("9db391d1-0e10-4763-8cdf-8f2875021666")) == null) {
				Columns.Add(CreateWSLookupColumn());
			}
			if (Columns.FindByUId(new Guid("853d0a74-06ec-48e1-9612-ef738009d3e5")) == null) {
				Columns.Add(CreateWSLookupValueColumn());
			}
			if (Columns.FindByUId(new Guid("8270c2e4-2f1f-4934-a4a3-6df5e441213c")) == null) {
				Columns.Add(CreateWSLookupCodeColumn());
			}
			if (Columns.FindByUId(new Guid("72ee92c2-acf3-4e2a-9ca4-0a56f12e55c8")) == null) {
				Columns.Add(CreateWSRegularColumn());
			}
			if (Columns.FindByUId(new Guid("1ca7cb1b-4f89-4681-bbd1-85e2c3f955ae")) == null) {
				Columns.Add(CreateWSMaskColumn());
			}
			if (Columns.FindByUId(new Guid("5f7142af-ef81-440e-8e22-17906e0705f3")) == null) {
				Columns.Add(CreateWSLookupGuidColumn());
			}
			if (Columns.FindByUId(new Guid("616f97d2-07c3-4fbb-beee-4165b392f581")) == null) {
				Columns.Add(CreateWSJSCodeColumn());
			}
			if (Columns.FindByUId(new Guid("8b55cc69-0a12-4b6a-9edd-fbf22b579766")) == null) {
				Columns.Add(CreateWSPermitSymbolsColumn());
			}
			if (Columns.FindByUId(new Guid("ceff1c88-7572-4b87-98ae-1140ab88ec9f")) == null) {
				Columns.Add(CreateWSIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("88e86339-cda9-4992-977e-57661a041132")) == null) {
				Columns.Add(CreateWSSerializedFilterColumn());
			}
			if (Columns.FindByUId(new Guid("0dcd65cd-a67f-4801-ab42-eaac76329418")) == null) {
				Columns.Add(CreateWSModuleNameColumn());
			}
			if (Columns.FindByUId(new Guid("436a51d9-0c46-498c-ad3f-8988a70e2f3c")) == null) {
				Columns.Add(CreateWSSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("857d18d5-4fc7-4407-be05-222913db60c7")) == null) {
				Columns.Add(CreateWSSchemaIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("733035ce-752a-4547-aaa8-727ee62b6eed"),
				Name = @"WSName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1e934738-240a-4c57-a047-89ed776cbf5a"),
				Name = @"WSNotes",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateWSFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ebac6d2d-53a0-47bc-8e28-8e1ff731bafc"),
				Name = @"WSFolder",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColumnCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("93c2c6e6-3106-4062-bd1c-7a74cd25f994"),
				Name = @"WSColumnCode",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d0de83ec-824a-4335-b5d3-a046742b49a0"),
				Name = @"WSColumn",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSLookupColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9db391d1-0e10-4763-8cdf-8f2875021666"),
				Name = @"WSLookup",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSLookupValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("853d0a74-06ec-48e1-9612-ef738009d3e5"),
				Name = @"WSLookupValue",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSLookupCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8270c2e4-2f1f-4934-a4a3-6df5e441213c"),
				Name = @"WSLookupCode",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSRegularColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("72ee92c2-acf3-4e2a-9ca4-0a56f12e55c8"),
				Name = @"WSRegular",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSMaskColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1ca7cb1b-4f89-4681-bbd1-85e2c3f955ae"),
				Name = @"WSMask",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSLookupGuidColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5f7142af-ef81-440e-8e22-17906e0705f3"),
				Name = @"WSLookupGuid",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSJSCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("616f97d2-07c3-4fbb-beee-4165b392f581"),
				Name = @"WSJSCode",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSPermitSymbolsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("8b55cc69-0a12-4b6a-9edd-fbf22b579766"),
				Name = @"WSPermitSymbols",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ceff1c88-7572-4b87-98ae-1140ab88ec9f"),
				Name = @"WSIsActive",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWSSerializedFilterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("88e86339-cda9-4992-977e-57661a041132"),
				Name = @"WSSerializedFilter",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSModuleNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0dcd65cd-a67f-4801-ab42-eaac76329418"),
				Name = @"WSModuleName",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057")
			};
		}

		protected virtual EntitySchemaColumn CreateWSSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("436a51d9-0c46-498c-ad3f-8988a70e2f3c"),
				Name = @"WSSchemaName",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("888c96b7-111b-45cc-afbe-4bc4e58377c0")
			};
		}

		protected virtual EntitySchemaColumn CreateWSSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("857d18d5-4fc7-4407-be05-222913db60c7"),
				Name = @"WSSchemaId",
				CreatedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				ModifiedInSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"),
				CreatedInPackageId = new Guid("888c96b7-111b-45cc-afbe-4bc4e58377c0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSPattern(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSPattern_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSPatternSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSPatternSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226"));
		}

		#endregion

	}

	#endregion

	#region Class: WSPattern

	/// <summary>
	/// Правила ввода.
	/// </summary>
	public class WSPattern : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WSPattern(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSPattern";
		}

		public WSPattern(WSPattern source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string WSName {
			get {
				return GetTypedColumnValue<string>("WSName");
			}
			set {
				SetColumnValue("WSName", value);
			}
		}

		/// <summary>
		/// Текст ошибки.
		/// </summary>
		public string WSNotes {
			get {
				return GetTypedColumnValue<string>("WSNotes");
			}
			set {
				SetColumnValue("WSNotes", value);
			}
		}

		/// <exclude/>
		public Guid WSFolderId {
			get {
				return GetTypedColumnValue<Guid>("WSFolderId");
			}
			set {
				SetColumnValue("WSFolderId", value);
				_wSFolder = null;
			}
		}

		/// <exclude/>
		public string WSFolderCaption {
			get {
				return GetTypedColumnValue<string>("WSFolderCaption");
			}
			set {
				SetColumnValue("WSFolderCaption", value);
				if (_wSFolder != null) {
					_wSFolder.Caption = value;
				}
			}
		}

		private SysSchema _wSFolder;
		/// <summary>
		/// Объект.
		/// </summary>
		public SysSchema WSFolder {
			get {
				return _wSFolder ??
					(_wSFolder = LookupColumnEntities.GetEntity("WSFolder") as SysSchema);
			}
		}

		/// <summary>
		/// Код колонки.
		/// </summary>
		public string WSColumnCode {
			get {
				return GetTypedColumnValue<string>("WSColumnCode");
			}
			set {
				SetColumnValue("WSColumnCode", value);
			}
		}

		/// <summary>
		/// Колонка на странице.
		/// </summary>
		public string WSColumn {
			get {
				return GetTypedColumnValue<string>("WSColumn");
			}
			set {
				SetColumnValue("WSColumn", value);
			}
		}

		/// <summary>
		/// Справочник.
		/// </summary>
		public string WSLookup {
			get {
				return GetTypedColumnValue<string>("WSLookup");
			}
			set {
				SetColumnValue("WSLookup", value);
			}
		}

		/// <summary>
		/// Значение справочника.
		/// </summary>
		public string WSLookupValue {
			get {
				return GetTypedColumnValue<string>("WSLookupValue");
			}
			set {
				SetColumnValue("WSLookupValue", value);
			}
		}

		/// <summary>
		/// Код справочной колонки.
		/// </summary>
		public string WSLookupCode {
			get {
				return GetTypedColumnValue<string>("WSLookupCode");
			}
			set {
				SetColumnValue("WSLookupCode", value);
			}
		}

		/// <summary>
		/// Регулярное выражение для валидации.
		/// </summary>
		public string WSRegular {
			get {
				return GetTypedColumnValue<string>("WSRegular");
			}
			set {
				SetColumnValue("WSRegular", value);
			}
		}

		/// <summary>
		/// Маска.
		/// </summary>
		public string WSMask {
			get {
				return GetTypedColumnValue<string>("WSMask");
			}
			set {
				SetColumnValue("WSMask", value);
			}
		}

		/// <summary>
		/// Guid справочника.
		/// </summary>
		public string WSLookupGuid {
			get {
				return GetTypedColumnValue<string>("WSLookupGuid");
			}
			set {
				SetColumnValue("WSLookupGuid", value);
			}
		}

		/// <summary>
		/// Код Javascript.
		/// </summary>
		public string WSJSCode {
			get {
				return GetTypedColumnValue<string>("WSJSCode");
			}
			set {
				SetColumnValue("WSJSCode", value);
			}
		}

		/// <summary>
		/// Разрешённые символы.
		/// </summary>
		public string WSPermitSymbols {
			get {
				return GetTypedColumnValue<string>("WSPermitSymbols");
			}
			set {
				SetColumnValue("WSPermitSymbols", value);
			}
		}

		/// <summary>
		/// Активно.
		/// </summary>
		public bool WSIsActive {
			get {
				return GetTypedColumnValue<bool>("WSIsActive");
			}
			set {
				SetColumnValue("WSIsActive", value);
			}
		}

		/// <summary>
		/// Данные фильтра.
		/// </summary>
		public string WSSerializedFilter {
			get {
				return GetTypedColumnValue<string>("WSSerializedFilter");
			}
			set {
				SetColumnValue("WSSerializedFilter", value);
			}
		}

		/// <summary>
		/// WSModuleName.
		/// </summary>
		public string WSModuleName {
			get {
				return GetTypedColumnValue<string>("WSModuleName");
			}
			set {
				SetColumnValue("WSModuleName", value);
			}
		}

		/// <summary>
		/// Название схемы объекта.
		/// </summary>
		public string WSSchemaName {
			get {
				return GetTypedColumnValue<string>("WSSchemaName");
			}
			set {
				SetColumnValue("WSSchemaName", value);
			}
		}

		/// <summary>
		/// Id схемы объекта.
		/// </summary>
		public string WSSchemaId {
			get {
				return GetTypedColumnValue<string>("WSSchemaId");
			}
			set {
				SetColumnValue("WSSchemaId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSPattern_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSPatternDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSPattern(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSPattern_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSPattern_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WSPattern
	{

		public WSPattern_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSPattern_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
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

	#region Class: WSPattern_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSPattern_WSFieldsmanagementEventsProcess : WSPattern_WSFieldsmanagementEventsProcess<WSPattern>
	{

		public WSPattern_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSPattern_WSFieldsmanagementEventsProcess

	public partial class WSPattern_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSPatternEventsProcess

	/// <exclude/>
	public class WSPatternEventsProcess : WSPattern_WSFieldsmanagementEventsProcess
	{

		public WSPatternEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

