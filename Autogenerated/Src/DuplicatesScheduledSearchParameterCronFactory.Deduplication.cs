namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Linq;

	#region Class: DuplicatesScheduledSearchParameterCronFactory

	public static class DuplicatesScheduledSearchParameterCronFactory
	{
		#region Constants: Private

		private const int DayOfWeekShortNameLength = 3;

		#endregion

		#region Methods: Public

		public static string GetCronExpression(
				this DuplicatesScheduledSearchParameter duplicatesScheduledSearchParameter) {
			var searchDays = duplicatesScheduledSearchParameter.SearchDays;
			var searchTime = duplicatesScheduledSearchParameter.SearchTime;
			var daysOfWeek = Enum.GetValues(typeof(SearchDayOfWeek))
				.Cast<SearchDayOfWeek>()
				.Where(dayOfWeek => searchDays.HasFlag(dayOfWeek) && dayOfWeek != SearchDayOfWeek.None)
				.Select(dayOfWeek => dayOfWeek.ToString("G").Substring(0, DayOfWeekShortNameLength).ToUpper());
			return $"0 {searchTime.Minutes} {searchTime.Hours} ? * {string.Join(",", daysOfWeek)} *";
		}

		#endregion
	}

	#endregion
}
