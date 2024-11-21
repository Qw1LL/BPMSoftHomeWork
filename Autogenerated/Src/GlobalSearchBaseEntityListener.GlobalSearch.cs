namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Configuration.GlobalSearchColumnUtils;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.GlobalSearch.Indexing;

	#region Class: GlobalSearchBaseEntityListener

	/// <summary>
	/// Listener for 'BaseEntity' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener"/>
	[EntityEventListener(SchemaName = "BaseEntity")]
	public class GlobalSearchBaseEntityListener : BaseEntityEventListener
	{
		#region Fields: Private

		private ConfigurableIndexingEntities _configurableIndexingEntities;
		private static readonly ILog _log = LogManager.GetLogger("GlobalSearch");

		#endregion

		#region Properties: Private

		private IndexerFactory _indexerFactory;
		private IndexerFactory IndexerFactory =>
			_indexerFactory ??
			(_indexerFactory = ClassFactory.Get<IndexerFactory>());

		private GlobalSearchColumnUtils _globalSearchColumnUtils;
		private GlobalSearchColumnUtils GlobalSearchColumnUtils =>
			_globalSearchColumnUtils ??
			(_globalSearchColumnUtils = ClassFactory.Get<GlobalSearchColumnUtils>());

		#endregion

		#region Methods: Private

		private ConfigurableIndexingEntities GetConfigurableIndexingEntities(UserConnection userConnection) {
			var userConnectionArgument = new ConstructorArgument("userConnection", userConnection);
			return _configurableIndexingEntities ??
				(_configurableIndexingEntities = ClassFactory.Get<ConfigurableIndexingEntities>(userConnectionArgument));
		}
		
		private bool IsChangedIndexedColumns(Entity entity, EntityAfterEventArgs e) {
			return e.ModifiedColumnValues
				.Any(entityColumnValue => IsChangedIndexedColumn(entity, entityColumnValue));
		}

		private bool IsChangedIndexedColumn(Entity entity, EntityColumnValue entityColumnValue) {
			var configurableIndexingEntities = GetConfigurableIndexingEntities(entity.UserConnection);
			var isIgnoredColumn = configurableIndexingEntities
				.GetIsIgnoredColumn(entity.Schema, entityColumnValue.Column);
			return !isIgnoredColumn && IsIndexedColumn(entity, entityColumnValue);
		}

		private bool IsIndexedColumn(Entity entity, EntityColumnValue entityColumnValue) {
			var column = entityColumnValue.Column;
			var schema = entity.Schema;
			var isPrimaryColumn = GlobalSearchColumnUtils.IsPrimaryColumn(schema, column);
			var isIndexedColumnType = GlobalSearchColumnUtils.IsIndexedColumnType(column);
			return isPrimaryColumn || isIndexedColumnType;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			try {
				var entity = (Entity) sender;
				var indexer = IndexerFactory.GetForInsert(entity);
				indexer.IndexEntity(entity, IndexingOperationType.Index);
			} catch (Exception exception) {
				_log.Error("Error during indexing after entity inserted", exception);
			}
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			try {
				var entity = (Entity) sender;
				var indexer = IndexerFactory.GetForDelete();
				indexer.IndexEntity(entity, IndexingOperationType.Delete);
			} catch (Exception exception) {
				_log.Error("Error during indexing after entity deleted", exception);
			}
		}

		/// <summary>
		/// Handles entity updated event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			try {
				var entity = (Entity) sender;
				var isChangedIndexingColumn = IsChangedIndexedColumns(entity, e);
				if (!isChangedIndexingColumn) {
					return;	
				}
				var indexer = IndexerFactory.GetForUpdate(entity, e);
				indexer.IndexEntity(entity, IndexingOperationType.Index);
			} catch (Exception exception) {
				_log.Error("Error during indexing after entity deleted", exception);
			}
		}

		#endregion
	}

	#endregion

}
