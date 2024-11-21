define("DynamicContentAttributesPropertiesPage", ["DynamicContentAttributesPropertiesPageResources",
		"AttributeContainerListItemViewModel", "ObservableContainerList"],
	function() {
		return {
			modules: {

				/**
				 * Defines module for edit attribute settings.
				 */
				DynamicContentAttributeSettingsModule: {
					moduleId: "DynamicContentAttributeSettingsModule",
					moduleName: "ConfigurationModuleV2",
					config: {
						schemaName: "DynamicContentAttributeSettingsPage",
						isSchemaConfigInitialized: true,
						useHistoryState: false
					}
				}
			},
			messages: {

				/**
				 * Publishes when need add one more attribute to collection.
				 */
				"DCAttributeAdd": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * Publishes when selected attribute properties changed.
				 */
				"DCAttributeUpdated": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Request for delete attribute.
				 */
				"DCAttributeDelete": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * Listens when attribute deletes from main attribute collection.
				 */
				"DCAttributeDeleted": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * Gets all attribute items for initialize collection.
				 */
				"GetDCAttributes": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * Sets selected attribute in collection to DynamicContentAttributeSettingsPage for edit.
				 */
				"SetSelectedAttribute": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Local collection of attributes. Needs to bind to observable collection.
				 */
				"DCAttributesCollection": {
					"dataValueType": BPMSoft.core.enums.DataValueType.COLLECTION,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Maximum allowed number of rules.
				 */
				"RulesLimit": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 7
				},

				/**
				 * Sign for rules count. True when rules count reaches the limit.
				 */
				"IsRulesLimitReached": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				// #region Methods: Private

				_subscribeOnMessages: function() {
					this.sandbox.subscribe("DCAttributeUpdated", this.onAttributeUpdated, this);
					this.sandbox.subscribe("DCAttributeDeleted", this.onAttributeDeleted, this);
				},

				_findAttributeById: function(id) {
					return this.$DCAttributesCollection.findByFn(function(item) {
						return item.$Item.Id === id;
					}, this);
				},

				_attributeToListItemViewModel: function(item) {
					var id = BPMSoft.generateGUID();
					var viewModelItem = this.Ext.create("BPMSoft.AttributeContainerListItemViewModel", {
						values: {
							Caption: item.Caption,
							Id: id,
							Index: item.Index
						}
					});
					viewModelItem.sandbox = this.sandbox;
					viewModelItem.initModel(id, item.Caption, false, item);
					return viewModelItem;
				},

				_setAttributesCollection: function(items) {
					var viewModelCollection = Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(items, function(item) {
						var viewModelItem = this._attributeToListItemViewModel(item);
						viewModelCollection.add(item.Index, viewModelItem);
					}, this);
					this.$DCAttributesCollection.clear();
					this.$DCAttributesCollection.loadAll(viewModelCollection);
				},

				_isRulesLimitReached: function(rulesCount) {
					return rulesCount >= this.$RulesLimit;
				},

				// #endregion

				// #region Methods: Protected

				/**
				 * @inheritDoc BaseSchemaViewModel#init
				 * @protected
				 */
				init: function() {
					this.callParent(arguments);
					if (BPMSoft.isEmpty(this.$DCAttributesCollection)) {
						this.$DCAttributesCollection = Ext.create("BPMSoft.BaseViewModelCollection");
						var attributes = this.sandbox.publish("GetDCAttributes");
						this._setAttributesCollection(attributes);
					}
					this.$IsRulesLimitReached = this._isRulesLimitReached(this.$DCAttributesCollection.getCount());
					this._subscribeOnMessages();
				},

				/**
				 * Handles changes of attribute properties.
				 * @protected
				 * @param attribute Instance of attribute model which was changed.
				 */
				onAttributeUpdated: function(attribute) {
					var changedItem = this._findAttributeById(attribute.Id);
					changedItem.$Caption = attribute.Caption;
				},

				/**
				 * Handles DCAttributeDeleted message.
				 * @protected
				 * @param attribute Instence of deleted attribute.
				 */
				onAttributeDeleted: function(attribute) {
					var itemForDeleted = this._findAttributeById(attribute.Id);
					this.$DCAttributesCollection.remove(itemForDeleted);
					this.$IsRulesLimitReached = this._isRulesLimitReached(this.$DCAttributesCollection.getCount());
				},

				/**
				 * Handles add button click for attribute.
				 * @protected
				 */
				onAddAttributeClick: function() {
					var newItem = this.sandbox.publish("DCAttributeAdd");
					var vm = this._attributeToListItemViewModel(newItem);
					BPMSoft.each(this.$DCAttributesCollection, function(attr) {
						attr.$Selected = false;
					}, this);
					this.$DCAttributesCollection.add(vm);
					this.$IsRulesLimitReached = this._isRulesLimitReached(this.$DCAttributesCollection.getCount());
				},

				/**
				 * Handles changin of selected item in ObservableContainerList.
				 * @protected
				 * @param item Selected attribute item.
				 */
				onSelectedItemChanged: function (item) {
					var itemForSend = item === undefined ? undefined : item.$Item;
					this.sandbox.publish("SetSelectedAttribute", itemForSend,
						[this.modules.DynamicContentAttributeSettingsModule.moduleId]);
				}

				// #endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "AttributesPropertiesPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["dc-properties-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributesContainer",
					"parentName": "AttributesPropertiesPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["attributes-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributesLabel",
					"parentName": "AttributesContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.AttributesCollectionLabel",
						"classes": {
							"labelClass": ["t-title-label-dc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AttributesContainerList",
					"parentName": "AttributesContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.ObservableContainerList",
						"collection": "$DCAttributesCollection",
						"classes": {"wrapClassName": ["attributes-container-list"]},
						"idProperty": "Id",
						"rowCssSelector": ".attribute-item-container-wrap.selectable",
						"onSelectedItemChanged" : {"bindTo":"onSelectedItemChanged"},
						"defaultItemConfig": {
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["attribute-item-container"]
							},
							"items": [{
								"className": "BPMSoft.Label",
								"caption": "$Caption"
							}]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddAttributeGroup",
					"parentName": "AttributesPropertiesPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AddAttributesButton",
					"parentName": "AddAttributeGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 20
						},
						"imageConfig": "$Resources.Images.AddButtonIcon",
						"caption": "$Resources.Strings.AddSegmentButtonCaption",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": "$onAddAttributeClick",
						"enabled": {
							bindTo: "IsRulesLimitReached",
							bindConfig: { converter: "invertBooleanValue" }
						},
						"classes": {
							"wrapperClass": ["add-button-control"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddAttributesHint",
					"parentName": "AddAttributeGroup",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 20,
							"row": 0,
							"colSpan": 2
						},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.MaximumRrulesCountHint",
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-checkbox-information-button"
							},
							"imageConfig": "$Resources.Images.RuleInfoButtonImage",
							"visible": "$IsRulesLimitReached"
						},
						"style": BPMSoft.TipStyle.WHITE,
						"behaviour": {
							"displayEvent": BPMSoft.controls.TipEnums.displayEvent.HOVER
								| BPMSoft.controls.TipEnums.displayEvent.CLICK
						},
						"tools": []
					}
				},
				{
					"operation": "insert",
					"name": "AttributeSettingsContainerLayout",
					"propertyName": "items",
					"parentName": "AttributesPropertiesPageContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["attribute-settings-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DynamicContentAttributeSettingsModule",
					"parentName": "AttributeSettingsContainerLayout",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				}
			]
		};
	});
