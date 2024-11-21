define("EntityColumnLookupPage", ["EntityColumnLookupPageResources", "ModalBox", "GridUtilitiesV2",
		"css!EntityColumnLookupPageCSS"], function(resources, ModalBox) {
	return {
		mixins: {
			GridUtilities: "BPMSoft.GridUtilities"
		},
		attributes: {
			/**
			 * Grid data.
			 */
			"GridData": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Selected rows in grid.
			 */
			"SelectedRows": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Default data collection.
			 */
			"DataCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Filtered data collection.
			 */
			"FilteredCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Number of currently selected rows.
			 */
			"SelectedRowsCount": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * search text virtual column
			 */
			"SearchInput": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Is grid empty tag.
			 */
			"IsGridEmpty": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Is multi select row in grid.
			 */
			"IsMultiSelect": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Active row ID.
			 */
			"ActiveRow": {
				dataValueType: BPMSoft.DataValueType.GUID
			}
		},
		messages: {
			/**
			 * @message SetParametersInfo
			 * Specifies parameter values.
			 */
			"SetColumnsLookupInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {
			/**
			 * Initialization of grid collection.
			 * @private
			 */
			_initGridData: function() {
				this.set("GridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
			},

			/**
			 * Gets grid data.
			 * @private
			 * @return {BPMSoft.BaseViewModelCollection} Returns view models.
			 */
			_getGridData: function() {
				return this.get("GridData");
			},

			/**
			 * Gets grid collection.
			 * @private
			 * @param {Function} callback Callback function.
			 */
			_getGridCollection: function(callback) {
				const collection = this.get("FilteredCollection");
				if (!this.get("DataCollection")) {
					this.set("DataCollection", collection);
				}
				if (!this.get("SelectedRows")) {
					const selectedRows = [];
					this.get("DataCollection").each(function(item) {
						if (item.selected) {
							selectedRows.push(item.id);
						}
					}, this);
					this.set("SelectedRows", selectedRows);
				}
				callback.call(this, collection);
			},

			/**
			 * Loads grid collection.
			 * @private
			 * @param {BPMSoft.Collection} dataCollection Data collection.
			 */
			_loadGridCollection: function(dataCollection) {
				const collection = this._getGridData();
				collection.clear();
				const gridRowCollection = this._getGridRowCollection(dataCollection);
				collection.loadAll(gridRowCollection);
			},

			/**
			 * Returns grid row view model item config.
			 * @protected
			 * @param {Object} dataItem Row values.
			 * @return {Object} Mapped config for grid row columns.
			 */
			getRowViewModelItemConfig: function(dataItem) {
				return {
					Id: dataItem.id,
					Icon: dataItem.icon,
					Caption: dataItem.caption
				};
			},

			/**
			 * Create grid row view model item.
			 * @protected
			 * @param {Object} dataItem Row values.
			 * @return {BPMSoft.BaseViewModel} Row view model instance.
			 */
			createRowViewModelItem: function(dataItem) {
				const gridRowViewModelName = this.getGridRowViewModelClassName();
				return this.Ext.create(gridRowViewModelName, {
					rowConfig: this.getColumnsConfig(),
					values: this.getRowViewModelItemConfig(dataItem)
				});
			},

			/**
			 * Gets grid row collection.
			 * @private
			 * @param {BPMSoft.Collection} dataCollection Data collection.
			 * @return {Object} Row collection.
			 */
			_getGridRowCollection: function(dataCollection) {
				const collection = {};
				dataCollection.each(function(dataItem) {
					const viewModel = this.createRowViewModelItem(dataItem);
					collection[dataItem.id] = viewModel;
				}, this);
				return collection;
			},

			/**
			 * Initialize SelectedRowsCount property.
			 * @private
			 */
			_initSelectedRowsCount: function() {
				const selectedRows = this.get("SelectedRows");
				const selectedRowsCount = selectedRows ? selectedRows.length : 0;
				this.set("SelectedRowsCount", selectedRowsCount);
			},

			/**
			 * Returns custom lookup message name.
			 * @protected
			 * @return {String} Get lookup message name to publish.
			 */
			getLookupMessage: function() {
				return "SetColumnsLookupInfo";
			},

			/**
			 * Returns grid columns config.
			 * @protected
			 * @return {Object} Columns config.
			 */
			getColumnsConfig: function() {
				return {
					"Id": {
						"columnPath": "Id",
						"dataValueType": BPMSoft.DataValueType.GUID,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"Icon": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"Caption": {
						"columnPath": "Caption",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				};
			},

			/**
			 * @inheritdoc BasePageV2#init
			 * @protected
			 * @override
			 */
			init: function(callback) {
				this.callParent([
					function() {
						this._initGridData();
						this.initGridRowViewModel(function() {
							this._getGridCollection(function(collection) {
								this._loadGridCollection(collection);
								this._initSelectedRowsCount();
								this.subscribeOnColumnChange("SelectedRows", this._initSelectedRowsCount, this);
								callback.call(this);
							});
						}, this);
					}, this
				]);
			},

			/**
			 * Cancels selection and closes window.
			 */
			close: function() {
				ModalBox.close();
			},

			/**
			 * Handles a click on the "Save" button.
			 */
			onSaveClick: function() {
				const isMultiSelect = this.get("IsMultiSelect");
				let selectedRows;
				if (isMultiSelect) {
					selectedRows = this.get("SelectedRows");
				} else {
					const activeRow = this.get("ActiveRow");
					selectedRows = activeRow ? [activeRow] : [];
				}
				const lookupInfo = {
					"selectedRows": selectedRows
				};
				this.sandbox.publish(this.getLookupMessage(), lookupInfo, [this.sandbox.id]);
			},

			/**
			 * Handles a click on the "Search" button.
			 */
			onSearchButtonClick: function() {
				this.initGridRowViewModel(function() {
					const collection = this.get("DataCollection");
					const searchFilter = this.get("SearchInput").toLowerCase();
					const filteredCollection = collection.filterByFn(function(item) {
						const itemCaption = item.caption.toLowerCase();
						return itemCaption.indexOf(searchFilter) > -1;
					}, this);
					const selectedRows = this.get("SelectedRows");
					filteredCollection.each(function(item) {
						item.selected = Ext.Array.contains(selectedRows, item.id);
					});
					this.set("IsGridEmpty", filteredCollection.isEmpty());
					this.set("FilteredCollection", filteredCollection);
					this._getGridCollection(this._loadGridCollection);
				}, this);
			},

			/**
			 * Handles a click on the "SelectAll" button.
			 */
			onSelectAllButtonClick: function() {
				this.initGridRowViewModel(function() {
					const collection = this.get("DataCollection");
					const selectedRows = [];
					collection.each(function(item) {
						selectedRows.push(item.id);
					});
					this.set("SelectedRows", selectedRows);
					this._getGridCollection(this._loadGridCollection);
				}, this);
			},

			/**
			 * Handles a click on the "DeselectAll" button.
			 */
			onDeselectAllButtonClick: function() {
				this.initGridRowViewModel(function() {
					this.set("SelectedRows", []);
					this._getGridCollection(this._loadGridCollection);
				}, this);
			},

			/**
			 * Handler for double click.
			 * @param {String|Array} selectedRow Selected row ID.
			 */
			onGridDoubleClick: function(selectedRow) {
				const isMultiSelect = this.get("IsMultiSelect");
				if (!isMultiSelect) {
					this.sandbox.publish(this.getLookupMessage(), {
						"selectedRows": [selectedRow]
					}, [this.sandbox.id]);
				}
			},

			/**
			 * Get additional wrap classes for root container
			 * @returns {[string]}
			 */
			getWrapClassNames: function() {
				return ['entity-column-lookup-page-container'];
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "fixed-area-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["modal-page-container", "modal-page-fixed-container", "column-lookup-page"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "fixed-area-container",
				"propertyName": "items",
				"name": "headContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "headContainer",
				"propertyName": "items",
				"name": "header-name-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-name-container", "header-name-container-full"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "header-name-container",
				"propertyName": "items",
				"name": "ModalBoxCaption",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "modalBoxCaption"}
				}
			},
			{
				"operation": "insert",
				"parentName": "headContainer",
				"propertyName": "items",
				"name": "close-icon-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-name-container", "header-name-container-full"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "close-icon-container",
				"propertyName": "items",
				"name": "close-icon",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["close-btn-user-class"]},
					"click": {"bindTo": "close"}
				}
			},
			{
				"operation": "insert",
				"parentName": "fixed-area-container",
				"propertyName": "items",
				"name": "utils-area-editPage",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-controls-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "actionsBtnContainer",
				"propertyName": "items",
				"name": "right-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-right-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "right-container",
				"propertyName": "items",
				"name": "options-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-options-container"],
					"items": [],
					"visible": {
						"bindTo": "IsMultiSelect"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "options-container",
				"propertyName": "items",
				"name": "TotalItemsCaption",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.TotalSelectedItemsCounterCaption"
					},
					"classes": {"labelClass": ["column-lookup-page-label-edit"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "options-container",
				"propertyName": "items",
				"name": "TotalItemsCounter",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "SelectedRowsCount"
					},
					"classes": {"labelClass": ["column-lookup-page-selected-rows-count-label"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "actionsBtnContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"click": {"bindTo": "onSaveClick"},
					"classes": {"textClass": ["utils-buttons"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "actionsBtnContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"click": {"bindTo": "close"},
					"classes": {"textClass": ["utils-buttons"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "utils-area-editPage",
				"propertyName": "items",
				"name": "filtering-container",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-filtering-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SearchInput",
				"parentName": "filtering-container",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"controlConfig": {
						"enterkeypressed": {
							"bindTo": "onSearchButtonClick"
						},
						"className": "BPMSoft.TextEdit",
						"value": {
							"bindTo": "SearchInput"
						},
						"focused": true,
						"markerValue": "SearchInput"
					},
					"wrapClass": ["search-edit"]
				}
			},
			{
				"operation": "insert",
				"parentName": "filtering-container",
				"propertyName": "items",
				"name": "SearchButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {
						"bindTo": "Resources.Strings.SearchButtonCaption"
					},
					"click": {
						"bindTo": "onSearchButtonClick"
					},
					"classes": {"textClass": ["vertical-align-top"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "filtering-container",
				"propertyName": "items",
				"name": "SelectAllButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {
						"bindTo": "Resources.Strings.SelectAllButtonCaption"
					},
					"click": {
						"bindTo": "onSelectAllButtonClick"
					},
					"classes": {"textClass": ["vertical-align-top"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "filtering-container",
				"propertyName": "items",
				"name": "DeselectAllButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {
						"bindTo": "Resources.Strings.DeselectAllButtonCaption"
					},
					"click": {
						"bindTo": "onDeselectAllButtonClick"
					},
					"classes": {"textClass": ["vertical-align-top"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "fixed-area-container",
				"propertyName": "items",
				"name": "center-area-editPage",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-controls-container", "center-area-editPage-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "center-area-grid-container",
				"parentName": "center-area-editPage",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["center-area-grid-container-column-lookup-page"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DataGrid",
				"parentName": "center-area-grid-container",
				"propertyName": "items",
				"values": {
					"primaryDisplayColumnName": "Caption",
					"primaryColumnName": "Id",
					"itemType": BPMSoft.ViewItemType.GRID,
					"collection": {"bindTo": "GridData"},
					"type": "listed",
					"multiSelect": {
						"bindTo": "IsMultiSelect"
					},
					"selectedRows": {
						"bindTo": "SelectedRows"
					},
					"activeRow": {
						"bindTo": "ActiveRow"
					},
					"openRecord": {
						"bindTo": "onGridDoubleClick"
					},
					"isEmpty": {
						"bindTo": "IsGridEmpty"
					},
					"columnsConfig": [
						{
							"cols": 24,
							"key": [
								{
									"name": {bindTo: "Icon"},
									"type": BPMSoft.GridIconType.ICON16LISTED
								},
								{
									"name": {
										bindTo: "Caption"
									}
								}
							]
						}
					],
					"captionsConfig": [
						{
							"cols": 24,
							"name": resources.localizableStrings.NameCaption
						}
					]
				}
			},
			{
				"operation": "insert",
				"parentName": "fixed-area-container",
				"propertyName": "items",
				"name": "actionsBtnContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["column-lookup-page-actions-container"],
					"items": []
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
