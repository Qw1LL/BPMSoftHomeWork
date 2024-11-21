namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using Common;
	using Core;
	using GeneratedWebFormService;
	using Core.Entities;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	#region Class: WebFormEventTargetPostProcessHandler

	/// <summary>
	/// Provides post processing for EventTarget landing save.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.IGeneratedWebFormPostProcessHandler" />
	public class WebFormEventTargetPostProcessHandler : IGeneratedWebFormPostProcessHandler
	{
		#region Fields: Private

		private const string _linkedColumnRegex = @"^([\w\d]+)\.([\w\d]+)$";

		private UserConnection _userConnection;
		private List<FormFieldsData> _formFields;
		private Entity _rootEntity;
		private EntitySchema _rootSchema;

		#endregion

		#region Properties: Protected

		protected virtual string SourceSchemaName {
			get {
				return "EventTarget";
			}
		}

		#endregion

		#region Methods: Private

		private bool IsLinkedColumn(string columnName) {
			return Regex.IsMatch(columnName, _linkedColumnRegex);
		}

		private string GetLinkedColumnEntityName(string columnName) {
			return GetLinkedColumnPart(columnName, 1);
		}

		private static string GetLinkedColumnPart(string columnName, int groupNumber) {
			Match match = Regex.Match(columnName, _linkedColumnRegex);
			return match.Groups[groupNumber].Value;
		}

		private string GetLinkedEntityColumnName(string columnName) {
			return GetLinkedColumnPart(columnName, 2);
		}

		private Guid GetNewLinkedEntityId(List<FormFieldsData> formFields, EntitySchemaColumn linkedColumn) {
			var entityIdField = FindLinkedEntityIdFieldData(formFields, linkedColumn);
			Guid idValue = entityIdField.value.IsValidGuid()
				? Guid.Parse(entityIdField.value)
				: Guid.NewGuid();
			return idValue;
		}

		private FormFieldsData FindLinkedEntityIdFieldData(List<FormFieldsData> formFields, EntitySchemaColumn linkedColumn) {
			var entityIdField = formFields.FirstOrDefault(field =>
				field.name == linkedColumn.ColumnValueName ||
				field.name == linkedColumn.Name
				);
			entityIdField = entityIdField ?? new FormFieldsData();
			return entityIdField;
		}

		private void SetEntityValues(IEnumerable<FormFieldsData> columnValues, Entity linkedEntity) {
			columnValues.ForEach(columnValue => {
				string columnName = GetLinkedEntityColumnName(columnValue.name);
				var linkedEntityColumn = GetSchemaColumnByName(columnName, linkedEntity.Schema);
				if (linkedEntityColumn == null) {
					return;
				}
				SetEntityColumnValue(linkedEntity, linkedEntityColumn, columnValue);
			});
		}

		private void SetEntityColumnValue(Entity linkedEntity, EntitySchemaColumn linkedEntityColumn, FormFieldsData columnValue) {
			if (linkedEntityColumn.IsLookupType) {
				Guid idValue = WebFormHelper.GetItemIdFromDictionary(linkedEntityColumn.ReferenceSchema.Name,
						columnValue.value, _userConnection);
				if (!idValue.Equals(Guid.Empty)) {
					linkedEntity.SetColumnValue(linkedEntityColumn, idValue);
				}
			} else {
				linkedEntity.SetColumnValue(linkedEntityColumn, columnValue.value);
			}
		}

		private EntitySchemaColumn GetSchemaColumnByName(string columnName, EntitySchema schema) {
			EntitySchemaColumnCollection columns = schema.Columns;
			return columns.FindByName(columnName) ?? columns.FindByColumnValueName(columnName);
		}

		#endregion

		#region Methods: Protected

		protected virtual Entity GetEntity(Guid entityId, EntitySchema schema = null) {
			schema = schema ?? _rootSchema;
			var linkedEntity = schema.CreateEntity(_userConnection);
			return linkedEntity.FetchFromDB(entityId) ? linkedEntity : null;
		}

		protected void SetUpLinkedEntity(string columnName, IEnumerable<FormFieldsData> linkedColumns) {
			EntitySchemaColumn linkedColumn = GetSchemaColumnByName(columnName, _rootSchema);
			if (linkedColumn == null || !linkedColumn.IsLookupType) {
				return;
			}
			var linkedEntityId = _rootEntity.GetTypedColumnValue<Guid>(linkedColumn.ColumnValueName);
			Entity linkedEntity = GetEntity(linkedEntityId, linkedColumn.ReferenceSchema);
			EntitySchema linkedSchema = linkedColumn.ReferenceSchema;
			if (linkedEntity == null) {
				linkedEntity = CreateLinkedEntity(linkedSchema, linkedColumn);
			}
			var columnValues = linkedColumns.Where(column =>
				GetLinkedColumnEntityName(column.name) == columnName);
			SetEntityValues(columnValues, linkedEntity);
			linkedEntity.Save(false);
		}

		protected virtual Entity CreateLinkedEntity(EntitySchema linkedSchema, EntitySchemaColumn linkedColumn) {
			Entity linkedEntity = linkedSchema.CreateEntity(_userConnection);
			linkedEntity.SetDefColumnValues();
			Guid idValue = GetNewLinkedEntityId(_formFields, linkedColumn);
			linkedEntity.SetColumnValue("Id", idValue);
			_rootEntity.SetColumnValue(linkedColumn, idValue);
			return linkedEntity;	
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes the specified user connection.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="landingId">The landing identifier.</param>
		/// <param name="formData">The form data.</param>
		/// <param name="entityId">The entity identifier.</param>
		public void Execute(UserConnection userConnection, Guid landingId, FormFieldsData[] formData, Guid entityId) {
			_userConnection = userConnection;
			_rootSchema = userConnection.EntitySchemaManager.GetInstanceByName(SourceSchemaName);
			_rootEntity = GetEntity(entityId);
			if (_rootEntity == null) {
				return;
			}
			_formFields = formData.ToList();
			IEnumerable<FormFieldsData> linkedColumns = _formFields.Where(field => IsLinkedColumn(field.name));
			IEnumerable<string> lookupColumnNames = linkedColumns
				.Select(lc => GetLinkedColumnEntityName(lc.name))
				.Distinct();
			foreach (string columnName in lookupColumnNames) {
				SetUpLinkedEntity(columnName, linkedColumns);
			}
			_rootEntity.Save();
		}

		#endregion

	}

	#endregion

}

