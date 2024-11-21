namespace BPMSoft.Configuration
{
	#region Class: AsyncReportGeneratorConfiguration

	/// <summary>
	/// Represents a extension of the <see cref="ReportGeneratorConfiguration"/> for asynchronous report generation.
	/// </summary>
	public class AsyncReportGeneratorConfiguration : ReportGeneratorConfiguration
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets a callback URL for notification of completion of report generation.
		/// </summary>
		public string CallbackUrl { get; set; }

		#endregion

	}

	#endregion

}
