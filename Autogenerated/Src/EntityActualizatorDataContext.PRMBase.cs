namespace BPMSoft.Configuration 
{

	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: EntityActualizatorDataContext

	/// <summary>
	/// Apply data to DB based on Mapping.
	/// </summary>
	public class EntityActualizatorDataContext 
	{

		#region Properties: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected UserConnection _userConnection { get; private set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize EntityActualizatorDataContext.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public EntityActualizatorDataContext(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Set mapped columns on entity.
		/// </summary>
		/// <param name="keyColumnName">Key column of entity.</param>
		/// <param name="columnMapping">Columns mapping for DataSet.</param>
		/// <param name="entity">Entity for which dataSet applied.</param>
		/// <param name="column">Column to apply.</param>
		private void SetMappedColumns(
			Dictionary<string, object> row,
			string keyColumnName,
			Dictionary<string, string> columnMapping,
			Entity entity) {
			foreach (var column in row) {
				if (column.Key != keyColumnName) {
					entity.SetColumnValue(columnMapping[column.Key], column.Value);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Apply data to database based on EntitySchema name, KeyColumn name and Column mapping.
		/// Base implementation sorts out data set, map columns with column mapping and set
		/// columns on entity.
		/// </summary>
		/// <param name="entitySchemaName">Entity schema name, for which data applied.</param>
		/// <param name="keyColumnName">Key column of entity.</param>
		/// <param name="columnMapping">Columns mapping for DataSet.</param>
		/// <param name="dataSet">DataSet which applied.</param>
		public virtual void ApplyData(
			string entitySchemaName,
			string keyColumnName,
			Dictionary<string, string> columnMapping,
			IEnumerable<Dictionary<string, object>> dataSet) {
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName(entitySchemaName);
			Entity entity = schema.CreateEntity(_userConnection);
			try {
				var mappedKeyColumnName = columnMapping[keyColumnName];
				using (var dataSetEnumerator = dataSet.GetEnumerator()) {
					while (dataSetEnumerator.MoveNext()) {
						var currentRow = dataSetEnumerator.Current;
						if (entity.FetchFromDB(currentRow[mappedKeyColumnName])) {
							SetMappedColumns(currentRow, keyColumnName, columnMapping, entity);
							entity.Save();
						}
					}
				}
			}
			catch (KeyNotFoundException) {
				throw new KeyNotFoundException("Column not found in columnMapping dictionary");
			}
		}

		#endregion
	}

	#endregion
}
