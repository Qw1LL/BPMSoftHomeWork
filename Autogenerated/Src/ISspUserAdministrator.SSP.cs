namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;

	public interface ISspUserAdministrator
	{
		/// <summary>
		/// Creates SysAdminUnit user.
		/// </summary>
		/// <param name="userInfo">New user creation data.</param>
		/// <returns>User identifier.</returns>
		Guid RegisterUser(SspUserInvite userInfo);

		/// <summary>
		/// Gets account group identifier.
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>Account group identifier.</returns>
		Guid GetGroupIdByAccountId(Guid accountId);

		/// <summary>
		/// Gets organization license name.
		/// </summary>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>License name.</returns>
		string GetLicenseName(Guid accountId);

		/// <summary>
		/// Check if SysAdminUnit exist.
		/// </summary>
		/// <param name="name">User name.</param>
		/// <returns>SysAdminUnit identifier.</returns>
		bool CheckIfUserNotExist(string name);

		/// <summary>
		/// Creates Contact user.
		/// </summary>
		/// <param name="email">email for creating contact.</param>
		/// <param name="accountId">Account identifier.</param>
		/// <returns>Contact identifier.</returns>
		Guid CreateContactByEmail(string email, Guid accountId);

		/// <summary>
		/// Set PortalAccountId to SysAdminUnit record.
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits names collection.</param>
		/// <param name="accountId">PortalAccount which will be connected to the record.</param>
		void BindPortalAccountAndActivateUsersByName(List<string> adminUnitsToUpdate, Guid accountId);

		/// <summary>
		/// Activate Users by Ids.
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits ids collection.</param>
		void ActivateUsersByIds(List<Guid> adminUnitsToUpdate);

		/// <summary>
		/// Add Portal account to portal account group
		/// </summary>
		/// <param name="adminUnitsToUpdate">SysAdminUnits id`s collection</param>
		/// <param name="accountGroupId">PortalAccount group which will be connected to the record.</param>
		void AddUsersToPortalAccountGroup(List<Guid> adminUnitsToUpdate, Guid accountGroupId);

		/// <summary>
		/// Creates roles for user.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="userRoles">User roles.</param>
		void CreateSysUserInRole(Guid userId, Guid[] userRoles);

		/// <summary>
		/// Changes user activation status.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="isActive">New user activation status.</param>
		void ChangeUserActivationStatus(Guid userId, bool isActive);
	}
}
