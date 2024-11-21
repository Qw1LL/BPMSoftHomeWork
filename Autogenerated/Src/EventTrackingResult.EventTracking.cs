namespace BPMSoft.Configuration.EventTrackingResult
{

	#region Enum: EventTrackingResult

	public enum EventTrackingResult
	{
		Ok = 0,
		ApiKeyNotFound = 1,
		InfrastructureNotDeployed = 2,
		OtherError = 3,
		ApiKeyAlreadyUsed = 4,
		IncorrectBpmAuthKey = 5,
		SysSettingIsEmpty = 6,
		DomainIsEmpty = 7
	}

	#endregion

}
