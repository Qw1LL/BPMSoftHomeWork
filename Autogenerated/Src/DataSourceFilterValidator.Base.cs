namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Core.Entities;
	using BPMSoft.UI.WebControls.Controls;

	[Obsolete("7.14.2 | Class is not in use and will be removed in upcoming releases")]
	public static class DataSourceFilterValidator
	{
		private static bool IsAnyLeftExpressionNullOrEmpty(DataSourceFilter filter) {
			bool result = false;
			if (filter == null) {
				return result;
			}
			
			if (filter.ComparisonType == FilterComparisonType.IsNull ||
					filter.ComparisonType == FilterComparisonType.IsNotNull) {
				return result;
			}
			if (filter.LeftExpression == null) {
				return true;
			}
			if (filter.RightExpression == null) {
				result = true;
			} else {
				if (filter.RightExpression.Type == DataSourceFilterExpressionType.SchemaColumn ||
						filter.RightExpression.Type == DataSourceFilterExpressionType.Aggregation) {
					result = String.IsNullOrEmpty(filter.RightExpression.TargetColumnPath);
				}
				
				if (filter.RightExpression.Type == DataSourceFilterExpressionType.Parameter ) {
					result = !(filter.RightExpression.Parameters != null &&
						filter.RightExpression.Parameters.Count != 0);
				}
			}
			
			return result;
		}
		
		private static bool IsAnyLeftExpressionNullOrEmpty(DataSourceFilterCollection filterCollection) {
			bool result = false;
			if (filterCollection == null) {
				return result;
			}
			
			result = filterCollection.Any(fi => fi.IsAnyLeftExpressionNullOrEmpty());
			return result;
		}
		
		public static bool IsAnyLeftExpressionNullOrEmpty(this IDataSourceFilterItem filterItem) {
			bool result = IsAnyLeftExpressionNullOrEmpty(filterItem as DataSourceFilterCollection);
			
			if (!result) {
				result = IsAnyLeftExpressionNullOrEmpty(filterItem as DataSourceFilter);
			}
			
			return result;
		}
	}
}
