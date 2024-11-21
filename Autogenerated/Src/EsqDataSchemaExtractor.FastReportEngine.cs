namespace BPMSoft.Configuration.Reporting.FastReportEngine.Esq
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Core;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Reporting.DataSource.Abstractions;
	using BPMSoft.Reporting.DataSource.Abstractions.Data;

	#region Class: EsqDataSelectExtractor

	public class EsqDataSchemaExtractor : IDataSchemaExtractor<ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData>>
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public EsqDataSchemaExtractor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private DataSchemaColumn ConvertToDataSchemaColumn(string columnAlias, EsqDataSchemaColumn esqDataSchemaColumn) {

			var coreDataValueType = esqDataSchemaColumn.DataValueType.ToDataValueType(_userConnection);
			if (coreDataValueType.IsLookup) {
				return new ReferenceDataSchemaColumn(
					columnAlias,
					coreDataValueType.ValueType,
					esqDataSchemaColumn.ReferenceSchemaName,
					esqDataSchemaColumn.ReferenceColumnName);
			}
			return new DataSchemaColumn(
				columnAlias,
				coreDataValueType.ValueType);
		}

		private DataSchema ConvertToDataSchema(EsqDataSchema esqDataSchema) {
			return new DataSchema(
				esqDataSchema.Name,
				esqDataSchema.Columns.Select(x => ConvertToDataSchemaColumn(x.Key, x.Value)));
		}

		#endregion

		#region Methods: Public

		public IEnumerable<DataSchema> Extract(ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData> configuration) {
			return configuration.Data.Schemas.Select(x => ConvertToDataSchema(x.Value));
		}

		#endregion

	}

	#endregion

}

