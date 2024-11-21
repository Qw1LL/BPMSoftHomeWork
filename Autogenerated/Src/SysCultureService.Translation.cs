namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;

	#region Class: SysCultureService

	/// <summary>
	/// Provides web-service for work with features.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SysCultureService : BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Returns default culture uniqueidentifier.
		/// </summary>
		/// <returns>Default culture uniqueidentifier.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDefaultCulture", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid GetDefaultCulture() {
			var sysCultureUtilities = new SysCultureUtilities(UserConnection);
			return sysCultureUtilities.GetDefaultCulture();
		}

		#endregion

	}

	#endregion

}
