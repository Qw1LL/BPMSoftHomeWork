namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Security;
	using System.Text;

	#region Class: DeactivateInactiveUsersMethodsWrapper

	/// <exclude/>
	public class DeactivateInactiveUsersMethodsWrapper : ProcessModel
	{

		public DeactivateInactiveUsersMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			int inactiveUserDeactivationIntervalInDay = SysSettings.GetValue(UserConnection, "InactiveUserDeactivationIntervalInDay", 0);
			
			if (inactiveUserDeactivationIntervalInDay <= 0) {
				 return true;
			}
			
			DateTime accountLastActivityTimeMax = DateTime.UtcNow.AddDays(Convert.ToDouble(-inactiveUserDeactivationIntervalInDay));
			var sysAdminUnitSelect = GetInactiveUsersSelect(accountLastActivityTimeMax);
			 
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = sysAdminUnitSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						TryInactiveUserDeactivationById(dataReader.GetColumnValue<Guid>("Id"));
					}
				}
			}
			return true;
		}

			public virtual Select GetInactiveUsersSelect(DateTime accountLastActivityTimeMax)
			{
				return new Select(UserConnection)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysAdminUnit", "LastActivityTime").Not().IsNull()
				.And("SysAdminUnit", "LastActivityTime").IsLess(new QueryParameter(accountLastActivityTimeMax))
				.And("SysAdminUnit", "SysAdminUnitTypeValue").In(
					Column.Parameter(Core.DB.SysAdminUnitType.User),
					Column.Parameter(Core.DB.SysAdminUnitType.SelfServicePortalUser))
				as Select;
			}
			
			public virtual void TryInactiveUserDeactivationById(Guid userId)
			{
				try {
					UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanAvoidInactiveUserDeactivation", userId);
				} catch (SecurityException e) {
					SetAdminUnitInactive(userId);
				}
			}
			
			public virtual void SetAdminUnitInactive(Guid adminUnitId)
			{
				var update = new Update(UserConnection, "SysAdminUnit")
					.Set("Active", Column.Parameter(false))
					.Set("LastActivityTime", Column.Parameter(null, "DateTime"))
				.Where("Id").IsEqual(Column.Parameter(adminUnitId)) as Update;
				update.Execute();
			}

		#endregion

	}

	#endregion

}

