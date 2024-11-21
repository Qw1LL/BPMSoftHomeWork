namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: EntityUtilsService

	/// <summary>
	/// Utility service class for working with <see cref="Entity"/>.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EntityUtilsService : BaseService
	{

		#region Methods: Private

		/// <summary>
		/// Initializes a new instance of the <see cref="EntityUtilsService"/> class.
		/// </summary>
		/// <returns>A new instance of the <see cref="EntityUtilsService"/> class.</returns>
		private EntityUtilsHelper GetEntityUtilsHelper() {
			return ClassFactory.Get<EntityUtilsHelper>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Copies and links data to the specified entity <paramref name="recipientEntityId"/> from the source
		/// <paramref name="sourceEntityId"/>.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
		/// <param name="columnName">The column name for linking with
		/// <paramref name="sourceEntitySchemaNames"/>.</param>
		/// <param name="entitySchemaName">Entity name of source and recipient.</param>
		/// <param name="sourceEntitySchemaNames">List of entity schema names, from which data will be copied.</param>
		/// <param name="inlineIds">List of ids for inline attachments.</param>
		/// <param name="isOnlyInline">Flag that forces to copy only inline attachments.</param>
		/// <returns>The result of copying.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> CopyEntities(Guid sourceEntityId, Guid recipientEntityId, string columnName,
			string entitySchemaName, List<string> sourceEntitySchemaNames, List<object> inlineIds = null, 
			bool isOnlyInline = false) {
				EntityUtilsHelper helper = GetEntityUtilsHelper();
				Dictionary<string, string> mappingIds = helper.Copy(sourceEntityId, recipientEntityId, columnName,
					entitySchemaName, sourceEntitySchemaNames, inlineIds, isOnlyInline);
				return mappingIds;
		}

		/// <summary>
		/// Gets the column paths by metaPath values.
		/// </summary>
		/// <param name="columnMetaPaths">The column meta paths.</param>
		/// <returns>Dictionary, where key is column metaPath or entity schema uid, value is column path or entity
		/// schema name.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "columnPaths")]
		public Dictionary<string, string> GetColumnPathsAndEntityNames(Dictionary<Guid, List<string>> columnMetaPaths) {
			var response = new Dictionary<string, string>();
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			foreach (KeyValuePair<Guid, List<string>> keyValuePair in columnMetaPaths) {
				Guid entitySchemaUId = keyValuePair.Key;
				EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
				response[entitySchemaUId.ToString()] = entitySchema.Name;
				List<string> metaPaths = keyValuePair.Value;
				foreach (string metaPath in metaPaths) {
					string columnPath = entitySchema.GetSchemaColumnPathByMetaPath(metaPath);
					response[metaPath] = columnPath;
				}
			}
			return response;
		}

		#endregion

	}

	#endregion

}

