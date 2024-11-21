  namespace BPMSoft.Configuration.ForecastV2
{
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	
	#region Class: FormulaSettingsEntityEventListener

	/// <summary>
	/// Provides functionality for automatic filling summary formula when formula column is created
	/// </summary>
	[EntityEventListener(SchemaName = "ForecastColumn")]
	public class SetDefaultFormulaSummaryValuesEEL : BaseEntityEventListener
	{
		
		#region Methods: Private
		
		private List<FormulaItem> CreateSummaryFormula(Entity entity) {
			var columnCaption = entity.GetTypedColumnValue<string>("Title");
			var columnId = entity.GetTypedColumnValue<string>("Id");
			var summaryFormula = new List<FormulaItem>() {
				new FormulaItem() {
					Caption = FunctionConstants.Sum,
					Value = FunctionConstants.Sum,
					Type = FormulaItemType.Function
				},
				new FormulaItem() {
					Caption = "(",
					Value = "(",
					Type = FormulaItemType.Operand
				},
				new FormulaItem() {
					Caption = columnCaption,
					Value = columnId,
					Type = FormulaItemType.Column
				},
				new FormulaItem() {
					Caption = ")",
					Value = ")",
					Type = FormulaItemType.Operand
				}
			};
			return summaryFormula;
		}
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			var typeId = entity.GetTypedColumnValue<string>("TypeId");
			if (typeId == null || !typeId.Equals(ForecastConsts.FormulaColumnTypeId.ToString())) {
				return;
			}
			var serializedSettings = entity.GetTypedColumnValue<string>("Settings");
			var settings = Json.Deserialize<FormulaSetting>(serializedSettings);
			if (settings == null) {
				return; 
			}
			if (settings.SummaryValue == null || !settings.SummaryValue.Any()) {
				var summaryFormula = CreateSummaryFormula(entity);
				settings.SummaryValue = summaryFormula;
				entity.SetColumnValue("Settings", JsonConvert.SerializeObject(settings));
			}
		}
	
		#endregion
	}

	#endregion

}


