 namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: SearchDuplicatesActionExecutor

	[DefaultBinding(typeof(ISearchDuplicatesActionExecutor))]
	public class SearchDuplicatesActionExecutor: ISearchDuplicatesActionExecutor
	{

		#region Fields: Private

		private DuplicatesSearchUtilities _duplicatesSearchUtilities;
		private IDuplicatesRuleRepository _duplicatesRuleRepository;
		private IDuplicatesRuleManager _duplicatesRuleManager;

		#endregion

		#region Properties: Private

		private DuplicatesSearchUtilities DuplicatesSearchUtilities =>
			_duplicatesSearchUtilities ?? (_duplicatesSearchUtilities =
				ClassFactory.Get<DuplicatesSearchUtilities>(new[] {
					new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("entitySchemaName", EntitySchemaName)
				}));

		private IDuplicatesRuleManager DuplicatesRuleManager =>
			_duplicatesRuleManager ?? (_duplicatesRuleManager = 
				ClassFactory.Get<IDuplicatesRuleManager>(new[] {
					new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("duplicatesRuleRepository", DuplicatesRuleRepository)
				}));

		private IDuplicatesRuleRepository DuplicatesRuleRepository {
			get =>
				_duplicatesRuleRepository ??
				(_duplicatesRuleRepository = new DuplicatesRuleRepository());
		}

		private UserConnection UserConnection { get; set; }

		private string EntitySchemaName { get; set; }

		#endregion

		#region Methods: Private

		private Guid MergeDuplicatesResult(IEnumerable<KeyValuePair<string, object>> entityColumns,
			IEnumerable<Dictionary<string, string>> duplicatesCollection, string primaryColumnName) {
			var searchColumns = entityColumns.Select(x=> x.Key).ToList();
			var entityIdColumnValue =
				entityColumns.Where(x => x.Key == "Id").Select(x => x.Value.ToString()).FirstOrDefault();
			if (entityIdColumnValue != null && !duplicatesCollection.Any(duplicate => duplicate.Values.Contains(entityIdColumnValue))) {
				duplicatesCollection = duplicatesCollection.Append(new Dictionary<string, string>() { { "Id", entityIdColumnValue }});
			}
			return DuplicatesSearchUtilities.MergeRecordDuplicates(duplicatesCollection, searchColumns) ?
				Guid.Parse(duplicatesCollection.FirstOrDefault()[primaryColumnName]) : Guid.Empty;
		}

		#endregion

		#region Constructors: Public

		public SearchDuplicatesActionExecutor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		public SearchDuplicatesActionExecutor(UserConnection userConnection, DuplicatesSearchUtilities duplicatesSearchUtilities) {
			UserConnection = userConnection;
			_duplicatesSearchUtilities = duplicatesSearchUtilities;
		}

		#endregion

		#region Methods: Public

		public Guid ExecuteDuplicatesSearch(SearchDuplicatesActionConfiguration config) {
			if (!UserConnection.GetIsFeatureEnabled("ESDeduplication")) {
				throw new Exception(
					UserConnection.GetLocalizableString("SearchDuplicatesActionExecutor", "ESDeduplicationFeatureException"));
			}
			config.EntityId.CheckArgumentNull(nameof(config.EntityId));
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(config.EntitySchemaId);
			EntitySchemaName = entitySchema.Name;
			var rulesList = DuplicatesSearchUtilities.GetActiveRules(entitySchema.Name, config.RulesList);
			if (!rulesList.Any()) {
				var message = UserConnection.GetLocalizableString(this.GetType().Name, "HasNoActiveDuplicatesRuleFound");
				throw new Exception(message);
			}
			var columns = DuplicatesSearchUtilities.GetColumnsFromRules(rulesList);
			var entityColumns = DuplicatesSearchUtilities.GetEntityColumns(config.EntityId, columns).Distinct();
			var duplicatesCollection = DuplicatesSearchUtilities.FindRecordDuplicates(entityColumns, config.RulesList);
			return (duplicatesCollection?.Any() == true)
				? MergeDuplicatesResult(entityColumns, duplicatesCollection, entitySchema.GetPrimaryColumnName())
				: Guid.Empty;
		}

		#endregion

	}

	#endregion

}
