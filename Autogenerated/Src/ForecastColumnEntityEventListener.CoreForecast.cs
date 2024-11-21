namespace BPMSoft.Configuration.ForecastV2
{
	using Newtonsoft.Json.Linq;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;
	using BPMSoft.UI.WebControls.ResourceHandlers;
	using global::Common.Logging;

	#region Class: ForecastColumnEntityEventListener

	/// <summary>
	/// ForecastColumn entity save event handler
	/// </summary>
	[EntityEventListener(SchemaName = "ForecastColumn")]
	public class ForecastColumnEntityEventListener : BaseEntityEventListener
	{

		#region Fields: Private

		private bool _isSettingsChanged;
		private bool _isFormulaColumn;
		private static readonly ILog _log = LogManager.GetLogger(nameof(ForecastColumnEntityEventListener));

		#endregion

		#region Methods: Private

		private bool IsSettingsChanged(Entity entity) {
			var changedColumns = entity.GetChangedColumnValues();
			return changedColumns.Any(columm => columm.Name.Equals("Settings"));
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
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("CalcFormulaOnSave")) {
				return;
			}
			var columnType = entity.GetTypedColumnValue<Guid>("TypeId");
			_isSettingsChanged = IsSettingsChanged(entity);
			_isFormulaColumn = columnType.Equals(ForecastConsts.FormulaColumnTypeId);
		}

		/// <summary>Handles entity Saved event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs"/> instance containing the event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (!userConnection.GetIsFeatureEnabled("CalcFormulaOnSave")) {
				return;
			}
			if (_isSettingsChanged && _isFormulaColumn) {
				var forecastId = entity.GetTypedColumnValue<Guid>("SheetId");
				IEnumerable<Guid> periodsId = ForecastExtensions.GetPeriodsId(userConnection, forecastId);
				var calculator = ClassFactory.Get<IForecastCalculator>(ForecastConsts.FormulaColumnTypeName,
					new ConstructorArgument("userConnection", userConnection));
				calculator.Calculate(new ForecastCalcParams(forecastId, periodsId));
			}
		}

		#endregion

	}

	#endregion
}

