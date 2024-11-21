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
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.Text;

	#region Class: PushExpiredLicensesNotificationProcessMethodsWrapper

	/// <exclude/>
	public class PushExpiredLicensesNotificationProcessMethodsWrapper : ProcessModel
	{

		public PushExpiredLicensesNotificationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("PushNotificationScriptTaskExecute", PushNotificationScriptTaskExecute);
		}

		#region Methods: Private

		private bool PushNotificationScriptTaskExecute(ProcessExecutingContext context) {
			var users = Get<ICompositeObjectList<ICompositeObject>>("Users");
			Guid sysLicPackageSchemaUId = new Guid("BBA64AD2-FF65-46F4-911D-4068AA0AF48A");
			Guid expireLicenseNotificationProcessUId = new Guid("1893CE0C-D743-4999-BF79-999E874737EB");
			var adminUnitId = Get<Guid>("AdminUnitRole");
			var select = (Select)
			new Select(UserConnection)
				.Column("sau", "Id")
				.Column("sau", "ContactId")
				.Column("sc", "Name").As("CultureName")
			.From("SysAdminUnit").As("sau")
			.InnerJoin("SysCulture").As("sc").On("sc", "Id").IsEqual("sau", "SysCultureId")
			.Where("sau", "Active").IsEqual(Column.Parameter(true))
				.And("sau", "ContactId").Not().IsNull()
				.And("sau", "SysAdminUnitTypeValue").IsEqual(Column.Parameter(4));
			if (users.Count == 0) {
				select.And("sau", "Id").IsEqual(Column.Parameter(adminUnitId));
			} else {
				select.InnerJoin("SysUserInRole").As("suir").On("sau", "Id").IsEqual("suir", "SysUserId")
					.And("suir", "SysRoleId").IsEqual(Column.Parameter(adminUnitId));
			}
			var remindingUtilities = new RemindingUtilities();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader adminUnit = select.ExecuteReader(dbExecutor)) {
					while (adminUnit.Read()) {
						var config = new RemindingConfig(sysLicPackageSchemaUId) {
							LoaderId = expireLicenseNotificationProcessUId,
							AuthorId = UserConnection.CurrentUser.ContactId,
							SourceId = RemindingConsts.RemindingSourceAuthorId,
							ContactId = adminUnit.GetColumnValue<Guid>("ContactId"),
							SubjectId = Guid.Empty,
							Description = GetLczDescription(UserConnection, Get<string>("NotificationDescription"),
								CultureInfo.GetCultureInfo(adminUnit.GetColumnValue<String>("CultureName"))),
							RemindTime = DateTime.UtcNow
						};
						remindingUtilities.CreateReminding(UserConnection, config);
					}
				}
			}
			return true;
		}

			private string GetLczDescription(UserConnection userConnection, string description, CultureInfo cultureInfo) {
				return String.Format(description,
					GetLczString(userConnection, "CaptionStart", cultureInfo),
					GetLczString(userConnection, "CaptionEnd", cultureInfo),
					GetLczString(userConnection, "IssuedCount", cultureInfo),
					GetLczString(userConnection, "AvailableCount", cultureInfo),
					GetLczString(userConnection, "FooterStart", cultureInfo),
					GetLczString(userConnection, "FooterEnd", cultureInfo),
					GetLczString(userConnection, "AndMoreStart", cultureInfo),
					GetLczString(userConnection, "AndMoreEnd", cultureInfo));
			}
			
			
			private string GetLczString(UserConnection userConnection, string lczName, CultureInfo cultureInfo) {
				string localizableStringName = string.Format("Parameters.{0}.Value", lczName);
				var result = new LocalizableString(userConnection.Workspace.ResourceStorage, "PushExpiredLicensesNotificationProcess",
					localizableStringName
				);
				if (result.HasCultureValue(cultureInfo)) {
					return result.GetCultureValue(cultureInfo);
				}
				return result;
			}

		#endregion

	}

	#endregion

}

