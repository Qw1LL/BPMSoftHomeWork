define("QueuePage", ["BPMSoft", "ConfigurationEnums", "ProcessModuleUtilities", "OperatorSingleWindowConstants",
		"QueueClientNotificationUtilities", "QueuePageResources", "QueueGridUtilities", "QueuePageProfileUtilities",
		"QueueFillingUtilities", "QueueSortUtilities", "QueueProcessUtilities", "css!DetailModuleV2"],
	function(BPMSoft, ConfigurationEnums, ProcessModuleUtilities, OperatorSingleWindowConstants,
			QueueClientNotificationUtilities, resources) {
		return {
			/**
			 * ### #####.
			 * @type {String}
			 */
			entitySchemaName: "QueueItem",
			mixins: {

				/**
				 * @class QueueGridUtilities ########### ###### ###### # ######## #######.
				 */
				GridUtilities: "BPMSoft.QueueGridUtilities",

				/**
				 * @class QueuePageProfileUtilities ########### ###### ###### # ######## ## ######## #######.
				 */
				QueuePageProfileUtilities: "BPMSoft.QueuePageProfileUtilities",

				/**
				 * @class QueueFillingUtilities ########### ###### ########## ########.
				 */
				QueueFillingUtilities: "BPMSoft.QueueFillingUtilities",

				/**
				 * @class QueueSortUtilities implements queue sorting features.
				 */
				QueueSortUtilities: "BPMSoft.QueueSortUtilities",

				/**
				 * @class QueueProcessUtilities implements queue process features.
				 */
				QueueProcessUtilities: "BPMSoft.QueueProcessUtilities"

			},
			messages: {

				/**
				 * ########## ######### ### ######### #########.
				 */
				"GetHistoryState": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ########## ######### ######### #########.
				 */
				"PushHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######## ## ######### ### ######### ########## ###### ######### ####### ######.
				 */
				"SaveGridSettings": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######## ## ######### ######### ######### #######.
				 */
				"GridSettingsChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######## ## ######### ### ########## ########## ###### ######### ####### ######.
				 */
				"GetGridSettingsInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######## ## ######### ### ########## ########## ###### ######### ####### ######.
				 */
				"GetEntitySchema": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetCardState
				 * ########## ######### ############ ######## ### ######### #########.
				 */
				"GetCardState": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SaveRecord
				 * ########## ######### ############ ######## # ############# ###########.
				 */
				"SaveRecord": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message FillingKindChanged
				 * ######## ## ######### # ######### #### ########## #######.
				 */
				"FillingKindChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateData
				 * ######## ## ######### # ############# ######## ######.
				 */
				"UpdateData": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {

				/**
				 * ############# ####### #######.
				 * @type {String}
				 */
				EntitySchemaUId: {dataValueType: BPMSoft.DataValueType.GUID},

				/**
				 * ######## ##### ####### #######.
				 * @type {String}
				 */
				EntitySchemaName: {dataValueType: BPMSoft.DataValueType.STRING},

				/**
				 * ######### ####### #######.
				 * @type {String}
				 */
				EntitySchemaCaption: {dataValueType: BPMSoft.DataValueType.STRING},

				/**
				 * ######### ####### #######.
				 * @type {String}
				 */
				EntitySchemaPrimaryDisplayColumnName: {dataValueType: BPMSoft.DataValueType.STRING},

				/**
				 * ######## ######### ####### ######## ###### #######.
				 * @type {String}
				 */
				ActiveRow: {dataValueType: BPMSoft.DataValueType.GUID},

				/**
				 * ######### ######.
				 * @type {BPMSoft.BaseViewModelCollection}
				 */
				Collection: {dataValueType: BPMSoft.DataValueType.COLLECTION},

				/**
				 * ####### "#### ######".
				 * @type {Boolean}
				 */
				IsGridEmpty: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####### "#### # ######## ########".
				 * @type {Boolean}
				 */
				IsGridLoading: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ######## ############# #####.
				 * @type {Boolean}
				 */
				MultiSelect: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ###### ######### #####.
				 * @type {Array}
				 */
				SelectedRows: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT},

				/**
				 * ########## #####.
				 * @type {Number}
				 */
				RowCount: {dataValueType: BPMSoft.DataValueType.INTEGER},

				/**
				 * ############ ########.
				 * @type {Boolean}
				 */
				IsPageable: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####### "###### #########".
				 * @type {Boolean}
				 */
				IsGridDataLoaded: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ###### ########## # ############# ######### ############ ####### ######## #######.
				 * @type {Boolean}
				 */
				GridSettingsChanged: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ######### ########### ###### ############## ######.
				 * @type {BPMSoft.BaseViewModelCollection}
				 */
				ToolsButtonMenu: {dataValueType: BPMSoft.DataValueType.COLLECTION},

				/**
				 * ############ ########## ####### ####### #######.
				 * @type {Object[]}
				 */
				QueueColumnsSortConfig: {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"value": []
				},

				/**
				 * ####### ######### ###### "######### ######".
				 * @type {Boolean}
				 */
				IsNextRecordButtonVisible: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ####### ########## #######.
				 * @type {Boolean}
				 */
				IsClosedQueue: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * #### #######.
				 * @type {String}
				 */
				ProfileKey: {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ""
				},

				/**
				 * ####### ###### ###########.
				 * @type {Boolean}
				 */
				IsSupervisorMode: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ####### ###### ######.
				 * @type {Boolean}
				 */
				IsDetailMode: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ############# #######.
				 * @type {String}
				 */
				QueueId: {"dataValueType": BPMSoft.DataValueType.GUID},

				/**
				 * ########### ##########.
				 * @type {Number}
				 */
				GridSortDirection: {dataValueType: BPMSoft.DataValueType.INTEGER},

				/**
				 * ####### ##########.
				 * @type {Number}
				 */
				SortColumnIndex: {dataValueType: BPMSoft.DataValueType.INTEGER},

				/**
				 * ####### ########## ####### #######.
				 * @type {Boolean}
				 */
				IsManuallyFilling: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * ####### ############# ##### ####### #######.
				 * @type {Boolean}
				 */
				IsEntityFolderExists: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * ######### # ##### ####### ##### ####### # ######## #######.
				 * @private
				 */
				addQueueEntityColumn: function() {
					var referenceSchemaName = this.get("EntitySchemaName");
					var queueEntityColumnCaption = this.get("EntitySchemaCaption");
					var queueLookupColumnName = "EntityRecord";
					var queueColumnName = queueLookupColumnName + "Id";
					this.entitySchema.columns[queueColumnName] = {
						uId: BPMSoft.generateGUID(),
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						referenceSchemaName: referenceSchemaName,
						isLookup: true,
						lookupType: "Exist",
						name: queueLookupColumnName,
						caption: queueEntityColumnCaption,
						usageType: ConfigurationEnums.EntitySchemaColumnUsageType.General
					};
					this.sandbox.subscribe("GetEntitySchema", this.onGetEntitySchema.bind(this),
						[this.sandbox.id + "_QueuePage"]);
				},

				/**
				 * ########## ####### ######### ###### "##### # ######".
				 * @private
				 * @return {Boolean} ####### #########.
				 */
				getIsProcessRunButtonVisible: function() {
					return !this.get("IsSupervisorMode");
				},

				/**
				 * ############## ########## ###### ############## ######.
				 * @private
				 */
				initToolsButtonMenu: function() {
					var toolsButtonMenu = this.get("ToolsButtonMenu");
					if (!toolsButtonMenu) {
						toolsButtonMenu = this.Ext.create("BPMSoft.BaseViewModelCollection");
					}
					this.addToolsButtonMenuItems(toolsButtonMenu);
					this.set("ToolsButtonMenu", toolsButtonMenu);
				},

				/**
				 * ############## ######### ###### "######### ######".
				 * @private
				 */
				setNextRecordButtonVisibility: function() {
					var isClosedQueue = this.get("IsClosedQueue");
					if (!isClosedQueue) {
						return;
					}
					this.BPMSoft.SysSettings.querySysSettings(["MaxCloseQueueProgressRecordsCount"],
						function(sysSettings) {
							var gridData = this.getGridData();
							this.set("IsNextRecordButtonVisible",
								sysSettings.MaxCloseQueueProgressRecordsCount > gridData.getCount());
						},
						this);
				},

				/**
				 * ############ ####### ####### #####.
				 * @private
				 * @param {String} schemaName ### #####.
				 * @return {BPMSoft.EntitySchemaQuery} #### ##### ## ####### - ########## #####, ##### - null.
				 */
				onGetEntitySchema: function(schemaName) {
					if (this.entitySchemaName === schemaName) {
						return this.entitySchema;
					}
					return null;
				},

				/**
				 * ############ ######### # ######### #### ########## #######.
				 * @private
				 * @param {Boolean} isManuallyFilling ####### ########## ####### #######..
				 */
				onFillingKindChanged: function(isManuallyFilling) {
					this.set("IsManuallyFilling", isManuallyFilling);
				},

				/**
				 * ############ ######### ## ############# ########## ######.
				 * @private
				 */
				onUpdateData: function(parameters) {
					this.applyParameters(parameters);
					var gridData = this.getGridData();
					if (!gridData) {
						return;
					}
					gridData.clear();
					BPMSoft.require(["profile!" + this.getProfileKey()], function(profile) {
						var profileColumnName = this.getProfileColumnName();
						this.set(profileColumnName, profile);
						this.set("GridSettingsChanged", true);
						this.queryColumnsSortConfig({
							entitySchemaUId: this.get("EntitySchemaUId"),
							callback: function(sortConfig) {
								this.set("QueueColumnsSortConfig", sortConfig);
								this.addQueueEntityColumn();
								this.loadGridData();
							}.bind(this)
						});
					}, this);
				},

				/**
				 * ########## ####### ######### ######### ######.
				 * @private
				 * @return {Boolean} ####### ######### ######### ######.
				 */
				getIsHeaderVisible: function() {
					return this.get("IsDetailMode");
				},

				/**
				 * ########## ####### ######### ###### ######### ####### # ###### "########".
				 * @private
				 * @return {Boolean} ####### #########.
				 */
				getIsPageToolsButtonVisible: function() {
					return !this.get("IsDetailMode");
				},

				/**
				 * ########## ####### ######### ###### ######### ####### # ###### "######".
				 * @return {Boolean} ####### #########.
				 */
				getIsDetailToolsButtonVisible: function() {
					return this.get("IsDetailMode");
				},

				/**
				 * ########## ######### ###### "########".
				 * @return {Boolean} ######### ######.
				 */
				getIsAddQueueItemsVisible: function() {
					return this.get("IsDetailMode") && this.get("IsManuallyFilling");
				},

				/**
				 * ########## ######### ###### ########.
				 * @private
				 * @return {String} ######### ###### ########.
				 */
				getQueuePageGroupCaption: function() {
					return this.get("IsDetailMode") ? this.get("Resources.Strings.QueuePageGroupCaption") : "";
				},

				/**
				 * ######### ############# ###### ####### #######.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 */
				getIsEntityFolderExist: function(callback) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysSchema",
						rowCount: 1
					});
					esq.addColumn("Name");
					esq.filters.add("Name", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Name", this.get("EntitySchemaName") + "Folder"));
					esq.getEntityCollection(function(response) {
						this.set("IsEntityFolderExists", (response.success && !response.collection.isEmpty()));
						callback();
					}.bind(this));
				},

				/**
				 * Extract entity name from related object column path.
				 * @private
				 * @param columnPath Column path.
				 * @returns {String} Entity name.
				 */
				extractRelatedEntityName: function (columnPath) {
					const relatedEntityWrapperTpl = /^\[.*?\]$/;
					let entityName = columnPath;
					if(relatedEntityWrapperTpl.test(columnPath)) {
						const relatedEntityNameTpl =/^\[(\w+):\D+\]$/;
						const matches = entityName.match(relatedEntityNameTpl);
						if(matches && matches.length === 2) {
							entityName = matches[1];
						}
					}
					return entityName;
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc QueuePage.mixins.GridUtilities.#getColumnByPath
				 * @overridden
				 */
				getColumnByPath:function(columnPath) {
					const mixinColumn = this.mixins.GridUtilities.getColumnByPath(columnPath);
					if(!mixinColumn) {
						const paths = (columnPath && columnPath.split(".")) || [];
						const columnName = paths.pop();
						const relatedColumnPath = paths.pop();
						const entityName = this.extractRelatedEntityName(relatedColumnPath);
						if(relatedColumnPath !== entityName) {
							columnPath = Ext.String.format("{0}.{1}", entityName, columnName);
							return this.mixins.GridUtilities.getColumnByPath(columnPath);
						}
					}
					return mixinColumn;
				},

				/**
				 * @inheritdoc BasePageV2#onRender
				 * @overridden
				 */
				onRender: function() {
					this.switchActiveRowActions();
					if (this.get("GridSettingsChanged")) {
						this.reloadGridData();
					} else {
						var gridData = this.getGridData();
						this.reloadGridColumnsConfig(true);
						if (gridData && gridData.getCount() > 0) {
							var tempCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
							var items = gridData.getItems();
							BPMSoft.each(items, function(item) {
								tempCollection.add(item.get("Id"), item);
							});
							gridData.clear();
							gridData.loadAll(tempCollection);
						}
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.subscribeEvents();
					this.callParent([function() {
						QueueClientNotificationUtilities.subscribeForQueuesNotifications();
						this.queryColumnsSortConfig({
							entitySchemaUId: this.get("EntitySchemaUId"),
							callback: function(sortConfig) {
								this.set("QueueColumnsSortConfig", sortConfig);
								this.addQueueEntityColumn();
								this.initData();
								if (this.get("IsDetailMode")) {
									this.getIsEntityFolderExist(function() {
										callback.call(scope);
									});
								} else {
									callback.call(scope);
								}
							}.bind(this)
						});
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getGridData
				 * @overridden
				 */
				getGridData: function() {
					return this.get("Collection");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getProfileKey
				 * @overridden
				 */
				getProfileKey: function() {
					var entitySchemaName = this.get("EntitySchemaName");
					var profileKey = this.get("ProfileKey");
					var defaultProfileKey = this.getPageProfileKey(entitySchemaName);
					return Ext.isEmpty(profileKey) ? defaultProfileKey : profileKey;
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(esq) {
					this.mixins.GridUtilities.initQueryColumns.apply(this, arguments);
					if (this.get("IsSupervisorMode")) {
						return;
					}
					this.addQueueSortColumns(esq, this.get("QueueColumnsSortConfig"));
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilities#initQuerySorting
				 * @overridden
				 */
				initQuerySorting: function(esq) {
					this.mixins.GridUtilities.initQuerySorting.apply(this, arguments);
					if (this.get("IsSupervisorMode")) {
						return;
					}
					this.initQueueQuerySorting(esq, this.get("QueueColumnsSortConfig"));
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#deleteRecords
				 * @overridden
				 */
				deleteRecords: function() {
					var activeRowId = this.get("ActiveRow");
					this.checkCanDelete([activeRowId], this.checkCanDeleteCallback, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getActiveRow
				 * @overridden
				 */
				getActiveRow: function() {
					var primaryColumnValue = this.get("ActiveRow");
					if (primaryColumnValue) {
						var gridData = this.getGridData();
						return gridData.get(primaryColumnValue);
					}
				},

				/**
				 * @inheritdoc BPMSoft.QueueSortUtilities#getQueueEntityColumnPath
				 */
				getQueueEntityColumnPath: function(entitySchemaName, columnName) {
					return Ext.String.format("[{0}:Id:EntityRecordId].{1}", entitySchemaName, columnName);
				},

				/**
				 * ############## ######### ###### ############# #######.
				 * @protected
				 */
				initData: function() {
					this.initGridRowViewModel(function() {
						this.initGridData();
						this.initSortActionItems();
						this.reloadGridColumnsConfig();
						this.loadGridData();
						this.initToolsButtonMenu();
						this.mixins.GridUtilities.init.call(this);
					}, this);
				},

				/**
				 * ######### ############# ######## ## ######### ### ###### ## #######.
				 * @protected
				 */
				initGridData: function() {
					this.set("Collection", Ext.create("BPMSoft.BaseViewModelCollection"));
					this.set("ActiveRow", "");
					if (Ext.isEmpty(this.get("MultiSelect"))) {
						this.set("MultiSelect", false);
					}
					if (Ext.isEmpty(this.get("IsPageable"))) {
						this.set("IsPageable", true);
					}
					this.set("IsClearGridData", false);
					if (!Ext.isNumber(this.get("RowCount"))) {
						this.set("RowCount", 15);
					}
				},

				/**
				 * ######### ######## ## #########.
				 * @protected
				 */
				subscribeEvents: function() {
					this.sandbox.subscribe("FillingKindChanged", this.onFillingKindChanged, this, [this.sandbox.id]);
					this.sandbox.subscribe("UpdateData", this.onUpdateData, this, [this.sandbox.id]);
				},

				/**
				 * ########## ####### ########### ###### ############## ######, ########## ## ######### #######.
				 * @protected
				 * @return {BaseViewModel} ####### ########### ###### ############## ######, ########## ## #########
				 * #######.
				 */
				getGridSettingsMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.SetupQueueGridMenuCaption"},
						Click: {"bindTo": "openGridSettings"}
					});
				},

				/**
				 * ######### ######## # ######### ########### ###### ############## ######.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} toolsButtonMenu ######### ###########
				 * ###### ############## ######.
				 */
				addToolsButtonMenuItems: function(toolsButtonMenu) {
					if (this.get("IsDetailMode")) {
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							Caption: {"bindTo": "Resources.Strings.DeleteMenuCaption"},
							Click: {"bindTo": "deleteRecords"},
							Enabled: {bindTo: "isAnySelected"}
						}));
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							Type: "BPMSoft.MenuSeparator"
						}));
						toolsButtonMenu.addItem(this.getButtonMenuItem({
							Caption: {"bindTo": "Resources.Strings.SortMenuCaption"},
							Items: this.get("SortColumns")
						}));
					}
					var gridSettingsMenuItem = this.getGridSettingsMenuItem();
					if (gridSettingsMenuItem) {
						toolsButtonMenu.addItem(gridSettingsMenuItem);
					}
				},

				/**
				 * ############ ####### ###### # ###### ######## ######## ######.
				 * @protected
				 * @param {String} buttonTag ### ######.
				 * @param {String} primaryColumnValue ########## ############# ######.
				 */
				onActiveRowAction: function(buttonTag, primaryColumnValue) {
					if (buttonTag === "runProcess") {
						this.mixins.QueueProcessUtilities.executeQueueItemProcess.call(this, primaryColumnValue, false,
							function(canRunQueueItemProcess) {
								if (!canRunQueueItemProcess) {
									this.set("ActiveRow", null);
									this.reloadGridData();
								}
							}.bind(this)
						);
					}
				},

				/**
				 * ########## ####### ############# ########## ############ ########.
				 * @protected
				 */
				onNeedLoadData: function() {
					if (!this.get("CanLoadMoreData")) {
						return;
					}
					this.loadGridData();
				},

				/**
				 * ######### ######### ###### ######## #######.
				 * @protected
				 */
				nextRecordButtonClick: function() {
					var maskId = this.showBodyMask({
						timeout: 0
					});
					var esq = this.getGridDataESQ();
					esq.rowCount = 1;
					this.initQueryColumns(esq);
					this.initQuerySorting(esq);
					this.addPrimaryColumnQuerySorting(esq);
					var filters = esq.filters;
					this.addQueueFilters(filters, {
						"skipOperatorFilter": true
					});
					filters.addItem(this.BPMSoft.createIsNullFilter(
						this.Ext.create("BPMSoft.ColumnExpression", {columnPath: "Operator"})
					));
					esq.getEntityCollection(function(response) {
						if (!response.success || response.collection.isEmpty()) {
							this.hideBodyMask(maskId);
							return;
						}
						var item = response.collection.getByIndex(0);
						this.mixins.QueueProcessUtilities.executeQueueItemProcess.call(this, item.get("Id"), false,
							function(canRunQueueItemProcess) {
								if (!canRunQueueItemProcess) {
									this.hideBodyMask(maskId);
									this.set("ActiveRow", null);
									this.reloadGridData();
								}
							}.bind(this)
						);
					}, this);
				},

				/**
				 * ######### ########## ## ######### #######.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq ######, # ####### ##### ################### #######.
				 */
				addPrimaryColumnQuerySorting: function(esq) {
					var queueSortColumns = this.get("QueueColumnsSortConfig");
					var idColumn = esq.columns.get("Id");
					if (idColumn) {
						idColumn.orderPosition = queueSortColumns.length + 1;
						idColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
					}
				},

				//endregion

				//region Methods: Public

				/**
				 * ######### ######### ######.
				 * @param {Object} parameters ######, ########### #########.
				 */
				applyParameters: function(parameters) {
					for (var parameterName in parameters) {
						if (!parameters.hasOwnProperty(parameterName)) {
							continue;
						}
						this.set(parameterName, parameters[parameterName]);
					}
				},

				/**
				 * @inheritdoc BPMSoft.configuration.mixins.GridUtilities#getGridSettingsModuleConfig
				 * @override
				 */
				getGridSettingsModuleConfig: function(gridSettingsId) {
					return {
						renderTo: "centerPanel",
						id: gridSettingsId,
						keepAlive: true,
						instanceConfig: {
							schemaName: "QueuePageGridSettingsPage",
							isSchemaConfigInitialized: true
						}
					};
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "pageToolsButton",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.PageToolsButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": {"bindTo": "ToolsButtonMenu"}
						},
						"classes": {"wrapperClass": ["page-tools-button"]},
						"selectors": {"wrapEl": "#pageToolsButton"},
						"visible": {"bindTo": "getIsPageToolsButtonVisible"},
						"markerValue": "queueTools"
					}
				},
				{
					"operation": "insert",
					"name": "QueuePageGroup",
					"propertyName": "items",
					"values": {
						"id": "QueuePageGroup",
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"controlConfig": {
							"collapsed": false,
							"caption": {"bindTo": "getQueuePageGroupCaption"}
						},
						"classes": {"wrapClass": ["detail"]},
						"markerValue": "QueuePageGroup",
						"isHeaderVisible": {"bindTo": "getIsHeaderVisible"},
						"items": [],
						"tools": []
					}
				},
				{
					"operation": "insert",
					"name": "AddQueueItemsButton",
					"parentName": "QueuePageGroup",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"markerValue": "AddTypedRecordButton",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"visible": {"bindTo": "getIsAddQueueItemsVisible"},
						"imageConfig": {"bindTo": "Resources.Images.AddQueueItemButtonImage"},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "AddEntityRecord",
					"parentName": "AddQueueItemsButton",
					"propertyName": "menu",
					"values": {
						"itemType": BPMSoft.ViewItemType.MENU_ITEM,
						"caption": {"bindTo": "Resources.Strings.AddEntityRecordCaption"},
						"click": {"bindTo": "onAddEntityRecordClick"},
						"markerValue": {"bindTo": "Resources.Strings.AddEntityRecordCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "AddEntityFolderRecord",
					"parentName": "AddQueueItemsButton",
					"propertyName": "menu",
					"values": {
						"itemType": BPMSoft.ViewItemType.MENU_ITEM,
						"caption": {"bindTo": "Resources.Strings.AddEntityFolderRecordCaption"},
						"click": {"bindTo": "onAddEntityFolderRecordClick"},
						"visible": {"bindTo": "IsEntityFolderExists"},
						"markerValue": {"bindTo": "Resources.Strings.AddEntityFolderRecordCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "detailToolsButton",
					"parentName": "QueuePageGroup",
					"propertyName": "tools",
					"values": {
						"id": "detailToolsButton",
						"markerValue": "ToolsButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.DetailToolsButton"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"menu": {
							"items": {"bindTo": "ToolsButtonMenu"}
						},
						"classes": {
							"wrapperClass": ["detail-tools-button-wrapper"],
							"menuClass": ["detail-tools-button-menu"]
						},
						"selectors": {"wrapEl": "#detailToolsButton"},
						"visible": {"bindTo": "getIsDetailToolsButtonVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "queueContainer",
					"parentName": "QueuePageGroup",
					"propertyName": "items",
					"values": {
						"id": "queueContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": {"bindTo": "EntitySchemaName"}
					}
				},
				{
					"operation": "insert",
					"name": "DataGrid",
					"parentName": "queueContainer",
					"propertyName": "items",
					"values": {
						"type": ConfigurationEnums.GridType.LISTED,
						"itemType": BPMSoft.ViewItemType.GRID,
						"listedZebra": true,
						"collection": {"bindTo": "Collection"},
						"activeRow": {"bindTo": "ActiveRow"},
						"primaryColumnName": "Id",
						"isEmpty": {"bindTo": "IsGridEmpty"},
						"isLoading": {"bindTo": "IsGridLoading"},
						"multiSelect": {"bindTo": "MultiSelect"},
						"selectedRows": {"bindTo": "SelectedRows"},
						"linkClick": {"bindTo": "linkClicked"},
						"sortColumn": {"bindTo": "sortColumn"},
						"sortColumnDirection": {"bindTo": "GridSortDirection"},
						"sortColumnIndex": {"bindTo": "SortColumnIndex"},
						"needLoadData": {"bindTo": "onNeedLoadData"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"canChangeMultiSelectWithGridClick": false,
						"activeRowActions": []
					}
				},
				{
					"operation": "insert",
					"name": "ProcessRunButton",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": resources.localizableStrings.RunProcessButtonCaption,
						"tag": "runProcess",
						"visible": {"bindTo": "getIsProcessRunButtonVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "nextRecordButton",
					"parentName": "queueContainer",
					"propertyName": "items",
					"values": {
						"id": "nextRecordButton",
						"selectors": {"wrapEl": "#nextRecordButton"},
						"classes": {"textClass": "next-record-button"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.NextRecordButtonCaption"},
						"click": {"bindTo": "nextRecordButtonClick"},
						"visible": {"bindTo": "IsNextRecordButtonVisible"},
						"clickDebounceTimeout": 10000
					}
				}
			]
		};
	}
);
