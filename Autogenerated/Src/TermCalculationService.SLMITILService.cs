using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using BPMSoft.Core;
using BPMSoft.Core.Factories;
using BPMSoft.Configuration;
using BPMSoft.Web.Common;

namespace BPMSoft.Configuration.TermCalculationService
{
	#region Class: TermCalculationService
	/// <summary>
	/// ##### ####### ## ######## ######## ### # ######## #######
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TermCalculationService: BaseService
	{
		#region Methods: Public
		/// <summary>
		/// Counts reaction time and a solution time to "ServiceItem", "ServicePact", "Priority"..
		/// </summary>
		/// <param name="request">Request for scheduled deadlines.</param>
		/// <returns>An object that contains the reaction time and solution time.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ServiceTermResponse GetServiceTerm(ServiceTermRequest request) {
			var userConnection = UserConnection;
			var termCalculator = ClassFactory.Get<TermCalculatorITILService>(
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("servicePactId", request.ServicePactId),
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
			var userConnection = UserConnection;
			var calendarRemindCalculator = BPMSoft.Configuration.CalendarRemindCalculatorITILService.CreateInstanceITILService(userConnection, request.CaseId);
			if(calendarRemindCalculator != null) {
				DateTime sourceDateTime = DateTime.Parse(request.SourceDateTime);
				sourceDateTime = TimeZoneInfo.ConvertTime(sourceDateTime, userConnection.CurrentUser.TimeZone, 
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
			var userConnection = UserConnection;
			var dateAfterPause = userConnection.CurrentUser.GetCurrentDateTime();
			var calendarRemindCalculator = BPMSoft.Configuration.CalendarRemindCalculatorITILService.CreateInstanceITILService(userConnection, request.CaseId);
			if(calendarRemindCalculator != null) {
				dateAfterPause = calendarRemindCalculator.GetSolutionDateAfterPause(request.RemainsTicks, request.IsResolution);
			}
			return dateAfterPause;
		}
		#endregion
	}
	#endregion
	
	#region Class: ServiceTermRequest
	//// <summary>
	/// Class Request scheduled dates.
	/// </summary>
	public partial class ServiceTermRequest
	{
		#region Properties: Public
		
		/// <summary>
		/// Service pact.
		/// </summary>
		[DataMember]
		public Guid ServicePactId { 
			get;
			set;
		}
		
		#endregion
	}
	#endregion
	
}

