namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: WSColourOfField

	/// <exclude/>
	public class WSColourOfField : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public WSColourOfField(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSColourOfField";
		}

		public WSColourOfField(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "WSColourOfField";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<WSColourOfFieldFile> WSColourOfFieldFileCollectionByWSColourOfField {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldInFolder> WSColourOfFieldInFolderCollectionByWSColourOfField {
			get;
			set;
		}

		public IEnumerable<WSColourOfFieldInTag> WSColourOfFieldInTagCollectionByEntity {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

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
					(_wSFolder = new SysSchema(LookupColumnEntities.GetEntity("WSFolder")));
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
					(_wSContact = new Contact(LookupColumnEntities.GetEntity("WSContact")));
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
					(_wSRole = new SysAdminUnit(LookupColumnEntities.GetEntity("WSRole")));
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
					(_wSColorRuleType = new WSColorRuleType(LookupColumnEntities.GetEntity("WSColorRuleType")));
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

	}

	#endregion

}

