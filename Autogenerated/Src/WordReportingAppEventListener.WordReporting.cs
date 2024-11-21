namespace BPMSoft.Configuration.Reporting.WordReporting
{
	using BPMSoft.Common;
	using BPMSoft.Configuration.Reporting.Word.Worker;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: WordReportingAppEventListener

	public class WordReportingAppEventListener : AppEventListenerBase
	{

		#region Properties: Private

		private UserConnection UserConnection => ClassFactory.Get<UserConnection>();

		#endregion

		#region Public: Methods

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			ClassFactory.Bind<IWordReportDesignWorker>(() => new WordReportingDesignWorker(UserConnection));
		}

		#endregion

	}

	#endregion

}

