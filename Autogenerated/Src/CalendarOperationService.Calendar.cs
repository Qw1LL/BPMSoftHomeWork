namespace BPMSoft.Configuration.Calendars
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Runtime.Serialization;
	using BPMSoft.Web.Common;

	[Obsolete]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CalendarOperationService : BaseService
	{
	
		#region Methods: Public
	
		/// <summary>
		/// Add time unit value to date by calendar information.
		/// </summary>
		/// <param name="calendarId">Calendar identifier.</param>
		/// <param name="date">Date.</param>
		/// <param name="timeUnit">Time unit.</param>
		/// <param name="value">Value.</param>
		/// <returns>Result date.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public DateTime Add(Guid calendarId, DateTime date, TimeUnit timeUnit, int value) {
			var utility = new CalendarUtility(calendarId, UserConnection);
			return utility.Add(date, timeUnit, value);
		}
	
		/// <summary>
		/// Add time unit value to date by calendar information.
		/// </summary>
		/// <param name="calendar">Calendar.</param>
		/// <param name="date">Date.</param>
		/// <param name="timeUnit">Time unit.</param>
		/// <param name="value">Value.</param>
		/// <returns>Result date.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public DateTime Add(ICalendar<ICalendarDay> calendar, DateTime date, TimeUnit timeUnit, int value) {
			var utility = new CalendarUtility(calendar);
			return utility.Add(date, timeUnit, value);
		}
	
		/// <summary>
		/// Generate calendar days by calendar week template.
		/// </summary>
		/// <param name="calendarId">Calendar identifier.</param>
		/// <param name="dateTime">Start date</param>
		/// <returns>Calendar days.</returns>
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public CalendarDaysServiceResponse GenerateWeek(Guid calendarId, DateTime dateTime)
		{
	
			var response = new CalendarDaysServiceResponse();
			try {
				var utility = new CalendarUtility(calendarId, UserConnection);
				response.Days = utility.GenerateWeek(dateTime);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
			
		}
	
		/// <summary>
		/// Generate calendar days by calendar week template.
		/// </summary>
		/// <param name="calendar">Calendar.</param>
		/// <param name="dateTime">Start date</param>
		/// <returns>Calendar days.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public CalendarDaysServiceResponse GenerateWeek(ICalendar<ICalendarDay> calendar, DateTime dateTime) {
			var response = new CalendarDaysServiceResponse();
			try {
				var utility = new CalendarUtility(calendar);
				utility.GenerateWeek(dateTime);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}
	
		#endregion
	
		#region Class: Public
	
		[DataContract]
		public class CalendarDaysServiceResponse : ConfigurationServiceResponse
		{
			#region Properties: Public
	
			/// <summary>
			/// Calendar days.
			/// </summary>
			[DataMember(Name = "Days")]
			public IList<ICalendarDay> Days { get; set; }
	
			#endregion
		}
	
		#endregion
	}
}
