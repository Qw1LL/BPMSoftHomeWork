namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using RegHelper = BPMSoft.Configuration.RegistrationHelper.RegistrationHelper;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: TotpSendResetPasswordLinkService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TotpSendResetPasswordLinkService : BaseService
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Authentication");
		private string _appUrl;
		private SystemUserConnection _systemUserConnection;

		#endregion

		#region Properties: Private

		private SystemUserConnection SystemUserConnection =>
			_systemUserConnection ?? (_systemUserConnection = (SystemUserConnection)AppConnection.SystemUserConnection);

		#endregion

		#region Properties: Protected

		protected string AppUrl => _appUrl ?? (_appUrl = GetApplicationUrl());

		#endregion

		#region Methods: Private

		private string GenerateToken(string userName) {
			var generator =
				ClassFactory.Get<ITotpSetupTokenGenerator>(new ConstructorArgument("userConnection",
					SystemUserConnection));
			return generator.GenerateToken(userName);
		}

		private string GetApplicationUrl() {
			return HttpContext.Current != null
				? WebUtilities.GetParentApplicationUrl(HttpContext.Current.Request)
				: SystemSettings.GetValue(SystemUserConnection, "SiteUrl", string.Empty).LeftOfRightmostOf("/");
		}

		private string GetPasswordChangeUrl(string userName) {
			string token = GenerateToken(userName);
			return $"{AppUrl}/Login/TotpRecoverPassword.aspx?totpSetupToken={token}";
		}

		private string FindUserEmail(string userName) {
			var select = (Select)new Select(SystemUserConnection)
				.Column("SysAdminUnit", "Email")
				.From("TotpSecret")
				.InnerJoin("SysAdminUnit").On("SysAdminUnit", "Id").IsEqual("TotpSecret", "SysAdminUnitId")
				.Where(Func.Upper("SysAdminUnit", "Name")).IsEqual(Func.Upper(Column.Parameter(userName)))
				.And("SysAdminUnitTypeValue").In(Column.Parameter(Core.DB.SysAdminUnitType.User),
					Column.Parameter(Core.DB.SysAdminUnitType.SelfServicePortalUser));
			return select.ExecuteScalar<string>();
		}

		private void UpdateResetPasswordAndExpirePasswordFlags(string userName) {
			var update = (Update)new Update(SystemUserConnection, "SysAdminUnit")
				.Set("ForceChangePassword", Column.Parameter(0))
				.Set("PasswordExpireDate", Column.Parameter(DateTime.UtcNow.AddDays(1))).Where("Name")
				.IsEqual(Column.Parameter(userName)).And("SysAdminUnitTypeValue").In(
					Column.Parameter(Core.DB.SysAdminUnitType.User),
					Column.Parameter(Core.DB.SysAdminUnitType.SelfServicePortalUser));
			update.Execute();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "RemindPassword", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public RemindPasswordResponse SendRecoveryPasswordLink(RemindPasswordRequest remindPasswordRequest) {
			const string successMessage = "The request was handled successfully";
			string userName = remindPasswordRequest.UserName;
			try {
				string email = FindUserEmail(userName);
				if (string.IsNullOrEmpty(email)) {
					_log.Warn($"User email not found ({userName})");
					return new RemindPasswordResponse {
						Success = true,
						Message = successMessage
					};
				}
				string subject;
				string body;
				if (SystemUserConnection.GetIsFeatureEnabled("MultilanguageRegistrationEmail")) {
					Entity template = RegHelper.GetTemplateByUserCulture(SystemUserConnection,
						HttpContext.Current.Request.UserLanguages,
						RegHelper.GetRecoveryPasswordEmailTemplateId(SystemUserConnection));
					subject = template.GetTypedColumnValue<string>("Subject");
					body = template.GetTypedColumnValue<string>("Body")
						.Replace("#RecoveryLinkUrl#", GetPasswordChangeUrl(userName));
				} else {
					subject = new LocalizableString("BPMSoft.WebApp.Loader", "RecoveryPasswordMailSubject");
					body = string.Format(new LocalizableString("BPMSoft.WebApp.Loader", "RecoveryPasswordMailBody"),
						GetPasswordChangeUrl(userName));
				}
				UpdateResetPasswordAndExpirePasswordFlags(userName);
				RegHelper.SendRecoveryPasswordLink(SystemUserConnection, email, subject, body);
			} catch (Exception e) {
				_log.Error("Exception occured in reset password procedure", e);
			}
			return new RemindPasswordResponse {
				Success = true,
				Message = successMessage
			};
		}

		#endregion

	}

	[DataContract]
	public class RemindPasswordRequest
	{

		#region Properties: Public

		[DataMember(Name = "userName")]
		public string UserName { get; set; }

		#endregion

	}

	[DataContract]
	public class RemindPasswordResponse
	{

		#region Properties: Public

		[DataMember(Name = "success")]
		public bool Success { get; set; }

		[DataMember(Name = "message")]
		public string Message { get; set; }

		#endregion

	}

	#endregion

}

