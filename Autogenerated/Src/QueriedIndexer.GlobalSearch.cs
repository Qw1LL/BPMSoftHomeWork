namespace BPMSoft.Configuration.GlobalSearch
{
	using BPMSoft.Core.Entities;
	using BPMSoft.Configuration.GlobalSearchColumnUtils;
	using BPMSoft.GlobalSearch.Indexing;

	#region Class: QueriedIndexer

	public class QueriedIndexer : BaseIndexer
	{

		#region Constructors: Public

		public QueriedIndexer(IndexingRequestDataBuilder indexingRequestDataBuilder,
			IndexingEntitySender indexingEntitySender)
			: base(indexingRequestDataBuilder, indexingEntitySender) { }

		#endregion

		#region Methods: Protected

		protected override void SendIndexingEntity(Entity entity, IndexingOperationType indexingOperationType) {
			var indexingData = IndexingRequestDataBuilder.BuildQueriedRequestData(entity.UserConnection,
				indexingOperationType, entity, GlobalSearchColumnUtils.Instance.RelationColumnsFieldPattern);
			IndexingEntitySender.SendIndexingEntity(indexingData);
		}

		#endregion

	}

	#endregion

}
