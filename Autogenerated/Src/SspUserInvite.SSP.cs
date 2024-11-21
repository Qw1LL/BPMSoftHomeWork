namespace BPMSoft.Configuration.SSP
{
	using System;

	#region Class: SspUserInvite

	/// <summary>
	/// Container for portal invite.
	/// </summary>
	public class SspUserInvite : ISspUserInvitation
	{
		#region Properties: Public

		/// <summary>
		/// Email of portal user.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Portal user ContactId.
		/// </summary>
		public Guid ContactId { get; set; }

		/// <summary>
		/// Portal user Contact name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Portal user SysAdminUnitId.
		/// </summary>
		public Guid SysAdminUnitId { get; set; }

		/// <summary>
		/// User roles.
		/// </summary>
		public Guid[] UserRoles { get; set; }

		/// <summary>
		/// Portal user PortalAccountId.
		/// </summary>
		public Guid PortalAccountId { get; set; }

		/// <summary>
		/// User license name.
		/// </summary>
		public string LicenseName { get; set; }

		/// <summary>
		/// Portal user AccountGroupId.
		/// </summary>
		public Guid AccountGroupId { get; set; }

		/// <summary>
		/// Portal user Name.
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Result of operation.
		/// </summary>
		public bool Success { get; set; } = true;

		/// <summary>
		/// Error while inviting.
		/// </summary>
		public string Error { get; set; }

		/// <summary>
		/// Status of sysadminunit record.
		/// </summary>
		public bool IsUserActive { get; set; }

		#endregion

	}

	#endregion

}
