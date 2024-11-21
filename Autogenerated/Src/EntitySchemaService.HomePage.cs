namespace BPMSoft.Configuration.EntityDefValues
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.ServiceModel.Activation;
    using System.Linq;
    using System.Runtime.Serialization;
    using BPMSoft.Core;
    using BPMSoft.Core.Entities;
    using BPMSoft.Web.Common;

    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class EntitySchemaService : BaseService
    {

        #region Methods: Private

        private static object SerializeDefaultValue(EntitySchemaColumn schemaColumn, object value) {
            if (schemaColumn.DataValueType is DateTimeDataValueType && value != null) {
                value = value is DateTime dateTime ? DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified) : value;
                return DateTimeDataValueType.Serialize(value, TimeZoneInfo.Utc);
            }
            return value;
        }

        #endregion

        #region Methods: Public

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetEntityDefaultValues?entityName={entityName}",
            BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        public Dictionary<string, object> GetEntityDefaultValues(string entityName) {
            var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
            var entityDefaultValues = entitySchema.Columns.Where(column => column.HasDefValue)
                .ToDictionary(column => column.Name,
                    column => SerializeDefaultValue(column, column.DefValue.Value));
            return entityDefaultValues;
        }

        #endregion

    }

    [DataContract]
    public class ColumnInfo
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "defaultValue")]
        public string DefaultValue;
    }
}

