namespace BPMSoft.Configuration.EmailMining
{
	using System.Runtime.Serialization;
	using BPMSoft.Enrichment.Interfaces;
	using Newtonsoft.Json;

	#region Class: GetEmailEntitiesRequest

	/// <summary>
	/// Represents service request for scraping email text into structured data.
	/// TODO Replace with <c>Enrichment.Interfaces.Requests.GetEmailEntitiesRequest</c>.
	/// </summary>
	[DataContract]
	public class GetEmailEntitiesRequest
	{

		#region Properties: Public

		/// <summary>
		/// Email body to parse.
		/// </summary>
		[DataMember(Name = "emailBody", IsRequired = true)]
		public string EmailBody {
			get;
			set;
		}

		/// <summary>
		/// Email body format: plane, html.
		/// </summary>
		[DataMember(Name = "msgType", IsRequired = true)]
		public string MsgType {
			get;
			set;
		}

		/// <summary>
		/// Optional sender email address.
		/// </summary>
		[DataMember(Name = "senderEmail", IsRequired = false)]
		public string SenderEmail {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		[DataMember(Name = "key", IsRequired = true)]
		public string ApiKey {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: GetEmailEntitiesResponse

	/// <summary>
	/// Represents response to scraping email webservice.
	/// TODO Replace with <c>Enrichment.Interfaces.Responses.GetEmailEntitiesResponse</c>.
	/// </summary>
	[DataContract]
	public class GetEmailEntitiesResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the entities that mined from the email's body text.
		/// </summary>
		/// <value>
		/// The text entities.
		/// </value>
		[DataMember(Name = "textEntities")]
		[JsonProperty(PropertyName = "textEntities")]
		public TextEntities TextEntities {
			get;
			set;
		}

		/// <summary>
		/// Verifies if sender email domain belongs to public ones.
		/// <para>This property is equal to default value <c>false</c>,
		/// if sender email was not specified in request.</para>
		/// </summary>
		[DataMember(Name = "isSenderEmailDomainFree", IsRequired = false, EmitDefaultValue = false)]
		[JsonProperty(PropertyName = "isSenderEmailDomainFree", Required = Required.Default)]
		public bool IsSenderEmailDomainFree {
			get;
			set;
		}

		/// <summary>
		/// Get or sets error message.
		/// </summary>
		[DataMember(Name = "message", IsRequired = false)]
		[JsonProperty(PropertyName = "message", Required = Required.Default)]
		public string ErrorMessage {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets response status code.
		/// </summary>
		[DataMember(Name = "code", IsRequired = false)]
		[JsonProperty(PropertyName = "code", Required = Required.Default)]
		public int Code {
			get;
			set;
		}

		/// <summary>
		/// Returns <c>true</c> if the <see cref="TextEntities"/> property is not <c>null</c>, <c>false</c> otherwise.
		/// </summary>
		public bool IsFailure {
			get {
				return TextEntities == null;
			}
		}

		/// <summary>
		/// Returns <c>true</c> if the <see cref="TextEntities"/> property is <c>null</c>, <c>false</c> otherwise.
		/// </summary>
		public bool IsSuccess {
			get {
				return TextEntities != null;
			}
		}

		#endregion

	}

	#endregion

}

