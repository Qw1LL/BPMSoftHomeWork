namespace BPMSoft.Configuration.ForecastV2 {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration.ExportToExcel;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using Consts = BPMSoft.Configuration.ForecastObjectValueRecordConstants;
	using DataValueType = BPMSoft.Nui.ServiceModel.DataContract.DataValueType;
	using FilterType = BPMSoft.Nui.ServiceModel.DataContract.FilterType;

	#region Class FilterConfig

	/// <summary>
	/// Filter data configuration.
	/// </summary>
	public partial class FilterConfig {

		/// <summary>
		/// Forecast column caption data.
		/// </summary>
		public ForecastHistoryDataService.ColumnCaptionData[] ColumnCaptionData { get; set; } 
	}

	#endregion

	#region Class: ForecastHistoryExportToExcelService

	/// <summary>
	/// Service for exporting forecast drilldown data to excel.
	/// </summary>
	[DefaultBinding(typeof(IForecastExportToExcelService), Name = "History")]
	public class ForecastHistoryExportToExcelService : IForecastExportToExcelService {

		#region Constructor ForecastExportToExcelService

		public ForecastHistoryExportToExcelService(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private ExportToExcelService _exportToExcelService;

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; set; }

		private ExportToExcelService ExportToExcelService =>
			_exportToExcelService ?? (_exportToExcelService = ClassFactory.Get<ExportToExcelService>());

		#endregion

		#region Methods: Private

		private Filters GetSelectQueryFilters(IEnumerable<Guid> recordsId) {
			var filters = new Filters {
				FilterType = FilterType.InFilter,
				ComparisonType = FilterComparisonType.Equal,
				LeftExpression = new BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.SchemaColumn,
					ColumnPath = "Id"
				},
				RightExpressions = recordsId.Select(recordId => new BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.Parameter,
					Parameter = new Parameter {
						DataValueType = DataValueType.Guid,
						Value = recordId
					}
				}).ToArray()
			};
			return filters;
		}

		private Dictionary<string, SelectQueryColumn> GetSelectQueryColumnItems(FilterConfig filterConfig) {
			var columnItems = new Dictionary<string, SelectQueryColumn>();
			var sortDirection = filterConfig.SortConfig?.Direction == OrderDirectionStrict.Ascending
				? OrderDirection.Ascending
				: OrderDirection.Descending;
			foreach (var column in filterConfig.ColumnCaptionData) {
				columnItems.Add(column.Name, new SelectQueryColumn() {
					Caption = column.Caption,
					OrderDirection = filterConfig.SortConfig?.ColumnPath == column.Name ? sortDirection : OrderDirection.None,
					Expression = new ColumnExpression() {
						ExpressionType = EntitySchemaQueryExpressionType.SchemaColumn,
						ColumnPath = column.Name
					}
				});
			}
			return columnItems;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates and writes excel stream to local storage and return export key.
		/// </summary>
		/// <param name="filterConfig">Filter data configuration.</param>
		/// <param name="objectValueRecords">Object value records, which will be exported.</param>
		/// <returns><see cref="ExportToExcelResponse"/>Export response.</returns>
		public ExportToExcelResponse GetExportToExcelKey(FilterConfig filterConfig, IEnumerable<ObjectValueRecord> objectValueRecords) {
			ClassFactory.ReBind<IRepository<StorableStreamEntity>, StreamRedisRepositorySecurityDecorator>();
			var columns = new SelectQueryColumns { Items = GetSelectQueryColumnItems(filterConfig) }; 
			var filters = GetSelectQueryFilters(objectValueRecords.Select(x => x.Id));
			var selectQuery = new SelectQuery {
				RootSchemaName = Consts.ForecastHistoryObjValueRecordSchemaName,
				Columns = columns,
				Filters = filters
			};
			return ExportToExcelService.PrepareExport(JsonConvert.SerializeObject(selectQuery));
		}

		#endregion

	}

	#endregion

}

