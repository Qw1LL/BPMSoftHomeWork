namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;

	#region Class: PartnershipRightsDistributor

	/// <summary>
	/// Class, which is manage partnership record rights.
	/// </summary>
	public class PartnershipRightsDistributor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly string _entitySchemaName = "Partnership";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="PartnershipRightsDistributor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public PartnershipRightsDistributor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<Guid> GetActivePartnerships(Guid partherId) {
			var partnershipSelect = GetActivePartnershipsSelect(partherId);
			var partnerships = new List<Guid>();
			partnershipSelect.ExecuteReader(reader => {
				partnerships.Add(reader.GetColumnValue<Guid>("Id"));
			});
			return partnerships;
		}

		private Select GetActivePartnershipsSelect(Guid partherId) {
			return new Select(_userConnection)
					.Column("Id")
					.From(_entitySchemaName)
					.Where("AccountId").IsEqual(Column.Parameter(partherId))
					.And("IsActive")
					.IsEqual(Column.Const(true))
				as Select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Grants organization read rights to active partnerships of it`s account.
		/// </summary>
		/// <param name="entityId">Entity identifier.</param>
		/// <param name="partherId">Partner identifier.</param>
		public void GrantPartnershipReadRightsToOrganization(Guid organizationId, Guid partherId) {
			foreach (var partnership in GetActivePartnerships(partherId)) {
				_userConnection.DBSecurityEngine.SetEntitySchemaRecordReadingRightLevel(organizationId,
					_entitySchemaName, partnership, EntitySchemaRecordRightLevel.Allow);
			}
		}


		#endregion

	}

	#endregion

}

