namespace BPMSoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: BaseServerConnector

	/// <summary
	/// Class implements connection to social network.
	/// </summary>
	public class BaseServerConnector
	{

		#region Properties: Private

		private string ConsumerInfoServiceUri {
			get {
				string consumerInfoServiceUri = UserConnection.AppConnection.ConsumerInfoServiceUri;
				if (consumerInfoServiceUri.IsNullOrEmpty()) {
					throw new MissingConsumerInfoServiceUriException();
				}
				return consumerInfoServiceUri;
			}
		}

		#endregion

		#region Properties: Protected

		private AppConnection _appConnection;
		protected AppConnection AppConnection {
			get {
				return _appConnection ?? (_appConnection = (AppConnection)HttpContext.Current.Application["AppConnection"]);
			}
		}

		private UserConnection _userConnection;
		protected UserConnection UserConnection {
			get {
				return _userConnection ?? (_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"]);
			}
		}

		private SystemUserConnection _systemUserConnection;
		protected SystemUserConnection SystemUserConnection {
			get {
				return _systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);
			}
		}

		private ILog _log;
		protected ILog Log {
			get {
				return _log ?? (_log = LogManager.GetLogger("commonAppender"));
			}
		}

		private string _clientVersion;
		protected string ClientVersion {
			get {
				return _clientVersion;
			}
			set {
				_clientVersion = value;
			}
		}

		private string _accessToken;
		protected string AccessToken {
			get {
				return _accessToken;
			}
			set {
				_accessToken = value;
			}
		}

		protected virtual bool UseSharedApplication {
			get {
				throw new NotImplementedException();
			}
		}

		protected virtual string ConsumerKeySysSettingName {
			get {
				throw new NotImplementedException();
			}
		}

		protected virtual string ConsumerSecretSysSettingName {
			get {
				throw new NotImplementedException();
			}
		}

		protected virtual string ConsumerVersionSysSettingName {
			get {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region Methods: Private

		private SocialAccount FetchSocialAccount(SocialNetworkServiceRequest request) {
			SocialAccount socialAccount = new SocialAccount(UserConnection);
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{"User", request.User},
				{"Type", request.Type}
			};
			bool socialAccountExists = socialAccount.FetchFromDB(conditions);
			Log.DebugFormat("SocialAccountExists: [{0}]", socialAccountExists);
			return socialAccountExists ? socialAccount : null;
		}

		private WebRequest CreateServiceRequest(params string[] parameters) {
			string parametersString = string.Join("/", parameters);
			string uri = string.Join("/", ConsumerInfoServiceUri, parametersString);
			return WebRequest.Create(uri);
		}

		#endregion

		#region Methods: Protected

		protected T GetSysSettingValue<T>(string code) {
			object value;
			if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(UserConnection, code, out value)) {
				return (T)value;
			}
			throw new ItemNotFoundException(new LocalizableString("BPMSoft.Core",
				"UserConnection.Exception.SettingsByCodeNotFound"), code);
		}

		protected virtual string GetRequestAccessToken(SocialNetworkServiceRequest request) {
			return request.AccessToken;
		}

		protected virtual string GetRequestConsumerSecret(SocialNetworkServiceRequest request) {
			return request.ConsumerSecret;
		}

		protected virtual string GetRequestConsumerVersion(SocialNetworkServiceRequest request) {
			return request.ConsumerVersion;
		}

		protected virtual string GetNewSocialAccountAccessToken(SocialNetworkServiceRequest request) {
			return request.AccessToken;
		}

		protected virtual ConsumerInfo GetConsumerInfoRemotely(SocialNetworkServiceRequest request) {
			throw new NotImplementedException();
		}

		protected virtual string GetConsumerKey(SocialNetworkServiceRequest request) {
			string consumerKey;
			if (UseSharedApplication) {
				ConsumerInfo consumerInfo = GetConsumerInfoRemotely(request);
				consumerKey = consumerInfo.Key;
			} else {
				consumerKey = GetSysSettingValue<string>(ConsumerKeySysSettingName);
			}
			if (consumerKey.IsNullOrEmpty()) {
				throw new MissingConsumerKeyException();
			}
			return consumerKey;
		}

		protected virtual string GetConsumerSecret(SocialNetworkServiceRequest request) {
			string consumerSecret = GetSysSettingValue<string>(ConsumerSecretSysSettingName);
			if (consumerSecret.IsNullOrEmpty()) {
				throw new MissingConsumerSecretException();
			}
			return consumerSecret;
		}

		protected virtual string GetConsumerVersion(SocialNetworkServiceRequest request) {
			return GetSysSettingValue<string>(ConsumerVersionSysSettingName);
		}

		protected virtual void InitSocialNetworkClient(SocialNetworkServiceRequest request) {
			AccessToken = GetAccessToken(request);
		}

		protected virtual void SocialAccountSaving(SocialAccount socialAccount, SocialNetworkServiceRequest request) {

		}

		protected T ExecuteConsumerInfoServiceMethod<T>(params string[] parameters) {
			WebRequest httpWebRequest = CreateServiceRequest(parameters);
			using (WebResponse webResponse = httpWebRequest.GetResponse()) {
				using (Stream responseStream = webResponse.GetResponseStream()) {
					using (StreamReader reader = new StreamReader(responseStream)) {
						string result = reader.ReadToEnd();
						return Json.Deserialize<T>(result);
					}
				}
			}
		}

		/// <summary>
		/// ############## ######## ########## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #######.</param>
		protected virtual void PrepareCommandExecutionContext(SocialNetworkServiceRequest request) {
			CheckSocialAccount(request);
			InitSocialNetworkClient(request);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ############ ##########.
		/// </summary>
		/// <param name="exception">##########.</param>
		public virtual T HandleException<T>(Exception exception) where T : ConfigurationServiceResponse, new() {
			Log.Debug(exception);
			T result = new T() {
				Exception = exception
			};
			return result;
		}

		/// <summary>
		/// ############# ###### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns><c>true</c>, #### ######### ###### #######;##### - <c>false</c>.</returns>
		public bool SetAccessToken(SocialNetworkServiceRequest request) {
			Log.Debug("SetAccessToken");
			SocialAccount socialAccount = GetSocialAccount(request);
			socialAccount.AccessToken = request.AccessToken;
			return socialAccount.Save();
		}

		/// <summary>
		/// ########## ###### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>###### #######.</returns>
		public string GetAccessToken(SocialNetworkServiceRequest request) {
			Log.Debug("GetAccessToken");
			SocialAccount socialAccount = GetSocialAccount(request);
			return socialAccount.AccessToken;
		}

		/// <summary>
		/// ########## ###### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>###### #######.</returns>
		public string FindAccessToken(SocialNetworkServiceRequest request) {
			Log.Debug("FindAccessToken");
			SocialAccount socialAccount = FindSocialAccount(request);
			return (socialAccount != null) ? socialAccount.AccessToken : string.Empty;
		}

		/// <summary>
		/// ####### ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ########.</param>
		/// <returns>######### ########## ######.</returns>
		public virtual bool CreateSocialAccount(SocialNetworkServiceRequest request) {
			SocialAccount currentSocialAccount = FindSocialAccount(request);
			if (currentSocialAccount != null && !currentSocialAccount.Public) {
				throw new DublicateDataException("SocialAccount");
			}
			string accessToken = GetNewSocialAccountAccessToken(request);
			string consumerKey = GetConsumerKey(request);
			Guid typeId = request.Type;
			Guid userId = request.User;
			string socialId = request.SocialId;
			SocialAccount socialAccount = new SocialAccount(UserConnection) {
				Name = "Name",
				Public = false,
				AccessToken = accessToken,
				ConsumerKey = consumerKey,
				TypeId = typeId,
				UserId = userId,
				SocialId = socialId
			};
			socialAccount.SetDefColumnValues();
			socialAccount.Saving += (object sender, EntityBeforeEventArgs e) => {
				SocialAccountSaving((SocialAccount)sender, request);
			};
			return socialAccount.Save();
		}

		/// <summary>
		/// ########## ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>####### ###### ## ####### #######.</returns>
		public virtual SocialAccount GetSocialAccount(SocialNetworkServiceRequest request) {
			Log.Debug("GetSocialAccount");
			var socialAccount = FindSocialAccount(request);
			if (socialAccount != null) {
				return socialAccount;
			}
			throw new MissingSocialAccountException();
		}

		/// <summary>
		/// ########## ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>####### ###### ## ####### #######.</returns>
		public virtual SocialAccount FindSocialAccount(SocialNetworkServiceRequest request) {
			Log.Debug("FindSocialAccount");
			EntitySchema socialAccountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SocialAccount");
			EntitySchemaQuery esq = new EntitySchemaQuery(socialAccountSchema);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("AccessToken");
			esq.AddColumn("ConsumerKey");
			esq.AddColumn("Login");
			esq.AddColumn("Name");
			esq.AddColumn("Public").OrderByAsc();
			esq.AddColumn("SocialId");
			esq.AddColumn("Type");
			esq.AddColumn("User");
			EntitySchemaQueryFilterCollection filters = esq.Filters;
			filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", request.Type));
			filters.Add(new EntitySchemaQueryFilterCollection(esq,
				LogicalOperationStrict.Or,
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "User", request.User),
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Public", true)));
//			esq.Cache = UserConnection.WorkspaceCache.WithLocalCaching
//			esq.CacheItemName
			EntityCollection socialAccounts = esq.GetEntityCollection(UserConnection);
			foreach (SocialAccount socialAccount in socialAccounts) {
				return socialAccount;
			}
			return null;
		}

		/// <summary>
		/// ########## ########## ## ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>########## ## ####### ###### ## ####### #######.</returns>
		public virtual SocialAccountInfo GetSocialAccountInfo(SocialNetworkServiceRequest request) {
			Log.Debug("GetSocialAccountInfo");
			SocialAccount socialAccount = GetSocialAccount(request);
			return new SocialAccountInfo(socialAccount);
		}

		/// <summary>
		/// ########## ########## ## ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>########## ## ####### ###### ## ####### #######.</returns>
		public virtual SocialAccountInfo FindSocialAccountInfo(SocialNetworkServiceRequest request) {
			SocialAccount socialAccount = FindSocialAccount(request);
			return (socialAccount != null) ? new SocialAccountInfo(socialAccount) : null;
		}

		/// <summary>
		/// ####### ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ####### ######.</param>
		/// <returns>######### ######## ######.</returns>
		public virtual bool DeleteSocialAccount(SocialNetworkServiceRequest request) {
			SocialAccount socialAccount = new SocialAccount(UserConnection);
			var conditions = new Dictionary<string, object> {
				{"User", request.User},
				{"Type", request.Type}
			};
			bool socialAccountExists = socialAccount.FetchFromDB(conditions);
			if (socialAccountExists) {
				bool deleteResult = socialAccount.Delete();
				return deleteResult;
			}
			throw new MissingSocialAccountException();
		}

		/// <summary>
		/// ######### ####### ####### ###### ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ####### ######.</param>
		public virtual void CheckSocialAccount(SocialNetworkServiceRequest request) {
			SocialAccount socialAccount = FindSocialAccount(request);
			if (socialAccount == null) {
				throw new MissingSocialAccountException();
			}
		}

		/// <summary>
		/// ######### ####### ########## # ########## ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>########## # ########## ## ####### #######.</returns>
		public virtual void CheckConsumerInfo(SocialNetworkServiceRequest request) {
			ConsumerInfo consumerInfo = GetConsumerInfo(request);
		}

		/// <summary>
		/// ######### ########### ########### # ######## #######.
		/// </summary>
		/// <param name="request">######, ######## ######### ###########.</param>
		public virtual void CheckCanOperate(SocialNetworkServiceRequest request) {
			CheckConsumerInfo(request);
			CheckSocialAccount(request);
		}

		/// <summary>
		/// ########## ########## # ########## ## ####### #######.
		/// </summary>
		/// <param name="request">######, ######## ######### #########.</param>
		/// <returns>########## # ########## ## ####### #######.</returns>
		public virtual ConsumerInfo GetConsumerInfo(SocialNetworkServiceRequest request) {
			if (UseSharedApplication) {
				return GetConsumerInfoRemotely(request);
			}
			return new ConsumerInfo {
				Key = GetConsumerKey(request),
				Secret = GetConsumerSecret(request),
				Version = GetConsumerVersion(request)
			};
		}

		#endregion

	}

	#endregion

}
