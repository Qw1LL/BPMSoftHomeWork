namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Interface: IContactTimezone

	public interface IContactTimezone
	{
		/// <summary>
		/// Returns contact GMT timezone.
		/// </summary>
		/// <param name="contactId">Contact id.</param>
		/// <returns>Contact GMT timezone.</returns>
		ContactTimezoneInfo GetTimezone(Guid contactId);
	}

	#endregion

	#region Class: ContactTimezoneInfo

	[Serializable]
	[DataContract]
	public class ContactTimezoneInfo
	{

		#region Properties: Public

		[DataMember(Name = "timezoneCode")]
		public string TimezoneCode { get; set; }

		[DataMember(Name = "location")]
		public string Location { get; set; }

		#endregion

	}

	#endregion

	#region Class: AdjustmentRule

	[Serializable]
	[DataContract]
	public class AdjustmentRule
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public AdjustmentRule(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "timezoneOffsetInMinutes")]
		public int TimeZoneOffsetInMinutes { get; set; }

		[DataMember(Name = "daylightDeltaInMinutes")]
		public int DaylightDeltaInMinutes { get; set; }

		[DataMember(Name = "transitionStart")]
		public DateTime TransitionStart { get; set; }

		[DataMember(Name = "transitionEnd")]
		public DateTime TransitionEnd { get; set; }

		#endregion

		#region Methods: Public

		public override string ToString() {
			return JsonConvert.SerializeObject(this, Formatting.None, new IsoDateTimeConverter());
		}

		#endregion

	}

	#endregion

	#region Class: TimezoneHelper

	public class TimezoneHelper
	{

		#region Class: CurrentTimeInfo

		[Serializable]
		[DataContract]
		private class CurrentTimeInfo
		{

			[DataMember(Name = "time")]
			public string Time { get; set; }

			[DataMember(Name = "timeZone")]
			public string TimeZone { get; set; }

			[DataMember(Name = "minutesOffset")]
			public int MinutesOffset { get; set; }

			[DataMember(Name = "location")]
			public string Location { get; set; }

			public override string ToString() {
				return JsonConvert.SerializeObject(this);
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance</param>
		public TimezoneHelper(UserConnection userConnection, IContactTimezone contactTimezone) {
			UserConnection = userConnection;
			ContactTimezone = contactTimezone;
		}

		#endregion

		#region Properties: Protected

		private UserConnection _userConnection;
		protected UserConnection UserConnection {
			set {
				if (value == null) {
					throw new ArgumentNullException("userConnection");
				}
				_userConnection = value;
			}
			get {
				return _userConnection;
			}
		}

		private IContactTimezone _contactTimezone;
		protected IContactTimezone ContactTimezone {
			set {
				if (value == null) {
					throw new ArgumentNullException("contactTimezone");
				}
				_contactTimezone = value;
			}
			get {
				return _contactTimezone;
			}
		}

		#endregion

		#region Methods: Private

		private string GetTimezoneName(string code) {
			string name = String.Empty;
			EntitySchemaQuery timezoneNameQuery = GetTimezoneNameQuery(code);
			EntityCollection timezoneEntityCollection = timezoneNameQuery.GetEntityCollection(UserConnection);
			if (timezoneEntityCollection.Count > 0) {
				name = timezoneEntityCollection[0].GetColumnValue("Name").ToString();
			}
			return name;
		}

		private EntitySchemaQuery GetTimezoneNameQuery(string code) {
			var timezoneNameQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TimeZone");
			timezoneNameQuery.AddColumn("Name");
			timezoneNameQuery.Filters.Add(timezoneNameQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Code",
				code));
			return timezoneNameQuery;
		}

		private CurrentTimeInfo GetCurrentTimeInfo(string timeZoneCode) {
			if (String.IsNullOrEmpty(timeZoneCode)) {
				return null;
			}
			TimeZoneInfo timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(timeZoneCode);
			DateTime currentTimeByTimeZoneTime = GetDateTimeWithTimezoneOffset(timeZoneInfo.Id);
			TimeSpan minutesOffset = GetMinutesOffsetTimeZone(timeZoneInfo, currentTimeByTimeZoneTime);
			var currentTimeInfo = new CurrentTimeInfo() {
				Time = currentTimeByTimeZoneTime.ToString("yyyy'-'MM'-'dd HH':'mm':'ss"),
				TimeZone = GetTimezoneName(timeZoneCode),
				MinutesOffset = (int)minutesOffset.TotalMinutes
			};
			return currentTimeInfo;
		}

		private TimeSpan GetMinutesOffsetTimeZone(TimeZoneInfo timeZoneInfo, DateTime currentTimeByTimeZoneTime) {
			AdjustmentRule adjustmentRule = GetTimeZoneAdjustmentRule(timeZoneInfo);
			TimeSpan minutesOffset = timeZoneInfo.BaseUtcOffset;
			if (adjustmentRule.TransitionStart < currentTimeByTimeZoneTime
					&& adjustmentRule.TransitionEnd > currentTimeByTimeZoneTime) {
				TimeSpan daylightDelta = new TimeSpan(0, adjustmentRule.DaylightDeltaInMinutes, 0);
				minutesOffset = minutesOffset.Add(daylightDelta);
			}
			return minutesOffset;
		}

		private DateTime GetDateTimeWithTimezoneOffset(string timezone) {
			return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, timezone);
		}

		private AdjustmentRule GetTimeZoneAdjustmentRule(TimeZoneInfo timezone) {
			var adjustmentRule = new AdjustmentRule(UserConnection) {
				TimeZoneOffsetInMinutes = (int)timezone.BaseUtcOffset.TotalMinutes
			};
			if (timezone.SupportsDaylightSavingTime) {
				TimeZoneInfo.AdjustmentRule currentRule = GetCurrentAdjustmentRules(timezone);
				if (currentRule != null) {
					TimeSpan daylightDelta = GetDaylightDelta(currentRule);
					adjustmentRule.DaylightDeltaInMinutes = (int)daylightDelta.TotalMinutes;
					DateTime transitionStart = GetTransitionDateTime(currentRule.DaylightTransitionStart);
					DateTime transitionEnd = GetTransitionDateTime(currentRule.DaylightTransitionEnd);
					adjustmentRule.TransitionStart = transitionStart.AddMinutes(adjustmentRule.TimeZoneOffsetInMinutes * -1);
					adjustmentRule.TransitionEnd = transitionEnd.AddMinutes(adjustmentRule.TimeZoneOffsetInMinutes * -1);
				}
			}
			return adjustmentRule;
		}

		private DateTime GetTransitionDateTime(TimeZoneInfo.TransitionTime transitionTime) {
			DateTime currentDateTime = GetCurrentDateTime();
			int year = currentDateTime.Year;
			if (transitionTime.IsFixedDateRule) {
				return new DateTime(
					year,
					transitionTime.Month,
					transitionTime.Day,
					transitionTime.TimeOfDay.Hour,
					transitionTime.TimeOfDay.Minute,
					transitionTime.TimeOfDay.Second,
					DateTimeKind.Utc);
			}
			return GetDateTimeNotFixedDateRule(transitionTime, year);
		}

		private DateTime GetCurrentDateTime() {
			return _userConnection.CurrentUser.GetCurrentDateTime();
		}

		private DateTime GetDateTimeNotFixedDateRule(TimeZoneInfo.TransitionTime transitionTime, int year) {
			System.Globalization.Calendar calendar = _userConnection.CurrentUser.Culture.Calendar;
			DateTime firstDateOfMonth = new DateTime(year, transitionTime.Month, 1);
			int firstDayOfMounth = (int)calendar.GetDayOfWeek(firstDateOfMonth);
			int startDayOfWeek = (transitionTime.Week * 7) - 6;
			int transitionDayOfWeek = (int)transitionTime.DayOfWeek;
			int transitionDay;
			if (firstDayOfMounth <= transitionDayOfWeek) {
				transitionDay = startDayOfWeek + (transitionDayOfWeek - firstDayOfMounth);
			} else {
				transitionDay = startDayOfWeek + (7 - firstDayOfMounth + transitionDayOfWeek);
			}
			if (transitionDay > calendar.GetDaysInMonth(year, transitionTime.Month))
				transitionDay -= 7;
			return new DateTime(
					year,
					transitionTime.Month,
					transitionDay,
					transitionTime.TimeOfDay.Hour,
					transitionTime.TimeOfDay.Minute,
					transitionTime.TimeOfDay.Second,
					DateTimeKind.Utc);
		}

		private TimeZoneInfo.AdjustmentRule GetCurrentAdjustmentRules(TimeZoneInfo timezone) {
			TimeZoneInfo.AdjustmentRule[] rules = timezone.GetAdjustmentRules();
			TimeZoneInfo.AdjustmentRule rule = rules.Last();
			DateTime currentDateTime = GetCurrentDateTime();
			return (rule.DateEnd > currentDateTime) ? rule : null;
		}

		private TimeSpan GetDaylightDelta(TimeZoneInfo.AdjustmentRule timezone) {
			return timezone.DaylightDelta;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns contact current time information.
		/// </summary>
		/// <param name="contactId">Contact id</param>
		/// <returns>Contact current time information</returns>
		public string GetContactCurrentTime(Guid contactId) {
			string result = string.Empty;
			ContactTimezoneInfo info = ContactTimezone.GetTimezone(contactId);
			if (info == null) {
				return result;
			}
			CurrentTimeInfo currentTimeInfo = GetCurrentTimeInfo(info.TimezoneCode);
			if (currentTimeInfo == null) {
				return result;
			}
			currentTimeInfo.Location = info.Location;
			return currentTimeInfo.ToString();
		}

		/// <summary>
		/// Returns adjustment rule of the time zone.
		/// </summary>
		/// <param name="timezoneCode">Code of the time zone.</param>
		/// <returns>Adjustment rule of the time zone.</returns>
		public string GetAdjustmentRule(string timezoneCode) {
			if (string.IsNullOrEmpty(timezoneCode)) {
				throw new ArgumentNullOrEmptyException("TimezoneCode");
			}
			TimeZoneInfo timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(timezoneCode);
			var adjustmentRule = GetTimeZoneAdjustmentRule(timeZoneInfo);
			return adjustmentRule.ToString();
		}

		#endregion

	}

	#endregion

}


