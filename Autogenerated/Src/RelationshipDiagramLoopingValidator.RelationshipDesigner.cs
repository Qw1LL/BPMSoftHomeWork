namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;

	#region Class: RelationshipDiagramLoopingValidator

	/// <summary>
	/// Class RelationshipDiagramLoopingValidator.
	/// </summary>

	public class RelationshipDiagramLoopingValidator
	{
		#region Fields: Private

		private List<Guid> _visitedEntities;
		private List<RelationshipEntityConnection> _loopingConnections;
		private Queue<Guid> _entityQueue;
		private HashSet<Tuple<Guid, Guid>> _connectedRecord;
		private int _minCountItemsToCheck = 1;

		#endregion

		#region Properties: Private

		private List<RelationshipEntityConnection> LoopingConnections => _loopingConnections ?? (_loopingConnections = new List<RelationshipEntityConnection>());

		private Queue<Guid> EntityQueue => _entityQueue ?? (_entityQueue = new Queue<Guid>());

		private List<RelationshipEntityConnection> RelationshipConnections {
			get; set;
		}

		private Guid CurrentRecord {
			get; set;
		}

		private List<Guid> VisitedEntities => _visitedEntities ?? (_visitedEntities = new List<Guid>());

		private HashSet<Tuple<Guid, Guid>> ConnectedRecords => _connectedRecord ?? (_connectedRecord = new HashSet<Tuple<Guid, Guid>>());

		#endregion

		#region Methods: Private

		private HashSet<Guid> GetUniqueEntities() {
			HashSet<Guid> uniqueItems1 = RelationshipConnections
				.Select(connection => connection.RelationshipEntityA)
				.Distinct()
				.ToHashSet();
			HashSet<Guid> uniqueItems2 = RelationshipConnections
				.Select(connection => connection.RelationshipEntityB)
				.Distinct()
				.ToHashSet();
			uniqueItems1.AddRange(uniqueItems2);
			return uniqueItems1;
		}

		private List<RelationshipEntityConnection> GetConnectedItems(Guid entityId) {
			return RelationshipConnections
				.Where(connection => connection.IsEntityConnected(entityId))
				.ToList();
		}

		private List<RelationshipEntityConnection> GetDirectedConnectedItems(Guid entityId) {
			return RelationshipConnections
				.Where(connection => connection.RelationshipEntityA.Equals(entityId))
				.ToList();
		}

		private void AddEntityToQueue(List<RelationshipEntityConnection> connectedItems) {
			var excludedVisitedRecords = connectedItems
				.Select(connectedItem => connectedItem.GetConnectedRecord(CurrentRecord))
				.Where(connectedItem => !VisitedEntities.Contains(connectedItem))
				.ToList();
			var foundConnectedItems = excludedVisitedRecords
				.Where(connectedItem => !EntityQueue.Contains(connectedItem))
				.Distinct();
			foundConnectedItems.ForEach(connectedItem => {
				EntityQueue.Enqueue(connectedItem);
			});
		}

		private void AddLoopingConnection(RelationshipEntityConnection connection) {
			var isNeedAdd = !LoopingConnections.Any(rec => rec.Id.Equals(connection.Id));
			if (isNeedAdd) {
				LoopingConnections.Add(connection);
			}
		}

		private bool IsDuplicateRecord(Guid recordId) {
			var connection = Tuple.Create(recordId, CurrentRecord);
			var revertConnection = Tuple.Create(CurrentRecord, recordId);
			return ConnectedRecords.Contains(connection) || ConnectedRecords.Contains(revertConnection);
		}

		private bool HasItemCotaintsInConnectedRecord(Guid recordId) {
			return ConnectedRecords.Any(con => con.Item1.Equals(recordId));
		}

		private void AddConnectedRecord(RelationshipEntityConnection connection) {
			var connectedRecordId = connection.GetConnectedRecord(CurrentRecord);
			if (IsDuplicateRecord(connectedRecordId)) {
				return;
			}

			if (HasItemCotaintsInConnectedRecord(connectedRecordId)) {
				AddLoopingConnection(connection);
			} else {
				ConnectedRecords.Add(Tuple.Create(connectedRecordId, CurrentRecord));
			}

		}

		private void HandleLoopCollection(List<RelationshipEntityConnection> connectedItems) {
			connectedItems.ForEach(connection => {
				AddConnectedRecord(connection);
			});
		}

		private void HandleConnections(List<RelationshipEntityConnection> relatedConnections) {
			AddEntityToQueue(relatedConnections);
			HandleLoopCollection(relatedConnections);
			VisitedEntities.Add(CurrentRecord);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Handle collection.
		/// </summary>
		protected void HandleCollection() {
			var entities = GetUniqueEntities();
			EntityQueue.Enqueue(entities.First());
			while (EntityQueue.Any()) {
				CurrentRecord = EntityQueue.Dequeue();
				var relatedConnections = GetConnectedItems(CurrentRecord);
				HandleConnections(relatedConnections);
			}
		}

		/// <summary>
		/// Handle directed collection.
		/// </summary>
		protected void HandleDirectedCollection(RelationshipEntityConnection connection) {
			var entities = GetUniqueEntities();
			ConnectedRecords.Add(Tuple.Create(connection.RelationshipEntityA, connection.RelationshipEntityB));
			EntityQueue.Enqueue(connection.RelationshipEntityB);
			while (EntityQueue.Any()) {
				CurrentRecord = EntityQueue.Dequeue();
				var relatedConnections = GetDirectedConnectedItems(CurrentRecord);
				HandleConnections(relatedConnections);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validate connection.
		/// </summary>
		public virtual List<RelationshipEntityConnection> ValidateConnection(List<RelationshipEntityConnection> connections, RelationshipEntityConnection connection) {
			RelationshipConnections = connections;
			if (connections.Count > _minCountItemsToCheck) {
				HandleDirectedCollection(connection);
			}
			return LoopingConnections;
		}

		/// <summary>
		/// Validate diagram.
		/// </summary>
		public virtual List<RelationshipEntityConnection> ValidateDiagram(List<RelationshipEntityConnection> connections) {
			RelationshipConnections = connections;
			if (connections.Count > _minCountItemsToCheck) {
				HandleCollection();
			}
			return LoopingConnections;
		}

		#endregion

	}

	#endregion

}
