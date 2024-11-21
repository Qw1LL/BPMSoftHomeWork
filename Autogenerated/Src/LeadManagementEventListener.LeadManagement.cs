 namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: LeadManagementEventListener

	/// <summary>
	/// Listener for Lead entity events.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Lead")]
	public class LeadManagementEventListener : BaseEntityEventListener
	{
		#region Methods: Private

		private static void SetStageId(Entity entity, UserConnection userConnection) {
			var stage = entity.GetTypedColumnValue<Guid>("QualifyStatusId");
			if (!stage.Equals(Guid.Empty)) {
				return;
			}
			Guid stageId = LeadConsts.QualificationUId;
			Core.Configuration.SysSettings.TryGetValue(userConnection, "UseTheSalesReadyLeadLifecycle",
				out var useTheSalesReadyLeadLifecycle);
			if ((bool)useTheSalesReadyLeadLifecycle) {
				Core.Configuration.SysSettings.TryGetValue(userConnection, "DefaultLeadStage",
					out var leadDefaultStage);
				stageId = (Guid)leadDefaultStage;
			}
			entity.SetColumnValue("QualifyStatusId", stageId);
		}

		#endregion

		#region Methods: Public

		/// <summary>Handles entity Inserting event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			SetStageId(entity, userConnection);
			base.OnInserting(sender, e);
		}
		
		#endregion
		
	}

	#endregion

}

