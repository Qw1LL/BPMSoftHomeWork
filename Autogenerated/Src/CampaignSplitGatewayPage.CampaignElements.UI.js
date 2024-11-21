 /**
 * Schema of Campaign split gateway element page.
 */
define("CampaignSplitGatewayPage", ["CampaignSplitGatewayPageResources", "CampaignSplitGatewayItemViewModel",
		"css!CampaignSplitGatewayPageCSS"],
	function(resources) {
		return {
			attributes: {
				"Distribution": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},
				"Flows": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: new BPMSoft.BaseViewModelCollection()
				},
				"CanChangeValue": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: true
				},
				"IsEqualized": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					onChange: "isEqualizedChanged"
				}
			},
			messages: {
			},
			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin"
			},
			methods: {

				/**
				 * @private
				 */
				_getNeighbour: function(id, excluded) {
					var neighbour;
					var collection = this.$Flows.filterByFn(function(el) {
						return !Ext.Array.contains(excluded, el.$Id);
					});
					var index = collection.indexOfKey(id);
					if (collection.getCount() > (index + 1)) {
						neighbour = collection.getByIndex(index + 1);
					} else if (index > 0) {
						neighbour = collection.getByIndex(index - 1);
					} else {
						neighbour = null;
					}
					if (neighbour) {
						excluded.push(neighbour.$Id);
					}
					return neighbour;

				},

				/**
				 * @private
				 */
				_decreaseNeighbours: function(id, excluded, totalDiff) {
					var neighbour = this._getNeighbour(id, excluded);
					if (neighbour) {
						var oldValue = neighbour.$Value;
						var part = oldValue + totalDiff;
						if (part < 1) {
							neighbour.$Value = 1;
							totalDiff += oldValue - 1;
						} else {
							neighbour.$Value += totalDiff;
							totalDiff = 0;
						}
						if (totalDiff < 0) {
							this._decreaseNeighbours(id, excluded, totalDiff);
						}
					}
				},

				/**
				 * @private
				 */
				_isDistributionEqualized: function(keys) {
					var result = true;
					var part = this.$Distribution[keys[0]];
					for (prop in this.$Distribution) {
						result &= this.$Distribution[prop] === part;
					}
					return result;
				},

				/**
				 * Fills Flows attribute collection.
				 * @private
				 * @param {BPMSoft.CampaignSplitGatewayElementSchema} element Current split gateway element.
				 */
				_fillFlowsCollection: function(element) {
					this.$Flows.clear();
					var flows = element.getOutgoingsSequenceFlows();
					BPMSoft.each(flows, function(flow) {
						var model = new BPMSoft.CampaignSplitGatewayItemViewModel({
							values: {
								Id: flow.uId,
								ElementIcon: this.getTargetElementIcon(flow),
								ElementCaption: this.getTargetElementCaption(flow),
								Value: this.$Distribution[flow.transitionId] || 0,
								CanChangeValue: !this.$IsEqualized,
								TransitionId: flow.transitionId
							},
							parentViewModel: this
						});
						this.$Flows.add(flow.uId, model);
					}, this);
				},

				/**
				 * @private
				 */
				_isAnyOutgoingFlow: function() {
					return this.$Flows.getCount() > 0;
				},

				/**
				 * @private
				 */
				_isEqualizeEnabled: function() {
					var isEqualizeEnabled = this.$Flows.getCount() > 1 && this.$Flows.getCount() < 100;
					if (!isEqualizeEnabled) {
						this.$IsEqualized = true;
					}
					return isEqualizeEnabled;
				},

				/**
				 * @private
				 */
				_isBlankSlateVisible: function() {
					return this.$Flows.isEmpty();
				},

				/**
				 * @private
				 */
				_refreshDescriptions: function() {
					var flows = this.$ProcessElement.getOutgoingsSequenceFlows();
					BPMSoft.each(flows, function(flow) {
						var value = this.$Distribution[flow.transitionId];
						this.$ProcessElement.updateFlowDescription(flow, value);
					}, this);
				},

				/**
				 * Returns caption of the target element by outgoing flow.
				 * @protected
				 * @param {BPMSoft.CampaignSplitGatewayTransitionSchema} flow Outgoing transition schema.
				 * @returns {String}
				 */
				getTargetElementCaption: function(flow) {
					var target = flow.findTargetElement();
					if (target && target.caption) {
						return target.caption.toString();
					}
					return "";
				},

				/**
				 * Returns small image of the target element by outgoing flow.
				 * @protected
				 * @param {BPMSoft.CampaignSplitGatewayTransitionSchema} flow Outgoing transition schema.
				 * @returns {Object}
				 */
				getTargetElementIcon: function(flow) {
					var target = flow.findTargetElement();
					if (target && target.smallImage) {
						return BPMSoft.ImageUrlBuilder.getUrl(target.smallImage);
					}
					return null;
				},

				/**
				 * Returns true if distribution is valid and no need to recalculate.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} flows Collection of outgoing flow view models.
				 * @returns {Boolean}
				 */
				validateDistribution: function(flows) {
					var transitionIds = flows
						.map(function(el) { return el.transitionId; })
						.sort();
					var distributionKeys = [];
					var sum = 0;
					for (var prop in this.$Distribution) {
						if (this.$Distribution.hasOwnProperty(prop)) {
							sum += this.$Distribution[prop];
							distributionKeys.push(prop);
						}
					}
					return Ext.Array.equals(transitionIds, distributionKeys.sort())
						&& (flows.length === 0
							|| (this.$IsEqualized && this._isDistributionEqualized(distributionKeys))
							|| (!this.$IsEqualized && sum === 100));
				},

				/**
				 * Refreshes distribution with outgoing flows collection state.
				 * @protected
				 */
				refreshDistribution: function() {
					var distribution = {};
					BPMSoft.each(this.$Flows, function(flow) {
						distribution[flow.$TransitionId] = flow.$Value;
					}, this);
					this.$Distribution = distribution;
					this.actualizeDistribution(this.$ProcessElement);
					this._refreshDescriptions();
				},

				/**
				 * Validates distribution and applies equalize operation for invalid state.
				 * @protected
				 * @param {BPMSoft.CampaignSplitGatewayElementSchema} element Current split gateway element.
				 */
				actualizeDistribution: function(element) {
					var flows = element.getOutgoingsSequenceFlows();
					if (!this.validateDistribution(flows)) {
						this.$Distribution = element.getEqualizedDistribution(this.$IsEqualized);
					}
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#initParameters
				 * @override
				 */
				initParameters: function(element) {
					this.callParent(arguments);
					this.$IsEqualized = !element.useCustomDistribution;
					this.$Distribution = JSON.parse(element.distribution) || {};
					this.actualizeDistribution(element);
					this._fillFlowsCollection(element);
					this._refreshDescriptions();
				},

				/**
				 * @inheritdoc BPMSoft.ProcessFlowElementPropertiesPage#saveValues
				 * @override
				 */
				saveValues: function() {
					this.callParent(arguments);
					var element = this.$ProcessElement;
					this.actualizeDistribution(element);
					element.saveDistribution(this.$Distribution);
					element.useCustomDistribution = !this.$IsEqualized;
					this.highlightFlow(null, false);
				},

				/**
				 * Handler on equalized attribute change event.
				 * @param {Object} model Changed model.
				 * @param {Number} value New value.
				 */
				isEqualizedChanged: function(model, value) {
					this.$Distribution = this.$ProcessElement.getEqualizedDistribution(value);
					BPMSoft.each(this.$Flows, function(flow) {
						flow.$CanChangeValue = !value;
						flow.$Value = this.$Distribution[flow.$TransitionId];
					}, this);
					this.actualizeDistribution(this.$ProcessElement);
					this._refreshDescriptions();
				},

				/**
				 * Returns collection list item view config.
				 * @protected
				 * @param {Object} itemConfig Item view config.
				 * @param {Object} item View item to render.
				 * @returns {Object}
				 */
				getFlowItemViewConfig: function(itemConfig, item) {
					if (item.getViewConfig) {
						itemConfig.config = item.getViewConfig();
					}
					return itemConfig;
				},

				/**
				 * Handler on Flows collection item view model change event.
				 * @public
				 * @param {Object} changed Changes of value from list item view model.
				 */
				onFlowValueChanged: function(changed) {
					var oldValue = this.$Distribution[changed.transitionId];
					if (changed.value === oldValue) {
						return;
					}
					var diff = oldValue - changed.value;
					if (diff > 0) {
						var neighbour = this._getNeighbour(changed.id, []);
						neighbour.$Value += diff;
					} else {
						this._decreaseNeighbours(changed.id, [], diff);
					}
					this.refreshDistribution();
				},

				/**
				 * Highlights selected connection on diagram.
				 * @protected
				 * @param {Guid} connectionUId Unique identifier of selected connection.
				 * @param {Boolean} state Selection state.
				 */
				highlightFlow: function(connectionUId, state) {
					this.$ProcessElement.highlightFlow(connectionUId, state);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "SplitGatewayPropertiesContainer",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateContainer",
					"parentName": "SplitGatewayPropertiesContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": "$_isBlankSlateVisible",
						"classes": {
							"wrapClassName": ["blank-slate-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SplitGatewayBlankSlateImage",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"iconAlign": this.BPMSoft.controls.ButtonEnums.iconAlign.TOP,
						"imageConfig": "$Resources.Images.BlankSlateImage",
						"classes": {
							"wrapperClass": ["blank-slate-wrap"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SplitGatewayBlankSlateLabel",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"highlightText": "$Resources.Strings.BlankSlateDetailsHighlight",
						"caption": "$Resources.Strings.BlankSlateDetails",
						"classes": {
							"labelClass": ["label-details"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SplitGatewayPropertiesContainer",
					"propertyName": "items",
					"name": "SplitGatewayPropertiesLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": "$_isAnyOutgoingFlow"
					}
				},
				{
					"operation": "insert",
					"name": "ElementPropertiesLabel",
					"parentName": "SplitGatewayPropertiesLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 22
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.PageCaption",
						"classes": {"labelClass": ["t-title-label-proc"]}
					}
				},
				{
					"name": "SplitGatewayPropertiesHint",
					"operation": "insert",
					"parentName": "SplitGatewayPropertiesLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 22,
							"row": 1,
							"colSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.SplitGatewayPropertiesHint",
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-checkbox-information-button"
							},
							"imageConfig": {
								"bindTo": "Resources.Images.InfoButtonImage"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "FlowsContainer",
					"parentName": "SplitGatewayPropertiesLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["flows-container"]
					}
				},
				{
					"operation": "insert",
					"name": "FlowsListContainer",
					"parentName": "FlowsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.ContainerList",
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "Flows",
						"onGetItemConfig": "getFlowItemViewConfig",
						"itemPrefix": "flowItem",
						"classes": {
							"wrapClassName": ["flows-list-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "IsEqualized",
					"parentName": "SplitGatewayPropertiesLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"markerValue": "EqualizeSplitCheckbox",
						"caption": "$Resources.Strings.EqualizeSplitCheckboxLabelCaption",
						"wrapClass": ["t-checkbox-control"],
						"enabled": "$_isEqualizeEnabled"
					}
				}
			]
		};
	}
);
