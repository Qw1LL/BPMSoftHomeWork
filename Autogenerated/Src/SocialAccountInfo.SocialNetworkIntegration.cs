namespace BPMSoft.Configuration.Social
{
	using System;
	using System.Runtime.Serialization;

	#region Class: SocialAccountInfo

	[DataContract]
	public class SocialAccountInfo
	{

		#region Constructors: Public

		public SocialAccountInfo(SocialAccount socialAccount) {
			Login = socialAccount.Login;
			Public = socialAccount.Public;
			SocialId = socialAccount.SocialId;
			TypeId = socialAccount.TypeId;
			UserId = socialAccount.UserId;
		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "userId")]
		public Guid UserId {
			get;
			set;
		}

		[DataMember(Name = "login")]
		public string Login {
			get;
			set;
		}

		[DataMember(Name = "typeId")]
		public Guid TypeId {
			get;
			set;
		}

		[DataMember(Name = "socialId")]
		public string SocialId {
			get;
			set;
		}

		[DataMember(Name = "isPublic")]
		public bool Public {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
