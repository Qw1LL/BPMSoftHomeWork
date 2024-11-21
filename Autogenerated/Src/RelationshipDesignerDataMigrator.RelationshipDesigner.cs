namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Threading.Tasks;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Entities;
	using global::Common.Logging;
	using Update = BPMSoft.Core.DB.Update;

	#region Interface: IRelationshipDesignerDataMigrator

	/// <summary>
	/// interface IRelationshipDesignerDataMigrator.
	/// </summary>
	interface IRelationshipDesignerDataMigrator
	{
		void StartMigration();

	}

	#endregion

	#region Class: RelationshipData

	/// <summary>
	/// Class RelationshipData.
	/// </summary>
	public class RelationshipData
	{

		#region Fields: Private

		private int _needRevertEntities = 1;

		#endregion

		#region Properties: Public

		/// <summary>
		/// AccountAId.
		/// </summary>
		public Guid AccountAId {
			get; set;
		}

		/// <summary>
		/// AccountBId.
		/// </summary>
		public Guid AccountBId {
			get; set;
		}

		/// <summary>
		/// ContactAId.
		/// </summary>
		public Guid ContactAId {
			get; set;
		}

		/// <summary>
		/// ContactBId.
		/// </summary>
		public Guid ContactBId {
			get; set;
		}

		/// <summary>
		/// RelationTypeId.
		/// </summary>
		public Guid RelationTypeId {
			get; set;
		}

		/// <summary>
		/// ReverseRelationTypeId.
		/// </summary>
		public Guid ReverseRelationTypeId {
			get; set;
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get; set;
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get; set;
		}

		/// <summary>
		/// ConnectionTypeId.
		/// </summary>
		public Guid ConnectionTypeId {
			get; set;
		}

		#endregion

		#region Methods: Private

		private bool ForAccountRecordA() {
			return !AccountAId.Equals(Guid.Empty);
		}

		private bool ForAccountRecordB() {
			return !AccountBId.Equals(Guid.Empty);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Return record A.
		/// </summary>
		public Guid GetRecordA() {
			return ForAccountRecordA() ? AccountAId : ContactAId;
		}

		/// <summary>
		/// Return record B.
		/// </summary>
		public Guid GetRecordB() {
			return ForAccountRecordB() ? AccountBId : ContactBId;
		}

		/// <summary>
		/// Return records a and record B.
		/// </summary>
		public (Guid, Guid) GetEntityRecords() {
			return Position == _needRevertEntities ? (GetRecordB(), GetRecordA()) : (GetRecordA(), GetRecordB());
		}

		/// <summary>
		/// Return relation type.
		/// </summary>
		public Guid GetRelationType() {
			return Position == _needRevertEntities ? ReverseRelationTypeId : RelationTypeId;
		}

		/// <summary>
		/// Check if entity id equals entity a or entity b.
		/// </summary>
		/// <param name="entityId">entityId.</param>
		public bool HasRecordConnected(Guid entityId) {
			var entities = GetEntityRecords();
			return entityId == entities.Item1 || entityId == entities.Item2;
		}

		/// <summary>
		/// Get connected record.
		/// </summary>
		/// <param name="entityId">.</param>
		public Guid GetConnectedRecord(Guid entityId) {
			(Guid, Guid) entities = GetEntityRecords();
			return entityId == entities.Item1 ? entities.Item2 : entities.Item1;
		}

		#endregion

	}

	#endregion

	#region Class RelationshipConnectionData

	/// <summary>
	/// Class RelationshipConnectionData.
	/// </summary>
	public class RelationshipConnectionData
	{

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get; set;
		}

		/// <summary>
		/// EntityAId.
		/// </summary>
		public Guid EntityAId {
			get; set;
		}

		/// <summary>
		/// EntityBId.
		/// </summary>
		public Guid EntityBId {
			get; set;
		}

		/// <summary>
		/// RelationTypeId.
		/// </summary>
		public Guid RelationTypeId {
			get; set;
		}

		/// <summary>
		/// Comment.
		/// </summary>
		public string Comment {
			get; set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Check if records equals current record.
		/// </summary>
		public bool Equals(Guid recordA, Guid recordB) {
			return EntityAId.Equals(recordA) && EntityBId.Equals(recordB) ||
				EntityAId.Equals(recordB) && EntityBId.Equals(recordA);
		}

		#endregion
	}

	#endregion

	#region Class: DiagramFromRecords

	/// <summary>
	/// Class DiagramsEntitiesBuilder.
	/// </summary>
	public class DiagramsEntitiesBuilder
	{

		#region Fields: Private

		private List<Guid> _visitedEntities;
		private Queue<Guid> _entityQueue;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionsData">.</param>
		public DiagramsEntitiesBuilder(List<RelationshipData> connectionsData) {
			ConnectionsData = connectionsData;
		}

		#endregion

		#region Properties: Private

		private List<RelationshipData> ConnectionsData {
			get; set;
		}

		private List<Guid> VisitedEntities {
			get => _visitedEntities ?? (_visitedEntities = new List<Guid>());
			set => _visitedEntities = value;
		}

		private Queue<Guid> EntityQueue => _entityQueue ?? (_entityQueue = new Queue<Guid>());

		private Dictionary<Guid, List<Guid>> _entityInDiagram;
		private Dictionary<Guid, List<Guid>> EntityInDiagram => _entityInDiagram ?? (_entityInDiagram = new Dictionary<Guid, List<Guid>>());

		private Guid CurrentRecord {
			get; set;
		}

		#endregion

		#region Methods: Private

		private List<Guid> GetUniqueEntities() {
			List<Guid> uniqueItems = ConnectionsData
				.AsParallel()
				.Select(connection => connection.GetRecordA())
				.Distinct()
				.ToList();
			List<Guid> uniqueItems2 = ConnectionsData
				.AsParallel()
				.Select(connection => connection.GetRecordB())
				.Where(rel => !uniqueItems.Contains(rel))
				.Distinct()
				.ToList();
			uniqueItems.AddRange(uniqueItems2);
			return uniqueItems;
		}

		private List<Guid> GetConnectedItems(Guid entityId) {
			return ConnectionsData
				.AsParallel()
				.Where(rec => rec.HasRecordConnected(entityId))
				.Select(connectedItem => connectedItem.GetConnectedRecord(CurrentRecord))
				.Where(connectedItem => !VisitedEntities.Contains(connectedItem))
				.ToList();
		}

		private void AddEntityToQueue(List<Guid> connectedItems) {
			var fundedConnectedItems = connectedItems
				.AsParallel()
				.Where(connectedItem => !EntityQueue.Contains(connectedItem))
				.Distinct();
			fundedConnectedItems.ForEach(connectedItem => {
				EntityQueue.Enqueue(connectedItem);
			});
		}

		private void GroupingEntitiesByDiagrams(List<Guid> entities) {
			while (entities.Any()) {
				var item = entities.FirstOrDefault();
				var groupItems = new HashSet<Guid> { item };
				EntityQueue.Enqueue(item);
				while (EntityQueue.Any()) {
					CurrentRecord = EntityQueue.Dequeue();
					var connectedItems = GetConnectedItems(CurrentRecord);
					if (connectedItems.Any()) {
						AddEntityToQueue(connectedItems);
						groupItems.AddRange(connectedItems);
					}
					VisitedEntities.Add(CurrentRecord);
				}
				EntityInDiagram.Add(Guid.NewGuid(), groupItems.ToList());
				CleanFoundListData(entities);
			}
		}

		private void CleanFoundListData(List<Guid> entities) {
			VisitedEntities.ForEach(ve => entities.Remove(ve));
			ConnectionsData = ConnectionsData
				.AsParallel()
				.Where(rec => !VisitedEntities.Contains(rec.GetRecordA()) && !VisitedEntities.Contains(rec.GetRecordB()))
				.ToList();
			VisitedEntities = new List<Guid>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds diagrams entities data.
		/// </summary>
		public Dictionary<Guid, List<Guid>> Build() {
			var entities = GetUniqueEntities();
			GroupingEntitiesByDiagrams(entities);
			return EntityInDiagram;
		}

		#endregion

	}

	#endregion

	#region Class: RelationshipDesignerDataMigrator

	/// <summary>
	/// Class RelationshipDesignerDataMigrator.
	/// </summary>
	[DefaultBinding(typeof(IRelationshipDesignerDataMigrator))]
	public class RelationshipDesignerDataMigrator : IRelationshipDesignerDataMigrator
	{

		#region Fields: Private

		private readonly ILog _log = LogManager.GetLogger("RelationshipDesignerDataMigrator");
		private int _chunkSize = 1000;
		private readonly int _insertMaxParametersCount = 2000;
		private string _contactSchemaName = "Contact";
		private string _accountSchemaName = "Account";
		private readonly Guid _relationConnectionTypeFormal = RelationshipDesignerConstants.RelationTypeConnectionType_Formal;
		private readonly Guid _relationConnectionTypeNotFormal = RelationshipDesignerConstants.RelationTypeConnectionType_NotFormal;
		private readonly Guid _relationPositionDirect = RelationshipDesignerConstants.RelationPosition_Direct;
		private readonly Guid _relationPositionHorizontal = RelationshipDesignerConstants.RelationPosition_Horizontal;
		private readonly Guid _technicalRelationType = new Guid("0C81982F-C716-4AC4-9D0B-7AD45D6CCAB3");
		private readonly List<string> _relationshipColumnNames = new List<string> {
			"RecordId", "SchemaUId"
		};

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		public RelationshipDesignerDataMigrator(UserConnection userConnection) => this.UserConnection = userConnection;

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get; set;
		}

		private Guid AccountSchemaUId => UserConnection.EntitySchemaManager.GetInstanceByName(_accountSchemaName).UId;

		private Guid ContactSchemaUId => UserConnection.EntitySchemaManager.GetInstanceByName(_contactSchemaName).UId;

		private int ChunkSize {
			get => _chunkSize;
			set {
				if (value > 0) {
					_chunkSize = value;
				}
			}
		}

		#endregion

		#region Methods: Private

		private string GetLocalizableString(string resourceName) {
			var localizableString = $"LocalizableStrings.{resourceName}.Value";
			string result = new LocalizableString(UserConnection.ResourceStorage,
				GetType().Name, localizableString);
			return result;
		}

		private int GetInsertChunkSize(int insertParametersCount) {
			return _insertMaxParametersCount / insertParametersCount;
		}

		private Dictionary<string, Guid> GetRelationshipColumnMapping() {
			return new Dictionary<string, Guid> {
				{ "AccountAId", AccountSchemaUId },
				{ "AccountBId", AccountSchemaUId },
				{ "ContactAId", ContactSchemaUId },
				{ "ContactBId", ContactSchemaUId }
			};
		}

		private Select GetRelationshipSelect() {
			return new Select(UserConnection)
				.Column("RelationshipEntityAccountA", "Id").As("AccountAId")
				.Column("RelationshipEntityAccountB", "Id").As("AccountBId")
				.Column("RelationshipEntityContactA", "Id").As("ContactAId")
				.Column("RelationshipEntityContactB", "Id").As("ContactBId")
				.Column("Relationship", "RelationTypeId")
				.Column("Relationship", "ReverseRelationTypeId")
				.Column("Relationship", "Description")
				.Column("RelationTypePosition", "Value")
				.Column("RelationType", "RelationConnectionTypeId").As("RelationConnectionTypeId")
				.From("Relationship", "Relationship")
				.InnerJoin("RelationType").As("RelationType").On("RelationType", "Id").IsEqual("Relationship", "RelationTypeId")
				.InnerJoin("RelationTypePosition").As("RelationTypePosition").On("RelationTypePosition", "Id").IsEqual("RelationType", "PositionId")
				.LeftOuterJoin("RelationshipEntity").As("RelationshipEntityAccountA").On("RelationshipEntityAccountA", "RecordId").IsEqual("Relationship", "AccountAId")
				.LeftOuterJoin("RelationshipEntity").As("RelationshipEntityAccountB").On("RelationshipEntityAccountB", "RecordId").IsEqual("Relationship", "AccountBId")
				.LeftOuterJoin("RelationshipEntity").As("RelationshipEntityContactA").On("RelationshipEntityContactA", "RecordId").IsEqual("Relationship", "ContactAId")
				.LeftOuterJoin("RelationshipEntity").As("RelationshipEntityContactB").On("RelationshipEntityContactB", "RecordId").IsEqual("Relationship", "ContactBId")
				.Where("Relationship", "Active").IsEqual(Column.Parameter(true)) as Select;
		}

		private Select GetRelationshipSelectForCreateEntity(string columnName, Guid schemaUId) {
			return new Select(UserConnection).Distinct().Top(ChunkSize)
				.Column("Relationship", columnName)
				.Column(Column.Parameter(schemaUId)).As("SchemaUId")
				.From("Relationship", "Relationship")
				.Where("Relationship", "Active").IsEqual(Column.Parameter(true))
					.And("Relationship", columnName).Not().IsNull()
					.And().Not().Exists(
						new Select(UserConnection)
						.Column("RelationshipEntity", "Id")
						.From("RelationshipEntity").As("RelationshipEntity")
						.Where("Relationship", columnName).IsEqual("RelationshipEntity", "RecordId") as Select
				 ) as Select;
		}

		private InsertSelect GetRelationshipEntityInsertQuery(Select relationshipQuery) {
			return new InsertSelect(UserConnection)
				.Into("RelationshipEntity")
				.Set(_relationshipColumnNames)
				.FromSelect(relationshipQuery);
		}

		private RelationshipData CreateRelationshipConnectionData(System.Data.IDataReader reader) {
			return new RelationshipData {
				AccountAId = reader.GetColumnValue<Guid>("AccountAId"),
				AccountBId = reader.GetColumnValue<Guid>("AccountBId"),
				ContactAId = reader.GetColumnValue<Guid>("ContactAId"),
				ContactBId = reader.GetColumnValue<Guid>("ContactBId"),
				RelationTypeId = reader.GetColumnValue<Guid>("RelationTypeId"),
				ReverseRelationTypeId = reader.GetColumnValue<Guid>("ReverseRelationTypeId"),
				Position = reader.GetColumnValue<int>("Value"),
				Description = reader.GetColumnValue<string>("Description"),
				ConnectionTypeId = reader.GetColumnValue<Guid>("RelationConnectionTypeId")
			};
		}

		private List<RelationshipData> GetRelationshipConnectionDataList() {
			var relationshipConnectionDataList = new List<RelationshipData>();
			var relationshipSelect = GetRelationshipSelect();
			relationshipSelect.ExecuteReader((reader) => {
				var relationConnectionData = CreateRelationshipConnectionData(reader);
				var recordA = relationConnectionData.GetRecordA();
				var recordB = relationConnectionData.GetRecordB();
				if (recordA.IsEmpty() || recordB.IsEmpty()) {
					return;
				}
				relationshipConnectionDataList.Add(relationConnectionData);
			});
			return relationshipConnectionDataList;
		}

		private void CreateRelationshipConnections(IEnumerable<RelationshipData> relationships) {
			int insertParametersCount = 4;
			int insertChunkSize = GetInsertChunkSize(insertParametersCount);
			var parts = relationships.SplitOnChunks(insertChunkSize);
			parts.ForEach(part => {
				var connectionsInsert = new Insert(UserConnection).Into("RelationshipConnection");
				foreach (var relationship in part) {
					var entityRecords = relationship.GetEntityRecords();
					var comment = relationship.Description.IsNullOrEmpty() ? string.Empty : relationship.Description;
					connectionsInsert.Values()
						.Set("RelationshipEntityAId", Column.Parameter(entityRecords.Item1))
						.Set("RelationshipEntityBId", Column.Parameter(entityRecords.Item2))
						.Set("RelationTypeId", Column.Parameter(relationship.GetRelationType()))
						.Set("Comment", Column.Parameter(comment));
				}
				if (connectionsInsert.ColumnValues.IsNotEmpty()) {
					try {
						connectionsInsert.Execute();
					} catch (SqlException e) {
						_log.ErrorFormat("Error while creating RelationshipConnection: {0}", e.ToString());
					}
				}
			});
		}

		private Dictionary<Guid, List<Guid>> GetDiagramsEntities(List<RelationshipData> relationshipConnections) {
			DiagramsEntitiesBuilder diagramsEntitiesBuilder = new DiagramsEntitiesBuilder(relationshipConnections);
			return diagramsEntitiesBuilder.Build();
		}

		private void CreateRelationEntInDiagram(Dictionary<Guid, List<Guid>> groups) {
			groups.AsParallel().ForEach(group => {
				var relationEntities = group.Value;
				CreateDiagram(group.Key);
				InsertRelationEntitiesInDiagram(relationEntities, group.Key);
			});
		}

		private void InsertRelationEntitiesInDiagram(List<Guid> relationEntities, Guid diagramId) {
			int insertParametersCount = 2;
			int insertChunkSize = GetInsertChunkSize(insertParametersCount);
			var parts = relationEntities.SplitOnChunks(insertChunkSize);
			parts.ForEach(part => {
				var entitiesInDiagramInsert = new Insert(UserConnection).Into("RelationEntInDiagram");
				foreach (var entityId in part) {
					entitiesInDiagramInsert.Values()
						.Set("RelationshipEntityId", Column.Parameter(entityId))
						.Set("RelationshipDiagramId", Column.Parameter(diagramId));
				}
				if (entitiesInDiagramInsert.ColumnValues.IsNotEmpty()) {
					try {
						entitiesInDiagramInsert.Execute();
					} catch (SqlException e) {
						_log.ErrorFormat("Error while creating RelationEntInDiagram: {0}", e.ToString());
					}
				}
			});

		}

		private void CreateDiagram(Guid diagramId) {
			var insertDiagram = new Insert(UserConnection)
				.Into("RelationshipDiagram")
				.Set("Id", Column.Parameter(diagramId));
			insertDiagram.Execute();
		}

		private void TruncateTable(string schemaName) {
			try {
				new Delete(UserConnection)
					.From(schemaName)
					.Execute();
			} catch (SqlException e) {
				_log.ErrorFormat("Error while deleting old data from {0}: {1}", schemaName, e.ToString());
			}
		}

		private void DeleteRelationshipConnection() {
			TruncateTable("RelationshipConnection");
		}

		private void DeleteRelationEntInDiagram() {
			TruncateTable("RelationEntInDiagram");
		}

		private void DeleteRelationEntityInGroup() {
			TruncateTable("RelationEntityInGroup");
		}

		private void DeleteRelationshipEntity() {
			TruncateTable("RelationshipEntity");
		}

		private void DeleteRelationshipDiagram() {
			TruncateTable("RelationshipDiagram");
		}

		private void DeleteTechnicalRelationType() {
			try {
				new Delete(UserConnection)
					.From("RelationType")
					.Where("Id").IsEqual(Column.Parameter(_technicalRelationType))
					.Execute();
			} catch (SqlException e) {
				_log.ErrorFormat("Error while deleting technical data from RelationType: {0}", e.ToString());
			}
		}

		private Select GetContactFormalConnectionSelect() {
			return new Select(UserConnection)
				.Column("RC", "Id").As("Id")
				.Column("RC", "RelationTypeId").As("RelationTypeId")
				.Column("RC", "RelationshipEntityAId").As("RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId").As("RelationshipEntityBId")
				.Column("RC", "Comment").As("Comment")
				.Column(new WindowQueryFunction(
					new RowNumberQueryFunction(),
					new QueryColumnExpression("RC", "RelationshipEntityBId"),
					new QueryColumnExpression("RC", "RelationshipEntityBId")
				)).As("RowNumber")
				.From("RelationshipConnection").As("RC")
				.InnerJoin("RelationType").As("RT").On("RT", "Id").IsEqual("RC", "RelationTypeId")
				.InnerJoin("RelationshipEntity").As("REA").On("REA", "Id").IsEqual("RC", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("REB").On("REB", "Id").IsEqual("RC", "RelationshipEntityBId")
				.Where("RT", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
					.And("REA", "SchemaUId").IsEqual(Column.Parameter(AccountSchemaUId))
					.And("REB", "SchemaUId").IsEqual(Column.Parameter(ContactSchemaUId)) as Select;
		}

		private List<RelationshipConnectionData> GetContactMultiAccountFormalConnections() {
			var relationshipConnectionData = new List<RelationshipConnectionData>();
			var rowNumberSelect = GetContactFormalConnectionSelect();
			var connectionsSelect = new Select(UserConnection)
				.Column("InnerRC", "Id")
				.Column("InnerRC", "RelationTypeId")
				.Column("InnerRC", "RelationshipEntityAId")
				.Column("InnerRC", "RelationshipEntityBId")
				.Column("InnerRC", "Comment")
				.From(rowNumberSelect).As("InnerRC")
				.Where("InnerRC", "RowNumber").IsGreater(Column.Parameter(1)) as Select;
			connectionsSelect.ExecuteReader((reader) => {
				var relationConnectionData = GetRelationshipConnectionData(reader);
				relationshipConnectionData.Add(relationConnectionData);
			});
			return relationshipConnectionData;
		}

		private List<RelationshipConnectionData> GetBeetwenContactAndAccountFormalConnections() {
			var relationshipConnectionData = new List<RelationshipConnectionData>();
			var connectionsSelect = new Select(UserConnection)
				.Column("RC", "Id")
				.Column("RC", "RelationTypeId")
				.Column("RC", "RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId")
				.Column("RC", "Comment")
				.From("RelationshipConnection").As("RC")
				.LeftOuterJoin("RelationType").As("RT")
					.On("RC", "RelationTypeId").IsEqual("RT", "Id")
				.LeftOuterJoin("RelationshipEntity").As("RE1")
					.On("RC", "RelationshipEntityAId").IsEqual("RE1", "Id")
				.LeftOuterJoin("RelationshipEntity").As("RE2")
					.On("RC", "RelationshipEntityBId").IsEqual("RE2", "Id")
				.Where("RT", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
					.And().OpenBlock()
						.OpenBlock("RE1", "SchemaUId").IsEqual(Column.Parameter(AccountSchemaUId))
							.And("RE2", "SchemaUId").IsEqual(Column.Parameter(ContactSchemaUId)).CloseBlock()
						.Or().OpenBlock("RE1", "SchemaUId").IsEqual(Column.Parameter(ContactSchemaUId))
							.And("RE2", "SchemaUId").IsEqual(Column.Parameter(AccountSchemaUId)).CloseBlock()
					.CloseBlock() as Select;
			connectionsSelect.ExecuteReader((reader) => {
				var relationConnectionData = GetRelationshipConnectionData(reader);
				relationshipConnectionData.Add(relationConnectionData);
			});
			return relationshipConnectionData;
		}

		private List<RelationshipConnectionData> GetBeetwenContactsFormalConnections() {
			var relationshipConnectionData = new List<RelationshipConnectionData>();
			var connectionsSelect = new Select(UserConnection)
				.Column("RC", "Id")
				.Column("RC", "RelationTypeId")
				.Column("RC", "RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId")
				.Column("RC", "Comment")
				.From("RelationshipConnection").As("RC")
				.LeftOuterJoin("RelationType").As("RT")
					.On("RC", "RelationTypeId").IsEqual("RT", "Id")
				.LeftOuterJoin("RelationshipEntity").As("RE1")
					.On("RC", "RelationshipEntityAId").IsEqual("RE1", "Id")
				.LeftOuterJoin("RelationshipEntity").As("RE2")
					.On("RC", "RelationshipEntityBId").IsEqual("RE2", "Id")
				.Where("RT", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
					.And("RE1", "SchemaUId").IsEqual(Column.Parameter(ContactSchemaUId))
					.And("RE2", "SchemaUId").IsEqual(Column.Parameter(ContactSchemaUId)) as Select;
			connectionsSelect.ExecuteReader((reader) => {
				var relationConnectionData = GetRelationshipConnectionData(reader);
				relationshipConnectionData.Add(relationConnectionData);
			});
			return relationshipConnectionData;
		}

		private RelationshipConnectionData GetRelationshipConnectionData(System.Data.IDataReader reader) {
			return new RelationshipConnectionData {
				Id = reader.GetColumnValue<Guid>("Id"),
				RelationTypeId = reader.GetColumnValue<Guid>("RelationTypeId"),
				EntityAId = reader.GetColumnValue<Guid>("RelationshipEntityAId"),
				EntityBId = reader.GetColumnValue<Guid>("RelationshipEntityBId"),
				Comment = reader.GetColumnValue<string>("Comment")
			};
		}

		private EntitySchemaQuery GetRelationType(List<Guid> relationTypes) {
			var relationTypeEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "RelationType");
			relationTypeEsq.UseAdminRights = false;
			relationTypeEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			relationTypeEsq.AddColumn("Name");
			relationTypeEsq.Filters.Add(relationTypeEsq.CreateFilterWithParameters(
				FilterComparisonType.Equal, "Id", relationTypes.Cast<object>().ToArray()));
			return relationTypeEsq;
		}

		private List<Guid> GetRelationTypes(List<RelationshipConnectionData> connections) {
			return connections
				.Select(entity => entity.RelationTypeId)
				.Distinct()
				.ToList();
		}

		private List<Guid> GetRelationTypes(List<RelationshipEntityConnection> connections) {
			return connections
				.Select(entity => entity.RelationshipType)
				.Distinct()
				.ToList();
		}

		private Dictionary<Guid, string> GetLocalizableRelationTypes(List<Guid> relationTypes) {
			relationTypes.Add(_technicalRelationType);
			var relationTypeEsq = GetRelationType(relationTypes);
			var relationTypeCollection = relationTypeEsq.GetEntityCollection(UserConnection);
			return relationTypeCollection.Any() ?
				relationTypeCollection.ToDictionary(type => type.PrimaryColumnValue, type => type.GetTypedColumnValue<string>("Name")) :
				new Dictionary<Guid, string>();
		}

		private void UpdateRelationshipConnectionsToTechnicalType(string comment, IEnumerable<RelationshipConnectionData> relationships) {
			var relationshipIds = relationships.Select(rel => rel.Id).ToArray();
			try {
				comment = comment.IsNullOrEmpty() ? string.Empty : comment;
				var updateConnection = new Update(UserConnection, "RelationshipConnection")
					.Set("RelationTypeId", Column.Parameter(_technicalRelationType))
					.Set("Comment", Column.Parameter(comment)).Where("Id")
					.In(Column.Parameters(relationshipIds)) as Update;
				updateConnection.Execute();
			} catch (SqlException e) {
				_log.ErrorFormat("Error while updating RelationshipConnections data: {0}", e.ToString());
			}
		}

		private void BulkUpdateRelationshipConnectionsToTechnicalType(List<RelationshipConnectionData> connections) {
			var uniqueRelationTypes = GetRelationTypes(connections);
			var relationTypes = GetLocalizableRelationTypes(uniqueRelationTypes);
			var groupConnectionsByType = connections
				.AsParallel()
				.GroupBy(connection => connection.RelationTypeId);

			foreach (var connectionsTypeGroup in groupConnectionsByType) {
				var previousRelationType = relationTypes[connectionsTypeGroup.Key];
				var connectionsComment = GetTechnicalRelationTypeComment(previousRelationType);
				var groupConnectionsByComment = connectionsTypeGroup
					.AsParallel()
					.GroupBy(connection => connection.Comment);
				foreach (var connectionsCommentGroup in groupConnectionsByComment) {
					var connection = connectionsCommentGroup.First();
					var currentComment = $"{connectionsComment} {connection.Comment}".Trim();
					var parts = connectionsCommentGroup.SplitOnChunks(ChunkSize).ToList();
					Parallel.For(0, parts.Count(), i => {
						UpdateRelationshipConnectionsToTechnicalType(currentComment, parts[i]);
					});
				}
			}
		}

		private string GetTechnicalRelationTypeComment(string previousRelationType) {
			var template = GetLocalizableString("UpdateTechnicalRelationTypeMessageTemplate");
			var comment = string.Format(template, previousRelationType);
			return comment;
		}

		private void ReplaceContactMultiAccountFormalConnections() {
			var entityConnection = GetContactMultiAccountFormalConnections();
			if (entityConnection.Any()) {
				InitializeTechnicalRelationType();
				BulkUpdateRelationshipConnectionsToTechnicalType(entityConnection);
			}
		}

		private void ReplaceBetweenContactsFormalConnections() {
			var processedConnections = GetProcessedBetweenContactsFormalConnections();
			if (processedConnections.Any()) {
				InitializeTechnicalRelationType();
				BulkUpdateRelationshipConnectionsToTechnicalType(processedConnections);
			}
		}

		private List<RelationshipConnectionData> GetProcessedBetweenContactsFormalConnections() {
			var processingConnections = GetBeetwenContactsFormalConnections();
			var connectionsBetweenContactAndAccount = GetBeetwenContactAndAccountFormalConnections();
			var connectionsBetweenContactAndAccountPairs = connectionsBetweenContactAndAccount
				.ToLookup(connection => connection.EntityAId, connection => connection.EntityBId);
			processingConnections = processingConnections
				.AsParallel()
				.Where(processingConnection => {
					var entityAId = processingConnection.EntityAId;
					var entityBId = processingConnection.EntityBId;
					var areContactsInOneAccount = connectionsBetweenContactAndAccountPairs
						.Where(pair => {
							var connectedEntityList = pair.Select(entityId => entityId).ToList();
							return connectedEntityList.Contains(entityAId) && connectedEntityList.Contains(entityBId);
						})
						.Any();
					return !areContactsInOneAccount;
				})
				.ToList();
			return processingConnections;
		}

		private void InitializeTechnicalRelationType() {
			if (!IsTechnicalRelationTypeExist()) {
				CreateTechnicalRelationType();
			}
		}

		private bool IsTechnicalRelationTypeExist() {
			Select select = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("RelationType")
				.Where("Id").IsEqual(Column.Parameter(_technicalRelationType)) as Select;
			return select.ExecuteScalar<int>() > 0;
		}

		private void CreateTechnicalRelationType() {
			try {
				var typeName = GetLocalizableString("TechnicalRelationTypeCaption");
				Insert insert = new Insert(UserConnection).Into("RelationType");
				insert
					.Set("Id", Column.Parameter(_technicalRelationType))
					.Set("Name", Column.Parameter(typeName))
					.Set("PositionId", Column.Parameter(_relationPositionDirect))
					.Set("RelationConnectionTypeId", Column.Parameter(_relationConnectionTypeNotFormal));
				insert.Execute();
			} catch (SqlException e) {
				_log.ErrorFormat("Error while inserting technical data to RelationType: {0}", e.ToString());
			}
		}

		private List<RelationshipEntityConnection> GetDiagramLoopingConnection(List<RelationshipEntityConnection> connections) {
			var result = new List<RelationshipEntityConnection>();
			var groupCollection = connections
				.AsParallel()
				.GroupBy(connection => connection.RelationshipRecordA.SchemaUId);
			groupCollection.ForEach(group => {
				var loopConnection = FindLoopingConnection(group);
				if (loopConnection.Any()) {
					result.AddRange(loopConnection);
				}
			});
			return result;
		}

		private List<RelationshipEntityConnection> FindLoopingConnection(IEnumerable<RelationshipEntityConnection> connections) {
			var diagramValidator = ClassFactory.Get<RelationshipDiagramLoopingValidator>();
			return diagramValidator.ValidateDiagram(connections.ToList());
		}

		private List<RelationshipEntityConnection> PrepareComment(List<RelationshipEntityConnection> connections) {
			if (connections.Any()) {
				InitializeTechnicalRelationType();
				var messageTemplate = GetLocalizableString("UpdateLoopConnectionMessageTemplate");
				var uniqueRelationTypes = GetRelationTypes(connections);
				var relationTypes = GetLocalizableRelationTypes(uniqueRelationTypes);
				foreach (var item in connections) {
					relationTypes.TryGetValue(item.RelationshipType, out var prevType);
					var comment = string.Format(messageTemplate, prevType);
					item.RelationshipType = _technicalRelationType;
					item.RelationshipType = _technicalRelationType;
					item.Comment = $"{comment} {item.Comment}";
				}
			}
			return connections;
		}

		private void HandleLoopingItems() {
			var connections = GetRelationshipEntityConnections();
			var resultLoopCollection = new List<RelationshipEntityConnection>();
			var groupByDiagram = connections
				.AsParallel()
				.GroupBy(connection => connection.DiagramId);

			foreach (var group in groupByDiagram) {
				var relationshipEntityConnections = GetDiagramLoopingConnection(group.ToList());
				if (relationshipEntityConnections.Any()) {
					resultLoopCollection.AddRange(relationshipEntityConnections);
				}
			}
			UpdateConnections(resultLoopCollection);
		}

		private void UpdateConnections(List<RelationshipEntityConnection> connections) {
			if (!connections.Any()) {
				return;
			}
			connections = PrepareComment(connections);
			Parallel.ForEach(connections, connection => {
				var update = GetRelationshipConnectionUpdate(connection);
				update.Execute();
			});
		}

		private Update GetRelationshipConnectionUpdate(RelationshipEntityConnection connection) {
			return new Update(UserConnection, "RelationshipConnection")
					.Set("RelationTypeId", Column.Parameter(connection.RelationshipType))
					.Set("Comment", Column.Parameter(connection.Comment)).Where("Id")
					.In(Column.Parameters(connection.Id)) as Update;
		}

		private Select GetFormalRelationshipConnectionSelect() {
			return new Select(UserConnection)
				.Column("RC", "Id").As("Id")
				.Column("RC", "RelationTypeId").As("RelationTypeId")
				.Column("RC", "RelationshipEntityAId").As("RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId").As("RelationshipEntityBId")
				.Column("RT", "RelationConnectionTypeId").As("RelationConnectionTypeId")
				.Column("REA", "SchemaUId").As("SchemaUId")
				.Column("RED", "RelationshipDiagramId").As("RelationshipDiagramId")
				.From("RelationshipConnection").As("RC")
				.InnerJoin("RelationType").As("RT").On("RT", "Id").IsEqual("RC", "RelationTypeId")
				.InnerJoin("RelationEntInDiagram").As("RED").On("RED", "RelationshipEntityId").IsEqual("RC", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("REA").On("REA", "Id").IsEqual("RC", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("REB").On("REB", "Id").IsEqual("RC", "RelationshipEntityBId")
				.Where("RT", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
					.And("REA", "SchemaUId").IsEqual("REB", "SchemaUId") as Select;
		}

		private List<RelationshipEntityConnection> GetRelationshipEntityConnections() {
			Select relationshipSelect = GetFormalRelationshipConnectionSelect();
			var relationConnections = new List<RelationshipEntityConnection>();
			relationshipSelect.ExecuteReader((reader) => {
				var connection = CreateRelationshipEntityConnection(reader);
				relationConnections.Add(connection);
			});
			return relationConnections;
		}

		private RelationshipEntityConnection CreateRelationshipEntityConnection(System.Data.IDataReader reader) {
			return new RelationshipEntityConnection {
				Id = reader.GetColumnValue<Guid>("Id"),
				RelationshipType = reader.GetColumnValue<Guid>("RelationTypeId"),
				RelationshipEntityA = reader.GetColumnValue<Guid>("RelationshipEntityAId"),
				RelationshipEntityB = reader.GetColumnValue<Guid>("RelationshipEntityBId"),
				RelationshipConnectionType = reader.GetColumnValue<Guid>("RelationConnectionTypeId"),
				DiagramId = reader.GetColumnValue<Guid>("RelationshipDiagramId"),
				RelationshipRecordA = new RelationshipRecord {
					SchemaUId = reader.GetColumnValue<Guid>("SchemaUId")
				}
			};
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Bulk create entity connections.
		/// </summary>
		protected bool BulkCreateRelationshipConnections(List<RelationshipData> relationshipConnections) {
			var parts = new List<IEnumerable<RelationshipData>>(relationshipConnections.SplitOnChunks(ChunkSize));
			Parallel.For(0, parts.Count(), i => {
				CreateRelationshipConnections(parts[i]);
			});
			return true;
		}

		/// <summary>
		/// Create relationship diagram entity records.
		/// </summary>
		protected void CreateRelationshipEntity() {
			var columnMapping = GetRelationshipColumnMapping();
			foreach (var item in columnMapping) {
				bool needInsert = true;
				var selectQuery = GetRelationshipSelectForCreateEntity(item.Key, item.Value);
				while (needInsert) {
					try {
						var insertQuery = GetRelationshipEntityInsertQuery(selectQuery);
						var recordCount = insertQuery.Execute();
						needInsert = recordCount == ChunkSize;
					} catch (SqlException e) {
						_log.ErrorFormat("Error while creating RelationshipEntity: {0}", e.ToString());
					}
				}
			}
		}

		/// <summary>
		/// Clear relationship diagram tables.
		/// </summary>
		protected void ClearRelationDiagramRecords() {
			DeleteRelationshipConnection();
			DeleteRelationEntInDiagram();
			DeleteRelationEntityInGroup();
			DeleteRelationshipEntity();
			DeleteRelationshipDiagram();
			DeleteTechnicalRelationType();
		}

		/// <summary>
		/// Validate relationship connection.
		/// </summary>
		protected void ValidateRelationshipConnections() {
			ReplaceContactMultiAccountFormalConnections();
			ReplaceBetweenContactsFormalConnections();
			HandleLoopingItems();
		}

		/// <summary>
		/// Prepare custom relation types.
		/// </summary>
		protected void PrepareCustomRelationTypes() {
			var update = new Update(UserConnection, "RelationType")
				.Set("RelationConnectionTypeId", Column.Parameter(_relationConnectionTypeNotFormal))
				.Set("PositionId", Column.Parameter(_relationPositionHorizontal))
				.Where("RelationConnectionTypeId").IsNull()
					.And("PositionId").IsNull() as Update;
			update.Execute();
		}

		/// <summary>
		/// Create relationship connections and
		/// splitting the collection into diagrams.
		/// </summary>
		protected void CreateRelationshipDesignerRecords() {
			CreateRelationshipEntity();
			var relationDataList = GetRelationshipConnectionDataList();
			var diagramGroups = GetDiagramsEntities(relationDataList);
			CreateRelationEntInDiagram(diagramGroups);
			BulkCreateRelationshipConnections(relationDataList);
			RemoveAloneRelationshipEntities();
		}

		/// <summary>
		/// Removes alone entities.
		/// </summary>
		protected void RemoveAloneRelationshipEntities() {
			try {
				var subSelect = new Select(UserConnection).From("RelationEntInDiagram")
					.Column("RelationshipEntityId");
				var delete = new Delete(UserConnection).From("RelationshipEntity")
					.Where("Id").Not().In(subSelect);
				delete.Execute();
			} catch (SqlException e) {
				_log.ErrorFormat("Error while delete alone RelationshipEntity: {0}", e.ToString());
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Start migration data.
		/// </summary>
		public void StartMigration() {
			_log.Info("Migration started");
			ClearRelationDiagramRecords();
			PrepareCustomRelationTypes();
			CreateRelationshipDesignerRecords();
			ValidateRelationshipConnections();
			_log.Info("Migration finished");
		}

		#endregion

	}

	#endregion

}

