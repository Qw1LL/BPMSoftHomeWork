namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Interface: IMessageInfo

	/// <summary>
	/// Provides methods and properties for work with messages.
	/// </summary>
	public interface IMessageInfo
	{
		#region Properties: Public

		/// <summary>
		/// Unique identifier of message.
		/// </summary>		
		Guid MessageId { 
			get; 
			set; 
		}

		/// <summary>
		/// RId of message.
		/// </summary>
		int MessageRId {
			get;
			set;
		}
		
		/// <summary>
		/// Collection of message recipients.
		/// </summary>
		IEnumerable<IMessageRecipientInfo> Recipients { 
			get; 
			set; 
		}

		/// <summary>
		/// Url of application.
		/// </summary>
		string ApplicationUrl { 
			get; 
			set; 
		}

		/// <summary>
		/// Flag of delayed start.
		/// </summary>
		bool IsDelayedStart { 
			get; 
			set; 
		}

		/// <summary>
		/// Utc timestamp of srart of message sending.
		/// </summary>
		int MailingStartTS { 
			get; 
			set; 
		}

		/// <summary>
		/// Utc date of message sending.
		/// </summary>
		DateTime SendDate {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates message.
		/// </summary>
		/// <returns>True - if message is valid.</returns>
		bool Validate();

		/// <summary>
		/// Prepares message before sending.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		void PrepareMessage(UserConnection userConnection);

		/// <summary>
		/// Updates message entity columns.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="isError">Indicates whether there is sending error.</param>
		void UpdateMessageInfo(UserConnection userConnection, bool isError = false);

		#endregion
	}

	#endregion
}

