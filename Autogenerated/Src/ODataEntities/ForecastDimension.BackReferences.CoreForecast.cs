namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastDimension

	/// <exclude/>
	public class ForecastDimension : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastDimension(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastDimension";
		}

		public ForecastDimension(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastDimension";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<ForecastItem> ForecastItemCollectionByForecastDimension {
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
		/// Уровень.
		/// </summary>
		public int Level {
			get {
				return GetTypedColumnValue<int>("Level");
			}
			set {
				SetColumnValue("Level", value);
			}
		}

		/// <exclude/>
		public Guid DimensionId {
			get {
				return GetTypedColumnValue<Guid>("DimensionId");
			}
			set {
				SetColumnValue("DimensionId", value);
				_dimension = null;
			}
		}

		/// <exclude/>
		public string DimensionName {
			get {
				return GetTypedColumnValue<string>("DimensionName");
			}
			set {
				SetColumnValue("DimensionName", value);
				if (_dimension != null) {
					_dimension.Name = value;
				}
			}
		}

		private Dimension _dimension;
		/// <summary>
		/// Измерение.
		/// </summary>
		public Dimension Dimension {
			get {
				return _dimension ??
					(_dimension = new Dimension(LookupColumnEntities.GetEntity("Dimension")));
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

		#endregion

	}

	#endregion

}

