namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CtiRightsService: BaseService, IReadOnlySessionState
	{

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetUserHasOperationLicense(List<string> operations, bool isAnyOperation) {
			var response = true;
			foreach (var operation in operations) {
				bool checkLicInfo = UserConnection.LicHelper.GetHasOperationLicense(operation);
				if (!checkLicInfo && !isAnyOperation) {
					response = false;
					break;
				} 
				if (checkLicInfo && isAnyOperation) {
					response = true;
					break;
				}
			}
			return response;
		}

	}

}

