namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Entities.AsyncOperations;

	#region Class: LeadEventListener

	/// <summary>
	/// Listener for Lead entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Lead")]
	public class LeadEventListener : BaseEntityEventListener
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
			LeadEntityEventAsyncOperationArgs operationArgs = new LeadEntityEventAsyncOperationArgs((Entity)sender, e);
			asyncExecutor.ExecuteAsync<LeadRightsRegulator>(operationArgs);
		}

		#endregion

	}

	#endregion

}

