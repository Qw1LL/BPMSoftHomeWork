namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.CESModels;
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: SendMessageData

	/// <summary>
	/// Class for parameters of batch to send.
	/// </summary>
	public class SendMessageData
	{

		#region Fields: Private

		private List<image> _images;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the session identifier.
		/// </summary>
		/// <value>
		/// The session identifier.
		/// </value>
		public Guid SessionId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the user connection.
		/// </summary>
		/// <value>
		/// The user connection.
		/// </value>
		public UserConnection UserConnection {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the bulk email entity.
		/// </summary>
		/// <value>
		/// The bulk email.
		/// </value>
		public BulkEmail BulkEmail {
			get;
			set;
		}

		/// <summary>
		/// Gets the bulk email integer identifier.
		/// </summary>
		/// <value>
		/// The bulk email integer identifier.
		/// </value>
		public int BulkEmailRId {
			get {
				return BulkEmailQueryHelper.GetBulkEmailRId(BulkEmail.Id, UserConnection);
			}
		}

		/// <summary>
		/// Gets or sets the bulk email start date.
		/// </summary>
		/// <value>
		/// The bulk email start date.
		/// </value>
		public DateTime BulkEmailStartDate {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the recipients batch identifier.
		/// </summary>
		/// <value>
		/// The batch identifier.
		/// </value>
		public int BatchId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the email message.
		/// </summary>
		/// <value>
		/// The email message.
		/// </value>
		public EmailMessage EmailMessage {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the email contact collection.
		/// </summary>
		/// <value>
		/// The email contact collection.
		/// </value>
		public Dictionary<Guid, int> EmailContactCollection {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the images.
		/// </summary>
		/// <value>
		/// The images.
		/// </value>
		public List<image> Images {
			get {
				if (_images == null) {
					_images = new List<image>();
				}
				return _images;
			}
			set {
				_images = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the template.
		/// </summary>
		/// <value>
		/// The name of the template.
		/// </value>
		public string TemplateName {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the length of the batch.
		/// </summary>
		/// <value>
		/// The length of the batch.
		/// </value>
		public int BatchLength {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the mailing start timestamp.
		/// </summary>
		/// <value>
		/// The mailing start ts.
		/// </value>
		public int MailingStartTS {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Clones this instance.
		/// </summary>
		/// <returns></returns>
		public SendMessageData Clone() {
			SendMessageData clone = new SendMessageData();
			clone.UserConnection = UserConnection;
			clone.SessionId = SessionId;
			clone.BulkEmailStartDate = BulkEmailStartDate;
			clone.BatchId = BatchId;
			clone.TemplateName = TemplateName;
			clone.BatchLength = BatchLength;
			clone.MailingStartTS = MailingStartTS;
			if (EmailContactCollection != null) {
				clone.EmailContactCollection = new Dictionary<Guid, int>(EmailContactCollection);
			}
			if (Images != null) {
				clone.Images = new List<image>(Images);
			}
			return clone;
		}

		/// <summary>
		/// Gets the low package edge.
		/// </summary>
		/// <returns></returns>
		public int GetLowPackageEdge() {
			return (BatchId - 1) * BatchLength + 1;
		}

		/// <summary>
		/// Gets the high package edge.
		/// </summary>
		/// <returns></returns>
		public int GetHighPackageEdge() {
			return BatchId * BatchLength;
		}

		#endregion
	}

	#endregion

}

