using global::Common.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BPMSoft.Common;
using BPMSoft.Common.Json;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.Core.Store;
using BPMSoft.UI.WebControls.Controls;
using BPMSoft.UI.WebControls.Utilities.Json.Converters;

namespace BPMSoft.Configuration
{

	#region Class: LocalMessageHelper

	public class LocalMessageHelper
	{

		#region Constants

		public readonly Guid LocalMessageNotifierId = new Guid("ED501EDB-8EBF-4C76-A35D-6F23BE243043");
		public readonly string LocalMessageSchemaName = "LocalMessage";

		#endregion

		#region Fields: Private

		private string _message;
		private readonly Entity _entity;
		private readonly Entity _clonedEntity;
		private readonly UserConnection _userConnection;
		private readonly EntitySchemaColumnCollection _entitySchemaColumns;
		private readonly EntityChangeType _changeType;
		private static readonly ILog _log = LogManager.GetLogger("LocalMessage");

		#endregion

		#region Properties:Private

		private string EntitySchemaName {
			get {
				return LocalMessageSchemaName;
			}
		}

		private string Empty {
			get {
				return new LocalizableString(_userConnection.Workspace.ResourceStorage, "LocalMessageHelper",
		"LocalizableStrings.Empty.Value").ToString();
			}
		}

		private string HrefLink {
			get {
				return new LocalizableString(_userConnection.Workspace.ResourceStorage, "LocalMessageHelper",
		"LocalizableStrings.HrefLink.Value").ToString();
			}
		}

		#endregion

		#region Constructor: Public

		public LocalMessageHelper(Entity entity, UserConnection userConnection, EntityChangeType changeType) {
			_entity = entity;
			_clonedEntity = new Entity(entity);
			_entity.UseLazyLoad = true;
			_userConnection = userConnection;
			_entitySchemaColumns = _entity.Schema.Columns;
			_changeType = changeType;
			SetCurrentUser();
		}

		#endregion

		#region Methods: Private

		private void SetCurrentUser() {
			var modifiedBy = _entitySchemaColumns.FindByName("ModifiedBy");
			if (modifiedBy != null) {
				_entity.SetColumnValue("ModifiedById", _userConnection.CurrentUser.ContactId);
			}
		}

		private Entity PickUpSourceEntity() {
			return _userConnection.GetIsFeatureEnabled("UseEntityCloneInLocalMessage") ? _clonedEntity : _entity;
		}

		private Dictionary<Guid, Guid> GetListenersData() {
			if (_entitySchemaColumns.FindByName("EntityId") != null &&
				_entitySchemaColumns.FindByName("EntitySchemaUId") != null) {
				if (_entity.GetTypedColumnValue<Guid>("EntitySchemaUId") == Guid.Empty &&
					_entity.GetTypedColumnValue<Guid>("EntityId") == Guid.Empty &&
					_entity.SchemaName == "SocialMessage") {
					return GetSocialMessageListenersData();
				}
				return new Dictionary<Guid, Guid> {
					{_entity.GetTypedColumnValue<Guid>("EntitySchemaUId"), _entity.GetTypedColumnValue<Guid>("EntityId")}
				};
			}
			var listenersData = new Dictionary<Guid, Guid>();
			var connectionColumnsSelect = new Select(_userConnection)
				.Column("NotifierConnectionColumn")
				.From("ListenerByNotifier")
				.Where("MessageNotifierId").IsEqual(new QueryParameter(LocalMessageNotifierId)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = connectionColumnsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var notifierConnectionColumnName = dataReader.GetColumnValue<string>("NotifierConnectionColumn");
						if (!string.IsNullOrEmpty(notifierConnectionColumnName)) {
							var entitySchemaColumn = _entitySchemaColumns.FindByName(notifierConnectionColumnName);
							if (entitySchemaColumn != null) {
								var connectionColumnValue = _entity.GetTypedColumnValue<Guid>(entitySchemaColumn.ColumnValueName);
								if (connectionColumnValue == Guid.Empty) {
									connectionColumnValue = _entity.GetTypedOldColumnValue<Guid>(entitySchemaColumn.ColumnValueName);
								}
								if (connectionColumnValue != Guid.Empty) {
									listenersData.Add(entitySchemaColumn.ReferenceSchemaUId, connectionColumnValue);
								}
							} else if (notifierConnectionColumnName == _entity.SchemaName) {
								listenersData.Add(_entity.Schema.UId, _entity.PrimaryColumnValue);
							}
						}
					}
				}
			}
			return listenersData;
		}

		private void CreateEntity(KeyValuePair<Guid, Guid> pair) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(EntitySchemaName);
			var localMessageEntity = entitySchema.CreateEntity(_userConnection);
			localMessageEntity.SetDefColumnValues();
			localMessageEntity.SetColumnValue("Message", _message);
			localMessageEntity.SetColumnValue("EntitySchemaUId", pair.Key);
			localMessageEntity.SetColumnValue("EntityId", pair.Value);
			localMessageEntity.Save();
		}

		private void InsertLocalMessage() {
			foreach (var pair in GetListenersData()) {
				CreateEntity(pair);
			}
		}

		private string CreateLink(string columnName) {
			var entitySchemaColumn = _entitySchemaColumns.FindByName(columnName);
			if (entitySchemaColumn == null) {
				return string.Empty;
			}
			if (!entitySchemaColumn.IsLookupType) {
				return string.Format(HrefLink, _entity.SchemaName, _entity.PrimaryColumnValue, _entity.PrimaryDisplayColumnValue);
			}
			Entity sourceEntity = PickUpSourceEntity();
			bool useAdminRightsOld = sourceEntity.UseAdminRights;
			sourceEntity.UseAdminRights = false;
			sourceEntity.LoadLookupDisplayValues(columnName);
			var columnValue = sourceEntity.GetTypedColumnValue<Guid>(entitySchemaColumn.ColumnValueName);
			var displayColumnValue = sourceEntity.GetTypedColumnValue<string>(entitySchemaColumn.DisplayColumnValueName);
			sourceEntity.UseAdminRights = useAdminRightsOld;
			return string.Format(HrefLink, entitySchemaColumn.ReferenceSchema.Name, columnValue, displayColumnValue);
		}

		private Dictionary<Guid, Guid> GetSocialMessageListenersData() {
			var parentColumn = _entitySchemaColumns.FindByName("Parent");
			if (parentColumn == null) {
				return new Dictionary<Guid, Guid>();
			}
			var parentColumnValue = _entity.GetTypedColumnValue<Guid>(parentColumn.ColumnValueName);
			if (parentColumnValue == Guid.Empty) {
				return new Dictionary<Guid, Guid>();
			}
			var entitySchemaManager = _userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName("SocialMessage");
			var entity = entitySchema.CreateEntity(_userConnection);
			var columnsToFetch = new EntitySchemaColumn[] {
				entitySchema.PrimaryColumn,
				entitySchema.Columns.GetByName("EntitySchemaUId"),
				entitySchema.Columns.GetByName("EntityId")
			};
			if (entity.FetchFromDB(entitySchema.PrimaryColumn, parentColumnValue, columnsToFetch)) {
				return new Dictionary<Guid, Guid> {
					{entity.GetTypedColumnValue<Guid>("EntitySchemaUId"), entity.GetTypedColumnValue<Guid>("EntityId")}
				};
			}
			return new Dictionary<Guid, Guid>();
		}

		private string GetDisplayColumnValue(string columnName) {
			var column = _entitySchemaColumns.FindByName(columnName);
			if (column == null) {
				return string.Empty;
			}
			Entity sourceEntity = PickUpSourceEntity();
			if (column.IsLookupType) {
				sourceEntity.LoadLookupDisplayValues(columnName);
			}
			return sourceEntity.GetTypedColumnValue<string>(column.DisplayColumnValueName);
		}

		private IEnumerable<string> GetColumnValues(LocalMessageColumnTemplate itemValue) {
			var list = new List<string>();
			if (itemValue.IsOnChange) {
				list.AddRange(GetChangedDisplayValues(itemValue.ColumnName));
			} else {
				list.Add(GetDisplayColumnValue(itemValue.ColumnName));
			}
			return ApplyPlainText(list);
		}

		private static IEnumerable<string> ApplyPlainText(List<string> list) {
			return list.ConvertAll(item => item.GetPlainText());
		}

		private IEnumerable<string> GetChangedDisplayValues(string columnName) {
			var list = new List<string>();
			var column = _entitySchemaColumns.FindByName(columnName);
			if (column == null) {
				return list;
			}
			Entity sourceEntity = PickUpSourceEntity();
			var oldValue = sourceEntity.GetTypedOldColumnValue<string>(column.DisplayColumnValueName);
			list.Add(!string.IsNullOrEmpty(oldValue) ? oldValue : Empty);
			if (column.IsLookupType) {
				sourceEntity.LoadLookupDisplayValues(columnName);
			}
			var value = sourceEntity.GetTypedColumnValue<string>(column.DisplayColumnValueName);
			list.Add(!string.IsNullOrEmpty(value) ? value : Empty);
			return list;
		}

		private bool IsSchemaMatch(Guid schemaUId) {
			return schemaUId == _entity.Schema.UId;
		}

		private bool IsChangeTypeMatch(int changeType) {
			return changeType == (int)_changeType;
		}

		private bool IsConditionDataMatch(string conditionData) {
			if (string.IsNullOrEmpty(conditionData)) {
				return true;
			}
			var jsonConverter = new DataSourceFiltersJsonConverter(_userConnection, _entity.Schema);
			jsonConverter.PreventRegisteringClientScript = true;
			var filterCollection = Json.Deserialize(conditionData, typeof(DataSourceFilterCollection), new List<JsonConverter> { jsonConverter }) as DataSourceFilterCollection;
			if (filterCollection == null) {
				return true;
			}
			var esq = new EntitySchemaQuery(_entity.Schema);
			esq.AddColumn(_entity.Schema.PrimaryColumn.Name);
			esq.Filters.Add(filterCollection.ToEntitySchemaQueryFilterCollection(esq));
			var entity = esq.GetEntity(_userConnection, _entity.PrimaryColumnValue);
			return entity != null;
		}

		private bool IsChangedColumnsMatch(string changedColumns) {
			if (string.IsNullOrEmpty(changedColumns)) {
				return true;
			}
			var changedColumnsMetaPaths = JsonConvert.DeserializeObject<Collection<string>>(changedColumns);
			foreach (var columnMetaPath in changedColumnsMetaPaths) {
				var changedColumn = _entity.Schema.GetSchemaColumnByMetaPath(columnMetaPath);
				if (_entity.GetChangedColumnValues()
					.Where(columnValue => columnValue.Column.UId == changedColumn.UId)
					.Where(columnValue =>
					((columnValue.Value != null) && !columnValue.Value.Equals(columnValue.OldValue)) ||
					((columnValue.Value == null) && columnValue.OldValue != null)).Any()
				) {
					return true;
				}
			}
			return false;
		}

		private void AppendMessage(LocalMessageStartEvent startEvent) {
			var result = new List<object>();
			var sb = new StringBuilder();
			var lmColumnTemplates = LocalMessageStore.GetLocalMessageColumnTemplates(_userConnection);
			foreach (var column in lmColumnTemplates.Where(item => item.LMStartEventId == startEvent.Id).OrderBy(t => t.Position)) {
				if (column.IsLink) {
					result.Add(CreateLink(column.ColumnName));
				} else {
					result.AddRange(GetColumnValues(column));
				}
			}
			_message = sb.AppendFormat(startEvent.MessageTemplate, result.ToArray()).ToString();
			if (_message.IsNullOrWhiteSpace()) {
				_log.Info($"" +
					$"Case: {result.FirstOrDefault()}; " +
					$"Start event message template: {startEvent.MessageTemplate};" +
					$"Current user: {_userConnection.CurrentUser};" +
					$"Empty message at \n {Environment.StackTrace}");
			}
		}

		#endregion

		#region Methods: Public

		public void CreateLocalMessage() {
			if (_changeType == EntityChangeType.None) {
				return;
			}
			foreach (var startEvent in LocalMessageStore.GetLocalMessageStartEvents(_userConnection)) {
				if (!IsSchemaMatch(startEvent.EntitySchemaUId)) {
					continue;
				}
				if (!IsChangeTypeMatch(startEvent.RecordChangeType)) {
					continue;
				}
				if (!IsChangedColumnsMatch(startEvent.ChangedColumns)) {
					continue;
				}
				if (!IsConditionDataMatch(startEvent.ConditionData)) {
					continue;
				}
				AppendMessage(startEvent);
				InsertLocalMessage();
			}
		}

		#endregion

	}

	#endregion

	#region Class: LocalMessageStore

	public static class LocalMessageStore
	{

		#region Properties: Private

		private static IDictionary<Guid, IList<LocalMessageStartEvent>> _localMessageStartEvents;

		private static IList<LocalMessageColumnTemplate> _localMessageColumnTemplates;

		private static ILog _log = LogManager.GetLogger("LocalMessage");

		private static string CacheableLocalMessageColumnTemplatesKey = "CacheableLocalMessageColumnTemplates";

		private static string CacheableLocalMessageStartEventsKey = "CacheableLocalMessageStartEvents";

		#endregion

		#region Methods: Private

		private static IList<LocalMessageStartEvent> GetLocalMessageStartEventsFromDB(UserConnection userConnection) {
			var query = new EntitySchemaQuery(userConnection.EntitySchemaManager, "LMStartEvent");
			query.PrimaryQueryColumn.IsAlwaysSelect = true;
			var messageTemplateColumnName = query.AddColumn("MessageTemplate").Name;
			var conditionDataColumnName = query.AddColumn("ConditionData").Name;
			var changedColumnsColumnName = query.AddColumn("ChangedColumns").Name;
			var recordChangeTypeColumnName = query.AddColumn("RecordChangeType").Name;
			var entitySchemaUIdColumnName = query.AddColumn("EntitySchemaUId").Name;
			query.UseAdminRights = false;
			var collection = query.GetEntityCollection(userConnection);
			return collection.Select(entity => new LocalMessageStartEvent {
				Id = entity.PrimaryColumnValue,
				ConditionData = entity.GetTypedColumnValue<string>(conditionDataColumnName),
				ChangedColumns = entity.GetTypedColumnValue<string>(changedColumnsColumnName),
				RecordChangeType = entity.GetTypedColumnValue<int>(recordChangeTypeColumnName),
				MessageTemplate = entity.GetTypedColumnValue<string>(messageTemplateColumnName),
				EntitySchemaUId = entity.GetTypedColumnValue<Guid>(entitySchemaUIdColumnName)
			}).ToList();
		}

		private static IList<LocalMessageColumnTemplate> GetLocalMessageColumnTemplatesFromDb(UserConnection userConnection) {
			var query = new EntitySchemaQuery(userConnection.EntitySchemaManager, "LMColumnTemplate");
			query.PrimaryQueryColumn.IsAlwaysSelect = true;
			var columnNameColumnName = query.AddColumn("ColumnName").Name;
			var isLinkColumnName = query.AddColumn("IsLink").Name;
			var isOnChangeColumnName = query.AddColumn("IsOnChange").Name;
			var positionColumnName = query.AddColumn("Position").Name;
			var lmStartEventIdColumnName = query.AddColumn("LMStartEvent").Name;
			query.UseAdminRights = false;
			var collection = query.GetEntityCollection(userConnection);
			return collection.Select(entity => new LocalMessageColumnTemplate() {
				ColumnName = entity.GetTypedColumnValue<string>(columnNameColumnName),
				IsLink = entity.GetTypedColumnValue<bool>(isLinkColumnName),
				IsOnChange = entity.GetTypedColumnValue<bool>(isOnChangeColumnName),
				Position = entity.GetTypedColumnValue<int>(positionColumnName),
				LMStartEventId = entity.GetTypedColumnValue<Guid>(lmStartEventIdColumnName + "Id")
			}).ToList();
		}

		private static void StoreInUserConnection(UserConnection userConnection, object value, string key) {
			userConnection.ApplicationCache.WithLocalCaching().SetOrRemoveValue(key, value);
		}

		private static T GetCachedLocalMessageValue<T>(UserConnection userConnection, string key) where T : class {
			return userConnection.ApplicationCache.WithLocalCaching()
						.GetValue<object>(key) as T;
		}

		#endregion

		#region Methods: Public

		public static IList<LocalMessageStartEvent> GetLocalMessageStartEvents(UserConnection userConnection) {
			Guid cultureId = userConnection.CurrentUser.SysCultureId;
			var localMessageStartEvents =
				GetCachedLocalMessageValue<Dictionary<Guid, IList<LocalMessageStartEvent>>>(userConnection, CacheableLocalMessageStartEventsKey);
			if (localMessageStartEvents == null) {
				localMessageStartEvents = new Dictionary<Guid, IList<LocalMessageStartEvent>>();
			}
			if (!localMessageStartEvents.ContainsKey(cultureId)) {
				_log.Info($"Empty list of start events for culture: {cultureId}; Current user: {userConnection.CurrentUser}");
				localMessageStartEvents.Add(cultureId, GetLocalMessageStartEventsFromDB(userConnection));
				_log.Info($"{localMessageStartEvents[cultureId].Count} start events were loaded. Current user: {userConnection.CurrentUser}.");
				StoreInUserConnection(userConnection, localMessageStartEvents, CacheableLocalMessageStartEventsKey);
			}
			return localMessageStartEvents[cultureId];
		}

		public static IList<LocalMessageColumnTemplate> GetLocalMessageColumnTemplates(UserConnection userConnection) {
			var localMessageColumnTemplates =
				GetCachedLocalMessageValue<IList<LocalMessageColumnTemplate>>(userConnection, CacheableLocalMessageColumnTemplatesKey);
			if (localMessageColumnTemplates != null) {
				return localMessageColumnTemplates;
			}
			_log.Info($"Empty list of column templates. Current user: {userConnection.CurrentUser}.");
			localMessageColumnTemplates = GetLocalMessageColumnTemplatesFromDb(userConnection);
			if (localMessageColumnTemplates.Count > 0) {
				_log.Info($"{localMessageColumnTemplates.Count} column templates were loaded. Current user: {userConnection.CurrentUser}.");
			}
			StoreInUserConnection(userConnection, localMessageColumnTemplates, CacheableLocalMessageColumnTemplatesKey);
			return localMessageColumnTemplates;
		}

		#endregion
	}

	#endregion

	#region Class: LMCacheSingleton

	class LMCacheSingleton
	{
		#region Fields: Private

		private static Guid _startEventId;

		private static UserConnection _userConnection;

		private static LMCacheSingleton _cacheSingletonInstance = null;

		private static IDictionary<Guid, IList<LocalMessageStartEvent>> _localMessageStartEvents;

		private static IList<LocalMessageColumnTemplate> _localMessageColumnTemplates;

		#endregion

		#region Properties: Private

		private static IDictionary<Guid, IList<LocalMessageStartEvent>> CacheableLocalMessageStartEvents {
			get {
				return _userConnection.SessionData["CacheableLocalMessageStartEvents"] as Dictionary<Guid, IList<LocalMessageStartEvent>>;
			}
			set {
				_userConnection.SessionData.Remove("CacheableLocalMessageStartEvents");
				_userConnection.SessionData["CacheableLocalMessageStartEvents"] = value;
			}
		}

		private static IList<LocalMessageColumnTemplate> CacheableLocalMessageColumnTemplates {
			get {
				return _userConnection.SessionData["CacheableLocalMessageColumnTemplates"] as List<LocalMessageColumnTemplate>;
			}
			set {
				_userConnection.SessionData.Remove("CacheableLocalMessageColumnTemplates");
				_userConnection.SessionData["CacheableLocalMessageColumnTemplates"] = value;
			}
		}

		#endregion

		#region Constructor: Private

		private LMCacheSingleton() {
		}

		#endregion

		#region Methods: Private

		private static IList<LocalMessageStartEvent> GetLocalMessageStartEventsFromDB() {
			var query = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "LMStartEvent");
			query.PrimaryQueryColumn.IsAlwaysSelect = true;
			var messageTemplateColumnName = query.AddColumn("MessageTemplate").Name;
			var conditionDataColumnName = query.AddColumn("ConditionData").Name;
			var changedColumnsColumnName = query.AddColumn("ChangedColumns").Name;
			var recordChangeTypeColumnName = query.AddColumn("RecordChangeType").Name;
			var entitySchemaUIdColumnName = query.AddColumn("EntitySchemaUId").Name;
			query.UseAdminRights = false;
			var collection = query.GetEntityCollection(_userConnection);
			return collection.Select(entity => new LocalMessageStartEvent {
				Id = entity.PrimaryColumnValue,
				ConditionData = entity.GetTypedColumnValue<string>(conditionDataColumnName),
				ChangedColumns = entity.GetTypedColumnValue<string>(changedColumnsColumnName),
				RecordChangeType = entity.GetTypedColumnValue<int>(recordChangeTypeColumnName),
				MessageTemplate = entity.GetTypedColumnValue<string>(messageTemplateColumnName),
				EntitySchemaUId = entity.GetTypedColumnValue<Guid>(entitySchemaUIdColumnName)
			}).ToList();
		}

		private static IList<LocalMessageColumnTemplate> GetLocalMessageColumnTemplatesFromDb() {
			var query = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "LMColumnTemplate");
			query.PrimaryQueryColumn.IsAlwaysSelect = true;
			var columnNameColumnName = query.AddColumn("ColumnName").Name;
			var isLinkColumnName = query.AddColumn("IsLink").Name;
			var isOnChangeColumnName = query.AddColumn("IsOnChange").Name;
			var positionColumnName = query.AddColumn("Position").Name;
			var lmStartEventIdColumnName = query.AddColumn("LMStartEvent").Name;
			query.UseAdminRights = false;
			var collection = query.GetEntityCollection(_userConnection);
			return collection.Select(entity => new LocalMessageColumnTemplate() {
				ColumnName = entity.GetTypedColumnValue<string>(columnNameColumnName),
				IsLink = entity.GetTypedColumnValue<bool>(isLinkColumnName),
				IsOnChange = entity.GetTypedColumnValue<bool>(isOnChangeColumnName),
				Position = entity.GetTypedColumnValue<int>(positionColumnName),
				LMStartEventId = entity.GetTypedColumnValue<Guid>(lmStartEventIdColumnName + "Id")
			}).ToList();
		}

		#endregion

		#region Methods: Public

		public static LMCacheSingleton GetInstance(UserConnection userConnection) {
			_userConnection = userConnection;
			return _cacheSingletonInstance ?? (_cacheSingletonInstance = new LMCacheSingleton());
		}

		public IList<LocalMessageStartEvent> LocalMessageStartEvents() {
			Guid cultureId = _userConnection.CurrentUser.SysCultureId;
			var localMessageStartEvents = _localMessageStartEvents ?? CacheableLocalMessageStartEvents;
			if (localMessageStartEvents == null) {
				localMessageStartEvents = new Dictionary<Guid, IList<LocalMessageStartEvent>>();
			}
			if (!localMessageStartEvents.ContainsKey(cultureId)) {
				localMessageStartEvents.Add(cultureId, GetLocalMessageStartEventsFromDB());
				CacheableLocalMessageStartEvents = _localMessageStartEvents = localMessageStartEvents;
			}
			return localMessageStartEvents[cultureId];
		}

		public IList<LocalMessageColumnTemplate> LocalMessageColumnTemplates() {
			var localMessageColumnTemplates = _localMessageColumnTemplates ?? CacheableLocalMessageColumnTemplates;
			if (localMessageColumnTemplates != null) {
				return localMessageColumnTemplates;
			}
			localMessageColumnTemplates = GetLocalMessageColumnTemplatesFromDb();
			CacheableLocalMessageColumnTemplates = _localMessageColumnTemplates = localMessageColumnTemplates;
			return localMessageColumnTemplates;
		}

		#endregion

	}

	#endregion

	#region LocalMessageColumnTemplate

	/// <summary>
	/// Contains data to fill template message.
	/// </summary>
	[Serializable]
	public class LocalMessageColumnTemplate
	{
		public string ColumnName;
		public bool IsLink;
		public bool IsOnChange;
		public int Position;
		public Guid LMStartEventId;
	}

	#endregion

	#region Class: LocalMessageStartEvent

	/// <summary>
	/// Contains start event data for local message.
	/// </summary>
	[Serializable]
	public class LocalMessageStartEvent
	{
		public Guid Id;
		public string MessageTemplate;
		public int RecordChangeType;
		public string ChangedColumns;
		public string ConditionData;
		public Guid EntitySchemaUId;
	}

	#endregion

	#region Class: HtmlHelpers

	public static class HtmlHelper
	{

		#region Methods:Public






		public static string GetPlainText(this string htmlText) {
			var reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
			return reg.Replace(htmlText, "");
		}

		#endregion

	}

	#endregion

}

