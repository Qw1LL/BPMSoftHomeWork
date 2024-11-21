namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using global::Common.Logging;

	#region Class: DuplicatesScheduledSearchSettingsEntityListener

	/// <summary>
	/// Class provides DuplicatesSearchParameter entity events handling.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "DuplicatesSearchParameter")]
	public class DuplicatesScheduledSearchParameterEntityListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const string BulkEsDeduplicationFeatureName = "BulkESDeduplication";

		#endregion

		#region Fields: Private

		private static readonly ILog Log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Methods: Private

		private static bool IsSearchParameterValid(DuplicatesScheduledSearchParameter duplicatesScheduledSearchParameter) {
			return duplicatesScheduledSearchParameter.SearchTime != TimeSpan.MinValue
				&& duplicatesScheduledSearchParameter.SearchDays != SearchDayOfWeek.None;
		}

		private static void UpdateDuplicatesSearchJob(Entity entity, bool isJobShouldBeRestarted) {
			if (!entity.UserConnection.GetIsFeatureEnabled(BulkEsDeduplicationFeatureName)) {
				return;
			}
			try {
				var bulkDeduplicationScheduler = ClassFactory.Get<IBulkDeduplicationScheduler>(
					new ConstructorArgument("userConnection", entity.UserConnection));
				var duplicatesScheduledSearchParameter = DuplicatesScheduledSearchParameter.CreateFromEntity(entity);
				bulkDeduplicationScheduler.DeleteSearchJob(duplicatesScheduledSearchParameter.SearchSchemaName);
				if (isJobShouldBeRestarted && IsSearchParameterValid(duplicatesScheduledSearchParameter)) {
					bulkDeduplicationScheduler.ScheduleSearchJob(duplicatesScheduledSearchParameter);
				}
			}
			catch (Exception ex) {
				Log.Error("Deduplication. Duplicates search settings has been changed. "
						+ "Failed to restart duplicates search job.", ex);
			}
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			UpdateDuplicatesSearchJob((Entity)sender, true);
		}

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			UpdateDuplicatesSearchJob((Entity)sender, true);
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			UpdateDuplicatesSearchJob((Entity)sender, false);
		}

		#endregion

	}

	#endregion

}

