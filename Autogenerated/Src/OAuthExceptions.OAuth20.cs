namespace BPMSoft.Configuration.OAuth20
{
	using System;
	using System.Runtime.Serialization;

	#region Class: OAuthResourceException

	/// <summary>
	/// Exception thrown while resource registering.
	/// </summary>
	[Serializable]
	public class OAuthResourceException : Exception
	{

		#region Constructors: Public

		/// <inheritdoc/>
		public OAuthResourceException() {
		}

		/// <inheritdoc/>
		public OAuthResourceException(string message) : base(message) {
		}

		/// <inheritdoc/>
		public OAuthResourceException(string message, Exception innerException) : base(message, innerException) {
		}

		#endregion

		#region Constructors: Protected

		/// <inheritdoc/>
		protected OAuthResourceException(SerializationInfo info, StreamingContext context)
				: base(info, context) {
		}

		#endregion
	}

	#endregion

	#region Class: OAuthResourceInClientException

	/// <summary>
	/// Exception thrown while client application registering.
	/// </summary>
	[Serializable]
	public class OAuthResourceInClientException : Exception
	{

		#region Constructors: Public

		/// <inheritdoc/>
		public OAuthResourceInClientException()
		{
		}

		/// <inheritdoc/>
		public OAuthResourceInClientException(string message) : base(message)
		{
		}

		/// <inheritdoc/>
		public OAuthResourceInClientException(string message, Exception innerException) : base(message, innerException)
		{
		}

		#endregion

		#region Constructors: Protected

		/// <inheritdoc/>
		protected OAuthResourceInClientException(SerializationInfo info, StreamingContext context)
				: base(info, context)
		{
		}

		#endregion

	}

	#endregion

	#region Class: OAuthClientAppException

	/// <summary>
	/// Exception thrown while client application registering.
	/// </summary>
	[Serializable]
	public class OAuthClientAppException : Exception
	{

		#region Constructors: Public

		/// <inheritdoc/>
		public OAuthClientAppException()
		{
		}

		/// <inheritdoc/>
		public OAuthClientAppException(string message) : base(message)
		{
		}

		/// <inheritdoc/>
		public OAuthClientAppException(string message, Exception innerException) : base(message, innerException)
		{
		}

		#endregion

		#region Constructors: Protected

		/// <inheritdoc/>
		protected OAuthClientAppException(SerializationInfo info, StreamingContext context)
				: base(info, context)
		{
		}

		#endregion

	}

	#endregion

}
