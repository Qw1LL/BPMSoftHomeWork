define("CasePage", [], function () {
    return {
        entitySchemaName: "Case",
        attributes: {
            "EnableComplainFunction": {
                dataValueType: this.BPMSoft.DataValueType.BOOLEAN
            }
        },
        details: /**SCHEMA_DETAILS*/{
            "DeclarerCommentsDetail": {
                "schemaName": "DeclarerCommentsDetail",
                "entitySchemaName": "VwDeclarerComments",
                "filter": {
                    "detailColumn": "Case",
                    "masterColumn": "Id"
                }
            }
        }/**SCHEMA_DETAILS*/,
        diff: /**SCHEMA_DIFF*/[
            {
                "operation": "insert",
                "name": "DeclarerCommentsDetail",
                "values": {
                    "itemType": 2,
                    "markerValue": "added-detail",
                    "visible": {"bindTo": "getDeclarerCommentsDetailVisible"}
                },
                "parentName": "SolutionTab",
                "propertyName": "items",
                "index": 3
            }
        ]/**SCHEMA_DIFF*/,
        methods: {
            /**
             * @inheritdoc BasePageV2#initEntity
             * @overridden
             */
            initEntity: function() {
                this.initSysSettings();
                this.callParent(arguments);
            },
            /**
             * Returns declarer comments detail visibility.
             * @returns {boolean}
             */
            getDeclarerCommentsDetailVisible: function() {
                return this.get("EnableComplainFunction");
            },

            /**
             * Initializes required system settings.
             */
            initSysSettings: function() {
                BPMSoft.SysSettings.querySysSettingsItem("EnableComplainFunction", function(value) {
                    this.set("EnableComplainFunction", value);
                }, this);
            }
        },
        businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/
    };
});
