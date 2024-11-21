namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: RelationshipRecord

	[DataContract]
	public class RelationshipRecord
	{

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "schemaName")]
		public string EntitySchemaName {
			get; set;
		}

		public Guid SchemaUId {
			get; set;
		}
	}

	#endregion

	#region Class: RelationshipEntityConnection

	[DataContract]
	public class RelationshipEntityConnection
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier entity connection.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		/// <summary>
		/// Unique identifier relationship diagram.
		/// </summary>
		[DataMember(Name = "diagramId")]
		public Guid DiagramId {
			get; set;
		}

		/// <summary>
		/// Record a.
		/// </summary>
		[DataMember(Name = "relationshipRecordA")]
		public RelationshipRecord RelationshipRecordA {
			get; set;
		}

		/// <summary>
		/// Record b.
		/// </summary>
		[DataMember(Name = "relationshipRecordB")]
		public RelationshipRecord RelationshipRecordB {
			get; set;
		}

		/// <summary>
		/// Label caption.
		/// </summary>
		[DataMember(Name = "labelCaption")]
		public string LabelCaption {
			get; set;
		}

		/// <summary>
		/// Comment.
		/// </summary>
		[DataMember(Name = "comment")]
		public string Comment {
			get; set;
		}

		/// <summary>
		/// Unique identifier of the RelationshipConnectionType.
		/// </summary>
		[DataMember(Name = "connectionType")]
		public Guid RelationshipConnectionType {
			get; set;
		}

		/// <summary>
		/// Unique identifier of the RelationshipType.
		/// </summary>
		[DataMember(Name = "relationshipType")]
		public Guid RelationshipType {
			get; set;
		}

		/// <summary>
		/// Unique identifier of the RelationshipEntity.
		/// </summary>
		public Guid RelationshipEntityA {
			get; set;
		}

		/// <summary>
		/// Unique identifier of the RelationshipEntity.
		/// </summary>
		public Guid RelationshipEntityB {
			get; set;
		}

		/// <summary>
		/// IncludeIntoContainer field.
		/// </summary>
		public bool IncludeIntoContainer {
			get; set;
		}

		#endregion

		#region Methods: Public

		public void SetEntities(Guid parentRecordId, Guid childEntityId, bool invertRecord = false) {
			this.RelationshipEntityA = invertRecord ? childEntityId : parentRecordId;
			this.RelationshipEntityB = invertRecord ? parentRecordId : childEntityId;
			if (invertRecord) {
				var relationRecordA = this.RelationshipRecordA;
				this.RelationshipRecordA = this.RelationshipRecordB;
				this.RelationshipRecordB = relationRecordA;
			}
		}

		public bool IsEmptyRelationshipEntity() {
			return RelationshipEntityA.Equals(Guid.Empty) && RelationshipEntityB.Equals(Guid.Empty);
		}

		public bool IsEntitySchemaEquals() {
			return RelationshipRecordA.EntitySchemaName.Equals(RelationshipRecordB.EntitySchemaName);
		}

		public bool IsEntityConnected(Guid entityId) {
			return RelationshipEntityA.Equals(entityId) || RelationshipEntityB.Equals(entityId);
		}

		public Guid GetConnectedRecord(Guid entityId) {
			return RelationshipEntityA.Equals(entityId) ? RelationshipEntityB : RelationshipEntityA;
		}

		#endregion

	}

	#endregion

	#region Class: RelationConnectionResult

	public class RelationConnectionResult
	{
		public Guid RelatedEntityAId {
			get; set;
		}
		public Guid RelatedTypeId {
			get; set;
		}
	}



	#endregion

	#region Class: CreateRelationshipEntityAndDiagramResult

	public class CreateRelationshipEntityAndDiagramResult
	{

		public CreateRelationshipEntityAndDiagramResult(Guid createdEntityId, Guid createdDiagramId) {
			CreatedEntityId = createdEntityId;
			CreatedDiagramId = createdDiagramId;
		}

		public Guid CreatedEntityId {
			get;
		}

		public Guid CreatedDiagramId {
			get;
		}

	}

	#endregion

	#region Interface: IRelationshipDiagramManager

	public interface IRelationshipDiagramManager
	{
		void DeleteEntity(Guid recordId);

		void DeleteEntityByRecordId(Guid recordId);

		void CreateConnection(RelationshipEntityConnection entityConnection);

		void UpdateConnection(RelationshipEntityConnection entityConnection);

		void DeleteConnection(Guid connectionId);

		Guid CreateDiagram();

		CreateRelationshipEntityAndDiagramResult CreateRelationshipEntityAndDiagramForRecord(Guid recordId, string schemaName);

		Dictionary<string, object> GetRecordEntityInfo(Guid entityId);

	}

	#endregion

	#region Class: RelationshipDiagramManager

	[DefaultBinding(typeof(IRelationshipDiagramManager))]
	public class RelationshipDiagramManager : IRelationshipDiagramManager
	{
		private IRelationshipDiagramConfigProvider _diagramConfigProvider;
		private IRelationshipDiagramBuilder _diagramBuilder;
		private RelationshipDiagramLoopingValidator _relationshipDiagramValidator;
		private readonly string _exceptionAlreadyExistWithThisType = "The relationship with the same type already exists.";
		private readonly string _exceptionRecordAlreadyExistsInAnotherContainer = "The relationship cannot be established.";
		private readonly string _entitySchemaAccountName = "Account";
		private readonly string _entitySchemaContactName = "Contact";
		private readonly Guid _relationConnectionTypeFormal = RelationshipDesignerConstants.RelationTypeConnectionType_Formal;

		public RelationshipDiagramManager(UserConnection userConnection) {
			UserConnection = userConnection;
			_exceptionAlreadyExistWithThisType = UserConnection.GetLocalizableString(GetType().Name, "AlreadyExistWithThisTypeExceptionMessage");
			_exceptionRecordAlreadyExistsInAnotherContainer = UserConnection.GetLocalizableString(GetType().Name, "RecordAlreadyExistsInAnotherContainerExceptionMessage");
		}

		private UserConnection UserConnection {
			get; set;
		}

		public IRelationshipDiagramConfigProvider DiagramConfigProvider =>
			_diagramConfigProvider ?? (_diagramConfigProvider = ClassFactory.Get<RelationshipDiagramConfigProvider>());

		public RelationshipDiagramLoopingValidator DiagramValidator =>
			_relationshipDiagramValidator ?? (_relationshipDiagramValidator = ClassFactory.Get<RelationshipDiagramLoopingValidator>());

		public IRelationshipDiagramBuilder DiagramBuilder =>
			_diagramBuilder ?? (_diagramBuilder = ClassFactory.Get<IRelationshipDiagramBuilder>(
				new ConstructorArgument("userConnection", UserConnection)));

		private Guid GetReverseRelationshipType(Guid relationshipTypeId) {
			var select = new Select(UserConnection)
				.Column("ReverseRelationTypeId")
				.From("RelationType")
				.Where("Id").IsEqual(Column.Parameter(relationshipTypeId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		private bool GetIncludeIntoContainerRelationshipType(Guid relationshipTypeId) {
			var select = new Select(UserConnection)
				.Column("IncludeIntoContainer")
				.From("RelationType")
				.Where("Id").IsEqual(Column.Parameter(relationshipTypeId)) as Select;
			return select.ExecuteScalar<bool>();
		}

		private Guid GetConnectionTypeByRelationType(Guid relationshipTypeId) {
			var select = new Select(UserConnection)
				.Column("RelationConnectionTypeId")
				.From("RelationType")
				.Where("Id").IsEqual(Column.Parameter(relationshipTypeId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		private int GetRelationTypePosition(Guid relationshipTypeId) {
			var positionSelect = new Select(UserConnection)
				.Column("RelationTypePosition", "Value").As("PositionValue")
				.From("RelationTypePosition")
				.InnerJoin("RelationType")
					.On("RelationType", "PositionId")
					.IsEqual("RelationTypePosition", "Id")
				.Where("RelationType", "Id").IsEqual(Column.Parameter(relationshipTypeId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = positionSelect.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						return reader.GetColumnValue<int>("PositionValue");
					}
				}
			}
			return -1;
		}

		private bool NeedChangePosition(Guid relationshipTypeId) {
			var relationshipTypePosition = GetRelationTypePosition(relationshipTypeId);
			return relationshipTypePosition == 1;
		}

		private RelationshipEntityConnection SetEntityRecords(RelationshipEntityConnection entityConnection) {
			if (!entityConnection.IsEmptyRelationshipEntity()) {
				return entityConnection;
			}
			var parentEntityId = CreateRelationshipEntity(entityConnection.RelationshipRecordA);
			var childEntityId = CreateRelationshipEntity(entityConnection.RelationshipRecordB);
			var invertRecords = NeedChangePosition(entityConnection.RelationshipType);
			if (invertRecords) {
				entityConnection.RelationshipType = GetReverseRelationshipType(entityConnection.RelationshipType);
			}
			entityConnection.IncludeIntoContainer = GetIncludeIntoContainerRelationshipType(entityConnection.RelationshipType);
			entityConnection.RelationshipConnectionType = GetConnectionTypeByRelationType(entityConnection.RelationshipType);
			entityConnection.SetEntities(parentEntityId, childEntityId, invertRecords);
			return entityConnection;
		}

		private Select GetRelationConnectionSelect(Guid entityAId, Guid entityBId, Guid connectionTypeId, Guid primaryConnectionId = default(Guid)) {
			var relationTypeSubselect = GetRelationTypeSelectByConnectionType(connectionTypeId);
			var relationSelect = new Select(UserConnection).Top(1)
				.Column("Id")
				.From("RelationshipConnection")
				.Where("RelationshipEntityAId").IsEqual(Column.Parameter(entityAId))
				.And("RelationshipEntityBId").IsEqual(Column.Parameter(entityBId))
				.And("RelationTypeId").In(relationTypeSubselect) as Select;
			if (!primaryConnectionId.Equals(Guid.Empty)) {
				relationSelect.And("Id").IsNotEqual(Column.Parameter(primaryConnectionId));
			}
			return relationSelect;
		}

		private Guid GetRelationshipConnection(Guid recordAId, Guid recordBId, Guid connectionTypeId, Guid primaryRecordId = default(Guid)) {
			var relationSelectA = GetRelationConnectionSelect(recordAId, recordBId, connectionTypeId, primaryRecordId);
			var selectAResult = relationSelectA.ExecuteScalar<Guid>();
			if (!selectAResult.Equals(Guid.Empty)) {
				return selectAResult;
			}
			var relationSelectB = GetRelationConnectionSelect(recordBId, recordAId, connectionTypeId, primaryRecordId);
			return relationSelectB.ExecuteScalar<Guid>();
		}


		private void SaveConnectionEntity(RelationshipEntityConnection entityConnection, Entity connection) {
			connection.SetColumnValue("RelationshipEntityAId", entityConnection.RelationshipEntityA);
			connection.SetColumnValue("RelationshipEntityBId", entityConnection.RelationshipEntityB);
			connection.SetColumnValue("Name", entityConnection.LabelCaption);
			connection.SetColumnValue("RelationTypeId", entityConnection.RelationshipType);
			connection.SetColumnValue("Comment", entityConnection.Comment);
			connection.Save();
		}

		private Guid GetParentEntityConnection(Guid relationshipEntityId, string parentEntityConnectionName, bool includeIntoContainer = true) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(parentEntityConnectionName);
			var relationSelect = new Select(UserConnection).Top(1)
				.Column("RelationshipConnection", "RelationshipEntityAId")
				.From("RelationshipConnection").As("RelationshipConnection")
				.InnerJoin("RelationshipEntity").As("RelationshipEntity").On("RelationshipEntity", "Id").IsEqual("RelationshipConnection", "RelationshipEntityAId")
				.InnerJoin("RelationType").As("RelationType").On("RelationType", "Id").IsEqual("RelationshipConnection", "RelationTypeId")
				.Where("RelationshipEntityBId").IsEqual(Column.Parameter(relationshipEntityId))
				.And("RelationshipEntity", "SchemaUId").IsEqual(Column.Parameter(entitySchema.UId))
				.And("RelationType", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
				.And("RelationType", "IncludeIntoContainer").IsEqual(Column.Parameter(includeIntoContainer)) as Select;
			return relationSelect.ExecuteScalar<Guid>();
		}

		private RelationConnectionResult GetParentEntityWithConnectionType(Guid relationshipEntityId, string parentEntityConnectionName) {
			var relationConnectionResult = new RelationConnectionResult();
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(parentEntityConnectionName);
			var relationSelect = new Select(UserConnection).Top(1)
				.Column("RelationshipConnection", "RelationTypeId")
				.Column("RelationshipConnection", "RelationshipEntityAId")
				.From("RelationshipConnection").As("RelationshipConnection")
				.InnerJoin("RelationshipEntity").As("RelationshipEntity").On("RelationshipEntity", "Id").IsEqual("RelationshipConnection", "RelationshipEntityAId")
				.InnerJoin("RelationType").As("RelationType").On("RelationType", "Id").IsEqual("RelationshipConnection", "RelationTypeId")
				.Where("RelationshipEntityBId").IsEqual(Column.Parameter(relationshipEntityId))
				.And("RelationshipEntity", "SchemaUId").IsEqual(Column.Parameter(entitySchema.UId))
				.And("RelationType", "IncludeIntoContainer").IsEqual(Column.Parameter(true)) as Select;
			relationSelect.ExecuteReader(reader => {
				relationConnectionResult.RelatedEntityAId = reader.GetColumnValue<Guid>("RelationshipEntityAId");
				relationConnectionResult.RelatedTypeId = reader.GetColumnValue<Guid>("RelationTypeId");
			});
			return relationConnectionResult;
		}

		private bool IsExistEntityConnection(RelationshipEntityConnection entityConnection) {
			var connectionId = GetRelationshipConnection(entityConnection.RelationshipEntityA, entityConnection.RelationshipEntityB,
				entityConnection.RelationshipConnectionType, entityConnection.Id);
			return !connectionId.Equals(Guid.Empty);
		}

		private void CheckContactExistInAnotherAccount(RelationshipEntityConnection entityConnection) {
			Guid relatedEntityId = GetParentEntityConnection(entityConnection.RelationshipEntityB, _entitySchemaAccountName);
			if (!relatedEntityId.Equals(Guid.Empty) && !relatedEntityId.Equals(entityConnection.RelationshipEntityA)) {
				ThrowException(_exceptionRecordAlreadyExistsInAnotherContainer);
			}
			var formalAccountConnectionId = GetParentEntityConnection(
				entityConnection.RelationshipEntityB, _entitySchemaAccountName, false);
			if (!formalAccountConnectionId.Equals(Guid.Empty) &&
					!formalAccountConnectionId.Equals(entityConnection.RelationshipEntityA) &&
					GetIncludeIntoContainerRelationshipType(entityConnection.RelationshipType)) {
				ThrowException(_exceptionRecordAlreadyExistsInAnotherContainer);
			}
		}

		private bool IsFormalConnection(RelationshipEntityConnection entityConnection) {
			return entityConnection.RelationshipConnectionType.Equals(_relationConnectionTypeFormal);
		}

		private bool CheckRecordsEqual(Guid recordA, Guid recordB) {
			return !recordA.Equals(Guid.Empty) && !recordB.Equals(Guid.Empty) && !recordA.Equals(recordB);
		}

		private RelationConnectionResult GetParentConnectionResult(RelationshipEntityConnection entityConnection) {
			RelationConnectionResult connectionEntityA = GetParentEntityWithConnectionType(entityConnection.RelationshipEntityA, _entitySchemaAccountName);
			RelationConnectionResult connectionEntityB = GetParentEntityWithConnectionType(entityConnection.RelationshipEntityB, _entitySchemaAccountName);
			if (CheckRecordsEqual(connectionEntityA.RelatedEntityAId, connectionEntityB.RelatedEntityAId) && IsFormalConnection(entityConnection)) {
				ThrowException(_exceptionRecordAlreadyExistsInAnotherContainer);
			}
			return connectionEntityA.RelatedEntityAId.Equals(Guid.Empty) ?
				connectionEntityB :
				connectionEntityA;
		}

		private void AddParentRelationshipConnection(RelationshipEntityConnection entityConnection) {
			var result = GetParentConnectionResult(entityConnection);
			if (!result.RelatedEntityAId.Equals(Guid.Empty) && entityConnection.IncludeIntoContainer) {
				var relationshipEntityAConnection = new RelationshipEntityConnection {
					RelationshipEntityA = result.RelatedEntityAId,
					RelationshipEntityB = entityConnection.RelationshipEntityA,
					RelationshipConnectionType = _relationConnectionTypeFormal,
					RelationshipType = result.RelatedTypeId
				};
				if (!IsExistEntityConnection(relationshipEntityAConnection)) {
					AddRelationshipConnectionEntity(relationshipEntityAConnection);
				}
				var relationshipEntityBConnection = new RelationshipEntityConnection {
					RelationshipEntityA = result.RelatedEntityAId,
					RelationshipEntityB = entityConnection.RelationshipEntityB,
					RelationshipConnectionType = _relationConnectionTypeFormal,
					RelationshipType = result.RelatedTypeId
				};
				if (!IsExistEntityConnection(relationshipEntityBConnection)) {
					AddRelationshipConnectionEntity(relationshipEntityBConnection);
				}
			} else if (result.RelatedEntityAId.Equals(Guid.Empty) && IsFormalConnection(entityConnection)) {
				ThrowException(_exceptionRecordAlreadyExistsInAnotherContainer);
			}
		}

		public Guid AddContactRelationshipConnection(RelationshipEntityConnection entityConnection) {
			if (IsAccountContactConnection(entityConnection) && IsFormalConnection(entityConnection)) {
				CheckContactExistInAnotherAccount(entityConnection);
			} else if (IsContactContactConnection(entityConnection)) {
				AddParentRelationshipConnection(entityConnection);
			}
			return AddRelationshipConnectionEntity(entityConnection);
		}

		private Guid AddRelationshipConnectionEntity(RelationshipEntityConnection entityConnection) {
			var relationshipConnectionEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("RelationshipConnection");
			var relationshipConnectionEntity = relationshipConnectionEntitySchema.CreateEntity(UserConnection);
			relationshipConnectionEntity.SetDefColumnValues();
			SaveConnectionEntity(entityConnection, relationshipConnectionEntity);
			return relationshipConnectionEntity.PrimaryColumnValue;
		}

		private void ThrowException(string errorMessage) {
			throw new Exception(errorMessage);
		}

		private Select GetFormalRelationshipConnectionSelect(Guid schemaUId, Guid diagramId) {
			return new Select(UserConnection)
				.Column("RelationshipConnection", "Id").As("Id")
				.Column("RelationshipConnection", "RelationTypeId").As("RelationTypeId")
				.Column("RelationshipConnection", "RelationshipEntityAId").As("RelationshipEntityAId")
				.Column("RelationshipConnection", "RelationshipEntityBId").As("RelationshipEntityBId")
				.Column("RT", "RelationConnectionTypeId").As("RelationConnectionTypeId")
				.From("RelationshipConnection").As("RelationshipConnection")
				.InnerJoin("RelationType").As("RT").On("RT", "Id").IsEqual("RelationshipConnection", "RelationTypeId")
				.InnerJoin("RelationshipEntity").As("REA").On("REA", "Id").IsEqual("RelationshipConnection", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("REB").On("REB", "Id").IsEqual("RelationshipConnection", "RelationshipEntityBId")
				.Where().Exists(new Select(UserConnection).Column(Column.Const(1))
							.From("RelationEntInDiagram").As("RED")
							.Where("RED", "RelationshipEntityId").IsEqual("RelationshipConnection", "RelationshipEntityAId")
							.And("RED", "RelationshipDiagramId").IsEqual(Column.Parameter(diagramId)))
				.And("RT", "RelationConnectionTypeId").IsEqual(Column.Parameter(_relationConnectionTypeFormal))
					.And("REA", "SchemaUId").IsEqual(Column.Parameter(schemaUId))
					.And("REB", "SchemaUId").IsEqual(Column.Parameter(schemaUId)) as Select;
		}


		private Guid GetEntitySchemaUId(RelationshipEntityConnection entityConnection) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityConnection.RelationshipRecordA.EntitySchemaName);
			return entitySchema == null ? Guid.Empty : entitySchema.UId;
		}

		private RelationshipEntityConnection CreateRelationshipEntityConnection(System.Data.IDataReader reader) {
			return new RelationshipEntityConnection {
				Id = reader.GetColumnValue<Guid>("Id"),
				RelationshipType = reader.GetColumnValue<Guid>("RelationTypeId"),
				RelationshipEntityA = reader.GetColumnValue<Guid>("RelationshipEntityAId"),
				RelationshipEntityB = reader.GetColumnValue<Guid>("RelationshipEntityBId"),
				RelationshipConnectionType = reader.GetColumnValue<Guid>("RelationConnectionTypeId")
			};
		}

		private List<RelationshipEntityConnection> GetFormalRelationshipEntityConnections(RelationshipEntityConnection entityConnection) {
			var entitySchemaUId = GetEntitySchemaUId(entityConnection);
			Select relationshipSelect = GetFormalRelationshipConnectionSelect(entitySchemaUId, entityConnection.DiagramId);
			var relationConnections = new List<RelationshipEntityConnection>();
			relationshipSelect.ExecuteReader((reader) => {
				var connection = CreateRelationshipEntityConnection(reader);
				relationConnections.Add(connection);
			});
			return relationConnections;
		}

		private List<RelationshipEntityConnection> AddConnectionToCollection(List<RelationshipEntityConnection> connections, RelationshipEntityConnection entityConnection) {
			connections.RemoveAll(con => con.Id == entityConnection.Id);
			connections.Add(entityConnection);
			return connections;
		}

		private void CheckForLoopingInDiagram(RelationshipEntityConnection entityConnection) {
			if (!entityConnection.IsEntitySchemaEquals() || !IsFormalConnection(entityConnection)) {
				return;
			}

			var connections = GetFormalRelationshipEntityConnections(entityConnection);
			connections = AddConnectionToCollection(connections, entityConnection);
			var loopingConnections = DiagramValidator.ValidateConnection(connections, entityConnection);
			if (loopingConnections.Any()) {
				ThrowException(_exceptionRecordAlreadyExistsInAnotherContainer);
			}
		}

		private bool ValidateConnection(RelationshipEntityConnection entityConnection) {
			if (IsExistEntityConnection(entityConnection)) {
				ThrowException(_exceptionAlreadyExistWithThisType);
			}
			CheckForLoopingInDiagram(entityConnection);
			return true;
		}

		private Guid CreateRelationshipConnection(RelationshipEntityConnection entityConnection) {
			if (!ValidateConnection(entityConnection)) {
				return Guid.Empty;
			}

			return IsAccountAccountConnection(entityConnection) ?
				AddRelationshipConnectionEntity(entityConnection) :
				AddContactRelationshipConnection(entityConnection);
		}

		private Guid CreateRelationshipEntity(RelationshipRecord record) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(record.EntitySchemaName);
			EntitySchema relationshipEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("RelationshipEntity");
			var relationshipEntity = relationshipEntitySchema.CreateEntity(UserConnection);
			var entityConditions = new Dictionary<string, object>() {
				{ "RecordId", record.Id },
				{ "SchemaUId", entitySchema.UId},
			};
			if (!relationshipEntity.FetchFromDB(entityConditions)) {
				relationshipEntity.SetDefColumnValues();
				relationshipEntity.SetColumnValue("RecordId", record.Id);
				relationshipEntity.SetColumnValue("SchemaUId", entitySchema.UId);
				relationshipEntity.Save();
			}
			return relationshipEntity.PrimaryColumnValue;
		}

		private void UpdateDiagramRecords(Guid newDiagramId, Guid previodDiagramId) {
			if (newDiagramId.Equals(previodDiagramId)) {
				return;
			}
			new Update(UserConnection, "RelationEntInDiagram")
				.Set("RelationshipDiagramId", Column.Parameter(newDiagramId))
				.Where("RelationshipDiagramId").IsEqual(Column.Parameter(previodDiagramId))
				.Execute();
		}

		private bool HasItemInDiagram(Guid diagramId) {
			var diagramSelect = new Select(UserConnection).Top(1)
				.Column("Id")
				.From("RelationEntInDiagram")
				.Where("RelationshipDiagramId").In(Column.Parameters(diagramId)) as Select;
			var countDiagramEntities = diagramSelect.ExecuteScalar<Guid>();
			return !countDiagramEntities.Equals(Guid.Empty);
		}

		private void DeleteDiagramIfEmpty(Guid diagramId) {
			if (HasItemInDiagram(diagramId)) {
				return;
			}
			new Delete(UserConnection)
				.From("RelationshipDiagram")
				.Where("Id").IsEqual(Column.Parameter(diagramId))
				.Execute();
		}

		private Guid GetDiagramIdForEntity(Guid entityId) {
			var diagramIdSelect = new Select(UserConnection)
				.Top(1)
				.Column("RelationshipDiagramId")
				.From("RelationEntInDiagram")
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(entityId)) as Select;
			return diagramIdSelect.ExecuteScalar<Guid>();
		}

		private bool IsEntityNotChangedInConnection(RelationshipEntityConnection entityConnection, Entity connection) {
			var entitiesAEquals = entityConnection.RelationshipEntityA.Equals(connection.GetTypedColumnValue<Guid>("RelationshipEntityAId"));
			var entitiesBEquals = entityConnection.RelationshipEntityB.Equals(connection.GetTypedColumnValue<Guid>("RelationshipEntityBId"));
			var entitiesABEquals = entityConnection.RelationshipEntityA.Equals(connection.GetTypedColumnValue<Guid>("RelationshipEntityBId"));
			var entitiesBAEquals = entityConnection.RelationshipEntityB.Equals(connection.GetTypedColumnValue<Guid>("RelationshipEntityAId"));
			return entitiesAEquals && entitiesBEquals || entitiesABEquals && entitiesBAEquals;
		}

		private Guid CreateRelationshipEntityInDiagram(Guid recordId, Guid diagramId) {
			var relationshipEntityInDiagramSchema = UserConnection.EntitySchemaManager.GetInstanceByName("RelationEntInDiagram");
			var relationshipEntityInDiagramEntity = relationshipEntityInDiagramSchema.CreateEntity(UserConnection);
			var entityConditions = new Dictionary<string, object>() {
				{ "RelationshipEntity", recordId }
			};
			if (!relationshipEntityInDiagramEntity.FetchFromDB(entityConditions)) {
				relationshipEntityInDiagramEntity.SetDefColumnValues();
				relationshipEntityInDiagramEntity.SetColumnValue("RelationshipEntityId", recordId);
			} else {
				var prevDiagramId = relationshipEntityInDiagramEntity.GetTypedColumnValue<Guid>("RelationshipDiagramId");
				UpdateDiagramRecords(diagramId, prevDiagramId);
				DeleteDiagramIfEmpty(prevDiagramId);
			}
			relationshipEntityInDiagramEntity.SetColumnValue("RelationshipDiagramId", diagramId);
			relationshipEntityInDiagramEntity.Save();

			return relationshipEntityInDiagramEntity.PrimaryColumnValue;
		}

		private Guid GetDiagramIdByEntityId(Guid entityId) {
			var entitySelect = new Select(UserConnection)
				.Column("RelationshipDiagramId")
				.From("RelationEntInDiagram")
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(entityId)) as Select;
			return entitySelect.ExecuteScalar<Guid>();
		}

		private void CreateRelationshipDiagramEntities(Guid entityAId, Guid entityBId, Guid diagramId = default(Guid)) {
			if (diagramId.Equals(Guid.Empty)) {
				diagramId = GetDiagramIdByEntityId(entityAId);
			}
			CreateRelationshipEntityInDiagram(entityAId, diagramId);
			CreateRelationshipEntityInDiagram(entityBId, diagramId);
		}

		private Entity GetConnectionEntity(Guid recordId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "RelationshipConnection");
			esq.AddAllSchemaColumns();
			esq.AddColumn("RelationType.IncludeIntoContainer");
			esq.AddColumn("RelationType.RelationConnectionType.Id");
			return esq.GetEntity(UserConnection, recordId);
		}

		private bool IsContactContactConnection(RelationshipEntityConnection entityConnection) {
			return entityConnection.IsEntitySchemaEquals() && entityConnection.RelationshipRecordA.EntitySchemaName.Equals(_entitySchemaContactName);
		}

		private bool IsAccountContactConnection(RelationshipEntityConnection entityConnection) {
			return !entityConnection.IsEntitySchemaEquals() && entityConnection.RelationshipRecordA.EntitySchemaName.Equals(_entitySchemaAccountName);
		}

		private bool IsAccountAccountConnection(RelationshipEntityConnection entityConnection) {
			return entityConnection.IsEntitySchemaEquals() && entityConnection.RelationshipRecordA.EntitySchemaName.Equals(_entitySchemaAccountName);
		}

		private void UpdateRelationshipConnection(RelationshipEntityConnection entityConnection) {
			var connectionEntity = GetConnectionEntity(entityConnection.Id);
			var entitiesEquals = IsEntityNotChangedInConnection(entityConnection, connectionEntity);
			var connectionTypeEquals = entityConnection.RelationshipConnectionType.Equals(
				connectionEntity.GetTypedColumnValue<Guid>("RelationType_RelationConnectionType_Id"));
			var includeIntoContainer = connectionEntity.GetTypedColumnValue<bool>("RelationType_IncludeIntoContainer");
			var includeIntoContainerChanged = !includeIntoContainer.Equals(entityConnection.IncludeIntoContainer);
			if (!entitiesEquals) {
				CreateRelationshipConnection(entityConnection);
				if (IsAccountContactConnection(entityConnection) && includeIntoContainer) {
					DeleteRelationConnectionEntitiesByType(connectionEntity.GetTypedColumnValue<Guid>("RelationshipEntityBId"), _relationConnectionTypeFormal);
				} else {
					DeleteConnection(entityConnection.Id);
				}
				return;
			}

			if (IsExistEntityConnection(entityConnection)) {
				ThrowException(_exceptionAlreadyExistWithThisType);
			}

			if (!connectionTypeEquals || includeIntoContainerChanged) {
				if (IsAccountContactConnection(entityConnection) && includeIntoContainerChanged && includeIntoContainer) {
					CheckContactExistInAnotherAccount(entityConnection);
				}
				if (IsContactContactConnection(entityConnection) && IsFormalConnection(entityConnection)) {
					AddParentRelationshipConnection(entityConnection);
				}
			}
			CheckForLoopingInDiagram(entityConnection);
			SaveConnectionEntity(entityConnection, connectionEntity);
		}


		private bool IsAccountContactIncludeIntoContainerConnection(Guid connectionId) {
			var select = new Select(UserConnection)
				.Column("EntityA", "SchemaUId").As("EntityASchemaUId")
				.Column("EntityB", "SchemaUId").As("EntityBSchemaUId")
				.Column("RelationType", "IncludeIntoContainer").As("IncludeIntoContainer")
				.From("RelationType")
				.InnerJoin("RelationshipConnection")
				.On("RelationshipConnection", "RelationTypeId")
				.IsEqual("RelationType", "Id")
				.InnerJoin("RelationshipEntity").As("EntityA")
				.On("EntityA", "Id")
				.IsEqual("RelationshipConnection", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("EntityB")
				.On("EntityB", "Id")
				.IsEqual("RelationshipConnection", "RelationshipEntityBId")
				.Where("RelationshipConnection", "Id").IsEqual(Column.Parameter(connectionId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						var entityASchemaId = reader.GetColumnValue<Guid>("EntityASchemaUId");
						var entityBSchemaId = reader.GetColumnValue<Guid>("EntityBSchemaUId");
						var isIncluded = reader.GetColumnValue<bool>("IncludeIntoContainer");
						return isIncluded && !entityASchemaId.Equals(entityBSchemaId) &&
							UserConnection.EntitySchemaManager.FindInstanceByUId(entityASchemaId).Name
								.Equals(_entitySchemaAccountName);
					}
				}
			}
			return false;
		}

		private void MoveEntitiesToSeparateDiagram(List<Guid> entitiesIds) {
			var newDiagramId = CreateDiagram();
			var update = new Update(UserConnection, "RelationEntInDiagram")
				.Set("RelationshipDiagramId", Column.Parameter(newDiagramId))
				.Where("RelationshipEntityId").In(Column.Parameters(entitiesIds)) as Update;
			update.Execute();
		}

		private void DeleteRelationEntityInGroup(Guid recordId) {
			new Delete(UserConnection)
				.From("RelationEntityInGroup")
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(recordId))
				.Execute();
		}

		private void DeleteRelationshipConnectionByEntityRecord(Guid recordId) {
			DeleteRelationshipEntityA(recordId);
			DeleteRelationshipEntityB(recordId);
		}

		private void DeleteRelationshipEntityB(Guid recordId) {
			var relationConnectionEntities = GetRelationConnectionEntities(recordId, null);
			DeleteRelationConnectionEntities(relationConnectionEntities);
		}

		private void DeleteRelationshipEntityA(Guid recordId) {
			var connections = GetRelationshipConnectionEntityA(recordId);
			foreach (var connectionId in connections) {
				DeleteConnection(connectionId);
			}
		}

		private List<Guid> GetRelationshipConnectionEntityA(Guid recordId) {
			var relationList = new List<Guid>();
			var relationSelect = new Select(UserConnection)
				.Column("Id")
				.From("RelationshipConnection")
				.Where("RelationshipEntityAId").IsEqual(Column.Parameter(recordId)) as Select;
			relationSelect.ExecuteReader(reader => {
				relationList.Add(reader.GetColumnValue<Guid>("Id"));
			});
			return relationList;
		}

		private void DeleteRelationEntity(Guid recordId) {
			new Delete(UserConnection)
				.From("RelationshipEntity")
				.Where("Id").IsEqual(Column.Parameter(recordId))
				.Execute();
		}

		private Select GetRelationTypeSelectByConnectionType(Guid connectionTypeId) {
			return new Select(UserConnection)
				.Column("Id")
				.From("RelationType")
				.Where("RelationConnectionTypeId")
					.IsEqual(Column.Parameter(connectionTypeId)) as Select;
		}

		private EntitySchemaQuery GetRelationConnectionEsq() {
			var relationshipConnectionEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "RelationshipConnection") {
				UseAdminRights = false,
				UseLocalization = false
			};
			relationshipConnectionEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			relationshipConnectionEsq.AddAllSchemaColumns();
			return relationshipConnectionEsq;
		}

		private void AddEntityRecordFiltersGroup(EntitySchemaQuery esq, Guid entityRecordId) {
			var entityRecordFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			entityRecordFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"RelationshipEntityA", entityRecordId));
			entityRecordFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"RelationshipEntityB", entityRecordId));
			esq.Filters.Add(entityRecordFilterGroup);
		}

		private void DeleteRelationConnectionEntities(EntityCollection entityCollection) {
			foreach (var entity in entityCollection.ToList()) {
				entity.Delete();
			}
		}

		private void DeleteRelationConnectionEntitiesByType(Guid entityRecordId, Guid connectionTypeId) {
			var relationConnectionEntities = GetRelationConnectionEntitiesByType(entityRecordId, connectionTypeId);
			DeleteRelationConnectionEntities(relationConnectionEntities);
		}

		private void DeleteRelationshipEntityInDiagram(Guid recordId) {
			new Delete(UserConnection)
				.From("RelationEntInDiagram")
				.Where("RelationshipEntityId").IsEqual(Column.Parameter(recordId))
				.Execute();
		}

		private (Guid entityRecordId, Guid schemaUId) GetRecordEntityData(Guid entityId) {
			Guid entityRecordId = Guid.Empty;
			Guid schemaUId = Guid.Empty;
			var entitySelect = new Select(UserConnection)
				.Column("RecordId")
				.Column("SchemaUId")
				.From("RelationshipEntity")
				.Where("Id").IsEqual(Column.Parameter(entityId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = entitySelect.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						entityRecordId = reader.GetColumnValue<Guid>("RecordId");
						schemaUId = reader.GetColumnValue<Guid>("SchemaUId");
					}
				}
			}
			return (entityRecordId, schemaUId);
		}

		private Dictionary<string, object> GetRecordEntityInfo(Guid entityRecordId, Guid schemaUId) {
			var result = new Dictionary<string, object>();
			var entity = new Entity(UserConnection, schemaUId);
			if (!entity.FetchFromDB("Id", entityRecordId)) {
				return result;
			}
			result.Add("RecordId", entity.PrimaryColumnValue);
			result.Add("Caption", entity.PrimaryDisplayColumnValue);
			result.Add("Type", entity.GetColumnDisplayValue(entity.Schema.Columns.GetByName("Type")));
			result.Add("Address", entity.GetTypedColumnValue<string>("Address"));
			result.Add("Phone", entity.GetTypedColumnValue<string>("Phone"));
			if (entity.Schema.Columns.FindByName("Web") != null) {
				result.Add("Web", entity.GetTypedColumnValue<string>("Web"));
			}
			if (entity.Schema.Columns.FindByName("Email") != null) {
				result.Add("Email", entity.GetTypedColumnValue<string>("Email"));
			}
			return result;
		}

		private EntityCollection GetRelationConnectionEntitiesIncludeIntoContainer(Guid entityRecordId) {
			var additionalFilters = new Dictionary<string, object> {
				{ "RelationType.IncludeIntoContainer", true }
			};
			return GetRelationConnectionEntities(entityRecordId, additionalFilters);
		}

		private EntityCollection GetRelationConnectionEntitiesByType(Guid entityRecordId, Guid connectionTypeId) {
			var additionalFilters = new Dictionary<string, object> {
				{ "RelationType.RelationConnectionType", connectionTypeId }
			};
			return GetRelationConnectionEntities(entityRecordId, additionalFilters);
		}

		private void AddAdditionalFiltersToEsq(EntitySchemaQuery esq, Dictionary<string, object> additionalFilters) {
			if (additionalFilters == null) {
				return;
			}
			foreach (var filter in additionalFilters) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					filter.Key, filter.Value));
			}
		}

		private EntityCollection GetRelationConnectionEntities(Guid entityRecordId, Dictionary<string, object> additionalFilters) {
			var relationshipConnectionEsq = GetRelationConnectionEsq();
			AddEntityRecordFiltersGroup(relationshipConnectionEsq, entityRecordId);
			AddAdditionalFiltersToEsq(relationshipConnectionEsq, additionalFilters);
			return relationshipConnectionEsq.GetEntityCollection(UserConnection);
		}

		private void DeleteAllIncludeIntoContainerConnections(Guid entityId) {
			var entityConnections = GetRelationConnectionEntitiesIncludeIntoContainer(entityId);
			DeleteRelationConnectionEntities(entityConnections);
		}

		private Guid GetRelationshipEntityByRecordId(Guid recordId) {
			var select = new Select(UserConnection).Top(1)
				.Column("Id")
				.From("RelationshipEntity")
				.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		public void DeleteEntity(Guid entityId) {
			DeleteRelationEntityInGroup(entityId);
			DeleteRelationshipConnectionByEntityRecord(entityId);
			Guid diagramId = GetDiagramIdForEntity(entityId);
			DeleteRelationshipEntityInDiagram(entityId);
			DeleteDiagramIfEmpty(diagramId);
			DeleteRelationEntity(entityId);
		}

		public void DeleteEntityByRecordId(Guid recordId) {
			var entityId = GetRelationshipEntityByRecordId(recordId);
			if (entityId.IsEmpty()) {
				return;
			}
			DeleteEntity(entityId);
		}

		public void CreateConnection(RelationshipEntityConnection entityConnection) {
			entityConnection = SetEntityRecords(entityConnection);
			CreateRelationshipConnection(entityConnection);
			CreateRelationshipDiagramEntities(entityConnection.RelationshipEntityA, entityConnection.RelationshipEntityB, entityConnection.DiagramId);
		}

		public void UpdateConnection(RelationshipEntityConnection entityConnection) {
			entityConnection = SetEntityRecords(entityConnection);
			UpdateRelationshipConnection(entityConnection);
			CreateRelationshipDiagramEntities(entityConnection.RelationshipEntityA, entityConnection.RelationshipEntityB, entityConnection.DiagramId);
		}

		public void DeleteConnection(Guid connectionId) {
			var configuration = DiagramConfigProvider.GetConfiguration();
			var relationshipConnection = UserConnection.EntitySchemaManager.GetInstanceByName("RelationshipConnection")
				.CreateEntity(UserConnection);
			if (!relationshipConnection.FetchFromDB("Id", connectionId)) {
				return;
			}
			var entityAId = relationshipConnection.GetTypedColumnValue<Guid>("RelationshipEntityAId");
			var entityBId = relationshipConnection.GetTypedColumnValue<Guid>("RelationshipEntityBId");
			var isNeedToDeleteAllIncludeConnections = IsAccountContactIncludeIntoContainerConnection(connectionId);
			relationshipConnection.Delete();

			var relationshipEntity = UserConnection.EntitySchemaManager.GetInstanceByName("RelationshipEntity")
				.CreateEntity(UserConnection);
			if (!relationshipEntity.FetchFromDB("Id", entityAId)) {
				return;
			};
			var recordAId = relationshipEntity.GetTypedColumnValue<Guid>("RecordId");
			var entities = DiagramBuilder.GetEntitiesFromDiagram(recordAId, configuration);
			var entityIds = entities.Select(x => x.Id).ToList();
			var connections = DiagramBuilder.GetDiagramConnections(entityIds);
			var entityBConnected = DiagramBuilder.GetOnlyConnectedEntities(entityBId, entityIds, connections);
			if (isNeedToDeleteAllIncludeConnections) {
				DeleteAllIncludeIntoContainerConnections(entityBId);
			}
			if (entityBConnected.Contains(entityAId)) {
				return;
			}
			MoveEntitiesToSeparateDiagram(entityBConnected);
		}

		public Guid CreateDiagram() {
			var diagramId = Guid.NewGuid();
			var insertDiagram = new Insert(UserConnection).Into("RelationshipDiagram")
				.Set("Id", Column.Parameter(diagramId));
			insertDiagram.Execute();
			return diagramId;
		}

		public CreateRelationshipEntityAndDiagramResult CreateRelationshipEntityAndDiagramForRecord(Guid recordId, string schemaName) {
			var entityId = Guid.NewGuid();
			var diagramId = CreateDiagram();
			var insertEntity = new Insert(UserConnection).Into("RelationshipEntity")
				.Set("Id", Column.Parameter(entityId))
				.Set("RecordId", Column.Parameter(recordId))
				.Set("SchemaUId",
					Column.Parameter(UserConnection.EntitySchemaManager.GetInstanceByName(schemaName).UId));
			insertEntity.Execute();
			var insertEntityInDiagram = new Insert(UserConnection).Into("RelationEntInDiagram")
				.Set("RelationshipEntityId", Column.Parameter(entityId))
				.Set("RelationshipDiagramId", Column.Parameter(diagramId));
			insertEntityInDiagram.Execute();
			return new CreateRelationshipEntityAndDiagramResult(entityId, diagramId);
		}

		public Dictionary<string, object> GetRecordEntityInfo(Guid entityId) {
			var recordEntityData = GetRecordEntityData(entityId);
			return GetRecordEntityInfo(recordEntityData.entityRecordId, recordEntityData.schemaUId);
		}

	}

	#endregion

}

