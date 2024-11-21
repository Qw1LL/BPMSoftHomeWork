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

	#region Class: WSColourOfFieldSchema

	/// <exclude/>
	public class WSColourOfFieldSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WSColourOfFieldSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSColourOfFieldSchema(WSColourOfFieldSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSColourOfFieldSchema(WSColourOfFieldSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			RealUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			Name = "WSColourOfField";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d");
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
			if (Columns.FindByUId(new Guid("13525894-f05e-4bba-a117-48263bc35e5a")) == null) {
				Columns.Add(CreateWSNotesColumn());
			}
			if (Columns.FindByUId(new Guid("d3bf571c-0346-4012-bb16-1e0ba0f96543")) == null) {
				Columns.Add(CreateWSFolderColumn());
			}
			if (Columns.FindByUId(new Guid("74d5db62-2dbe-44e0-b167-48f321fdb31d")) == null) {
				Columns.Add(CreateWSColumnCodeColumn());
			}
			if (Columns.FindByUId(new Guid("7cdd76aa-e2e9-471f-af95-b7f0d9caa774")) == null) {
				Columns.Add(CreateWSColumnColumn());
			}
			if (Columns.FindByUId(new Guid("8085ff40-ddf4-48be-af62-ebc1a2346bcc")) == null) {
				Columns.Add(CreateWSColorColumn());
			}
			if (Columns.FindByUId(new Guid("35747aba-a60e-4833-b90d-23655c8c1c37")) == null) {
				Columns.Add(CreateWSContactColumn());
			}
			if (Columns.FindByUId(new Guid("b9c32bfa-8a2b-4db2-8454-db1876982469")) == null) {
				Columns.Add(CreateWSColorFontColumn());
			}
			if (Columns.FindByUId(new Guid("a75b2164-b9c8-4883-9602-f31c611729a1")) == null) {
				Columns.Add(CreateWSActiveColumn());
			}
			if (Columns.FindByUId(new Guid("75e7fcb5-5331-41b1-985f-7f020fca6bed")) == null) {
				Columns.Add(CreateWSRoleColumn());
			}
			if (Columns.FindByUId(new Guid("3104b77d-cbef-488f-96ef-dc0b7cbc8146")) == null) {
				Columns.Add(CreateWSSerializedFilterColumn());
			}
			if (Columns.FindByUId(new Guid("650df146-c9f4-47e3-864a-488472886437")) == null) {
				Columns.Add(CreateWSModuleNameColumn());
			}
			if (Columns.FindByUId(new Guid("813b9476-58f2-4454-bdfa-90cb64bbbd32")) == null) {
				Columns.Add(CreateWSColorRuleTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7768d3db-0d8c-474c-b8f8-6a34effa4556")) == null) {
				Columns.Add(CreateWSPriorityColumn());
			}
			if (Columns.FindByUId(new Guid("c19ccfe7-ae84-4a40-8bf3-a39c60548859")) == null) {
				Columns.Add(CreateWSSchemaIdColumn());
			}
			if (Columns.FindByUId(new Guid("a154cf69-4fc5-48d9-9175-75e953223df2")) == null) {
				Columns.Add(CreateWSSchemaNameColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWSNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("69e93b88-7ef0-41ab-9d35-f0b25d7be787"),
				Name = @"WSName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("13525894-f05e-4bba-a117-48263bc35e5a"),
				Name = @"WSNotes",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d3bf571c-0346-4012-bb16-1e0ba0f96543"),
				Name = @"WSFolder",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColumnCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("74d5db62-2dbe-44e0-b167-48f321fdb31d"),
				Name = @"WSColumnCode",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7cdd76aa-e2e9-471f-af95-b7f0d9caa774"),
				Name = @"WSColumn",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8085ff40-ddf4-48be-af62-ebc1a2346bcc"),
				Name = @"WSColor",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("35747aba-a60e-4833-b90d-23655c8c1c37"),
				Name = @"WSContact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWSColorFontColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b9c32bfa-8a2b-4db2-8454-db1876982469"),
				Name = @"WSColorFont",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a75b2164-b9c8-4883-9602-f31c611729a1"),
				Name = @"WSActive",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWSRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("75e7fcb5-5331-41b1-985f-7f020fca6bed"),
				Name = @"WSRole",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSSerializedFilterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3104b77d-cbef-488f-96ef-dc0b7cbc8146"),
				Name = @"WSSerializedFilter",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSModuleNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("650df146-c9f4-47e3-864a-488472886437"),
				Name = @"WSModuleName",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d")
			};
		}

		protected virtual EntitySchemaColumn CreateWSColorRuleTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("813b9476-58f2-4454-bdfa-90cb64bbbd32"),
				Name = @"WSColorRuleType",
				ReferenceSchemaUId = new Guid("4eab961e-5f91-4f66-8e91-95a653fd8371"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"a08d7efd-6ca5-4ba3-86bb-35d4ebd7e02e"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWSPriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("7768d3db-0d8c-474c-b8f8-6a34effa4556"),
				Name = @"WSPriority",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("0b5cfdfd-ab13-4d8b-93a0-61a7172b646d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateWSSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c19ccfe7-ae84-4a40-8bf3-a39c60548859"),
				Name = @"WSSchemaId",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				CreatedInPackageId = new Guid("888c96b7-111b-45cc-afbe-4bc4e58377c0")
			};
		}

		protected virtual EntitySchemaColumn CreateWSSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("a154cf69-4fc5-48d9-9175-75e953223df2"),
				Name = @"WSSchemaName",
				CreatedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
				ModifiedInSchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"),
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
			return new WSColourOfField(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSColourOfField_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSColourOfFieldSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSColourOfFieldSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9"));
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfField

	/// <summary>
	/// Правила цветового выделения.
	/// </summary>
	public class WSColourOfField : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WSColourOfField(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfField";
		}

		public WSColourOfField(WSColourOfField source)
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
		/// Описание.
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
		/// Цвет фона.
		/// </summary>
		public string WSColor {
			get {
				return GetTypedColumnValue<string>("WSColor");
			}
			set {
				SetColumnValue("WSColor", value);
			}
		}

		/// <exclude/>
		public Guid WSContactId {
			get {
				return GetTypedColumnValue<Guid>("WSContactId");
			}
			set {
				SetColumnValue("WSContactId", value);
				_wSContact = null;
			}
		}

		/// <exclude/>
		public string WSContactName {
			get {
				return GetTypedColumnValue<string>("WSContactName");
			}
			set {
				SetColumnValue("WSContactName", value);
				if (_wSContact != null) {
					_wSContact.Name = value;
				}
			}
		}

		private Contact _wSContact;
		/// <summary>
		/// Контакт пользователя.
		/// </summary>
		public Contact WSContact {
			get {
				return _wSContact ??
					(_wSContact = LookupColumnEntities.GetEntity("WSContact") as Contact);
			}
		}

		/// <summary>
		/// Цвет шрифта.
		/// </summary>
		public string WSColorFont {
			get {
				return GetTypedColumnValue<string>("WSColorFont");
			}
			set {
				SetColumnValue("WSColorFont", value);
			}
		}

		/// <summary>
		/// Активно.
		/// </summary>
		public bool WSActive {
			get {
				return GetTypedColumnValue<bool>("WSActive");
			}
			set {
				SetColumnValue("WSActive", value);
			}
		}

		/// <exclude/>
		public Guid WSRoleId {
			get {
				return GetTypedColumnValue<Guid>("WSRoleId");
			}
			set {
				SetColumnValue("WSRoleId", value);
				_wSRole = null;
			}
		}

		/// <exclude/>
		public string WSRoleName {
			get {
				return GetTypedColumnValue<string>("WSRoleName");
			}
			set {
				SetColumnValue("WSRoleName", value);
				if (_wSRole != null) {
					_wSRole.Name = value;
				}
			}
		}

		private SysAdminUnit _wSRole;
		/// <summary>
		/// Роль.
		/// </summary>
		public SysAdminUnit WSRole {
			get {
				return _wSRole ??
					(_wSRole = LookupColumnEntities.GetEntity("WSRole") as SysAdminUnit);
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

		/// <exclude/>
		public Guid WSColorRuleTypeId {
			get {
				return GetTypedColumnValue<Guid>("WSColorRuleTypeId");
			}
			set {
				SetColumnValue("WSColorRuleTypeId", value);
				_wSColorRuleType = null;
			}
		}

		/// <exclude/>
		public string WSColorRuleTypeWSName {
			get {
				return GetTypedColumnValue<string>("WSColorRuleTypeWSName");
			}
			set {
				SetColumnValue("WSColorRuleTypeWSName", value);
				if (_wSColorRuleType != null) {
					_wSColorRuleType.WSName = value;
				}
			}
		}

		private WSColorRuleType _wSColorRuleType;
		/// <summary>
		/// Область применения.
		/// </summary>
		public WSColorRuleType WSColorRuleType {
			get {
				return _wSColorRuleType ??
					(_wSColorRuleType = LookupColumnEntities.GetEntity("WSColorRuleType") as WSColorRuleType);
			}
		}

		/// <summary>
		/// Приоритетность.
		/// </summary>
		public Decimal WSPriority {
			get {
				return GetTypedColumnValue<Decimal>("WSPriority");
			}
			set {
				SetColumnValue("WSPriority", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSColourOfField_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSColourOfFieldDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSColourOfField(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSColourOfField_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSColourOfField_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WSColourOfField
	{

		public WSColourOfField_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSColourOfField_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ae41d0ef-e9e5-4b75-b7c8-3044e9b892b9");
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

	#region Class: WSColourOfField_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSColourOfField_WSFieldsmanagementEventsProcess : WSColourOfField_WSFieldsmanagementEventsProcess<WSColourOfField>
	{

		public WSColourOfField_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSColourOfField_WSFieldsmanagementEventsProcess

	public partial class WSColourOfField_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSColourOfFieldEventsProcess

	/// <exclude/>
	public class WSColourOfFieldEventsProcess : WSColourOfField_WSFieldsmanagementEventsProcess
	{

		public WSColourOfFieldEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

