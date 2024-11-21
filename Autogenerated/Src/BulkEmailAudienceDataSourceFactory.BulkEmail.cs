namespace BPMSoft.Configuration
{
	using System;
	using Core;

	#region Interface: IMailingAudienceDataSourceFactory

	/// <summary>
	/// Implements factory to create instances of <see cref="IMailingAudienceDataSource"/>.
	/// </summary>
	[Obsolete("Will be removed after 7.17.3")]
	public class BulkEmailAudienceDataSourceFactory: IMailingAudienceDataSourceFactory, IMailingAudienceSessionedDataSourceFactory
	{
		#region Constructors: Public

		/// <summary>
		/// Default constructor. Creates an instance of the BulkEmailAudienceDataSourceFactory.
		/// </summary>
		public BulkEmailAudienceDataSourceFactory() {
		}

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// Implements method to create new instance of <see cref="IMailingAudienceDataSource"/>.
		/// </summary>
		/// <param name="userConnection">User's connection.</param>
		/// <param name="bulkEmailId">The unique identifier of the bulk email.</param>
		/// <param name="batchSize">The size of page to read.</param>
		/// <returns>New instance of <see cref="BulkEmailAudienceDataSource"/></returns>
		/// 
		public IMailingAudienceDataSource CreateInstance(UserConnection userConnection, Guid bulkEmailId, int batchSize) {
			return new BulkEmailAudienceDataSource(userConnection, bulkEmailId, batchSize);
		}

		/// <summary>
		/// Implements method to create new instance of <see cref="IMailingAudienceDataSource"/> with sessionId support.
		/// </summary>
		/// <param name="userConnection">User's connection.</param>
		/// <param name="bulkEmailId">The unique identifier of the bulk email.</param>
		/// <param name="batchSize">The size of page to read.</param>
		/// <returns>New instance of <see cref="BulkEmailAudienceDataSource"/></returns>
		/// 
		public IMailingAudienceDataSource CreateSessionedInstance(UserConnection userConnection, Guid bulkEmailId, int batchSize, Guid sessionId) {
			return new BulkEmailAudienceDataSource(userConnection, bulkEmailId, batchSize, sessionId);
		}

		#endregion

	}

	#endregion

}
