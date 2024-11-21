namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
	using CoreSysSettingsRights = BPMSoft.Core.Configuration.SysSettingsRights;

	#region Class: SysSettingsRightsEventListener

	/// <summary>
	/// Class provides events handling for system settings rights.
	/// </summary>
	[EntityEventListener(SchemaName = "SysSettingsRights")]
	public class SysSettingsRightsEventListener : BaseSysSettingsEventListener<CoreSysSettingsRights>
	{

		#region Methods: Protected

		protected override CoreSysSettingsRights CreateCoreEntity(UserConnection userConnection) {
			return new CoreSysSettingsRights(userConnection);
		}

		protected override void ActualizeCoreEntity(UserConnection userConnection, 
				CoreSysSettingsRights coreEntity, EntityChangeType entityChangeType) {
			CoreSysSettings.ActualizeRights(userConnection, coreEntity, entityChangeType);
		}

		#endregion

	}

	#endregion

}
 
