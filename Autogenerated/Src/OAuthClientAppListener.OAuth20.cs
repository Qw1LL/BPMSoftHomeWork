namespace BPMSoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.OAuthIntegration.DTO;
	using BPMSoft.OAuthIntegration.Exception;

	#region Class: OAuthClientAppListener

	[EntityEventListener(SchemaName = "OAuthClientApp")]
	public class OAuthClientAppListener : BaseOAuthApiCaller
	{

		#region Constructors: Public

		public OAuthClientAppListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.ClientApplicationHandlingErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private ClientAppInfoRequest GetClientAppInfoFromEntity(Entity entity) {
			var clientName = entity.GetTypedColumnValue<string>("Name");
			var redirectUrl = entity.GetTypedColumnValue<string>("RedirectUrl");
			var applicationUrl = entity.GetTypedColumnValue<string>("ApplicationUrl");
			var clientId = entity.GetTypedColumnValue<string>("ClientId");
			var systemUserId = entity.GetTypedColumnValue<string>("SystemUserId");
			var isActive = entity.GetTypedColumnValue<bool>("IsActive");
			var clientDescription = entity.GetTypedColumnValue<string>("Description");
			var clientAppInfoReq = new ClientAppInfoRequest {
				ClientId = clientId,
				CustomerId = clientName,
				ClientAppName = clientName,
				ClientAppDescription = clientDescription,
				ClientAppUri = applicationUrl,
				Enabled = isActive,
				SystemUserId = systemUserId,
				RedirectUris = new[] { redirectUrl }
			};
			return clientAppInfoReq;
		}

		private void CreateOAuthResourceInClient(Guid clientAppId, Guid resourceId, UserConnection userConnection) {
			var resourceInClient = new OAuthResourceInClient(userConnection);
			resourceInClient.SetDefColumnValues();
			resourceInClient.OAuthClientId = clientAppId;
			resourceInClient.OAuthResourceId = resourceId;
			resourceInClient.Save();
		}

		private Guid GetOAuthDefaultResourceId(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OAuthResource");
			EntitySchemaQueryColumn columnId = esq.AddColumn("Id");
			IEntitySchemaQueryFilterItem isDefaultFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsDefault", true);
			esq.Filters.Add(isDefaultFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			if (entityCollection.Count == 1) {
				return entityCollection[0].GetTypedColumnValue<Guid>(columnId.Name);
			} else if (entityCollection.Count > 1) {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.MoreThanOneDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			} else {
				string message = new LocalizableString(userConnection.ResourceStorage, "OAuthClientAppListener",
					"LocalizableStrings.NoDefaultResourceMessage.Value");
				throw new OAuthClientAppException(message);
			}
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMsg) => throw new OAuthClientAppException(errorMsg);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			var entity = (Entity)sender;
			GetOAuthDefaultResourceId(entity.UserConnection);
			base.OnInserting(sender, e);
			ClientAppInfo clientAppResponse = null;
			ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(entity);
			ExecuteApiCall(() => clientAppResponse = IdentityServiceWrapper.AddClient(clientAppRequest), entity.UserConnection, e);
			entity.SetColumnValue("ClientId", clientAppResponse.ClientId);
			entity.SetColumnValue("ClientSecret", clientAppResponse.Secret);
		}

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			Guid clientAppId = entity.PrimaryColumnValue;
			Guid resourceId = GetOAuthDefaultResourceId(entity.UserConnection);
			CreateOAuthResourceInClient(clientAppId, resourceId, entity.UserConnection);
		}

		/// <summary>Handles entity Updating event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
			var entity = (Entity)sender;
			ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.UpdateClient(clientAppRequest), entity.UserConnection, e);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			string clientId = entity.GetTypedColumnValue<string>("ClientId");
			ExecuteApiCall(() => IdentityServiceWrapper.RemoveClient(clientId), entity.UserConnection, e);
		}

		#endregion

	}

	#endregion

}
