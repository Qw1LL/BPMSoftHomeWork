namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using global::Common.Logging;

	#region Class: DeduplicationBaseEntityListener

	/// <summary>
	/// Listener for 'BaseEntity' entity events.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "BaseEntity")]
	public class DeduplicationBaseEntityListener : BaseEntityEventListener
	{
		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Deduplication");

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			if (!entity.UserConnection.GetIsFeatureEnabled("BulkESDeduplication")) {
				return;
			}
			try {
				var duplicatesRuleChecker = ClassFactory.Get<IDuplicatesRuleChecker>(
					new ConstructorArgument("userConnection", entity.UserConnection),
					new ConstructorArgument("duplicatesRuleRepository", ClassFactory.Get<IDuplicatesRuleRepository>())
				);
				if (duplicatesRuleChecker.GetIsDuplicationRuleExist(entity.Schema.UId)) {
					var deduplicateDeletion = ClassFactory.Get<IDuplicateDeletionManager>(
						new ConstructorArgument("userConnection", entity.UserConnection));
					deduplicateDeletion.Delete(entity.SchemaName, new[] {entity.PrimaryColumnValue});
				}
			} catch (Exception ex) {
				_log.Error("Deduplication. OnDeleted. Exception. ", ex);
			}
		}

		#endregion

	}

	#endregion

}

