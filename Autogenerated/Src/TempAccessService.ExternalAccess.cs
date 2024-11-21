namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using CoreConfig = Core.Configuration;

	#region Class: GetTempAccessListDto

	/// <summary>
	/// Response Dto for GetTempAccessList method.
	/// </summary>
	[DataContract]
	public class GetTempAccessListDto {

		#region Properties: Public

		/// <summary>
		/// Gets or sets the access identifier.
		/// </summary>
		/// <value>
		/// The access identifier.
		/// </value>
		[DataMember(Name = "accessId")]
		public string AccessId { get; set; }

		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		[DataMember(Name = "url")]
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the expiration date.
		/// </summary>
		/// <value>
		/// The expiration date.
		/// </value>
		[DataMember(Name = "expirationDate")]
		public string ExpirationDate { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier (CID).
		/// </summary>
		/// <value>
		/// The customer identifier (CID).
		/// </value>
		[DataMember(Name = "customerId")]
		public string CustomerId { get; set; }

		#endregion

	}

	#endregion

	#region Class: TempAccessDeactivationDto

	/// <summary>
	/// Response Dto for DeactivateAccesses method.
	/// </summary>
	[DataContract]
	public class TempAccessDeactivationDto
	{

		#region Properties: Public

		/// <summary>Gets or sets the access server affected records.</summary>
		/// <value>Remote affected records.</value>
		[DataMember(Name = "accessServerAffectedRecords")]
		public int AccessServerAffectedRecords { get; set; }

		/// <summary>
		/// Gets or sets the access server error.
		/// </summary>
		/// <value>
		/// The access server error.
		/// </value>
		[DataMember(Name = "accessServerError")]
		public string AccessServerError { get; set; }

		#endregion

	}

	#endregion

	#region Class: TempAccessService

	/// <summary>
	/// Web methods request access granted by external apps.
	/// </summary>
	/// <seealso cref="BPMSoft.Web.Common.BaseService" />
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TempAccessService : BaseService, System.Web.SessionState.IReadOnlySessionState
	{

		#region Constants: Private

		private const string IdentityAddressSettingsName = "IdentityServerUrl";
		private const string ClientIdSettingsName = "IdentityServerClientId";
		private const string ClientSecretSettingsName = "IdentityServerClientSecret";
		private const string AdminOperationName = "CanUseExternalAccess";

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ExternalAccess");

		#endregion

		#region Methods: Private

		private ConstructorArgument[] PrepareProxyConnectionParams(UserConnection userConnection) {
			var serverAddress = CoreConfig.SysSettings.GetValue(userConnection, IdentityAddressSettingsName, "");
			var clientId = CoreConfig.SysSettings.GetValue(userConnection, ClientIdSettingsName, "");
			var clientSecret = CoreConfig.SysSettings.GetValue(userConnection, ClientSecretSettingsName, "");
			var serverAddressArg = new ConstructorArgument("serverUrl", serverAddress);
			var clientIdArg = new ConstructorArgument("clientId", clientId);
			var clientSecretArg = new ConstructorArgument("clientSecret", clientSecret);
			return new[] { serverAddressArg, clientIdArg, clientSecretArg };
		}

		private T GetTempAccessProxy<T>(UserConnection userConnection) where T : class {
			ConstructorArgument[] proxyParams = PrepareProxyConnectionParams(userConnection);
			return ClassFactory.Get<T>(proxyParams);
		}

		private void CheckOperationRights() {
			var securityEngine = UserConnection.DBSecurityEngine;
			securityEngine.CheckCanExecuteOperation(AdminOperationName);
		}

		private void UpdateExternalAccessRecords(string[] accessIds) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName("ExternalAccess");
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			esq.IgnoreDisplayValues = true;
			object[] ids = accessIds.Select(item => (object)Guid.Parse(item)).ToArray();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", ids));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			foreach (var entity in collection) {
				entity.SetColumnValue("IsActive", false);
				entity.Save();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Requests actual granted access list for our application.
		/// </summary>
		/// <param name="customerIds">The customer ids.</param>
		/// /// <param name="clientId">Access grantor's client id. If set, accesses of the given client will be added
		/// to the result set.</param>
		/// <returns>List of granted access info.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public List<GetTempAccessListDto> GetTempAccessList(string[] customerIds, string clientId = null) {
			CheckOperationRights();
			var accessProxy = GetTempAccessProxy<ITempAccessProxy>(UserConnection);
			List<(string AccessId, string Url, string Description, DateTime ExpirationDate, string CustomerId)> result
				= accessProxy.GetAccessList(customerIds, clientId);
			return result
				.Where(item => item.ExpirationDate.ToUniversalTime().Date >= DateTime.UtcNow.Date)
				.Select(item => new GetTempAccessListDto {
					AccessId = item.AccessId,
					Url = item.Url,
					Description = item.Description,
					ExpirationDate = item.ExpirationDate.ToString("o"),
					CustomerId = item.CustomerId
				}).ToList();
		}

		/// <summary>
		/// Request access token.
		/// </summary>
		/// <param name="accessId">Access id.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public string GetAccessToken(string accessId) {
			CheckOperationRights();
			var accessProxy = GetTempAccessProxy<ITempAccessProxy>(UserConnection);
			return accessProxy.GetAccessToken(accessId);
		}

		/// <summary>
		/// Deactivates specified accesses.
		/// </summary>
		/// <param name="accessIds">Accesses to deactivate.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public TempAccessDeactivationDto DeactivateAccesses(string[] accessIds) {
			UpdateExternalAccessRecords(accessIds);
			var result = new TempAccessDeactivationDto();
			try {
				var proxy = GetTempAccessProxy<ITempAccessDeactivator>(UserConnection);
				result.AccessServerAffectedRecords = proxy.Deactivate(accessIds);
				_log.InfoFormat("Successfully deactivated {0} of {1} record(s).", result, accessIds.Length);
			} catch (Exception e) {
				_log.Warn("An error occured while deactivating records using proxy.", e);
				result.AccessServerError = e.ToString();
			}
			return result;
		}

		/// <summary>
		/// Checks whether any identity client registered by customer ids or client id.
		/// </summary>
		/// <param name="customerIds">The customer ids.</param>
		/// /// <param name="clientId">Client id.</param>
		/// <returns><c>true</c> if any clients exists, otherwise <c>false</c>.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public bool IsAnyClientRegistered(List<string> customerIds, string clientId = null) {
			CheckOperationRights();
			var accessProxy = GetTempAccessProxy<IIdentityServiceClientFinder>(UserConnection);
			IList<ShortIdentityClientInfo> result = accessProxy.Search(new FindIdentityClientsFilter {
				CustomerIds = customerIds,
				ClientId = clientId
			});
			return !result.IsNullOrEmpty();
		}

		#endregion

	}

	#endregion

}


