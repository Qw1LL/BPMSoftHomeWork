namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Store;
	using BPMSoft.Nui;
	using BPMSoft.UI.WebControls;
	using BPMSoft.Web.Http.Abstractions;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: ConfigurationSectionHelper

	public class ConfigurationSectionHelper : ISectionHelper
	{

		#region Constants: Private

		private const string WorkplaceCacheKeyTemplate = "SysWorkplaceId_{0}";
		private const string SysWorkspaceIdParameterName = "SysWorkspaceId";
		private const string GuidTypeName = "Guid";
		private const string LocalCacheGroupName = "LoginLocalCache";
		private const string LocalCacheKeyTemplate = "ConfigurationScript_{0}_{1}";
		private const string RootSchemaDescriptors = "RootSchemaDescriptors";
		private const string IsFirstLoginKey = "IsFirstLogin";
		private const string MiniPageAddModeCode = "Has{0}MiniPageAddMode";

		#endregion

		#region Fields: Private

		private static readonly object Lock = new object();
		private UserConnection _userConnection;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IClientUnitSchemaDecorator _clientUnitSchemaDecorator;
		private Select _moduleStructureSelect;

		#endregion

		#region Constructors: Public

		public ConfigurationSectionHelper(UserConnection userConnection)
				: this(userConnection, HttpContext.HttpContextAccessor) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor)
				: this(userConnection, httpContextAccessor, ClassFactory.Get<IClientUnitSchemaDecorator>()) {
		}

		public ConfigurationSectionHelper(UserConnection userConnection, IHttpContextAccessor httpContextAccessor,
				IClientUnitSchemaDecorator clientUnitSchemaDecorator) {
			_userConnection = userConnection;
			_httpContextAccessor = httpContextAccessor;
			_clientUnitSchemaDecorator = clientUnitSchemaDecorator;
		}

		#endregion

		#region Properties: Private

		private UserConnection SystemUserConnection {
			get {
				return _userConnection.AppConnection.SystemUserConnection;
			}
		}

		#endregion

		#region Methods: Private

		private Select GetModuleStructureSelect(IEnumerable<string> entityNames) {
			if (_moduleStructureSelect == null) {
				InitializeModuleStructureSelect(entityNames);
			}
			return _moduleStructureSelect;
		}

		private void InitializeModuleStructureSelectJoins(Guid workplaceId, Guid? cultureId) {
			string sysModuleLczSchemaName = GetLczSchemaName("SysModule");
			string sysModuleEditLczSchemaName = GetLczSchemaName("SysModuleEdit");
			if (cultureId.HasValue) {
				_moduleStructureSelect
					.Column("SysModule", "Caption").As("ModuleCaption")
					.Column("SysModule", "ModuleHeader").As("ModuleHeader")
					.Column("SysModuleEdit", "ActionKindCaption").As("ActionCaption")
					.Column("SysModuleEdit", "PageCaption").As("PageCaption")
					.Column(sysModuleLczSchemaName, "Caption").As("ModuleCaptionLcz")
					.Column(sysModuleLczSchemaName, "ModuleHeader").As("ModuleHeaderLcz")
					.Column(sysModuleEditLczSchemaName, "ActionKindCaption").As("ActionCaptionLcz")
					.Column(sysModuleEditLczSchemaName, "PageCaption").As("PageCaptionLcz");
			}
			_moduleStructureSelect.From("SysModule");
			bool isWorkplaceIdNotEmpty = workplaceId.IsNotEmpty();
			if (isWorkplaceIdNotEmpty) {
				_moduleStructureSelect.LeftOuterJoin("SysModuleInWorkplace")
					.On("SysModuleInWorkplace", "SysModuleId").IsEqual("SysModule", "Id")
					.And("SysModuleInWorkplace", "SysWorkplaceId").IsEqual(Column.Parameter(workplaceId));
			} else {
				_moduleStructureSelect.LeftOuterJoin("SysModuleInSysModuleFolder")
					.On("SysModuleInSysModuleFolder", "SysModuleId").IsEqual("SysModule", "Id");
			}
			_moduleStructureSelect.LeftOuterJoin("SysModuleEdit")
					.On("SysModuleEdit", "SysModuleEntityId").IsEqual("SysModule", "SysModuleEntityId")
				.LeftOuterJoin("SysModuleEntity")
					.On("SysModuleEntity", "Id").IsEqual("SysModuleEdit", "SysModuleEntityId");
			_moduleStructureSelect.LeftOuterJoin("SysModuleVisa")
				.On("SysModuleVisa", "Id").IsEqual("SysModule", "SysModuleVisaId");
			if (cultureId.HasValue) {
				_moduleStructureSelect
					.LeftOuterJoin(sysModuleLczSchemaName)
						.On(sysModuleLczSchemaName, "RecordId").IsEqual("SysModule", "Id")
						.And(sysModuleLczSchemaName, "SysCultureId").IsEqual(Column.Parameter(cultureId))
					.LeftOuterJoin(sysModuleEditLczSchemaName)
						.On(sysModuleEditLczSchemaName, "RecordId").IsEqual(
							isWorkplaceIdNotEmpty ? "SysModuleEdit" : "SysModule", "Id")
						.And(sysModuleEditLczSchemaName, "SysCultureId").IsEqual(Column.Parameter(cultureId));
			}
			if (isWorkplaceIdNotEmpty) {
				_moduleStructureSelect.Where("SysModule", "SectionModuleSchemaUId").Not().IsNull()
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleInWorkplace", "Position")
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			} else {
				var rootSysModuleFolderId = new Guid("F330F0C2-3EE4-4A73-9AC9-8439543CA19B");
				_moduleStructureSelect.Where("SysModuleInSysModuleFolder", "SysModuleFolderId")
						.IsEqual(new QueryParameter("SysModuleFolderId", rootSysModuleFolderId, GuidTypeName))
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleInSysModuleFolder", "Position")
					.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			}
		}

		private static string GetLczSchemaName(string schemaName, UserConnection userConnection) {
			if (!GlobalAppSettings.UseEntitySchemaLczNaming) {
				return schemaName.StartsWith("Sys") ? string.Concat(schemaName, "Lcz")
					: string.Concat("Sys", schemaName, "Lcz");
			}
			EntitySchema entitySchema = userConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			return entitySchema.LocalizationSchemaName;
		}

		private string GetLczSchemaName(string schemaName) {
			return GetLczSchemaName(schemaName, _userConnection);
		}

		private void AppendRequestsCachingOptions(StringBuilder sb) {
			sb.AppendLine("BPMSoft.RequestsCachingSettings={};");
			AppendValueFromSysSettings(sb, "RequestsCachingTtl", "BPMSoft.RequestsCachingSettings.ttl");
			AppendValueFromSysSettings(sb, "RequestsCachingOptions", "BPMSoft.RequestsCachingSettings.options");
		}
		
		private void AppendValueFromSysSettings(StringBuilder sb, string settingsCode, string propPath) {
			if (!CoreSysSettings.TryGetValue(_userConnection, settingsCode, out object propValue)) {
				return;
			}
			var isOptionsEmpty = string.IsNullOrWhiteSpace(propValue?.ToString());
			if (!isOptionsEmpty) {
				sb.AppendFormat("{0}={1};{2}", propPath, Json.Serialize(propValue), Environment.NewLine);
			}
		}
		
		private void AppendMinSearchCharsCountSetting(StringBuilder sb) {
			object value;
			if (CoreSysSettings.TryGetValue(_userConnection, "StringColumnSearchMinCharCount", out value)) {
				sb.AppendFormat("BPMSoft.ControlsSettings={{lookupMinSearchCharsCount:{0}}};{1}", value, Environment.NewLine);
			}
		}

		/// <summary>Gets script that initializes isFirstLogin property.
		/// It determines if user logged in for the first time.</summary>
		/// <returns>Script that initializes isFirstLogin property.</returns>
		private string GetIsFirstLoginScript() {
			HttpContext httpContext = _httpContextAccessor.GetInstance();
			object sessionParameter = httpContext.Session[IsFirstLoginKey];
			string isFirstLogin = bool.FalseString.ToLower();
			if (sessionParameter == null) {
				httpContext.Session[IsFirstLoginKey] = false;
				isFirstLogin = bool.TrueString.ToLower();
			}
			return string.Format("BPMSoft.isFirstLogin={0};{1}", isFirstLogin, Environment.NewLine);
		}

		private static string GetLessConstantsScript(UserConnection userConnection) {
			var sysSettingsList = new List<string>(){"SectionPanelBackgroundColor", "SectionPanelFontColor",
				"SectionPanelSelectedBackgroundColor", "SectionPanelSelectedFontColor"};
			var sysSettingsDictionary = new Dictionary<string, string>();
			foreach (var sysSetting in sysSettingsList) {
				object sysSettingValue;
				if (CoreSysSettings.TryGetValue(userConnection, sysSetting, out sysSettingValue)) {
					sysSettingsDictionary.Add(sysSetting, sysSettingValue.ToString());
				}
			}
			string json = Json.Serialize(sysSettingsDictionary);
			return string.Format("BPMSoft.Resources.LessConstants={0};{1}", json, Environment.NewLine);
		}

		private static string GetSysSettingsHashScript(UserConnection userConnection) {
			var sysSettingsList = new List<string>() {"LogoImage", "MenuLogoImage", "HeaderLogoImage"};
			var sysSettingsValueHash = new Dictionary<string, string>();
			foreach (var sysSetting in sysSettingsList) {
				object sysSettingValue;
				if (CoreSysSettings.TryGetValue(userConnection, sysSetting, out sysSettingValue)) {
					using (MD5 md5Hash = MD5.Create()) {
						byte[] hash = md5Hash.ComputeHash((byte[])sysSettingValue);
						StringBuilder sBuilder = new StringBuilder();
						for (int i = 0; i < hash.Length; i++) {
							sBuilder.Append(hash[i].ToString("x2"));
						}
						string hashStr = sBuilder.ToString();
						sysSettingsValueHash.Add(sysSetting, hashStr);
					}
				}
			}
			string json = Json.Serialize(sysSettingsValueHash);
			return string.Format("BPMSoft.SysSettingsImageHash={0};{1}", json, Environment.NewLine);
		}

		private Select GetClientUnitSchemaNameSelect(string sourceAlias, string sourceColumnAlias) {
			var clientUnitSchemaNameSelect = (Select)new Select(SystemUserConnection)
				.Column("Name")
				.From("SysSchema")
				.Where("ManagerName")
				.IsEqual(Column.Parameter(_userConnection.ClientUnitSchemaManager.Name))
				.And("UId").IsEqual(sourceAlias, sourceColumnAlias);
			return clientUnitSchemaNameSelect;
		}

		private static string GetWorkplaceCacheKey(UserConnection userConnection) {
			return string.Format(WorkplaceCacheKeyTemplate, userConnection.CurrentUser.Id);
		}

		private static Guid? GetWorkplaceCashedValue(UserConnection userConnection) {
			string key = GetWorkplaceCacheKey(userConnection);
			var cachedValue = userConnection.SessionCache[key];
			Guid? result = null;
			if (cachedValue != null) {
				result = new Guid(cachedValue.ToString());
			}
			return result;
		}

		/// <summary>
		/// Gets default intro page name script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Default intro page name script.</returns>
		private static string GetDefaultIntroPageNameScript(UserConnection userConnection) {
			object defaultIntroPageId;
			if (CoreSysSettings.TryGetValue(userConnection, "DefaultIntroPage", out defaultIntroPageId) &&
				defaultIntroPageId != null) {
				using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
					var query = (new Select(userConnection)
						.Column("SysSchema", "Name")
						.From("ApplicationMainMenu")
						.InnerJoin("SysSchema").On("ApplicationMainMenu", "IntroPageUId")
							.IsEqual("SysSchema", "UId")
						.Where("ApplicationMainMenu", "Id")
							.IsEqual(Column.Parameter(defaultIntroPageId)) as Select);
					string defaultIntroPageName = query.ExecuteScalar<string>(dbExecutor);
					if (defaultIntroPageName.IsNotNullOrEmpty()) {
						return string.Format("BPMSoft.configuration.defaultIntroPageName=\"{0}\";", defaultIntroPageName);
					}
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// Gets ClientUnitSchema descriptors script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>ClientUnitSchema descriptors script.</returns>
		private string GetClientUnitSchemaDescriptorsScript(UserConnection userConnection) {
			string descriptors = GlobalAppSettings.UseStaticFileContent ? "{}" :
				GetClientUnitSchemaDescriptors(userConnection);
			return string.Format("BPMSoft.configuration.{0}={1};", RootSchemaDescriptors, descriptors);
		}

		/// <summary>
		/// Gets default user task schemas that valid by default in Process Designer.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Script with UId's array of user task schemas.</returns>
		private static string GetValidUserTasksByDefault(UserConnection userConnection) {
			var validUserTasksByDefault = new string[] {
				"ActivityUserTask",
				"AutoGeneratedPageUserTask"
			};
			var userTaskSchemaManager = userConnection.ProcessUserTaskSchemaManager;
			string validUserTasksByDefaultString = string.Join(",", validUserTasksByDefault
				.Select(x => '\'' + userTaskSchemaManager.FindItemByName(x).UId.ToString() + '\''));
			return string.Format("BPMSoft.configuration.validUserTasksByDefault=[{0}];",
				validUserTasksByDefaultString);
		}

		/// <summary>
		/// Gets quick add menu items select query.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Quick add menu items select query.</returns>
		private static Select GetQuickAddMenuItemsSelect(UserConnection userConnection) {
			Guid userId = userConnection.CurrentUser.Id;
			bool useMultilanguageData = !userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			var select = new Select(userConnection).Distinct()
				.Column("QuickAddMenuItem", "Id")
				.Column("QuickAddMenuItem", "Position")
				.Column("QuickAddMenuItem", "Name") as Select;
			if (useMultilanguageData) {
				string lczSchemaName = GetLczSchemaName("QuickAddMenuItem", userConnection);
				Guid sysCultureId = userConnection.CurrentUser.SysCultureId;
				select
					.Column(lczSchemaName, "Name").As("Caption")
					.LeftOuterJoin(lczSchemaName)
						.On(lczSchemaName, "RecordId").IsEqual("QuickAddMenuItem", "Id")
						.And(lczSchemaName, "SysCultureId").IsEqual(Column.Parameter(sysCultureId));
			}
			select
				.Column("QuickAddMenuItem", "SysModuleEditId")
				.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
				.Column("SysModuleEntity", "TypeColumnUId").As("TypeColumnUId")
				.Column("VwSysModuleSchemaEdit", "TypeColumnValue").As("TypeColumnValue")
				.Column("VwSysModuleSchemaEdit", "SysModuleEntityId").As("SysModuleEntityId")
				.Column("VwSysModuleSchemaEdit", "EditPageName").As("EditPageName")
				.Column("VwSysModuleSchemaEdit", "MiniPageSchemaUId").As("MiniPageSchemaUId")
				.Column("VwSysModuleSchemaEdit", "MiniPageModes").As("MiniPageModes")
				.Column("SysSchema", "Name").As("EntityName")
				.Column("QuickAddMenuSettings", "Position").As("SettingPosition")
				.Column("ssModule", "Name").As("ModuleName")
				.From("QuickAddMenuItem")
					.Join(JoinType.LeftOuter, "QuickAddMenuSettings")
						.On("QuickAddMenuSettings", "SysAdminUnitId").IsEqual("QuickAddMenuItem", "QuickAddMenuSettingsId")
					.Join(JoinType.LeftOuter, "VwSysModuleSchemaEdit")
						.On("VwSysModuleSchemaEdit", "Id").IsEqual("QuickAddMenuItem", "SysModuleEditId")
					.Join(JoinType.LeftOuter, "SysModuleEntity")
						.On("SysModuleEntity", "Id").IsEqual("VwSysModuleSchemaEdit", "SysModuleEntityId")
					.Join(JoinType.LeftOuter, "SysSchema")
						.On("SysSchema", "UId").IsEqual("SysModuleEntity", "SysEntitySchemaUId")
					.Join(JoinType.LeftOuter, "SysSchema").As("ssModule")
						.On("ssModule", "UId").IsEqual("QuickAddMenuItem", "ModuleUId")
				.Where("QuickAddMenuItem", "QuickAddMenuSettingsId")
					.IsEqual(new Select(userConnection).Top(1)
						.Column("Id")
						.From("QuickAddMenuSettings")
						.Where().Exists(new Select(userConnection)
							.Column(Column.Const(1))
							.From("SysAdminUnitInRole")
							.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(userId))
								.And("QuickAddMenuSettings", "SysAdminUnitId")
									.IsEqual("SysAdminUnitInRole", "SysAdminUnitRoleId") as Select)
						.OrderByAsc("Position"))
				.OrderByAsc("QuickAddMenuItem", "Position");
			return select;
		}

		private static bool HasSchemaEditAddMiniPage(UserConnection userConnection, string entityName,
				string miniPageModes) {
			bool hasAddMiniPage = false;
			if (string.IsNullOrEmpty(miniPageModes)) {
				hasAddMiniPage = GetMiniPageAddModeSysSetting(userConnection, entityName);
			} else {
				hasAddMiniPage = miniPageModes.Split(';').Contains("add");
			}
			return hasAddMiniPage;
		}

		private static bool GetMiniPageAddModeSysSetting(UserConnection userConnection, string entityName) {
			string sysSettingCode = string.Format(MiniPageAddModeCode, entityName);
			bool value = CoreSysSettings.GetValue<bool>(userConnection, sysSettingCode, false);
			return value;
		}

		/// <summary>
		/// Gets workplace identifier.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		private static Guid GetWorkplaceId(UserConnection userConnection) {
			Guid? cachedValue = GetWorkplaceCashedValue(userConnection);
			if (cachedValue.HasValue) {
				return cachedValue.Value;
			} else {
				Guid workplaceId = Guid.Empty;
				var workplaceSelect = new Select(userConnection).Top(1)
					.Column("Id")
					.Column("Position")
					.From("SysWorkplace")
					.Where().Exists(
						new Select(userConnection)
						.Column(Column.Const(1))
						.From("SysAdminUnitInWorkplace")
						.Where().Exists(
							new Select(userConnection)
								.Column(Column.Const(1))
							.From("SysAdminUnitInRole")
							.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(userConnection.CurrentUser.Id))
								.And("SysAdminUnitInRole", "SysAdminUnitRoleId")
									.IsEqual("SysAdminUnitInWorkplace", "SysAdminUnitId") as Select)
						.And("SysWorkplace", "Id")
							.IsEqual("SysAdminUnitInWorkplace", "SysWorkplaceId") as Select
					)
					.OrderByAsc("Position") as Select;
				workplaceSelect.ExecuteReader(dataReader => {
					workplaceId = dataReader.GetColumnValue<Guid>("Id");
				});
				return workplaceId;
			}
		}

		private IEnumerable<ISectionStructureBuilder> GetCustomSelectConditions() {
			return ClassFactory.GetAll<ISectionStructureBuilder>(_userConnection.CurrentUser.ConnectionType.ToString());
		}

		private void ApplyCustomSelectConditions(string schemaName, Select select) {
			foreach (ISectionStructureBuilder customSelectCondition in GetCustomSelectConditions()) {
				customSelectCondition.ApplyCustomConditions(schemaName, select);
			}
		}

		private IEnumerable<ICustomConfigurationScriptBuilder> GetCustomConfigurationScriptBuilders() {
			return ClassFactory.GetAll<ICustomConfigurationScriptBuilder>();
		}

		private string GetCustomConfigurationScript(UserConnection userConnection) {
			return string.Join(Environment.NewLine,
				GetCustomConfigurationScriptBuilders().AsParallel().Select(s => s.BuildScript(userConnection))) +
				Environment.NewLine;
		}

		/// <summary>
		/// Initializes module structure select query.
		/// </summary>
		private void InitializeModuleStructureSelect(IEnumerable<string> entityNames) {
			Select sectionModuleSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionModuleSchemaUId");
			Select sectionSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionSchemaUId");
			Select cardModuleSelect = GetClientUnitSchemaNameSelect("SysModule", "CardModuleUId");
			Select cardSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "CardSchemaUId");
			Select cardSchemaPageSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "CardSchemaUId");
			Select miniPageSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "MiniPageSchemaUId");
			_moduleStructureSelect = new Select(SystemUserConnection)
				.Column("SysModule", "Id").As("ModuleId")
				.Column("SysModule", "Image32Id").As("ImageId")
				.Column("SysModule", "LogoId").As("LogoId")
				.Column("SysModule", "Code").As("Module")
				.Column(sectionModuleSelect).As("SectionModule")
				.Column(sectionSchemaSelect).As("SectionSchema")
				.Column(cardModuleSelect).As("CardModule")
				.Column(cardSchemaSelect).As("CardSchema")
				.Column("SysModule", "Attribute").As("Attribute")
				.Column("SysModule", "TypeColumnValue").As("ModuleTypeColumnValue")
				.Column(cardSchemaPageSelect).As("CardSchemaPage")
				.Column(miniPageSchemaSelect).As("MiniPageSchema")
				.Column("SysModuleEdit", "Id").As("ModuleEditId")
				.Column("SysModuleEdit", "ActionKindName").As("ActionName")
				.Column("SysModuleEdit", "TypeColumnValue").As("TypeColumnValue")
				.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
				.Column("SysModuleVisa", "VisaSchemaUId").As("VisaSchemaUId");
			var workplaceId = GetWorkplaceId(_userConnection);
			if (workplaceId.IsNotEmpty()) {
				_moduleStructureSelect.Column("SysModuleInWorkplace", "SysWorkplaceId").As("ShowInWorkplace");
			} else {
				_moduleStructureSelect.Column(Column.Const(1)).As("ShowInWorkplace");
			}
			bool useMultilanguageData = !_userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			Guid cultureId = _userConnection.CurrentUser.SysCultureId;
			InitializeModuleStructureSelectJoins(workplaceId, useMultilanguageData ? (Guid?)cultureId : null);
			AddEntityNamesCondition(entityNames, _moduleStructureSelect);
			ApplyCustomSelectConditions("SysModule", _moduleStructureSelect);
			if (!useMultilanguageData) {
				string cultureName = _userConnection.CurrentUser.SysCultureName;
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModule", "SysModule", "Id", "Caption", false, "ModuleCaption", "SysModuleLcz_ModuleCaption");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModule", "SysModule", "Id", "ModuleHeader", false, "ModuleHeader", "SysModuleLcz_ModuleHeader");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "ActionKindCaption", false, "ActionCaption",
					"SysModuleEditLcz_ActionCaption");
				CommonUtilities.AddLczColumn(SystemUserConnection, cultureId, cultureName, _moduleStructureSelect,
					"SysModuleEdit", "SysModuleEdit", "Id", "PageCaption", false, "PageCaption",
					"SysModuleEditLcz_PageCaption");
			}
			_moduleStructureSelect.InitializeParameters();
		}

		private string FixGuidForOracle(string uid) {
			if (string.IsNullOrEmpty(uid)) {
				return string.Empty;
			}
			return uid.ToLower().Replace("{", "").Replace("}", "");
		}

		private Select GetPortalSchemaAccessSelect() {
			return
				new Select(SystemUserConnection)
					.Column("PortalSchemaAccessList", "AccessEntitySchemaName")
					.Column("PortalSchemaAccessList", "SchemaUId")
					.Column("PortalColumnAccessList", "ColumnUId")
				.From("PortalSchemaAccessList")
				.LeftOuterJoin("PortalColumnAccessList")
					.On("PortalColumnAccessList", "PortalSchemaListId").IsEqual("PortalSchemaAccessList", "Id")
				.Where("PortalSchemaAccessList", "SchemaUId").Not().IsNull()
				.OrderByAsc("AccessEntitySchemaName") as Select;
		}

		/// <summary>
		/// Gets localizable column value.
		/// </summary>
		/// <param name="useMultilanguageData">Determines if should use multilanguage data.</param>
		/// <param name="dataReader">Data reader.</param>
		/// <param name="columnName">Column name.</param>
		/// <returns>Column value.</returns>
		private static string GetLczColumnValue(bool useMultilanguageData, IDataReader dataReader, string columnName) {
			string value = dataReader.GetColumnValue<string>(columnName);
			if (!useMultilanguageData) {
				return value;
			}
			if (useMultilanguageData) {
				columnName += "Lcz";
			}
			string lczValue = dataReader.GetColumnValue<string>(columnName);
			return !string.IsNullOrEmpty(lczValue) ? lczValue : value;
		}

		/// <summary>
		/// Builds string that contains entities structure from initial dictionary.
		/// </summary>
		/// <param name="entitiesStructure">Entities structure dictionary.</param>
		/// <returns>Stringified entities structure.</returns>
		private string BuildEntitiesStructureString(Dictionary<Guid, EntityStructure> entitiesStructure) {
			var entitieStructureSb = new StringBuilder("{");
			foreach (var entityStructure in entitiesStructure) {
				var structure = entityStructure.Value;
				entitieStructureSb.Append(structure.EntityName);
				entitieStructureSb.Append(":{");
				if (!string.IsNullOrEmpty(structure.Attribute)) {
					entitieStructureSb.Append(string.Format("attribute:{0},", Json.Serialize(structure.Attribute)));
				}
				entitieStructureSb.Append(string.Format("entitySchemaName:{0},", Json.Serialize(structure.EntityName)));
				entitieStructureSb.Append(string.Format("entitySchemaUId:{0},", Json.Serialize(structure.EntitySchemaUId)));
				entitieStructureSb.Append(string.Format("searchRowSchema:{0},", Json.Serialize(structure.SearchRowSchema)));
				entitieStructureSb.Append("pages:[");

				foreach (var pageStructure in structure.PagesStructure) {
					entitieStructureSb.Append("{cardSchema:'");
					entitieStructureSb.Append(pageStructure.CardSchema);
					if (!string.IsNullOrEmpty(pageStructure.MiniPageSchema)) {
						entitieStructureSb.Append("',miniPageSchema:'");
						entitieStructureSb.Append(pageStructure.MiniPageSchema);
						entitieStructureSb.Append("',miniPageModes:'");
						entitieStructureSb.Append(pageStructure.MiniPageModes);
						bool hasAddMiniPage = HasSchemaEditAddMiniPage(_userConnection, structure.EntityName,
							pageStructure.MiniPageModes);
						if (hasAddMiniPage) {
							entitieStructureSb.Append("',hasAddMiniPage:'");
							entitieStructureSb.Append(hasAddMiniPage);
						}
					}
					entitieStructureSb.Append("',UId:'");
					entitieStructureSb.Append(pageStructure.UId);
					entitieStructureSb.Append("',caption:");
					entitieStructureSb.Append(Json.Serialize(pageStructure.Caption));
					entitieStructureSb.Append(",captionLcz:");
					entitieStructureSb.Append(Json.Serialize(pageStructure.CaptionLcz));
					entitieStructureSb.Append(",typeColumnName:'");
					entitieStructureSb.Append(structure.Attribute);
					entitieStructureSb.Append("',moduleEditId:'");
					entitieStructureSb.Append(pageStructure.ModuleEditId);
					entitieStructureSb.Append("'},");
				}
				entitieStructureSb = entitieStructureSb.Remove(entitieStructureSb.Length - 1, 1);
				entitieStructureSb.Append("]},");
			}
			if (entitieStructureSb.Length > 2) {
				entitieStructureSb = entitieStructureSb.Remove(entitieStructureSb.Length - 1, 1);
			}
			entitieStructureSb.Append("}");
			return entitieStructureSb.ToString();
		}

		/// <summary>
		/// Builds string that contains modules structure from initial dictionary.
		/// </summary>
		/// <param name="modulesStructure">Modules structure dictionary.</param>
		/// <returns>Stringified modules structure.</returns>
		private string BuildModulesStructureString(Dictionary<string, ModuleStructure> modulesStructure) {
			string modulesStructureString = "{" + string.Join(",", modulesStructure.AsParallel().Select(m => {
				string moduleStructureString = m.Value.ToString();
				moduleStructureString = ModifyModuleStructureString(m.Value, moduleStructureString);
				return moduleStructureString;
			})) + "}";
			return modulesStructureString;
		}

		private static ICacheStore GetLocalCache(UserConnection userConnection) {
			return userConnection.SessionCache.WithLocalCaching(LocalCacheGroupName);
		}

		private static string GetSessionCacheKey(UserConnection userConnection) {
			return string.Format(LocalCacheKeyTemplate, userConnection.CurrentUser.Culture.Name, userConnection.SessionId);
		}

		private void AddItemDescriptors<T>(StringBuilder descriptorsStringBuilder,
				IEnumerable<ISchemaManagerItem<T>> schemaManagerItems)
				where T : Schema, ISchemaManagerSchema<T> {
			foreach (ISchemaManagerItem<T> item in schemaManagerItems) {
				string descriptor = _clientUnitSchemaDecorator.GetSchemaDescriptor(item);
				if ((GlobalAppSettings.UseStaticFileContent && !string.IsNullOrEmpty(descriptor)) || !GlobalAppSettings.UseStaticFileContent) {
					descriptorsStringBuilder.AppendFormat("{0}:{1},", item.Name, descriptor).AppendLine();
				}
			}
		}

		private bool GetAccessFromSspLicense(UserConnection userConnection, string moduleName) {
			return userConnection.CurrentUser.ConnectionType == UserType.SSP
				? userConnection.DBSecurityEngine.GetIsAvailableOnSsp(moduleName)
				: true;
		}

		private string GetEnableSanitizeHtmlScript(UserConnection userConnection) {
			var featureState = userConnection.GetIsFeatureEnabled("SanitizeHtml");
			return string.Concat(Environment.NewLine, "BPMSoft.enableSanitizeHtml = ",
				featureState.ToString().ToLower(), ";");
		}

		private Dictionary<Guid, EntityStructure> InnerGetEntitiesStructure(UserConnection userConnection, IEnumerable<string> entityNames = null) {
			bool useMultilanguageData = !_userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			var entitySchemaManager = userConnection.EntitySchemaManager;
			Guid cultureId = _userConnection.CurrentUser.SysCultureId;
			string cultureName = _userConnection.CurrentUser.SysCultureName;
			Select cardSchemaPageSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "CardSchemaUId");
			Select miniPageSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "MiniPageSchemaUId");
			Select searchRowSchemaSelect = GetClientUnitSchemaNameSelect("SysModuleEdit", "SearchRowSchemaUId");
			var entityEditPageSelect = new Select(SystemUserConnection)
				.Column("SysModuleEdit", "ActionKindName").As("ActionName")
				.Column("SysModuleEdit", "TypeColumnValue").As("TypeColumnValue")
				.Column("SysModuleEdit", "CardSchemaUId").As("CardSchemaUId")
				.Column("SysModuleEdit", "MiniPageSchemaUId").As("MiniPageSchemaUId")
				.Column("SysModuleEdit", "MiniPageModes").As("MiniPageModes")
				.Column("SysModuleEdit", "Id").As("SysModuleEditId")
				.Column("SysModuleEntity", "SysEntitySchemaUId").As("SysEntitySchemaUId")
				.Column("SysModuleEntity", "TypeColumnUId").As("TypeColumnUId")
				.Column(cardSchemaPageSelect).As("CardSchemaPage")
				.Column(searchRowSchemaSelect).As("SearchRowSchema")
				.Column(miniPageSchemaSelect).As("MiniPageSchema");
			if (!useMultilanguageData) {
				CommonUtilities.AddLczColumn(_userConnection, cultureId, cultureName, entityEditPageSelect, "SysModuleEdit", "SysModuleEdit",
					"Id", "ActionKindCaption", false, "ActionCaption", "SysModuleEditLcz_ActionCaption");
				CommonUtilities.AddLczColumn(_userConnection, cultureId, cultureName, entityEditPageSelect, "SysModuleEdit", "SysModuleEdit",
					"Id", "PageCaption", false, "PageCaption", "SysModuleEditLcz_PageCaption");
			} else {
				string sysModuleEditLczName = GetLczSchemaName("SysModuleEdit", userConnection);
				entityEditPageSelect
					.Column("SysModuleEdit", "ActionKindCaption").As("ActionCaption")
					.Column("SysModuleEdit", "PageCaption").As("PageCaption")
					.Column(sysModuleEditLczName, "ActionKindCaption").As("ActionCaptionLcz")
					.Column(sysModuleEditLczName, "PageCaption").As("PageCaptionLcz")
					.LeftOuterJoin(sysModuleEditLczName)
						.On(sysModuleEditLczName, "RecordId").IsEqual("SysModuleEdit", "Id")
						.And(sysModuleEditLczName, "SysCultureId").IsEqual(Column.Parameter(cultureId));
			}
			entityEditPageSelect
				.From("SysModuleEdit")
					.Join(JoinType.Inner, "SysModuleEntity")
						.On("SysModuleEntity", "Id").IsEqual("SysModuleEdit", "SysModuleEntityId");
			AddEntityNamesCondition(entityNames, entityEditPageSelect);
			entityEditPageSelect.OrderBy(OrderDirectionStrict.Ascending, "SysModuleEdit", "Position");
			ApplyCustomSelectConditions("SysModuleEdit", entityEditPageSelect);
			entityEditPageSelect.InitializeParameters();
			var entitiesStructure = new Dictionary<Guid, EntityStructure>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = entityEditPageSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						string cardSchemaPage = dataReader.GetColumnValue<string>("CardSchemaPage");
						if (string.IsNullOrEmpty(cardSchemaPage)) {
							continue;
						}
						Guid sysEntitySchemaUId = dataReader.GetColumnValue<Guid>("SysEntitySchemaUId");
						if (!entitiesStructure.TryGetValue(sysEntitySchemaUId, out EntityStructure entityStructure)) {
							var item = entitySchemaManager.FindItemByUId(sysEntitySchemaUId);
							if (item == null) {
								continue;
							}
							EntityStructure entityStructureNew = new EntityStructure {
								EntityName = item.Name,
								SearchRowSchema = dataReader.GetColumnValue<string>("SearchRowSchema"),
								EntitySchemaUId = sysEntitySchemaUId.ToString()
							};
							var columnUId = dataReader.GetColumnValue<Guid>("TypeColumnUId");
							if (columnUId != null && columnUId != Guid.Empty) {
								var entitySchema = entitySchemaManager.GetInstanceByUId(sysEntitySchemaUId);
								var column = entitySchema.Columns.FindByUId(columnUId);
								if (column != null) {
									entityStructureNew.Attribute = column.Name;
								}
							}
							entityStructureNew.PagesStructure = new List<PageStructure>();
							entitiesStructure.Add(sysEntitySchemaUId, entityStructureNew);
							entityStructure = entityStructureNew;
						}
						PageStructure pageStructure = new PageStructure {
							Caption = GetLczColumnValue(useMultilanguageData, dataReader, "ActionCaption"),
							CaptionLcz = GetLczColumnValue(useMultilanguageData, dataReader, "PageCaption"),
							Name = dataReader.GetColumnValue<string>("ActionName"),
							UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
							CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
							MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
							MiniPageModes = dataReader.GetColumnValue<string>("MiniPageModes"),
							ModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("SysModuleEditId"))
						};
						entityStructure.PagesStructure.Add(pageStructure);
					}
				}
			}
			return entitiesStructure;
		}

		private Dictionary<string, ModuleStructure> InnerGetModulesStructure(UserConnection userConnection, IEnumerable<string> entityNames = null) {
			_userConnection = userConnection;
			bool useMultilanguageData = !_userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			bool useFixGuidForOracle = _userConnection.GetIsFeatureEnabled("ReplaceOracleGuid");
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var modulesStructure = new Dictionary<string, ModuleStructure>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = GetModuleStructureSelect(entityNames).ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var moduleName = dataReader.GetColumnValue<string>("Module");
						if (!GetAccessFromSspLicense(userConnection, moduleName)) {
							continue;
						}
						if (!modulesStructure.TryGetValue(moduleName, out ModuleStructure moduleStructure)) {
							var entitySchemaUId = dataReader.GetColumnValue<string>("SysEntitySchemaUId");
							var imageId = dataReader.GetColumnValue<string>("ImageId");
							var logoId = dataReader.GetColumnValue<string>("LogoId");
							moduleStructure = new ModuleStructure {
								Module = moduleName,
								EntitySchemaUId = useFixGuidForOracle ? FixGuidForOracle(entitySchemaUId) : entitySchemaUId,
								ModuleId = dataReader.GetColumnValue<Guid>("ModuleId").ToString(),
								ImageId = useFixGuidForOracle ? FixGuidForOracle(imageId) : imageId,
								LogoId = useFixGuidForOracle ? FixGuidForOracle(logoId) : logoId,
								ModuleCaption = GetLczColumnValue(useMultilanguageData, dataReader, "ModuleCaption"),
								ModuleHeader = GetLczColumnValue(useMultilanguageData, dataReader, "ModuleHeader"),
								SectionModule = dataReader.GetColumnValue<string>("SectionModule"),
								SectionSchema = dataReader.GetColumnValue<string>("SectionSchema"),
								CardModule = dataReader.GetColumnValue<string>("CardModule"),
								CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
								MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
								Attribute = dataReader.GetColumnValue<string>("Attribute")
							};
							var showInWorkplace = dataReader.GetColumnValue("ShowInWorkplace");
							moduleStructure.Workplace = showInWorkplace == null ? "" : showInWorkplace.ToString();
							moduleStructure.Hide = "true";
							moduleStructure.TypeColumnValue = dataReader.GetColumnValue<string>("ModuleTypeColumnValue");
							moduleStructure.PagesStructure = new List<PageStructure>();
							moduleStructure.VisaSchemaUId = dataReader.GetColumnValue<string>("VisaSchemaUId");
							if (!string.IsNullOrEmpty(moduleStructure.VisaSchemaUId)) {
								var visaSchemaUId = new Guid(moduleStructure.VisaSchemaUId);
								var item = entitySchemaManager.FindItemByUId(visaSchemaUId);
								if (item != null) {
									moduleStructure.VisaSchemaName = item.Name;
								}
							}
							if (!string.IsNullOrEmpty(moduleStructure.Attribute)) {
								PageStructure pageStructure = new PageStructure {
									CaptionLcz = GetLczColumnValue(useMultilanguageData, dataReader, "PageCaption"),
									Caption = GetLczColumnValue(useMultilanguageData, dataReader, "ActionCaption"),
									Name = dataReader.GetColumnValue<string>("ActionName"),
									UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
									CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
									MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
									ModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("ModuleEditId"))
								};
								moduleStructure.PagesStructure.Add(pageStructure);
							}
							modulesStructure.Add(moduleName, moduleStructure);
						}
						else {
							PageStructure pageStructure = new PageStructure {
								CaptionLcz = GetLczColumnValue(useMultilanguageData, dataReader, "PageCaption"),
								Caption = GetLczColumnValue(useMultilanguageData, dataReader, "ActionCaption"),
								Name = dataReader.GetColumnValue<string>("ActionName"),
								UId = FixGuidForOracle(dataReader.GetColumnValue<string>("TypeColumnValue")),
								CardSchema = dataReader.GetColumnValue<string>("CardSchemaPage"),
								MiniPageSchema = dataReader.GetColumnValue<string>("MiniPageSchema"),
								ModuleEditId = FixGuidForOracle(dataReader.GetColumnValue<string>("ModuleEditId"))
							};
							moduleStructure.PagesStructure.Add(pageStructure);
						}
					}
				}
			}
			return modulesStructure;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns worksplace select by <paramref name="applicationClientTypeId"/>.
		/// <param name="userConnection">User connection.</param>
		/// <param name="applicationClientTypeId">Application client type id.</param>
		/// </summary>
		/// <returns>Builded worksplace select.</returns>
		protected virtual Select GetWorkspaceSelect(UserConnection userConnection, Guid applicationClientTypeId) {
			if (applicationClientTypeId == Guid.Empty) {
				applicationClientTypeId = BaseConsts.BrowserClientTypeId;
			}
			bool useMultilanguageData = !userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			Select sectionSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionSchemaUId");
			Select sectionModuleSchemaSelect = GetClientUnitSchemaNameSelect("SysModule", "SectionModuleSchemaUId");
			Select loaderSchemaSelect = GetClientUnitSchemaNameSelect("SysWorkplace", "LoaderId");
			var workplaceSelect = new Select(userConnection)
				.Column("SysWorkplace", "Id")
				.Column("SysWorkplace", "Position")
				.Column("SysWorkplace", "Name") as Select;
			workplaceSelect
				.Column("SysWorkplace", "IsPersonal")
				.Column("SysWorkplace", "LoaderId")
				.Column(loaderSchemaSelect).As("LoaderName")
				.Column("SysModuleInWorkplace", "SysModuleId")
				.Column("SysModuleInWorkplace", "Position").As("ModulePosition")
				.Column("SysModule", "Caption").As("SysModuleCaption")
				.Column("SysModule", "Code").As("SysModuleName")
				.Column(sectionSchemaSelect).As("SectionModule")
				.Column(sectionModuleSchemaSelect).As("SectionModuleSchema")
				.From("SysWorkplace")
				.Join(JoinType.LeftOuter, "SysModuleInWorkplace")
					.On("SysModuleInWorkplace", "SysWorkplaceId").IsEqual("SysWorkplace", "Id")
				.Join(JoinType.LeftOuter, "SysModule")
					.On("SysModule", "Id").IsEqual("SysModuleInWorkplace", "SysModuleId");
				workplaceSelect
					.Column("SysSchema", "Name").As("HomePageSchemaName")
					.Column("SysSchemaProperty", "Value").As("HomePageSchemaType")
					.Join(JoinType.LeftOuter, "SysSchema").On("SysSchema", "UId")
						.IsEqual("SysWorkplace", "HomePageUId")
					.Join(JoinType.LeftOuter, "SysSchemaProperty")
						.On("SysSchemaProperty", "SysSchemaId").IsEqual("SysSchema", "Id")
						.And("SysSchemaProperty", "Name").IsEqual(Column.Const("SchemaType"));

			if (useMultilanguageData) {
				Guid sysCultureId = userConnection.CurrentUser.SysCultureId;
				string sysWorkplaceLczName = GetLczSchemaName("SysWorkplace", userConnection);
				workplaceSelect.Column(sysWorkplaceLczName, "Name").As("NameLcz")
					.LeftOuterJoin(sysWorkplaceLczName)
						.On(sysWorkplaceLczName, "RecordId").IsEqual("SysWorkplace", "Id")
						.And(sysWorkplaceLczName, "SysCultureId").IsEqual(Column.Parameter(sysCultureId));
			}
			workplaceSelect
				.Where().Exists(
					new Select(userConnection)
					.Column(Column.Parameter(1))
					.From("SysAdminUnitInWorkplace")
					.Where().Exists(
						new Select(userConnection)
						.Column(Column.Parameter(1))
						.From("SysAdminUnitInRole")
						.InnerJoin("SysAdminUnit").On("SysAdminUnit", "Id")
							.IsEqual("SysAdminUnitInRole", "SysAdminUnitRoleId")
						.Where("SysAdminUnitInRole", "SysAdminUnitId")
							.IsEqual(Column.Parameter(userConnection.CurrentUser.Id))
						.And("SysAdminUnitInWorkplace", "SysAdminUnitId")
							.IsEqual("SysAdminUnit", "Id") as Select
					)
					.And("SysWorkplace", "Id")
					.IsEqual("SysAdminUnitInWorkplace", "SysWorkplaceId") as Select
				)
				.And("SysWorkplace", "SysApplicationClientTypeId")
					.IsEqual(Column.Parameter(applicationClientTypeId))
				.OrderByAsc("SysWorkplace", "Position")
				.OrderByAsc("SysWorkplace", "Name")
				.OrderByAsc("SysModuleInWorkplace", "Position");
			return workplaceSelect;
		}

		protected virtual string ModifyModuleStructureString(ModuleStructure moduleStructure, string moduleStructureString) {
			return moduleStructureString;
		}

		/// <summary>
		/// Returns true, if current user has rights for <paramref name="sysModuleName"/> module, and module not disabled.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="sysModuleName">Module name.</param>
		/// <returns> True, if module active and allowed for user.</returns>
		protected virtual bool GetIsModuleAllowed(UserConnection userConnection, string sysModuleName) {
			var securityEngine = userConnection.DBSecurityEngine;
			return securityEngine.GetIsEntitySchemaReadingAllowed(sysModuleName) &&
					!userConnection.GetIsFeatureEnabled("Disable" + sysModuleName) &&
					GetAccessFromSspLicense(userConnection, sysModuleName);
		}

		/// <summary>
		/// Gets Google tag manager script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Google tag manager script.</returns>
		protected string GetGoogleTagManagerScript(UserConnection userConnection) {
			string script = string.Empty;
			bool useGoogleTagManager = CoreSysSettings.GetValue<bool>(userConnection, "UseGoogleTagManager", false);
			if (!useGoogleTagManager) {
				return script;
			}
			string googleTagManagerScript = CoreSysSettings.GetValue<string>(userConnection, "GoogleTagManagerScript",
				string.Empty);
			if (googleTagManagerScript.IsNotEmpty()) {
				string gtmScript = googleTagManagerScript.Replace("'", @"""").Replace("/script", @"\/script");
				gtmScript = gtmScript.Replace("&amp;", "&");
				if (_userConnection.GetIsFeatureEnabled("DecodeGoogleTagManagerScript")) {
					string gtmScriptEncoded = HttpUtility.HtmlDecode(gtmScript);
					gtmScript = gtmScriptEncoded.Replace("'", @"\'");
				}
				script = "document.onreadystatechange = function() { if (document.readyState === \"interactive\") { " +
					"document.body.insertAdjacentHTML(\"beforeEnd\", \'" + gtmScript + "\'); } " +
					"if (document.readyState === \"complete\") { " +
					"var scripts = document.body.getElementsByTagName(\"script\");  eval(scripts[0].innerHTML) }};";
			}
			return script;
		}

		/// <summary>
		/// Gets configuration structures scripts.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Configuration structures scripts.</returns>
		protected Dictionary<string, string> GetConfigurationStructuresScripts(UserConnection userConnection) {
			_userConnection = userConnection;
			var modulesStructure = GetModulesStructure(userConnection);
			var entitiesStructure = GetEntitiesStructure(userConnection);
			string modulesStructureString = BuildModulesStructureString(modulesStructure);
			string entitiesStructureString = BuildEntitiesStructureString(entitiesStructure);
			string quickAddMenuStructureConfig = GetQuickAddConfig(userConnection);
			string columnsInfoConfig = GetColumnsInfoConfig(userConnection);
			string workplacesStructureConfig = GetWorkplacesConfig(userConnection);
			string portalSchemaAccessConfig = "{}";
			if ((userConnection is SSPUserConnection) && userConnection.GetIsFeatureEnabled("PortalColumnConfig")) {
				portalSchemaAccessConfig = GetPortalSchemaAccessConfig();
			}
			return new Dictionary<string, string> {
				{ "WorkplacesStructure", workplacesStructureConfig },
				{ "ModuleStructure", modulesStructureString },
				{ "EntityStructure", entitiesStructureString },
				{ "Storage", @"{}" },
				{ "QuickAddMenu", quickAddMenuStructureConfig },
				{ "ColumnsInfo", columnsInfoConfig },
				{ "PortalSchemaAccessList", portalSchemaAccessConfig }
			};
		}

		protected Dictionary<string, ModuleStructure> GetModulesStructure(UserConnection userConnection) {
			return InnerGetModulesStructure(userConnection);
		}

		protected Dictionary<string, ModuleStructure> GetModulesStructure(UserConnection userConnection,
			IEnumerable<string> entityNames) {
			return InnerGetModulesStructure(userConnection, entityNames);
		}

		protected Dictionary<Guid, EntityStructure> GetEntitiesStructure(UserConnection userConnection,
			IEnumerable<string> entityNames) {
			return InnerGetEntitiesStructure(userConnection, entityNames);
		}

		protected Dictionary<Guid, EntityStructure> GetEntitiesStructure(UserConnection userConnection) {
			return InnerGetEntitiesStructure(userConnection);
		}

		protected void AddEntityNamesCondition(IEnumerable<string> entityNames, Select select) {
			if (!entityNames.IsNullOrEmpty()) {
				select.InnerJoin("SysSchema").On("SysSchema", "UId")
					.IsEqual("SysModuleEntity", "SysEntitySchemaUId");
				select.AddCondition("SysSchema", "Name", LogicalOperation.And).In(Column.Parameters(entityNames as IEnumerable<string>));
			}
		}

		#endregion

		#region Methods: Public

		public static void ResetWorkplaceCache(UserConnection userConnection) {
			string key = GetWorkplaceCacheKey(userConnection);
			userConnection.SessionCache.Remove(key);
		}

		public static void SetWorkplaceCache(UserConnection userConnection, Guid workplaceId) {
			string key = GetWorkplaceCacheKey(userConnection);
			userConnection.SessionCache[key] = workplaceId;
		}

		/// <summary>
		/// Returns worksplace config by <paramref name="applicationClientTypeId"/>.
		/// <param name="userConnection"> User connection.</param>
		/// <param name="isScript">Is script mode.</param>
		/// <param name="applicationClientTypeId">Application client type id.</param>
		/// </summary>
		/// <returns>Builded worksplace config.</returns>
		public string GetWorkplacesConfig(UserConnection userConnection, bool isScript = false, Guid applicationClientTypeId = default(Guid)) {
			Dictionary<Guid, string> workplaces = new Dictionary<Guid, string>();
			Dictionary<Guid, List<string>> modules = new Dictionary<Guid, List<string>>();
			bool useMultilanguageData = !userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			string tmpl = @"{{Workplaces:[{0}]}}";
			string itemTmpl = "{{workplaceId:'{0}',name:'{1}',position:{2},loaderId:'{3}',loaderName:'{4}',isPersonal:{5}";
			itemTmpl += ",homePageSchemaName:'{6}',homePageSchemaType:'{7}'";
			var modulesItem = @",modules:[{0}]}}";
			var modulesConfig = @"{{moduleId:'{0}',moduleName:'{1}',moduleCaption:{2},position:'{3}',sectionName:'{4}'}}";
			if (isScript) {
				tmpl = @"{{""Workplaces"":[{0}]}}";
				itemTmpl = @"{{""workplaceId"":""{0}"",""name"":""{1}"",""position"":""{2}"",""loaderId"":""{3}"",""loaderName"":""{4}"",""isPersonal"":""{5}""";
				modulesItem = @",""modules"":[{0}]}}";
				modulesConfig = @"{{""moduleId"":""{0}"",""moduleName"":""{1}"",""moduleCaption"":{2},""position"":""{3}"",""sectionName"":""{4}""}}";
				itemTmpl += @",""homePageSchemaName"":""{6}"",""homePageSchemaType"":""{7}""";
			}
			var workplaceSelect = GetWorkspaceSelect(userConnection, applicationClientTypeId);
			var checkedModules = new Dictionary<string, bool>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = workplaceSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid workplaceId = dataReader.GetColumnValue<Guid>("Id");
						string sysModuleName = dataReader.GetColumnValue<string>("SysModuleName") ?? string.Empty;
						if (!checkedModules.TryGetValue(sysModuleName, out bool allowed)) {
							allowed = GetIsModuleAllowed(userConnection, sysModuleName);
							checkedModules.Add(sysModuleName, allowed);
						}
						if (allowed) {
							Guid sysModuleId = dataReader.GetColumnValue<Guid>("SysModuleId");
							int modulePosition = dataReader.GetColumnValue<int>("ModulePosition");
							string sysModuleCaption = Json.Serialize(dataReader.GetColumnValue<string>("SysModuleCaption"));
							string sectionName = dataReader.GetColumnValue<string>("SectionModule");
							string sectionModuleSchemaName = dataReader.GetColumnValue<string>("SectionModuleSchema");
							sectionName = (string.IsNullOrEmpty(sectionName) && !string.IsNullOrEmpty(sectionModuleSchemaName)) ? sectionModuleSchemaName : sectionName;
							if (modules.TryGetValue(workplaceId, out List<string> moduleStrings)) {
								moduleStrings.Add(string.Format(modulesConfig, sysModuleId, sysModuleName, sysModuleCaption, modulePosition, sectionName));
							} else {
								modules.Add(workplaceId, new List<string> {
									string.Format(modulesConfig, sysModuleId, sysModuleName, sysModuleCaption, modulePosition, sectionName)
								});
							}
						}
						if (!workplaces.ContainsKey(workplaceId)) {
							string workplaceName = dataReader.GetColumnValue<string>("Name");
							string workplaceNameLcz = useMultilanguageData ? dataReader.GetColumnValue<string>("NameLcz") : string.Empty;
							workplaceName = workplaceNameLcz.IsNullOrEmpty() ? workplaceName : workplaceNameLcz;
							int position = dataReader.GetColumnValue<int>("Position");
							Guid workplaceLoaderId = dataReader.GetColumnValue<Guid>("LoaderId");
							string loaderName = dataReader.GetColumnValue<string>("LoaderName");
							string homePageSchemaName = dataReader.GetColumnValue<string>("HomePageSchemaName");
							string homePageSchemaType = dataReader.GetColumnValue<string>("HomePageSchemaType");
							string isPersonal = dataReader.GetColumnValue<bool>("IsPersonal") ? "true" : "false";
							string workplaceNameValidate = workplaceName.EscapeBackslash().EscapeSingleQuotes();
							workplaces.Add(workplaceId, string.Format(itemTmpl, workplaceId, workplaceNameValidate, position,
									workplaceLoaderId, loaderName, isPersonal, homePageSchemaName, homePageSchemaType));
						}
					}
				}
			}
			List<string> workplaceModules = null;
			var itemsStringBuilder = new StringBuilder();
			foreach (var item in workplaces) {
				if (modules.TryGetValue(item.Key, out workplaceModules)) {
					itemsStringBuilder.Append(item.Value);
					itemsStringBuilder.AppendFormat(modulesItem, string.Join(",", workplaceModules));
					itemsStringBuilder.Append(",");
				}
			}
			return string.Format(tmpl, itemsStringBuilder.ToString().TrimEnd(','));
		}

		public virtual string GetColumnsInfoConfig(UserConnection userConnection) {
			var lookupImages = new Dictionary<string, string>();
			string itemTmpl = @"{0}:{{ImageId:'{1}'}}";
			var LookupImagesSelect = new Select(userConnection).Distinct()
				.Column("MultiLookupImage", "Code")
				.Column("MultiLookupImage", "LookupImageId")
				.From("MultiLookupImage");
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = LookupImagesSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid LookupImageId = dataReader.GetColumnValue<Guid>("LookupImageId");
						string Code = dataReader.GetColumnValue<string>("Code");
						lookupImages.Add(Code, string.Format(itemTmpl, Code, LookupImageId));
					}
				}
			}
			var items = string.Join(",", lookupImages.Select(x => x.Value));
			return "{" + items + "}";
		}

		/// <summary>
		/// Get config of portal schema access restrictions.
		/// </summary>
		/// <returns>JSON string config</returns>
		public virtual string GetPortalSchemaAccessConfig() {
			Select schemaAccessListSelect = GetPortalSchemaAccessSelect();
			string wrapperTpl = "{{{0}\n}}";
			string entityTpl = "\n\t{0}:{{\n\t\tuId:\"{1}\",\n\t\tname:\"{0}\",\n\t\texplorerAllowedColumns:[{2}]\n\t}},";
			string fieldTpl = "{{\"uId\":\"{0}\"}},";
			StringBuilder fieldsBuilder = new StringBuilder();
			StringBuilder entityBuilder = new StringBuilder();
			string lastSchemaName = "";
			string currentSchemaName;
			Guid lastSchemaUId = new Guid();
			int dataReaderColumnUIdOrdinal;
			using (DBExecutor dbExecutor = SystemUserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = schemaAccessListSelect.ExecuteReader(dbExecutor)) {
					dataReaderColumnUIdOrdinal = dataReader.GetOrdinal("ColumnUId");
					while (dataReader.Read()) {
						currentSchemaName = dataReader.GetString(dataReader.GetOrdinal("AccessEntitySchemaName"));
						if (currentSchemaName == lastSchemaName) {
							if (dataReader[dataReaderColumnUIdOrdinal] != DBNull.Value) {
								fieldsBuilder.Append(string.Format(fieldTpl, dataReader.GetGuid(dataReaderColumnUIdOrdinal).ToString()));
							}
						} else {
							if (!string.IsNullOrEmpty(lastSchemaName)) {
								entityBuilder.Append(string.Format(entityTpl, lastSchemaName, lastSchemaUId.ToString(), fieldsBuilder.ToString().TrimEnd(',')));
								fieldsBuilder.Clear();
							}
							if (dataReader[dataReaderColumnUIdOrdinal] != DBNull.Value) {
								fieldsBuilder.Append(string.Format(fieldTpl, dataReader.GetGuid(dataReaderColumnUIdOrdinal).ToString()));
							}
							lastSchemaName = currentSchemaName;
							lastSchemaUId = dataReader.GetGuid(dataReader.GetOrdinal("SchemaUId"));
						}
					}
				}
			}
			if (!lastSchemaUId.Equals(Guid.Empty)) {
				entityBuilder.Append(string.Format(entityTpl, lastSchemaName, lastSchemaUId.ToString(), fieldsBuilder.ToString().TrimEnd(',')));
			}
			return String.Format(wrapperTpl, entityBuilder.ToString().TrimEnd(','));
		}

		/// <summary>
		/// Gets quick add menu items configuration.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Quick add menu items configuration.</returns>
		public virtual string GetQuickAddConfig(UserConnection userConnection) {
			Dictionary<Guid, string> quickItems = new Dictionary<Guid, string> ();
			string tpl = @"{{QuickAddMenu: [{0}]}}";
			string itemTpl = @"{{itemId:'{0}',SysEditId:'{1}',name:{2},EditPageName:'{3}',TypeColumnValue:'{4}',TypeColumnName:{5},ModuleName:'{6}',EntitySchemaName:'{7}',miniPageSchema:'{8}',hasAddMiniPage:{9}}}";
			bool useMultilanguageData = !userConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			Select quickAddMenuItemsSelect = GetQuickAddMenuItemsSelect(userConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = quickAddMenuItemsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						Guid itemId = dataReader.GetColumnValue<Guid>("Id");
						Guid sysModuleEditId = dataReader.GetColumnValue<Guid>("SysModuleEditId");
						Guid typeColumnValue = dataReader.GetColumnValue<Guid>("TypeColumnValue");
						string editPageName = dataReader.GetColumnValue<string>("EditPageName");
						string name = dataReader.GetColumnValue<string>("Name");
						string caption = useMultilanguageData ? dataReader.GetColumnValue<string>("Caption") : string.Empty;
						name = Json.Serialize(caption.IsNullOrEmpty() ? name : caption);
						string typeColumnName = Json.Serialize(String.Empty);
						Guid sysEntitySchemaUId = dataReader.GetColumnValue<Guid>("SysEntitySchemaUId");
						string entitySchemaName = dataReader.GetColumnValue<string>("EntityName");
						string moduleName = dataReader.GetColumnValue<string>("ModuleName");

						bool rightLevel = string.IsNullOrEmpty(entitySchemaName) ? true :
							userConnection.DBSecurityEngine.GetIsEntitySchemaAppendingAllowed(entitySchemaName);
						Guid columnUId = dataReader.GetColumnValue<Guid>("TypeColumnUId");
						Guid miniPageSchemaUId = dataReader.GetColumnValue<Guid>("MiniPageSchemaUId");
						string miniPageModes = dataReader.GetColumnValue<string>("MiniPageModes");
						bool hasAddMiniPage = HasSchemaEditAddMiniPage(userConnection, entitySchemaName, miniPageModes);
						if (columnUId != null && columnUId != Guid.Empty) {
							typeColumnName = Json.Serialize(userConnection.EntitySchemaManager.GetInstanceByUId(sysEntitySchemaUId).Columns.GetByUId((Guid)columnUId).Name);
						}
						if (!quickItems.ContainsKey(itemId) && rightLevel) {
							quickItems.Add(itemId, string.Format(itemTpl, itemId, sysModuleEditId, name, editPageName, typeColumnValue, typeColumnName, moduleName, entitySchemaName, miniPageSchemaUId, hasAddMiniPage.ToString().ToLower()));
						}
					}
				}
			}
			var items = string.Join(",", quickItems.Select(x => x.Value));
			return string.Format(tpl, items);
		}

		public virtual string GetClientUnitSchemaDescriptors(UserConnection userConnection) {
			userConnection.CheckArgumentNull("userConnection");
			ClientUnitSchemaManager clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			var localCache = GetLocalCache(userConnection);
			string clientUnitSchemaManagerHash = clientUnitSchemaManager.GetHash();
			string entitySchemaManagerHash = entitySchemaManager.GetHash();
			string key = string.Concat(clientUnitSchemaManagerHash, entitySchemaManagerHash,
				userConnection.CurrentUser.Culture.Name);
			string descriptors;
			lock (Lock) {
				descriptors = (string)localCache[key];
				if (descriptors.IsNullOrEmpty()) {
					var sb = new StringBuilder();
					sb.AppendLine("{");
					IEnumerable<ISchemaManagerItem<ClientUnitSchema>> clientUnitSchemaItems =
						clientUnitSchemaManager.GetItems();
					AddItemDescriptors(sb, clientUnitSchemaItems);
					IEnumerable<ISchemaManagerItem<EntitySchema>> entitySchemaItems = entitySchemaManager.GetItems();
					AddItemDescriptors(sb, entitySchemaItems);
					sb.AppendLine("}");
					descriptors = sb.ToString();
					localCache[key] = descriptors;
				}
			}
			return descriptors;
		}

		public virtual string GetConfigurationScript(UserConnection userConnection) {
			userConnection.CheckArgumentNull("userConnection");
			var localCache = GetLocalCache(userConnection);
			string key = GetSessionCacheKey(userConnection);
			string resultScript;
			string cachedScript = (string)localCache[key];
			if (cachedScript.IsNullOrEmpty()) {
				Dictionary<string, string> config = GetConfigurationStructuresScripts(userConnection);
				var sb = new StringBuilder();
				foreach (KeyValuePair<string, string> configPropety in config) {
					sb.Append("BPMSoft.configuration.");
					sb.Append(configPropety.Key);
					sb.Append("=");
					sb.Append(configPropety.Value);
					sb.Append(";");
					sb.AppendLine();
				}
				AppendRequestsCachingOptions(sb);
				AppendMinSearchCharsCountSetting(sb);
				if (GlobalAppSettings.FeatureUseViewModuleCaching) {
					sb.Append(string.Join(Environment.NewLine,
						GetLessConstantsScript(userConnection),
						GetSysSettingsHashScript(userConnection),
						GetPreloadedFeatures(userConnection),
						GetGoogleTagManagerScript(userConnection),
						GetDefaultIntroPageNameScript(userConnection),
						GetValidUserTasksByDefault(userConnection),
						GetCustomConfigurationScript(userConnection)
					));
				}
				cachedScript = sb.ToString();
				localCache[key] = cachedScript;
			}

			string isFirstLoginScript = GetIsFirstLoginScript();
			string descriptorsScript = GetClientUnitSchemaDescriptorsScript(userConnection);
			if (GlobalAppSettings.FeatureUseViewModuleCaching) {
				resultScript = string.Join(Environment.NewLine, descriptorsScript, cachedScript, isFirstLoginScript);
			} else {
				string lessConstantsScript = GetLessConstantsScript(userConnection);
				string sysSettingsHashScript = GetSysSettingsHashScript(userConnection);
				string cachedFeatures = GetPreloadedFeatures(userConnection);
				string gtmScript = GetGoogleTagManagerScript(userConnection);
				string defaultIntroPageNameScript = GetDefaultIntroPageNameScript(userConnection);
				string defaultValidUserTasksScript = GetValidUserTasksByDefault(userConnection);
				string customConfigurationScript = GetCustomConfigurationScript(userConnection);
				resultScript = string.Join(Environment.NewLine, descriptorsScript, cachedScript,
					isFirstLoginScript, lessConstantsScript, sysSettingsHashScript, cachedFeatures,
					gtmScript, defaultIntroPageNameScript, defaultValidUserTasksScript, customConfigurationScript);
			}
			resultScript += GetEnableSanitizeHtmlScript(userConnection);
			return resultScript;
		}

		public virtual ConfigurationData GetConfigurationData(UserConnection userConnection) {
			return new ConfigurationData {
				ModulesStructure = GetModulesStructure(userConnection),
				EntitiesStructure = GetEntitiesStructure(userConnection)
			};
		}

		/// <summary>
		/// Forms structure data based filtered by entity names collection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="entityNames">Collection of entity names.</param>
		/// <returns>Filtered structures data.</returns>
		public virtual ConfigurationData GetConfigurationData(UserConnection userConnection, IEnumerable<string> entityNames) {
			return new ConfigurationData {
				ModulesStructure = GetModulesStructure(userConnection, entityNames),
				EntitiesStructure = GetEntitiesStructure(userConnection, entityNames)
			};
		}

		/// <summary>
		/// Returns preloaded features configuration script.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Preloaded features string.</returns>
		public string GetPreloadedFeatures(UserConnection userConnection) {
			var featureStates = userConnection.GetFeatureStates();
			string template = "{1}:{{state:{0},code:{1}}}";
			var preLoadedFeaturesString = string.Join(",", featureStates.Select(f =>
				string.Format(template, Json.Serialize(f.Value), Json.Serialize(f.Key))));
			return string.Format("BPMSoft.preLoadedFeatures={{{0}}};", preLoadedFeaturesString);
		}

		public virtual string GetModuleItemsDescriptors(UserConnection userConnection) {
			var moduleItems = new List<Guid>();
			var moduleItemsSelect = new Select(userConnection)
					.Column("SysModuleEntity", "SysEntitySchemaUId")
					.Column("CardModuleUId")
					.Column("CardSchemaUId")
					.Column("SectionModuleSchemaUId")
					.Column("SectionSchemaUId")
				.From("SysModule")
					.InnerJoin("SysModuleEntity").On("SysModule", "SysModuleEntityId").IsEqual("SysModuleEntity","Id") as Select;
			var rootSchemaPaths = new StringBuilder();
			var columns = new List<string> {
				"SysEntitySchemaUId",
				"CardModuleUId",
				"CardSchemaUId",
				"SectionModuleSchemaUId",
				"SectionSchemaUId"
			};
			var clientUnitSchemaManager = userConnection.ClientUnitSchemaManager;
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var clientUnitSchemaDecorator = new ClientUnitSchemaDecorator(userConnection.AppConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = moduleItemsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						foreach (string columnName in columns) {
							var columnValue = dataReader.GetColumnValue<Guid>(columnName);
							if (!columnValue.Equals(Guid.Empty) && !moduleItems.Contains(columnValue)) {
								moduleItems.Add(columnValue);
								switch (columnName) {
									case "SysEntitySchemaUId":
										EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(columnValue);
										rootSchemaPaths.AppendLine(entitySchema.Name + ":" + clientUnitSchemaDecorator.GetSchemaDescriptor(entitySchema) + ",");
										break;
									default:
										ClientUnitSchema clientUnitSchema = clientUnitSchemaManager.GetInstanceByUId(columnValue);
										rootSchemaPaths.AppendLine(clientUnitSchema.Name + ":" + clientUnitSchemaDecorator.GetSchemaDescriptor(clientUnitSchema) + ",");
										break;
								}
							}
						}
					}
				}
			}
			ClientUnitSchema viewModuleSchema = clientUnitSchemaManager.GetInstanceByName("ViewModule");
			rootSchemaPaths.AppendLine(viewModuleSchema.Name + ":" + clientUnitSchemaDecorator.GetSchemaDescriptor(viewModuleSchema));
			return "{" + Environment.NewLine + rootSchemaPaths.ToString() + "}";
		}

		public static void ClearCache(UserConnection userConnection) {
			var localCache = GetLocalCache(userConnection);
			string key = GetSessionCacheKey(userConnection);
			localCache.Remove(key);
		}

		public static void ClearCache() {
			var userConnection = (UserConnection)HttpContext.Current?.Session["UserConnection"];
			if (userConnection != null) {
				var configurationSectionHelper = new ConfigurationSectionHelper(userConnection);
				configurationSectionHelper.ExpireLoginLocalCache();
			}
		}

		public void ExpireLoginLocalCache() {
			ICacheStore localCache = GetLocalCache(_userConnection);
			localCache.ExpireGroup(LocalCacheGroupName);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigurationData

	public class ConfigurationData
	{
		public Dictionary<string, ModuleStructure> ModulesStructure {
			get;
			set;
		}

		public Dictionary<Guid, EntityStructure> EntitiesStructure {
			get;
			set;
		}
	}

	#endregion

	#region Class: ModuleStructure

	public class ModuleStructure
	{

		public string ImageId {
			get;
			set;
		}

		public string LogoId {
			get;
			set;
		}

		public string ModuleId {
			get;
			set;
		}

		public string Module {
			get;
			set;
		}

		public string EntitySchemaUId {
			get;
			set;
		}

		public string ModuleCaption {
			get;
			set;
		}

		public string ModuleHeader {
			get;
			set;
		}

		public string SectionModule {
			get;
			set;
		}

		public string SectionSchema {
			get;
			set;
		}

		public string CardModule {
			get;
			set;
		}

		public string CardSchema {
			get;
			set;
		}

		public string MiniPageSchema {
			get;
			set;
		}

		public string Attribute {
			get;
			set;
		}

		public string Hide {
			get;
			set;
		}

		public string Workplace {
			get;
			set;
		}

		public string TypeColumnValue {
			get;
			set;
		}

		public List<PageStructure> PagesStructure {
			get;
			set;
		}

		public string VisaSchemaUId {
			get;
			set;
		}

		public string VisaSchemaName {
			get;
			set;
		}


		public override string ToString() {
			var moduleStructure = new StringBuilder(Module);
			moduleStructure.Append(":{");
			AddProperty(moduleStructure, "imageId", ImageId);
			AddProperty(moduleStructure, "logoId", LogoId);
			AddProperty(moduleStructure, "moduleId", ModuleId);
			AddProperty(moduleStructure, "moduleCaption", ModuleCaption);
			AddProperty(moduleStructure, "moduleHeader", ModuleHeader);
			AddProperty(moduleStructure, "entitySchemaName", Module);
			AddProperty(moduleStructure, "entitySchemaUId", EntitySchemaUId);
			AddProperty(moduleStructure, "sectionModule", SectionModule);
			AddProperty(moduleStructure, "sectionSchema", SectionSchema);
			AddProperty(moduleStructure, "cardModule", CardModule);
			AddProperty(moduleStructure, "cardSchema", CardSchema);
			AddProperty(moduleStructure, "miniPageSchema", MiniPageSchema);
			AddProperty(moduleStructure, "attribute", Attribute);
			AddProperty(moduleStructure, "workplace", Workplace);
			AddProperty(moduleStructure, "visaSchemaUId", VisaSchemaUId);
			AddProperty(moduleStructure, "visaSchemaName", VisaSchemaName);
			if (SectionSchema == "SysProcessLogSection") {
				AddProperty(moduleStructure, "hide", "true");
			} else {
				AddProperty(moduleStructure, "hide", Hide);
			}
			AddProperty(moduleStructure, "typeColumnValue", TypeColumnValue);
			if (PagesStructure != null && PagesStructure.Count > 0) {
				moduleStructure.Append("pages:[");
				var index = 0;
				foreach (var pageStructure in PagesStructure) {
					moduleStructure.Append("{");
					bool added = false;
					added = AddProperty(moduleStructure, "captionLcz", pageStructure.CaptionLcz) || added;
					added = AddProperty(moduleStructure, "caption", pageStructure.Caption) || added;
					added = AddProperty(moduleStructure, "name", pageStructure.Name) || added;
					added = AddProperty(moduleStructure, "UId", pageStructure.UId) || added;
					added = AddProperty(moduleStructure, "cardSchema", pageStructure.CardSchema) || added;
					added = AddProperty(moduleStructure, "miniPageSchema", pageStructure.MiniPageSchema) || added;
					added = AddProperty(moduleStructure, "moduleEditId", pageStructure.ModuleEditId) || added;
					if (added) {
						moduleStructure.Length = moduleStructure.Length - 1;
						moduleStructure.Append("}");
						if (index != PagesStructure.Count - 1) {
							moduleStructure.Append(",");
							index++;
						}
					} else {
						moduleStructure.Length = moduleStructure.Length - 1;
					}
				}
				moduleStructure.Append("]");
			} else {
				moduleStructure.Length = moduleStructure.Length - 1;
			}
			moduleStructure.Append("}");
			return moduleStructure.ToString();
		}

		/// <summary>
		/// Adds "propertyName: propertyValue, " - formatted string.
		/// </summary>
		/// <param name="destination">Destination string.</param>
		/// <param name="propertyName">Property name.</param>
		/// <param name="propertyValue">Property value.</param>
		/// <returns>True, if formatted string was added.</returns>
		private bool AddProperty(StringBuilder destination, string propertyName, string propertyValue) {
			if (propertyValue.IsNotNullOrEmpty()) {
				destination.Append(propertyName);
				destination.Append(":");
				destination.Append(Json.Serialize(propertyValue));
				destination.Append(",");
				return true;
			}
			return false;
		}
	}

	#endregion

	#region Class: EntityStructure

	public class EntityStructure
	{
		public string EntityName {
			get;
			set;
		}
		public string SearchRowSchema {
			get;
			set;
		}
		public string Attribute {
			get;
			set;
		}
		public string EntitySchemaUId {
			get;
			set;
		}
		public List<PageStructure> PagesStructure {
			get;
			set;
		}
	}

	#endregion

	#region Class: PageStructure

	public class PageStructure
	{
		public string CaptionLcz {
			get;
			set;
		}
		public string Caption {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public string UId {
			get;
			set;
		}
		public string ModuleEditId {
			get;
			set;
		}
		public string CardSchema {
			get;
			set;
		}
		public string MiniPageSchema {
			get;
			set;
		}
		public string MiniPageModes {
			get;
			set;
		}
	}

	#endregion

}

