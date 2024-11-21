define("SspAccountProfilePage", ["css!ContactPageV2CSS"],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{
				"PortalUserInOrganization": {
					"schemaName": "PortalUserInOrganizationDetail",
					"filter": {
						"masterColumn": "OrganizationId",
						"detailColumn": "PortalAccount"
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
						"visible": true,
						"bindTo": "Name",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "PrimaryContact",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"visible": true,
						"bindTo": "PrimaryContact",
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"name": "Phone",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"bindTo": "PortalAccountPhone",
						"enabled": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "PortalUsersTab",
					"parentName": "Tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.PortalUsersTabCaption"
						},
						"items": []
					},
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "PortalUserInOrganization",
					"parentName": "PortalUsersTab",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "getPortalUserInOrganizationDetailVisible"}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"OrganizationId": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"PrimaryContact": {
					"columnPath": "PrimaryContact",
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"caption": {bindTo: "Resources.Strings.PrimaryContactCaption"},
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				"PortalAccountPhone": {
					"columnPath": "Phone",
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"caption": {bindTo: "Resources.Strings.PortalAccountPhoneCaption"},
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"enabled": false
				}
			},
			methods: {

				/**
				 * @inheritDoc BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.getSspAccountInfo();
				},

				/**
				 * Get info about SSP account
				 */
				getSspAccountInfo: function() {
					const serviceConfig = {serviceName: "SspUserManagementService", methodName: "GetSspAccountInfo"};
					this.callService(serviceConfig, function(response) {
						const result = response && response.GetSspAccountInfoResult;
						if (result && result.success && result.SspAccountId) {
							this.set("OrganizationId", result.SspAccountId);
						}
					}, this);
				},

				/**
				 * Get portal user in organization detail visibility.
				 * @returns {boolean} detail visibility.
				 */
				getPortalUserInOrganizationDetailVisible: function() {
					return this.get("OrganizationId") === this.get("Id");
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2.mixins.PrintReportUtilities#initCardPrintForms
				 * @override
				 */
				initCardPrintForms: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc DuplicatesSearchUtilitiesV2#initPerformSearchOnSave
				 * @override
				 */
				initPerformSearchOnSave: this.BPMSoft.emptyFn
			}
		};
	});
