namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: Integration

	/// <summary>
	/// Class for describing integration.
	/// </summary>

	[DataContract]
	public class Integration
	{

		#region Class: MetadataSettings

		/// <summary>
		/// Class for describing integration.
		/// </summary>
		[DataContract]
		public class MetadataSettings
		{
			[DataContract]
			public class SettingsSocialBase
			{
				[DataContract]
				public class MappingData
				{
					[DataContract]
					public class MappingColumn
					{
						[DataContract]
						public class ColumnValue
						{
							[DataContract]
							public class MacrosValue
							{
								[DataMember(Name = "selector")]
								public string Selector { get; set; }
							}

							[DataContract]
							public class FormValue
							{
								[DataContract]
								public class PredefinedQuestionValue
								{
									[DataMember(Name = "predefinedField")]
									public string PredefinedField { get; set; }

									[DataMember(Name = "question")]
									public string Question { get; set; }
								}

								[DataContract]
								public class CustomQuestionValue
								{
									[DataMember(Name = "name")]
									public string Name { get; set; }

									[DataMember(Name = "question")]
									public string Question { get; set; }
								}

								[DataContract]
								public class ConsentValue
								{
									[DataMember(Name = "id")]
									public long Id { get; set; }

									[DataMember(Name = "content")]
									public string Content { get; set; }
								}

								[DataContract]
								public class HiddenFieldValue
								{
									[DataMember(Name = "name")]
									public string Name { get; set; }
								}

								[DataMember(Name = "predefinedQuestion")]
								public PredefinedQuestionValue PredefinedQuestion { get; set; }

								[DataMember(Name = "customQuestion")]
								public CustomQuestionValue CustomQuestion { get; set; }

								[DataMember(Name = "consent")]
								public ConsentValue Consent { get; set; }

								[DataMember(Name = "hiddenField")]
								public HiddenFieldValue HiddenField { get; set; }
							}

							[DataMember(Name = "const")]
							public string Const { get; set; }

							[DataMember(Name = "form")]
							public FormValue Form { get; set; }

							[DataMember(Name = "macros")]
							public MacrosValue Macros { get; set; }
						}

						[DataMember(Name = "name")]
						public string Name { get; set; }

						[DataMember(Name = "value")]
						public ColumnValue Value { get; set; }
					}

					[DataMember(Name = "entitySchemaName")]
					public string EntitySchemaName { get; set; }

					[DataMember(Name = "columns")]
					public List<MappingColumn> Columns { get; set; }
				}

				[DataContract]
				public class SocialForm
				{
					[DataMember(Name = "id")]
					public long Id { get; set; }

					[DataMember(Name = "name")]
					public string Name { get; set; }

					[DataMember(Name = "linkedInCreatedTime")]
					public string LinkedInCreatedTime { get; set; }

					[DataMember(Name = "linkedInStatus")]
					public string LinkedInStatus { get; set; }

					[DataMember(Name = "isActive")]
					public bool IsActive { get; set; }

					[DataMember(Name = "useCustomMapping")]
					public bool UseCustomMapping { get; set; }

					[DataMember(Name = "mapping")]
					public MappingData Mapping { get; set; }
				}

				[DataMember(Name = "forms")]
				public List<SocialForm> Forms { get; set; }
			}

			#region Class: FacebookSettings

			/// <summary>
			/// Class for describing integration.
			/// </summary>
			[DataContract]
			public class FacebookSettings : SettingsSocialBase
			{

				#region Properties: Public

				[DataMember(Name = "facebookPageId")]
				public string FacebookPageId { get; set; }

				#endregion

			}

			#endregion

			#region Class: LinkedInSettings

			/// <summary>
			/// Class for describing integration.
			/// </summary>
			[DataContract]
			public class LinkedInSettings : SettingsSocialBase
			{

				#region Properties: Public

				[DataMember(Name = "linkedInAdAccountId")]
				public string LinkedInAdAccountId { get; set; }

				[DataMember(Name = "mapping")]
				public MappingData Mapping { get; set; }

				#endregion

			}

			#endregion

			#region Properties: Public

			[DataMember(Name = "facebook")]
			public FacebookSettings Facebook { get; set; }

			[DataMember(Name = "linkedIn")]
			public LinkedInSettings LinkedIn { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration unique identificator.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets integration name.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets flag indicate is integration active.
		/// </summary>
		[DataMember(Name = "isActive")]
		public bool IsActive { get; set; }

		/// <summary>
		/// Gets or sets integration type.
		/// </summary>
		[DataMember(Name = "type")]
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets integration metadata.
		/// </summary>
		[DataMember(Name = "metadata")]
		public MetadataSettings Metadata { get; set; }

		#endregion

	}

	#endregion


}
