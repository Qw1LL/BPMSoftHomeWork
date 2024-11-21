namespace BPMSoft.Configuration.Tracking
{
	using BPMSoft.Core;
	using CoreConfig = Core.Configuration;

	#region Class: TrackingDataProvider

	/// <summary>
	/// Provide information from tenant service.
	/// </summary>
	public class TenantServiceDataProvider : TrackingDataProvider
	{

		#region Properties: Private

		/// <summary>
		/// System settings name for base tenant service url.
		/// </summary>
		private string TenantAddressSettingsName => "TrackingTenantUrl";

		#endregion

		#region Properties: Protected

		private string _tenantUrl;
		/// <summary>
		/// Tenant service url value.
		/// </summary>
		protected string TenantUrl {
			get {
				if (string.IsNullOrEmpty(_tenantUrl)) {
					_tenantUrl = CoreConfig.SysSettings.GetValue(UserConnection, TenantAddressSettingsName).ToString();
					return _tenantUrl;
				} else {
					return _tenantUrl;
				}
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public TenantServiceDataProvider(UserConnection userConnection) : base(userConnection) { }

		#endregion

	}

	#endregion

}

