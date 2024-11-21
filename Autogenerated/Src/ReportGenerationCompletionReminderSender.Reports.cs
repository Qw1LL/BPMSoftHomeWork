namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using FileConverter.Client.Task;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class ReportGenerationCompletionReminderSender

	/// <summary>
	/// Represents a reminder sender of report generation completion.
	/// </summary>
	public class ReportGenerationCompletionReminderSender : ReportGenerationCompletionSender
	{

		#region Fileds: Private

		private readonly AppConnection _appConnection;
		private readonly RemindingUtilities _remindingUtilities;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportGenerationCompletionReminderSender"/> class with a specified application connection.
		/// </summary>
		/// <param name="appConnection">The application connection.</param>
		public ReportGenerationCompletionReminderSender(AppConnection appConnection) {
			_appConnection = appConnection;
			_remindingUtilities = ClassFactory.Get<RemindingUtilities>();
		}

		#endregion

		#region Methods: Private

		private Entity CreateSysUserEntity() {
			var systemUserConnection = _appConnection.SystemUserConnection;
			return systemUserConnection.EntitySchemaManager
				.GetInstanceByName("SysAdminUnit")
				.CreateEntity(systemUserConnection);
		}

		private void SendReminding(IEntity sysUserEntity, FileConversionTask fileConversionTask, ReportGenerationTask reportGenerationTask) {
			var contactId = sysUserEntity.GetTypedColumnValue<Guid>("ContactId");
			contactId.CheckDependencyNull(nameof(contactId));
			var systemUserConnection = _appConnection.SystemUserConnection;
			var sysModuleReportEntity = systemUserConnection.EntitySchemaManager.FindInstanceByName("SysModuleReport");
			sysModuleReportEntity.CheckDependencyNull(nameof(sysModuleReportEntity));
			var config = new RemindingConfig(sysModuleReportEntity.UId) {
				AuthorId = contactId,
				SourceId = RemindingConsts.RemindingSourceAuthorId,
				ContactId = contactId,
				SubjectId = Guid.Empty,
				Description = string.Empty,
				RemindTime = DateTime.UtcNow,
				Config = new Dictionary<string, object> {
						{ "serviceName", nameof(PdfAsyncReportGenerationController) },
						{ "methodName", nameof(PdfAsyncReportGenerationController.GetReportFile) },
						{ "success", fileConversionTask.Status == TaskStatus.Successed },
						{ "reportName", reportGenerationTask.ReportName },
						{ "taskId", reportGenerationTask.TaskId }
					}
			};
			_remindingUtilities.CreateReminding(systemUserConnection, config);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc cref="ReportGenerationCompletionSender.SendMessageInternal"/>
		protected override bool SendMessageInternal(FileConversionTask fileConversionTask, UserReportGenerationTask reportGenerationTask) {
			var taskId = reportGenerationTask.TaskId;
			var userId = reportGenerationTask.UserId;
			var sysUserEntity = CreateSysUserEntity();
			if (!sysUserEntity.FetchFromDB(userId)) {
				return false;
			}
			SendReminding(sysUserEntity, fileConversionTask, reportGenerationTask);
			Log.Info($"The reminder about report generation completion for the task ID = {taskId} has been sent.");
			return true;
		}

		#endregion

	}

	#endregion

}
