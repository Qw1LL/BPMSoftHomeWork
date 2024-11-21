namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Enums;
	using BPMSoft.Core.DB;
	using CoreCampaignSchema = BPMSoft.Core.Campaign.CampaignSchema;

	#region Class: CampaignTimeScheduler

	/// <summary>
	/// Contains logic of calculation campaign time parameters.
	/// </summary>
	public class CampaignTimeScheduler : ICampaignTimeScheduler
	{

		#region Class: BaseCampaignTimeCalculator

		/// <summary>
		/// Base item for chain of the campaign time calculators.
		/// </summary>
		private class BaseCampaignTimeCalculator
		{

			#region Properties: Protected

			protected BaseCampaignTimeCalculator NextCalculator {
				get; set;
			}

			#endregion

			#region Methods: Protected

			/// <summary>
			/// Calculates nearest time to benchmark time from conditional transition and timer elements.
			/// </summary>
			/// <param name="elements">List of elements which containes time for calculates next campaign run.</param>
			/// <param name="scheduledTimeParameters">Parameters which describes campaign state
			/// and includes parameters for calculates next fire time.</param>
			/// <returns>Returns instance of <see cref="CampaignFireTimeConfig"/>. It containes min 
			/// time for next schedule job, when some element are contanies times, and otherwise returns 
			/// config that containes <see cref="CampaignFireTimeConfig.Time"/> is equal 
			/// <see cref="DateTime.MaxValue"/>.</returns>
			protected CampaignFireTimeConfig GetTimedElementsNextFireTime(IEnumerable<CampaignSchemaElement> elements,
					CampaignScheduledTimeParameters scheduledTimeParameters) {
				var fireTimeConfig = new CampaignFireTimeConfig {
					Time = DateTime.MaxValue,
					ExecutionStrategy = CampaignSchemaExecutionStrategy.Immediate
				};
				foreach (var element in elements) {
					var elementFireTime = element.GetFireTime();
					if (!elementFireTime.HasValue) {
						continue;
					}
					var elementExecutionDate = new DateTime(elementFireTime.Value.Ticks);
					if (elementExecutionDate < fireTimeConfig.Time
						&& elementExecutionDate > scheduledTimeParameters.BenchmarkTime) {
						fireTimeConfig.Time = elementExecutionDate;
					}
				}
				return fireTimeConfig;
			}

			/// <summary>
			/// Calls next step in chain and returns result from this step.
			/// </summary>
			/// <param name="schema">Campaign schema.
			/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
			/// <param name="scheduledTimeParameters">Parameters which describes campaign state
			/// and includes parameters for calculates next fire time.</param>
			/// <param name="previousStepCalculatedTime"><see cref="CampaignFireTimeConfig"/> containes
			/// current step calculation result.</param>
			/// <returns>Returns <paramref name="previousStepCalculatedTime"/> when <see cref="NextCalculator"/>
			/// is not defined. And result of calculation from next step in otherwise.</returns>
			protected CampaignFireTimeConfig CallNextStep(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				return NextCalculator == null
					? previousStepCalculatedTime
					: NextCalculator.Calculate(schema, scheduledTimeParameters, previousStepCalculatedTime);
			}

			/// <summary>
			/// Calls next step in chain with min value between <paramref name="previousStepCalculatedTime"/> and
			/// <paramref name="comparedCalculatedTime"/> and returns result from calculates next step.
			/// </summary>
			/// <param name="schema">Campaign schema.
			/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
			/// <param name="scheduledTimeParameters">Parameters which describes campaign state
			/// and includes parameters for calculates next fire time.</param>
			/// <param name="previousStepCalculatedTime"><see cref="CampaignFireTimeConfig"/> containes
			/// current step calculation result.</param>
			/// <param name="comparedCalculatedTime">This config should compare with
			/// <paramref name="previousStepCalculatedTime"/> and with minimum of this calls
			/// <see cref="CallNextStep(CoreCampaignSchema, CampaignScheduledTimeParameters, CampaignFireTimeConfig)"/>
			/// method.</param>
			/// <returns>Returns <paramref name="previousStepCalculatedTime"/> when <see cref="NextCalculator"/>
			/// is not defined. And result of calculation from next step in otherwise.</returns>
			protected CampaignFireTimeConfig CallNextStepWithMinValue(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime,
					CampaignFireTimeConfig comparedCalculatedTime) {
				var minFireTime = comparedCalculatedTime.Time < previousStepCalculatedTime.Time
						&& comparedCalculatedTime.Time != default(DateTime)
					? comparedCalculatedTime
					: previousStepCalculatedTime;
				return CallNextStep(schema, scheduledTimeParameters, minFireTime);
			}

			#endregion

			#region Methods: Internal

			internal BaseCampaignTimeCalculator SetNextStep(BaseCampaignTimeCalculator nextStep) {
				nextStep.CheckArgumentNull(nameof(nextStep));
				NextCalculator = nextStep;
				return nextStep;
			}

			#endregion

			#region Methods: Public

			internal virtual CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				return new CampaignFireTimeConfig();
			}

			#endregion

		}

		#endregion

		#region Class: CampaignDefaultTimeCalculator

		/// <summary>
		/// Chain item for calculates next default fire of campaign
		/// based on <see cref="CoreCampaignSchema.DefaultCampaignFirePeriod"/>.
		/// </summary>
		private class CampaignDefaultTimeCalculator : BaseCampaignTimeCalculator
		{

			#region Fields: Private

			private UserConnection _userConnection;

			#endregion

			#region Constructors: Public

			/// <summary>
			/// Creates a new instance with specified userConnection.
			/// </summary>
			/// <param name="userConnection">Instance of current user connection.</param>
			public CampaignDefaultTimeCalculator(UserConnection userConnection) : base() {
				_userConnection = userConnection;
			}

			#endregion

			#region Properties: Public

			/// <summary>
			/// Gets or sets the campaign helper. Instance of <see cref="CampaignHelper"/>.
			/// </summary>
			private CampaignHelper _campaignHelper;
			public CampaignHelper CampaignHelper {
				get {
					return _campaignHelper ?? (_campaignHelper = new CampaignHelper(_userConnection));
				}
				set {
					_campaignHelper = value;
				}
			}

			#endregion

			#region Methods: Private

			/// <summary>
			/// Converts local date and time to UTC based on current campaign time zone.
			/// If date is not valid (for example 26.03.2017 03:00-04:00 for Kiev GMT+02:00)
			/// Shifts it to the future by campaign default period.
			/// </summary>
			/// <param name="schema">Campaign schema.
			/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/>.</param>
			/// <param name="localTime">Local <see cref="System.DateTime"/> date and time to convert to UTC.</param>
			/// <returns>UTC <see cref="System.DateTime"/> with daylight offset.</returns>
			private DateTime ConvertToUtcByCampaignTimeZone(CoreCampaignSchema schema, DateTime localTime) {
				if (localTime.Kind == DateTimeKind.Utc) {
					return localTime;
				}
				var defaultPeriodAddingCount = 100;
				if (schema.TimeZoneOffset.IsInvalidTime(localTime)) {
					for (int i = 0; i < defaultPeriodAddingCount; i++) {
						localTime = localTime.AddMinutes(schema.DefaultCampaignFirePeriod);
						if (!schema.TimeZoneOffset.IsInvalidTime(localTime)) {
							break;
						}
					}
					if (schema.TimeZoneOffset.IsInvalidTime(localTime)) {
						var message = CampaignHelper
							.GetLczStringValue(nameof(CampaignTimeScheduler), "IsInvalidTimeOutOfRangeIterationError");
						throw new Exception(message);
					}
				}
				return TimeZoneInfo.ConvertTimeToUtc(localTime, schema.TimeZoneOffset);
			}

			#endregion

			#region Methods: Public

			/// <summary>
			/// Returns config for schedule next campaign job by default campaign fire period.
			/// Uses to local time convertion to include daylight offset and reverts next fire time to UTC.
			/// </summary>
			/// <param name="schema">Campaign schema.
			/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/>.</param>
			/// <param name="scheduledTimeParameters">Parameters for schedule new job for campaign.</param>
			/// <param name="previousStepCalculatedTime">Instance of <see cref="CampaignFireTimeConfig"/> that contains
			/// information for schedule next campaign job by previous calculation step.</param>
			/// <returns>Instance of <see cref="CampaignFireTimeConfig"/> that contains
			/// all needed information for schedule next campaign job by current step.</returns>
			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				var fireTimeConfig = new CampaignFireTimeConfig {
					Time = DateTime.MaxValue,
					ExecutionStrategy = CampaignSchemaExecutionStrategy.DefaultPeriod
				};
				if (scheduledTimeParameters.CampaignStatusId != CampaignConsts.RunCampaignStatusId) {
					fireTimeConfig.ScheduledAction = CampaignScheduledAction.Start;
					fireTimeConfig.Time = scheduledTimeParameters.CurrentTime;
					return fireTimeConfig;
				}
				var localStartDate = TimeZoneInfo.ConvertTimeFromUtc(scheduledTimeParameters.StartDate, schema.TimeZoneOffset);
				var localBenchmarkTime = TimeZoneInfo.ConvertTimeFromUtc(scheduledTimeParameters.BenchmarkTime, schema.TimeZoneOffset);
				var campaignLifeTime = localBenchmarkTime - localStartDate;
				var toPreviousDefault = (int)Math.Round(campaignLifeTime.TotalMinutes) % schema.DefaultCampaignFirePeriod;
				var nextLocalDefaultTime = toPreviousDefault == 0 && !scheduledTimeParameters.PreviousFireTime.HasValue
					? localBenchmarkTime
					: localBenchmarkTime
						.AddMinutes(schema.DefaultCampaignFirePeriod - toPreviousDefault);
				fireTimeConfig.Time = ConvertToUtcByCampaignTimeZone(schema, nextLocalDefaultTime);
				return CallNextStep(schema, scheduledTimeParameters, fireTimeConfig);
			}

			#endregion

		}

		#endregion

		#region Class: CampaignMisfiredScheduledStopCalculator

		/// <summary>
		/// Calculates time for misfired scheduled stop and StoppingCampaignStatus.
		/// When campaign misfired default scheduled stop
		/// method <see cref="Calculate(CoreCampaignSchema, CampaignScheduledTimeParameters, CampaignFireTimeConfig)"/>
		/// returns time of scheduled stop.
		/// When campaign status is stoppping at this time returns time for immediate stop.
		/// In otherwise calls next calculator.
		/// </summary>
		private class CampaignImmediateStopCalculator : BaseCampaignTimeCalculator
		{

			#region Methods: Public

			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				if (scheduledTimeParameters.CampaignStatusId == CampaignConsts.StoppingCampaignStatusId) {
					return new CampaignFireTimeConfig {
						Time = scheduledTimeParameters.CurrentTime,
						ScheduledAction = CampaignScheduledAction.Stop,
						ExecutionStrategy = CampaignSchemaExecutionStrategy.DefaultPeriod
					};
				}
				if (scheduledTimeParameters.ScheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId
						&& scheduledTimeParameters.CurrentTime >= scheduledTimeParameters.ScheduledStopDate) {
					return new CampaignFireTimeConfig {
						Time = scheduledTimeParameters.ScheduledStopDate,
						ScheduledAction = CampaignScheduledAction.ScheduledStop,
						ExecutionStrategy = CampaignSchemaExecutionStrategy.DefaultPeriod
					};
				}
				return CallNextStep(schema, scheduledTimeParameters, previousStepCalculatedTime);
			}

			#endregion

		}

		#endregion

		#region Calss: CampaignScheduledStartTimeCalculator

		/// <summary>
		/// Calculates scheduled start time.
		/// </summary>
		private class CampaignScheduledStartTimeCalculator : BaseCampaignTimeCalculator
		{

			#region Methods: Public

			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				var fireTimeConfig = previousStepCalculatedTime;
				if (scheduledTimeParameters.CampaignStatusId != CampaignConsts.RunCampaignStatusId
						&& scheduledTimeParameters.ScheduledStartModeId == CampaignConsts.CampaingSpecifiedTimeModeId) {
					return new CampaignFireTimeConfig {
						Time = new DateTime(scheduledTimeParameters.ScheduledStartDate.Ticks, DateTimeKind.Utc),
						ExecutionStrategy = CampaignSchemaExecutionStrategy.DefaultPeriod,
						ScheduledAction = CampaignScheduledAction.ScheduledStart
					};
				}
				return CallNextStep(schema, scheduledTimeParameters, fireTimeConfig);
			}

			#endregion

		}

		#endregion

		#region Calss: CampaignScheduledStopTimeCalculator

		/// <summary>
		/// Calculates scheduled stop time, based on <see cref="Campaign.ScheduledStartModeId"/>.
		/// </summary>
		private class CampaignScheduledStopTimeCalculator : BaseCampaignTimeCalculator
		{

			#region Methods: Public

			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				var fireTimeConfig = previousStepCalculatedTime;
				if (scheduledTimeParameters.ScheduledStopModeId == CampaignConsts.CampaingSpecifiedTimeModeId
						&& previousStepCalculatedTime.Time >= scheduledTimeParameters.ScheduledStopDate) {
					fireTimeConfig = new CampaignFireTimeConfig {
						Time = new DateTime(scheduledTimeParameters.ScheduledStopDate.Ticks, DateTimeKind.Utc),
						ExecutionStrategy = CampaignSchemaExecutionStrategy.DefaultPeriod,
						ScheduledAction = CampaignScheduledAction.ScheduledStop
					};
				}
				return CallNextStep(schema, scheduledTimeParameters, fireTimeConfig);
			}

			#endregion

		}

		#endregion

		#region Class: CampaignTransitionTimeCalculator

		/// <summary>
		/// Calculates min transitions time from <see cref="CoreCampaignSchema"/>.
		/// </summary>
		private class CampaignTransitionTimeCalculator : BaseCampaignTimeCalculator
		{

			#region Methods: Public

			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				var elements = schema.FlowElements
					.Where(x => x.ElementType.HasFlag(CampaignSchemaElementType.Transition));
				var fireTimeConfig = GetTimedElementsNextFireTime(elements, scheduledTimeParameters);
				return CallNextStepWithMinValue(schema, scheduledTimeParameters, previousStepCalculatedTime,
					fireTimeConfig);
			}

			#endregion

		}

		#endregion

		#region Class: CampaignScheduledTimeParameters

		/// <summary>
		/// Contains parameters for schedule new job for campaign.
		/// </summary>
		private class CampaignScheduledTimeParameters
		{

			#region Properties: Internal

			/// <summary>
			/// When <see cref="ScheduledStartModeId"/> is
			/// <see cref="CampaignConstants.CampaingSpecifiedTimeModeId"/> then
			/// this parameters describes time to scheduled start.
			/// </summary>
			internal DateTime ScheduledStartDate {
				get; set;
			}

			/// <summary>
			/// When <see cref="ScheduledStopModeId"/> is
			/// <see cref="CampaignConstants.CampaingSpecifiedTimeModeId"/> then
			/// this parameters describes time to scheduled stop.
			/// </summary>
			internal DateTime ScheduledStopDate {
				get; set;
			}

			/// <summary>
			/// Campaign scheduled start mode identifier.
			/// </summary>
			internal Guid ScheduledStartModeId
			{
				get; set;
			}

			/// <summary>
			/// Campaign scheduled stop mode identifier.
			/// </summary>
			internal Guid ScheduledStopModeId {
				get; set;
			}

			/// <summary>
			/// Campaign status identifier.
			/// </summary>
			internal Guid CampaignStatusId {
				get; set;
			}

			/// <summary>
			/// Defines previous campaign scheduled time.
			/// Can be null when previous job is lost or it's first execution.
			/// </summary>
			internal DateTime? PreviousFireTime {
				get; set;
			}

			/// <summary>
			/// Defines current time of for schedule next campaign job.
			/// </summary>
			internal DateTime CurrentTime {
				get; set;
			}

			/// <summary>
			/// Campaign start date.
			/// </summary>
			internal DateTime StartDate {
				get; set;
			}

			/// <summary>
			/// Previous execution date from database.
			/// </summary>
			internal DateTime PrevExecutedOn {
				get; set;
			}

			/// <summary>
			/// Defines time for which <see cref="CampaignTimeScheduler"/> calculates next fire time for campaign.
			/// </summary>
			internal DateTime BenchmarkTime {
				get; set;
			}

			#endregion

		}

		#endregion

		#region Class: CampaignTimerTimeCalculator

		private class CampaignTimerTimeCalculator : BaseCampaignTimeCalculator
		{

			#region Methods: Internal

			internal override CampaignFireTimeConfig Calculate(CoreCampaignSchema schema,
					CampaignScheduledTimeParameters scheduledTimeParameters,
					CampaignFireTimeConfig previousStepCalculatedTime) {
				var timerElements = schema.FlowElements.OfType<CampaignTimerElement>();
				CampaignFireTimeConfig fireTimeConfig = GetTimedElementsNextFireTime(timerElements, scheduledTimeParameters);
				return CallNextStepWithMinValue(schema, scheduledTimeParameters, previousStepCalculatedTime,
					fireTimeConfig);
			}

			#endregion

		}

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public CampaignTimeScheduler(UserConnection userConnection) {
			_userConnection = userConnection;
			var misfiredScheduledStopCalculator = new CampaignImmediateStopCalculator();
			var defaultTimeCalculator = new CampaignDefaultTimeCalculator(userConnection);
			var scheduledStartTimeCalculator = new CampaignScheduledStartTimeCalculator();
			var transitionTimeCalculator = new CampaignTransitionTimeCalculator();
			var scheduledStopTimeCalculator = new CampaignScheduledStopTimeCalculator();
			var timerTimeCalculator = new CampaignTimerTimeCalculator();
			misfiredScheduledStopCalculator
				.SetNextStep(scheduledStartTimeCalculator)
				.SetNextStep(defaultTimeCalculator)
				.SetNextStep(scheduledStopTimeCalculator)
				.SetNextStep(transitionTimeCalculator)
				.SetNextStep(timerTimeCalculator);
			TimeCalculator = misfiredScheduledStopCalculator;
		}

		#endregion

		#region Properties: Private

		private BaseCampaignTimeCalculator TimeCalculator {
			get; set;
		}

		#endregion

		#region Properties: Public

		private DateTime _currentTime;
		/// <summary>
		/// Defines current time.
		/// Returns value when it was set before, and otherwise now time in UTC.
		/// </summary>
		public DateTime CurrentTime {
			get {
				return _currentTime == default(DateTime)
					? DateTime.UtcNow
					: _currentTime;
			}
			set {
				_currentTime = value;
			}
		}

		private TimeSpan _userTimeZoneOffset;
		/// <summary>
		/// Defines current user time zone offset.
		/// Returns value when it was set before,
		/// and otherwise time zone offset in <see cref="UserConnection.CurrentUser"/>
		/// </summary>
		public TimeSpan UserTimeZoneOffset {
			get {
				return _userTimeZoneOffset == default(TimeSpan)
					? _userConnection.CurrentUser.GetTimeZoneOffset()
					: _userTimeZoneOffset;
			}
			set {
				_userTimeZoneOffset = value;
			}
		}

		#endregion

		#region Methods: Private

		private Guid GetCampaignSchemaUid(Guid campaignId) {
			var schemaUidSelect = new Select(_userConnection)
				.Column("CampaignSchemaUId")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			schemaUidSelect.SpecifyNoLockHints();
			var schemaUid = schemaUidSelect.ExecuteScalar<Guid>();
			return schemaUid;
		}

		private CampaignScheduledTimeParameters GetScheduledParameters(Guid campaignId) {
			var scheduledParametersContainer = new CampaignScheduledTimeParameters();
			var campaignSelect = new Select(_userConnection)
				.Column("ScheduledStartDate")
				.Column("ScheduledStopDate")
				.Column("ScheduledStartModeId")
				.Column("ScheduledStopModeId")
				.Column("CampaignStatusId")
				.Column("StartDate")
				.Column("PrevExecutedOn")
				.From("Campaign")
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Select;
			campaignSelect.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = campaignSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						scheduledParametersContainer.ScheduledStartDate
							= reader.GetColumnValue<DateTime>("ScheduledStartDate");
						scheduledParametersContainer.ScheduledStopDate
							= reader.GetColumnValue<DateTime>("ScheduledStopDate");
						scheduledParametersContainer.ScheduledStartModeId
							= reader.GetColumnValue<Guid>("ScheduledStartModeId");
						scheduledParametersContainer.ScheduledStopModeId
							= reader.GetColumnValue<Guid>("ScheduledStopModeId");
						scheduledParametersContainer.CampaignStatusId
							= reader.GetColumnValue<Guid>("CampaignStatusId");
						scheduledParametersContainer.StartDate
							= reader.GetColumnValue<DateTime>("StartDate");
						scheduledParametersContainer.PrevExecutedOn
							= reader.GetColumnValue<DateTime>("PrevExecutedOn");
					}
				}
			}
			return scheduledParametersContainer;
		}

		private IEnumerable<CampaignSchemaElement> GetMisfiredTimedElements(IEnumerable<CampaignSchemaElement> elements,
				DateTime startTime, DateTime endTime) {
			foreach (var element in elements) {
				var nextFireTime = element.GetFireTime();
				if (nextFireTime.HasValue) {
					var executionTime = new DateTime(nextFireTime.Value.Ticks);
					if (executionTime > startTime && executionTime <= endTime) {
						yield return element;
					}
				}
			}
		}

		private IEnumerable<CampaignSchemaElement> GetMisfiredTimedElements(CoreCampaignSchema schema,
				DateTime startTime, DateTime endTime) {
			var transitionElements = schema.FlowElements.OfType<ConditionalSequenceFlowElement>();
			var timerElements = schema.FlowElements.OfType<CampaignTimerElement>();
			return GetMisfiredTimedElements(transitionElements.Union<CampaignSchemaElement>(timerElements),
				startTime, endTime);
		}

		private TimeSpan RoundToMinutes(TimeSpan time) {
			return new TimeSpan(time.Days, time.Hours, time.Minutes, 0, 0);
		}

		private DateTime RoundToSeconds(DateTime time) {
			return time.AddTicks(-(time.Ticks % TimeSpan.TicksPerSecond));
		}

		private void DefinesTimeParameters(CoreCampaignSchema schema, DateTime? previousScheduledFireTime,
				CampaignScheduledTimeParameters scheduledParameters) {
			scheduledParameters.PreviousFireTime = previousScheduledFireTime
				?? (scheduledParameters.PrevExecutedOn != default(DateTime)
					? scheduledParameters.PrevExecutedOn
					: (DateTime?)null);
			scheduledParameters.CurrentTime = CurrentTime;
			scheduledParameters.BenchmarkTime = scheduledParameters.PreviousFireTime ?? scheduledParameters.CurrentTime;
			schema.CampaignConfiguration["ScheduledUtcFireTime"] = RoundToSeconds(scheduledParameters.BenchmarkTime);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns next fire time for campaign.
		/// When <paramref name="previousScheduledFireTime"/> is null then used
		/// <see cref="DateTime.UtcNow"/> as benchmark point for calculation.
		/// </summary>
		/// <param name="campaignId">Campaign identifier.</param>
		/// <param name="useCurrentUserTimezone">Flag that indicates add current user
		/// timezone offset to next campaign scheduled time(in UTC) or not.</param>
		/// <param name="previousScheduledFireTime">Time of the previous campaign run.
		/// It can be null when need calculate next fire time relatively current time.</param>
		/// <returns>Returns campaign's next run time.</returns>
		public DateTime GetCampaignNextFireTime(Guid campaignId, bool useCurrentUserTimezone,
				DateTime? previousScheduledFireTime = null) {
			var schemaUid = GetCampaignSchemaUid(campaignId);
			var benchmarkTime = previousScheduledFireTime ?? new DateTime(CurrentTime.Year, CurrentTime.Month,
				CurrentTime.Day, CurrentTime.Hour, CurrentTime.Minute, 0, DateTimeKind.Utc);
			var schemaManager = (CampaignSchemaManager)_userConnection.GetSchemaManager("CampaignSchemaManager");
			CoreCampaignSchema campaignSchema = schemaManager.GetSchemaInstance(schemaUid);
			var scheduledUtcFireTime = GetNextFireTime(campaignSchema, benchmarkTime);
			if (useCurrentUserTimezone) {
				return scheduledUtcFireTime.Time.AddMinutes(UserTimeZoneOffset.TotalMinutes);
			}
			return scheduledUtcFireTime.Time;
		}

		/// <summary>
		/// Returns next fire time for campaign's schema.
		/// </summary>
		/// <param name="schema">Campaign schema.
		/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
		/// <param name="previousScheduledFireTime">Time of the previous campaign run.
		/// It can be null when need calculate next fire time relatively current time.</param>
		/// <returns>Returns instance of <see cref="CampaignFireTimeConfig"/> that contains
		/// all needed information for schedule next campaign job.</returns>
		public CampaignFireTimeConfig GetNextFireTime(CoreCampaignSchema schema,
				DateTime? previousScheduledFireTime) {
			var scheduledParameters = GetScheduledParameters(schema.EntityId);
			DefinesTimeParameters(schema, previousScheduledFireTime, scheduledParameters);
			var resultConfig = TimeCalculator.Calculate(schema, scheduledParameters, new CampaignFireTimeConfig());
			resultConfig.Time = DateTime.SpecifyKind(RoundToSeconds(resultConfig.Time), DateTimeKind.Utc);
			return resultConfig;
		}

		/// <summary>
		/// Returns config <see cref="CampaignExecutionLatenessConfig"/>, which describes lateness parameters.
		/// Lateness calculates relatively <paramref name="scheduledTime"/>.
		/// </summary>
		/// <param name="schema">Campaign's schema instance of
		/// <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
		/// <param name="scheduledTime">Time relatively this need calculate lateness config.</param>
		/// <returns>Returns instance <see cref="CampaignExecutionLatenessConfig"/>.</returns>
		public CampaignExecutionLatenessConfig GetLatenessConfig(CoreCampaignSchema schema, DateTime scheduledTime) {
			schema.CampaignConfiguration["ScheduledUtcFireTime"] = RoundToSeconds(scheduledTime);
			var latenessTime = RoundToMinutes(CurrentTime - scheduledTime);
			var criticalLateness = schema.CriticalExecutionLateness;
			var latenessConfig = new CampaignExecutionLatenessConfig {
				MisfiredTimeConditionElements = new List<CampaignSchemaElement>(),
				LatenessTime = latenessTime,
				Lateness = CampaignExecutionLateness.NoMisfire
			};
			if (latenessTime.TotalMinutes <= 0) {
				return latenessConfig;
			}
			var misfiredTimedElements = GetMisfiredTimedElements(schema, scheduledTime, CurrentTime);
			latenessConfig.MisfiredTimeConditionElements = misfiredTimedElements;
			if (latenessTime.TotalMinutes <= criticalLateness) {
				latenessConfig.Lateness = !misfiredTimedElements.Any()
					? CampaignExecutionLateness.NoMisfire
					: CampaignExecutionLateness.MisfiredTimeConditionElements;
			} else {
				latenessConfig.Lateness = !misfiredTimedElements.Any()
					? CampaignExecutionLateness.Critical
					: CampaignExecutionLateness.CriticalAndMisfiredTimeConditionElements;
			}
			return latenessConfig;
		}

		#endregion

	}

	#endregion

}

