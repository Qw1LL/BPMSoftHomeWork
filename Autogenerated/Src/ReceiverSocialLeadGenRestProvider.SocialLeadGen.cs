namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;
    using System.Globalization;
    using BPMSoft.Core;
	using CoreConfig = Core.Configuration;

	#region Class: ReceiverSocialLeadGenRestProvider

	/// <summary>
	/// Provide information from receiver service.
	/// </summary>
	public class ReceiverSocialLeadGenRestProvider : SocialLeadGenRestProvider
	{

		#region Properties: Private

		/// <summary>
		/// System settings name for base receiver service url.
		/// </summary>
		private readonly string _socialReceiverServiceUrlSysSettingCode = "SocialReceiverServiceUrl";

		#endregion

		#region Properties: Private

		/// <summary>
		/// Receiver service url value.
		/// </summary>
		private string SocialReceiverServiceUrl {
            get { 
				return CoreConfig.SysSettings.GetValue(UserConnection, _socialReceiverServiceUrlSysSettingCode).ToString();
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public ReceiverSocialLeadGenRestProvider(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calls API of receiver service for retrieve list of leads.
		/// </summary>
		public void PullLinkedInLeads(DateTime startDate, DateTime endDate, string[] ignoreSocialLeadIds, bool includeInactiveRanges = false, Guid ? integrationId = default, long? formId = default) {
			string url = $"{SocialReceiverServiceUrl}/api/PullRequests/linkedin";
			var data = new LinkedInPullLeadsRestRequest {
				StartDate = startDate.ToString("s", DateTimeFormatInfo.InvariantInfo),
				EndDate = endDate.ToString("s", DateTimeFormatInfo.InvariantInfo),
				IncludeInactiveRanges = includeInactiveRanges,
				IgnoreSocialLeadIds = ignoreSocialLeadIds,
				IntegrationId = (integrationId.HasValue && integrationId.Value == Guid.Empty ? null : integrationId),
				FormId = (formId.HasValue && formId == 0 ? null : formId)
			};
			SendTokenizedPostRequest<SocialLeadGenRestProviderResponse>(url, data);
		}

		#endregion

	}

	#endregion

}
