namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastItem

	/// <exclude/>
	public class ForecastItem : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastItem";
		}

		public ForecastItem(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastItem";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ForecastItem> ForecastItemCollectionByParent {
			get;
			set;
		}

		public IEnumerable<ForecastItemValue> ForecastItemValueCollectionByForecastItem {
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

		/// <exclude/>
		public Guid ForecastId {
			get {
				return GetTypedColumnValue<Guid>("ForecastId");
			}
			set {
				SetColumnValue("ForecastId", value);
				_forecast = null;
			}
		}

		/// <exclude/>
		public string ForecastName {
			get {
				return GetTypedColumnValue<string>("ForecastName");
			}
			set {
				SetColumnValue("ForecastName", value);
				if (_forecast != null) {
					_forecast.Name = value;
				}
			}
		}

		private Forecast _forecast;
		/// <summary>
		/// Планирование.
		/// </summary>
		public Forecast Forecast {
			get {
				return _forecast ??
					(_forecast = new Forecast(LookupColumnEntities.GetEntity("Forecast")));
			}
		}

		/// <exclude/>
		public Guid ForecastDimensionId {
			get {
				return GetTypedColumnValue<Guid>("ForecastDimensionId");
			}
			set {
				SetColumnValue("ForecastDimensionId", value);
				_forecastDimension = null;
			}
		}

		private ForecastDimension _forecastDimension;
		/// <summary>
		/// Срез планирования.
		/// </summary>
		public ForecastDimension ForecastDimension {
			get {
				return _forecastDimension ??
					(_forecastDimension = new ForecastDimension(LookupColumnEntities.GetEntity("ForecastDimension")));
			}
		}

		/// <summary>
		/// Значение элемента планирования.
		/// </summary>
		public Guid DimensionValueId {
			get {
				return GetTypedColumnValue<Guid>("DimensionValueId");
			}
			set {
				SetColumnValue("DimensionValueId", value);
			}
		}

		/// <summary>
		/// Удален.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
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

		private ForecastItem _parent;
		/// <summary>
		/// Родительский элемент планирования.
		/// </summary>
		public ForecastItem Parent {
			get {
				return _parent ??
					(_parent = new ForecastItem(LookupColumnEntities.GetEntity("Parent")));
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

		#endregion

	}

	#endregion

}

