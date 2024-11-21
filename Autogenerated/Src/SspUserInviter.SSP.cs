namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using SystemSettings = Core.Configuration.SysSettings;

	#region Class: SspUserInviter

	/// <summary>
	/// Class which invite users to portal.
	/// </summary>
	public class SspUserInviter
	{
	
		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection {
			get;
		}

		private string _appUrl;
		/// <summary>
		/// Base application url.
		/// </summary>
		protected string AppUrl => _appUrl ?? (_appUrl = GetApplicationUrl());

		/// <summary>
		/// Class which work with SysAdminUnit<see cref="ISspUserAdministrator"/> class.
		/// </summary>
		protected ISspUserAdministrator SspUserAdministrator { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Collection of portal invites, instances of the<see cref="ISspUserInvitation"/> class.
		/// </summary>
		public List<ISspUserInvitation> UserInvites;

		#endregion

		#region Constructors: public

		/// <summary>
		/// Initializes a new instance of the <see cref="SspUserInviter"/> class.
		/// </summary>
		public SspUserInviter(UserConnection userConnection) {
			UserInvites = new List<ISspUserInvitation>();
			UserConnection = userConnection;
			SspUserAdministrator = new SspUserAdministrator(userConnection);
		}

		#endregion

		#region Methods: Private

		private string GetApplicationUrl() {
			var portalSiteUrl = SystemSettings.GetValue(UserConnection, "PortalSiteUrl", string.Empty).LeftOfRightmostOf("/");
			if (string.IsNullOrEmpty(portalSiteUrl)) {
				return HttpContext.Current != null
					? WebUtilities.GetParentApplicationUrl(HttpContext.Current.Request)
					: SystemSettings.GetValue(UserConnection, "SiteUrl", string.Empty).LeftOfRightmostOf("/");
			}		
			return portalSiteUrl;
		}

		private Select CreateSysAdminUnitQuery(List<Guid> users) {
			return new Select(UserConnection)
				.Column("sd", "Id")
				.Column("c", "Email")
				.Column("c", "Id").As("ContactId")
				.Column("sd", "Name")
				.From("SysAdminUnit", "sd")
				.LeftOuterJoin("Contact").As("c")
				.On("sd", "ContactId").IsEqual("c", "Id")
				.Where("sd", "Id").In(Column.Parameters(users)) as Select;
		}

		private void ActivateUsers() {
			var usersToConnect = UserInvites.Where(x => x.SysAdminUnitId != Guid.Empty).Select(user => user.SysAdminUnitId).ToList();
			SspUserAdministrator.ActivateUsersByIds(usersToConnect);
		}

		private void ReadUserData() {
			List<Guid> users = UserInvites.Where(x => x.SysAdminUnitId != Guid.Empty).
				Select(user => user.SysAdminUnitId).ToList();
			if (users.Any()) {
				var userDataSelectQuery = CreateSysAdminUnitQuery(users);
				using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = userDataSelectQuery.ExecuteReader(dbExec)) {
						while (reader.Read()) {
							var userId =  reader.GetColumnValue<Guid>("Id");
							var user = UserInvites.Find(x => x.SysAdminUnitId == userId);
							if (user != null) {
								user.Email = reader.GetColumnValue<string>("Email");
								user.UserName = reader.GetColumnValue<string>("Name");
								user.ContactId = reader.GetColumnValue<Guid>("ContactId");
							}
						}
					}
				}
			}
		}

		private void SetErrorForUsersWithoutEmails() {
			UserInvites.Where(x => string.IsNullOrEmpty(x.Email)).ForEach(x => {
				x.Success = false;
				x.Error = new LocalizableString(UserConnection.Workspace.ResourceStorage,
					"SspUserInviter", "LocalizableStrings.ContactHasNoEmail.Value");
			});
		}

		private bool CheckIfAllUserCorrect() {
			return !UserInvites.Any(x => string.IsNullOrEmpty(x.Email));
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Send email with portal invite.
		/// </summary>
		protected virtual void SendInvites() {
			var usersForInvites = UserInvites.Where(x => x.Success);
			foreach (var userInvite in usersForInvites) {
				var passwordRecovery = LoginUtilities
					.GenerateRecoveryPasswordLink(UserConnection, userInvite.UserName, AppUrl);
				RegistrationHelper.RegistrationHelper
					.SendInvitationEmail(UserConnection, userInvite.Email, userInvite.ContactId, 
						passwordRecovery.PasswordChangeUrl);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Add portal invite to portal invites collection.
		/// </summary>
		/// <param name="invite">Portal user invite.<see cref="ISspUserInvitation"/></param>
		public void AddInvite(ISspUserInvitation invite) {
			UserInvites.Add(invite);
		}

		/// <summary>
		/// Invite portal user which are in PortalInvites property.
		/// </summary>
		public virtual List<ISspUserInvitation> InviteUsers() {
			ReadUserData();
			SetErrorForUsersWithoutEmails();
			if (CheckIfAllUserCorrect()) {
				ActivateUsers();
				SendInvites();
			}
			return UserInvites;
		}

		#endregion

	}

	#endregion

}

