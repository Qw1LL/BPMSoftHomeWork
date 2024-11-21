namespace BPMSoft.Configuration.GlobalSearch
{
	using System;
	using BPMSoft.Core.Entities;
	using BPMSoft.GlobalSearch.Indexing;

	#region Class: DetailIndexer

	public class DetailIndexer : BaseIndexer
	{

		#region Constructors: Public

		public DetailIndexer(IndexingRequestDataBuilder indexingRequestDataBuilder,
			IndexingEntitySender indexingEntitySender)
			: base(indexingRequestDataBuilder, indexingEntitySender) { }

		#endregion

		#region Methods: Private

		private Entity GetDetailParentEntity(Entity detailEntity) {
			var parentEntityName = detailEntity.SchemaName.Contains("Contact") ? "Contact" : "Account";
			var parentEntityColumn = $"{parentEntityName}Id";
			if (!detailEntity.IsColumnValueLoaded(parentEntityColumn)) {
				return null;
			}
			var parentEntity = detailEntity.LookupColumnEntities.GetEntity(parentEntityName);
			parentEntity.SetColumnValue(parentEntity.Schema.PrimaryColumn,
				detailEntity.GetTypedColumnValue<Guid>(parentEntityColumn));
			return parentEntity;
		}

		#endregion

		#region Methods: Protected

		protected override void SendIndexingEntity(Entity entity, IndexingOperationType indexingOperationType) {
			base.SendIndexingEntity(entity, indexingOperationType);
			var parentEntity = GetDetailParentEntity(entity);
			if (parentEntity == null) {
				return;
			}
			base.SendIndexingEntity(parentEntity, IndexingOperationType.Index);
		}

		#endregion

	}

	#endregion

}
