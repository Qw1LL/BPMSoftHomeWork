namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: OmniChatEventListener

	/// <summary>
	/// Class provides OmniChat entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "OmniChat")]
	public class OmniChatEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void SetFieldValues(object sender) {
			var entity = (Entity)sender;
			if (entity.GetTypedColumnValue<Guid>("OperatorId").IsNotEmpty()
					&& entity.GetTypedColumnValue<Guid>("OperatorId") != entity.GetTypedOldColumnValue<Guid>("OperatorId")) {
				entity.SetColumnValue("AcceptDate", entity.UserConnection.CurrentUser.GetCurrentDateTime());
				entity.SetColumnValue("DirectedOperatorId", null);
			}
			if (entity.GetTypedColumnValue<Guid>("OperatorId").IsEmpty()
					&& entity.GetTypedOldColumnValue<Guid>("OperatorId").IsNotEmpty()) {
				entity.SetColumnValue("AcceptDate", null);
			}
		}

		private void DeleteOmnichannelMessages(object sender) {
			var entity = (Entity)sender;
			new Delete(entity.UserConnection)
				.From("OmnichannelMessages")
				.Where("ChatId").IsEqual(Column.Parameter(entity.GetTypedColumnValue<Guid>("Id")))
				.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			SetFieldValues(sender);
			base.OnUpdating(sender, e);
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			DeleteOmnichannelMessages(sender);
		}

		#endregion

	}

	#endregion

} 
