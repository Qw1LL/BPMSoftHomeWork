 namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: SelectQueryConfig

	/// <summary>
	/// Config used to pass data to GetSelectQueryWithOptions(SelectQueryConfig config) method
	/// </summary>
	public class SelectQueryConfig
	{
		public Select Select {
			get; set;
		}
		public Sheet Sheet {
			get; set;
		}
		public PageableConfig PageableConfig {
			get; set;
		}

		public IEnumerable<HierarchySettingItem> Hierarchy {
			get; set;
		}

	}

	#endregion

	#region Class: BaseForecastHierarchyRowRepository

	/// <summary>
	/// Base class for actual and historical hierarchy row data repositories.
	/// </summary>
	public abstract class BaseForecastHierarchyRowRepository
	{
		#region Constants: Protected

		protected const string ForecastEntityAlias = "FE";
		protected const string ForecastRowAlias = "FR";
		protected const string LczIdColumnName = "RecordId";
		protected const string IdColumnName = "Id";
		protected const string ForecastRowSchemaName = "ForecastRow";
		protected const string ForecastEnityInCellAlias = "FEIC";

		#endregion

		#region Fields: Private

		private IForecastRowSortStrategy _forecastRowSortStrategy;
		private IForecastAddRowColumnsQueryBuilder _addRowColumnsQueryBuilder;

		#endregion

		#region Properties: Protected

		private UserConnection _userConnection;

		protected UserConnection UserConnection {
			get => _userConnection;
			set {
				value.CheckArgumentNull(nameof(UserConnection));
				_userConnection = value;
			}
		}

		protected IForecastRowSortStrategy ForecastRowSortStrategy {
			get {
				return _forecastRowSortStrategy ??
					(_forecastRowSortStrategy = ClassFactory.Get<IForecastRowSortStrategy>());
			}
		}

		protected IForecastAddRowColumnsQueryBuilder AddRowColumnsQueryBuilder {
			get {
				return _addRowColumnsQueryBuilder ??
					(_addRowColumnsQueryBuilder = ClassFactory.Get<IForecastAddRowColumnsQueryBuilder>(
						new ConstructorArgument("userConnection", UserConnection)));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="ForecastRowQueryBuilder"/>
		/// </summary>
		/// <param name="userConnection"></param>
		public BaseForecastHierarchyRowRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Protected

		protected IEnumerable<HierarchyRow> GetSelectQueryWithOptions(SelectQueryConfig config) {
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(config.Sheet.ForecastEntityUId);
			var pageableConfig = config.PageableConfig;
			var level = pageableConfig.HierarchyLevel;
			var columns = GetHierarchyColumns(entitySchema, config.Hierarchy).Where(c => c.Key <= level);
			var select = config.Select;
			AddRowColumnsQueryBuilder.AddColumnsToSelect(select, columns, new AddRowColumnsQueryBuilderParams {
				ForecastSchema = entitySchema,
				SelectEntityAlias = ForecastEntityAlias
			});
			AddConditions(select, config);
			if (!pageableConfig.IgnoreRights) {
				AddRightsConditions(config.Sheet, select, entitySchema);
			}
			if (level > 0) {
				AddHierarhyConditions(select, columns.Where(c => c.Key < level), pageableConfig.HierarchyRowsId);
			}
			if (!string.IsNullOrEmpty(pageableConfig.PrimaryFilterValue)) {
				EntitySchema forecastEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entitySchema.Name);
				select.AddCondition(Func.Upper(ForecastEntityAlias, forecastEntitySchema.PrimaryDisplayColumn.Name),
						LogicalOperation.And)
					.IsLike(Column.Parameter($"%{pageableConfig.PrimaryFilterValue.ToUpper()}%"));
			}
			if (pageableConfig.RowCount > 0 && pageableConfig.RowsOffset >= 0) {
				select = GetPageableSelect(select, pageableConfig);
			}
			AddOrderOptions(config.Sheet, select, level);
			var lastHierarchyColumn = columns.First(c => c.Key == level);
			var emptyValue = GetEmptyHierarchyValue(lastHierarchyColumn.Value, entitySchema);
			var result = GetFilledHierarchyRows(select, level, emptyValue);
			return result;
		}

		protected virtual Select AddConditions(Select select, SelectQueryConfig config) {
			var recordIds = config.PageableConfig.RecordIds;
			if (recordIds.IsNullOrEmpty()) {
				return select.Where(Column.Const(1)).IsEqual(Column.Const(1)) as Select;
			}
			var filterRecords = recordIds.ToList();
			bool containsEmptyValue = filterRecords.Any(id => id == Guid.Empty);
			if (containsEmptyValue) {
				filterRecords.Remove(Guid.Empty);
			}
			var idColumn = select.Columns[1];
			if (filterRecords.IsNotEmpty()) {
				select.AddCondition(idColumn, LogicalOperation.Or).In(Column.Parameters(filterRecords));
			}
			if (containsEmptyValue) {
				select.AddCondition(idColumn, LogicalOperation.Or).IsNull();
			}
			return select;
		}

		protected virtual Select GetForecastEntitySelect(string forecastEntityName, Sheet sheet) {
			EntitySchema entityInCellSchema = GetForecastRowsSchema(sheet);
			string entityInCellSchemaName = entityInCellSchema.Name;
			var forecastEntityColumnValueName = sheet.GetEntityReferenceColumn(UserConnection)?.ColumnValueName;
			Select select = new Select(UserConnection).From(forecastEntityName).As(ForecastEntityAlias)
				.Join(JoinType.Inner, entityInCellSchemaName).As(ForecastEnityInCellAlias).On(ForecastEntityAlias, "Id")
				.IsEqual(ForecastEnityInCellAlias, forecastEntityColumnValueName).And(ForecastEnityInCellAlias, "SheetId")
				.IsEqual(Column.Parameter(sheet.Id)) as Select;
			return select;
		}

		protected virtual EntitySchema GetForecastRowsSchema(Sheet sheet) {
			EntitySchema entityInCellSchema =
				UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityInCellUId);
			return entityInCellSchema;
		}

		protected QueryCondition GetRightsCondition(Select select, EntitySchema forecastEntitySchema) {
			var securityEngine = UserConnection.DBSecurityEngine;
			var rightsCondition = securityEngine.GetRecordsByRightCondition(new RecordsByRightOptions {
				EntitySchemaName = forecastEntitySchema.Name,
				EntitySchemaSourceAlias = @select.SourceExpression.Alias,
				RightEntitySchemaName = securityEngine.GetRecordRightsSchemaName(forecastEntitySchema.Name),
				Operation = Core.Configuration.EntitySchemaRecordRightOperation.Read,
				PrimaryColumnName = forecastEntitySchema.GetPrimaryColumnName(),
				UserId = UserConnection.CurrentUser.Id,
				UseDenyRecordRights = forecastEntitySchema.UseDenyRecordRights
			});
			return rightsCondition;
		}

		protected void AddHierarhyConditions(Select select, IEnumerable<KeyValuePair<int, string>> columns,
			IEnumerable<Guid> hierarchyRowsId) {
			columns.ForEach(c => {
				if (c.Key > hierarchyRowsId.Count() - 1) {
					return;
				}
				var value = hierarchyRowsId.ElementAt(c.Key);
				var sourceAlias = @select.Columns.GetByAlias($"hierarchyColumn{c.Key}Id")?.SourceAlias;
				if (sourceAlias.IsNotNullOrEmpty()) {
					string columnName = "Id";
					var condition = @select.AddCondition(sourceAlias, columnName, LogicalOperation.And);
					if (value.IsEmpty()) {
						condition.IsNull();
					} else {
						condition.IsEqual(Column.Parameter(value));
					}
				}
			});
		}

		protected Select GetPageableSelect(Select select, PageableConfig pageableConfig) {
			if (GlobalAppSettings.UseOffsetFetchPaging) {
				@select.OffsetFetch(pageableConfig.RowsOffset, pageableConfig.RowCount);
				return @select;
			}
			var conditionColumn = @select.Columns[0];
			var direction = PageableSelectDirection.First;
			var conditionValue = string.Empty;

			if (pageableConfig.LastValue.IsNotNullOrEmpty()) {
				direction = PageableSelectDirection.Next;
				conditionValue = pageableConfig.LastValue;
			}
			var options = new PageableSelectOptions(null, pageableConfig.RowCount, direction);
			options.AddCondition(conditionColumn, new QueryParameter("columnLastValue", conditionValue));
			Select pageableSelect = @select.ToPageable(options);
			return pageableSelect.Top(pageableConfig.RowCount);
		}

		protected void AddForecastRowRightsCondition(Sheet sheet, Select select) {
			var securityEngine = UserConnection.DBSecurityEngine;
			EntitySchema forecastRowSchema =
				UserConnection.EntitySchemaManager.GetInstanceByName(ForecastRowSchemaName);
			var forecastRowCondition = securityEngine.GetRecordsByRightCondition(new RecordsByRightOptions {
				EntitySchemaName = ForecastRowSchemaName,
				EntitySchemaSourceAlias = ForecastRowAlias,
				RightEntitySchemaName = securityEngine.GetRecordRightsSchemaName(ForecastRowSchemaName),
				Operation = Core.Configuration.EntitySchemaRecordRightOperation.Read,
				PrimaryColumnName = IdColumnName,
				UserId = UserConnection.CurrentUser.Id,
				UseDenyRecordRights = forecastRowSchema.UseDenyRecordRights
			});
			if (forecastRowCondition != null) {
				@select.InnerJoin(ForecastRowSchemaName).As(ForecastRowAlias).On(ForecastRowAlias, IdColumnName)
					.IsEqual(ForecastEnityInCellAlias, "RowId");
				@select.AddCondition(forecastRowCondition, LogicalOperation.And);
			}
		}

		protected void AddRightsConditions(Sheet sheet, Select select, EntitySchema entitySchema) {
			var rightsCondition = GetRightsCondition(@select, entitySchema);
			if (rightsCondition != null) {
				@select.AddCondition(rightsCondition, LogicalOperation.And);
			}
			if (UserConnection.GetIsFeatureEnabled("ForecastRowRights")) {
				AddForecastRowRightsCondition(sheet, @select);
			}
		}

		protected void AddOrderOptions(Sheet sheet, Select @select, int level) {
			if (GlobalAppSettings.UseOffsetFetchPaging) {
				ForecastRowSortStrategy.ApplySortOptions(@select, new ForecastRowSortStrategyParams {
					Sheet = sheet,
					CurrentHierarchyLevel = level
				});
				var idColumn = @select.Columns[1];
				@select.OrderByAsc(idColumn);
			}
		}

		protected IEnumerable<HierarchyRow> GetFilledHierarchyRows(Select select, int level, string emptyValue) {
			var result = new List<HierarchyRow>();
			select.ExecuteReader(reader => {
				Guid id = reader.GetColumnValue<Guid>($"hierarchyColumn{level}Id");
				string value = reader.GetColumnValue<string>($"hierarchyColumn{level}");
				if (id.IsEmpty()) {
					value = emptyValue;
				}
				var hierarchyRow = new HierarchyRow() {
					RecordId = id,
					Value = value
				};
				result.Add(hierarchyRow);
			});
			return result;
		}

		protected string GetEmptyHierarchyValue(string columnName, EntitySchema entitySchema) {
			string message = new LocalizableString(UserConnection.ResourceStorage,
				nameof(ForecastHierarchyRowDataRepository), "LocalizableStrings.EmptyHierarchyValue.Value");
			var entityColumn = entitySchema.GetSchemaColumnByPath(columnName);
			return string.Format(message, entityColumn.Caption);
		}

		protected IDictionary<int, string> GetHierarchyColumns(EntitySchema entitySchema,
			IEnumerable<HierarchySettingItem> hierarchy) {
			var columns = new Dictionary<int, string>();
			if (!hierarchy.IsNullOrEmpty()) {
				foreach (HierarchySettingItem settingItem in hierarchy.OrderBy(a => a.Level)) {
					columns[columns.Keys.Count] = settingItem.ColumnPath;
				}
			}
			var primaryDisplayColumnName = entitySchema.GetPrimaryDisplayColumnName();
			columns[columns.Keys.Count] = primaryDisplayColumnName;
			return columns;
		}

		#endregion
	}

	#endregion

}

