namespace BPMSoft.Configuration
{
	using global::Common.Logging;
	using IntegrationApi.Calendar.DTO;
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using static BPMSoft.EmailDomain.IntegrationConsts.Calendar;

	#region Class: MeetingService

	/// <summary>
	/// Service for working with calendar meetings.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MeetingService : BaseService
	{

		#region Properties: Private

		/// <summary>
		/// Current user contact identifier.
		/// </summary>
		private Guid CurrentUserContactId {
			get {
				return UserConnection.CurrentUser.ContactId;
			}
		}

		/// <summary>
		/// Current user contact name.
		/// </summary>
		private string CurrentUserContactName {
			get {
				return UserConnection.CurrentUser.ContactName;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Send invitations for <see cref="Activity"/> identifier.
		/// </summary>
		/// <param name="meetingId"><see cref="Activity"/> identifier.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse SendInvitations(Guid meetingId) {
			var response = new BaseResponse {
				Success = true
			};
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				meetingService.SendInvitations(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				response.Success = false;
				response.ErrorInfo = new ErrorInfo() {
					Message = e.Message,
					StackTrace = e.StackTrace
				};
				var logger = LogManager.GetLogger("Calendar");
				logger.Error("Failed to send invitations.", e);
			}
			return response;
		}

		/// <summary>
		/// Get meeting invitation info for <see cref="Activity"/> identifier.
		/// </summary>
		/// <param name="meetingId"><see cref="Activity"/> identifier.</param>
		/// <returns><see cref="MeetingInvitationInfo"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public MeetingInvitationInfo GetMeetingInvitationInfo(Guid meetingId) {
			MeetingInvitationInfo response;
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				response = meetingService.GetMeetingInvitationInfo(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error("Failed to GetMeetingIntegrationInfo.", e);
				throw;
			}
			return response;
		}

		/// <summary>
		/// Check if the appointment is available for editing under the user.
		/// </summary>
		/// <param name="meetingId">Meeting unique identifier.</param>
		/// <returns><see cref="ChangeMeetingResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public ChangeMeetingResponse CanUserChangeMeeting(Guid meetingId) {
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				return meetingService.CanUserChangeMeeting(meetingId, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while checking for meeting changes by the current user '{CurrentUserContactName}'.", e);
			}
			return ChangeMeetingResponse.No;
		}

		/// <summary>
		/// Check if the appointment is available for editing under the user.
		/// </summary>
		/// <param name="senderEmailAddress">Sender Email address.</param>
		/// <returns><see cref="ChangeMeetingResponse"/>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
			ResponseFormat = WebMessageFormat.Json)]
		public bool CanUserChangeCalendar(string senderEmailAddress) {
			try {
				var meetingService = ClassFactory.Get<IMeetingService>(new ConstructorArgument("uc", UserConnection));
				return meetingService.CanUserChangeCalendar(senderEmailAddress, CurrentUserContactId);
			} catch (Exception e) {
				var logger = LogManager.GetLogger("Calendar");
				logger.Error($"Error while checking for calendar changes by the current user '{CurrentUserContactName}'.", e);
			}
			return true;
		}

		#endregion

	}

	#endregion
}

