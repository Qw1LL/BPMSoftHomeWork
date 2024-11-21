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
	using System.Security;
	using System.Text;

	#region Class: ExpireLicenseNotificationProcessMethodsWrapper

	/// <exclude/>
	public class ExpireLicenseNotificationProcessMethodsWrapper : ProcessModel
	{

		public ExpireLicenseNotificationProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("SetsNotificationDescriptionScriptTaskExecute", SetsNotificationDescriptionScriptTaskExecute);
		}

		#region Methods: Private

		private bool SetsNotificationDescriptionScriptTaskExecute(ProcessExecutingContext context) {
			SetNotificationDescription();
			return true;
		}

			private string TruncateString(string source, int length) {
				return (source.Length > length)
					? source = source.Substring(0, length) + "..."
					: source;
			}
			
			public void SetNotificationDescription() {
				var checkedLicenseslist = Get<ICompositeObjectList<ICompositeObject>>("CheckedLicenses");
				string notificationDescription = Get<string>("NotificationDescription");
				int displayedLicensesCount = 2;
				int productNameMaxLength = 43;
				int counter = 0;
				foreach (ICompositeObject item in checkedLicenseslist) {
					if (counter < displayedLicensesCount) {
						item.TryGetValue<bool>("IsNotEnoughLicenses", out bool IsNotEnoughLicense);
						if (IsNotEnoughLicense) {
							item.TryGetValue<string>("LicenseProductName", out string LicenseProductName);
							item.TryGetValue<int>("LicensedUsersCount", out int LicensedUsersCount);
							item.TryGetValue<int>("AvailableLicensesCount", out int AvailableLicensesCount);
							LicenseProductName = TruncateString(LicenseProductName, productNameMaxLength);
							notificationDescription += "\n-" + LicenseProductName + "{2}" + LicensedUsersCount.ToString() + "{3}" + AvailableLicensesCount.ToString();
							Set<bool>("NeedToSendNotification", true);
						}
					}
					counter++;
				}
				if (checkedLicenseslist.Count > displayedLicensesCount) {
					notificationDescription += "\n {6}" + (checkedLicenseslist.Count - displayedLicensesCount).ToString() + "{7}";
				}
				notificationDescription += "\n\n{4}" + Get<DateTime>("ExpireDate").ToString("d") + "{5}";
				Set<string>("NotificationDescription", notificationDescription);
			}

		#endregion

	}

	#endregion

}

