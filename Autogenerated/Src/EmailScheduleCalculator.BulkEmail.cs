namespace BPMSoft.Configuration
{
    using System;
    using System.Linq;
	using Quartz;
    using BPMSoft.Core;
    using SysDayOfWeek = System.DayOfWeek;

    #region Class: EmailScheduleCalculator

	/// <summary>
	/// Provides method to calculate first scheduled launch date and time of email.
	/// </summary>
	public class EmailScheduleCalculator
    {

        #region Class: Nested

        private class CustomCronExpression : CronExpression
        {

            #region Fields: Private

            private SysDayOfWeek[] _daysDayOfWeeks;

            #endregion

            #region Constructors: Public

            public CustomCronExpression(string cronExpression)
                : base(cronExpression) { }

            #endregion

            #region Properties: Public

            public SysDayOfWeek[] DaysOfWeek => _daysDayOfWeeks ?? (_daysDayOfWeeks = GetDaysOfWeek());

            #endregion

            #region Methods: Private

            private SysDayOfWeek[] GetDaysOfWeek() {
                return daysOfWeek.Select(x => (SysDayOfWeek)(x - 1)).ToArray();
            }

            #endregion

        }

        #endregion

        #region Methods: Private

        private DateTime GetFirstDateOfSchedule(DateTime resultDateTime, SysDayOfWeek[] daysOfWeek) {
            var dayOfWeek = resultDateTime.DayOfWeek;
            var firstDayOfSchedule = daysOfWeek.Min();
            int daysCount;
			if (firstDayOfSchedule > dayOfWeek) {
				daysCount = firstDayOfSchedule - dayOfWeek;
			} else {
				var nextDay = daysOfWeek.FirstOrDefault(x => x > dayOfWeek);
				nextDay = nextDay == SysDayOfWeek.Sunday ? daysOfWeek.Min() : nextDay;
				daysCount = (7 + (nextDay - dayOfWeek)) % 7;
			}
			return resultDateTime.AddDays(daysCount);
        }

        private DateTime GetTimeWithTimeZoneOffset(string timeZoneId, DateTime utcDateTime) {
            var timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(timeZoneId);
            var targetLocalTimeNow = utcDateTime.Add(timeZoneInfo.GetUtcOffset(utcDateTime));
            return DateTime.SpecifyKind(targetLocalTimeNow, DateTimeKind.Local);
        }

        private bool IsDayOfWeekInRange(SysDayOfWeek[] daysOfWeek, string timeZoneId, DateTime localDateTime) {
            var targetDate = GetTimeWithTimeZoneOffset(timeZoneId, localDateTime);
            var currentDay = targetDate.DayOfWeek;
            return daysOfWeek.Contains(currentDay);
        }

		
		private bool IsTimeInRange(TimeSpan start, TimeSpan end, TimeSpan value) {
			if (start < end) {
				return start <= value && value < end;
			}
			return start <= value || value < end;
        }

        #endregion

        #region Methods: Public

        public DateTime GetFirstLaunchDate(DateTime now, EmailScheduleSettings settings) {
			var currentLocalTime = GetTimeWithTimeZoneOffset(settings.TimeZoneId, now);
			var resultDateTime = GetTimeWithTimeZoneOffset(settings.TimeZoneId, now);
            var businessTimeStart = settings.BusinessTimeStart.TimeOfDay;
            var businessTimeEnd = settings.BusinessTimeEnd.TimeOfDay;
			if (!IsTimeInRange(businessTimeStart, businessTimeEnd, resultDateTime.TimeOfDay)) {
				resultDateTime = resultDateTime.Date + businessTimeStart;
			}
			var daysOfWeek = new CustomCronExpression(settings.CronExpression).DaysOfWeek;
            var isAllWeekSchedule = daysOfWeek.Length == 0 || daysOfWeek.Length == 7;
			bool isDayOfWeekInRange = isAllWeekSchedule || IsDayOfWeekInRange(daysOfWeek, settings.TimeZoneId, resultDateTime);
			if (isDayOfWeekInRange && resultDateTime >= currentLocalTime) {
				return resultDateTime;
			}
			resultDateTime = resultDateTime.Date + businessTimeStart;
            return GetFirstDateOfSchedule(resultDateTime, daysOfWeek);
        }

        #endregion

    }

    #endregion

}
 
