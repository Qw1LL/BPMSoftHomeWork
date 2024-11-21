namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;
	using System.Web.SessionState;

	#region Class: PingResponse

	/// <summary>
	/// Response to ping from the service.
	/// </summary>
	public class PingResponse
	{

		#region Properties: Public

		/// <summary>
		/// Status liveness probe.
		/// </summary>
		public int Status { get; set; } = 1;

		/// <summary>
		/// Error message.
		/// </summary>
		public string ErrorMessage { get; set; } = string.Empty;

		#endregion
	}

	#endregion

	#region Class: GetInfoResponse

	/// <summary>
	/// Descibe response from GetInfo web API.
	/// </summary>
	public class GetInfoResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets identity service client id.
		/// </summary>
		public string IdentityClientId { get; set; }

		/// <summary>
		/// Gets or sets tracking service tenant id.
		/// </summary>
		public Guid TenantId { get; set; }

		#endregion

	}

	#endregion

	#region Class: TrackingTenantService

	/// <summary>
	/// Class to work with tenant service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TrackingTenantService : BaseService, IReadOnlySessionState
	{

		#region Methods: Public

		/// <summary>
		/// Liveness probe tenant service.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "PingTenant", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public PingResponse PingTenant()
		{
			try {
				var tenantDataProvider = new TenantDataProvider(UserConnection);
				var dataProviderResponse = tenantDataProvider.PingTenant();
				return new PingResponse();
			} catch (Exception ex) {
				return new PingResponse {
					Status = 3,
					ErrorMessage = ex.Message
				};
			}
		}

		/// <summary>
		/// Requests tenant information from tracking service.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
				RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetInfoResponse GetInfo() {
			var tenantDataProvider = new TenantDataProvider(UserConnection);
			var response = tenantDataProvider.GetTenantInfo();
			return new GetInfoResponse() {
				IdentityClientId = response.IdentityClientId,
				TenantId = response.TenentId
			};
		}

		#endregion

	}

	#endregion

}
