namespace BPMSoft.Configuration.FoldersAndGroups {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Extensions.Validation;

	#region DeleteFolderCommand

	public class DeleteFolderCommand {

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructor: Public

		public DeleteFolderCommand(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion
		
		#region Methods: Private
		
		private bool GetIsDeleteAllowed(string entitySchemaName, IEnumerable<Guid> records) {
			DBSecurityEngine engine = _userConnection.DBSecurityEngine;
			if (engine.GetIsEntitySchemaAdministratedByOperations(entitySchemaName) &&
				!engine.GetIsEntitySchemaDeletingAllowed(entitySchemaName)) {
				return false;
			}
			if (engine.GetIsEntitySchemaAdministratedByRecords(entitySchemaName)  && 
			records.Any(record => IsDenyDeleteFolderForCurrentUser(engine, entitySchemaName, record))) {
				return false;
			}
			return true;
		}

		private static bool IsDenyDeleteFolderForCurrentUser(DBSecurityEngine engine, string entitySchemaName,
			Guid recordId) {
			var rightLevel = engine.GetEntitySchemaRecordRightLevel(entitySchemaName, recordId);
			return(rightLevel & SchemaRecordRightLevels.CanDelete) != SchemaRecordRightLevels.CanDelete;
		}

		private void CheckUserPermissions(string sourceSchemaName, IEnumerable<Guid> records) {
			if (_userConnection.DBSecurityEngine.GetCanExecuteOperation("CanDeleteEverything")) {
				return;
			}
			bool havePermission = GetIsDeleteAllowed(sourceSchemaName, records);
			if (!havePermission) {
				throw new SecurityException(string.Format(
					new LocalizableString("BPMSoft.Core",
						"DBSecurityEngine.Exception.CurrentUserHasNotRightsForObject"), sourceSchemaName));
			}
		}

		private bool DeleteFromFavoriteFolder(Guid folderEntitySchemaUId, Guid[] records) {
			var folderFavoriteSchema = _userConnection.EntitySchemaManager.GetInstanceByName("FolderFavorite");
			EntitySchemaQuery favoriteFolderQuery = new EntitySchemaQuery(folderFavoriteSchema);
			favoriteFolderQuery.AddAllSchemaColumns();
			AddFilterByRecords(favoriteFolderQuery, "FolderId", records);
			favoriteFolderQuery.Filters.Add(
				favoriteFolderQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal, 
					"FolderEntitySchemaUId", 
					folderEntitySchemaUId));
			EntityCollection favoriteFolders = favoriteFolderQuery.GetEntityCollection(_userConnection);
			bool deleted = DeleteEntities(favoriteFolders);
			return deleted;
		}

		private static void AddFilterByRecords(EntitySchemaQuery query, string columnPath, Guid[] records) {
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal,
				columnPath, records.Select(record => record.ToString())));
		}

		private static bool DeleteEntities(EntityCollection favoriteFolders) {
			bool deleted = false;
			while (favoriteFolders.Any()) {
				favoriteFolders.First().Delete();
				deleted = true;
			}
			return deleted;
		}

		private void DeleteFolders(EntitySchema folderEntitySchema, Guid[] records) {
			EntitySchemaQuery folderQuery = new EntitySchemaQuery(folderEntitySchema);
			folderQuery.AddAllSchemaColumns();
			AddFilterByRecords(folderQuery, folderEntitySchema.PrimaryColumn.ColumnValueName, records);
			DeleteEntities(folderQuery.GetEntityCollection(_userConnection));
		}
		
		#endregion

		#region Methods: Public
		
		public bool Execute(string sourceSchemaName, params Guid[] records) {
			sourceSchemaName.CheckArgumentNullOrWhiteSpace(nameof(sourceSchemaName));
			records.CheckIsNotEmpty(nameof(records));
			CheckUserPermissions(sourceSchemaName, records);
			EntitySchema folderEntitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(sourceSchemaName);
			bool result = DeleteFromFavoriteFolder(folderEntitySchema.UId, records);
			DeleteFolders(folderEntitySchema, records);
			return result;
		}

		#endregion

	}

	#endregion
}

