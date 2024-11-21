namespace BPMSoft.Configuration.Calendars
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.TermCalculationService;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;
	using BPMSoft.Core.Entities;

	/// <summary>
	/// Entry point for calculation terms
	/// </summary>
	public class CaseTermCalculateEntryPoint
	{

		#region Fields: Private

		private readonly TermCalculationLogStore _calculationLogStore;

		#endregion

		#region Properties : Protected

		/// <summary>
		/// Gets the user connection.
		/// </summary>
		/// <value>
		/// The user connection.
		/// </value>
		protected UserConnection UserConnection {
			get;
			private set;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CaseTermCalculateEntryPoint"/> class.
		/// </summary>
		public CaseTermCalculateEntryPoint() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CaseTermCalculateEntryPoint"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public CaseTermCalculateEntryPoint(UserConnection userConnection) {
			UserConnection = userConnection;
			_calculationLogStore = TermCalculationLogStoreInitializer.GetStore(userConnection);
		}

        public CaseTermCalculateEntryPoint(UserConnection userConnection, TermCalculationLogStore logStore)
        {
            UserConnection = userConnection;
            _calculationLogStore = logStore ?? TermCalculationLogStoreInitializer.GetStore(userConnection);
        }

        #endregion

        #region Methods: Private

        private DateTime ConvertFromUtc(DateTime dateTime, TimeZoneInfo timeZoneInfo) {
			return TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo);
		}

		private ServiceTermResponse ExecuteCalculateTerms(DateTime startDate, CaseTermInterval termInterval,
				TimeZoneInfo userTimeZone, CaseTermStates mask, TermCalculationLogStore logStore = null) {
			var calendarutility = new CalendarUtility(UserConnection, logStore);
			var response = new ServiceTermResponse();
			response.ReactionTime = mask.HasFlag(CaseTermStates.ContainsResponse)
				? calendarutility.Add(startDate, termInterval.ResponseTerm, userTimeZone) as DateTime?
				: null;
			response.SolutionTime = mask.HasFlag(CaseTermStates.ContainsResolve)
				? calendarutility.Add(startDate, termInterval.ResolveTerm, userTimeZone) as DateTime?
				: null;
			return response;
		}

		private ServiceTermResponse ExecuteRecalculateTerms(CaseTermInterval termInterval,
				IEnumerable<DateTimeInterval> intervals, TimeZoneInfo userTimeZone, CaseTermStates mask, object caseId) {
			var calendarutility = new CalendarUtility(UserConnection);
			var response = new ServiceTermResponse();
			var dateTime = ConvertFromUtc(DateTime.UtcNow, userTimeZone);
			var isOverdue = CheckIsOverdue(termInterval.ResolveTerm, intervals);
			var caseEntity = GetCaseEntity(caseId);

			if (mask.HasFlag(CaseTermStates.ContainsResponse))
			{
				if (caseEntity.GetTypedColumnValue<DateTime>("RespondedOn") == DateTime.MinValue)
					response.ReactionTime = calendarutility.Add(dateTime, termInterval.ResponseTerm, intervals, userTimeZone) as DateTime?;
				else
					response.ReactionTime = isOverdue
						? caseEntity.GetTypedColumnValue<DateTime>("ResponseDate")
						: calendarutility.Add(dateTime, termInterval.ResponseTerm, intervals, userTimeZone) as DateTime?;
			}

			if (mask.HasFlag(CaseTermStates.ContainsResolve))
			{
				if (caseEntity.GetTypedColumnValue<DateTime>("RespondedOn") == DateTime.MinValue)
					response.SolutionTime = calendarutility.Add(dateTime, termInterval.ResolveTerm, intervals, userTimeZone) as DateTime?;
				else
					response.SolutionTime = isOverdue
						? CalculateTermsForOverdue(termInterval.ResolveTerm, intervals)
						: calendarutility.Add(dateTime, termInterval.ResolveTerm, intervals, userTimeZone) as DateTime?;
			}

			return response;
		}

		private Entity GetCaseEntity(object caseId)
		{
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName("Case");
			var entityCase = entitySchema.CreateEntity(UserConnection);
			return entityCase.FetchFromDB(caseId) ? entityCase : null;
		}

		private bool CheckIsOverdue(TimeTerm term, IEnumerable<DateTimeInterval> intervals)
		{
			var calendarUtility = new CalendarUtility(UserConnection);
			var userTimeZone = UserConnection.CurrentUser.TimeZone;
			var alreadyWorkedTime = calendarUtility.GetTimeUnitsInPeriods(term, intervals, userTimeZone);
			var timeForSolutionLeft = term.Value - alreadyWorkedTime;
			return timeForSolutionLeft <= 0;
		}

		private DateTime CalculateTermsForOverdue(TimeTerm term, IEnumerable<DateTimeInterval> intervals)
		{
			var calendarUtility = new CalendarUtility(UserConnection);
			var userTimeZone = UserConnection.CurrentUser.TimeZone;
			var timeForSolutionLeft = term.Value;
			var starDate = ConvertFromUtc(DateTime.UtcNow, userTimeZone);

			foreach (var interval in intervals)
			{
				var intervalWorkedTime = calendarUtility.GetTimeUnitsInPeriod(term, interval, userTimeZone);

				if (timeForSolutionLeft <= intervalWorkedTime)
				{
					starDate = interval.Start;
					break;
				}

				timeForSolutionLeft -= intervalWorkedTime;
			}

			var newTerm = new TimeTerm
			{
				Type = term.Type,
				Value = timeForSolutionLeft,
				CalendarId = term.CalendarId,
				NativeTimeTerm = term.NativeTimeTerm
			};

			return calendarUtility.Add(starDate, newTerm, userTimeZone);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Counts reaction time and a solution time to Case.
		/// </summary>
		/// <param name="arguments">Dictionary with params for strategies.</param>
		/// <param name="startDate">Start date for calculation.</param>
		/// <returns>An object that contains the reaction time and solution time.</returns>
		public ServiceTermResponse CalculateTerms(Dictionary<string, object> arguments, DateTime startDate) {
			var response = new ServiceTermResponse();
			var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			var argumentsArg = new ConstructorArgument("arguments", arguments);
			var selector = ClassFactory.Get<CaseTermIntervalSelector>(userConnectionArg);
			var termInterval = selector.Get(arguments) as CaseTermInterval;
			CaseTermStates mask;
			if (_calculationLogStore != null) {
				mask = new TermCalculationLogger(_calculationLogStore).GetCaseTermState(termInterval);
			} else {
				mask = termInterval.GetMask();
			}
			if (mask != CaseTermStates.None) {
				var intervalReader = ClassFactory.Get<CaseActiveIntervalReader>(userConnectionArg, argumentsArg);
				var userTimeZone = UserConnection.CurrentUser.TimeZone;
				IEnumerable<DateTimeInterval> intervals = intervalReader.GetActiveIntervals();
				arguments.TryGetValue("CaseId", out var caseId);
				if (intervals.IsEmpty()) {
					response = ExecuteCalculateTerms(startDate, termInterval, userTimeZone, mask, _calculationLogStore);
				} else {
					response = ExecuteRecalculateTerms(termInterval, intervals, userTimeZone, mask, caseId);
				}
			}
			return response;
		}

		/// <summary>
		/// Start calculation reaction time and a solution time to Case.
		/// </summary>
		/// <param name="arguments">Dictionary with params for strategies.</param>
		/// <param name="startDate">Start date for calculation.</param>
		/// <returns></returns>
		public ServiceTermResponse ForceCalculateTerms(Dictionary<string, object> arguments, DateTime startDate) {
			var response = new ServiceTermResponse();
			var userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			var selector = ClassFactory.Get<CaseTermIntervalSelector>(userConnectionArg);
			var termInterval = selector.Get(arguments) as CaseTermInterval;
			var mask = termInterval.GetMask();
			if (mask != CaseTermStates.None) {
				var userTimeZone = UserConnection.CurrentUser.TimeZone;
				response = ExecuteCalculateTerms(startDate, termInterval, userTimeZone, mask);
			}
			return response;
		}

		#endregion
	}
}
