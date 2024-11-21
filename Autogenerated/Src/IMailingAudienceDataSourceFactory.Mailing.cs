namespace BPMSoft.Configuration
{
	using System;
	using Core;

	#region Interface: IMailingAudienceDataSourceFactory

	/// <summary>
	/// Provides method to create instances of <see cref="IMailingAudienceDataSource"/>.
	/// </summary>
	[Obsolete("Will be removed after 7.17.3")]
	public interface IMailingAudienceDataSourceFactory 
	{

		#region Methods: Public

		/// <summary>
		/// Provides interface method to create new instance of <see cref="IMailingAudienceDataSource"/>.
		/// </summary>
		/// <param name="userConnection">User's connection.</param>
		/// <param name="messageId">The unique identifier of the mailing.</param>
		/// <param name="batchSize">The size of page to read.</param>
		/// <returns>New instance of <see cref="IMailingAudienceDataSource"/>.</returns>
		IMailingAudienceDataSource CreateInstance(UserConnection userConnection, Guid messageId, int batchSize);

		#endregion

	}

	#endregion

	#region Interface: IMailingAudienceSessionedDataSourceFactory

	/// <summary>
	/// Provides method to create instances of <see cref="IMailingAudienceDataSource"/>. 
	/// Extends the <see cref="IMailingAudienceDataSourceFactory"/> with the sessionId support.
	/// </summary>
	[Obsolete("Will be removed after 7.17.3")]
	public interface IMailingAudienceSessionedDataSourceFactory : IMailingAudienceDataSourceFactory
	{

		#region Methods: Public

		/// <summary>
		/// Provides interface method to create new instance of <see cref="IMailingAudienceDataSource"/>.
		/// </summary>
		/// <param name="userConnection">User's connection.</param>
		/// <param name="messageId">The unique identifier of the trigger mailing session.</param>
		/// <param name="batchSize">The size of page to read.</param>
		/// <param name="sessionId">The mailing session identifier.</param>
		/// <returns>New instance of <see cref="IMailingAudienceDataSource"/>.</returns>
		IMailingAudienceDataSource CreateSessionedInstance(UserConnection userConnection, Guid messageId, int batchSize, Guid sessionId);

		#endregion

	}

	#endregion

}
