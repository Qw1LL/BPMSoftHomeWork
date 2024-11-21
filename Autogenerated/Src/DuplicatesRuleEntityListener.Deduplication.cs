namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core;
	using global::Common.Logging;

	#region Class: DuplicatesRuleEntityListener

	/// <summary>
	/// Class provides DuplicatesRule entity events handling.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "DuplicatesRule")]
	public class DuplicatesRuleEntityListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const string BulkEsDeduplicationFeatureName = "BulkESDeduplication";

		#endregion

		#region Fields: Private

		private static readonly ILog Log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Methods: Private

		private static string GetSearchSchemaName(Entity entity) {
			var entityUid = entity.GetTypedColumnValue<Guid>(nameof(DuplicatesRule.ObjectId));
			var entitySchema = entity.UserConnection.EntitySchemaManager.FindItemByUId(entityUid);
			return entitySchema.Name;
		}

		private static IDuplicatesRuleChecker GetDuplicatesRuleChecker(
				UserConnection userConnection) {
			return ClassFactory.Get<IDuplicatesRuleChecker>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("duplicatesRuleRepository", ClassFactory.Get<IDuplicatesRuleRepository>())
			);
		}

		private static IDuplicatesScheduledSearchParameterRepository GetDuplicatesSearchSettingsRepository(
				UserConnection userConnection) {
			return ClassFactory.Get<IDuplicatesScheduledSearchParameterRepository>(
				new ConstructorArgument("userConnection", userConnection));
		}

		private static void ChangeScheduledDuplicatesSearchSettings(Entity entity) {
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled(BulkEsDeduplicationFeatureName)) {
				return;
			}
			try {
				var searchSchemaName = GetSearchSchemaName(entity);
				var duplicatesRuleChecker = GetDuplicatesRuleChecker(userConnection);
				var duplicatesSearchSettingsRepository = GetDuplicatesSearchSettingsRepository(userConnection);
				var isActiveRulesExistBySchema = duplicatesRuleChecker.GetIsActiveDuplicationRuleExist(searchSchemaName);
				var isSearchSettingsExistBySchema = duplicatesSearchSettingsRepository.GetIsSearchParametersExist(searchSchemaName);
				if (isActiveRulesExistBySchema && !isSearchSettingsExistBySchema) {
					duplicatesSearchSettingsRepository
						.CreateDefaultSearchParameterBySchemaName(searchSchemaName);
				}
				else if (!isActiveRulesExistBySchema && isSearchSettingsExistBySchema) {
					duplicatesSearchSettingsRepository
						.DeleteSearchParameterBySchemaName(searchSchemaName);
				}
			}
			catch (Exception ex) {
				Log.Error("Deduplication. Duplicates rule has been inserted, updated or deleted. "
						+ "Failed to update scheduled duplicates search settings.", ex);
			}
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			ChangeScheduledDuplicatesSearchSettings((Entity)sender);
		}

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			ChangeScheduledDuplicatesSearchSettings((Entity)sender);
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ChangeScheduledDuplicatesSearchSettings((Entity)sender);
		}

		#endregion

	}

	#endregion

}

