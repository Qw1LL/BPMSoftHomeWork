namespace BPMSoft.Configuration.Campaigns
{
	using System;
	using System.Linq;

	#region Class: MacroValueReplacer

	/// <summary>
	/// Element for <see cref="ColumnValuesIterator"/> which replaces macro values.
	/// </summary>
	public class MacroValueReplacer : ColumnValuesIteratorElement
	{

		#region Methods: Public

		/// <summary>
		/// Replaces macro with value in columns.
		/// </summary>
		/// <param name="context"></param>
		public override void Process(ColumnValuesIteratorContext context) {
			if (!context.MacrosValues.Any()) {
				return;
			}
			var columnValues = context.ColumnValues.Where(c => c.HasMacrosValue && !c.IsTextColumn);
			foreach (var columnValue in columnValues) {
				var result = new ColumnValueResult(columnValue.ColumnUId);
				if (!string.IsNullOrWhiteSpace(columnValue.Value?.ToString())) {
					var macroValue = context.MacrosValues
						.FirstOrDefault(x => x.Alias == columnValue.Value.ToString()).Value;
					result.Value = macroValue;
				}
				context.Results.Add(columnValue.ColumnUId, result);
			}
		}

		#endregion

	}

	#endregion

}
