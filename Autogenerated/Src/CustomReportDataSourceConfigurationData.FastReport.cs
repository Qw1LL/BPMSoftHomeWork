namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region Class: CustomReportDataSourceConfigurationData

	[DefaultBinding(typeof(IReportDataSourceConfigurationData), Name = "Custom")]
	public class CustomReportDataSourceConfigurationData : ReportDataSourceConfigurationData
	{

		#region Constructors: Public

		public CustomReportDataSourceConfigurationData(Guid id, string name, string serializedData) : base(id, name) {
			try {
				var data = JsonConvert.DeserializeObject<CustomReportDataSourceConfigurationDataDto>(serializedData);
				ProviderName = data.ProviderName;
				Schemas = data.Schemas;
			} catch {
				throw new Exception();
			}
		}

		#endregion

		#region Properties: Public

		public string ProviderName { get; set; }

		public Dictionary<string, Dictionary<string, CustomDataSchemaColumn>> Schemas { get; }

		#endregion

	}

	#endregion

	#region Class: CustomReportDataSourceConfigurationDataDto

	public class CustomReportDataSourceConfigurationDataDto
	{

		#region Properties: Public

		public string ProviderName { get; set; }

		public Dictionary<string, Dictionary<string, CustomDataSchemaColumn>> Schemas { get; set; }

		#endregion

	}

	#endregion

	#region Class: CustomDataSchemaColumn

	public class CustomDataSchemaColumn
	{

		#region Properties: Public

		public DataValueType DataValueType { get; set; }

		public string ReferenceSchemaName { get; set; }

		public string ReferenceColumnName { get; set; }

		#endregion

	}

	#endregion

}

