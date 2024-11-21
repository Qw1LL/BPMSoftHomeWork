namespace BPMSoft.Configuration.Reporting.FastReportEngine.Custom
{
	using System.Collections.Generic;
	using BPMSoft.Reporting.DataSource.Abstractions.Data;

	#region Class: CustomDataSelect

	public class CustomDataSelect : IDataSelect
	{

		#region Constructors: Public

		public CustomDataSelect(string providerName, string schemaName, IReadOnlyDictionary<string, object> parameters) {
			ProviderName = providerName;
			SchemaName = schemaName;
			Parameters = parameters;
		}

		#endregion

		#region Properties: Public

		public string ProviderName { get; }

		public string SchemaName { get; }

		public IReadOnlyDictionary<string, object> Parameters { get; }

		#endregion

	}

	#endregion

}

