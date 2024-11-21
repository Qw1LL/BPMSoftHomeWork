define("PortalSchemaAccessListDetail", ["ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities"], function() {
	return {
		entitySchemaName: "PortalColumnAccessList",
		attributes: {
			"IsEditable": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
			"AccessEntitySchemaName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		messages: {
			/**
			 * @message GetColumnsValues
			 * Returns requested column values.
			 */
			"GetColumnsValues": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		details: {},
		diff: [],
		mixins: {
			ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSettingsMenuItem
			 * @overridden
			 */
			getGridSettingsMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#hideQuickFilterButton
			 * @overridden
			 */
			getHideQuickFilterButton: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetail#getQuickFilterButton
			 * @overridden
			 */
			getShowQuickFilterButton: BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @overridden
			 */
			getGridSortMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#sortColumn
			 * @overridden
			 */
			sortColumn: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
			 * @overridden
			 */
			getAddRecordButtonVisible: function() {
				return true;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseGridDetailV2#addRecord
			 * @overridden
			 */
			addRecord: function() {
				var entitySchemaName = this.get("AccessEntitySchemaName");
				this.BPMSoft.StructureExplorerUtilities.open({
					scope: this,
					handlerMethod: this.addCallback,
					moduleConfig: {
						schemaName: entitySchemaName,
						useBackwards: false,
						firstColumnsOnly: true
					}
				});
			},

			/**
			 * On add item callback.
			 * @param {Object} result
			 * @protected
			 */
			addCallback: function(result) {
				if (this.isColumnAdded(result.metaPath[0])) {
					this.showInformationDialog(this.get("Resources.Strings.DuplicateColumnMessage"));
					return;
				}
				const insertQuery = this.getPortalColumnsInsertQuery(result);
				insertQuery.execute(function() {
					this.reloadGridData();
				}, this);
			},

			/**
			 * Creates a query to insert column that can be used on portal.
			 * @param {Object} columnInfo Information about column.
			 * @returns {BPMSoft.InsertQuery} Portal column insert query.
			 */
			getPortalColumnsInsertQuery: function(columnInfo) {
				const masterRecordId = this.get("MasterRecordId");
				const insertQuery = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "PortalColumnAccessList"
				});
				insertQuery.setParameterValue("PortalSchemaList", masterRecordId,
					this.BPMSoft.DataValueType.GUID);
				insertQuery.setParameterValue("ColumnUId", columnInfo.metaPath[0],
					this.BPMSoft.DataValueType.GUID);
				insertQuery.setParameterValue("ColumnName", this._getPortalColumnName(columnInfo),
					this.BPMSoft.DataValueType.TEXT);
				return insertQuery;
			},

			_getPortalColumnName: function(columnInfo) {
				return columnInfo.isLookup ? columnInfo.path[0] + "Id" : columnInfo.path[0];
			},

			/**
			 * Check if column already added.
			 * @param columnUId Column uid.
			 * @returns {boolean} Is column added.
			 */
			isColumnAdded: function(columnUId){
				var gridData = this.getGridData();
				var collection = gridData.getItems();
				for (var i = 0; i < gridData.getCount(); i++) {
					if (collection[i].values.ColumnUId === columnUId) {
						return true;
					}
				}
				return false;
			},

			/**
			 * Returns page column value.
			 * @private
			 * @param {String} columnName Page column name.
			 */
			getValueByName: function(columnName) {
				var names = this.sandbox.publish("GetColumnsValues", [columnName],
						[this.sandbox.id]);
				return names[columnName];
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 **/
			init: function() {
				this.callParent(arguments);
				var entitySchemaNameColumn = "AccessEntitySchemaName";
				var entitySchemaName = this.getValueByName(entitySchemaNameColumn);
				this.set("AccessEntitySchemaName", entitySchemaName);
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#prepareResponseCollectionItem:
			 * @overridden
			 */
			prepareResponseCollectionItem: function(item) {
				this.callParent(arguments);
				var entitySchemaName = this.get("AccessEntitySchemaName");
				var columns = this.BPMSoft[entitySchemaName].columns;
				this.BPMSoft.each(columns, function(column) {
					if (column.uId === item.get("ColumnUId")) {
						item.set("ColumnUId", column.caption);
					}
				}, this);
			}
		}
	};
});
