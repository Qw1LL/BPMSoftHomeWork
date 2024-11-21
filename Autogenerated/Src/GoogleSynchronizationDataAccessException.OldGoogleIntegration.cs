namespace BPMSoft.Configuration
{

	using System;

	#region Class: GoogleSynchronizationDataAccessException

	/// <summary>
	/// Google api data access exception wrapper.
	/// </summary>
	public class GoogleSynchronizationDataAccessException : Exception
	{

		#region Constructors: Public

		/// <summary>
		/// <see cref="Exception()"/>.
		/// </summary>
		public GoogleSynchronizationDataAccessException() {
		}

		/// <summary>
		/// <see cref="Exception(string)"/>.
		/// </summary>
		public GoogleSynchronizationDataAccessException(string message)
			: base(message) {
		}

		/// <summary>
		/// <see cref="Exception(string, Exception)"/>.
		/// </summary>
		public GoogleSynchronizationDataAccessException(string message, Exception innerException)
			: base(message, innerException) {
		}

		#endregion

	}

	#endregion

}

