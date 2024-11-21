namespace BPMSoft.Configuration.Social
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using BPMSoft.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;

	#region Class: SocialNetworkService

	public class SocialNetworkService<T> : BaseService where T : BaseServerConnector
	{

		#region Properties: Protected

		private T _serverConnector;
		protected T ServerConnector {
			get {
				return _serverConnector ?? (_serverConnector = GetServerConnector<T>());
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual T GetServerConnector<T>() where T : class {
			return ClassFactory.Get<T>();
		}

		#endregion

		#region Methods: Public

		public ConfigurationServiceResponse SetAccessToken(SocialNetworkServiceRequest request) {
			try {
				bool success = ServerConnector.SetAccessToken(request);
				return new ConfigurationServiceResponse() {
					Success = success
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<ConfigurationServiceResponse>(e);
			}
		}

		public AccessTokenResponse GetAccessToken(SocialNetworkServiceRequest request) {
			try {
				string accessToken = ServerConnector.GetAccessToken(request);
				return new AccessTokenResponse() {
					AccessToken = accessToken
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<AccessTokenResponse>(e);
			}
		}

		public AccessTokenResponse FindAccessToken(SocialNetworkServiceRequest request) {
			try {
				string accessToken = ServerConnector.FindAccessToken(request);
				return new AccessTokenResponse() {
					AccessToken = accessToken
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<AccessTokenResponse>(e);
			}
		}

		public ConfigurationServiceResponse CreateSocialAccount(SocialNetworkServiceRequest request) {
			try {
				bool saveResult = ServerConnector.CreateSocialAccount(request);
				return new ConfigurationServiceResponse() {
					Success = saveResult
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<ConfigurationServiceResponse>(e);
			}
		}

		public SocialAccountInfoResponse GetSocialAccountInfo(SocialNetworkServiceRequest request) {
			try {
				SocialAccountInfo socialAccountInfo = ServerConnector.GetSocialAccountInfo(request);
				return new SocialAccountInfoResponse() {
					SocialAccountInfo = socialAccountInfo
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<SocialAccountInfoResponse>(e);
			}
		}

		public SocialAccountInfoResponse FindSocialAccountInfo(SocialNetworkServiceRequest request) {
			try {
				SocialAccountInfo socialAccountInfo = ServerConnector.FindSocialAccountInfo(request);
				return new SocialAccountInfoResponse() {
					SocialAccountInfo = socialAccountInfo
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<SocialAccountInfoResponse>(e);
			}
		}

		public ConfigurationServiceResponse DeleteSocialAccount(SocialNetworkServiceRequest request) {
			try {
				bool deleteResult = ServerConnector.DeleteSocialAccount(request);
				return new ConfigurationServiceResponse() {
					Success = deleteResult
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<ConfigurationServiceResponse>(e);
			}
		}

		public ConfigurationServiceResponse CheckSocialAccount(SocialNetworkServiceRequest request) {
			try {
				ServerConnector.CheckSocialAccount(request);
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return ServerConnector.HandleException<ConfigurationServiceResponse>(e);
			}
		}

		public ConsumerInfoResponse GetConsumerInfo(SocialNetworkServiceRequest request) {
			try {
				ConsumerInfo consumerInfo = ServerConnector.GetConsumerInfo(request);
				return new ConsumerInfoResponse() {
					ConsumerInfo = consumerInfo
				};
			} catch (Exception e) {
				return ServerConnector.HandleException<ConsumerInfoResponse>(e);
			}
		}

		#endregion

	}

	#endregion

	#region Class: SocialNetworkServiceRequest

	[DataContract]
	public class SocialNetworkServiceRequest
	{

		#region Properties: Public

		[DataMember(Name = "accessToken")]
		public string AccessToken {
			get;
			set;
		}

		[DataMember(Name = "type")]
		public Guid Type {
			get;
			set;
		}

		[DataMember(Name = "user")]
		public Guid User {
			get;
			set;
		}

		[DataMember(Name = "consumerKey")]
		public string ConsumerKey {
			get;
			set;
		}

		[DataMember(Name = "consumerSecret")]
		public string ConsumerSecret {
			get;
			set;
		}

		[DataMember(Name = "consumerVersion")]
		public string ConsumerVersion {
			get;
			set;
		}

		[DataMember(Name = "socialId")]
		public string SocialId {
			get;
			set;
		}

		[DataMember(Name = "socialIds")]
		public string[] SocialIds {
			get;
			set;
		}

		[DataMember(Name = "command")]
		public BaseCommand Command {
			get;
			set;
		}

		[DataMember(Name = "commands")]
		public IEnumerable<BaseCommand> Commands {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SocialAccountInfoResponse

	[DataContract]
	public class SocialAccountInfoResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "socialAccountInfo")]
		public SocialAccountInfo SocialAccountInfo;

		#endregion

	}

	#endregion

	#region Class: AccessTokenResponse

	[DataContract]
	public class AccessTokenResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "accessToken")]
		public string AccessToken;

		#endregion

	}

	#endregion

	#region Class: ConsumerInfoResponse

	[DataContract]
	public class ConsumerInfoResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "consumerInfo")]
		public ConsumerInfo ConsumerInfo;

		#endregion

	}

	#endregion

}
