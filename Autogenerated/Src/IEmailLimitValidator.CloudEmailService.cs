namespace BPMSoft.Configuration
{
	using System;

	#region Interface: IEmailLimitValidator
	
	/// <summary>
	/// Provides methods to validate email with sending limits.
	/// </summary>
	public interface IEmailLimitValidator
	{

		/// <summary>
		/// Validates single email.
		/// </summary>
		/// <param name="messageId">Unique identifier of the message.</param>
		/// <param name="recipientsCount">Recipients count to validate for sending limits.</param>
		/// <returns>Validation result. Instance of <see cref="ConfigurationServiceResponse"/>.</returns>
		ConfigurationServiceResponse ValidateMessage(Guid messageId, int recipientsCount);
	}
	
	#endregion

}
