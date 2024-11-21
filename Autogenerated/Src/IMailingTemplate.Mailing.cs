namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Configuration.Mailing;
	using System.Collections.Generic;

	#region Interface: IMailingTemplate

	/// <summary>
	/// Provides methods to work with mailing template.
	/// </summary>
	public interface IMailingTemplate
	{
		#region Properties: Public

		/// <summary>
		/// Name of the template.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Template subject.
		/// </summary>
		string TemplateSubject { get; }

		/// <summary>
		/// Content of the template.
		/// </summary>
		string Content { get; }

		/// <summary>
		/// List of inline images.
		/// </summary>
		IEnumerable<Base64Image> InlineImages { get; }

		/// <summary>
		/// List of macros included in template.
		/// </summary>
		List<MacrosInfo> MacrosCollection { get; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializes properties of current instance.
		/// </summary>
		void Init();

		#endregion

	}

	#endregion

	#region Interface: IMailingTemplateReplica

	/// <summary>
	/// Provides methods to work with mailing template replica.
	/// </summary>
	public interface IMailingTemplateReplica : IMailingTemplate
	{

		/// <summary>
		/// Template replica checksum.
		/// </summary>
		string Checksum { get; }

		/// <summary>
		/// Gets or sets the replica identifier.
		/// </summary>
		Guid ReplicaId { get; set; }

	}
	
	/// <summary>
	/// Provides methods to work with mailing template replica.
	/// </summary>
	public interface IMailingTemplateWithHeaders : IMailingTemplateReplica
	{
		/// <value>
		/// The name of the sender.
		/// </value>
		string SenderName { get; }

		/// <value>
		/// The sender email.
		/// </value>
		string SenderEmail { get; }
	}

	#endregion

}

