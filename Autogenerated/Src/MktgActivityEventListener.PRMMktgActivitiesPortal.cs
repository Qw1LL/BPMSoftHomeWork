namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;

	#region Class: MktgActivityEventListener

	/// <summary>
	/// Listener for MktgActivity entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "MktgActivity")]
	public class MktgActivityEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			UserConnection userConnection = ((Entity)sender).UserConnection;
			IEntityEventAsyncExecutor asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(new ConstructorArgument("userConnection", userConnection));
			EntityEventAsyncOperationArgs operationArgs = new EntityEventAsyncOperationArgs((Entity)sender, e);
			asyncExecutor.ExecuteAsync<MktgActivityRightsRegulator>(operationArgs);
		}

		#endregion

	}

	#endregion

}

