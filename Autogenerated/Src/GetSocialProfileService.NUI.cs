namespace BPMSoft.Configuration.GetSocialProfileService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Social;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GetSocialProfileService : BaseService 
	{

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSocialProfile", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetSocialProfile(string socialMediaId, string socialNetworkName, string socialAccountId) {
			SocialProfile resultProfile = null;
			SocialCommutator commutator = null;  
			if (string.IsNullOrEmpty(socialNetworkName)) {
				socialNetworkName = ((SocialNetwork)int.Parse(socialMediaId)).ToString();
			}
			switch (socialNetworkName) {
				case "Facebook":
					commutator = new SocialCommutator(UserConnection, SocialNetwork.Facebook);
					break;
				case "Twitter":
					commutator = new SocialCommutator(UserConnection, SocialNetwork.Twitter);
					break;
				}
			if(commutator != null) {
				SocialNetwork AccessTokenExceptionNetworks = SocialNetwork.None;
				SocialNetwork ExceptionNetworks = SocialNetwork.None;
				commutator.ExceptionOccurred += delegate(ISocialNetwork network, Exception e) {
					if (e is AccessTokenExpired) {
						AccessTokenExceptionNetworks = (SocialNetwork)AccessTokenExceptionNetworks | (e as AccessTokenExpired).SocialNetwork;
					} else if (e is SocialNetworkException) {
						ExceptionNetworks = (SocialNetwork)ExceptionNetworks | (e as SocialNetworkException).SocialNetwork;
					} else {
						throw e;
					}
				};
				var profile = commutator.GetProfile(socialAccountId);
				resultProfile = new SocialProfile();
				resultProfile.SocialNetwork = socialNetworkName;
				if(profile == null && (AccessTokenExceptionNetworks != SocialNetwork.None || ExceptionNetworks != SocialNetwork.None)){
					return string.Format("{{\"accessTokenExNetworks\":\"{0}\", \"exeptionNetworks\":\"{1}\"}}", AccessTokenExceptionNetworks.ToString(), ExceptionNetworks.ToString());
				}
				resultProfile.ProdileId = profile.Id;
				if(!string.IsNullOrEmpty(profile.Name)) {
					resultProfile.Name = profile.Name;
				}
				if(!string.IsNullOrEmpty(profile.Email)) {
					resultProfile.Email= profile.Email;
				}
				if(!string.IsNullOrEmpty(profile.PhoneNumber)) {
					resultProfile.Phone = profile.PhoneNumber;
				}
				if(!string.IsNullOrEmpty(profile.IM)) {
					resultProfile.Skype = profile.IM;
				}
				if(!string.IsNullOrEmpty(profile.BirthDay) && !profile.BirthDay.Contains("<")) {
					var birthDay = DateTime.Now;
					if (DateTime.TryParse(profile.BirthDay, out birthDay)) {
						resultProfile.BirthDate = birthDay.ToString("dd-MM-yyyy");
					}
				}
				if(!string.IsNullOrEmpty(profile.Address)) {
					resultProfile.Address = profile.Address;
				}
				if(!string.IsNullOrEmpty(profile.Work)) {
					resultProfile.JobTitle = profile.Work;
				}
				if(!string.IsNullOrEmpty(profile.AboutMe)) {
					resultProfile.AboutMe = profile.AboutMe;
				}
				var gender = profile.Gender;
				if (gender != 0) {
					resultProfile.GenderId = profile.Gender == BPMSoft.Social.Gender.Male
						? new Guid("EEAC42EE-65B6-DF11-831A-001D60E938C6")
						: new Guid("FC2483F8-65B6-DF11-831A-001D60E938C6");
					resultProfile.Gender = GetNameById(UserConnection, "Gender", resultProfile.GenderId);
				}
				if(!string.IsNullOrEmpty(profile.Country)) {
					resultProfile.Country = profile.Country;
					var id = GetIdByName(UserConnection, "Country", profile.Country);
					if (id != Guid.Empty) {
						resultProfile.CountryId = id;
					}
				}
				if(!string.IsNullOrEmpty(profile.HomeTown)) {
					resultProfile.City = profile.HomeTown;
					var id = GetIdByName(UserConnection, "City", profile.HomeTown);
					if (id != Guid.Empty) {
						resultProfile.CityId = id;
					}
				}
			}
			return ServiceStackTextHelper.Serialize(resultProfile);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "FindUsers", BodyStyle = WebMessageBodyStyle.Wrapped,
		RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string FindUsers (string searchCriteria, string socialNetworks) {
			if (string.IsNullOrEmpty(searchCriteria)) {
				return "";
			}
			SocialNetwork network = SocialNetwork.All;
			if (!string.IsNullOrEmpty(socialNetworks)) {
				network = (SocialNetwork)Enum.Parse(typeof(SocialNetwork), socialNetworks, true);
			}
			var commutator = new SocialCommutator(UserConnection, network);
			var exceptionNetworks = SocialNetwork.None;
			var accessTokenExceptionNetworks = SocialNetwork.None;
			commutator.ExceptionOccurred += delegate(ISocialNetwork n, Exception e) {
				if (e is AccessTokenExpired) {
					accessTokenExceptionNetworks = (SocialNetwork)accessTokenExceptionNetworks | (e as AccessTokenExpired).SocialNetwork;
				} else if (e is SocialNetworkException) {
					exceptionNetworks = (SocialNetwork)exceptionNetworks | (e as SocialNetworkException).SocialNetwork;
				} else {
					throw e;
				}
			};
			List<ISocialNetworkUser> bag = new List<ISocialNetworkUser>(commutator.FindUsers(searchCriteria));
			string users = ServiceStackTextHelper.Serialize(bag);
			return string.Format("{{\"users\":{0}, \"accessTokenExNetworks\":\"{1}\", \"exeptionNetworks\":\"{2}\"}}", users, accessTokenExceptionNetworks.ToString(), exceptionNetworks.ToString());
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetPublicProfileUrl", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetPublicProfileUrl(string socialMediaId, string socialNetworkName) {
			SocialCommutator commutator = null;  
			switch (socialNetworkName) {
				case "Facebook":
					commutator = new SocialCommutator(UserConnection, SocialNetwork.Facebook);
					break;
				case "Twitter":
					commutator = new SocialCommutator(UserConnection, SocialNetwork.Twitter);
					break;
				}
			if (commutator != null) {
				return commutator.GetPublicProfileUrl(socialMediaId);
			}
			return string.Empty;
		}

		private Guid GetIdByName(UserConnection userConnection, string tableName, string value) {
			Select select =
				new Select(userConnection)
					.Column("Id")
					.From(tableName)
					.Where("Name").IsEqual(Column.Parameter(value)) as Select;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if(reader.Read()) {
						int columnOrdinal = reader.GetOrdinal("Id");
						return reader.GetGuid(columnOrdinal);
					}
				}
			}
			return Guid.Empty;
		}
		
		private String GetNameById(UserConnection userConnection, string tableName, Guid value) {
			Select select =
				new Select(userConnection)
					.Column("Name")
					.From(tableName)
					.Where("Id").IsEqual(Column.Parameter(value)) as Select;
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if(reader.Read()) {
						int columnOrdinal = reader.GetOrdinal("Name");
						return reader.GetString(columnOrdinal);
					}
				}
			}
			return String.Empty;
		}
		
	}

	public class SocialProfile {
		public string SocialNetwork { get; set; }
		public string ProdileId { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string JobTitle { get; set; }
		public string Skype { get; set; }
		public string Email { get; set; }
		public string BirthDate { get; set; }
		public string Address { get; set; }
		public string AboutMe { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public Guid CityId { get; set; }
		public Guid CountryId { get; set; }
		public string Gender { get; set; }
		public Guid GenderId { get; set; }
	}
}
