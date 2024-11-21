namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;


	#region Class: FilterConfig

	/// <summary>
	/// Filter data configuration.
	/// </summary>
	public partial class FilterConfig
	{
		/// <summary>
		/// Forecast column settings data.
		/// </summary>
		public ColumnSettingsData ColumnSettings { get; set; }

		/// <summary>
		/// Forecast column id. 
		/// </summary>
		public Guid ColumnId { get; set; }

		/// <summary>
		/// Sorting configuration.
		/// </summary>
		public SortConfig SortConfig { get; set; }

		/// <summary>
		/// Paging configuration.
		/// </summary>
		public PagingConfig PagingConfig { get; set; }
	}

	#endregion


	#region Class: ForecastObjectValueSnapshotService

	/// <summary>
	/// Save snapshot service for forecast object value record.
	/// </summary>
	[DefaultBinding(typeof(IForecastEntitySnapshotService), Name = "History_Drilldown")]
	public class ForecastObjectValueSnapshotService: IForecastEntitySnapshotService
	{

		#region Fields: private

		private IForecastObjectValueGetOperation _actualObjectValueRepository;
		private IForecastObjectValueGetOperation _historyObjectValueRepository;
		private IForecastObjectValueBulkAddOperation _forecastObjectValueBulkAddOperation;
		private IForecastColumnRepository _columnRepository;
		private IForecastColumnSettingsMapper _mapper;

		#endregion

		#region Constructors: Public

		public ForecastObjectValueSnapshotService(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private ForecastSnapshotData Snapshot { get; set; }

		private IForecastObjectValueGetOperation ActualObjectValueRepository {
			get =>
				_actualObjectValueRepository ??
				(_actualObjectValueRepository =
					ClassFactory.Get<IForecastObjectValueGetOperation>("Actual",
						new ConstructorArgument("userConnection", UserConnection)));
			set => _actualObjectValueRepository = value;
		}

		private IForecastObjectValueGetOperation HistoryObjectValueRepository {
			get =>
				_historyObjectValueRepository ??
				(_historyObjectValueRepository =
					ClassFactory.Get<IForecastObjectValueGetOperation>("History",
						new ConstructorArgument("userConnection", UserConnection),
						new ConstructorArgument("snapshotData", Snapshot)
						)
					);
			set => _historyObjectValueRepository = value;
		}

		private IForecastObjectValueBulkAddOperation ForecastObjectValueBulkAddOperation {
			get =>
				_forecastObjectValueBulkAddOperation ?? (_forecastObjectValueBulkAddOperation =
					ClassFactory.Get<IForecastObjectValueBulkAddOperation>("History",
						new ConstructorArgument("userConnection", UserConnection)));
			set => _forecastObjectValueBulkAddOperation = value;
		}

		private IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastColumnSettingsMapper ColumnSettingsMapper =>
			_mapper ?? (_mapper = ClassFactory.Get<IForecastColumnSettingsMapper>());

		#endregion

		#region Methods: Private

		private IEnumerable<ObjectValueRecord> GetDiff(IEnumerable<ObjectValueRecord> objectValueRecords,
			IEnumerable<ObjectValueRecord> historyObjectValueRecords) {
			var result = new List<ObjectValueRecord>();
			foreach (var objectValueRecord in objectValueRecords) {
				var historyObjectValueRecord = historyObjectValueRecords.FirstOrDefault(
					x => x.EntityId == objectValueRecord.EntityId &&
					x.RefEntityId == objectValueRecord.RefEntityId &&
					x.Value == objectValueRecord.Value &&
					x.ColumnId == objectValueRecord.ColumnId &&
					x.PeriodId == objectValueRecord.PeriodId);
				if (historyObjectValueRecord == null) {
					result.Add(objectValueRecord);
				}
			}
			foreach (var historyObjectValueRecord in historyObjectValueRecords) {
				var objectValueRecord = objectValueRecords.FirstOrDefault(
					x => x.EntityId == historyObjectValueRecord.EntityId && 
						x.PeriodId == historyObjectValueRecord.PeriodId &&
						x.RefEntityId == historyObjectValueRecord.RefEntityId &&
						x.ColumnId == historyObjectValueRecord.ColumnId);
				if (objectValueRecord == null) {
					historyObjectValueRecord.DeletedOn = Snapshot.Date;
					result.Add(historyObjectValueRecord);
				}
			}
			return result;
		}

		private IEnumerable<ForecastColumn> GetObjectValueColumns() {
			var columns = ColumnRepository.GetColumns(Snapshot.Sheet.Id);
			return columns.Where(c => c.TypeId == ForecastConsts.ObjectValueColumnTypeId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves snapshot data for entity.
		/// </summary>
		/// <param name="snapshot">Snapshot metadata</param>
		/// <param name="filter">Filter configuration</param>
		public void SaveSnapshot(ForecastSnapshotData snapshot, FilterConfig filter) {
			snapshot.CheckArgumentNull(nameof(snapshot));
			snapshot.Sheet.CheckArgumentNull(nameof(snapshot.Sheet));
			Snapshot = snapshot;
			var sheet = snapshot.Sheet;
			var columns = GetObjectValueColumns();
			foreach (var column in columns) {
				filter.ColumnId = column.Id;
				filter.ColumnSettings = ColumnSettingsMapper.GetForecastColumnSettingsData(UserConnection, column);
				var objectValueRecords = ActualObjectValueRepository.GetRecords(sheet, filter);
				var historyObjectValueRecords = HistoryObjectValueRepository.GetRecords(sheet, filter);
				var diffObjectValueRecords = GetDiff(objectValueRecords, historyObjectValueRecords);
				ForecastObjectValueBulkAddOperation.AddRecords(snapshot, diffObjectValueRecords);
			}
		}

		#endregion

	}

	#endregion

}

