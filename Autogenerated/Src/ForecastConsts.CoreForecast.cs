using System;

namespace BPMSoft.Configuration
{
	public static class ForecastConsts
	{
		public static readonly int MaxPeriodsCount = 24;

		public static readonly Guid ForecastEntitySchemaUId = new Guid("BA399098-A520-4A1B-9AB2-2EC7EA8D97C9");

		public static readonly string UpdateForecastsTopic = "UpdateForecasts";

		public static readonly string ForecastCalcStartedMessage = "ForecastCalcStarted";

		public static readonly string ForecastSheet = "ForecastSheet";

		public static readonly string LastCalculationDateTime = "LastCalculationDateTime";

		public static readonly string Name = "Name";

		public static readonly string PeriodType = "PeriodTypeId";

		public static readonly string ForecastEntity = "ForecastEntityId";

		public static readonly string ForecastEntityInCell = "ForecastEntityInCellUId";

		public static readonly string Setting = "Setting";

		public static readonly Guid ObjectValueColumnTypeId = new Guid("42DF643E-AC48-4E67-8F78-52D18BEECF10");

		public static readonly Guid EditableColumnTypeId = new Guid("85A0EDDC-0638-4CD5-B1D4-7F2F82FE514F");

		public static readonly Guid FormulaColumnTypeId = new Guid("1B401172-D1CE-4C75-8530-C5272B9B328D");

		public const string ObjectValueColumnTypeName = "ObjectValue";

		public const string EditableColumnTypeName = "Editable";

		public const string FormulaColumnTypeName = "Formula";

		public static readonly Guid FinanceRoleId = new Guid("8DDE850B-379D-4E50-99EC-B6CC41AFF2D3");

	}
}

