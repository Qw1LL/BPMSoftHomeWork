namespace BPMSoft.Configuration.SSP
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: SspUserManagementService

	/// <summary>
	/// Service for creating users and invitation them on ssp which uses <see cref="SspUserManagementServiceHelper"/>.
	/// </summary>
	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SspUserManagementService : BaseService
	{

		#region Methods: Private

		private List<ContactInvite> MapContactsInvites(IEnumerable<ISspUserInvitation> usersInvitation) {
			return usersInvitation.Select(userInvite => new ContactInvite {
				ContactId = userInvite.ContactId,
				SysAdminUnitId = userInvite.SysAdminUnitId,
				Success = userInvite.Success,
				Error = userInvite.Error,
				Name = userInvite.Name,
				UserName = userInvite.UserName,
				Email = userInvite.Email
			}).ToList();
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ContactsInviteServiceResponse CreateUsers(SspUserManagementServiceRequest request) {
			var response = new ContactsInviteServiceResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				sspUserManagementHelper.CheckCanAddRoles(request.UserRoles, request.AccountId);
				IEnumerable<ISspUserInvitation> result = sspUserManagementHelper.CreateUsersByEmails(request);
				response.ContactInvites = MapContactsInvites(result);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ContactsInviteServiceResponse InviteUsers(InviteServiceRequest request) {
			var response = new ContactsInviteServiceResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				IEnumerable<ISspUserInvitation> result = sspUserManagementHelper.InviteUsers(request);
				response.ContactInvites = MapContactsInvites(result);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ContactsInviteServiceResponse CreateUsersByContactsIds(CreateUsersByContactsServiceRequest request) {
			var response = new ContactsInviteServiceResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				sspUserManagementHelper.CheckCanAddRoles(request.UserRoles, request.AccountId);
				IEnumerable<ISspUserInvitation> result = sspUserManagementHelper.CreateUsersByContactIds(request);
				response.ContactInvites = MapContactsInvites(result);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		///  Checks portal account group existence.
		/// </summary>
		/// <param name="accountId">Account which must be checked.</param>
		/// <returns>True if portal account exists, otherwise - false.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SspUserManagementServiceResponse CheckIfPortalAccountExist(Guid accountId) {
			var response = new SspUserManagementServiceResponse();
			try {
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				response.IsPortalAccountExists = sspUserManagementHelper.CheckIfAccountGroupExist(accountId);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Get information about portal account.
		/// </summary>
		/// <returns>Object with ssp account fields set.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SspUserManagementServiceSspAccountInfo GetSspAccountInfo() {
			var response = new SspUserManagementServiceSspAccountInfo();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				var sspAccountInfo = sspUserManagementHelper.GetSspAccountInfo(UserConnection.CurrentUser.Id);
				response.SspAccountId = (Guid)sspAccountInfo["PortalAccountId"];
				response.SspAccountAdminUnitId = (Guid)sspAccountInfo["SspAccountAdminUnitId"];
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Get optional functional roles for portal account.
		/// </summary>
		/// <returns>key-value pair with role id and role caption</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SspUserManagementServiceRolesListResponse GetOptionalFuncRolesList(Guid sspAccountId) {
			var response = new SspUserManagementServiceRolesListResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				var rolesList = sspUserManagementHelper.GetOptionalFuncRolesList(sspAccountId);
				response.RolesCollection = rolesList;
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		/// <summary>
		/// Get enabled functional roles from optional roles list for ssp user.
		/// </summary>
		/// <returns>key-value pair with role id and role caption</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public UserInRolePairServiceResponse GetEnabledFuncRolesForUser(Guid[] userIds) {
			var response = new UserInRolePairServiceResponse {
				UsersInRoles = new List<UserInRolePair>()
			};
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				response.UsersInRoles = sspUserManagementHelper.GetEnabledFuncRolesForUser(userIds.ToList()).ToList();
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ApplyOptionalFuncRolesForUsers(UserInRolePair[] usersInRoles) {
			var response = new ConfigurationServiceResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				sspUserManagementHelper.ApplyOptionalFuncRolesForUsers(usersInRoles.ToList());
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse ChangeUserActivationStatus(Guid userId, bool isActive) {
			var response = new ConfigurationServiceResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				sspUserManagementHelper.ChangeUserActivationStatus(userId, isActive);
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SspLicenseResponse GetSspLicNames() {
			var response = new SspLicenseResponse();
			try {
				UserConnection.DBSecurityEngine.CheckCanManageSspUsers();
				var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
				response.SspLicNames = sspUserManagementHelper.GetSspLicNames();
			} catch (Exception ex) {
				response.Exception = ex;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public string GetDefaultSspLicName() {
			var sspUserManagementHelper = new SspUserManagementServiceHelper(UserConnection);
			return sspUserManagementHelper.GetDefaultSspLicName();
		}

		#endregion

	}

	#endregion

	#region Class: SspUserManagementServiceResponse

	[DataContract]
	public class SspUserManagementServiceResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "isPortalAccountExists")]
		public bool IsPortalAccountExists { get; set; }

		#endregion

	}

	#endregion

	#region Class: SspUserManagementServiceSspAccountInfo

	[DataContract]
	public class SspUserManagementServiceSspAccountInfo : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "SspAccountId")]
		public Guid SspAccountId { get; set; }

		[DataMember(Name = "SspAccountAdminUnitId")]
		public Guid SspAccountAdminUnitId { get; set; }

		#endregion

	}

	[DataContract]
	public class SspUserManagementServiceRolesListResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "RolesCollection")]
		public Dictionary<Guid, string> RolesCollection { get; set; }

		#endregion

	}

	[DataContract]
	public class UserInRolePairServiceResponse : ConfigurationServiceResponse
	{
		[DataMember(Name = "UsersInRoles")]
		public List<UserInRolePair> UsersInRoles { get; set; }
	}

	[DataContract]
	public class UserInRolePair
	{

		#region Properties: Public

		[DataMember(Name = "UserId")]
		public Guid UserId { get; set; }

		[DataMember(Name = "RoleId")]
		public Guid RoleId { get; set; }

		[DataMember(Name = "IsRoleApplied")]
		public bool IsRoleApplied { get; set; }

		#endregion

	}

	#endregion

	#region Class: SspLicenseResponse

	[DataContract]
	public class SspLicenseResponse : ConfigurationServiceResponse
	{

		#region Properties: Public
		
		[DataMember(Name = "sspLicNames")]
		public List<string> SspLicNames { get; set; }

		#endregion

	}

	#endregion

	#region Class: ContactsInviteServiceResponse

	[DataContract]
	public class ContactsInviteServiceResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		[DataMember(Name = "contactInvites")]
		public List<ContactInvite> ContactInvites { get; set; }

		[DataMember(Name = "userRoles")]
		public Guid[] UserRoles { get; set; }

		#endregion
	}

	#endregion

	#region Class: ContactInvite

	[DataContract]
	public class ContactInvite
	{
		#region Properties: Public

		[DataMember(Name = "contactId")]
		public Guid ContactId { get; set; }

		[DataMember(Name = "sysAdminUnitId")]
		public Guid SysAdminUnitId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "userName")]
		public string UserName { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "success")]
		public bool Success { get; set; }

		[DataMember(Name = "error")]
		public string Error { get; set; }

		#endregion
	}

	#endregion



	#region Class: SspUserManagementServiceRequest

	[DataContract]
	public class SspUserManagementServiceRequest
	{

		#region Properties: Public

		[DataMember(Name = "emails")]
		public string Emails { get; set; }

		[DataMember(Name = "accountId")]
		public Guid AccountId { get; set; }

		[DataMember(Name = "userRoles")]
		public Guid[] UserRoles { get; set; }

		#endregion

	}

	#endregion

	#region Class: CreateUsersByContactsServiceRequest

	[DataContract]
	public class CreateUsersByContactsServiceRequest
	{

		#region Properties: Public

		[DataMember(Name = "contactIds")]
		public Guid[] ContactIds { get; set; }

		[DataMember(Name = "accountId")]
		public Guid AccountId { get; set; }

		[DataMember(Name = "userRoles")]
		public Guid[] UserRoles { get; set; }

		#endregion

	}

	#endregion

	#region Class: InviteServiceRequest

	[DataContract]
	public class InviteServiceRequest
	{

		#region Properties: Public

		[DataMember(Name = "sysAdminUnitIds")]
		public List<Guid> SysAdminUnitIds { get; set; }

		#endregion

	}

	#endregion

}

