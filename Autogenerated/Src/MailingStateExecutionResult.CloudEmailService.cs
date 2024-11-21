namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: MailingStateExecutionResult

	/// <summary> 
	/// Provides properties of the bulk email sending response.
	/// </summary>
	public class MailingStateExecutionResult
	{

		#region Properties: Public

		/// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
		public MailingStateExecutionResult(Type stateType) {
			State = stateType.ToString();
		}
		
		/// <summary>
		/// Currently executed state.
		/// </summary>
		public string State { get; }
		
		/// <summary>
		/// Gets or sets the MailingStateExecutionStatus value.
		/// </summary>
		public MailingStateExecutionStatus Status { get; set; }

		/// <summary>
		/// Result of sending.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets exception.
		/// </summary>
		public Exception Exception { get; set; }

		/// <summary>
		/// Gets or sets enumerable of notification localizable codes. 
		/// </summary>
		public IEnumerable<string> NotificationLcsStringCodes { get; set; }

		/// <summary>
		/// Gets or sets localizable name of executed state.
		/// </summary>
		public string EventLczStringCode { get; set; }

		#endregion

	}

	#endregion

	public enum MailingStateExecutionStatus
	{
		Skipped,
		Done,
		Continue,
		Failed
	}

}

