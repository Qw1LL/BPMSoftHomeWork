define("ViewModelCollectionGridSchemaV2", ["GridUtilitiesV2", "css!ViewModelCollectionGridSchemaV2CSS"], function() {
	return {

		messages: {},

		mixins: {
			/**
			 * @class GridUtilities implements basic methods for working with grid.
			 */
			GridUtilities: "BPMSoft.GridUtilities"
		},

		attributes: {
			/**
			 * Base view model collection grid data.
			 */
			"GridData": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Grid type.
			 */
			"GridType": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "listed"
			},

			/**
			 * Active row primary column value.
			 */
			"ActiveRow": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Is grid is empty.
			 */
			"IsGridEmpty": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: null
			},

			/**
			 * Flag whether the registry loaded
			 */
			"IsGridLoading": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.showBodyMask();
				this.callParent([function() {
					this.initGridData();
					this.mixins.GridUtilities.init.call(this);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Returns grid data.
			 * @protected
			 * @return {BPMSoft.BaseViewModelCollection} Grid data.
			 */
			getGridData: function() {
				return this.get("GridData");
			},

			/**
			 * Returns grid data item by id.
			 * @param {Guid} id Active row id.
			 * @return {BPMSoft.BaseViewModel} Row view model item.
			 */
			getGridDataItemById: function(id) {
				var gridData = this.get("GridData");
				return gridData.get(id);
			},

			/**
			 * Returns active row.
			 * @protected
			 * @return {BPMSoft.BaseViewModel} Active row.
			 */
			getActiveRow: function() {
				var rowId = this.get("ActiveRow");
				return this.getGridDataItemById(rowId);
			},

			/**
			 * Removes active row from data grid.
			 * @protected
			 */
			removeActiveRow: function() {
				var gridData = this.get("GridData");
				gridData.remove(this.getActiveRow());
			},

			/**
			 * Initializes grid data.
			 * @protected
			 */
			initGridData: function() {
				var collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.set("GridData", collection);
			},

			/**
			 * Handler of active row actions.
			 * @protected
			 * @param {String} buttonTag Button tag.
			 * @param {String|GUID} primaryColumnValue Primary column value.
			 */
			onActiveRowAction: function(buttonTag, primaryColumnValue) {
				switch (buttonTag) {
					case "edit":
						this.editRecord(primaryColumnValue);
						break;
					case "disable":
						this.disableRecord();
						break;
					case "remove":
						this.removeRecord();
						break;
				}
			},

			/**
			 * Edit record handler.
			 * @protected
			 * @virtual
			 */
			editRecord: BPMSoft.emptyFn,

			/**
			 * Remove record handler.
			 * @protected
			 * @virtual
			 */
			removeRecord: BPMSoft.emptyFn,

			/**
			 * Disable record handler.
			 * @protected
			 * @virtual
			 */
			disableRecord: BPMSoft.emptyFn,

			/**
			 * handler of add button click.
			 * @protected
			 * @virtual
			 */
			onAddButtonClick: BPMSoft.emptyFn

			//endregion

		},

		diff: /**SCHEMA_DIFF*/[{
			"operation": "insert",
			"name": "DataGridContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["base-grid-dataview-container-wrapClass"],
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "DataGridToolsContainer",
			"propertyName": "items",
			"parentName": "DataGridContainer",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["base-grid-tools-container-wrapClass"],
				"items": []
			},
			"index": 1
		}, {
			"operation": "insert",
			"name": "DataGridAddNewRecordButton",
			"parentName": "DataGridToolsContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.BUTTON,
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"caption": {"bindTo": "Resources.Strings.AddButtonCaption"},
				"tag": "add",
				"click": {"bindTo": "onAddButtonClick"},
				"markerValue": "AddNewBusinessRule",
				"classes": {
					"wrapperClass": ["add-new-record"]
				}
			}
		}, {
			"operation": "insert",
			"name": "DataGrid",
			"parentName": "DataGridContainer",
			"propertyName": "items",
			"index": 2,
			"values": {
				"itemType": BPMSoft.ViewItemType.GRID,
				"type": {"bindTo": "GridType"},
				"collection": {"bindTo": "GridData"},
				"listedZebra": true,
				"primaryColumnName": "Id",
				"activeRowAction": {"bindTo": "onActiveRowAction"},
				"activeRow": {"bindTo": "ActiveRow"},
				"isEmpty": {"bindTo": "IsGridEmpty"},
				"isLoading": {"bindTo": "IsGridLoading"},
				"columnsConfig": [],
				"captionsConfig": [],
				"activeRowActions": []
			}
		}, {
			"operation": "insert",
			"name": "DataGridActiveRowOpenAction",
			"parentName": "DataGrid",
			"propertyName": "activeRowActions",
			"values": {
				"className": "BPMSoft.Button",
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"caption": {"bindTo": "OpenButtonCaption"},
				"tag": "edit"
			}
		}, {
			"operation": "insert",
			"name": "DataGridActiveRowDisableAction",
			"parentName": "DataGrid",
			"propertyName": "activeRowActions",
			"values": {
				"className": "BPMSoft.Button",
				"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				"caption": {"bindTo": "DisableButtonCaption"},
				"tag": "disable"
			}
		}, {
			"operation": "insert",
			"name": "DataGridActiveRowDeleteAction",
			"parentName": "DataGrid",
			"propertyName": "activeRowActions",
			"values": {
				"className": "BPMSoft.Button",
				"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				"caption": {"bindTo": "DeleteButtonCaption"},
				"tag": "remove"}
		}]/**SCHEMA_DIFF*/
	};
});
