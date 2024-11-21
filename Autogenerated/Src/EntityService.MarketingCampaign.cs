namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Common;

	#region Class: EntityService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EntityService : BaseService
	{

		#region Methods: Public

		/// <summary>
		///  ### ########## ####### ####### ###### # ##
		/// </summary>
		/// <param name="entityContainer">{"EntityName" : "", "EntityOperation" : "", "EntityStructure": [{ "Key":"", "Value":"" }, { "Key":"", "Value":"" }]}</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ExecRequest", BodyStyle = WebMessageBodyStyle.Bare,
				 RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public EntityServiseResponse ExecRequest(EntityContainer entityContainer) {
			var result = new EntityServiseResponse();
			try {
				var schemaObject = UserConnection.EntitySchemaManager.GetItems().FirstOrDefault(x => x.Caption.Value == entityContainer.EntityName);
				if (schemaObject == null) {
					throw new Exception(string.Format("Схема с названием {0} не найдена.", entityContainer.EntityName));
				}
				var schema = UserConnection.EntitySchemaManager.FindInstanceByUId(schemaObject.UId);
				if (entityContainer.EntityOperation == EntityOperations.InsertIfNotExist) {
					var primaryDisplayColumnName = schema.GetPrimaryDisplayColumnName();
					var primaryDisplayColumnCaption = schema.FindSchemaColumnByPath(primaryDisplayColumnName).Caption.Value;
					if (!entityContainer.EntityStructure.ContainsKey(primaryDisplayColumnCaption)) {
						throw new Exception(string.Format("Не указано поле {0}, по которому выполняется проверка существования записи.", primaryDisplayColumnCaption));
					}
					var entityCollection = FindEntityByPrimaryDisplay(schema, entityContainer.EntityStructure[primaryDisplayColumnCaption]);
					if (entityCollection.Count > 0) {
						result.Success = true;
						return result;
					}
				}

				var entity = schema.CreateEntity(UserConnection);
				entity.SetDefColumnValues();
				foreach (var field in entityContainer.EntityStructure) {
					if (string.IsNullOrEmpty(field.Value)) {
						continue;
					}
					var schemaColumn = schema.Columns.FirstOrDefault(x => x.Caption.Value == field.Key);
					if (schemaColumn != null) {
						if (schemaColumn.IsLookupType) {
							var referenceSchema = schemaColumn.ReferenceSchema;
							var id = GetIdByPrimaryDisplay(referenceSchema, field.Value);
							entity.SetColumnValue(schemaColumn.ColumnValueName, id);
						} else if (schemaColumn.DataValueType.ValueType == typeof(DateTime)) {
							entity.SetColumnValue(schemaColumn.Name, Convert.ToDateTime(field.Value));
						} else if (schemaColumn.DataValueType.ValueType == typeof(Boolean)) {
							entity.SetColumnValue(schemaColumn.Name, Convert.ToBoolean(field.Value));
						} else if (schemaColumn.DataValueType.ValueType == typeof(Int32)) {
							entity.SetColumnValue(schemaColumn.Name, Convert.ToInt32(field.Value));
						} else if (schemaColumn.DataValueType.ValueType == typeof(Decimal)) {
							entity.SetColumnValue(schemaColumn.Name, Convert.ToDecimal(field.Value));
						} else if (schemaColumn.DataValueType.ValueType == typeof(String)) {
							entity.SetColumnValue(schemaColumn.Name, Convert.ToString(field.Value));
						}
					} else {
						throw new Exception(string.Format("Поле с именем {0} для объекта {1} не найдено в схеме.", field.Key, entityContainer.EntityName));
					}
				}
				entity.Validate();
				if (entity.ValidationMessages.HasErrors()) {
					var errors = entity.ValidationMessages.Select(x => x.Text).Aggregate((a, b) => a + "; " + b);
					throw new Exception(string.Format("Ошибка при валидации записи: {0}.", errors));
				}
				if (!entity.Save()) {
					throw new Exception(string.Format("Ошибка при сохранении."));
				}
				result.Success = true;
			} catch (Exception ex) {
				result.Success = false;
				result.ErrorDescription = ex.Message;
			}
			return result;
		}

		#endregion

		#region Methods: Private

		private Guid GetIdByPrimaryDisplay(EntitySchema entitySchema, string primaryDisplayValue) {
			var result = Guid.Empty;
			var entityCollection = FindEntityByPrimaryDisplay(entitySchema, primaryDisplayValue);
			if (entityCollection.Count == 0) {
				throw new Exception(string.Format("Для справочного поля не найдена ссылающая запись со значением {0}.", primaryDisplayValue));
			} else if (entityCollection.Count > 1) {
				throw new Exception(string.Format("Для справочного поля найдено несколько ссылающихся записей со значением {0}.", primaryDisplayValue));
			} else {
				result = entityCollection[0].PrimaryColumnValue;
			}
			return result;
		}

		private EntityCollection FindEntityByPrimaryDisplay(EntitySchema entitySchema, string primaryDisplayValue) {
			var ESQ = new EntitySchemaQuery(entitySchema);
			ESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			ESQ.AddColumn(entitySchema.PrimaryDisplayColumn.Name);
			ESQ.Filters.Add(ESQ.CreateFilterWithParameters(FilterComparisonType.Equal, entitySchema.PrimaryDisplayColumn.Name, primaryDisplayValue));
			var entityCollection = ESQ.GetEntityCollection(UserConnection);
			return entityCollection;
		}

		#endregion

	}

	#endregion

	#region Class: DataContract

	[DataContract]
	public class EntityContainer {

		[DataMember(Order = 0)]
		public string EntityName {
			get;
			set;
		}

		[DataMember(Order = 1)]
		public EntityOperations EntityOperation {
			get;
			set;
		}

		[DataMember(Order = 2)]
		public Dictionary<string, string> EntityStructure {
			get;
			set;
		}

	}

	[DataContract]
	public class EntityServiseResponse {

		[DataMember(Order = 0)]
		public bool Success {
			get;
			set;
		}

		[DataMember(Order = 1)]
		public string ErrorDescription {
			get;
			set;
		}

	}

	public enum EntityOperations {
		Insert = 1,
		InsertIfNotExist = 2
	}

	#endregion
}

