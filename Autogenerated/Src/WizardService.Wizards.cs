namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;

	#region Class: WizardService

	/// <summary>
	/// Utility service class for working with Wizard.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WizardService : BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Clear configuration script from cash.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ClearConfigurationScript() {
			ConfigurationSectionHelper.ClearCache(UserConnection);
		}

		#endregion
	}

	#endregion

}

