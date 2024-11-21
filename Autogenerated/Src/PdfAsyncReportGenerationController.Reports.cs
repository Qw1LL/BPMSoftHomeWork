namespace BPMSoft.Configuration
{
	using System.ServiceModel.Activation;
	using BPMSoft.Core.Factories;

	#region Class: PdfAsyncReportGenerationController


	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	/// <summary>
	/// Represents a controller of asynchronous PDF-report generation service.
	/// </summary>
	public class PdfAsyncReportGenerationController : BaseAsyncReportGenerationController
	{

		#region Properties: Protected

		/// <inheritdoc cref="BaseAsyncReportGenerationService.ContentType"/>
		protected override string ContentType => "application/pdf; charset=UTF-8";


		/// <inheritdoc cref="BaseAsyncReportGenerationService.ReportGenerator"/>
		protected override IAsyncReportGenerator ReportGenerator => ClassFactory.Get<IAsyncReportGenerator>("PDF");

		#endregion

	}

	#endregion

}
