namespace BPMSoft.Configuration {
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: FolderConverter

	/// <summary>
	/// Class for work with groups
	/// </summary>
	public class FolderConverter {

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Properties: Public
		public int ConvertingTimeout { get; }

		#endregion

		#region Constructors: Public

		public FolderConverter() { }

		public FolderConverter(UserConnection userConnection) {
			_userConnection = userConnection;
			ConvertingTimeout = BPMSoft.Core.Configuration.SysSettings.GetValue(_userConnection, "ConvertContactGroupTimeout", 2000);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Create esq for entity
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <param name="folderId">Search folder id</param>
		/// <param name="newFolderId">New folder id</param>
		/// <returns></returns>
		protected virtual Select CreateEntityDataSelect(string entitySchemaName, Guid folderId, Guid newFolderId) {
			var entitySchemaManager = _userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName(entitySchemaName);
			var sourceSchemaUId = entitySchema.UId;
			var folderSchemaUId = _userConnection.EntitySchemaManager.GetInstanceByName($"{entitySchemaName}Folder").UId;
			var esq = new EntitySchemaQuery(entitySchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn(newFolderId, _userConnection.DataValueTypeManager.FindDataValueTypeByType(typeof(Guid)));
			var esqFilter = CommonUtilities.GetFolderEsqFilters(_userConnection, folderId, folderSchemaUId, sourceSchemaUId, true);
			esq.Filters.Add(esqFilter);
			return esq.GetSelectQuery(_userConnection);
		}

		/// <summary>
		/// Create insert select for add new entity folder
		/// </summary>
		/// <param name="select">Entity select</param>
		/// <param name="entitySchemaName">Entity schema name</param>
		/// <returns>Insert select</returns>
		protected virtual InsertSelect GetInsertSelectForEntityFolder(Select select, string entitySchemaName) {
			var inFolderSchemaName = entitySchemaName + "InFolder";
			var inFolderSchema = _userConnection.EntitySchemaManager.GetInstanceByName(inFolderSchemaName);
			var refEntityColumn = inFolderSchema.Columns.FindByName(entitySchemaName);
			return new InsertSelect(_userConnection)
				.Into(inFolderSchemaName)
				.Set(refEntityColumn.ColumnValueName)
				.Set("FolderId")
				.FromSelect(select);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Fill static group by dynamic group filter
		/// </summary>
		/// <returns>Result response</returns>
		public void Convert(Guid newFolderId, Guid parentFolderId, string entitySchemaName) {
			var selectFromEsq = CreateEntityDataSelect(entitySchemaName, parentFolderId, newFolderId);
			selectFromEsq.SpecifyNoLockHints();
			var entityFolderInsertSelect = GetInsertSelectForEntityFolder(selectFromEsq, entitySchemaName);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				dbExecutor.CommandTimeout = ConvertingTimeout;
				entityFolderInsertSelect.Execute(dbExecutor);
			}
		}

		#endregion
	}

	#endregion

}

