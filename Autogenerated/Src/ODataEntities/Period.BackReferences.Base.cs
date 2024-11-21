namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Period

	/// <exclude/>
	public class Period : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Period(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Period";
		}

		public Period(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Period";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<AccountForecast> AccountForecastCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<ContactForecast> ContactForecastCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<ForecastHistDrilldown> ForecastHistDrilldownCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<ForecastHistoryCell> ForecastHistoryCellCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<ForecastItemValue> ForecastItemValueCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<ForecastObjValueRecord> ForecastObjValueRecordCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<LeadTypeForecast> LeadTypeForecastCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<OppDepartmentForecast> OppDepartmentForecastCollectionByPeriod {
			get;
			set;
		}

		public IEnumerable<Period> PeriodCollectionByParent {
			get;
			set;
		}

		public IEnumerable<Period> PeriodCollectionByQuarter {
			get;
			set;
		}

		public IEnumerable<Period> PeriodCollectionByYear {
			get;
			set;
		}

		public IEnumerable<ProductForecast> ProductForecastCollectionByPeriod {
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
		/// Название.
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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
		/// Дата начала периода.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Дата окончания периода.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid PeriodTypeId {
			get {
				return GetTypedColumnValue<Guid>("PeriodTypeId");
			}
			set {
				SetColumnValue("PeriodTypeId", value);
				_periodType = null;
			}
		}

		/// <exclude/>
		public string PeriodTypeName {
			get {
				return GetTypedColumnValue<string>("PeriodTypeName");
			}
			set {
				SetColumnValue("PeriodTypeName", value);
				if (_periodType != null) {
					_periodType.Name = value;
				}
			}
		}

		private PeriodType _periodType;
		/// <summary>
		/// Тип периода.
		/// </summary>
		public PeriodType PeriodType {
			get {
				return _periodType ??
					(_periodType = new PeriodType(LookupColumnEntities.GetEntity("PeriodType")));
			}
		}

		/// <exclude/>
		public Guid YearId {
			get {
				return GetTypedColumnValue<Guid>("YearId");
			}
			set {
				SetColumnValue("YearId", value);
				_year = null;
			}
		}

		/// <exclude/>
		public string YearName {
			get {
				return GetTypedColumnValue<string>("YearName");
			}
			set {
				SetColumnValue("YearName", value);
				if (_year != null) {
					_year.Name = value;
				}
			}
		}

		private Period _year;
		/// <summary>
		/// Год.
		/// </summary>
		public Period Year {
			get {
				return _year ??
					(_year = new Period(LookupColumnEntities.GetEntity("Year")));
			}
		}

		/// <exclude/>
		public Guid QuarterId {
			get {
				return GetTypedColumnValue<Guid>("QuarterId");
			}
			set {
				SetColumnValue("QuarterId", value);
				_quarter = null;
			}
		}

		/// <exclude/>
		public string QuarterName {
			get {
				return GetTypedColumnValue<string>("QuarterName");
			}
			set {
				SetColumnValue("QuarterName", value);
				if (_quarter != null) {
					_quarter.Name = value;
				}
			}
		}

		private Period _quarter;
		/// <summary>
		/// Квартал.
		/// </summary>
		public Period Quarter {
			get {
				return _quarter ??
					(_quarter = new Period(LookupColumnEntities.GetEntity("Quarter")));
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private Period _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public Period Parent {
			get {
				return _parent ??
					(_parent = new Period(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		#endregion

	}

	#endregion

}

