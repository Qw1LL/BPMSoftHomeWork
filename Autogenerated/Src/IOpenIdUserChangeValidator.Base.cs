namespace BPMSoft.Configuration.OpenIdAuth
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Interface: IOpenIdUserChangeValidator

	public interface IOpenIdUserChangeValidator
	{
		/// <summary>
		/// Checks if existing user can be modified
		/// </summary>
		/// <param name="userConnection">Connection to database</param>
		/// <param name="sysAdminUnitModified">Modified entity of User</param>
		/// <returns>Returns true if user can be modified and saved to database, otherwise return false</returns>
		bool CanChangeUser(UserConnection userConnection, Entity sysAdminUnitModified);
	}
	
	#endregion
	
}
