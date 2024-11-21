namespace BPMSoft.Configuration.GlobalSearch
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.GlobalSearch.Indexing;
	using GlobalSearchIndexingOperationType = BPMSoft.GlobalSearch.Indexing.IndexingOperationType;

	#region Class: BaseIndexer

	/// <summary>
	/// Template method for indexing entities.
	/// </summary>
	public class BaseIndexer
	{

		#region Constructors: Public

		public BaseIndexer(IndexingRequestDataBuilder indexingRequestDataBuilder,
			IndexingEntitySender indexingEntitySender) {
			IndexingRequestDataBuilder = indexingRequestDataBuilder;
			IndexingEntitySender = indexingEntitySender;
		}

		#endregion

		#region Properties: Protected

		protected IndexingRequestDataBuilder IndexingRequestDataBuilder { get; }
		protected IndexingEntitySender IndexingEntitySender { get; }

		#endregion

		#region Methods: Protected

		protected bool GetIsGlobalSearchFeatureEnabled(UserConnection userConnection) {
			return userConnection.GetIsFeatureEnabled("GlobalSearch_V2");
		}

		protected virtual void SendIndexingEntity(Entity entity, GlobalSearchIndexingOperationType indexingOperationType) {
			var indexingData =
				IndexingRequestDataBuilder.BuildRequestData(entity.UserConnection, indexingOperationType, entity);
			IndexingEntitySender.SendIndexingEntity(indexingData);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends entity to indexation.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="indexingOperationType">Operation type <see cref="IndexingOperationType"/></param>
		public void IndexEntity(Entity entity, GlobalSearchIndexingOperationType indexingOperationType) {
			if (!GetIsGlobalSearchFeatureEnabled(entity.UserConnection)) {
				return;
			}
			SendIndexingEntity(entity, indexingOperationType);
		}

		#endregion

	}

	#endregion


}
