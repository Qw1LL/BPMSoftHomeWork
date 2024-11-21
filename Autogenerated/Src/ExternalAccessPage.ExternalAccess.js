define("ExternalAccessPage", [
	"ExternalAccessUtilities"
], function() {
	return {
		entitySchemaName: "ExternalAccess",
		attributes: {
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"IsolatedRecordsDetail": {
				"schemaName": "IsolatedRecordDetail",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "ExternalAccess"
				}
			},
			"SessionDetail": {
				"schemaName": "SessionDetailV2",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "ExternalAccess"
				}
			},
			"Files": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "ExternalAccessFile",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "ExternalAccess"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		mixins: {
			ExternalAccessUtilities: "BPMSoft.ExternalAccessUtilities"
		},
		methods: {

			/**
			 * @param {Object} responseObject Response of service that deactivates external accesses.
			 * @private
			 */
			_processDeactivationResponse: function(responseObject) {
				if (!BPMSoft.isEmptyObject(responseObject)) {
					this.reloadEntity();
				}
			},

			/**
			 * @override
			 * @inheritdoc
			 */
			getActions: function() {
				const actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					Type: "BPMSoft.MenuSeparator",
					Caption: BPMSoft.emptyString
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "getDeactivationActionCaption"},
					"Tag": this.deactivateExternalAccessRecord.name,
					"Enabled": {"bindTo": "getIsDeactivationActionEnabled"}
				}));
				return actionMenuItems;
			},

			/**
			 * Returns whether deactivation action should be active
			 * @return {Boolean} Whether deactivation action should be active.
			 */
			getIsDeactivationActionEnabled: function() {
				return this.$IsActive;
			},

			/**
			 * Deactivates current access record.
			 */
			deactivateExternalAccessRecord: function() {
				const accessIds = [this.get(this.primaryColumnName)];
				this.deactivateAccesses(accessIds, this._processDeactivationResponse, this);
			}

		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AccessReason",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ExternalAccessClient",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "StartDate",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "DueDate",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Grantor",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsDataIsolationEnabled",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsActive",
				"values": {
					"layout": {
						"column": 13,
						"row": 2,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsSystemOperationsRestricted",
				"values": {
					"layout": {
						"column": 13,
						"row": 3,
						"layoutName": "Header"
					},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "SessionsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.SessionsTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs"
			},
			{
				"operation": "insert",
				"name": "SessionDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"markerValue": "sessions-detail"
				},
				"parentName": "SessionsTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsolatedRecordsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.IsolatedRecordsTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs"
			},
			{
				"operation": "insert",
				"name": "IsolatedRecordsDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"markerValue": "isolated-records-detail"
				},
				"parentName": "IsolatedRecordsTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "NotesAndFilesTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.NotesAndFilesTabCaption"
					},
					"items": [],
					"order": 2
				},
				"parentName": "Tabs",
				"propertyName": "tabs"
			},
			{
				"operation": "insert",
				"name": "Files",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.NotesGroupCaption"
					},
					"items": []
				},
				"parentName": "NotesAndFilesTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Notes",
				"values": {
					"bindTo": "Notes",
					"dataValueType": 1,
					"contentType": 4,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "insertImagesToNotes"
						},
						"images": {
							"bindTo": "NotesImagesCollection"
						}
					}
				},
				"parentName": "NotesControlGroup",
				"propertyName": "items"
			}
		]/**SCHEMA_DIFF*/
	};
});
