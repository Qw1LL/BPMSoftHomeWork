namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	
	#region Class: SingleIndexingDetailListBuilder
	
	public class SingleIndexingDetailListBuilder : IndexingDetailListBuilder
	{
		
		#region Constructors: Public
		
		/// <inheritdoc/>
		public SingleIndexingDetailListBuilder(UserConnection userConnection) : base(userConnection) {}
		
		#endregion
		
		#region Methods: Protected
		
		/// <inheritdoc/>
		protected override IndexingEntity GetIndexingEntity(KeyValuePair<string, EntitySchemaQuery> entityQuery) {
			var indexingEntity = base.GetIndexingEntity(entityQuery);
			indexingEntity.IsSingle = true;
			return indexingEntity;
		}
		
		/// <inheritdoc/>
		protected override void ApplyPrimaryColumnRule(EntitySchemaQueryColumn primaryEsqColumn,
			EntitySchemaQuery esq, string primaryEsqColumnAlias) {
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, primaryEsqColumnAlias, 
				Guid.Empty, Guid.Empty);
			esq.Filters.Add(filter);
		}
		
		/// <inheritdoc/>
		protected override string GetSqlText(EntitySchemaQuery esq) {
			string sqlText = base.GetSqlText(esq);
			string inFilter = $"'{{{Guid.Empty}}}', '{{{Guid.Empty}}}'";
			return sqlText.Replace(inFilter, _idListMacro);
		}
		
		/// <inheritdoc/>
		protected override EntitySchemaQuery PrepareDetailEsq(KeyValuePair<string, string> detail, string detailSuffix = "") {
			string parentSchemaName = detail.Value;
			EntitySchema detailEntitySchema = _userConnection.EntitySchemaManager.FindInstanceByName(detail.Key);
			EntitySchema parentSchema = _userConnection.EntitySchemaManager.FindInstanceByName(parentSchemaName);
			if (detailEntitySchema == null || parentSchema == null) {
				return null;
			}
			EntitySchemaQuery esq = GetDefEsq(detailEntitySchema);
			string idColumn = GetDetailParentColumnName(detail, "{0}.{1}");
			var parentColumnAliasWrap = GetColumnAliasWrapper(parentSchema.PrimaryColumn.Name);
			esq.AddColumn(idColumn).SetForcedQueryColumnValueAlias(parentColumnAliasWrap);
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, idColumn,  
				Guid.Empty, Guid.Empty);
			esq.Filters.Add(filter);
			return esq;
		}
		
		/// <inheritdoc/>
		protected override int GetDefEsqRowCount() {
			return -1;
		}
		
		#endregion

	}

	#endregion
	
}
