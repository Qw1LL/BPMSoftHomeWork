namespace BPMSoft.Mail
{
	using System;

	#region Class: SmtpException

	public class SmtpException : ApplicationException {
		
		#region Properties: Puplic

		public string EmailSendStatus {
			get;
			private set;
		}

		#endregion

		#region Constructors: Puplic

		public SmtpException(string emailSendStatus, string emailSendStatusDescription)
			: base(emailSendStatusDescription) {
			EmailSendStatus = emailSendStatus;
		}

		public SmtpException(string emailSendStatus, string emailSendStatusDescription, Exception innerException)
			: base(emailSendStatusDescription, innerException) {
			EmailSendStatus = emailSendStatus;
		}

		#endregion

	}

	#endregion

}
