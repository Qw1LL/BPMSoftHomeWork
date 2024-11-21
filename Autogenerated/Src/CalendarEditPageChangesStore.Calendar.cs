using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Class: CalendarEditPageChangesStore

	/// <summary>
	/// ######### ######### ######## ############## #########.
	/// </summary>
	[Serializable]
	public class CalendarEditPageChangesStore
	{
		#region Enum: ChangedStatus

		/// <summary>
		/// ######### ######## # ######### #########.
		/// </summary>
		[Serializable]
		public enum ChangedStatus
		{
			Original = 0,
			New = 1,
			Changed = 2,
			Deleted = 3
		}

		#endregion

		#region Class: BaseChangedObject

		/// <summary>
		/// ####### #####, ############## ########## ###### ## ######## ############## #########.
		/// </summary>
		[Serializable]
		public abstract class BaseChangedObject
		{
			#region Constructor: Protected

			protected BaseChangedObject() {
				ChangedStatus = ChangedStatus.Original;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// ######### ########### #######.
			/// </summary>
			public ChangedStatus ChangedStatus { get; set; }

			#endregion

			#region Methods: Protected

			protected abstract IEntityObject GetEntityObject();

			protected abstract string GetEntitySchemaName();

			#endregion

			#region Methods: Public

			/// <summary>
			/// ######### ######### ####### ##### ######## # ##.
			/// # ########### ## ######### ######### ###### ######## ### ########: ##########/#########/########.
			/// </summary>
			/// <param name="userConnection"></param>
			public void Save(UserConnection userConnection) {
				IEntityObject entityObject = GetEntityObject();
				string schemaName = GetEntitySchemaName();
				switch (ChangedStatus) {
					case ChangedStatus.Deleted: {
						var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
						esq.AddAllSchemaColumns();
						Entity entity = esq.GetEntity(userConnection, entityObject.Id);
						if (entity != null) {
							entity.Delete();
						}
					}
						break;
					case ChangedStatus.New: {
						Entity entity = userConnection.EntitySchemaManager.GetInstanceByName(schemaName)
							.CreateEntity(userConnection);
						entity.SetDefColumnValues();
						entityObject.FillEntity(entity).Save();
					}
						break;
					case ChangedStatus.Changed: {
						var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
						esq.AddAllSchemaColumns();
						Entity entity = esq.GetEntity(userConnection, entityObject.Id);
						if (entity != null) {
							entityObject.FillEntity(entity).Save();
						}
					}
						break;
				}
			}

			#endregion
		}

		#endregion

		#region Class: DayInCalendarChangedObject

		/// <summary>
		/// #####, ############## ######## #### # ######### ## ######## ############## #########.
		/// </summary>
		[Serializable]
		public class DayInCalendarChangedObject : BaseChangedObject
		{
			#region Constructor: Public

			public DayInCalendarChangedObject(DayInCalendarObject dayInCalendar, ChangedStatus changedStatus) {
				ChangedStatus = changedStatus;
				DayInCalendar = dayInCalendar;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// ######### ############# ######## ### # #########.
			/// </summary>
			public DayInCalendarObject DayInCalendar { get; set; }

			/// <summary>
			/// ############# ######## # ##.
			/// </summary>
			public Guid EntityId {
				get { return DayInCalendar.Id; }
			}

			#endregion

			#region Methods: Protected

			protected override IEntityObject GetEntityObject() {
				return DayInCalendar;
			}

			protected override string GetEntitySchemaName() {
				return "DayInCalendar";
			}

			#endregion
		}

		#endregion

		#region Class: TimeIntervalChangedObject

		/// <summary>
		/// #####, ############## ######## ######### ######## ## ######## ############## #########.
		/// </summary>
		[Serializable]
		public class TimeIntervalChangedObject : BaseChangedObject
		{
			#region Constructor: Public

			public TimeIntervalChangedObject(WorkingTimeIntervalObject workingTimeInterval, 
				ChangedStatus changedStatus) {
				ChangedStatus = changedStatus;
				WorkingTimeInterval = workingTimeInterval;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// ######### ############# ######## ########## #########.
			/// </summary>
			public WorkingTimeIntervalObject WorkingTimeInterval { get; set; }

			/// <summary>
			/// ############# ######## # ##.
			/// </summary>
			public Guid EntityId {
				get { return WorkingTimeInterval.Id; }
			}

			#endregion

			#region Methods: Protected

			protected override IEntityObject GetEntityObject() {
				return WorkingTimeInterval;
			}

			protected override string GetEntitySchemaName() {
				return "WorkingTimeInterval";
			}

			#endregion
		}

		#endregion

		#region Constructors: Public

		public CalendarEditPageChangesStore() {
			Days = new List<DayInCalendarChangedObject>();
			Intervals = new List<TimeIntervalChangedObject>();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ######### ########## #### # #########.
		/// </summary>
		public List<DayInCalendarChangedObject> Days { get; private set; }

		/// <summary>
		/// ######### ########## ######### ##########.
		/// </summary>
		public List<TimeIntervalChangedObject> Intervals { get; private set; }

		#endregion

		#region Methods: Private

		private void RemoveChangedDayIntervals(DayInCalendarChangedObject day) {
			Intervals.RemoveAll(i => i.WorkingTimeInterval.DayInCalendarId == day.EntityId);
		}

		private IEnumerable<DayInCalendarObject> GetChangedDays(Guid calendarId) {
			return Days.Where(d => d.DayInCalendar.CalendarId == calendarId && 
				(d.ChangedStatus == ChangedStatus.New || d.ChangedStatus == ChangedStatus.Changed))
					.Select(d => d.DayInCalendar);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######### ##### #### # ######### #########.
		/// </summary>
		/// <param name="day">##### ####</param>
		public void AddNewDay(DayInCalendarObject day) {
			DayInCalendarChangedObject existedDay = Days.SingleOrDefault(d => d.EntityId == day.Id);
			if (existedDay != null) {
				Days.Remove(existedDay);
			}
			Days.Add(new DayInCalendarChangedObject(day, ChangedStatus.New));
		}

		/// <summary>
		/// ######### ########## #### # ######### #########.
		/// </summary>
		/// <param name="day">########## ####</param>
		public void AddChangedDay(DayInCalendarObject day) {
			var changedStatus = ChangedStatus.Changed;
			DayInCalendarChangedObject existedDay = Days.SingleOrDefault(d => d.EntityId == day.Id);
			if (existedDay != null) {
				changedStatus = existedDay.ChangedStatus == ChangedStatus.New 
					? ChangedStatus.New 
					: ChangedStatus.Changed;
				Days.Remove(existedDay);
			}
			Days.Add(new DayInCalendarChangedObject(day, changedStatus));
		}

		/// <summary>
		/// ######### ######### #### # ######### #########.
		/// </summary>
		/// <param name="day">######### ####</param>
		public void AddRemovedDay(DayInCalendarObject day) {
			DayInCalendarChangedObject existedDay = Days.SingleOrDefault(d => d.EntityId == day.Id);
			if (existedDay != null) {
				RemoveChangedDayIntervals(existedDay);
				Days.Remove(existedDay);
				if (existedDay.ChangedStatus == ChangedStatus.New) {
					return;
				}
			}
			Days.Add(new DayInCalendarChangedObject(day, ChangedStatus.Deleted));
		}

		/// <summary>
		/// ######### ##### ######### ######## # ######### #########.
		/// </summary>
		/// <param name="interval">#### ######### ########</param>
		public void AddNewInterval(WorkingTimeIntervalObject interval) {
			TimeIntervalChangedObject existedInterval = Intervals.SingleOrDefault(i => i.EntityId == interval.Id);
			if (existedInterval != null) {
				Intervals.Remove(existedInterval);
			}
			Intervals.Add(new TimeIntervalChangedObject(interval, ChangedStatus.New));
		}

		/// <summary>
		/// ######### ########## ######## # ######### #########.
		/// </summary>
		/// <param name="interval">########## ######### ########</param>
		public void AddChangedInterval(WorkingTimeIntervalObject interval) {
			var changedStatus = ChangedStatus.Changed;
			TimeIntervalChangedObject existedInterval = Intervals.SingleOrDefault(i => i.EntityId == interval.Id);
			if (existedInterval != null) {
				changedStatus = existedInterval.ChangedStatus == ChangedStatus.New 
					? ChangedStatus.New 
					: ChangedStatus.Changed;
				Intervals.Remove(existedInterval);
			}
			Intervals.Add(new TimeIntervalChangedObject(interval, changedStatus));
		}

		/// <summary>
		/// ######### ######### ######### ######## # ######### #########.
		/// </summary>
		/// <param name="interval">######### ######### ########</param>
		public void AddRemovedInterval(WorkingTimeIntervalObject interval) {
			TimeIntervalChangedObject existedInterval = Intervals.SingleOrDefault(i => i.EntityId == interval.Id);
			if (existedInterval != null) {
				Intervals.Remove(existedInterval);
				if (existedInterval.ChangedStatus == ChangedStatus.New) {
					return;
				}
			}
			Intervals.Add(new TimeIntervalChangedObject(interval, ChangedStatus.Deleted));
		}

		/// <summary>
		/// ######### ######### ######### #########, # ####, ####### ######## # ######### ## ############ ####.
		/// </summary>
		/// <param name="dayId">####, ## ####### ##### ########### #########</param>
		/// <param name="sourceTimeIntervals">######## ######### #########</param>
		/// <returns>############## ######### #########</returns>
		public IEnumerable<WorkingTimeIntervalObject> MergeIntervals(Guid dayId,
			IEnumerable<WorkingTimeIntervalObject> sourceTimeIntervals) {
			List<WorkingTimeIntervalObject> sourceTimeIntervalsList = sourceTimeIntervals.ToList();

			List<TimeIntervalChangedObject> changedIntervals =
				Intervals.Where(i => i.WorkingTimeInterval.DayInCalendarId == dayId).ToList();
			IEnumerable<Guid> changedIntervalsIds = changedIntervals.Select(i => i.EntityId);
			sourceTimeIntervalsList.RemoveAll(t => changedIntervalsIds.Contains(t.Id));
			sourceTimeIntervalsList.AddRange(
				changedIntervals.Where(i => i.ChangedStatus == ChangedStatus.New 
					|| i.ChangedStatus == ChangedStatus.Changed).Select(i => i.WorkingTimeInterval));
			return sourceTimeIntervalsList;
		}

		/// <summary>
		/// ######### ######### ### ######, # ####, ####### ######## # ######### # ######### # #########.
		/// </summary>
		/// <param name="calendarId">#########, ### ######## ##### ###########</param>
		/// <param name="days">######## ###</param>
		/// <returns>############## ###</returns>
		public IEnumerable<DayInCalendarObject> MergeWeekDays(Guid calendarId, IEnumerable<DayInCalendarObject> days) {
			List<DayInCalendarObject> daysList = days.ToList();
			List<DayInCalendarObject> changedDays =
				GetChangedDays(calendarId).Where(d => d.Date.Date == DateTime.MinValue).ToList();
			IEnumerable<Guid> changedDayOfWeekIds = changedDays.Select(d => d.DayOfWeekId);
			daysList.RemoveAll(d => changedDayOfWeekIds.Contains(d.DayOfWeekId));
			daysList.AddRange(changedDays);
			return daysList;
		}

		/// <summary>
		/// ######### ######### ########### ###, # ####, ####### ######## # ######### # ######### # #########.
		/// </summary>
		/// <param name="calendarId">#########, ### ######## ##### ###########</param>
		/// <param name="days">######## ##</param>
		/// <param name="fromDate">###### ########## #########, ########## ####</param>
		/// <param name="toDate">##### ########## #########, ########## ####</param>
		/// <returns>############## ###</returns>
		public IEnumerable<DayInCalendarObject> MergeCalendarDays(Guid calendarId, 
			IEnumerable<DayInCalendarObject> days, DateTime fromDate, DateTime toDate) {
			List<DayInCalendarObject> daysList = days.ToList();
			List<DayInCalendarObject> changedDays =
				GetChangedDays(calendarId).Where(d => d.Date.Date >= fromDate && d.Date.Date <= toDate).ToList();
			IEnumerable<DateTime> changedDates = changedDays.Select(d => d.Date);
			daysList.RemoveAll(d => changedDates.Contains(d.Date.Date));
			daysList.AddRange(changedDays);
			return daysList;
		}

		/// <summary>
		/// ########## ###### ############### ####, ####### ##### #######.
		/// </summary>
		/// <returns>############## ####, ####### ##### #######</returns>
		public IEnumerable<Guid> GetDeletedDaysIds() {
			return Days.Where(d => d.ChangedStatus == ChangedStatus.Deleted).Select(d => d.EntityId);
		}

		/// <summary>
		/// ######### ######### ## ######### # ##.
		/// </summary>
		/// <param name="userConnection">########### ############</param>
		public void SaveChanges(UserConnection userConnection) {
			Days.ForEach(d => d.Save(userConnection));
			Intervals.ForEach(d => d.Save(userConnection));
			Days.Clear();
			Intervals.Clear();
		}

		#endregion
	}

	#endregion
}
