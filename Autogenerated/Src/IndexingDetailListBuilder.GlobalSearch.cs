namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: IndexingDetailListBuilder

	/// <summary>
	/// Builds the indexed details.
	/// </summary>
	public class IndexingDetailListBuilder : IndexingEntityListBuilder
	{

		#region Properties: Protected

		/// <summary>
		/// Default indexing type of the entity.
		/// </summary>
		protected override IndexingType DefaultIndexingType {
			get {
				return IndexingType.Upsert;
			}
		}

		/// <summary>
		/// Simple indexation details.
		/// </summary>
		protected Dictionary<string, string> _simpleDetails;
		protected virtual Dictionary<string, string> SimpleDetails {
			get {
				return _simpleDetails ?? (_simpleDetails = new Dictionary<string, string> {
					{ "ContactAddress", "Contact" },
					{ "AccountAddress", "Account" },
					{ "AccountBillingInfo", "Account" }
				});
			}
		}

		/// <summary>
		/// Communication indexation details.
		/// </summary>
		protected Dictionary<string, string>  _communicationDetails;
		protected virtual Dictionary<string, string> CommunicationDetails {
			get {
				return _communicationDetails ?? (_communicationDetails = new Dictionary<string, string> {
					{ "ContactCommunication", "Contact" },
					{ "AccountCommunication", "Account" }
				});
			}
		}

		/// <summary>
		/// Communication column aliases list.
		/// </summary>
		protected Dictionary<string, FilterComparisonType> _communicationNumberColumnAliases;
		protected virtual Dictionary<string, FilterComparisonType> CommunicationNumberColumnAliases {
			get {
				return _communicationNumberColumnAliases ?? (_communicationNumberColumnAliases = new Dictionary<string, FilterComparisonType> {
					{"phone_numbercolumn", FilterComparisonType.Equal},
					{"text", FilterComparisonType.NotEqual}
				});
			}
		}

		/// <summary>
		/// Communication number column name.
		/// </summary>
		protected string _communicationNumberColumnName;
		protected virtual string CommunicationNumberColumnName {
			get {
				return _communicationNumberColumnName ?? (_communicationNumberColumnName = "Number");
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the <see cref="UserConnection" /> class.</summary>
		public IndexingDetailListBuilder(UserConnection userConnection)
			: base(userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets referance entity name of the detail name.
		/// </summary>
		/// <param name="detailNameWithSuffix">Detail name with suffix.</param>
		/// <returns>Detail parent schema name.</returns>
		private string GetDetailParentSchemaName(string detailNameWithSuffix) {
			var detail = GetDetailByName(detailNameWithSuffix);
			return detail.Value;
		}

		/// <summary>
		/// Gets key value pair detail by detail name.
		/// </summary>
		/// <param name="detailNameWithSuffix">Detail name with suffix.</param>
		/// <returns>Custom or simple detail.</returns>
		private KeyValuePair<string, string> GetDetailByName(string detailNameWithSuffix) {
			var simpleDetail = SimpleDetails.FirstOrDefault(d => detailNameWithSuffix == d.Key);
			var communicationDetail = CommunicationDetails.FirstOrDefault(d => detailNameWithSuffix.StartsWith(d.Key));
			return simpleDetail.Equals(default(KeyValuePair<string, string>)) ? communicationDetail : simpleDetail;
		}

		/// <summary>
		/// Preparies simple details entities queries.
		/// </summary>
		private void PrepareSimpleDetailsEntityQueries() {
			foreach (var detail in SimpleDetails) {
				EntitySchemaQuery esq = PrepareDetailEsq(detail);
				if (esq != null) {
					EntityQueries.Add(detail.Key, esq);
				}
			}
		}

		/// <summary>
		/// Applies details modifiedOn filters.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> instance.</param>
		/// <param name="parentColumnName">Parent entity column name.</param>
		private void ApplyDetailsModifiedOnFilters(EntitySchemaQuery esq, string parentColumnName) {
			var detailSchema = esq.RootSchema;
			var filterEsq = new EntitySchemaQuery(detailSchema);
			filterEsq.PrimaryQueryColumn.IsAlwaysSelect = false;
			filterEsq.IsDistinct = true;
			filterEsq.AddColumn(parentColumnName);
			ApplyModifiedOnFilters(filterEsq);
			esq.Filters.Add(esq.CreateFilter(FilterComparisonType.Equal, parentColumnName, filterEsq));
		}

		/// <summary>
		/// Gets column name by aggregation task id.
		/// </summary>
		/// <param name="detailName">Detail name.</param>
		/// <param name="columnName">Column name.</param>
		/// <param name="detailSuffix">Detail suffix name.</param>
		/// <returns></returns>
		private string GetAggregationIdColumnName(string detailName, string columnName, string detailSuffix = "") {
			string format = string.IsNullOrEmpty(detailSuffix) ? "{0}{1}_{2}" : "{0}_{1}_{2}";
			return string.Format(format, detailName, detailSuffix, columnName);
		}

		/// <summary>
		/// Preparies communication details entities queries.
		/// </summary>
		/// <param name="filterType">Filter type.</param>
		/// <param name="numberColumnAlias">Alias name of the number column.</param>
		private void PrepareCommunicationDetailEntityQueries(FilterComparisonType filterType, string numberColumnAlias) {
			foreach (var detail in CommunicationDetails) {
				EntitySchemaQuery esq = PrepareDetailEsq(detail, numberColumnAlias);
				if (esq != null) {
					ApplyDetailPhoneFilter(esq, filterType);
					var numberColumn = esq.Columns.FindByName(CommunicationNumberColumnName);
					if (numberColumn == null) {
						continue;
					}
					string numberColumnAliasWrap = GetColumnAliasWrapper(numberColumnAlias);
					numberColumn.SetForcedQueryColumnValueAlias(numberColumnAliasWrap);
					var key = string.Format("{0}_{1}", detail.Key, numberColumnAlias);
					EntityQueries.Add(key, esq);
				}
			}
		}

		/// <summary>
		/// Adds esq detail phone filter.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		/// <param name="filterComparisonType"><see cref="FilterComparisonType"/> filterComparisonType.</param>
		private void ApplyDetailPhoneFilter(EntitySchemaQuery esq, FilterComparisonType filterComparisonType) {
			EntitySchemaQueryFilterCollection esqFilters = new EntitySchemaQueryFilterCollection(esq);
			Guid phoneTypeId = new Guid(CommunicationTypeConsts.CommunicationPhoneId);
			Guid smsTypeId = new Guid(CommunicationTypeConsts.CommunicationSmsId);
			esqFilters.Add(esq.CreateFilterWithParameters(filterComparisonType,
				"[ComTypebyCommunication:CommunicationType:CommunicationType].[Communication:Id:Communication].Id",
				phoneTypeId, smsTypeId));
			esq.Filters.Add(esqFilters);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Prepare detail esq.
		/// </summary>
		/// <param name="detail">Custom or simple detail.</param>
		/// <param name="detailSuffix">Detail suffix name.</param>
		/// <returns><see cref="EntitySchemaQuery"/>prepared esq.</returns>
		protected virtual EntitySchemaQuery PrepareDetailEsq(KeyValuePair<string, string> detail, string detailSuffix = "") {
			string parentSchemaName = detail.Value;
			EntitySchema detailEntitySchema = _userConnection.EntitySchemaManager.FindInstanceByName(detail.Key);
			EntitySchema parentSchema = _userConnection.EntitySchemaManager.FindInstanceByName(parentSchemaName);
			if (detailEntitySchema == null || parentSchema == null) {
				return null;
			}
			EntitySchemaQuery esq = GetDefEsq(detailEntitySchema);
			string idColumn = GetDetailParentColumnName(detail, "{0}.{1}");
			var parentColumnAliasWrap = GetColumnAliasWrapper(parentSchema.PrimaryColumn.Name);
			esq.AddColumn(idColumn).OrderByAsc().SetForcedQueryColumnValueAlias(parentColumnAliasWrap);
			ApplyDetailsModifiedOnFilters(esq, idColumn);
			ApplyNextPrimaryColumnFilter(esq, idColumn);
			return esq;
		}

		/// <summary>
		/// Gets detail column name of the parent schema.
		/// </summary>
		/// <param name="detail">Simple or custom detail.</param>
		/// <param name="columnTemplate">Column template path.</param>
		/// <returns></returns>
		protected string GetDetailParentColumnName(KeyValuePair<string, string> detail, string columnTemplate) {
			string parentSchemaName = detail.Value;
			EntitySchema parentSchema = _userConnection.EntitySchemaManager.FindInstanceByName(parentSchemaName);
			if (parentSchema == null) {
				return string.Empty;
			}
			string columnName = string.Format(columnTemplate, parentSchema.Name, parentSchema.PrimaryColumn.Name);
			return columnName;
		}

		/// <summary>
		/// Adds primary lookup column to entity schema query.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/>column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		protected override void AddPrimaryLookupColumn(EntitySchema entitySchema, EntitySchemaColumn column, EntitySchemaQuery esq) {}

		/// <summary>
		/// Adds primary image lookup column to entity schema query.
		/// </summary>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <param name="column"><see cref="EntitySchemaColumn"/>column.</param>
		/// <param name="esq"><see cref="EntitySchemaQuery"/>esq.</param>
		protected override void AddPrimaryImageLookupColumn(EntitySchema entitySchema, EntitySchemaColumn column, EntitySchemaQuery esq) {}

		/// <summary>
		/// Check column is a indexed.
		/// </summary>
		/// <param name="column"><see cref="EntitySchemaColumn"/>Checking column.</param>
		/// <param name="entitySchema"><see cref="EntitySchema"/>entitySchema.</param>
		/// <returns>True if column is indexed.</returns>
		protected override bool GetIsIndexedColumn(EntitySchemaColumn column, EntitySchema entitySchema) {
			if (IgnoredEntityList.GetIsIgnoredColumn(entitySchema, column)) {
				return false;
			}
			string parentSchemaName = GetDetailParentSchemaName(entitySchema.Name);
			if (column.ReferenceSchema != null && column.ReferenceSchema.Name == parentSchemaName) {
				return false;
			}
			return GlobalSearchColumnUtils.IsIndexedColumnType(column);;
		}

		/// <summary>
		/// Prepares entities queries. 
		/// </summary>
		protected override void PrepareEntityQueries() {
			PrepareSimpleDetailsEntityQueries();
			foreach (var columnAlias in CommunicationNumberColumnAliases) {
				PrepareCommunicationDetailEntityQueries(columnAlias.Value, columnAlias.Key);
			}
		}

		/// <summary>
		/// Gets parent schema.
		/// </summary>
		/// <param name="schema"><see cref="EntitySchema"/>schema.</param>
		/// <returns>Parent schema if schema is a detail.</returns>
		protected override string GetParentSchemaName(EntitySchema schema) {
			string schemaName = schema.Name;
			return CommunicationDetails.GetValueOrDefault(schemaName, default(string)) 
				?? SimpleDetails.GetValueOrDefault(schemaName, default(string));
		}

		/// <summary>
		/// Applies and return  entity schema query modifiedOn filter collection.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> esq.</param>
		/// <returns><see cref="EntitySchemaQueryFilterCollection"/> entity schema query modifiedOn filter collection.</returns>
		protected override EntitySchemaQueryFilterCollection ApplyModifiedOnFilters(EntitySchemaQuery esq) {
			EntitySchemaQueryFilterCollection esqFilters = base.ApplyModifiedOnFilters(esq);
			string parentSchemaName = GetParentSchemaName(esq.RootSchema);
			var parentSchema = _userConnection.EntitySchemaManager.FindInstanceByName(parentSchemaName);
			var modifiedOnColumn = parentSchema.ModifiedOnColumn;
			if (ModifiedOnLookupFilterEnabled && modifiedOnColumn != null) {
				string modifiedOnColumnPath = string.Format("{0}.{1}", parentSchemaName, modifiedOnColumn.Name);
				esqFilters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Between, modifiedOnColumnPath, _fromSqlDateTimeMacro, _toSqlDateTimeMacro));
			}
			return esqFilters;
		}

		#endregion

	}

	#endregion
}

