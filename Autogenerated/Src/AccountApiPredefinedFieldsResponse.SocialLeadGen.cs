namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	#region Class: AccountApiPredefinedFieldsResponse

	/// <summary>
	/// DTO that describre API response from account service.
	/// </summary>
	public class AccountApiPredefinedFieldsResponse : SocialLeadGenRestProviderResponse
	{

		#region Class: PredefinedQuestion

		public class PredefinedQuestion
		{

			#region Properties: Public

			[JsonProperty("predefinedField")]
			public string PredefinedField { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		[JsonProperty("predefinedQuestions")]
		public List<PredefinedQuestion> PredefinedQuestions { get; set; }

		#endregion

	}

	#endregion

}
