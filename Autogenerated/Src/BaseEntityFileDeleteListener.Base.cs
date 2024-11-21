namespace BPMSoft.Configuration.EntityFileDelete
{
	using BPMSoft.File;
	using BPMSoft.File.Abstractions;
	using System;
	using global::Common.Logging;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: BaseEntityFileDeleteListener

	/// <summary>
	/// Listener for 'BaseEntity' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener"/>
	[EntityEventListener(SchemaName = "BaseEntity")]
	public class BaseEntityFileDeleteListener : BaseEntityEventListener
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger(typeof(BaseEntityFileDeleteListener));
		private static readonly List<string> _ignoreColumnNames = new List<string> {
			"CreatedBy",
			"ModifiedBy",
			"LockedBy"
		};

		#endregion

		#region Methods: Private

		private void DeleteEntityFiles(UserConnection userConnection, string entityFileSchemaName,
				string entitySchemaName, Entity entity) {
			var entityId = entity.PrimaryColumnValue;
			string key = GetStoreKey(entitySchemaName, entityId);
			var dataStore = userConnection.ApplicationData;
			_log.Debug("Retrieving file ids from data store.");
			var fileIds = (Guid[])dataStore[key];
			if (fileIds == null) {
				return;
			}
			_log.Debug($"Deleting {fileIds.Length} files.");
			foreach (Guid fileId in fileIds) {
				DeleteFile(fileId, entityFileSchemaName, userConnection);
			}
			dataStore.Remove(key);
		}
		
		private void DeleteEntityFileReferences(UserConnection userConnection, string entityFileSchemaName,
				Entity entity) {
			var entityId = entity.PrimaryColumnValue;
			string referenceColumnName = GetReferenceColumnName(userConnection, entity.Schema, entityFileSchemaName);
			var update = new Update(userConnection, entityFileSchemaName)
				.Set(referenceColumnName, new QueryParameter("MasterRecord", null, "Guid"))
				.Where(referenceColumnName).IsEqual(new QueryParameter(entityId));
			update.Execute();
		}

		private void DeleteFile(Guid fileId, string entityFileSchemaName, UserConnection userConnection) {
			_log.Debug($"Deleting file with Id: {fileId}.");
			var fileLocator = new EntityFileLocator(entityFileSchemaName, fileId);
			IFile file = userConnection.GetFile(fileLocator);
			file.Delete();
			_log.Debug($"File (Id: {fileId}) deleted successfully");
		}

		private List<ISchemaManagerItem<EntitySchema>> GetEntityFileInheritorsItems(EntitySchemaManager schemaManager) {
			var parentItem = GetParentFileItem(schemaManager);
			var entityFileItems = new List<ISchemaManagerItem<EntitySchema>>();
			foreach (ISchemaManagerItem<EntitySchema> item in schemaManager.GetItems()
				.Where(item => item.ParentUId == parentItem.UId)) {
				entityFileItems.Add(item);
			}
			foreach (var item in schemaManager.GetItems().Where(item => item.ExtendParent)) {
				EntitySchema instance = item.Instance;
				EntitySchema realParent = instance.ParentSchema;
				if (realParent.UId == parentItem.UId) {
					entityFileItems.Add(item);
				}
			}
			return entityFileItems;
		}

		private string GetEntityFileSchemaName(Entity entity, UserConnection userConnection, string entitySchemaName) {
			Guid entitySchemaUId = entity.Schema.UId;
			_log.Debug($"Searching file entity for schema with Name: {entitySchemaName}, UId: {entitySchemaUId}.");
			List<string> entitiesWithFiles = GetEntityWithFileNamesByRefSchemaUId(userConnection, entitySchemaUId);
			_log.Debug($"Found {entitiesWithFiles.Count} entities referencing current schema {entitySchemaName}.");
			string entityFileSchemaNameConvention = entitySchemaName + "File";
			string entityFileSchemaName = string.Empty;
			if (entitiesWithFiles.Count == 1) {
				entityFileSchemaName = entitiesWithFiles.First();
			}
			if (entitiesWithFiles.Count > 1) {
				entityFileSchemaName =
					entitiesWithFiles.Single(itemName => itemName == entityFileSchemaNameConvention);
			}
			_log.Debug($"EntityFileName = {entityFileSchemaName}");
			return entityFileSchemaName;
		}

		private List<string> GetEntityWithFileNamesByRefSchemaUId(UserConnection userConnection, Guid entityUId) {
			var entityNamesByUId = new List<string>();
			EntitySchemaManager schemaManager = userConnection.EntitySchemaManager;
			List<ISchemaManagerItem<EntitySchema>> entityFileItems = GetEntityFileInheritorsItems(schemaManager);
			foreach (var item in entityFileItems) {
				EntitySchemaColumnCollection schemaColumns = item.Instance.Columns;
				foreach (EntitySchemaColumn column in schemaColumns) {
					if (column.IsLookupType && !_ignoreColumnNames.Contains(column.Name)
						&& column.ReferenceSchemaUId == entityUId) {
						entityNamesByUId.Add(item.Name);
					}
				}
			}
			return entityNamesByUId;
		}

		private ISchemaManagerItem<EntitySchema> GetParentFileItem(EntitySchemaManager schemaManager) {
			string parentEntityName = "File";
			var parentItem = schemaManager.GetItemByName(parentEntityName);
			return parentItem;
		}

		private string GetReferenceColumnName(UserConnection userConnection, EntitySchema schema,
				string entityFileSchemaName) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var fileEntitySchema = entitySchemaManager.GetInstanceByName(entityFileSchemaName);
			var referenceColumn = fileEntitySchema.Columns.Where(column => column.IsLookupType
				&& !_ignoreColumnNames.Contains(column.Name) && column.ReferenceSchemaUId == schema.UId).First();
			return referenceColumn.ColumnValueName;
		}

		private string GetStoreKey(string entitySchemaName, Guid entityId) {
			return $"{entitySchemaName}{entityId}Files";
		}

		private void RestoreEntityFileReferences(UserConnection userConnection, string entityFileSchemaName,
				string entitySchemaName, Entity entity) {
			var entityId = entity.PrimaryColumnValue;
			string key = GetStoreKey(entitySchemaName, entityId);
			var dataStore = userConnection.ApplicationData;
			_log.Debug("Retrieving file ids from data store.");
			var fileIds = (Guid[])dataStore[key];
			if (fileIds == null) {
				return;
			}
			int count = fileIds.Length;
			string referenceColumnName = GetReferenceColumnName(userConnection, entity.Schema, entityFileSchemaName);
			const int parametersCount = 1000;
			_log.Debug($"Restoring {count} files.");
			for (int i = 0; i < count; i += parametersCount) {
				IEnumerable<Guid> fileIdsPart = fileIds.Skip(i).Take(parametersCount);
				var update = new Update(userConnection, entityFileSchemaName)
					.Set(referenceColumnName, new QueryParameter("MasterRecord", entityId, "Guid"))
					.Where("Id").In(Column.Parameters(fileIdsPart));
				update.Execute();
			}
			dataStore.Remove(key);
		}

		private void SaveEntityFileIds(UserConnection userConnection, string entityFileSchemaName,
				string entitySchemaName, Entity entity) {
			var entityId = entity.PrimaryColumnValue;
			EntityCollection files = GetFilesForEntity(userConnection, entityFileSchemaName, entitySchemaName, entityId,
				out EntitySchemaQueryColumn primaryKeyColumn);
			Guid[] fileIds = files.Select(file => file.GetTypedColumnValue<Guid>(primaryKeyColumn.Name)).ToArray();
			if (fileIds.Length > 0) {
			_log.Debug("Saving file ids to data store.");
				string key = GetStoreKey(entitySchemaName, entityId);
				var dataStore = userConnection.ApplicationData;
				dataStore[key] = fileIds;
			}
		}

		#endregion

		#region Methods: Public

		public virtual EntityCollection GetFilesForEntity(UserConnection userConnection, string entityFileSchemaName, 
			string entitySchemaName, Guid entityId, out EntitySchemaQueryColumn primaryKeyColumn) {
			_log.Debug($"Searching files for Entity: {entitySchemaName}, Id: {entityId} in {entityFileSchemaName}");
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, entityFileSchemaName);
			primaryKeyColumn = esq.AddColumn("Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, entitySchemaName, entityId));
			EntityCollection files = esq.GetEntityCollection(userConnection);
			_log.Debug($"Found {files.Count} files for specified record in {entityFileSchemaName}.");
			return files;
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("UseBaseEntityFileDeleteListener")) {
				return;
			}
			try {
				string entitySchemaName = entity.SchemaName;
				_log.Debug($"Processing entity {entitySchemaName}.");
				var entityFileSchemaName = GetEntityFileSchemaName(entity, userConnection, entitySchemaName);
				if (entityFileSchemaName != string.Empty) {
					SaveEntityFileIds(userConnection, entityFileSchemaName, entitySchemaName, entity);
					DeleteEntityFileReferences(userConnection, entityFileSchemaName, entity);
				}
			} catch (Exception ex) {
				_log.Error($"There was an error while deleting entity file references. {ex}");
			}
		}

		/// <summary>
		/// Handles error in delete operation.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityErrorEventArgs"/> instance containing the event data.</param>
		public override void OnDeleteFailed(object sender, EntityErrorEventArgs e) {
			base.OnDeleteFailed(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("UseBaseEntityFileDeleteListener")) {
				return;
			}
			try {
				string entitySchemaName = entity.SchemaName;
				_log.Debug($"Processing entity {entitySchemaName}.");
				var entityFileSchemaName = GetEntityFileSchemaName(entity, userConnection, entitySchemaName);
				if (entityFileSchemaName != string.Empty) {
					RestoreEntityFileReferences(userConnection, entityFileSchemaName, entitySchemaName, entity);
				}
			} catch (Exception ex) {
				_log.Error($"There was an error while restoring entity files. {ex}");
			}
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="EntityAfterEventArgs"/> instance containing the event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("UseBaseEntityFileDeleteListener")) {
				return;
			}
			try {
				string entitySchemaName = entity.SchemaName;
				_log.Debug($"Processing entity {entitySchemaName}.");
				var entityFileSchemaName = GetEntityFileSchemaName(entity, userConnection, entitySchemaName);
				if (entityFileSchemaName != string.Empty) {
					DeleteEntityFiles(userConnection, entityFileSchemaName, entitySchemaName, entity);
				}
			} catch (Exception ex) {
				_log.Error($"There was an error while deleting entity files. {ex}");
			}
		}

		#endregion

	}

	#endregion

}
