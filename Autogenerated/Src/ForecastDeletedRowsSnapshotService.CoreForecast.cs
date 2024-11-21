namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastDeletedRowsSnapshotService

	/// <summary>
	/// Service for saving snapshot for forecast rows.
	/// </summary>
	[DefaultBinding(typeof(IForecastEntitySnapshotService), Name = "Deleted_Rows")]
	public class ForecastDeletedRowsSnapshotService : BaseForecastRowSnapshotService, IForecastEntitySnapshotService
	{

		#region Fields: Private

		private IForecastHistoricalHierarchyRowDataRepository _forecastHistoricalHierarchyRowRepository;

		#endregion

		#region Constructors: Public

		public ForecastDeletedRowsSnapshotService(UserConnection userConnection) : base(userConnection) {}

		#endregion

		#region Properties: Protected

		/// <summary> Gets the forecast historical hierarchy row repository. </summary>
		/// <value> The forecast historical hierarchy row repository. </value>
		protected IForecastHistoricalHierarchyRowDataRepository ForecastHistoricalHierarchyRowRepository {
			get {
				return _forecastHistoricalHierarchyRowRepository ??
					(_forecastHistoricalHierarchyRowRepository =
						ClassFactory.Get<IForecastHistoricalHierarchyRowDataRepository>("Default",
						new ConstructorArgument("userConnection", UserConnection)));
			}
			set => _forecastHistoricalHierarchyRowRepository = value;
		}

		protected Sheet Sheet { get; set; }

		#endregion

		#region Methods: Protected

		protected override void ProcessDiffRows(List<ForecastHistoryRowData> rowValues) {
			ForecastHistoricalHierarchyRowRepository.DeleteRows(new ForecastHistoricalRowsDeleteParams {
				SheetId = Sheet.Id,
				RowsIds = rowValues.Select(row => row.RowId),
				DeletedOn = Snapshot.Date
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Saves forecast new rows snapshot of difference between actual and last snapshot rows.
		/// </summary>
		/// <param name="snapshot">Snapshot metadata.</param>
		/// <param name="filter">Filter configuration.</param>
		public void SaveSnapshot(ForecastSnapshotData snapshot, FilterConfig filter) {
			snapshot.CheckArgumentNull(nameof(snapshot));
			snapshot.Sheet.CheckArgumentNull(nameof(snapshot.Sheet));
			filter.CheckArgumentNull(nameof(filter));
			filter.RecordIds.CheckArgumentNull(nameof(filter.RecordIds));
			Snapshot = snapshot;
			Sheet = snapshot.Sheet;
			EntitySchemaColumn referenceColumn = Sheet.GetEntityReferenceColumn(UserConnection);
			EntitySchema forecastCellSchema =
				UserConnection.EntitySchemaManager.GetInstanceByUId(Sheet.ForecastEntityInCellUId);
			InnerSaveSnapshot(snapshot, filter,
				new ForecastSchemaComparisonConfig {
					SchemaName = ForecastHistoryRowConstants.RowSchemaName,
					EntityColumnName = ForecastHistoryRowConstants.EntityColumnName
				},
				new ForecastSchemaComparisonConfig {
				SchemaName = forecastCellSchema.Name,
				EntityColumnName = referenceColumn.ColumnValueName
			});
		}

		#endregion

	}

	#endregion

}

