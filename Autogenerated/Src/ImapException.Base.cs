namespace BPMSoft.Mail
{
	using System;

	#region Class: ImapException

	public class ImapException : Exception
	{

		#region Constructors: Public

		public ImapException(string message)
			: base(message) {
		}

		public ImapException(string message, Exception innerException)
			: base(message, innerException) {
		}

		#endregion

	}

	#endregion

}
