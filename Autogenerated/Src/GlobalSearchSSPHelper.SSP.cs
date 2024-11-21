namespace BPMSoft.Configuration.GlobalSearchHelper
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.GlobalSearch;
	using BPMSoft.Core.Factories;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using BPMSoft.Core.Store;
	using BPMSoft.Core.DB;
	using System.Collections.Concurrent;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities;


	#region Class: GlobalSearchSSPHelper

	[Override]
	public class GlobalSearchSSPHelper : GlobalSearchHelper
	{

		#region Constants: Private

		private List<Guid> _sysSchemaSSPList;

		private ConcurrentDictionary<string, List<string>> _allowedPortalColumns;

		private bool _isAllowedPortalColumnsInitialized;

		#endregion

		#region Properties: Private

		private bool IsCurrentUserSSP => UserConnection.CurrentUser.ConnectionType == UserType.SSP;

		private Guid CurrentUserId => UserConnection.CurrentUser.Id;

		private List<Guid> SysSchemaSSPList => _sysSchemaSSPList ?? (_sysSchemaSSPList = GetSSPSysSchemaUId());

		private bool UsePortalSchemaAllowedColumns => GlobalAppSettings.UsePortalSchemaAllowedColumns;

		private ConcurrentDictionary<string, List<string>> AllowedPortalColumns {
			get {
				if (!_isAllowedPortalColumnsInitialized) {
					_allowedPortalColumns = GetAllowedPortalColumnsFromCache();
					if (_allowedPortalColumns == null) {
						InitializeAllowedPortalColumns();
					}
					_isAllowedPortalColumnsInitialized = true;
				}

				return _allowedPortalColumns;
			}
		}

		#endregion

		#region Constructor: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public GlobalSearchSSPHelper(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Methods: Private

		private bool IsAllowedEntity(string entityName) {
			EntitySchema schema = UserConnection.EntitySchemaManager.FindInstanceByName(entityName);
			if (schema == null) {
				return false;
			}
			var findEntity = SysSchemaSSPList.Find(e => e == schema.UId);
			return !findEntity.Equals(Guid.Empty);
		}

		private List<Guid> GetSSPSysSchemaUId() {
			List<Guid> sysSchemaList = new List<Guid>();
			var sysSchemaSelectQuery = GetSysModuleEntitySelectQuery();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = sysSchemaSelectQuery.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var sysSchemaUId = UserConnection.DBTypeConverter.DBValueToGuid(dataReader["SysEntitySchemaUId"]);
						var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByUId(sysSchemaUId);
						if (entitySchema != null && GetIsLicensedEntity(entitySchema.Name)) {
							sysSchemaList.Add(sysSchemaUId);
						}
					}
				}
			}
			return sysSchemaList;
		}

		private Select GetSysModuleEntitySelectQuery() {
			return new Select(UserConnection).Distinct()
				.Column("SysModuleEntity", "SysEntitySchemaUId")
				.From("SysModuleInWorkplace").As("SysModuleInWorkplace")
				.Join(JoinType.Inner, "SysModule").As("SysModule")
				.On("SysModule", "Id").IsEqual("SysModuleInWorkplace", "SysModuleId")
				.Join(JoinType.Inner, "SysModuleEntity").As("SysModuleEntity")
				.On("SysModuleEntity", "Id").IsEqual("SysModule", "SysModuleEntityId")
				.Where("SysModuleInWorkplace", "SysWorkplaceId").In(GetWorkplaceSelectQuery()) as Select;
		}

		private Select GetWorkplaceSelectQuery() {
			return new Select(UserConnection)
				.Column("Id")
				.From("SysWorkplace")
				.Where().Exists(
					new Select(UserConnection)
						.Column(Column.Const(1))
						.From("SysAdminUnitInWorkplace")
						.Where().Exists(
							new Select(UserConnection)
								.Column(Column.Const(1))
								.From("SysAdminUnitInRole")
								.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(CurrentUserId))
								.And("SysAdminUnitInRole", "SysAdminUnitRoleId")
								.IsEqual("SysAdminUnitInWorkplace", "SysAdminUnitId") as Select)
						.And("SysWorkplace", "Id")
						.IsEqual("SysAdminUnitInWorkplace", "SysWorkplaceId") as Select
				) as Select;
		}

		private void AddColumnToAllowedPortalColumns(Guid schemaUId, Guid columnUId) {
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByUId(schemaUId);
			var columnName = entitySchema?.Columns.FindByUId(columnUId)?.ColumnValueName;
			if (string.IsNullOrEmpty(columnName)) {
				return;
			}
			var schemaName = entitySchema.Name;
			if (_allowedPortalColumns.ContainsKey(schemaName)) {
				_allowedPortalColumns[schemaName].AddIfNotExists(columnName);
			} else {
				_allowedPortalColumns[schemaName] = new List<string> { "Id", columnName };
			}
		}

		private void InitializeAllowedPortalColumns() {
			_allowedPortalColumns = new ConcurrentDictionary<string, List<string>>();
			Select select = GetPortalAccessColumnSelect();
			select.ExecuteReader(dataReader => {
				var schemaUId = dataReader.GetColumnValue<Guid>("SchemaUId");
				var columnUId = dataReader.GetColumnValue<Guid>("ColumnUId");
				if (schemaUId.Equals(Guid.Empty) || columnUId.Equals(Guid.Empty)) {
					return;
				}
				AddColumnToAllowedPortalColumns(schemaUId, columnUId);
			});
			SetAllowedPortalColumnsToCache();
		}

		private Select GetPortalAccessColumnSelect() {
			return new Select(UserConnection)
						.Column("PortalSchemaAccessList", "SchemaUId")
						.Column("PortalColumnAccessList", "ColumnUId")
					.From("PortalSchemaAccessList").As("PortalSchemaAccessList")
					.LeftOuterJoin("PortalColumnAccessList").As("PortalColumnAccessList")
						.On("PortalColumnAccessList", "PortalSchemaListId")
						.IsEqual("PortalSchemaAccessList", "Id")
					.Where("PortalSchemaAccessList", "SchemaUId").Not().IsNull() as Select;
		}

		private ConcurrentDictionary<string, List<string>> GetAllowedPortalColumnsFromCache() {
			return UserConnection.ApplicationCache.WithLocalCaching()
						.GetValue<ConcurrentDictionary<string, List<string>>>(SSPSecurityEngine.AllowedPortalColumnsCacheKey);
		}

		private void SetAllowedPortalColumnsToCache() {
			UserConnection.ApplicationCache.WithLocalCaching()
				.SetOrRemoveValue(SSPSecurityEngine.AllowedPortalColumnsCacheKey, _allowedPortalColumns);
		}

		private bool HasColumnForPortalUser(string schemaName, string columnName) {
			return AllowedPortalColumns.ContainsKey(schemaName) && AllowedPortalColumns[schemaName].Contains(columnName);
		}

		private List<ESAggregation> GetSSPAllowedEsAggregations(List<ESAggregation> aggregations) {
			var groups = new List<ESAggregation>();
			if (aggregations.Any()) {
				groups = aggregations.FindAll(e => IsAllowedEntity(e.Type));
			}
			return groups;
		}

		private bool GetIsLicensedEntity(string entityName) {
			return UserConnection.DBSecurityEngine.GetIsAvailableOnSsp(entityName);
		}

		private IEnumerable<IGrouping<string, string>> GetAllowedEntitiesFromResponse(IEnumerable<IGrouping<string, string>> groups) {
			return groups.Where(e => IsAllowedEntity(e.Key));
		}

		private bool CanReadColumnSSPUser(string schemaName, EntitySchemaColumn column) {
			return HasColumnForPortalUser(schemaName, column.ColumnValueName) && CanReadColumn(schemaName, column);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get available column colection.
		/// </summary>
		/// <param name="entityName"> entity schema name.</param>
		/// <returns><see cref="IEnumerable<EntitySchemaColumn>"/>.</returns>
		protected override IEnumerable<EntitySchemaColumn> GetAvailableColumnsCollection(string entityName) {
			if (UsePortalSchemaAllowedColumns || !IsCurrentUserSSP) {
				return base.GetAvailableColumnsCollection(entityName);
			}

			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(entityName);
			return entitySchema.Columns
				.Where(x => CanReadColumnSSPUser(entityName, x));
		}

		/// <summary>
		/// Get aggregation groups.
		/// </summary>
		/// <param name="esAggsResponse"><see cref="ESAggregationResponse"/> instance. </param>
		/// <returns><see cref="List<ESAggregation>"/> collection elastic search aggregation.</returns>
		protected override List<ESAggregation> GetEsAggregationGroups(ESAggregationResponse esAggsResponse) {
			var groups = base.GetEsAggregationGroups(esAggsResponse);
			return IsCurrentUserSSP ? GetSSPAllowedEsAggregations(groups) : groups;
		}

		/// <summary>
		/// Get search response groups.
		/// </summary>
		/// <param name="esResponse"><see cref="ESSearchResponse"/> search response. </param>
		/// <returns><see cref="IEnumerable<IGrouping<string, string>>"/> grouped elastic search response.</returns>
		protected override IEnumerable<IGrouping<string, string>> GetEsSearchResponseGroups(ESSearchResponse esResponse) {
			var aggregationGroups = base.GetEsSearchResponseGroups(esResponse);
			return IsCurrentUserSSP ? GetAllowedEntitiesFromResponse(aggregationGroups) : aggregationGroups;
		}

		/// <summary>
		/// Add default score settings.
		/// </summary>
		/// <param name="functions">.</param>
		/// <param name="multiMatchQueries">.</param>
		protected override void ApplyDefaultScoreSettings(List<ESFunction> functions, List<ESMultiMatchQuery> multiMatchQueries) {
			if (!IsCurrentUserSSP) {
				base.ApplyDefaultScoreSettings(functions, multiMatchQueries);
			}
		}

		#endregion

	}

	#endregion

}
