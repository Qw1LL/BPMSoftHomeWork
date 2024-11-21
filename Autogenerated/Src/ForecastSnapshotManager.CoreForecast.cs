 namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Interface: ISnapshot

	/// <summary>
	/// Provides properties with snapshot data.
	/// </summary>
	public interface ISnapshot
	{
		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		ForecastSnapshotData SnapshotData { get; set; }
	}

	#endregion

	#region Interface: IForecastSnapshotManager

	/// <summary>
	/// Provides methods to make forecast snapshots.
	/// </summary>
	public interface IForecastSnapshotManager
	{
		/// <summary>
		/// Make and save snapshot.
		/// </summary>
		/// <param name="forecastId">The forecast id.</param>
		/// <param name="filterConfig">The filter config.</param>
		/// <returns><see cref="Sheet"/></returns>
		bool SaveSnapshot(Guid forecastId, FilterConfig filterConfig);
	}

	#endregion

	#region Class: ForecastSnapshotData

	/// <summary>
	/// The forecast snapshot data.
	/// </summary>
	public class ForecastSnapshotData
	{

		#region Properties: Public

		/// <summary>
		/// Forecast sheet identifier.
		/// </summary>
		public Guid SheetId { get; set; }

		/// <summary>
		/// Forecast sheet data object.
		/// </summary>
		public Sheet Sheet { get; set; }

		/// <summary>
		/// The snapshot identifier.
		/// </summary>
		public Guid SnapshotId { get; set; }

		/// <summary>
		/// Snapshot date taken.
		/// </summary>
		public DateTime Date { get; set; }

		#endregion

	}

	#endregion

	#region Class: Diff<T>

	/// <summary>
	/// The diff data.
	/// </summary>
	public class Diff<T>
	{

		#region Properties: Public

		/// <summary>
		/// The new records.
		/// </summary>
		public IEnumerable<T> Created { get; set; }

		/// <summary>
		/// The changed records.
		/// </summary>
		public IEnumerable<T> Updated { get; set; }

		/// <summary>
		/// The removed records.
		/// </summary>
		public IEnumerable<T> Deleted { get; set; }

		#endregion

	}

	#endregion

	#region Class: ForecastSnapshotManager

	/// <summary>
	/// Provides methods to make forecast snapshots.
	/// </summary>
	/// <seealso cref="IForecastSnapshotManager" />
	[DefaultBinding(typeof(IForecastSnapshotManager))]
	public class ForecastSnapshotManager : IForecastSnapshotManager
	{

		#region Fields: Private

		private IForecastHistoricalHierarchyRowDataRepository _historicalRowsRepository;
		private IForecastSheetRepository _sheetRepository;
		private IForecastSnapshotRepository _snapshotRepository;
		private IForecastEntitySnapshotService _cellsService;
		private IForecastEntitySnapshotService _addedRowsService;
		private IForecastDataIterator _dataIterator;
		private IForecastDataIterator _historicalDataIterator;
		private IForecastEntitySnapshotService _deletedRowsService;
		private IForecastEntitySnapshotService _forecastObjectValueSnapshotService;

		#endregion

		#region Constructors: Public

		public ForecastSnapshotManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected Sheet Sheet { get; set; }

		protected UserConnection UserConnection { get; set; }

		protected ForecastSnapshotData Snapshot { get; set; }

		#endregion

		#region Properties: Public

		public IForecastSnapshotRepository SnapshotRepository {
			get {
				return _snapshotRepository ?? (_snapshotRepository = ClassFactory.Get<IForecastSnapshotRepository>(
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _snapshotRepository = value; }
		}

		public IForecastHistoricalHierarchyRowDataRepository ForecastHistoricalHierarchyRowDataRepository {
			get {
				if (_historicalRowsRepository == null) {
					_historicalRowsRepository = ClassFactory.Get<IForecastHistoricalHierarchyRowDataRepository>(
						"Default",
						new ConstructorArgument("userConnection", UserConnection));
					(_historicalRowsRepository as ISnapshot).SetSnapshotData(Snapshot);
				}
				return _historicalRowsRepository;
			}
			set { _historicalRowsRepository = value; }
		}

		public IForecastSheetRepository SheetRepository {
			get {
				return _sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _sheetRepository = value; }
		}

		public IForecastEntitySnapshotService CellsEntitySnapshotService {
			get {
				return _cellsService ?? (_cellsService = ClassFactory.Get<IForecastEntitySnapshotService>("Cells",
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _cellsService = value; }
		}

		public IForecastEntitySnapshotService AdddeRowsEntitySnapshotService {
			get {
				return _addedRowsService ?? (_addedRowsService = ClassFactory.Get<IForecastEntitySnapshotService>("Added_Rows",
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _addedRowsService = value; }
		}

		public IForecastEntitySnapshotService DeletedRowsEntitySnapshotService {
			get {
				return _deletedRowsService ?? (_deletedRowsService = ClassFactory.Get<IForecastEntitySnapshotService>("Deleted_Rows",
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _deletedRowsService = value; }
		}

		public IForecastDataIterator ForecastActualDataIterator {
			get {
				return _dataIterator ?? (_dataIterator = ClassFactory.Get<IForecastDataIterator>(
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _dataIterator = value; }
		}

		public IForecastDataIterator ForecastHistoricalDataIterator {
			get {
				if (_historicalDataIterator == null) {
					_historicalDataIterator = ClassFactory.Get<IForecastDataIterator>(
						new ConstructorArgument("userConnection", UserConnection));
					var iterator = (_historicalDataIterator as ForecastDataIterator);
					if (iterator != null) {
						iterator.ForecastHierarchyRowDataRepository = ForecastHistoricalHierarchyRowDataRepository;
					}
				}
				return _historicalDataIterator;
			}
			set { _historicalDataIterator = value; }
		}

		public IForecastEntitySnapshotService ForecastObjectValueSnapshotService {
			get => _forecastObjectValueSnapshotService ?? (_forecastObjectValueSnapshotService =
					ClassFactory.Get<IForecastEntitySnapshotService>("History_Drilldown",
						new ConstructorArgument("userConnection", UserConnection)
					)
				);
			set => _forecastObjectValueSnapshotService = value;
		}

		#endregion

		#region Methods: Private

		private void SaveCellsSnapshot(IEnumerable<Guid> rows) {
			CellsEntitySnapshotService.SaveSnapshot(Snapshot, new FilterConfig {
				RecordIds = rows
			});
		}

		private void SaveRowsSnapshot(IEnumerable<Guid> rows) {
			AdddeRowsEntitySnapshotService.SaveSnapshot(Snapshot, new FilterConfig {
				RecordIds = rows
			});
		}

		private void IterateActualData() {
			ForecastActualDataIterator.IterateRows(Sheet, new ForecastDataIteratorParams {
				RowsIteratorFn = HandleRowsSnapshotSave
			});
		}

		private void IterateHistoricalData() {
			if (!UserConnection.GetIsFeatureEnabled("ForecastRowSnapshot")) {
				return;
			}
			ForecastHistoricalDataIterator.IterateRows(Sheet, new ForecastDataIteratorParams {
				RowsIteratorFn = HandleHistoricalRowsSnapshotSave
			});
		}

		private void HandleRowsSnapshotSave(IEnumerable<Guid> rows) {
			if (UserConnection.GetIsFeatureEnabled("ForecastRowSnapshot")) {
				SaveRowsSnapshot(rows);
			}
			SaveCellsSnapshot(rows);
			if (UserConnection.GetIsFeatureEnabled("ForecastHistoryDrilldown")) {
				var filterConfig = new FilterConfig{ RecordIds = rows };
				ForecastObjectValueSnapshotService.SaveSnapshot(Snapshot, filterConfig);
			}
		}

		private void HandleHistoricalRowsSnapshotSave(IEnumerable<Guid> rows) {
			DeletedRowsEntitySnapshotService.SaveSnapshot(Snapshot, new FilterConfig {
				RecordIds = rows
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Make and save snapshot of forecast data.
		/// </summary>
		/// <param name="forecastId">The forecast id.</param>
		/// <param name="filterConfig">The filter config.</param>
		/// <returns><see cref="Sheet"/></returns>
		public bool SaveSnapshot(Guid forecastId, FilterConfig filterConfig) {
			Sheet = SheetRepository.GetSheet(forecastId);
			Snapshot = new ForecastSnapshotData {
				SheetId = forecastId,
				Sheet = Sheet
			};
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				try {
					SnapshotRepository.Add(Snapshot);
					IterateHistoricalData();
					IterateActualData();
					dbExecutor.CommitTransaction();
				} catch (Exception exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return true;
		}

		#endregion

	}

	#endregion

}

