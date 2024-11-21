namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using BPMSoft.Core.DB;

	#region Class: BaseWebHook

	public abstract class BaseWebHook
	{

		#region Properties: Public

		public StatisticEventType Type {
			get;
			set;
		}

		private DateTime _eventDate;
		public DateTime EventDate {
			get {
				return WebHookUtilities.GetSafeSqlDate(_eventDate);
			}
			set {
				_eventDate = value;
			}
		}

		#endregion

		#region Methods: Public

		public abstract void HandleWebHook(UserConnection userConnection);

		public bool TryHandleWebHook(DBExecutor dbExecutor, UserConnection userConnection){
			try {
				dbExecutor.StartTransaction();
				HandleWebHook(userConnection);
				dbExecutor.CommitTransaction();
				return true;
			} catch (Exception e) {
				dbExecutor.RollbackTransaction();
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookHandler.ProcessWebHooks.TryHandleWebHook]", e);
			}
			return false;
		}

		public virtual string GetGroupKey() {
			return Type.ToString();
		}

		#endregion

	}

	#endregion

}


