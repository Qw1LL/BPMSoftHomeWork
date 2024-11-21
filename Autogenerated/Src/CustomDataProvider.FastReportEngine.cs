namespace BPMSoft.Configuration.Reporting.FastReportEngine.Custom
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using BPMSoft.Configuration.Reporting.FastReport;
	using BPMSoft.Core;
	using BPMSoft.Reporting.DataSource.Abstractions;

	#region Class: CustomDataProvider

	internal class CustomDataProvider : IDataProvider<CustomDataSelect>
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IFastReportDataSourceDataProviderResolver _dataSourceDataProviderResolver;
		private ReportDataDictionary _dataSourceData;

		#endregion

		#region Constructors: Internal

		internal CustomDataProvider(UserConnection userConnection, IFastReportDataSourceDataProviderResolver dataSourceDataProviderResolver) {
			_userConnection = userConnection;
			_dataSourceDataProviderResolver = dataSourceDataProviderResolver;
		}

		#endregion

		#region Methods: Private

		public async Task<ReportDataDictionary> GetDataSourceData(string providerName, IReadOnlyDictionary<string, object> parameters) {
			if (_dataSourceData == null) {
				var provider = _dataSourceDataProviderResolver.Resolve(providerName);
				_dataSourceData = await provider.GetData(_userConnection, parameters);
			}
			return _dataSourceData;
		}

		#endregion

		#region Methods: Public

		public async Task<IEnumerable<IReadOnlyDictionary<string, object>>> GetData(CustomDataSelect select) {
			var dataSourceData = await GetDataSourceData(select.ProviderName, select.Parameters);
			if (!dataSourceData.TryGetValue(select.SchemaName, out var result)) {
				throw new Exception();
			}
			return result;
		}

		#endregion

	}

	#endregion

}

