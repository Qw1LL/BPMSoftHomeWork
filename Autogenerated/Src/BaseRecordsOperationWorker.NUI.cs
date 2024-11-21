namespace BPMSoft.Configuration {
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using global::Common.Logging;

	#region Class: BaseRecordsOperationWorker

	public abstract class BaseRecordsOperationWorker : IRecordsOperationWorker {

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("MultiDelete");

		#endregion

		#region Fields: Protected

		protected readonly UserConnection UserConnection;
		protected readonly IDictionary<string, object> Parameters;
		protected IRecordOperationExecutor OperationExecutor;

		#endregion

		#region Constructors: Protected

		protected BaseRecordsOperationWorker(UserConnection userConnection,
				IDictionary<string, object> parameters) {
			UserConnection = userConnection;
			Parameters = parameters;
		}

		#endregion

		#region Properties: Protected

		private EntitySchemaQuery _esq;
		protected EntitySchemaQuery Esq {
			get {
				if (_esq == null) {
					string schemaName = Parameters["SchemaName"].ToString();
					_esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
					_esq.AddAllSchemaColumns();
				}
				return _esq;
			}
		}

		#endregion

		#region Methods: Private

		private RecordProcessedEventArgs GetRecordProcessedEventArgs(Guid recordId) {
			Exception ex = GetOperationException();
			SaveLog(ex, recordId);
			return new RecordProcessedEventArgs() {
				RecordId = recordId,
				Exception = ex
			};
		}

		private void SaveLog(Exception ex, Guid recordId) {
			if (ex != null) {
				_log.Error(String.Concat(recordId.ToString(), ex.Message), ex);
			} else {
				_log.Info(String.Concat(recordId.ToString(), "success\n"));
			}
		}

		private void RemoveProcessedEntity(EntityCollection entityCollection, Entity entity) {
			if (entity != null) {
				entityCollection.Remove(entity);
			}
		}

		private Entity GetFirstEntity(EntityCollection entityCollection) {
			if (entityCollection.Count > 0) {
				return entityCollection.First();
			} else {
				return null;
			}
		}

		private void ApplyRecordProcessed(Guid recordId) {
			RecordProcessedEventArgs recordProcessedEventArgs = GetRecordProcessedEventArgs(recordId);
			OnRecordProcessed(this, recordProcessedEventArgs);
		}

		private void ProcessedForAlreadyDeletedRecords(IEnumerable<Guid> collection,
				EntityCollection entityCollection) {
			var entityCollectionGuids = (IEnumerable<Guid>)entityCollection.Select(item => (Guid)item.PrimaryColumnValue);
			IEnumerable<Guid> exceptedCollection = collection.Except(entityCollectionGuids);
			foreach (Guid id in exceptedCollection) {
				ApplyRecordProcessed(id);
			}
		}
		
		private void DistinctEntityCollection(EntityCollection entityCollection) {
			Entity[] entities = entityCollection.ToArray();
			IEnumerable<Entity> distinctResult;
			distinctResult = entities.GroupBy(i => i.PrimaryColumnValue).Select(e => e.First());
			entityCollection.Clear();
			foreach (var entity in distinctResult) {
				entityCollection.Add(entity);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual void OnRecordProcessed(object sender, RecordProcessedEventArgs args) {
			EventHandler<RecordProcessedEventArgs> handler = RecordProcessed;
			if (handler != null) {
				handler(sender, args);
			}
		}

		abstract protected Entity GetPreparedEntity(Entity entity);

		protected void PrepareEntitySchemaQuery(IEnumerable<Guid> collection) {
			string[] recordsId = collection.Select(item => item.ToString()).ToArray();
			Esq.ResetSelectQuery();
			Esq.Filters.Clear();
			Esq.Filters.Add(Esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				Esq.PrimaryQueryColumn.Name, recordsId));
		}

		protected abstract Exception GetOperationException();

		#endregion

		#region IRecordsOperationWorker Members

		public event EventHandler<RecordProcessedEventArgs> RecordProcessed;

		public virtual void ApplyOperations(IEnumerable<Guid> collection) {
			PrepareEntitySchemaQuery(collection);
			EntityCollection entityCollection = Esq.GetEntityCollection(UserConnection);
			DistinctEntityCollection(entityCollection);
			ProcessedForAlreadyDeletedRecords(collection, entityCollection);
			Entity entity = GetFirstEntity(entityCollection);
			while (entity != null) {
				entity = GetPreparedEntity(entity);
				OperationExecutor.Execute(entity);
				ApplyRecordProcessed(entity.PrimaryColumnValue);
				RemoveProcessedEntity(entityCollection, entity);
				entity = GetFirstEntity(entityCollection);
			}
		}

		#endregion

	}

	#endregion

}

