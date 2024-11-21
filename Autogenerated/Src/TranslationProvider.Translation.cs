namespace BPMSoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: TranslationProvider

	public class TranslationProvider : ITranslationProvider, ITranslationErrorHandler
	{

		#region Constants: Private

		private const string TranslationModifiedOnColumnName = "ModifiedOn";
		private const int MAX_ERRORMESSAGE_LENGTH = 500;

		#endregion

		#region Constants: Protected

		protected const string TranslationSchemaName = "SysTranslation";
		protected const string TranslationKeyColumnName = "Key";
		protected const string TranslationErrorColumnName = "ErrorMessage";

		#endregion

		#region Constructors: Public

		public TranslationProvider(UserConnection userConnection, ITranslationLogger translationLogger) {
			UserConnection = userConnection;
			TranslationLogger = translationLogger;
		}

		#endregion

		#region Fields: Private

		private readonly Regex _translationCultureIndexRegex = new Regex(@"Language(?<Index>\d+)");

		#endregion

		#region Fields: Protected

		protected DBExecutor _dbExecutor;

		#endregion

		#region Properties: Private

		private Dictionary<string, Update> _translationUpdateQueries;
		private Dictionary<string, Update> TranslationUpdateQueries {
			get {
				return _translationUpdateQueries ?? (_translationUpdateQueries = new Dictionary<string, Update>());
			}
		}

		private Dictionary<string, Insert> _translationInsertQueries;
		private Dictionary<string, Insert> TranslationInsertQueries {
			get {
				return _translationInsertQueries ?? (_translationInsertQueries = new Dictionary<string, Insert>());
			}
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
			private set;
		}

		protected ITranslationLogger TranslationLogger {
			get;
			private set;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets translation culture index.
		/// </summary>
		/// <param name="columnName">Translation key.</param>
		/// <param name="cultureIndex">System culture index.</param>
		/// <returns>
		/// <c>true</c>, if parameter <paramref name="cultureIndex"/> was initialized; <c>false</c> otherwise.
		/// </returns>
		private bool TryGetTranslationCultureIndex(string columnName, out int cultureIndex) {
			Match match = _translationCultureIndexRegex.Match(columnName);
			if (!match.Success) {
				cultureIndex = 0;
				return false;
			}
			Group indexMatch = match.Groups["Index"];
			return int.TryParse(indexMatch.Value, out cultureIndex);
		}

		private Update GetTranslationUpdateQuery(string key, string columnName, string columnValue) {
			Update tranlationUpdateQuery;
			if (!TranslationUpdateQueries.TryGetValue(columnName, out tranlationUpdateQuery)) {
				tranlationUpdateQuery =
					(Update)new Update(UserConnection, TranslationSchemaName)
						.Set(columnName, new QueryParameter(columnName, null))
					.Where(TranslationKeyColumnName).IsEqual(new QueryParameter(TranslationKeyColumnName, null));
				tranlationUpdateQuery.InitializeParameters();
				TranslationUpdateQueries.Add(columnName, tranlationUpdateQuery);
			}
			tranlationUpdateQuery.SetParameterValue(TranslationKeyColumnName, key);
			tranlationUpdateQuery.SetParameterValue(columnName, columnValue);
			return tranlationUpdateQuery;
		}

		private Insert GetTranslationInsertQuery(string key, string columnName, string columnValue) {
			Insert tranlationInsertQuery;
			if (!TranslationInsertQueries.TryGetValue(columnName, out tranlationInsertQuery)) {
				tranlationInsertQuery =
					new Insert(UserConnection)
					.Into(TranslationSchemaName)
						.Set(TranslationKeyColumnName, new QueryParameter(TranslationKeyColumnName, null))
						.Set(columnName, new QueryParameter(columnName, null));
				tranlationInsertQuery.InitializeParameters();
				TranslationInsertQueries.Add(columnName, tranlationInsertQuery);
			}
			tranlationInsertQuery.SetParameterValue(TranslationKeyColumnName, key);
			tranlationInsertQuery.SetParameterValue(columnName, columnValue);
			return tranlationInsertQuery;
		}

		private Select GetChangedTranslationsSelect(List<ISysCultureInfo> sysCulturesInfo) {
			Select select =
				new Select(UserConnection)
					.Column(TranslationModifiedOnColumnName)
					.Column(TranslationKeyColumnName)
				.From(TranslationSchemaName);
			QueryColumnExpression isTranslationChangedParameter = Column.Parameter(true);
			bool isConditionAdded = false;
			foreach (ISysCultureInfo sysCultureInfo in sysCulturesInfo) {
				string isChangedColumnName = sysCultureInfo.IsChangedColumnName;
				select
					.Column(sysCultureInfo.TranslationColumnName)
					.Column(isChangedColumnName);
				if (isConditionAdded) {
					select.Or(isChangedColumnName).IsEqual(isTranslationChangedParameter);
				} else {
					select.Where(isChangedColumnName).IsEqual(isTranslationChangedParameter);
					isConditionAdded = true;
				}
			}
			return select;
		}

		private void AddResetChangedStateColumns(Update tranlationsResetQuery, IEnumerable<ISysCultureInfo> sysCulturesInfo) {
			var resetStateValue = Column.Parameter(false);
			sysCulturesInfo.ForEach(sysCultureInfo => {
				string isChangedColumnName = sysCultureInfo.IsChangedColumnName;
				tranlationsResetQuery.Set(isChangedColumnName, resetStateValue);
			});
		}

		private void AddResetChangedStateConditions(Update tranlationsResetQuery, IEnumerable<ISysCultureInfo> sysCulturesInfo) {
			tranlationsResetQuery.Where(TranslationErrorColumnName).IsEqual(Column.Parameter(string.Empty));
			var changedLanguagesCondition = GetLanguageConditions(sysCulturesInfo);
			if (changedLanguagesCondition != null) {
				tranlationsResetQuery.And(changedLanguagesCondition);
			}
		}

		private static QueryCondition GetLanguageConditions(IEnumerable<ISysCultureInfo> sysCulturesInfo) {
			QueryCondition conditions = null;
			var rightExpression = Column.Parameter(true);
			sysCulturesInfo.ForEach(sysCultureInfo => {
				var condition = new QueryCondition(QueryConditionType.Equal) {
					LeftExpression = new QueryColumnExpression(sysCultureInfo.IsChangedColumnName),
					RightExpressions = {
						rightExpression
					}
				};
				if (conditions == null) {
					conditions = new QueryCondition(QueryConditionType.Block);
				} else {
					condition.LogicalOperation = LogicalOperation.Or;
				}
				conditions.Add(condition);
			});
			return conditions;
		}

		#endregion

		#region Methods: Protected

		protected int ExecuteQuery(IDBCommand query) {
			return _dbExecutor != null ? query.Execute(_dbExecutor) : query.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes translation.
		/// </summary>
		/// <param name="key">Resource key.</param>
		/// <param name="columnName">Translation column name.</param>
		/// <param name="columnValue">Translation column value.</param>
		public virtual void WriteTranslation(string key, string columnName, string columnValue) {
			Update update = GetTranslationUpdateQuery(key, columnName, columnValue);
			int rowsAffected = ExecuteQuery(update);
			if (rowsAffected < 1) {
				Insert insert = GetTranslationInsertQuery(key, columnName, columnValue);
				ExecuteQuery(insert);
			}
		}

		/// <summary>
		/// Selects changed translation columns values.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="readMethod">Translation column value processing method.</param>
		public void ReadChangedTranslationColumnsValues(Entity entity,
				Action<string, string, int, DateTime> readMethod) {
			IEnumerable<EntityColumnValue> changedColumnValues = entity.GetChangedColumnValues();
			foreach (EntityColumnValue changedColumnValue in changedColumnValues) {
				EntitySchemaColumn column = changedColumnValue.Column;
				if (column.UsageType.Equals(EntitySchemaColumnUsageType.Advanced)) {
					continue;
				}
				int cultureIndex;
				if (!TryGetTranslationCultureIndex(column.Name, out cultureIndex)) {
					continue;
				}
				string value = (string)changedColumnValue.Value;
				if (value.IsNullOrEmpty() && entity.StoringState.Equals(StoringObjectState.New)) {
					continue;
				}
				string key = entity.GetTypedColumnValue<string>(TranslationKeyColumnName);
				DateTime modifiedOn = entity.GetTypedColumnValue<DateTime>(TranslationModifiedOnColumnName);
				readMethod(key, value, cultureIndex, modifiedOn);
			}
		}

		/// <summary>
		/// Reads changed translations.
		/// <param name="sysCulturesInfo">Entity.</param>
		/// <param name="readMethod">Entity.</param>
		/// </summary>
		public void ReadChangedTranslations(List<ISysCultureInfo> sysCulturesInfo,
				Action<string, string, int, DateTime> readMethod) {
			Select select = GetChangedTranslationsSelect(sysCulturesInfo);
			select.ExecuteReader(dataReader => {
				string key = dataReader.GetColumnValue<string>(TranslationKeyColumnName);
				DateTime modifiedOn = dataReader.GetColumnValue<DateTime>(TranslationModifiedOnColumnName);
				foreach (ISysCultureInfo sysCultureInfo in sysCulturesInfo) {
					bool isChanged = dataReader.GetColumnValue<bool>(sysCultureInfo.IsChangedColumnName);
					if (!isChanged) {
						continue;
					}
					string value = dataReader.GetColumnValue<string>(sysCultureInfo.TranslationColumnName);
					readMethod(key, value, sysCultureInfo.Index, modifiedOn);
				}
			});
		}

		/// <summary>
		/// Resets changed translations state.
		/// <param name="sysCulturesInfo">System cultures information.</param>
		/// </summary>
		public void ResetChangedTranslationsState(IEnumerable<ISysCultureInfo> sysCulturesInfo) {
			var tranlationsResetQuery = new Update(UserConnection, TranslationSchemaName);
			AddResetChangedStateColumns(tranlationsResetQuery, sysCulturesInfo);
			AddResetChangedStateConditions(tranlationsResetQuery, sysCulturesInfo);
			ExecuteQuery(tranlationsResetQuery);
		}

		/// <summary>
		/// Executes action in transaction.
		/// <param name="action">Action.</param>
		/// </summary>
		public void Transaction(Action action) {
			using (_dbExecutor = UserConnection.EnsureDBConnection()) {
				_dbExecutor.StartTransaction();
				try {
					action();
					_dbExecutor.CommitTransaction();
				} catch (Exception e) {
					_dbExecutor.RollbackTransaction();
					TranslationLogger.Error(e);
					throw;
				}
			}
		}

		public void SaveErrors(Dictionary<string, string> erroneousRecords) {
			erroneousRecords.ForEach(errorPair => {
				string errorToSave = StringUtilities.Truncate(errorPair.Value, MAX_ERRORMESSAGE_LENGTH);
				var Update = GetTranslationUpdateQuery(errorPair.Key, TranslationErrorColumnName, errorToSave);
				Update.Execute();
			});
		}

		public void ResetErrors() {
			Update resetErrorsUpdate = new Update(UserConnection, TranslationSchemaName)
				.Set(TranslationErrorColumnName, new QueryParameter(TranslationErrorColumnName, null))
				.Where(TranslationErrorColumnName).IsNotEqual(Column.Parameter(string.Empty)) as Update;
			resetErrorsUpdate.InitializeParameters();
			resetErrorsUpdate.SetParameterValue(TranslationErrorColumnName, string.Empty);
			resetErrorsUpdate.Execute();
		}

		#endregion

	}

	#endregion

}

