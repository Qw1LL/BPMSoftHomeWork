namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Linq;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.GlobalSearch.Indexing;
	
	#region Class: IndexerFactory

	public class IndexerFactory
	{

		#region Fields: Private

		private readonly AvailableIndexingEntities _availableIndexingEntities;

		#endregion

		#region Constructors: Public

		public IndexerFactory(AvailableIndexingEntities availableIndexingEntities) {
			_availableIndexingEntities = availableIndexingEntities;
		}

		#endregion

		#region Methods: Private

		private bool GetIsRealtedEntityIndexingEnabled(Entity entity) {
			return entity.UserConnection.GetIsFeatureEnabled("GlobalSearchRelatedEntityIndexing");
		}

		private bool CheckIsPrimaryColumnChanged(Entity entity, EntityAfterEventArgs entityAfterEventArgs) {
			var modifiedColumnValues =
				entityAfterEventArgs?.ModifiedColumnValues ?? Enumerable.Empty<EntityColumnValue>();
			var primaryDisplayColumnUid = GetPrimaryDisplayColumnUid(entity);
			if (primaryDisplayColumnUid == null) {
				return false;
			}
			return modifiedColumnValues.Any(column => column.Column.UId == primaryDisplayColumnUid);
		}

		private Guid? GetPrimaryDisplayColumnUid(Entity entity) {
			var entitySchema = entity.Schema;
			var entitySchemaPrimaryDisplayColumn = entitySchema.PrimaryDisplayColumn;
			return entitySchemaPrimaryDisplayColumn?.UId;
		}

		private bool GetIsIndexingDetail(string schemaName) {
			return _availableIndexingEntities.DetailNames.Contains(schemaName);
		}

		#endregion

		#region Methods: Public

		public BaseIndexer GetForInsert(Entity entity) {
			if (GetIsIndexingDetail(entity.SchemaName)) {
				return ClassFactory.Get<DetailIndexer>();
			}
			return ClassFactory.Get<BaseIndexer>();
		}

		public BaseIndexer GetForUpdate(Entity entity, EntityAfterEventArgs entityAfterEventArgs) {
			if (GetIsIndexingDetail(entity.SchemaName)) {
				return ClassFactory.Get<DetailIndexer>();
			}
			if (GetIsRealtedEntityIndexingEnabled(entity) &&
				CheckIsPrimaryColumnChanged(entity, entityAfterEventArgs)) {
				return ClassFactory.Get<QueriedIndexer>();
			}
			return ClassFactory.Get<BaseIndexer>();
		}

		public BaseIndexer GetForDelete() {
			return ClassFactory.Get<BaseIndexer>();
		}

		#endregion

	}

	#endregion




}
