namespace BPMSoft.Configuration.EnrichmentDto
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;

	#region Class: ShortCompanyInfo

	/// <summary>
	/// Represents company name, website and logo url.
	/// </summary>
	public class ShortCompanyInfo
	{

		#region Properties: Public

		/// <summary>
		/// Company name.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Company website url.
		/// </summary>
		[DataMember(Name = "domain")]
		public string Domain {
			get;
			set;
		}

		/// <summary>
		/// Company logo url.
		/// </summary>
		[DataMember(Name = "logo")]
		public string Logo {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: BaseCloudResponse

	/// <summary>
	/// Represents base cloud response.
	/// </summary>
	[DataContract]
	public class BaseCloudResponse
	{

		/// <summary>
		/// External service Http response status.
		/// </summary>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		/// <summary>
		/// External service Http response code.
		/// </summary>
		[DataMember(Name = "code")]
		public int Code { get; set; }

		/// <summary>
		/// Error message.
		/// </summary>
		[DataMember(Name = "message")]
		public string Message { get; set; }

	}

	#endregion

	#region Class: CloudRestResponse

	/// <summary>
	/// Represents response of company autocomplete service.
	/// </summary>
	[DataContract]
	public class CloudRestResponse : BaseCloudResponse
	{

		#region Properties: Public

		/// <summary>
		/// Collection of companies info.
		/// </summary>
		[DataMember(Name = "companiesInfo")]
		public List<ShortCompanyInfo> CompaniesInfo {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SearchInfoRequest

	/// <summary>
	/// Represents search info request.
	/// </summary>
	[DataContract]
	public class SearchInfoRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		[DataMember(Name = "key")]
		public string ApiKey {
			get;
			set;
		}

		/// <summary>
		/// Search subject name.
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Array of subject web site urls.
		/// </summary>
		[DataMember(Name = "urls", IsRequired = true)]
		public List<string> Urls {
			get;
			set;
		}

		/// <summary>
		/// Array of subject emails.
		/// </summary>
		[DataMember(Name = "emails", IsRequired = true)]
		public List<string> Emails {
			get;
			set;
		}

		/// <summary>
		/// Restrictions search config.
		/// </summary>
		[DataMember(Name = "config", IsRequired = false)]
		public SearchInfoConfiguration Config {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: CommunicationInfo

	/// <summary>
	/// Represents communication information such as phone number, email, web.
	/// </summary>
	[DataContract]
	[DebuggerDisplay("Value = {Value}; Type = {Type}")]
	public class CommunicationInfo : IEquatable<CommunicationInfo>
	{

		#region Properties: Public

		/// <summary>
		/// Communication info category.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type {
			get;
			set;
		}

		/// <summary>
		/// String representation of communication info (phone number, email, address).
		/// </summary>
		[DataMember(Name = "value")]
		public string Value {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		public bool Equals(CommunicationInfo other) {
			return Type.Equals(other.Type) && Value.Equals(other.Value);
		}

		#endregion

	}

	#endregion

	#region Class: SearchInfoConfiguration

	/// <summary>
	/// Represents restrictions configuration of search info requests.
	/// </summary>
	[DataContract]
	public class SearchInfoConfiguration
	{

		#region Properties: Public

		/// <summary>
		/// Restricts social links search.
		/// </summary>
		[DataMember(Name = "maxSocialLinksCount")]
		public int MaxSocialLinksCount {
			get;
			set;
		}

		/// <summary>
		/// Restricts phone number search.
		/// </summary>
		[DataMember(Name = "maxPhoneNumberCount")]
		public int MaxPhoneNumberCount {
			get;
			set;
		}

		/// <summary>
		/// Restricts emails search.
		/// </summary>
		[DataMember(Name = "maxEmailsCount")]
		public int MaxEmailsCount {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SearchInfoResponse

	/// <summary>
	/// Represents response to search info webservice.
	/// </summary>
	[DataContract]
	public class SearchInfoResponse : BaseCloudResponse
	{

		#region Properties: Public

		/// <summary>
		/// Structured communication information found by search request.
		/// </summary>
		[DataMember(Name = "communicationInfo")]
		public IList<CommunicationInfo> CommunicationInfo {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

