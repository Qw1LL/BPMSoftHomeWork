﻿define("DuplicatesDetailViewModelV2", ["ServiceHelper", "ModalBox", "DesktopPopupNotification",
		"DuplicatesDetailViewModelV2Resources", "SectionMergeHelperResources",
		"DuplicatesMergeHelper", "GridUtilitiesV2", "ContextCallUtilities",
		"DuplicatesMergeModuleV2"],
	function(ServiceHelper, ModalBox, DesktopPopupNotification, resources, mergeHelperResources) {
		Ext.define("BPMSoft.configuration.DuplicatesDetailViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.DuplicatesDetailViewModel",

			mixins: {
				GridUtilities: "BPMSoft.GridUtilities",
				ContextCallUtilities: "BPMSoft.ContextCallUtilities",
				MergeHelper: "BPMSoft.DuplicatesMergeHelper"
			},

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			messages: {
				/**
				 * @message MergeEntityDuplicatesExecuted
				 * Message merge entities operation executed.
				 */
				"MergeEntityDuplicatesExecuted": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message NotDuplicatesOperationExecuted
				 * Message on not duplicates operation executed.
				 */
				"NotDuplicatesOperationExecuted": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			columns: {
				/**
				 * The text of the header caption.
				 */
				"Caption": {
					columnPath: "Caption",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: ""
				},
				/**
				 * identifier of the group of search results.
				 */
				"GroupId": {
					columnPath: "GroupId",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: 0
				},
				/**
				 * The collection of the grid rows.
				 */
				"GridData": {
					columnPath: "GridData",
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					isCollection: true,
					value: Ext.create("BPMSoft.BaseViewModelCollection"),
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				/**
				 * The collection of the selected grid rows.
				 */
				"SelectedRows": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					isCollection: true,
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: []
				},
				/**
				 * Number of currently selected rows.
				 */
				"SelectedRowsCount": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: 0
				},
				/**
				 * The caption of the SelectAll button.
				 */
				"SelectAllCaption": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: resources.localizableStrings.SelectAllCaption
				},
				/**
				 * Indicates state of the Enabled parameter of Merge button.
				 */
				"IsMergeButtonEnabled": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: false
				},
				/**
				 * The caption of the Merge button.
				 */
				"MergeButtonCaption": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: Ext.String.format(resources.localizableStrings.MergeButtonCaptionTemplate, "")
				}
			},

			/**
			 * Decoupling object of the parameter values for columns of the viewmodel.
			 * @type {Object}
			 */
			propertiesTranslator: {
				"Caption": "caption",
				"GroupId": "groupId",
				"EntitySchemaName": "entitySchemaName"
			},

			/**
			 * On render handler.
			 */
			onRender: Ext.emptyFn,

			/**
			 * Returns grid row collection.
			 * @return {Object}
			 */
			getGridData: function() {
				var sandbox = this.sandbox;
				var gridData = sandbox.publish("GetGridData", sandbox.id, [sandbox.id]) || {};
				this.set("GridData", gridData);
				return gridData;
			},

			/**
			 * Initialize model properties.
			 */
			initProperties: function() {
				var parameters = this.values;
				BPMSoft.each(this.propertiesTranslator, function(configName, viewModelName) {
					var value = parameters[configName];
					if (configName === "entitySchemaName") {
						this.entitySchemaName = value;
					} else if (value) {
						this.set(viewModelName, value);
					}
				}, this);
			},

			/**
			 * Select all/Clear all hyperlink click handler.
			 */
			onSelectAllClick: function() {
				var rows = this.get("GridData");
				var keys = rows.getKeys();
				var selectedRows = this.get("SelectedRows");
				if (selectedRows.length === keys.length) {
					keys = [];
				}
				this.set("SelectedRows", keys);
			},

			/**
			 * Merge button click handler.
			 */
			onMergeButtonClick: function() {
				this.mergeEntityDuplicatesAsync();
				this.sandbox.publish("MergeEntityDuplicatesExecuted", this.get("SelectedRows"));
			},

			/**
			 * @private
			 */
			_isBulkESDeduplicationEnabled: function (){
				return BPMSoft.Features.getIsEnabled("BulkESDeduplication");
			},

			/**
			 * @private
			 */
			_saveUniqueRecords: function(callback) {
				var selectedRows = this.get("SelectedRows");
				var config = {
					"schemaName": this.entitySchemaName,
					"uniqueRecordIds": selectedRows
				};
				ServiceHelper.callService("BulkDeduplicationService", "AddToUniqueList", callback, config, this);
			},

			/**
			 * Not doubles button click handler.
			 */
			onNotDoublesButtonClick: function() {
				if (this._isBulkESDeduplicationEnabled()) {
					this._saveUniqueRecords(this.saveUniqueRecordsHandler);
					this._setIsUniqueGridDataRows();
					this._hideUniqueGroupsIfNeeded();
				} else {
					this.addToIgnoreList();
					this.hide();
				}
			},
			
			/**
			 * @private
			 */
			_setIsUniqueGridDataRows: function() {
				var selectedRows = this.get("SelectedRows");
				var gridData = this.get("GridData");
				BPMSoft.each(selectedRows, function(key) {
					var modelItem = gridData.get(key);
					if (modelItem) {
						modelItem.$IsUnique = true;
					}
				}, this);
			},
			
			/**
			 * @private
			 */
			_hideUniqueGroupsIfNeeded: function() {
				if (this.isAllRowsUnique()) {
					this.hide();
				}
			},

			/**
			 * Handles save not duplicates records response.
			 */
			saveUniqueRecordsHandler: function() {
				this.sandbox.publish("NotDuplicatesOperationExecuted");
			},
			
			/**
			 * Checks if all rows in grid data marks as unique rows.
			 * @protected
			 * @returns {Boolean} True if all rows in grid data marks as unique rows.
			 */
			isAllRowsUnique: function() {
				const gridData = this.get("GridData");
				const uniqueItems = gridData.filterByFn(function(item) {
					return item && item.$IsUnique;
				}, this);
				const isAllRowsIsUnique = gridData.getCount() === uniqueItems.getCount();
				return isAllRowsIsUnique;
			},

			/**
			 * Moves records group to ignore list.
			 */
			addToIgnoreList: function() {
				var gridData = this.get("GridData");
				var config = {
					"schemaName": this.entitySchemaName,
					"deduplicateRecordIds": gridData.getKeys()
				};
				ServiceHelper.callService("DeduplicationService", "AddToIgnoreList", Ext.emptyFn, config, this);
			},

			/**
			 * Returns identifier of the merge module.
			 * @returns {String} Module identifier.
			 */
			getMergeModuleId: function() {
				return this.sandbox.id + "DuplicatesMergeModuleV2";
			},

			/**
			 * Opens duplicates merge modal box.
			 */
			openDuplicatesMergePage: function(conflicts) {
				var modalBoxConfig = {
					heightPixels: 420,
					widthPixels: 750
				};
				var mergeModuleParameters = this.getMergeModuleConfig(conflicts);
				mergeModuleParameters.schemaName = this.entitySchemaName;
				var moduleId = this.getMergeModuleId();
				var renderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, renderTo);
				}.bind(this));
				this.sandbox.loadModule("DuplicatesMergeModuleV2", {
					id: moduleId,
					renderTo: renderTo.id,
					parameters: {
						config: mergeModuleParameters
					}
				});
			},

			/**
			 * Merge selected entities.
			 * @param {Object} mergeConfig Config for merge operation.
			 */
			mergeEntityDuplicatesAsync: function(mergeConfig) {
				var selectedRows = this.get("SelectedRows");
				var fakeGroupId = 2147483647;
				var groupId = BPMSoft.Features.getIsEnabled("BulkESDeduplication")
					? fakeGroupId
					: this.get("GroupId");
				var selectedRowsLength =  selectedRows.length;
				if (selectedRowsLength > 1 && groupId > 0) {
					var config = {
						"schemaName": this.entitySchemaName,
						"groupId": groupId,
						"deduplicateRecordIds": selectedRows,
						"mergeConfig": JSON.stringify(mergeConfig)
					};
					ServiceHelper.callService("DeduplicationService", "MergeEntityDuplicatesAsync", function(response) {
						if (response) {
							var responseResult = response.MergeEntityDuplicatesAsyncResult;
							if (Ext.isEmpty(responseResult) === false) {
								if (responseResult.success === true) {
									this.showMergePopup(selectedRowsLength);
									this.hide();
								} else {
									this.openDuplicatesMergePage(responseResult.conflicts);
								}
							}
						}
					}, config, this);
				} else {
					this.showInformationMessage(resources.localizableStrings.SelectMoreThanOneRowErrorMessage);
				}
			},

			/**
			 * Show popup message with the merge info.
			 * @param {Number} mergeRecordsCount Count of records to merge.
			 */
			showMergePopup: function(mergeRecordsCount) {
				var config = this.getMergePopupConfig(mergeRecordsCount);
				DesktopPopupNotification.showNotification(config);
			},

			/**
			 * Returns temaple for the message body.
			 * @returns {String} Template for the message body.
			 */
			getMergePopupBodyTemplate: function() {
				var entitySchemaName = this.entitySchemaName;
				var localizableStrings = resources.localizableStrings;
				return localizableStrings["Merge" + entitySchemaName + "NotificationBodyTemplate"]
					|| mergeHelperResources.localizableStrings.DefaultMergeNotificationBodyTemplate;
			},

			/**
			 * Returns Url for the message icon.
			 * @returns {String} Url.
			 */
			getMergePopupIconUrl: function() {
				var entitySchemaName = this.entitySchemaName;
				var module = BPMSoft.configuration.ModuleStructure[entitySchemaName];
				return BPMSoft.ImageUrlBuilder.getUrl({
					source: BPMSoft.ImageSources.SYS_IMAGE,
					params: {
						primaryColumnValue: module.logoId
					}
				});
			},

			/**
			 * Returns the config of the popup notification.
			 * @param {Number} mergeRecordsCount Count of records to merge.
			 * @returns {Object} Config of the popup notification.
			 */
			getMergePopupConfig: function(mergeRecordsCount) {
				var bodyTemplate = this.getMergePopupBodyTemplate();
				return {
					id: BPMSoft.generateGUID(),
					title: resources.localizableStrings.MergeNotificationTitleTemplate,
					body: Ext.String.format(bodyTemplate, mergeRecordsCount),
					icon: this.getMergePopupIconUrl(),
					onShow: this.onShowPopup,
					ignorePageVisibility: true
				};
			},

			/**
			 * Handling popup notification after display.
			 * @param {Event} event Event show.
			 */
			onShowPopup: function(event) {
				setTimeout(function() {
					DesktopPopupNotification.closeNotification(event.target);
				}, DesktopPopupNotification.defaultDisplayTimeout);
			},

			/**
			 * Show information message.
			 * @param {String} message Message text.
			 */
			showInformationMessage: function(message) {
				var messageConfig = {
					caption: message,
					buttons: ["ok"],
					defaultButton: 0,
					style: BPMSoft.MessageBoxStyles.ORANGE
				};
				BPMSoft.utils.showMessage(messageConfig);
			},

			/**
			 * Returns true when all the rows in the grid are selected.
			 * @returns {Boolean} result.
			 */
			isAllItemsSelected: function() {
				var selectedRowsCount = this.get("SelectedRowsCount");
				var rows = this.get("GridData");
				return rows.getCount() <= selectedRowsCount;
			},

			/**
			 * Initialize Select all/Clear all hyperlink text.
			 */
			initSelectAllCaption: function() {
				var allSelected = this.isAllItemsSelected();
				var selectAllCaption = allSelected
					? resources.localizableStrings.ClearAllCaption
					: resources.localizableStrings.SelectAllCaption;
				this.set("SelectAllCaption", selectAllCaption);
			},

			/**
			 * Initialize properties of the Merge button.
			 */
			initializeMergeButton: function() {
				var selectedRowsCount = this.get("SelectedRowsCount");
				this.set("IsMergeButtonEnabled", (selectedRowsCount > 1));
				var template = resources.localizableStrings.MergeButtonCaptionTemplate;
				var templateParameter = "";
				if (selectedRowsCount > 0) {
					templateParameter = " (" + selectedRowsCount + ")";
				}
				var caption = Ext.String.format(template, templateParameter);
				this.set("MergeButtonCaption", caption);
			},

			/**
			 * Initialize SelectedRowsCount property.
			 * @param {Boolean} newItemSelected Is new item added to collection of selected rows.
			 */
			initSelectedRowsCount: function(newItemSelected) {
				var selectedRows = this.get("SelectedRows");
				var selectedRowsCount = selectedRows.length;
				if (newItemSelected) {
					selectedRowsCount++;
				} else {
					selectedRowsCount--;
				}
				if (selectedRowsCount < 0) {
					selectedRowsCount = 0;
				}
				var rows = this.get("GridData");
				var totalRowsCount = rows.getCount();
				if (totalRowsCount < selectedRowsCount) {
					selectedRowsCount = totalRowsCount;
				}
				this.set("SelectedRowsCount", selectedRowsCount);
			},

			/**
			 * Row selection changed handler.
			 * @param {Boolean} rowSelected Is new item added to collection of selected rows.
			 */
			onRowSelectionChange: function(rowSelected) {
				this.initSelectedRowsCount(rowSelected);
				this.initSelectAllCaption();
				this.initializeMergeButton();
			},

			/**
			 * Row selection handler.
			 */
			onSelectRow: function() {
				this.onRowSelectionChange(true);
			},

			/**
			 * Row deselect handler.
			 */
			onUnSelectRow: function() {
				this.onRowSelectionChange(false);
			},

			/**
			 * Row link click handler.
			 * @param {String} rowId Row identifier.
			 * @param {String} columnName Name of column.
			 * @returns {Boolean} Follow a link executed.
			 */
			linkClicked: function(rowId, columnName) {
				var handled = this.phoneLinkClicked(rowId, columnName);
				return !handled;
			},

			/**
			 * Subscribe for messages.
			 */
			subscribeMessages: function() {
				var moduleId = this.getMergeModuleId();
				this.sandbox.registerMessages(this.messages);
				this.sandbox.subscribe("Merge", function(config) {
					this.mergeEntityDuplicatesAsync(config);
				}, this, [moduleId]);
				
			},

			/**
			 * Initialize model.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			init: function(callback, scope) {
				this.initProperties();
				this.subscribeMessages();
				this.mixins.GridUtilities.init.call(this);
				callback.call(scope || this);
			},

			/**
			 * Hide module from DOM.
			 */
			hide: function() {
				this.sandbox.publish("HideDetail", null, [this.sandbox.id]);
				var renderTo = this.renderTo;
				var compositeElement = Ext.select("#" + renderTo);
				var switchOffConfig = {
					easing: "easeOut",
					duration: 600,
					remove: true,
					useDisplay: true
				};
				compositeElement.switchOff(switchOffConfig);
			}
		});
	});
