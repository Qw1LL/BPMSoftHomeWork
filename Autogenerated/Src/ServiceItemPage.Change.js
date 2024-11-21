define("ServiceItemPage", [],
    function() {
        return {
            entitySchemaName: "ServiceItem",
            details: /**SCHEMA_DETAILS*/{
                "Change": {
                    "schemaName": "ChangeInServiceItemDetail",
                    "entitySchemaName": "ChangeServiceItem",
                    "filter": {
                        "masterColumn": "Id",
                        "detailColumn": "ServiceItem"
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
                    "index": 3
                }
            ]/**SCHEMA_DIFF*/
        };
    });
