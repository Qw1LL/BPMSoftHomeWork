namespace BPMSoft.Configuration
{
	using System;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Web.Common;

	#region Class: EntityDependenciesService

	#region Class: DependentInfo

	[DataContract]
	public class DependentInfo {

		#region Fields: Public

		/// <summary>
		/// Unique identification of entity.
		/// </summary>
		[DataMember(Name = "EntitySchemaUId")]
		public Guid EntitySchemaUId { get; set; }

		/// <summary>
		/// Name of entity.
		/// </summary>
		[DataMember(Name = "EntitySchemaName")]
		public string EntitySchemaName { get; set; }

		/// <summary>
		/// Caption of entity.
		/// </summary>
		[DataMember(Name = "EntitySchemaCaption")]
		public string EntitySchemaCaption { get; set; }

		/// <summary>
		/// Collection of column names.
		/// </summary>
		[DataMember(Name = "ColumnsName")]
		public List<string> ColumnsName { get; set; }

		/// <summary>
		/// Count of records.
		/// </summary>
		[DataMember(Name = "RecordsCount")]
		public int RecordsCount { get; set; }

		/// <summary>
		/// Identificator of records.
		/// </summary>
		[DataMember(Name = "RecordIds")]
		public List<Guid> RecordIds { get; set; }

		/// <summary>
		/// Flag of having read rights.
		/// </summary>
		[DataMember(Name = "CanRead")]
		public bool CanRead { get; set; }

		#endregion

	}

	#endregion

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EntityDependenciesService : BaseService
	{

		#region Methods: Private

		private EntityDependenciesHelper GetEntityDependenciesHelper(UserConnection userConnection) {
			var argumetns = new[] {
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("useAdminRights", false)
			};
			return ClassFactory.Get<EntityDependenciesHelper>(argumetns);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<DependentInfo> GetDependentEntities(string entitySchemaName, Guid recordId) {
			UserConnection userConnection = GetUserConnection();
			EntityDependenciesHelper helper = GetEntityDependenciesHelper(userConnection);
			List<DependentInfo> entities = helper.GetDependentEntitiesContainRecords(entitySchemaName, recordId);
			return entities;
		}

		#endregion

	}

	#endregion

	#region Class: EntityDependenciesHelper

	public class EntityDependenciesHelper {

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly bool _useAdminRights = true;
		private bool _isLoadRecordId;

		#endregion

		#region Constructors: Public

		public EntityDependenciesHelper(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public EntityDependenciesHelper(UserConnection userConnection, bool useAdminRights) : this(userConnection) {
			_useAdminRights = useAdminRights;
		}

		#endregion

		#region Properties: Private

		private readonly List<string> excludedColumns = new List<string>{"ModifiedBy", "CreatedBy"};

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		private EntitySchemaManager _entitySchemaManager;
		protected EntitySchemaManager EntitySchemaManager {
			get {
				return _entitySchemaManager ??
					(_entitySchemaManager = UserConnection.EntitySchemaManager);
			}
		}

		private string _entitySchemaName;
		protected string EntitySchemaName {
			get {
				return _entitySchemaName;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException("EntitySchemaName");
				}
				_entitySchemaName = value;
			}
		}

		private Guid _recordId;
		protected Guid RecordId {
			get {
				return _recordId;
			}
			set {
				if (value == null) {
					throw new ArgumentNullException("RecordId");
				}
				_recordId = value;
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns collection of column names.
		/// </summary>
		/// <param name="entitySchema">Entity which has columns.</param>
		/// <param name="columnsUId">Collection of column UIds.</param>
		/// <returns>Collection of column names.</returns>
		private List<string> GetColumnsNameByUIds(EntitySchema entitySchema, List<Guid> columnsUId) {
			var columnsName = new List<string>();
			EntitySchemaColumnCollection columns = entitySchema.Columns;
			foreach (Guid columnUId in columnsUId) {
				EntitySchemaColumn column = columns.GetByUId(columnUId);
				var columnName = column.Name;
				if (column.IsCascade || excludedColumns.Contains(columnName)) {
					continue;
				}
				columnsName.Add(columnName);
			}
			return columnsName;
		}

		/// <summary>
		/// Adds to dictionary the information of dependent entity.
		/// </summary>
		/// <param name="dependentEntity">Information of dependent entity.</param>
		/// <param name="result">Collection of dependent entites.</param>
		/// <returns>Collection of column names.</returns>
		private void AddDependentEntity(EntitySchemaOppositeReferenceInfo dependentEntity,
			Dictionary<string, List<Guid>> result) {
			string key = dependentEntity.SchemaName;
			var columns = new List<Guid>();
			if (result.ContainsKey(key)) {
				columns = result[key];
				columns.Add(dependentEntity.ColumnUId);
			} else {
				columns.Add(dependentEntity.ColumnUId);
				result.Add(key, columns);
			}
		}

		/// <summary>
		/// Retuns query object to the scheme.
		/// </summary>
		/// <param name="schemaName">Schema name of entity.</param>
		/// <param name="columnsName">Collection of column names.</param>
		/// <returns>Query object to the scheme.</returns>
		private EntitySchemaQuery GetEntitySchemaQuery(string schemaName, List<string> columnsName) {
			var query = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName);
			query.UseAdminRights = _useAdminRights;
			var filtersGroup = new EntitySchemaQueryFilterCollection(query, LogicalOperationStrict.Or);
			foreach (string columnName in columnsName) {
				filtersGroup.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, columnName, RecordId));
			}
			query.Filters.Add(filtersGroup);
			return query;
		}

		/// <summary>
		/// Returns information of dependent entity.
		/// </summary>
		/// <param name="dependentEntity">Information of dependent entity.</param>
		/// <returns>Information of dependent entity.</returns>
		private DependentInfo GetDependenInfo(KeyValuePair<string, List<Guid>> dependentEntity) {
			var count = 0;
			var recordIds = new List<Guid>();
			string schemaName = dependentEntity.Key;
			EntitySchema entitySchema = EntitySchemaManager.GetInstanceByName(schemaName);
			string caption = entitySchema.Caption;
			Guid entitySchemaUId = entitySchema.UId;
			List<string> columnsName = GetColumnsNameByUIds(entitySchema, dependentEntity.Value);
			if (columnsName.Count == 0) {
				return null;
			}
			var dependentInfo = new DependentInfo {
				EntitySchemaUId = entitySchemaUId,
				EntitySchemaName = schemaName,
				EntitySchemaCaption = caption,
				ColumnsName = columnsName
			};
			try {
				if (_isLoadRecordId) {
					recordIds = GetRecordIds(schemaName, columnsName);
					if (recordIds != null) {
						count = recordIds.Count;
					}
				} else {
					count = CountRecords(schemaName, columnsName);
				}
			} catch (SecurityException) {
				dependentInfo.CanRead = false;
				return dependentInfo;
			}
			if (count > 0) {
				dependentInfo.CanRead = true;
				dependentInfo.RecordsCount = count;
				if (_isLoadRecordId) {
					dependentInfo.RecordIds = recordIds;
				}
				return dependentInfo;
			}
			return null;

		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns collection of dependent entites.
		/// </summary>
		/// <returns>Collection of dependent entites.</returns>
		protected virtual Dictionary<string, List<Guid>> GetDependentEntities() {
			EntitySchema entity = EntitySchemaManager.GetInstanceByName(EntitySchemaName);
			EntitySchemaOppositeReferenceInfoCollection dependentEntites =
				EntitySchemaManager.GetSchemaOppositeReferences(entity.UId, EntitySchemaColumnUsageType.General,
				UserConnection, true);
			var result = new Dictionary<string, List<Guid>>();
			foreach (EntitySchemaOppositeReferenceInfo dependentEntity in dependentEntites) {
				EntitySchema depEntity = EntitySchemaManager.GetInstanceByName(dependentEntity.SchemaName);
				if (!depEntity.IsDBView) {
					AddDependentEntity(dependentEntity, result);
				}
			}
			return result;
		}

		/// <summary>
		/// Adds to dictionary the information of dependent entity.
		/// </summary>
		/// <param name="dependentEntites">Collection of dependent entites.</param>
		/// <returns>Collection of entites which has a records.</returns>
		protected virtual List<DependentInfo> GetEntitiesContainRecords(
			Dictionary<string, List<Guid>> dependentEntites) {
			var result = new List<DependentInfo>();
			foreach (KeyValuePair<string, List<Guid>> dependentEntity in dependentEntites) {
				DependentInfo info = GetDependenInfo(dependentEntity);
				if (info != null) {
					result.Add(info);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the identificator of records contained in the entity.
		/// </summary>
		/// <param name="schemaName">Schema name of entity.</param>
		/// <param name="columnsName">Collection of column names.</param>
		/// <returns>Count of records contained in the entity.</returns>
		protected virtual List<Guid> GetRecordIds(string schemaName, List<string> columnsName) {
			var recordIds = new List<Guid>();
			var query = GetEntitySchemaQuery(schemaName, columnsName);
			query.PrimaryQueryColumn.IsAlwaysSelect = true;
			var enities = query.GetEntityCollection(_userConnection);
			foreach (Entity entity in enities) {
				var recordId = entity.GetTypedColumnValue<Guid>(query.PrimaryQueryColumn.Name);
				recordIds.Add(recordId);
			}
			return recordIds;
		}

		/// <summary>
		/// Returns the count of records contained in the entity.
		/// </summary>
		/// <param name="schemaName">Schema name of entity.</param>
		/// <param name="columnsName">Collection of column names.</param>
		/// <returns>Count of records contained in the entity.</returns>
		protected virtual int CountRecords(string schemaName, List<string> columnsName) {
			var query = GetEntitySchemaQuery(schemaName, columnsName);
			var columnCount = query.AddColumn(query.CreateAggregationFunction(AggregationTypeStrict.Count, query.PrimaryQueryColumn.Name));
			var countEntity = query.GetEntityCollection(UserConnection)[0];
			var count = countEntity.GetTypedColumnValue<int>(columnCount.Name);
			return count;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns the collection of dependent entites which has a records.
		/// </summary>
		/// <param name="entitySchemaName">Schema name of entity.</param>
		/// <param name="recordId">Id of record.</param>
		/// <param name="isLoadRecordId">If true then load identificator of dependent record.</param>
		/// <returns>Collection of dependent entites which has a records.</returns>
		public List<DependentInfo> GetDependentEntitiesContainRecords(string entitySchemaName, Guid recordId, bool isLoadRecordId = false) {
			_isLoadRecordId = isLoadRecordId;
			EntitySchemaName = entitySchemaName;
			RecordId = recordId;
			var dependentEntites = GetDependentEntities();
			var result = GetEntitiesContainRecords(dependentEntites);
			return result;
		}

		#endregion

	}

	#endregion

}
