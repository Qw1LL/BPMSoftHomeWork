define("EmailTemplatePageV2", ["ContentBuilderEnumsModule", "css!EmailTemplatePageV2V2Styles"],
	function(ContentBuilderEnumsModule) {
		return {
			entitySchemaName: "EmailTemplate",
			methods: {
				/**
				 * @inheritDoc BasePageV2#initActionButtonMenu
				 * @overridden
				 */
				initActionButtonMenu: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.set("BodyToDisplay", this.get("Body"));
					this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
				},

				/**
				 * Opens window for editing template message.
				 * @protected
				 */
				editTemplate: function() {
					var contentBuilderMode = ContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATE;
					var recordId = this.getPrimaryColumnValue();
					var contentBuilderUrl = ContentBuilderEnumsModule.getContentBuilderUrl(contentBuilderMode, recordId);
					if (this.isNewMode() || this.isChanged()) {
						var config = {
							callback: function() {
								window.open(contentBuilderUrl);
							},
							callBaseSilentSavedActions: true,
							isSilent: true
						};
						this.save(config);
					} else {
						window.open(contentBuilderUrl);
					}
				},

				/**
				 * Handles the message server communications channel.
				 * @protected
				 * @param {BPMSoft.ServerChannel} channel Channel messaging server BPMCRM.
				 * @param {Object} message Message object.
				 */
				onChannelMessage: function(channel, message) {
					if (this.Ext.isEmpty(message)) {
						return;
					}
					var header = message.Header;
					if (header.Sender !== ContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATE) {
						return;
					}
					var messageObject = BPMSoft.decode(message.Body || "{}");
					var primaryColumnValue = this.getPrimaryColumnValue();
					if (messageObject.recordId !== primaryColumnValue) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: this.entitySchemaName});
					esq.addColumn("Body");
					esq.getEntity(primaryColumnValue, function(result) {
						this.set("BodyToDisplay", result.entity.get("Body"));
					}, this);
				},

				/**
				 * Returns filters for the entity objects.
				 * @return {BPMSoft.FilterGroup} Filters for the entity objects.
				 */
				getObjectEntitySchemaFilters: function() {
					var filters = this.Ext.create("BPMSoft.FilterGroup");
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"ManagerName",
						"EntitySchemaManager"
					));
					filters.addItem(this.BPMSoft.createColumnIsNotNullFilter("Caption"));
					return filters;
				},

				/**
				 * @inheritdoc BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
					this.callParent(arguments);
				}
			},
			attributes: {
				/**
				 * Virtual column reference scheme.
				 */
				Object: {
					lookupListConfig: {
						filter: function() {
							return this.getObjectEntitySchemaFilters();
						}
					}
				},

				/**
				 * Body to display.
				 */
				BodyToDisplay: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 1,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},	
				{
					"operation": "insert",
					"name": "Object",
					"values": {
						"layout": {
							"column": 1,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.ObjectTip"
							}
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.GeneralInfoTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "GeneralInfoControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"controlConfig": {
							"classes": ["detail"]
						},
						"tools": [],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EditTemplateItem",
					"parentName": "GeneralInfoControlGroup",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.EditTemplateButtonCaption"
						},
						"click": {
							"bindTo": "editTemplate"
						}
					}
				},
				{
					"operation": "insert",
					"name": "TemplateContaner",
					"parentName": "GeneralInfoControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "TemplateContaner",
					"propertyName": "items",
					"name": "Body",
					"values": {
						"generator": function() {
							return {
								"className": "BPMSoft.IframeControl",
								"id": "preview-content-iframe",
								"iframeContent": {"bindTo": "BodyToDisplay"}
							};
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
