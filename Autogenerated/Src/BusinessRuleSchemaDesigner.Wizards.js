define("BusinessRuleSchemaDesigner", ["BusinessRuleSchemaDesignerResources", "css!BusinessRuleSchemaDesignerCSS",
	"BusinessRuleCaseDesignerViewModel", "BusinessRuleCaseDesignerCollectionContainer", "SysModuleEntityManager",
	"SysModuleEditManager", "SectionManager", "BusinessRuleSchemaManager", "BusinessRuleConverter", "ImageView",
	"BusinessRuleCaptionGenerator"
], function() {
	return {
		mixins: {
			/**
			 * Mixin for view model, that contains reorderable logic.
			 */
			ReorderableContainerVMMixin: "BPMSoft.ReorderableContainerVMMixin"
		},
		attributes: {
			/**
			 * Business rule caption.
			 */
			"Caption": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"size": 250,
				"isRequired": true,
				"value": null
			},

			/**
			 * Business rule description.
			 */
			"Description": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": null
			},

			/**
			 * Page, that contains business rule.
			 */
			"Page": {
				"dataValueType": BPMSoft.DataValueType.ENUM,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"value": null
			},

			/**
			 * Page list.
			 */
			"PageList": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Business rule manager item UId.
			 */
			"BusinessRuleManagerItem": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Module entity manager item UId.
			 */
			"SysModuleEntityManagerItem": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Business rule schema.
			 */
			"BusinessRuleSchema": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Flag indicating that the schema is changed.
			 */
			"IsBusinessRuleChanged": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Flag indicating that the module entity contain mann edit pages.
			 */
			"IsMultiPage": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Case view model class name.
			 */
			"CaseViewModelClassName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": "BPMSoft.BusinessRuleCaseDesignerViewModel"
			},

			/**
			 * Flag indicating that the business rule is new.
			 */
			"IsNewBusinessRule": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Current schema package identifier.
			 */
			"PackageUId": {
				"dataValueType": BPMSoft.DataValueType.GUID,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * UId of business rule entity schema.
			 */
			"BusinessRuleEntitySchemaUId": {
				"dataValueType": BPMSoft.DataValueType.GUID,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		messages: {
			/**
			 * @message GetModuleConfigDesigner
			 * For publish require designer config.
			 */
			"GetModuleConfigDesigner": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetModuleConfigResultDesigner
			 * For subscribe on response designer config.
			 */
			"GetModuleConfigResultDesigner": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message CloseBusinessRuleDesigner
			 * For subscribe on designer close.
			 */
			"CloseBusinessRuleDesigner": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		methods: {

			/**
			 * Returns converted module edit manager items to lookup value.
			 * @private
			 * @param {BPMSoft.Collection} sysModuleEditManagerItems Collection of sys module edit manager item.
			 * @return {Object} Lookup values.
			 */
			convertSysModuleEditManagerItemsToLookupValue: function(sysModuleEditManagerItems) {
				var items = {};
				sysModuleEditManagerItems.each(function(managerItem) {
					var cardSchemaUId = managerItem.getCardSchemaUId();
					var pageCaption = managerItem.getPageCaption();
					if (this.Ext.isEmpty(items[cardSchemaUId])) {
						items[cardSchemaUId] = {
							value: cardSchemaUId,
							displayValue: pageCaption
						};
					} else {
						items[cardSchemaUId].displayValue += ", " + pageCaption;
					}
				}, this);
				return items;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.showBodyMask();
				this.callParent([function() {
					var sandbox = this.sandbox;
					this.mixins.ReorderableContainerVMMixin.preInit.call(this);
					this.initDesignerSchemaProperties();
					sandbox.subscribe("GetModuleConfigResultDesigner", this.onGetModuleConfigResultDesigner,
						this, [sandbox.id]);
					sandbox.publish("GetModuleConfigDesigner", null, [sandbox.id]);
					this.hideBodyMask();
					this.on("change", this.onDesignerDataChange, this);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Designer change handler.
			 * @protected
			 */
			onDesignerDataChange: function() {
				this.set("IsBusinessRuleChanged", true);
			},

			/**
			 * Processes getting grid configuration.
			 * @protected
			 * @param {Object} config
			 * @param {BPMSoft.manager.BusinessRuleSchemaManagerItem} config.businessRuleItem
			 * @param {String} config.entitySchemaId Entity schema id.
			 * @param {Boolean} config.isMultiPage
			 * @param {Boolean} config.isNew
			 * @param {String} config.packageUId
			 * @param {Guid} config.entitySchemaUId
			 */
			onGetModuleConfigResultDesigner: function(config) {
				const entitySchemaId = config.entitySchemaId;
				if (entitySchemaId) {
					const moduleEntity = BPMSoft.SysModuleEntityManager.getItem(entitySchemaId);
					this.set("SysModuleEntityManagerItem", moduleEntity);
				}
				this.set("BusinessRuleManagerItem", config.businessRuleItem);
				this.set("IsMultiPage", config.isMultiPage);
				this.set("IsNewBusinessRule", config.isNew);
				this.set("PackageUId", config.packageUId);
				this.set("BusinessRuleEntitySchemaUId", config.entitySchemaUId);
				this.setEditPageCaption(config.businessRuleItem);
				this.prepareBusinessRuleSchema();
			},

			/**
			 * Sets edit page caption.
			 * @protected
			 * @param {BPMSoft.manager.BusinessRuleSchemaManagerItem} businessRuleItem
			 */
			setEditPageCaption: function(businessRuleItem) {
				var clientUnitSchemaUId = businessRuleItem.getClientUnitSchemaUId();
				if (!clientUnitSchemaUId) {
					return;
				}
				var sysModuleEditItems = BPMSoft.SysModuleEditManager.filterByFn(function(item) {
					return item.getCardSchemaUId() === clientUnitSchemaUId;
				}, this);
				if (sysModuleEditItems.getCount()) {
					var items = this.convertSysModuleEditManagerItemsToLookupValue(sysModuleEditItems);
					this.set("Page", items[clientUnitSchemaUId]);
				} else {
					this.set("Page", {value: clientUnitSchemaUId});
				}
			},

			/**
			 * Initialize designer schema properties.
			 * @protected
			 */
			initDesignerSchemaProperties: function() {
				this.set("ViewModelItems", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("PageList", this.Ext.create("BPMSoft.Collection"));
			},

			/**
			 * Prepare business rule designer properties from business rule schema.
			 * @protected
			 */
			prepareBusinessRuleSchema: function() {
				var businessRuleManagerItem = this.get("BusinessRuleManagerItem");
				businessRuleManagerItem.getInstance(function(businessRuleSchema) {
					this.set("BusinessRuleSchema", businessRuleSchema);
					var description = businessRuleSchema.getPropertyValue("description");
					var descriptionValue = description ? description.getValue() : "";
					this.set("Description", descriptionValue);
					this.set("Caption", this.getCaption(businessRuleSchema));
					this.initializeBusinessRuleSwitch(businessRuleSchema.ruleSwitch);
				}, this);
			},

			/**
			 * Returns business rule caption.
			 * @param {BPMSoft.BusinessRuleManagerItem} schema BusinessRuleSchema.
			 * @return {String} Caption.
			 */
			getCaption: function(schema) {
				return this.get("IsNewBusinessRule")
					? this.get("Resources.Strings.NewBusinessRuleCaption")
					: schema.getCaption();
			},

			/**
			 * Initialize business rule designer view model from business rule swith.
			 * @protected
			 * @param {BPMSoft.BusinessRuleSwitch} ruleSwitch Business rule switch.
			 */
			initializeBusinessRuleSwitch: function(ruleSwitch) {
				var caseCollection = this.get("ViewModelItems");
				if (!this.Ext.isEmpty(ruleSwitch.cases)) {
					this.BPMSoft.each(ruleSwitch.cases, function(caseMetaItem) {
						this.addSpecifiedCaseToCollection(caseCollection, {
							"Id": this.BPMSoft.generateGUID(),
							"MetaItem": caseMetaItem
						});
					}, this);
				} else {
					this.addSpecifiedCaseToCollection(caseCollection, {
						"Id": this.BPMSoft.generateGUID()
					});
				}
			},

			/**
			 * Adds case to collection with specified config.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} caseCollection Case collection.
			 * @param {Object} caseConfig Case config.
			 */
			addSpecifiedCaseToCollection: function(caseCollection, caseConfig) {
				var caseViewModel = this.createBusinessRuleCaseViewModel(caseConfig);
				caseCollection.add(caseViewModel.get("Id"), caseViewModel);
			},

			/**
			 * Create business rule case designer view model.
			 * @protected
			 * @param {Object} values Business View model values.
			 * @return {BPMSoft.BusinessRuleCaseDesignerViewModel} Case designer view model.
			 */
			createBusinessRuleCaseViewModel: function(values) {
				var entitySchemaUId = this.getBusinessRuleEntitySchemaUId();
				var className = this.get("CaseViewModelClassName");
				var page = this.get("Page");
				var viewModel = this.Ext.create(className, {
					"Ext": this.Ext,
					"BPMSoft": this.BPMSoft,
					"sandbox": this.sandbox,
					"entitySchemaUId": entitySchemaUId,
					"pageSchemaUId": page && page.value,
					"packageUId": this.$PackageUId,
					"values": values
				});
				viewModel.on("change", this.onCaseViewModelChange, this);
				viewModel.on("pullChanges", this._onPullChanges, this);
				return viewModel;
			},

			/**
			 * Returns business rules entity schema UId.
			 * @protected
			 * @returns {Guid} Entity schema UId.
			 */
			getBusinessRuleEntitySchemaUId: function() {
				var entitySchemaUId = this.get("BusinessRuleEntitySchemaUId");
				if (!this.Ext.isEmpty(entitySchemaUId)) {
					return entitySchemaUId;
				}
				var moduleEntityItem = this.get("SysModuleEntityManagerItem");
				return moduleEntityItem && moduleEntityItem.getEntitySchemaUId();
			},

			onCaseViewModelChange: function() {
				this.fireEvent("change");
			},

			/**
			 * Prepare page list.
			 * @protected
			 * @param {String} filter Lookup filter.
			 * @param {BPMSoft.Collection} list Page collection.
			 */
			preparePageList: function(filter, list) {
				var sysModuleEntityManagerItem = this.get("SysModuleEntityManagerItem");
				sysModuleEntityManagerItem.getSysModuleEditManagerItems(function(collection) {
					var items = this.convertSysModuleEditManagerItemsToLookupValue(collection);
					list.loadAll(items);
				}, this);
			},

			/**
			 * Update business rule schema properties.
			 * @protected
			 */
			updateMetaItem: function(callback, scope) {
				this.updateMetaItemChildCollection("ruleSwitch", "ViewModelItems", callback, scope);
			},

			/**
			 * Update meta item child.
			 * @protected
			 * @param {String} metaItemPropertyName Meta item property name.
			 * @param {String} childCollectionName View model collection attribute name.
			 * @param {Function} callback Callback method.
			 * @param {Object} scope Callback method context.
			 */
			updateMetaItemChildCollection: function(metaItemPropertyName, childCollectionName, callback, scope) {
				var schema = this.get("BusinessRuleSchema");
				var collection = this.get(childCollectionName);
				var metaItemElement = schema[metaItemPropertyName];
				var items = [];
				BPMSoft.eachAsync(
					collection.getItems(),
					function(item, next) {
						item.updateMetaItem(function() {
							items.push(item.getMetaItem());
							next();
						}, this);
					},
					function() {
						metaItemElement.cases = items;
						schema.fireEvent("changed");
						callback.call(scope);
					}, this);
			},

			/**
			 * Saves client unit schema UId.
			 * @protected
			 */
			saveEditPage: function() {
				var businessRuleManagerItem = this.get("BusinessRuleManagerItem");
				var page = this.get("Page");
				businessRuleManagerItem.setClientUnitSchemaUId(page.value);
			},

			/**
			 * Saves manager item.
			 * @protected
			 */
			saveManagerItem: function() {
				var schema = this.get("BusinessRuleSchema");
				var businessRuleManagerItem = this.get("BusinessRuleManagerItem");
				businessRuleManagerItem.setInstance(schema);
			},

			/**
			 * Apply button click handler.
			 * @protected
			 */
			onApplyButtonClick: function() {
				if (!this.validate()) {
					return;
				}
				this.showBodyMask();
				this.asyncValidate(this.onAsyncValidate, this);
			},

			/**
			 * Async validate view model handler.
			 * @param  {Object} validateInfo Validate info.
			 */
			onAsyncValidate: function(validateInfo) {
				if (validateInfo && !validateInfo.isValid) {
					var message = validateInfo.messageList.join(";\n") + ".";
					this.showErrorInformation(message);
				} else {
					var businessRuleCaptionGenerator = this.getBusinessRuleCaptionGenerator();
					var schema = this.get("BusinessRuleSchema");
					BPMSoft.chain(
						this.updateMetaItem,
						function(next) {
							businessRuleCaptionGenerator.generateUniqueCaption(schema, next, this);
						},
						function(next, generatedCaption) {
							businessRuleCaptionGenerator.updateSchemaCaption(
								schema, generatedCaption, this.get("IsNewBusinessRule"));
							this.saveEditPage();
							this.saveManagerItem();
							this.hideBodyMask();
							this.sandbox.publish("CloseBusinessRuleDesigner", this.get("BusinessRuleManagerItem"),
								[this.sandbox.id]);
						},
						this
					);
				}
			},

			/**
			 * Return business rule caption generator.
			 * @protected
			 * @return {BPMSoft.BusinessRuleCaptionGenerator} Business rule caption generator.
			 */
			getBusinessRuleCaptionGenerator: function() {
				return Ext.create("BPMSoft.BusinessRuleCaptionGenerator");
			},

			/**
			 * Shows erorr information.
			 * @param {String} message Error message.
			 */
			showErrorInformation: function(message) {
				message = message || "";
				BPMSoft.showInformation(message, function() {
					this.hideBodyMask();
				}, this);
			},

			/**
			 * Async validate cases.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			asyncValidate: function(callback, scope) {
				var caseCollection = this.get("ViewModelItems");
				var items = caseCollection.getItems();
				BPMSoft.eachAsync(
					items,
					function(item, next) {
						item.asyncValidate(next, this);
					},
					function(validateInfo) {
						callback.call(scope, validateInfo);
					}, this);
			},

			/**
			 * Cancel button click handler.
			 * @protected
			 */
			onCancelButtonClick: function() {
				var sandbox = this.sandbox;
				sandbox.publish("CloseBusinessRuleDesigner", null, [sandbox.id]);
			},

			/**
			 * Close button click handler.
			 * @protected
			 */
			onCloseButtonClick: function() {
				var sandbox = this.sandbox;
				sandbox.publish("CloseBusinessRuleDesigner", null, [sandbox.id]);
			},

			/**
			 * Returns logo configuration.
			 * @param {String} logoName Logo name.
			 * @return {Object} Logo configuration.
			 */
			getBusinessRuleLogoImageConfig: function(logoName) {
				var config = {
					params: {
						r: logoName
					},
					source: this.BPMSoft.ImageSources.SYS_SETTING
				};
				return this.BPMSoft.ImageUrlBuilder.getUrl(config);
			},

			/**
			 * Return caption label caption.
			 * @protected
			 * @return {String} Caption label caption.
			 */
			getCaptionLabelCaption: function() {
				return this.get("IsNewBusinessRule")
					? this.get("Resources.Strings.CaptionLabelCaptionNew")
					: this.get("Resources.Strings.CaptionLabelCaption");
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.un("pullChanges", this._onPullChanges, this);
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_onPullChanges: function(config) {
				if (config.actionType === "PullPageSchemaUId") {
					config.sourceElement.pageSchemaUId = this.$Page && this.$Page.value;
				}
			},

			/**
			 * Returns availability for editing of page property.
			 * @return {Boolean}
			 */
			getIsPageEnabled: function() {
				return this.$IsNewBusinessRule && !this.$Page;
			}

		},
		diff: /**SCHEMA_DIFF*/[{
			"operation": "insert",
			"name": "BusinessRuleDesignerContainer",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": ["business-rule-designer-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleDesignerHeaderContainer",
			"parentName": "BusinessRuleDesignerContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": ["business-rule-designer-header-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleDesignerMainContainer",
			"parentName": "BusinessRuleDesignerContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": ["business-rule-designer-main-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleDesignerFooterContainer",
			"parentName": "BusinessRuleDesignerContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": ["business-rule-designer-footer-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleGeneralContainer",
			"parentName": "BusinessRuleDesignerMainContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": [
						"business-rule-box-container",
						"business-rule-general-container",
						"business-rule-island-container"
					]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleSwitchWrapperContainer",
			"parentName": "BusinessRuleDesignerMainContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": [
						"business-rule-box-container",
						"business-rule-switch-container"
					]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleHeaderLabel",
			"parentName": "BusinessRuleGeneralContainer",
			"propertyName": "items",
			"index": 1,
			"values": {
				"itemType": this.BPMSoft.ViewItemType.LABEL,
				"caption": {"bindTo": "Resources.Strings.DesignerHeaderCaption"}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleButtonsContainer",
			"parentName": "BusinessRuleDesignerFooterContainer",
			"propertyName": "items",
			"index": 2,
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": [
						"business-rule-buttons-container"
					]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleRightLogoContainer",
			"parentName": "BusinessRuleDesignerHeaderContainer",
			"propertyName": "items",
			"index": 3,
			"values": {
				"id": "main-header-logo-container",
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["main-header-logo-container-class"],
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleLogoImage",
			"parentName": "BusinessRuleRightLogoContainer",
			"propertyName": "items",
			"values": {
				"id": "BusinessRuleLogoImage",
				"itemType": this.BPMSoft.ViewItemType.COMPONENT,
				"selectors": {
					"wrapEl": "#logoImage"
				},
				"className": "BPMSoft.ImageView",
				"imageSrc": {"bindTo": "getBusinessRuleLogoImageConfig"},
				"tag": "HeaderLogoImage"
			}
		}, {
			"operation": "insert",
			"name": "ApplyButton",
			"parentName": "BusinessRuleButtonsContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.BUTTON,
				"caption": {"bindTo": "Resources.Strings.ApplyButtonCaption"},
				"click": {"bindTo": "onApplyButtonClick"},
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"visible": {"bindTo": "IsBusinessRuleChanged"}
			}
		}, {
			"operation": "insert",
			"name": "CancelButton",
			"parentName": "BusinessRuleButtonsContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.BUTTON,
				"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
				"click": {"bindTo": "onCancelButtonClick"},
				"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				"visible": {"bindTo": "IsBusinessRuleChanged"}
			}
		}, {
			"operation": "insert",
			"name": "CloseButton",
			"parentName": "BusinessRuleButtonsContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.BUTTON,
				"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
				"click": {"bindTo": "onCloseButtonClick"},
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"visible": {
					"bindTo": "IsBusinessRuleChanged",
					"bindConfig": {"converter": "invertBooleanValue"}
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleInfoContainer",
			"parentName": "BusinessRuleGeneralContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "Caption",
			"parentName": "BusinessRuleInfoContainer",
			"propertyName": "items",
			"values": {
				"layout": {
					"column": 0,
					"row": 0,
					"colSpan": 24,
					"rowSpan": 1
				},
				"contentType": this.BPMSoft.ContentType.LONG_TEXT,
				"enabled": false,
				"caption": {"bindTo": "Resources.Strings.CaptionLabelCaption"},
				"value": {
					"bindTo": "Caption"
				},
				"classes": {
					"labelClass": ["business-rule-general-label"],
					"editInputClass": ["business-rule-caption-control"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRulePageContainer",
			"parentName": "BusinessRuleGeneralContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
				"items": [],
				"visible": {"bindTo": "IsMultiPage"},
				"classes": {
					"wrapClassName": ["business-rule-island-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "Page",
			"parentName": "BusinessRulePageContainer",
			"propertyName": "items",
			"values": {
				"layout": {
					"column": 0,
					"row": 0,
					"colSpan": 24,
					"rowSpan": 1
				},
				"caption": {"bindTo": "Resources.Strings.PageGroupCaption"},
				"enabled": {
					"bindTo": "getIsPageEnabled"
				},
				"value": {
					"bindTo": "Page"
				},
				"classes": {
					"labelClass": ["business-rule-general-label"]
				},
				"controlConfig": {
					"list": {"bindTo": "PageList"},
					"prepareList": {"bindTo": "preparePageList"}
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleSwitchContainer",
			"parentName": "BusinessRuleSwitchWrapperContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"classes": {
					"wrapClassName": ["business-rule-island-container"]
				}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleTriggerContainer",
			"parentName": "BusinessRuleSwitchContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"visible": false
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleCaseCollectionContainer",
			"parentName": "BusinessRuleSwitchContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"className": "BPMSoft.BusinessRuleCaseDesignerCollectionContainer",
				"items": [],
				"viewModelItems": {"bindTo": "ViewModelItems"}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleCaseDefaultContainer",
			"parentName": "BusinessRuleSwitchContainer",
			"propertyName": "items",
			"values": {
				"itemType": this.BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"visible": false
			}
		}]/**SCHEMA_DIFF*/
	};
});
