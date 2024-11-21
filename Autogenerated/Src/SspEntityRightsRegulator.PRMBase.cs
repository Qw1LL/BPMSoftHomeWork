namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;

	#region Class: SspEntityRightsRegulator

	/// <summary>
	/// Class, which is manage entity record rights.
	/// </summary>
	public class SspEntityRightsRegulator
	{

		#region Fields: Private

		private readonly Guid _organizationSysAdminUnitId = new Guid("DF93DCB9-6BD7-DF11-9B2A-001D60E938C6");
		private readonly UserConnection _userConnection;
		private readonly string _entitySchemaName;

		#endregion

		public SspEntityRightsRegulator(UserConnection userConnection, string entitySchemaName) {
			_userConnection = userConnection;
			_entitySchemaName = entitySchemaName;
		}

		#region Methods: Private

		private bool TryGetOwnerSspUserId(Guid ownerId, out Guid ownerSSPUserId) {
			ownerSSPUserId = Guid.Empty;
			Select selectQuery = new Select(_userConnection)
										.Column("Id")
										.From("VwSspAdminUnit")
										.Where("ContactId").IsEqual(Column.Parameter(ownerId))
										.And("SysAdminUnitTypeId")
										.IsEqual(Column.Const(BaseConsts.UserSysAdminUnitTypeId))
											as Select;
			selectQuery.ExecuteSingleRecord<Guid>(reader =>
				reader.GetColumnValue<Guid>("Id"), out ownerSSPUserId);
			return ownerSSPUserId != Guid.Empty;
		}

		private bool TryGetSspOrganizationId(Guid partnerId, out Guid organizationId) {
			organizationId = Guid.Empty;
			Select selectQuery = new Select(_userConnection)
					.Column("Id")
					.From("VwSspAdminUnit")
					.Where("PortalAccountId").IsEqual(Column.Parameter(partnerId))
					.And("SysAdminUnitTypeId")
					.IsEqual(Column.Const(_organizationSysAdminUnitId))
				as Select;
			selectQuery.ExecuteSingleRecord<Guid>(reader =>
				reader.GetColumnValue<Guid>("Id"), out organizationId);
			return organizationId != Guid.Empty;
		}

		private bool IsNeedToDenyAccess(Guid newContactId, Guid oldContactId) {
			return newContactId != oldContactId && oldContactId != Guid.Empty;
		}

		private bool IsNeedToGrantAccess(Guid newContactId, Guid oldContactId) {
			return newContactId != oldContactId && newContactId != Guid.Empty;
		}

		private void GrantManagingRights(Guid sysAdminUnitId, Guid entityId) {
			_userConnection.DBSecurityEngine.SetEntitySchemaRecordReadingRightLevel(sysAdminUnitId,
				_entitySchemaName, entityId, EntitySchemaRecordRightLevel.AllowAndGrant);
			_userConnection.DBSecurityEngine.SetEntitySchemaRecordEditingRightLevel(sysAdminUnitId,
				_entitySchemaName, entityId, EntitySchemaRecordRightLevel.AllowAndGrant);
		}

		private void DenyManagingRights(Guid sysAdminUnitId, Guid entityId) {
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Read, _entitySchemaName, entityId);
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Edit, _entitySchemaName, entityId);
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Delete, _entitySchemaName, entityId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Manages rights of the entity for old and new organization's partner.
		/// </summary>
		/// <param name="entityId">Identifier of the entity whose rights will be changed.</param>
		/// <param name="newPartnerId">Identifier of the partner who will receive the rights on the entity.</param>
		/// <param name="oldPartnerId">Identifier of the partner that will lose rights on the entity.</param>
		public virtual void ManageEntityOrganizationRights(Guid entityId, Guid newPartnerId, Guid oldPartnerId) {
			if (IsNeedToGrantAccess(newPartnerId, oldPartnerId) &&
					TryGetSspOrganizationId(newPartnerId, out Guid organizationId)) {
				GrantManagingRights(organizationId, entityId);
			}
			if (IsNeedToDenyAccess(newPartnerId, oldPartnerId) &&
					TryGetSspOrganizationId(oldPartnerId, out Guid oldOrganizationId)) {
				DenyManagingRights(oldOrganizationId, entityId);
			}
		}

		/// <summary>
		/// Manages rights of the entity for old and new owner.
		/// </summary>
		/// <param name="entityId">Identifier of the entity whose rights will be changed.</param>
		/// <param name="ownerId">Identifier of the contact who will receive the rights on the entity.</param>
		/// <param name="oldOwnerId">Identifier of the contact that will lose rights on the entity.</param>
		public virtual void ManageEntityOwnerRights(Guid entityId, Guid ownerId, Guid oldOwnerId) {
			if (IsNeedToGrantAccess(ownerId, oldOwnerId) &&
					TryGetOwnerSspUserId(ownerId, out Guid ownerUserId)) {
				GrantManagingRights(ownerUserId, entityId);
			}
			if (IsNeedToDenyAccess(ownerId, oldOwnerId) &&
					TryGetOwnerSspUserId(oldOwnerId, out Guid oldOwnerUserId)) {
				DenyManagingRights(oldOwnerUserId, entityId);
			}
		}
		
		/// <summary>
		/// Grants entity read rights to the organization.
		/// </summary>
		/// <param name="entityId">Entity identifier.</param>
		/// <param name="partherId">Partner identifier.</param>
		public void GrantOrganizationReadRights(Guid entityId, Guid partherId) {
			if (TryGetSspOrganizationId(partherId, out Guid organizationId)) {
				_userConnection.DBSecurityEngine.SetEntitySchemaRecordReadingRightLevel(organizationId,
					_entitySchemaName, entityId, EntitySchemaRecordRightLevel.Allow);
			}
		}

		#endregion

	}

	#endregion

}

