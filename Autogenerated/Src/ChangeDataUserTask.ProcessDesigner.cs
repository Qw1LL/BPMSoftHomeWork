namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;

	#region Class: ChangeDataUserTask

	/// <exclude/>
	public partial class ChangeDataUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (EntitySchemaUId.Equals(Guid.Empty)) {
				return false;
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(EntitySchemaUId);
			if (RecordColumnValues.Values.Count == 0) {
				return true;
			}
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entitySchema.Name) {
				UseAdminRights = false,
				IgnoreDisplayValues = GlobalAppSettings.FeatureIgnoreDisplayValuesInDataUserTasks
			};
			entitySchemaQuery.AddAllSchemaColumns();
			if (IsMatchConditions) {
				ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, entitySchema, entitySchemaQuery,
					DataSourceFilters);
				bool isEmptyFilter = entitySchemaQuery.Filters.Count == 0;
				if (!isEmptyFilter && entitySchemaQuery.Filters.Count == 1) {
					if (entitySchemaQuery.Filters[0] is EntitySchemaQueryFilterCollection filterGroup &&
							filterGroup.Count == 0) {
						isEmptyFilter = true;
					}
				}
				if (isEmptyFilter) {
					throw new NullOrEmptyException(new LocalizableString("BPMSoft.Core",
						"ProcessSchemaChangeDataUserTask.Exception.ChangeDataWithEmptyFilter"));
				}
			}
			EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			UpdateEntityCollection(entityCollection, entitySchema);
			return true;
		}

		#endregion

		#region Methods: Public

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process,
				DataSourceFilterCollection filters) {
			foreach (IDataSourceFilterItem filter in filters) {
				if (filter is DataSourceFilterCollection dataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourceFilterCollection);
					continue;
				}
				var dataSourceFilter = (DataSourceFilter)filter;
				if (dataSourceFilter.RightExpression?.Type == DataSourceFilterExpressionType.Custom) {
					dataSourceFilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourceFilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourceFilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourceFilter.SubFilters?.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourceFilter.SubFilters);
					}
				}
			}
		}

		public virtual void UpdateEntityCollection(EntityCollection entityCollection, EntitySchema entitySchema) {
			string GetDebugInfo(Entity source) {
				var info = new System.Text.StringBuilder();
				try {
					info.Append(source.SchemaName);
					info.Append($" ({source.Schema.PrimaryColumn.Name}: [{source.PrimaryColumnValue}])");
				} catch (Exception) {
				}
				return info.ToString();
			}
			foreach (Entity entity in entityCollection) {
				try {
					foreach(KeyValuePair<string, object> columnValue in RecordColumnValues.Values) {
						EntitySchemaColumn column = entitySchema.GetSchemaColumnByMetaPath(columnValue.Key);
						object value = columnValue.Value;
						if (ProcessUserTaskUtilities.GetIsEmptyLookupOrDateTimeValue(value, column.DataValueType)) {
							value = null;
						}
						entity.SetColumnValue(column, value);
					}
					entity.UseAdminRights = false;
					entity.Save(false);
				} catch (Exception e) {
					string debugInfo = GetDebugInfo(entity);
					Log.Error($"An error occurred during process element {this} when updating an entity {debugInfo}",
						e);
				}
			}
		}

		#endregion

	}

	#endregion

}
