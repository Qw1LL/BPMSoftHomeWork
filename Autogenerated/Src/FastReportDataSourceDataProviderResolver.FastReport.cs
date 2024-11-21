namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using BPMSoft.Core.Factories;

	#region Class: FastReportDataSourceDataProviderResolver

	public class FastReportDataSourceDataProviderResolver : IFastReportDataSourceDataProviderResolver
	{

		#region Methods: Public

		public IFastReportDataSourceDataProvider Resolve(string providerName) {
			if (!ClassFactory.TryGet<IFastReportDataSourceDataProvider>(providerName, out var provider)) {
				throw new Exception();
			}
			return provider;
		}

		#endregion

	}

	#endregion

}

