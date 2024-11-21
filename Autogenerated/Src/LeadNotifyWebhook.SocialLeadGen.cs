namespace BPMSoft.Configuration.SocialLeadGen
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;

	#region Class: LeadNotifyWebhook

	/// <summary>
	/// Lead notify webhook
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class LeadNotifyWebhook
	{

		#region Class: SocialMetadata

		/// <summary>
		/// Social metadata
		/// </summary>
		[JsonObject(MemberSerialization.OptIn)]
		public class SocialMetadata
		{

			#region Class: FacebookMetadata

			/// <summary>
			/// Facebook metadata
			/// </summary>
			[JsonObject(MemberSerialization.OptIn)]
			public class FacebookMetadata
			{
				/// <summary>
				/// Gets or sets page id.
				/// </summary>
				[JsonProperty("pageId")]
				public string PageId { get; set; }
			}

			#endregion

			#region Class: LinkedInMetadata

			/// <summary>
			/// LinkedIn metadata
			/// </summary>
			[JsonObject(MemberSerialization.OptIn)]
			public class LinkedInMetadata
			{

				#region Class: LinkedInForm

				/// <summary>
				/// LinkedIn form
				/// </summary>
				[JsonObject(MemberSerialization.OptIn)]
				public class LinkedInForm
				{
					/// <summary>
					/// Gets or sets id.
					/// </summary>
					[JsonProperty("id")]
					public long Id { get; set; }

					/// <summary>
					/// Gets or sets name.
					/// </summary>
					[JsonProperty("name")]
					public string Name { get; set; }
				}

				#endregion

				#region Class: LinkedInAdAccount

				/// <summary>
				/// LinkedIn ad account
				/// </summary>
				[JsonObject(MemberSerialization.OptIn)]
				public class LinkedInAdAccount
				{
					/// <summary>
					/// Gets or sets id.
					/// </summary>
					[JsonProperty("id")]
					public long Id { get; set; }

					/// <summary>
					/// Gets or sets name.
					/// </summary>
					[JsonProperty("name")]
					public string Name { get; set; }
				}

				#endregion

				#region Class: LinkedInCampaignGroup

				/// <summary>
				/// LinkedIn campaign group
				/// </summary>
				[JsonObject(MemberSerialization.OptIn)]
				public class LinkedInCampaignGroup
				{
					/// <summary>
					/// Gets or sets id.
					/// </summary>
					[JsonProperty("id")]
					public long Id { get; set; }

					/// <summary>
					/// Gets or sets name.
					/// </summary>
					[JsonProperty("name")]
					public string Name { get; set; }
				}

				#endregion

				#region Class: LinkedInCampaign

				/// <summary>
				/// LinkedIn campaign
				/// </summary>
				[JsonObject(MemberSerialization.OptIn)]
				public class LinkedInCampaign
				{
					/// <summary>
					/// Gets or sets id.
					/// </summary>
					[JsonProperty("id")]
					public long Id { get; set; }

					/// <summary>
					/// Gets or sets name.
					/// </summary>
					[JsonProperty("name")]
					public string Name { get; set; }
				}

				#endregion

				#region Class: LinkedInAdCreativeSubject

				/// <summary>
				/// LinkedIn ad creative subject
				/// </summary>
				[JsonObject(MemberSerialization.OptIn)]
				public class LinkedInAdCreativeSubject
				{
					/// <summary>
					/// Gets or sets id.
					/// </summary>
					[JsonProperty("id")]
					public long Id { get; set; }

					/// <summary>
					/// Gets or sets name.
					/// </summary>
					[JsonProperty("name")]
					public string Name { get; set; }
				}

				#endregion

				/// <summary>
				/// Gets or sets form.
				/// </summary>
				[JsonProperty("form")]
				public LinkedInForm Form { get; set; }

				/// <summary>
				/// Gets or sets ad account.
				/// </summary>
				[JsonProperty("adAccount")]
				public LinkedInAdAccount AdAccount { get; set; }

				/// <summary>
				/// Gets or sets campaign group.
				/// </summary>
				[JsonProperty("campaignGroup")]
				public LinkedInCampaignGroup CampaignGroup { get; set; }

				/// <summary>
				/// Gets or sets campaign.
				/// </summary>
				[JsonProperty("campaign")]
				public LinkedInCampaign Campaign { get; set; }

				/// <summary>
				/// Gets or sets ad creative.
				/// </summary>
				[JsonProperty("adCreative")]
				public LinkedInAdCreativeSubject AdCreative { get; set; }
			}

			#endregion

			/// <summary>
			/// Gets or sets facebook metadata.
			/// </summary>
			[JsonProperty("facebook")]
			public FacebookMetadata Facebook { get; set; }

			/// <summary>
			/// Gets or sets linkedin metadata.
			/// </summary>
			[JsonProperty("linkedIn")]
			public LinkedInMetadata LinkedIn { get; set; }
		}

		#endregion

		#region Class: LeadField

		/// <summary>
		/// Lead field
		/// </summary>
		[JsonObject(MemberSerialization.OptIn)]
		public class LeadField
		{
			/// <summary>
			/// Gets or sets entity column name.
			/// </summary>
			[JsonProperty("entityColumnName")]
			public string EntityColumnName { get; set; }

			/// <summary>
			/// Gets or sets social question name.
			/// </summary>
			[JsonProperty("socialQuestionName")]
			public string SocialQuestionName { get; set; }

			/// <summary>
			/// Gets or sets value.
			/// </summary>
			[JsonProperty("value")]
			public string Value { get; set; }

			/// <summary>
			/// Gets or sets type.
			/// </summary>
			[JsonProperty("type")]
			public string Type { get; set; }
		}

		#endregion

		/// <summary>
		/// Gets or sets integration id.
		/// </summary>
		[JsonProperty("integrationId")]
		public Guid IntegrationId { get; set; }

		/// <summary>
		/// Gets or sets social lead id.
		/// </summary>
		[JsonProperty("socialLeadId")]
		public string SocialLeadId { get; set; }

		/// <summary>
		/// Gets or sets submitted at.
		/// </summary>
		[JsonProperty("submittedAt")]
		[JsonConverter(typeof(UTCDateTimeJsonConverter))]
		public DateTime SubmittedAt { get; set; }

		/// <summary>
		/// Gets or sets social metadata.
		/// </summary>
		[JsonProperty("metadata")]
		public SocialMetadata Metadata { get; set; }

		/// <summary>
		/// Gets or sets entity schema name.
		/// </summary>
		[JsonProperty("entitySchemaName")]
		public string EntitySchemaName { get; set; }

		/// <summary>
		/// Gets or sets lead fields.
		/// </summary>
		[JsonProperty("leadFields")]
		public IEnumerable<LeadField> LeadFields { get; set; }

	}

	#endregion

}
