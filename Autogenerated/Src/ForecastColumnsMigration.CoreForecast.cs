namespace BPMSoft.Configuration.ForecastV2
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: ForecastColumnsMigration

	public static class ForecastColumnsMigration
	{
		#region Methods: Private

		private static FormulaItem OpenBrace() {
			return new FormulaItem {
				Type = FormulaItemType.Operand,
				Caption = "(",
				Value = "(",
			};
		}

		private static FormulaItem ClosedBrace() {
			return new FormulaItem {
				Type = FormulaItemType.Operand,
				Caption = ")",
				Value = ")",
			};
		}

		private static FormulaItem[] BuildSUMSelfFormula(ForecastColumn column) {
			return new [] {
				new FormulaItem {
					Type = FormulaItemType.Function,
					Caption = "SUM",
					Value = "SUM",
				},
				OpenBrace(),
				new FormulaItem {
					Type = FormulaItemType.Column,
					Caption = column.Name,
					Value = column.Id.ToString(),
				},
				ClosedBrace(),
			};
		}

		private static FormulaItem[] BuildSumAllFormula(FormulaSetting settings) {
			var value = settings.Value;
			if (value == null) {
				return new FormulaItem[]{};
			}
			var summaryValue = new List<FormulaItem>(value.Count() * 2);
			foreach (FormulaItem item in value) {
				if (item.Type != FormulaItemType.Column) {
					summaryValue.Add(item);
					continue;
				}
				summaryValue.Add(new FormulaItem {
					Type = FormulaItemType.Function,
					Caption = "SUM",
					Value = "SUM",
				});
				summaryValue.Add(OpenBrace());
				summaryValue.Add(item);
				summaryValue.Add(ClosedBrace());
			}
			return summaryValue.ToArray();
		}

		private static bool IsFormulaColumn(ForecastColumn column) {
			return column.TypeId == BPMSoft.Configuration.ForecastConsts.FormulaColumnTypeId;
		}

		private static bool ShouldMigrateColumn(FormulaSetting settings) {
			return settings.SummaryValue == null;
		}

		private static void ProcessSheetColumns(
			UserConnection userConnection, EntitySchema columnSchema, IEnumerable<ForecastColumn> columns)
		{
			foreach (ForecastColumn column in columns) {
				if (!IsFormulaColumn(column)) continue;
				FormulaSetting settings = column.GetColumnSettings<FormulaSetting>();
				if (!ShouldMigrateColumn(settings)) continue;
				var sumFormulaItems = settings.UseInSummary
					? BuildSumAllFormula(settings)
					: BuildSUMSelfFormula(column);
				settings.SummaryValue = sumFormulaItems;
				var newSettingsJson = JsonConvert.SerializeObject(settings);
				var entity = columnSchema.CreateEntity(userConnection);
				entity.FetchFromDB(column.Id);
				entity.SetColumnValue("Settings", newSettingsJson);
				entity.Save(false);
			}
		}

		#endregion

		#region Methods: Public

		public static bool RunMigration(UserConnection userConnection) {
			var schemaManager = userConnection.EntitySchemaManager;
			var columnsRepo = new ForecastColumnRepository(userConnection);
			var columnSchema = schemaManager.FindInstanceByName("ForecastColumn");
			var sheetSchema = schemaManager.FindInstanceByName("ForecastSheet");
			var sheetQuery = new EntitySchemaQuery(schemaManager, sheetSchema.Name);
			var idColumn = sheetQuery.AddColumn("Id");
			var sheets = sheetQuery.GetEntityCollection(userConnection);
			if (!sheets.Any()) return true;
			sheets.ForEach(sheet => {
				var sheetGuid = sheet.GetTypedColumnValue<Guid>(idColumn.Name);
				var sheetColumns = columnsRepo.GetColumns(sheetGuid);
				ProcessSheetColumns(userConnection, columnSchema, sheetColumns);
			});
			return true;
		}

		#endregion
	}

	#endregion
}
