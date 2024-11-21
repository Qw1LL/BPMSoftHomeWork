namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: SetWinnerOpportunityEventListener

	/// <summary>
	/// Handler for Opportunity entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Opportunity")]
	public class SetWinnerOpportunityEventListener : BaseEntityEventListener
	{

		#region Methods: Protected

		protected virtual void SetOpportunityWinner(Entity entity) {
			var setOpportunityWinnerOperation = Core.Factories.ClassFactory.Get<SetOpportunityWinnerOperation>(
					new Core.Factories.ConstructorArgument("userConnection", entity.UserConnection));
			setOpportunityWinnerOperation.DoOperation(entity);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			SetOpportunityWinner(entity);
		}

		#endregion

	}

	#endregion

}
