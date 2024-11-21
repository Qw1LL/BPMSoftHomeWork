define("AccountRelationshipDetailV2", ["AccountRelationshipDetailV2Resources", "MiniPageUtilities",
	"ConfigurationDiagramGenerator", "RelationshipDiagramViewModel", "RelationshipDiagram",
	"LookupQuickAddMixin", "RelationshipChartGenerator", "RelationshipChart",
	"css!AccountRelationshipDetailCss"
], function() {

	var relationshipMode = {
		Datagrid: "datagrid",
		Relationship: "relationship"
	};

	return {
		entitySchemaName: "VwAccountRelationship",
		mixins: {
			RelationshipDiagramViewModel: "BPMSoft.RelationshipDiagramViewModel",
			LookupQuickAddMixin: "BPMSoft.LookupQuickAddMixin",
			MiniPageUtilitiesMixin: "BPMSoft.MiniPageUtilities"
		},
		messages: {
			/**
			 * @message UpdateRelationshipDiagram
			 * ############# ######### ############.
			 */
			"UpdateRelationshipDiagram": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * ############# ##### ########### ############.
			 * @protected
			 */
			initMode: function() {
				var profile = this.getProfile();
				var mode = !this.Ext.isEmpty(profile.Mode) ? profile.Mode : this.setDefaultMode();
				if (mode) {
					this.changeDetailMode(mode);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#onLookupDataLoaded
			 * @overridden
			 */
			onLookupDataLoaded: function(config) {
				this.callParent(arguments);
				var isComplicatedFiltersExists = false;
				var cacheObject = {
					filters: new BPMSoft.Collection(),
					isComplicatedFiltersExists: isComplicatedFiltersExists
				};
				this.setValueToLookupInfoCache(config.columnName, "lookupFiltersInfo", cacheObject);
				var refSchemaName = this.getLookupEntitySchemaName({}, config.columnName);
				var preventSchemaNames = this.getPreventQuickAddSchemaNames();
				if (config.isLookupEdit && !Ext.isEmpty(config.filterValue) &&
						!isComplicatedFiltersExists && preventSchemaNames.indexOf(refSchemaName) === -1) {
					this.setValueToLookupInfoCache(config.columnName, "filterValue", config.filterValue);
					config.objects[BPMSoft.GUID_EMPTY] = this.getNewListItemConfig(config.filterValue);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onLookupChange
			 * @overridden
			 */
			onLookupChange: function(newValue, columnName) {
				this.callParent(arguments);
				this.mixins.LookupQuickAddMixin.onLookupChange.call(this, newValue, columnName);
				this.mixins.RelationshipDiagramViewModel.onLookupChange.call(this, newValue, columnName);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#getLookupQuery
			 * @overridden
			 */
			getLookupQuery: function(filterValue, columnName) {
				var esq = this.callParent(arguments);
				var lookupColumn = this.columns[columnName];
				var lookupListConfig = lookupColumn.lookupListConfig;
				if (!lookupListConfig) {
					return esq;
				}
				this.BPMSoft.each(lookupListConfig.columns, function(column) {
					if (!esq.columns.contains(column)) {
						esq.addColumn(column);
					}
				}, this);
				var filterGroup = this.getLookupQueryFilters(columnName);
				esq.filters.addItem(filterGroup);
				var columns = esq.columns;
				if (lookupListConfig.orders) {
					var orders = lookupListConfig.orders;
					this.BPMSoft.each(orders, function(order) {
						var orderColumnPath = order.columnPath;
						if (!columns.contains(orderColumnPath)) {
							esq.addColumn(orderColumnPath);
						}
						var sortedColumn = columns.get(orderColumnPath);
						var direction = order.direction;
						sortedColumn.orderDirection = direction ? direction : this.BPMSoft.OrderDirection.ASC;
						var position = order.position;
						sortedColumn.orderPosition = position ? position : 1;
						this.shiftColumnsOrderPosition(columns, sortedColumn);
					}, this);
				}
				return esq;
			},

			/**
			 * ######### #######, ####### ############# ## ########## ####.
			 * @protected
			 * @param {String} columnName ######## #######.
			 * @return {BPMSoft.FilterGroup} ########## ###### ########.
			 */
			getLookupQueryFilters: function(columnName) {
				var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
				var column = this.columns[columnName];
				var lookupListConfig = column.lookupListConfig;
				if (lookupListConfig) {
					var filterArray = lookupListConfig.filters;
					this.BPMSoft.each(filterArray, function(item) {
						var filter;
						if (this.Ext.isObject(item) && this.Ext.isFunction(item.method)) {
							filter = item.method.call(this, item.argument);
						}
						if (this.Ext.isFunction(item)) {
							filter = item.call(this);
						}
						if (this.Ext.isEmpty(filter)) {
							throw new this.BPMSoft.InvalidFormatException({
								message: this.Ext.String.format(
									this.get("Resources.Strings.ColumnFilterInvalidFormatException"), columnName)
							});
						}
						filterGroup.addItem(filter);
					}, this);
					if (lookupListConfig.filter) {
						var filterItem = lookupListConfig.filter.call(this);
						if (filterItem) {
							filterGroup.addItem(filterItem);
						}
					}
				}
				return filterGroup;
			},

			/**
			 * ######### ######## ######## ### ####### ##### ######### ######
			 * ### ######## ######## #### #### ## #### ######## #######.
			 * @protected
			 * @return {Array} ######### ######## ########.
			 */
			getForceAddSchemaNames: function() {
				return ["Account"];
			},

			/**
			* ########## ############# ###### ########
			* @protected
			* @return {String} ########## ############# ###### ########
			*/
			getCardModuleSandboxId: function() {
				return this.sandbox.id + "_CardModuleV2";
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#initData
			 * @overridden
			 */
			initData: function(callback, scope) {
				this.callParent([
					function() {
						this.mixins.RelationshipDiagramViewModel.init.call(this);
						callback.call(scope);
						this.initMode();
					},
					this
				]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("UpdateRelationshipDiagram", function() {
					var isNotCollapsed = !this.get("IsDetailCollapsed");
					var isRelationshipMode = this.get("Mode") === relationshipMode.Relationship;
					if (isNotCollapsed && isRelationshipMode) {
						this.loadRelationship();
					}
				}, this, [this.getCardModuleSandboxId()]);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#loadGridData
			 * @overridden
			 */
			loadGridData: function() {
				if (this.get("Mode") === relationshipMode.Datagrid) {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#updateDetail
			 * @overridden
			 */
			updateDetail: function() {
				this.callParent(arguments);
				if (!this.get("IsDetailCollapsed") && this.get("Mode") === relationshipMode.Relationship) {
					this.loadRelationship();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#onDetailCollapsedChanged
			 * @overridden
			 */
			onDetailCollapsedChanged: function(isCollapsed) {
				this.callParent(arguments);
				if (!isCollapsed && this.get("Mode") === relationshipMode.Relationship) {
					this.loadRelationship();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseDetailV2#getToolsVisible
			 * @overridden
			 */
			getToolsVisible: function() {
				var toolsVisible = this.callParent(arguments);
				var dataGridVisible = this.getDataGridVisible();
				return toolsVisible && dataGridVisible;
			},

			/**
			 * ########## ######## ########### ###### #######.
			 * @protected
			 * @return {Boolean} ######## ########### ###### #######.
			 */
			getModeButtonsVisible: function() {
				return !this.get("IsDetailCollapsed");
			},

			/**
			 * ########## ######## ########### ###### ############.
			 * @protected
			 * @return {Boolean} ######## ########### ###### ############.
			 */
			getRelationshipDataVisible: function() {
				return this.get("Mode") === relationshipMode.Relationship &&
					(!this.get("UseNewChart") || this.get("IsDiagramVisible"));
			},

			/**
			 * ########## ######## ########### ####### ######.
			 * @protected
			 * @return {Boolean} ######## ########### ####### ######.
			 */
			getDataGridVisible: function() {
				return (this.get("Mode") === relationshipMode.Datagrid);
			},

			/**
			 * ########## ######## ####### ###### ###### #########.
			 * @protected
			 * @return {Boolean} ######## ####### ###### ###### #########.
			 */
			getRelationshipButtonPressed: function() {
				return (this.get("Mode") === relationshipMode.Relationship);
			},

			/**
			 * ########## ######## ####### ###### ###### ######.
			 * @protected
			 * @return {Boolean} ######## ####### ###### ###### ######.
			 */
			getDataGridButtonPressed: function() {
				return (this.get("Mode") === relationshipMode.Datagrid);
			},

			/**
			 * ######### ####### ##### ########### # #######.
			 * @protected
			 */
			saveModeToProfile: function() {
				var profile = this.getProfile();
				var key = this.getProfileKey();
				if (profile && key) {
					profile.Mode = this.get("Mode");
					this.set(this.getProfileColumnName(), profile);
					this.BPMSoft.utils.saveUserProfile(key, profile, false);
				}
			},

			/**
			 * ######## ##### ######.
			 * @protected
			 * @param {String} mode ##### #####.
			 */
			changeDetailMode: function(mode) {
				if (mode === this.get("Mode")) {
					return;
				}
				var isDataGridMode = (mode === relationshipMode.Datagrid);
				this.set("Mode", mode);
				this.set("IsDiagramVisible", false);
				this.saveModeToProfile();
				this.deselectRows();
				if (isDataGridMode) {
					this.reloadGridData();
				} else if (!this.get("IsDetailCollapsed")) {
					this.loadRelationship();
				}
			},

			/**
			 * ############# ##### ########### ###### ############.
			 * @protected
			 */
			setRelationshipMode: function() {
				this.changeDetailMode(relationshipMode.Relationship);
			},

			/**
			 * ############# ##### #######.
			 * @protected
			 */
			setDataGridMode: function() {
				this.changeDetailMode(relationshipMode.Datagrid);
			},

			/**
			 * ############# ##### ## #########.
			 * @protected
			 */
			setDefaultMode: function() {
				this.setRelationshipMode();
			},

			/**
			 * ########## ######## #######.
			 * @protected
			 * @param {String} mode #####.
			 * @return {String} ######## #######.
			 */
			getDetailMarkerValue: function(mode) {
				var caption = this.get("Resources.Strings.Caption");
				return this.Ext.String.format("{0} {1}", caption, mode);
			},

			/**
			 * Returns the name of the schema object reference field.
			 * @protected
			 * @return {String} Name the schema object reference field.
			 */
			getLookupEntitySchemaName: function() {
				return "Account";
			},

			/**
			 * Returns a config for a lookup dialog to select new account to be added to the relationship chart.
			 * @protected
			 * @return {Object} Lookup dialog config object.
			 */
			getAccountToAddLookupConfig: function() {
				var filterGroup = this.BPMSoft.createFilterGroup();
				var notInChartFilter = this.getNotInAccountOnDiagramFilter();
				if (notInChartFilter) {
					filterGroup.addItem(notInChartFilter);
				}
				return {
					entitySchemaName: this.getLookupEntitySchemaName(),
					multiSelect: false,
					filters: filterGroup,
					columns: ["Parent"]
				};
			},

			/**
			 * Opens a lookup dialog to select new account to be added to the relationship chart and passes selected
			 * account to callback function.
			 * @protected
			 * @param {Function} callback Callback function that will be called with identifier of the selected account.
			 * @param {Object} scope Callback function execution context.
			 */
			selectAccountToAdd: function(callback, scope) {
				this.openLookup(this.getAccountToAddLookupConfig(), function(result) {
					var selectedRows = result.selectedRows;
					if (!selectedRows || selectedRows.getCount() !== 1) {
						return;
					}
					var firstItem = selectedRows.first();
					var selectedId = firstItem.Id;
					var parent = firstItem.Parent;
					this.Ext.callback(callback, scope, [selectedId, parent]);
				}, this);
			},

			/**
			 * Handles remove node chart event.
			 * @param {String} nodeId Node identifier.
			 */
			onNodeRemove: function(nodeId) {
				var confirmationMessage = this.getRemoveRelationshipMessage();
				var messageBoxButtons = this.BPMSoft.MessageBoxButtons;
				this.BPMSoft.showConfirmation(confirmationMessage, function(returnCode) {
					if (returnCode === messageBoxButtons.YES.returnCode) {
						this.updateRelationship(nodeId, null, this.loadRelationship);
					}
				}, [messageBoxButtons.YES, messageBoxButtons.NO], this);
			},

			/**
			 * Handles add parent account event of the chart.
			 * @param {String} nodeId Node identifier.
			 */
			onAddParentNode: function(nodeId) {
				this.selectAccountToAdd(function(newParentId) {
					this.updateRelationship(nodeId, newParentId, this.loadRelationship);
				}, this);
			},

			/**
			 * Updates parent account if needed by selected values.
			 * @param {String} nodeId Node identifier.
			 * @param {String} newChildId Child account identifier.
			 * @param {Object} newChildParent Child parent account object.
			 */
			updateParentAccountIfNeeded: function(nodeId, newChildId, newChildParent) {
				if (this.Ext.isEmpty(newChildParent)) {
					this.updateRelationship(newChildId, nodeId, this.loadRelationship);
				} else {
					var messageBoxButtons = this.BPMSoft.MessageBoxButtons;
					var confirmationMessage = this.get("Resources.Strings.ParentAccountExistsMessage");
					this.BPMSoft.showConfirmation(confirmationMessage, function(returnCode) {
						if (returnCode === messageBoxButtons.YES.returnCode) {
							this.updateRelationship(newChildId, nodeId, this.loadRelationship);
						}
					}, [messageBoxButtons.YES, messageBoxButtons.NO], this);
				}
			},

			/**
			 * Handles add child account event of the chart.
			 * @param {String} nodeId Node identifier.
			 */
			onAddChildNode: function(nodeId) {
				this.selectAccountToAdd(function(newChildId, parentAccount) {
					this.updateParentAccountIfNeeded(nodeId, newChildId, parentAccount);
				}, this);
			},

			/**
			 * Handles on node title mouse over.
			 * @param {String} id Node unique identifier.
			 */
			onNodeTitleMouseOver: function(id) {
				if (!Ext.isEmpty(id) && id !== this.$MasterRecordId) {
					this.openMiniPage({
						recordId: id,
						targetId: Ext.String.format("node-title-link-{0}", id),
						entitySchemaName: this.getLookupEntitySchemaName()
					});
				}
			},

			/**
			 * Handles on node title click.
			 * @param {String} id Node unique identifier.
			 */
			onNodeTitleClick: function(id) {
				if (!Ext.isEmpty(id) && id !== this.$MasterRecordId) {
					this.openAccountCardInChain(id);
					BPMSoft.MiniPageListener.close();
				}
			}

		},

		diff: /**SCHEMA_DIFF*/ [{
			"operation": "merge",
			"name": "Detail",
			"values": {
				"classes": {
					"wrapClass": ["account-relationship", "detail", "grid-detail"]
				},
				"markerValue": {
					"bindTo": "Mode",
					"bindConfig": {
						"converter": "getDetailMarkerValue"
					}
				}
			}
		}, {
			"operation": "merge",
			"name": "DataGrid",
			"values": {
				"visible": {
					"bindTo": "getDataGridVisible"
				}
			}
		}, {
			"operation": "insert",
			"name": "RelationshipDataContainer",
			"parentName": "Detail",
			"propertyName": "items",
			"values": {
				"id": "RelationshipDataContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"visible": {
					"bindTo": "getRelationshipDataVisible"
				},
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "RelationshipDiagram",
			"parentName": "RelationshipDataContainer",
			"propertyName": "items",
			"values": {
				"generator": "ConfigurationDiagramGenerator.generateDiagram",
				"className": window.ej ? "BPMSoft.RelationshipDiagram" : "BPMSoft.BaseDiagram",
				"items": "Nodes",
				"visible": {
					"bindTo": "UseNewChart",
					"bindConfig": {
						"converter": "invertBooleanValue"
					}
				},
				"afterrender": {
					"bindTo": "onAfterRender"
				}
			}
		}, {
			"operation": "insert",
			"name": "RelationshipChart",
			"parentName": "RelationshipDataContainer",
			"propertyName": "items",
			"values": {
				"generator": "RelationshipChartGenerator.generateChart",
				"className": "BPMSoft.RelationshipChart",
				"cssClass": "account-relationship-chart",
				"items": {
					"bindTo": "AccountsTree"
				},
				"masterNodeId": {
					"bindTo": "MasterRecordId"
				},
				"nodeTitleMouseOver": {
					"bindTo": "onNodeTitleMouseOver"
				},
				"nodeTitleClick": {
					"bindTo": "onNodeTitleClick"
				},
				"nodeRemove": {
					"bindTo": "onNodeRemove"
				},
				"addParentNode": {
					"bindTo": "onAddParentNode"
				},
				"addChildNode": {
					"bindTo": "onAddChildNode"
				},
				"visible": {
					"bindTo": "UseNewChart"
				},
				"buttonTooltips": {
					"bindTo": "getNodeButtonTooltips"
				}
			}
		}, {
			"operation": "insert",
			"name": "RelationshipModeButton",
			"parentName": "Detail",
			"propertyName": "tools",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.BUTTON,
				"hint": {"bindTo": "Resources.Strings.DiagramViewButtonHint"},
				"click": {
					"bindTo": "setRelationshipMode"
				},
				"visible": {
					"bindTo": "getModeButtonsVisible"
				},
				"pressed": {
					"bindTo": "getRelationshipButtonPressed"
				},
				"classes": {
					"wrapperClass": ["relationship-mode-button"],
					"pressedClass": ["mode-button-pressed"]
				},
				"controlConfig": {
					"imageConfig": {
						"bindTo": "Resources.Images.RelationshipViewIcon"
					}
				},
				"markerValue": relationshipMode.Relationship
			}
		}, {
			"operation": "insert",
			"name": "DataGridModeButton",
			"parentName": "Detail",
			"propertyName": "tools",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.BUTTON,
				"hint": {"bindTo": "Resources.Strings.ListViewButtonHint"},
				"click": {
					"bindTo": "setDataGridMode"
				},
				"visible": {
					"bindTo": "getModeButtonsVisible"
				},
				"pressed": {
					"bindTo": "getDataGridButtonPressed"
				},
				"classes": {
					"wrapperClass": ["datagrid-mode-button", "disable-left-margin"],
					"pressedClass": ["mode-button-pressed"]
				},
				"controlConfig": {
					"imageConfig": {
						"bindTo": "Resources.Images.DataGridViewIcon"
					}
				},
				"markerValue": relationshipMode.Datagrid
			}
		}] /**SCHEMA_DIFF*/
	};
});
