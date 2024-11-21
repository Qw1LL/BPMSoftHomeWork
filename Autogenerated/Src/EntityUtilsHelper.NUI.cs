namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: EntityUtilsHelper

	/// <summary>
	/// Helper class for working with entity.
	/// </summary>
	public class EntityUtilsHelper
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>Initializes a new instance of the class <see cref="EntityUtilsHelper"/>,
		/// using the specified user connection.</summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public EntityUtilsHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public EntityUtilsHelper() {
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates data collection for copying.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="columnName">The column name for linking with <paramref name="sourceEntitySchemaName"/>.
		/// </param>
		/// <param name="sourceEntitySchemaName">The name of the entity schema, from which data will be copied.</param>
		/// <returns><see cref="EntityCollection"/> instance.</returns>
		protected virtual EntityCollection GetSourceEntityCollection(Guid sourceEntityId, string columnName,
				string sourceEntitySchemaName) {
			var sourceQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, sourceEntitySchemaName);
			sourceQuery.AddAllSchemaColumns();
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, columnName,
				sourceEntityId));
			return sourceQuery.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Creates data collection for copying.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="columnName">The column name for linking with <paramref name="sourceEntitySchemaName"/>.
		/// </param>
		/// <param name="sourceEntitySchemaName">The name of the entity schema, from which data will be copied.</param>
		/// <param name="inlineIds">Additional filter on primary column.</param>
		/// <returns><see cref="EntityCollection"/> instance.</returns>
		protected virtual EntityCollection GetSourceEntityCollection(Guid sourceEntityId, string columnName,
				string sourceEntitySchemaName, IEnumerable<object> inlineIds) {
			var sourceQuery = new EntitySchemaQuery(_userConnection.EntitySchemaManager, sourceEntitySchemaName);
			sourceQuery.AddAllSchemaColumns();
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, columnName,
				sourceEntityId));
			sourceQuery.Filters.Add(sourceQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id",
				inlineIds));
			return sourceQuery.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Calls <see cref="Entity.Save(bool, bool)"/> method for <paramref name="entity"/>.
		/// </summary>
		/// <param name="entity"><see cref="Entity"/> instance.</param>
		/// <remarks>
		/// External dependency allocation.
		/// </remarks>
		protected virtual void SaveEntity(Entity entity) {
			entity.Save();
		}

		/// <summary>
		/// Fills columns of the new entity by values from the source <paramref name="sourceEntity"/>.
		/// </summary>
		/// <param name="sourceEntity">The entity, from which column values will be copied.</param>
		/// <param name="newEntity">The entity, to which column values will be copied.</param>
		/// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
		/// <param name="refColumnName">Reference column name.</param>
		/// <param name="entitySchemaName">The new entity schema name for <paramref name="recipientEntityId"/>.</param>
		protected virtual void FillEntityColumnValues(Entity sourceEntity, Entity newEntity, Guid recipientEntityId,
				string refColumnName, string entitySchemaName) {
			newEntity.SetDefColumnValues();
			foreach (var column in sourceEntity.Schema.Columns) {
				if (!column.IsValueCloneable) {
					continue;
				}
				DataValueType dataValueType = column.DataValueType;
				if (dataValueType.IsLookup) {
					object columnValue;
					object displayColumnValue;
					string columnValueName = column.ColumnValueName;
					string displayColumnValueName = column.DisplayColumnValueName;
					if (column.Name == refColumnName) {
						Entity entity = _userConnection.EntitySchemaManager
							.GetInstanceByName(entitySchemaName).CreateEntity(_userConnection);
						entity.FetchFromDB(recipientEntityId);
						columnValue = entity.GetColumnValue(entity.Schema.PrimaryColumn.Name);
						displayColumnValue = entity.GetColumnValue(entity.Schema.PrimaryDisplayColumn.Name);
					} else {
						columnValue = sourceEntity.GetColumnValue(columnValueName);
						displayColumnValue = sourceEntity.GetColumnValue(displayColumnValueName);
					}
					newEntity.SetColumnValue(columnValueName, columnValue);
					newEntity.SetColumnValue(displayColumnValueName, displayColumnValue);
					continue;
				}
				string columnName = column.Name;
				object value = sourceEntity.GetColumnValue(columnName);
				if (!dataValueType.IsBinary) {
					if (columnName != sourceEntity.Schema.GetPrimaryColumnName()) {
						newEntity.SetColumnValue(columnName, value);
						continue;
					}
				} else {
					var byteArray = value as byte[];
					if (byteArray != null) {
						newEntity.SetBytesValue(columnName, byteArray);
					} else {
						newEntity.SetStreamValue(columnName, value as Stream);
					}
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Copies and links data to the specified entity <paramref name="recipientEntityId"/> from the source
		/// <paramref name="sourceEntityId"/>.
		/// </summary>
		/// <param name="sourceEntityId">The source id, which copy data is linked with.</param>
		/// <param name="recipientEntityId">The recipient id, which data will be linked to.</param>
		/// <param name="columnName">The column name for linking with
		/// <paramref name="sourceEntitySchemaNames"/>.</param>
		/// <param name="entitySchemaName">Entity name of source and recipient.</param>
		/// <param name="sourceEntitySchemaNames">List of entity schema names, from which data will be copied.</param>
		/// <param name="inlineIds">List of ids for inline attachments.</param>
		/// <param name="isOnlyInline">Flag that forces to copy only inline attachments.</param>
		/// <returns>The result of copying.</returns>
		public Dictionary<string, string> Copy(Guid sourceEntityId, Guid recipientEntityId, string columnName,
				string entitySchemaName, List<string> sourceEntitySchemaNames, List<object> inlineIds = null,
				bool isOnlyInline = false) {
			var mappingIds = new Dictionary<string, string>();
			if (isOnlyInline && inlineIds.IsNullOrEmpty()) {
				return mappingIds;
			}
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				try {
					dbExecutor.StartTransaction();
					foreach (var sourceEntitySchemaName in sourceEntitySchemaNames) {
						EntityCollection sourceEntityCollection;
						if (isOnlyInline) {
							sourceEntityCollection = GetSourceEntityCollection(sourceEntityId, columnName,
								sourceEntitySchemaName, inlineIds);
						} else {
							sourceEntityCollection = GetSourceEntityCollection(sourceEntityId, columnName, 
								sourceEntitySchemaName);
						}
						if (sourceEntityCollection.Count == 0) {
							continue;
						}
						foreach (var sourceEntity in sourceEntityCollection) {
							Entity recipientEntity = _userConnection.EntitySchemaManager
								.GetInstanceByName(sourceEntitySchemaName).CreateEntity(_userConnection);
							FillEntityColumnValues(sourceEntity, recipientEntity, recipientEntityId, columnName,
								entitySchemaName);
							SaveEntity(recipientEntity);
							Guid sourceId = sourceEntity.PrimaryColumnValue;
							Guid recipientId = recipientEntity.PrimaryColumnValue;
							mappingIds.Add(sourceId.ToString(), recipientId.ToString());
						}
					}
					dbExecutor.CommitTransaction();
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return mappingIds;
		}

		#endregion

	}

	#endregion

}

