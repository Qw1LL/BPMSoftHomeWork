using System;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;

namespace BPMSoft.Configuration
{
	public static class AdminUtilities
	{
		public static readonly Guid DefColumnRightLevelId = new Guid("007F04EE-1FE1-DF11-971B-001D60E938C6");			
		
		public static Guid GetRootAdminUnitId(UserConnection userConnection) {
			Select select = new Select(userConnection).Top(1).Column("Id").From("SysAdminUnit").
				Where("SysAdminUnitTypeValue").IsEqual(Column.Const(0)).And("ParentRoleId").IsNull() as Select;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return userConnection.DBTypeConverter.DBValueToGuid(dataReader["Id"]);
					}
				}
				
			}
			return Guid.Empty;
		}
	}
}
