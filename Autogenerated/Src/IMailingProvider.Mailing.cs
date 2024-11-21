namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using BPMSoft.Configuration.CES;

	#region Interface: IMailingProvider

	/// <summary>
	/// Provides methods and properties of the mailing provider.
	/// </summary>
	public interface IMailingProvider
	{

		#region Properties: Public

		/// <summary>
		/// Instance of current user connection.
		/// </summary>
		UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Breaks process of sending.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <returns>Returns status of bulk email.</returns>
		MailingResponse BreakMailing(Guid bulkEmailId);

		/// <summary>
		/// Starts sending of the bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="isDelayedStart">Deelay sending.</param>
		/// <returns>Returns status of bulk email.</returns>
		MailingResponse SendMessage(Guid bulkEmailId, bool isDelayedStart = false, string applicationUrl = "");

		/// <summary>
		/// Starts sending of the message.
		/// </summary>
		/// <param name="messageInfo">Object that holds information about message.</param>
		/// <returns>Status of message.</returns>
		MailingResponse SendMessage(IMessageInfo messageInfo);

		/// <summary>
		/// Sends test email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="contactId">Unique identifier of the contact from audience.</param>
		/// <param name="emailRecipient">Email address of the recipient.</param>
		/// <returns>Returns result of successful sending.</returns>
		bool SendTestMessage(Guid bulkEmailId, Guid contactId, string emailRecipient);

		/// <summary>
		/// Validates message.
		/// </summary>
		/// <param name="messageId">Unique identifier of the message.</param>
		/// <returns>Validation result.</returns>
		ConfigurationServiceResponse ValidateMessage(Guid messageId);

		/// <summary>
		/// Validates messages.
		/// </summary>
		/// <param name="messageIds">Unique identifiers of the message.</param>
		/// <returns>Validation result.</returns>
		ConfigurationServiceResponse ValidateMessages(Guid[] messageIds);

		/// <summary>
		/// Validates bulk emails if any of items in Draft status.
		/// </summary>
		/// <param name="bulkEmailIds">Unique identifiers of the message.</param>
		/// <returns>Validation result.</returns>
		ConfigurationServiceResponse ValidateDraftStatus(Guid[] bulkEmailIds);

		/// <summary>
		/// Ping provider's service.
		/// </summary>
		bool PingProvider();

		#endregion

	}

	#endregion
	
	#region Interface: IMailingCesApiProvider

	/// <summary>
	/// Provides interface to operate with ICESApi instance.
	/// </summary>
	public interface IMailingCesApiProvider: IMailingProvider
	{

		#region Properties: Public
		
		/// <summary>
		/// Instance of <see cref="BulkEmailEventLogger"/>, provides logging to BulkEmailEventLog table in DB.
		/// </summary>
		BulkEmailEventLogger BulkEmailEventLogger { get; }

		/// <summary>
		/// Gets or sets instance of <see cref="ICESApi"/>
		/// </summary>
		ICESApi ServiceApi { get;}
		
		#endregion

	}

	#endregion

	#region Interface: ISessionedMailingProvider

	/// <summary>
	/// Extends the IMailingProvider with the overloaded method SendMessage.
	/// </summary>
	public interface ISessionedMailingProvider : IMailingProvider
	{

		#region Methods: Public

		/// <summary>
		/// Starts sending of the bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="sessionId">Identifies each trigger mailing session.</param>
		/// <param name="isDelayedStart">Deelay sending.</param>
		/// <returns>Returns status of bulk email.</returns>
		MailingResponse SendMessage(Guid bulkEmailId, Guid sessionId, bool isDelayedStart = false, string applicationUrl = ""); 
		
		#endregion

	}

	#endregion

}

