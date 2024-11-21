using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using BPMSoft.UI.WebControls.Controls;

namespace BPMSoft.Configuration
{

	#region Class: CalendarHelperCalendarEditPage

	/// <summary>
	/// ############### #### ## ###### # ######## "#########" ######## ############## #########.
	/// </summary>
	[Serializable]
	public class CalendarHelperCalendarEditPage : BaseHelperCalendarEditPage
	{
		#region Constructors: Public

		public CalendarHelperCalendarEditPage() {
			DaysTreeGridControlName = "CalendarDaysTreeGrid";
			DayTypeEditControlName = "DayTypeCalendarEdit";
			IsDiffFromParentEditControlName = "IsDiffFromParentCalendarEdit";
			IntervalsControlLayoutName = "CalendarIntervalsControlLayout";
			DaysEntityDataSourceName = "CalendarDaysDataSource";

			TimeIntervalTypeControlAlias = "Calendar";
			DaysVirtualDataSourceName = "CalendarVirtualDataSource";
			TreeGridSelectionChangeEventName = "CalendarDaysTreeGridSelectionChange";
			IsCalendarDayValue = true;
		}

		#endregion

		#region Constants: Private

		private const string DateStringVirtualColumnName = "DateString";

		#endregion

		#region Fields: Private

		private string _diffFromParentCalendarLabel;
		private string _diffFromWorkingWeekLabel;
		private string _dataVirtualColumnCaption;

		#endregion

		#region Properties: Protected

		protected string DiffFromParentCalendarLabel {
			get {
				return _diffFromParentCalendarLabel ??
						(_diffFromParentCalendarLabel = LocalizableStringHelper.GetValue(UserConnection,
							"CalendarHelperCalendarEditPage", "DiffFromParentCalendarLabel"));
			}
		}

		protected string DiffFromWorkingWeekLabel {
			get {
				return _diffFromWorkingWeekLabel ??
						(_diffFromWorkingWeekLabel = LocalizableStringHelper.GetValue(UserConnection,
							"CalendarHelperCalendarEditPage", "DiffFromWorkingWeekLabel"));
			}
		}
		
		protected string DataVirtualColumnCaption {
			get {
				return _dataVirtualColumnCaption ??
						(_dataVirtualColumnCaption = LocalizableStringHelper.GetValue(UserConnection,
							"CalendarHelperCalendarEditPage", "DataVirtualColumnCaption"));
			}
		}

		#endregion

		#region Methods: Private

		private bool HasDayOfWeekOverrides(Guid treeGridRecordId) {
			if (!CurrentDaysGridData.Keys.Contains(treeGridRecordId)){
				return false;
			}
			DateTime date = CurrentDaysGridData[treeGridRecordId].Date.Date;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayInCalendar");
			esq.AddColumn("Id");
			esq.RowCount = 1;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Calendar",
				_page.DataSource.ActiveRowPrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.IsNull, "Date"));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayOfWeek.Number",
				CalendarUtils.GetDayOfWeekNumber(date)));
			return esq.GetEntityCollection(UserConnection).Any();
		}

		private void SubscribePeriodFilterChange() {
			string script = @"{0}.on('change', function(s, e) {{
				if (validateCalendarControls() && {0}.enabledAjaxEvents.change) {{
					window.BPMSoft.AjaxMethods.ThrowClientEventWithMask('{1}', '{2}');
				}}
			}}, this);";
			_page.AddScript(string.Format(script, _page.StartDateEdit.ClientID, InstanceUId, "StartDateEditChange"));
			_page.AddScript(string.Format(script, _page.EndDateEdit.ClientID, InstanceUId, "EndDateEditChange"));
		}

		#endregion

		#region Methods: Protected

		protected override DayInCalendarObject GetDay(Guid treeGridRecordId) {
			Guid calendarId = _page.DataSource.ActiveRowPrimaryColumnValue;
			DateTime date = CurrentDaysGridData[treeGridRecordId].Date;

			var calendarUtils = new CalendarUtils(UserConnection);
			CalendarEditPageChangesStore.DayInCalendarChangedObject changedDay = ChangesStore.Days.SingleOrDefault(d =>
				d.DayInCalendar.CalendarId == calendarId && d.DayInCalendar.Date.Date == date.Date &&
				d.ChangedStatus != CalendarEditPageChangesStore.ChangedStatus.Deleted);
			if (changedDay != null) {
				return changedDay.DayInCalendar;
			}
			DayInCalendarExtended day = calendarUtils.GetCalendarDayExtended(CalendarIdsChain, date,
				ChangesStore.GetDeletedDaysIds());
			return new DayInCalendarObject(day);
		}

		protected override IEnumerable<DayInCalendarObject> GetDays() {
			Guid calendarId = _page.DataSource.ActiveRowPrimaryColumnValue;
			var calendarUtils = new CalendarUtils(UserConnection);
			DateTime fromDate = _page.StartDateEdit.SelectedDate;
			DateTime toDate = _page.EndDateEdit.SelectedDate;
			if (fromDate.Date == DateTime.MinValue.Date || toDate.Date == DateTime.MinValue.Date) {
				return new List<DayInCalendarObject>();
			}
			List<Guid> ignoredIds = ChangesStore.GetDeletedDaysIds().ToList();

			IEnumerable<DayInCalendarObject> calendarDaysEntities =
				calendarUtils.GetCalendarDaysExtended(CalendarIdsChain, fromDate, toDate, ignoredIds)
					.Select(d => new DayInCalendarObject(d));
			List<DayInCalendarObject> calendarDays =
				ChangesStore.MergeCalendarDays(calendarId, calendarDaysEntities, fromDate, toDate).ToList();

			return calendarDays;
		}

		protected override bool GetIsDiffFromParent(DayInCalendarObject day) {
			return _page.DataSource.ActiveRow.PrimaryColumnValue == day.CalendarId && day.IsCalendarDayValue;
		}

		protected override void InitializeDaysVirtualDataSource(VirtualDataSource virtualDataSource) {
			DataSourceStructure structure = virtualDataSource.DefStructure;
			var dataValueTypeManager =
				(DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			var dateStringColumn = new DataSourceStructureColumn {
				Name = DateStringVirtualColumnName,
				DataValueType = dataValueTypeManager.GetInstanceByName("MediumText"),
				IsVisible = true,
				Caption = DataVirtualColumnCaption,
				IsHideable = false,
				IsSortable = false,
				MenuDisabled = true
			};
			structure.AddColumn(dateStringColumn);
			base.InitializeDaysVirtualDataSource(virtualDataSource);
		}

		protected override Entity CreateDayVirtualDataSourceRow(VirtualDataSource daysDataSource, 
			DayInCalendarObject day, Guid gridRecordId) {
			Entity row = base.CreateDayVirtualDataSourceRow(daysDataSource, day, gridRecordId);
			row.SetColumnValue(DateStringVirtualColumnName, day.Date.ToString("ddd dd MMMM yyyy"));
			return row;
		}

		protected override void DisplayDayByTreeGridRecord(Guid treeGridRecordId) {
			base.DisplayDayByTreeGridRecord(treeGridRecordId);
			if (treeGridRecordId != Guid.Empty) {
				IsDiffFromParentEdit.Caption = IsBaseCalendar() ? DiffFromWorkingWeekLabel :
					(HasDayOfWeekOverrides(treeGridRecordId)
						? DiffFromWorkingWeekLabel
						: DiffFromParentCalendarLabel);
			}
		}

		protected override KeyValuePair<Guid, DayInCalendarObject> GetFirstDayInCalendarData() {
			DateTime minDate = CurrentDaysGridData.Min(d => d.Value.Date);
			return CurrentDaysGridData.SingleOrDefault(d => d.Value.Date == minDate);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ########## ######## ########.
		/// </summary>
		public override void HandlePageLoadComplete() {
			SubscribePeriodFilterChange();
			base.HandlePageLoadComplete();
		}

		/// <summary>
		/// ########## ######### ####### ### ########### #########.
		/// </summary>
		public void HandleDatesChange() {
			if (CurrentTreeGridRecordId != Guid.Empty && CurrentDaysGridData.Keys.Contains(CurrentTreeGridRecordId)) {
				SaveChangesToStore(CurrentDaysGridData[CurrentTreeGridRecordId]);
			}
			LoadDaysData();
		}

		#endregion
	}

	#endregion
}
