define("OAuthClientAppSection", [],
	function() {
		return {
			entitySchemaName: "OAuthClientApp",
			attributes: {
				"SecurityOperationName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "CanManageAdministration"
				}
			},
			methods: {
				getDefaultDataViews: function() {
					var dataViews = this.callParent(arguments);
					delete dataViews.AnalyticsDataView;
					return dataViews;
				},

				getModuleCaption: function() {
					return this.get("Resources.Strings.SectionCaption");
				},

				initEditPages: function() {
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					var typeUId = this.BPMSoft.GUID_EMPTY;
					if (this.Ext.isEmpty(editPages.find(typeUId))) {
						editPages.add(typeUId, this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: typeUId,
								Caption: this.get("Resources.Strings.EditPageCaption"),
								Click: {bindTo: "addRecord"},
								Tag: typeUId,
								SchemaName: "OAuthClientAppPage"
							}
						}));
					}
				},

				addDefaultResource: function() {
					this.callService({
						serviceName: "OAuthConfigService",
						methodName: "AddDefaultResource",
					}, function(response) {
						if (!response.AddDefaultResourceResult.success) {
							BPMSoft.showMessage(response.AddDefaultResourceResult.errorInfo.message);
						} else {
							var message = this.get("Resources.Strings.DefaultResourceSuccessMessage");
							BPMSoft.showMessage(message);
						}
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overridden
				 */
				getSectionActions: function() {
					var actions = this.callParent(arguments);
					actions.clear();
					actions.addItem(this.createAddDefaultResourceButton());
					return actions;
				},

				/**
				 * Creates add default resource button.
				 * @protected
				 */
				createAddDefaultResourceButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.AddDefaultResourceButtonCaption"},
						"Click": {"bindTo": "addDefaultResource"},
						"Visible": true,
						"Enabled": true,
						"IsEnabledForSelectedAll": true
					});
				}
			},
			diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGridActiveRowCopyAction",
				"values": {
					"visible": false
				}
			}
			]/**SCHEMA_DIFF*/
		};
	});