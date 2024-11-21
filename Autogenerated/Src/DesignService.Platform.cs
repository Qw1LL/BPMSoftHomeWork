namespace BPMSoft.Configuration.DesignService
{
	using System;
#if !NETSTANDARD2_0
	using System.CodeDom.Compiler;
#endif
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Packages;
	using BPMSoft.Core.Process;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Nui.ServiceModel.WebService;
	using BPMSoft.UI.WebControls;
	using BPMSoft.UI.WebControls.ResourceHandlers;
	using BPMSoft.Web.Http.Abstractions;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DesignService
	{

		#region Constants: Private

		private const string SchemaDataNameTemplate = "SectionDesigner_{0}_{1}";
		private const string SqlScriptNameTemplate = "SectionDesigner_{0}_ModuleEditDifScript{1}";

		#endregion

		#region Fields: Private

		private static readonly object _lockObject = new object();

		#endregion

		#region Enums

		public enum ModificationType
		{
			New = 0,
			Modified = 1,
			Deleted = 2
		}

		#endregion

		#region Utilities

		public static class DesignServiceUtilities
		{

			#region Methods: Public

			public static Guid GetPackageUId(UserConnection userConnection) {
				var schemaDesignerUtilities = new SchemaDesignerUtilities(userConnection);
				return schemaDesignerUtilities.ForceGetCurrentPackageUId();
			}

			public static Dictionary<Guid, string> GetUserPackagesInfo(UserConnection userConnection) {
				Dictionary<Guid, string> result = new Dictionary<Guid, string>();
				var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysPackage");
				esq.IsDistinct = true;
				esq.AddColumn("UId");
				var nameColumn = esq.AddColumn("Name");
				nameColumn.OrderByAsc();
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Maintainer", userConnection.Maintainer));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "InstallType", SysPackageInstallType.SourceControl));
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysWorkspace", userConnection.Workspace.Id));
				var packages = esq.GetEntityCollection(userConnection);
				foreach (var package in packages) {
					Guid uId = package.GetTypedColumnValue<Guid>("UId");
					string name = package.GetTypedColumnValue<string>("Name");
					result.Add(uId, name);
				}
				return result;
			}

			public static DataValueType GetCoreDataValueType(EntitySchemaColumnModifiedData columnConfig, UserConnection userConnection) {
				string clientDataValueTypeName = columnConfig.DataValueType.ToString();
				var columnDataValueTypeName = (clientDataValueTypeName == "Blob") ? "Binary" : clientDataValueTypeName;
				if (columnDataValueTypeName.Contains("Float")) {
					switch (columnConfig.Precision) {
						case 1:
							columnDataValueTypeName = "Float1";
							break;
						case 3:
							columnDataValueTypeName = "Float3";
							break;
						case 4:
							columnDataValueTypeName = "Float4";
							break;
						default:
							columnDataValueTypeName = "Float2";
							break;
					}
				} else if (columnDataValueTypeName.Contains("Text")) {
					switch (columnConfig.Size) {
						case 50:
							columnDataValueTypeName = "ShortText";
							break;
						case 250:
							columnDataValueTypeName = "MediumText";
							break;
						case 500:
							columnDataValueTypeName = "LongText";
							break;
						default:
							columnDataValueTypeName = "MaxSizeText";
							break;
					}
				}
				var resultDataValuetype = userConnection.DataValueTypeManager.GetInstanceByName(columnDataValueTypeName);
				return resultDataValuetype;
			}

			public static (Guid UId, Guid Id) GetSchemaUIdInPackage(UserConnection userConnection, string schemaName, Guid packageUId) {
				Guid workspaceId = userConnection.Workspace.Id;
				if (string.IsNullOrEmpty(schemaName)) {
					new ArgumentNullOrEmptyException("schemaName");
				}
				Select select = new Select(userConnection)
						.Column("SysSchema", "UId")
						.Column("SysSchema", "Id")
					.From("SysSchema")
					.InnerJoin("SysPackage").On("SysPackage", "Id").IsEqual("SysSchema", "SysPackageId")
					.Where("SysPackage", "UId").IsEqual(Column.Parameter(packageUId))
					.And("SysPackage", "SysWorkspaceId").IsEqual(Column.Parameter(workspaceId))
					.And("SysSchema", "Name").IsEqual(Column.Parameter(schemaName))
					.UnionAll(
						new Select(userConnection)
								.Column("SysSchema", "UId")
								.Column("SysSchema", "Id")
							.From("SysSchema")
							.InnerJoin("SysSchema").As("ParentSchema").On("ParentSchema", "Id").IsEqual("SysSchema", "ParentId")
							.InnerJoin("SysPackage").On("SysPackage", "Id").IsEqual("SysSchema", "SysPackageId")
							.Where("SysSchema", "ExtendParent").IsEqual(Column.Parameter(true))
							.And("SysPackage", "UId").IsEqual(Column.Parameter(packageUId))
							.And("SysPackage", "SysWorkspaceId").IsEqual(Column.Parameter(workspaceId))
							.And("ParentSchema", "Name").IsEqual(Column.Parameter(schemaName)) as Select
					) as Select;
				using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
					using (IDataReader dr = select.ExecuteReader(dbExecutor)) {
						if (dr.Read()) {
							return (dr.GetColumnValue<Guid>("UId"), dr.GetColumnValue<Guid>("Id"));
						}
					}
				}
				return (Guid.Empty, Guid.Empty);
			}

			#endregion

		}

		#endregion

		#region DesignData

		public class DesignData
		{

			public SchemaManager SchemaManager {
				get;
				set;
			}

			public Dictionary<string, Data[]> Data {
				get;
				set;
			}

			public UserProfile GridSettings {
				get;
				set;
			}

			public List<UserProfile> DetailGridSettings {
				get;
				set;
			}

			public string[] SchemaNameSequence {
				get;
				set;
			}

			public string SectionCode {
				get;
				set;
			}

			public Guid SectionTypeColumnUId {
				get;
				set;
			}

			public string SectionEntitySchemaName {
				get;
				set;
			}

			public Guid CurrentPackageUId {
				get;
				set;
			}

		}

		public class Data
		{

			#region Properties: Private

			private UserConnection _userConnection;
			private UserConnection UserConnection {
				get {
					if (_userConnection == null) {
						_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"];
					}
					return _userConnection;
				}
			}

			private EntitySchemaManager EntitySchemaManager {
				get {
					return UserConnection.EntitySchemaManager;
				}
			}

			private UserConnection SystemUserConnection {
				get {
					return UserConnection.AppConnection.SystemUserConnection;
				}
			}

			#endregion

			#region Properties: Public

			public DataMetaInfo MetaInfo {
				get;
				set;
			}

			public Guid Id {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public Guid ApplyChanges(string SchemaName) {
				if (this.MetaInfo == null) {
					return Guid.Empty;
				}
				var entitySchema = EntitySchemaManager.GetInstanceByName(SchemaName);
				var entity = entitySchema.CreateEntity(SystemUserConnection);
				if (MetaInfo.ModificationType != ModificationType.New) {
					if (!entity.FetchFromDB(Id)) {
						return Guid.Empty;
					}
				} else {
					entity.SetDefColumnValues();
				}
				if (MetaInfo.ModificationType == ModificationType.Deleted) {
					entity.Delete();
					return Guid.Empty;
				} else {
					var entitySchemaColumns = MetaInfo.ModifiedData;
					if (entitySchemaColumns != null) {
						var entityColumns = entity.Schema.Columns;
						foreach (var entitySchemaColumn in entitySchemaColumns) {
							var column = entityColumns.GetByName(entitySchemaColumn.Key);
							object value = entitySchemaColumn.Value;
							if (column.DataValueType is BPMSoft.Core.BooleanDataValueType) {
								value = SystemUserConnection.DBTypeConverter.DBValueToBool(value);
							}
							entity.SetColumnValue(column.ColumnValueName, value);
						}
					}
					entity.Save();
					return entity.PrimaryColumnValue;
				}
			}

			#endregion

		}

		public class DataMetaInfo
		{

			public ModificationType ModificationType {
				get;
				set;
			}

			public Dictionary<string, object> ModifiedData {
				get;
				set;
			}

		}

		public class SchemaManager
		{

			public EntitySchemaMetaInfo[] Entity {
				get;
				set;
			}

			public ClientUnitMetaInfo[] ClientUnit {
				get;
				set;
			}

		}

		public class ClientUnitMetaInfo
		{

			#region Properties: Private

			private UserConnection _userConnection;
			private UserConnection UserConnection {
				get {
					return _userConnection ?? (_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"]);
				}
			}

			private ClientUnitSchemaManager ClientUnitSchemaManager {
				get {
					return UserConnection.Workspace.SchemaManagerProvider
						.GetManager("ClientUnitSchemaManager") as ClientUnitSchemaManager;
				}
			}

			private EntitySchemaManager EntitySchemaManager {
				get {
					return UserConnection.Workspace.SchemaManagerProvider
						.GetManager("EntitySchemaManager") as EntitySchemaManager;
				}
			}

			private Guid _workspaceId = Guid.Empty;
			private Guid WorkspaceId {
				get {
					if (_workspaceId.IsEmpty()) {
						_workspaceId = UserConnection.Workspace.Id;
					}
					return _workspaceId;
				}
			}

			private UserConnection SystemUserConnection {
				get {
					return UserConnection.AppConnection.SystemUserConnection;
				}
			}

			#endregion

			#region Methods: Private

			private static string GetJavaScriptSchemaType(ClientUnitSchemaType clientUnitSchemaType) {
				return "BPMSoft.SchemaType." + clientUnitSchemaType.ToString().ToJavaScriptEnumStyle();
			}

			private static string GetClientUnitAutogeneratedCode(ClientUnitSchemaType clientUnitSchemaType) {
				string result = string.Empty;
				switch (clientUnitSchemaType) {
					case ClientUnitSchemaType.EditViewModelSchema:
					case ClientUnitSchemaType.ModuleViewModelSchema:
					case ClientUnitSchemaType.GridDetailViewModelSchema:
						result =
							"define(" + ClientUnitSchemaDecorator.StructureNameTemplate + ", ["
								+ ClientUnitSchemaDecorator.ResourceNameTemplate + "], function(resources) {{"
								+ "return {{"
								+ "schemaUId:'{2}',"
								+ "schemaName:'{3}',"
								+ "parentSchemaUId:'{4}',"
								+ "extendParent:{5},"
								+ "type:" + GetJavaScriptSchemaType(clientUnitSchemaType) + ","
								+ "entitySchema:'',name:'',"
								+ ClientUnitSchemaDecorator.StructureExtendParameter + ","
								+ "schema:{{leftPanel:[],rightPanel:[],actions:[],analytics:[]}},"
								+ "methods:{{}},controlsConfig:{{}},customBindings:{{}},bindings:{{}},"
								+ ClientUnitSchemaDecorator.SchemaDifferencesTemplate
								+ "}};"
								+ "}});";
						break;
					case ClientUnitSchemaType.EditControlsDetailViewModelSchema:
						result =
							"define(" + ClientUnitSchemaDecorator.StructureNameTemplate + ", ["
								+ ClientUnitSchemaDecorator.ResourceNameTemplate + "], function(resources) {{"
								+ "return {{"
								+ "schemaUId:'{2}',"
								+ "schemaName:'{3}',"
								+ "parentSchemaUId:'{4}',"
								+ "extendParent:{5},"
								+ "type:" + GetJavaScriptSchemaType(clientUnitSchemaType) + ","
								+ "entitySchema:'',name:'',"
								+ ClientUnitSchemaDecorator.StructureExtendParameter + ","
								+ "schema:{{attributes:[]}},"
								+ "methods:{{}},"
								+ ClientUnitSchemaDecorator.SchemaDifferencesTemplate
								+ "}};"
								+ "}});";
						break;
				}
				return result;
			}

			private void UpdateSchema(ClientUnitSchema schema, string schemaName, LocalizableString schemaCaption, string schemaBody,
					ClientUnitSchemaType schemaType, bool extendParent, string entitySchemaName) {
				schema.Name = schemaName;
				schema.Caption = schemaCaption;
				schema.ExtendParent = extendParent;
				schema.SchemaType = schemaType;
				schema.Body = schemaBody;
				if (string.IsNullOrEmpty(schema.AutogeneratedCode)) {
					schema.AutogeneratedCode = GetClientUnitAutogeneratedCode(schemaType);
				}
			}

			private void UpdateSchemaLocalizableStrings(ClientUnitSchema schema, Dictionary<string, string> localizableStrings) {
				if (localizableStrings != null) {
					foreach (var localizableString in localizableStrings) {
						SchemaLocalizableString schemaLocalizableStringItem = schema.LocalizableStrings.FindByName(localizableString.Key);
						if (schemaLocalizableStringItem == null) {
							schemaLocalizableStringItem = new SchemaLocalizableString(Guid.NewGuid(), localizableString.Key);
							schema.LocalizableStrings.Add(schemaLocalizableStringItem);
						}
						schemaLocalizableStringItem.Value = (LocalizableString)localizableString.Value;
						schemaLocalizableStringItem.ModifiedInSchemaUId = schema.UId;
					}
				}
			}

			private Guid GetClientUnitSchemaRealUId(Guid schemaRealUId) {
				Guid result = schemaRealUId;
				var parentItem = ClientUnitSchemaManager.FindItemByUId(schemaRealUId);
				if (parentItem == null) {
					var clientUnitScheme = ClientUnitSchemaManager.GetItems();
					foreach (var managerItem in clientUnitScheme) {
						var item = managerItem as ManagerItem<ClientUnitSchema>;
						if (schemaRealUId == item.RealUId) {
							result = item.UId;
							break;
						}
					}
				}
				return result;
			}

			private Guid DesignClientUnitSchema() {
				ISchemaManagerItem managerItem;
				ClientUnitSchema schema;
				ClientUnitSchemaStructure schemaStructure = ModifiedData.Structure;
				ClientUnitSchemaResources schemaResources = ModifiedData.Resources;
				string schemaName = schemaStructure.SchemaName;
				Guid schemaUId = schemaStructure.SchemaUId;
				string schemaCaption = schemaStructure.SchemaCaption;
				string schemaBody = ModifiedData.Body;
				string entitySchemaName = ModifiedData.EntitySchemaName;
				bool extendParent = schemaStructure.ExtendParent;
				Guid parentSchemaUId = GetClientUnitSchemaRealUId(schemaStructure.ParentSchemaUId);
				ClientUnitSchemaType schemaType = schemaStructure.Type;
				if (schemaType == 0) {
					schemaType = ClientUnitSchemaType.Module;
				}
				var existingSchema = ClientUnitSchemaManager.FindItemByName(schemaName);
				if (existingSchema == null) {
					managerItem = ClientUnitSchemaManager.CreateSchema(schemaName, null, SystemUserConnection, schemaUId, true);
					managerItem.Caption = schemaCaption;
					schema = managerItem.Instance as ClientUnitSchema;
					schema.ParentSchemaUId = parentSchemaUId;
				} else {
					var resultPair = DesignServiceUtilities.GetSchemaUIdInPackage(SystemUserConnection, schemaName, PackageUId);
					Guid realUId = resultPair.UId;
					Guid schemaId = resultPair.Id;
					if (!realUId.IsEmpty()) {
						managerItem = ClientUnitSchemaManager.DesignItem(SystemUserConnection, realUId);
						managerItem.Caption = schemaCaption;
						managerItem.Id = schemaId;
						schema = managerItem.Instance as ClientUnitSchema;
						schema.Id = schemaId;
						entitySchemaName = null;
					} else {
						schemaUId = Guid.NewGuid();
						extendParent = true;
						managerItem = ClientUnitSchemaManager.CreateSchema(schemaName, existingSchema.Instance, SystemUserConnection, schemaUId, false);
						managerItem.Caption = schemaCaption;
						schema = managerItem.Instance as ClientUnitSchema;
					}
				}
				UpdateSchema(schema, schemaName, schemaCaption, schemaBody, schemaType, extendParent, entitySchemaName);
				UpdateSchemaLocalizableStrings(schema, ModifiedData.Resources.LocalizableStrings);
				Guid itemId = managerItem.Id;
				var managerItemUId = managerItem.UId;
				ClientUnitSchemaManager.SaveDesignedItemIdInSessionData(SystemUserConnection, managerItemUId, itemId);
				ClientUnitSchemaManager.SaveDesignedItemPackageUIdInSessionData(SystemUserConnection, managerItemUId, PackageUId);
				ClientUnitSchemaManager.SaveDesignedItemInSessionData(SystemUserConnection, managerItem.Instance as MetaSchema, managerItemUId);
				ClientUnitSchemaManager.SaveSchema(managerItemUId, true, SystemUserConnection);
				return schema.UId;
			}

			#endregion

			#region Properties: Public

			public ClientUnitModifiedData ModifiedData {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public Guid ApplyChanges() {
				return DesignClientUnitSchema();
			}

			#endregion

		}

		public class ClientUnitModifiedData
		{

			#region Properties: Public

			public ClientUnitSchemaResources Resources {
				get;
				set;
			}

			public ClientUnitSchemaStructure Structure {
				get;
				set;
			}

			public string Body {
				get;
				set;
			}

			public string EntitySchemaName {
				get;
				set;
			}

			#endregion

		}

		public class ClientUnitSchemaStructure
		{

			#region Properties: Public

			public ClientUnitSchemaType Type {
				get;
				set;
			}

			public Guid SchemaUId {
				get;
				set;
			}

			public string SchemaName {
				get;
				set;
			}

			public string SchemaCaption {
				get;
				set;
			}

			public bool ExtendParent {
				get;
				set;
			}

			public Guid ParentSchemaUId {
				get;
				set;
			}

			#endregion

		}

		public class ClientUnitSchemaResources
		{

			#region Properties: Public

			public Dictionary<string, string> LocalizableStrings {
				get;
				set;
			}

			#endregion

		}

		public class EntitySchemaMetaInfo
		{

			#region Properties: Private

			private UserConnection _userConnection;
			private UserConnection UserConnection {
				get {
					return _userConnection ?? (_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"]);
				}
			}

			private EntitySchemaManager EntitySchemaManager {
				get {
					return UserConnection.EntitySchemaManager;
				}
			}

			private Guid _workspaceId = Guid.Empty;
			private Guid WorkspaceId {
				get {
					if (_workspaceId.IsEmpty()) {
						_workspaceId = UserConnection.Workspace.Id;
					}
					return _workspaceId;
				}
			}

			private UserConnection SystemUserConnection {
				get {
					return UserConnection.AppConnection.SystemUserConnection;
				}
			}

			#endregion

			#region Methods: Private

			private void ChangeColumn(EntitySchema schema, EntitySchemaColumnModifiedData columnConfig) {
				Guid designedColumnUId = columnConfig.UId;
				EntitySchemaColumn column = schema.Columns.FindByUId(designedColumnUId);
				var coreDataValueType = DesignServiceUtilities.GetCoreDataValueType(columnConfig, UserConnection);
				if (column == null) {
					column = schema.AddColumn(coreDataValueType.Name);
					column.UId = columnConfig.UId;
				} else {
					column.DataValueType = coreDataValueType;
				}
				column.Caption = (LocalizableString)columnConfig.Caption;
				if (!column.IsInherited) {
					column.Name = columnConfig.Name;
				}
				if (column.DataValueType.IsLookup) {
					column.IsIndexed = true;
					Guid referenceSchemaUId = Guid.Empty;
					if (column.DataValueType.Name == "ImageLookup") {
						referenceSchemaUId = EntitySchemaManager.GetItemByName("SysImage").UId;
					} else {
						string referenceSchemaName = columnConfig.ReferenceSchemaName;
						if (!string.IsNullOrEmpty(referenceSchemaName)) {
							IManagerItem referenceSchemaItem = EntitySchemaManager.GetItemByName(referenceSchemaName);
							referenceSchemaUId = referenceSchemaItem.UId;
						} else {
							referenceSchemaUId = columnConfig.ReferenceSchemaUId;
						}
					}
					column.ReferenceSchemaUId = referenceSchemaUId;
				}
				column.RequirementType = (columnConfig.IsRequired) ? EntitySchemaColumnRequirementType.ApplicationLevel : EntitySchemaColumnRequirementType.None;
			}

			private void SetEntitySchemaPrimaryColumns(EntitySchema schema) {
				if (!String.IsNullOrEmpty(ModifiedData.PrimaryColumnName)) {
					schema.PrimaryColumn = schema.Columns.FindByName(ModifiedData.PrimaryColumnName);
				}
				if (!String.IsNullOrEmpty(ModifiedData.PrimaryDisplayColumnName)) {
					schema.PrimaryDisplayColumn = schema.Columns.FindByName(ModifiedData.PrimaryDisplayColumnName);
				}
				if (!String.IsNullOrEmpty(ModifiedData.HierarchicalColumnName)) {
					schema.HierarchyColumn = schema.Columns.FindByName(ModifiedData.HierarchicalColumnName);
				}
			}

			private void UpdateSchema(EntitySchema schema, string schemaName, LocalizableString schemaCaption, bool extendParent) {
				schema.Name = schemaName;
				schema.Caption = schemaCaption;
				schema.ExtendParent = extendParent;
			}

			private ISchemaManagerItem DesignEntitySchema() {
				ISchemaManagerItem managerItem;
				EntitySchema schema;
				string schemaName = ModifiedData.Name;
				LocalizableString schemaCaption = (LocalizableString)ModifiedData.Caption;
				bool extendParent = false;
				var existingSchema = EntitySchemaManager.FindItemByName(schemaName);
				if (existingSchema == null) {
					Guid parentSchemaId = ModifiedData.RootEntitySchemaId;
					var parentSchema = EntitySchemaManager.FindItemByUId(parentSchemaId);
					managerItem = EntitySchemaManager.CreateSchema(schemaName, parentSchema.Instance, SystemUserConnection, ModifiedData.UId, true);
					schema = managerItem.Instance as EntitySchema;
					schema.AdministratedByRecords = ModifiedData.AdministratedByRecords;
				} else {
					var resultPair = DesignServiceUtilities.GetSchemaUIdInPackage(SystemUserConnection, schemaName, PackageUId);
					Guid realUId = resultPair.UId;
					Guid schemaId = resultPair.Id;
					if (!realUId.IsEmpty()) {
						managerItem = EntitySchemaManager.DesignItem(SystemUserConnection, realUId);
						managerItem.Id = schemaId;
						schema = managerItem.Instance as EntitySchema;
						schema.Id = schemaId;
						extendParent = schema.ExtendParent;
					} else {
						managerItem = EntitySchemaManager.CreateSchema(schemaName, existingSchema.Instance, SystemUserConnection, Guid.NewGuid(), false);
						managerItem.Caption = ModifiedData.Caption;
						schema = managerItem.Instance as EntitySchema;
						extendParent = true;
					}
				}
				schemaCaption = String.IsNullOrEmpty(schemaCaption) ? schema.Caption : schemaCaption;
				UpdateSchema(schema, schemaName, schemaCaption, extendParent);
				var columnCollections = ModifiedData.Columns;
				if (columnCollections != null) {
					foreach (var columnConfig in columnCollections) {
						this.ChangeColumn(managerItem.Instance as EntitySchema, columnConfig.Value);
					}
				}
				SetEntitySchemaPrimaryColumns(managerItem.Instance as EntitySchema);
				Guid itemId = managerItem.Id;
				var managerItemUId = managerItem.UId;
				EntitySchemaManager.SaveDesignedItemIdInSessionData(SystemUserConnection, managerItemUId, itemId);
				EntitySchemaManager.SaveDesignedItemPackageUIdInSessionData(SystemUserConnection, managerItemUId, PackageUId);
				var processBasedSchema = managerItem.Instance as ProcessBasedSchema;
				if (processBasedSchema != null) {
					EmbeddedProcessSchema defEmbeddedProcessSchema =
						processBasedSchema.ProcessSchemaManager.DefEmbeddedProcessSchema;
					processBasedSchema.EventsProcessSchema = new EmbeddedProcessSchema(defEmbeddedProcessSchema) {
						UId = Guid.NewGuid(),
						OwnerSchema = processBasedSchema,
						Name = processBasedSchema.Name + ProcessBasedSchema.EventsProcessPartName,
						ParentSchema = defEmbeddedProcessSchema,
						Caption = new LocalizableString(processBasedSchema.ProcessSchemaManager.ItemCaption)
					};
				}
				var processSchema = managerItem.Instance as ProcessSchema;
				if (processSchema != null) {
					UserConnection.ProcessSchemaManager
						.BuildDefEventHandlerSchemaProperties(processSchema, new DesignModeEventDescriptor());
				}
				var processUserTaskSchema = managerItem.Instance as ProcessUserTaskSchema;
				if (processUserTaskSchema != null) {
					var processUserTaskSchemaManager = UserConnection.ProcessUserTaskSchemaManager;
					processUserTaskSchemaManager.AddDefaultMethods(processUserTaskSchema);
				}
				EntitySchemaManager.SaveDesignedItemInSessionData(SystemUserConnection, managerItem.Instance as MetaSchema, managerItemUId);
				EntitySchemaManager.SaveSchema(managerItemUId, false, SystemUserConnection);
				return EntitySchemaManager.GetDesignItem(SystemUserConnection, managerItemUId);
			}

			#endregion

			#region Properties: Public

			public ModificationType ModificationType {
				get;
				set;
			}

			public EntitySchemaModifiedData ModifiedData {
				get;
				set;
			}

			#endregion

			#region Methods: Public

			public Guid ApplyChanges() {
				var managerItem = DesignEntitySchema();
				var schema = managerItem.Instance as EntitySchema;
				return schema.UId;
			}

			#endregion

		}

		public class EntitySchemaModifiedData
		{

			public bool AdministratedByRecords {
				get;
				set;
			}

			public string Caption {
				get;
				set;
			}

			public Dictionary<Guid, EntitySchemaColumnModifiedData> Columns {
				get;
				set;
			}

			public EntitySchemaColumnModifiedData HierarchicalColumn {
				get;
				set;
			}

			public string HierarchicalColumnName {
				get;
				set;
			}

			public string Name {
				get;
				set;
			}

			public EntitySchemaColumnModifiedData PrimaryColumn {
				get;
				set;
			}

			public string PrimaryColumnName {
				get;
				set;
			}

			public EntitySchemaColumnModifiedData PrimaryDisplayColumn {
				get;
				set;
			}

			public string PrimaryDisplayColumnName {
				get;
				set;
			}

			public Guid RootEntitySchemaId {
				get;
				set;
			}

			public Guid UId {
				get;
				set;
			}

		}

		public class EntitySchemaColumnModifiedData
		{

			public string Caption {
				get;
				set;
			}

			public BPMSoft.Nui.ServiceModel.DataContract.DataValueType DataValueType {
				get;
				set;
			}

			public bool IsRequired {
				get;
				set;
			}

			public bool isValueCloneable {
				get;
				set;
			}

			public string Name {
				get;
				set;
			}

			public Guid UId {
				get;
				set;
			}

			public bool IsLookup {
				get;
				set;
			}

			public EntitySchemaColumnReferenceSchemaData ReferenceSchema {
				get;
				set;
			}

			public string ReferenceSchemaName {
				get;
				set;
			}

			public Guid ReferenceSchemaUId {
				get;
				set;
			}

			public int Size {
				get;
				set;
			}

			public int Precision {
				get;
				set;
			}

		}

		public class EntitySchemaColumnReferenceSchemaData
		{

			public string Name {
				get;
				set;
			}

			public string PrimaryColumnName {
				get;
				set;
			}

			public string PrimaryDisplayColumnName {
				get;
				set;
			}

		}

		#endregion

		#region Properties: Private

		private UserConnection _userConnection;
		private UserConnection UserConnection {
			get {
				if (_userConnection == null) {
					_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"];
				}
				return _userConnection;
			}
		}

		private EntitySchemaManager EntitySchemaManager {
			get {
				return this.UserConnection.EntitySchemaManager;
			}
		}

		private Guid _workspaceId = Guid.Empty;
		private Guid WorkspaceId {
			get {
				if (_workspaceId.IsEmpty()) {
					_workspaceId = ((BPMSoft.Core.Configuration.SysBaseEntity)(UserConnection.Workspace)).Id;
				}
				return _workspaceId;
			}
		}

		private UserConnection SystemUserConnection {
			get {
				return UserConnection.AppConnection.SystemUserConnection;
			}
		}


		private static Guid PackageUId {
			get;
			set;
		}

		/// <summary>
		/// Multilingual support.
		/// </summary>
		private bool UseMultilanguageData {
			get {
				return !UserConnection.GetIsFeatureEnabled("DoNotUseMultilanguageData");
			}
		}

		#endregion

		#region Methods: Private

		private List<Guid> GetSysModuleEditDeleteList(string sectionCode, string typeObjectName) {
			List<Guid> result = new List<Guid>();
			if (!typeObjectName.IsNullOrEmpty()) {
				Select select = new Select(UserConnection)
							.Column(typeObjectName, "Id").As("Id")
						.From(typeObjectName)
						.Where().Not().Exists(
							new Select(UserConnection)
									.Column("SysModuleEdit", "Id")
								.From("SysModuleEdit")
									.InnerJoin("SysModule").On("SysModule", "SysModuleEntityId").IsEqual("SysModuleEdit", "SysModuleEntityId")
								.Where("SysModule", "Code").IsEqual(Column.Parameter(sectionCode))
									.And(typeObjectName, "Id").IsEqual("SysModuleEdit", "TypeColumnValue")
						) as Select;
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					IDataReader dr = select.ExecuteReader(dbExecutor);
					while (dr.Read()) {
						result.Add(Guid.Parse(dr.GetValue(0).ToString()));
					}
				}
			}
			return result;
		}

		private string GetSqlScriptName(string code, DBEngineType dbEngineType) {
			return string.Format(SqlScriptNameTemplate, code, dbEngineType);
		}

        public Dictionary<Guid, string> GetPackagesInfo() {
			Dictionary<Guid, string> result = new Dictionary<Guid, string>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysPackage");
			esq.IsDistinct = true;
			esq.AddColumn("UId");
			esq.AddColumn("Name");
			var packages = esq.GetEntityCollection(UserConnection);
			foreach (var package in packages) {
				Guid uId = package.GetTypedColumnValue<Guid>("UId");
				if (!result.ContainsKey(uId)) {
					string name = package.GetTypedColumnValue<string>("Name");
					result.Add(uId, name);
				}
			}
			return result;
		}

		private void UpdateSchemaData(UserConnection userConnection, List<object> entitySchemaDataUIds, string schemaName, Guid packageId, string code) {
			if (entitySchemaDataUIds.IsNullOrEmpty() || packageId.IsEmpty() || schemaName.IsNullOrEmpty()) {
				return;
			}
			string packageSchemaDataName = string.Format(SchemaDataNameTemplate, code, schemaName);
			var packageElementUtilities = new PackageElementUtilities(userConnection);
			var query = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
			query.AddAllSchemaColumns(true);
			query.Filters.Add(query.CreateFilterWithParameters(FilterComparisonType.Equal, query.RootSchema.PrimaryColumn.Name, entitySchemaDataUIds.ToArray()));
			packageElementUtilities.SavePackageSchemaData(packageSchemaDataName, packageId, query);
		}

		private static LocalizableString GetResource(string resourceName) {
			return new LocalizableString("BPMSoft.Tools.WorkspaceConsole", resourceName);
		}

        private void ApplyEntitySchemeChanges(Collection<Guid> ModifiedEntitySchemaUIds) {
			if (ModifiedEntitySchemaUIds.Count > 0) {
				var installUtilities = new PackageInstallUtilities(UserConnection);
				installUtilities.SaveSchemaDBStructure(ModifiedEntitySchemaUIds, true);
			}
		}

		private string GetSchemaInfo(string id, string name) {
			string result = string.Empty;
			result = string.Format("{{\"id\":\"{0}\", \"name\":\"{1}\"}}", id, name);
			return result;
		}

		private string GetModuleEditInfo(string ModuleCode) {
			var vwModuleEditInfoESQ = new EntitySchemaQuery(this.EntitySchemaManager, "VwModuleEditInfo");
			var idColumn = vwModuleEditInfoESQ.AddColumn("Id");
			string pageCaptionLczColumnName = UseMultilanguageData ? "PageCaptionLcz" : "PageCaptionLczOld";
			vwModuleEditInfoESQ.AddColumn("ModuleCode");
			vwModuleEditInfoESQ.AddColumn("TypeColumnValue");
			vwModuleEditInfoESQ.AddColumn("Name");
			vwModuleEditInfoESQ.AddColumn("WorkspaceId");
			vwModuleEditInfoESQ.AddColumn("RecordId");
			vwModuleEditInfoESQ.AddColumn("ActionKindCaptionLczId");
			vwModuleEditInfoESQ.AddColumn("PageCaptionLczId");
			EntitySchemaQueryColumn pageCaptionLczColumn = vwModuleEditInfoESQ.AddColumn(pageCaptionLczColumnName);
			EntitySchemaQueryColumn defaultPageCaptionColumn = vwModuleEditInfoESQ.AddColumn("DefaultPageCaption");
			vwModuleEditInfoESQ.AddColumn("Position").OrderByAsc();
			vwModuleEditInfoESQ.Filters.Add(vwModuleEditInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "ModuleCode",
				ModuleCode));
			vwModuleEditInfoESQ.Filters.Add(vwModuleEditInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "WorkspaceId",
				WorkspaceId));
			var cultureFilter = new EntitySchemaQueryFilterCollection(vwModuleEditInfoESQ);
			cultureFilter.LogicalOperation = LogicalOperationStrict.Or;
			cultureFilter.Add(vwModuleEditInfoESQ.CreateIsNullFilter("CultureId"));
			cultureFilter.Add(vwModuleEditInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "CultureId",
				UserConnection.CurrentUser.SysCultureId));
			vwModuleEditInfoESQ.Filters.Add(cultureFilter);
			var vwModuleEditInfoESQCollection = vwModuleEditInfoESQ.GetEntityCollection(UserConnection);
			string result = "[";
			if (vwModuleEditInfoESQCollection.Count > 0) {
				foreach (var moduleInfoItem in vwModuleEditInfoESQCollection) {
					string id = moduleInfoItem.GetTypedColumnValue<Guid>(idColumn.Name).ToString();
					string name = moduleInfoItem.GetTypedColumnValue<string>("Name");
					string code = moduleInfoItem.GetTypedColumnValue<string>("ModuleCode");
					string typeColumnValue = moduleInfoItem.GetTypedColumnValue<Guid>("TypeColumnValue").ToString();
					string recordId = moduleInfoItem.GetTypedColumnValue<Guid>("RecordId").ToString();
					string actionKindCaptionLczId = moduleInfoItem.GetTypedColumnValue<Guid>("ActionKindCaptionLczId").ToString();
					string pageCaptionLczId = moduleInfoItem.GetTypedColumnValue<Guid>("PageCaptionLczId").ToString();
					string position = moduleInfoItem.GetTypedColumnValue<int>("Position").ToString();
					string pageCaption = moduleInfoItem.GetTypedColumnValue<string>(pageCaptionLczColumn.Name);
					string pageCaptionLcz = Json.Serialize(pageCaption.IsNullOrEmpty() ? moduleInfoItem.GetTypedColumnValue<string>(defaultPageCaptionColumn.Name) : pageCaption);
					result += string.Format("{{\"id\":\"{0}\",\"name\":\"{1}\",\"typeColumnValue\":\"{2}\",\"moduleCode\":\"{3}\"," +
						"\"recordId\":\"{4}\",\"actionKindCaptionLczId\":\"{5}\",\"pageCaptionLczId\":\"{6}\",\"position\":{7},\"pageCaption\":{8}}},",
						id, name, typeColumnValue, code, recordId, actionKindCaptionLczId, pageCaptionLczId, position, pageCaptionLcz);
				}
			}
			result = result.Remove(result.Length - 1);
			result += "]";
			return result;
		}

		private DataValueTypeInfo InitDataValueTypeGroupInfo(string groupName, string rootTypeName, string[] subTypeNames) {
			DataValueTypeInfo result = new DataValueTypeInfo();
			result.DataValueSubTypeInfo = new List<DataValueSubTypeInfo>();
			Collection<DataValueType> groupDataValueTypes = UserConnection.DataValueTypeManager.GetDataValueTypesByGroupName(groupName);
			foreach (DataValueType item in groupDataValueTypes) {
				string dataValueTypeName = item.Name;
				if (dataValueTypeName == rootTypeName) {
					result.DataValueType = DataValueTypeExtension.GetDataValueType(dataValueTypeName);
					result.Caption = item.Caption;
				}
				if (Array.IndexOf(subTypeNames, dataValueTypeName) > -1) {
					DataValueSubTypeInfo dataValueSubType = new DataValueSubTypeInfo();
					dataValueSubType.Caption = item.Caption;
					var columnDbDataValueType = (DBDataValueType)item;
					dataValueSubType.Size = columnDbDataValueType.DBSize;
					dataValueSubType.Precision = columnDbDataValueType.DBPrecision;
					result.DataValueSubTypeInfo.Add(dataValueSubType);
				}
			};
			return result;
		}

		private Responce CheckDesignData(DesignData data, Responce response = null) {
			var result = response ?? new Responce() {
				Success = true
			};
			if (data.CurrentPackageUId.IsEmpty()) {
				result.Success = false;
				result.ErrorMessage = new LocalizableString(UserConnection.ResourceStorage, "DesignService", "LocalizableStrings.PackageIdNotSpecified.Value");
			}
			return result;
		}

		private bool ValidateSchemaMarkerComments(ClientUnitSchema clientUnitSchema, out LocalizableString validationMessage) {
			validationMessage = string.Empty;
			Regex detailRegexp = new Regex(@"(\/\*\*SCHEMA_DETAILS\*\/)([\s\S]*)(\/\*\*SCHEMA_DETAILS\*\/)");
			Regex diffRegexp = new Regex(@"(\/\*\*SCHEMA_DIFF\*\/)([\s\S]*)(\/\*\*SCHEMA_DIFF\*\/)");
			bool isValid = true;
			string schemaBody = clientUnitSchema.Body;
			ClientUnitSchemaType clientUnitSchemaType = clientUnitSchema.SchemaType;
			switch (clientUnitSchemaType) {
				case ClientUnitSchemaType.EditViewModelSchema:
					isValid = detailRegexp.IsMatch(schemaBody) && diffRegexp.IsMatch(schemaBody);
					break;
				case ClientUnitSchemaType.ModuleViewModelSchema:
				case ClientUnitSchemaType.EditControlsDetailViewModelSchema:
				case ClientUnitSchemaType.DetailViewModelSchema:
				case ClientUnitSchemaType.GridDetailViewModelSchema:
					isValid = diffRegexp.IsMatch(schemaBody);
					break;
				default:
					break;
			}
			if (!isValid) {
				validationMessage = new LocalizableString(UserConnection.ResourceStorage, "DesignService", "LocalizableStrings.MarkerCommentsNotSpecified.Value");
			}
			return isValid;
		}

		private bool ValidateSchemaDiff(ClientUnitSchema clientUnitSchema, out LocalizableString validationMessage) {
			validationMessage = string.Empty;
			Regex diffRegexp = new Regex(@"(\/\*\*SCHEMA_DIFF\*\/)([\s\S]*)(\/\*\*SCHEMA_DIFF\*\/)");
			Regex functionRegexp = new Regex(@"(\:\s*function\s*\(.*\)\s*\{[\s\S]*\})");
			string schemaBody = clientUnitSchema.Body;
			string diffContent = diffRegexp.Match(schemaBody).Value;
			bool isValid = diffRegexp.IsMatch(schemaBody) && !functionRegexp.IsMatch(diffContent);
			if (!isValid) {
				validationMessage = new LocalizableString(UserConnection.ResourceStorage, "DesignService", "LocalizableStrings.InvalidSchemaDiff.Value");
			}
			return isValid;
		}

		private void SaveDetailsProfile(List<UserProfile> gridSettings) {
			foreach (UserProfile userProfile in gridSettings) {
				UserProfileResourceHandler.SaveUserProfile(UserConnection, userProfile);
			}
		}

		#endregion

		#region DataContract

		[DataContract]
		public class Responce
		{
			[DataMember]
			public bool Success {
				get;
				set;
			}
			[DataMember]
			public string ErrorMessage {
				get;
				set;
			}
			[DataMember]
			public Dictionary<string, string> ErrorMessages {
				get;
				set;
			}
        }

		[DataContract]
		public class ModuleInfoResponse
		{
			[DataMember]
			public string ModuleName {
				get;
				set;
			}
			[DataMember]
			public string ModuleCaption {
				get;
				set;
			}
			[DataMember]
			public Guid ModuleUId {
				get;
				set;
			}
		}

		[DataContract]
		public class DataValueTypeInfoResponse
		{
			[DataMember]
			public List<DataValueTypeInfo> DataValueTypeInfoList {
				get;
				set;
			}
		}

		[DataContract]
		public class DataValueTypeInfo
		{
			[DataMember]
			public BPMSoft.Nui.ServiceModel.DataContract.DataValueType DataValueType {
				get;
				set;
			}
			[DataMember]
			public string Caption {
				get;
				set;
			}
			[DataMember]
			public List<DataValueSubTypeInfo> DataValueSubTypeInfo {
				get;
				set;
			}
		}

		[DataContract]
		public class DataValueSubTypeInfo
		{
			[DataMember]
			public string Caption {
				get;
				set;
			}
			[DataMember]
			public int Size {
				get;
				set;
			}
			[DataMember]
			public int Precision {
				get;
				set;
			}
		}

		[DataContract]
		public class AvailablePackagesInfo : Responce
		{
			[DataMember]
			public Guid CurrentPackageUId {
				get;
				set;
			}
			[DataMember]
			public Dictionary<Guid, string> AvailablePackages {
				get;
				set;
			}
		}

		#endregion

		#region OperationContract: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetModuleStructureInfo(string ModuleCode) {
			var vwSectionDesignerModuleInfoESQ = new EntitySchemaQuery(this.EntitySchemaManager, "VwSectionDesignerModuleInfo");
			var idColumn = vwSectionDesignerModuleInfoESQ.AddColumn("Id");
			string captionColumnName = UseMultilanguageData ? "Caption" : "CaptionOld";
			string headerColumnName = UseMultilanguageData ? "Header" : "HeaderOld";
			vwSectionDesignerModuleInfoESQ.AddColumn("Code");
			vwSectionDesignerModuleInfoESQ.AddColumn("Image32Id");
			vwSectionDesignerModuleInfoESQ.AddColumn("LogoId");
			vwSectionDesignerModuleInfoESQ.AddColumn("WorkspaceId");
			vwSectionDesignerModuleInfoESQ.AddColumn("WorkspaceName");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityId");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityName");
			vwSectionDesignerModuleInfoESQ.AddColumn("SectionSchemaId");
			vwSectionDesignerModuleInfoESQ.AddColumn("SectionSchemaName");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityTagId");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityTagName");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityInTagId");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityInTagName");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityFolderId");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityFolderName");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityInFolderId");
			vwSectionDesignerModuleInfoESQ.AddColumn("EntityInFolderName");
			vwSectionDesignerModuleInfoESQ.AddColumn("TypeColumnId");
			EntitySchemaQueryColumn defaultCaptionColumn = vwSectionDesignerModuleInfoESQ.AddColumn("DefaultCaption");
			EntitySchemaQueryColumn captionColumn = vwSectionDesignerModuleInfoESQ.AddColumn(captionColumnName);
			EntitySchemaQueryColumn defaultHeaderColumn = vwSectionDesignerModuleInfoESQ.AddColumn("DefaultHeader");
			EntitySchemaQueryColumn headerColumn = vwSectionDesignerModuleInfoESQ.AddColumn(headerColumnName);
			vwSectionDesignerModuleInfoESQ.AddColumn("SysModuleEntityId");
			vwSectionDesignerModuleInfoESQ.AddColumn("SysModuleCaptionLczId");
			vwSectionDesignerModuleInfoESQ.AddColumn("SysModuleHeaderLczId");
			vwSectionDesignerModuleInfoESQ.AddColumn("SectionDetailId");
			vwSectionDesignerModuleInfoESQ.AddColumn("SectionDetailName");
			vwSectionDesignerModuleInfoESQ.Filters.Add(vwSectionDesignerModuleInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Code",
				ModuleCode));
			/*vwSectionDesignerModuleInfoESQ.Filters.Add(vwSectionDesignerModuleInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "WorkspaceId", 
				WorkspaceId));*/
			vwSectionDesignerModuleInfoESQ.Filters.Add(vwSectionDesignerModuleInfoESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "CultureId",
				UserConnection.CurrentUser.SysCultureId));
			var vwSectionDesignerModuleInfoESQCollection = vwSectionDesignerModuleInfoESQ.GetEntityCollection(UserConnection);
			string result = string.Empty;
			if (vwSectionDesignerModuleInfoESQCollection.Count > 0) {
				foreach (var moduleInfoItem in vwSectionDesignerModuleInfoESQCollection) {
					string id = moduleInfoItem.GetTypedColumnValue<Guid>(idColumn.Name).ToString();
					string code = moduleInfoItem.GetTypedColumnValue<string>("Code");
					string sectionIconId = moduleInfoItem.GetTypedColumnValue<string>("Image32Id");
					string sectionLogoId = moduleInfoItem.GetTypedColumnValue<string>("LogoId");
					string workspaceId = moduleInfoItem.GetTypedColumnValue<Guid>("WorkspaceId").ToString();
					string workspaceName = moduleInfoItem.GetTypedColumnValue<string>("WorkspaceName");
					string entityId = moduleInfoItem.GetTypedColumnValue<Guid>("EntityId").ToString();
					string entityName = moduleInfoItem.GetTypedColumnValue<string>("EntityName");
					string sectionSchemaId = moduleInfoItem.GetTypedColumnValue<Guid>("SectionSchemaId").ToString();
					string sectionSchemaName = moduleInfoItem.GetTypedColumnValue<string>("SectionSchemaName");
					string entityTagId = moduleInfoItem.GetTypedColumnValue<Guid>("EntityTagId").ToString();
					string entityTagName = moduleInfoItem.GetTypedColumnValue<string>("EntityTagName");
					string entityInTagId = moduleInfoItem.GetTypedColumnValue<Guid>("EntityInTagId").ToString();
					string entityInTagName = moduleInfoItem.GetTypedColumnValue<string>("EntityInTagName");
					string entityFolderId = moduleInfoItem.GetTypedColumnValue<Guid>("EntityFolderId").ToString();
					string entityFolderName = moduleInfoItem.GetTypedColumnValue<string>("EntityFolderName");
					string entityInFolderId = moduleInfoItem.GetTypedColumnValue<Guid>("EntityInFolderId").ToString();
					string entityInFolderName = moduleInfoItem.GetTypedColumnValue<string>("EntityInFolderName");
					string typeColumnId = moduleInfoItem.GetTypedColumnValue<Guid>("TypeColumnId").ToString();
					string moduleCaption = moduleInfoItem.GetTypedColumnValue<string>(captionColumn.Name);
					string caption = Json.Serialize(moduleCaption.IsNullOrEmpty() ? moduleInfoItem.GetTypedColumnValue<string>(defaultCaptionColumn.Name) : moduleCaption);
					string moduleHeader = moduleInfoItem.GetTypedColumnValue<string>(headerColumn.Name);
					string header = Json.Serialize(moduleHeader.IsNullOrEmpty() ? moduleInfoItem.GetTypedColumnValue<string>(defaultHeaderColumn.Name) : moduleHeader);
					string sysModuleEntityId = moduleInfoItem.GetTypedColumnValue<Guid>("SysModuleEntityId").ToString();
					string sysModuleCaptionLczId = moduleInfoItem.GetTypedColumnValue<Guid>("SysModuleCaptionLczId").ToString();
					string sysModuleHeaderLczId = moduleInfoItem.GetTypedColumnValue<Guid>("SysModuleHeaderLczId").ToString();
					string sectionDetailId = moduleInfoItem.GetTypedColumnValue<Guid>("SectionDetailId").ToString();
					string sectionDetailName = Json.Serialize(moduleInfoItem.GetTypedColumnValue<string>("SectionDetailName"));
					string pages = GetModuleEditInfo(code);
					result = string.Format("{{\"id\":\"{0}\",\"code\":\"{1}\",\"workspaceId\":\"{2}\",\"workspaceName\":\"{3}\"," +
						"\"entityId\":\"{4}\",\"entityName\":\"{5}\",\"sectionSchemaId\":\"{6}\",\"sectionSchemaName\":\"{7}\"," +
						"\"entityFolderId\":\"{8}\",\"entityFolderName\":\"{9}\",\"entityInFolderId\":\"{10}\",\"entityInFolderName\":\"{11}\"," +
						"\"entityTagId\":\"{12}\",\"entityTagName\":\"{13}\",\"entityInTagId\":\"{14}\",\"entityInTagName\":\"{15}\"," +
						"\"typeColumnId\":\"{16}\",\"pages\":{17},\"caption\":{18},\"header\":{19},\"sysModuleEntityId\":\"{20}\",\"sysModuleCaptionLczId\":\"{21}\", " +
						"\"sysModuleHeaderLczId\":\"{22}\",\"sectionIconId\":\"{23}\",\"sectionDetailId\":\"{24}\",\"sectionDetailName\":{25},\"sectionLogoId\":\"{26}\"}}",
							id, code, workspaceId, workspaceName, entityId, entityName, sectionSchemaId, sectionSchemaName,
							entityFolderId, entityFolderName, entityInFolderId, entityInFolderName,
							entityTagId, entityTagName, entityInTagId, entityInTagName,
							typeColumnId, pages, caption, header, sysModuleEntityId,
							sysModuleCaptionLczId, sysModuleHeaderLczId, sectionIconId, sectionDetailId, sectionDetailName, sectionLogoId);
					break;
				}
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetEntitySchemaInfoById(string schema) {
			string result = string.Empty;
			if (!schema.IsNullOrEmpty()) {
				ISchemaManagerItem<EntitySchema> schemaItem = UserConnection.EntitySchemaManager.FindItemByUId(Guid.Parse(schema));
				if (schemaItem != null) {
					EntitySchema schemaInstance = schemaItem.Instance as EntitySchema;
					result = GetSchemaInfo(schemaInstance.Id.ToString(), schemaInstance.Name);
				}
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetEntitySchemaInfoByName(string schema) {
			string result = string.Empty;
			if (!schema.IsNullOrEmpty()) {
				ISchemaManagerItem<EntitySchema> schemaItem = UserConnection.EntitySchemaManager.FindItemByName(schema);
				if (schemaItem != null) {
					EntitySchema schemaInstance = schemaItem.Instance as EntitySchema;
					result = GetSchemaInfo(schemaInstance.Id.ToString(), schemaInstance.Name);
				}
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetClientUnitSchemaInfoById(string schema) {
			string result = string.Empty;
			if (!schema.IsNullOrEmpty()) {
				ISchemaManagerItem<ClientUnitSchema> schemaItem = UserConnection.ClientUnitSchemaManager.FindItemByUId(Guid.Parse(schema));
				if (schemaItem != null) {
					ClientUnitSchema schemaInstance = schemaItem.Instance as ClientUnitSchema;
					result = GetSchemaInfo(schemaInstance.Id.ToString(), schemaInstance.Name);
				}
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetClientUnitSchemaInfoByName(string schema) {
			string result = string.Empty;
			if (!schema.IsNullOrEmpty()) {
				ISchemaManagerItem<ClientUnitSchema> schemaItem = UserConnection.ClientUnitSchemaManager.FindItemByName(schema);
				if (schemaItem != null) {
					ClientUnitSchema schemaInstance = schemaItem.Instance as ClientUnitSchema;
					result = GetSchemaInfo(schemaInstance.Id.ToString(), schemaInstance.Name);
				}
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string CreateEntitySchema(string schema) {
			string result = GetEntitySchemaInfoByName(schema);
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public ModuleInfoResponse GetModuleInfoByModuleName(string moduleName) {
			ModuleInfoResponse moduleInfoResponse = new ModuleInfoResponse();
			ISchemaManagerItem item = UserConnection.ClientUnitSchemaManager.GetItemByName(moduleName);
			moduleInfoResponse.ModuleCaption = item.Caption;
			moduleInfoResponse.ModuleName = item.Name;
			moduleInfoResponse.ModuleUId = item.UId;
			return moduleInfoResponse;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public DataValueTypeInfoResponse GetDataValueTypes() {
			DataValueTypeInfoResponse dataValueTypeInfoResponse = new DataValueTypeInfoResponse();
			dataValueTypeInfoResponse.DataValueTypeInfoList = new List<DataValueTypeInfo>();
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Strings", "Text", new string[] { "ShortText", "MediumText", "LongText", "MaxSizeText" }));
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Numbers", "Float", new string[] { "Float1", "Float2", "Float3", "Float4" }));
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Dictionaries", "Lookup", new string[] { }));
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Dates", "DateTime", new string[] { }));
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Dates", "Date", new string[] { }));
			dataValueTypeInfoResponse.DataValueTypeInfoList.Add(InitDataValueTypeGroupInfo("Dates", "Time", new string[] { }));
			return dataValueTypeInfoResponse;
		}

        [OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public Responce GetCanUseSectionDesigner() {
			Responce response = new Responce();
			try {
				string adminOperationName = "CanManageSolution";
				var securityEngine = UserConnection.DBSecurityEngine;
				response.Success = securityEngine.GetCanExecuteOperation(adminOperationName, UserConnection.CurrentUser.Id);
			} catch (Exception e) {
				response.Success = false;
				response.ErrorMessage = e.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public AvailablePackagesInfo GetAvailablePackages() {
			AvailablePackagesInfo response = new AvailablePackagesInfo();
			try {
				var packageUId = DesignServiceUtilities.GetPackageUId(UserConnection);
				response.AvailablePackages = DesignServiceUtilities.GetUserPackagesInfo(UserConnection);
				if (response.AvailablePackages.ContainsKey(packageUId)) {
					response.CurrentPackageUId = packageUId;
				}
				response.Success = response.CurrentPackageUId != Guid.Empty || response.AvailablePackages.Count > 0;
			} catch (Exception e) {
				response.Success = false;
				response.ErrorMessage = e.Message;
			}
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public int GetMaxEntitySchemaNameLength() {
			int systemNameAdditionalLength = EntitySchema.SystemNameAdditionalLength;
			int maxNameLength = UserConnection.MaxEntitySchemaNameLength - systemNameAdditionalLength * 2;
			return maxNameLength;
		}

#if !NETSTANDARD2_0
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public Responce LockPackageElements(IEnumerable<string> schemaNames, Guid packageUId) {
			Responce response = new Responce();
			response.Success = true;
			try {
				string message;
				var packageElementsInfo = new Collection<PackageElementInfo>();
				Dictionary<Guid, string> packagesInfo = GetPackagesInfo();
				string packageName;
				packagesInfo.TryGetValue(packageUId, out packageName);
				EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
				ClientUnitSchemaManager clientUnitSchemaManager = UserConnection.ClientUnitSchemaManager;
				foreach(var schemaName in schemaNames) {
					if (schemaName.IsNotNullOrEmpty()) {
						var packageElementInfo = new PackageElementInfo {
							ElementName = schemaName,
							PackageName = packageName,
							Type = PackageStorageObjectType.Schema
						};
						packageElementsInfo.Add(packageElementInfo);
					}
				}
				var packageElementUtilities = new PackageElementUtilities(UserConnection);
				Dictionary<string, string> messages;
				response.Success = packageElementUtilities.TryLockPackageElements(packageElementsInfo, out messages, out message);
				response.ErrorMessage = message;
				response.ErrorMessages = messages;
			} catch (Exception e) {
				response.Success = false;
				response.ErrorMessage = e.Message;
			}
			return response;
		}
#endif

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public Responce ValidateClientUnitSchemes(IEnumerable<string> schemaNames) {
			Responce response = new Responce();
			response.ErrorMessages = new Dictionary<string, string>();
			foreach (var schemaName in schemaNames) {
				ClientUnitSchema clientUnitSchema = UserConnection.ClientUnitSchemaManager.FindInstanceByName(schemaName);
				if (clientUnitSchema == null) {
					continue;
				}
				var packagesInfo = GetPackagesInfo();
				string packageName = string.Empty;
				packagesInfo.TryGetValue(clientUnitSchema.PackageUId, out packageName);
				string packageSchemaName = packageName + "." + schemaName;
				LocalizableString validationMessage = string.Empty;
				if (!ValidateSchemaMarkerComments(clientUnitSchema, out validationMessage)) {
					response.ErrorMessages.Add(packageSchemaName, validationMessage);
				} else if (!ValidateSchemaDiff(clientUnitSchema, out validationMessage)) {
					response.ErrorMessages.Add(packageSchemaName, validationMessage);
				}
			}
			response.Success = response.ErrorMessages.Count == 0;
			return response;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public string GetClientUnitSchemaBody(string schemaName) {
			string result = string.Empty;
			ClientUnitSchemaManager schemaManager = UserConnection.ClientUnitSchemaManager;
			ClientUnitSchema clientUnitSchema = schemaManager.FindInstanceByName(schemaName) as ClientUnitSchema;
			if (clientUnitSchema != null) {
				result = clientUnitSchema.Body;
			}
			return result;
		}

		public enum SchemaPackageStatus
		{
			NotExist = 0,
			NotExistInCurrentPackage = 1,
			ExistInCurrentPackage = 2
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public SchemaPackageStatus GetSchemaPackageStatus(string schemaName, Guid packageUId) {
			SchemaPackageStatus result = SchemaPackageStatus.NotExist;
			if (UserConnection.ClientUnitSchemaManager.FindItemByName(schemaName) != null) {
				result = SchemaPackageStatus.NotExistInCurrentPackage;
				var resultPair = DesignServiceUtilities.GetSchemaUIdInPackage(UserConnection, schemaName, packageUId);
				Guid realUId = resultPair.UId;
				if (!realUId.IsEmpty()) {
					result = SchemaPackageStatus.ExistInCurrentPackage;
				}
			}
			return result;
		}

		#endregion

	}
}

