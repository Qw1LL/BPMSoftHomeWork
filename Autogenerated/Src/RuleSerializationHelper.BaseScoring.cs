namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;

	#region Class: RuleSerializationHelper

	/// <summary>
	/// Implement select serialization. Select based on scoring rule filter
	/// </summary>
	public class RuleSerializationHelper
	{

		#region Methods: Private

		private List<SerializableCondition> MapConditionItems(IEnumerable<QueryCondition> sourceQueryCondition,
				List<SerializableCondition> serializableConditions = null) {
			var items = serializableConditions ?? new List<SerializableCondition>();
			foreach (QueryCondition conditionItem in sourceQueryCondition) {
				var condition = new SerializableCondition() {
					ConditionType = conditionItem.ConditionType,
					IsNot = conditionItem.IsNot,
					LogicalOperation = conditionItem.LogicalOperation
				};
				if ((conditionItem.ConditionType == QueryConditionType.Block ||
						conditionItem.ConditionType == QueryConditionType.Blank)
						&& conditionItem.Any()) {
					condition.Items = MapConditionItems(conditionItem, condition.Items);
				}
				if (conditionItem.ConditionType == QueryConditionType.Exist) {
					var sourceExpressions = conditionItem.RightExpressions;
					var targetExpressions = new List<SerializableExpression>();
					foreach (QueryColumnExpression sourceExpression in sourceExpressions) {
						var targetExpression = new SerializableExpression();
						var serializedQuery = ConvertToSerializableQuery(sourceExpression.SubSelect);
						targetExpression.ExpressionType = sourceExpression.ExpressionType;
						targetExpression.SubSelect = serializedQuery;
						targetExpressions.Add(targetExpression);
					}
					condition.RightExpressions = targetExpressions;
				} else {
					condition.LeftExpression = MapLeftExpression(conditionItem.LeftExpression);
					condition.RightExpressions = MapRightExpression(conditionItem.RightExpressions);
				}
				items.Add(condition);
			}
			return items;
		}

		private List<SerializableCondition> ConvertToSerializableCondition(QueryCondition sourceQueryCondition) {
			return MapConditionItems(sourceQueryCondition);
		}

		private void ApplyJoinCondition(SerializableJoin join, QueryCondition sourceCondition) {
			join.Conditions = new List<SerializableCondition>();
			foreach (QueryCondition conditionItem in sourceCondition) {
				var condition = new SerializableCondition() {
					ConditionType = conditionItem.ConditionType,
					IsNot = conditionItem.IsNot,
					LogicalOperation = conditionItem.LogicalOperation
				};
				condition.LeftExpression = MapLeftExpression(conditionItem.LeftExpression);
				condition.RightExpressions = MapRightExpression(conditionItem.RightExpressions);
				join.Conditions.Add(condition);
			}
		}

		private void ApplySelectCondition(SerializableQuery query, QueryCondition sourceCondition) {
			query.Conditions = ConvertToSerializableCondition(sourceCondition);
		}

		private SerializableFunction MapQueryFunction(QueryFunction queryFunction) {
			var resultFunction = new SerializableFunction();
			var functionType = queryFunction.GetType();
			switch (functionType.ToString()) {
				case "BPMSoft.Core.DB.DatePartQueryFunction":
					var datePartQueryFunction = (BPMSoft.Core.DB.DatePartQueryFunction)queryFunction;
					resultFunction.Expression = datePartQueryFunction.Expression;
					resultFunction.FunctionType = SerializableFunctionType.DatePart;
					resultFunction = new SerializableDatePartFunction(resultFunction) {
						Interval = datePartQueryFunction.Interval,
						UseUtcOffset = datePartQueryFunction.UseUtcOffset
					};
					break;
			}
			return resultFunction;
		}

		private SerializableExpression MapLeftExpression(QueryColumnExpression sourceColumnExpression) {
			if (sourceColumnExpression == null) {
				return null;
			}
			var leftExpression = new SerializableExpression();
			leftExpression.ExpressionType = sourceColumnExpression.ExpressionType;
			if (sourceColumnExpression.Function != null) {
				leftExpression.Function = MapQueryFunction(sourceColumnExpression.Function);
			}
			leftExpression.SourceColumnAlias = sourceColumnExpression.SourceColumnAlias;
			leftExpression.SourceAlias = sourceColumnExpression.SourceAlias;
			leftExpression.Alias = sourceColumnExpression.Alias;
			return leftExpression;
		}

		private List<SerializableExpression> MapRightExpression(IEnumerable<QueryColumnExpression> sourceColumnExpressions) {
			if (sourceColumnExpressions == null) {
				return null;
			}
			var serializedExpressions = new List<SerializableExpression>();
			foreach (QueryColumnExpression sourceColumnExpression in sourceColumnExpressions) {
				var targetExpression = new SerializableExpression {
					ExpressionType = sourceColumnExpression.ExpressionType,
					SourceColumnAlias = sourceColumnExpression.SourceColumnAlias,
					SourceAlias = sourceColumnExpression.SourceAlias,
					Alias = sourceColumnExpression.Alias,
					Parameter = MapExpressionParameter(sourceColumnExpression.Parameter)
				};
				serializedExpressions.Add(targetExpression);
			}
			return serializedExpressions;
		}

		private SerializableParameter MapExpressionParameter(QueryParameter sourceParameter) {
			if (sourceParameter == null) {
				return null;
			}
			return new SerializableParameter() {
				Name = sourceParameter.Name,
				Value = sourceParameter.Value,
				ValueType = sourceParameter.ValueType != null
					? sourceParameter.ValueType.ClientDataValueType
					: null,
				ValueTypeName = sourceParameter.ValueTypeName
			};
		}

		private void ApplyJoins(SerializableQuery sourceQuery, IEnumerable<Join> joins) {
			sourceQuery.Joins = new List<SerializableJoin>();
			foreach (var joinItem in joins) {
				var serializedJoin = new SerializableJoin();
				ApplyJoinCondition(serializedJoin, joinItem.Condition);
				ApplySourceExpressions(serializedJoin, joinItem.SourceExpression);
				sourceQuery.Joins.Add(serializedJoin);
			}
		}

		private void ApplySourceExpressions(SerializableQuery sourceQuery, QuerySourceExpression sourceExpression) {
			if (sourceExpression != null) {
				sourceQuery.SourceExpression = new SerializableExpression() {
					Alias = sourceExpression.Alias,
					SchemaName = sourceExpression.SchemaName,
					SourceExpressionType = sourceExpression.ExpressionType
				};
			}
		}

		private SerializableQuery ConvertToSerializableQuery(Select sourceQuery) {
			var targetQuery = new SerializableQuery();
			ApplySelectCondition(targetQuery, sourceQuery.Condition);
			ApplySourceExpressions(targetQuery, sourceQuery.SourceExpression);
			ApplyJoins(targetQuery, sourceQuery.Joins);
			return targetQuery;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Serialize Select to JSON.
		/// </summary>
		/// <param name="sourceQuery">Instance of <see cref="Select"/>.</param>
		/// <returns>Serialized Select JSON data.</returns>
		public string SerializeSelectQuery(Select sourceQuery) {
			string resultJSON = string.Empty;
			SerializableQuery query = ConvertToSerializableQuery(sourceQuery);
			resultJSON = JsonConvert.SerializeObject(query, Newtonsoft.Json.Formatting.None,
				new JsonSerializerSettings {
					NullValueHandling = NullValueHandling.Ignore
				});
			return resultJSON;
		}

		/// <summary>
		/// Convert client filters to Select object.
		/// </summary>
		/// <param name="userConnection">A <see cref="instance"/> of the current user connection.</param>
		/// <param name="ruleId">Unique identifier of the scoring rule.</param>
		/// <param name="entitySchemaName">Rule entity schema name.</param>
		/// <returns>Select object</returns>
		public Select GetRuleSelectQuery(UserConnection userConnection, Guid ruleId, string entitySchemaName) {
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			EntitySchemaQuery formESQ = new EntitySchemaQuery(entitySchemaManager, entitySchemaName);
			formESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			formESQ.AddColumn("SearchData");
			formESQ.Filters.Add(formESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"Id",
					new object[] { ruleId }
				));
			EntityCollection formEntityCollection = formESQ.GetEntityCollection(userConnection);
			Entity entity = formEntityCollection.First();
			byte[] searchData = entity.GetColumnValue("SearchData") as byte[];
			string serializedFilters = UTF8Encoding.UTF8.GetString(searchData, 0, searchData.Length);
			DataContract.Filters jsonFilters = Json.Deserialize<DataContract.Filters>(serializedFilters);
			var leadSchema = entitySchemaManager.GetInstanceByName("Lead");
			var esqFilters = jsonFilters.BuildEsqFilter(leadSchema.UId, userConnection);
			var leadEsq = new EntitySchemaQuery(userConnection.EntitySchemaManager, leadSchema.Name);
			leadEsq.UseAdminRights = false;
			leadEsq.PrimaryQueryColumn.IsVisible = true;
			leadEsq.Filters.Add(esqFilters);
			return leadEsq.GetSelectQuery(userConnection);
		}

		/// <summary>
		/// Creates rule criteria.
		/// </summary>
		/// <param name="serializedFilters">Serialized rule filters.</param>
		/// <param name="scoringObjectId">Unique identifier of score object.</param>
		/// <param name="userConnection">A <see cref="instance"/> of the current user connection.</param>
		/// <param name="generateQuery">True if requared query text; otherwise, false.</param>
		/// <returns></returns>
		public string CreateRuleCriteria(string serializedFilters, Guid scoringObjectId, UserConnection userConnection,
				bool generateQuery = false) {
			if (string.IsNullOrEmpty(serializedFilters)) {
				return string.Empty;
			}
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			DataContract.Filters jsonFilters
				= Json.Deserialize<DataContract.Filters>(serializedFilters);
			EntitySchema scoringObjectSchema = entitySchemaManager.GetInstanceByUId(scoringObjectId);
			IEntitySchemaQueryFilterItem esqFilters
				= jsonFilters.BuildEsqFilter(scoringObjectSchema.UId, userConnection);
			var scoringObjectEsq = new EntitySchemaQuery(userConnection.EntitySchemaManager, scoringObjectSchema.Name);
			scoringObjectEsq.UseAdminRights = false;
			scoringObjectEsq.PrimaryQueryColumn.IsVisible = true;
			scoringObjectEsq.Filters.Add(esqFilters);
			Select scoringObjectSelect = scoringObjectEsq.GetSelectQuery(userConnection);
			if (generateQuery) {
				string query = scoringObjectSelect.GetSqlText();
				return query;
			}
			string serializedSelectQuery = SerializeSelectQuery(scoringObjectSelect);
			return serializedSelectQuery;
		}

		#endregion
	}

	#endregion

	#region Enum: SerializableFunctionType

	[Serializable]
	public enum SerializableFunctionType
	{
		None = 0,
		Macros = 1,
		Aggregation = 2,
		DatePart = 3,
		Length = 4
	}

	#endregion

	#region Class: SerializableDatePartFunction

	[Serializable]
	public class SerializableDatePartFunction : SerializableFunction
	{

		#region Constructors: Public

		public SerializableDatePartFunction(SerializableFunction sourceFunction) {
			this.Expression = sourceFunction.Expression;
			this.FunctionType = sourceFunction.FunctionType;
		}

		#endregion

		#region Properties: Public

		public DatePartQueryFunctionInterval Interval {
			get;
			set;
		}

		public bool UseUtcOffset {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: SerializableFunction

	[Serializable]
	public class SerializableFunction
	{

		#region Properties: Public

		public QueryColumnExpression Expression {
			get;
			set;
		}

		public SerializableFunctionType FunctionType {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: SerializableQuery

	[Serializable]
	public class SerializableQuery
	{

		#region Properties: Public

		public List<SerializableCondition> Conditions {
			get;
			set;
		}

		public SerializableExpression SourceExpression {
			get;
			set;
		}

		public List<SerializableJoin> Joins {
			get;
			set;
		}

		public List<SerializableParameter> Parameters {
			get;
			set;
		}

		public int Limit {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: SerializableJoin

	[Serializable]
	public class SerializableJoin : SerializableQuery
	{

		#region Properties: Public

		public JoinType JoinType {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SerializableCondition

	[Serializable]
	public class SerializableCondition
	{

		#region Properties: Public

		private readonly string _key = Guid.NewGuid().ToString();
		public string Key {
			get {
				return _key;
			}
		}

		public QueryConditionType ConditionType {
			get;
			set;
		}

		public bool IsNot {
			get;
			set;
		}

		public LogicalOperation LogicalOperation {
			get;
			set;
		}

		public SerializableExpression LeftExpression {
			get;
			set;
		}

		public List<SerializableExpression> RightExpressions {
			get;
			set;
		}

		public string ParentConditionKey {
			get;
			set;
		}

		public List<SerializableCondition> Items {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SerializableExpression

	[Serializable]
	public class SerializableExpression
	{

		#region Properties: Public

		public QueryColumnExpressionType ExpressionType {
			get;
			set;
		}

		public QuerySourceExpressionType SourceExpressionType {
			get;
			set;
		}

		public SerializableFunction Function {
			get;
			set;
		}

		public bool IsBlock {
			get;
			set;
		}

		public bool IsNegative {
			get;
			set;
		}

		public string Alias {
			get;
			set;
		}

		public string SourceAlias {
			get;
			set;
		}

		public string SourceColumnAlias {
			get;
			set;
		}

		public string ConstValue {
			get;
			set;
		}

		public SerializableParameter Parameter {
			get;
			set;
		}

		public SerializableQuery SubSelect {
			get;
			set;
		}

		public string SchemaName {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SerializableParameter

	public class SerializableParameter
	{

		#region Properties: Public

		public string Name {
			get;
			set;
		}

		public object Value {
			get;
			set;
		}

		public string ValueType {
			get;
			set;
		}

		public string ValueTypeName {
			get;
			set;
		}

		#endregion

	}

	#endregion
}


