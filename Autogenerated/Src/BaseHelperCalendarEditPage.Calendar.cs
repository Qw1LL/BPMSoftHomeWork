namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.WebApp;
	
	#region Class: HelperCalendarEditPageState

	/// <summary>
	/// ######### ###### ############## ##########
	/// </summary>
	[Serializable]
	public class HelperCalendarEditPageState
	{
		#region Properties: Public

		/// <summary>
		/// ######### #### # ###### ######## ############## ########
		/// </summary>
		public Dictionary<Guid, DayInCalendarObject> CurrentDaysGridData { get; set; }

		/// <summary>
		/// ######### ########## ######## #######
		/// </summary>
		public IEnumerable<WorkingTimeIntervalObject> CurrentWorkingTimeIntervalsData { get; set; }

		/// <summary>
		/// ############# ######### ###### # ######
		/// </summary>
		public Guid CurrentTreeGridRecordId { get; set; }

		/// <summary>
		/// ####### ########## ##########
		/// </summary>
		public List<int> ChangedWorkingTimeIntervalsIndexes { get; set; }

		/// <summary>
		/// ######### #########
		/// </summary>
		public CalendarEditPageChangesStore ChangesStore { get; set; }

		/// <summary>
		/// ############# ######### ####### ######### ######### ###### # ######
		/// </summary>
		public bool NeedSkipTreeGridSelectionChangeEvent { get; set; }

		/// <summary>
		/// ######### ############### ##########
		/// </summary>
		public IEnumerable<Guid> CalendarIdsChain { get; set; }

		#endregion
	}

	#endregion

	#region Class: BaseHelperCalendarEditPage

	/// <summary>
	/// ######## ###### ############## ##########
	/// </summary>
	public abstract class BaseHelperCalendarEditPage
	{

		#region Constants: Protected

		/// <summary>
		/// ########### ####### ##########
		/// </summary>
		protected const int WorkingTimeIntervalIndexesCount = 5;
		/// <summary>
		/// ############ ####### ############## # ######
		/// </summary>
		protected const string GridRecordIdColumnName = "GridRecordId";
		/// <summary>
		/// ##### ##### ####### ####### ###### ######## ###
		/// </summary>
		protected const string ToControlNameFormat = "{0}To{1}Edit";
		/// <summary>
		/// ##### ##### ####### ####### ########## ######## ###
		/// </summary>
		protected const string FromControlNameFormat = "{0}From{1}Edit";
		/// <summary>
		/// ##### ########### ######### ### ###### #####
		/// </summary>
		protected const string ColorRegExpMask = @"^\s*(#[0-9A-F]{6}|[A-Z]+)\s*$";

		#endregion

		#region Fields: Private

		private Dictionary<Guid, string> _dayOfWeekNames;
		private Dictionary<Guid, string> _dayTypeNames;
		private IEnumerable<Guid> _dayTypeWeekends;
		private Dictionary<Guid, string> _dayTypeColors;

		#endregion

		#region Fields: Protected

		/// <summary>
		/// ##### ######## ############## ##########
		/// </summary>
		protected CalendarEditPageSchemaUserControl _page;
		/// <summary>
		/// ######### ######## #### ######### #######
		/// </summary>
		protected string TimeIntervalTypeControlAlias;
		/// <summary>
		/// ############ ############ ########## ###### ####
		/// </summary>
		protected string DaysVirtualDataSourceName;
		/// <summary>
		/// ############ ########### ####### ######### ######### ######
		/// </summary>
		protected string TreeGridSelectionChangeEventName;
		/// <summary>
		/// ######## ## ######## #### #########
		/// </summary>
		protected bool IsCalendarDayValue;

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// ########### ######### ###### ############## #########
		/// </summary>
		protected BaseHelperCalendarEditPage() {
			CurrentDaysGridData = new Dictionary<Guid, DayInCalendarObject>();
			CurrentWorkingTimeIntervalsData = new List<WorkingTimeIntervalObject>();
			ChangedWorkingTimeIntervalsIndexes = new List<int>();
			ChangesStore = new CalendarEditPageChangesStore();
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// ######### #### # ###### ######## ############## ########
		/// </summary>
		protected Dictionary<Guid, DayInCalendarObject> CurrentDaysGridData { get; set; }
		
		/// <summary>
		/// ######### ########## ######## #######
		/// </summary>
		protected List<WorkingTimeIntervalObject> CurrentWorkingTimeIntervalsData { get; set; }
		
		/// <summary>
		/// ############# ######### ###### # ######
		/// </summary>
		protected Guid CurrentTreeGridRecordId { get; set; }
		
		/// <summary>
		/// ####### ########## ##########
		/// </summary>
		protected List<int> ChangedWorkingTimeIntervalsIndexes { get; set; }
		
		/// <summary>
		/// ######### #########
		/// </summary>
		protected CalendarEditPageChangesStore ChangesStore { get; set; }
		
		/// <summary>
		/// ######### ############### ##########
		/// </summary>
		protected IEnumerable<Guid> CalendarIdsChain { get; set; }
		
		/// <summary>
		/// ############ ########## ###### ####
		/// </summary>
		protected string DaysEntityDataSourceName { get; set; }
		
		/// <summary>
		/// ############ ########## ## ####### ####
		/// </summary>
		protected string DaysTreeGridControlName { get; set; }
		
		/// <summary>
		/// ############ ########## # ##### ####
		/// </summary>
		protected string DayTypeEditControlName { get; set; }
		
		/// <summary>
		/// ############ ########## # ############### ######### ####### # ############ ##########
		/// </summary>
		protected string IsDiffFromParentEditControlName { get; set; }
		
		/// <summary>
		/// ############ ########## # ########## #######
		/// </summary>
		protected string IntervalsControlLayoutName { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// ############# ##########
		/// </summary>
		public string InstanceUId { get; set; }

		/// <summary>
		/// ###### ########### ######## ############
		/// </summary>
		public UserConnection UserConnection { get; set; }

		/// <summary>
		/// ####### ###### #### # ######
		/// </summary>
		public TreeGrid DaysTreeGrid {
			get { return (TreeGrid)_page.PageContainer.FindPageControl(DaysTreeGridControlName, true); }
		}

		/// <summary>
		/// ####### ######### #### ###
		/// </summary>
		public ComboBoxEdit DayTypeEdit {
			get { return (ComboBoxEdit)_page.PageContainer.FindPageControl(DayTypeEditControlName, true); }
		}

		/// <summary>
		/// ####### ####### ## ######## #########
		/// </summary>
		public CheckBox IsDiffFromParentEdit {
			get { return (CheckBox)_page.PageContainer.FindPageControl(IsDiffFromParentEditControlName, true); }
		}

		/// <summary>
		/// ###### ######### # ###########
		/// </summary>
		public ControlLayout IntervalsControlLayout {
			get { return (ControlLayout)_page.PageContainer.FindPageControl(IntervalsControlLayoutName, true); }
		}

		/// <summary>
		/// ######### ###### ####
		/// </summary>
		public EntityDataSource DaysEntityDataSource {
			get { return (EntityDataSource)_page.PageContainer.FindPageControl(DaysEntityDataSourceName, true); }
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// ###### ########### ####
		/// </summary>
		private void SubscribeDayDisplayControlEvents() {
			string script = @"this.weekendDayTypeIds = [{0}];";
			string paramsScript = string.Format(script,
				string.Join(", ", GetDayTypeWeekends().Select(d => string.Format("'{0}'", d.ToString().ToLower()))));
			_page.AddScript(paramsScript);
			script = @"function setRequired{0}TimeIntervals() {{
				var isDiffFromParent = {1}.checked;
				var dayTypeId = {2}.value;
				var isWeekend = this.weekendDayTypeIds.indexOf(dayTypeId) != -1;
				var isIntervalControlsEnabled = isDiffFromParent && !isWeekend;
				{3}.setRequired(!isWeekend && isDiffFromParent);
				{4}.setRequired(!isWeekend && isDiffFromParent);
				{5}.setEnabled(isIntervalControlsEnabled, true);
			}}";
			var container = _page.PageContainer;
			var fromDate =
				(DateTimeEdit)
					container.FindControl(string.Format(FromControlNameFormat, TimeIntervalTypeControlAlias, 0));
			var toDate =
				(DateTimeEdit)
					container.FindControl(string.Format(ToControlNameFormat, TimeIntervalTypeControlAlias, 0));
			paramsScript = string.Format(script, TimeIntervalTypeControlAlias, IsDiffFromParentEdit.ClientID,
				DayTypeEdit.ClientID, fromDate.ClientID, toDate.ClientID, IntervalsControlLayout.ClientID);
			_page.AddScript(paramsScript);
			SubscribeIsDiffFromParentEvents();
			SubscribeDayTypeEvents();
		}

		/// <summary>
		/// ###### ########### #### ####
		/// </summary>
		private void SubscribeDayTypeEvents() {
			const string script = @"{0}.on('change', function(s, e) {{
				setRequired{1}TimeIntervals();
			}}, this);";
			_page.AddScript(string.Format(script, DayTypeEdit.ClientID, TimeIntervalTypeControlAlias));
		}

		/// <summary>
		/// ####### ########### ######## ####### # ########### ##########
		/// </summary>
		private void SubscribeIsDiffFromParentEvents() {
			const string script = @"{0}.on('check', function(s, e) {{
				var isChecked = s.checked;
				{1}.setRequired(isChecked);
				{1}.setEnabled(isChecked);
				setRequired{2}TimeIntervals();
			}});";
			_page.AddScript(string.Format(script, IsDiffFromParentEdit.ClientID, DayTypeEdit.ClientID,
				TimeIntervalTypeControlAlias));
		}

		/// <summary>
		/// ############ ###### ######## ########## ##########
		/// </summary>
		private void SubscribeTimeIntervalEditsEvents() {
			IEnumerable<DateTimeEdit> workingTimeIntervalEdits = GetWorkingTimeIntervalEdits();
			foreach (DateTimeEdit workingTimeIntervalEdit in workingTimeIntervalEdits) {
				workingTimeIntervalEdit.AjaxEvents.Change.Event += (s, e) => {
					int dateTimeEditIndex = int.Parse(((DateTimeEdit)s).Tag);
					List<int> indexes = ChangedWorkingTimeIntervalsIndexes;
					if (!indexes.Contains(dateTimeEditIndex)) {
						indexes.Add(dateTimeEditIndex);
					}
				};
			}
		}

		/// <summary>
		/// ############ ###### ######### ####### ##########
		/// </summary>
		/// <returns>###### #########</returns>
		private IEnumerable<DateTimeEdit> GetWorkingTimeIntervalEdits() {
			var result = new List<DateTimeEdit>();
			var container = _page.PageContainer;
			for (int i = 0; i < WorkingTimeIntervalIndexesCount; i++) {
				var fromDate =
					(DateTimeEdit)
						container.FindControl(string.Format(FromControlNameFormat, TimeIntervalTypeControlAlias, i));
				var toDate =
					(DateTimeEdit)
						container.FindControl(string.Format(ToControlNameFormat, TimeIntervalTypeControlAlias, i));
				result.Add(fromDate);
				result.Add(toDate);
			}
			return result;
		}

		/// <summary>
		/// ########### ########## #######
		/// </summary>
		/// <param name="day">#### #########</param>
		private void DisplayWorkingTimeIntervals(DayInCalendarObject day) {
			var calendarUtils = new CalendarUtils(UserConnection);
			IEnumerable<WorkingTimeInterval> timeIntervalsEntities = calendarUtils.GetWorkingTimeIntervals(day.Id);
			List<WorkingTimeIntervalObject> timeIntervals =
				ChangesStore.MergeIntervals(day.Id, timeIntervalsEntities
					.Select(t => new WorkingTimeIntervalObject(t))).ToList();
			CurrentWorkingTimeIntervalsData = timeIntervals;
			ClearIntervalDateTimeControls();
			var container = _page.PageContainer;
			foreach (WorkingTimeIntervalObject timeInterval in CurrentWorkingTimeIntervalsData) {
				var i = timeInterval.Index;
				var fromDate = 
					(DateTimeEdit)
						container.FindControl(string.Format(FromControlNameFormat, TimeIntervalTypeControlAlias, i));
				var toDate = 
					(DateTimeEdit)
						container.FindControl(string.Format(ToControlNameFormat, TimeIntervalTypeControlAlias, i));
				fromDate.SuspendAjaxEvents();
				toDate.SuspendAjaxEvents();
				fromDate.SelectedDate = timeInterval.From;
				toDate.SelectedDate = timeInterval.To;
				fromDate.ResumeAjaxEvents();
				toDate.ResumeAjaxEvents();
			}
		}

		/// <summary>
		/// ####### ######### ########## #######
		/// </summary>
		private void ClearIntervalDateTimeControls() {
			var dateTimeControlList = IntervalsControlLayout.Items.OfType<ControlLayout>()
				.SelectMany(dateTimeControlLayout => dateTimeControlLayout.Items.OfType<DateTimeEdit>());
			foreach (
				DateTimeEdit dateTimeControl in dateTimeControlList) {
				dateTimeControl.SuspendAjaxEvents();
				dateTimeControl.SelectedDate = DateTime.MinValue;
				dateTimeControl.ResumeAjaxEvents();
			}
		}

		/// <summary>
		/// ######### ###### ########## ######## #########, ###### ########### ##########
		/// </summary>
		/// <returns>########## ######### ### ##### foreach</returns>
		private IEnumerable<int> GetChagedTimeIntervalIndexesFromFilledControls() {
			List<DateTimeEdit> intervalList = GetWorkingTimeIntervalEdits().ToList();
			var minDate = DateTime.MinValue.Date;
			for (int i = 0; i < WorkingTimeIntervalIndexesCount; i++) {
				if (intervalList.Count(t => int.Parse(t.Tag) == i && t.SelectedDate.Date != minDate) == 2) {
					yield return i;
				}
			}
		}

		/// <summary>
		/// ######### #########
		/// </summary>
		/// <param name="dayInCalendarId">############# ### # #########</param>
		private void UpdateIntervals(Guid dayInCalendarId) {
			foreach (int i in ChangedWorkingTimeIntervalsIndexes) {
				var container = _page.PageContainer;
				var fromDate = 
					(DateTimeEdit)
						container.FindControl(string.Format(FromControlNameFormat, TimeIntervalTypeControlAlias, i));
				var toDate = 
					(DateTimeEdit)
						container.FindControl(string.Format(ToControlNameFormat, TimeIntervalTypeControlAlias, i));
				var minDate = DateTime.MinValue;
				bool isIntervalControlsFilled = fromDate.SelectedDate != minDate && toDate.SelectedDate != minDate;
				WorkingTimeIntervalObject timeInterval = CurrentWorkingTimeIntervalsData
					.SingleOrDefault(t => t.Index == i);
				if (isIntervalControlsFilled && timeInterval != null) {
					timeInterval.From = fromDate.SelectedDate;
					timeInterval.To = toDate.SelectedDate;
					ChangesStore.AddChangedInterval(timeInterval);
				} else if (isIntervalControlsFilled) {
					var newTimeInterval = new WorkingTimeIntervalObject {
						Id = Guid.NewGuid(),
						Index = i,
						DayInCalendarId = dayInCalendarId,
						From = fromDate.SelectedDate,
						To = toDate.SelectedDate
					};
					ChangesStore.AddNewInterval(newTimeInterval);
				} else if (timeInterval != null) {
					ChangesStore.AddRemovedInterval(timeInterval);
				}
			}
		}

		/// <summary>
		/// ######## ###### ############### ##########
		/// </summary>
		/// <returns>###### ############### ##########</returns>
		private IEnumerable<Guid> GetCalendarIdsChain() {
			var activeRow = _page.DataSource.ActiveRow;
			return new CalendarUtils(UserConnection).GetCalendarIdsChain(activeRow.PrimaryColumnValue,
				activeRow.HierarchyColumnValue);
		}

		/// <summary>
		/// ######## ######## ########## ########## ###
		/// </summary>
		private void ClearDisplayDayControls() {
			ClearIntervalDateTimeControls();
			IsDiffFromParentEdit.Disable();
			DayTypeEdit.Required = false;
			DayTypeEdit.Clear();
		}

		/// <summary>
		/// ######## ############## ##### ######## ####
		/// </summary>
		/// <returns>###### ############### ##### ######## ####</returns>
		private IEnumerable<Guid> GetDayTypeWeekends() {
			if (_dayTypeWeekends != null) {
				return _dayTypeWeekends;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayType");
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsWeekend", true));
			_dayTypeWeekends = esq.GetEntityCollection(UserConnection).Select(d => d.PrimaryColumnValue);
			return _dayTypeWeekends;
		}

		/// <summary>
		/// ######## ######### ############ #### ######
		/// </summary>
		/// <returns>########## ############ # ############### #### ######</returns>
		private Dictionary<Guid, string> GetDayOfWeekNames() {
			if (_dayOfWeekNames != null) {
				return _dayOfWeekNames;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayOfWeek");
			esq.AddAllSchemaColumns();
			_dayOfWeekNames = esq.GetEntityCollection(UserConnection)
				.ToDictionary(e => e.PrimaryColumnValue, e => e.PrimaryDisplayColumnValue);
			return _dayOfWeekNames;
		}

		/// <summary>
		/// ######## ######### ############ ##### ####
		/// </summary>
		/// <returns>########## ##### #### ###### # ############### </returns>
		private Dictionary<Guid, string> GetDayTypeNames() {
			if (_dayTypeNames != null) {
				return _dayTypeNames;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayType");
			esq.AddAllSchemaColumns();
			_dayTypeNames = esq.GetEntityCollection(UserConnection)
				.ToDictionary(e => e.PrimaryColumnValue, e => e.PrimaryDisplayColumnValue);
			return _dayTypeNames;
		}

		/// <summary>
		/// ######## ######### ###### ##### ####
		/// </summary>
		/// <returns>########## ###### ##### #### ###### # ############### </returns>
		private Dictionary<Guid, string> GetDayTypeColors() {
			if (_dayTypeColors != null) {
				return _dayTypeColors;
			}
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayType");
			esq.AddAllSchemaColumns();
			_dayTypeColors = esq.GetEntityCollection(UserConnection)
				.ToDictionary(e => e.PrimaryColumnValue, e => e.GetTypedColumnValue<string>("Color"));
			return _dayTypeColors;
		}

		/// <summary>
		/// ######### ############# ######### ###### ### # #########
		/// </summary>
		/// <param name="day">###### ### # #########</param>
		/// <returns>##/###</returns>
		private bool NeedUpdateDayInCalendarData(DayInCalendarObject day) {
			var selectedDayTypeId = (Guid)DayTypeEdit.Value;
			return day.DayTypeId != selectedDayTypeId && selectedDayTypeId != Guid.Empty;
		}

		#endregion

		#region Methods: Protected

		protected abstract DayInCalendarObject GetDay(Guid treeGridRecordId);

		protected abstract IEnumerable<DayInCalendarObject> GetDays();

		protected abstract bool GetIsDiffFromParent(DayInCalendarObject day);

		protected abstract KeyValuePair<Guid, DayInCalendarObject> GetFirstDayInCalendarData();

		/// <summary>
		/// ######### ###### #### ######
		/// </summary>
		protected void LoadDaysData() {
			CurrentTreeGridRecordId = Guid.Empty;
			FillVirtualDataSource();
			GetDaysVirtualDataSource().LoadRows();
			Guid treeGridRecordId = SelectDefaultDayRecord();
			if (treeGridRecordId == Guid.Empty) {
				ClearDisplayDayControls();
			}
		}

		/// <summary>
		/// ######### ######### # #########
		/// </summary>
		/// <param name="previousSelectedDay">###### ### # #########</param>
		/// <returns>##/###</returns>
		protected bool SaveChangesToStore(DayInCalendarObject previousSelectedDay) {
			bool isDiffFromParent = GetIsCurrentDayDiffFromParent();
			bool wasDiffFromParent = GetIsDiffFromParent(previousSelectedDay);
			Guid dayInCalendarId = previousSelectedDay.Id;
			bool isUpdated = true;
			if (!isDiffFromParent && wasDiffFromParent){
				ChangesStore.AddRemovedDay(previousSelectedDay);
			} else if (isDiffFromParent && !wasDiffFromParent) {
				var newDay = (DayInCalendarObject)previousSelectedDay.Clone();
				newDay.Id = Guid.NewGuid();
				newDay.DayTypeId = (Guid)DayTypeEdit.Value;
				newDay.CalendarId = _page.DataSource.ActiveRowPrimaryColumnValue;
				newDay.IsCalendarDayValue = IsCalendarDayValue;
				ChangesStore.AddNewDay(newDay);
				dayInCalendarId = newDay.Id;
				ChangedWorkingTimeIntervalsIndexes = GetChagedTimeIntervalIndexesFromFilledControls().ToList();
				CurrentWorkingTimeIntervalsData.Clear();
			} else if (isDiffFromParent && NeedUpdateDayInCalendarData(previousSelectedDay)) {
				previousSelectedDay.DayTypeId = (Guid)DayTypeEdit.Value;
				ChangesStore.AddChangedDay(previousSelectedDay);
			} else {
				isUpdated = false;
			}
			UpdateIntervals(dayInCalendarId);
			return isUpdated;
		}

		/// <summary>
		/// ######## ####### ####### ######## ### # ######### ## #############
		/// </summary>
		/// <returns>##/###</returns>
		protected virtual bool GetIsCurrentDayDiffFromParent() {
			return IsDiffFromParentEdit.Checked;
		}

		/// <summary>
		/// ########### ######## ########## ########## ### #########
		/// </summary>
		/// <param name="treeGridRecordId">############# ### ######### # ######</param>
		protected virtual void DisplayDayByTreeGridRecord(Guid treeGridRecordId) {
			if (treeGridRecordId != Guid.Empty && CurrentDaysGridData.Keys.Contains(treeGridRecordId)) {
				DisplayDayRecord(CurrentDaysGridData[treeGridRecordId]);
				CurrentTreeGridRecordId = treeGridRecordId;
				IsDiffFromParentEdit.Enable();
			}
			CurrentTreeGridRecordId = treeGridRecordId;
		}

		/// <summary>
		/// ########## #### ######### ## #########
		/// </summary>
		/// <returns>############# ### # ######</returns>
		protected virtual Guid SelectDefaultDayRecord() {
			Guid gridRecordId = Guid.Empty;
			if (!CurrentDaysGridData.Any()) {
				return gridRecordId;
			}
			VirtualDataSource dataSource = GetDaysVirtualDataSource();
			gridRecordId = GetFirstDayInCalendarData().Key;
			dataSource.SetClientActiveRow(gridRecordId);
			dataSource.SetActiveRow(gridRecordId);
			DaysTreeGrid.SelectNode(gridRecordId.ToString(), true);
			return gridRecordId;
		}

		/// <summary>
		/// ########### ######## ######### ########## ########## ### #########
		/// </summary>
		/// <param name="day">###### ### #########</param>
		protected virtual void DisplayDayRecord(DayInCalendarObject day) {
			IsDiffFromParentEdit.Value = GetIsDiffFromParent(day);
			DayTypeEdit.SetValueAndText(day.DayTypeId, GetDayTypeNames()[day.DayTypeId]);
			DisplayWorkingTimeIntervals(day);
			ChangedWorkingTimeIntervalsIndexes.Clear();
		}

		/// <summary>
		/// ######## ########### ######### ### #########
		/// </summary>
		/// <param name="treeGridRecordId">############# ### ######### # ######</param>
		protected void RefreshDayVirtualDataSourceRecord(Guid treeGridRecordId) {
			VirtualDataSource dataSource = GetDaysVirtualDataSource();
			DayInCalendarObject actualDayInCalendar = GetDay(treeGridRecordId);
			CurrentDaysGridData[treeGridRecordId] = actualDayInCalendar;
			Entity row = CreateDayVirtualDataSourceRow(dataSource, actualDayInCalendar, treeGridRecordId);
			dataSource.Update(row);
			dataSource.LoadRow(treeGridRecordId);
		}

		/// <summary>
		/// ################ ########### ######### ### #########
		/// </summary>
		protected void RegisterDaysVirtualDataSource() {
			VirtualDataSource dataSource = GetDaysVirtualDataSource();
			if (dataSource != null) {
				return;
			}
			dataSource = CreateDaysVirtualDataSource();
			InitializeDaysVirtualDataSource(dataSource);
			dataSource.LoadStructure();
			_page.PageContainer.Controls.Add(dataSource);
		}

		/// <summary>
		/// ####### ########### ######### ### ######### # ############ ## ########### #######
		/// </summary>
		protected VirtualDataSource CreateDaysVirtualDataSource() {
			var virtualDataSource = new VirtualDataSource {
				ID = DaysVirtualDataSourceName
			};
			virtualDataSource.Loaded += DaysTreeGrid.DataLoaded;
			virtualDataSource.RowUpdated += DaysTreeGrid.RowUpdated;
			DaysTreeGrid.GetRowConfigHandler = GetTreeGridRowConfig;
			return virtualDataSource;
		}

		/// <summary>
		/// ################ ########### ######### ### #########
		/// </summary>
		protected virtual void InitializeDaysVirtualDataSource(VirtualDataSource virtualDataSource) {
			var dataValueTypeManager =
				(DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			DaysTreeGrid.DataSourceId = virtualDataSource.ID;
			DataSourceStructure edsStructure = DaysEntityDataSource.CurrentStructure;
			DataSourceStructure vdsStructure = virtualDataSource.DefStructure;
			vdsStructure.PrimaryColumnName = GridRecordIdColumnName;
			vdsStructure.PrimaryDisplayColumnName = edsStructure.PrimaryDisplayColumnName;
			foreach (DataSourceStructureColumn edsColumn in edsStructure.Columns) {
				vdsStructure.AddColumn((DataSourceStructureColumn)edsColumn.Clone());
			}
			var treeGridRecordIdColumn = new DataSourceStructureColumn {
				Name = GridRecordIdColumnName,
				DataValueType = dataValueTypeManager.GetInstanceByName("Guid"),
				IsVisible = false,
			};
			vdsStructure.AddColumn(treeGridRecordIdColumn);
		}

		/// <summary>
		/// ######### ########### ######### ### #########
		/// </summary>
		protected virtual void FillVirtualDataSource() {
			IEnumerable<DayInCalendarObject> days = GetDays();
			VirtualDataSource daysDataSource = GetDaysVirtualDataSource();
			daysDataSource.Clear();
			CurrentDaysGridData.Clear();
			foreach (DayInCalendarObject day in days) {
				Guid gridRecordId = Guid.NewGuid();
				Entity row = CreateDayVirtualDataSourceRow(daysDataSource, day, gridRecordId);
				daysDataSource.Add(row);
				CurrentDaysGridData.Add(gridRecordId, day);
			}
		}

		/// <summary>
		/// ####### ###### # ########### ########## ### #########
		/// </summary>
		/// <param name="daysDataSource">########### ######### ### #########</param>
		/// <param name="day">###### ### #########</param>
		/// <param name="gridRecordId">############# ### ######### # ######</param>
		/// <returns>######## ### ######### # ##########</returns>
		protected virtual Entity CreateDayVirtualDataSourceRow(VirtualDataSource daysDataSource, DayInCalendarObject day,
			Guid gridRecordId) {
			Entity row = daysDataSource.CreateRow();
			row.SetColumnValue("DayOfWeekId", day.DayOfWeekId);
			row.SetColumnValue("DayOfWeekName", GetDayOfWeekNames()[day.DayOfWeekId]);
			row.SetColumnValue("DayTypeId", day.DayTypeId);
			row.SetColumnValue("DayTypeName", GetDayTypeNames()[day.DayTypeId]);
			row.SetColumnValue("CalendarId", day.CalendarId);
			row.SetColumnValue(GridRecordIdColumnName, gridRecordId);
			if (day.Date.Date != DateTime.MinValue.Date) {
				row.SetColumnValue("Date", day.Date);
			}
			return row;
		}

		/// <summary>
		/// ######## ########### ######### ### #########
		/// </summary>
		/// <returns></returns>
		protected virtual VirtualDataSource GetDaysVirtualDataSource() {
			return _page.PageContainer.FindControl(DaysVirtualDataSourceName) as VirtualDataSource;
		}

		/// <summary>
		/// ######### ###### ######### ####### ############ ########## ### #########
		/// </summary>
		protected virtual void SubscribeDataSourcesEvents() {
			string validationFunctionScript = CalendarHelperEditPageScriptManager
				.GetValidationFunctionScript(UserConnection);
			_page.AddScript(validationFunctionScript);
			string rowChangedFunc = CalendarHelperEditPageScriptManager.GetRowChangedFunctionScript();
			_page.AddScript(String.Format(rowChangedFunc, DaysVirtualDataSourceName, InstanceUId,
				TreeGridSelectionChangeEventName, TimeIntervalTypeControlAlias, DaysTreeGrid.ClientID));
		}

		/// <summary>
		/// ############ ######## #### ### #########
		/// </summary>
		protected virtual void FillDayTypeControl() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "DayType");
			esq.AddAllSchemaColumns();
			EntityCollection dayTypes = esq.GetEntityCollection(UserConnection);
			foreach (Entity type in dayTypes) {
				DayTypeEdit.AddItem(type.PrimaryColumnValue, type.PrimaryDisplayColumnValue);
			}
		}

		/// <summary>
		/// ######## config ###### # ######
		/// </summary>
		/// <param name="row">######## ### ######### # ##########</param>
		/// <returns>config ###### # ######</returns>
		protected virtual DataSourceRowConfig GetTreeGridRowConfig(Entity row) {
			var rowConfig = new DataSourceRowConfig(row.PrimaryColumnValue);
			string color = GetDayTypeColors()[row.GetTypedColumnValue<Guid>("DayTypeId")];
			if (Regex.IsMatch(color, ColorRegExpMask, RegexOptions.IgnoreCase)) {
				var colorConfigValue = new DataSourceRowBackgroundColorConfigValue(color);
				rowConfig.AddConfig(colorConfigValue);
			}
			return rowConfig;
		}

		/// <summary>
		/// ######## ## ######### #######
		/// </summary>
		/// <returns>##/###</returns>
		protected bool IsBaseCalendar() {
			return _page.DataSource.ActiveRow.GetTypedColumnValue<Guid>("ParentId") == Guid.Empty;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ############ ####### ######
		/// </summary>
		/// <param name="page">######## ############## ##########</param>
		/// <param name="userConnection">###### ########### ######## ############</param>
		/// <param name="instanceUId">############# ##########</param>
		public void UpdatePageControl(CalendarEditPageSchemaUserControl page, UserConnection userConnection,
			string instanceUId) {
			_page = page;
			UserConnection = userConnection;
			InstanceUId = instanceUId;
		}

		/// <summary>
		/// ######## ######### ######### ###### ############## #########
		/// </summary>
		/// <returns>######### ###### ############## #########</returns>
		public HelperCalendarEditPageState GetHelperState() {
			return new HelperCalendarEditPageState {
				CurrentDaysGridData = CurrentDaysGridData,
				CurrentWorkingTimeIntervalsData = CurrentWorkingTimeIntervalsData,
				CurrentTreeGridRecordId = CurrentTreeGridRecordId,
				ChangedWorkingTimeIntervalsIndexes = ChangedWorkingTimeIntervalsIndexes,
				CalendarIdsChain = CalendarIdsChain,
				ChangesStore = ChangesStore
			};
		}

		/// <summary>
		/// ########## ######## ######### ######### ###### ############## #########
		/// </summary>
		/// <param name="state">######### ######### ###### ############## #########</param>
		public void LoadHelperState(HelperCalendarEditPageState state) {
			CurrentDaysGridData = state.CurrentDaysGridData;
			CurrentWorkingTimeIntervalsData = state.CurrentWorkingTimeIntervalsData.ToList();
			CurrentTreeGridRecordId = state.CurrentTreeGridRecordId;
			ChangedWorkingTimeIntervalsIndexes = state.ChangedWorkingTimeIntervalsIndexes;
			CalendarIdsChain = state.CalendarIdsChain;
			ChangesStore = state.ChangesStore;
		}

		/// <summary>
		/// ########## ####### ######### ######## ########
		/// </summary>
		public virtual void HandlePageLoadComplete() {
			DaysTreeGrid.SelectionMode = TreeGridSelectionMode.SingleRow;
			CalendarIdsChain = GetCalendarIdsChain();
			FillDayTypeControl();
			SubscribeDayDisplayControlEvents();
			SubscribeDataSourcesEvents();
			LoadDaysData();
		}

		/// <summary>
		/// ############# ############ ########## ########## # ############
		/// </summary>
		public void HandleInit() {
			RegisterDaysVirtualDataSource();
			SubscribeTimeIntervalEditsEvents();
		}

		/// <summary>
		/// ########## ####### ######### ######### ######
		/// </summary>
		public void HandleTreeGridSelectionChange() {
			if (CurrentTreeGridRecordId != Guid.Empty && CurrentDaysGridData.Keys.Contains(CurrentTreeGridRecordId) &&
				SaveChangesToStore(CurrentDaysGridData[CurrentTreeGridRecordId])) {
				RefreshDayVirtualDataSourceRecord(CurrentTreeGridRecordId);
			}
			DisplayDayByTreeGridRecord(GetDaysVirtualDataSource().ActiveRowPrimaryColumnValue);
		}

		/// <summary>
		/// ########## ####### ##########. ########## ########## # #########
		/// </summary>
		public void HandleDataSourceSaved() {
			if (CurrentTreeGridRecordId != Guid.Empty && CurrentDaysGridData.Keys.Contains(CurrentTreeGridRecordId)) {
				SaveChangesToStore(CurrentDaysGridData[CurrentTreeGridRecordId]);
			}
			ChangesStore.SaveChanges(UserConnection);
		}

		/// <summary>
		/// ########## ####### ######### #### ### #########
		/// </summary>
		public void HandleDayTypeEditChange() {
			var dayTypeId = (Guid)DayTypeEdit.Value;
			bool isDayTypeWeekend = dayTypeId != Guid.Empty && GetDayTypeWeekends().Contains(dayTypeId);
			if (isDayTypeWeekend) {
				ClearIntervalDateTimeControls();
				ChangedWorkingTimeIntervalsIndexes.AddRange(Enumerable.Range(0, WorkingTimeIntervalIndexesCount));
			}
		}

		#endregion
	}

	#endregion
}
