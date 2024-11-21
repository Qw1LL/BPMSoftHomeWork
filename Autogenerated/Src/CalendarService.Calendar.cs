namespace BPMSoft.Configuration.Calendars
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Runtime.Serialization;
	using Web.Common;
	using Core.Factories;

	#region Class: CalendarService

	/// <summary>
	/// Provides methods that works with calendar.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.BaseService" />
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CalendarService : BaseService
	{

		#region Class: CalendarServiceResponse

		[DataContract]
		public class CalendarServiceResponse : ConfigurationServiceResponse
		{
			#region Properties: Public

			/// <summary>
			/// Gets or sets the calendar identifier.
			/// </summary>
			/// <value>
			/// The calendar identifier.
			/// </value>
			[DataMember(Name = "CalendarId")]
			public Guid? CalendarId { get; set; }

			#endregion
		}

		#endregion

		#region Constructs: Public

		public CalendarService() {
		}

		public CalendarService(ICalendarDataStore<ICalendar<ICalendarDay>> storage) {
			_calendarDataStore = storage;
		}

		#endregion

		#region Properties: Protected
		
		private ICalendarDataStore<ICalendar<ICalendarDay>> _calendarDataStore;
		protected ICalendarDataStore<ICalendar<ICalendarDay>> CalendarDataStore {
			get {
				return _calendarDataStore ??
						(_calendarDataStore =
							ClassFactory.Get<CalendarDataStore<ICalendar<ICalendarDay>>>(
								 new ConstructorArgument("userConnection", UserConnection)));
			}
		} 

		#endregion

		#region Methods: Public

		/// <summary>
		/// Clones the calendar.
		/// </summary>
		/// <param name="calendarId">The calendar identifier.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CloneCalendar", BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public CalendarServiceResponse CloneCalendar(Guid calendarId) {
			var response = new CalendarServiceResponse();
			try {
				ICalendar<ICalendarDay> calendar = new Calendar(calendarId);
				CalendarDataStore.Load(ref calendar);
				var clonedCalendar = (ICalendar<ICalendarDay>)calendar.Clone();
				if (CalendarDataStore.Save(clonedCalendar)) {
					response.CalendarId = clonedCalendar.Id;
				}
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		#endregion
	}

	#endregion
}

