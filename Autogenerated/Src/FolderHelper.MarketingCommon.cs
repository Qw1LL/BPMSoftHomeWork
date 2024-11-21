using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BPMSoft.Common.Json;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.Nui.ServiceModel.Extensions;

namespace BPMSoft.Configuration
{
	#region Class: FolderHelper

	/// <summary>
	/// Utility class that contains helper methods to operate with ContactFolder schema.
	/// </summary>
	public class FolderHelper
	{

		#region Enum: Private

		/// <summary>
		/// Optimization type enum.
		/// </summary>
		private enum OptimizationType {
			Count = 1,
			CountAndData = 3,
			AppliedCountTryData = 6
		}

		#endregion

		#region Methods : Private

		/// <summary>
		/// Returns folder information.
		/// </summary>
		/// <param name="folderSchemaName">Folder table name.</param>
		/// <param name="folderId">Unique identifier of the folder.</param>
		/// <param name="userConnection">User connection.</param>
		/// <param name="ignoreRights">True when ignores user rights.</param>
		/// <returns>Folder info entity.</returns>
		private static Entity GetFolderInfo(string folderSchemaName, Guid folderId, UserConnection userConnection, bool ignoreRights) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, folderSchemaName);
			esq.AddColumn("SearchData").Name = "SearchData";
			esq.AddColumn("FolderType.Id").Name = "FolderTypeId";
			esq.AddColumn("OptimizationType").Name = "OptimizationType";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, false, "Id", folderId));
			if (ignoreRights) {
				esq.JoinRightState = QueryJoinRightLevel.Disabled;
			}
			EntityCollection entities = esq.GetEntityCollection(userConnection);
			if (entities.Count == 0) {
				return null;
			}
			return entities[0];
		}

		private FolderInfoModel GetFolderInfoModel(string folderSchemaName, Guid folderId,
				UserConnection userConnection, bool ignoreRights) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, folderSchemaName);
			esq.AddColumn("SearchData").Name = "SearchData";
			esq.AddColumn("Name").Name = "Name";
			esq.UseAdminRights = !ignoreRights;
			var folderEntity = esq.GetEntity(userConnection, folderId);
			if (folderEntity == null) {
				return null;
			}
			string searchDataStr = string.Empty;
			byte[] searchData = folderEntity.GetBytesValue("SearchData");
			if (searchData != null && searchData.Length != 0) {
				searchDataStr = Encoding.UTF8.GetString(searchData);
			}
			return new FolderInfoModel {
				Id = folderId,
				DisplayValue = folderEntity.GetTypedColumnValue<string>("Name"),
				SearchData = searchDataStr,
				FolderSchemaName = folderSchemaName,
				EntitySchemaName = GetFolderEntitySchemaName(folderSchemaName)
			};
		}

		private static EntitySchemaQuery GetFolderESQ(string schemaName, string folderSchemaName, Guid folderId,
				UserConnection userConnection) {
			EntitySchemaQuery result;
			Entity folderInfoEntity = GetFolderInfo(folderSchemaName, folderId, userConnection, false);
			if (folderInfoEntity == null) {
				return null;
			}
			Guid folderTypeId = folderInfoEntity.GetTypedColumnValue<Guid>("FolderTypeId");
			if (folderTypeId == MarketingConsts.FolderTypeDynamicId) {
				byte[] searchData = folderInfoEntity.GetBytesValue("SearchData");
				if (searchData == null || searchData.Length == 0) {
					return null;
				}
				result = GetDynamicFolderESQ(schemaName, searchData, userConnection);
				if (userConnection.GetIsFeatureEnabled("UseQueryOptimize")) {
					var optimizarionType = folderInfoEntity.GetTypedColumnValue<int>("OptimizationType");
					result.QueryOptimize = GetQueryOptimize((OptimizationType)optimizarionType);
				}
			} else {
				result = GetStaticFolderESQ(schemaName, folderId, userConnection, out var recordIdColumn);
			}
			return result;
		}

		private static bool GetQueryOptimize(OptimizationType type) {
			return Enum.IsDefined(typeof(OptimizationType), type);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Extracts an entity schema name from the folder schema name.
		/// </summary>
		/// <returns>Entity schema name or <see cref="string.Empty"/>.</returns>
		public static string GetFolderEntitySchemaName(string folderSchemaName) {
			if (string.IsNullOrWhiteSpace(folderSchemaName) || folderSchemaName.Length <= 6) {
				return string.Empty;
			}
			return folderSchemaName.Remove(folderSchemaName.Length - 6);
		}

		/// <summary>
		///Returns query to get records srored in static folder
		/// </summary>
		/// <param name="objectName">Entity schema name</param>
		/// <param name="folderId">Unique id of the folder</param>
		/// <param name="userConnection">Connection</param>
		public static Select GetStaticFolderContentSelect(
				string objectName, Guid folderId, UserConnection userConnection) {
			if (folderId.Equals(Guid.Empty) || string.IsNullOrEmpty(objectName)) {
				return null;
			}
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, objectName + "InFolder");
			esq.AddColumn(string.Format("{0}.Id", objectName));
			IEntitySchemaQueryFilterItem folderFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Folder", folderId);
			esq.Filters.Add(folderFilter);
			esq.IsDistinct = true;
			return esq.GetSelectQuery(userConnection);
		}

		/// <summary>
		///Returns entity schema query to get records srored in static folder
		/// </summary>
		/// <param name="objectName">Entity schema name</param>
		/// <param name="folderId">Unique id of the folder</param>
		/// <param name="userConnection">Connection</param>
		/// <param name="recordIdColumn">Column with record identifier</param>
		public static EntitySchemaQuery GetStaticFolderESQ(string objectName, Guid folderId,
				UserConnection userConnection, out EntitySchemaQueryColumn recordIdColumn) {
			var ESQ = new EntitySchemaQuery(userConnection.EntitySchemaManager, objectName + "InFolder");
			ESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			recordIdColumn = ESQ.AddColumn(objectName);
			IEntitySchemaQueryFilterItem folderFilter =
				ESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Folder", folderId);
			ESQ.Filters.Add(folderFilter);
			ESQ.IsDistinct = true;
			return ESQ;
		}

		/// <summary>
		///Returns entity schema query to get records srored in dynamic folder
		/// </summary>
		/// <param name="objectName">Entity schema name</param>
		/// <param name="searchData">Byte array which represent serialized search data for dynamic folder query</param>
		/// <param name="userConnection">Connection</param>
		/// <param name="recordIdColumn">Column with record identifier</param>
		public static EntitySchemaQuery GetDynamicFolderESQ(string objectName, byte[] searchData,
				UserConnection userConnection, out EntitySchemaQueryColumn recordIdColumn) {
			var ESQ = new EntitySchemaQuery(userConnection.EntitySchemaManager, objectName);
			recordIdColumn = ESQ.AddColumn(ESQ.RootSchema.GetPrimaryColumnName());
			IEntitySchemaQueryFilterItem filters =
				CommonUtilities.ConvertClientFilterDataToEsqFilters(userConnection, searchData, ESQ.RootSchema.UId);
			CommonUtilities.DisableEmptyEntitySchemaQueryFilters(new[] { filters });
			if (filters != null) {
				ESQ.Filters.Add(filters);
			}
			return ESQ;
		}

		/// <summary>
		/// Returns entity schema query to get records stored in dynamic folder.
		/// </summary>
		/// <param name="schemaName">Entity schema name.</param>
		/// <param name="searchData">Byte array which represent serialized search data for dynamic folder query.</param>
		/// <param name="userConnection">Connection.</param>
		/// <returns>Entity schema query instance with deserialized filters.</returns>
		public static EntitySchemaQuery GetDynamicFolderESQ(string schemaName, byte[] searchData,
				UserConnection userConnection) {
			var selectQuery = new Nui.ServiceModel.DataContract.SelectQuery {
				RootSchemaName = schemaName,
				Filters = Json.Deserialize<Nui.ServiceModel.DataContract.Filters>(Encoding.UTF8.GetString(searchData,
					0, searchData.Length))
			};
			var esq = selectQuery.BuildEsq(userConnection);
			CommonUtilities.DisableEmptyEntitySchemaQueryFilters(new[] { esq.Filters });
			return esq;
		}

		/// <summary>
		/// Returns query to get contacts from folder.
		/// </summary>
		/// <param name="schemaName">Root schema name.</param>
		/// <param name="folderSchemaName">Root folder schema name.</param>
		/// <param name="folderRecordId">Unique identifier of the folder.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Select instance for get contacts from folder.</returns>
		public static Select GetFolderSelect(string schemaName, string folderSchemaName, Guid folderRecordId,
				UserConnection userConnection) {
			EntitySchemaQuery folderESQ = GetFolderESQ(schemaName, folderSchemaName, folderRecordId, userConnection);
			if (folderESQ == null) {
				return null;
			}
			return folderESQ.GetSelectQuery(userConnection);
		}

		/// <summary>
		/// Wrapper for the <see cref="FolderHelper.GetFolderSelect(string, string, Guid, UserConnection)"/> method.
		/// Is used only for Mock props.
		/// </summary>
		public virtual Select GetFolderSelectV2(string schemaName, string folderSchemaName, Guid folderRecordId,
				UserConnection userConnection) {
			EntitySchemaQuery folderESQ = GetFolderESQ(schemaName, folderSchemaName, folderRecordId, userConnection);
			if (folderESQ == null) {
				return null;
			}
			folderESQ.UseAdminRights = false;
			return folderESQ.GetSelectQuery(userConnection);
		}

		/// <summary>
		/// Returns true when search data has filters and filters aren't disabled.
		/// </summary>
		/// <param name="schemaName">Root schema name.</param>
		/// <param name="searchData">Folder search data.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>True when search data has filter.</returns>
		public virtual bool CheckSearchDataHasFilter(string schemaName, byte[] searchData,
				UserConnection userConnection) {
			if (searchData == null || searchData.Length == 0) {
				return false;
			}
			var foldersQuery = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
			IEntitySchemaQueryFilterItem filters = CommonUtilities.ConvertClientFilterDataToEsqFilters(userConnection,
				searchData, foldersQuery.RootSchema.UId);
			CommonUtilities.DisableEmptyEntitySchemaQueryFilters(new[] { filters });
			if (!filters.GetFilterInstances().Any()) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns folders information by Select query ignoring user rights.
		/// </summary>
		/// <param name="folderSchemaName">Folder table name.</param>
		/// <param name="folderIds">Unique identifiers of the folders.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Collection of folder information containers.</returns>
		public virtual List<FolderInfoModel> GetFoldersInfo(string folderSchemaName, List<Guid> folderIds, UserConnection userConnection) {
			List<FolderInfoModel> foldersInfo = new List<FolderInfoModel>();
			Select selectQuery = new Select(userConnection)
				.Column("Id")
				.Column("Name")
				.Column("SearchData")
				.Column("FolderTypeId")
				.From(folderSchemaName)
				.Where("Id")
				.In(Column.Parameters(folderIds)) as Select;
			DBTypeConverter dbTypeConverter = userConnection.DBTypeConverter;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					var nameColumnIndex = reader.GetOrdinal("Name");
					var searchDataColumnIndex = reader.GetOrdinal("SearchData");
					while (reader.Read()) {
						Guid folderId = dbTypeConverter.DBValueToGuid(reader["Id"]);
						string displayValue = reader.GetString(nameColumnIndex);
						Guid typeId = dbTypeConverter.DBValueToGuid(reader["FolderTypeId"]);
						byte[] searchData = reader.GetValue(searchDataColumnIndex) as byte[];
						var folderInfo = new FolderInfoModel {
							Id = folderId,
							DisplayValue = displayValue,
							SearchDataBin = searchData,
							TypeId = typeId,
							FolderSchemaName = folderSchemaName,
							EntitySchemaName = GetFolderEntitySchemaName(folderSchemaName)
						};
						foldersInfo.Add(folderInfo);
					}
				}
			}
			return foldersInfo;
		}

		/// <summary>
		/// Gets folder data info.
		/// </summary>
		/// <param name="schemaName">Root folder schema name.</param>
		/// <param name="folderId">The folder identifier.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Folder data info.</returns>
		public virtual FolderInfoModel GetFolderInfo(string schemaName, Guid folderId, UserConnection userConnection) {
			return GetFolderInfoModel(schemaName, folderId, userConnection, true);
		}

		#endregion

	}

	#endregion

	#region Class: FolderInfoModel

	/// <summary>
	/// Folder info container.
	/// </summary>
	public class FolderInfoModel
	{
		/// <summary>
		/// Unique identifier of current folder.
		/// </summary>
		public Guid Id {
			get;
			set;
		}

		/// <summary>
		/// Text value to display.
		/// </summary>
		public string DisplayValue {
			get;
			set;
		}

		/// <summary>
		/// Json representation of binary search data.
		/// </summary>
		public string SearchData {
			get;
			set;
		}

		/// <summary>
		/// The binary representation of search data.
		/// </summary>
		public byte[] SearchDataBin {
			get;
			set;
		}

		/// <summary>
		/// Unique identifier of folder type.
		/// </summary>
		public Guid TypeId {
			get;
			set;
		}

		/// <summary>
		/// Name of folder schema, like ContactFolder or LeadFolder etc.
		/// </summary>
		public string FolderSchemaName {
			get;
			set;
		}

		/// <summary>
		/// Name of folder's entity schema, like Contact or Lead etc.
		/// </summary>
		public string EntitySchemaName {
			get;
			set;
		}
	}

	#endregion

}

