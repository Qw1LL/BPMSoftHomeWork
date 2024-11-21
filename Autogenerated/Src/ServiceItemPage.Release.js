define("ServiceItemPage", [],
    function() {
        return {
            entitySchemaName: "ServiceItem",
            details: /**SCHEMA_DETAILS*/{
                "Release": {
                    "schemaName": "ReleaseInServiceItemDetail",
                    "entitySchemaName": "ReleaseServiceItem",
                    "filter": {
                        "masterColumn": "Id",
                        "detailColumn": "ServiceItem"
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
                    "index": 2
                }
            ]/**SCHEMA_DIFF*/
        };
    });
