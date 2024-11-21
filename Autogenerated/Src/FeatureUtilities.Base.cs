namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;

	#region Enum: FeatureStates

	/// <summary>
	/// Feature states.
	/// </summary>
	public enum FeatureState
	{
		/// <summary>
		/// Feature disabled.
		/// </summary>
		Disabled = 0,

		/// <summary>
		/// Feature enabled.
		/// </summary>
		Enabled = 1,

		/// <summary>
		/// Feature established.
		/// </summary>
		Established = 2
	}

	#endregion

	#region Class: FeatureUtilities

	/// <summary>
	/// Provides utilities methods for work with features.
	/// </summary>
	public static class FeatureUtilities
	{

		#region Constants: Private

		private const string FeaturesCacheGroupName = "FeaturesCache_{0}";
		private const string FeaturesCacheGroupItem = "FeatureInitializing_{0}_{1}";

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns list of <see cref="FeatureStateInfo"/> items for the <paramref name="featureId"/>.
		/// </summary>
		/// <param name="featureId">Identifier of the feature.</param>
		/// <param name="features">Collection of found features.</param>
		/// <param name="stateColumnName">Name of the state column.</param>
		/// <param name="adminUnitColumnName">Name of the admin unit column.</param>
		/// <returns>Feature states list.</returns>
		private static List<FeatureStateInfo> GetFeatureStatesInfo(Guid featureId, EntityCollection features,
			string stateColumnName, string adminUnitColumnName) {
			return (from feature in features
				where feature.PrimaryColumnValue == featureId
				select new FeatureStateInfo {
					Code = feature.GetTypedColumnValue<string>("Code"),
					State = feature.GetTypedColumnValue<int>(stateColumnName),
					SysAdminUnitId = feature.GetTypedColumnValue<Guid>(adminUnitColumnName)
				}).ToList();
		}

		/// <summary>
		/// Clears cache of the feature by <paramref name="code"/>.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		private static void ClearFeatureCache(this UserConnection source, string code) {
			var itemKey = string.Format(FeaturesCacheGroupItem, code, source.CurrentUser.Id);
			source.SessionCache.WithLocalCaching().SetOrRemoveValue(itemKey, null);
		}

		/// <summary>
		/// Returns feature identifier by <paramref name="code"/>.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <returns>Feature identifier.</returns>
		private static Guid GetFeatureByCode(this UserConnection source, string code) {
			var manager = source.EntitySchemaManager.GetInstanceByName("Feature");
			var entity = manager.CreateEntity(source);
			if (entity.FetchFromDB(new Dictionary<string, object> {
				{"Code", code}
			})) {
				return entity.PrimaryColumnValue;
			}
			return Guid.Empty;
		}

		private static Guid ExtractFeatureId(UserConnection source, string code) {
			source.ClearFeatureCache(code);
			var featureId = source.GetFeatureByCode(code);
			return featureId;
		}

		private static void SafeSetAdminUnitFeatureState(UserConnection source, Guid featureId, int state, bool forAllUsers) {
			var schema = source.EntitySchemaManager.GetInstanceByName("AdminUnitFeatureState");
			var esq = new EntitySchemaQuery(schema);
			esq.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem featureFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Feature", featureId);
			esq.Filters.Add(featureFilter);
			if (!forAllUsers) {
				IEntitySchemaQueryFilterItem sauFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"SysAdminUnit", source.CurrentUser.Id);
				esq.Filters.Add(sauFilter);
			}
			var existRows = esq.GetEntityCollection(source);
			if (existRows.Count == 0) {
				var entity = schema.CreateEntity(source);
				entity.SetDefColumnValues();
				entity.SetColumnValue("SysAdminUnitId", source.CurrentUser.Id);
				entity.SetColumnValue("FeatureId", featureId);
				existRows.Add(entity);
			}
			foreach (var sauFeatureState in existRows) {
				sauFeatureState.SetColumnValue("FeatureState", state);
				sauFeatureState.Save();
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns feature state by <paramref name="code"/>.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <returns>State of feature.</returns>
		public static int GetFeatureState(this UserConnection source, string code) {
			var currentUser = source.CurrentUser;
			if (currentUser == null) {
				return (int)FeatureState.Disabled;
			}
			var cacheGroupName = string.Format(FeaturesCacheGroupName, "AdminUnitFeatureState");
			var cacheItemName = string.Format(FeaturesCacheGroupItem, code, currentUser.Id);
			var cacheStore = source.SessionCache.WithLocalCaching(cacheGroupName);
			if (cacheStore[cacheItemName] is int cachedValue) {
				return cachedValue;
			}
			var select = (Select)new Select(source).Top(1)
					.Column("AdminUnitFeatureState", "FeatureState")
				.From("AdminUnitFeatureState")
				.InnerJoin("Feature").On("Feature", "Id").IsEqual("AdminUnitFeatureState", "FeatureId")
				.InnerJoin("SysAdminUnitInRole").On("SysAdminUnitInRole", "SysAdminUnitRoleId")
					.IsEqual("AdminUnitFeatureState", "SysAdminUnitId")
				.Where("Feature", "Code").IsEqual(Column.Parameter(code))
					.And("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(currentUser.Id))
				.OrderByDesc("AdminUnitFeatureState", "FeatureState");
			var value = select.ExecuteScalar<int>();
			cacheStore[cacheItemName] = value;
			return value;
		}

		/// <summary>
		/// Returns sign that feature is enabled by <paramref name="code"/> for any user.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <returns><c>True</c> if feature enabled for any user. Returns <c>false</c> otherwise.</returns>
		public static bool GetIsFeatureEnabledForAnyUser(this UserConnection source, string code) {
			var esq = new EntitySchemaQuery(source.EntitySchemaManager, "AdminUnitFeatureState");
			var stateColumn = esq.AddColumn("FeatureState");
			stateColumn.OrderByDesc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Feature.Code", code));
			var collection = esq.GetEntityCollection(source);
			foreach (var entity in collection) {
				var state = entity.GetTypedColumnValue<int>("FeatureState");
				if (state == 1) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Returns all feature states.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <returns>List of features.</returns>
		public static Dictionary<string, int> GetFeatureStates(this UserConnection source) {
			var esq = new EntitySchemaQuery(source.EntitySchemaManager, "Feature");
			esq.AddColumn("Name");
			esq.AddColumn("Code");
			var stateColumn = esq.AddColumn("[AdminUnitFeatureState:Feature].FeatureState");
			stateColumn.OrderByDesc();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[AdminUnitFeatureState:Feature].[SysAdminUnitInRole:SysAdminUnitRoleId:SysAdminUnit].SysAdminUnit",
				source.CurrentUser.Id));
			var collection = esq.GetEntityCollection(source);
			var result = new Dictionary<string, int>();
			foreach (var entity in collection) {
				string code = entity.GetTypedColumnValue<string>("Code");
				int state = entity.GetTypedColumnValue<int>(stateColumn.Name);
				if (result.ContainsKey(code)) {
					continue;
				}
				result.Add(code, state);
			}
			return result;
		}

		/// <summary>
		/// Returns info about all features and their states.
		/// </summary>
		/// <param name="source"><see cref="UserConnection"/> instance.</param>
		/// <returns>Information about features and their states.</returns>
		public static List<FeatureInfo> GetFeaturesInfo(this UserConnection source) {
			var result = new List<FeatureInfo>();
			var esq = new EntitySchemaQuery(source.EntitySchemaManager, "Feature");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Code");
			esq.AddColumn("Name");
			esq.AddColumn("Description");
			esq.AddColumn("ModifiedOn").OrderByDesc();
			var stateColumn = esq.AddColumn("[AdminUnitFeatureState:Feature].FeatureState");
			var adminUnitColumn = esq.AddColumn("[AdminUnitFeatureState:Feature].SysAdminUnit.Id");
			var collection = esq.GetEntityCollection(source);
			if (collection.Count > 0) {
				foreach (var entity in collection) {
					if (result.All(f => f.Id != entity.PrimaryColumnValue)) {
						var featureInfo = new FeatureInfo {
							Id = entity.PrimaryColumnValue,
							Name = entity.GetTypedColumnValue<string>("Name"),
							Code = entity.GetTypedColumnValue<string>("Code"),
							Description = entity.GetTypedColumnValue<string>("Description"),
							StatesInfo = GetFeatureStatesInfo(entity.PrimaryColumnValue, collection, stateColumn.Name,
								adminUnitColumn.Name)
						};
						featureInfo.ActualizeFeatureState(source);
						result.Add(featureInfo);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Sets feature state.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		/// <param name="forAllUsers">If defined as true state will be updated for all users</param>
		public static void SetFeatureState(this UserConnection source, string code, int state,
				bool forAllUsers = false) {
			Guid featureId = ExtractFeatureId(source, code);
			SafeSetAdminUnitFeatureState(source, featureId, state, forAllUsers);
		}

		/// <summary>
		/// Create Feature if it does not exist and sets feature state.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <param name="state">New feature state.</param>
		/// <param name="forAllUsers">If defined as true state will be updated for all users</param>
		public static void SafeSetFeatureState(this UserConnection source, string code, int state,
				bool forAllUsers = false) {
			Guid featureId = ExtractFeatureId(source, code);
			if (featureId == Guid.Empty) {
				source.CreateFeature(code, code, String.Empty);
				featureId = ExtractFeatureId(source, code);
			}
			SafeSetAdminUnitFeatureState(source, featureId, state, forAllUsers);
		}

		/// <summary>
		/// Creates feature.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <param name="name">Feature name.</param>
		/// <param name="description">Feature description.</param>
		public static void CreateFeature(this UserConnection source, string code, string name, string description) {
			var manager = source.EntitySchemaManager.GetInstanceByName("Feature");
			var entity = manager.CreateEntity(source);
			if (!entity.FetchFromDB(new Dictionary<string, object> {
				{"Code", code}
			})) {
				entity.SetDefColumnValues();
				entity.SetColumnValue("Code", code);
				entity.SetColumnValue("Name", name);
				entity.SetColumnValue("Description", description);
				entity.Save();
			}
		}

		/// <summary>
		/// Checks is feature enabled.
		/// </summary>
		/// <param name="source">User connection.</param>
		/// <param name="code">Feature code.</param>
		/// <returns>Is feature enabled flag.</returns>
		public static bool GetIsFeatureEnabled(this UserConnection source, string code) {
			var featureState = source.GetFeatureState(code);
			return featureState == (int)FeatureState.Enabled;
		}

		#endregion

	}

	#endregion

}
