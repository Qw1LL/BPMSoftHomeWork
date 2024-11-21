namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: EntityCreator

	public static class EntityCreator
	{

		#region Fields: Private

		private static string _notMappedFieldsMacros = "not_mapped_fields";
		private static string _columnTypeData = "data";
		private static string _columnTypeMacros = "macros";

		#endregion

		#region Methods: Private

		private static void SetValueToColumn(EntitySchema schema, Entity entity, string entityColumnName, string value) {
			var entityColumn = schema.Columns.FindByName(entityColumnName);
			var typedValue = DataTypeUtilities.ValueAsType(value, entityColumn.ValueType);
			entity.SetColumnValue(entityColumn, typedValue);
		}

		private static void FillColumnValues(EntitySchema schema, Entity entity, LeadNotifyWebhook webhook) {
			webhook.LeadFields?.Where(f => f.Type == _columnTypeData && !string.IsNullOrEmpty(f.EntityColumnName)).ForEach(field => {
				SetValueToColumn(schema, entity, field.EntityColumnName, field.Value);
			});
		}

		private static void FillNotMappedFields(EntitySchema schema, Entity entity, LeadNotifyWebhook webhook) {
			var columnForNotMappedFields = webhook.LeadFields?.Where(f =>
				f.Type == _columnTypeMacros
				&& f.Value == _notMappedFieldsMacros
				&& !string.IsNullOrEmpty(f.EntityColumnName));
			if (columnForNotMappedFields != default && columnForNotMappedFields.Any()) {
				var notMappedFieldsString = string.Empty;
				webhook.LeadFields?.Where(f => string.IsNullOrEmpty(f.EntityColumnName) && f.Type == _columnTypeData)
					.ForEach(notMappedField => {
						notMappedFieldsString += (!string.IsNullOrEmpty(notMappedFieldsString) ? "," : string.Empty)
							+ $"\"{notMappedField.SocialQuestionName}\" : \"{notMappedField.Value}\"";
					});
				if (!string.IsNullOrEmpty(notMappedFieldsString)) {
				columnForNotMappedFields.ForEach(field => {
					 SetValueToColumn(schema, entity, field.EntityColumnName, notMappedFieldsString);
				 });
				}
			}
		}

		#endregion

		#region Methods: Public

		public static bool Create(LeadNotifyWebhook webhook, UserConnection userConnection, out Entity entity) {
			var schema = userConnection.EntitySchemaManager.GetInstanceByName(webhook.EntitySchemaName);
			entity = schema.CreateEntity(userConnection);
			entity.SetDefColumnValues();
			FillColumnValues(schema, entity, webhook);
			FillNotMappedFields(schema, entity, webhook);
			return entity.Save(validateRequired: false);
		}

		#endregion

	}

	#endregion

}

