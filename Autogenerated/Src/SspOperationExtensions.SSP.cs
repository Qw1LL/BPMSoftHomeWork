namespace BPMSoft.Configuration.SSP
{
	using System.Security;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: SspOperationExtensions

	/// <summary>
	/// Class for working with available operations on ssp.
	/// </summary>
	public static class SspOperationExtensions
	{

		/// <summary>
		/// Checks if the user has rights to manage ssp users.
		/// </summary>
		/// <param name="securityEngine">Security engine <see cref="DBSecurityEngine"/></param>
		public static void CheckCanManageSspUsers(this DBSecurityEngine securityEngine) {
			bool canAdministrate = securityEngine.GetCanExecuteOperation("CanManageUsers") ||
				securityEngine.GetCanExecuteOperation("CanAdministratePortalUsers");
			if (!canAdministrate) {
				throw new SecurityException(string.Format(new LocalizableString("BPMSoft.Core",
					"DBSecurityEngine.Exception.CurrentUserCannotExecuteAdminOperation"), "CanAdministratePortalUsers"));
			}
		}
	}

	#endregion

}
