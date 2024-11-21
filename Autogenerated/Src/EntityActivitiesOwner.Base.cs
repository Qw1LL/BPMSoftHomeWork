namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: EntityActivitiesOwner

	/// <summary>
	/// Class which manages owner of activities for the entity.
	/// </summary>
	public class EntityActivitiesOwner
	{

		#region Fields: Private

		private readonly string _activityEntitySchemaName = "Activity";
		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initilizes new instance of <see cref="EntityActivitiesOwner"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public EntityActivitiesOwner(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetEntityOwnerActivitiesSelect(string entityPrimaryColumnName, EntityActivitiesOwnerInfo entityOwnerInfo) {
			return new Select(_userConnection)
				.Column("Id")
				.From("Activity")
				.Where("OwnerId")
					.IsEqual(Column.Parameter(entityOwnerInfo.OldOwnerId))
				.And(entityPrimaryColumnName)
					.IsEqual(Column.Parameter(entityOwnerInfo.EntityId))
				.And("TypeId")
					.IsNotEqual(Column.Parameter(ActivityConsts.EmailTypeUId))
				.And("StatusId")
					.IsNotEqual(Column.Parameter(ActivityConsts.CanceledStatusUId))
				.And("StatusId")
					.IsNotEqual(Column.Parameter(ActivityConsts.CompletedStatusUId))
				as Select;
		}

		private Guid GetUserIdByContact(Guid contactId) {
			Select selectQuery = new Select(_userConnection)
					.Column("Id")
					.From("VwSysAdminUnit")
					.Where("ContactId").IsEqual(Column.Parameter(contactId))
					.And("SysAdminUnitTypeId").IsEqual(Column.Parameter(BaseConsts.UserSysAdminUnitTypeId))
				as Select;
			selectQuery.ExecuteSingleRecord(reader => reader.GetColumnValue<Guid>("Id"), out Guid adminUnit);
			return adminUnit;
		}

		private List<Guid> GetEntityOwnerActivitiesId(string entityPrimaryColumnName, EntityActivitiesOwnerInfo entityOwnerInfo) {
			Select select = GetEntityOwnerActivitiesSelect(entityPrimaryColumnName, entityOwnerInfo);
			return select.ExecuteEnumerable(reader => reader.GetColumnValue<Guid>("Id")).ToList();
		}

		private void DenyActivityManagingRights(Guid activityId, Guid sysAdminUnitId) {
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Read, _activityEntitySchemaName, activityId);
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Edit, _activityEntitySchemaName, activityId);
			_userConnection.DBSecurityEngine.ForceDeleteEntitySchemaRecordRightLevel(sysAdminUnitId,
				EntitySchemaRecordRightOperation.Delete, _activityEntitySchemaName, activityId);
		}

		private string GetEntityConnectionColumnName(EntitySchema activitySchema, EntityActivitiesOwnerInfo entityOwnerInfo) {
			string entityPrimaryColumnName = activitySchema.Columns
				.FirstOrDefault(column =>
					column.IsLookupType &&
					!column.UsageType.Equals(EntitySchemaColumnUsageType.Advanced) &&
					column.ReferenceSchema.Name == entityOwnerInfo.EntitySchemaName &&
					column.ColumnValueName.Contains(entityOwnerInfo.EntitySchemaName))?.ColumnValueName;
			return entityPrimaryColumnName;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Changes owner of entity activities.
		/// <param name="entityOwnerInfo">Information about entity and owners of activities.</param>
		/// </summary>
		public virtual void Change(EntityActivitiesOwnerInfo entityOwnerInfo) {
			EntitySchema activitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(_activityEntitySchemaName);
			string entityPrimaryColumnName = GetEntityConnectionColumnName(activitySchema, entityOwnerInfo);
			if (entityPrimaryColumnName.IsNotNullOrEmpty()) {
				Entity activityEntity = activitySchema.CreateEntity(_userConnection);
				activityEntity.UseAdminRights = false;
				foreach (var activityId in GetEntityOwnerActivitiesId(entityPrimaryColumnName, entityOwnerInfo)) {
					if (activityEntity.FetchFromDB(activityId)) {
						activityEntity.SetColumnValue("OwnerId", entityOwnerInfo.NewOwnerId);
						activityEntity.Save(false);
						DenyActivityManagingRights(activityId, GetUserIdByContact(entityOwnerInfo.OldOwnerId));
					}
				}
			}
		}

		#endregion

	}

	#endregion

}
