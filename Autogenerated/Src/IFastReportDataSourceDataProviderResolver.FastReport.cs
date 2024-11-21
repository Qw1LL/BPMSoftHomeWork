namespace BPMSoft.Configuration.Reporting.FastReport
{

	#region Interface: IFastReportDataSourceDataProviderResolver

	public interface IFastReportDataSourceDataProviderResolver
	{

		#region Methods: Public

		IFastReportDataSourceDataProvider Resolve(string providerName);

		#endregion

	}

	#endregion

}

