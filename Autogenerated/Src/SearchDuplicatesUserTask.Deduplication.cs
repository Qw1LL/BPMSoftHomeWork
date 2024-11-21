namespace BPMSoft.Core.Process.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Deduplication;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;


	#region Class: SearchDuplicatesUserTask

	/// <exclude/>
	public partial class SearchDuplicatesUserTask
	{

		#region Properties: Private

		private ISearchDuplicatesActionExecutor SearchDuplicatesActionExecutor =>
			_searchDuplicatesActionExecutor ?? (_searchDuplicatesActionExecutor =
				ClassFactory.Get<ISearchDuplicatesActionExecutor>(
					new ConstructorArgument[] { new ConstructorArgument("userConnection", UserConnection) }
					)
				);

		#endregion

		#region Fields: Private

		private ISearchDuplicatesActionExecutor _searchDuplicatesActionExecutor;

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var parameterList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(Rules);
			var rules = parameterList.Select(x=>Guid.Parse(x.GetTypedValue<string>("RuleId"))).ToList();
			var actionConfig = new SearchDuplicatesActionConfiguration {
				EntityId = EntityId,
				EntitySchemaId = EntitySchemaId,
				RulesList = rules
			};
			GoldRecordId = SearchDuplicatesActionExecutor.ExecuteDuplicatesSearch(actionConfig);
			return true;
		}
		
		#endregion

	}

	#endregion

}