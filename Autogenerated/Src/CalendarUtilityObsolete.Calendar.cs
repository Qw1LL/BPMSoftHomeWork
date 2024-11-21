namespace BPMSoft.Configuration.Calendars
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using CalendarTimeUnit = BPMSoft.Configuration.Calendars.TimeUnit;

	#region Class : CalendarUtility

	/// <summary>
	/// A class that provides calendar time calculation utilities.
	/// </summary>
	public partial class CalendarUtility
	{

		#region Fields

		[Obsolete]
		private readonly ICalendarOperationProvider _provider;
		[Obsolete]
		private readonly ICalendar<ICalendarDay> _calendar;

		#endregion

		#region Constructors : Public

		/// <summary>
		/// Create a calendar utility.
		/// </summary>
		/// <param name="calendarId">Calendar identifier.</param>
		/// <param name="userConnection">User connection.</param>
		[Obsolete]
		public CalendarUtility(Guid calendarId, UserConnection userConnection) {
			var store = new CalendarDataStore<ICalendar<ICalendarDay>>(userConnection);
			_calendar = new Calendar(calendarId);
			store.Load(ref _calendar);
			_provider = new CalendarOperationProvider(_calendar);
		}

		/// <summary>
		/// Create a calendar utility.
		/// </summary>
		/// <param name="calendar">Calendar.</param>
		[Obsolete]
		public CalendarUtility(ICalendar<ICalendarDay> calendar) {
			_calendar = calendar;
			_provider = new CalendarOperationProvider(calendar);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Add time unit value to date by calendar information.
		/// </summary>
		/// <param name="date">CalendarDate.</param>
		/// <param name="timeUnit">Time unit.</param>
		/// <param name="value">Value.</param>
		/// <returns>Result date.</returns>
		[Obsolete]
		public DateTime Add(DateTime date, CalendarTimeUnit timeUnit, int value) {
			return _provider.Add(date, timeUnit, value);
		}

		/// <summary>
		/// Add time unit value to date by calendar information and time zone information.
		/// </summary>
		/// <param name="date">CalendarDate.</param>
		/// <param name="timeUnit">Time unit.</param>
		/// <param name="value">Value.</param>
		/// <param name="timeZone">Time zone.</param>
		/// <returns>Result date.</returns>
		[Obsolete]
		public DateTime Add(DateTime date, CalendarTimeUnit timeUnit, int value, TimeZoneInfo timeZone) {
			var dateInCalendarTimeZone = TimeZoneInfo.ConvertTime(date, timeZone, _calendar.TimeZone);
			var result = _provider.Add(dateInCalendarTimeZone, timeUnit, value);
			return TimeZoneInfo.ConvertTime(result, _calendar.TimeZone, timeZone);
		}

		/// <summary>
		/// Generate calendar days by calendar week template.
		/// </summary>
		/// <param name="dateTime">Start date</param>
		/// <returns>Calendar days.</returns>
		[Obsolete]
		public IList<ICalendarDay> GenerateWeek(DateTime dateTime) {
			return _provider.GenerateWeeks(dateTime, 1);
		}

		#endregion

	}

	#endregion

}
