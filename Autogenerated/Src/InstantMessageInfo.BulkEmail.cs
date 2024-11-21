namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: InstantMessageInfo

	/// <summary>
	/// Provides methods and properties for work with instant messages.
	/// </summary>
	public class InstantMessageInfo : IMessageInfo
	{
		#region Properties: Public

		/// <summary>
		/// Bulk email entity.
		/// </summary>
		public BulkEmail BulkEmail {
			get;
			private set;
		}
		
		/// <summary>
		/// Unique identifier of message.
		/// </summary>
		public Guid MessageId {
			get;
			set;
		}

		/// <summary>
		/// RId of message.
		/// </summary>
		public int MessageRId {
			get;
			set;
		}

		/// <summary>
		/// Collection of message recipients.
		/// </summary>
		public IEnumerable<IMessageRecipientInfo> Recipients {
			get;
			set;
		}

		/// <summary>
		/// Url of application.
		/// </summary>
		public string ApplicationUrl {
			get;
			set;
		}

		/// <summary>
		/// Flag of delayed start.
		/// </summary>
		public bool IsDelayedStart {
			get;
			set;
		}

		/// <summary>
		/// Utc timestamp of srart of message sending.
		/// </summary>
		public int MailingStartTS {
			get;
			set;
		}

		/// <summary>
		/// Utc date of message sending.
		/// </summary>
		public DateTime SendDate {
			get;
			set;
		}

		#endregion		

		#region Methods: Private

		private static int ConvertDateTimeToTimestamp(DateTime dateTime) {
			return (Int32)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates message.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <returns>True - if message is valid.</returns>
		public bool Validate() {
			if (BulkEmail == null) {
				MailingUtilities.Log.InfoFormat("[ExecuteSendMessage]: Can't access record with Id: {0}.", MessageId);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Prepares message before sending.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		public void PrepareMessage(UserConnection userConnection) {
			BulkEmail = new BulkEmail(userConnection);
			BulkEmail.FetchFromDB(MessageId);
			SendDate = DateTime.UtcNow;
			MailingStartTS = ConvertDateTimeToTimestamp(SendDate);
		}

		/// <summary>
		/// Updates StartDate, SendStartDate, SendDueDate, RecipientCount and CommonError count columns.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="isError">Indicates whether there is sending error.</param>
		public void UpdateMessageInfo(UserConnection userConnection, bool isError = false) {
			int count = Recipients.Count();
			var update = new Update(userConnection, "BulkEmail")
				.Set("StartDate", Column.Parameter(SendDate))
				.Set("SendStartDate", Column.Parameter(SendDate))
				.Set("SendDueDate", Column.Parameter(SendDate))
				.Set("RecipientCount", QueryColumnExpression.Add(new QueryColumnExpression("RecipientCount"),
					Column.Parameter(count)));
			if (isError) {
				update.Set("CommonErrorCount", QueryColumnExpression.Add(new QueryColumnExpression("CommonErrorCount"),
					Column.Parameter(count)));
			} else {
				QueryColumnExpression actualSentExpression 
					= MailingDbUtilities.GetAddCountColumnExpression("SendCount", count);
				update.Set("SendCount", actualSentExpression);
			}
			update.Where("Id").IsEqual(Column.Parameter(MessageId));
			(update as Update).Execute();
		}

		#endregion
	}

	#endregion
}

