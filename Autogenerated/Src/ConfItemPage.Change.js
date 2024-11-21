define("ConfItemPage", [],
    function() {
        return {
            entitySchemaName: "ConfItem",
            details: /**SCHEMA_DETAILS*/{
                "Change": {
                    "schemaName": "ChangeInConfItemDetail",
                    "entitySchemaName": "ChangeConfItem",
                    "filter": {
                        "masterColumn": "Id",
                        "detailColumn": "ConfItem"
                    }
                }
            }/**SCHEMA_DETAILS*/,
            diff: /**SCHEMA_DIFF*/[
                {
                    "operation": "insert",
                    "name": "Change",
                    "values": {
                        "itemType": this.BPMSoft.ViewItemType.DETAIL
                    },
                    "parentName": "HistoryTab",
                    "propertyName": "items",
                    "index": 2
                }
            ]/**SCHEMA_DIFF*/
        };
    });
