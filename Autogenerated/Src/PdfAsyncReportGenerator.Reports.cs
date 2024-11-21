namespace BPMSoft.Configuration
{
	using FileConverterFileExtension = FileConverter.Client.File;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.ReportService;

	#region Class: PdfAsyncReportGenerator

	/// <summary>
	/// Represents a report generator in the PDF format.
	/// </summary>
	[DefaultBinding(typeof(IAsyncReportGenerator), Name = "PDF")]
	public class PdfAsyncReportGenerator : BaseAsyncReportGenerator
	{

		#region Fields: Private

		private readonly IReportGenerator _wordReportGenerator;

		#endregion

		#region Constructors: Public

		public PdfAsyncReportGenerator() {
			_wordReportGenerator = ClassFactory.Get<IReportGenerator>("Word");
		}

		#endregion

		#region Properties: Protected

		/// <inheritdoc cref="BaseAsyncReportGenerator.SourceFileExtension"/>
		protected override FileConverterFileExtension.FileExtension SourceFileExtension => FileConverterFileExtension.FileExtension.Docx;

		/// <inheritdoc cref="BaseAsyncReportGenerator.TargetFileExtension"/>
		protected override FileConverterFileExtension.FileExtension TargetFileExtension => FileConverterFileExtension.FileExtension.Pdf;

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="BaseAsyncReportGenerator.PrepareReport(UserConnection, ReportGeneratorConfiguration)"/>
		protected override ReportData PrepareReport(UserConnection userConnection, ReportGeneratorConfiguration configuration) {
			return _wordReportGenerator.Generate(userConnection, configuration);
		}

		#endregion

	}

	#endregion

}

