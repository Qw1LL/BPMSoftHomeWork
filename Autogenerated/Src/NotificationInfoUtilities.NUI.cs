namespace BPMSoft.Configuration
{
	#region Class: NotificationInfoUtilities

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Class of utilities for notification informations.
	/// </summary>
	public static class NotificationInfoUtilities
	{

		#region Classes: Private

		private class SysAdminUnitInRole
		{
			public Guid SysAdminUnit {
				get;
				set;
			}
			public Guid Group {
				get;
				set;
			}
		}

		#endregion

		#region Methods: Private

		private static IEnumerable<SysAdminUnitInRole> GetSysAdminUnitsInGroup(IEnumerable<Guid> sysAdminUnitIds, UserConnection userConnection) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysUserInRole");
			esq.AddColumn("SysUser");
			esq.AddColumn("SysRole");
			IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysRole", sysAdminUnitIds.Select(a => (object)a));
			esq.Filters.Add(filter);
			EntityCollection result = esq.GetEntityCollection(userConnection);
			IEnumerable<SysAdminUnitInRole> sysAdminUnitInGroup =
				result.Select(
					entity =>
						new SysAdminUnitInRole {
							SysAdminUnit = entity.GetTypedColumnValue<Guid>("SysUserId"),
							Group = entity.GetTypedColumnValue<Guid>("SysRoleId")
						});
			return sysAdminUnitInGroup;
		}

		private static IEnumerable<INotificationInfo> CloneNotificationInfo(IEnumerable<SysAdminUnitInRole> sysAdminUnitInGroup, IEnumerable<INotificationInfo> notifications) {
			IEnumerable<Guid> groups = sysAdminUnitInGroup.Select(item => item.Group).Distinct();
			IEnumerable<INotificationInfo> newNotifications = notifications;
			foreach (Guid group in groups) {
				IEnumerable<Guid> sysAdminUnits = sysAdminUnitInGroup
					.Where(item => item.Group.Equals(group))
					.Select(item => item.SysAdminUnit);
				newNotifications = CloneNotificationInfo(group, sysAdminUnits, newNotifications);
			}
			return newNotifications;
		}

		private static IEnumerable<Guid> AddSysAdminUnitInGroup(IEnumerable<SysAdminUnitInRole> sysAdminUnitsInGroup, IEnumerable<Guid> sysAdminUnitIds) {
			IEnumerable<Guid> sysAdminUnits = sysAdminUnitsInGroup.Select(item => item.SysAdminUnit);
			return sysAdminUnitIds.Concat(sysAdminUnits).Distinct();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns collection of ids from SysAdminUnit.
		/// </summary>
		/// <param name="notifications">Collection of notification informations.</param>
		/// <returns>Collection of ids from SysAdminUnit.</returns>
		public static IEnumerable<Guid> GetSysAdminUnits(IEnumerable<INotificationInfo> notifications) {
			return notifications.Select(notification => notification.SysAdminUnit).Distinct();
		}

		/// <summary>
		/// Returns collection of informations. Clones notification info for each SysAdminUnit from group.
		/// </summary>
		/// <param name="group">Id of SysAdminUnit group.</param>
		/// <param name="sysAdminUnits">Collection of ids from SysAdminUnit.</param>
		/// <param name="notifications">Collection of informations.</param>
		/// <returns>Collection of notification informations.</returns>
		public static IEnumerable<INotificationInfo> CloneNotificationInfo(Guid group, IEnumerable<Guid> sysAdminUnits, IEnumerable<INotificationInfo> notifications) {
			IEnumerable<INotificationInfo> notificationsBySysAdminUnit = GetNotificationInfoBySysAdminUnit(group, notifications);
			IEnumerable<INotificationInfo> newNotifications = notifications;
			foreach (INotificationInfo notification in notificationsBySysAdminUnit) {
				IEnumerable<INotificationInfo> result = sysAdminUnits
					.Select(sysAdminUnit => new NotificationInfo() {
						Body = notification.Body,
						EntitySchemaName = notification.EntitySchemaName,
						GroupName = notification.GroupName,
						ImageId = notification.ImageId,
						LoaderName = notification.LoaderName,
						Title = notification.Title,
						EntityId = notification.EntityId,
						MessageId = notification.MessageId,
						SysAdminUnit = sysAdminUnit
					});
				newNotifications = newNotifications.Concat(result);
			}
			return newNotifications;
		}

		/// <summary>
		/// Returns collection of informations by SysAdminUnit.
		/// </summary>
		/// <param name="sysAdminUnits">Collection of ids from SysAdminUnit.</param>
		/// <param name="notifications">Collection of notifications.</param>
		/// <returns>Collection of notification informations.</returns>
		public static IEnumerable<INotificationInfo> GetNotificationInfoBySysAdminUnit(Guid sysAdminUnit, IEnumerable<INotificationInfo> notifications) {
			return notifications.Where(notification => notification.SysAdminUnit.Equals(sysAdminUnit));
		}

		/// <summary>
		/// Returns collection of ids from SysAdminUnit and modify collection of notification informations.
		/// </summary>
		/// <param name="notifications">Collection of notifications.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Collection of ids from SysAdminUnit.</returns>
		public static IEnumerable<Guid> GetUsers(ref IEnumerable<INotificationInfo> notifications, UserConnection userConnection) {
			IEnumerable<Guid> sysAdminUnitIds = GetSysAdminUnits(notifications);
			IEnumerable<SysAdminUnitInRole> sysAdminUnitsInGroup = GetSysAdminUnitsInGroup(sysAdminUnitIds, userConnection);
			if (sysAdminUnitsInGroup.Any()) {
				sysAdminUnitIds = AddSysAdminUnitInGroup(sysAdminUnitsInGroup, sysAdminUnitIds);
				notifications = CloneNotificationInfo(sysAdminUnitsInGroup, notifications);
			}
			return sysAdminUnitIds;
		}

		/// <summary>
		/// Returns dictionary with notifications count by group.
		/// </summary>
		/// <param name="sysAdminUnits">Collection of ids from SysAdminUnit.</param>
		/// <param name="notifications">Collection of notifications.</param>
		/// <returns>Dictionary with notifications count by group.</returns>
		public static Dictionary<string, int> GetCountNotificationInGroup(IEnumerable<INotificationInfo> notifications) {
			var result = new Dictionary<string, int>();
			IEnumerable<string> groups = notifications.Select(notification => notification.GroupName).Distinct();
			foreach (string group in groups) {
				int countInGroup = notifications.Count(notification => notification.GroupName.Equals(group));
				result.Add(group, countInGroup);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

