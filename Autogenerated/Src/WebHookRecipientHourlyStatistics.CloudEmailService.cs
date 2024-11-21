namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: RecipientHourlyStatistics

	public class RecipientHourlyStatistics : RecipientStatistics
	{

		#region Properties: Public

		private DateTime _dateMark;
		public DateTime DateMark {
			get {
				return WebHookUtilities.GetSafeSqlDate(_dateMark);
			}
			set {
				_dateMark = value;
			}
		}

		#endregion

		#region Methods: Public

		public override string GetGroupKey() {
			return base.GetGroupKey() + DateMark;
		}

		public override void HandleWebHook(UserConnection userConnection) {
			SetStatistic(userConnection, "BulkEmailHourlyClicks", Clicks);
			SetStatistic(userConnection, "BulkEmailHourlyOpens", Opens);
		}

		private void SetStatistic(UserConnection userConnection, string schemaName, int count) {
			var select = new Select(userConnection)
				.Top(1)
				.Column(Column.Parameter(count)).As("EventsCount")
				.Column(Column.Parameter(DateMark)).As("DateMark")
				.Column(Column.Parameter(EmailId)).As("BulkEmailId")
				.From("SysOneRecord")
				.Where().Not().Exists(new Select(userConnection)
					.Column(Column.Const(1))
					.From(schemaName)
					.Where("BulkEmailId").IsEqual(Column.Parameter(EmailId))
					.And("DateMark").IsEqual(Column.Parameter(DateMark))) as Select;
			select.SpecifyNoLockHints();
			new InsertSelect(userConnection).Into(schemaName)
				.Set("EventsCount", "DateMark", "BulkEmailId")
				.FromSelect(select)
				.Execute();
			new Update(userConnection, schemaName)
				.Set("EventsCount", Column.Parameter(count))
				.Where("DateMark").IsEqual(Column.Parameter(DateMark))
				.And("BulkEmailId").IsEqual(Column.Parameter(EmailId)).Execute();
		}

		#endregion

	}
	
	#endregion

}
