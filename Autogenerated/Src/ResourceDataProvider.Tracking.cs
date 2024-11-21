namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: TenantDataProvider

	/// <summary>
	/// Provide information from tenant resource service.
	/// </summary>
	public class ResourceDataProvider : TenantServiceDataProvider
	{

		#region Fields: Private

		private readonly string _resourcePathSuffix = "/api/Resource";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public ResourceDataProvider(UserConnection userConnection)
				: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates resource with parameters.
		/// </summary>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse Create(Guid resourceId, Guid projectId, bool isActive) {
			var requestUrl = TenantUrl + _resourcePathSuffix + "/create";
			return SendTokenizedPostRequest<DataProviderResponse>(requestUrl, new {
				Id = resourceId,
				ProjectId = projectId,
				ResourceType = 0,
				IsActive = isActive
			});
		}

		/// <summary>
		/// Creates resource with parameters.
		/// </summary>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse Update(Guid resourceId, bool isActive) {
			var requestUrl = TenantUrl + _resourcePathSuffix + "/update";
			return SendTokenizedPutRequest<DataProviderResponse>(requestUrl, new
			{
				Id = resourceId,
				ResourceType = 0,
				IsActive = isActive
			});
		}

		/// <summary>
		/// Deactivates project.
		/// </summary>
		/// <param name="projectId">Project identifier.</param>
		/// <returns>Status code from server request.</returns>
		public DataProviderResponse Delete(Guid resourceId) {
			var requestUrl = TenantUrl + _resourcePathSuffix + $"/delete/{resourceId}";
			return SendTokenizedDeleteRequest<DataProviderResponse>(requestUrl);
		}

		#endregion

	}

	#endregion

}


