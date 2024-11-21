namespace BPMSoft.Configuration.Reporting.FastReportEngine
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Reporting.DataSource.Abstractions.Data;

	#region Class: ReportDataSourceConfiguration

	public class ReportDataSourceConfiguration<TReportDataSourceConfigurationData> : IDataSourceConfiguration
		where TReportDataSourceConfigurationData : class, IReportDataSourceConfigurationData
	{

		#region Constructors: Public

		public ReportDataSourceConfiguration(TReportDataSourceConfigurationData data) {
			Data = data;
		}

		#endregion

		#region Properties: Public

		public Guid DataSourceId => Data.Id;

		public string DataSourceName => Data.Name;

		public TReportDataSourceConfigurationData Data { get; }

		public IReadOnlyDictionary<string, object> Parameters { get; private set; }

		#endregion

		#region Methods: Public

		public void ApplyParameters(IReadOnlyDictionary<string, object> parameters) {
			Parameters = parameters;
		}

		#endregion

	}

	#endregion

}

