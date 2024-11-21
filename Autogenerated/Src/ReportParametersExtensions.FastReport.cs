namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region CLass: ReportParametersExtensions

	public static class ReportParametersExtensions
	{

		#region Methods: Public

		public static IEntitySchemaQueryFilterItem ExtractEsqFilterFromReportParameters(this IReadOnlyDictionary<string, object> source,
				UserConnection userConnection, string entitySchemaName) {
			if (source.TryGetValue("EsqFilters", out var parameter) && parameter is IReadOnlyDictionary<string, Filters> allFilters) {
				if (allFilters.TryGetValue(entitySchemaName, out var entitySchemaFilters)) {
					return entitySchemaFilters.BuildEsqFilter(entitySchemaName, userConnection);
				}
			}
			return null;
		}

		public static bool TryAddFilterFromReportParameters(this EntitySchemaQuery source,
				UserConnection userConnection, IReadOnlyDictionary<string, object> parameters) {
			var filter = parameters.ExtractEsqFilterFromReportParameters(userConnection, source.RootSchema.Name);
			if (filter != null) {
				source.Filters.Add(filter);
				return true;
			}
			return false;
		}

		#endregion

	}

	#endregion

}

