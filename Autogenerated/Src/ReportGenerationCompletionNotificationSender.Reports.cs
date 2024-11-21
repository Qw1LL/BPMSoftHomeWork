namespace BPMSoft.Configuration
{
	using System;
	using FileConverter.Client.Task;
	using BPMSoft.Messaging.Common;

	#region Class ReportGenerationCompletionNotificationSender

	/// <summary>
	/// Represents a notification sender of report generation completion.
	/// </summary>
	public class ReportGenerationCompletionNotificationSender : ReportGenerationCompletionSender
	{

		#region Properties: Protected

		/// <summary>
		/// Gets the name of a socket message sender.
		/// </summary>
		protected virtual string NotifySender => "AsyncReportNotifier";

		#endregion

		#region Methods: Private

		private void SendNotification(
				IMsgChannel channel,
				FileConversionTask fileConversionTask,
				UserReportGenerationTask reportGenerationTask) {
			var simpleMessage = new SimpleMessage {
				Id = Guid.NewGuid(),
				Body = GetNotificationBody(fileConversionTask, reportGenerationTask),
			};
			simpleMessage.Header.Sender = NotifySender;
			channel.PostMessage(simpleMessage);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets the body of a notification message.
		/// </summary>
		/// <param name="fileConversionTask">The remote task of file conversion.</param>
		/// <param name="reportGenerationTask">The local task of a report generation.</param>
		/// <returns>The message body of notification by the <paramref name="fileConversionTask"/> and <paramref name="reportGenerationTask"/>.</returns>
		protected virtual object GetNotificationBody(FileConversionTask fileConversionTask, UserReportGenerationTask reportGenerationTask) {
			return new {
				taskId = reportGenerationTask.TaskId,
				reportName = reportGenerationTask.ReportName,
				success = fileConversionTask.Status == TaskStatus.Successed,
				methodName = nameof(IAsyncReportGenerationController.GetReportFile),
				serviceName = nameof(PdfAsyncReportGenerationController),
			};
		}

		/// <inheritdoc cref="ReportGenerationCompletionSender.SendMessageInternal"/>
		protected override bool SendMessageInternal(FileConversionTask fileConversionTask, UserReportGenerationTask reportGenerationTask) {
			var taskId = reportGenerationTask.TaskId;
			var userId = reportGenerationTask.UserId;
			var channel = MsgChannelManager.Instance.FindItemByUId(userId);
			if (channel == null) {
				return false;
			}
			SendNotification(channel, fileConversionTask, reportGenerationTask);
			Log.Info($"The notification about report generation completion for the task ID = {taskId} has been sent.");
			return true;
		}

		#endregion

	}

	#endregion

}
