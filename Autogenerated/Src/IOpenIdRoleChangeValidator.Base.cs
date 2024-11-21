namespace BPMSoft.Configuration.OpenIdAuth
{
	using System;
	using BPMSoft.Core;
	
	#region Interface: IOpenIdRoleChangeValidator

	public interface IOpenIdRoleChangeValidator
	{
		bool CanChangeUserInRole(UserConnection userConnection, Guid userId, Guid roleId);
	}
	
	#endregion
	
}
