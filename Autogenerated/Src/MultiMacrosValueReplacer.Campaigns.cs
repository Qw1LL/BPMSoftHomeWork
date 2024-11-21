namespace BPMSoft.Configuration.Campaigns
{
	using System.Linq;
	using System.Text;
	using BPMSoft.Common;

	#region Class: MultiMacrosValueReplacer

	/// <summary>
	/// Element for <see cref="ColumnValuesIterator"/> which replaces multimacros values.
	/// </summary>
	public class MultiMacrosValueReplacer : ColumnValuesIteratorElement
	{

		#region Methods: Public

		/// <summary>
		/// Replaces macros with values in columns.
		/// </summary>
		/// <param name="context"></param>
		public override void Process(ColumnValuesIteratorContext context) {
			if (!context.MacrosValues.Any()) {
				return;
			}
			var columnValues = context.ColumnValues.Where(c => c.HasMacrosValue && c.IsTextColumn);
			foreach (var columnValue in columnValues) {
				var result = new ColumnValueResult(columnValue.ColumnUId);
				if (!string.IsNullOrWhiteSpace(columnValue.Value?.ToString())) {
					var stringBuilder = new StringBuilder(columnValue.Value.ToString());
					context.MacrosValues
						.ForEach(macro => {
							stringBuilder.Replace(macro.Alias, macro.StringValue);
						});
					result.Value = stringBuilder.ToString();
				}
				context.Results.Add(columnValue.ColumnUId, result);
			}
		}

		#endregion

	}

	#endregion

}
