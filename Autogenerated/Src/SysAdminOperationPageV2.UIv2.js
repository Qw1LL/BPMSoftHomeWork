define("SysAdminOperationPageV2",
	["SysAdminOperationPageV2Resources"],
	function() {
		return {
			entitySchemaName: "SysAdminOperation",
			details: /**SCHEMA_DETAILS*/{
				DetailOperation: {
					"schemaName": "SysAdminOperationGranteeDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "SysAdminOperation"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "Code",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 13, "row": 0, "colSpan": 11},
						"enabled": {"bindTo": "isAddMode"}
					}
				},
				{
					"operation": "insert",
					"name": "Description",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"name": "DetailOperation",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {"itemType": this.BPMSoft.ViewItemType.DETAIL}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				addSectionDesignerViewOptions: this.BPMSoft.emptyFn,

				initActionButtonMenu: this.BPMSoft.emptyFn,

				initRunProcessButtonMenu: this.BPMSoft.emptyFn,

				saveEntity: function(callback, scope) {
					var config = {
						"serviceName": "RightsService",
						"methodName": "UpsertAdminOperation",
						"data": {
							"recordId": this.get("Id"),
							"name": this.get("Name"),
							"code": this.get("Code"),
							"description": this.get("Description")
						}
					};
					this.callService(config, this.onGetResponse.bind(undefined, callback, scope), this);
				},

				onGetResponse: function(callback, scope, response) {
					if (response && response.UpsertAdminOperationResult) {
						var result = this.Ext.decode(response.UpsertAdminOperationResult);
						if (result && !this.Ext.isEmpty(result)) {
							response.success = result.Success;
							response.message = result.ExMessage;
							response.rowsAffected = 1;
							response.nextPrcElReady = false;
							scope.isNew = false;
							scope.changedValues = null;
							callback.call(scope || this, response);
						}
					}
				}
			}
		};
	});
