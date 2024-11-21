define("ConfItemPage", [],
    function() {
        return {
            entitySchemaName: "ConfItem",
            details: /**SCHEMA_DETAILS*/{
                "Release": {
                    "schemaName": "ReleaseInConfItemDetail",
                    "entitySchemaName": "ReleaseConfItem",
                    "filter": {
                        "masterColumn": "Id",
                        "detailColumn": "ConfItem"
                    }
                }
            }/**SCHEMA_DETAILS*/,
            diff: /**SCHEMA_DIFF*/[
                {
                    "operation": "insert",
                    "name": "Release",
                    "values": {
                        "itemType": this.BPMSoft.ViewItemType.DETAIL
                    },
                    "parentName": "HistoryTab",
                    "propertyName": "items",
                    "index": 3
                }
            ]/**SCHEMA_DIFF*/
        };
    });
