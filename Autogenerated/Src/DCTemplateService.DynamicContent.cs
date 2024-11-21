namespace BPMSoft.Configuration.DynamicContent
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Configuration.DynamicContent.DataContract;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Web.Common;

	#region Class: DCTemplateService

	/// <summary>
	/// Service operates with dynamic templates. Performs CRUD operations.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DCTemplateService : BaseService
	{

		#region Methods: Public

		/// <summary>
		/// Saves template in DB.
		/// </summary>
		/// <param name="template"><see cref="DCTemplateContract"/> instance that contains template details.</param>
		/// <returns><see cref="ConfigurationServiceResponse"/> object with 
		/// <see cref="ConfigurationServiceResponse.Success"/> property true when save was success. 
		/// <see cref="ConfigurationServiceResponse"/> object with  <see cref="ConfigurationServiceResponse.Success"/> 
		/// property false in otherwise.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Save", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse Save(DCTemplateContract template) {
			var response = new ConfigurationServiceResponse();
			try {
				var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
				var repositoryReadOptions = new DCRepositoryReadOptions<DCTemplateModel, DCReplicaModel> {
					TemplateReadOptions = DCTemplateReadOption.ExcludeAttributes
						| DCTemplateReadOption.ExcludeReplicaHtmlContent
				};
				var existedTemplate = templateRepository.ReadByRecordId(template.RecordId, repositoryReadOptions);
				if (existedTemplate != null) {
					template.Id = existedTemplate.Id;
				} else if (template.Id.Equals(Guid.Empty)) {
					template.Id = Guid.NewGuid();
				}
				templateRepository.Save((DCTemplateModel)template);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		/// <summary>
		/// Reads template from DB.
		/// </summary>
		/// <param name="templateId">Unique identifier of the teplate.</param>
		/// <returns><see cref="DCTemplateContractResponse"/> object with all information about template.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Read", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public DCTemplateContractResponse Read(Guid templateId) {
			var response = new DCTemplateContractResponse();
			try {
				var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
				var templateModel = templateRepository.Read(templateId);
				response.TemplateContract = (DCTemplateContract)templateModel;
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		/// <summary>
		/// Deletes template from DB.
		/// </summary>
		/// <param name="templateId">Unique identifier of the wanted teplate.</param>
		/// <returns><see cref="ConfigurationServiceResponse"/> object with 
		/// <see cref="ConfigurationServiceResponse.Success"/> property true when when template and all linked 
		/// entities were successfully deleted. <see cref="ConfigurationServiceResponse"/> object 
		/// with <see cref="ConfigurationServiceResponse.Success"/> property false in otherwise.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse Delete(Guid templateId) {
			var response = new ConfigurationServiceResponse();
			try {
				var templateRepository = new DCTemplateRepository<DCTemplateModel>(UserConnection);
				response.Success = templateRepository.Delete(templateId);
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

		#endregion

	}

	#endregion

}
