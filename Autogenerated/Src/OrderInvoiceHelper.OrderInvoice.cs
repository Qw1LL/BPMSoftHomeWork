using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using CoreConfiguration = BPMSoft.Core.Configuration;

namespace BPMSoft.Configuration.OrderInvoice
{
	public class OrderInvoiceHelper
	{

		#region Constructors: Public

		public OrderInvoiceHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			private set;
		}
		
		#endregion

		#region Methods: Protected

		protected virtual Entity GetSourceEntity(EntitySchema sourceSchema, Dictionary<string, string> validColumnmap, Guid sourceRowId) {
			var entity = sourceSchema.CreateEntity(UserConnection);
			IEnumerable<string> columnsToFetch = validColumnmap.Values.Distinct();
			entity.FetchFromDB(sourceSchema.GetPrimaryColumnName(), sourceRowId, columnsToFetch);
			return entity;
		}

		protected virtual Entity GetDestinationEntity(EntitySchema destinationSchema) {
			var entity = destinationSchema.CreateEntity(UserConnection);
			entity.SetDefColumnValues();
			return entity;
		}

		protected Dictionary<string, string> GetValidColumnMap(EntitySchema sourceSchema, EntitySchema destinationSchema, Dictionary<string, string> inputMap) {
			var result = new Dictionary<string, string>();
			foreach (var columnMapItem in inputMap) {
				if (destinationSchema.Columns.FindByName(columnMapItem.Key) != null && 
						sourceSchema.Columns.FindByName(columnMapItem.Value) != null) {
							result.Add(columnMapItem.Key, columnMapItem.Value);
				}
			}
			return result;
		}

		protected void FillColumnValues(Entity source, Entity destination, Dictionary<string, string> columnMap) {
			foreach (var columnMapItem in columnMap) {
				EntitySchemaColumn destinationColumn = destination.Schema.Columns.GetByName(columnMapItem.Key);
				EntitySchemaColumn sourceColumn = source.Schema.Columns.GetByName(columnMapItem.Value);
				object value = source.GetColumnValue(sourceColumn);
				destination.SetColumnValue(destinationColumn, value);
			}
		}

		protected void FillColumnValues(Entity destination, Dictionary<string, object> columnMap) {
			foreach (var columnMapItem in columnMap) {
				EntitySchemaColumn destinationColumn = destination.Schema.Columns.FindByName(columnMapItem.Key);
				if (destinationColumn != null) {
					destination.SetColumnValue(destinationColumn, columnMapItem.Value);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ####### ###### # ####### ## ######### ###### ###### #######, ####### ######## #######.
		/// </summary>
		/// <param name="sourceSchemaName">######## ######## #######.</param>
		/// <param name="destinationSchemaName">######## ####### #######.</param>
		/// <param name="sourceRowId">Id ######  ######## #######.</param>
		/// <param name="columnMap">############ ####### ######## (########) # ####### (####) #######.</param>
		/// <param name="columnValueMap">############## ######## ####### ###### ####### #######.</param>
		/// <returns>Id ######## ###### ####### #######.</returns>
		public virtual Guid CreateEntity(string sourceSchemaName, string destinationSchemaName, Guid sourceRowId, 
				Dictionary<string, string> columnMap, Dictionary<string, object> columnValueMap = null) {
			EntitySchema sourceEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(sourceSchemaName);
			EntitySchema destinationEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(destinationSchemaName);
			Dictionary<string, string> validColumnMap = GetValidColumnMap(sourceEntitySchema, destinationEntitySchema, columnMap);
			Entity sourceEntity = GetSourceEntity(sourceEntitySchema, validColumnMap, sourceRowId);
			Entity destinationEntity = GetDestinationEntity(destinationEntitySchema);
			FillColumnValues(sourceEntity, destinationEntity, validColumnMap);
			if (columnValueMap != null) {
				FillColumnValues(destinationEntity, columnValueMap);
			}
			destinationEntity.Save(false);
			return destinationEntity.PrimaryColumnValue;
		}

		#endregion
	}
}


