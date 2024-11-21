namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastColumn

	/// <exclude/>
	public class ForecastColumn : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastColumn";
		}

		public ForecastColumn(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastColumn";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountForecast> AccountForecastCollectionByForecastColumn {
			get;
			set;
		}

		public IEnumerable<ContactForecast> ContactForecastCollectionByForecastColumn {
			get;
			set;
		}

		public IEnumerable<ForecastHistDrilldown> ForecastHistDrilldownCollectionByColumn {
			get;
			set;
		}

		public IEnumerable<ForecastHistoryCell> ForecastHistoryCellCollectionByColumn {
			get;
			set;
		}

		public IEnumerable<ForecastObjValueRecord> ForecastObjValueRecordCollectionByColumn {
			get;
			set;
		}

		public IEnumerable<LeadTypeForecast> LeadTypeForecastCollectionByForecastColumn {
			get;
			set;
		}

		public IEnumerable<OppDepartmentForecast> OppDepartmentForecastCollectionByForecastColumn {
			get;
			set;
		}

		public IEnumerable<ProductForecast> ProductForecastCollectionByForecastColumn {
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
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <exclude/>
		public Guid SheetId {
			get {
				return GetTypedColumnValue<Guid>("SheetId");
			}
			set {
				SetColumnValue("SheetId", value);
				_sheet = null;
			}
		}

		/// <exclude/>
		public string SheetName {
			get {
				return GetTypedColumnValue<string>("SheetName");
			}
			set {
				SetColumnValue("SheetName", value);
				if (_sheet != null) {
					_sheet.Name = value;
				}
			}
		}

		private ForecastSheet _sheet;
		/// <summary>
		/// Лист планирования.
		/// </summary>
		public ForecastSheet Sheet {
			get {
				return _sheet ??
					(_sheet = new ForecastSheet(LookupColumnEntities.GetEntity("Sheet")));
			}
		}

		/// <exclude/>
		public Guid IndicatorId {
			get {
				return GetTypedColumnValue<Guid>("IndicatorId");
			}
			set {
				SetColumnValue("IndicatorId", value);
				_indicator = null;
			}
		}

		/// <exclude/>
		public string IndicatorName {
			get {
				return GetTypedColumnValue<string>("IndicatorName");
			}
			set {
				SetColumnValue("IndicatorName", value);
				if (_indicator != null) {
					_indicator.Name = value;
				}
			}
		}

		private ForecastIndicator _indicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator Indicator {
			get {
				return _indicator ??
					(_indicator = new ForecastIndicator(LookupColumnEntities.GetEntity("Indicator")));
			}
		}

		/// <summary>
		/// Настройки колонки.
		/// </summary>
		public string Settings {
			get {
				return GetTypedColumnValue<string>("Settings");
			}
			set {
				SetColumnValue("Settings", value);
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

		private ForecastColumnType _type;
		/// <summary>
		/// Тип колонки.
		/// </summary>
		public ForecastColumnType Type {
			get {
				return _type ??
					(_type = new ForecastColumnType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Скрывать колонку.
		/// </summary>
		public bool IsHide {
			get {
				return GetTypedColumnValue<bool>("IsHide");
			}
			set {
				SetColumnValue("IsHide", value);
			}
		}

		#endregion

	}

	#endregion

}

