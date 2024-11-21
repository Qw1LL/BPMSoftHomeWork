namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core;

	#region Interface: IReportGenerator

	/// <summary>
	/// Provides report generating functionality.
	/// </summary>
	public interface IReportGenerator
	{

		#region Methods: Public

		/// <summary>
		/// Generates report.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="configuration">Provides configuration for report generator.</param>
		/// <returns>Returns prepared report.</returns>
		ReportData Generate(UserConnection userConnection, ReportGeneratorConfiguration configuration);

		#endregion

	}

	#endregion

}

