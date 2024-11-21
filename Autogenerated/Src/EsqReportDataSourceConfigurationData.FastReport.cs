namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;

	#region Class: EsqReportDataSourceConfigurationData

	[DefaultBinding(typeof(IReportDataSourceConfigurationData), Name = "ESQ")]
	public class EsqReportDataSourceConfigurationData : ReportDataSourceConfigurationData
	{

		#region Constructors: Public

		public EsqReportDataSourceConfigurationData(Guid id, string name, string serializedData) : base(id, name) {
			try {
				Schemas = JsonConvert.DeserializeObject<Dictionary<string, EsqDataSchema>>(serializedData);
			} catch {
				throw new Exception();
			}
		}

		#endregion

		#region Properties: Public

		public Dictionary<string, EsqDataSchema> Schemas { get; }

		#endregion

	}

	#endregion

	#region Class: EsqDataSchema

	public class EsqDataSchema
	{

		#region Properties: Public

		public string Name { get; set; }

		public Dictionary<string, EsqDataSchemaColumn> Columns { get; set; }

		#endregion

	}

	#endregion

	#region Class: EsqDataSchemaColumn

	public class EsqDataSchemaColumn
	{

		#region Properties: Public

		public string Path { get; set; }

		public DataValueType DataValueType { get; set; }

		public string ReferenceSchemaName { get; set; }

		public string ReferenceColumnName { get; set; }

		#endregion

	}

	#endregion

}

