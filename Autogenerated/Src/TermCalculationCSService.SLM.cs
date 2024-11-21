namespace BPMSoft.Configuration.TermCalculationService
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: TermCalculationCSService : BaseService
	/// <summary>
	/// Class of service calculation scheduled date and time balances
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TermCalculationCSService : BaseService
	{
		#region Methods: Public
		/// <summary>
		/// Counts reaction time and a solution time to "ServiceItem", "ServicePact", "Priority".
		/// </summary>
		/// <param name="request">Request for scheduled deadlines.</param>
		/// <returns>An object that contains the reaction time and solution time</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ServiceTermResponse GetServiceTerm(ServiceTermRequest request) {
			var termCalculator = ClassFactory.Get<TermCalculatorCustomerService>(
					new ConstructorArgument("UserConnection", UserConnection),
					new ConstructorArgument("serviceItemId", request.ServiceItemId),
					new ConstructorArgument("priorityId", request.PriorityId)
				);
			DateTime registrationTime = DateTime.Parse(request.RegistrationTime);
			DateTime reactionTime = termCalculator.Calculate(registrationTime, 
				TermCalculationConstants.ReactionTimeColumnsConfig);
			DateTime solutionTime = termCalculator.Calculate(registrationTime, 
				TermCalculationConstants.SolutionTimeColumnsConfig);
			return new ServiceTermResponse {
				ReactionTime = reactionTime,
				SolutionTime = solutionTime
			};
		}
		
		/// <summary>
		/// Counts the remaining time before the planned date.
		/// </summary>
		/// <param name="request">A request for the remainder of time.</param>
		/// <returns>Time remaining until the target date.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public long GetRemainsTicks(RemainsTicksRequest request) {
			var remainTicks = new long();
			var calendarRemindCalculator = BPMSoft.Configuration.CalendarRemindCalculatorCustomerService.CreateInstanceCustomerService(UserConnection, request.CaseId);
			if(calendarRemindCalculator != null) {
				DateTime sourceDateTime = DateTime.Parse(request.SourceDateTime);
				sourceDateTime = TimeZoneInfo.ConvertTime(sourceDateTime, UserConnection.CurrentUser.TimeZone, 
					System.TimeZoneInfo.Local);
				remainTicks = (long)calendarRemindCalculator.GetRemindTimeSpan(sourceDateTime, request.IsResolution).Ticks;
			}
			return remainTicks;
		}
		
		/// <summary>
		/// Counts the planned date for the remaining time of the current date.
		/// </summary>
		/// <param name="request">The request for a date after pause.</param>
		/// <returns>Planned date.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public DateTime GetDateAfterPause(RemainsTicksRequest request) {
			var dateAfterPause = UserConnection.CurrentUser.GetCurrentDateTime();
			var calendarRemindCalculator = BPMSoft.Configuration.CalendarRemindCalculatorCustomerService.CreateInstanceCustomerService(UserConnection, request.CaseId);
			if(calendarRemindCalculator != null) {
				dateAfterPause = calendarRemindCalculator.GetSolutionDateAfterPause(request.RemainsTicks, request.IsResolution);
			}
			return dateAfterPause;
		}
		#endregion
	}
	#endregion
	
}

