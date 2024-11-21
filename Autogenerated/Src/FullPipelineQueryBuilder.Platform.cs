namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Nui.ServiceModel.Extensions;
	using BPMSoft.Core.Factories;

	#region Class: FullPipelineQueryBuilder

	/// <summary>
	/// Provides method of query build for full pipeline data.
	/// </summary>
	[DefaultBinding(typeof(IFullPipelineQueryBuilder))]
	public class FullPipelineQueryBuilder : IFullPipelineQueryBuilder
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IGetRepositoryFactory<CommonStageData> _stageRepositoryFactory;
		private readonly ISysModuleStageHistoryRepository _stageSettingsRepository;
		private IEnumerable<FullPipelineEntityConfig> _pipelineEntityConfigs;
		private StageHistorySetting _stageHistorySetting;
		private IEnumerable<CommonStageData> _stages;
		private string _schemaName;

		#endregion

		#region Properties: Protected

		
		private StageHistorySetting StageHistorySetting => _stageHistorySetting ?? 
			(_stageHistorySetting = GetStageHistorySetting(SchemaName));

		private string SchemaName {
			get => _schemaName;
			set {
				_stageHistorySetting = null;
				_stages = null;
				_schemaName = value;
			}
		}

		private IEnumerable<CommonStageData> Stages {
			get {
				if (_stages == null) {
					var stageRepository = _stageRepositoryFactory.GetRepository(StageHistorySetting);
					_stages = stageRepository.GetAll();
				}
				return _stages;
			}
		}

		#endregion

		#region Constructors: Public

		public FullPipelineQueryBuilder(UserConnection userConnection,
				IGetRepositoryFactory<CommonStageData> stageRepositoryFactory,
				ISysModuleStageHistoryRepository stageSettingsRepository) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			stageRepositoryFactory.CheckArgumentNull(nameof(stageRepositoryFactory));
			stageSettingsRepository.CheckArgumentNull(nameof(stageSettingsRepository));
			_userConnection = userConnection;
			_stageRepositoryFactory = stageRepositoryFactory;
			_stageSettingsRepository = stageSettingsRepository;
		}

		#endregion

		#region Methods: Private

		private StageHistorySetting GetStageHistorySetting(string schemaName) {
			return _stageSettingsRepository.Get(schemaName);
		}

		private void ApplyPeriodFilter(Select select, FullPipelineEntityConfig pipelineEntityConfig,
				StageHistorySetting stageHistorySetting) {
			if (pipelineEntityConfig.StartDate != null) {
				var queryCondition = new QueryCondition(QueryConditionType.GreaterOrEqual) {
					LeftExpression = new QueryColumnExpression(stageHistorySetting.StageHistorySchemaName, 
						stageHistorySetting.StageHistoryStartDateColumnName)
				};
				queryCondition.IsGreaterOrEqual(Column.Parameter(DateTime.Parse(pipelineEntityConfig.StartDate)));
				select.AddCondition(queryCondition, LogicalOperation.And);
			}
			if (pipelineEntityConfig.DueDate != null) {
				var queryCondition = new QueryCondition(QueryConditionType.LessOrEqual) {
					LeftExpression = new QueryColumnExpression(stageHistorySetting.StageHistorySchemaName,
						stageHistorySetting.StageHistoryStartDateColumnName)
				};
				queryCondition.IsLessOrEqual(Column.Parameter(DateTime.Parse(pipelineEntityConfig.DueDate)));
				select.AddCondition(queryCondition, LogicalOperation.And);
			}
		}

		private Select DecorateWithFilters(Select select, FullPipelineEntityConfig pipelineEntityConfig, 
				StageHistorySetting stageHistorySetting) {
			ApplyPeriodFilter(select, pipelineEntityConfig, stageHistorySetting);
			if (pipelineEntityConfig.Filters.IsNullOrWhiteSpace()) {
				return select;
			}
			var filters = pipelineEntityConfig.GetFilters();
			var esqFilters = filters.BuildEsqFilter(stageHistorySetting.EntitySchemaUId,
				_userConnection);
			var queryFilterCollection = esqFilters as EntitySchemaQueryFilterCollection;
			if (queryFilterCollection.Count == 0) {
				return select;
			}
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, stageHistorySetting.EntitySchemaName) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (queryFilterCollection != null) {
				esq.Filters.LogicalOperation = queryFilterCollection.LogicalOperation;
				esq.Filters.IsNot = queryFilterCollection.IsNot;
				foreach (IEntitySchemaQueryFilterItem filter in queryFilterCollection) {
					esq.Filters.Add(filter);
				}
			} else {
				esq.Filters.Add(esqFilters);
			}
			var filterSelect = esq.GetSelectQuery(_userConnection);
			var condition = filterSelect.Condition;
			condition.ConditionType = QueryConditionType.Block;
			return select.AddCondition(condition, LogicalOperation.And) as Select;
		}

		private QueryCase CreateAggregationQueryCase(QueryColumnExpression returnValue) {
			var queryCase = new QueryCase();
			var endStatuses = Stages.Where(e => e.IsEnd)
				.Select(e => e.Id);
			queryCase.AddWhenItem(new QueryCondition(QueryConditionType.IsNull) {
				LeftExpression = new QueryColumnExpression(StageHistorySetting.StageHistorySchemaName,
					StageHistorySetting.StageHistoryDueDateColumnName)
			}, returnValue);
			if (endStatuses.Any()) {
				var statusesCondition = new QueryCondition(QueryConditionType.In) {
					LeftExpression = new QueryColumnExpression(StageHistorySetting.StageHistorySchemaName,
					$"{StageHistorySetting.StageHistoryStageColumnName}Id")
				};
				statusesCondition.RightExpressions.AddExpressionsRange(Column.Parameters(endStatuses));
				queryCase.AddWhenItem(statusesCondition, returnValue);
			}
			queryCase.SetElseExpression(Column.Const(0));
			return queryCase;
		}

		private Select BuildExistsFilterQuery(FullPipelineEntityConfig pipelineEntityConfig) {
			var schemaName = pipelineEntityConfig.SchemaName;
			var historySetting = GetStageHistorySetting(schemaName);
			var select = new Select(_userConnection)
				.From(pipelineEntityConfig.SchemaName)
				.Column(Column.Const(1))
				.InnerJoin(historySetting.StageHistorySchemaName)
				.On(historySetting.StageHistorySchemaName, $"{historySetting.StageHistoryMainEntityColumnName}Id")
				.IsEqual(pipelineEntityConfig.SchemaName, "Id") as Select;
			return DecorateWithFilters(select, pipelineEntityConfig, historySetting);
		}

		private Select DecorateWithPreviousEntityFilter(Select select,
				FullPipelineEntityConfig mainPipelineConfig) {
			var connectionSchemaName = mainPipelineConfig.ConnectedWith.ConnectionSchemaName;
			var previousPiplineConfig = _pipelineEntityConfigs
				.FirstOrDefault(member => member.SchemaName.Equals(connectionSchemaName));
			var existsQuery = BuildExistsFilterQuery(previousPiplineConfig);
			if (previousPiplineConfig.ConnectedWith != null) {
				existsQuery = DecorateWithPreviousEntityFilter(existsQuery, previousPiplineConfig);
			}
			if (mainPipelineConfig.ConnectedWith.Type != FullPipelineSchemaConnectionType.ManyToMany) {
				existsQuery
					.And(mainPipelineConfig.SchemaName,
						mainPipelineConfig.ConnectedWith.ChildSchemaColumnName)
					.IsEqual(previousPiplineConfig.SchemaName,
						$"{mainPipelineConfig.ConnectedWith.ParentSchemaColumnName}Id");
			} else {
				throw new NotImplementedException();
			}
			return select.And().Exists(existsQuery) as Select;
		}

		private Select InnerBuildQuery() {
			var select = GetMainSelect();
			var mainPiplineConfig = _pipelineEntityConfigs
				.FirstOrDefault(member => member.SchemaName.Equals(SchemaName));
			var overallCountCase = CreateAggregationQueryCase(Column.Const(1));
			select.Column(StageHistorySetting.StageHistorySchemaName,
					$"{StageHistorySetting.StageHistoryStageColumnName}Id")
				.As(FullPipelineQueryConsts.StageIdColumnName);
			select.Column(Func.Count(Column.Const(1))).As(FullPipelineQueryConsts.OverallStageCountColumnName);
			select.Column(Func.Sum(new QueryColumnExpression(overallCountCase)))
				.As(FullPipelineQueryConsts.CurrentInStageCountColumnName);
			AddCalculatedColumns(select, mainPiplineConfig);
			if (mainPiplineConfig.ConnectedWith != null) {
				DecorateWithPreviousEntityFilter(select, mainPiplineConfig);
			}
			return DecorateWithFilters(select, mainPiplineConfig, StageHistorySetting);
		}

		private void AddCalculatedColumns(Select select, FullPipelineEntityConfig pipelineEntityConfigs) {
			foreach (var operation in pipelineEntityConfigs.CalculatedOperations) {
				if (operation.Operation.ToLower(_userConnection.CurrentUser.Culture).Equals("amount")) {
					AddAmountCalcColumn(select, operation);
				}
			}
		}

		private void AddAmountCalcColumn(Select select, CalculatedOperation operation) {
			var columnExpression = new QueryColumnExpression(
				SchemaName, operation.TargetColumnName);
			var amountCase = CreateAggregationQueryCase(columnExpression);
			select.Column(Func.Sum(new QueryColumnExpression(amountCase))).As(operation.Operation);
		}

		private Select GetMainSelect() {
			var stageHistorySchemaName = StageHistorySetting.StageHistorySchemaName;
			if (!Stages.Any()) {
				var localizableExceptionMessage = _userConnection.GetLocalizableString("FullPipelineQueryBuilder",
					"NoStagesToShowInPipeline");
				throw new NoStagesToShowInPipelineException(string.Format(localizableExceptionMessage, SchemaName));
			}
			var select = new Select(_userConnection)
				.From(stageHistorySchemaName)
				.InnerJoin(SchemaName)
					.On(stageHistorySchemaName, $"{StageHistorySetting.StageHistoryMainEntityColumnName}Id")
					.IsEqual(SchemaName, "Id")
				.Where(stageHistorySchemaName, StageHistorySetting.StageHistoryHistoricalColumnName)
					.IsEqual(Column.Parameter(false))
					.And(stageHistorySchemaName, $"{StageHistorySetting.StageHistoryStageColumnName}Id").In
						(Column.Parameters(Stages.Select(e => e.Id)))
				.GroupBy(stageHistorySchemaName, $"{StageHistorySetting.StageHistoryStageColumnName}Id") as Select;
			return select;
		}

		#endregion

		#region Methods: Public

		public Select BuildQuery(IEnumerable<FullPipelineEntityConfig> configs, string schemaName) {
			schemaName.CheckArgumentNullOrWhiteSpace(nameof(schemaName));
			configs.CheckArgumentNull(nameof(configs));
			SchemaName = schemaName;
			_pipelineEntityConfigs = configs;
			return InnerBuildQuery();
		}

		#endregion

	}

	#endregion

	#region Class: NoStagesToShowInPipelineException

	public class NoStagesToShowInPipelineException: ApplicationException
	{

		#region Constructors: Public

		public NoStagesToShowInPipelineException(string message): base(message) { }

		#endregion

	}

	#endregion
}

