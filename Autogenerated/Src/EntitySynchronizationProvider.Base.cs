namespace BPMSoft.Configuration.EntitySynchronization
{

	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;

	#region Class: EntitySynchronizationProvider

	/// <summary>
	/// Provides entity for synchronization.
	/// </summary>
	public class EntitySynchronizationProvider : IEntitySynchronizationProvider
	{

		#region Fields: Private

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection _userConnection;

		#endregion

		#region Methods: Public

		public EntitySynchronizationProvider(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		/// <summary>
		/// Create entity of entity schema with name <paramref name="entitySchemaName">.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name.</param>
		/// <returns>Created entity.</returns>
		public Entity CreateEntity(string entitySchemaName, bool useAdminRights = false) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.FindInstanceByName(entitySchemaName); 
			if (entitySchema == null) {
				return null;
			}
			Entity entity = entitySchema.CreateEntity(_userConnection);
			entity.SetDefColumnValues();
			entity.UseAdminRights = useAdminRights;
			return entity;
		}

		/// <summary>
		/// Finds entity for synchronization using <paramref name="conditions">.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name.</param>
		/// <param name="conditions">Search condition.</param>
		/// <returns>Found entity.</returns>
		public Entity FindEntity(string entitySchemaName, Dictionary<string, object> conditions) {
			Entity entity = CreateEntity(entitySchemaName);			
			if (entity.FetchFromDB(conditions)) {
				return entity;
			}
			return null;
		}

		public Entity FindEntity(string entitySchemaName, Dictionary<string, object> conditions,
				Dictionary<string, OrderDirection> orderByColumns) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, entitySchemaName);
			esq.AddAllSchemaColumns();
			foreach (KeyValuePair<string, object> condition in conditions) {
				IEntitySchemaQueryFilterItem columnFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					condition.Key, condition.Value);
				esq.Filters.Add(columnFilter);
			}
			foreach (KeyValuePair<string, OrderDirection> orderByColumn in orderByColumns) {
				EntitySchemaQueryColumn column = esq.Columns.GetByName(orderByColumn.Key);
				column.OrderDirection = orderByColumn.Value;
			}
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			return entities.FirstOrDefault();
		}

		#endregion

	}

	#endregion

}

