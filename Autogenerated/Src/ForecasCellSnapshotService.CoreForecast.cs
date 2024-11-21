namespace BPMSoft.Configuration.ForecastV2
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: ForecasCellEntitySnapshotService

	/// <summary>
	/// Service for saving snapshot for forecast cells.
	/// </summary>
	[DefaultBinding(typeof(IForecastEntitySnapshotService), Name = "Cells")]
	public class ForecasCellSnapshotService : IForecastEntitySnapshotService
	{

		#region Fields: Private

		private IGetForecastCellRepository _actualRepository;
		private IInsertForecastCellRepository _historicalInsertRepository;
		private IGetForecastCellRepository _historicalRepository;
		private IForecastSummaryColumnCalculator _summaryColumnCalculator;

		#endregion

		public ForecasCellSnapshotService(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		protected ForecastSnapshotData Snapshot { get; set; }

		#endregion

		#region Properties: Public

		protected IForecastSummaryColumnCalculator SummaryColumnCalculator {
			get {
				return _summaryColumnCalculator ??
					(_summaryColumnCalculator = ClassFactory.Get<IForecastSummaryColumnCalculator>());
			}
			set {
				_summaryColumnCalculator = value;
			}
		}

		public IGetForecastCellRepository ActualCellsRepository {
			get {
				return _actualRepository ?? (_actualRepository = ClassFactory.Get<IGetForecastCellRepository>("Actual",
					new ConstructorArgument("userConnection", UserConnection)));
			}
			set { _actualRepository = value; }
		}

		public IGetForecastCellRepository HistoricalGetCellsRepository {
			get {
				if (_historicalRepository == null) {
					_historicalRepository = ClassFactory.Get<IGetForecastCellRepository>("History",
						new ConstructorArgument("userConnection", UserConnection));
					(_historicalRepository as ISnapshot).SetSnapshotData(Snapshot);
				}
				return _historicalRepository;
			}
			set { _historicalRepository = value; }
		}

		public IInsertForecastCellRepository HistoricalInsertCellsRepository {
			get {
				if (_historicalInsertRepository == null) {
					_historicalInsertRepository = ClassFactory.Get<IInsertForecastCellRepository>("History",
						new ConstructorArgument("userConnection", UserConnection));
					(_historicalInsertRepository as ISnapshot).SetSnapshotData(Snapshot);
				}
				return _historicalInsertRepository;
			}
			set { _historicalInsertRepository = value; }
		}

		#endregion

		#region Methods: Private

		private Cell FindCell(IEnumerable<Cell> historicalCells, Cell actualCell) {
			return historicalCells.FirstOrDefault(cell =>
				cell.PeriodId == actualCell.PeriodId &&
				cell.ColumnId == actualCell.ColumnId &&
				cell.EntityId == actualCell.EntityId);
		}

		private Diff<Cell> GetDiff(IEnumerable<Cell> actualCells, IEnumerable<Cell> historicalCells) {
			var changedCells = new List<Cell>();
			foreach (Cell actualCell in actualCells) {
				bool changed = false;
				var historyCell = FindCell(historicalCells, actualCell);
				if (historyCell == null) {
					historyCell = actualCell;
					changed = true;
				}
				changed = changed || historyCell.Value != actualCell.Value;
				if (changed) {
					changedCells.Add(actualCell);
				}
			}
			var diff = new Diff<Cell> {
				Created = changedCells
			};
			return diff;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves forecast cells snapshot of difference between actual and last snapshot cells.
		/// </summary>
		/// <param name="snapshot">Snapshot metadata.</param>
		/// <param name="filter">Filter configuration.</param>
		public void SaveSnapshot(ForecastSnapshotData snapshot, FilterConfig filter) {
			snapshot.CheckArgumentNull(nameof(snapshot));
			snapshot.Sheet.CheckArgumentNull(nameof(snapshot.Sheet));
			Snapshot = snapshot;
			var sheet = snapshot.Sheet;
			var cells = ActualCellsRepository.GetCells(sheet, filter);
			var historicalCells = HistoricalGetCellsRepository.GetCells(sheet, filter);
			var diffCells = GetDiff(cells, historicalCells);
			HistoricalInsertCellsRepository.InsertCells(sheet, diffCells.Created);
		}

		#endregion

	}

	#endregion

}

