namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ChildImportEntitiesGetter

	/// <summary>
	/// An instance of this class is responsible for getting child import entities.
	/// </summary>
	[DefaultBinding(typeof(IChildImportEntitiesGetter), Name = nameof(ChildImportEntitiesGetter))]
	public class ChildImportEntitiesGetter : ImportEntitiesGetter, IChildImportEntitiesGetter
	{

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="PrimaryImportEntitiesGetter"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="columnsProcessor">Columns processor.</param>
		public ChildImportEntitiesGetter(UserConnection userConnection, IColumnsAggregatorAdapter columnsProcessor)
			: base(userConnection, columnsProcessor) {
		}

		#endregion

		#region Properties: Protected

		private Dictionary<EntitySchema, EntitySchemaQuery> _childEntitiesQueries;

		/// <summary>
		/// Child entities search queries.
		/// </summary>
		protected Dictionary<EntitySchema, EntitySchemaQuery> ChildEntitiesQueries {
			get {
				return _childEntitiesQueries ?? 
					(_childEntitiesQueries = new Dictionary<EntitySchema, EntitySchemaQuery>());
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets destination attribute column name.
		/// </summary>
		/// <param name="destination">Import column destination.</param>
		/// <param name="schema">EntitySchema.</param>
		/// <returns>Destination attribute column name.</returns>
		private string GetDestinationAttributeColumnName(ImportColumnDestination destination, EntitySchema schema) {
			string attributeColumnValueName = destination.FindAttributeColumnValueName();
			return schema.Columns
				.Where(column => column.ColumnValueName.Equals(attributeColumnValueName))
				.Select(column => column.Name)
				.First();
		}

		/// <summary>
		/// Creates child entity filters.
		/// </summary>
		/// <param name="esq">Entity schema query.</param>
		/// <param name="importEntity">Import entity.</param>
		/// <param name="destination">Import column destination.</param>
		/// <param name="valueForSave">Value for save.</param>
		/// <returns>Child entity filters.</returns>
		private EntitySchemaQueryFilterCollection CreateChildEntityFilters(EntitySchemaQuery esq,
				ImportEntity importEntity, Dictionary<string, object> keyColumnsValues) {
			EntitySchemaQueryFilterCollection filters = new EntitySchemaQueryFilterCollection(esq);
			foreach (KeyValuePair<string, object> keyColumnValue in keyColumnsValues) {
				IEntitySchemaQueryFilterItem filterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					keyColumnValue.Key, keyColumnValue.Value);
				filters.Add(filterItem);
			}
			return filters;
		}

		/// <summary>
		/// Gets schemas key columns values.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <param name="importEntity">Import entity.</param>
		/// <returns>Schemas key columns values.</returns>
		private SchemasKeyColumnsValues GetSchemasKeyColumnsValues(
				ImportParameters parameters, ImportEntity importEntity) {
			var schemasKeyColumnsValues = new SchemasKeyColumnsValues();
			foreach (ImportColumn column in parameters.Columns) {
				ImportColumnValue columnValue = importEntity.FindColumnValue(column);
				if (columnValue == null) {
					continue;
				}
				foreach (ImportColumnDestination destination in column.Destinations) {
					Guid schemaUId = destination.SchemaUId;
					if (schemaUId.Equals(parameters.RootSchemaUId)) {
						continue;
					}
					object valueForSave = ColumnsProcessor.FindValueForSave(destination, columnValue);
					if (valueForSave == null) {
						continue;
					}
					EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
					EntitiesKeyColumnsValues entitiesKeyColumnsValues;
					if (!schemasKeyColumnsValues.TryGetValue(schema, out entitiesKeyColumnsValues)) {
						entitiesKeyColumnsValues = new EntitiesKeyColumnsValues();
						schemasKeyColumnsValues.Add(schema, entitiesKeyColumnsValues);
					}
					int destinationIndex = destination.GetIndex();
					object attributeColumnValue = destination.FindAttributeColumnValue();
					string destinationKey = string.Concat(destinationIndex, attributeColumnValue);
					KeyColumnsValues keyColumnsValues;
					if (!entitiesKeyColumnsValues.TryGetValue(destinationKey, out keyColumnsValues)) {
						keyColumnsValues = new KeyColumnsValues();
						entitiesKeyColumnsValues.Add(destinationKey, keyColumnsValues);
					}
					keyColumnsValues.Add(destination.ColumnName, valueForSave);
					string attributeColumnName = GetDestinationAttributeColumnName(destination, schema);
					if (!keyColumnsValues.ContainsKey(attributeColumnName)) {
						keyColumnsValues.Add(attributeColumnName, attributeColumnValue);
					}
					EntitySchemaColumn connectionColumn = importEntity.GetReferenceColumn(schema);
					string connectionColumnName = connectionColumn.Name;
					if (!keyColumnsValues.ContainsKey(connectionColumnName)) {
						Guid primaryColumnValue = importEntity.PrimaryEntity.PrimaryColumnValue;
						keyColumnsValues.Add(connectionColumnName, primaryColumnValue);
					}
				}
			}
			return schemasKeyColumnsValues;
		}

		/// <summary>
		/// Adds child entities query filters.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <param name="importEntity">Import entity.</param>
		/// <param name="schemasKeyColumnsValues">Schemas key columns values.</param>
		private void AddChildEntitiesQueryFilters(ImportParameters parameters, ImportEntity importEntity,
				SchemasKeyColumnsValues schemasKeyColumnsValues) {
			foreach (var schemaKeyColumnsValues in schemasKeyColumnsValues) {
				EntitySchema schema = schemaKeyColumnsValues.Key;
				EntitySchemaQuery esq;
				if (!ChildEntitiesQueries.TryGetValue(schema, out esq)) {
					esq = CreateEntitiesSearchQuery(schema);
					ChildEntitiesQueries.Add(schema, esq);
				}
				foreach (var entitiesKeyColumnsValues in schemaKeyColumnsValues.Value) {
					Dictionary<string, object> keyColumnsValues = entitiesKeyColumnsValues.Value;
					EntitySchemaQueryFilterCollection filters = CreateChildEntityFilters(esq, importEntity,
						keyColumnsValues);
					esq.Filters.Add(filters);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IChildImportEntitiesGetter"/>
		public virtual IEnumerable<Entity> Get(ImportParameters parameters) {
			List<Entity> entities = new List<Entity>();
			foreach (ImportEntity importEntity in parameters.Entities) {
				if (importEntity.PrimaryEntity == null) {
					continue;
				}
				SchemasKeyColumnsValues schemasKeyColumnsValues =
					GetSchemasKeyColumnsValues(parameters, importEntity);
				AddChildEntitiesQueryFilters(parameters, importEntity, schemasKeyColumnsValues);
				foreach (EntitySchemaQuery esq in ChildEntitiesQueries.Values) {
					if (esq.Filters.Count >= FileImporterConstants.MaxQueryChildFiltersCount) {
						EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
						entities.AddRange(entityCollection);
						esq.ResetSelectQuery();
						esq.Filters.Clear();
					}
				}
			}
			foreach (EntitySchemaQuery esq in ChildEntitiesQueries.Values) {
				if (esq.Filters.Any()) {
					EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
					entities.AddRange(entityCollection);
				}
			}
			return entities;
		}

		#endregion

		#region Class: KeyColumnsValues

		/// <summary>
		/// An instance of this class represents key columns values.
		/// </summary>
		private class KeyColumnsValues : Dictionary<string, object>
		{
		}

		#endregion

		#region Class: EntitiesKeyColumnsValues

		/// <summary>
		/// An instance of this class represents entities key columns values.
		/// </summary>
		private class EntitiesKeyColumnsValues : Dictionary<string, KeyColumnsValues>
		{
		}

		#endregion

		#region Class: SchemasKeyColumnsValues

		/// <summary>
		/// An instance of this class represents schemas key columns values.
		/// </summary>
		private class SchemasKeyColumnsValues : Dictionary<EntitySchema, EntitiesKeyColumnsValues>
		{
		}

		#endregion

	}

	#endregion

}
