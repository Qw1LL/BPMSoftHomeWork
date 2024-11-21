namespace BPMSoft.Configuration.SerializedEsqFilterConvertation
{
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: SerializedEsqFilterConverter

	public static class SerializedEsqFilterConverter
	{

		#region Methods: Private

		private static void DisableEmptyEntitySchemaQueryFilters(EntitySchemaQueryFilterCollection queryFilterCollection) {
			foreach (var item in queryFilterCollection) {
				var filter = item as EntitySchemaQueryFilter;
				if (filter != null) {
					if (filter.RightExpressions.Count == 0 && filter.ComparisonType != FilterComparisonType.IsNull &&
							filter.ComparisonType != FilterComparisonType.IsNotNull) {
						filter.IsEnabled = false;
						continue;
					}
					if (filter.LeftExpression != null &&
							filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
						DisableEmptyEntitySchemaQueryFilters(filter.LeftExpression.SubQuery.Filters);
					}
					foreach (var rightExpression in filter.RightExpressions) {
						if (rightExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
							DisableEmptyEntitySchemaQueryFilters(rightExpression.SubQuery.Filters);
						}
					}
				} else {
					DisableEmptyEntitySchemaQueryFilters((EntitySchemaQueryFilterCollection)item);
				}
			}
		}

		private static EntitySchemaQueryFilterCollection ConvertSerializedFilter(UserConnection userConnection, string filterStr, EntitySchemaQuery query) {
			Filters filter7x;
			try {
				filter7x = JsonConvert.DeserializeObject<Filters>(filterStr);
			} catch {
				filter7x = null;
			}
			if (filter7x != null) {
				return (EntitySchemaQueryFilterCollection)QueryExtension.BuildEsqFilter(filter7x, query, userConnection);
			}
			var converter = new DataSourceFiltersJsonConverter(userConnection, query.RootSchema) {
				PreventRegisteringClientScript = true
			};
			var filter5x = JsonConvert.DeserializeObject<DataSourceFilterCollection>(filterStr, converter);
			return filter5x.ToEntitySchemaQueryFilterCollection(query);
		}

		#endregion

		#region Methods: Public

		public static void AddSerializedFilter(this EntitySchemaQuery source, UserConnection userConnection, string filterStr) {
			source.CheckArgumentNull(nameof(source));
			userConnection.CheckArgumentNull(nameof(userConnection));
			filterStr.CheckArgumentNullOrEmpty(nameof(filterStr));
			var esqFilter = ConvertSerializedFilter(userConnection, filterStr, source);
			DisableEmptyEntitySchemaQueryFilters(esqFilter);
			source.Filters.Add(esqFilter);
		}

		#endregion

	}

	#endregion

}

