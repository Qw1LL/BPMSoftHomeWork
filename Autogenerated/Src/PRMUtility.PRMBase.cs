namespace BPMSoft.Configuration.PRM 
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	/// <summary>
	/// Utility class for PRM.
	/// </summary>
	public class PRMUtility 
	{

		#region Fields: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection;

		/// <summary>
		/// SysAdminUnit type organisation role. 
		/// </summary>
		protected readonly int OrganiztionRoleConst = (int)BPMSoft.Core.DB.SysAdminUnitType.Organisation;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="userConnection">User connection</param>
		public PRMUtility(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Default value SysCulture unique identifier of current user.
		/// </summary>
		protected Guid DefaultCultureId {
			get {
				return UserConnection.CurrentUser.SysCultureId;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Select query to find a role by account.
		/// </summary>
		/// <param name="accountId">Unique idetifier of account in patrnership</param>
		/// <returns>Result select</returns>
		protected virtual Select GetSelectPartnershipRoleByAccountQuery(Guid accountId) {
			Select resultSelect = new Select(UserConnection).Top(1)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysAdminUnitTypeValue").IsEqual(Column.Parameter(OrganiztionRoleConst))
					.And("AccountId").IsEqual(Column.Parameter(accountId)) as Select;
			return resultSelect;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Return unique idetifier of partnership role in SysAdminUnit table.
		/// If row not exists return Guid.Empty.
		/// </summary>
		/// <param name="accountId">Unique idetifier of account in patrnership</param>
		/// <returns>Return unique idetifier of partnership if exists else return Guid.Empty</returns>
		public virtual Guid GetPartnershipRoleByAccount(Guid accountId) {
			Guid resultId = Guid.Empty;
			if (accountId != Guid.Empty) {
				Select selectPartnershipRole = GetSelectPartnershipRoleByAccountQuery(accountId);
				 resultId = selectPartnershipRole.ExecuteScalar<Guid>();
				return resultId;
			} else {
				return resultId;
			}
			
		}

		#endregion

	}
}
