namespace BPMSoft.Core.Process
{

	using BPMSoft.Common;
	using BPMSoft.Configuration;
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
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: SysAdminsNotificationProcessMethodsWrapper

	/// <exclude/>
	public class SysAdminsNotificationProcessMethodsWrapper : ProcessModel
	{

		public SysAdminsNotificationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var recipientEmails = GetSysAdministratorsEmails();
			Set("RecipientEmails", string.Join(";", recipientEmails));
			return true;
		}

			public virtual List<string> GetSysAdministratorsEmails() {
				var userIds = new List<string>();
				var sysAdminRoleId = BaseConsts.SystemAdministratorsSysAdminUnitId;
				var select =
					new Select(UserConnection)
						.Column("Contact", "Email")
						.From("SysAdminUnit")
						.InnerJoin("Contact").On("SysAdminUnit", "ContactId")
						.IsEqual("Contact", "Id")
						.InnerJoin("SysAdminUnitInRole").On("SysAdminUnit", "Id")
						.IsEqual("SysAdminUnitInRole", "SysAdminUnitId")
						.Where("Contact", "Email").IsNotEqual(Column.Parameter(""))
						.And("SysAdminUnitInRole", "SysAdminUnitRoleId")
						.IsEqual(Column.Parameter(sysAdminRoleId))
						.OrderByAsc("Contact", "Email") as Select;
				select.ExecuteReader(r => {
					var userEmail = r.GetColumnValue<string>("Email");
					userIds.Add(userEmail);
				});
				return userIds;
			}

		#endregion

	}

	#endregion

}

