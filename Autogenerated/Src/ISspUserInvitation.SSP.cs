namespace BPMSoft.Configuration.SSP
{
	using System;

	#region Interface: ISspUserInvitation

	public interface ISspUserInvitation
	{
		/// <summary>
		/// Email of portal user.
		/// </summary>
		string Email { get; set; }

		/// <summary>
		/// Portal user ContactId.
		/// </summary>
		Guid ContactId { get; set; }

		/// <summary>
		/// Portal user Contact name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Portal user SysAdminUnitId.
		/// </summary>
		Guid SysAdminUnitId { get; set; }

		/// <summary>
		/// User roles.
		/// </summary>
		Guid[] UserRoles { get; set; }

		/// <summary>
		/// Portal user PortalAccountId.
		/// </summary>
		Guid PortalAccountId { get; set; }

		/// <summary>
		/// User license name.
		/// </summary>
		string LicenseName { get; set; }

		/// <summary>
		/// Portal user AccountGroupId.
		/// </summary>
		Guid AccountGroupId { get; set; }

		/// <summary>
		/// Portal user Name.
		/// </summary>
		string UserName { get; set; }

		/// <summary>
		/// Result of operation.
		/// </summary>
		bool Success { get; set; }

		/// <summary>
		/// Error while inviting.
		/// </summary>
		string Error { get; set; }

		/// <summary>
		/// Status of sysadminunit record.
		/// </summary>
		bool IsUserActive { get; set; }

	}

	#endregion

}
