namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: LeadBaseEventListener

	/// <summary>
	/// Listener for Lead entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Lead")]
	public class LeadBaseEventListener : BaseEntityEventListener
	{
		#region Fields: Private

		private LeadStatusChecker _leadStatusChecker;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; private set; }

		#endregion

		#region Methods: Private

		private bool IsLeadInFinalStatus(Entity lead) {
			Guid leadStatusId = lead.GetTypedColumnValue<Guid>("QualifyStatusId");
			LeadStatusChecker leadStatusStore = GetLeadStatusChecker();
			return leadStatusStore.IsLeadInFinalStatus(leadStatusId);
		}

		private LeadStatusChecker GetLeadStatusChecker() {
			return _leadStatusChecker ?? (_leadStatusChecker = new LeadStatusChecker(UserConnection));
		}

		private void SynchronizeLeadContact(Entity lead, EntityAfterEventArgs e) {
			if (UserConnection.GetIsFeatureEnabled("SynchronizeLeadContact")) {
				if (IsLeadInFinalStatus(lead)) {
					return;
				}
				LeadContactSynchronizer leadContactSynchronizer = new LeadContactSynchronizer(UserConnection);
				leadContactSynchronizer.SynchronizeContactData(lead, e.ModifiedColumnValues);
			}
		}

		#endregion

		#region Methods: Public

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			Entity lead = (Entity)sender;
			UserConnection = lead.UserConnection;
			SynchronizeLeadContact(lead, e);
		}

		#endregion

	}

	#endregion

}

