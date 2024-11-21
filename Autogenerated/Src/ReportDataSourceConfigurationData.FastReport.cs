namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;

	#region Class: ReportDataSourceConfigurationData

	public abstract class ReportDataSourceConfigurationData : IReportDataSourceConfigurationData
	{

		#region Constructors: Protected

		protected ReportDataSourceConfigurationData(Guid id, string name) {
			Id = id;
			Name = name;
		}

		#endregion

		#region Properties: Public

		public Guid Id { get; }

		public string Name { get; }

		#endregion

	}

	#endregion

}

