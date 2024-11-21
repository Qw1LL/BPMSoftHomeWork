namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Quartz;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.Process;
	using global::Common.Logging;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;

	#region Class: CampaignTimerElement

	/// <summary>
	/// Timer schema element in campaign.
	/// </summary>
	[MetaType("{467B53F4-412C-43E8-AEFF-ADD959D76314}")]
	[DesignModeClass(DefNamePrefix = "CampaignTimerElement", DefCaptionPrefix = "")]
	[DesignModeProperty(Name = "CronExpression", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = CronExpressionPropertyName)]
	[DesignModeProperty(Name = "ExpressionType", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = ExpressionTypePropertyName)]
	[DesignModeProperty(Name = "StartDateTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = StartDateTimePropertyName)]
	[DesignModeProperty(Name = "EndDateTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = EndDateTimePropertyName)]
	[DesignModeProperty(Name = "TimeZoneOffset", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = TimeZoneOffsetPropertyName)]
	[DesignModeProperty(Name = "PeriodStartTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = PeriodStartTimePropertyName)]
	[DesignModeProperty(Name = "PeriodEndTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = PeriodEndTimePropertyName)]
	[DesignModeProperty(Name = "ExactTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = ExactTimePropertyName)]
	[DesignModeProperty(Name = "UseExactTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = UseExactTimePropertyName)]
	[DesignModeProperty(Name = "UseStartDateTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = UseStartDateTimePropertyName)]
	[DesignModeProperty(Name = "UseEndDateTime", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = UseEndDateTimePropertyName)]
	[DesignModeProperty(Name = "UseCustomTimeZone", UsageType = DesignModeUsageType.Available,
		MetaPropertyName = UseCustomTimeZonePropertyName)]
	public class CampaignTimerElement : CampaignSchemaElement, IScheduledExecutionCondition
	{

		#region Constants: Private

		private const string CronExpressionPropertyName = "CronExpression";
		private const string ExpressionTypePropertyName = "ExpressionType";
		private const string StartDateTimePropertyName = "StartDateTime";
		private const string EndDateTimePropertyName = "EndDateTime";
		private const string TimeZoneOffsetPropertyName = "TimeZoneOffset";
		private const string PeriodStartTimePropertyName = "PeriodStartTime";
		private const string PeriodEndTimePropertyName = "PeriodEndTime";
		private const string ExactTimePropertyName = "ExactTime";
		private const string UseExactTimePropertyName = "UseExactTime";
		private const string UseStartDateTimePropertyName = "UseStartDateTime";
		private const string UseEndDateTimePropertyName = "UseEndDateTime";
		private const string UseCustomTimeZonePropertyName = "UseCustomTimeZone";
		private const string DefaultCronExpression = "0 * * ? * * *";
		private const string DefaultDateTimeValue = "0001-01-01 00:00";
		private const string DateTimeFormat = "yyyy-MM-dd HH:mm";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default constructor for <see cref="CampaignTimerElement"/>.
		/// </summary>
		public CampaignTimerElement() {
			ElementType = CampaignSchemaElementType.AsyncTask | CampaignSchemaElementType.Sessioned;
		}

		/// <summary>
		/// Constructor for <see cref="CampaignTimerElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignTimerElement"/>.</param>
		public CampaignTimerElement(CampaignTimerElement source)
				: this(source, null, null) {
		}

		/// <summary>
		/// Constructor for <see cref="CampaignTimerElement"/>.
		/// </summary>
		/// <param name="source">Instance of <see cref="CampaignTimerElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public CampaignTimerElement(CampaignTimerElement source, Dictionary<Guid, Guid> dictToRebind,
				Core.Campaign.CampaignSchema parentSchema) : base(source, dictToRebind, parentSchema) {
			ExpressionType = source.ExpressionType;
			StartDateTime = source.StartDateTime;
			UseStartDateTime = source.UseStartDateTime;
			EndDateTime = source.EndDateTime;
			UseEndDateTime = source.UseEndDateTime;
			PeriodStartTime = source.PeriodStartTime;
			PeriodEndTime = source.PeriodEndTime;
			ExactTime = source.ExactTime;
			UseExactTime = source.UseExactTime;
			CronExpression = source.CronExpression?.Clone() as CronExpression
				?? new CronExpression(DefaultCronExpression);
			UseCustomTimeZone = source.UseCustomTimeZone;
			TimeZoneCode = source.TimeZoneCode;
		}

		#endregion

		#region Properties: Private

		private TimeZoneInfo _timeZoneOffset;
		private TimeZoneInfo CalculatedTimeZone => _timeZoneOffset ?? (_timeZoneOffset = GetTimeZoneOffset());
		private DateTime PeriodStartTimeUtc => TimeZoneInfo.ConvertTimeToUtc(PeriodStartTime, CalculatedTimeZone);
		private DateTime PeriodEndTimeUtc => TimeZoneInfo.ConvertTimeToUtc(PeriodEndTime, CalculatedTimeZone);
		private DateTime ExactTimeUtc {
			get {
				var executionDate = ScheduledUtcFireTime ?? DateTime.UtcNow;
				var currentExactTime = new DateTime(executionDate.Year, executionDate.Month, executionDate.Day,
					ExactTime.Hour, ExactTime.Minute, 0, ExactTime.Kind);
				return TimeZoneInfo.ConvertTimeToUtc(currentExactTime, CalculatedTimeZone);
			}
		}
		private CronExpression SafeCronExpression => CronExpression ?? new CronExpression(DefaultCronExpression);

		/// <summary>
		/// Gets or sets the campaign logger. Instance of <see cref="ILog"/>.
		/// </summary>
		private ILog _logger;
		private ILog Logger {
			get => _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));
			set => _logger = value;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeTimer;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Cron expression.
		/// </summary>
		[MetaTypeProperty("{870278DA-E89B-4999-A0D0-8A1D964592CF}")]
		public CronExpression CronExpression { get; set; }

		/// <summary>
		/// Type of expression.
		/// </summary>
		[MetaTypeProperty("{D8FFF64C-C80D-4AAA-B7AE-D5106C1E57CB}")]
		public StartTimerEventExpresionType ExpressionType { get; set; }

		/// <summary>
		/// The beginning of timers range. The <see cref="DateTime"/> value for the CRON initial point.
		/// </summary>
		[MetaTypeProperty("{4A0B1884-5E44-461B-B757-508A4006C964}")]
		public DateTime StartDateTime { get; set; }

		/// <summary>
		/// The end of timers range. The <see cref="DateTime"/> value.
		/// </summary>
		[MetaTypeProperty("{246F5B06-B4BD-47F8-9903-DC2C9EC48346}")]
		public DateTime EndDateTime { get; set; }

		/// <summary>
		/// The time zone code for current timer.
		/// </summary>
		[MetaTypeProperty("{7F491448-3EC2-4098-AD24-D4A10436837B}")]
		public string TimeZoneCode { get; set; }

		/// <summary>
		/// The time zone offset of the the job scheduling.
		/// </summary>
		public TimeZoneInfo TimeZoneOffset {
			get => GetTimeZoneByCode(TimeZoneCode);
			set {
				_timeZoneOffset = value;
				TimeZoneCode = value?.Id;
			}
		}

		/// <summary>
		/// Defines if custom <see cref="TimeZoneOffset"/> value is used for the filtering rules.
		/// </summary>
		[MetaTypeProperty("{7E424733-B230-43F1-A13C-1813A44FC07F}")]
		public bool UseCustomTimeZone { get; set; }

		/// <summary>
		/// If <see cref="UseExactTime"/> == false then defines part of first two digits of the CRON expression.
		/// 0 x-59 x-18 * * * *.
		/// </summary>
		[MetaTypeProperty("{A6E1B582-FF56-4B3B-8945-0B3336405CD6}")]
		public DateTime PeriodStartTime { get; set; }

		/// <summary>
		/// If <see cref="UseExactTime"/> == false then defines part of first two digits of the CRON expression.
		/// 0 0-x 9-x * * * *.
		/// </summary>
		[MetaTypeProperty("{CAAAD178-92F7-4108-8ED1-80E2341FDEFC}")]
		public DateTime PeriodEndTime { get; set; }

		/// <summary>
		/// If <see cref="UseExactTime"/> == true then defines first two digits of the exact CRON expression.
		/// 0 x x 1-31 1 1 *.
		/// </summary>
		[MetaTypeProperty("{EC87ABB6-E14D-4ABD-B6AB-7ABE200BB1E2}")]
		public DateTime ExactTime { get; set; }

		/// <summary>
		/// Defines if <see cref="ExactTime"/> value is used or the period <see cref="PeriodStartTime"/> and
		/// <see cref="PeriodEndTime"/>.
		/// </summary>
		[MetaTypeProperty("{B7AA6B62-B728-4E84-81CD-FEBF0238A8D3}")]
		public bool UseExactTime { get; set; }

		/// <summary>
		/// Defines if <see cref="StartDateTime"/> value is used for the filtering rules.
		/// </summary>
		[MetaTypeProperty("{766435D0-D398-43FB-9BED-A7FB62527717}")]
		public bool UseStartDateTime { get; set; }

		/// <summary>
		/// Defines if <see cref="EndDateTime"/> value is used for the filtering rules.
		/// </summary>
		[MetaTypeProperty("{C58D089F-B9CC-49DC-B909-26916B146F55}")]
		public bool UseEndDateTime { get; set; }

		/// <summary>
		/// Returns <see cref="StartDateTime"/> in UTC.
		/// </summary>
		public DateTime StartDateTimeUtc => TimeZoneInfo.ConvertTimeToUtc(StartDateTime, CalculatedTimeZone);

		/// <summary>
		/// Returns <see cref="EndDateTime"/> in UTC.
		/// </summary>
		public DateTime EndDateTimeUtc => TimeZoneInfo.ConvertTimeToUtc(EndDateTime, CalculatedTimeZone);

		#endregion

		#region Methods: Private

		/// <summary>
		/// Generates new instance of the <see cref="CronExpression"/> class that contains redefined tokens.
		/// </summary>
		/// <param name="sourceCron">Source cron expression.</param>
		/// <param name="newTokens">The array of new tokens from the beginning (seconds, minutes, hours, ...).
		/// If you need to skip some token, just use the <see cref="string.Empty"/> value.</param>
		/// <returns>An instance of the <see cref="CronExpression"/> class.</returns>
		private CronExpression RedefineTokens(CronExpression sourceCron, params string[] newTokens) {
			if (newTokens == null || newTokens.Length == 0) {
				return sourceCron.Clone() as CronExpression;
			}
			var tokens = sourceCron.CronExpressionString.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
			for (int i = 0; i < newTokens.Length && i < tokens.Count; i++) {
				if (string.IsNullOrEmpty(newTokens[i])) {
					continue;
				}
				tokens[i] = newTokens[i];
			}
			var newCronString = tokens.Aggregate((x, y) => $"{x} {y}");
			return new CronExpression(newCronString);
		}

		/// <summary>
		/// Returns true if hours and minutes are equal.
		/// </summary>
		private bool AreHoursAndMinutesEqual(DateTime firstDate, DateTime secondDate) {
			return firstDate.Hour == secondDate.Hour && firstDate.Minute == secondDate.Minute;
		}

		/// <summary>
		/// Returns true if year, month, day, hours and minutes are equal.
		/// </summary>
		private bool AreDatesAndTimeEqual(DateTime firstDate, DateTime secondDate) {
			return firstDate.Date == secondDate.Date && AreHoursAndMinutesEqual(firstDate, secondDate);
		}

		/// <summary>
		/// Returns <see cref="T:System.TimeZoneInfo" /> object for current timer time zone code.
		/// </summary>
		/// <param name="timeZoneCode">Current timer time zone code.</param>
		/// <returns></returns>
		private TimeZoneInfo GetTimeZoneByCode(string timeZoneCode) {
			try {
				return TimeZoneUtilities.GetTimeZoneInfo(timeZoneCode);
			} catch (TimeZoneNotFoundException ex) {
				Logger.Error($"Time zone with code '{timeZoneCode}' is not recognized " +
					$"for campaign timer element with UId = '{UId}'", ex);
				return CalculatedTimeZone;
			}
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case CronExpressionPropertyName:
					var cronString = reader.GetValue<string>();
					if (string.IsNullOrWhiteSpace(cronString)) {
						cronString = DefaultCronExpression;
					}
					CronExpression = new CronExpression(cronString);
					break;
				case ExpressionTypePropertyName:
					ExpressionType = reader.GetValue<StartTimerEventExpresionType>();
					break;
				case StartDateTimePropertyName:
					var startDateString = reader.GetValue<string>();
					StartDateTime = DateTime.ParseExact(startDateString, DateTimeFormat, CultureInfo.InvariantCulture);
					break;
				case EndDateTimePropertyName:
					var endDateString = reader.GetValue<string>();
					EndDateTime = DateTime.ParseExact(endDateString, DateTimeFormat, CultureInfo.InvariantCulture);
					break;
				case TimeZoneOffsetPropertyName:
					TimeZoneCode = reader.GetValue<string>();
					break;
				case PeriodStartTimePropertyName:
					var periodStartDateString = reader.GetValue<string>();
					PeriodStartTime = DateTime.ParseExact(periodStartDateString, DateTimeFormat,
						CultureInfo.InvariantCulture);
					break;
				case PeriodEndTimePropertyName:
					var periodEndDateString = reader.GetValue<string>();
					PeriodEndTime = DateTime.ParseExact(periodEndDateString, DateTimeFormat,
						CultureInfo.InvariantCulture);
					break;
				case ExactTimePropertyName:
					var exactTimeString = reader.GetValue<string>();
					ExactTime = DateTime.ParseExact(exactTimeString, DateTimeFormat, CultureInfo.InvariantCulture);
					break;
				case UseExactTimePropertyName:
					UseExactTime = reader.GetBoolValue();
					break;
				case UseStartDateTimePropertyName:
					UseStartDateTime = reader.GetBoolValue();
					break;
				case UseEndDateTimePropertyName:
					UseEndDateTime = reader.GetBoolValue();
					break;
				case UseCustomTimeZonePropertyName:
					UseCustomTimeZone = reader.GetBoolValue();
					break;
				default:
					break;
			}
		}

		private TimeZoneInfo GetTimeZoneOffset() {
			return UseCustomTimeZone
				? TimeZoneOffset ?? ParentSchema.TimeZoneOffset
				: ParentSchema.TimeZoneOffset;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(CronExpressionPropertyName, CronExpression?.ToString(), null);
			writer.WriteValue(ExpressionTypePropertyName, typeof(StartTimerEventExpresionType), ExpressionType,
				StartTimerEventExpresionType.Empty);
			writer.WriteValue(UseStartDateTimePropertyName, UseStartDateTime, false);
			writer.WriteValue(StartDateTimePropertyName, StartDateTime.ToString(DateTimeFormat), DefaultDateTimeValue);
			writer.WriteValue(UseEndDateTimePropertyName, UseEndDateTime, false);
			writer.WriteValue(EndDateTimePropertyName, EndDateTime.ToString(DateTimeFormat), DefaultDateTimeValue);
			writer.WriteValue(PeriodStartTimePropertyName, PeriodStartTime.ToString(DateTimeFormat),
				DefaultDateTimeValue);
			writer.WriteValue(PeriodEndTimePropertyName, PeriodEndTime.ToString(DateTimeFormat), DefaultDateTimeValue);
			writer.WriteValue(UseExactTimePropertyName, UseExactTime, false);
			writer.WriteValue(ExactTimePropertyName, ExactTime.ToString(DateTimeFormat), DefaultDateTimeValue);
			writer.WriteValue(TimeZoneOffsetPropertyName, TimeZoneCode, null);
			writer.WriteValue(UseCustomTimeZonePropertyName, UseCustomTimeZone, false);
		}

		/// <summary>
		/// Creates a new instance that is a clone of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the CampaignTimerElement.</returns>
		public override object Clone() {
			return new CampaignTimerElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the CampaignTimerElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new CampaignTimerElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Creates specific ProcessFlowElement instance.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <returns>Instance of <see cref="ProcessFlowElement"/>.</returns>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new CampaignTimerFlowElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			return executableElement;
		}

		/// <summary>
		/// Defines if element can be processed at a specified time at the specified time zone.
		/// </summary>
		/// <param name="time"><see cref="TimeSpan"/> to check. Contains the whole date and time.</param>
		/// <returns><see cref="true"/> if can be processed.</returns>
		public bool CanProcessAt(TimeSpan time) {
			var dateTimeToCheckUtc = new DateTime(time.Ticks, DateTimeKind.Utc).AddSeconds(-time.Seconds);
			if (ExpressionType == StartTimerEventExpresionType.SingleRun) {
				return AreDatesAndTimeEqual(StartDateTimeUtc, dateTimeToCheckUtc);
			}
			var isBeforeStartDate = UseStartDateTime ? dateTimeToCheckUtc < StartDateTimeUtc : false;
			var isAfterEndDate = UseEndDateTime ? dateTimeToCheckUtc > EndDateTimeUtc : false;
			if (isBeforeStartDate || isAfterEndDate) {
				return false;
			}
			if (UseExactTime && !AreHoursAndMinutesEqual(ExactTimeUtc, dateTimeToCheckUtc)) {
				return false;
			}
			if (!UseExactTime) {
				var timeToCheckUtc = new TimeSpan(dateTimeToCheckUtc.Hour, dateTimeToCheckUtc.Minute, 0);
				var periodStartUtc = new TimeSpan(PeriodStartTimeUtc.Hour, PeriodStartTimeUtc.Minute, 0);
				var periodEndUtc = new TimeSpan(PeriodEndTimeUtc.Hour, PeriodEndTimeUtc.Minute, 0);
				var isPeriodAtSingleDay = periodStartUtc < periodEndUtc;
				var isTimeMatchesStartOfPeriod = timeToCheckUtc >= periodStartUtc;
				var isTimeMatchesEndOfPeriod = timeToCheckUtc <= periodEndUtc;
				if (isPeriodAtSingleDay && !(isTimeMatchesStartOfPeriod && isTimeMatchesEndOfPeriod)) {
					return false;
				}
				if (!isPeriodAtSingleDay && !isTimeMatchesStartOfPeriod && !isTimeMatchesEndOfPeriod) {
					return false;
				}
			}
			SafeCronExpression.TimeZone = CalculatedTimeZone;
			return SafeCronExpression.IsSatisfiedBy(dateTimeToCheckUtc);
		}

		/// <summary>
		/// Returns fire time for the scheduler.
		/// </summary>
		/// <returns>UTC Time for timers execution.</returns>
		public override TimeSpan? GetFireTime() {
			if (ExpressionType == StartTimerEventExpresionType.SingleRun) {
				return TimeSpan.FromTicks(StartDateTimeUtc.Ticks);
			}
			if (UseExactTime) {
				var tokenSeconds = string.Empty;
				var tokenMinutes = ExactTime.Minute.ToString();
				var tokenHours = ExactTime.Hour.ToString();
				var redefinedCron = RedefineTokens(SafeCronExpression, tokenSeconds, tokenMinutes, tokenHours);
				redefinedCron.TimeZone = CalculatedTimeZone;
				var nextFireTime = redefinedCron.GetNextValidTimeAfter(ScheduledUtcFireTime.Value);
				if (nextFireTime == null) {
					return null;
				}
				var nextFireTimeUtc = nextFireTime.Value.UtcDateTime;
				var isBeforeStartDate = UseStartDateTime ? nextFireTimeUtc < StartDateTimeUtc : false;
				var isAfterEndDate = UseEndDateTime ? nextFireTimeUtc > EndDateTimeUtc : false;
				if (isBeforeStartDate || isAfterEndDate) {
					return null;
				}
				return TimeSpan.FromTicks(nextFireTimeUtc.Ticks);
			}
			return null;
		}

		#endregion

	}

	#endregion

}

