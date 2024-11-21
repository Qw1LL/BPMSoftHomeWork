namespace BPMSoft.Configuration.SearchDuplicatesService
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.CodeDom.Compiler;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Packages;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ColumnService : BaseService
	{
		private const string DatesDataValueTypeName = "Dates";
		private const string FloatDataValueTypeName = "Float";
		private const string LookupDataValueTypeName = "Lookup";
		private const string StringsDataValueTypeGroupName = "Strings";
		private const string NumbersDataValueTypeGroupName = "Numbers";
		
		#region Methods: Public
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<ResponceColumnType> GetTypeList(string name) {
			List<ResponceColumnType> responce = new List<ResponceColumnType>();
			switch (name) {
				case DatesDataValueTypeName: 
					responce = GetTypeListByName(DatesDataValueTypeName);
					break;
				case NumbersDataValueTypeGroupName: 
					responce = GetTypeListByName(NumbersDataValueTypeGroupName);
					break;
				case StringsDataValueTypeGroupName: 
					responce = GetTypeListByName(StringsDataValueTypeGroupName);
					break;
			}
			return responce;
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ResponceReferenceSchema GetReferenceInfo(string name) {
			return GetReferenceInfoByName(name);  
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ResponceColumnInfo GetColumnInfo(Guid entitySchemaId, Guid columnId) {
			return GetColumnSchemaInfo(entitySchemaId, columnId);  
		}
		
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ResponceApplyChanges ApplyChanges(Guid entitySchemaId, List<ChangedColumn> changedColumns) {
			return ApplyColumnsChanges(entitySchemaId, changedColumns);
		}
		
		
		#endregion
		
		#region DataContract
		
		[DataContract]
		public class ResponceColumnType {
			[DataMember]
			public string value { get; set; }
			[DataMember]
			public string displayValue { get; set; }
		}
		
		[DataContract]
		public class ResponceReferenceSchema {
			[DataMember]
			public Guid UId { get; set; }
			[DataMember]
			public string Name { get; set; }
			[DataMember]
			public string Caption { get; set; }
			[DataMember]
			public string PrimaryColumnName { get; set; }
			[DataMember]
			public string PrimaryDisplayColumnName { get; set; }
		}
		
		[DataContract]
		public class ResponceColumnInfo {
			[DataMember]
			public int Code { get; set; }
			[DataMember]
			public string DataValueTypeName { get; set; }
		}
		
		[DataContract]
		public class ChangedColumn {
			[DataMember]
			public string Name { get; set; }
			[DataMember]
			public string Caption { get; set; }
			[DataMember]
			public string TypeGroupName { get; set; }
			[DataMember]
			public string TypeName { get; set; }
			[DataMember]
			public bool IsNewLookup { get; set; }
			[DataMember]
			public bool IsRequired { get; set; }
			[DataMember]
			public bool IsEnum { get; set; }
			[DataMember]
			public bool IsMultiline { get; set; }
			[DataMember]
			public string ReferenceSchemaName { get; set; }
			[DataMember]
			public string ReferenceSchemaCaption { get; set; }
		}
		
		[DataContract]
		public class ResponceApplyChanges {
			[DataMember]
			public bool success { get; set; }
			[DataMember]
			public string Code { get; set; }
			[DataMember]
			public string Message { get; set; }
		}
		
		
		
		#endregion
		
		#region Methods: Private
		
		private ResponceApplyChanges ApplyDbChanges(ResponceApplyChanges response, EntitySchema entitySchema, bool isBild = false) {
			try {
				DBMetaScript dbMetaScript = UserConnection.DBMetaScript;
				DBMetaActionCollection actions = GetDbMetaActions(entitySchema);
				dbMetaScript.CheckActions(actions);
				DBMetaScriptValidationMessageCollection validationMessages = dbMetaScript.ValidationMessages;
				if (validationMessages.HasErrors()) {
					response.Code = "Error.DbMetaActions.Get";
					response.success = false;
					return response;
				}
				dbMetaScript.ExecuteActions(actions);
				if (validationMessages.HasErrors()) {
					response.Code = "Error.DbMetaActions.Execute";
					response.success = false;
					return response;
				}
			} catch (Exception e) {
				response.success = false;
				response.Code = "Error.DbMetaActions.Apply";
				response.Message = e.Message;
				return response;
			}
			if (response.success && isBild) {
				try {
#if !NETSTANDARD2_0
					var workspaceBuilder = WorkspaceBuilderUtility.CreateWorkspaceBuilder(AppConnection);
					CompilerErrorCollection compilerErrors = workspaceBuilder.Build(AppConnection.Workspace);
					if (compilerErrors.HasErrors) {
						response.success = false;
						response.Code = "Error.DbMetaActions.BuildError";
						return response;
					} else {
						if (GlobalAppSettings.FeatureDetachWorkspaceAssemblyChangedFromCompilation) {
							AppConnection.Workspace.WorkspaceChanged();
						}
					}
#endif
				} catch (Exception) {
					response.success = false;
					response.Code = "Error.DbMetaActions.Build";
					return response;
				}
			}
			return response; 
		}
		
		private ResponceApplyChanges ApplyColumnsChanges(Guid entitySchemaId, List<ChangedColumn> changedColumns) {
			ResponceApplyChanges responce = new ResponceApplyChanges();
			responce.success = true;
			
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			
			string baseCaption = string.Empty;
			var baseEntitySchema = entitySchemaManager.FindItemByUId(entitySchemaId);
			if (baseEntitySchema != null) {
				baseCaption = baseEntitySchema.Caption;
			}
			ISchemaManagerItem designSchemaItem = entitySchemaManager.DesignItemInCustomPackage(UserConnection, entitySchemaId);
			if (baseCaption != string.Empty) {
				designSchemaItem.Caption = baseCaption;
			}
			var entitySchema = designSchemaItem.Instance as EntitySchema;
			if (baseCaption != string.Empty) {
				entitySchema.Caption = baseCaption;
			}
			
			Dictionary<string, string> newLookupsCollection = new Dictionary<string, string>();
			Dictionary<string, EntitySchema> newLookupsEntitiesCollection = new Dictionary<string, EntitySchema>(); 
			
			var newLookups = changedColumns.Where(c => c.IsNewLookup && entitySchema.Columns.FindByName(c.Name) == null);
			if (newLookups != null) {
				foreach (ChangedColumn item in newLookups) {
					var dictionaryEntitySchema = entitySchemaManager.FindItemByName(item.ReferenceSchemaName);
					if (dictionaryEntitySchema != null) {
						responce.Code = "Error.Dictionary.Exists";
						responce.Message = item.ReferenceSchemaName;
						responce.success = false;
						return responce;
					}
					newLookupsCollection.Add(item.ReferenceSchemaName, item.ReferenceSchemaCaption);
				}
			}
			if (newLookupsCollection.Count > 0) {
				var sysFolderId = (new Select(UserConnection)
										.Column("Id")
									.From("SysSchemaFolder")
									.Where("ParentId").IsNull() as Select)
									.ExecuteScalar<Guid>();
				var baseLookupEntitySchema = entitySchemaManager.GetInstanceByName("BaseLookup");
				var sysLookup = entitySchemaManager.GetInstanceByName("SysLookup");
				var customPackageId = WorkspaceUtilities.ForceGetCustomPackageUId(UserConnection);
				foreach (var item in newLookupsCollection) {
					var lookupEntitySchemaItemUId = Guid.NewGuid();
					object schemaNamePrefix;
					var lookupSchemaName = item.Key;
					if (SysSettings.TryGetValue(UserConnection, "SchemaNamePrefix", out schemaNamePrefix)
							&& !schemaNamePrefix.Equals(string.Empty)) {
						lookupSchemaName = string.Concat(schemaNamePrefix, lookupSchemaName);
					}
					ISchemaManagerItem<EntitySchema> lookupEntitySchemaItem = entitySchemaManager.CreateSchema(lookupSchemaName,
						baseLookupEntitySchema, UserConnection, lookupEntitySchemaItemUId, false);
					lookupEntitySchemaItem.Caption = item.Value;
					var lookupEntitySchema = (EntitySchema)lookupEntitySchemaItem.Instance;
					lookupEntitySchema.Caption = item.Value;
					entitySchemaManager.SaveDesignedItemInSessionData(lookupEntitySchemaItem);
					entitySchemaManager.SaveDesignedItemFolderIdInSessionData(UserConnection, lookupEntitySchemaItemUId, sysFolderId);
					entitySchemaManager.SaveDesignedItemPackageUIdInSessionData(UserConnection, lookupEntitySchemaItemUId, customPackageId); 
					entitySchemaManager.SaveSchema(lookupEntitySchemaItemUId, UserConnection);
					try {
						responce = ApplyDbChanges(responce, lookupEntitySchema);
					} catch (Exception) {
						responce.success = false;
						responce.Code = "Error.DbMetaActions.LookupApply";
						return responce;
					}
					newLookupsEntitiesCollection.Add(item.Key, lookupEntitySchema);
					Entity sysLookupEntity = sysLookup.CreateEntity(UserConnection);
					sysLookupEntity.SetColumnValue("Id", Guid.NewGuid());
					sysLookupEntity.SetColumnValue("Name", item.Value);
					sysLookupEntity.SetColumnValue("Description", string.Empty);
					sysLookupEntity.SetColumnValue("SysFolderId", new Guid("80AB12C2-F36B-1410-A883-16D83CAB0980")); //// SysLookupFolder - General
					sysLookupEntity.SetColumnValue("SysEntitySchemaUId", lookupEntitySchema.UId);
					sysLookupEntity.SetColumnValue("ProcessListeners", 0);
					sysLookupEntity.Save();
				}
			}

			foreach (ChangedColumn item in changedColumns) {
				EntitySchemaColumn column = entitySchema.Columns.FindByName(item.Name);
				if (column == null) {
					DataValueType dataValueType = GetDataValueTypeByTypeName(item.TypeGroupName, item.TypeName);
					column = entitySchema.Columns.CreateItem();
					column.UId = Guid.NewGuid();
					column.UsageType = EntitySchemaColumnUsageType.General;
					column.Name = item.Name;
					column.DataValueType = dataValueType;
					column.DataValueTypeManager = dataValueType.DataValueTypeManager;
					column.DataValueTypeUId = dataValueType.UId;
					if (dataValueType.IsLookup || dataValueType.IsMultiLookup) {
						EntitySchema referenceEntitySchema;
						if (item.IsNewLookup) {
							referenceEntitySchema = newLookupsEntitiesCollection.First(l => l.Key == item.ReferenceSchemaName).Value; 
						} else {
							referenceEntitySchema = entitySchemaManager.GetInstanceByName(item.ReferenceSchemaName);
						}
						column.ReferenceSchema = referenceEntitySchema;
						column.ReferenceSchemaUId = referenceEntitySchema.UId;
					}
					entitySchema.Columns.Add(column);
				}
				column.Caption = item.Caption;
				column.IsSimpleLookup = item.IsEnum;
				column.RequirementType = item.IsRequired ?
					EntitySchemaColumnRequirementType.ApplicationLevel : EntitySchemaColumnRequirementType.None;
				column.IsMultiLineText = item.IsMultiline;
			}
			
			entitySchemaManager.SaveDesignedItemInSessionData(UserConnection, entitySchema as MetaSchema, entitySchema.UId);
			
			try {
				entitySchemaManager.SaveSchema(entitySchema.UId, UserConnection, false);
				responce = ApplyDbChanges(responce, entitySchema, true);
				responce.success = true;
			} catch (Exception) {
				responce.success = false;
				responce.Code = "Error.DbMetaActions.EntitySchemaApply";
			}
			return responce;
		}
		
		private DBMetaActionCollection GetDbMetaActions(EntitySchema entitySchema) {
			DBMetaActionManager dbMetaActionManager = (DBMetaActionManager)
				UserConnection.UserManagerProvider.GetManager("DBMetaActionManager");
			Guid entitySchemaUId = entitySchema.UId;
			var actions = dbMetaActionManager.GetEntitySchemaActions(entitySchemaUId) ??
				new DBMetaActionCollection(UserConnection);
			actions.Clear();
			DBMetaScript dbMetaScript = UserConnection.DBMetaScript;
			dbMetaScript.ValidationMessages.Clear();
			dbMetaScript.CheckObject(entitySchema);
			DBMetaScriptValidationMessageCollection validationMessages = dbMetaScript.ValidationMessages;
			dbMetaScript.AddEntitySchemaSavingActions(actions, entitySchema);
			if (actions.Count == 0) {
				return actions;
			}
			actions.Sort();
			dbMetaActionManager.Clear();
			foreach (DBMetaAction action in actions) {
				dbMetaActionManager.Add(action, entitySchemaUId);
			}
			return actions;
		}
		
		private DataValueType GetDataValueTypeByTypeName(string groupName, string name) {
			var dataValueTypeManager = UserConnection.DataValueTypeManager;
			var dataValueTypes =
				dataValueTypeManager.GetDataValueTypesByGroupName(groupName);
			DataValueType response = dataValueTypes.First();
			if (name != string.Empty) {
				foreach (var dataValueType in dataValueTypes) {
					if (dataValueType.Name == name) {
						response = dataValueType;
					}
				}
			}
			return response;
		}
		
		private List<ResponceColumnType> GetTypeListByName(string dataValueTypeGroupName) {
			List<ResponceColumnType> responce = new List<ResponceColumnType>();
			var dataValueTypeManager = UserConnection.DataValueTypeManager;
			var dataValueTypes =
				dataValueTypeManager.GetDataValueTypesByGroupName(dataValueTypeGroupName);
			foreach (var dataValueType in dataValueTypes) {
				if (CanAddDataValueType(dataValueTypeGroupName, dataValueType)) {
					responce.Add(new ResponceColumnType() {value = dataValueType.Name, displayValue = dataValueType.Caption});
				}
			}
			return responce;
		}
		
		private bool CanAddDataValueType(string dataValueTypeGroupName, DataValueType dataValueType) {
			if (dataValueTypeGroupName == StringsDataValueTypeGroupName) {
				if (dataValueType.UsageType != DesignModeUsageType.General) {
					return false;
				}
			}
			if (dataValueTypeGroupName == NumbersDataValueTypeGroupName) {
				if (dataValueType.Name == FloatDataValueTypeName ||
						!dataValueType.Name.StartsWith(FloatDataValueTypeName)) {
					return false;
				}
			}
			return true;
		}
		
		private ResponceReferenceSchema GetReferenceInfoByName(string name) {
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(name);
			var reference = new ResponceReferenceSchema();
			reference.UId = entitySchema.UId;
			reference.Name = entitySchema.Name;
			reference.Caption = entitySchema.Caption;
			reference.PrimaryColumnName = entitySchema.PrimaryColumn.Name;
			if (entitySchema.PrimaryDisplayColumn != null) {
				reference.PrimaryDisplayColumnName = entitySchema.PrimaryDisplayColumn.Name;
			}
			return reference;
		}
		
		private ResponceColumnInfo GetColumnSchemaInfo(Guid entitySchemaId, Guid columnId) {
			ResponceColumnInfo responce = new ResponceColumnInfo();
			responce.Code = 0;
			if (entitySchemaId == Guid.Empty || columnId == Guid.Empty) {
				responce.Code = -1;
				return responce;
			}
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaId);
			var column = entitySchema.Columns.GetByUId(columnId);
			responce.DataValueTypeName = column.DataValueType.Name;
			return responce;
		}
		
		#endregion
	}
}
