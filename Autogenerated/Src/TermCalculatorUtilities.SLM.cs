using System;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: TimeZoneConvertor

	internal class TimeZoneConvertor
	{
		#region Constructors: Public

		public TimeZoneConvertor(TimeZoneInfo calendarTimeZone, TimeZoneInfo userTimeZone) {
			CalendarTimeZone = calendarTimeZone;
			UserTimeZone = userTimeZone;
		}

		#endregion

		#region Properties: Public

		public TimeZoneInfo CalendarTimeZone { 
			get; 
			set; 
		}

		public TimeZoneInfo UserTimeZone { 
			get; 
			set; 
		}

		#endregion

		#region Methods: Public

		public DateTime ToUserDateTime(DateTime calendarDateTime) {
			return TimeZoneInfo.ConvertTime(calendarDateTime, 
				calendarDateTime.Kind == DateTimeKind.Local ? System.TimeZoneInfo.Local : CalendarTimeZone,
				UserTimeZone);
		}

		public DateTime ToCalendarDateTime(DateTime userDateTime) {
			return TimeZoneInfo.ConvertTime(userDateTime, 
				userDateTime.Kind == DateTimeKind.Local ? System.TimeZoneInfo.Local : UserTimeZone,
				CalendarTimeZone);
		}

		#endregion
	}
	
	#endregion
	
	#region Class: ResponseTime

	public class ResponseTime
	{
		#region Properties: Public

		public int Value { 
			get;
			set;
		}

		public Guid TimeUnitId { 
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public TimeSpan GetTimeSpan(UserConnection userConnection) {
			var returnedTimeSpan = TimeSpan.Zero;
			if (TimeUnitId == TermCalculationConstants.CalendarDayTimeUnitId) {
				returnedTimeSpan = new TimeSpan(Value, 0, 0, 0);
			}
			if (TimeUnitId == TermCalculationConstants.WorkingDayTimeUnitId) {
				var hoursPerDay = (int)Core.Configuration.SysSettings.GetValue(userConnection, 
					"WorkingHoursPerDayAmount");
				returnedTimeSpan = new TimeSpan(hoursPerDay * Value, 0, 0);
			}
			if (TimeUnitId == TermCalculationConstants.CalendarHourTimeUnitId ||
					TimeUnitId == TermCalculationConstants.WorkingHourTimeUnitId) {
				returnedTimeSpan = new TimeSpan(Value, 0, 0);
			}
			if(TimeUnitId == TermCalculationConstants.CalendarMinuteTimeUnitId || 
				TimeUnitId == TermCalculationConstants.WorkingMinuteTimeUnitId) {
				returnedTimeSpan = new TimeSpan(0, Value, 0);
			}
			return returnedTimeSpan;
		}

		#endregion
	}

	#endregion
	
	#region Class: TimeCalculationExtenssions

	public static class TimeCalculationExtenssions
	{
		#region Methods: Public

		public static ResponseTime GetResponseTime(this Entity entity, ResponseTimeColumnsConfig columnsConfig) {
			return new ResponseTime {
				Value = entity.GetTypedColumnValue<int>(columnsConfig.ValueColumnName),
				TimeUnitId = entity.GetTypedColumnValue<Guid>(columnsConfig.TimeUnitColumnName)
			};
		}

		#endregion
	}

	#endregion

	#region Class: ResponseLabelTermCalculationData

	public class ResponseLabelTermCalculationData
	{
		#region Properties: Public

		public bool IsResponseInCalendarDays { 
			get;
			set;
		}

		public bool IsResolutionInCalendarDays { 
			get;
			set;
		}

		public Guid CalendarId { 
			get;
			set;
		}

		public TimeZoneInfo CalendarTimeZone { 
			get;
			set;
		}

		public bool IsResponseInDayUnits { 
			get;
			set;
		}

		public bool IsResolutionInDayUnits { 
			get;
			set;
		}

		#endregion
	}

	#endregion
	
	#region Class: TermCalculator

	public class TermCalculator
	{

		#region Constants: Public

		public const string BaseCalendarSysSettingsCode = "BaseCalendar";

		#endregion

		#region Fields: Private

		private TermCalculatorActions _actions;

		private Calendar _calendar;

		private Guid _calendarId;

		private TimeZoneInfo _calendarTimeZone;

		private CasePriority _priority;

		private ServiceItem _serviceItem;

		#endregion

		#region Constructors: Public

		public TermCalculator(UserConnection userConnection, Guid serviceItemId, Guid priorityId) {
			UserConnection = userConnection;
			ServiceItemId = serviceItemId;
			PriorityId = priorityId;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { 
			get;
			set;
		}

		protected Guid ServiceItemId { 
			get;
			set;
		}

		protected Guid PriorityId { 
			get;
			set;
		}

		protected Guid CalendarId {
			get {
				if (_calendarId != Guid.Empty) {
					return _calendarId;
				}
				_calendarId = GetCalendarId();
				return _calendarId;
			}
		}

		protected ServiceItem ServiceItem {
			get {
				if (_serviceItem != null) {
					return _serviceItem;
				}

				if (ServiceItemId == Guid.Empty) {
					return null;
				}

				var serviceItem = new ServiceItem(UserConnection);
				if (serviceItem.FetchFromDB(ServiceItemId)) {
					_serviceItem = serviceItem;
				}
				return _serviceItem;
			}
		}

		protected CasePriority Priority {
			get {
				if (_priority != null) {
					return _priority;
				}

				if (PriorityId == Guid.Empty) {
					return null;
				}

				var priority = new CasePriority(UserConnection);
				if (priority.FetchFromDB(PriorityId)) {
					_priority = priority;
				}
				return _priority;
			}
		}

		protected Calendar Calendar {
			get {
				if (_calendar != null) {
					return _calendar;
				}

				if (CalendarId == Guid.Empty) {
					return null;
				}

				var calendar = new Calendar(UserConnection);
				if (calendar.FetchFromDB(CalendarId)) {
					_calendar = calendar;
				}
				return _calendar;
			}
		}

		protected TimeZoneInfo CalendarTimeZone {
			get {
				if (_calendarTimeZone != null) {
					return _calendarTimeZone;
				}

				if (Calendar == null) {
					return null;
				}

				var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "TimeZone");
				esq.AddColumn("Code");
				Entity typeZone = esq.GetEntity(UserConnection, Calendar.TimeZoneId);
				if (typeZone != null) {
					_calendarTimeZone = TimeZoneUtilities.GetTimeZoneInfo(
						typeZone.GetTypedColumnValue<string>("Code"));
				}

				return _calendarTimeZone;
			}
		}

		#endregion

		#region Properties: Public

		public TermCalculatorActions Actions {
			get {
				if (_actions != null) {
					return _actions;
				}
				_actions = new TermCalculatorActions(UserConnection, CalendarId);
				return _actions;
			}
		}

		#endregion

		#region Methods: Private

		private DateTime CalculateDelayByCalendarInner(DateTime registrationDateTime, TimeSpan responseTimeSpan) {
			if (!Actions.IsTimeInWorkingInterval(registrationDateTime)) {
				registrationDateTime = Actions.GetPreviousWorkingTimeIntervalEnd(registrationDateTime);
			}
			DateTime responseDateTime = registrationDateTime + responseTimeSpan;
			TimeSpan weekendTimeSpan = Actions.GetWeekendTimeSpan(responseDateTime, registrationDateTime);
			return weekendTimeSpan != TimeSpan.Zero
				? CalculateDelayByCalendarInner(responseDateTime, -weekendTimeSpan)
				: responseDateTime;
		}

		private DateTime CalculateByCalendarInner(DateTime registrationDateTime, TimeSpan responseTimeSpan) {
			bool isTimeInWorkingInterval = Actions.IsTimeInWorkingInterval(registrationDateTime);
			if (!isTimeInWorkingInterval) {
				registrationDateTime = Actions.GetNextWorkingTimeIntervalStart(registrationDateTime);
			}
			DateTime responseDateTime = registrationDateTime + responseTimeSpan;
			TimeSpan weekendTimeSpan = Actions.GetWeekendTimeSpan(registrationDateTime, responseDateTime);
			return weekendTimeSpan != TimeSpan.Zero
				? CalculateByCalendarInner(responseDateTime, weekendTimeSpan)
				: responseDateTime;
		}

		private static bool IsCalendarTimeUnit(Guid timeUnitId)
		{
			return timeUnitId == TermCalculationConstants.CalendarDayTimeUnitId ||
					timeUnitId == TermCalculationConstants.CalendarHourTimeUnitId ||
					timeUnitId == TermCalculationConstants.CalendarMinuteTimeUnitId;
		}

		private static bool IsDaysTimeUnit(Guid timeUnitId)
		{
			return timeUnitId == TermCalculationConstants.WorkingDayTimeUnitId ||
					timeUnitId == TermCalculationConstants.CalendarDayTimeUnitId;
		}

		#endregion
		
		#region Methods: Protected
		
		protected virtual Guid GetCalendarId() {
			return (Guid)Core.Configuration.SysSettings.GetValue(UserConnection, BaseCalendarSysSettingsCode);
		}
		
		protected ResponseTime GetMinResponseTimeByPriority(ResponseTime serviceResponse, 
			ResponseTimeColumnsConfig respondTimeColumnsConfig) {
			if (Priority != null) {
				ResponseTime priorityResponse = Priority.GetResponseTime(respondTimeColumnsConfig);
				return priorityResponse.GetTimeSpan(UserConnection) < serviceResponse.GetTimeSpan(UserConnection)
					? priorityResponse
					: serviceResponse;
			}
			return serviceResponse;
		}
		
		#endregion
		
		#region Methods: Public

		public virtual DateTime Calculate(DateTime registrationDateTime, 
			ResponseTimeColumnsConfig respondTimeColumnsConfig) {
			if (ServiceItem == null) {
				return registrationDateTime;
			}
			ResponseTime responseTime = GetMinResponseTime(respondTimeColumnsConfig);
			if (IsCalendarTimeUnit(responseTime.TimeUnitId)) {
				return registrationDateTime + responseTime.GetTimeSpan(UserConnection);
			}
			DateTime responseDateTime;
			if (responseTime.TimeUnitId == TermCalculationConstants.WorkingDayTimeUnitId) {
				var timeZoneConvertor = new TimeZoneConvertor(CalendarTimeZone, UserConnection.CurrentUser.TimeZone);
				DateTime calendarRegistrationDateTime = timeZoneConvertor.ToCalendarDateTime(registrationDateTime);
				responseDateTime = timeZoneConvertor.ToUserDateTime(Actions.AddWorkingDays(calendarRegistrationDateTime, 
					responseTime.Value));
				return responseDateTime;
			}
			responseDateTime = CalculateByCalendar(registrationDateTime, responseTime.GetTimeSpan(UserConnection));
			return responseDateTime;
		}

		public virtual DateTime CalculateByCalendar(DateTime registrationDateTime, TimeSpan responseTimeSpan) {
			if (Calendar == null) {
				return registrationDateTime;
			}
			var timeZoneConvertor = new TimeZoneConvertor(CalendarTimeZone, UserConnection.CurrentUser.TimeZone);
			DateTime calendarRegistrationDateTime = timeZoneConvertor.ToCalendarDateTime(registrationDateTime);
			DateTime calendarResponseDateTime = responseTimeSpan >= TimeSpan.Zero
				? CalculateByCalendarInner(calendarRegistrationDateTime, responseTimeSpan)
				: CalculateDelayByCalendarInner(calendarRegistrationDateTime, responseTimeSpan);
			return timeZoneConvertor.ToUserDateTime(calendarResponseDateTime);
		}

		public virtual ResponseTime GetMinResponseTime(ResponseTimeColumnsConfig respondTimeColumnsConfig) {
			return ServiceItem.GetResponseTime(respondTimeColumnsConfig);
		}

		public ResponseLabelTermCalculationData GetResponseLabelTermCalculationData() {
			ResponseTime minResponseTime = GetMinResponseTime(TermCalculationConstants.ReactionTimeColumnsConfig);
			ResponseTime minResolutionTime = GetMinResponseTime(TermCalculationConstants.SolutionTimeColumnsConfig);
			return new ResponseLabelTermCalculationData {
				CalendarId = GetCalendarId(),
				CalendarTimeZone = CalendarTimeZone,
				IsResolutionInCalendarDays = IsCalendarTimeUnit(minResolutionTime.TimeUnitId),
				IsResponseInCalendarDays = IsCalendarTimeUnit(minResponseTime.TimeUnitId),
				IsResolutionInDayUnits = IsDaysTimeUnit(minResolutionTime.TimeUnitId),
				IsResponseInDayUnits = IsDaysTimeUnit(minResponseTime.TimeUnitId)
			};
		}

		#endregion
	}

	#endregion
}
