namespace BPMSoft.Configuration.Reporting.FastReportEngine.Custom
{
	using System;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Reporting.DataSource.Abstractions;

	#region Class: CustomDataSelectExtractor

	internal class CustomDataSelectExtractor : IDataSelectExtractor<ReportDataSourceConfiguration<CustomReportDataSourceConfigurationData>, CustomDataSelect>
	{

		#region Methods: Public

		public CustomDataSelect Extract(ReportDataSourceConfiguration<CustomReportDataSourceConfigurationData> configuration, string schemaName) {
			if (!configuration.Data.Schemas.ContainsKey(schemaName)) {
				throw new Exception();
			}
			return new CustomDataSelect(configuration.Data.ProviderName, schemaName, configuration.Parameters);
		}

		#endregion

	}

	#endregion

}

