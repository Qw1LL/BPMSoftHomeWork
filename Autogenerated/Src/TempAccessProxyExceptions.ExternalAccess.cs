namespace BPMSoft.Configuration.ExternalAccessPackage
{
	using System;

	#region Class: ApiServerException

	[Obsolete("Use BPMSoft.OAuthIntegration.Exception.ApiServerException", true)]
	/// <summary>
	/// The exception that is thrown when proxy got error from api server.
	/// </summary>
	public class ApiServerException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiServerException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public ApiServerException(string message)
			: base(message) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiServerException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference
		/// if no inner exception is specified.</param>
		public ApiServerException(string message, Exception innerException) : base(message, innerException) {
		}

		#endregion

	}

	#endregion

	#region Class: ApiServerConnectivityException

	[Obsolete("Use BPMSoft.OAuthIntegration.Exception.ApiServerConnectivityException", true)]
	/// <summary>
	/// The exception that is thrown when api call failed due client timeout, network problems, DNS failure, etc.
	/// </summary>
	public class ApiServerConnectivityException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiServerException"/> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public ApiServerConnectivityException(string message)
			: base(message) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiServerConnectivityException"/> class.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference
		/// if no inner exception is specified.</param>
		public ApiServerConnectivityException(string message, Exception innerException)
			: base(message, innerException) {
		}

		#endregion

	}

	#endregion

}

