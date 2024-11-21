namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Newtonsoft.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: RemindingsDataService

	/// <summary>
	/// Class of the data service for notification unit.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class RemindingsDataService : BaseService, IReadOnlySessionState
	{

		#region Methods: Private

		private RemindingsHelper GetRemindingsHelper() {
			return ClassFactory.Get<RemindingsHelper>(new ConstructorArgument("userConnection", UserConnection));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns counters of user notification.
		/// </summary>
		/// <param name="sysAdminUnitId">User for which counters are collected.</param>
		/// <param name="dueDate">The date on which must collect counters.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetRemindingsCount(Guid sysAdminUnitId, string dueDate) {
			RemindingsHelper helper = GetRemindingsHelper();
			string counter = helper.GetRemindingsCountResponse(sysAdminUnitId, dueDate);
			return counter;
		}

		/// <summary>
		/// Returns popup configs of user notification.
		/// </summary>
		/// <param name="sysAdminUnitId">User for which popup configs are collected.</param>
		/// <param name="dueDate">The date on which must collect popup configs.</param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetPopupConfig(Guid sysAdminUnitId, string dueDate) {
			RemindingsHelper helper = GetRemindingsHelper();
			string popupConfig = helper.GetPopupConfigResponse(sysAdminUnitId, dueDate);
			return popupConfig;
		}

		#endregion
	}

	#endregion

	#region Class RemindingsHelper

	public class RemindingsHelper
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly NotificationUtilities _notificationUtilities = new NotificationUtilities();

		#endregion

		#region Constructors: Public

		public RemindingsHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetSysAdminUnit(Guid sysAdminUnitId) {
			const string template = "{{\"displayValue\":\"{0}\", \"primaryImageValue\":\"{1}\", \"value\":\"{2}\"}}";
			return string.Format(template, _userConnection.CurrentUser.Name, "", sysAdminUnitId);
		}

		private int GetCount(Guid sysAdminUnitId, NotificationProviderType type, DateTime date) {
			var methodName = "GetCount";
			int result = 0;
			List<object> methodResults = GetResult(sysAdminUnitId, type, date, methodName).ToList();
			foreach (object item in methodResults) {
				result += (int)item;
			}
			return result;
		}

		private string GetPopupConfig(Guid sysAdminUnitId, NotificationProviderType type, DateTime date) {
			var methodName = "GetPopupConfig";
			var result = string.Empty;
			List<object> methodResults = GetResult(sysAdminUnitId, type, date, methodName).ToList();
			return string.Join(", ", methodResults.FindAll(a => !string.IsNullOrWhiteSpace((string)a)));
		}

		private IEnumerable<object> GetResult(Guid sysAdminUnitId, NotificationProviderType type, DateTime date, string methodName) {
			var result = new List<object>();
			var parameters = new Dictionary<string, object> {
				{
					"sysAdminUnitId", sysAdminUnitId
				}, {
					"dueDate", date
				}, {
					"userConnection", _userConnection
				}
			};
			List<string> classNames = GetNotificationProviderClassNames(type);
			object[] objectParams = { parameters };
			foreach (string className in classNames) {
				object methodResult = _notificationUtilities
					.GetMethodResult(className, methodName, objectParams);
				result.Add(methodResult);
			}
			return result;
		}

		private List<string> GetNotificationProviderClassNames(NotificationProviderType type) {
			bool isFeatureEnabled = _userConnection.GetIsFeatureEnabled("NotificationsOnOneClassJob");
			if (isFeatureEnabled) {
				return GetNotImplementedProviders(_userConnection, type).ToList();
			}
			return _notificationUtilities.GetNotificationProviderClassNames(type, _userConnection);
		}

		private IEnumerable<string> GetNotImplementedProviders(UserConnection userConnection,
				NotificationProviderType type) {
			var store = new NotificationStore();
			var helper = new ImplementedNotificationProviderHelper(userConnection, store);
			IDictionary<string, NotificationProviderType> providers = helper.GetNotImplementedProviders();
			return providers
				.Where(provider => provider.Value.Equals(type))
				.Select(provider => provider.Key);
		}

		private DateTime GetFixedDate(DateTime date) {
			DateTime utcDate = DateTime.SpecifyKind(date, DateTimeKind.Unspecified);
			TimeZoneInfo timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(_userConnection.CurrentUser.TimeZone.Id);
			return TimeZoneInfo.ConvertTimeToUtc(utcDate, timeZoneInfo);
		}

		private DateTime GetDateByTimeZone(string date) {
			var dateOffset = DateTimeOffset.Parse(date);
			TimeZoneInfo timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(_userConnection.CurrentUser.TimeZone.Id);
			DateTime utcDate = DateTime.SpecifyKind(dateOffset.DateTime, DateTimeKind.Unspecified);
			return TimeZoneInfo.ConvertTimeFromUtc(utcDate, timeZoneInfo);
		}

		private string GetPopupConfigs(RemindersCounter counter, Guid sysAdminUnitId, string dueDate) {
			var result = new List<string>();
			DateTime date = GetDateByTimeZone(dueDate);
			if (counter.RemindingsCount > 0) {
				result.Add(GetUserPopupConfig(sysAdminUnitId, date));
			}
			if (counter.NotificationCount > 0) {
				result.Add(GetUserNotificationPopupConfig(sysAdminUnitId, date));
			}
			if (counter.VisaCount > 0) {
				result.Add(GetUserVisaPopupConfig(sysAdminUnitId));
			}
			if (counter.ESNNotificationsCount > 0) {
				result.Add(GetESNNotificationsPopupConfig(sysAdminUnitId));
			}
			if (counter.AnniversariesCount > 0) {
				result.Add(GetAnniversariesPopupConfig(sysAdminUnitId));
			}
			return string.Join(", ", result.Where(item => !string.IsNullOrWhiteSpace(item)));
		}

		private RemindersCounter GetRemindersCounter(Guid sysAdminUnitId, string dueDate) {
			DateTime date = GetDateByTimeZone(dueDate);
			int remindingsCount = GetUserRemindingsCount(sysAdminUnitId, date);
			int notificationCount = GetUserNotificationCount(sysAdminUnitId, date);
			int emailsCount = GetEmailRemindingsCount(sysAdminUnitId);
			int visaCount = GetUserVisaRemindingsCount(sysAdminUnitId);
			int esnNotificationsCount = GetESNNotificationsCount(sysAdminUnitId);
			int anniversariesCount = GetAnniversariesCount(sysAdminUnitId);
			string sysAdminUnit = GetSysAdminUnit(sysAdminUnitId);
			var counter = new RemindersCounter() {
				RemindingsCount = remindingsCount,
				NotificationCount = notificationCount,
				EmailsCount = emailsCount,
				VisaCount = visaCount,
				SysAdminUnit = sysAdminUnit,
				ESNNotificationsCount = esnNotificationsCount,
				AnniversariesCount = anniversariesCount

			};
			return counter;
		}

		#endregion

		#region Methods: Public

		public string GetRemindingsCountResponse(Guid sysAdminUnitId, string dueDate) {
			const string resultTemplate = "{{\"RemindingsCount\":{0}, \"NotificationCount\":{1}, " +
				"\"EmailsCount\":{2}, \"VisaCount\":{3}, \"SysAdminUnit\":{4}, \"ESNNotificationsCount\":{5}, \"AnniversariesCount\": {6}}}";
			var counter = GetRemindersCounter(sysAdminUnitId, dueDate);
			return string.Format(resultTemplate, counter.RemindingsCount, counter.NotificationCount,
				counter.EmailsCount, counter.VisaCount, counter.SysAdminUnit, counter.ESNNotificationsCount, counter.AnniversariesCount);
		}

		public string GetPopupConfigResponse(Guid sysAdminUnitId, string dueDate) {
			RemindersCounter counter = GetRemindersCounter(sysAdminUnitId, dueDate);
			const string resultTemplate = "{{{0}}}";
			var remindings = GetPopupConfigs(counter, sysAdminUnitId, dueDate);
			var popupConfig = string.Format(resultTemplate, remindings);
			var result = new { Counter = counter, PopupConfig = popupConfig };
			return JsonConvert.SerializeObject(result);
		}

		public int GetUserRemindingsCount(Guid sysAdminUnitId, DateTime date) {
			DateTime fixedDate = GetFixedDate(date);
			int result = GetCount(sysAdminUnitId, NotificationProviderType.Reminding, fixedDate);
			return result;
		}

		public int GetUserNotificationCount(Guid sysAdminUnitId, DateTime date) {
			DateTime fixedDate = GetFixedDate(date);
			int result = GetCount(sysAdminUnitId, NotificationProviderType.Notification, fixedDate);
			return result;
		}

		public int GetESNNotificationsCount(Guid sysAdminUnitId) {
			int result = GetCount(sysAdminUnitId, NotificationProviderType.ESNNotification, DateTime.MinValue);
			return result;
		}

		public int GetEmailRemindingsCount(Guid sysAdminUnitId) {
			return 0;
		}

		public int GetUserVisaRemindingsCount(Guid sysAdminUnitId) {
			int result = GetCount(sysAdminUnitId, NotificationProviderType.Visa, DateTime.MinValue);
			return result;
		}

		public int GetAnniversariesCount(Guid sysAdminUnitId) {
			int result = GetCount(sysAdminUnitId, NotificationProviderType.Anniversary, DateTime.Now);
			return result;
		}

		public string GetUserPopupConfig(Guid sysAdminUnitId, DateTime date) {
			DateTime fixedDate = GetFixedDate(date);
			string result = GetPopupConfig(sysAdminUnitId, NotificationProviderType.Reminding, fixedDate);
			return result;
		}

		public string GetUserNotificationPopupConfig(Guid sysAdminUnitId, DateTime date) {
			DateTime fixedDate = GetFixedDate(date);
			string result = GetPopupConfig(sysAdminUnitId, NotificationProviderType.Notification, fixedDate);
			return result;
		}

		public string GetUserVisaPopupConfig(Guid sysAdminUnitId) {
			string result = GetPopupConfig(sysAdminUnitId, NotificationProviderType.Visa, DateTime.MinValue);
			return result;
		}

		public string GetESNNotificationsPopupConfig(Guid sysAdminUnitId) {
			string result = GetPopupConfig(sysAdminUnitId, NotificationProviderType.ESNNotification, DateTime.MinValue);
			return result;
		}

		public string GetAnniversariesPopupConfig(Guid sysAdminUnitId) {
			string result = GetPopupConfig(sysAdminUnitId, NotificationProviderType.Anniversary, DateTime.Now);
			return result;
		}

		#endregion
	}

	#endregion

	#region Class: RemindersCounter

	[JsonObject(MemberSerialization.OptIn)]
	public class RemindersCounter
	{
		[JsonProperty]
		public int RemindingsCount { get; set; }
		[JsonProperty]
		public int NotificationCount { get; set; }
		[JsonProperty]
		public int EmailsCount { get; set; }
		[JsonProperty]
		public int VisaCount { get; set; }
		[JsonProperty]
		public string SysAdminUnit { get; set; }
		[JsonProperty]
		public int ESNNotificationsCount { get; set; }
		[JsonProperty]
		public int AnniversariesCount { get; set; }

		public string Serialize() {
			return JsonConvert.SerializeObject(this);
		}
	}

	#endregion
}






