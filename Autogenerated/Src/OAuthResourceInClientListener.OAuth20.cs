namespace BPMSoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.OAuthIntegration.DTO;
	using BPMSoft.OAuthIntegration.Exception;

	#region Class: OAuthResourceInClientListener

	[EntityEventListener(SchemaName = "OAuthResourceInClient")]
	public class OAuthResourceInClientListener : BaseOAuthApiCaller
	{

		#region Constructors: Public

		public OAuthResourceInClientListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.OAuthResourceInClientErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private string GetResourceName(Guid resourceId, string resourceSchema, string searchColumn, UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, resourceSchema);
			EntitySchemaQueryColumn colId = esq.AddColumn(searchColumn);
			IEntitySchemaQueryFilterItem resourceNameFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", resourceId);
			esq.Filters.Add(resourceNameFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			var resourceName = entityCollection[0].GetTypedColumnValue<string>(colId.Name);
			return resourceName;
		}

		private string GetResourceNameByResourceId(Guid resourceId, UserConnection userConnection) {
			string resourceName = GetResourceName(resourceId, "OAuthResource", "Name", userConnection);
			return resourceName;
		}

		private string GetClientIdByClientAppId(Guid clientAppId, UserConnection userConnection) {
			string resourceName = GetResourceName(clientAppId, "OAuthClientApp", "ClientId", userConnection);
			return resourceName;
		}

		private GrantAccessInfo GetGrantAccessInfoFromEntity(Entity entity) {
			var clientAppId = entity.GetTypedColumnValue<Guid>("OAuthClientId");
			var resourceId = entity.GetTypedColumnValue<Guid>("OAuthResourceId");
			string resourceName = GetResourceNameByResourceId(resourceId, entity.UserConnection);
			string clientId = GetClientIdByClientAppId(clientAppId, entity.UserConnection);
			return new GrantAccessInfo {
				ClientId = clientId,
				ResourceName = resourceName
			};
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMessage) => throw new OAuthResourceInClientException(errorMessage);

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
			base.OnInserting(sender, e);
			var entity = (Entity)sender;
			GrantAccessInfo grantAccessInfo = GetGrantAccessInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.GrantAccess(grantAccessInfo), entity.UserConnection, e);
		}

		/// <summary>
		/// Handles entity remove event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			GrantAccessInfo grantAccessInfo = GetGrantAccessInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.DeleteClientScopes(new ClientScopesRequest {
				ClientId = grantAccessInfo.ClientId,
				AllowedScopes = new List<string> { grantAccessInfo.ResourceName }
			}), entity.UserConnection, e);
		}

		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
		}

		#endregion
	}

	#endregion

}
