define("SocialMessagePublisherPage", [ "LookupUtilities", "ServiceHelper", "ESNHtmlEditModule", "SocialMentionUtilities",
	"MacrosHelperServiceRequest", "css!SocialMessagePublisherModule"
], function(LookupUtilities, ServiceHelper) {
	return {
		entitySchemaName: "SocialMessage",
		mixins: {
			SocialMentionUtilities: "BPMSoft.SocialMentionUtilities"
		},
		attributes: {
			entitiesList: {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			"WritePostHintText": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},
			/**
			 * Template menu items collection.
			 */
			"TemplateMenuCollection": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * User templates collection.
			 */
			"UserTemplates": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.SocialMentionUtilities.init.call(this);
					this.initCollection("entitiesList");
					this.initTemplatesMenuCollection(callback, scope);
				}, this]);
			},

			/**
			 * Initialize template button menu collection.
			 * @protected
			 */
			initTemplatesMenuCollection: function(callback, scope) {
				this.clearOrCreateMenuCollection();
				var templateEsq = this._getTemplateSelectQuery();
				templateEsq.getEntityCollection(function(response) {
					this.onLoadTemplateData(response, callback, scope);
				}, this);
			},

			/**
			 * Create template button menu collection or clear from previous items.
			 * @protected
			 */
			clearOrCreateMenuCollection: function() {
				if(this.$TemplateMenuCollection) {
					this.$TemplateMenuCollection.clear();
				} else {
					this.$TemplateMenuCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				}
			},

			/**
			 * Returns template select query.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} Select template query.
			 */
			_getTemplateSelectQuery: function() {
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SocialFeedFavoriteTpl"
				});
				esq.addColumn("EmailTemplate");
				esq.addColumn("EmailTemplate.Body", "Body");
				esq.addColumn("SysAdminUnit");
				const filterGroup = new this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				filterGroup.add("SysAdminUnitColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value));
				filterGroup.add("AdminUnitGroupsFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[SysUserInRole:SysRole:SysAdminUnit].SysUser",
					this.BPMSoft.SysValue.CURRENT_USER.value));
				esq.filters.add(filterGroup);
				return esq;
			},

			/**
			 * Handle template query result.
			 * @protected
			 * @param {Object} response Response from template query.
			 * @param {Function} callback  Function, which will be called after filling menu items.
			 * @param {Object} scope Scope of callback function.
			 */
			onLoadTemplateData: function (response, callback, scope) {
				if (response && response.success) {
					this.fillTemplateMenuCollection(response.collection.getItems());
				}
				this.Ext.callback(callback, scope);
			},

			/**
			 * Fill User template and group templates separately.
			 * @protected
			 * @param {BPMSoft.Collection} fullTemplateCollection Response query collection.
			 */
			fillTemplateMenuCollection: function(fullTemplateCollection) {
				this.addMenuItemsToTemplateMenuCollection(fullTemplateCollection.filter(function(template) {
					return template.get("SysAdminUnit").value === this.BPMSoft.SysValue.CURRENT_USER.value;
				}, this), this.$TemplateMenuCollection);
				this.addMenuSeparatorToMenuCollection(this.$TemplateMenuCollection);
				this.addMenuItemsToTemplateMenuCollection(fullTemplateCollection.filter(function(template) {
					return template.get("SysAdminUnit").value !== this.BPMSoft.SysValue.CURRENT_USER.value;
				}, this), this.$TemplateMenuCollection);
				this.$UserTemplates = fullTemplateCollection;
				this.addMenuSeparatorToMenuCollection(this.$TemplateMenuCollection);
				this.addSetupTemplateButtonToMenuCollection(this.$TemplateMenuCollection);
			},

			/**
			 * Adds Setup template menu item.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} collection menu items collection.
			 */
			addSetupTemplateButtonToMenuCollection: function(collection) {
				collection.addItem(this.getButtonMenuItem({
					"Caption": {
						"bindTo": "Resources.Strings.SetupTemplates"
					},
					"Click": {
						"bindTo": "setupTemplates"
					}
				}));
			},

			/**
			 * Adds menu separator.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} collection menu items collection.
			 */
			addMenuSeparatorToMenuCollection: function(collection) {
				collection.addItem(this.getButtonMenuItem({
					"Type": "BPMSoft.MenuSeparator",
					"Caption": ""
				}));
			},

			/**
			 * Adds menu items.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} collection menu items collection.
			 * @param {BPMSoft.Collection} templateMenuCollection templates collection.
			 */
			addMenuItemsToTemplateMenuCollection: function(collection, templateMenuCollection) {
				collection.forEach(function(item) {
					const templateMenuItem = templateMenuCollection.getItems().find(function(menuItem) {
						return menuItem.$Tag === item.$EmailTemplate.value;
					}, this);
					if(!templateMenuItem) {
						templateMenuCollection.addItem(this.getButtonMenuItem({
							"Caption": item.$EmailTemplate.displayValue,
							"Click": {"bindTo": "onTemplateClick"},
							"MarkerValue": item.$EmailTemplate.displayValue,
							"Tag": item.$EmailTemplate.value
						}));
					}
				}, this);
			},

			/**
			 * Setup personal template using EmailTemplate lookup.
			 * @protected
			 */
			setupTemplates: function() {
				const rowsToSelect = this.getUserTemplatesIds();
				var config = {
					entitySchemaName: "EmailTemplate",
					multiSelect: true,
					hideActions: true,
					columns: ["Name"],
					selectedRows: rowsToSelect
				};
				LookupUtilities.Open(this.sandbox, config, this.onTemplatesSetup, this, null, false, false);
			},

			/**
			 * Get array with user templates only.
			 * @protected
			 * @return {Array} Array with ids.
			 */
			getUserTemplatesIds: function() {
				const userTemplates = this.$UserTemplates.filter(function(template) {
					return template.$SysAdminUnit.value === this.BPMSoft.SysValue.CURRENT_USER.value;
				}, this);
				const resultIds = [];
				userTemplates.forEach(function(item) {
					if(!resultIds.find(function (resultId) { return resultId === item.$EmailTemplate.value})) {
						resultIds.push(item.$EmailTemplate.value);
					}
				});
				return resultIds;
			},

			/**
			 * Handle user choices in EmailTemplate lookup.
			 * @protected
			 *@param {Object} result Result query.
			 */
			onTemplatesSetup: function(result) {
				var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
				this.addQueries(batchQuery, result.selectedRows.getItems());
				batchQuery.execute(this.initTemplatesMenuCollection, this);
			},

			/**
			 * Add insert and delete queries to batch query using EmailTemplate lookup result.
			 * @protected
			 * @param {BPMSoft.BatchQuery} batchQuery query.
			 * @return {Array} Array with ids.
			 */
			addQueries: function(batchQuery, lookupRows) {
				const userTemplates = this.getUserTemplatesIds();
				const lookupTemplates = this.getLookupTemplateArray(lookupRows);
				this.addInsertQueries(batchQuery, this.getTemplatesMultitudeDifference(lookupTemplates, userTemplates));
				this.addDeleteQueries(batchQuery, this.getTemplatesMultitudeDifference(userTemplates, lookupTemplates));
			},

			/**
			 * Get lookup template ids.
			 * @protected
			 * @param {Array} lookupRows rows from lookup.
			 * @return {Array} Array with ids.
			 */
			getLookupTemplateArray: function(lookupRows) {
				const lookupTemplates = [];
				lookupRows.forEach(function(lookupRow) {
					lookupTemplates.push(lookupRow.Id);
				});
				return lookupTemplates;
			},

			/**
			 * Get multitude difference.
			 * @protected
			 * @param {Array} firstMultitude Multitude A.
			 * @param {Array} secondMultitude Multitude B.
			 * @return {Array} Result Multitude.
			 */
			getTemplatesMultitudeDifference: function(firstMultitude, secondMultitude) {
				return firstMultitude.filter(function(templateFromFirst) {
					return !secondMultitude.find(function(templateFromSecond) {
						return templateFromSecond === templateFromFirst
					}, this);
				}, this);
			},

			/**
			 * Add to batch query inserts with user templates.
			 * @param {BPMSoft.BatchQuery} batchQuery query.
			 * @param {Array} Array with ids.
			 * @protected
			 */
			addInsertQueries: function(batchQuery, insertIds) {
				insertIds.forEach(function(item) {
					const insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "SocialFeedFavoriteTpl"
					});
					insert.setParameterValue("EmailTemplate", item, BPMSoft.DataValueType.GUID);
					insert.setParameterValue("SysAdminUnit",
						this.BPMSoft.SysValue.CURRENT_USER.value, BPMSoft.DataValueType.GUID);
					batchQuery.add(insert)
				})
			},

			/**
			 * Add to batch query deltete query with user templates.
			 * @param {BPMSoft.BatchQuery} batchQuery query.
			 * @param {Array} Array with ids.
			 * @protected
			 */
			addDeleteQueries: function(batchQuery, deleteIds) {
				if(!this.Ext.isEmpty(deleteIds)) {
					const deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: "SocialFeedFavoriteTpl"
					});
					const emailTemplateIdFilter = BPMSoft.createColumnInFilterWithParameters("EmailTemplate",
						deleteIds);
					const userFilter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysAdminUnit",
						this.BPMSoft.SysValue.CURRENT_USER.value, BPMSoft.DataValueType.GUID);
					deleteQuery.filters.add("emailTemplateIdsFilter", emailTemplateIdFilter);
					deleteQuery.filters.add("userFilter", userFilter);
					batchQuery.add(deleteQuery);
				}
			},

			/**
			 * Handle template button click.
			 * @protected
			 * @param {BPMSoft.GUID} tag templates id.
			 */
			onTemplateClick: function (tag) {
				const body = this.$UserTemplates.find(function(template) {
					return template.$EmailTemplate.value === tag;
				}, this).$Body;
				this.callMacrosHelperServiceRequest(body, this.onGetMacrosHelperResponse, this);
			},

			/**
			 * Calls service for getting template text with replaced macroses.
			 * @protected
			 * @param {String} textTemplate Body for service.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function's scope.
			 */
			callMacrosHelperServiceRequest: function(textTemplate, callback, scope) {
				this.showBodyMask();
				const data = this.getListenerRecordData();
				const serviceRequest = this.Ext.create("BPMSoft.MacrosHelperServiceRequest", {
					contractName: "GetTemplate",
					entityId: data.relationSchemaRecordId,
					entityName: data.relationSchemaName,
					textTemplate: textTemplate
				});
				serviceRequest.execute(function(response) {
					callback.call(scope || this, response);
				});
			},

			/**
			 * Handle response from MacrosHelperService.
			 * @protected
			 * @virtual
			 * @param {Object} response Response with text template.
			 */
			onGetMacrosHelperResponse: function(response) {
				this.hideBodyMask();
				if (response && response.textTemplate) {
					this.$Message = response.textTemplate;
				}
			},

			/**
			 * Initializes a collection.
			 * @private
			 * @param {String} collectionName.
			 */
			initCollection: function(collectionName) {
				var collection = this.get(collectionName);
				if (!collection) {
					collection = this.Ext.create("BPMSoft.Collection");
					this.set(collectionName, collection);
				} else {
					collection.clear();
				}
			},

			/**
			 * @private
			 */
			_getMessageData: function() {
				var publishData = this.getPublishData();
				var messageData = { message: {} };
				BPMSoft.each(publishData, function(item) {
					var key = item && item.Key;
					switch(key) {
						case "EntitySchemaUId":
							messageData.message.SchemaUId = item.Value;
							break;
						case "EntityId":
							messageData.message.EntityId = item.Value;
							break;
						case "Message":
							messageData.message.Message = item.Value;
							break;
					}
				});
				return messageData;
			},

			/**
			 * @private
			 */
			_publishMessage: function() {
				var messageData = this._getMessageData();
				ServiceHelper.callService({
					"serviceName": "EsnService",
					"methodName": "PostMessage",
					"data": messageData,
					"callback": function(response) {
						if(response.success) {
							this.set("PrimaryColumnValue", response.Id);
						}
						this.onPublished({
							PublishMessageResult: response
						});
					},
					"scope": this
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#initDefaultValues
			 * @overridden
			 */
			initDefaultValues: function() {
				this.callParent(arguments);
				var writePostHint = BPMSoft.isCurrentUserSsp()
					? this.get("Resources.Strings.WritePostHintOnPortal")
					: this.get("Resources.Strings.WritePostHint");
				this.set("WritePostHintText", writePostHint);
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getServiceConfig
			 * @overridden
			 */
			getServiceConfig: function() {
				return {
					className: "BPMSoft.Configuration.SocialMessagePublisher"
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onPublished
			 * @overridden
			 */
			onPublished: function() {
				var id = this.get("PrimaryColumnValue");
				var message = this.get("Message");
				var socialMessage = {
					id: id,
					message: message
				};
				this.addSocialMention(socialMessage);
				this.set("Message", "");
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishMaskCaption
			 * @overridden
			 */
			getPublishMaskCaption: function() {
				return this.get("Resources.Strings.SocialMaskCaption");
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onNewCardSaved
			 * @overridden
			 */
			onNewCardSaved: function() {
				if (!this.get("Message")) {
					return;
				}
				this.publishMessage();
			},

			/**
			 * Check whether Template button enabled
			 * Returns true if button enabled.
			 */
			isTemplateButtonVisible: function() {
				return this.getIsFeatureEnabled("UseTemplatesInSocialFeed");
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishData
			 * @overridden
			 */
			getPublishData: function() {
				var publishData = this.callParent(arguments) || [];
				var message = this.get("Message");
				publishData.push({"Key": "Message", "Value": message});
				return publishData;
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#isNeedToBePublished
			 * @overridden
			 */
			isNeedToBePublished: function() {
				return Boolean(this.get("Message"));
			},

			/**
			 * @inheritdoc BPMSoft.BaseMessagePublisherPage#publishMessage
			 * @overridden
			 */
			publishMessage: function() {
				if (BPMSoft.Features.getIsEnabled("UseEsnRights")) {
					this._publishMessage();
				} else {
					this.callParent(arguments);
				}
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"parentName": "ModulePageContainer",
				"name": "BodyContainer",
				"propertyName": "items",
				"values": {
					"id": "SocialMessageBodyContainer",
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["body-container"]
				}
			},
			{
				"operation": "insert",
				"name": "SocialMessagePublisherEdit",
				"parentName": "BodyContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"className": "BPMSoft.ESNHtmlEdit",
					"itemType": this.BPMSoft.ViewItemType.MODEL_ITEM,
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"contentType": this.BPMSoft.ContentType.RICH_TEXT,
					"labelConfig": {
						"visible": false
					},
					"value": {
						"bindTo": "Message"
					},
					"placeholder": {
						"bindTo": "WritePostHintText"
					},
					"classes": {
						"htmlEditClass": ["postMessage", "placeholderOpacity"]
					},
					"markerValue": "SocialMessagePublisherEdit",
					"prepareList": {bindTo: "prepareEntitiesExpandableList"},
					"list": {bindTo: "entitiesList"},
					"listViewItemRender": {bindTo: "onEntitiesListViewItemRender"},
					"height": "100px",
					"autoGrow": true,
					"autoGrowMinHeight": 100
				}
			},
			{
				"operation": "insert",
				"name": "TemplateButton",
				"propertyName": "items",
				"parentName": "PublisherBottomContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"controlConfig": {
						"menu": {
							"items": {"bindTo": "TemplateMenuCollection"}
						}
					},
					"imageConfig": {
						"bindTo": "Resources.Images.TemplateButtonImage"
					},
					"hint": {
						"bindTo": "Resources.Strings.TemplateButtonCaption"
					},
					"visible": {
						"bindTo": "isTemplateButtonVisible"
					},
					"enabled": {
						"bindTo": "IsPublishButtonEnabled"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
