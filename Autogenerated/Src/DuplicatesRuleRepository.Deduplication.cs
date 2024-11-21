namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;
	using BPMSoft.Core.Factories;

	#region Class: DuplicatesRuleRepository

	/// <summary>
	/// Default implementation of the <see cref="IDuplicatesRuleRepository"/> interface.
	/// </summary>
	/// <seealso cref="IDuplicatesRuleRepository"/>
	[DefaultBinding(typeof(IDuplicatesRuleRepository), Name = "Default")]
	public class DuplicatesRuleRepository : IDuplicatesRuleRepository
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Deduplication");
		private EntitySchemaQueryColumn _sourceSchemaColumn;
		private EntitySchemaQueryColumn _schemaNameColumn;
		private EntitySchemaQueryColumn _idSchemaColumn;

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetStructuredESQ(UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "DuplicatesRule") {
				UseAdminRights = false
			};
			esq.AddColumn("Name");
			esq.AddColumn("IsActive");
			esq.AddColumn("UseAtSave");
			esq.AddColumn("RuleBody");
			_idSchemaColumn = esq.AddColumn("Id");
			_schemaNameColumn = esq.AddColumn("[SysSchema:UId:Object].Name");
			_sourceSchemaColumn = esq.AddColumn("[SysSchema:UId:SearchObject].Name");
			return esq;
		}

		private DuplicatesRuleDTO GetDtoFromEntity(Entity duplicateRuleEntity) {
			if (duplicateRuleEntity == null) {
				return null;
			}
			var duplicatesRuleDTO = new DuplicatesRuleDTO {
				Id = duplicateRuleEntity.GetTypedColumnValue<Guid>(_idSchemaColumn.Name),
				IsActive = duplicateRuleEntity.GetTypedColumnValue<bool>("IsActive"),
				UseAtSave = duplicateRuleEntity.GetTypedColumnValue<bool>("UseAtSave"),
				RuleName = duplicateRuleEntity.GetTypedColumnValue<string>("Name"),
				SchemaName = duplicateRuleEntity.GetTypedColumnValue<string>(_schemaNameColumn.Name),
				SearchSchemaName = duplicateRuleEntity.GetTypedColumnValue<string>(_sourceSchemaColumn.Name)
			};
			try {
				var ruleBody = duplicateRuleEntity.GetTypedColumnValue<string>("RuleBody");
				duplicatesRuleDTO.RuleBody = (DuplicatesRuleBody)Json.Deserialize(ruleBody,
					typeof(DuplicatesRuleBody));
			} catch (Exception ex) {
				duplicatesRuleDTO.RuleBody = null;
				_log.Error("Error during retrieving rulebody", ex);
			}
			return duplicatesRuleDTO;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDuplicatesRuleRepository.GetDuplicatesRules"/>
		public IEnumerable<DuplicatesRuleDTO> GetDuplicatesRules(UserConnection userConnection,
				ICacheStore cacheStore) {
			var esq = GetStructuredESQ(userConnection);
			esq.Cache = cacheStore;
			var collection = esq.GetEntityCollection(userConnection);
			return collection.Select(GetDtoFromEntity);
		}

		/// <inheritdoc cref="IDuplicatesRuleRepository.Get"/>
		public DuplicatesRuleDTO Get(UserConnection userConnection, Guid id) {
			var esq = GetStructuredESQ(userConnection);
			var entity = esq.GetEntity(userConnection, id);
			return GetDtoFromEntity(entity);
		}

		public bool Update(DuplicatesRuleDTO dto) {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion

}
