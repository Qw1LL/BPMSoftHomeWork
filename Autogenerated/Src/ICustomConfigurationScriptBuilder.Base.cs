namespace BPMSoft.Configuration 
{
	using BPMSoft.Core;

	#region Interface: ICustomConfigurationScriptBuilder
	
	public interface ICustomConfigurationScriptBuilder
	{
		string BuildScript(UserConnection userConnection);
	}
	
	#endregion
	
}
