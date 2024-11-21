namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: PortalMessageEventListener

	/// <summary>
	/// Listener for 'PortalMessage' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "PortalMessage")]
	public class PortalMessageEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			Entity message = (Entity)sender;
			if(message.GetTypedColumnValue<bool>("IsNotPublished")){
				return;
			}
			var notifier = new PortalMessageNotifier(message);
			var manager = new MessageHistoryManager(message.UserConnection, notifier);
			manager.Notify();
		}

		#endregion

	}

	#endregion

}
 
