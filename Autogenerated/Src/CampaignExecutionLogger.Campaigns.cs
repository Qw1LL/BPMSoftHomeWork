namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.Campaign;
	using Core.DB;

	#region Class: CampaignExecutionLogger

	/// <summary>
	/// Represented method for the logging results of campaign actions.
	/// </summary>
	public class CampaignExecutionLogger : ICampaignExecutionLogger
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize <see cref="CampaignExecutionLogger"/> instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public CampaignExecutionLogger(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void AddLogActionColumnValue(Insert insert, string columnName, object value) {
			if (value == null) {
				return;
			}
			insert.Set(columnName, Column.Parameter(value));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Common log action method.
		/// </summary>
		/// <param name="info">Instance of <see cref="CampaignLogInfo"/>.</param>
		public void LogAction(CampaignLogInfo info) {
			Guid status = info.IsSuccess
				? CampaignConstants.CampaignLogStatusSuccess
				: CampaignConstants.CampaignLogStatusError;
			Insert insert = new Insert(_userConnection).Into("CampaignLog");
			AddLogActionColumnValue(insert, "ErrorText", info.ErrorText);
			AddLogActionColumnValue(insert, "ActionId", info.Action);
			AddLogActionColumnValue(insert, "CampaignId", info.CampaignId);
			AddLogActionColumnValue(insert, "StatusId", status);
			AddLogActionColumnValue(insert, "ScheduledDate", info.ScheduledDate);
			AddLogActionColumnValue(insert, "Amount", info.Amount);
			AddLogActionColumnValue(insert, "CampaignItemId", info.CampaignItemId);
			AddLogActionColumnValue(insert, "StartDate", info.StartDate);
			AddLogActionColumnValue(insert, "EndDate", info.EndDate);
			if (info.SessionId != default(Guid)) {
				AddLogActionColumnValue(insert, "SessionId", info.SessionId);
			}
			insert.Execute();
		}

		#endregion

	}

	#endregion

}
