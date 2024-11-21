namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign.Interfaces;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: ConditionalSequenceFlowElement

	[DesignModeProperty(Name = "FilterId",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = FilterIdPropertyName)]
	[DesignModeProperty(Name = "Filter",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = FilterPropertyName)]
	[DesignModeProperty(Name = "DelayUnit",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = DelayUnitPropertyName)]
	[DesignModeProperty(Name = "DelayInDays",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = DelayInDaysPropertyName)]
	[DesignModeProperty(Name = "StartTime",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = StartTimePropertyName)]
	[DesignModeProperty(Name = "IsDelayedStart",
		UsageType = DesignModeUsageType.NotVisible, MetaPropertyName = IsDelayedStartPropertyName)]
	[DesignModeProperty(Name = "HasFilter",
		UsageType = DesignModeUsageType.Available, MetaPropertyName = HasFilterPropertyName)]
	[DesignModeProperty(Name = "HasStartTime",
		UsageType = DesignModeUsageType.Available, MetaPropertyName = HasStartTimePropertyName)]
	[DesignModeProperty(Name = "IsFilterChanged",
		UsageType = DesignModeUsageType.Available, MetaPropertyName = IsFilterChangedPropertyName)]
	[DesignModeProperty(Name = "FilterEntitySchemaId",
		UsageType = DesignModeUsageType.Available, MetaPropertyName = FilterEntitySchemaIdPropertyName)]
	public class ConditionalSequenceFlowElement : SequenceFlowElement, IDelayedExecutionCondition,
		IScheduledExecutionCondition
	{

		#region Constants: Private

		private const string FilterIdPropertyName = "FilterId";
		private const string FilterPropertyName = "Filter";
		private const string DelayUnitPropertyName = "DelayUnit";
		private const string DelayInDaysPropertyName = "DelayInDays";
		private const string StartTimePropertyName = "StartTime";
		private const string IsDelayedStartPropertyName = "IsDelayedStart";
		private const string HasFilterPropertyName = "HasFilter";
		private const string HasStartTimePropertyName = "HasStartTime";
		private const string IsFilterChangedPropertyName = "IsFilterChanged";
		private const string FilterEntitySchemaIdPropertyName = "FilterEntitySchemaId";
		private const string DateTimeFormat = "yyyy-MM-dd HH:mm";
		private readonly Guid ContactSchemaUId = new Guid("16BE3651-8FE2-4159-8DD0-A803D4683DD3");

		#endregion

		#region Constants: Private

		protected const int ConditionalFlowPriority = 1;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Identifier of element action.
		/// </summary>
		protected override Guid Action => CampaignConsts.CampaignLogTypeConditionFlow;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Default ctor
		/// </summary>
		public ConditionalSequenceFlowElement() {
			HasFilter = true;
			HasStartTime = true;
		}

		/// <summary>
		/// Constructor of the clone.
		/// </summary>
		/// <param name="source">Instance of <see cref="ConditionalSequenceFlowElement"/>.</param>
		public ConditionalSequenceFlowElement(ConditionalSequenceFlowElement source)
			: this(source, null, null) {
		}

		/// <summary>
		/// Constructor of the copy.
		/// </summary>
		/// <param name="source">Instance of <see cref="ConditionalSequenceFlowElement"/>.</param>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		public ConditionalSequenceFlowElement(ConditionalSequenceFlowElement source,
				Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema)
					: base(source, dictToRebind, parentSchema) {
			FilterId = source.FilterId;
			DelayInDays = source.DelayInDays;
			DelayUnit = source.DelayUnit;
			HasStartTime = source.HasStartTime;
			StartTime = source.StartTime;
			IsDelayedStart = source.IsDelayedStart;
			HasFilter = source.HasFilter;
			IsFilterChanged = source.IsFilterChanged;
			FilterEntitySchemaId = source.FilterEntitySchemaId;
			Filter = source.Filter;
		}

		#endregion

		#region Properties: Public
		
		/// <summary>
		/// Delay unit for part of query with time condition.
		/// </summary>
		public virtual ConditionalSequenceFlowDelayUnit DelayUnit { get; set; }

		/// <summary>
		/// The Guid of the condition from ContactFolder table.
		/// </summary>
		[MetaTypeProperty("{C001BAA1-1187-4FFF-B949-3459936B5FC8}")]
		public virtual Guid FilterId { get; set; }

		/// <summary>
		/// Value of Filter json to save in ContactFolder SearchData property.
		/// </summary>
		[MetaTypeProperty("{925C8CA1-A711-43C5-9667-F36732B745A7}")]
		public virtual string Filter { get; set; }

		/// <summary>
		/// Delay in days before the conditional flow execution.
		/// </summary>
		[MetaTypeProperty("{8B0F7C84-BB45-45E8-A466-7AC3AE78FBFA}")]
		public virtual int DelayInDays { get; set; }

		/// <summary>
		/// Flag to indicate that tarnsition has start time specified or not.
		/// </summary>
		[MetaTypeProperty("{45EB5D89-465B-4791-8401-B90280998BF1}")]
		public virtual bool HasStartTime { get; set; }

		/// <summary>
		/// The start time of the conditional flow. Treated as local time from <see cref="ParentSchema"/> time zone.
		/// </summary>
		[MetaTypeProperty("{0BF8F07A-4DA7-46AF-876F-4A37F1329A82}")]
		public virtual DateTime StartTime { get; set; }

		/// <summary>
		/// Defines if transition execution is delayed.
		/// </summary>
		[MetaTypeProperty("{82B43134-C7D3-4C76-A16D-96118F65E467}")]
		public virtual bool IsDelayedStart { get; set; }

		/// <summary>
		/// Is filter used in generating query.
		/// </summary>
		[MetaTypeProperty("{CC960AC7-4F3F-4964-8262-1D7FA85F3254}")]
		public virtual bool HasFilter { get; set; }

		/// <summary>
		/// Is filter used in generating query.
		/// </summary>
		[MetaTypeProperty("{A30C9946-9E6B-4CE4-8C85-E956E4D2B90B}")]
		public virtual bool IsFilterChanged { get; set; }

		/// <summary>
		/// Entity schema identifier to filter campaign participants.
		/// </summary>
		[MetaTypeProperty("{557347E3-EDE7-481B-921B-7B2EAD2E7AFF}")]
		public virtual Guid FilterEntitySchemaId { get; set; }

		/// <summary>
		/// Priority of the transition.
		/// </summary>
		public override int Priority {
			get => HasFilterConditions() ? ConditionalFlowPriority : base.Priority;
			set => base.Priority = value;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// The overriden metadata reader.
		/// </summary>
		protected override void ApplyMetaDataValue(DataReader reader) {
			base.ApplyMetaDataValue(reader);
			switch (reader.CurrentName) {
				case FilterIdPropertyName:
					FilterId = reader.GetGuidValue();
					break;
				case FilterPropertyName:
					Filter = reader.GetValue<string>();
					break;
				case DelayUnitPropertyName:
					DelayUnit = reader.GetEnumValue<ConditionalSequenceFlowDelayUnit>();
					break;
				case DelayInDaysPropertyName:
					DelayInDays = reader.GetValue<int>();
					break;
				case StartTimePropertyName:
					var dateString = reader.GetValue<string>();
					StartTime = DateTime.ParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture);
					break;
				case IsDelayedStartPropertyName:
					IsDelayedStart = reader.GetBoolValue();
					break;
				case HasFilterPropertyName:
					HasFilter = reader.GetBoolValue();
					break;
				case HasStartTimePropertyName:
					HasStartTime = reader.GetBoolValue();
					break;
				case IsFilterChangedPropertyName:
					IsFilterChanged = reader.GetBoolValue();
					break;
				case FilterEntitySchemaIdPropertyName:
					FilterEntitySchemaId = reader.GetGuidValue();
					break;
				default:
					break;
			}
		}

		private bool HasFilterConditions() {
			if (string.IsNullOrWhiteSpace(Filter)) {
				return false;
			}
			var filterObject = Common.Json.Json.Deserialize<Nui.ServiceModel.DataContract.Filters>(Filter);
			var hasConditions = (filterObject?.Items?.Count ?? 0) > 0;
			return HasFilter && hasConditions;
		}

		private TimeSpan? GetNextFireTime() {
			if (!ScheduledUtcFireTime.HasValue) {
				return null;
			}
			var scheduledFireTime = ScheduledUtcFireTime.Value;
			var startTimeWithScheduledDate = scheduledFireTime.Date.AddTicks(StartTime.TimeOfDay.Ticks);
			if (!ParentSchema.TimeZoneOffset.Equals(TimeZoneInfo.Utc)) {
				startTimeWithScheduledDate = new DateTime(startTimeWithScheduledDate.Ticks, DateTimeKind.Unspecified);
			}
			var elementFireTimeUtc = TimeZoneInfo.ConvertTimeToUtc(startTimeWithScheduledDate,
				ParentSchema.TimeZoneOffset).TimeOfDay;
			var elementTimeMinutes = (int)elementFireTimeUtc.TotalMinutes;
			var scheduledFireTimeMinutes = (int)scheduledFireTime.TimeOfDay.TotalMinutes;
			if (elementTimeMinutes <= scheduledFireTimeMinutes) {
				elementFireTimeUtc = elementFireTimeUtc.Add(TimeSpan.FromDays(1));
			}
			var elementExecutionDate = scheduledFireTime.Date.AddMinutes(elementFireTimeUtc.TotalMinutes);
			return TimeSpan.FromTicks(elementExecutionDate.Ticks);
		}

		/// <summary>
		/// Returns entity schema name and contact column path due to selected audience schema.
		/// </summary>
		private (string schemaName, string contactColumnPath, Guid schemaUId) GetFilterEntitySchemaInfo(
				UserConnection userConnection) {
			if (FilterEntitySchemaId.IsEmpty()) {
				return ("Contact", "Id", ContactSchemaUId);
			}
			var select = new Select(userConnection)
				.Column("ss", "Name")
				.Column("cse", "EntityObjectId")
				.Column("cse", "ContactColumn")
				.From("CampaignSignalEntity").As("cse")
				.InnerJoin("SysSchema").As("ss").On("cse", "EntityObjectId").IsEqual("ss", "UId")
				.Where("cse", "Id").IsEqual(Column.Parameter(FilterEntitySchemaId)) as Select;
			select.ExecuteSingleRecord(reader => (reader.GetColumnValue<string>("Name"),
				reader.GetColumnValue<string>("ContactColumn"), reader.GetColumnValue<Guid>("EntityObjectId")),
				out (string, string, Guid) audienceSchemaInfo);
			return audienceSchemaInfo;
		}

		/// <summary>
		/// Initializes conditional transition flow element properties.
		/// </summary>
		protected void InitializeConditionalTransitionFlowElement(ConditionalTransitionFlowElement element) {
			element.IsDelayedStart = IsDelayedStart;
			element.DelayInDays = DelayInDays;
			element.DelayUnit = DelayUnit;
			element.FilterId = FilterId;
			element.Filter = Filter;
			element.HasFilter = HasFilter;
		}

		/// <summary>
		/// Initializes entity schema and contact column path due to selected audience schema.
		/// </summary>
		protected void InitializeAudienceSchemaInfo(ConditionalTransitionFlowElement executableElement,
				UserConnection userConnection) {
			var audienceEntitySchemaInfo = GetFilterEntitySchemaInfo(userConnection);
			executableElement.FilterEntitySchemaUId = audienceEntitySchemaInfo.schemaUId;
			executableElement.FilterEntityContactPath = audienceEntitySchemaInfo.contactColumnPath;
			executableElement.FilterEntitySchemaName = audienceEntitySchemaInfo.schemaName;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines if element is delayed at any number of days, hours etc. that are greater than 0.
		/// </summary>
		/// <returns>True if execution is delayed.</returns>
		public bool HasDelay() {
			return IsDelayedStart && DelayInDays > 0;
		}

		/// <summary>
		/// Defines if element can be processed at a specified time.
		/// </summary>
		/// <param name="time"><see cref="TimeSpan"/> to check. Contains the whole date and time by UTC.</param>
		/// <returns>True if can be processed at <paramref name="time"/>.</returns>
		public virtual bool CanProcessAt(TimeSpan time) {
			var timeToCheck = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(time.Ticks), ParentSchema.TimeZoneOffset);
			return !IsDelayedStart
				|| !HasStartTime
				|| (HasStartTime && StartTime.TimeOfDay.Hours == timeToCheck.TimeOfDay.Hours
					&& StartTime.TimeOfDay.Minutes == timeToCheck.TimeOfDay.Minutes);
		}

		/// <summary>
		/// Writes meta data values.
		/// </summary>
		/// <param name="writer">Instance of the <see cref="DataWriter"/> type.</param>
		public override void WriteMetaData(DataWriter writer) {
			base.WriteMetaData(writer);
			writer.WriteValue(FilterIdPropertyName, FilterId, Guid.Empty);
			writer.WriteValue(DelayUnitPropertyName, typeof(ConditionalSequenceFlowDelayUnit), DelayUnit,
				ConditionalSequenceFlowDelayUnit.Days);
			writer.WriteValue(DelayInDaysPropertyName, typeof(int), DelayInDays, 0);
			writer.WriteValue(StartTimePropertyName, typeof(string), StartTime.ToString(DateTimeFormat), string.Empty);
			writer.WriteValue(IsDelayedStartPropertyName, typeof(bool), IsDelayedStart, false);
			writer.WriteValue(HasFilterPropertyName, HasFilter, true);
			writer.WriteValue(HasStartTimePropertyName, HasStartTime, true);
			writer.WriteValue(FilterPropertyName, Filter, string.Empty);
			writer.WriteValue(FilterEntitySchemaIdPropertyName, FilterEntitySchemaId, Guid.Empty);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <returns>Cloned instance of the ConditionalSequenceFlowElement.</returns>
		public override object Clone() {
			return new ConditionalSequenceFlowElement(this);
		}

		/// <summary>
		/// Creates a new instance that is a copy of the current instance.
		/// </summary>
		/// <param name="dictToRebind">Dictionary to rebind schema elements' ids.</param>
		/// <param name="parentSchema">Parent campaign schema.</param>
		/// <returns>Copied instance of the ConditionalSequenceFlowElement.</returns>
		public override object Copy(Dictionary<Guid, Guid> dictToRebind, Core.Campaign.CampaignSchema parentSchema) {
			return new ConditionalSequenceFlowElement(this, dictToRebind, parentSchema);
		}

		/// <summary>
		/// Returns fire time for transition
		/// </summary>
		/// <returns>Time for transition execution. Returns null when property IsDelayedStart is false.
		/// Returns time when property IsDelayedStart is true.</returns>
		public override TimeSpan? GetFireTime() {
			return IsDelayedStart && HasStartTime ? GetNextFireTime() : null;
		}

		/// <summary>
		/// Creates executable instance of conditional transition.
		/// </summary>
		public override ProcessFlowElement CreateProcessFlowElement(UserConnection userConnection) {
			var executableElement = new ConditionalTransitionFlowElement {
				UserConnection = userConnection
			};
			InitializeCampaignProcessFlowElement(executableElement);
			InitializeCampaignTransitionFlowElement(executableElement);
			InitializeConditionalTransitionFlowElement(executableElement);
			InitializeAudienceSchemaInfo(executableElement, userConnection);
			return executableElement;
		}

		#endregion

	}

	#endregion

}

