namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastHistoryCellConstants

	/// <summary>
	/// Provides forecast history cell constants.
	/// </summary>
	public static class ForecastHistoryCellConstants
	{
		public static readonly string CellSchemaName = "ForecastHistoryCell";
		public static readonly string EntityColumnName = "EntityId";
		public static readonly string ForecastColumnName = "ColumnId";
		public static readonly string ForecastRowName = "RowId";
		public static readonly string PeriodColumnName = "PeriodId";
		public static readonly string SheetColumnName = "SheetId";
		public static readonly string SnapshotColumnName = "SnapshotId";
		public static readonly string SnapshotSchemaName  = "ForecastSnapshot";
		public static readonly string ValueColumnName = "Value";
		public static readonly string ForecastRowColumnName = "RowId";
	}

	#endregion

	#region Interface: IForecastHistoryCellQueryBuilder

	/// <summary>
	/// Provides forecast history cells query methods.
	/// </summary>
	public interface IForecastHistoryCellQueryBuilder
	{

		/// <summary>
		/// Gets cells snapshot select.
		/// </summary>
		/// <param name="sheetId">The forecast sheet identifier.</param>
		/// <param name="snapshotId">The snapshot identifier.</param>
		/// <param name="filterConfig">The filter config.</param>
		/// <returns>Instance of <see cref="Select"/>s</returns>
		Select CreateCellsSnapshotSelect(Guid sheetId, Guid snapshotId, FilterConfig filterConfig);

		/// <summary>
		/// Gets max date snapshot subquery.
		/// </summary>
		/// <param name="sheetId">The forecast sheet identifier.</param>
		/// <param name="snapshotId">The snapshot identifier.</param>
		/// <param name="snapshotId">The main select history cell alias.</param>
		/// <param name="filterConfig">The filter config.</param>
		/// <returns>Instance of <see cref="Select"/>s</returns>
		Select CreateMaxDateSnapshotSelect(Guid sheetId, Guid snapshotId, FilterConfig filterConfig);

		/// <summary>
		/// Gets the snapshot date select subquery.
		/// </summary>
		/// <param name="snapshotId">The snapshot identifier.</param>
		/// <returns>Instance of <see cref="Select"/></returns>
		Select CreateSnapshotDateSelect(Guid snapshotId);

		/// <summary>
		/// Adds rights conditions to the select.
		/// </summary>
		/// <param name="snapshotId">The snapshot identifier.</param>
		/// <returns>Instance of <see cref="Select"/></returns>
		void AddRightsConditions(Select select, EntitySchema entitySchema);
	}

	#endregion


	#region Class: ForecastHistoryCellQueryBuilder

	///<inheritdoc />
	[DefaultBinding(typeof(IForecastHistoryCellQueryBuilder))]
	public class ForecastHistoryCellQueryBuilder: IForecastHistoryCellQueryBuilder
	{

		#region Constants: Private

		private const string ForecastRowSchemaName = "ForecastRow";
		private const string ForecastRowAlias = "FR";
		private const string IdColumnName = "Id";

		#endregion

		#region Constructors: Public

		public ForecastHistoryCellQueryBuilder(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		#endregion

		#region Methods: Private

		private QueryCondition GetRightsCondition(Select select, EntitySchema forecastEntitySchema) {
			var securityEngine = UserConnection.DBSecurityEngine;
			var rightsCondition = securityEngine.GetRecordsByRightCondition(new RecordsByRightOptions {
				EntitySchemaName = forecastEntitySchema.Name,
				EntitySchemaSourceAlias = select.SourceExpression.Alias,
				RightEntitySchemaName = securityEngine.GetRecordRightsSchemaName(forecastEntitySchema.Name),
				Operation = Core.Configuration.EntitySchemaRecordRightOperation.Read,
				PrimaryColumnName = ForecastHistoryCellConstants.EntityColumnName,
				UserId = UserConnection.CurrentUser.Id,
				UseDenyRecordRights = forecastEntitySchema.UseDenyRecordRights
			});
			return rightsCondition;
		}

		private void AddForecastRowRightsCondition(Select select) {
			var securityEngine = UserConnection.DBSecurityEngine;
			EntitySchema forecastRowSchema = UserConnection.EntitySchemaManager.GetInstanceByName(ForecastRowSchemaName);
			var forecastRowCondition = securityEngine.GetRecordsByRightCondition(new RecordsByRightOptions {
				EntitySchemaName = ForecastRowSchemaName,
				EntitySchemaSourceAlias = ForecastRowAlias,
				RightEntitySchemaName = securityEngine.GetRecordRightsSchemaName(ForecastRowSchemaName),
				Operation = Core.Configuration.EntitySchemaRecordRightOperation.Read,
				PrimaryColumnName = IdColumnName,
				UserId = UserConnection.CurrentUser.Id,
				UseDenyRecordRights = forecastRowSchema.UseDenyRecordRights
			});
			if (forecastRowCondition != null) {
				select.InnerJoin(ForecastRowSchemaName).As(ForecastRowAlias).On(ForecastRowAlias, IdColumnName)
					.IsEqual(select.SourceExpression.Alias, ForecastHistoryCellConstants.ForecastRowName);
				select.AddCondition(forecastRowCondition, LogicalOperation.And);
			}
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public Select CreateCellsSnapshotSelect(Guid sheetId, Guid snapshotId, FilterConfig filterConfig) {
			string historyCellAlias = "cs_fhc";
			string snapshotAlias = "cs_fs";
			string cellsSubQueryAlias = "cs_sqc";
			return new Select(UserConnection)
						.Column(historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
						.Column(historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName)
						.Column(historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
						.Column(historyCellAlias, ForecastHistoryCellConstants.ValueColumnName)
						.Column(historyCellAlias, ForecastHistoryCellConstants.ForecastRowColumnName)
					.From(ForecastHistoryCellConstants.CellSchemaName).As(historyCellAlias)
					.InnerJoin(ForecastHistoryCellConstants.SnapshotSchemaName).As(snapshotAlias).On(snapshotAlias, "Id")
						.IsEqual(historyCellAlias, ForecastHistoryCellConstants.SnapshotColumnName)
					.InnerJoin(CreateMaxDateSnapshotSelect(sheetId, snapshotId, filterConfig)).As(cellsSubQueryAlias)
						.On(cellsSubQueryAlias, ForecastHistoryCellConstants.EntityColumnName).IsEqual(historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
						.And(cellsSubQueryAlias, ForecastHistoryCellConstants.ForecastColumnName).IsEqual(historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName)
						.And(cellsSubQueryAlias, ForecastHistoryCellConstants.PeriodColumnName).IsEqual(historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
						.And(snapshotAlias, "Date").IsEqual(cellsSubQueryAlias, "Date")
				as Select;
		}

		///<inheritdoc />
		public Select CreateMaxDateSnapshotSelect(Guid sheetId, Guid snapshotId, FilterConfig filterConfig) {
			string snapshotAlias = "mds_fs";
			string historyCellAlias = "mds_fhc";
			var select = new Select(UserConnection)
					.Column(historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
					.Column(historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName)
					.Column(historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
					.Column(Func.Max(snapshotAlias, "Date")).As("Date")
				.From(ForecastHistoryCellConstants.CellSchemaName).As(historyCellAlias)
				.InnerJoin(ForecastHistoryCellConstants.SnapshotSchemaName).As(snapshotAlias).On(snapshotAlias, "Id")
					.IsEqual(historyCellAlias, ForecastHistoryCellConstants.SnapshotColumnName)
				.Where(snapshotAlias, "Date")
					.IsLessOrEqual(CreateSnapshotDateSelect(snapshotId))
				.And(historyCellAlias, ForecastHistoryCellConstants.SheetColumnName)
					.IsEqual(Column.Parameter(sheetId))
				as Select;
			if (!filterConfig.RecordIds.IsNullOrEmpty()) {
				select.And(historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
					.In(Column.Parameters(filterConfig.RecordIds));
			}
			if (!filterConfig.PeriodIds.IsNullOrEmpty()) {
				select.And(historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
					.In(Column.Parameters(filterConfig.PeriodIds));
			}
			select
				.GroupBy(historyCellAlias, ForecastHistoryCellConstants.EntityColumnName)
				.GroupBy(historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName)
				.GroupBy(historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName);
			return select;
		}

		///<inheritdoc />
		public Select CreateSnapshotDateSelect(Guid snapshotId) {
			string snapshotAlias = "sds_fs";
			return new Select(UserConnection)
				.Column(snapshotAlias, "Date")
				.From(ForecastHistoryCellConstants.SnapshotSchemaName).As(snapshotAlias)
				.Where(snapshotAlias, "Id").IsEqual(Column.Parameter(snapshotId)) as Select;
		}

		///<inheritdoc />
		public void AddRightsConditions(Select select, EntitySchema entitySchema) {
			var rightsCondition = GetRightsCondition(select, entitySchema);
			if (rightsCondition != null) {
				select.AddCondition(rightsCondition, LogicalOperation.And);
			}
			if (UserConnection.GetIsFeatureEnabled("ForecastRowRights")) {
				AddForecastRowRightsCondition(select);
			}
		}

		#endregion

	}

	#endregion

}

