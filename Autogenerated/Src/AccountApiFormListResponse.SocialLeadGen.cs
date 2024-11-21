namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	#region Class: AccountApiFormListResponse

	/// <summary>
	/// DTO that describre API response from account service.
	/// </summary>
	public class AccountApiFormListResponse : SocialLeadGenRestProviderResponse
	{

		#region Class: Form

		public class Form
		{

			#region Properties: Public

			[JsonProperty("id")]
			public long Id { get; set; }

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("linkedInCreatedTime")]
			public string LinkedInCreatedTime { get; set; }


			[JsonProperty("linkedInStatus")]
			public string LinkedInStatus { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		[JsonProperty("forms")]
		public List<Form> Forms { get; set; }

		#endregion

	}

	#endregion

}

