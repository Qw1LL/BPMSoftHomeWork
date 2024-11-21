namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: OrganizationEventListener

	/// <summary>
	/// Listener for Organization entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "VwSspAdminUnit")]
	public class OrganizationEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var organization = (Entity)sender;
			var accountId = organization.GetTypedColumnValue<Guid>("PortalAccountId");
			if(accountId.IsNotEmpty()) {
				var rightsRegulator = new PartnershipRightsDistributor(organization.UserConnection);
				rightsRegulator.GrantPartnershipReadRightsToOrganization(organization.PrimaryColumnValue, accountId);
			}

		}

		#endregion

	}

	#endregion

}

