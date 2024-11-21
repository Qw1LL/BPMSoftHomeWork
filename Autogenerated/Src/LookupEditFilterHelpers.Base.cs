namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.UI.WebControls.Controls;

	public static class LookupEditFilterHelpers
	{
	
		public static void SetLookupFilter(LookupEdit targetEdit, List<LookupEdit> sourceEdits, 
			Dictionary<string, string> bindings) {
			foreach (var source in sourceEdits) {
				source.AjaxEvents.Change.Event += (seneder, e) => {
					targetEdit.SuspendAjaxEvents();
					targetEdit.Clear();
					targetEdit.ResumeAjaxEvents();
				};
			}
			targetEdit.PrepareLookupFilter += (sender, e) => {
				e.Filters.Clear();
				foreach (var source in sourceEdits) {
					var value = source.Value;
					var id = value != null ? (Guid) value : Guid.Empty;
					if (id == Guid.Empty) {
						continue;
					}
					e.Filters.Add(new Dictionary<string, object> {
						{"comparisonType", FilterComparisonType.Equal},
						{"leftExpressionColumnPath", bindings[source.ClientID]},
						{"useDisplayValue", false},
						{"rightExpressionParameterValues", new object[] {id}}});
				}
			};
		
		}	
	}
}
