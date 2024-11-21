namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: CopyProjectResponse

	/// <summary>
	/// Copy operation response class.
	/// </summary>
	public class CopyProjectResponse : ConfigurationServiceResponse
	{
		/// <summary>
		/// Created project identifier
		/// </summary>
		[DataMember(Name = "CreatedProjectId")]
		public Guid CreatedProjectId { get; set; }
	}

	#endregion

	#region Class: ProjectUtilitiesService

	/// <inheritdoc />
	/// <summary>
	/// Service with utilities methods for Project entity.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProjectUtilitiesService : BaseService
	{
		#region Fields: Private

		private readonly Lazy<ProjectCopyManager> _copyManager;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		public ProjectUtilitiesService() {
			_copyManager = new Lazy<ProjectCopyManager>(
				() => ClassFactory.Get<ProjectCopyManager>(
					new ConstructorArgument("userConnection", UserConnection)));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Copy project with all subordinate works.
		/// </summary>
		/// <param name="projectId">Project identifier</param>
		[OperationContract]
		[WebInvoke(UriTemplate = "CopyProjectWithStructure", ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public CopyProjectResponse CopyProjectWithStructure(Guid projectId) {
			CopyProjectResponse response = new CopyProjectResponse {
				Success = true
			};
			try {
				response.CreatedProjectId = _copyManager.Value.CopyProjectWithStructure(projectId);
			} catch (Exception e) {
				response.Success = false;
				response.Exception = e;
			}
			return response;
		}

		#endregion
	}

	#endregion
} 
