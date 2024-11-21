namespace BPMSoft.Configuration.ForecastV2
{
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastEditColumnCalculator

	[DefaultBinding(typeof(IForecastCalculator), Name = ForecastConsts.EditableColumnTypeName)]
	public class ForecastEditColumnCalculator : IForecastCalculator
	{

		#region Fields: Private

		private IForecastColumnRepository _columnRepository;

		private IForecastGroupCellsProvider _groupCellsProvider;

		private IForecastSheetRepository _sheetRepository;

		#endregion

		private static readonly ILog _log = LogManager.GetLogger<ForecastEditColumnCalculator>();

		#region Constructors: Public

		public ForecastEditColumnCalculator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastGroupCellsProvider GroupCellsProvider =>
			_groupCellsProvider ?? (_groupCellsProvider = ClassFactory.Get<IForecastGroupCellsProvider>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected UserConnection UserConnection { get; private set; }

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetRefEntitiesESQ(Sheet sheet) {
			var forecastSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityInCellUId);
			string forecastSchemaName = forecastSchema.Name;
			var refColumn = sheet.GetEntityReferenceColumn(UserConnection);
			string linkTemplate = $"[{forecastSchemaName}:{refColumn.Name}:Id].";
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityUId));
			var hierarchy = sheet.GetHierarchyItems();
			esq.PrimaryQueryColumn.IsAlwaysSelect = false;
			esq.IgnoreDisplayValues = true;
			esq.IsDistinct = true;
			hierarchy.ForEach(item => {
				esq.AddColumn(item.ColumnPath);
			});
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, $"{linkTemplate}Sheet", sheet.Id));
			esq.Filters.Add(esq.CreateIsNullFilter($"{linkTemplate}ForecastColumn"));
			esq.Filters.Add(esq.CreateIsNullFilter($"{linkTemplate}Period"));
			return esq;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates forecast column values.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		/// <returns>Modified parameters.</returns>
		public ForecastCalcParams Calculate(ForecastCalcParams parameters) {
			parameters.CheckArgumentNull(nameof(parameters));
			_log.Info("ForecastEditColumnCalculator: Calculation started");
			var columns = ColumnRepository.GetColumns(parameters.ForecastId);
			var groupEditColumns = columns.Where(c => c.GetColumnSettings<EditableSetting>().IsGroupEdit);
			if (groupEditColumns.IsEmpty()) {
				_log.Info("ForecastEditColumnCalculator: No group edit columns found");
				return parameters;
			}
			var sheet = SheetRepository.GetSheet(parameters.ForecastId);
			if (sheet.GetHierarchyItems().IsEmpty()) {
				return parameters;
			}
			EntitySchemaQuery esq = GetRefEntitiesESQ(sheet);
			var referenceEntities = esq.GetEntityCollection(UserConnection);
			_log.Info($"ForecastEditColumnCalculator: Found {referenceEntities.Count()} groups to recalculate");
			GroupCellsProvider.RecalculateGroupCells(sheet, new RecalculateGroupCellsParameters {
				GroupEntities = referenceEntities
			});
			_log.Info($"ForecastEditColumnCalculator: Calculation finished");
			return parameters;
		}

		#endregion

	}

	#endregion

}

