namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastHistDrilldown

	/// <exclude/>
	public class ForecastHistDrilldown : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastHistDrilldown(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastHistDrilldown";
		}

		public ForecastHistDrilldown(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastHistDrilldown";
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

		/// <summary>
		/// Дата удаления.
		/// </summary>
		public DateTime DeletedOn {
			get {
				return GetTypedColumnValue<DateTime>("DeletedOn");
			}
			set {
				SetColumnValue("DeletedOn", value);
			}
		}

		/// <exclude/>
		public Guid SnapshotId {
			get {
				return GetTypedColumnValue<Guid>("SnapshotId");
			}
			set {
				SetColumnValue("SnapshotId", value);
				_snapshot = null;
			}
		}

		private ForecastSnapshot _snapshot;
		/// <summary>
		/// Слепок данных планирования.
		/// </summary>
		public ForecastSnapshot Snapshot {
			get {
				return _snapshot ??
					(_snapshot = new ForecastSnapshot(LookupColumnEntities.GetEntity("Snapshot")));
			}
		}

		/// <summary>
		/// Заголовок объекта сущности.
		/// </summary>
		public string EntityDisplayValue {
			get {
				return GetTypedColumnValue<string>("EntityDisplayValue");
			}
			set {
				SetColumnValue("EntityDisplayValue", value);
			}
		}

		/// <summary>
		/// Идентификатор ссылочной записи.
		/// </summary>
		public Guid RefEntityId {
			get {
				return GetTypedColumnValue<Guid>("RefEntityId");
			}
			set {
				SetColumnValue("RefEntityId", value);
			}
		}

		/// <summary>
		/// Идентификатор записи.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
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
		public Guid ColumnId {
			get {
				return GetTypedColumnValue<Guid>("ColumnId");
			}
			set {
				SetColumnValue("ColumnId", value);
				_column = null;
			}
		}

		/// <exclude/>
		public string ColumnTitle {
			get {
				return GetTypedColumnValue<string>("ColumnTitle");
			}
			set {
				SetColumnValue("ColumnTitle", value);
				if (_column != null) {
					_column.Title = value;
				}
			}
		}

		private ForecastColumn _column;
		/// <summary>
		/// Колонка планирования.
		/// </summary>
		public ForecastColumn Column {
			get {
				return _column ??
					(_column = new ForecastColumn(LookupColumnEntities.GetEntity("Column")));
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

		#endregion

	}

	#endregion

}

