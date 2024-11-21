namespace BPMSoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Configuration;

	#region Class: OAuthConfigService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class OAuthConfigService : BaseService
	{

		#region Properties: Public

		public string OAuthDisabledMessage {
			get {
				return new LocalizableString(UserConnection.ResourceStorage, "OAuthConfigService",
						"LocalizableStrings.OAuthDisabledMessage.Value");
			}
		}
		#endregion

		#region Methods: Private

		private bool IsResourceInClientAlreadyExists(string clientId, string resourceName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OAuthResourceInClient");
			esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem clientFilter = esq
				.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthClient.ClientId", clientId);
			IEntitySchemaQueryFilterItem resourceFilter = esq
				.CreateFilterWithParameters(FilterComparisonType.Equal, "OAuthResource.Name", resourceName);
			esq.Filters.Add(clientFilter);
			esq.Filters.Add(resourceFilter);
			EntityCollection result = esq.GetEntityCollection(UserConnection);
			if (result.Count > 0) {
				return true;
			}
			return false;
		}

		private bool TryGetClientAppIdByClientId(string clientId, out Guid clientAppId) {
			clientAppId = Guid.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OAuthClientApp");
			EntitySchemaQueryColumn colId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem clientIdFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ClientId", clientId);
			esq.Filters.Add(clientIdFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				clientAppId = entityCollection[0].GetTypedColumnValue<Guid>(colId.Name);
				return true;
			}
			return false;
		}

		private bool IsSysAdminUnitValid(Guid sysAdminUnitId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			EntitySchemaQueryColumn colId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem sysAdminUnitIdFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", sysAdminUnitId);
			IEntitySchemaQueryFilterItem sysAdminUnitTypeFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnitTypeValue", 4);
			esq.Filters.Add(sysAdminUnitIdFilter);
			esq.Filters.Add(sysAdminUnitTypeFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				return true;
			}
			return false;
		}

		private bool TryGetResourceIdByName(string resourceName, out Guid resourceId) {
			resourceId = Guid.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OAuthResource");
			EntitySchemaQueryColumn colId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem resourceNameFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Name", resourceName);
			esq.Filters.Add(resourceNameFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				resourceId = entityCollection[0].GetTypedColumnValue<Guid>(colId.Name);
				return true;
			}
			return false;
		}

		private void CreateOAuthResourceInClient(Guid clientAppId, Guid resourceId) {
			var resourceInClient = new OAuthResourceInClient(UserConnection);
			resourceInClient.SetDefColumnValues();
			resourceInClient.OAuthClientId = clientAppId;
			resourceInClient.OAuthResourceId = resourceId;
			resourceInClient.Save();
		}

		private ConfigurationServiceResponse GetErrorConfigurationServiceResponse(string message) {
			return new ConfigurationServiceResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo() {
					Message = message
				}
			};
		}

		private OAuthResource CreateResource() {
			var conditions = new Dictionary<string, object> {
				{ "IsDefault", true }
			};
			var resource = new OAuthResource(UserConnection);
			if (!resource.FetchFromDB(conditions)) {
				resource.SetDefColumnValues();
				resource.Name = $"ApplicationAccess_{Guid.NewGuid():N}";
				resource.DisplayName = "Application access";
				resource.IsDefault = true;
				resource.Save();
			}
			else {
				throw new ItemAlreadyExistException(resource.Name);
			}
			return resource;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public AddResourceResponse AddDefaultResource() {
			if(!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new AddResourceResponse() {
					Success = false,
					ErrorInfo = new ErrorInfo() {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				var resource = CreateResource();
				return new AddResourceResponse() {
					Scope = resource.Name
				};
			} catch (Exception e) {
				return new AddResourceResponse() {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public AddClientResponse AddClient(AddClientRequest addClientRequest) {
			if(!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return new AddClientResponse() {
					Success = false,
					ErrorInfo = new ErrorInfo() {
						Message = OAuthDisabledMessage
					}
				};
			}
			try {
				if (!IsSysAdminUnitValid(addClientRequest.SystemUserId)) {
					string message = "Specified system user is not valid.";
					var clientResponse = new AddClientResponse() {
						Success = false,
						ErrorInfo = new ErrorInfo() {
							Message = message
						}
					};
					return clientResponse;
				}
				var client = new OAuthClientApp(UserConnection);
				client.SetDefColumnValues();
				client.Name = addClientRequest.Name;
				client.ApplicationUrl = addClientRequest.ApplicationUrl;
				client.RedirectUrl = addClientRequest.RedirectUrl;
				client.SystemUserId = addClientRequest.SystemUserId;
				client.IsActive = true;
				client.Save();
				return new AddClientResponse() {
					ClientId = client.ClientId,
					ClientSecret = client.ClientSecret
				};
			} catch (Exception e) {
				return new AddClientResponse() {
					Exception = e
				};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UpdateClient(UpdateClientRequest updateClientRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var conditions = new Dictionary<string, object>() {
					{ "ClientId", updateClientRequest.ClientId }
				};
				var client = new OAuthClientApp(UserConnection);
				if (!client.FetchFromDB(conditions)) {
					string message = "Record with specified Id does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (updateClientRequest.SystemUserId != null &&
					!IsSysAdminUnitValid((Guid)updateClientRequest.SystemUserId)) {
					string message = "Specified system user is not valid.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Name = updateClientRequest.Name ?? client.Name;
				client.RedirectUrl = updateClientRequest.RedirectUrl ?? client.RedirectUrl;
				client.ApplicationUrl = updateClientRequest.ApplicationUrl ?? client.ApplicationUrl;
				client.SystemUserId = updateClientRequest.SystemUserId ?? client.SystemUserId;
				client.IsActive = updateClientRequest.IsActive ?? client.IsActive;
				client.Save();
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, 
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteClient(DeleteClientRequest deleteClientRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				var conditions = new Dictionary<string, object>() {
					{ "ClientId", deleteClientRequest.ClientId }
				};
				var client = new OAuthClientApp(UserConnection);
				if (!client.FetchFromDB(conditions)) {
					string message = "Record with specified Id does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Delete();
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse GrantAccess(UpdateClientScopesRequest grantAccessRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				if (IsResourceInClientAlreadyExists(grantAccessRequest.ClientId, grantAccessRequest.ResourceName)) {
					string message = "Specified client application already has access to specified resource.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if(!TryGetClientAppIdByClientId(grantAccessRequest.ClientId, out Guid clientAppId)) {
					string message = "Client with specified clientId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetResourceIdByName(grantAccessRequest.ResourceName, out Guid resourceId)) {
					string message = "Resource with specified name does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				CreateOAuthResourceInClient(clientAppId, resourceId);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse DeleteScope(UpdateClientScopesRequest removeClientScopesRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				if (!IsResourceInClientAlreadyExists(removeClientScopesRequest.ClientId,
					removeClientScopesRequest.ResourceName)) {
					string message = "Specified client application already has no access to specified resource.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetClientAppIdByClientId(removeClientScopesRequest.ClientId, out Guid clientAppId)) {
					string message = "Client with specified clientId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				if (!TryGetResourceIdByName(removeClientScopesRequest.ResourceName, out Guid resourceId)) {
					string message = "Resource with specified name does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				var conditions = new Dictionary<string, object>() {
					{ "OAuthClient", clientAppId },
					{ "OAuthResource", resourceId }
				};
				var client = new OAuthResourceInClient(UserConnection);
				if (!client.FetchFromDB(conditions))
				{
					string message = "Record with specified OAuthClientId and OAuthResourceId does not exist.";
					return GetErrorConfigurationServiceResponse(message);
				}
				client.Delete();
				return new ConfigurationServiceResponse();
			}
			catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ClientSecretResponse GetClientSecret(Guid clientAppId) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
			var client = new OAuthClientApp(UserConnection);
			if(client.FetchFromDB(clientAppId)) {
				return new ClientSecretResponse() {
					ClientSecret = client.ClientSecret
				};
			} else {
				string message = "Client with specified Id does not exist.";
				return new ClientSecretResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo() {
					Message = message
				}
			};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ConfigureIdentityProvider(OAuthSettingsRequest settingsRequest) {
			if (!GlobalAppSettings.FeatureEnableOAuth20Integration) {
				return GetErrorConfigurationServiceResponse(OAuthDisabledMessage);
			}
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				string serverUrlSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerUrl" : "IdentityServerUrl";
				string clientIdSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerClientId" : "IdentityServerClientId";
				string clientSecretSettingCode = GlobalAppSettings.FeatureUseSeparateSettingsForOAuth20
					? "OAuth20IdentityServerClientSecret" : "IdentityServerClientSecret";
				SysSettings.SetDefValue(UserConnection, clientIdSettingCode, settingsRequest.ClientId);
				SysSettings.SetDefValue(UserConnection, clientSecretSettingCode, settingsRequest.ClientSecret);
				SysSettings.SetDefValue(UserConnection, serverUrlSettingCode, settingsRequest.ServerUrl);
				CreateResource();
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse(e);
			}
		}

		#endregion

	}

	#endregion

}
