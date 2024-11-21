using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: TermCalculatorActions

	public class TermCalculatorActions
	{
		#region Constructors: Public

		public TermCalculatorActions(UserConnection userConnection, Guid calendarId) {
			UserConnection = userConnection;
			Utils = new CalendarUtils(UserConnection);
			CalendarId = calendarId;
			CalendarIdsChain = Utils.GetCalendarIdsChain(calendarId);
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { 
			get; 
			set; 
		}

		protected CalendarUtils Utils { 
			get; 
			set; 
		}

		protected Guid CalendarId { 
			get; 
			set; 
		}

		protected IEnumerable<Guid> CalendarIdsChain { 
			get; 
			set; 
		}

		#endregion

		#region Methods: Private

		private KeyValuePair<DateTime, DayInCalendar> GetNearestNotWeekendDay(DateTime registrationDateTime,
			bool moveForvard = true) {
			DayInCalendar day = Utils.GetCalendarDay(CalendarIdsChain, registrationDateTime);
			if (!day.GetTypedColumnValue<bool>("DayType_IsWeekend")) {
				return new KeyValuePair<DateTime, DayInCalendar>(registrationDateTime, day);
			}
			registrationDateTime = registrationDateTime.Date.AddDays(moveForvard ? 1 : -1);
			return GetNearestNotWeekendDay(registrationDateTime, moveForvard);
		}

		private TimeSpan GetLastWorkingTimeIntervalEnd(Guid dayPrimaryColumnValue) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			EntitySchemaQueryColumn toColumn = esq.AddColumn("To");
			toColumn.SummaryType = AggregationType.Max;
			esq.RowCount = 1;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				dayPrimaryColumnValue));
			Entity entity = esq.GetSummaryEntity(UserConnection);

			return entity != null ? entity.GetTypedColumnValue<DateTime>(toColumn.Name).TimeOfDay : TimeSpan.Zero;
		}
		
		private DateTime GetLastWorkingDayDateTime (DayInCalendar day) {
			return day.Date.Date + GetLastWorkingTimeIntervalEnd(day.PrimaryColumnValue);
		}

		private DateTime RemoveWorkingDays(DateTime registrationDateTime, int daysCount) {
			DateTime fromDay = registrationDateTime.Date.AddDays(-daysCount);
			DateTime toDay = registrationDateTime.Date.AddDays(-1);

			List<DayInCalendar> days = Utils.GetCalendarDays(CalendarIdsChain, fromDay, toDay).ToList();
			int weekendDaysCount = days.Count(d => d.GetTypedColumnValue<bool>("DayType_IsWeekend"));
			while (weekendDaysCount != 0) {
				toDay = fromDay.AddDays(-1);
				fromDay = fromDay.AddDays(-weekendDaysCount);
				days = Utils.GetCalendarDays(CalendarIdsChain, fromDay, toDay).ToList();
				weekendDaysCount = days.Count(d => d.GetTypedColumnValue<bool>("DayType_IsWeekend"));
			}

			DateTime minDate = days.Min(d => d.Date);
			DayInCalendar minDay = days.Single(d => d.Date == minDate);
			return minDay.Date + GetLastWorkingTimeIntervalEnd(minDay.PrimaryColumnValue);
		}

		private DateTime AddWorkingPeriod(DateTime periodDateTime) {
			periodDateTime = GetNextWorkingTimeIntervalStart(periodDateTime) + 
					(periodDateTime.TimeOfDay - GetPreviousWorkingTimeIntervalEnd(periodDateTime).TimeOfDay);
			if (!IsTimeInWorkingInterval(periodDateTime)) {
				 periodDateTime = AddWorkingPeriod(periodDateTime);
			}
			return periodDateTime;
		}

		#endregion

		#region Methods: Public

		public bool IsTimeInWorkingInterval(DateTime registrationDateTime) {
			DayInCalendar day = Utils.GetCalendarDay(CalendarIdsChain, registrationDateTime);
			if (day.GetTypedColumnValue<bool>("DayType_IsWeekend")) {
				return false;
			}

			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("Id");
			esq.RowCount = 1;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				day.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "To",
				registrationDateTime.TimeOfDay));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "From",
				registrationDateTime.TimeOfDay));
			return esq.GetEntityCollection(UserConnection).Any();
		}

		public DateTime GetNextWorkingTimeIntervalStart(DateTime registrationDateTime) {
			KeyValuePair<DateTime, DayInCalendar> foundDay = GetNearestNotWeekendDay(registrationDateTime);
			DayInCalendar day = foundDay.Value;
			DateTime dateTime = foundDay.Key;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("From");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				day.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.GreaterOrEqual, "From", 
				dateTime.TimeOfDay));

			EntityCollection timeIntervals = esq.GetEntityCollection(UserConnection);
			if (!timeIntervals.Any()) {
				return GetNextWorkingTimeIntervalStart(dateTime.Date.AddDays(1));
			}

			return dateTime.Date + timeIntervals.Min(d => d.GetTypedColumnValue<DateTime>("From").TimeOfDay);
		}

		public DateTime GetPreviousWorkingTimeIntervalEnd(DateTime registrationDateTime) {
			KeyValuePair<DateTime, DayInCalendar> foundDay = GetNearestNotWeekendDay(registrationDateTime, false);
			DayInCalendar day = foundDay.Value;
			DateTime dateTime = foundDay.Key;

			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("To");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				day.PrimaryColumnValue));
			if (dateTime.TimeOfDay != TimeSpan.Zero) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.LessOrEqual, "To", 
					dateTime.TimeOfDay));
			}

			EntityCollection timeIntervals = esq.GetEntityCollection(UserConnection);
			if (!timeIntervals.Any()) {
				return GetPreviousWorkingTimeIntervalEnd(dateTime.Date.AddDays(-1));
			}

			return dateTime.Date + timeIntervals.Max(d => d.GetTypedColumnValue<DateTime>("To").TimeOfDay);
		}

		public DateTime GetFirstDateTimeInDay(DateTime registrationDateTime) {
			KeyValuePair<DateTime, DayInCalendar> foundDay = GetNearestNotWeekendDay(registrationDateTime, false);
			DayInCalendar day = foundDay.Value;
			DateTime dateTime = foundDay.Key;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("From");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				day.PrimaryColumnValue));
			EntityCollection timeIntervals = esq.GetEntityCollection(UserConnection);
			if (!timeIntervals.Any()) {
				return GetPreviousWorkingTimeIntervalEnd(dateTime.Date.AddDays(-1));
			}
			return dateTime.Date + timeIntervals.Min(d => d.GetTypedColumnValue<DateTime>("From").TimeOfDay);
		}

		public DateTime GetLastDateTimeInDay(DateTime registrationDateTime) {
			KeyValuePair<DateTime, DayInCalendar> foundDay = GetNearestNotWeekendDay(registrationDateTime, false);
			DayInCalendar day = foundDay.Value;
			DateTime dateTime = foundDay.Key;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("To");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", 
				day.PrimaryColumnValue));
			EntityCollection timeIntervals = esq.GetEntityCollection(UserConnection);
			if (!timeIntervals.Any()) {
				return GetPreviousWorkingTimeIntervalEnd(dateTime.Date.AddDays(1));
			}
			return dateTime.Date + timeIntervals.Max(d => d.GetTypedColumnValue<DateTime>("To").TimeOfDay);
		}

		public TimeSpan GetWeekendTimeSpan(DateTime registrationDateTime, DateTime responseDateTime) {
			TimeSpan weekendTimeSpan = responseDateTime - registrationDateTime;
			TimeSpan workingTimeSpan = GetWorkingTimeSpan(registrationDateTime, responseDateTime);
			return weekendTimeSpan > workingTimeSpan ? weekendTimeSpan - workingTimeSpan : TimeSpan.Zero;
		}

		public TimeSpan GetWorkingTimeSpan(DateTime fromDateTime, DateTime toDateTime) {
			bool isNegative = false;
			if (fromDateTime > toDateTime) {
				DateTime tempDateTime = fromDateTime;
				fromDateTime = toDateTime;
				toDateTime = tempDateTime;
				isNegative = true;
			}

			List<DayInCalendar> days =
				Utils.GetCalendarDays(CalendarIdsChain, fromDateTime, toDateTime).OrderBy(d => d.Date).ToList();
			DayInCalendar fromDay = days.First();
			DayInCalendar toDay = days.Last();

			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddColumn("From");
			esq.AddColumn("To");
			esq.AddColumn("DayInCalendar");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar",
				days.Select(d => d.Id).Distinct().Select(d => (object)d).ToArray()));
			List<WorkingTimeInterval> timeIntervals =
				esq.GetEntityCollection(UserConnection).Select(d => (WorkingTimeInterval)d).ToList();

			TimeSpan workingTimeSpan = TimeSpan.Zero;
			foreach (DayInCalendar day in days) {
				List<WorkingTimeInterval> dayTimeIntervals = timeIntervals.Where(t => t.DayInCalendarId == day.Id).
					ToList();
				foreach (WorkingTimeInterval interval in dayTimeIntervals) {
					if (Equals(day, fromDay) && interval.From.TimeOfDay < fromDateTime.TimeOfDay) {
						interval.From = fromDateTime;
					}
					if (Equals(day, toDay) && interval.To.TimeOfDay > toDateTime.TimeOfDay) {
						interval.To = toDateTime;
					}
					if (interval.From.TimeOfDay < interval.To.TimeOfDay) {
						workingTimeSpan = workingTimeSpan.Add(interval.To.TimeOfDay - interval.From.TimeOfDay);
					}
				}
			}

			return isNegative ? -workingTimeSpan : workingTimeSpan;
		}

		public DateTime AddWorkingDays(DateTime registrationDateTime, int daysCount) {
			if (daysCount < 0) {
				return RemoveWorkingDays(registrationDateTime, Math.Abs(daysCount));
			}
			var registrationDay = Utils.GetCalendarDay(CalendarIdsChain, registrationDateTime, null);
			var firstDateInDay = GetFirstDateTimeInDay(registrationDateTime);
			var lastDateInDay = GetLastDateTimeInDay(registrationDateTime);
			var lessFirstDate = registrationDateTime <= firstDateInDay;
			var moreLastDate = registrationDateTime >= lastDateInDay;
			DateTime fromDay = registrationDateTime.Date.AddDays(daysCount == 0 ? 0 : 1);
			DateTime toDay = registrationDateTime.Date.AddDays(daysCount);

			List<DayInCalendar> days = Utils.GetCalendarDays(CalendarIdsChain, fromDay, toDay).ToList();
			int weekendDaysCount = days.Count(d => d.GetTypedColumnValue<bool>("DayType_IsWeekend"));
			while (weekendDaysCount != 0) {
				fromDay = toDay.AddDays(1);
				toDay = toDay.AddDays(weekendDaysCount);
				days = Utils.GetCalendarDays(CalendarIdsChain, fromDay, toDay).ToList();
				weekendDaysCount = days.Count(d => d.GetTypedColumnValue<bool>("DayType_IsWeekend"));
			}
			DateTime maxDate = days.Max(d => d.Date);
			DayInCalendar maxDay = days.Single(d => d.Date == maxDate);
			DayInCalendar almostMaxDay = GetNearestNotWeekendDay(maxDay.Date.AddDays(-1), false).Value;
			maxDay.Date = lessFirstDate ?  GetLastWorkingDayDateTime(almostMaxDay): GetLastWorkingDayDateTime(maxDay);
			return maxDay.Date;
		}

		public TimeSpan GetWorkingTimeSpanByWorkingDays(DateTime fromDate, DateTime toDay) {
			bool isNegative = false;
			if (fromDate > toDay) {
				DateTime tempDateTime = fromDate;
				fromDate = toDay;
				toDay = tempDateTime;
				isNegative = true;
			}

			DateTime fromDay = fromDate.Date.AddDays(1);

			List<DayInCalendar> days = Utils.GetCalendarDays(CalendarIdsChain, fromDay, toDay).ToList();
			int workingDaysCount = days.Count(d => !d.GetTypedColumnValue<bool>("DayType_IsWeekend"));

			var workingTimeSpan = new TimeSpan(workingDaysCount, 0, 0, 0);
			return isNegative ? -workingTimeSpan : workingTimeSpan;
		}

		#endregion
	}

	#endregion
}
