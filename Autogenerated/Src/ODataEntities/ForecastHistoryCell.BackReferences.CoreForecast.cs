namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: ForecastHistoryCell

	/// <exclude/>
	public class ForecastHistoryCell : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public ForecastHistoryCell(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ForecastHistoryCell";
		}

		public ForecastHistoryCell(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "ForecastHistoryCell";
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
		/// Идентификатор сущности.
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
		public Guid RowId {
			get {
				return GetTypedColumnValue<Guid>("RowId");
			}
			set {
				SetColumnValue("RowId", value);
				_row = null;
			}
		}

		private ForecastRow _row;
		/// <summary>
		/// Строка планирования.
		/// </summary>
		public ForecastRow Row {
			get {
				return _row ??
					(_row = new ForecastRow(LookupColumnEntities.GetEntity("Row")));
			}
		}

		#endregion

	}

	#endregion

}

