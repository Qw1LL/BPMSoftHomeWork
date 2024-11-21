namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: ServiceObjectEventListener

	[EntityEventListener(SchemaName = "ServiceObject")]
	public class ServiceObjectEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		public void ChangeReadRights(Entity entity, EntitySchemaRecordRightLevel rightLevel) {
			bool rightsEnabled = SystemSettings.GetValue(entity.UserConnection,	"EnableRightsOnServiceObjects", false);
			if (rightsEnabled) {
				var regulator = new ServiceObjectsRightsRegulator(entity.UserConnection, "ServicePact");
				Guid servicePactId = entity.GetTypedColumnValue<Guid>("ServicePactId");
				regulator.ChangeContactReadRightsLevel(entity.GetTypedColumnValue<Guid>("ContactId"), servicePactId, rightLevel);
				regulator.ChangeOrganizationReadRightsLevel(entity.GetTypedColumnValue<Guid>("AccountId"), servicePactId, rightLevel);
			}

		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnInserted"/>
		/// </summary>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Entity entity = (Entity)sender;
			ChangeReadRights(entity, EntitySchemaRecordRightLevel.Allow);
		}

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnDeleted"/>
		/// </summary>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Entity entity = (Entity)sender;
			ChangeReadRights(entity, EntitySchemaRecordRightLevel.Deny);
		}

		#endregion

	}

	#endregion

}

