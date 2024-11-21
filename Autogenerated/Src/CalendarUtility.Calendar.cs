namespace BPMSoft.Configuration.Calendars
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Store;
	using CalendarTimeUnit = BPMSoft.Configuration.Calendars.TimeUnit;

	#region Class : CalendarUtility

	/// <summary>
	/// A class that provides calendar time calculation utilities.
	/// </summary>
	public partial class CalendarUtility
	{
		private readonly UserConnection _userConnection;

		#region Fields: Private

		private readonly ICalendarDataStore<ICalendar<ICalendarDay>> _store;
		private readonly Dictionary<Guid, ICalendar<ICalendarDay>> _calendarsCache =
			new Dictionary<Guid, ICalendar<ICalendarDay>>();
		private readonly TermCalculationLogStore _calculationLogStore;

		#endregion

		#region Methods : Protected

		/// <summary>
		/// Gets a calendar from the store by its id and caches it into a private dictionary at the instance level.
		/// </summary>
		/// <param name="calendarId">The calendar identifier.</param>
		/// <returns>Calendar.</returns>
		protected virtual ICalendar<ICalendarDay> GetLoadedCalendar(Guid calendarId) {
			if (_calendarsCache.ContainsKey(calendarId)) {
				return _calendarsCache[calendarId];
			}
			ICalendar<ICalendarDay> calendar = new Calendar(calendarId);
			_store.Load(ref calendar);
			_calendarsCache.Add(calendarId, calendar);
			return calendar;
		}

		/// <summary>
		/// Gets calendar operation provider.
		/// </summary>
		/// <param name="calendar">The calendar.</param>
		/// <param name="timeUnit">The time unit.</param>
		/// <returns>Calendar operation provider.</returns>
		protected ICalendarOperationProvider GetProvider(ICalendar<ICalendarDay> calendar, CalendarTimeUnit timeUnit) {
			if (_calculationLogStore != null) {
				return new CalendarOperationProvider(calendar, timeUnit, _calculationLogStore);
			}
			return new CalendarOperationProvider(calendar, timeUnit);
		}

		#endregion

		#region Constructors : Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CalendarUtility"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public CalendarUtility(UserConnection userConnection) {
			_userConnection = userConnection;
			_store = new CalendarDataStore<ICalendar<ICalendarDay>>(userConnection);
			_calculationLogStore = TermCalculationLogStoreInitializer.GetStore(userConnection);
		}

        public CalendarUtility(UserConnection userConnection, TermCalculationLogStore logStore)
        {
            _userConnection = userConnection;
            _store = new CalendarDataStore<ICalendar<ICalendarDay>>(userConnection);
            _calculationLogStore = logStore ?? TermCalculationLogStoreInitializer.GetStore(userConnection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarUtility"/> class.
        /// </summary>
        /// <param name="store">The store.</param>
        public CalendarUtility(ICalendarDataStore<ICalendar<ICalendarDay>> store) {
			_store = store;
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Adds a value of time units to specified dateTime.
		/// </summary>
		/// <param name="startDate">Calculation pivot.</param>
		/// <param name="term">Calculation term.</param>
		/// <param name="userTimeZone">Current time zone.</param>
		/// <returns>
		/// Calendar time.
		/// </returns>
		public DateTime Add(DateTime startDate, TimeTerm term, TimeZoneInfo userTimeZone) {
			var calendar = GetLoadedCalendar(term.CalendarId);
			var convertedStartDate = TimeZoneInfo.ConvertTime(startDate, userTimeZone, calendar.TimeZone);
			var provider = GetProvider(calendar, term.Type);
			if (_calculationLogStore != null) {
				_calculationLogStore.UserTimeZoneInfo = userTimeZone;
				_calculationLogStore.CalendarTimeZoneInfo = calendar.TimeZone;
				_calculationLogStore.IsUsedIntervalCalculated = true;
				new TermCalculationLogger(_calculationLogStore).FillUsedTimeIntervals(provider, term, new TermCalculationCalendarDataLoader(_userConnection));
			}
			DateTime result = provider.Add(convertedStartDate, term.Value);
			return TimeZoneInfo.ConvertTime(result, calendar.TimeZone, userTimeZone);
		}

		/// <summary>
		/// Adds a value of time units to specified dateTime considering already worked time.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="term">The term.</param>
		/// <param name="periods">The working intervals.</param>
		/// <param name="userTimeZone">Current time zone.</param>
		/// <returns>
		/// Calendar time considering already worked time.
		/// </returns>
		public DateTime Add(DateTime startDate, TimeTerm term, IEnumerable<DateTimeInterval> periods,
			TimeZoneInfo userTimeZone) {
			var calendar = GetLoadedCalendar(term.CalendarId);
			var convertedPeriods = periods.Select(period => new DateTimeInterval {
				Start = TimeZoneInfo.ConvertTime(period.Start, userTimeZone, calendar.TimeZone),
				End = TimeZoneInfo.ConvertTime(period.End, userTimeZone, calendar.TimeZone)
			});
			var provider = GetProvider(calendar, term.Type);
			if (_calculationLogStore != null) {
				_calculationLogStore.UserTimeZoneInfo = userTimeZone;
				_calculationLogStore.CalendarTimeZoneInfo = calendar.TimeZone;
				new TermCalculationLogger(_calculationLogStore).FillUsedTimeIntervals(provider, term, new TermCalculationCalendarDataLoader(_userConnection));
			}
			int alreadyWorked = provider.GetTimeUnits(convertedPeriods);
			term.Value -= alreadyWorked;
			return Add(startDate, term, userTimeZone);
		}
		
		/// <summary>
		/// Returns a value of time units in supplied period
		/// </summary>
		/// <param name="term">The term.</param>
		/// <param name="period">The working interval.</param>
		/// <param name="userTimeZone">Current time zone.</param>
		/// <returns>
		/// Amount of time units in supplied period
		/// </returns>
		public int GetTimeUnitsInPeriod(TimeTerm term, DateTimeInterval period, TimeZoneInfo userTimeZone)
		{
			return GetTimeUnitsInPeriods(term, new[] {period}, userTimeZone);
		}
		
		/// <summary>
		/// Returns a value of time units in supplied periods
		/// </summary>
		/// <param name="term">The term.</param>
		/// <param name="periods">The working intervals.</param>
		/// <param name="userTimeZone">Current time zone.</param>
		/// <returns>
		/// Sum of time units in supplied periods
		/// </returns>
		public int GetTimeUnitsInPeriods(TimeTerm term, IEnumerable<DateTimeInterval> periods, TimeZoneInfo userTimeZone)
		{
			var calendar = GetLoadedCalendar(term.CalendarId);
			var provider = GetProvider(calendar, term.Type);
			var convertedPeriods = periods.Select(period => new DateTimeInterval {
				Start = TimeZoneInfo.ConvertTime(period.Start, userTimeZone, calendar.TimeZone),
				End = TimeZoneInfo.ConvertTime(period.End, userTimeZone, calendar.TimeZone)
			});
			return provider.GetTimeUnits(convertedPeriods);
		}

		#endregion

	}

	#endregion

}

