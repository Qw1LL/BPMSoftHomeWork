namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	/// <summary>
	/// Case time zone service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CaseTimezoneService : BaseService
	{
		/// <summary>
		/// Get contact time zone
		/// </summary>
		/// <param name="contactId"></param>
		/// <returns>contact time zone</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetContactTimezone(string contactId) {
			return CaseTimezoneHelper.GetContactTimezone(UserConnection, contactId);
		}
	}
}
