define("SiteEventDetailV2",
    function() {
        return {
            attributes: {
                /**
                 * Is detail collapsed
                 * @type {Boolean}
                 */
                ToolsButtonVisible: {dataValueType: BPMSoft.DataValueType.BOOLEAN}
            },
            methods: {
                /**
                 * Init detail page.
                 * @protected
                 * @overridden
                 */
                init: function() {
                    this.callParent(arguments);
                    this.set("MultiSelect", false);
                },

	            /**
	             * Initialize detail property. Set detail collapsed by default.
	             * @protected
	             * @overridden
	             */
	            initDetailOptions: function() {
		            this.callParent();
		            this.set("IsDetailCollapsed", true);
	            },

                /**
                 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
                 * @overridden
                 */
                getDeleteRecordMenuItem: BPMSoft.emptyFn,

                /**
                 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
                 * @overridden
                 */
                getCopyRecordMenuItem: BPMSoft.emptyFn,

                /**
                 * Returns visibility button add.
                 * @protected
                 * @return {Boolean} Visibility button, add.
                 */
                getAddRecordButtonVisible: function() {
                    return false;
                },

                /**
                 * Returns visibility of the button with a menu was added.
                 * @protected
                 * @return {Boolean} Visibility button to add a menu.
                 */
                getAddTypedRecordButtonVisible: function() {
                    return false;
                },

                /**
                 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
                 * @overridden
                 */
                getSwitchGridModeMenuItem: BPMSoft.emptyFn,

                /**
                 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
                 * @overridden
                 */
                getEditRecordMenuItem: BPMSoft.emptyFn,
                /**
                 * Add filters and load grid data
                 * @protected
                 * @virtual
                 */
                loadGridData: function() {
                    var masterRecordId = this.get("MasterRecordId");
                    if (masterRecordId !== "") {
                        this.callParent();
                    } else {
                        var gridData = this.getGridData();
                        gridData.clear();
                        var emptyCollection = Ext.create("BPMSoft.Collection");
                        this.set("CanLoadMoreData", false);
                        this.initIsGridEmpty(emptyCollection);
                    }
                    return;
                },
                /**
                 * Handles colapse event for detail
                 * @protected
                 * @virtual
                 * @param {Boolean} isCollapsed Flag of detail is colapsed.
                 */
                onDetailCollapsedChanged: function(isCollapsed) {
                    this.set("ToolsButtonVisible", !isCollapsed);
                    this.callParent(arguments);
                }
            },
            diff: /**SCHEMA_DIFF*/[
                {
                    "operation": "merge",
                    "name": "OpenButton",
                    "parentName": "Detail",
                    "propertyName": "tools",
                    "values": {
                        "visible": false
                    },
                    "index": 0
                },
                {
                    "operation": "merge",
                    "name": "AddRecordButton",
                    "parentName": "Detail",
                    "propertyName": "tools",
                    "values": {
                        "visible": false
                    }
                },
                {
                    "operation": "merge",
                    "name": "ToolsButton",
                    "parentName": "Detail",
                    "propertyName": "menu",
                    "values": {
                        "visible": {"bindTo":"ToolsButtonVisible"}
                    }
                }
            ]/**SCHEMA_DIFF*/
        };
    }
);
