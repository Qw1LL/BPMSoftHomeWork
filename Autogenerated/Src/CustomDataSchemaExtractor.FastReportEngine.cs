namespace BPMSoft.Configuration.Reporting.FastReportEngine.Custom
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Core;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Reporting.DataSource.Abstractions;
	using BPMSoft.Reporting.DataSource.Abstractions.Data;

	#region Class: CustomDataSchemaExtractor

	internal class CustomDataSchemaExtractor : IDataSchemaExtractor<ReportDataSourceConfiguration<CustomReportDataSourceConfigurationData>>
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Internal

		internal CustomDataSchemaExtractor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Type ToClrType(DataValueType dataValueType) {
			return dataValueType is BinaryDataValueType ? typeof(byte[]) : dataValueType.ValueType;
		}

		private DataSchemaColumn ConvertToDataSchemaColumn(string columnName, CustomDataSchemaColumn customDataSchemaColumn) {
			var coreDataValueType = customDataSchemaColumn.DataValueType.ToDataValueType(_userConnection);
			if (coreDataValueType.IsLookup) {
				return new ReferenceDataSchemaColumn(
					columnName,
					ToClrType(coreDataValueType),
					customDataSchemaColumn.ReferenceSchemaName,
					customDataSchemaColumn.ReferenceColumnName);
			}
			return new DataSchemaColumn(
				columnName,
				ToClrType(coreDataValueType));
		}

		private DataSchema ConvertToDataSchema(string dataSchemaName, Dictionary<string, CustomDataSchemaColumn> columns) {
			return new DataSchema(
				dataSchemaName,
				columns.Select(x => ConvertToDataSchemaColumn(x.Key, x.Value)));
		}

		#endregion

		#region Methods: Public

		public IEnumerable<DataSchema> Extract(ReportDataSourceConfiguration<CustomReportDataSourceConfigurationData> configuration) {
			return configuration.Data.Schemas.Select(x => ConvertToDataSchema(x.Key, x.Value));
		}

		#endregion

	}

	#endregion

}

