namespace BPMSoft.Configuration.LDAP
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data;
	using System.DirectoryServices.Protocols;
	using System.Globalization;
	using System.Linq;
	using System.Net;
	using System.Runtime.InteropServices;
	using System.Security.Cryptography;
	using System.Security.Cryptography.X509Certificates;
	using System.Text;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Struct: LdapGroup

	[Serializable]
	public struct LdapGroup
	{

		#region Fields: Public

		public string Id;
		public string Name;
		public string Dn;
		public DateTime ModifiedOn;

		#endregion

		#region Constructors: Public

		public LdapGroup(string id, string name, string dn) {
			Id = id;
			Name = name;
			Dn = dn;
			ModifiedOn = DateTime.MinValue;
		}

		#endregion

	}

	#endregion

	#region Struct: LdapUser

	[Serializable]
	public struct LdapUser
	{

		#region Fields: Public

		public string Id;
		public string Name;
		public string FullName;
		public string Company;
		public string Email;
		public string Phone;
		public string JobTitle;
		public bool IsActive;
		public string Dn;
		public DateTime ModifiedOn;

		#endregion

	}

	#endregion

	#region Class: LdapUtilities

	public class LdapUtilities : IDisposable
	{

		#region Constants: Private

		private const string LdapServerSysSettingCode = "LDAPServer";
		private const string LdapServerLoginSysSettingCode = "LDAPServerLogin";
		private const string LdapServerPasswordSysSettingCode = "LDAPServerPassword";
		private const string LdapUsersEntrySysSettingCode = "LDAPUsersEntry";
		private const string LdapGroupsEntrySysSettingCode = "LDAPGroupsEntry";
		private const string LdapUsersFilterSysSettingCode = "LDAPUsersFilter";
		private const string LdapGroupsFilterSysSettingCode = "LDAPGroupsFilter";
		private const string LdapUsersInGroupFilterSysSettingCode = "LDAPUsersInGroupFilter";
		private const string LdapUserLoginAttributeSysSettingCode = "LDAPUserLoginAttribute";
		private const string LdapUserIdentityAttributeSysSettingCode = "LDAPUserIdentityAttribute";
		private const string LdapGroupNameAttributeSysSettingCode = "LDAPGroupNameAttribute";
		private const string LdapGroupIdentityAttributeSysSettingCode = "LDAPGroupIdentityAttribute";
		private const string LdapEntryModifiedOnAttributeSysSettingCode = "LDAPEntryModifiedOnAttribute";
		private const string LdapUserFullNameAttributeSysSettingCode = "LDAPUserFullNameAttribute";
		private const string MacroOpenBracket = "[#";
		private const string MacroCloseBracket = "#]";
		private const string DnMacroName = "LDAPGroupDN";
		private const int PageRecordsCount = 40;
		private const int InvalidCredentialsErrorCode = 49;
		private const string LdapUserCompanyAttributeSysSettingCode = "LDAPUserCompanyAttribute";
		private const string LdapUserEmailAttributeSysSettingCode = "LDAPUserEmailAttribute";
		private const string LdapUserPhoneAttributeSysSettingCode = "LDAPUserPhoneAttribute";
		private const string LdapUserJobTitleAttributeSysSettingCode = "LDAPUserJobTitleAttribute";
		private const string LdapSynchIntervalSysSettingCode = "LDAPSynchInterval";
		private const string LdapEntryMaxModifiedOnSysSettingCode = "LDAPEntryMaxModifiedOn";
		private const string LdapKeyDistributionCenterSysSettingCode = "LDAPKeyDistributionCenter";
		private const string LdapAuthType = "LDAPAuthType";
		private const string LdapUserAccountControlAttributeName = "userAccountControl";
		private const string LdapDateTimeFormat = "yyyyMMddHHmmss.f'Z'";
		private const int LdapDisabledAccountValue = 2;
		private const string LdapSslSysSettingCode = "LDAPUseSecureConnection";
		private const int DefLdapPort = 389;
		private const int DefSslLdapPort = 636;

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("LDAP");
		private readonly UserConnection _userConnection;
		private LdapConnection _ldapConnection;
		private readonly string _ldapServer;
		private readonly int _ldapPort;
		private readonly string _ldapServerLogin;
		private readonly string _ldapServerPassword;
		private readonly string _ldapUsersEntry;
		private readonly string _ldapGroupsEntry;
		private readonly string _ldapUsersFilter;
		//!!private readonly string _ldapModifiedUsersFilter;
		private readonly string _ldapGroupsFilter;
		private readonly string _ldapUsersInGroupFilter;
		private readonly string _ldapUserLoginAttribute;
		private readonly string _ldapUserIdentityAttribute;
		private readonly string _ldapGroupIdentityAttribute;
		private readonly string _ldapGroupNameAttribute;
		private readonly string _ldapEntryModifiedOnAttribute;
		private readonly string _ldapUserFullNameAttribute;
		private readonly string _ldapUserCompanyAttribute;
		private readonly string _ldapUserEmailAttribute;
		private readonly string _ldapUserPhoneAttribute;
		private readonly string _ldapUserJobTitleAttribute;
		private readonly DateTime _ldapEntryMaxModifiedOn;

		#endregion

		#region Constructors: Public

		public LdapUtilities(UserConnection userConnection) {
			_userConnection = userConnection;
			string ldapServer = SysSettings.GetValue(userConnection, LdapServerSysSettingCode).ToString();
			bool useSsl = SysSettings.GetValue(_userConnection, LdapSslSysSettingCode, false);
			_ldapServer = GetLdapServer(ldapServer);
			_ldapPort = GetLdapPort(ldapServer, useSsl);
			_ldapServerLogin = SysSettings.GetValue(userConnection, LdapServerLoginSysSettingCode, string.Empty);
			_ldapServerPassword = SysSettings.GetValue(userConnection, LdapServerPasswordSysSettingCode, string.Empty);
			try {
				AuthType authType = GetAuthType(userConnection);
				_ldapConnection = new LdapConnection(new LdapDirectoryIdentifier(_ldapServer, _ldapPort)) {
					AuthType = authType
				};
				_ldapConnection.SessionOptions.ProtocolVersion = 3;
			//	IServerInfoProvider serverInfoProvider = ClassFactory.Get<IServerInfoProvider>();
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
					_ldapConnection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
				}				
				bool isFeatureEnabled = BPMSoft.Configuration.FeatureUtilities.GetIsFeatureEnabled(
						_userConnection, LdapSslSysSettingCode);
				if (isFeatureEnabled && useSsl) {
					_ldapConnection.SessionOptions.SecureSocketLayer = true;
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
						_ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback(VerifyServerCertificate);
					}
				}
				string keyDistributionCenter = string.Empty;
				if (authType == AuthType.Kerberos) {
					keyDistributionCenter =
						SysSettings.GetValue(userConnection, LdapKeyDistributionCenterSysSettingCode, string.Empty);
				}
				if (authType == AuthType.Negotiate) {
					_ldapConnection.Bind();
				} else {
					var credentials = new NetworkCredential(_ldapServerLogin, _ldapServerPassword, keyDistributionCenter);
					_ldapConnection.Bind(credentials);
				}
			} catch (LdapException e) {
				string message = e.ErrorCode == InvalidCredentialsErrorCode ? "Invalid user name or password."
					: "Unable to connect to server.";
				_log.Error(message, e);
				throw;
			}
			_log.Debug("Server connection successfully established.");
			_ldapEntryMaxModifiedOn = GetEntryMaxModifiedOn(userConnection);
			_log.DebugFormat("Last updated: {0}.", _ldapEntryMaxModifiedOn);
			_ldapUsersEntry = SysSettings.GetValue(userConnection, LdapUsersEntrySysSettingCode).ToString();
			_ldapGroupsEntry = SysSettings.GetValue(userConnection, LdapGroupsEntrySysSettingCode).ToString();
			_ldapUserLoginAttribute = SysSettings.GetValue(userConnection,
				LdapUserLoginAttributeSysSettingCode).ToString();
			_ldapUserIdentityAttribute = SysSettings.GetValue(userConnection,
				LdapUserIdentityAttributeSysSettingCode).ToString();
			_ldapGroupIdentityAttribute = SysSettings.GetValue(userConnection,
				LdapGroupIdentityAttributeSysSettingCode).ToString();
			_ldapGroupNameAttribute = SysSettings.GetValue(userConnection,
				LdapGroupNameAttributeSysSettingCode).ToString();
			_ldapEntryModifiedOnAttribute = SysSettings.GetValue(userConnection,
				LdapEntryModifiedOnAttributeSysSettingCode).ToString();
			_ldapUserFullNameAttribute = SysSettings.GetValue(userConnection,
				LdapUserFullNameAttributeSysSettingCode).ToString();
			_ldapUserCompanyAttribute = SysSettings.GetValue(userConnection,
				LdapUserCompanyAttributeSysSettingCode).ToString();
			_ldapUserEmailAttribute = SysSettings.GetValue(userConnection,
				LdapUserEmailAttributeSysSettingCode).ToString();
			_ldapUserPhoneAttribute = SysSettings.GetValue(userConnection,
				LdapUserPhoneAttributeSysSettingCode).ToString();
			_ldapUserJobTitleAttribute = SysSettings.GetValue(userConnection,
				LdapUserJobTitleAttributeSysSettingCode).ToString();
			_ldapUsersFilter = SysSettings.GetValue(userConnection,
				LdapUsersFilterSysSettingCode, string.Empty);
			//!!_ldapModifiedUsersFilter = GetUserFilterWithModifiedOnAttribute();
			_ldapGroupsFilter = SysSettings.GetValue(userConnection,
				LdapGroupsFilterSysSettingCode, string.Empty);
			_ldapUsersInGroupFilter = SysSettings.GetValue(userConnection,
				LdapUsersInGroupFilterSysSettingCode, string.Empty);
		}

		#endregion

		#region Properties: Public

		public TimeSpan RequestTimeout {
			get {
				var timeout = ConfigurationManager.AppSettings["RequestTimeout"];
				return (timeout != null) ? TimeSpan.Parse(timeout) : new TimeSpan(0, 0, 120);
			}
		}

		/// <summary>
		/// Indicates whether phone number should be changed when synchronizing with LDAP.
		/// </summary>
		/// <value>
		/// <c>true</c>, if the phone number needs to be changed; else - <c>false</c>.
		/// </value>
		public bool IsPhoneNeedUpdate {
			get {
				return _ldapUserPhoneAttribute.IsNotNullOrEmpty();
			}
		}

		/// <summary>
		/// Indicates whether user's email should be changed when synchronizing with LDAP.
		/// </summary>
		/// <value>
		/// <c>true</c>, if the email needs to be changes; else - <c>false</c>.
		/// </value>
		public bool IsEmailNeedUpdate {
			get {
				return _ldapUserEmailAttribute.IsNotNullOrEmpty();
			}
		}

		/// <summary>
		/// Indicates whether user's job title should be changed when synchronizing with LDAP.
		/// </summary>
		/// <value>
		/// <c>true</c>, if the position needs to be changed; else - <c>false</c>.
		/// </value>
		public bool IsJobTitleNeedUpdate {
			get {
				return _ldapUserJobTitleAttribute.IsNotNullOrEmpty();
			}
		}

		#endregion

		#region Methods: Private

		private string[] SplitLdapServerAdress(string ldapServer) {
			return ldapServer.Split(':');
		}

		private string GetLdapServer(string ldapServer) {
			var result = SplitLdapServerAdress(ldapServer);
			return result.FirstOrDefault();
		}

		private int GetLdapPort(string ldapServer, bool useSsl) {
			var ldapServerAdress = SplitLdapServerAdress(ldapServer);
			var port = ldapServerAdress.LastOrDefault();
			if (int.TryParse(port, out int result)) {
				return result;
			}
			return useSsl ? DefSslLdapPort : DefLdapPort;
		}

		private static bool VerifyServerCertificate(LdapConnection connection, X509Certificate certificate) {
			var certificate2 = new X509Certificate2(certificate);
			try {
				bool isVerified = certificate2.Verify();
				if (!isVerified) {
					isVerified = CheckCertificateChain(certificate2);
				}
				return isVerified;
			}
			catch (Exception ex) {
				string message = "Unable to connect to server. SSL certificate verification failed";
				_log.Error(message, ex);
				if(_log.IsDebugEnabled) {
					return CheckCertificateChain(certificate2);
				}
				return false;
			}
		}
		
		private static bool CheckCertificateChain(X509Certificate2 certificate) {
			List<string> chainErrors = GetCertificateChainErrors(certificate);
			if(chainErrors.Any()) {
				var chainError = string.Join("\n", chainErrors);
				_log.Error($"Chain errors were detected during certificate validation:{chainError}");
				return false;
			}
			return true;
		}

		private static List<string> GetCertificateChainErrors(X509Certificate2 certificate) {
			X509Chain chain = new X509Chain();
			List<string> errors = new List<string>();
			try {
				var chainBuilt = chain.Build(certificate);
				if (chainBuilt == false) {
					foreach (X509ChainStatus chainStatus in chain.ChainStatus)
						errors.Add(string.Format("Chain error: {0} {1}", chainStatus.Status, chainStatus.StatusInformation));
				}
			}
			catch (Exception ex) {
				_log.Debug("Error occured while obtaining LDAPS certificate chain errors", ex);
			}
			return errors;
		}

		private static string ConvertToLdapFormat(DateTime dateTime) {
			return dateTime.ToString(LdapDateTimeFormat, CultureInfo.InvariantCulture);
		}

		private static DateTime GetEntryMaxModifiedOn(UserConnection userConnection) {
			if (!SysSettings.TryGetValue(userConnection, LdapEntryMaxModifiedOnSysSettingCode,
				out var entryMaxModifiedOn)) {
				return DateTime.MinValue;
			}
			return entryMaxModifiedOn != null
				? TimeZoneInfo.ConvertTimeToUtc((DateTime)entryMaxModifiedOn, userConnection.CurrentUser.TimeZone)
				: DateTime.MinValue;
		}

		private static bool GetIsValidRequiredLDAPSettings(UserConnection userConnection) {
			var requiredLdapSettingsCodeCollection = new List<string> {
				LdapServerSysSettingCode,
				LdapServerLoginSysSettingCode,
				LdapServerPasswordSysSettingCode,
				LdapUsersEntrySysSettingCode,
				LdapGroupsEntrySysSettingCode,
				LdapUsersFilterSysSettingCode,
				LdapGroupsFilterSysSettingCode,
				LdapUsersInGroupFilterSysSettingCode,
				LdapUserLoginAttributeSysSettingCode,
				LdapUserIdentityAttributeSysSettingCode,
				LdapGroupIdentityAttributeSysSettingCode,
				LdapGroupNameAttributeSysSettingCode,
				LdapEntryModifiedOnAttributeSysSettingCode,
				LdapUserFullNameAttributeSysSettingCode
			};
			foreach (string sysSettingCode in requiredLdapSettingsCodeCollection) {
				if (!GetIsNotEmptySysSettingsValue(userConnection, sysSettingCode)) {
					return false;
				}
			}
			object intervalValue;
			if (!SysSettings.TryGetValue(userConnection, LdapSynchIntervalSysSettingCode, out intervalValue)) {
				return false;
			}
			bool hasIntervalSettingValue = false;
			if (intervalValue is int) {
				hasIntervalSettingValue = (int)intervalValue > 0;
			} else if (intervalValue is decimal) {
				hasIntervalSettingValue = (decimal)intervalValue > 0;
			}
			if (!hasIntervalSettingValue) {
				return false;
			}
			AuthType authType = GetAuthType(userConnection);
			if (authType == AuthType.Kerberos) {
				return GetIsNotEmptySysSettingsValue(userConnection, LdapKeyDistributionCenterSysSettingCode);
			}
			return true;
		}

		private static AuthType GetAuthType(UserConnection userConnection) {
			var authTypeId = (Guid)SysSettings.GetValue(userConnection, LdapAuthType);
			var selectQuery = new Select(userConnection)
				.Column("Value")
				.From("LDAPAuthType").As("LAT")
				.Where("LAT", "Id").IsEqual(new QueryParameter(authTypeId))
				as Select;
			using (DBExecutor executor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(executor)) {
					if (reader.Read()) {
						return (AuthType)Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Value")));
					}
				}
			}
			string errorMessage = "LDAP authentication type is not specified.";
			_log.Error(errorMessage);
			throw new Exception(errorMessage);
		}

		private static bool GetIsNotEmptySysSettingsValue(UserConnection userConnection, string sysSettingCode) {
			object value;
			if (!SysSettings.TryGetValue(userConnection, sysSettingCode, out value) ||
					string.IsNullOrEmpty(value as string)) {
				return false;
			}
			return true;
		}

		private static void LogLdapRequestError(Exception exception, SearchRequest request) {
			var formatBuilder = new StringBuilder();
			formatBuilder
				.AppendFormat("A critical error occurred while obtaining the list of entries: {0}", exception.Message)
				.AppendLine();
			if (request != null) {
				formatBuilder
					.AppendFormat("LDAP search entry: {0};", request.DistinguishedName)
					.AppendLine()
					.AppendFormat("LDAP filter: {0};", request.Filter)
					.AppendLine();
				if (!request.Attributes.IsNullOrEmpty()) {
					formatBuilder.AppendFormat("Requested attributes: ");
					foreach (string requestAttribute in request.Attributes) {
						formatBuilder.AppendFormat(" {0};", requestAttribute ?? string.Empty);
					}
				}
				formatBuilder.AppendLine();
			}
			if (exception is LdapException ldapException) {
				formatBuilder.AppendFormat("Error code: {0}, Server error message: {1}", ldapException.ErrorCode,
					ldapException.ServerErrorMessage)
					.AppendLine();
			}
			if (exception.InnerException != null) {
				formatBuilder.AppendFormat("Inner exception: {0}", exception.InnerException.Message)
					.AppendLine();
			}
			_log.ErrorFormat(formatBuilder.ToString(), exception);
		}

		private int InsertUsersToTableByFilter(string tableCode, string filter, Guid syncId) {
			// TODO look at possibility to get users through method GetUsersByLdapFilter
			var result = 0;
			string[] userAttributes = GetUserAttributes();
			string[] userRequiredAttributes = GetUserRequiredAttributes();
			var request = new SearchRequest(_ldapUsersEntry, filter, SearchScope.Subtree, userAttributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			SortRequestControl sortControl = CreateSortRequestControl(_ldapUserLoginAttribute);
			request.Controls.Add(sortControl);
			do {
				SearchResponse response;
				try {
					response = _ldapConnection.SendRequest(request, RequestTimeout) as SearchResponse;
				} catch (Exception exception) {
					LogLdapRequestError(exception, request);
					throw;
				}
				if (response.ResultCode == ResultCode.Success) {
					foreach (SearchResultEntry entry in response.Entries) {
						CheckEntryAttributes(entry, userRequiredAttributes);
						LdapUser ldapUser = CreateLdapUser(entry, string.Empty);
						var insertUser = new Insert(_userConnection).Into(tableCode)
							.Set("Id", Column.Parameter(ldapUser.Id))
							.Set("Name", Column.Parameter(ldapUser.Name))
							.Set("ModifiedOn", Column.Parameter(ldapUser.ModifiedOn))
							.Set("FullName", Column.Parameter(ldapUser.FullName))
							.Set("Company", Column.Parameter(ldapUser.Company))
							.Set("Email", Column.Parameter(ldapUser.Email))
							.Set("Phone", Column.Parameter(ldapUser.Phone))
							.Set("JobTitle", Column.Parameter(ldapUser.JobTitle))
							.Set("IsActive", Column.Parameter(ldapUser.IsActive))
							.Set("Dn", Column.Parameter(ldapUser.Dn));
						if (syncId.IsNotEmpty()) {
							insertUser.Set("LdapSyncId", Column.Parameter(syncId));
						}
						try {
							result += insertUser.Execute();
						} catch (Exception e) {
							_log.ErrorFormat("SyncID: {2}. An error occurred while adding the record to the \"{0}\" table: {1}", e,
								tableCode, e.Message, syncId);
							throw;
						}
					}
				} else {
					_log.DebugFormat("SyncID: {2}. Unable to obtain a list of users with the \"{0}\" filter. Result code: {1}.",
						filter, response.ResultCode, syncId);
				}
				var responseControl = (PageResultResponseControl)Array.Find(response.Controls,
					item => item is PageResultResponseControl);
				paging.Cookie = responseControl.Cookie;
			} while (paging.Cookie.Length != 0);
			return result;
		}

		private string GetUserInGroupFilterString(string filter, LdapGroup group) {
			string groupDn = ReplaceSpecialCharacters(group.Dn);
			string groupName = ReplaceSpecialCharacters(group.Name);
			return filter.Replace(MacroOpenBracket + DnMacroName + MacroCloseBracket, groupDn)
				.Replace(MacroOpenBracket + LdapGroupNameAttributeSysSettingCode.Replace("Attribute", string.Empty) +
					MacroCloseBracket, groupName).Replace(MacroOpenBracket + LdapGroupIdentityAttributeSysSettingCode
						.Replace("Attribute", string.Empty) + MacroCloseBracket, group.Id);
		}

		private string ReplaceSpecialCharacters(string filterString) {
			return filterString.Replace("*", "\\2A")
				.Replace("(", "\\28")
				.Replace(")", "\\29")
				.Replace("\\", "\\5C")
				.Replace("Nul", "\\00");
		}

		private string GetUserFilterWithMinModifiedOnAttributeOrDate(DateTime? fromDate) {
			if (_ldapEntryMaxModifiedOn == DateTime.MinValue || string.IsNullOrEmpty(_ldapEntryModifiedOnAttribute)) {
				return _ldapUsersFilter;
			}
			DateTime fromDateValue = fromDate ?? DateTime.MaxValue;
			DateTime syncFromDate = fromDateValue < _ldapEntryMaxModifiedOn ? fromDateValue : _ldapEntryMaxModifiedOn;
			string lastSyncDateInLdapFormat = ConvertToLdapFormat(syncFromDate);
			var modifiedOnAttributeFilter = string.Format("({0}>={1})", _ldapEntryModifiedOnAttribute,
				lastSyncDateInLdapFormat);
			return "(&" + _ldapUsersFilter + modifiedOnAttributeFilter + ")";
		}

		private bool IsActive(string userAccountControlValue) {
			int value;
			if (!int.TryParse(userAccountControlValue, out value)) {
				return false;
			}
			return (value & LdapDisabledAccountValue) != LdapDisabledAccountValue;
		}

		private string GetEntryAttributeStringValue(SearchResultEntry entry, string attributeName, string defValue) {
			DirectoryAttribute attribute = entry.Attributes[attributeName];
			if (attribute == null) {
				return defValue;
			}
			return attribute[0].ToString();
		}

		private string GetEntryRequiredAttributeStringValue(SearchResultEntry entry, string attributeName) {
			return entry.Attributes[attributeName][0].ToString();
		}

		private string GetEntryIdentityAttribute(SearchResultEntry entry, string attributeName) {
			object attributeValue = entry.Attributes[attributeName][0];
			if (!(attributeValue is byte[])) {
				return Convert.ChangeType(attributeValue, typeof(string)).ToString();
			}
			var hasher = MD5.Create();
			byte[] data = hasher.ComputeHash(attributeValue as byte[]);
			var sb = new StringBuilder(512);
			for (int i = 0; i < data.Length; i++) {
				sb.Append(data[i].ToString("x2"));
			}
			return sb.ToString();
		}

		private DateTime GetEntryDateTimeAttributeValue(SearchResultEntry entry, string attributeName) {
			return ConvertToDateTime(entry.Attributes[attributeName][0].ToString());
		}

		private LdapUser CreateLdapUser(SearchResultEntry entry, string attributeDefValue) {
			LdapUser ldapUser = new LdapUser();
			ldapUser.Id = GetEntryIdentityAttribute(entry, _ldapUserIdentityAttribute);
			ldapUser.Name = GetEntryRequiredAttributeStringValue(entry, _ldapUserLoginAttribute);
			ldapUser.FullName = GetEntryAttributeStringValue(entry, _ldapUserFullNameAttribute, attributeDefValue);
			ldapUser.Company = GetEntryAttributeStringValue(entry, _ldapUserCompanyAttribute, attributeDefValue);
			ldapUser.Email = GetEntryAttributeStringValue(entry, _ldapUserEmailAttribute, attributeDefValue);
			ldapUser.Phone = GetEntryAttributeStringValue(entry, _ldapUserPhoneAttribute, attributeDefValue);
			ldapUser.JobTitle = GetEntryAttributeStringValue(entry, _ldapUserJobTitleAttribute, attributeDefValue);
			string accountControlAttributeValue =
				GetEntryAttributeStringValue(entry, LdapUserAccountControlAttributeName, string.Empty);
			ldapUser.IsActive = string.IsNullOrEmpty(accountControlAttributeValue) ||
				IsActive(accountControlAttributeValue);
			bool useLoginUserLDAPEntryDN = _userConnection.AppConnection.UseLoginUserLDAPEntryDN;
			ldapUser.Dn = useLoginUserLDAPEntryDN ? entry.DistinguishedName : attributeDefValue;
			ldapUser.ModifiedOn = GetEntryDateTimeAttributeValue(entry, _ldapEntryModifiedOnAttribute);
			return ldapUser;
		}

		private LdapGroup CreateLdapGroup(SearchResultEntry entry) {
			LdapGroup ldapGroup = new LdapGroup();
			ldapGroup.Id = GetEntryIdentityAttribute(entry, _ldapGroupIdentityAttribute);
			ldapGroup.Name = GetEntryRequiredAttributeStringValue(entry, _ldapGroupNameAttribute);
			ldapGroup.Dn = entry.DistinguishedName;
			ldapGroup.ModifiedOn = GetEntryDateTimeAttributeValue(entry, _ldapEntryModifiedOnAttribute);
			return ldapGroup;
		}

		private void CheckEntryAttributes(SearchResultEntry entry, string[] requiredAttributes) {
			foreach (var attributeName in requiredAttributes) {
				if (!entry.Attributes.Contains(attributeName)) {
					var errorMessage = string.Format("Required attribute value \"{0}\" is missing from the LDAP {1} element.",
						attributeName,
						entry.DistinguishedName);
					_log.Error(errorMessage);
					throw new Exception(errorMessage);
				}
			}
		}

		private string[] GetRequiredGroupAttributes() {
			var requiredGroupAttributes =
				new[] { _ldapGroupIdentityAttribute, _ldapGroupNameAttribute, _ldapEntryModifiedOnAttribute };
			return requiredGroupAttributes;
		}

		private string[] GetUserRequiredAttributes() {
			var userRequiredAttributes =
				new[] { _ldapUserIdentityAttribute, _ldapUserLoginAttribute, _ldapEntryModifiedOnAttribute };
			return userRequiredAttributes;
		}

		private string[] GetUserAttributes() {
			var userAttributes = new[] {
				_ldapUserIdentityAttribute, _ldapUserLoginAttribute, _ldapEntryModifiedOnAttribute,
				_ldapUserFullNameAttribute, _ldapUserCompanyAttribute, _ldapUserEmailAttribute, _ldapUserPhoneAttribute,
				_ldapUserJobTitleAttribute, LdapUserAccountControlAttributeName
			};
			return userAttributes;
		}

		private PageResultRequestControl CreatePageResultRequestControl() {
			var paging = new PageResultRequestControl(PageRecordsCount);
			paging.IsCritical = false;
			return paging;
		}

		private SortRequestControl CreateSortRequestControl(string sortByAttr) {
			var sortControl = new SortRequestControl(sortByAttr, false);
			sortControl.IsCritical = false;
			return sortControl;
		}

		private static void SetPagingCookie(SearchResponse response, PageResultRequestControl paging) {
			if (response.Controls.Length != 0) {
				var responseControl = (PageResultResponseControl) Array.Find(response.Controls,
					item => item is PageResultResponseControl);
				paging.Cookie = responseControl.Cookie;
			}
		}

		private int InsertUsersIdsToTableByFilter(string tableCode, string filter, Guid syncId) {
			var result = 0;
			string[] userAttributes = new[] { _ldapUserIdentityAttribute, LdapUserAccountControlAttributeName };
			var request = new SearchRequest(_ldapUsersEntry, filter, SearchScope.Subtree, userAttributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			do {
				SearchResponse response;
				try {
					response = _ldapConnection.SendRequest(request, RequestTimeout) as SearchResponse;
				} catch (Exception exception) {
					LogLdapRequestError(exception, request);
					throw;
				}
				if (response.ResultCode == ResultCode.Success) {
					foreach (SearchResultEntry entry in response.Entries) {
						var ldapUserId = GetEntryIdentityAttribute(entry, _ldapUserIdentityAttribute);
						var insertUser = new Insert(_userConnection).Into(tableCode)
							.Set("Id", Column.Parameter(ldapUserId));
						if (syncId.IsNotEmpty()) {
							insertUser.Set("LdapSyncId", Column.Parameter(syncId));
						}
						try {
							result += insertUser.Execute();
						} catch (Exception e) {
							_log.ErrorFormat("SyncID: {2}. An error occurred while adding the record to the \"{0}\" table: {1}", e,
								tableCode, e.Message, syncId);
							throw;
						}
					}
				} else {
					_log.DebugFormat("SyncID: {2}. Unable to obtain a list of users with the \"{0}\" filter. Result code: {1}.",
						filter, response.ResultCode, syncId);
				}
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			return result;
		}

		private int InsertMembersOfGroupToTable(LdapGroup group, string tableCode, Guid syncId) {
			_log.DebugFormat("SyncID: {2}. Insert data on users from group \"{0}\" to table {1}.", group.Name,
				tableCode, syncId);
			var filter = "(&" + _ldapUsersFilter + _ldapUsersInGroupFilter + ")";
			string usersInGroupFilter = GetUserInGroupFilterString(filter, group);
			var result = InsertUsersToTableByFilter(tableCode, usersInGroupFilter, syncId);
			_log.DebugFormat("SyncID: {2}. {0} records about users from group \"{1}\" added to table {2}.", result,
				group.Name, tableCode, syncId);
			return result;
		}

		private int InsertUsersToTable(string tableCode, Guid syncId) {
			_log.DebugFormat("SyncID: {1}. Inserting user data in table {0}.", tableCode, syncId);
			string ldapModifiedUsersFilter = GetUserFilterWithMinModifiedOnAttributeOrDate(null);
			int result = InsertUsersToTableByFilter(tableCode, ldapModifiedUsersFilter, syncId);
			_log.DebugFormat("SyncID: {2}. {0} user records have been added to table {1}.", result, tableCode, syncId);
			return result;
		}

		private int InsertGroupsToTable(string tableCode, Guid syncId) {
			// TODO consider getting a list of groups using GetGroups
			_log.DebugFormat("SyncID: {1}. Inserting group data into table {0}.", tableCode, syncId);
			var result = 0;
			string[] requiredGroupAttributes = GetRequiredGroupAttributes();
			var request = new SearchRequest(_ldapGroupsEntry, _ldapGroupsFilter, SearchScope.Subtree,
				requiredGroupAttributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			SortRequestControl sortControl = CreateSortRequestControl(_ldapGroupNameAttribute);
			request.Controls.Add(sortControl);
			do {
				SearchResponse response;
				try {
					response = _ldapConnection.SendRequest(request, RequestTimeout) as SearchResponse;
				} catch (Exception exception) {
					LogLdapRequestError(exception, request);
					throw;
				}
				if (response.ResultCode == ResultCode.Success) {
					foreach (SearchResultEntry entry in response.Entries) {
						CheckEntryAttributes(entry, requiredGroupAttributes);
						LdapGroup ldapGroup = CreateLdapGroup(entry);
						var insertGroup = new Insert(_userConnection).Into(tableCode)
							.Set("Id", Column.Parameter(ldapGroup.Id))
							.Set("Name", Column.Parameter(ldapGroup.Name))
							.Set("Dn", Column.Parameter(ldapGroup.Dn))
							.Set("ModifiedOn", Column.Parameter(ldapGroup.ModifiedOn));
						if (syncId.IsNotEmpty()) {
							insertGroup.Set("LdapSyncId", Column.Parameter(syncId));
						}
						try {
							result += insertGroup.Execute();
						} catch (Exception e) {
							_log.ErrorFormat("SyncID: {2}. An error occurred while adding the record to the \"{0}\" table: {1}",
								e, tableCode, e.Message, syncId);
							throw;
						}
					}
				} else {
					_log.DebugFormat("SyncID: {2}. Unable to obtain the list of folders. Result code: {0}. Error: {1}.",
						response.ResultCode, response.ErrorMessage ?? string.Empty, syncId);
				}
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			_log.DebugFormat("SyncID: {2}. {0} group records added to table {1}.", result, tableCode, syncId);
			return result;
		}

		#endregion

		#region Methods: Internal

		internal int InsertUsersIdsToTableByFilter(Guid syncId) {
			return InsertUsersIdsToTableByFilter("SysLDAPSynchUser", _ldapUsersFilter, syncId);
		}

		internal int InsertMembersOfGroupToTable(LdapGroup group, Guid syncId) {
			return InsertMembersOfGroupToTable(group, "SysLDAPSynchUser", syncId);
		}

		internal int InsertUsersToTable(Guid syncId) {
			return InsertUsersToTable("SysLDAPSynchUser", syncId);
		}

		internal int InsertGroupsToTable(Guid syncId) {
			return InsertGroupsToTable("SysLDAPSynchGroup", syncId);
		}

		#endregion

		#region Methods: Public

		#region Custom: Log

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="message">Message text.</param>
		public static void WriteToLog(string message) {
			_log.Info(message);
		}

		/// <summary>
		/// Logs an info message.
		/// </summary>
		/// <param name="format">Composite format string with debug message.</param>
		/// <param name="args">Message format options.</param>
		/// <exception cref="BPMSoft.Common.ArgumentNullOrEmptyException">
		/// If the value of the object <paramref name = "format"/> or <paramref name="args"/> equals <c>null</c>.
		/// </exception>
		public static void LogInfo(string format, params object[] args) {
			_log.InfoFormat(format, args);
		}

		/// <summary>
		/// Logs an error message.
		/// </summary>
		/// <param name="format">Composite format string with debug message.</param>
		/// <param name="args">Message format options.</param>
		/// <exception cref="BPMSoft.Common.ArgumentNullOrEmptyException">
		/// If the value of the object <paramref name = "format"/> or <paramref name="args"/> equals <c>null</c>.
		/// </exception>
		public static void LogError(string format, params object[] args) {
			_log.ErrorFormat(format, args);
		}

		/// <summary>
		/// Logs a debug message.
		/// </summary>
		/// <param name="format">Composite format string with debug message.</param>
		/// <param name="args">Message format options.</param>
		/// <exception cref="BPMSoft.Common.ArgumentNullOrEmptyException">
		/// If the value of the object <paramref name = "format"/> or <paramref name="args"/> equals <c>null</c>.
		/// </exception>
		public static void LogDebug(string format, params object[] args) {
			_log.DebugFormat(format, args);
		}

		#endregion

		public static DateTime ConvertToDateTime(string value) {
			if (value.Length < 10 || (value.Length >= 15 && char.IsDigit(value, 14))) {
				return DateTime.FromFileTime(long.Parse(value));
			}
			var val = value;
			var format = "yyyyMMddHH";
			switch (value.Length) {
				case 11:
					val = value.Remove(value.Length - 1, 1);
					format = "yyyyMMddHH";
					break;
				case 12:
					format = "yyyyMMddHHmm";
					break;
				case 13:
					val = value.Remove(value.Length - 1, 1);
					format = "yyyyMMddHHmm";
					break;
				case 14:
					format = "yyyyMMddHHmmss";
					break;
				case 15:
					val = value.Remove(value.Length - 1, 1);
					format = "yyyyMMddHHmmss";
					break;
				case 16:
					format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "f";
					break;
				case 17:
					if (value.Substring(value.Length - 1, 1) == "Z") {
						val = value.Remove(value.Length - 1, 1);
						format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "f";
					} else {
						format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "ff";
					}
					break;
				case 18:
					if (value.Substring(value.Length - 1, 1) == "Z") {
						val = value.Remove(value.Length - 1, 1);
						format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "ff";
					} else {
						format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "fff";
					}
					break;
				case 19:
					val = value.Remove(value.Length - 1, 1);
					format = "yyyyMMddHHmmss" + value.Substring(14, 1) + "fff";
					break;
			}
			return DateTime.ParseExact(val, format, CultureInfo.InvariantCulture);
		}

		public static bool CheckRequiredLDAPSettings(UserConnection userConnection) {
			_log.Debug("Checking required settings for LDAP.");
			bool isValidLDAPSettings = GetIsValidRequiredLDAPSettings(userConnection);
			_log.DebugFormat("LDAP settings check result: {0}", isValidLDAPSettings);
			return isValidLDAPSettings;
		}
		
		public static List<Guid> GetExistingContactIds(UserConnection userConnection, string fullName, string email,
				string phone) {
			var contactIdsQuery = new Select(userConnection)
				.Column("Id")
				.From("Contact")
				.Where("Name").IsEqual(Column.Parameter(string.IsNullOrEmpty(fullName) ? string.Empty : fullName));
			if (!string.IsNullOrEmpty(email)) {
				contactIdsQuery.And("Id").In(new Select(userConnection)
					.Column("ContactId").From("ContactCommunication")
					.Where("Number").IsEqual(Column.Parameter(string.IsNullOrEmpty(email) ? string.Empty : email)));
			}
			if (!string.IsNullOrEmpty(phone)) {
				contactIdsQuery.And("Id").In(new Select(userConnection)
					.Column("ContactId").From("ContactCommunication")
					.Where("Number").IsEqual(Column.Parameter(string.IsNullOrEmpty(phone) ? string.Empty : phone)));
			}
			var contactIds = new List<Guid>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = ((Select)contactIdsQuery).ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						string val = dr.GetValue(0).ToString();
						contactIds.Add(new Guid(val));
					}
				}
			}
			return contactIds;
		}

		public virtual List<LdapUser> GetUsersByLdapFilter(string filter) {
			var usersList = new List<LdapUser>();
			string[] userAttributes = GetUserAttributes();
			string[] userRequiredAttributes = GetUserRequiredAttributes();
			var request = new SearchRequest(_ldapUsersEntry, filter, SearchScope.Subtree, userAttributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			SortRequestControl sortControl = CreateSortRequestControl(_ldapUserLoginAttribute);
			request.Controls.Add(sortControl);
			do {
				SearchResponse response;
				try {
					response = _ldapConnection.SendRequest(request, RequestTimeout) as SearchResponse;
				} catch (Exception exception) {
					LogLdapRequestError(exception, request);
					throw;
				}
				if (response.ResultCode == ResultCode.Success) {
					foreach (SearchResultEntry entry in response.Entries) {
						CheckEntryAttributes(entry, userRequiredAttributes);
						LdapUser ldapUser = CreateLdapUser(entry, null);
						usersList.Add(ldapUser);
					}
				} else {
					_log.DebugFormat("Unable to obtain a list of users with the \"{0}\" filter. Result code: {1}. Error: {2}",
						filter, response.ResultCode, response.ErrorMessage ?? string.Empty);
				}
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			return usersList;
		}

		public List<Guid> GetUserIdsByContactId(Guid contactId) {
			var userIdsQuery = new Select(_userConnection)
				.Column("Id")
				.From("SysAdminUnit")
				.Where("ContactId").IsEqual(Column.Parameter(contactId))
				.And("SysAdminUnitTypeValue").IsEqual(Column.Parameter(SysAdminUnitType.User));
			var userIds = new List<Guid>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection())
			using (IDataReader dr = ((Select)userIdsQuery).ExecuteReader(dbExecutor)) {
				while (dr.Read()) {
					var val = dr.GetValue(0).ToString();
					userIds.Add(new Guid(val));
				}
			}
			return userIds;
		}

		public List<LdapGroup> GetGroups() {
			_log.Debug("Obtaining list of user groups from server.");
			var groupsList = new List<LdapGroup>();
			string[] requiredGroupAttributes = GetRequiredGroupAttributes();
			var request = new SearchRequest(_ldapGroupsEntry, _ldapGroupsFilter, SearchScope.Subtree,
				requiredGroupAttributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			SortRequestControl sortControl = CreateSortRequestControl(_ldapGroupNameAttribute);
			request.Controls.Add(sortControl);
			do {
				SearchResponse response;
				try {
					response = _ldapConnection.SendRequest(request, RequestTimeout) as SearchResponse;
				} catch (Exception exception) {
					LogLdapRequestError(exception, request);
					throw;
				}
				if (response.ResultCode == ResultCode.Success) {
					foreach (SearchResultEntry entry in response.Entries) {
						CheckEntryAttributes(entry, requiredGroupAttributes);
						LdapGroup ldapGroup = CreateLdapGroup(entry);
						groupsList.Add(ldapGroup);
					}
				} else {
					_log.DebugFormat("Unable to obtain the list of folders. Result code: {0}. Error: {1}.",
						response.ResultCode, response.ErrorMessage ?? string.Empty);
				}
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			_log.DebugFormat("{0} user group(s) received from server.", groupsList.Count);
			return groupsList;
		}

		public List<LdapUser> GetUsers() {
			_log.Debug("Obtaining list of users from server.");
			string ldapModifiedUsersFilter = GetUserFilterWithMinModifiedOnAttributeOrDate(null);
			List<LdapUser> usersList = GetUsersByLdapFilter(ldapModifiedUsersFilter);
			_log.DebugFormat("{0} user(s) received from server.", usersList.Count);
			return usersList;
		}

		public List<LdapUser> GetMembersOfGroup(LdapGroup group) {
			return GetMembersOfGroup(group, null);
		}

		public List<LdapUser> GetMembersOfGroup(LdapGroup group, DateTime? ldapModifiedDate) {
			_log.DebugFormat("Receiving list of users in group \"{0}\" from server.", group.Name);
			string ldapModifiedUsersFilter = GetUserFilterWithMinModifiedOnAttributeOrDate(ldapModifiedDate);
			var filter = "(&" + ldapModifiedUsersFilter + _ldapUsersInGroupFilter + ")";
			List<LdapUser> usersList = GetUsersByLdapFilter(GetUserInGroupFilterString(filter, group));
			_log.DebugFormat("{0} users of group \"{1}\" received from server.", usersList.Count, group.Name);
			return usersList;
		}

		public IEnumerable<SearchResultEntry> GetGroupsAttributesByFilter(string filter, string[] attributes,
				string sortByAttr = null) {
			_log.Debug("Obtaining group data from server.");
			var request = new SearchRequest(_ldapGroupsEntry, filter, SearchScope.Subtree, attributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			if (sortByAttr != null) {
				SortRequestControl sortControl = CreateSortRequestControl(sortByAttr);
				request.Controls.Add(sortControl);
			}
			var result = new List<SearchResultEntry>();
			do {
				var response = _ldapConnection.SendRequest(request) as SearchResponse;
				if (response.ResultCode != ResultCode.Success) {
					throw new Exception(response.ErrorMessage);
				}
				for (int index = 0; index < response.Entries.Count; index++) {
					result.Add(response.Entries[index]);
				}
				_log.DebugFormat("Data about {0} groups received from server.", result.Count);
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			return result;
		}

		public IEnumerable<SearchResultEntry> GetUsersAttributesByFilter(string filter, string[] attributes,
				string sortByAttr = null) {
			_log.Debug("Obtaining user data from server.");
			var request = new SearchRequest(_ldapUsersEntry, filter, SearchScope.Subtree, attributes);
			PageResultRequestControl paging = CreatePageResultRequestControl();
			request.Controls.Add(paging);
			if (sortByAttr != null) {
				SortRequestControl sortControl = CreateSortRequestControl(sortByAttr);
				request.Controls.Add(sortControl);
			}
			var result = new List<SearchResultEntry>();
			do {
				var response = _ldapConnection.SendRequest(request) as SearchResponse;
				if (response.ResultCode != ResultCode.Success) {
					throw new Exception(response.ErrorMessage);
				}
				for (int index = 0; index < response.Entries.Count; index++) {
					result.Add(response.Entries[index]);
				}
				_log.Debug(string.Format("Received data on {0} users from server.", result.Count));
				SetPagingCookie(response, paging);
			} while (paging.Cookie.Length != 0);
			return result;
		}

		[Obsolete("7.18.2. Use InsertGroupsToTable(Guid)")]
		public int InsertGroupsToTable() {
			return InsertGroupsToTable("SysLDAPSynchGroup", Guid.Empty);
		}

		[Obsolete("7.18.2. Use InsertGroupsToTable(Guid)")]
		public int InsertGroupsToTable(string tableCode) {
			return InsertGroupsToTable(tableCode, Guid.Empty);
		}

		[Obsolete("7.18.2. Use InsertUsersToTable(Guid)")]
		public int InsertUsersToTable() {
			return InsertUsersToTable("SysLDAPSynchUser", Guid.Empty);
		}

		[Obsolete("7.18.2. Use InsertUsersToTable(Guid)")]
		public int InsertUsersToTable(string tableCode) {
			return InsertUsersToTable(tableCode, Guid.Empty);
		}

		[Obsolete("7.18.2. Use InsertMembersOfGroupToTable(LdapGroup, Guid)")]
		public int InsertMembersOfGroupToTable(LdapGroup group) {
			return InsertMembersOfGroupToTable(group, "SysLDAPSynchUser", Guid.Empty);
		}

		[Obsolete("7.18.2. Use InsertMembersOfGroupToTable(LdapGroup, Guid)")]
		public int InsertMembersOfGroupToTable(LdapGroup group, string tableCode) {
			return InsertMembersOfGroupToTable(group, tableCode, Guid.Empty);
		}

		public void Dispose() {
			if (_ldapConnection == null) {
				return;
			}
			_ldapConnection.Dispose();
			_ldapConnection = null;
			_log.Debug("Connection complete.");
		}

		public string IdentityAttributeToString(object val) {
			if (!(val is byte[])) {
				return Convert.ChangeType(val, typeof(string)).ToString();
			}
			var hasher = MD5.Create();
			byte[] data = hasher.ComputeHash(val as byte[]);
			var sb = new StringBuilder(512);
			for (int i = 0; i < data.Length; i++) {
				sb.Append(data[i].ToString("x2"));
			}
			return sb.ToString();
		}

		#endregion

	}

	#endregion

}
