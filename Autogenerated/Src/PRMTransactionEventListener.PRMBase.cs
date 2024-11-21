namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;

	#region Class: PRMTransactionEventListener

	/// <summary>
	/// Listener for 'PRMTransaction' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "PRMTransaction")]
	public class PRMTransactionEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			Entity prmTransactionEntity = (Entity)sender;
			Guid partnershipId = prmTransactionEntity.GetTypedColumnValue<Guid>("PartnershipId");
			if (partnershipId == Guid.Empty) {
				TransactionEnricher transactionEnricher = new TransactionEnricher(prmTransactionEntity.UserConnection);
				transactionEnricher.EnrichTransactionWithPartnership(prmTransactionEntity);
			}
			base.OnSaving(sender, e);
		}

		#endregion

	}

	#endregion

}

