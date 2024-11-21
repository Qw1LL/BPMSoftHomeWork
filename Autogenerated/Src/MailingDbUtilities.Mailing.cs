namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: MailingDbUtilities

	/// <summary>
	/// Utility class for work with database.
	/// </summary>
	public class MailingDbUtilities
	{

		#region Methods: Private

		/// <summary>
		/// Returns subquery that select top n items from query.
		/// </summary>
		/// <param name="select">Query instance.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="packageSize">Number of top items to be selected.</param>
		/// <returns>Query that selects top n items.</returns>
		private static Select GetTopItemsSelect(Select select, UserConnection userConnection, int packageSize) {
			return new Select(userConnection)
				.Top(packageSize)
				.Column(Column.Asterisk("ResultSelect"))
				.From(select).As("ResultSelect");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes InsertSelect splitted into packages.
		/// </summary>
		/// <param name="select">Select object.</param>
		/// <param name="getInsertSelect">Function that transforms Select into InsertSelect.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Count of inserted rows.</returns>
		public static int ExecuteInsertSelect(Select select, Func<Select, InsertSelect> getInsertSelect,
				UserConnection userConnection) {
			const int packageSize = 10000;
			var topItemsSelect = GetTopItemsSelect(select, userConnection, packageSize);
			topItemsSelect.SpecifyNoLockHints();
			var iterateInsertedCount = 0;
			var insertedCount = 0;
			do {
				var insertSelect = getInsertSelect(topItemsSelect);
				using (var dbExecutor = userConnection.EnsureDBConnection()) {
					iterateInsertedCount = insertSelect.Execute(dbExecutor);
					insertedCount += iterateInsertedCount;
				}
			} while (iterateInsertedCount == packageSize);
			return insertedCount;
		}

		/// <summary>
		/// Returns column expression with non-empty result.
		/// </summary>
		/// <param name="value">Value of column</param>
		/// <param name="columnName">Name of column.</param>
		/// <returns>Column expression with non-empty result.</returns>
		public static QueryColumnExpression GetIsNotEmptyCountColumnExpression(int value, string columnName) {
			QueryCase queryCase = new QueryCase();
			QueryCondition queryCondition = new QueryCondition(QueryConditionType.Equal) {
				LeftExpression = new QueryColumnExpression(columnName)
			};
			queryCondition.RightExpressions.Add(Column.Const(0));
			queryCase.AddWhenItem(queryCondition, Column.Parameter(value));
			queryCase.ElseExpression = new QueryColumnExpression(columnName);
			return new QueryColumnExpression(queryCase);
		}

		/// <summary>
		/// Returns expression that adds value to column value.
		/// </summary>
		/// <param name="columnName">Name of column.</param>
		/// <param name="value">Value to add.</param>
		/// <returns>Query expression that adds value to column value.</returns>
		public static QueryColumnExpression GetAddCountColumnExpression(string columnName, int value) {
			return QueryColumnExpression.Add(new QueryColumnExpression(columnName),
				new QueryColumnExpression(new QueryParameter(value)));
		}

		/// <summary>
		/// Runs stored procedure.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="spName">Stored procedure name.</param>
		/// <param name="parameters">Execution params.</param>
		/// <returns>Execution results.</returns>
		public static int ExecuteStoredProcedure(UserConnection userConnection, string spName,
				params KeyValuePair<string, object>[] parameters) {
			var sp = new StoredProcedure(userConnection, spName);
			foreach (var parameter in parameters) {
				sp.WithParameter(parameter.Key, parameter.Value);
			}
			return sp.Execute();
		}

		/// <summary>
		/// Adds when condition to case statement of select.
		/// </summary>
		/// <param name="queryCase">Case statement of select.</param>
		/// <param name="sourceTableAlias">Alias of table in left expression.</param>
		/// <param name="sourceColumnAlias">Alias of column in left expression.</param>
		/// <param name="conditionType">Type of comparison condition.</param>
		/// <param name="rightExpressionValue">Value of right expression.</param>
		/// <param name="thenValue">Value that is returned in then statement.</param>
		public static void AddWhenCondition(QueryCase queryCase, string sourceTableAlias, string sourceColumnAlias,
				QueryConditionType conditionType, object rightExpressionValue, object thenValue) {
			var whenCondition = new QueryCondition(conditionType) {
				LeftExpression = new QueryColumnExpression(sourceTableAlias, sourceColumnAlias)
			};
			if (conditionType != QueryConditionType.IsNull) {
				whenCondition.RightExpressions.Add(Column.Parameter(rightExpressionValue));
			}
			queryCase.AddWhenItem(whenCondition, Column.Parameter(thenValue));
		}

		#endregion
	}

	#endregion
}

