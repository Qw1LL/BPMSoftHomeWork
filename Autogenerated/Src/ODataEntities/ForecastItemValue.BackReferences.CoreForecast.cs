namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastItemValue

	/// <exclude/>
	public class ForecastItemValue : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastItemValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastItemValue";
		}

		public ForecastItemValue(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastItemValue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid ForecastIndicatorId {
			get {
				return GetTypedColumnValue<Guid>("ForecastIndicatorId");
			}
			set {
				SetColumnValue("ForecastIndicatorId", value);
				_forecastIndicator = null;
			}
		}

		/// <exclude/>
		public string ForecastIndicatorName {
			get {
				return GetTypedColumnValue<string>("ForecastIndicatorName");
			}
			set {
				SetColumnValue("ForecastIndicatorName", value);
				if (_forecastIndicator != null) {
					_forecastIndicator.Name = value;
				}
			}
		}

		private ForecastIndicator _forecastIndicator;
		/// <summary>
		/// Показатель планирования.
		/// </summary>
		public ForecastIndicator ForecastIndicator {
			get {
				return _forecastIndicator ??
					(_forecastIndicator = new ForecastIndicator(LookupColumnEntities.GetEntity("ForecastIndicator")));
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public Decimal Value {
			get {
				return GetTypedColumnValue<Decimal>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		/// <exclude/>
		public Guid PeriodId {
			get {
				return GetTypedColumnValue<Guid>("PeriodId");
			}
			set {
				SetColumnValue("PeriodId", value);
				_period = null;
			}
		}

		/// <exclude/>
		public string PeriodName {
			get {
				return GetTypedColumnValue<string>("PeriodName");
			}
			set {
				SetColumnValue("PeriodName", value);
				if (_period != null) {
					_period.Name = value;
				}
			}
		}

		private Period _period;
		/// <summary>
		/// Период.
		/// </summary>
		public Period Period {
			get {
				return _period ??
					(_period = new Period(LookupColumnEntities.GetEntity("Period")));
			}
		}

		/// <exclude/>
		public Guid ForecastItemId {
			get {
				return GetTypedColumnValue<Guid>("ForecastItemId");
			}
			set {
				SetColumnValue("ForecastItemId", value);
				_forecastItem = null;
			}
		}

		private ForecastItem _forecastItem;
		/// <summary>
		/// Элемент планирования.
		/// </summary>
		public ForecastItem ForecastItem {
			get {
				return _forecastItem ??
					(_forecastItem = new ForecastItem(LookupColumnEntities.GetEntity("ForecastItem")));
			}
		}

		#endregion

	}

	#endregion

}

