namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: IndexingSectionListBuilder
	
	/// <summary>
	/// Builds the indexed sections.
	/// </summary>
	public class IndexingSectionListBuilder : IndexingEntityListBuilder
	{
		#region Constants: Private

		/// <summary>
		/// Type id of the file entity link.
		/// </summary>
		private static readonly Guid _fileEntityLinkTypeId = new Guid("549bc2f8-0ee0-df11-971b-001d60e938c6");

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="UserConnection" /> class.</summary>
		public IndexingSectionListBuilder(UserConnection userConnection) : base(userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Adds file schema query to list.
		/// </summary>
		/// <param name="entitySchema">Section <see cref="EntitySchema"/> instance.</param>
		/// <param name="esqList">List of entityschemaqueries.</param>
		private void AddFileSchemaQuery(EntitySchema entitySchema, List<EntitySchemaQuery> esqList) {
			var fileSchema = FindReferenceFileSchema(entitySchema);
			if (fileSchema == null || fileSchema.Columns.FindByName("Type") == null) {
				return;
			}
			var fileEsq = GetSelectForIndexation(fileSchema);
			fileEsq.Filters.Add(fileEsq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Type", _fileEntityLinkTypeId));
			esqList.Add(fileEsq);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get <see cref="Select"/> query for indexation containing columns with lookup and text data value type.
		/// </summary>
		/// <param name="entitySchema">Section <see cref="EntitySchema"/> with columns.</param>
		/// <returns>Returns <see cref="Select"/> for logstash *.sql file.</returns>
		protected virtual EntitySchemaQuery GetSelectForIndexation(EntitySchema entitySchema) {
			var esq = GetDefEsq(entitySchema);
			ApplyModifiedOnFilters(esq);
			ApplyNextPrimaryColumnFilter(esq, entitySchema.PrimaryColumn.Name);
			return esq;
		}

		/// <summary>
		/// Gets entity schema queries from section uids.
		/// </summary>
		/// <param name="entityUIds"></param>
		/// <returns></returns>
		protected List<EntitySchemaQuery> GetEntitySchemaQueries(List<Guid> entityUIds) {
			var entitySchemaQueries = new List<EntitySchemaQuery>();
			foreach (Guid uId in entityUIds) {
				EntitySchema entitySchema = _userConnection.EntitySchemaManager.FindInstanceByUId(uId);
				if (IgnoredEntityList.GetIsIgnoredSection(entitySchema)) {
					continue;
				}
				var entitySchemaQuery = GetSelectForIndexation(entitySchema);
				entitySchemaQueries.Add(entitySchemaQuery);
				AddFileSchemaQuery(entitySchema, entitySchemaQueries);
			}
			return entitySchemaQueries;
		}

		/// <summary>
		/// Prepares entities queries. 
		/// </summary>
		protected override void PrepareEntityQueries() {
			var entitySchemaQueries = GetEntitySchemaQueries(IndexingSectionsUIds);
            foreach (var esq in entitySchemaQueries) {
				EntitySchema schema = esq.RootSchema;
                if (!EntityQueries.ContainsKey(schema.Name)) {
                    EntityQueries.Add(schema.Name, esq);
                }
            }
            RemoveEmptyEsqList(EntityQueries);
		}

		/// <summary>
		/// Gets parent schema.
		/// </summary>
		/// <param name="schema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Parent schema if schema is a detail.</returns>
		protected override string GetParentSchemaName(EntitySchema schema) {
			return null;
		}

		#endregion

	}

	#endregion
}

