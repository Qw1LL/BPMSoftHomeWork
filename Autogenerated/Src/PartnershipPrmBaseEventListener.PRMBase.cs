namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: PartnershipPrmBaseEventListener

	/// <summary>
	/// Listener for Partnership entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Partnership")]
	public class PartnershipPrmBaseEventListener : BaseEntityEventListener
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
			var parthership = (Entity)sender;
			var rightsRegulator = new SspEntityRightsRegulator(parthership.UserConnection, parthership.SchemaName);
			rightsRegulator.GrantOrganizationReadRights(parthership.PrimaryColumnValue,
					parthership.GetTypedColumnValue<Guid>("AccountId"));
		}

		#endregion

	}

	#endregion

}

