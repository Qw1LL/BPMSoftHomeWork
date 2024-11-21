namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Entities;
	using EntityCollection = Core.Entities.EntityCollection;

	#region Interface: IBulkEmailAudienceRepository

	/// <summary>
	/// Describes functionality for audience of the bulk email.
	/// </summary>
	public interface IBulkEmailAudienceRepository
	{

		#region Methods: Public

		/// <summary>
		/// Gets audience of the bulk email with duplicate conditions.
		/// </summary>
		/// <param name="bulkEmailId">Unique identifier of the bulk email.</param>
		/// <param name="esq">Select query of the bulk email audience.</param>
		/// <param name="duplicateType">Audience duplicate type.</param>
		/// <param name="options">Select query options.</param>
		/// <returns>Collection of recipients with duplicate contact identifier.</returns>
		EntityCollection SelectAudience(Guid bulkEmailId, EntitySchemaQuery esq,
			BulkEmailAudienceDuplicateType duplicateType, EntitySchemaQueryOptions options);

		#endregion

	}

	#endregion
    
}

