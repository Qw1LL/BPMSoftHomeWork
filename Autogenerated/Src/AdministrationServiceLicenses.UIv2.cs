namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using Newtonsoft.Json;
	using LicType = BPMSoft.Core.Configuration.SysLicType;
	
	#region Class: LicenseItem
	public class LicenseItem
	{
		/// <summary>
		/// ############# ###### ########.
		/// </summary>
		public Guid Id {
			get;
			set;
		}

		/// <summary>
		/// ### ########.
		/// </summary>
		public LicType Type {
			get;
			set;
		}

		/// <summary>
		/// ######## ###### ########.
		/// </summary>
		public string Caption {
			get;
			set;
		}

		/// <summary>
		/// #######, ######## ## ######## ### ######.
		/// </summary>
		public bool Enabled {
			get;
			set;
		}

		/// <summary>
		/// #######, ####### ## ########.
		/// </summary>
		public bool Checked {
			get;
			set;
		}

		/// <summary>
		/// ########## ######### ########.
		/// </summary>
		public int AvailableCount {
			get;
			set;
		}

		/// <summary>
		/// ########## ########## ########.
		/// </summary>
		public int PaidCount {
			get;
			set;
		}

		/// <summary>
		/// ########## ######### ########.
		/// </summary>
		public int UsedCount {
			get;
			set;
		}
	}
	#endregion

	#region Class: AdministrationService
	public partial class AdministrationService
	{
		#region Properties: Private

		private EntityCollection _availablePackages;
		/// <summary>
		/// ###### ######### ##############, ######### ############ #######.
		/// </summary>
		private EntityCollection AvailablePackages {
			get {
				return _availablePackages ?? (_availablePackages = UserConnection.LicHelper.GetAvailablePackages());
			}
		}

		#endregion Properties: Private

		#region Methods: Private

		/// <summary>
		/// ########## #######, ####### ## ############.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <returns>####### "Active" ### ###### # ####### SysAdminUnit,
		/// ########## ## userId.</returns>
		private bool IsUserActive(Guid userId) {
			Select selectIsActiveUser =
				new Select(UserConnection)
				.Column("Active")
				.From("SysAdminUnit")
				.Where("Id").IsEqual(Column.Parameter(userId))
				as Select;
			return selectIsActiveUser.ExecuteScalar<bool>();
		}

		/// <summary>
		/// ######### ############ #######.
		/// </summary>
		/// <param name="obj">######, ####### ########## ###############.</param>
		/// <param name="quoteName">#######, ############ ### ### ####### # ###### #######.</param>
		/// <returns>############### ######.</returns>
		private static string Serialize(object obj, bool quoteName) {
			using (var sw = new StringWriter(CultureInfo.InvariantCulture)) {
				using (var writer = new JsonTextWriter(sw) {
					QuoteName = quoteName
				}) {
					var serializer = new JsonSerializer();
					serializer.Serialize(writer, obj);
				}
				return sw.GetStringBuilder().ToString();
			}
		}

		/// <summary>
		/// #########, #### ## # ############ ###### ########.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="licPackageId">############# ###### ########.</param>
		/// <returns>######, #### # ############ #### ###### ########, ##### ####.</returns>
		private bool GetUserHasLicense(Guid userId, Guid licPackageId) {
			var sysLicUserSchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysLicUser");
			EntitySchemaQueryColumn countColumn = sysLicUserSchemaQuery.AddColumn("Id");
			countColumn.SummaryType = AggregationType.Count;
			IEntitySchemaQueryFilterItem userIdFilter = sysLicUserSchemaQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysUser", userId);
			IEntitySchemaQueryFilterItem sysPackageIdFilter = sysLicUserSchemaQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysLicPackage", licPackageId);
			var filter = new EntitySchemaQueryFilterCollection(sysLicUserSchemaQuery, LogicalOperationStrict.And,
				userIdFilter, sysPackageIdFilter);
			sysLicUserSchemaQuery.Filters.Add(filter);
			Entity summary = sysLicUserSchemaQuery.GetSummaryEntity(UserConnection);
			return (summary != null) ? summary.GetTypedColumnValue<int>(countColumn.Name) > 0 : false;
		}

		/// <summary>
		/// ######### ######### ########## ######## # ########.
		/// </summary>
		/// <param name="sysLicPackageGuid">############# ######## ##############.</param>
		/// <returns>######## ########, #### ########## ############ ########
		/// ######## ######### ######### ##########, ### ###### ######, # ######### ######.</returns>
		private string HasLicErrors(Guid sysLicPackageGuid) {
			var sb = new StringBuilder();
			foreach (Entity item in AvailablePackages) {
				Guid sysLicPackageId = item.GetTypedColumnValue<Guid>("SysLicPackageId");
				if (sysLicPackageId == sysLicPackageGuid) {
					string operations = item.GetTypedColumnValue<string>("Operations");
					SysLicType licType = item.GetTypedColumnValue<SysLicType>("LicType");
					if (!operations.Contains("IsServerLicPackage") && licType == SysLicType.Personal &&
						item.GetTypedColumnValue<int>("PersonalLicCount") >=
						item.GetTypedColumnValue<int>("Count")) {
						sb.AppendIfNotEmpty(", ");
						sb.Append(item.GetTypedColumnValue<string>("SysPackageName"));
					}
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Adds user package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void AddSysLicUser(Guid userId, Guid sysPackageId) {
			UserConnection.AppConnection.LicManager.AddUserLicense(UserConnection, userId, sysPackageId);
		}

		/// <summary>
		/// Deletes user package license.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="sysPackageId">Licensing package identifier.</param>
		private void DeleteSysLicUser(Guid userId, Guid sysPackageId) {
			UserConnection.AppConnection.LicManager.DeleteUserLicense(UserConnection, userId, sysPackageId);
		}
		
		/// <summary>
		/// ####### ######### ### ######### ########## ########, 
		/// ######### #############.
		/// </summary>
		/// <returns>######### ### ######### ########## ######### ########.</returns>
		private Select GenerateSelectForCase() {
			 return 
				new Select(UserConnection)
					.Column(Func.Count("SysLicUser", "Id"))
				.From("SysLicUser")
				.InnerJoin("SysAdminUnit")
					.On("SysAdminUnit", "Id").IsEqual("SysLicUser", "SysUserId")
				.Where("lic", "SysLicPackageId").IsEqual("SysLicPackageId")
				.And("SysLicUser", "Active").IsEqual(Column.Parameter(true))
				.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true)) as Select;
		}

		/// <summary>
		/// ####### ####### ### CASE, # ####### ########### c######## ############ 
		/// ######### ## ######### #######.
		/// </summary>
		/// <param name="columnExpression">########, ############# # ##### ##### 
		/// #########.</param>
		/// <returns>####### ######## ######### ######### ## ######### 
		/// #######.</returns>
		private QueryCondition CreateQueryCondition(QueryColumnExpression columnExpression) {
			var queryCondition = new QueryCondition(QueryConditionType.Greater) {
				LeftExpression = columnExpression
			};
			queryCondition.IsEqual(Column.Const(1));
			return queryCondition;
		}
		
		/// <summary>
		/// ########## ######### CASE ## ######### ########### ##########.
		/// </summary>
		/// <param name="conditionForCaseExpression">########, ############# 
		/// # ##### ##### ####### WHEN.</param>
		/// <param name="expressionForThenInCase">#########, ####### ##### 
		/// ######### # ##### THEN.</param>
		/// <param name="expressionForElseInCase">#########, ####### ##### 
		/// ######### # ##### ELSE.</param>
		/// <returns>######### CASE.</returns>
		private QueryCase GenerateCaseForLicQuery(QueryColumnExpression conditionForCaseExpression, 
				QueryColumnExpression expressionForThenInCase, QueryColumnExpression expressionForElseInCase) {
			var queryCase = new QueryCase();
			QueryCondition queryCondition = CreateQueryCondition(conditionForCaseExpression);
			queryCase.AddWhenItem(queryCondition, expressionForThenInCase);
			queryCase.SetElseExpression(expressionForElseInCase);
			return queryCase;
		}

		/// <summary>
		/// ########## ######### CASE ### ######### ########## ######### ########.
		/// </summary>
		/// <returns>######### CASE.</returns>
		private QueryCase GenerateCaseForAvailableLic() {
			Select selectForCase = GenerateSelectForCase();
			return GenerateCaseForLicQuery(new QueryColumnExpression("lic", "LicType"),
				new QueryColumnExpression("lic", "Count"),
				new QueryColumnExpression(ArithmeticOperation.Subtraction, 
					new QueryColumnExpression("lic", "Count"),
					Column.SubSelect(selectForCase)));
		}
		
		/// <summary>
		/// ########## ######### CASE, ##### ########, ####### ## ####### ######## ### 
		/// ######## ############.
		/// </summary>
		/// <param name="userId">############# ############, ### ######## ## #########
		/// ####### ########.</param>
		/// <returns>######### CASE.</returns>
		private QueryCase GenerateCaseForHadLic(Guid userId) {
			Select selectForCase = GenerateSelectForCase();
			selectForCase
				.And("SysUserId").IsEqual(Column.Parameter(userId));
			return GenerateCaseForLicQuery(new QueryColumnExpression(selectForCase),
				Column.Const(1), Column.Const(0));
		}

		/// <summary>
		/// Returns list of available licenses with license amount 
		/// and presence information for target user.
		/// </summary>
		/// <param name="userId">User identifier.</param>
		/// <param name="isNew">Indicates if user is new or not.</param>
		/// <returns>Licenses list.</returns>
		private EntityCollection GetAvaliableLic(Guid userId, bool isNew) {
			QueryCase caseForAvailable = GenerateCaseForAvailableLic();
			var select =
				new Select(UserConnection)
					.Column("SysLicPackageId")
					.Column("Count").As("Purchased")
					.Column(Column.SubSelect(GenerateSelectForCase())).As("Used")
					.Column(caseForAvailable).As("Available")
					.Column("licPackage", "Name").As("SysPackageName")
					.Column("licPackage", "Operations").As("PackageOperations")
					.Column("LicType")
				.From("SysLic").As("lic")
				.InnerJoin("SysLicPackage").As("licPackage").On("lic", "SysLicPackageId").IsEqual("licPackage", "Id")
				.Where(new QueryParameter(DateTime.Now.Date)).IsBetween("StartDate").And("DueDate")
				.OrderByAsc("licPackage", "Name").OrderByDesc("lic", "DueDate") as Select;
			if (!isNew) {
				QueryCase caseForHadLic = GenerateCaseForHadLic(userId);
				select
					.Column(caseForHadLic).As("HadLicense");
			}
			EntitySchema licSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysLic");
			var result = new EntityCollection(UserConnection, licSchema);
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (System.Data.IDataReader reader = select.ExecuteReader(executor)) {
					result.Load(reader);
				}
			}
			return result;
		}
		#endregion

		#region Methods: Public
		/// <summary>
		/// ###### ###### ####### ######## ### ############.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <returns>############### ###### ######## ########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAvailableLicPackages", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetAvailableLicPackages(string userId) {
			var collection = new List<LicenseItem>();
			var recordId = new Guid(userId);
			bool isNew = (recordId == Guid.Empty);
			EntityCollection result = GetAvaliableLic(recordId, isNew);
			bool isActive = isNew || IsUserActive(recordId);
			bool canManageLicUsers = UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageLicUsers");
			foreach (Entity licPackage in result) {
				Guid licPackageId = licPackage.GetTypedColumnValue<Guid>("SysLicPackageId");
				string licPackageName = licPackage.GetTypedColumnValue<string>("SysPackageName");
				int availableLicensesCount = licPackage.GetTypedColumnValue<int>("Available");
				bool userInitiallyHadLicense = isNew ? false : licPackage.GetTypedColumnValue<int>("HadLicense") == 1;
				LicType licType;
				string packageOperations = licPackage.GetTypedColumnValue<string>("PackageOperations");
				if (packageOperations.Contains("IsServerLicPackage")) {
					licType = LicType.Server;
				} else {
					licType = licPackage.GetTypedColumnValue<LicType>("LicType");
				}
				bool isEnabled = false, isChecked = false;
				if (isActive) {
					isEnabled = (canManageLicUsers && (userInitiallyHadLicense || availableLicensesCount > 0 
						|| licType == LicType.Server));
					isChecked = (userInitiallyHadLicense || (isNew && availableLicensesCount > 0 &&
						UserConnection.GetIsFeatureEnabled("EnableNewUserLicensing")));
				}
				var licItem = new LicenseItem {
					Id = licPackageId,
					Type = licType,
					Caption = licPackageName,
					Enabled = isEnabled,
					Checked = isChecked,
					AvailableCount = availableLicensesCount,
					PaidCount = licPackage.GetTypedColumnValue<int>("Purchased"),
					UsedCount = licPackage.GetTypedColumnValue<int>("Used")
				};
				collection.Add(licItem);
			}
			collection = collection.GroupBy(i => i.Id).Select(o => o.First()).ToList();
			return Serialize(collection, true);
		}

		/// <summary>
		/// ########## ######## ############.
		/// </summary>
		/// <param name="userId">############# ############.</param>
		/// <param name="licenseItems">############### #######, ### #### - ### ############# ########,
		/// # ######## - ####### ####, ### ######## #######.</param>
		/// <returns>##### ###### ########## ########## ######## ### ###### ######,
		/// #### ########## ## #########.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateLicenseInfo", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string UpdateLicenseInfo(string userId, string licenseItems) {
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLicUsers");
				Dictionary<string, bool> licenses = Json.Deserialize<Dictionary<string, bool>>(licenseItems);
				var sb = new StringBuilder();
				foreach (KeyValuePair<string, bool> licItem in licenses) {
					var userGuid = new Guid(userId);
					var sysPackageGuid = new Guid(licItem.Key);
					bool userHasLicense = GetUserHasLicense(userGuid, sysPackageGuid);
					if (licItem.Value && !userHasLicense) {
						string errors = HasLicErrors(sysPackageGuid);
						if (errors.Length > 0) {
							sb.Append(errors);
						} else {
							AddSysLicUser(userGuid, sysPackageGuid);
						}
					}
					if (!licItem.Value && userHasLicense) {
						DeleteSysLicUser(userGuid, sysPackageGuid);
					}
				}
				if (sb.Length > 0) {
					return string.Format(
						new LocalizableString("BPMSoft.WebApp.Loader", "LicManager.PaidLicenseCountExceededMessage"),
						sb);
				}
			} catch (Exception e) {
				return e.Message;
			}
			return string.Empty;
		}
		#endregion Methods: Public
	}
	#endregion Class: AdministrationService
}


