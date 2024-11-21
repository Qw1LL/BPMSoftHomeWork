namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;

	/// <summary>
	/// Email mining constants.
	/// </summary>
	public static class EmailMiningConsts
	{

		/// <summary>
		/// Text parsing service URL system setting code.
		/// </summary>
		public const string TextParsingServiceSysSetting = "TextParsingService";

	}

	/// <summary>
	/// The type of the extracted entity identification in bpmcrm.
	/// </summary>
	public class IdentificationType : StringEnum
	{
		/// <summary>
		/// Identified manually. Used when identification specified manually by the user.
		/// </summary>
		public static readonly IdentificationType Manual = new IdentificationType("Manual");
		/// <summary>
		/// Identified due to the custom logic.
		/// </summary>
		public static readonly IdentificationType Custom = new IdentificationType("Custom");

		protected IdentificationType(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// The type of the extracted contact identification.
	/// </summary>
	/// <seealso cref="IdentificationType" />
	public class ContactIdentificationType : IdentificationType
	{
		/// <summary>
		/// By the full name.
		/// </summary>
		public static readonly ContactIdentificationType Name = new ContactIdentificationType("Name");
		/// <summary>
		/// By the first and the last name.
		/// </summary>
		public static readonly ContactIdentificationType FirstLastName =
			new ContactIdentificationType("FirstLastName");
		/// <summary>
		/// By the email.
		/// </summary>
		public static readonly ContactIdentificationType Email = new ContactIdentificationType("Email");
		/// <summary>
		/// By the sender's email.
		/// </summary>
		public static readonly ContactIdentificationType SenderEmail = new ContactIdentificationType("SenderEmail");
		/// <summary>
		/// By the phone number.
		/// </summary>
		public static readonly ContactIdentificationType Phone = new ContactIdentificationType("Phone");

		protected ContactIdentificationType(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// The type of the extracted account identification.
	/// </summary>
	/// <seealso cref="IdentificationType" />
	public class AccountIdentificationType : IdentificationType
	{

		/// <summary>
		/// By the name.
		/// </summary>
		public static readonly AccountIdentificationType Name = new AccountIdentificationType("Name");
		/// <summary>
		/// By the domain of the web-address.
		/// </summary>
		public static readonly AccountIdentificationType WebDomain = new AccountIdentificationType("WebDomain");
		/// <summary>
		/// By the domain of the email.
		/// </summary>
		public static readonly AccountIdentificationType EmailDomain = new AccountIdentificationType("EmailDomain");

		protected AccountIdentificationType(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// Statuses of the processed data.
	/// </summary>
	public class ProcessedDataStatus : StringEnum
	{

		/// <summary>
		/// The data was rejected by the user.
		/// </summary>
		public static readonly ProcessedDataStatus Rejected = new ProcessedDataStatus("Rejected");
		/// <summary>
		/// The data was applied by the user.
		/// </summary>
		public static readonly ProcessedDataStatus Applied = new ProcessedDataStatus("Applied");

		protected ProcessedDataStatus(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// Types of enriched communication entities.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EmailMining.StringEnum" />
	public class EnrchCommunicationType : StringEnum
	{

		/// <summary>
		/// Email.
		/// </summary>
		public static readonly EnrchCommunicationType Email = new EnrchCommunicationType("email");

		/// <summary>
		/// Web site.
		/// </summary>
		public static readonly EnrchCommunicationType Web = new EnrchCommunicationType("web");

		/// <summary>
		/// Mobile phone.
		/// </summary>
		public static readonly EnrchCommunicationType Mobile = new EnrchCommunicationType("mobile");

		protected EnrchCommunicationType(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// Values enum for Type column of EnrcTextEntity.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EmailMining.StringEnum" />
	public class EnrchTextEntityType : StringEnum
	{

		/// <summary>
		/// Organization.
		/// </summary>
		public static readonly EnrchTextEntityType Organization = new EnrchTextEntityType("OrganizationEntity");

		/// <summary>
		/// Contact.
		/// </summary>
		public static readonly EnrchTextEntityType Contact = new EnrchTextEntityType("ContactEntity");

		/// <summary>
		/// Communication (such as phone, web, social network, etc.).
		/// </summary>
		public static readonly EnrchTextEntityType Communication = new EnrchTextEntityType("CommunicationEntity");

		/// <summary>
		/// Address.
		/// </summary>
		public static readonly EnrchTextEntityType Address = new EnrchTextEntityType("AddressEntity");

		/// <summary>
		/// Job.
		/// </summary>
		public static readonly EnrchTextEntityType Job = new EnrchTextEntityType("JobEntity");

		protected EnrchTextEntityType(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// Values enum for EnrichStatus column of Activity.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EmailMining.StringEnum" />
	public class EnrichStatus : StringEnum
	{

		/// <summary>
		/// Email not processed yet.
		/// </summary>
		public static readonly EnrichStatus Inactive = new EnrichStatus("");

		/// <summary>
		/// Enrichment process succesfully completed.
		/// </summary>
		public static readonly EnrichStatus Done = new EnrichStatus("Done");

		/// <summary>
		/// Enrichment service return error for email.
		/// </summary>
		public static readonly EnrichStatus Error = new EnrichStatus("Error");

		protected EnrichStatus(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// Values enum for Status column of EnrichEmailData.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EmailMining.StringEnum" />
	public class EnrichEmailDataStatus : StringEnum
	{

		#region Filds: Private

		private static readonly Dictionary<string, EnrichEmailDataStatus> _valueMap
			= new Dictionary<string, EnrichEmailDataStatus>();

		#endregion

		#region Fields: Public

		/// <summary>
		/// Email data mined, but not processed by user yet.
		/// </summary>
		public static readonly EnrichEmailDataStatus Mined = new EnrichEmailDataStatus("Mined");

		/// <summary>
		/// Email data processed.
		/// </summary>
		public static readonly EnrichEmailDataStatus Enriched = new EnrichEmailDataStatus("Enriched");

		#endregion

		#region Constructors: Protected

		protected EnrichEmailDataStatus(string value)
			: base(value) {
			_valueMap.Add(value, this);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Performs an implicit conversion from <see cref="System.String"/> to <see cref="EnrichEmailDataStatus"/>.
		/// </summary>
		/// <param name="str">The string value. For the empty string will be return default "Mined" value</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator EnrichEmailDataStatus(string str) {
			EnrichEmailDataStatus result;
			if (str.IsNullOrEmpty()) {
				return Mined;
			}
			if (_valueMap.TryGetValue(str, out result)) {
				return result;
			}
			throw new InvalidCastException(string.Format("Cannot cast '{0}' to EnrichEmailDataStatus", str));
		}

		#endregion

	}

	/// <summary>
	/// Statuses of the extracted entity duplication. Indicates if the extracted data found in existing business entity.
	/// </summary>
	public class EnrchDuplicateStatus : StringEnum
	{

		/// <summary>
		/// Not exists in the business entity (new data).
		/// </summary>
		public static readonly EnrchDuplicateStatus NotDuplicated = new EnrchDuplicateStatus("");

		/// <summary>
		/// Exists in the business entity.
		/// </summary>
		public static readonly EnrchDuplicateStatus ExistsInEntity = new EnrchDuplicateStatus("ExistsInEntity");

		protected EnrchDuplicateStatus(string value)
			: base(value) {
		}
	}

	/// <summary>
	/// The source of the enriched text entity.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EmailMining.StringEnum" />
	public class EnrchTextEntitySource : StringEnum
	{

		/// <summary>
		/// Email mining text service (default).
		/// </summary>
		public static readonly EnrchTextEntitySource ServiceEmailParser = new EnrchTextEntitySource("");

		/// <summary>
		/// Existing Activity business entity.
		/// </summary>
		public static readonly EnrchTextEntitySource AppDbActivity = new EnrchTextEntitySource("AppDb-Activity");

		protected EnrchTextEntitySource(string value)
			: base(value) {
		}
	}
}

