namespace BPMSoft.Configuration.FolderManagerService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;

	#region Interface: IFolderManagerService
	
	[ServiceContract(Name = "FolderManagerService")]
	public interface IFolderManagerService
	{
		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ConvertFolder", BodyStyle = WebMessageBodyStyle.Wrapped, 
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		void ConvertFolder(Guid newFolderId, Guid parentFolderId, string entitySchemaName);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "IncludeEntitiesInFolder", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		ConfigurationServiceResponse IncludeEntitiesInFolder(string sourceSchemaName, string destinationSchemaName,
			string entityColumnNameInFolderEntity, Guid folderId, string filtersConfig);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteFolder", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		DeleteFolderResponse DeleteFolder(string sourceSchemaName, Guid[] records);

		#endregion
	}

	#endregion 
}
