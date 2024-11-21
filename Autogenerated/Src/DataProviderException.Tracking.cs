namespace BPMSoft.Configuration.Tracking
{
	using System;
	using System.Net;
	using System.Runtime.Serialization;

	#region Class: DataProviderException

	/// <summary>
	/// Base data provider exception provided for API.
	/// </summary>
	[Serializable]
	public class DataProviderException : Exception
	{

		#region Properties: Public

		/// <summary>
		/// Contains http status code of origianl response from cloud.
		/// </summary>
		public HttpStatusCode ResponseStatusCode { get; set; }

		/// <summary>
		/// Request url to cloud on which we gets exception.
		/// </summary>
		public string RequestedUrl { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DataProviderException() {}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">Exception message.</param>
		public DataProviderException(string message) : base(message) {}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">Exception message.</param>
		/// <param name="responseStatusCode">Response status code from cloud.</param>
		/// <param name="requestedUrl">Requested url to cloud which caused exception.</param>
		public DataProviderException(string message, HttpStatusCode responseStatusCode, string requestedUrl)
				: base(message) {
			ResponseStatusCode = responseStatusCode;
			RequestedUrl = requestedUrl;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">Exception message.</param>
		/// <param name="innerException">Inner exception.</param>
		/// <param name="responseStatusCode">Response status code from cloud.</param>
		/// <param name="requestedUrl">Requested url to cloud which caused exception.</param>
		public DataProviderException(string message, Exception innerException, HttpStatusCode responseStatusCode,
				string requestedUrl) : base(message, innerException) {
			ResponseStatusCode = responseStatusCode;
			RequestedUrl = requestedUrl;
		}

		/// <inheritdoc/>
		public DataProviderException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		#endregion

		#region Methods: Public

		public override string ToString() {
			var str = base.ToString();
			return $"ResponseStatusCode: {ResponseStatusCode}. RequesttedUrl: {RequestedUrl}." + str;
		}

		#endregion
	}

	#endregion

}

