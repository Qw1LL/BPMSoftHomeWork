namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration.ForecastV2;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: BaseForecastRowSnapshotService

	/// <summary>
	/// Base forecast row snapshot service.
	/// </summary>
	public abstract class BaseForecastRowSnapshotService
	{

		#region Class: ForecastSchemaComparisonConfig

		public class ForecastSchemaComparisonConfig
		{

			#region Properties: Public

			public string SchemaName { get; set; }

			public string EntityColumnName { get; set; }

			#endregion

		}

		#endregion

		protected const string ActualRowSchemaName = "ForecastRow";
		protected const string HistoryRowAlias = "fhr";
		protected const string ForecastRowAlias = "fr";
		protected const string EntityForecastAlias = "ef";

		#region Constructors: Public

		public BaseForecastRowSnapshotService(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <see cref="ForecastSnapshotData"/> instance.
		/// </summary>
		protected ForecastSnapshotData Snapshot { get; set; }

		/// <summary>
		/// <see cref="Core.UserConnection"/> instance.
		/// </summary>
		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Protected

		protected virtual ForecastHistoryRowData CreateHistoryRowData(IDataReader reader) {
			var rowId = reader.GetColumnValue<Guid>(ForecastHistoryRowConstants.IdColumnName);
			var entityId = reader.GetColumnValue<Guid>(ForecastHistoryRowConstants.EntityColumnName);
			return new ForecastHistoryRowData() {
				RowId = rowId,
				EntityId = entityId,
				SnapshotId = Snapshot.SnapshotId,
				SheetId = Snapshot.Sheet.Id
			};
		}

		protected virtual Select CreateNewRowsSelect(FilterConfig filter, Sheet sheet,
				ForecastSchemaComparisonConfig rootSchemaConfig, ForecastSchemaComparisonConfig comparedSchemaConfig) {
			Select rowsIdSelect = CreateRowIdsSelect(sheet, filter, rootSchemaConfig);
			Select existingRowsIdsSelect = CreateRowIdsSelect(sheet, filter, comparedSchemaConfig);
			var select = new Select(UserConnection).Distinct()
					.Column(ForecastRowAlias, ForecastHistoryRowConstants.IdColumnName)
					.Column(EntityForecastAlias, rootSchemaConfig.EntityColumnName).As(ForecastHistoryRowConstants.EntityColumnName)
				.From(ActualRowSchemaName).As(ForecastRowAlias)
				.InnerJoin(rootSchemaConfig.SchemaName).As(EntityForecastAlias)
					.On(ForecastRowAlias, ForecastHistoryRowConstants.IdColumnName)
						.IsEqual(EntityForecastAlias, ForecastHistoryRowConstants.RowColumnName)
				.Where(ForecastRowAlias, ForecastHistoryRowConstants.IdColumnName)
					.In(rowsIdSelect)
				.And(ForecastRowAlias, ForecastHistoryRowConstants.IdColumnName)
					.Not().In(existingRowsIdsSelect) as Select;
			return select;
		}

		protected virtual Select CreateRowIdsSelect(Sheet sheet, FilterConfig filter, ForecastSchemaComparisonConfig schemaConfig) {
			return new Select(UserConnection).Distinct()
					.Column(ForecastHistoryRowConstants.RowColumnName)
				.From(schemaConfig.SchemaName)
				.Where(schemaConfig.EntityColumnName).In(Column.Parameters(filter.RecordIds))
					.And(EntityForecastAlias, ForecastHistoryRowConstants.SheetColumnName)
						.IsEqual(Column.Parameter(sheet.Id)) as Select;
		}

		protected void InnerSaveSnapshot(ForecastSnapshotData snapshot, FilterConfig filter,
				ForecastSchemaComparisonConfig rootSchemaConfig, ForecastSchemaComparisonConfig comparedSchemaConfig) {
			Sheet sheet = snapshot.Sheet;
			Select select = CreateNewRowsSelect(filter, sheet, rootSchemaConfig, comparedSchemaConfig);
			var rowValues = new List<ForecastHistoryRowData>();
			select.ExecuteReader((reader) => {
				rowValues.Add(CreateHistoryRowData(reader));
			});
			ProcessDiffRows(rowValues);
		}

		protected abstract void ProcessDiffRows(List<ForecastHistoryRowData> rowValues);

		#endregion

	}

	#endregion

}

