using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration
{

	#region Interface: IEntityObject

	/// <summary>
	/// ######### ############# ######## # ##.
	/// ############ ### ############ ######## ######## ##### ######### ########## ## ########.
	/// </summary>
	public interface IEntityObject
	{
		#region Properties: Public

		/// <summary>
		/// ############# ###### # ##.
		/// </summary>
		Guid Id { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// #####, ############### ########## ######## # ########.
		/// </summary>
		/// <param name="entity">######## ######## ##</param>
		/// <returns>######## # ############# ##########</returns>
		Entity FillEntity(Entity entity);

		#endregion
	}

	#endregion

	#region Class: DayInCalendarObject

	/// <summary>
	/// ######### ############# ######## ### # #########.
	/// </summary>
	[Serializable]
	public class DayInCalendarObject : ICloneable, IEntityObject
	{

		#region Constructors: Public

		public DayInCalendarObject() { }

		public DayInCalendarObject(DayInCalendar dayInCalendarEntity) {
			Id = dayInCalendarEntity.Id;
			CalendarId = dayInCalendarEntity.CalendarId;
			Date = dayInCalendarEntity.Date;
			DayTypeId = dayInCalendarEntity.DayTypeId;
			DayOfWeekId = dayInCalendarEntity.DayOfWeekId;
			IsDayTypeWeekend = dayInCalendarEntity.GetTypedColumnValue<bool>("DayType_IsWeekend");
			DayOfWeekNumber = dayInCalendarEntity.GetTypedColumnValue<int>("DayOfWeek_Number");
		}

		public DayInCalendarObject(DayInCalendarExtended dayInCalendarExtended)
			: this(dayInCalendarExtended.DayInCalendar) {
			IsCalendarDayValue = dayInCalendarExtended.IsCalendarValue;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ########## #############.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// ############# #########.
		/// </summary>
		public Guid CalendarId { get; set; }

		/// <summary>
		/// ####.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// ############# #### ###.
		/// </summary>
		public Guid DayTypeId { get; set; }

		/// <summary>
		/// ############# ### # ######.
		/// </summary>
		public Guid DayOfWeekId { get; set; }

		/// <summary>
		/// #######, ######## ## #### ########
		/// </summary>
		public bool IsDayTypeWeekend { get; set; }

		/// <summary>
		/// ##### ### # ######.
		/// </summary>
		public int DayOfWeekNumber { get; set; }

		/// <summary>
		/// #######, ########### ## ##, ### ### ############# ########### ####.
		/// </summary>
		public bool IsCalendarDayValue { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######## ########### ########## ###.
		/// </summary>
		/// <returns>##### ######### ###</returns>
		public object Clone() {
			return new DayInCalendarObject {
				Id = Id,
				CalendarId = CalendarId,
				Date = Date,
				DayTypeId = DayTypeId,
				DayOfWeekId = DayOfWeekId,
				IsDayTypeWeekend = IsDayTypeWeekend,
				DayOfWeekNumber = DayOfWeekNumber,
				IsCalendarDayValue = IsCalendarDayValue
			};
		}

		/// <summary>
		/// ########## ######## ### # ######### ######## ##########.
		/// </summary>
		/// <param name="entity">######## #### # #########</param>
		/// <returns>########## ########</returns>
		public Entity FillEntity(Entity entity) {
			if (Date.Date != DateTime.MinValue.Date) {
				entity.SetColumnValue("Date", Date.Date);
			} else {
				entity.SetColumnValue("Date", null);
			}
			entity.SetColumnValue("DayTypeId", DayTypeId);
			entity.SetColumnValue("DayOfWeekId", DayOfWeekId);
			entity.SetColumnValue("CalendarId", CalendarId);
			entity.SetColumnValue("Id", Id);
			return entity;
		}

		#endregion
	}

	#endregion

	#region Class: WorkingTimeIntervalObject

	/// <summary>
	/// ######### ############# ######## ######### ######## #######.
	/// </summary>
	[Serializable]
	public class WorkingTimeIntervalObject : IEntityObject
	{

		#region Constructors: Public

		public WorkingTimeIntervalObject() { }

		public WorkingTimeIntervalObject(WorkingTimeInterval workingTimeIntervalEntity) {
			Id = workingTimeIntervalEntity.Id;
			DayInCalendarId = workingTimeIntervalEntity.DayInCalendarId;
			From = workingTimeIntervalEntity.From;
			To = workingTimeIntervalEntity.To;
			Index = workingTimeIntervalEntity.Index;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ########## #############.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// #### # #########.
		/// </summary>
		public Guid DayInCalendarId { get; set; }

		/// <summary>
		/// ###### ########## ##########.
		/// </summary>
		public DateTime From { get; set; }

		/// <summary>
		/// ##### ########## ##########.
		/// </summary>
		public DateTime To { get; set; }

		/// <summary>
		/// ########## ##### ########## ##########.
		/// </summary>
		public int Index { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ######## ########## ######## ####### ######## ##########.
		/// </summary>
		/// <param name="entity">######## ####### ########</param>
		/// <returns>########## ########</returns>
		public Entity FillEntity(Entity entity) {
			entity.SetColumnValue("Id", Id);
			entity.SetColumnValue("DayInCalendarId", DayInCalendarId);
			entity.SetColumnValue("From", From);
			entity.SetColumnValue("To", To);
			entity.SetColumnValue("Index", Index);
			return entity;
		}

		#endregion

	}

	#endregion

	#region Class: DayInCalendarExtended

	/// <summary>
	/// ########### ########### ####. ###### ############# # ######, #### ########## ##### ##### ####### ### #######
	/// ####: #### ### #### ## ####### ######, #### ############# ########### ####.
	/// </summary>
	public class DayInCalendarExtended
	{
		#region Constructors: Public

		public DayInCalendarExtended() { }

		public DayInCalendarExtended(DayInCalendar dayInCalendar, bool isCalendarValue) {
			IsCalendarValue = isCalendarValue;
			DayInCalendar = dayInCalendar;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// #######, ########### ## ##, ### ### ############# ########### ####.
		/// </summary>
		public bool IsCalendarValue { get; set; }

		/// <summary>
		/// ###### ## #### # #########.
		/// </summary>
		public DayInCalendar DayInCalendar { get; set; }

		#endregion
	}

	#endregion

	#region Class: CalendarUtils

	/// <summary>
	/// ######### ##### ## ###### # ###########.
	/// </summary>
	public class CalendarUtils
	{
		#region Constructors: Public

		public CalendarUtils(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private EntitySchemaQuery AddAllDayInCalendarColumns(EntitySchemaQuery esq) {
			esq.AddAllSchemaColumns();
			esq.AddColumn("DayOfWeek.Number");
			esq.AddColumn("DayType.IsWeekend");
			return esq;
		}

		private Guid GetParentCalendarId(Guid calendarId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Calendar");
			esq.AddColumn("Parent");
			Entity entity = esq.GetEntity(UserConnection, calendarId);
			return entity != null
				? entity.GetTypedColumnValue<Guid>("ParentId")
				: Guid.Empty;
		}

		private DayInCalendar GetCalendarDayInner(IEnumerable<Guid> calendarIds, DateTime date,
			IEnumerable<Guid> ignoredIds) {
			object[] calendarsIdObjects = calendarIds.Select(id => (object)id).ToArray();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayInCalendar");
			esq = AddAllDayInCalendarColumns(esq);
			esq.RowCount = 1;
			esq.AddColumn("Calendar.Depth").OrderByDesc(0);
			esq.AddColumn("Date").OrderByDesc(1);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Calendar", calendarsIdObjects));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayOfWeek.Number",
				GetDayOfWeekNumber(date)));
			var dateFilterCollection = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			dateFilterCollection.Add(esq.CreateFilterWithParameters(FilterComparisonType.IsNull, "Date"));
			dateFilterCollection.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Date", date.Date));
			esq.Filters.Add(dateFilterCollection);
			if (ignoredIds != null && ignoredIds.Any()) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id",
					ignoredIds.Select(i => (object)i)));
			}
			return (DayInCalendar)esq.GetEntityCollection(UserConnection).SingleOrDefault();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ##### ### # ###### ## ####.
		/// </summary>
		/// <param name="date">####</param>
		/// <returns>##### ### # ######</returns>
		public static int GetDayOfWeekNumber(DateTime date) {
			var dayOfWeekNumber = (int)date.Date.DayOfWeek;
			return dayOfWeekNumber == 0 ? 7 : dayOfWeekNumber;
		}

		/// <summary>
		/// ########## ####### ######## ############ ##########.
		/// </summary>
		/// <param name="baseCalendarId">######## #########</param>
		/// <returns>####### ############ ##########</returns>
		public IEnumerable<Guid> GetCalendarIdsChain(Guid baseCalendarId) {
			return GetCalendarIdsChain(baseCalendarId, GetParentCalendarId(baseCalendarId));
		}

		/// <summary>
		/// ########## ####### ######## ############ ##########.
		/// ##### ########### # ###### #### ######## ######### ### ## ######## # ##.
		/// </summary>
		/// <param name="baseCalendarId">######## #########</param>
		/// <param name="parentCalendarId">############ ######### ### #########</param>
		/// <returns>####### ############ ##########</returns>
		public IEnumerable<Guid> GetCalendarIdsChain(Guid baseCalendarId, Guid parentCalendarId) {
			var calendarChain = new List<Guid> {baseCalendarId};
			if (parentCalendarId != Guid.Empty) {
				calendarChain.Add(parentCalendarId);
				Guid nextParentCalendarId = GetParentCalendarId(parentCalendarId);
				while (nextParentCalendarId != Guid.Empty) {
					calendarChain.Add(nextParentCalendarId);
					nextParentCalendarId = GetParentCalendarId(nextParentCalendarId);
				}
			}
			return calendarChain;
		}

		/// <summary>
		/// ########## #### # #########, ############## ##### #### ######.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="dayOfWeekNumber">##### ### ######</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>#### ######</returns>
		public DayInCalendar GetWeekDay(IEnumerable<Guid> calendarIds, int dayOfWeekNumber,
			IEnumerable<Guid> ignoredIds = null) {
			object[] calendarsIdObjects = calendarIds.Select(id => (object)id).ToArray();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayInCalendar");
			esq = AddAllDayInCalendarColumns(esq);
			esq.RowCount = 1;
			esq.AddColumn("Calendar.Depth").OrderByDesc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Calendar", calendarsIdObjects));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayOfWeek.Number", dayOfWeekNumber));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.IsNull, "Date"));
			if (ignoredIds != null && ignoredIds.Any()) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Id",
					ignoredIds.Select(i => (object)i)));
			}
			return (DayInCalendar)esq.GetEntityCollection(UserConnection).SingleOrDefault();
		}

		/// <summary>
		/// ########## ########### ####.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="date">#### ### #######</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>########### ####</returns>
		public DayInCalendar GetCalendarDay(IEnumerable<Guid> calendarIds, DateTime date,
			IEnumerable<Guid> ignoredIds = null) {
			DayInCalendar day = GetCalendarDayInner(calendarIds, date, ignoredIds);
			if (day.Date == DateTime.MinValue) {
				day.Date = date.Date.Date;
			}
			return day;
		}

		/// <summary>
		/// ########## ########### ########### ####.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="date">#### ### #######</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>########### ########### ####</returns>
		public DayInCalendarExtended GetCalendarDayExtended(IEnumerable<Guid> calendarIds, DateTime date,
			IEnumerable<Guid> ignoredIds = null) {
			DayInCalendar day = GetCalendarDayInner(calendarIds, date, ignoredIds);
			var isMinDate = day.Date == DateTime.MinValue;
			if (isMinDate) {
				day.Date = date.Date;
			}
			return new DayInCalendarExtended(day, !isMinDate);
		}

		/// <summary>
		/// ########## ### ###### ### ####### ##########.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>### ######</returns>
		public IEnumerable<DayInCalendar> GetWeekDays(IEnumerable<Guid> calendarIds,
			IEnumerable<Guid> ignoredIds = null) {
			for (int i = 1; i <= 7; i++) {
				yield return GetWeekDay(calendarIds, i, ignoredIds);
			}
		}

		/// <summary>
		/// ########## ###### ########### #### ### ####### ########## # ########## ##########.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="fromDate">###### #########</param>
		/// <param name="toDate">##### #########</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>########### ###</returns>
		public IEnumerable<DayInCalendar> GetCalendarDays(IEnumerable<Guid> calendarIds, DateTime fromDate,
			DateTime toDate, IEnumerable<Guid> ignoredIds = null) {
			while (fromDate.Date <= toDate.Date) {
				yield return GetCalendarDay(calendarIds, fromDate, ignoredIds);
				fromDate = fromDate.AddDays(1);
			}
		}

		/// <summary>
		/// ########## ###### ########### ########### #### ### ####### ########## # ########## ##########.
		/// </summary>
		/// <param name="calendarIds">############## ######## ########## ### #######</param>
		/// <param name="fromDate">###### #########</param>
		/// <param name="toDate">##### #########</param>
		/// <param name="ignoredIds">############## ####, ####### ## ##### ############ # #######</param>
		/// <returns>########### ########### ###</returns>
		public IEnumerable<DayInCalendarExtended> GetCalendarDaysExtended(IEnumerable<Guid> calendarIds,
			DateTime fromDate, DateTime toDate, IEnumerable<Guid> ignoredIds = null) {
			while (fromDate.Date <= toDate.Date) {
				yield return GetCalendarDayExtended(calendarIds, fromDate, ignoredIds);
				fromDate = fromDate.AddDays(1);
			}
		}

		/// <summary>
		/// ########## ###### ########## ######## ####### ### ########### ###.
		/// </summary>
		/// <param name="dayInCalendarId">####</param>
		/// <returns>###### ####### ##########</returns>
		public IEnumerable<WorkingTimeInterval> GetWorkingTimeIntervals(Guid dayInCalendarId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "WorkingTimeInterval");
			esq.AddAllSchemaColumns();
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "DayInCalendar", dayInCalendarId));
			return esq.GetEntityCollection(UserConnection).Select(d => (WorkingTimeInterval)d);
		}

		#endregion
	}

	#endregion

}
