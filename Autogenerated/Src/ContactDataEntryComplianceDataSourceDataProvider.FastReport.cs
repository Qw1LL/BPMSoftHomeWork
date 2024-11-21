namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using EntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;

	#region Class: CustomDataProvider

	[DefaultBinding(typeof(IFastReportDataSourceDataProvider), Name = "ContactDataEntryComplianceDataSourceDataProvider")]
	public class ContactDataEntryComplianceDataSourceDataProvider : IFastReportDataSourceDataProvider
	{

		#region Fields: Private

		private readonly Guid _entitySchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");
		private readonly string _resourceManagerName = "ContactDataEntryComplianceDataSourceDataProvider";
		private readonly string[] _localizableStringNames = new[] {
			"ReportTitle",
			"QuantityOfRecordsLabel",
			"ColumnLabel",
			"FilledInPercentageLabel",
			"FilledInLabel",
			"NotFilledInLabel"
		};

		#endregion

		#region Methods: Private

		private IEntitySchemaQueryFilterItem CreateEmptyColumnValueFilter(EntitySchemaQuery query, EntitySchemaColumn column) {
			return column.DataValueType is TextDataValueType
				? query.CreateFilterWithParameters(FilterComparisonType.NotEqual, column.Name, string.Empty)
				: query.CreateIsNotNullFilter(column.Name);
		}

		private int GetFilledColumnRowCount(UserConnection userConnection,
				EntitySchema entitySchema, EntitySchemaColumn column, IEntitySchemaQueryFilterItem filter) {
			EntitySchemaQuery query = new EntitySchemaQuery(entitySchema);
			query.AddColumn(query.RootSchema.GetPrimaryColumnName()).SummaryType = AggregationType.Count;
			query.Filters.Add(CreateEmptyColumnValueFilter(query, column));
			query.Filters.Add(filter);
			return query.GetSummarySelectQuery(userConnection).ExecuteScalar<int>();
		}

		private int GetRecordCount(UserConnection userConnection, Guid entitySchemaUId, IEntitySchemaQueryFilterItem filter) {
			var entitySchema = userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			return GetFilledColumnRowCount(userConnection, entitySchema, entitySchema.GetDBPrimaryColumn(), filter);
		}

		private bool CanSkipColumn(EntitySchemaColumn column) {
			return
				column.UsageType == EntitySchemaColumnUsageType.None ||
				column.UsageType == EntitySchemaColumnUsageType.Advanced ||
				(column.DataValueType is BooleanDataValueType) ||
				column.Name == "Photo16" ||
				column.Name == "Photo22" ||
				column.Name == "Photo32";
		}

		private IEnumerable<IReadOnlyDictionary<string, object>> GetCompletnessData(
				UserConnection userConnection,
				Guid entitySchemaUId,
				IEntitySchemaQueryFilterItem filter) {
			var entitySchema = userConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			var recordCount = GetRecordCount(userConnection, entitySchemaUId, filter);
			return entitySchema.Columns
				.Where(column => !CanSkipColumn(column))
				.Select(entitySchemaColumn => {
					var filledColumnRowCount = GetFilledColumnRowCount(userConnection, entitySchema, entitySchemaColumn, filter);
					return new Dictionary<string, object> {
						["ColumnName"] = entitySchemaColumn.Caption.ToString(),
						["PercentageFilledIn"] =
							(int)Math.Round((double)filledColumnRowCount / (recordCount == 0 ? 1 : recordCount) * 100, 0),
						["FilledIn"] = filledColumnRowCount,
						["NotFilledIn"] = recordCount - filledColumnRowCount
					};
				})
				.OrderByDescending(x => x["PercentageFilledIn"])
				.ThenBy(x => x["ColumnName"]);
		}

		private IEnumerable<IReadOnlyDictionary<string, object>> GetNumberOfRecordsData(
				UserConnection userConnection,
				Guid entitySchemaUId,
				IEntitySchemaQueryFilterItem filter) {
			return new[] {
				new Dictionary<string, object> {
					["Count"] = GetRecordCount(userConnection, entitySchemaUId, filter)
				}
			};
		}

		private IEnumerable<IReadOnlyDictionary<string, object>> GetLocalizableStrings(UserConnection userConnection) {
			var localizableStrings = _localizableStringNames.ToDictionary(
				x => x,
				x => (object)(new LocalizableString(userConnection.ResourceStorage, _resourceManagerName, $"LocalizableStrings.{x}.Value")).Value);
			return new[] { localizableStrings };
		}

		private IEntitySchemaQueryFilterItem ExtractFilterFromParameters(UserConnection userConnection, Guid entitySchemaUId,
				IReadOnlyDictionary<string, object> parameters) {
			var managerItem = userConnection.EntitySchemaManager.GetItemByUId(entitySchemaUId);
			return parameters.ExtractEsqFilterFromReportParameters(userConnection, managerItem.Name) ?? throw new Exception();
		}

		#endregion

		#region Methods: Public

		public Task<ReportDataDictionary> GetData(UserConnection userConnection, IReadOnlyDictionary<string, object> parameters) {
			var filter = ExtractFilterFromParameters(userConnection, _entitySchemaUId, parameters);
			var result = new ReportDataDictionary {
				["CompletnessData"] = GetCompletnessData(userConnection, _entitySchemaUId, filter),
				["NumberOfRecordsData"] = GetNumberOfRecordsData(userConnection, _entitySchemaUId, filter),
				["LocalizableStrings"] = GetLocalizableStrings(userConnection)
			};
			return Task.FromResult(result);
		}

		#endregion

	}

	#endregion

}

