namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Store;

	/// <summary>
	/// Listener for 'VwSysAdminUnit' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysAdminUnit")]
	[EntityEventListener(SchemaName = "VwSysAdminUnit")]
	public class ExternalAccessSysAdminUnitListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>Handles entity Saved event. Removes key for caching external access query for getting user name.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			if (e.ModifiedColumnValues.Any(value => value.Name == "Name")) {
				UserConnection userConnection = ((Entity)sender).UserConnection;
				var key = $"GetUserNameById_{e.PrimaryColumnValue}";
				userConnection.ApplicationCache.Remove(key);
				ICacheStore localStorage = userConnection.ApplicationCache.WithLocalCaching();
				localStorage.Remove(key);
			}
		}

		#endregion

	}

} 
