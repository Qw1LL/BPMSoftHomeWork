namespace BPMSoft.Configuration.Tracking
{
	using System;
	using BPMSoft.Core;

	#region Class: TenantDataProvider

	/// <summary>
	/// Provide information from project service.
	/// </summary>
	public class ProjectDataProvider : TenantServiceDataProvider
	{

		#region Fields: Private

		private readonly string _projectPathSuffix = "/api/Project";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public ProjectDataProvider(UserConnection userConnection)
				: base(userConnection) { }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates project with <paramref name="projectId"/>.
		/// </summary>
		/// <param name="projectId">Project identifier.</param>
		/// <returns>Response from the service.</returns>
		public DataProviderResponse CreateProject(Guid projectId) {
			var requestUrl = TenantUrl + _projectPathSuffix + "/create";
			return SendTokenizedPostRequest<DataProviderResponse>(requestUrl, new { ProjectId = projectId });
		}

		/// <summary>
		/// Deletes project.
		/// </summary>
		/// <param name="projectId">Project identifier.</param>
		/// <returns>Status code from server request.</returns>
		public DataProviderResponse Delete(Guid projectId) {
			var requestUrl = TenantUrl + _projectPathSuffix + $"/delete/{projectId}";
			return SendTokenizedDeleteRequest<DataProviderResponse>(requestUrl);
		}
		#endregion

	}

	#endregion

}

