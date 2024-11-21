namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;
	using CoreEntitySchema = Core.Entities.EntitySchema;
	using EntityCollection = Core.Entities.EntityCollection;

	#region Class: VisaDataService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class VisaDataService : BaseService
	{

		#region Methods: Private

		private VisaHelper GetVisaHelper(Guid sysAdminUnitId) {
			return ClassFactory.Get<VisaHelper>(new ConstructorArgument("sysAdminUnitId", sysAdminUnitId),
				new ConstructorArgument("userConnection", UserConnection));
		}

		private Select GetSysModuleSelect(string schemaName) {
			var select =
				new Select(UserConnection)
					.Column("SysModuleVisa", "VisaSchemaUId").As("VisaSchemaUId")
					.Column("SysModuleVisa", "MasterColumnUId").As("MasterColumnUId")
				.From("SysModule")
					.InnerJoin("SysModuleVisa").On("SysModuleVisa", "Id")
						.IsEqual("SysModule", "SysModuleVisaId")
				.Where("SysModule", "Code")
					.IsEqual(Column.Parameter(schemaName)) as Select;
			return select;
		}

		private HistoryParameters GetHistoryParameters(string parentSchemaName) {
			var result = new HistoryParameters();
			CoreEntitySchema schema = null;
			string masterColumnName = "";
			GetSysModuleSelect(parentSchemaName).ExecuteReader(reader => {
				Guid schemaUId = reader.GetColumnValue<Guid>("VisaSchemaUId");
				schema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
				Guid masterColumnUId = reader.GetColumnValue<Guid>("MasterColumnUId");
				Core.Entities.EntitySchemaColumn masterColumn = schema.Columns.GetByUId(masterColumnUId);
				masterColumnName = masterColumn.Name;
			});
			result.Schema = schema;
			result.MasterColumnName = masterColumnName;
			return result;
		}

		private SelectQueryResponse GetHistoryResponse(string parentSchemaName, Guid parentRecordId) {
			HistoryParameters historyParams = GetHistoryParameters(parentSchemaName);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, historyParams.Schema.Name);
			var columnNameMap = new Dictionary<string, string>();
			columnNameMap[esq.AddColumn("Id").Name] = "Id";
			columnNameMap[esq.AddColumn("VisaOwner").Name] = "VisaOwner";
			columnNameMap[esq.AddColumn("VisaOwner.Contact").Name] = "VisaOwnerContact";
			columnNameMap[esq.AddColumn("SetBy").Name] = "SetBy";
			columnNameMap[esq.AddColumn("Status").Name] = "Status";
			columnNameMap[esq.AddColumn("Comment").Name] = "Comment";
			columnNameMap[esq.AddColumn("Objective").Name] = "Objective";
			var setDateColumn = esq.AddColumn("SetDate");
			setDateColumn.OrderByAsc();
			columnNameMap[setDateColumn.Name] = "SetDate";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, historyParams.MasterColumnName, parentRecordId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCanceled", false));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", ApprovalConstants.Canceled));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			var convertedEntities = QueryExtension.GetEntityCollection(collection, columnNameMap);
			Dictionary<string, object> config = QueryExtension.GetColumnConfig(esq, columnNameMap);
			SelectQueryResponse response = new SelectQueryResponse {
				Rows = convertedEntities,
				RowsAffected = convertedEntities.Count,
				RowConfig = config
			};
			return response;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
		BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetVisaEntities(Guid sysAdminUnitId, RequestOptions requestOptions) {
			var helper = GetVisaHelper(sysAdminUnitId);
			SelectQueryResponse result = helper.GetEntities(requestOptions);
			return ServiceStackTextHelper.Serialize(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
		BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetVisaEntity(Guid sysAdminUnitId, Guid visaId) {
			var helper = GetVisaHelper(sysAdminUnitId);
			SelectQueryResponse result = helper.GetEntity(visaId);
			return ServiceStackTextHelper.Serialize(result);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
		BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
		public string GetVisaHistory(string parentSchemaName, Guid parentRecordId) {
			SelectQueryResponse response = GetHistoryResponse(parentSchemaName, parentRecordId);
			return ServiceStackTextHelper.Serialize(response);
		}

		#endregion

	}

	#endregion

	#region Class: VisaHelper

	public class VisaHelper {

		#region Fields: Private

		private UserConnection _userConnection;

		private Guid _sysAdminUnitId;

		private CoreEntitySchema _baseVisaSchema;

		private EntitySchemaQuery _baseVisaESQ;

		#endregion

		#region Constructord: Public

		public VisaHelper(Guid sysAdminUnitId, UserConnection userConnection) {
			_sysAdminUnitId = sysAdminUnitId;
			_userConnection = userConnection;
			_baseVisaSchema = GetExtendedBaseVisaEntitySchema();
			_baseVisaESQ = GetExtendedBaseVisaESQ(_baseVisaSchema);
		}

		#endregion

		#region Methods: Private

		private Select WrapSelect(Select sourceSelect) {
			EntitySchemaColumnCollection visaColumns = _baseVisaSchema.Columns;
			string alias = "InternalSelect";
			Select select = 
				new Select(_userConnection)
					.Column(alias, "Id")
					.Column(alias, "CreatedOn")
					.Column(alias, "CreatedById")
					.Column(alias, "ModifiedOn")
					.Column(alias, "ModifiedById")
					.Column(alias, "ProcessListeners")
					.Column(alias, "Objective")
					.Column(alias, "VisaOwnerId")
					.Column(alias, "IsAllowedToDelegate")
					.Column(alias, "DelegatedFromId")
					.Column(alias, "StatusId")
					.Column(alias, "SetById")
					.Column(alias, "SetDate")
					.Column(alias, "IsCanceled")
					.Column(alias, "Comment")
					.Column(alias, "VisaSchemaName")
					.Column(alias, "Title")
					.Column(alias, "VisaObjectId")
					.Column(alias, "VisaSchemaTypeId")
					.Column(alias, "VisaTypeName")
					.Column(alias, "VisaSchemaCaption")
					.Column(alias, "SchemaName")
				.From(sourceSelect).As(alias)
				.OrderBy(OrderDirectionStrict.Descending, alias, "ModifiedOn") as Select;
			CommonUtilities.AddRelatedColumn(_userConnection, select, alias, "CreatedById", "Contact", "Name",
				visaColumns.FindByName("CreatedBy").DisplayColumnValueName, "CreatedBy");
			CommonUtilities.AddRelatedColumn(_userConnection, select, alias, "StatusId", "VisaStatus", "Name",
				visaColumns.FindByName("Status").DisplayColumnValueName, "VisaStatus");
			return select;
		}

		private void ApplyOptions(ref Select select, RequestOptions requestOptions) {
			if (requestOptions.IsPageable) {
				select.Top(requestOptions.RowCount);
			}
		}

		private Dictionary<string, string> GetColumnNameMap(Select select) {
			var map = new Dictionary<string, string>();
			foreach(var column in select.Columns) {
				string columnName = column.Alias;
				if (string.IsNullOrEmpty(columnName)) {
					columnName = column.SourceColumnAlias;
				}
				map[columnName] = columnName;
			}
			map["CreatedBy"] = "CreatedBy";
			map["Status"] = "Status";
			return map;
		}

		private CoreEntitySchema GetExtendedBaseVisaEntitySchema() {
			var entitySchemaManager = _userConnection.GetSchemaManager("EntitySchemaManager") as EntitySchemaManager;
			var baseVisaEntitySchema = entitySchemaManager.GetInstanceByName("BaseVisa");
			CoreEntitySchema baseVisaSchema = new CoreEntitySchema(baseVisaEntitySchema, false);
			baseVisaSchema.AddColumn("LongText", "Title");
			baseVisaSchema.AddColumn("LongText", "VisaSchemaName");
			baseVisaSchema.AddColumn("Guid", "VisaObjectId");
			baseVisaSchema.AddColumn("Guid", "VisaSchemaTypeId");
			baseVisaSchema.AddColumn("LongText", "VisaTypeName");
			baseVisaSchema.AddColumn("LongText", "VisaSchemaCaption");
			baseVisaSchema.AddColumn("LongText", "SchemaName");
			return baseVisaSchema;
		}

		private EntitySchemaQuery GetExtendedBaseVisaESQ(CoreEntitySchema schema) {
			EntitySchemaQuery entitySchemaQuery = new EntitySchemaQuery(schema);
			entitySchemaQuery.RootSchema.IsVirtual = false;
			entitySchemaQuery.AddAllSchemaColumns();
			return entitySchemaQuery;
		}

		private SelectQueryResponse GetVisaData(Select entitiesSelect) {
			Dictionary<string, string> serverToClientColumnNameMap = GetColumnNameMap(entitiesSelect);
			var collection = new EntityCollection(_userConnection, _baseVisaSchema);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = entitiesSelect.ExecuteReader(dbExecutor)) {
					collection.Load(dataReader);
				}
			}
			var convertedEntities = QueryExtension.GetEntityCollection(collection, serverToClientColumnNameMap);
			Dictionary<string, object> config = QueryExtension.GetColumnConfig(_baseVisaESQ, serverToClientColumnNameMap);
			SelectQueryResponse response = new SelectQueryResponse {
				Rows = convertedEntities,
				RowsAffected = convertedEntities.Count,
				RowConfig = config
			};
			return response;
		}

		private List<Select> GetSelectsFromProviders(RequestOptions requestOptions) {
			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "sysAdminUnitId", _sysAdminUnitId },
				{ "userConnection", _userConnection },
				{ "ownerRoleSources", requestOptions.OwnerRoleSources }
			};
			if (!requestOptions.StatusId.IsEmpty()) {
				parameters.Add("statusId", requestOptions.StatusId);
			}
			if (requestOptions.ModifiedOn != DateTime.MinValue) {
				parameters.Add("modifiedOn", requestOptions.ModifiedOn);
			}
			NotificationUtilities notificationUtilities = new NotificationUtilities();
			List<string> classNames = notificationUtilities
				.GetNotificationProviderClassNames(NotificationProviderType.Visa, _userConnection);
			List<Select> selectsFromProviders = new List<Select>();
			if (classNames.Count > 0) {
				object[] objectParams = { parameters };
				foreach (string className in classNames) {
					var classInstance = notificationUtilities.GetClassInstance(className, objectParams);
					if (requestOptions.StatusId.IsEmpty() || (classInstance is BaseVisaNotificationProvider)) {
						Select providerSelect = ((INotificationProvider)classInstance).GetEntitiesSelect();
						if (providerSelect != null) {
							selectsFromProviders.Add(providerSelect);
						}
					}
				}
			}
			return selectsFromProviders;
		}

		private Select GetMainSelect(Guid? visaId, RequestOptions requestOptions) {
			Select mainSelect = null;
			List<Select> selectsFromProviders = GetSelectsFromProviders(requestOptions);
			foreach (Select providerSelect in selectsFromProviders) {
				if (visaId != null) {
					string sourceSchemaName = providerSelect.SourceExpression.SchemaName;
					providerSelect.And(sourceSchemaName, "Id").IsEqual(Column.Parameter(visaId));
				}
				mainSelect = mainSelect == null
					? providerSelect
					: mainSelect.UnionAll(providerSelect) as Select;
			}
			return mainSelect;
		}

		private static SelectQueryResponse GetEmptyResponse() {
			return new SelectQueryResponse {
				Rows = null,
				RowsAffected = 0,
				RowConfig = null
			};
		}

		#endregion

		#region Methods: Public

		public SelectQueryResponse GetEntities(RequestOptions requestOptions) {
			Select mainSelect = GetMainSelect(null, requestOptions);
			if (mainSelect == null) {
				return GetEmptyResponse();
			}
			Select entitiesSelect = WrapSelect(mainSelect);
			ApplyOptions(ref entitiesSelect, requestOptions);
			return GetVisaData(entitiesSelect);
		}

		public SelectQueryResponse GetEntity(Guid visaId) {
			Select mainSelect = GetMainSelect(visaId, new RequestOptions());
			if (mainSelect == null) {
				return GetEmptyResponse();
			}
			Select entitiesSelect = WrapSelect(mainSelect);
			return GetVisaData(entitiesSelect);
		}

		#endregion
	}

	#endregion

	#region Class: RequestOptions

	[DataContract, Serializable]
	public class RequestOptions {

		#region Properties: Public

		[DataMember(Name = "isPageable")]
		public bool IsPageable {
			get; set;
		}

		[DataMember(Name = "ownerRoleSources")]
		public AdminUnitRoleSources OwnerRoleSources {
			get; set;
		}

		[DataMember(Name = "rowCount")]
		public int RowCount {
			get; set;
		}
		
		[DataMember(Name = "statusId")]
		public Guid StatusId {
			get; set;
		}
		
		[DataMember(Name = "modifiedOn")]
		public string ModifiedOnStr {
			get {
				return ModifiedOn.ToString();
			}
			set {
				ModifiedOn = DateTime.Parse(value).ToUniversalTime();
			}
		}

		public DateTime ModifiedOn {
			get;set;
		}

		#endregion

	}

	#endregion

	#region Class: ConditionalValues

	[DataContract, Serializable]
	public class ConditionalValues {
		
		#region Properties: Public

		[DataMember(Name = "columnName")]
		public string ColumnName {
			get; set;
		}

		[DataMember(Name = "value")]
		public object Value {
			get; set;
		}

		[DataMember(Name = "valueType")]
		public int ValueType {
			get; set;
		}
		
		#endregion
	}

	#endregion

	#region Class: HistoryParameters

	public class HistoryParameters {

		#region Properties: Public

		public BPMSoft.Core.Entities.EntitySchema Schema {
			get; set;
		}

		public string MasterColumnName {
			get; set;
		}

		#endregion
	}

	#endregion

}

