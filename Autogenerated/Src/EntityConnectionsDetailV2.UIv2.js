define("EntityConnectionsDetailV2", ["BPMSoft", "EntityConnectionsDetailV2Resources", "EntityConnectionViewModel",
		"ConfigurationItemGenerator", "BaseDetailV2", "EntityConnectionLinksUtilities"],
	function(BPMSoft) {
		return {
			attributes: {

				/**
				 * ####### "###### #########".
				 */
				IsDataLoaded: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * ########## ## ####### ### ########## ##### ######.
				 */
				EntityInfo: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Page tips.
				 */
				PageTips: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * ########## # ######. ######## ### ##### # ####### ##########.
				 */
				DetailInfo: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * ########### ########## ##### ## #########.
				 * @type {BPMSoft.OrderDirection} [SortDirection=BPMSoft.OrderDirection.ASC]
				 */
				SortDirection: BPMSoft.OrderDirection.ASC

			},
			messages: {

				/**
				 * @message GetEntityInfo
				 * ######## ########## # ####### ### ######## ########## ########## #### #####.
				 */
				"GetEntityInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetPageTips
				 * Getting page tips to modify entity connection detail tips.
				 */
				"GetPageTips": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message EntityInitialized
				 * ######### ### ############# ######## #######. ###### ### ###### ######## ###### # ######## #####.
				 */
				"EntityInitialized": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetColumnsValues
				 * ########### # ######## ####### ######## ########## #######.
				 */
				"GetColumnsValues": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message LookupInfo
				 * ### ###### LookupUtilities. ######### ######## ######.
				 */
				"LookupInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ResultSelectedRows
				 * ### ###### LookupUtilities. ######## ###### ## ######.
				 */
				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message UpdateCardProperty
				 * ############# ######## ######## ##############.
				 */
				"UpdateCardProperty": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetLookupQueryFilters
				 * ######## ####### ########## #######.
				 */
				"GetLookupQueryFilters": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetLookupListConfig
				 * ######## ########## # ########## ########## #######.
				 */
				"GetLookupListConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message EntityColumnChanged
				 * ######### ## ######### ######## ####### ####### ########.
				 */
				"EntityColumnChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetLookupValuePairs
				 * ########## ########## # ######### ## #########, ############ # ##### ###### ########## #######.
				 */
				"GetLookupValuePairs": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			mixins: {
				EntityConnectionLinksUtilities: BPMSoft.EntityConnectionLinksUtilities
			},
			methods: {

				/**
				 * Returns default item config.
				 * @private
				 * @param {String} columnName Column name.
				 * @param {BPMSoft.DataValueType} dataValueType Column dataValueType.
				 * @return {Object} Default item config.
				 */
				getDefaultItemConfig: function(columnName, dataValueType) {
					dataValueType = dataValueType || BPMSoft.DataValueType.LOOKUP;
					var defaultItemConfig = {
						itemType: BPMSoft.ViewItemType.MODEL_ITEM,
						dataValueType: dataValueType,
						name: columnName,
						caption: {bindTo: "Caption"},
						markerValue: {bindTo: "MarkerValue"}
					};
					switch (dataValueType) {
						case BPMSoft.DataValueType.LOOKUP:
							defaultItemConfig.controlConfig = {
								value: {bindTo: "Value"},
								list: {bindTo: "ValuesList"},
								href: {bindTo: "getHref"},
								linkclick: {bindTo: "onLinkClick"},
								linkmouseover: {bindTo: "linkMouseOver"},
								tag: {
									columnName: "Value",
									referenceSchemaName: columnName
								},
								showValueAsLink: true,
								hasClearIcon: true
							};
							break;
						default:
							defaultItemConfig.controlConfig = {
								value: {bindTo: "Value"}
							};
							break;
					}
					return defaultItemConfig;
				},

				/**
				 * Create instance of View Generator.
				 * @protected
				 * @return {BPMSoft.ViewGenerator}
				 */
				createViewGeneratorInstance: function() {
					return Ext.create("BPMSoft.ViewGenerator");
				},

				/**
				 * Append tip to column.
				 * @private
				 * @param {Object} itemConfig Entity connection item config.
				 * @param {String} columnName Entity connection column name.
				 */
				appendTip: function(itemConfig, columnName) {
					var pageTips = this.get("PageTips");
					if (pageTips && pageTips[columnName]) {
						this.Ext.merge(itemConfig, {
							tip: {
								content: pageTips[columnName]
							}
						});
					}
				},

				/**
				 * Generates item view config.
				 * @param {Object} itemConfig Item config.
				 * @param {BPMSoft.EntityConnectionViewModel} item Entity connection model item.
				 */
				getItemViewConfig: function(itemConfig, item) {
					var columnName = item.get("ColumnName");
					var itemViewConfig = this.get("ItemViewConfig") || [];
					if (itemViewConfig && itemViewConfig[columnName]) {
						itemConfig.config = itemViewConfig[columnName];
						return;
					}
					var dataValueType = item.get("DataValueType");
					var defaultItemConfig = this.getDefaultItemConfig(columnName, dataValueType);
					var viewGenerator = this.createViewGeneratorInstance();
					this.appendTip(defaultItemConfig, columnName);
					var editConfig = viewGenerator.generatePartial(
						{
							itemType: BPMSoft.ViewItemType.CONTAINER,
							wrapClass: ["control-width-15", "detail-edit-container-user-class"],
							items: [defaultItemConfig]
						},
						{
							schemaName: "EntityConnectionsDetailV2",
							viewModelClass: Ext.ClassManager.get("BPMSoft.EntityConnectionViewModel"),
							schema: {}
						}
					);
					itemConfig.config = editConfig[0];
					itemViewConfig[columnName] = editConfig[0];
					this.set("ItemViewConfig", itemViewConfig);
				},

				/**
				 * ############ ####### ######### ######## ####### ####### ########.
				 * @param {Object} changed
				 * @param {Text} changed.columnName ######## #######.
				 * @param {Object} changed.columnValue ######## #######.
				 */
				onEntityColumnChanged: function(changed) {
					var gridData = this.get("Collection");
					var filterResult = gridData.filterByFn(function(item) {
						return item.get("ColumnName") === changed.columnName;
					}, this);
					filterResult.each(function(item) {
						item.set("Value", changed.columnValue);
					}, this);
				},

				/**
				 * ######### ###### # ###### ############# ####### ##### #######.
				 * @private
				 * @param {BPMSoft.BaseViewModelCollection} inputCollection (optional)
				 * ######### ### ########## #######.
				 */
				loadColumnValues: function(inputCollection) {
					var collection = inputCollection || this.get("Collection");
					var columnValues = this.getColumnValues(inputCollection);
					collection.each(function(item) {
						var columnName = item.get("ColumnName");
						var columnValue = columnValues[columnName];
						item.set("Value", columnValue);
					}, this);
				},

				/**
				 * ######## ######## ###### ######## #######. ######## ####### ###### #### ######### ##
				 * ############### #########.
				 * @private
				 * @return {Object} ######## ####### #######.
				 */
				getColumnValues: function(inputCollection) {
					var sandbox = this.sandbox;
					var gridData = inputCollection || this.get("Collection");
					var linkColumnNames = [];
					gridData.each(function(gridItem) {
						var columnName = gridItem.get("ColumnName");
						linkColumnNames.push(columnName);
					}, this);
					return sandbox.publish("GetColumnsValues", linkColumnNames, [sandbox.id]);
				},

				/**
				 * ########## ####### ############ #######.
				 * @param {Object} entityInfo ########## # #######. ###, ######### # ######### #######.
				 * @private
				 */
				onEntityInitialized: function(entityInfo) {
					this.set("EntityInfo", entityInfo);
					if (this.get("IsDataLoaded")) {
						this.loadColumnValues();
					} else {
						var collection = this.get("Collection");
						this.loadEntityConnections(collection);
					}
				},

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						var sandbox = this.sandbox;
						var messageTags = [sandbox.id];
						var entityInfo = sandbox.publish("GetEntityInfo", null, messageTags);
						var pageTips = sandbox.publish("GetPageTips", null, messageTags);
						var detailInfo = this.getDetailInfo();
						this.set("PageTips", pageTips);
						this.set("EntityInfo", entityInfo);
						this.set("DetailInfo", detailInfo);
						this.onDetailCollapsedChanged(false);
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var sandbox = this.sandbox;
					var messageTags = [sandbox.id];
					sandbox.subscribe("EntityInitialized", this.onEntityInitialized, this, messageTags);
					sandbox.subscribe("EntityColumnChanged", this.onEntityColumnChanged, this, messageTags);
				},

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#onDetailCollapsedChanged
				 * @overridden
				 */
				onDetailCollapsedChanged: function(isCollapsed) {
					this.callParent(arguments);
					if (!isCollapsed && !this.get("IsDataLoaded") && this.get("EntityInfo")) {
						var collection = this.get("Collection");
						this.loadEntityConnections(collection);
					}
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Detail",
					"values": {
						caption: {bindTo: "Resources.Strings.Caption"}
					}
				},
				{
					"operation": "insert",
					"name": "CommunicationsContainer",
					"parentName": "Detail",
					"propertyName": "items",
					"values": {
						generator: "ConfigurationItemGenerator.generateContainerList",
						idProperty: "Id",
						collection: "Collection",
						observableRowNumber: 10,
						onGetItemConfig: "getItemViewConfig"
					}
				},
				{
					"operation": "insert",
					"name": "AddButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						visible: {bindTo: "getToolsVisible"},
						itemType: BPMSoft.ViewItemType.BUTTON,
						caption: {bindTo: "Resources.Strings.AddButtonCaption"},
						controlConfig: {
							menu: {
								items: {bindTo: "ToolsMenuItems"}
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
