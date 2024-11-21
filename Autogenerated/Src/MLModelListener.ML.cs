namespace BPMSoft.Configuration.ML
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: MLModelListener

	/// <summary>
	/// Listener for 'MLModel' entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "MLModel")]
	public class MLModelListener : BaseEntityEventListener
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
			userConnection.ApplicationCache.Remove(MLConsts.PredictableEntitiesScriptKey);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			UserConnection userConnection = ((Entity)sender).UserConnection;
			userConnection.ApplicationCache.Remove(MLConsts.PredictableEntitiesScriptKey);
		}

		#endregion

	}

	#endregion

}

