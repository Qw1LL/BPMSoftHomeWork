namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;
	using EntityCollection = Nui.ServiceModel.DataContract.EntityCollection;
	using CoreEntitySchema = Core.Entities.EntitySchema;

	#region Class: BulkEmailAudienceService

	/// <summary>
	/// Manages audience of bulk emails.
	/// </summary>
	[ServiceContract(Name = "BulkEmailAudience")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class BulkEmailAudienceService : BaseService
	{

		#region Properties: Public

		/// <summary>
		/// An instance of <see cref="BulkEmailFacade"/> class.
		/// </summary>
		private BulkEmailFacade _bulkEmailFacade;
		public BulkEmailFacade BulkEmailFacade {
			get => _bulkEmailFacade ?? (_bulkEmailFacade = new BulkEmailFacade(UserConnection));
			set => _bulkEmailFacade = value;
		}

		/// <summary>
		/// An instance of <see cref="IBulkEmailAudienceRepository"/> class.
		/// </summary>
		private IBulkEmailAudienceRepository _audienceRepository;
		public IBulkEmailAudienceRepository AudienceRepository {
			get => _audienceRepository ?? (_audienceRepository = new BulkEmailAudienceRepository(UserConnection));
			set => _audienceRepository = value;
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetAudienceESQ(string esqSerialized, string audienceSchemaName,
				out EntitySchemaQueryOptions options, out Dictionary<string, string> columnNameMap) {
			var selectQuery = Json.Deserialize<SelectQuery>(esqSerialized);
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(selectQuery.RootSchemaName)
				.Clone() as CoreEntitySchema;
			var audienceSchema = UserConnection.EntitySchemaManager
				.GetInstanceByName(audienceSchemaName);
			var column = schema.Columns.FindByName("LinkedEntity");
			column.ReferenceSchema = audienceSchema;
			column.ReferenceSchemaUId = audienceSchema.UId;
			EntitySchemaQuery esq = selectQuery.BuildEsq(schema, UserConnection, out columnNameMap);
			options = null;
			if (selectQuery.IsPageable || selectQuery.IsHierarchical) {
				options = QueryExtension.GetEntitySchemaQueryOptions(selectQuery, columnNameMap, UserConnection);
			} else {
				esq.RowCount = selectQuery.RowCount;
			}
			return esq;
		}

		private AudienceSelectQueryResponse CreateAudienceQueryResponse(Core.Entities.EntityCollection coreEntities,
				Dictionary<string, string> columnNameMap, Dictionary<string, object> rowConfig) {
			EntityCollection entities = QueryExtension.GetEntityCollection(coreEntities, columnNameMap);
			return new AudienceSelectQueryResponse {
				Rows = Json.Serialize(entities, true),
				RowsAffected = entities.Count,
				RowConfig = Json.Serialize(rowConfig, true)
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Imports bulk email audience by the list of entities or folders.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AudienceServiceResponse Import(BulkEmailAudienceImportModel audienceModel) {
			try {
				BulkEmailFacade.AddAudience(audienceModel);
			} catch (Exception e) {
				return new AudienceServiceResponse {
					Success = false,
					Message = e.Message
				};
			}
			return new AudienceServiceResponse();
		}

		/// <summary>
		/// Removes bulk email audience by the list of entities or folders.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AudienceServiceResponse Remove(BulkEmailAudienceRemoveModel audienceModel) {
			try {
				BulkEmailFacade.RemoveAudience(audienceModel);
			} catch (Exception e) {
				return new AudienceServiceResponse {
					Success = false,
					Message = e.Message
				};
			}
			return new AudienceServiceResponse();
		}

		/// <summary>
		/// Checks tasks in bulk email queue.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>True when queue contains tasks for bulk email.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool HasIncompleteTask(Guid bulkEmailId) {
			return BulkEmailFacade.HasIncompleteTask(bulkEmailId);
		}

		/// <summary>
		/// Estimates bulk email queue tasks' execution for specified bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Response with estimated tasks.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public QueueTaskEstimationResponse EstimateTaskExecution(Guid bulkEmailId) {
			var estimation = BulkEmailFacade.EstimateTaskExecution(bulkEmailId);
			return new QueueTaskEstimationResponse {
				Position = estimation.Position,
				EstimatedTime = estimation.EstimatedTime
			};
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AudienceSelectQueryResponse SelectAudience(AudienceSelectQueryModel audienceModel) {
			var bulkEmailId = audienceModel.BulkEmailId;
			var esq = GetAudienceESQ(audienceModel.EsqSerialized, audienceModel.LinkedEntitySchemaName,
				out var options, out var columnNameMap);
			var entities = AudienceRepository.SelectAudience(bulkEmailId, esq,
				audienceModel.DuplicateType, options);
			var rowConfig = QueryExtension.GetColumnConfig(esq, columnNameMap);
			return CreateAudienceQueryResponse(entities, columnNameMap, rowConfig);
		}

		#endregion

	}

	#endregion

	#region Class: AudienceSelectQueryModel

	/// <summary>
	/// Data model for <see cref="BulkEmailAudienceService"/>.
	/// </summary>
	[DataContract]
	public class AudienceSelectQueryModel
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of bulk email.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid BulkEmailId { get; set; }

		/// <summary>
		/// Audience duplicate type.
		/// </summary>
		[DataMember(IsRequired = true)]
		public BulkEmailAudienceDuplicateType DuplicateType { get; set; }

		/// <summary>
		/// Serialized ESQ. Contains JSON that can be deserialized as
		/// <see cref="BPMSoft.Nui.ServiceModel.DataContract.SelectQuery"/>.
		/// </summary>
		[DataMember(IsRequired = true)]
		public string EsqSerialized { get; set; }

		/// <summary>
		/// Name of the linked entity schema.
		/// </summary>
		[DataMember(IsRequired = true)]
		public string LinkedEntitySchemaName { get; set; }

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceImportModel

	/// <summary>
	/// Data model for <see cref="BulkEmailAudienceService"/>.
	/// </summary>
	[DataContract]
	public class BulkEmailAudienceImportModel : BulkEmailAudienceModel
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of bulk email audience schema.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid AudienceSchemaId { get; set; }

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceRemoveModel

	/// <summary>
	/// Data model for <see cref="BulkEmailAudienceService"/>.
	/// </summary>
	[DataContract]
	public class BulkEmailAudienceRemoveModel : BulkEmailAudienceModel
	{

		#region Properties: Public

		/// <summary>
		/// Audience duplicate type.
		/// Default value = 0.
		/// </summary>
		[DataMember(IsRequired = false)]
		public BulkEmailAudienceDuplicateType DuplicateType { get; set; } = 0;

		#endregion

	}

	#endregion

	#region Class: AudienceSelectQueryResponse

	/// <summary>
	/// Response for <see cref="BulkEmailAudienceService"/>.
	/// </summary>
	[DataContract]
	public class AudienceSelectQueryResponse
	{

		#region Properties: Public

		/// <summary>
		/// Execution result. Success by default.
		/// </summary>
		[DataMember]
		public bool Success { get; set; } = true;

		[DataMember]
		public string Rows { get; set; }

		[DataMember]
		public string RowConfig { get; set; }

		[DataMember]
		public int RowsAffected { get; set; }

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceModel

	/// <summary>
	/// Data model for <see cref="BulkEmailAudienceService"/>.
	/// </summary>
	[DataContract]
	public class BulkEmailAudienceModel : BaseAudienceServiceDataModel
	{

		#region Properties: Public

		/// <summary>
		/// Identifier of bulk email.
		/// </summary>
		[DataMember(IsRequired = true)]
		public Guid BulkEmailId { get; set; }

		#endregion

	}

	#endregion

	#region Class: BulkEmailAudienceDuplicateType

	/// <summary>
	/// Audience duplicate types.
	/// </summary>
	[DataContract]
	public enum BulkEmailAudienceDuplicateType
	{
		[EnumMember]
		None = 0,
		[EnumMember]
		Email = 1,
		[EnumMember]
		Contact = 2
	}

	#endregion

}

