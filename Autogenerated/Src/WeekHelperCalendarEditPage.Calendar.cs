using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: WeekHelperCalendarEditPage

	/// <summary>
	/// ############### ##### ## ###### # ######## "####### ######" ######## ############## #########.
	/// </summary>
	[Serializable]
	public class WeekHelperCalendarEditPage : BaseHelperCalendarEditPage
	{
		#region Constructors: Public

		public WeekHelperCalendarEditPage() {
			DaysTreeGridControlName = "WeekDaysTreeGrid";
			DayTypeEditControlName = "DayTypeWeekEdit";
			IsDiffFromParentEditControlName = "IsDiffFromParentWeekEdit";
			IntervalsControlLayoutName = "WeekIntervalsControlLayout";
			DaysEntityDataSourceName = "WeekDaysDataSource";

			TimeIntervalTypeControlAlias = "Week";
			DaysVirtualDataSourceName = "WeekVirtualDataSource";
			TreeGridSelectionChangeEventName = "WeekDaysTreeGridSelectionChange";
		}

		#endregion

		#region Methods: Protected

		protected override IEnumerable<DayInCalendarObject> GetDays() {
			Guid calendarId = _page.DataSource.ActiveRowPrimaryColumnValue;
			var calendarHelper = new CalendarUtils(UserConnection);
			IEnumerable<DayInCalendar> daysEntities = calendarHelper.GetWeekDays(CalendarIdsChain,
				ChangesStore.GetDeletedDaysIds());
			return
				ChangesStore.MergeWeekDays(calendarId, daysEntities.Select(d => new DayInCalendarObject(d)))
					.OrderBy(d => d.DayOfWeekNumber);
		}

		protected override KeyValuePair<Guid, DayInCalendarObject> GetFirstDayInCalendarData() {
			int minDayOfWeek = CurrentDaysGridData.Min(d => d.Value.DayOfWeekNumber);
			return CurrentDaysGridData.SingleOrDefault(d => d.Value.DayOfWeekNumber == minDayOfWeek);
		}

		protected override bool GetIsDiffFromParent(DayInCalendarObject day) {
			return _page.DataSource.ActiveRow.PrimaryColumnValue == day.CalendarId;
		}

		protected override void FillDayTypeControl() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayType");
			esq.AddAllSchemaColumns();
			EntityCollection dayTypes = esq.GetEntityCollection(UserConnection);
			var allowedWeekDayTypeIds = new List<Guid> {
				DayTypeConstants.WorkDayId,
				DayTypeConstants.WeekEndId,
			};

			foreach (Entity type in dayTypes.Where(type => allowedWeekDayTypeIds.Contains(type.PrimaryColumnValue))) {
				DayTypeEdit.AddItem(type.PrimaryColumnValue, type.PrimaryDisplayColumnValue);
			}
		}

		protected override bool GetIsCurrentDayDiffFromParent() {
			return base.GetIsCurrentDayDiffFromParent() || IsBaseCalendar();
		}

		protected override DayInCalendarObject GetDay(Guid treeGridRecordId) {
			Guid calendarId = _page.DataSource.ActiveRowPrimaryColumnValue;
			int dayOfWeekNumber = CurrentDaysGridData[treeGridRecordId].DayOfWeekNumber;

			var calendarHelper = new CalendarUtils(UserConnection);
			CalendarEditPageChangesStore.DayInCalendarChangedObject changedDay = ChangesStore.Days.SingleOrDefault(d =>
				d.DayInCalendar.CalendarId == calendarId && d.DayInCalendar.DayOfWeekNumber == dayOfWeekNumber &&
					d.ChangedStatus != CalendarEditPageChangesStore.ChangedStatus.Deleted);
			if (changedDay != null) {
				return changedDay.DayInCalendar;
			}
			DayInCalendar day = calendarHelper.GetWeekDay(CalendarIdsChain, dayOfWeekNumber, 
				ChangesStore.GetDeletedDaysIds());
			return new DayInCalendarObject(day);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ########## ######## ########.
		/// </summary>
		public override void HandlePageLoadComplete() {
			base.HandlePageLoadComplete();
			IsDiffFromParentEdit.SetVisible(!IsBaseCalendar());
		}

		#endregion
	}

	#endregion
}
