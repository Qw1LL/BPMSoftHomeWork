namespace BPMSoft.Configuration.EntityFilterConverterService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;

	#region Class: EntityFilterConverterService

    /// <summary>
    /// Utility service class for working with <see cref="Entity"/>.
    /// </summary>
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class EntityFilterConverterService : BaseService
    {
        #region Methods: Public

        /// <summary>
        /// Gets the column metaPath by column name.
        /// </summary>
        /// <param name="columnMetaPaths">The column meta paths.</param>
        /// <returns>Dictionary, where key is column metaPath or entity schema uid, value is column path or entity
        /// schema name.</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "columnPaths")]
        public Dictionary<string, string> GetMetaPathsAndEntityNames(Dictionary<string, List<string>> columnMetaPaths) {
            var response = new Dictionary<string, string>();
            EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
            foreach (KeyValuePair<string, List<string>> keyValuePair in columnMetaPaths) {
                string entitySchemaName = keyValuePair.Key;
                EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(entitySchemaName);
                response[entitySchemaName] = entitySchema.UId.ToString();
                List<string> columnPaths = keyValuePair.Value;
                foreach (string columnPath in columnPaths) {
                    response[columnPath] = entitySchema.GetSchemaColumnMetaPathByPath(columnPath);
                }
            }
            return response;
        }

        /// <summary>
        /// Gets the column reference schema uid by metaPath values.
        /// </summary>
        /// <param name="columnMetaPaths">The column meta paths.</param>
        /// <returns>Dictionary, where key is column metaPath or entity schema uid, value is column path or entity
        /// schema name.</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [return: MessageParameter(Name = "columnMetaSchema")]
        public Dictionary<string, Guid> GetColumnReferenceSchemaUIds(Dictionary<string, List<string>> columnMetaSchema) {
            var response = new Dictionary<string, Guid>();
            EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
            foreach (KeyValuePair<string, List<string>> keyValuePair in columnMetaSchema) {
                string entitySchemaName = keyValuePair.Key;
                EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(entitySchemaName);
                List<string> metaPaths = keyValuePair.Value;
                foreach (string metaPath in metaPaths) {
                    EntitySchemaColumn columnPath = entitySchema.GetSchemaColumnByMetaPath(metaPath);
                    response[metaPath] = columnPath.ReferenceSchemaUId;
                }
            }
            return response;
        }
        #endregion
    }

    #endregion

}

