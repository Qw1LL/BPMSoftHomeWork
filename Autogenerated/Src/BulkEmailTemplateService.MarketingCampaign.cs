namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Text;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common.Json;
	using BPMSoft.Web.Common;

	#region Class: BulkEmailTemplateService

	/// <summary>
	///############ ##### ### ########## ####### ######.
	///</summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BulkEmailTemplateService : BaseService
	{

		#region Constants: Private

		private const int _templateBytesLimit = 5242880;

		#endregion

		#region Methods: Private

		private bool ValidateTemplateBodyLength(string body) {
			var bodyBytesCount = Encoding.ASCII.GetByteCount(body);
			return !(bodyBytesCount >= _templateBytesLimit);
		}

		private string GetLczStringValue(string lczName) {
			var localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "BulkEmailSplitService", localizableStringName);
			var value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private Entity GetEmailTemplateEntity(Guid templateId) {
			var emailTemplateESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				"EmailTemplate");
			emailTemplateESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			emailTemplateESQ.AddColumn("Subject");
			emailTemplateESQ.AddColumn("TemplateConfig");
			emailTemplateESQ.AddColumn("Body");
			var emailTemplate = emailTemplateESQ.GetEntity(UserConnection, templateId);
			return emailTemplate;
		}

		private List<string> GetUnsubscribeMacrosValues() {
			var cultures = GetCulturesWithId();
			var macroses = new List<string>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmailTemplateMacros");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var nameColumn = esq.AddColumn("Name");
			var parentNameColumn = esq.AddColumn("Parent.Name");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				MarketingConsts.EmailTemplateMacrosUnsubscribeUrlId));
			foreach (var cultureInfo in cultures) {
				esq.SetLocalizationCultureId(cultureInfo.Key);
				var entityCollection = esq.GetEntityCollection(UserConnection);
				var entity = entityCollection.FirstOrDefault();
				if (entity == null) {
					continue;
				}
				var name = entity.GetTypedColumnValue<string>(nameColumn.Name);
				var parentName = entity.GetTypedColumnValue<string>(parentNameColumn.Name);
				macroses.Add($"[#{parentName}.{name}#]");
			}
			return macroses;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Return`s active system cultures with Ids.
		/// </summary>
		/// <returns></returns>
		protected virtual Dictionary<Guid, string> GetCulturesWithId() {
			var cultures = Core.Configuration.SysCulture.GetSysCultures(UserConnection);
			return cultures;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ###-##### ########## ####### ######### ######## ### ########.
		/// </summary>
		/// <param name="bulkEmailId">########## ############# Email.</param>
		/// <param name="emailTemplateId">########## ############# ####### email #########.</param>
		/// <param name="requiredColumnValues">############### ########## ######## ############
		/// ##### ##### "BulkEmail".</param>
		/// <param name="body">##### #######.</param>
		/// <returns>######### ########## ####### BulkEmailTemplateServiceResponse.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveBulkEmailTemplate", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public BulkEmailTemplateServiceResponse SaveBulkEmailTemplate(Guid bulkEmailId,
			Guid emailTemplateId, string requiredColumnValues, string body, string config) {
			var result = new BulkEmailTemplateServiceResponse {
				Success = false,
				Message = GetLczStringValue("CommonError")
			};
			var columnsToSave = Json.Deserialize<Dictionary<string, object>>(requiredColumnValues);
			var emailTemplate = GetEmailTemplateEntity(emailTemplateId);
			if (emailTemplate != null) {
				var templateBody =
					string.IsNullOrEmpty(body) ? emailTemplate.GetTypedColumnValue<string>("Body") : body;
				var templateConfig = string.IsNullOrEmpty(config)
					? emailTemplate.GetTypedColumnValue<string>("TemplateConfig")
					: config;
				if (!ValidateTemplateBodyLength(templateBody)) {
					result.Success = false;
					result.Message = string.Format(GetLczStringValue("TooLargeEmailTemplate"),
						_templateBytesLimit / 1024);
					return result;
				}
				var bulkEmail = UserConnection.EntitySchemaManager.GetInstanceByName("BulkEmail")
					.CreateEntity(UserConnection);
				var temlpateSubject = emailTemplate.GetTypedColumnValue<string>("Subject");
				if (!bulkEmail.FetchFromDB(bulkEmailId)) {
					bulkEmail.SetDefColumnValues();
					bulkEmail.SetColumnValue("Id", bulkEmailId);
				}
				bulkEmail.SetColumnValue("TemplateSubject", temlpateSubject);
				bulkEmail.SetColumnValue("TemplateConfig", templateConfig);
				bulkEmail.SetColumnValue("TemplateBody", templateBody);
				bulkEmail.SetColumnValue("Name", columnsToSave["Name"]);
				bulkEmail.SetColumnValue("SenderName", columnsToSave["SenderName"]);
				bulkEmail.SetColumnValue("SenderEmail", columnsToSave["SenderEmail"]);
				if (bulkEmail.Save(false)) {
					result.Success = true;
					result.Message = GetLczStringValue("TemplateSavedSuccessFully");
					result.TemplateSubject = temlpateSubject;
					result.TemplateBody = templateBody;
					result.TemplateConfig = templateConfig;
					return result;
				}
			}
			return result;
		}

		/// <summary>
		/// ###-##### ########## ############ ####### # ##### ####### ## ########### ########.
		/// </summary>
		/// <param name="emailTemplateId">########## ############# ####### email #########.</param>
		/// <returns>###### ########## ############ ####### # ##### #######.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetEmailTemplateConfig", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EmailTemplateResponse GetEmailTemplateConfig(Guid emailTemplateId) {
			var result = new EmailTemplateResponse();
			var emailTemplate = GetEmailTemplateEntity(emailTemplateId);
			if (emailTemplate != null) {
				result.TemplateConfig = emailTemplate.GetTypedColumnValue<string>("TemplateConfig");
				result.TemplateBody = emailTemplate.GetTypedColumnValue<string>("Body");
				result.TemplateSubject = emailTemplate.GetTypedColumnValue<string>("Subject");
			}
			return result;
		}

		/// <summary>
		/// Web-method that returns all replicas of email.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <returns>Response object containing sent replicas.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDcReplicas", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public DcReplicasResponse GetDcReplicas(Guid bulkEmailId) {
			var bulkEmailTemplateRepository = new BulkEmailTemplateRepository(UserConnection);
			var dcReplicaModels = bulkEmailTemplateRepository.GetDcReplicas(bulkEmailId);
			var replicas = dcReplicaModels.Select(sr => new Replica {
				Name = sr.Caption,
				Mask = sr.Mask,
				Id = sr.Id
			}).ToArray();
			return new DcReplicasResponse {
				Replicas = replicas
			};
		}

		/// <summary>
		/// Web-method that returns identifiers of sent replicas of email.
		/// </summary>
		/// <param name="bulkEmailId">Email identifier.</param>
		/// <returns>Response object containing identifiers of sent replicas.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSentDcReplicaIds", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public DcReplicasResponse GetSentDcReplicaIds(Guid bulkEmailId) {
			var bulkEmailTemplateRepository = new BulkEmailTemplateRepository(UserConnection);
			return new DcReplicasResponse {
				Replicas = bulkEmailTemplateRepository.GetSentDcReplicaIds(bulkEmailId).Select(id => new Replica {
					Id = id
				}).ToArray()
			};
		}

		/// <summary>
		/// Web-method that counts the number of recipients for each template replica.
		/// </summary>
		/// <param name="replicaIds">Array of replica's identifiers.</param>
		/// <returns>Response object with numbers of recipients for each replica.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDcReplicasRecipientCount",
			BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public DcReplicasResponse GetDcReplicasRecipientCount(Guid[] replicaIds) {
			var bulkEmailTemplateRepository = new BulkEmailTemplateRepository(UserConnection);
			return new DcReplicasResponse {
				Replicas = bulkEmailTemplateRepository.GetBulkEmailRecipientReplicaCount(replicaIds)
					.Select(x => new Replica {
						Id = x.Key,
						RecipientCount = x.Value
					}).ToArray()
			};
		}

		/// <summary>
		/// Web-method that saves the bulk email hyperlinks from template.
		/// </summary>
		/// <param name="request">The request, instance of <see cref="SaveBulkEmailHyperlinkRequest"/>.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse"./></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveBulkEmailHyperlinks", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SaveBulkEmailHyperlinks(SaveBulkEmailHyperlinkRequest request) {
			var response = new ConfigurationServiceResponse();
			try {
				var repository = ClassFactory.Get<BulkEmailHyperlinkRepository>(
					new ConstructorArgument("userConnection", UserConnection));
				repository.SaveBulkEmailHyperlinks(request.BulkEmailId, request.Hyperlinks);
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[BulkEmailTemplateService.SaveBulkEmailHyperlinks]: Error while saving hyperlinks", e);
				throw;
			}
			return response;
		}

		/// <summary>
		/// Returns enumeration of unsubscribe macros localization values.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUnsubscribeMacros", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public UnsubscribeMacrosResponse GetUnsubscribeMacros() {
			try {
				var macros = GetUnsubscribeMacrosValues();
				return new UnsubscribeMacrosResponse {
					Macros = macros.ToArray()
				};
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[BulkEmailTemplateService.GetUnsubscribeMacros]: Error while getting macroses", e);
				throw;
			}
		}

		/// <summary>
		/// Web-method that saves the bulk email replica headers - from name, from email, subject, preheader.
		/// </summary>
		/// <param name="request">The request, instance of <see cref="SaveBulkEmailHyperlinkRequest"/>.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse"./></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveBulkEmailHeaders", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse SaveBulkEmailReplicaHeaders(SaveBulkEmailHeadersRequest request) {
			try {
				var repository = ClassFactory.Get<BulkEmailTemplateRepository>(
					new ConstructorArgument("userConnection", UserConnection));
				repository.SaveHeaders(request.BulkEmailId, request.Headers.Select(x => new ReplicaHeaderModel {
					ReplicaMask = x.ReplicaMask,
					Preheader = x.Preheader,
					SenderName = x.SenderName,
					SenderEmail = x.SenderEmail,
					Subject = x.Subject
				}));
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[BulkEmailTemplateService.SaveBulkEmailReplicaHeaders]: Error while saving replica headers", e);
				throw;
			}
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Web-method that copies the bulk email headers - from name, from email, subject, preheader - from source bulk email.
		/// </summary>
		/// <param name="request">The request, instance of <see cref="CopyBulkEmailHeadersRequest"/>.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse"./></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CopyBulkEmailHeaders", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse CopyBulkEmailReplicaHeaders(CopyBulkEmailHeadersRequest request) {
			try {
				var repository = ClassFactory.Get<BulkEmailTemplateRepository>(
					new ConstructorArgument("userConnection", UserConnection));
				repository.CopyBulkEmailReplicaHeaders(request.SourceBulkEmailId, request.BulkEmailId);
			}
			catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[BulkEmailTemplateService.SaveBulkEmailReplicaHeaders]: Error while saving replica headers", e);
				throw;
			}
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Web-method that returns headers of bulk email replicas.
		/// </summary>
		/// <param name="request">Instance of<see cref="GetBulkEmailHeadersRequest"/>.</param>
		/// <returns>Instance of <see cref="ConfigurationServiceResponse"/></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetBulkEmailReplicaHeaders", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public GetBulkEmailHeadersResponse GetBulkEmailReplicaHeaders(GetBulkEmailHeadersRequest request) {
			try {
				var repository = new BulkEmailTemplateRepository(UserConnection);
				var response = new GetBulkEmailHeadersResponse();
				response.Headers = repository.GetHeaders(request.BulkEmailId)
					.Select(x => (ReplicaHeaders)x)
					.ToArray();
				var defaultHeaders = repository.GetDefaultHeaders(request.BulkEmailId);
				response.DefaultHeaders = defaultHeaders;
				return response;
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat(
					"[BulkEmailTemplateService.GetBulkEmailReplicaHeaders]: Error while reading replica headers", e);
				throw;
			}
		}

		#endregion

	}

	#endregion

	#region Class: SaveBulkEmailHeadersRequest

	/// <summary>
	/// Represents DTO to save replica headers.
	/// </summary>
	[DataContract]
	public class CopyBulkEmailHeadersRequest
	{
		/// <summary>
		/// Gets or sets the identifier of new bulk email.
		/// </summary>
		[DataMember]
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Gets or sets the identifier of source bulk email.
		/// </summary>
		[DataMember]
		public Guid SourceBulkEmailId { get; set; }
	}

	#endregion

	#region Class: SaveBulkEmailHeadersRequest

	/// <summary>
	/// Represents DTO to save replica headers.
	/// </summary>
	[DataContract]
	public class SaveBulkEmailHeadersRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the bulk email identifier.
		/// </summary>
		[DataMember]
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Gets or sets the headers array.
		/// </summary>
		[DataMember]
		public ReplicaHeaders[] Headers { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetBulkEmailHeadersRequest

	/// <summary>
	/// Represents DTO to get replica headers.
	/// </summary>
	[DataContract]
	public class GetBulkEmailHeadersRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the bulk email identifier.
		/// </summary>
		[DataMember]
		public Guid BulkEmailId { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetBulkEmailHeadersResponse

	/// <summary>
	/// Represents DTO to save replica headers.
	/// </summary>
	[DataContract]
	public class GetBulkEmailHeadersResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the headers array.
		/// </summary>
		[DataMember]
		public ReplicaHeaders[] Headers { get; set; }

		/// <summary>
		/// Gets or sets default headers.
		/// </summary>
		[DataMember]
		public EmailHeaders DefaultHeaders { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReplicaHeadersResponse

	/// <summary>
	/// Represents DTO to get replica headers.
	/// </summary>
	[DataContract]
	public class GetReplicaHeadersResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the replica headers.
		/// </summary>
		[DataMember(Name = "headers")]
		public ReplicaHeaders[] Headers { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReplicaHeaders

	/// <summary>
	/// Represents DTO of headers for the bulk email template replica.
	/// </summary>
	[DataContract]
	public class ReplicaHeaders : EmailHeaders
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the replica mask.
		/// </summary>
		[DataMember]
		public int ReplicaMask { get; set; }

		/// <summary>
		/// Gets or sets the replica id.
		/// </summary>
		[DataMember]
		public Guid ReplicaId { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Performs an implicit conversion from <see cref="ReplicaHeaderModel"/> to <see cref="ReplicaHeaders"/>.
		/// </summary>
		/// <param name="headersModel">The headers model.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator ReplicaHeaders(ReplicaHeaderModel headersModel) {
			return new ReplicaHeaders {
				Preheader = headersModel.Preheader,
				SenderName = headersModel.SenderName,
				SenderEmail = headersModel.SenderEmail,
				ReplicaMask = headersModel.ReplicaMask,
				Subject = headersModel.Subject,
				ReplicaId = headersModel.ReplicaId
			};
		}

		#endregion

	}

	#endregion

	#region Class: EmailHeaders

	/// <summary>
	/// Represents DTO of headers for the bulk email template.
	/// </summary>
	[DataContract]
	public class EmailHeaders
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets sender name.
		/// </summary>
		[DataMember]
		public string SenderName { get; set; }

		/// <summary>
		/// Gets or sets sender email.
		/// </summary>
		[DataMember]
		public string SenderEmail { get; set; }

		/// <summary>
		/// Gets or sets the email subject.
		/// </summary>
		[DataMember]
		public string Subject { get; set; }

		/// <summary>
		/// Gets or sets the email preheader.
		/// </summary>
		[DataMember]
		public string Preheader { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Performs an implicit conversion from <see cref="EmailHeaderModel"/> to <see cref="EmailHeaders"/>.
		/// </summary>
		/// <param name="headersModel">The headers model.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator EmailHeaders(EmailHeaderModel headersModel) {
			return new EmailHeaders {
				Preheader = headersModel.Preheader,
				SenderName = headersModel.SenderName,
				SenderEmail = headersModel.SenderEmail,
				Subject = headersModel.Subject
			};
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailTemplateServiceResponse

	/// <summary>
	/// ############ ##### ########## ########## ###### GetEmailTemplateConfig.
	/// </summary>
	[DataContract]
	public class BulkEmailTemplateServiceResponse
	{

		#region Properties: Public

		/// <summary>
		/// ######### ##########.
		/// </summary>
		[DataMember]
		public bool Success { get; set; }

		/// <summary>
		/// ##### ######.
		/// </summary>
		[DataMember]
		public string Message { get; set; }

		/// <summary>
		/// ######## #######.
		/// </summary>
		[DataMember]
		public string TemplateSubject { get; set; }

		/// <summary>
		/// ######### #######.
		/// </summary>
		[DataMember]
		public string TemplateConfig { get; set; }

		/// <summary>
		/// ######### #######.
		/// </summary>
		[DataMember]
		public string TemplateBody { get; set; }

		#endregion

	}

	#endregion

	#region Class: EmailTemplateResponse

	/// <summary>
	/// Represents email template properties response
	/// </summary>
	[DataContract]
	public class EmailTemplateResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the template configuration.
		/// </summary>
		[DataMember]
		public string TemplateConfig { get; set; }

		/// <summary>
		/// Gets or sets the template body.
		/// </summary>
		[DataMember]
		public string TemplateBody { get; set; }

		/// <summary>
		/// Gets or sets the template subject.
		/// </summary>
		[DataMember]
		public string TemplateSubject { get; set; }

		#endregion

	}

	#endregion

	#region Class: UnsubscribeMacrosResponse

	/// <summary>
	/// Represents the class for describe result for GetUnsubscribeMacros.
	/// </summary>
	[DataContract]
	public class UnsubscribeMacrosResponse
	{

		#region Properties: Public

		/// <summary>
		/// Macros templates.
		/// </summary>
		[DataMember]
		public string[] Macros { get; set; }

		#endregion

	}

	#endregion

	#region Class: Replica

	[DataContract]
	public class Replica
	{

		#region Properties: Public

		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Mask { get; set; }

		[DataMember]
		public int RecipientCount { get; set; }

		#endregion

	}

	#endregion

	#region Class: SentDcReplicasResponse

	[DataContract]
	public class DcReplicasResponse
	{

		#region Properties: Public

		[DataMember(Name = "replicas")]
		public Replica[] Replicas { get; set; }

		#endregion

	}

	#endregion

	#region Class: SaveBulkEmailHyperlinkRequest

	/// <summary>
	/// Represents DTO for saving hyperlinks of bulk email.
	/// </summary>
	[DataContract]
	public class SaveBulkEmailHyperlinkRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the bulk email identifier.
		/// </summary>
		[DataMember]
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Gets or sets the hyperlinks.
		/// </summary>
		[DataMember]
		public HyperlinkData[] Hyperlinks { get; set; }

		#endregion

	}

	#endregion

}
