namespace BPMSoft.Configuration
{
	using System;
	using global::Common.Logging;
	using FileConverter.Client;
	using FileConverter.Client.Http;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: AsyncReportGenerationBinder

	public class AsyncReportGenerationBinder : AppEventListenerBase
	{
		#region Constants: Private

		private const string FileConverterSysSettingCode = "ConvertServiceUrl";

		#endregion

		#region Methods: Private

		private void RegisterFileConverter(UserConnection userConnection) {
			var fileConverterServiceUrl = Core.Configuration.SysSettings.GetValue(userConnection, FileConverterSysSettingCode, string.Empty);
			if (string.IsNullOrEmpty(fileConverterServiceUrl)) {
				return;
			}
			var fileConverterClientSettings = new FileConverterHttpConnectionSettings {
				BaseUrl = new Uri(fileConverterServiceUrl),
				Timeout = TimeSpan.FromSeconds(30)
			};
			var fileConverterClient = new FileConverterHttpClient(fileConverterClientSettings);
			ClassFactory.Bind<IFileConverterClient>(() => fileConverterClient);
		}

		private void RegisterReportGenerationCompletionSender(AppConnection appConnection) {
			var reminderSender = new ReportGenerationCompletionReminderSender(appConnection);
			var notificationSender = new ReportGenerationCompletionNotificationSender();
			notificationSender.SetSuccessor(reminderSender);
			ClassFactory.Bind<ReportGenerationCompletionSender>(() => notificationSender);
		}

		#endregion

		#region Methods: Public

		public override void OnAppStart(AppEventContext context) {
			base.OnAppStart(context);
			var appConnection = context.Application["AppConnection"] as AppConnection;
			var userConnection = appConnection?.SystemUserConnection;
			RegisterFileConverter(userConnection);
			RegisterReportGenerationCompletionSender(appConnection);
		}

		#endregion

	}

	#endregion

}
