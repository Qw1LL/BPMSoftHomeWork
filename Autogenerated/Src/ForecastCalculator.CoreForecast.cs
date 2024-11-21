namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;

	#region Class: ForecastCalculator

	/// <summary>
	/// Provides methods to calculate fact and potential of forecast.
	/// </summary>
	public class ForecastCalculator : IJobExecutor
	{

		#region Fields: Private

		private static Guid _factIndicatorId = new Guid("52CAE26F-84F6-42A0-AAEF-97790AF3B8D9");
		private static Guid _potentialIndicatorId = new Guid("A004FC7A-D63D-4E3C-9356-0AD77B2600F3");

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; private set; }
		protected Sheet ForecastSheet { get; private set; }
		protected List<Period> Periods { get; private set; }
		protected ColumnSetting ColumnSetting { get; private set; }

		private IEntityInForecastCellRepository _cellRepository;
		protected IEntityInForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IEntityInForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastSheetRepository _sheetRepository;
		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IPeriodRepository _periodRepository;
		protected IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private IForecastColumnRepository _columnRepository;
		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private string _referencedColumnValueName;
		protected string ReferencedColumnValueName {
			get { return _referencedColumnValueName ?? (_referencedColumnValueName = GetReferencedColumnValueName()); }
		}

		private string _calculatedEntityName;
		protected string CalculatedEntityName {
			get { return _calculatedEntityName ?? (_calculatedEntityName = GetCalculatedEntityName()); }
		}

		private Guid _completedStageId;
		protected Guid CompletedStageId {
			get { return _completedStageId.IsEmpty() 
					? (_completedStageId = GetCompletedStageId()) 
					: _completedStageId;
			}
		}

		#endregion

		#region Methods: Private

		private void PreparedParameters(IDictionary<string, object> parameters) {
			Guid forecastId;
			if (Guid.TryParse(parameters["ForecastId"]?.ToString(), out forecastId)) {
				ForecastSheet = SheetRepository.GetSheet(forecastId);
			}
			else {
				throw new ArgumentNullException(paramName: "ForecastId");
			}
			InitPeriods(parameters);
		}

		private void InitPeriods(IDictionary<string, object> parameters) {
			var periodIds = parameters["PeriodIds"] as List<Guid>;
			Periods = PeriodRepository.GetPeriods(periodIds).Where(p => p.StartDate <= DateTime.Now).ToList();
		}

		private List<(Guid, Guid, decimal, decimal)> Calculate(List<Cell> cells, List<Period> periods) {
			List<Guid> entityIds = cells.Select(c => c.EntityId).Distinct().ToList();
			List<(Guid, Guid, decimal, decimal)> result = new List<(Guid, Guid, decimal, decimal)>();
			periods.ForEach(p => {
				List<(Guid, decimal, decimal)> calculated = CalculateFactAndPotential(p, entityIds);
				List<(Guid, Guid, decimal, decimal)> res = 
					calculated.Select(c => (c.Item1, p.Id, c.Item2, c.Item3)).ToList();
				result.AddRange(res);
			});
			return result;
		}

		private void UpdateForecastCells() {
			List<Cell> cells = CellRepository.GetCells(ForecastSheet, Periods.Select(p => p.Id)).ToList();
			if (cells.IsNullOrEmpty()) {
				return;
			}
			List<(Guid entityId, Guid periodId, decimal fact, decimal potential)> data = 
				Calculate(cells, Periods);
			data.ForEach(d => {
				CellRepository.SaveCell(ForecastSheet, d.entityId, _factIndicatorId, d.periodId,
					new ValueInfo { Value = d.fact });
				CellRepository.SaveCell(ForecastSheet, d.entityId, _potentialIndicatorId, d.periodId,
					new ValueInfo { Value = d.potential });
			});
		}

		private string GetLocalizableString(string name) {
			return UserConnection.GetLocalizableString(GetType().Name, name) ?? string.Empty;
		}

		private void CreateReminding() {
			var remindingUtilities = ClassFactory.Get<RemindingUtilities>();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName("ForecastSheet");
			var _currentUserContactId = UserConnection.CurrentUser.ContactId;
			var config = new RemindingConfig(entitySchema.UId) {
				AuthorId = _currentUserContactId,
				ContactId = _currentUserContactId,
				SubjectId = ForecastSheet.Id,
				Description = GetLocalizableString("RemindingDescription"),
				PopupTitle = string.Format(GetLocalizableString("RemindingPopupTitle"), ForecastSheet.Name)
			};
			remindingUtilities.CreateReminding(UserConnection, config);
		}

		private ColumnSetting GetForecastColumnSettings() {
			ForecastColumn column = ColumnRepository.GetColumns(ForecastSheet.Id)
				.FirstOrDefault();
			if (column == null || column.Settings.IsNullOrWhiteSpace()) {
				return new ColumnSetting();
			}
			return Json.Deserialize<ColumnSetting>(column.Settings);
		}

		#endregion

		#region Methods: Protected

		protected virtual Guid GetCompletedStageId() {
			var stageRepository = ClassFactory.Get<OpportunityStageRepository>(
				new ConstructorArgument("userConnection", UserConnection));
			Guid? completedStage = stageRepository.GetAll().FirstOrDefault(s => s.IsEnd && s.IsSuccessful)?.Id;
			return completedStage.HasValue ? completedStage.Value : Guid.Empty;
		}

		protected virtual string GetCalculatedEntityName() {
			Guid uId = ColumnSetting.SourceUId;
			string name = uId != null
				? UserConnection.EntitySchemaManager.FindInstanceByUId(uId).Name
				: string.Empty;
			return name;
		}

		protected virtual string GetReferencedColumnValueName() {
			Guid columnUId = ColumnSetting.RefColumnId;
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(CalculatedEntityName);
			string columnName = columnUId != null
				? entitySchema.Columns.FirstOrDefault(c => c.UId == columnUId)?.ColumnValueName
				: string.Empty;
			return columnName;
		}

		protected virtual List<(Guid, decimal, decimal)> CalculateFactAndPotential(Period period, List<Guid> entityIds) {
			var columnName = ReferencedColumnValueName;
			List<(Guid, decimal, decimal)> result = new List<(Guid, decimal, decimal)>();
			if (columnName.IsNullOrEmpty()) {
				return result;
			}
			var select = new Select(UserConnection)
				.Column(columnName)
				.Column(Func.Sum("Amount")).As("Fact")
				.Column(Func.Sum(
					Column.SourceColumn("Amount") * Column.SourceColumn("Probability") / Column.Const(100))
				).As("Potential")
				.From(CalculatedEntityName).As("o")
				.Where("o", "StageId").IsEqual(Column.Parameter(CompletedStageId))
					.And("o", "DueDate").IsGreaterOrEqual(Column.Parameter(period.StartDate))
					.And("o", "DueDate").IsLess(Column.Parameter(period.DueDate))
					.And("o", columnName).In(Column.Parameters(entityIds))
				.GroupBy("o", columnName) as Select;
			select.ExecuteReader(reader => {
				decimal fact = reader.GetColumnValue<decimal>("Fact");
				decimal potential = reader.GetColumnValue<decimal>("Potential");
				Guid entityId = reader.GetColumnValue<Guid>(columnName);
				result.Add((entityId, fact, potential));
			});
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates forecasts.
		/// </summary>
		/// <param name="userConnection">Connection of user.</param>
		/// <param name="parameters">Job parameters.</param>
		public void Execute(UserConnection userConnection, IDictionary<string, object> parameters) {
			UserConnection = userConnection;
			PreparedParameters(parameters);
			ColumnSetting = GetForecastColumnSettings();
			UpdateForecastCells();
			CreateReminding();
		}

		#endregion
	} 

	#endregion
}
