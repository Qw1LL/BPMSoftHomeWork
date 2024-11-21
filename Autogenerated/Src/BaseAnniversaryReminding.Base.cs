namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Core.Factories;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;

	#region Enum: Days

	public enum Days
	{
		Sun = 1,
		Mon = 2,
		Tue = 3,
		Wed = 4,
		Thu = 5,
		Fri = 6,
		Sat = 7
	}

	#endregion

	#region Class: BaseAnniversaryReminding

	/// <summary>
	/// Base class for generate anniversary remindings.
	/// </summary>
	public abstract class BaseAnniversaryReminding
	{

		#region Constants

		private const int DefaultRemindingLifePeriod = 30;
		private const int DefaultNotifyDaysPeriod = 2;

		#endregion

		#region Fields: Private

		/// <summary>
		/// Query properties collection.
		/// </summary>
		private List<KeyValuePair<string, string>> _queryProperties;

		#endregion

		#region Fields: Protected

		/// <summary>
		/// Current schema name.
		/// </summary>
		protected string SchemaName;

		/// <summary>
		/// Current record Id.
		/// </summary>
		protected Guid RecordId = Guid.Empty;

		/// <summary>
		/// Source Id.
		/// </summary>
		protected Guid SourceId;

		/// <summary>
		/// The query options dictionary.
		/// </summary>
		protected Dictionary<string, KeyValuePair<string, string>> QueryOptionsDictionary;

		#endregion

		#region Constructor: Protected

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// </summary>
		protected BaseAnniversaryReminding(UserConnection userConnection) {
			_userConnection = userConnection;
			_notifyDaysPeriod = -1 * Core.Configuration.SysSettings.GetValue(UserConnection,
				                    "NoteworthyEventNotificationPeriod", DefaultNotifyDaysPeriod);
		}

		#endregion

		#region Properties: Private

		private List<KeyValuePair<string, string>> QueryProperties {
			get {
				return _queryProperties ?? (_queryProperties = new List<KeyValuePair<string, string>>());
			}
			set {
				_queryProperties = value;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// UserConnection instance.
		/// </summary>
		private readonly UserConnection _userConnection;
		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		/// <summary>
		/// Flag of anniversary reminding generating on record save.
		/// </summary>
		public bool IsGenerationOnSave { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Number of the days before anniversary remindings is generate.
		/// </summary>
		private int _notifyDaysPeriod;
		public int NotifyDaysPeriod {
			get {
				if (_notifyDaysPeriod == 0) {
					_notifyDaysPeriod = -1 * DefaultNotifyDaysPeriod;
				}
				return _notifyDaysPeriod;
			}
			protected set {
				_notifyDaysPeriod = value;
			}
		}

		/// <summary>
		/// The number of days is an anniversary remindings isn't delete.
		/// </summary>
		private int _remindingLifePeriod;
		public int RemindingLifePeriod {
			get {
				if (_remindingLifePeriod == 0) {
					_remindingLifePeriod = DefaultRemindingLifePeriod;
				}
				return _remindingLifePeriod;
			}
			protected set {
				_remindingLifePeriod = value;
			}
		}

		/// <summary>
		/// Generate anniversary options.
		/// </summary>
		public IEnumerable<string> Options {
			get; set;
		}

		#endregion

		#region Methods: Private

		private void ExecuteQueries() {
			foreach (KeyValuePair<string, string> queryProperty in QueryProperties) {
				Select select = GetBaseSelect(queryProperty.Key);
				select = DecorateSelect(select, queryProperty);
				if (queryProperty.Key.Equals("Account")) {
					select = AddAccountAnniversaryFilters(select);
				}
				if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
					GenerateRemindings(select, queryProperty.Key);
				} else {
					AddNewRemindings(select);
				}
			}
		}

		private void AddNewRemindings(Select select) {
			var insertSelect =
				new InsertSelect(UserConnection)
					.Into("Reminding")
					.Set("ContactId", "SubjectId", "SysEntitySchemaId", "SubjectCaption", "RemindTime",
						"NotificationTypeId", "ProcessListeners", "SenderId", "SourceId")
					.FromSelect(select);
			ExecuteDbQuery(insertSelect);
		}

		private bool CanReceiverReadConnectedEntity(Reminding reminding, string schemaName) {
			Dictionary<string, object> conditions = new Dictionary<string, object> {
				{ "Contact", reminding.ContactId },
				{ "Active", true }
			};
			var sysAdminUnit = new SysAdminUnit(UserConnection);
			if (!sysAdminUnit.FetchFromDB(conditions, false)) {
				return false;
			}
			var rightsLevel = UserConnection.DBSecurityEngine.GetEntitySchemaRecordRightLevel(sysAdminUnit.Id,
				schemaName, reminding.SubjectId);
			return rightsLevel.HasFlag(SchemaRecordRightLevels.CanRead);
		}

		private void GenerateRemindings(Select select, string anniversarySchemaName) {
			var subSelect = new Select(UserConnection)
				.Column("Id")
				.From("Reminding")
				.Where("Reminding", "NotificationTypeId").IsEqual("source", "NotificationTypeId")
				.And("Reminding", "ContactId").IsEqual("source", "ReceiverId")
				.And("Reminding", "SubjectId").IsEqual("source", "Id")
				.And("Reminding", "TypeCaption").IsEqual("source", "SubjectCaption");
			var mainSelect = (Select)new Select(UserConnection)
				.Column(Column.Asterisk())
				.From(select).As("source")
				.Where().Not().Exists(subSelect);
			var remindings = new List<Reminding>();
			mainSelect.ExecuteReader(reader => {
				var reminding = GetReminding(reader);
				remindings.Add(reminding);
			});
			foreach (var reminding in remindings) {
				if (IsGenerationOnSave && !CanReceiverReadConnectedEntity(reminding, anniversarySchemaName)) {
					continue;
				}
				reminding.Save();
			}
			if (remindings.Count > 0) {
				DeleteNotActualAnniversaryRemindings(anniversarySchemaName);
			}
		}

		private Reminding GetReminding(IDataReader reader) {
			var contactId = reader.GetColumnValue<Guid>("ReceiverId");
			var entityId = reader.GetColumnValue<Guid>("Id");
			var entityName = reader.GetColumnValue<string>("Name");
			var sysEntitySchemaId = reader.GetColumnValue<Guid>("SubjectId");
			var schema = UserConnection.EntitySchemaManager.GetItemByUId(sysEntitySchemaId);
			var dateString = reader.GetColumnValue<string>("SubjectCaption");
			var anniversaryBaseDate = reader.GetColumnValue<DateTime>("AnniversaryBaseDate");
			IRemindingTextFormer textFormer = ClassFactory.Get<AnniversaryRemindingTextFormer>(
				new ConstructorArgument("userConnection", UserConnection));
			var title = textFormer.GetTitle(new Dictionary<string, object> {
				{"SchemaName", schema.Name}
			});
			var body = textFormer.GetBody(new Dictionary<string, object> {
				{"SchemaName", schema.Name},
				{"EntityId", entityId},
				{"EntityName", entityName},
				{"Date", dateString}
			});
			var reminding = new Reminding(_userConnection);
			reminding.SetDefColumnValues();
			reminding.RemindTime = reader.GetColumnValue<DateTime>("RemindTime");
			reminding.Description = title;
			reminding.PopupTitle = title;
			reminding.ContactId = contactId;
			reminding.SubjectCaption = body;
			reminding.SubjectId = entityId;
			reminding.SourceId = SourceId;
			reminding.SenderId = sysEntitySchemaId;
			reminding.SysEntitySchemaId = sysEntitySchemaId;
			reminding.NotificationTypeId = RemindingConsts.NotificationTypeAnniversaryId;
			reminding.TypeCaption = dateString;
			reminding.AnniversaryDate = GetAnniversaryDate(anniversaryBaseDate);
			return reminding;
		}

		private DateTime GetAnniversaryDate(DateTime anniversaryBaseDate) {
			var dayInMonth = DateTime.DaysInMonth(DateTime.Today.Year, anniversaryBaseDate.Month);
			var day = anniversaryBaseDate.Day > dayInMonth ? dayInMonth : anniversaryBaseDate.Day;
			return new DateTime(DateTime.Today.Year, anniversaryBaseDate.Month, day);
		}

		private void DeleteNotActualAnniversaryRemindings(string anniversarySchemaName) {
			var notActualRemindingsList = new List<Guid>();
			var notActualRemindingsQuery = GetNotActualAnniversaryRemindingQuery(anniversarySchemaName);
			notActualRemindingsQuery.ExecuteReader(r => notActualRemindingsList.Add(r.GetColumnValue<Guid>("Id")));
			foreach (var remindingId in notActualRemindingsList) {
				var reminding = new Reminding(_userConnection);
				if (reminding.FetchFromDB(remindingId)) {
					reminding.Delete();
				}
			}
		}
		
		private Select GetNotActualAnniversaryRemindingQuery(string anniversarySchemaName) {
			var targetEntitySchema = GetTargetEntitySchema(anniversarySchemaName);
			var subSelect = (Select)new Select(_userConnection)
				.Column(Func.Max("source", "CreatedOn"))
				.From("Reminding").As("source")
				.Where("source", "NotificationTypeId").IsEqual(Column.SourceColumn("target", "NotificationTypeId"))
				.And("source", "ContactId").IsEqual(Column.SourceColumn("target", "ContactId"))
				.And("source", "SysEntitySchemaId").IsEqual(Column.SourceColumn("target", "SysEntitySchemaId"))
				.And("source", "SubjectId").IsEqual(Column.SourceColumn("target", "SubjectId"));
			var select = (Select)new Select(_userConnection)
				.Column("target", "Id")
				.From("Reminding").As("target")
				.Where("target", "CreatedOn").IsNotEqual(subSelect)
				.And("target", "NotificationTypeId").IsEqual(Column.Parameter(RemindingConsts.NotificationTypeAnniversaryId))
				.And("target", "SenderId").IsEqual(Column.Parameter(targetEntitySchema.UId));
			if (RecordId.IsNotEmpty()) {
				select.And("target", "SubjectId").IsEqual(Column.Parameter(RecordId));
			}
			return select;
		}
		
		private void DeleteNotActualEntityRemindings() {
			var delete =
				new Delete(UserConnection)
					.From("Reminding").WithHints(new RowLockHint())
					.Where("Reminding", "SourceId").IsEqual(Column.Parameter(SourceId))
					.And("Reminding", "SenderId").IsEqual(Column.Parameter(RecordId)) as Delete;
			ExecuteDbQuery(delete);
		}

		private Select GetBaseSelect(string anniversarySchemaName) {
			var isAccountAnniversary = IsAccountAnniversary(anniversarySchemaName);
			string usingSchemaName = isAccountAnniversary ? "AccountAnniversary" : "Contact";
			string column = isAccountAnniversary ? "Date" : "BirthDate";
			var targetEntitySchema = GetTargetEntitySchema(anniversarySchemaName);
			Select select =
				new Select(UserConnection)
					.Column(SchemaName, "OwnerId").As("ReceiverId")
					.Column(anniversarySchemaName, "Id")
					.Column(Column.Parameter(targetEntitySchema.UId)).As("SubjectId")
					.Column(Func.CustomFunction("fn_CastDateToString", Column.SourceColumn(usingSchemaName, column)))
						.As("SubjectCaption")
					.Column(Column.Parameter(DateTime.UtcNow)).As("RemindTime")
					.Column(Column.Parameter(RemindingConsts.NotificationTypeAnniversaryId)).As("NotificationTypeId")
					.Column(Column.Parameter(0)).As("ProcessListeners")
					.Column(SchemaName, "Id").As("SenderId")
					.Column(Column.Parameter(SourceId)).As("SourceId")
					.From(SchemaName);
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				select = select.Column(anniversarySchemaName, "Name")
					.Column(usingSchemaName, column).As("AnniversaryBaseDate");
			}			
			select = AddDefaultAnniversaryFilters(select, anniversarySchemaName);
			if (RecordId.IsNotEmpty()) {
				select.And(SchemaName, "Id").IsEqual(Column.Parameter(RecordId));
			}
			return select;
		}

		private EntitySchema GetTargetEntitySchema(string anniversarySchemaName) {
			var targetEntitySchema = IsAccountAnniversary(anniversarySchemaName)
				? UserConnection.EntitySchemaManager.GetInstanceByName("Account")
				: UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			return targetEntitySchema;
		}

		private bool IsAccountAnniversary(string anniversarySchemaName) {
			bool isAccountAnniversary = anniversarySchemaName.Equals("Account");
			return isAccountAnniversary;
		}

		private Select AddAccountAnniversaryFilters(Select select) {
			select.Join(JoinType.Inner, "AccountAnniversary")
				.On("Account", "Id").IsEqual("AccountAnniversary", "AccountId");
			select.And("AccountAnniversary", "AnniversaryTypeId").IsEqual(Column
				.Parameter(AnniversaryTypeConsts.FoundationDayId));
			return select;
		}

		private Select AddDefaultAnniversaryFilters(Select select, string anniversarySchemaName) {
			bool isAccountAnniversary = anniversarySchemaName.Equals("Account");
			string usingSchemaName = isAccountAnniversary ? "AccountAnniversary" : "Contact";
			string column = isAccountAnniversary ? "Date" : "BirthDate";
			var dateDiffFilterFilter = GetDateDiffFilterExpression(usingSchemaName, column);
			var dayOfWeekFilter = GetDayOfWeekFilterExpression(usingSchemaName, column);
			select
				.Where(SchemaName, "OwnerId").Not().IsNull()
				.And()
				.OpenBlock()
				.OpenBlock(dateDiffFilterFilter).IsBetween(Column.Parameter(NotifyDaysPeriod)).And(Column.Parameter(0))
				.And(dayOfWeekFilter).In(Column.Parameters((int)Days.Sun,
					(int)Days.Mon, (int)Days.Tue, (int)Days.Wed, (int)Days.Thu, (int)Days.Fri, (int)Days.Sat))
				.CloseBlock()
				.Or()
				.OpenBlock(dateDiffFilterFilter).IsEqual(Column.Parameter(NotifyDaysPeriod - 1))
				.And(dayOfWeekFilter).IsEqual(Column.Parameter((int)Days.Mon))
				.CloseBlock()
				.Or()
				.OpenBlock(dateDiffFilterFilter).IsEqual(Column.Parameter(NotifyDaysPeriod - 2))
				.And(dayOfWeekFilter).IsEqual(Column.Parameter((int)Days.Tue))
				.CloseBlock()
				.CloseBlock();
			return select;
		}

		private DateDiffQueryFunction GetDateDiffFilterExpression(string schemaName, string column) {
			DateDiffQueryFunction filter = Func.DateDiff(
				DateDiffQueryFunctionInterval.Day,
				Func.DateAddYear(
					Func.DateDiff(
						DateDiffQueryFunctionInterval.Year,
						Column.SourceColumn(schemaName, column),
						Func.CurrentDateTime()
					),
					Column.SourceColumn(schemaName, column)
				),
				Func.CurrentDateTime()
			);
			return filter;
		}

		private DatePartQueryFunction GetDayOfWeekFilterExpression(string schemaName, string column) {
			DatePartQueryFunction filter = Func.DatePart(
				DatePartQueryFunctionInterval.Weekday,
				Func.DateAddYear(
					Func.DateDiff(
						DateDiffQueryFunctionInterval.Year,
						Column.SourceColumn(schemaName, column),
						Func.CurrentDateTime()
					),
					Column.SourceColumn(schemaName, column)
				)
			);
			return filter;
		}

		private void Init() {
			QueryProperties = new List<KeyValuePair<string, string>>();
			if (Options.IsNullOrEmpty()) {
				InitQueryProperties();
			}
			InitQueryOptions();
		}

		private void DeleteEntityRemindings(Guid schemaUId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Reminding") {
				UseAdminRights = false,
				IgnoreDisplayValues = true
			};
			esq.AddAllSchemaColumns();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "NotificationType",
				RemindingConsts.NotificationTypeAnniversaryId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysEntitySchema", schemaUId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SubjectId", RecordId));
			var remindings = esq.GetEntityCollection(UserConnection).ToArray();
			foreach (var reminding in remindings) {
				reminding.Delete();
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes query in database.
		/// </summary>
		/// <param name="query">Query to execute.</param>
		protected virtual void ExecuteDbQuery(IDBCommand query) {
			query.Execute();
		}

		protected virtual void InitQueryProperties() { }

		protected virtual void InitQueryOptions() {
			QueryOptionsDictionary = GetQueryOptionsDictionary();
			if (Options == null) {
				return;
			}
			foreach (string optionName in Options) {
				KeyValuePair<string, string> pair;
				if (QueryOptionsDictionary.TryGetValue(optionName, out pair)) {
					AddQueryProperty(pair.Key, pair.Value);
				}
			}
		}

		protected virtual Dictionary<string, KeyValuePair<string, string>> GetQueryOptionsDictionary() {
			return new Dictionary<string, KeyValuePair<string, string>>();
		}

		/// <summary>
		/// Returns select with all filters for current entity.
		/// <param name="select">Select for getting anniversary reminding.</param>
		/// <param name="queryProperty">Query property for current select.</param>
		/// <param name="queryProperty.Key">Anniversary entity schema name</param>
		/// <param name="queryProperty.Value">The property determines type of the decoration.</param>
		/// <returns>Modified select with all filters for current entity.</returns>
		/// </summary>
		protected abstract Select DecorateSelect(Select select, KeyValuePair<string, string> queryProperty);

		/// <summary>
		/// Add new query property to query properties list.
		/// <param name="key">Anniversary entity schema name.</param>
		/// <param name="value">The property determines type of the decoration.</param>
		/// <example>AddQueryProperty("Contact", "Participant")</example>
		/// </summary>
		protected void AddQueryProperty(string key, string value) {
			if (QueryProperties.Any(pair => pair.Key == key && pair.Value == value)) {
				return;
			}
			QueryProperties.Add(new KeyValuePair<string, string>(key, value));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Delete all old remindings.
		/// </summary>
		[Obsolete("Method is deprecated, BPMSoft.Configuration.NotificationCleanerJob must be scheduled.")]
		public void DeleteOldRemindings() {
			_remindingLifePeriod = Core.Configuration.SysSettings.GetValue<int>(UserConnection,
				"NotificationsExpirationTerm", DefaultRemindingLifePeriod);
			var delete =
			(Delete)new Delete(UserConnection).From("Reminding")
			.Where(Func.DateDiff(DateDiffQueryFunctionInterval.Day,
				Column.SourceColumn("Reminding", "RemindTime"), Func.CurrentDateTime())).IsGreater(Column
				.Parameter(RemindingLifePeriod))
				.And("Reminding", "NotificationTypeId").In(Column.Parameters(
					RemindingConsts.NotificationTypeNotificationId, RemindingConsts.NotificationTypeAnniversaryId))
				.And("Reminding", "IsRead").IsEqual(Column.Parameter(true));
			var deleteEsn =
			 (Delete)new Delete(UserConnection).From("ESNNotification")
			.Where(Func.DateDiff(DateDiffQueryFunctionInterval.Day,
				Column.SourceColumn("ESNNotification", "CreatedOn"), Func.CurrentDateTime())).IsGreater(Column
				.Parameter(RemindingLifePeriod))
				.And("ESNNotification", "IsRead").IsEqual(Column.Parameter(true));
			ExecuteDbQuery(delete);
			ExecuteDbQuery(deleteEsn);
		}

		/// <summary>
		/// Delete all remindings for current record.
		/// <param name="schemaUId">Current schema UId.</param>
		/// </summary>
		public void DeleteRecordRemindings(Guid schemaUId) {
			if (UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				DeleteEntityRemindings(schemaUId);
			} else {
				var delete = new Delete(UserConnection)
					.From("Reminding").WithHints(new RowLockHint())
					.Where("SysEntitySchemaId").IsEqual(Column.Parameter(schemaUId))
					.And("SubjectId").IsEqual(Column.Parameter(RecordId)) as Delete;
				ExecuteDbQuery(delete);
			}
		}

		/// <summary>
		/// Generate all new remindings for contacts and accounts.
		/// <param name="onSaveRemindingGeneration">Flag for generating remindings when entity was saved.</param>
		/// </summary>
		public void GenerateActualRemindings(bool onSaveRemindingGeneration) {
			if (onSaveRemindingGeneration && !UserConnection.GetIsFeatureEnabled("GenerateAnnyversaryOnSave")) {
				return;
			}
			IsGenerationOnSave = onSaveRemindingGeneration;
			Init();
			if (!UserConnection.GetIsFeatureEnabled("NotificationV2")) {
				DeleteNotActualEntityRemindings();
			}
			ExecuteQueries();
		}

		/// <summary>
		/// Generate all new remindings for contacts and accounts.
		/// </summary>
		public void GenerateActualRemindings() {
			GenerateActualRemindings(true);
		}

		#endregion

	}

	#endregion
}

