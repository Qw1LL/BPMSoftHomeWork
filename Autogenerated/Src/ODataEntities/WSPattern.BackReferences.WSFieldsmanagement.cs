namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: WSPattern

	/// <exclude/>
	public class WSPattern : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public WSPattern(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSPattern";
		}

		public WSPattern(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "WSPattern";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<WSPatternFile> WSPatternFileCollectionByWSPattern {
			get;
			set;
		}

		public IEnumerable<WSPatternInFolder> WSPatternInFolderCollectionByWSPattern {
			get;
			set;
		}

		public IEnumerable<WSPatternInTag> WSPatternInTagCollectionByEntity {
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

	}

	#endregion

}

