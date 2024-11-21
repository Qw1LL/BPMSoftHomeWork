namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Factories;

	#region Class: ForecastSheetEEL

	/// <summary>
	/// ForecastSheet entity event handler
	/// </summary>
	[EntityEventListener(SchemaName = "ForecastSheet")]
	public class ForecastSheetEEL : BaseEntityEventListener
	{

		#region Fields: Private

		private bool _isAutoCalcSettingsChanged;
		private bool _isAutoSnapshotSettingsChanged;
		private bool _isTimeZoneChanged;
		private UserConnection _userConnection;
		private SheetSetting _sheetSetting;
		private SheetSetting _oldSheetSetting;
		private bool _isSettingsNotChanged;
		private TimeZoneInfo _timeZoneInfo;

		#endregion

		#region Properties: Protected

		private IAppSchedulerWraper _schedulerWrapper;
		protected IAppSchedulerWraper SchedulerWraper {
			get {
				return _schedulerWrapper ?? (_schedulerWrapper = ClassFactory.Get<IAppSchedulerWraper>());
			}
		}

		#endregion

		#region Properties: Protected

		private IForecastCalculationScheduler _forecastCalculationScheduler;
		private IForecastSnapshotScheduler _forecastSnapshotScheduler;

		public IForecastCalculationScheduler ForecastCalculationScheduler {
			get {
				if (_forecastCalculationScheduler != null) {
					return _forecastCalculationScheduler;
				}
				return _forecastCalculationScheduler = ClassFactory.Get<IForecastCalculationScheduler>(
					new ConstructorArgument("userConnection", _userConnection),
					new ConstructorArgument("wrapper", SchedulerWraper));
			}
			set {
				_forecastCalculationScheduler = value;
			}
		}

		public IForecastSnapshotScheduler ForecastSnapshotScheduler {
			get => _forecastSnapshotScheduler ??
				(_forecastSnapshotScheduler = ClassFactory.Get<IForecastSnapshotScheduler>(
					new ConstructorArgument("userConnection", _userConnection),
					new ConstructorArgument("wrapper", SchedulerWraper)));
			set => _forecastSnapshotScheduler = value;
		}

		#endregion

		#region Methods: Private

		private bool IsSettingsChanged(Entity entity) {
			var changedColumns = entity.GetChangedColumnValues();
			return changedColumns.Any(column => column.Name.Equals("Setting"));
		}

		private bool IsAutoCalculateSettingsChanged() {
			if (_isSettingsNotChanged) {
				return false;
			}
			if (_sheetSetting?.AutoCalculation == null) {
				return false;
			}
			bool isAutoCalcStateChanged = !_sheetSetting.AutoCalculation.Equals(_oldSheetSetting?.AutoCalculation);
			return isAutoCalcStateChanged;
		}
		
		private bool GetIsTimeZoneChanged() {
			if (_isSettingsNotChanged) {
				return false;
			}
			if (_sheetSetting?.TimeZoneId == null) {
				return false;
			}
			bool isTimeZoneChanged = !_sheetSetting.TimeZoneId.Equals(_oldSheetSetting?.TimeZoneId);
			return isTimeZoneChanged;
		}

		private void InitializeSheetSettings(Entity entity) {
			var settings = entity.SafeGetColumnValue<string>("Setting");
			_sheetSetting = GetSheetSettings(settings);
			if (!_isSettingsNotChanged) {
				return;
			}
			var oldSettings = entity.GetTypedOldColumnValue<string>("Setting");
			_oldSheetSetting = GetSheetSettings(oldSettings);
		}

		private static SheetSetting GetSheetSettings(string settings) {
			if (settings == null) {
				return null;
			}
			var forecastSheetSettings = JsonConvert.DeserializeObject<SheetSetting>(settings);
			return forecastSheetSettings;
		}

		private TimeZoneInfo GetTimeZoneInfo() {
			if (_userConnection.GetIsFeatureEnabled("ForecastSnapshot") && _sheetSetting?.TimeZoneId != null) {
				if (_timeZoneInfo == null) {
					string code = GetTimeZoneCode();
					_timeZoneInfo = TimeZoneUtilities.GetTimeZoneInfo(code);
				}
				return _timeZoneInfo;
			}
			return TimeZoneInfo.Utc;
		}

		private string GetTimeZoneCode() {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("TimeZone");
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddColumn("Code");
			Entity entity = esq.GetEntity(_userConnection, _sheetSetting.TimeZoneId);
			var code = entity.GetTypedColumnValue<string>("Code");
			return code;
		}

		private void ScheduleForecastAutoCalculation(Entity entity) {
			if (!_isAutoCalcSettingsChanged && !_isTimeZoneChanged) {
				return;
			}
			var forecastId = entity.GetTypedColumnValue<Guid>("Id");
			AutoCalculationSettings autoCalcSettings = _sheetSetting.AutoCalculation;
			if (autoCalcSettings == null) {
				return;
			}
			ForecastCalculationScheduler.RemoveJobs(new QuartzSchedulerConfig() {
				ForecastId = forecastId
			});
			if (autoCalcSettings.IsEnabled) {
				ForecastCalculationScheduler.ScheduleJobs(new QuartzSchedulerConfig() {
					ForecastId = forecastId,
					CroneExpression = autoCalcSettings.CronExpression,
					TimeZoneInfo = GetTimeZoneInfo()
				});
			}
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
			_userConnection = entity.UserConnection;
			_isSettingsNotChanged = !IsSettingsChanged(entity);
			InitializeSheetSettings(entity);
			if (_userConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
				_isAutoCalcSettingsChanged = IsAutoCalculateSettingsChanged();
			}
			if (_userConnection.GetIsFeatureEnabled("ForecastSnapshot")) {
				_isTimeZoneChanged = GetIsTimeZoneChanged();
				_isAutoSnapshotSettingsChanged = ForecastSnapshotScheduler.IsAutoSnapshotSettingsChanged(
					new QuartzSchedulerConfig() {
						Entity = entity
					});
			}
		}

		/// <summary>Handles entity Saved event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityAfterEventArgs"/> instance containing the event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var entity = (Entity)sender;
			_userConnection = entity.UserConnection;
			if (_userConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
				ScheduleForecastAutoCalculation(entity);
			}
			if (_userConnection.GetIsFeatureEnabled("ForecastSnapshot") 
				&& (_isAutoSnapshotSettingsChanged || _isTimeZoneChanged)) {
				ForecastSnapshotScheduler.ScheduleForecastAutoSnapshot(new QuartzSchedulerConfig() {
					Entity = entity,
					TimeZoneInfo = GetTimeZoneInfo()
				});
			}
		}

		/// <summary>Handles entity Deleting event.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:BPMSoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			_userConnection = entity.UserConnection;
			var forecastId = entity.GetTypedColumnValue<Guid>("Id");
			if (_userConnection.GetIsFeatureEnabled("ForecastAutoCalculation")) {
				ForecastCalculationScheduler.RemoveJobs(new QuartzSchedulerConfig() {
					ForecastId = forecastId
				});
			}
			if (_userConnection.GetIsFeatureEnabled("ForecastSnapshot")) {
				ForecastSnapshotScheduler.RemoveJob(new QuartzSchedulerConfig() {
					ForecastId = forecastId
				});
			}
		}

		#endregion

	}

	#endregion

}

