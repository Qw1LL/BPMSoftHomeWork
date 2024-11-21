namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
	using CoreSysSettingsValue = BPMSoft.Core.Configuration.SysSettingsValue;

	#region Class: SysSettingsValueEventListener

	/// <summary>
	/// Class provides events handling for system settings values.
	/// </summary>
	[EntityEventListener(SchemaName = "SysSettingsValue")]
	public class SysSettingsValueEventListener : BaseSysSettingsEventListener<CoreSysSettingsValue>
	{

		#region Methods: Protected

		protected override CoreSysSettingsValue CreateCoreEntity(UserConnection userConnection) {
			return new CoreSysSettingsValue(userConnection);
		}

		protected override void ActualizeCoreEntity(UserConnection userConnection,
				CoreSysSettingsValue coreEntity, EntityChangeType entityChangeType) {
			CoreSysSettings.ActualizeValues(userConnection, coreEntity, entityChangeType);
		}

		#endregion

	}

	#endregion

}
 
