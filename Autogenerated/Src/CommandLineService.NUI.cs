namespace BPMSoft.Configuration.CommandLineService
{
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Store;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CommandLineService : BaseService, System.Web.SessionState.IReadOnlySessionState {

		#region Properties: Private

		private EntitySchemaQuery _hintQuery;
		private EntitySchema _hintEntityEntitySchema;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Reads <see cref="EntityCollection"/> using specified <see cref="EntitySchemaQuery"/>.
		/// </summary>
		public Func<EntitySchemaQuery, EntitySchemaQueryOptions, EntityCollection> EntityReader { get; set; }

		#endregion

		#region Methods: Private

		private EntitySchemaQuery GetESQWithCommonProperties(string entitySchemaName) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, entitySchemaName);
			esq.IsDistinct = true;
			esq.Cache = UserConnection.SessionCache.WithLocalCaching("VwCommandActionCache");
			return esq;
		}

		private EntitySchemaQuery GetMacrosESQ(Dictionary<string, string> columnNames) {
			EntitySchemaQuery esq = GetESQWithCommonProperties("Macros");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			EntitySchemaQueryColumn primaryColumn = esq.PrimaryQueryColumn;
			columnNames.Add("Id", primaryColumn.Name);
			EntitySchemaQueryColumn captionColumn = esq.AddColumn("Name");
			columnNames.Add("Caption", captionColumn.Name);
			columnNames.Add("AddCaption", "");
			EntitySchemaQueryColumn createdByColumn = esq.AddColumn("CreatedBy");
			EntitySchemaQueryColumn commandCodeColumn = esq.AddColumn("=Command.Code");
			columnNames.Add("Code", commandCodeColumn.Name);
			EntitySchemaQueryColumn columnCaptionColumn = esq.AddColumn(">AdditionalParam.ColumnCaption");
			columnNames.Add("ColumnCaption", columnCaptionColumn.Name);
			EntitySchemaQueryColumn subjectColumn = esq.AddColumn(">AdditionalParam.SubjectColumnUId");
			columnNames.Add("SubjectColumnUId", subjectColumn.Name);
			EntitySchemaQueryColumn subjectSchemaColumn = esq.AddColumn("=MainParam.SubjectSchemaUId");
			columnNames.Add("SubjectSchemaUId", subjectSchemaColumn.Name);
			EntitySchemaQueryColumn mainParamNameColumn = esq.AddColumn("=MainParam.Name");
			columnNames.Add("MainParamCaption", mainParamNameColumn.Name);
			EntitySchemaQueryColumn typeColumn = esq.AddColumn("=MainParam.=[SysModuleEntity:SysEntitySchemaUId:SubjectSchemaUId].TypeColumnUId");
			columnNames.Add("TypeColumnUId", typeColumn.Name);
			columnNames.Add("OrderColumn", "");
			EntitySchemaQueryColumn mainParamTypeColumn = esq.AddColumn("MainParamType");
			columnNames.Add("TypeColumnCode", mainParamTypeColumn.Name);
			EntitySchemaQueryColumn isSharedColumn = esq.AddColumn("IsShared");
			esq.Filters.Add(esq.CreateIsNotNullFilter("MainParam"));
			ApplyCreatedByOrIsSharedFilter(esq);
			esq.CacheItemName = "CommandActionCacheItem_Macros";
			return esq;
		}

		private EntitySchemaQuery GetCommandESQ(Dictionary<string, string> columnNames) {
			EntitySchemaQuery esq = GetESQWithCommonProperties("CommandParams");
			EntitySchemaQueryColumn primaryColumn = esq.AddColumn("=Command.Id");
			columnNames.Add("Id", primaryColumn.Name);
			EntitySchemaQueryColumn createdByColumn = esq.AddColumn("=Command.CreatedBy");
			EntitySchemaQueryColumn captionColumn = esq.AddColumn("=Command.Name");
			columnNames.Add("Caption", captionColumn.Name);
			EntitySchemaQueryColumn mainParamNameColumn = esq.AddColumn("=MainParam.Name");
			columnNames.Add("AddCaption", mainParamNameColumn.Name);
			columnNames.Add("MainParamCaption", mainParamNameColumn.Name);
			EntitySchemaQueryColumn commandCodeColumn = esq.AddColumn("=Command.Code");
			columnNames.Add("Code", commandCodeColumn.Name);
			EntitySchemaQueryColumn columnCaptionColumn = esq.AddColumn("AdditionalParam.ColumnCaption");
			columnNames.Add("ColumnCaption", columnCaptionColumn.Name);
			EntitySchemaQueryColumn subjectColumn = esq.AddColumn("AdditionalParam.SubjectColumnUId");
			columnNames.Add("SubjectColumnUId", subjectColumn.Name);
			EntitySchemaQueryColumn subjectSchemaColumn = esq.AddColumn("=MainParam.SubjectSchemaUId");
			columnNames.Add("SubjectSchemaUId", subjectSchemaColumn.Name);
			EntitySchemaQueryColumn typeColumn = esq.AddColumn("=MainParam.[SysModuleEntity:SysEntitySchemaUId:SubjectSchemaUId].TypeColumnUId");
			columnNames.Add("TypeColumnUId", typeColumn.Name);
			columnNames.Add("TypeColumnCode", "");
			columnNames.Add("OrderColumn", "");
			esq.CacheItemName = "CommandActionCacheItem_Command";
			return esq;
		}

		private EntitySchemaQuery GetSynonymESQ(Dictionary<string, string> columnNames) {
			EntitySchemaQuery esq = GetESQWithCommonProperties("Macros");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			EntitySchemaQueryColumn primaryColumn = esq.PrimaryQueryColumn;
			columnNames.Add("Id", primaryColumn.Name);
			EntitySchemaQueryColumn captionColumn = esq.AddColumn("Name");
			columnNames.Add("Caption", captionColumn.Name);
			EntitySchemaQueryColumn mainParamNameColumn = esq.AddColumn("=[CommandParams:Command:Command].=MainParam.Name");
			columnNames.Add("AddCaption", mainParamNameColumn.Name);
			columnNames.Add("MainParamCaption", mainParamNameColumn.Name);
			EntitySchemaQueryColumn createdByColumn = esq.AddColumn("CreatedBy");
			EntitySchemaQueryColumn commandCodeColumn = esq.AddColumn("=Command.Code");
			columnNames.Add("Code", commandCodeColumn.Name);
			EntitySchemaQueryColumn columnCaptionColumn = esq.AddColumn("=[CommandParams:Command:Command].AdditionalParam.ColumnCaption");
			columnNames.Add("ColumnCaption", columnCaptionColumn.Name);
			EntitySchemaQueryColumn subjectColumn = esq.AddColumn("=[CommandParams:Command:Command].AdditionalParam.SubjectColumnUId");
			columnNames.Add("SubjectColumnUId", subjectColumn.Name);
			EntitySchemaQueryColumn subjectSchemaColumn = esq.AddColumn("=[CommandParams:Command:Command].=MainParam.SubjectSchemaUId");
			columnNames.Add("SubjectSchemaUId", subjectSchemaColumn.Name);
			EntitySchemaQueryColumn typeColumn = esq.AddColumn("=[CommandParams:Command:Command].=MainParam.=[SysModuleEntity:SysEntitySchemaUId:SubjectSchemaUId].TypeColumnUId");
			columnNames.Add("TypeColumnUId", typeColumn.Name);
			EntitySchemaQueryColumn mainParamTypeColumn = esq.AddColumn("MainParamType");
			columnNames.Add("TypeColumnCode", mainParamTypeColumn.Name);
			columnNames.Add("OrderColumn", "");
			EntitySchemaQueryColumn isSharedColumn = esq.AddColumn("IsShared");
			esq.Filters.Add(esq.CreateIsNullFilter("MainParam"));
			ApplyCreatedByOrIsSharedFilter(esq);
			esq.CacheItemName = "CommandActionCacheItem_Synonym";
			return esq;
		}

		private void ApplyCreatedByOrIsSharedFilter(EntitySchemaQuery esq) {
			var fullFilterCollection = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			fullFilterCollection.Add(esq.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"CreatedBy",
					UserConnection.CurrentUser.ContactId
				));
			fullFilterCollection.Add(
				esq.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"IsShared",
					true
				)
			);
			esq.Filters.Add(fullFilterCollection);
		}

		private void FillCommandResultList(EntityCollection commandEntityCollection,
				List<CommandResult> commandResultList, Dictionary<string, string> columnNames, int order) {
			foreach (var entity in commandEntityCollection) {
				var commandResult = new CommandResult();
				string idColumnName = columnNames["Id"];
				Guid id = entity.GetTypedColumnValue<Guid>(idColumnName);
				Guid realId = id;
				string captionColumnName = columnNames["Caption"];
				string caption = entity.GetTypedColumnValue<string>(captionColumnName);
				string addCaptionColumnName = columnNames["AddCaption"];
				if (!string.IsNullOrEmpty(addCaptionColumnName)) {
					string addCaption = entity.GetTypedColumnValue<string>(addCaptionColumnName);
					caption = string.Format("{0} {1}", caption, addCaption);
				}
				string codeColumnName = columnNames["Code"];
				string code = entity.GetTypedColumnValue<string>(codeColumnName);
				string columnCaptionColumnName = columnNames["ColumnCaption"];
				string columnCaption = entity.GetTypedColumnValue<string>(columnCaptionColumnName);
				string subjectSchemaUIdColumnName = columnNames["SubjectSchemaUId"];
				Guid subjectSchemaUId = entity.GetTypedColumnValue<Guid>(subjectSchemaUIdColumnName);
				string mainParamCaptionColumnName = columnNames["MainParamCaption"];
				string mainParamCation = entity.GetTypedColumnValue<string>(mainParamCaptionColumnName);
				string typeColumnCodeColumnName = columnNames["TypeColumnCode"];
				string typeCode = "";
				if (!string.IsNullOrEmpty(typeColumnCodeColumnName)) {
					typeCode = entity.GetTypedColumnValue<string>(typeColumnCodeColumnName);
				}
				EntitySchema subjectSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(subjectSchemaUId);
				string subjectColumnUIdColumnName = columnNames["SubjectColumnUId"];
				Guid subjectColumnUId = entity.GetTypedColumnValue<Guid>(subjectColumnUIdColumnName);
				EntitySchemaColumn subjectColumn = subjectSchema.Columns.FindByUId(subjectColumnUId);
				string subjectSchemaColumnName = subjectColumn == null ? null : subjectColumn.Name;
				string orderColumnName = columnNames["OrderColumn"];
				int orderColumnValue;
				if (!string.IsNullOrEmpty(orderColumnName)) {
					orderColumnValue = entity.GetTypedColumnValue<int>(orderColumnName);
				} else {
					orderColumnValue = order;
				}
				string commandCaption = caption.Replace(mainParamCation, "").Trim();
				string typeColumnUIdColumnName = columnNames["TypeColumnUId"];
				Guid typeColumn = entity.GetTypedColumnValue<Guid>(typeColumnUIdColumnName);
				if (typeColumn != Guid.Empty && orderColumnValue != 1 && (code == "create")) {
					EntitySchema typeSchema = subjectSchema.Columns.GetByUId(typeColumn).ReferenceSchema;
					var typeESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEdit");
					typeESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
					EntitySchemaQueryColumn primaryDisplayColumn = typeESQ.AddColumn("[" + typeSchema.Name + ":Id:TypeColumnValue]." + typeSchema.PrimaryDisplayColumn.Name);
					EntitySchemaQueryColumn codeESQColumn = null;
					EntitySchemaColumn codeColumn = typeSchema.Columns.FindByName("Code");
					codeESQColumn = codeColumn == null ? null : typeESQ.AddColumn("[" + typeSchema.Name + ":Id:TypeColumnValue]." + codeColumn.Name);
					typeESQ.Filters.Add(
						typeESQ.CreateFilterWithParameters(
							FilterComparisonType.Equal,
							"SysModuleEntity.SysEntitySchemaUId",
							subjectSchemaUId
						)
					);
					typeESQ.Filters.Add(
						typeESQ.CreateFilterWithParameters(
							FilterComparisonType.NotEqual,
							"TypeColumnValue",
							BPMSoft.Configuration.ActivityConsts.CallTypeUId
						)
					);
					typeESQ.Cache = UserConnection.SessionCache.WithLocalCaching("VwCommandActionCache");
					typeESQ.CacheItemName = string.Format("CommandLineEdit_{0}", subjectSchemaUId);
					EntityCollection typeEntityCollection = typeESQ.GetEntityCollection(UserConnection);
					foreach (Entity typeEntity in typeEntityCollection) {
						string typeName = typeEntity.GetTypedColumnValue<string>(primaryDisplayColumn.Name);
						typeCode = codeESQColumn == null ? null : typeEntity.GetTypedColumnValue<string>(codeESQColumn.Name);
						string newCaption = caption + "(" + typeName + ")";
						string newMainParamCation = mainParamCation + "(" + typeName + ")";
						commandResultList.Add(new CommandResult() {
							Id = Guid.NewGuid(),
							Caption = newCaption,
							CommandCaption = commandCaption,
							Code = code,
							ColumnCaption = columnCaption,
							MainParamCaption = newMainParamCation,
							SubjectName = subjectSchema.Name,
							ColumnTypeCode = typeCode,
							ColumnName = subjectSchemaColumnName,
							HintType = orderColumnValue,
							RealId = realId
						});
					}
				} else {
					if (code == "startbp" || code == "run") {
						caption = caption.Replace(mainParamCation, "").Trim();
					}
					if (commandResultList.Count(item => item.Id == id) > 0) {
						id = Guid.NewGuid();
					}
					commandResultList.Add(new CommandResult() {
						Id = id,
						Caption = caption,
						CommandCaption = commandCaption,
						Code = code,
						ColumnCaption = columnCaption,
						MainParamCaption = mainParamCation,
						SubjectName = subjectSchema.Name,
						ColumnTypeCode = typeCode,
						ColumnName = subjectSchemaColumnName,
						HintType = orderColumnValue,
						RealId = realId
					});
				}
			}
		}

		private void FillCommandResultListFromESQ(List<CommandResult> resultList,
				Func<Dictionary<string, string>, EntitySchemaQuery> getESQ, int order) {
			Dictionary<string, string> columnNames = new Dictionary<string, string>();
			EntitySchemaQuery esq = getESQ(columnNames);
			EntityCollection esqCollection = esq.GetEntityCollection(UserConnection);
			FillCommandResultList(esqCollection, resultList, columnNames, order);
		}

		private EntitySchemaColumn GetTypedColumnForHintQuery() {

			var typeColumnQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEntity");
			var queryColunm = typeColumnQuery.AddColumn("TypeColumnUId");
			typeColumnQuery.UseAdminRights = false;
			typeColumnQuery.RowCount = 1;

			typeColumnQuery.Filters.Add(
				typeColumnQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"SysEntitySchemaUId",
					_hintEntityEntitySchema.UId
				)
			);

			var typeColumnCollection = typeColumnQuery.GetEntityCollection(UserConnection);

			if (typeColumnCollection.IsEmpty()) {

				return null;

			}

			var typeColumnUId = typeColumnCollection[0].GetTypedColumnValue<Guid>(queryColunm.Name);

			return typeColumnUId.IsNotEmpty() ? _hintEntityEntitySchema.Columns.FindByUId(typeColumnUId): null;

		}

		private void AddIsTagPropertyToHintQuery() {
			var isTagPropertyColumn = _hintEntityEntitySchema.Columns.FindByName("TagProperty");
			if (isTagPropertyColumn != null) {
				_hintQuery.Filters.Add(
					_hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						isTagPropertyColumn.Name,
						BPMSoft.Configuration.BaseConsts.BusinessProcessTag
					)
				);
			}
		}

		private void AddIsMaxVersionFilterToHintQuery() {
			var isMaxVersionColumn = _hintEntityEntitySchema.Columns.FindByName("IsMaxVersion");
			if (isMaxVersionColumn != null) {
				_hintQuery.Filters.Add(
					_hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						isMaxVersionColumn.Name,
						true
					)
				);
			}
		}

		private void AddSysWorkspaceFilterToHintQuery() {
			var worspaceColumn = _hintEntityEntitySchema.Columns.FindByName("SysWorkspace");
			if (worspaceColumn != null) {
				_hintQuery.Filters.Add(
					_hintQuery.CreateFilterWithParameters(
						FilterComparisonType.Equal,
						worspaceColumn.Name,
						UserConnection.Workspace.Id
					)
				);
			}
		}

		#endregion

		#region Constructors: Public

		public CommandLineService() {
			EntityReader = (query, options) => query.GetEntityCollection(UserConnection, options);
		}

		public CommandLineService(UserConnection userConnection)
			:this() {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCommandList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<CommandResult> GetCommandList() {
			var commandResultList = new List<CommandResult>();
			Func<Dictionary<string, string>, EntitySchemaQuery> getMacrosESQ = GetMacrosESQ;
			FillCommandResultListFromESQ(commandResultList, getMacrosESQ, 1);
			Func<Dictionary<string, string>, EntitySchemaQuery> getCommandESQ = GetCommandESQ;
			FillCommandResultListFromESQ(commandResultList, getCommandESQ, 2);
			Func<Dictionary<string, string>, EntitySchemaQuery> getSynonymESQ = GetSynonymESQ;
			FillCommandResultListFromESQ(commandResultList, getSynonymESQ, 3);
			return commandResultList;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetHintList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> GetHintList(string subjectName, string hintText) {
			subjectName.CheckArgumentNullOrEmpty(nameof(subjectName));
			_hintEntityEntitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(subjectName);
			_hintEntityEntitySchema.CheckArgumentNull(nameof(_hintEntityEntitySchema));
			if (_hintEntityEntitySchema.PrimaryDisplayColumn == null) {
				return null;
			}
			_hintQuery = new EntitySchemaQuery(_hintEntityEntitySchema);
			_hintQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			_hintQuery.AddColumn(_hintEntityEntitySchema.PrimaryDisplayColumn.Name).OrderByAsc();
			var nameColumn = _hintEntityEntitySchema.Columns.FindByName("Name");
			if (nameColumn != null) {
				_hintQuery.AddColumn(nameColumn.Name);
			}
			var typeColumn = GetTypedColumnForHintQuery();
			if (typeColumn != null) {
				_hintQuery.AddColumn(typeColumn.Name);
			}
			var folderTypeColumn = _hintEntityEntitySchema.Columns.FindByName("FolderType");
			if (folderTypeColumn != null) {
				_hintQuery.AddColumn(folderTypeColumn.Name);
			}
			AddSysWorkspaceFilterToHintQuery();
			AddIsMaxVersionFilterToHintQuery();
			AddIsTagPropertyToHintQuery();
			AddHintTextFilterToHintQuery(hintText);
			bool isGetHintListForStartProcess = _hintEntityEntitySchema.Name == "VwSysProcess";
			if (isGetHintListForStartProcess) {
				AddProcessFiltersToHintQuery();
			}
			var options = new EntitySchemaQueryOptions {
				PageableDirection = PageableSelectDirection.First,
				PageableRowCount = 21,
				PageableConditionValues = new Dictionary<string, object>()
			};
			EntityCollection entityCollection = EntityReader(_hintQuery, options);
			var hintCollection = new Dictionary<string, string>();
			foreach (var entity in entityCollection) {
				if (isGetHintListForStartProcess) {
					if (hintCollection.ContainsKey(entity.PrimaryDisplayColumnValue)) {
						hintCollection[entity.PrimaryDisplayColumnValue] = null;
					} else {
						hintCollection.Add(entity.PrimaryDisplayColumnValue, entity.GetTypedColumnValue<string>(nameColumn.Name));
					}
				} else {
					string hintData = "";
					Guid hintId = entity.PrimaryColumnValue;
					if (typeColumn != null) {
						var result = new {
							value = hintId,
							typeId = entity.GetTypedColumnValue<string>(typeColumn.ColumnValueName)
						};
						hintData = JsonConvert.SerializeObject(result);
					} else if (folderTypeColumn != null) {
						var primaryDisplayValue = entity.PrimaryDisplayColumnValue;
						var result = new {
							value = hintId,
							displayValue = primaryDisplayValue,
							sectionFilter = new {
								value = hintId,
								displayValue = primaryDisplayValue,
								folderType = new {
									value = entity.GetTypedColumnValue<Guid>(folderTypeColumn.ColumnValueName)
								},
								folderId = hintId
							}
						};
						hintData = JsonConvert.SerializeObject(result);
					} else {
						hintData = hintId.ToString();
					}
					hintCollection[entity.PrimaryDisplayColumnValue] = hintData;
				}
			}
			return hintCollection;
		}

		private void AddProcessFiltersToHintQuery() {
			AddProcessStartTypeFilterToHintQuery();
			AddProcessRightsFilterToHintQuery();
		}

		private void AddProcessRightsFilterToHintQuery() {
			EntitySchemaQueryFilter rightsFilter =
				_hintQuery.CreateExistsFilter("[VwSysProcessSchemaUserRight:SysSchema:SysSchemaId].Id");
			rightsFilter.Name = "processesRights";
			EntitySchemaQuery rightsSubQuery = rightsFilter.RightExpressions[0].SubQuery;
			IEntitySchemaQueryFilterItem adminUnitFilter = rightsSubQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "SysAdminUnit", UserConnection.CurrentUser.Id);
			adminUnitFilter.Name = "adminUnit";
			rightsSubQuery.Filters.Add(adminUnitFilter);
			_hintQuery.Filters.Add(rightsFilter);
		}

		private void AddProcessStartTypeFilterToHintQuery() {
			IEntitySchemaQueryFilterItem startTypeFilter = _hintQuery.CreateFilterWithParameters(
				FilterComparisonType.Equal, "[VwProcessLib:SysSchemaId:SysSchemaId].HasStartEvent", true);
			startTypeFilter.Name = "hasStartEventFilter";
			_hintQuery.Filters.Add(startTypeFilter);
		}

		private void AddHintTextFilterToHintQuery(string hintText) {
			if (string.IsNullOrEmpty(hintText)) {
				return;
			}
			IEntitySchemaQueryFilterItem filter = _hintQuery.CreateFilterWithParameters(
				FilterComparisonType.StartWith, _hintEntityEntitySchema.PrimaryDisplayColumn.Name, hintText);
			_hintQuery.Filters.Add(filter);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetFixedCommandList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<CommandLineUtility.ParamCommand> GetFixedCommandList() {
			return CommandLineUtility.GetParamCommandList(UserConnection);
		}

		[WebInvoke(Method = "POST", UriTemplate = "GetMainParamTypeList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Dictionary<string, string> GetMainParamTypeList(string subjectSchemaUId, string columnUId) {
			if (string.IsNullOrEmpty(subjectSchemaUId) || string.IsNullOrEmpty(columnUId)) {
				return null;
			}
			var typeColumn = Guid.Parse(columnUId);
			var schemaUId = Guid.Parse(subjectSchemaUId);
			if (typeColumn == Guid.Empty || schemaUId == Guid.Empty) {
				return null;
			}
			var subjectSchema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
			var mainParamTypeCollection = new Dictionary<string, string>();
			var typeSchema = subjectSchema.Columns.GetByUId(typeColumn).ReferenceSchema;
			var typeESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModuleEdit");
			typeESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			var primaryDisplayColumn = typeESQ.AddColumn("[" + typeSchema.Name + ":Id:TypeColumnValue]." + typeSchema.PrimaryDisplayColumn.Name);
			EntitySchemaQueryColumn codeESQColumn = null;
			var codeColumn = typeSchema.Columns.FindByName("Code");
			codeESQColumn = codeColumn == null ? null : typeESQ.AddColumn("[" + typeSchema.Name + ":Id:TypeColumnValue]." + codeColumn.Name);
			typeESQ.Filters.Add(
				typeESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"SysModuleEntity.SysEntitySchemaUId",
					schemaUId
				)
			);
			typeESQ.Filters.Add(
				typeESQ.CreateFilterWithParameters(
					FilterComparisonType.NotEqual,
					"TypeColumnValue",
					BPMSoft.Configuration.ActivityConsts.CallTypeUId
				)
			);
			var typeEntityCollection = typeESQ.GetEntityCollection(UserConnection);
			foreach (var typeEntity in typeEntityCollection) {
				var typeName = typeEntity.GetTypedColumnValue<string>(primaryDisplayColumn.Name);
				var typeCode = codeESQColumn == null ? null : typeEntity.GetTypedColumnValue<string>(codeESQColumn.Name);
				mainParamTypeCollection.Add(typeCode, typeName);
			}
			return mainParamTypeCollection;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ClearCache", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ClearCache(string[] cacheArray) {
			if (cacheArray.Length == 0) {
				return;
			}
			foreach (var cacheName in cacheArray) {
				var appCache = UserConnection.SessionCache.WithLocalCaching(cacheName);
				appCache.ExpireGroup(cacheName);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateParamCommands", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateParamCommands() {
			CommandLineUtility.CheckRegisteredSections(UserConnection);
		}

		#endregion

		#region Class: CommandResult

		public class CommandResult {
			public Guid Id {
				get;
				set;
			}
			public string Caption {
				get;
				set;
			}
			public string CommandCaption {
				get;
				set;
			}
			public string Code {
				get;
				set;
			}
			public string ColumnCaption {
				get;
				set;
			}
			public string ColumnName {
				get;
				set;
			}
			public string SubjectName {
				get;
				set;
			}
			public string MainParamCaption {
				get;
				set;
			}
			public string ColumnTypeCode {
				get;
				set;
			}
			public int HintType {
				get;
				set;
			}
			public Guid RealId {
				get;
				set;
			}
		}

		#endregion

		#region Enum: CommandHintTypeResult

		enum HintType {
			Macros = 1,
			Command = 2,
			Synonym = 3
		}

		#endregion
	}
}
