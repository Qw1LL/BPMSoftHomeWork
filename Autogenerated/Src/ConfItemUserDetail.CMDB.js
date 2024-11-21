define("ConfItemUserDetail", ["ServiceDeskConstants"], function(ServiceDeskConstants) {
	return {
		entitySchemaName: "ConfItemUser",
		attributes: {
			MasterColumnName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			LookupTypeColumnName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},
		messages: {},
		methods: {
			/**
			 * ########## #######, ####### ###### ########## ########.
			 * @protected
			 * @override
			 * @return {Object} ########## ###### ########-############ #######
			 */
			getGridDataColumns: function() {
				return {
					"Account": {
						path: "Account"
					}
				};
			},

			/**
			 * �?############# ######### ######## ######.
			 * @protected
			 * @override
			 */
			init: function() {
				this.set("MasterColumnName", "ConfItem");
				this.set("LookupTypeColumnName", "Type");
				this.callParent(arguments);
			},

			/**
			 * ########## ######## ######## ###### #######.
			 * @private
			 * @returns {*|Object} ########## ######## ###### ####### ### null #### ## #########/## ####### ## ####
			 */
			getSelectedRecord: function() {
				var selectedItems = this.getSelectedItems();
				if (selectedItems && (selectedItems.length === 1)) {
					return this.getGridData().get(selectedItems[0]);
				}
			},

			isMasterRecordNew: function() {
				var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
				var isNew = (cardState.state === this.BPMSoft.ConfigurationEnums.CardOperation.ADD ||
				cardState.state === this.BPMSoft.ConfigurationEnums.CardOperation.COPY);
				return isNew;
			},

			/**
			 * ######### ############ ###### #### ### ##### #### #############.
			 * @private
			 */
			saveMasterRecord: function() {
				var args = {
					isSilent: true,
					messageTags: [this.sandbox.id]
				};
				this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
			},

			/**
			 * ########## ####### ## ###### ########## ########.
			 * ######### ###### #########.
			 * @protected
			 */
			addContact: function() {
				var addRecordConfig = {
					typeColumnValue: ServiceDeskConstants.ServiceObjectType.Contact,
					lookupSchemaName: "Contact",
					valueColumnName: "Contact"
				};
				this.addRecordLookup(addRecordConfig, this.selectContactCallback, this);
			},

			/**
			 * ######### ###### ######### ## ####### ########### ### ##########.
			 * ######### ########## ######### # ##.
			 * @protected
			 * @param {Object} config ############ ######### #######
			 */
			selectContactCallback: function(config) {
				config.getInsertQuery = this.getContactInsertQuery;
				this.selectCallback(config);
			},

			/**
			 * ########## ###### ## ########## ## #########.
			 * @param {Object} item ######### #######
			 * @protected
			 * @returns {BPMSoft.InsertQuery} ###### ## ########## ##
			 */
			getContactInsertQuery: function(item) {
				var typeId = ServiceDeskConstants.ServiceObjectType.Contact;
				var valueColumnName = "Contact";
				return this.getInsertQuery(valueColumnName, item, typeId);
			},

			/**
			 * ########## ####### ## ###### ########## ###########.
			 * ######### ###### ############.
			 * @protected
			 */
			addAccount: function() {
				var addRecordConfig = {
					typeColumnValue: ServiceDeskConstants.ServiceObjectType.Account,
					lookupSchemaName: "Account",
					valueColumnName: "Account"
				};
				this.addRecordLookup(addRecordConfig, this.selectAccountCallback, this);
			},

			/**
			 * ######### ###### ############ ## ####### ########### ### ##########.
			 * ######### ########## ############.
			 * @protected
			 * @param {Object} args ############ ######### #######
			 */
			selectAccountCallback: function(args) {
				args.getInsertQuery = this.getAccountInsertQuery;
				args.scope = this;
				this.selectCallback(args);
			},

			/**
			 * ########## ###### ## ########## ############.
			 * @protected
			 * @param {Object} item ######### ##########
			 * @returns {BPMSoft.InsertQuery} ###### ## ########## ##
			 */
			getAccountInsertQuery: function(item) {
				var typeId = ServiceDeskConstants.ServiceObjectType.Account;
				var valueColumnName = "Account";
				return this.getInsertQuery(valueColumnName, item, typeId);
			},

			/**
			 * ########## ####### ## ###### ######## #############.
			 * ######### ###### ############# ########## ###########.
			 * @protected
			 */
			createDepartments: function() {
				var addRecordConfig = {
					typeColumnValue: ServiceDeskConstants.ServiceObjectType.Department,
					lookupSchemaName: "Department",
					valueColumnName: "Department",
					isLookupMultiSelect: true
				};
				addRecordConfig.additionalFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Account", this.getSelectedRecord().get("Account").value);
				this.addRecordLookup(addRecordConfig, this.selectDepartmentCallback, this);
			},

			/**
			 * ######### ###### ############# ## ####### ########### ### ##########.
			 * ######### ########## ############# # ##.
			 * @protected
			 * @param {Object} config ############ ######### #######
			 */
			selectDepartmentCallback: function(config) {
				config.getInsertQuery = this.getDepartmentInsertQuery;
				config.onRecordInsert = this.onDepartmentsInsert;
				this.selectCallback(config);
			},

			/**
			 * ########## ###### ## ########## #############.
			 * @protected
			 * @param {Object} item ######### ############
			 * @returns {BPMSoft.InsertQuery} ###### ## ########## ##
			 */
			getDepartmentInsertQuery: function(item) {
				var typeId = ServiceDeskConstants.ServiceObjectType.Department;
				var valueColumnName = "Department";
				var insertQuery = this.getInsertQuery(valueColumnName, item, typeId);
				var selectedAccountId = this.getSelectedRecord().get("Account").value;
				insertQuery.setParameterValue("Account", selectedAccountId, this.BPMSoft.DataValueType.GUID);
				return insertQuery;
			},

			/**
			 * ########## ########## #############.
			 * ####### ######## ###### ## ########### # ######### ######.
			 * @protected
			 * @param {Object} response ############ ###### ##### ########## #######
			 */
			onDepartmentsInsert: function(response) {
				var departmentResponse = this.BPMSoft.deepClone(response);
				this.showBodyMask();
				this.callService({
					serviceName: "GridUtilitiesService",
					methodName: "DeleteRecords",
					data: {
						primaryColumnValues: this.getSelectedItems(),
						rootSchema: this.entitySchema.name
					}
				}, function(responseObject) {
					this.hideBodyMask();
					var result = this.Ext.decode(responseObject.DeleteRecordsResult);
					var success = result.Success;
					var deletedItems = result.DeletedItems;
					this.removeGridRecords(deletedItems);
					if (!success) {
						this.showDeleteExceptionMessage(result);
					}
					this.onRecordInsert(departmentResponse);
				}, this);
			},

			/**
			 * ########## ####### ########### ###### #### ######## #############.
			 * ######## #### ####### ###### ########### ### ######## ############.
			 * @protected
			 * @returns {boolean}
			 */
			getCreateDepartmentsMenuEnabled: function() {
				var selectedRecord = this.getSelectedRecord();
				return selectedRecord && selectedRecord.get("Account") &&
						!selectedRecord.get("Department");
			},

			/**
			 * ######### ######## ###### ## ########### ### ########## #######.
			 * @protected
			 * @param {Object} config ############ ########## ######
			 * @param {Function} callback ####### ######### ######
			 * @param {Object} scope ######## ####### ######### ######
			 */
			addRecordLookup: function(config, callback, scope) {
				function addRecordLookupInner() {
					config.valueColumnName = config.valueColumnName || "Id";
					config.isLookupMultiSelect = true;
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn(config.valueColumnName);
					this.addRecordLookupFilters(esq, config);
					esq.getEntityCollection(function(result) {
						this.onGetExistsRecords(result, config, callback, scope);
					}, this);
				}
				if (this.isMasterRecordNew()) {
					this.set("onSavedMethod", addRecordLookupInner);
					this.saveMasterRecord();
					return;
				} else {
					addRecordLookupInner.call(this);
				}
			},

			/**
			 * ########## ####### ########## ######## #######.
			 * #### ########## ####### ######## ########## ###### ## ######, ## ########### ########
			 * ########## ###### ## ###### (#### ##### ## ###########).
			 * @protected
			 * @override
			 */
			onCardSaved: function() {
				var onSavedMethod = this.get("onSavedMethod");
				if (onSavedMethod) {
					onSavedMethod.call(this);
				}
			},

			/**
			 * ####### - ########## ######### ### ############ ## ###### #######.
			 * ######### ######## ###### ## ########### #########, ####### ### ## ######### ## ######.
			 * @protected
			 * @param {Object} result ######### ####### ############ #######
			 * @param {Object} config ############ ########## ######
			 * @param {Function} callback ####### ######### ######. ########### ### ###### ####### # #######
			 * @param {Object} scope ######## ####### ######### ######
			 */
			onGetExistsRecords: function(result, config, callback, scope) {
				var lookupSchemaName = config.lookupSchemaName;
				var isMultiSelect = config.isLookupMultiSelect;
				var valueColumnName = config.valueColumnName;

				var existsItems = [];
				if (result.success) {
					result.collection.each(function(item) {
						var columnValue = item.get(valueColumnName);
						existsItems.push(Ext.isObject(columnValue) ? columnValue.value : columnValue);
					});
				}
				var lookupConfig = {
					entitySchemaName: lookupSchemaName,
					multiSelect: isMultiSelect
				};
				if (existsItems.length > 0) {
					var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id", existsItems);
					existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
					existsFilter.Name = "existsFilter";
					lookupConfig.filters = existsFilter;
				}
				this.openLookup(lookupConfig, callback, scope);
			},

			/**
			 * ######### ####### ### ####### ###### ## ########### ### ########## ##### ######.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq �?########## ######
			 * @param {Object} config ############ ########## ######
			 */
			addRecordLookupFilters: function(esq, config) {
				var typeColumnValue = config.typeColumnValue;
				var additionalFilter = config.additionalFilter;
				var masterColumnName = this.get("MasterColumnName");
				var masterRecordId = this.get("MasterRecordId");
				var typeColumnName = this.get("LookupTypeColumnName");
				esq.filters.add("masterRecordFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, masterColumnName, masterRecordId));
				if (typeColumnValue && typeColumnName) {
					esq.filters.add("typeFilter", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, typeColumnName, typeColumnValue));
				}
				if (additionalFilter) {
					esq.filters.add("additionalFilter", additionalFilter);
				}
			},

			/**
			 * ######## ########## ######### ####### ######### BatchQuery.
			 * @protected
			 * @param {Object} config ############ ######### #######
			 */
			selectCallback: function(config) {
				var getInsertQuery = config.getInsertQuery;
				var onRecordInsert = config.onRecordInsert || this.onRecordInsert;
				var bq = this.Ext.create("BPMSoft.BatchQuery");
				this.selectedRows = config.selectedRows.getItems();
				this.selectedItems = [];
				this.selectedRows.forEach(function(item) {
					bq.add(getInsertQuery.call(this, item));
					this.selectedItems.push(item.value);
				}, this);
				if (bq.queries.length) {
					this.showBodyMask.call(this);
					bq.execute(onRecordInsert, this);
				}
			},

			/**
			 * ########## ###### ## ########## ########.
			 * @protected
			 * @param {String} valueColumnName ######## #######, # ####### ############# ######### ########
			 * @param {Object} valueItem ######### ########
			 * @param {String} typeId ######## ####### ####
			 * @returns {BPMSoft.InsertQuery} ###### ## ########## ########
			 */
			getInsertQuery: function(valueColumnName, valueItem, typeId) {
				var typeColumnName = this.get("LookupTypeColumnName");
				var masterRecordId = this.get("MasterRecordId");
				var masterColumnName = this.get("MasterColumnName");
				var insert = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: this.entitySchemaName
				});
				insert.setParameterValue(masterColumnName, masterRecordId, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue(valueColumnName, valueItem.value, this.BPMSoft.DataValueType.GUID);
				if (typeColumnName && typeId) {
					insert.setParameterValue(typeColumnName, typeId, this.BPMSoft.DataValueType.GUID);
				}
				return insert;
			},

			/**
			 ** ######### ####### "########## ############" # ######### ########### ###### ############## ######.
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
			 * @overridden
			 */
			addRecordOperationsMenuItems: function(toolsButtonMenu) {
				this.callParent(arguments);
				toolsButtonMenu.addItem(this.getButtonMenuSeparator());
				toolsButtonMenu.addItem(this.getButtonMenuItem({
					"Caption": {
						"bindTo": "Resources.Strings.CreateDepartmentsMenuCaption"
					},
					"Click": {
						"bindTo": "createDepartments"
					},
					"Enabled": {
						"bindTo": "getCreateDepartmentsMenuEnabled"
					}
				}));
			},
			/**
			 * ######### ###### ##### ########## ####### ## ######.
			 * @protected
			 * @param {Object} response ######## ##### # ########### ########## #######
			 */
			onRecordInsert: function(response) {
				this.hideBodyMask.call(this);
				this.beforeLoadGridData();
				var insertedIds = [];
				response.queryResults.forEach(function(item) {
					insertedIds.push(item.id);
				});
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName
				});
				this.initQueryColumns(esq);
				esq.filters.add("idFilter", BPMSoft.createColumnInFilterWithParameters("Id", insertedIds));
				esq.getEntityCollection(function(response) {
					this.afterLoadGridData();
					if (response.success) {
						var responseCollection = response.collection;
						this.prepareResponseCollection(responseCollection);
						this.getGridData().loadAll(responseCollection);
					}
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
			 * @overridden
			 */
			getFilterDefaultColumnName: function() {
				return "Contact";
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: this.BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: this.BPMSoft.emptyFn
		},
		diff: [
			{
				"operation": "merge",
				"name": "AddRecordButton",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "AddTypedRecordButton",
				"parentName": "Detail",
				"propertyName": "tools",
				"index": 1,
				"values": {
					"visible": {
						"bindTo": "getToolsVisible"
					},
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"menu": []
				}
			},
			{
				"operation": "insert",
				"name": "AddContactMenu",
				"parentName": "AddTypedRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AddContactMenuCaption"
					},
					"click": {
						"bindTo": "addContact"
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddAccountMenu",
				"parentName": "AddTypedRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AddAccountMenuCaption"
					},
					"click": {
						"bindTo": "addAccount"
					}
				}
			},
			{
				"operation": "merge",
				"name": "EditRecordMenu",
				"values": {
					"visible": false
				}
			},
			{
				"operation": "merge",
				"name": "CopyRecordMenu",
				"values": {
					"visible": false
				}
			}
		]
	};
});
