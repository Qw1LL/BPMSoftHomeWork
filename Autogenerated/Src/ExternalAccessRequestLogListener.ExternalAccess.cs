namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;
	using System.Security;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: ExternalAccessRequestLogListener

	/// <summary>
	/// Listener for 'ExternalAccessRequestLog' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "ExternalAccessRequestLog")]
	public class ExternalAccessRequestLogListener : BaseEntityEventListener
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("ExternalAccess");

		#endregion

		private void CheckCanManageSolution(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
		}

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			base.OnInserting(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (userConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageSolution")) {
				return;
			}
			Guid requestedById = entity.GetTypedColumnValue<Guid>("RequestedById");
			if (requestedById != userConnection.CurrentUser.ContactId) {
				e.IsCanceled = true;
				_log.Warn($"User {userConnection.CurrentUser.Name} tried to insert ExternalAccessRequestLog with " +
					$"RequestedBy = {requestedById}");
				var message = new LocalizableString(userConnection.ResourceStorage, "ExternalAccessRequestLogListener",
					"LocalizableStrings.IncorrectIssuedByMessageCaption.Value");
				throw new SecurityException(message);
			}
		}

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
		}

		#endregion

	}

	#endregion

}

