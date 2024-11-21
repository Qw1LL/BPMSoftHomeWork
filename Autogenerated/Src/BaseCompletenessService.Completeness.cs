namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Reflection;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: BaseCompletenessService

	public class BaseCompletenessService : BaseService
	{

		#region Fields: Private

		private static readonly ILog _log;
		private readonly List<CompletenessItem> _completenessItems;

		#endregion

		#region Methods: Private

		/// <summary>
		/// Maps entity collection to object properties.
		/// </summary>
		/// <typeparam name="T">Result type.</typeparam>
		/// <param name="entityCollection">Entity collection.</param>
		/// <returns>List of mapped objects.</returns>
		private static List<T> EntityCollectionMapToList<T>(EntityCollection entityCollection) {
			var list = new List<T>();
			foreach (Entity entity in entityCollection) {
				T obj = Activator.CreateInstance<T>();
				PropertyInfo[] properties = obj.GetType().GetProperties();
				foreach (PropertyInfo property in properties) {
					object objValue = entity.GetColumnValue(property.Name);
					if (objValue == null || Equals(objValue, DBNull.Value)) {
						continue;
					}
					if (property.PropertyType == typeof(Guid)) {
						objValue = new Guid(objValue.ToString());
					} else if (property.PropertyType == typeof(bool)) {
						bool boolVal;
						string stringVal = objValue.ToString();
						objValue = bool.TryParse(stringVal, out boolVal) ? boolVal : stringVal.Equals("1");
					}
					property.SetValue(obj, Convert.ChangeType(objValue, property.PropertyType), null);
				}
				list.Add(obj);
			}
			return list;
		}

		#endregion

		#region Constructors: Public

		static BaseCompletenessService() {
			_log = LogManager.GetLogger(typeof(BaseCompletenessService));
		}

		public BaseCompletenessService() {
			_completenessItems = new List<CompletenessItem>();
		}

		public BaseCompletenessService(UserConnection userConnection)
			: this() {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get completeness list.
		/// </summary>
		/// <param name="typeValue">Type Id.</param>
		/// <returns>Completeness List.</returns>
		protected List<Completeness> GetCompletenessList(Guid typeValue = new Guid()) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Completeness");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Name");
			esq.AddColumn("EntitySchemaName");
			esq.AddColumn("TypeColumnName");
			esq.AddColumn("TypeColumnValue");
			esq.AddColumn("ResultColumnName");
			esq.AddColumn("Scale");
			if (typeValue.IsNotEmpty()) {
				esq.Filters.Add(
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "TypeColumnValue", typeValue)
				);
			}
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			return EntityCollectionMapToList<Completeness>(entityCollection);
		}

		/// <summary>
		/// Get completeness parameters by schema name.
		/// </summary>
		/// <param name="completenessId">Completeness Id.</param>
		/// <returns>Completeness parameters list.</returns>
		protected List<CompletenessParameter> GetCompletenessParameters(Guid completenessId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CompletenessParameter");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Completeness");
			esq.AddColumn("Percentage");
			esq.AddColumn("Name");
			esq.AddColumn("IsColumn");
			esq.AddColumn("IsDetail");
			esq.AddColumn("ColumnName");
			esq.AddColumn("DetailEntityName");
			esq.AddColumn("AttributeId");
			esq.AddColumn("DetailColumn");
			esq.AddColumn("MasterColumn");
			esq.AddColumn("TypeColumn");
			esq.AddColumn("TypeValue");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Completeness", completenessId));
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			return EntityCollectionMapToList<CompletenessParameter>(entityCollection);
		}

		/// <summary>
		/// Obsolete.
		/// This method does NOT save completeness records into database. 
		/// Instead it puts them into a collection that should later be persisted 
		/// by invoking <see cref="PersistCompletenessItems"/>.
		/// </summary>
		/// <param name="recordIds">Collection of record ids.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="completeness">Completeness value.</param>
		/// <param name="resultColumn">Column for update.</param>
		[Obsolete("7.11.2 | Use CompletenessItem.update instead")]
		protected virtual void UpdateCompletenessForRecords(IEnumerable<Guid> recordIds, string schemaName, int completeness,
				string resultColumn) {
			recordIds?.ForEach((id => {
				var item = new CompletenessItem(id, schemaName, completeness, resultColumn);
				_completenessItems.Add(item);
			}));
		}

		/// <summary>
		/// Calculate completeness value from detail.
		/// </summary>
		/// <param name="param">Completeness parameter for detail completeness.</param>
		/// <param name="recordId">Record id.</param>
		/// <returns>Completeness value.</returns>
		protected int GetCompletenessFromDetail(CompletenessParameter param, Guid recordId) {
			int detailCompleteness = 0;
			Select entitiesSelect =
				new Select(AppConnection.SystemUserConnection)
					.Column(Func.Count(param.DetailColumn))
				.From(param.DetailEntityName)
				.Where(param.DetailColumn).IsEqual(new QueryParameter(recordId)) as Select;
			if (!string.IsNullOrEmpty(param.TypeColumn) && !param.TypeValue.IsEmpty()) {
				var typeCondition = new QueryCondition {
					LeftExpression = new QueryColumnExpression(param.TypeColumn)
				};
				typeCondition.In(new QueryParameter(param.TypeValue));
				entitiesSelect.AddCondition(typeCondition, LogicalOperation.And);
			}
			entitiesSelect.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = EnsureSystemUserDbConnection()) {
				using (IDataReader dataReader = entitiesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						if (Convert.ToInt32(dataReader.GetValue(0)) > 0) {
							detailCompleteness = param.Percentage;
						}
					}
				}
			}
			return detailCompleteness;
		}

		/// <summary>
		/// Calculate completeness for record.
		/// </summary>
		/// <param name="recordId">Record id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="typeValue">Type Id.</param>
		/// <returns>Dictionary with completeness info for each calculated record.</returns>
		protected Dictionary<Guid, CompletenessServiceResponse> CalculateRecordCompleteness(Guid recordId,
				string schemaName, Guid typeValue) {
			int completenessValue = 0;
			string resultColumn = string.Empty;
			string scale = string.Empty;
			var result = new Dictionary<Guid, CompletenessServiceResponse>();
			var completenessParameterList = new List<CompletenessParameter>();
			result.Add(recordId, new CompletenessServiceResponse());
			if (recordId.IsEmpty()) {
				return result;
			}
			Completeness completeness = GetCompletenessList(typeValue)
				.FirstOrDefault(cmpl => cmpl.EntitySchemaName == schemaName);
			if (completeness != null) {
				resultColumn = completeness.ResultColumnName;
				scale = completeness.Scale;
				completenessParameterList = GetCompletenessParameters(completeness.Id);
			}
			var columnParams = new List<CompletenessParameter>();
			var detailParams = new List<CompletenessParameter>();
			EntitySchema schema = AppConnection.SystemUserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			var esq = new EntitySchemaQuery(schema);
			string primaryColumnName = esq.RootSchema.GetPrimaryColumnName();
			Select entitiesSelect =
				new Select(AppConnection.SystemUserConnection)
					.Column(primaryColumnName).As(primaryColumnName)
					.Column(resultColumn).As("Completeness")
				.From(schemaName) as Select;
			entitiesSelect.Where(primaryColumnName).IsEqual(new QueryParameter(recordId));
			foreach (CompletenessParameter param in completenessParameterList) {
				if (param.IsColumn) {
					if (!entitiesSelect.Columns.ExistsByAlias(param.ColumnName)) {
						entitiesSelect.Column(param.ColumnName).As(param.ColumnName);
					}
					param.setDBColumnName(param.ColumnName);
					columnParams.Add(param);
				} else if (param.IsDetail) {
					if (!entitiesSelect.Columns.ExistsByAlias(param.MasterColumn)) {
						entitiesSelect.Column(param.MasterColumn).As(param.MasterColumn);
					}
					param.setDBMasterColumn(param.MasterColumn);
					detailParams.Add(param);
				}
			}
			using (DBExecutor dbExecutor = EnsureSystemUserDbConnection()) {
				using (IDataReader dataReader = entitiesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var primaryColumnValue = dataReader.GetColumnValue<Guid>(primaryColumnName);
						var missingParameters = new List<CompletenessParameter>();
						foreach (CompletenessParameter param in detailParams) {
							var detailMasterColumnId = dataReader.GetColumnValue<Guid>(param.getDBMasterColumn());
							int detailCompleteness = GetCompletenessFromDetail(param, detailMasterColumnId);
							if (detailCompleteness == 0) {
								missingParameters.Add(param);
							}
							completenessValue += detailCompleteness;
						}
						foreach (CompletenessParameter param in columnParams) {
							double valueDouble = 0;
							object value = dataReader.GetColumnValue(param.getDBColumnName());
							bool isDouble = value != null && double.TryParse(value.ToString(), out valueDouble);
							if (value != null &&
								((isDouble && valueDouble != 0) ||
									(!isDouble && !string.IsNullOrEmpty(value.ToString())))) {
								completenessValue += param.Percentage;
							} else {
								missingParameters.Add(param);
							}
						}
						var currentEntityCompleteness = dataReader.GetColumnValue<int>("Completeness");
						if (currentEntityCompleteness != completenessValue) {
							var item = ClassFactory.Get<CompletenessItem>(
								new ConstructorArgument("recordId", primaryColumnValue),
								new ConstructorArgument("schemaName", schemaName),
								new ConstructorArgument("completeness", completenessValue),
								new ConstructorArgument("resultColumn", resultColumn));
							_completenessItems.Add(item);
						}
						missingParameters = missingParameters.OrderBy(param => param.Percentage).ToList();
						result[primaryColumnValue] = new CompletenessServiceResponse {
							Completeness = completenessValue,
							MissingParameters = missingParameters,
							Scale = scale
						};
					}
				}
				PersistCompletenessItems();
			}
			return result;
		}

		private DBExecutor EnsureSystemUserDbConnection() {
			return AppConnection.SystemUserConnection.EnsureDBConnection();
		}

		private void PersistCompletenessItems() {
			_completenessItems?.ForEach(item => {
				try {
					item.Update(AppConnection.SystemUserConnection);
				} catch (DbOperationException exception) {
					_log.Error(exception);
				}
			});
			_completenessItems?.Clear();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculate completeness for one record by its record id.
		/// </summary>
		/// <param name="recordId">Record id.</param>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="typeValue">Type of record.</param>
		/// <returns>Object that contains profile completeness and list of missing parameters.</returns>
		public virtual CompletenessServiceResponse GetRecordCompleteness(Guid recordId, string schemaName,
				Guid typeValue = new Guid()) {
			Dictionary<Guid, CompletenessServiceResponse> recordsForUpdate =
				CalculateRecordCompleteness(recordId, schemaName, typeValue);
			return recordsForUpdate[recordId];
		}

		/// <summary>
		/// Calculate completeness for records by completeness Id.
		/// </summary>
		/// <param name="completenessId">Completeness Id.</param>
		public virtual void RecalculateAllByCompleteness(Guid completenessId) {
			StoredProcedure recalculateAllBySchema =
				new StoredProcedure(AppConnection.SystemUserConnection, "tsp_CompletenessRenew")
				.WithParameter(new QueryParameter("CompletenessId", completenessId, "Guid")) as StoredProcedure;
			recalculateAllBySchema.PackageName = "tspkg_Completeness";
			recalculateAllBySchema.Execute();
		}

		/// <summary>
		/// Calculate completeness for all schemas in Completness.
		/// </summary>
		public virtual void RecalculateAll() {
			List<Completeness> completenessList = GetCompletenessList();
			foreach(Completeness completeness in completenessList) {
				RecalculateAllByCompleteness(completeness.Id);
			}
		}

		#endregion

		#region Class: Completeness

		public class Completeness
		{

			#region Properties: Public

			public Guid Id {
				get;
				set;
			}

			public string Name {
				get;
				set;
			}

			public string EntitySchemaName {
				get;
				set;
			}

			public string TypeColumnName {
				get;
				set;
			}

			public Guid TypeColumnValue {
				get;
				set;
			}

			public string ResultColumnName {
				get;
				set;
			}

			public string Scale {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: CompletenessParameter

		[DataContract]
		public class CompletenessParameter
		{

			#region Properties: Private

			private string DBColumnName {
				get;
				set;
			}

			private string DBMasterColumn {
				get;
				set;
			}

			#endregion

			#region Properties: Public

			[DataMember(Name = "id")]
			public Guid Id {
				get;
				set;
			}

			[DataMember(Name = "completenessId")]
			public Guid CompletenessId {
				get;
				set;
			}

			[DataMember(Name = "percentage")]
			public int Percentage {
				get;
				set;
			}

			[DataMember(Name = "name")]
			public string Name {
				get;
				set;
			}

			[DataMember(Name = "isColumn")]
			public bool IsColumn {
				get;
				set;
			}

			[DataMember(Name = "isDetail")]
			public bool IsDetail {
				get;
				set;
			}

			[DataMember(Name = "columnName")]
			public string ColumnName {
				get;
				set;
			}

			[DataMember(Name = "detailEntityName")]
			public string DetailEntityName {
				get;
				set;
			}

			[DataMember(Name = "attributeId")]
			public Guid AttributeId {
				get;
				set;
			}

			[DataMember(Name = "detailColumn")]
			public string DetailColumn {
				get;
				set;
			}

			[DataMember(Name = "masterColumn")]
			public string MasterColumn {
				get;
				set;
			}

			[DataMember(Name = "typeColumn")]
			public string TypeColumn {
				get;
				set;
			}

			[DataMember(Name = "typeValue")]
			public Guid TypeValue {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public void setDBColumnName(string value) {
				DBColumnName = value;
			}

			public string getDBColumnName() {
				return DBColumnName;
			}

			public void setDBMasterColumn(string value) {
				DBMasterColumn = value;
			}

			public string getDBMasterColumn() {
				return DBMasterColumn;
			}

			#endregion

		}

		#endregion

	}

	#endregion

	#region Class: CompletenessServiceResponse

	[DataContract]
	public class CompletenessServiceResponse : ConfigurationServiceResponse
	{

		#region Properties: Public

		[DataMember(Name = "completeness")]
		public int Completeness {
			get;
			set;
		}

		[DataMember(Name = "missingParameters")]
		public List<BaseCompletenessService.CompletenessParameter> MissingParameters {
			get;
			set;
		}

		[DataMember(Name = "scale")]
		public string Scale {
			get;
			set;
		}

		#endregion

	}

	#endregion

}
