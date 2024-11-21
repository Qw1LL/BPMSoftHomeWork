namespace BPMSoft.Configuration.Tracking
{
	using System;
	using BPMSoft.Core;

	#region Class: TenantInfoResponse

	/// <summary>
	/// Descibes response from <see cref="TenantDataProvider.GetTenantInfo()"/>.
	/// </summary>
	public class TenantInfoResponse : DataProviderResponse
	{

		#region Properties: Public

		/// <summary>
		///  Gets or sets identity service client id.
		/// </summary>
		public string IdentityClientId { get; set; }

		/// <summary>
		///  Gets or sets tracking service tenant id.
		/// </summary>
		public Guid TenentId { get; set; }

		#endregion

	}

	#endregion

	#region Class: TenantDataProvider

	/// <summary>
	/// Provide information from tenant service.
	/// </summary>
	public class TenantDataProvider : TenantServiceDataProvider
	{

		#region Fields: Private

		private readonly string _pathPingService = "/api/Tenant/ping";

		private readonly string _pathInfoService = "/api/Tenant/info";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public TenantDataProvider(UserConnection userConnection)
				: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Pings tenant service.
		/// </summary>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse PingTenant() {
			var pingUrl = TenantUrl + _pathPingService;
			return SendTokenizedGetRequest<DataProviderResponse>(pingUrl);
		}

		/// <summary>
		/// Executes request to '/api/Tenant/info' tracking service web API.
		/// </summary>
		/// <returns>Instance of <see cref="TenantInfoResponse"/>.</returns>
		public TenantInfoResponse GetTenantInfo() {
			var url = TenantUrl + _pathInfoService;
			return SendTokenizedGetRequest<TenantInfoResponse>(url);
		}

		#endregion

	}

	#endregion

}
