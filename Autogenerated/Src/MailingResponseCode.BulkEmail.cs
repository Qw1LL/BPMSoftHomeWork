namespace BPMSoft.Configuration {
	using System;

	#region Enum: MailingResponseCode

	/// <summary>
	/// Response code in mailing.
	/// </summary>
	public enum MailingResponseCode {
		/// <summary>
		/// General request failure.
		/// </summary>
		RequestFailed = 1,

		/// <summary>
		/// Sent.
		/// </summary>
		Sent = 2,

		/// <summary>
		/// Recived by provider (delayed).
		/// </summary>
		Deferral = 3,

		/// <summary>
		/// Rejected.
		/// </summary>
		Rejected = 4,
		
		/// <summary>
		/// Incorrect addressee.
		/// </summary>
		Invalid = 5,
		
		/// <summary>
		/// Recived by provider (queued).
		/// </summary>
		Queued = 6,
		
		/// <summary>
		/// Sent to provider.
		/// </summary>
		PostedProvider = 7,

		/// <summary>
		/// Hard Bounce.
		/// </summary>
		HardBounce = 8,

		/// <summary>
		/// Spam.
		/// </summary>
		Spam = 9,

		/// <summary>
		/// Unsubiscribe.
		/// </summary>
		Unsub = 10,

		/// <summary>
		/// Link open.
		/// </summary>
		Clicked = 12,

		/// <summary>
		/// Soft Bounce.
		/// </summary>
		SoftBounce = 13,

		/// <summary>
		/// Planned.
		/// </summary>
		Planned = 14,

		/// <summary>
		/// Opened.
		/// </summary>
		Opened = 15,

		/// <summary>
		/// Canceled (unsubscribed list).
		/// </summary>
		CanceledDoNotUseEmail = 19,

		/// <summary>
		/// Canceled (invalid email).
		/// </summary>
		CanceledInvalidEmail = 20,

		/// <summary>
		/// Canceled (incorrect email).
		/// </summary>
		CanceledIncorrectEmail = 21,

		/// <summary>
		/// Canceled (blank email).
		/// </summary>
		CanceledBlankEmail = 22,

		/// <summary>
		/// Canceled (there is no template replica for recipient).
		/// </summary>
		CanceledTemplateNotFound = 25,

		/// <summary>
		/// Canceled (sender's domain not verified)
		/// </summary>
		CanceledSendersDomainNotVerified = 26,

		/// <summary>
		/// Canceled (sender's name not valid)
		/// </summary>
		CanceledSendersNameNotValid = 27,

		/// <summary>
		/// There are already such email in sending audience.
		/// </summary>
		Duplicated = 42,

		/// <summary>
		/// Sending.
		/// </summary>
		Sending = 43,

		/// <summary>
		/// Cancelled (communication limit)
		/// </summary>
		CanceledCommunicationLimit = 11,
		
		/// <summary>
		/// Canceled (unsubscribed in email subscriptions by email type)
		/// </summary>
		CanceledUnsubscribedByType = 44

	}

	#endregion
}

