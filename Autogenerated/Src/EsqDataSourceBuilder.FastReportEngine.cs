namespace BPMSoft.Configuration.Reporting.FastReportEngine.Esq
{
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Reporting.DataSource.Abstractions;

	#region Class: EsqDataSourceBuilder

	[DefaultBinding(typeof(IDataSourceBuilder), Name = "ESQ")]
	public class EsqDataSourceBuilder : DataSourceBuilder<ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData>, EsqDataSelect>
	{

		#region Constructors: Public

		public EsqDataSourceBuilder(UserConnection userConnection)
			: base(CreateConfigurationProvider(userConnection), CreateDataProvider(userConnection), CreateDataSelectExtractor(userConnection), CreateDataSchemaExtractor(userConnection)) {
		}

		#endregion

		#region Methods: Private

		private static IDataSourceConfigurationProvider<ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData>> CreateConfigurationProvider(UserConnection userConnection) {
			return new ReportDataSourceConfigurationProvider<EsqReportDataSourceConfigurationData>(userConnection);
		}

		private static IDataProvider<EsqDataSelect> CreateDataProvider(UserConnection userConnection) {
			return new EsqDataProvider(userConnection);
		}

		private static IDataSelectExtractor<ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData>, EsqDataSelect> CreateDataSelectExtractor(UserConnection userConnection) {
			return new EsqDataSelectExtractor(userConnection);
		}

		private static IDataSchemaExtractor<ReportDataSourceConfiguration<EsqReportDataSourceConfigurationData>> CreateDataSchemaExtractor(UserConnection userConnection) {
			return new EsqDataSchemaExtractor(userConnection);
		}

		#endregion

	}

	#endregion

}

