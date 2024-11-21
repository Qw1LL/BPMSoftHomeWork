namespace BPMSoft.Configuration.InterfaceDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.ServiceModelContract.Designers;
	using BPMSoft.Web.Common;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region Class: SchemaTemplateService

	/// <summary>
	/// Provides methods schema templates.
	/// </summary>
	[ServiceContract(Name = "schema.template.api")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SchemaTemplateService : BaseService
	{

		#region Constants: Private

		private const string BaseHomePageUID = "0c5cfb7a-1ed9-41b8-905e-9a38c6915550";
		private const string BasePageTemplateUId = "0f8eb896-7b62-4dfa-bd55-a414f50932a7";

		#endregion

		#region Methods: Private

		private static ParentItemDto ConvertToParentItemDto(ISchemaManagerItem<ClientUnitSchema> managerItem) {
			return new ParentItemDto {
				UId = managerItem.RealUId,
				Name = managerItem.Name,
				Title = managerItem.Caption
			};
		}

		private string GetSchemaGroup(ISchemaManagerItem<ClientUnitSchema> schema) {
			return schema.GetGroupName();
		}

		private IEnumerable<Guid> GetSchemaTemplatesUIds() {
			return new[] { new Guid(BaseHomePageUID), new Guid(BasePageTemplateUId), };
		}

		private ClientUnitSchemaType GetSchemaType(ISchemaManagerItem<ClientUnitSchema> schema) {
			var schemaExtraProperties = schema.ExtraProperties;
			ClientUnitSchemaType schemaType;
			if (schemaExtraProperties.Count == 0) {
				schemaType = schema.Instance.SchemaType;
			} else {
				ExtraProperty schemaTypeExtraProperty = schemaExtraProperties.GetByName("SchemaType");
				if (!Enum.TryParse(schemaTypeExtraProperty?.Value?.ToString(),
					out ClientUnitSchemaType extraPropertySchemaType)) {
					extraPropertySchemaType = schema.Instance.SchemaType;
				}
				schemaType = extraPropertySchemaType;
			}
			return schemaType;
		}

		private ISchemaManagerItem<ClientUnitSchema> GetManagerItem(Guid UId) {
			return UserConnection.ClientUnitSchemaManager.FindItemByUId(UId);
		}

		private IEnumerable<SchemasGroup> GetTemplateSchemas() {
			var templatesUIds = GetSchemaTemplatesUIds();
			var templateSchemasGroup = templatesUIds.Select(GetManagerItem)
				.Where(item =>
				!item.ExtendParent && GetSchemaType(item).Equals(ClientUnitSchemaType.AngularSchema))
				.GroupBy(GetSchemaGroup);
			var test = templateSchemasGroup.ToList();
			return templateSchemasGroup.Select(group => new SchemasGroup {
				GroupName = @group.Key,
				Items = @group.ToArray().Select(ConvertToParentItemDto).Distinct().OrderBy(a => a.Title).ToArray()
			}).ToArray();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/templates", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public TemplatesResponse GetTemplates() {
			var response = new TemplatesResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
				response.Groups = GetTemplateSchemas();
				return response;
			} catch (SecurityException exception) {
				var exceptionResponse = new TemplatesResponse(exception);
				throw new WebFaultException<TemplatesResponse>(exceptionResponse, HttpStatusCode.Forbidden);
			} catch (Exception exception) {
				var exceptionResponse = new TemplatesResponse(exception);
				throw new WebFaultException<TemplatesResponse>(exceptionResponse, HttpStatusCode.InternalServerError);
			}
		}

		#endregion

	}

	#endregion

	#region Classes

	[DataContract]
	public class TemplatesResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		public TemplatesResponse() { }

		public TemplatesResponse(Exception e)
			: base(e) { }

		#endregion

		#region Properties: Public

		[DataMember(Name = "groups")]
		public IEnumerable<SchemasGroup> Groups { get; set; }

		#endregion

	}

	[DataContract]
	public class SchemasGroup
	{

		#region Properties: Public

		[DataMember(Name = "groupName")]
		public string GroupName { get; set; }

		[DataMember(Name = "items")]
		public IEnumerable<ParentItemDto> Items { get; set; }

		#endregion

	}

	#endregion

}

