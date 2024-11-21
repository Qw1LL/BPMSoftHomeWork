using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using BPMSoft.Common;
using BPMSoft.Common.Json;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.Core.Process;
using BPMSoft.Core.Process.Configuration;
using BPMSoft.Core.Store;
using System.Globalization;
using TSConfiguration = BPMSoft.Configuration;

namespace BPMSoft.Configuration
{
	public static class CommandLineUtility
	{
		#region Constants: Public
		
		public static readonly Guid SoftKeyContactId = new Guid("22C5540C-D9B1-49EF-8EB7-72419B78E57C");
		
		#endregion
		
		#region Properties: Private

		private static UserConnection UserConnection { get; set; }

		private static List<Command> CommandList {
				get {
					return LoadCommands();
				}
			}

		private static List<ParamCommand> ParamCommandList {
				get {
					return LoadCommandParams();
				}
			}

		private static Dictionary<Guid, Guid> _typedColumnCollection;
		private static Dictionary<Guid, Guid> TypedColumnCollection
		{
			get {
				if (_typedColumnCollection == null) {
					_typedColumnCollection = new Dictionary<Guid, Guid>();
					var typedColumnESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEntity");
					typedColumnESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
					typedColumnESQ.AddColumn("TypeColumnUId");
					typedColumnESQ.AddColumn("SysEntitySchemaUId");
					typedColumnESQ.Filters.Add(
						typedColumnESQ.CreateFilterWithParameters(FilterComparisonType.IsNotNull, "TypeColumnUId")
					);
					typedColumnESQ.Filters.Add(
						typedColumnESQ.CreateFilterWithParameters(FilterComparisonType.NotEqual, "TypeColumnUId", Guid.Empty)
					);
					typedColumnESQ.Filters.Add(
						typedColumnESQ.CreateFilterWithParameters(FilterComparisonType.NotEqual, "SysEntitySchemaUId", Guid.Empty)
					);
					typedColumnESQ.Cache = UserConnection.SessionCache.WithLocalCaching("TypeColumnCache");
					typedColumnESQ.CacheItemName = "TypeColumnCacheItem";
					var typedColumnEntityCollection = typedColumnESQ.GetEntityCollection(UserConnection);
					foreach(var entity in typedColumnEntityCollection) {
						_typedColumnCollection[entity.GetTypedColumnValue<Guid>("SysEntitySchemaUId")] = entity.GetTypedColumnValue<Guid>("TypeColumnUId");
					}
				}
				return _typedColumnCollection;
			}
		}
			
		#endregion
		
		#region Methods: Private
		
		private static List<Command> LoadCommands() {
			var commandESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Command");
			commandESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			commandESQ.AddColumn("Id");
			commandESQ.AddColumn("Name");
			commandESQ.AddColumn("Code");
			commandESQ.Cache = UserConnection.SessionCache.WithLocalCaching("CommandsCache");
			commandESQ.CacheItemName = "CommandsCacheItem";
			var commandEntityCollection = commandESQ.GetEntityCollection(UserConnection);
			var commandResultList = new List<Command>();
			foreach(var entity in commandEntityCollection) {
				var id = entity.GetTypedColumnValue<Guid>("Id");
				var commandName = entity.GetTypedColumnValue<string>("Name");
				var commandCode = entity.GetTypedColumnValue<string>("Code");
				commandResultList.Add(new Command() {
					Id = id,
					Name = commandName,
					Code = commandCode
				});
			}
			return commandResultList;
		}

		private static List<ParamCommand> LoadCommandParams() {
			var commandESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "CommandParams");
			commandESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			commandESQ.AddColumn("Command.Id");
			commandESQ.AddColumn("Command.Name");
			commandESQ.AddColumn("Command.Code");
			commandESQ.AddColumn("MainParam.Id");
			commandESQ.AddColumn("MainParam.Name");
			commandESQ.AddColumn("MainParam.SubjectSchemaUId");
			commandESQ.AddColumn("AdditionalParam.Id");
			commandESQ.AddColumn("AdditionalParam.ColumnCaption");
			commandESQ.AddColumn("AdditionalParam.SubjectSchemaUId");
			commandESQ.Cache = UserConnection.SessionCache.WithLocalCaching("CommandParamsCache");
			commandESQ.CacheItemName = "CommandParamsCacheItem";
			var commandEntityCollection = commandESQ.GetEntityCollection(UserConnection);
			var paramCommandResultList = new List<ParamCommand>();
			foreach(var entity in commandEntityCollection) {
				var id = entity.GetTypedColumnValue<Guid>("Id");
				var commandId = entity.GetTypedColumnValue<Guid>("Command_Id");
				var commandName = entity.GetTypedColumnValue<string>("Command_Name");
				var commandCode = entity.GetTypedColumnValue<string>("Command_Code");
				var mainParamId = entity.GetTypedColumnValue<Guid>("MainParam_Id");
				var mainParamName = entity.GetTypedColumnValue<string>("MainParam_Name");
				var subjectSchemaUId = entity.GetTypedColumnValue<Guid>("MainParam_SubjectSchemaUId");
				var subjectSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(subjectSchemaUId);
				var subjectSchemaName = subjectSchema.Name;
				var subjectSchemaPCName = subjectSchema.PrimaryColumn.Name;
				var subjectSchemaPDCName = subjectSchema.PrimaryDisplayColumn?.Name == null ? "" : subjectSchema.PrimaryDisplayColumn.Name;
				var additionalParamId = entity.GetTypedColumnValue<Guid>("AdditionalParam_Id");
				var additionalParamName = entity.GetTypedColumnValue<string>("AdditionalParam_ColumnCaption");
				var additionalParamSchemaUId = entity.GetTypedColumnValue<Guid>("AdditionalParam_SubjectSchemaUId");
				string addSchemaName = string.Empty, addSchemaPCName = string.Empty, addSchemaPDCName = string.Empty;
				if (additionalParamSchemaUId != Guid.Empty) {
					var addSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(additionalParamSchemaUId);
					addSchemaName = addSchema.Name;
					addSchemaPCName = addSchema.PrimaryColumn.Name;
					addSchemaPDCName = addSchema.PrimaryDisplayColumn?.Name == null ? "" : addSchema.PrimaryDisplayColumn.Name;
				}
				var typeColumn = TypedColumnCollection.ContainsKey(subjectSchemaUId) ? TypedColumnCollection[subjectSchemaUId] : Guid.Empty;
				paramCommandResultList.Add(new ParamCommand() {
					Id = id,
					CommandId = commandId,
					CommandName = commandName,
					CommandCode = commandCode,
					MainParamId = mainParamId,
					MainParamName = mainParamName,
					MainParamSubjectSchemaUId = subjectSchemaUId,
					MainParamSubjectSchemaName = subjectSchemaName,
					MainParamSubjectSchemaPCName = subjectSchemaPCName,
					MainParamSubjectSchemaPDCName = subjectSchemaPDCName,
					AdditionalParamId = additionalParamId,
					AdditionalParamName = additionalParamName,
					AdditionalParamSchemaName = addSchemaName,
					AdditionalParamSchemaPCName = addSchemaPCName,
					AdditionalParamSchemaPDCName = addSchemaPDCName,
					ColumnTypeId = typeColumn
				});
			}
			return paramCommandResultList;
		}

		private static Dictionary<Guid, ModuleData> GetSysModuleEntities () {
			var list = new Dictionary<Guid, ModuleData>();
			var sysModuleESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModule");
			sysModuleESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			var schemaUIdColumnName = sysModuleESQ.AddColumn("SysModuleEntity.SysEntitySchemaUId").Name;
			sysModuleESQ.AddColumn("CardSchemaUId");
			sysModuleESQ.AddColumn("SectionSchemaUId");
			sysModuleESQ.AddColumn("Caption");
			var folderModeCodeColumnName = sysModuleESQ.AddColumn("FolderMode.Code").Name;
			var orFilterCollection = new EntitySchemaQueryFilterCollection(sysModuleESQ, LogicalOperationStrict.Or);
			orFilterCollection.Add(sysModuleESQ.CreateIsNotNullFilter("CardSchemaUId"));
			orFilterCollection.Add(sysModuleESQ.CreateIsNotNullFilter("SectionSchemaUId"));
			sysModuleESQ.Filters.Add(orFilterCollection);
			var entityCollection = sysModuleESQ.GetEntityCollection(UserConnection);
			foreach (var entity in entityCollection) {
				var module = new ModuleData();
				var schemaUId = entity.GetTypedColumnValue<Guid>(schemaUIdColumnName);
				var cardSchemaUId = entity.GetTypedColumnValue<Guid>("CardSchemaUId");
				var sectionSchemaUId = entity.GetTypedColumnValue<Guid>("SectionSchemaUId");
				var folderModeCode = entity.GetTypedColumnValue<string>(folderModeCodeColumnName);
				module.ModuleCaption = entity.GetTypedColumnValue<string>("Caption");
				if (cardSchemaUId != null && cardSchemaUId != Guid.Empty) {
					module.CommandsList.Add("create");
				}
				if (sectionSchemaUId != null && sectionSchemaUId != Guid.Empty) {
					module.CommandsList.Add("goto");
					module.CommandsList.Add("search");
				}
				if (folderModeCode != "None") {
					module.HasFolder = true;
				}
				if (!list.ContainsKey(schemaUId)) {
					list.Add(schemaUId, module);
				}
			}
			return list;
		}
		
		private static void CreateParamCommand(string command, Guid schemaUId, ModuleData module) {
			var paramCommand = ParamCommandList.Find(
				delegate(ParamCommand pc) {
					return (pc.CommandCode == command && pc.MainParamSubjectSchemaUId == schemaUId);
			}, null);
			if(paramCommand == null) {
				Guid commandId = CommandList.Find(
					delegate(Command pc) {
						return (pc.Code == command);
					}, null).Id;
				var mainParamId = AddOrGetMainParam(command, schemaUId, module);
				if(mainParamId == Guid.Empty) {
					return;
				}
				var addParamId = AddOrGetAddParam(command, schemaUId, module);
				var paramCommandSchema = UserConnection.EntitySchemaManager.GetInstanceByName("CommandParams");
				var paramCommandEntity = paramCommandSchema.CreateEntity(UserConnection);
				paramCommandEntity.SetDefColumnValues();
				paramCommandEntity.SetColumnValue("CommandId", commandId);
				paramCommandEntity.SetColumnValue("MainParamId", mainParamId);
				if(addParamId != Guid.Empty) {
					paramCommandEntity.SetColumnValue("AdditionalParamId", addParamId);
				}
				paramCommandEntity.SetColumnValue("CreatedById", SoftKeyContactId);
				paramCommandEntity.Save();
				
			}
		}
		
		private static Guid AddOrGetMainParam(string command, Guid schemaUId, ModuleData module) {
			var mainParam = Guid.Empty;
			var subjectSchema = UserConnection.EntitySchemaManager.FindInstanceByUId(schemaUId);
			if (subjectSchema == null) {
				return mainParam;
			}
			var mainParamSchema = UserConnection.EntitySchemaManager.GetInstanceByName("MainParam");
			var mainParamEntity = mainParamSchema.CreateEntity(UserConnection);
			var conditions = new Dictionary<string, object>();
			switch (command) {
					case "create": {
							var sysModuleEditESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEdit");
							sysModuleEditESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
							sysModuleEditESQ.AddColumn("CardSchemaUId");
							sysModuleEditESQ.Filters.Add(sysModuleEditESQ.CreateIsNotNullFilter("CardSchemaUId"));
							sysModuleEditESQ.Filters.Add(sysModuleEditESQ.CreateFilterWithParameters(FilterComparisonType.Equal,
								"SysModuleEntity.SysEntitySchemaUId", schemaUId));
							var editCollection = sysModuleEditESQ.GetEntityCollection(UserConnection);
							if (editCollection.Count < 1) {
								break;
							}
							conditions.Add("SubjectSchemaUId", schemaUId);
							conditions.Add("Name", subjectSchema.Caption.ToString());
							if(mainParamEntity.FetchFromDB(conditions)) {
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
							else {
								mainParamEntity.SetDefColumnValues();
								mainParamEntity.SetColumnValue("SubjectSchemaUId", schemaUId);
								mainParamEntity.SetColumnValue("Name", subjectSchema.Caption.ToString());
								mainParamEntity.SetColumnValue("CreatedById", SoftKeyContactId);
								mainParamEntity.Save();
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
						}
						break;
					case "goto": {
							conditions.Add("SubjectSchemaUId", schemaUId);
							conditions.Add("Name", module.ModuleCaption);
							if(mainParamEntity.FetchFromDB(conditions)) {
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
							else {
								mainParamEntity.SetDefColumnValues();
								mainParamEntity.SetColumnValue("SubjectSchemaUId", schemaUId);
								mainParamEntity.SetColumnValue("Name", module.ModuleCaption);
								mainParamEntity.SetColumnValue("CreatedById", SoftKeyContactId);
								mainParamEntity.Save();
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
						}
						break;
					case "search": {
							conditions.Add("SubjectSchemaUId", schemaUId);
							conditions.Add("Name", subjectSchema.Caption.ToString());
							if(mainParamEntity.FetchFromDB(conditions)) {
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
							else {
								mainParamEntity.SetDefColumnValues();
								mainParamEntity.SetColumnValue("SubjectSchemaUId", schemaUId);
								mainParamEntity.SetColumnValue("Name", subjectSchema.Caption.ToString());
								mainParamEntity.SetColumnValue("CreatedById", SoftKeyContactId);
								mainParamEntity.Save();
								mainParam = mainParamEntity.PrimaryColumnValue;
							}
						}
						break;
					default:
						break;
				}
			return mainParam;
		}
		
		private static Guid AddOrGetAddParam(string command, Guid schemaUId, ModuleData module) {
			var addParam = Guid.Empty;
			var subjectSchema = UserConnection.EntitySchemaManager.FindInstanceByUId(schemaUId);
			var addParamSchema = UserConnection.EntitySchemaManager.GetInstanceByName("AdditionalParam");
			var addParamEntity = addParamSchema.CreateEntity(UserConnection);
			var conditions = new Dictionary<string, object>();
			switch (command) {
					case "create":
					case "search":
						if (subjectSchema.PrimaryDisplayColumn == null) {
							break;
						}
						var columnCaptionValue = subjectSchema
							.FindSchemaColumnByPath(subjectSchema.PrimaryDisplayColumn.Name).Caption.ToString();
						conditions.Add("SubjectSchemaUId", schemaUId);
						conditions.Add("ColumnCaption", columnCaptionValue);
						conditions.Add("SubjectColumnUId", subjectSchema.PrimaryDisplayColumn.UId);
						if (addParamEntity.FetchFromDB(conditions)) {
							addParam = addParamEntity.PrimaryColumnValue;
						} else {
							addParamEntity.SetDefColumnValues();
							addParamEntity.SetColumnValue("SubjectSchemaUId", schemaUId);
							addParamEntity.SetColumnValue("ColumnCaption", columnCaptionValue);
							addParamEntity.SetColumnValue("SubjectColumnUId", subjectSchema.PrimaryDisplayColumn.UId);
							addParamEntity.SetColumnValue("CreatedById", SoftKeyContactId);
							addParamEntity.Save();
							addParam = addParamEntity.PrimaryColumnValue;
						}
						break;
					case "goto":
						if (!module.HasFolder) {
							break;
						}
						var mainParamSchema = UserConnection.EntitySchemaManager.FindInstanceByUId(schemaUId);
						if (mainParamSchema == null) {
							break;
						}
						var folderSchema =
							UserConnection.EntitySchemaManager.FindInstanceByName(mainParamSchema.Name + "Folder");
						if (folderSchema == null) {
							break;
						}
						conditions.Add("SubjectSchemaUId", folderSchema.UId);
						conditions.Add("ColumnCaption", folderSchema.Caption.ToString());
						if (addParamEntity.FetchFromDB(conditions)) {
							addParam = addParamEntity.PrimaryColumnValue;
						} else {
							addParamEntity.SetDefColumnValues();
							addParamEntity.SetColumnValue("SubjectSchemaUId", folderSchema.UId);
							addParamEntity.SetColumnValue("ColumnCaption", folderSchema.Caption.ToString());
							addParamEntity.SetColumnValue("CreatedById", SoftKeyContactId);
							addParamEntity.Save();
							addParam = addParamEntity.PrimaryColumnValue;
						}
						break;
					default:
						break;
				}
			return addParam;
		}
		
		#endregion

		#region Methods: Public
		
		public static void CheckRegisteredSections(UserConnection userConnection) {
			UserConnection = userConnection;
			var modulesEntity = GetSysModuleEntities();
			foreach(var entityDictionary in modulesEntity) {
				var entityUId = entityDictionary.Key;
				foreach(var command in entityDictionary.Value.CommandsList) {
					CreateParamCommand(command, entityUId, entityDictionary.Value);
				}
			}
			string[] cacheArray = new string[] {"VwCommandActionCache", "CommandParamsCache", "CommandsCache"};
			foreach (var cacheName in cacheArray) {
				var appCache = UserConnection.SessionCache.WithLocalCaching(cacheName);
				appCache.ExpireGroup(cacheName);
			}
		}
		
		public static List<ParamCommand> GetParamCommandList(UserConnection userConnection) {
			UserConnection = userConnection;
			return ParamCommandList;
		}
		
		#endregion

		#region Class: Command

		public class Command
		{

			#region Properties: Public

			public Guid Id {
				get;
				set;
			}
			public string Name {
				get;
				set;
			}
			public string Code {
				get;
				set;
			}

			#endregion

		}

		#endregion

		#region Class: ParamCommand
		
		public class ParamCommand
		{

			#region Properties: Public
			
			public Guid Id {
				get;
				set;
			}
			public Guid CommandId {
				get;
				set;
			}
			public string CommandName {
				get;
				set;
			}
			public string CommandCode {
				get;
				set;
			}
			public Guid MainParamId {
				get;
				set;
			}
			public string MainParamName {
				get;
				set;
			}
			public Guid MainParamSubjectSchemaUId {
				get;
				set;
			}
			public string MainParamSubjectSchemaName {
				get;
				set;
			}
			public string MainParamSubjectSchemaPCName {
				get;
				set;
			}
			public string MainParamSubjectSchemaPDCName {
				get;
				set;
			}
			public Guid AdditionalParamId {
				get;
				set;
			}
			public string AdditionalParamName {
				get;
				set;
			}
			public string AdditionalParamSchemaName {
				get;
				set;
			}
			public string AdditionalParamSchemaPCName {
				get;
				set;
			}
			public string AdditionalParamSchemaPDCName {
				get;
				set;
			}
			public Guid ColumnTypeId {
				get;
				set;
			}
			
			#endregion
			
			#region Methods:Public
			
			
			#endregion
		}
		
		#endregion

		#region Class: ModuleData
		
		public class ModuleData {
			
			#region Constructors: Public
			
			public ModuleData() {
				CommandsList = new List<string>();
			}
			
			#endregion
			
			#region Properties: Public
			
			public string ModuleCaption {
				get;
				set;
			}
			public bool HasFolder {
				get;
				set;
			}
			public List<string> CommandsList {
				get;
				set;
			}
			
			#endregion
		}
		
		#endregion
	}
}
