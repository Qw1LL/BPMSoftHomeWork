 namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	#region Class: AccountApiFormFieldsResponse

	/// <summary>
	/// DTO that describre API response from account service.
	/// </summary>
	public class AccountApiFormFieldsResponse : SocialLeadGenRestProviderResponse
	{

		#region Class: HiddenField

		public class HiddenField
		{

			#region Properties: Public

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("answer")]
			public string Answer { get; set; }

			#endregion

		}

		#endregion

		#region Class: Consent

		public class Consent
		{

			#region Properties: Public

			[JsonProperty("id")]
			public int Id { get; set; }

			[JsonProperty("consentText")]
			public string ConsentText { get; set; }

			#endregion

		}

		#endregion

		#region Class: CustomTextQuestion

		public class CustomTextQuestion
		{

			#region Properties: Public

			[JsonProperty("id")]
			public string Id { get; set; }

			[JsonProperty("questionText")]
			public string QuestionText { get; set; }

			#endregion

		}

		#endregion

		#region Class: CustomMultipleChoiceQuestion

		public class CustomMultipleChoiceQuestion
		{

			#region Properties: Public

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("questionText")]
			public string QuestionText { get; set; }

			#endregion

		}

		#endregion

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

		[JsonProperty("hiddenFields")]
		public List<HiddenField> HiddenFields { get; set; }

		[JsonProperty("consents")]
		public List<Consent> Consents { get; set; }

		[JsonProperty("customTextQuestions")]
		public List<CustomTextQuestion> CustomTextQuestions { get; set; }

		[JsonProperty("customMultipleChoiceQuestions")]
		public List<CustomMultipleChoiceQuestion> CustomMultipleChoiceQuestions { get; set; }

		[JsonProperty("predefinedQuestions")]
		public List<PredefinedQuestion> PredefinedQuestions { get; set; }

		#endregion

	}

	#endregion

}
