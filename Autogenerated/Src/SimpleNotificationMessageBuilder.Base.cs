namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Messaging.Common;

	#region Class: SimpleNotificationMessageBuilder

	public class SimpleNotificationMessageBuilder : INotificationMessageBuilder
	{

		#region Fields: Private

		private readonly SimpleMessage _message = new SimpleMessage();

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets identifer of the entity.
		/// </summary>
		public Guid Id {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets identifier of the admin unit.
		/// </summary>
		public Guid SysAdminUnitId {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets name of the operation to notify.
		/// </summary>
		public string Operation {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets sender of the message.
		/// </summary>
		public string Sender {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds a message identifier.
		/// </summary>
		public Guid BuildId() {
			return SysAdminUnitId;
		}

		/// <summary>
		/// Builds a message header.
		/// </summary>
		public IMsgHeader BuildHeader() {
			IMsgHeader header = _message.Header;
			header.Sender = Sender;
			return header;
		}

		/// <summary>
		/// Builds a message body.
		/// </summary>
		public string BuildBody() {
			return string.Format("{{ \"recordId\": \"{0}\", \"operation\":\"{1}\"}}", Id, Operation);
		}

		/// <summary>
		/// Builds a notification message.
		/// </summary>
		public IMsg Build() {
			_message.Id = BuildId();
			_message.Body = BuildBody();
			BuildHeader();
			return _message;
		}

		#endregion

	}

	#endregion

}

