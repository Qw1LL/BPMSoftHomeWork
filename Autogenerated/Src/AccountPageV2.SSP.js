define("AccountPageV2", [],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{
				"PortalUserInOrganization": {
					"schemaName": "PortalUserInOrganizationDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "PortalAccount"
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				_getIsPortalUserManagementV2Enabled: function() {
					return this.getIsFeatureEnabled("PortalUserManagementV2");
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDetailChanged
				 * @overridden
				 */
				onDetailChanged: function(config) {
					this.callParent(arguments);
					if (!this.Ext.isEmpty(config)) {
						switch (config.schemaName){
							case "AccountContactsDetailV2":
								this.updatePortalUserInOrganizationDetail(config);
								break;
							case "PortalUserInOrganizationDetail":
								this.updateAccountContactsDetail(config);
								break;
						}
					}
				},

				/**
				 * Updates PortalUserInOrganization detail.
				 */
				updatePortalUserInOrganizationDetail: function() {
					const detailName = "PortalUserInOrganization";
					const detail = this.details[detailName];
					detail.detail = detail.detail || detailName;
					this.updateDetail(detail);
				},

				/**
				 * Updates AccountContacts detail.
				 */
				updateAccountContactsDetail: function() {
					const detailName = "AccountContacts";
					const detail = this.details[detailName];
					detail.detail = detail.detail || detailName;
					this.updateDetail(detail);
				},

				updateDetail: function(detailConfig) {
					this.callParent([detailConfig]);
					if (detailConfig && detailConfig.detail === "PortalUserInOrganization") {
						if (detailConfig.containerId) {
							let view = this.Ext.get(detailConfig.containerId);
							if (view) {
								view = this.Ext.get(view.getAttribute("data-item-marker"));
								if (view) {
									view.destroy();
								}
							}
							this.sandbox.loadModule("DetailModuleV2", {
								renderTo: detailConfig.containerId,
								id: this.getDetailId(detailConfig.detailName)
							});
						}
					}
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "PortalUserInOrganization",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "_getIsPortalUserManagementV2Enabled"}
					},
					"parentName": "ContactsAndStructureTabContainer",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/
		};
	});
