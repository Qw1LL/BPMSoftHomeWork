namespace BPMSoft.Configuration.Reporting.FastReportEngine
{
	using BPMSoft.Reporting.FastReport.Connection;
	using BPMSoft.Reporting.FastReport;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: FastReportAppEventListener

	public class FastReportAppEventListener : AppEventListenerBase
	{

		#region Fields: Private

		private ILog _logger = LogManager.GetLogger("BPMSoft");

		#endregion

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ReportDataSourceConnectionInitializer.Initialize();
			var fontListFileWasCreated = FontListFileCreator.TryCreate();
			if (!fontListFileWasCreated) {
				this._logger.Error("font.list file was not created.");
			}
		}

		#endregion

	}

	#endregion

}

