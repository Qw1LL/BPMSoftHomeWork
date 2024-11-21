namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using RestSharp;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.OAuthIntegration;
	using BPMSoft.OAuthIntegration.DTO;

	#region Interface: ITempAccessProxy

	/// <summary>
	/// Proxy for TempAccess service Api.
	/// </summary>
	public interface ITempAccessProxy
	{

		#region Methods: Public

		/// <summary>
		/// Grants the access.
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="expirationDate">The expiration date.</param>
		/// <param name="grantorSysAdminUnitId">The grantor system admin unit id.</param>
		/// <param name="granteeClientIds">The grantee client ids.</param>
		void GrantAccess(string resourceName, string reason, DateTime expirationDate, Guid grantorSysAdminUnitId,
			string[] granteeClientIds);

		/// <summary>
		/// Enumerate granted access list.
		/// </summary>
		/// <param name="customerIds">The customer ids (Access grantors).</param>
		/// <param name="clientId">Access grantor's client id. If set, accesses of the given client will be added to
		/// the result set.</param>
		List<(string AccessId, string Url, string Description, DateTime ExpirationDate, string CustomerId)>
			GetAccessList(string[] customerIds, string clientId = null);

		/// <summary>
		/// Request access token.
		/// </summary>
		/// <param name="accessId">Access id.</param>
		string GetAccessToken(string accessId);

		#endregion

	}

	#endregion

	#region Interface: ITempAccessDeactivator

	/// <summary>
	/// Proxy for TempAccess deactivation Api.
	/// </summary>
	public interface ITempAccessDeactivator
	{

		#region Methods: Public

		/// <summary>Deactivates the specified access ids.</summary>
		/// <param name="accessIds">The access ids.</param>
		/// <returns>Affected access count.</returns>
		int Deactivate(string[] accessIds);

		#endregion

	}

	#endregion

	#region Interface: IIdentityServiceClientFinder

	/// <summary>
	/// Proxy for Identity service client finder Api.
	/// </summary>
	public interface IIdentityServiceClientFinder
	{

		#region Methods: Public

		/// <summary>Searches clients by customer ids or client id.</summary>
		/// <param name="clientsFilter">Filter info (customerIds, clientId, etc.) to search clients.</param>
		IList<ShortIdentityClientInfo> Search(FindIdentityClientsFilter clientsFilter);

		#endregion

	}

	#endregion

	#region Class: TempAccessProxy

	/// <summary>
	/// Default proxy for TempAccess service Api.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ExternalAccessPackage.ITempAccessProxy" />
	[DefaultBinding(typeof(ITempAccessProxy))]
	[DefaultBinding(typeof(ITempAccessDeactivator))]
	[DefaultBinding(typeof(IIdentityServiceClientFinder))]
	public class TempAccessProxy : ITempAccessProxy, ITempAccessDeactivator, IIdentityServiceClientFinder
	{

		#region Constants: Public

		public const string RegisterAccessScopes = "register_own_resource IdentityServerApi";
		public const string ListAccessScopes = "get_resource_list IdentityServerApi";
		public const string ClientInfoScopes = "get_client_info IdentityServerApi";
		public const string FindClientsScopes = "find_clients IdentityServerApi";
		public const int RegistrationTimeoutMs = 20000;
		public const string RegisterAccessMethod = "OwnedResources/register";
		public const string ListAccessMethod = "OwnedResources/list";
		public const string RemoveAccessesMethod = "OwnedResources/delete";
		public const string FindClientsMethod = "Clients/find";

		#endregion

		#region Fields: Private

		private readonly string _serverUrl;
		private readonly string _clientId;
		private readonly string _clientSecret;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TempAccessProxy"/> class.
		/// </summary>
		/// <param name="serverUrl">The identity server URL.</param>
		/// <param name="clientId">The application client id.</param>
		/// <param name="clientSecret">The client secret.</param>
		public TempAccessProxy(string serverUrl, string clientId, string clientSecret) {
			serverUrl.CheckArgumentNullOrWhiteSpace(nameof(serverUrl));
			clientId.CheckArgumentNullOrWhiteSpace(nameof(clientId));
			_serverUrl = serverUrl;
			_clientId = clientId;
			_clientSecret = clientSecret;
		}

		#endregion

		#region Properties: Public

		private IRestClient _restClient;

		[Obsolete]
		/// <summary>
		/// Gets or sets the rest client for Api calls.
		/// </summary>
		/// <value>
		/// The rest client.
		/// </value>
		public IRestClient RestClient {
			get {
				if (_restClient == null) {
					_restClient = new RestClient {
#if NETFRAMEWORK
						BaseUrl = _serverUrl
#else
						BaseUrl = new Uri(_serverUrl)
#endif
					};
					_restClient.AddDefaultHeader("Content-Type", "application/json");
				}
				return _restClient;
			}
			set {
				_restClient = value;
			}
		}

		private IIdentityServiceWrapper _identityServiceWrapper;
		public IIdentityServiceWrapper IdentityServiceWrapper {
			get {
				if (_identityServiceWrapper == null) {
					_identityServiceWrapper = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
						? ClassFactory.Get<IIdentityServiceWrapper>("ExternalAccess")
						: ClassFactory.Get<IIdentityServiceWrapper>();
				}
				return _identityServiceWrapper;
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Grants the access.
		/// </summary>
		/// <param name="resourceName">Name of the resource.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="expirationDate">The expiration date.</param>
		/// <param name="grantorSysAdminUnitId">The grantor system admin unit id.</param>
		/// <param name="granteeClientIds">The grantee client ids.</param>
		public void GrantAccess(string resourceName, string reason, DateTime expirationDate, Guid grantorSysAdminUnitId,
				string[] granteeClientIds) {
			resourceName.CheckArgumentNullOrWhiteSpace(nameof(resourceName));
			var apiResource = new ApiResourceInfo {
				Name = resourceName,
				DisplayName = reason,
				Properties = new Dictionary<string, string> {
					{ "ExpirationDate", expirationDate.ToUniversalTime().ToString("o") },
					{ "SysAdminUnitId", grantorSysAdminUnitId.ToString() },
					{ "Type", "TempAccess" }
				}
			};
			IdentityServiceWrapper.AddResource(apiResource, granteeClientIds);
		}

		/// <summary>
		/// Enumerate granted access list.
		/// </summary>
		/// <param name="customerIds">The customer ids (Access grantors).</param>
		/// <param name="clientId">Access grantor's client id. If set, accesses of the given client will be added to
		/// the result set.</param>
		public List<(string AccessId, string Url, string Description, DateTime ExpirationDate, string CustomerId)>
				GetAccessList(string[] customerIds, string clientId = null) {
			if (customerIds.IsNullOrEmpty() && clientId.IsNullOrEmpty()) {
				throw new ArgumentNullOrEmptyException($"{nameof(customerIds)} or {nameof(clientId)}");
			}
			var result = IdentityServiceWrapper.GetResourcesList("TempAccess", customerIds, clientId)
				.SelectMany(clientInfo => clientInfo.Resources.Select(item => (
					AccessId: item.Name,
					Url: clientInfo.ClientUri,
					Description: item.DisplayName,
					item.ExpirationDate,
					clientInfo.CustomerId
				))).ToList();
			return result;
		}

		/// <summary>
		/// Request access token.
		/// </summary>
		/// <param name="accessId">The access id.</param>
		/// <returns></returns>
		public string GetAccessToken(string accessId) {
			return IdentityServiceWrapper.GetAccessToken(accessId);
		}

		/// <summary>Deactivates the specified access list.</summary>
		/// <param name="accessIds">The access ids.</param>
		/// <returns>Affected access count.</returns>
		public int Deactivate(string[] accessIds) {
			return IdentityServiceWrapper.RemoveResource(accessIds);
		}

		/// <summary>Searches clients by customer ids or client id.</summary>
		/// <param name="clientsFilter">Filter info (customerIds, clientId, etc.) to search clients.</param>
		public IList<ShortIdentityClientInfo> Search(FindIdentityClientsFilter clientsFilter) {
			if (clientsFilter.CustomerIds.IsNullOrEmpty() && clientsFilter.ClientId.IsNullOrEmpty()) {
				throw new ArgumentNullOrEmptyException($"{nameof(clientsFilter.CustomerIds)} or " +
					$"{nameof(clientsFilter.ClientId)}");
			}
			var findClientsDto = new OAuthIntegration.DTO.FindIdentityClientsFilter {
				ClientId = clientsFilter.ClientId,
				CustomerIds = clientsFilter.CustomerIds
			};
			return IdentityServiceWrapper.FindClients(findClientsDto).Select(clientInfo =>
				new ShortIdentityClientInfo {
					ClientId = clientInfo.ClientId,
					ClientName = clientInfo.ClientName,
					Description = clientInfo.Description,
					CustomerId = clientInfo.CustomerId
				}).ToList();
		}

		#endregion

	}

	#endregion

}
