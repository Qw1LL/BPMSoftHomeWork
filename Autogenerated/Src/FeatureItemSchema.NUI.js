define("FeatureItemSchema", [], function() {
	return {
		entitySchemaName: "Feature",
		attributes: {
			/**
			 * Feature Enabled.
			 * @private
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"FeatureEnabled": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
			"ActualState": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Is Changed Feature.
			 * @protected
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"IsChangedFeature": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
			"HasStateForGroup": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "FeatureItemContainer",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["feature-item-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureNameWrap",
				"parentName": "FeatureItemContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap", "feature-item-label-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureName",
				"parentName": "FeatureNameWrap",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": ["feature-item-label"]
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Name",
						"bindConfig": {
							"converter": function (value) {
								return value || this.$Code;
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "SwitchFeatureStateButtonWrap",
				"parentName": "FeatureNameWrap",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["feature-state-switch-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureEnabled",
				"parentName": "SwitchFeatureStateButtonWrap",
				"propertyName": "items",
				"values": {
					"bindTo": "FeatureEnabled",
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"classes": ["toggle-feature-state"],
						"className": "BPMSoft.ToggleEdit",
						"checked": {
							"bindTo": "FeatureEnabled"
						},
						"checkedchanged": {
							"bindTo": "onStateChanged"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "FeatureNameWrap",
				"propertyName": "items",
				"name": "HeaderLabelInfoButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {bindTo: "getTipCaption"},
					"controlConfig": {
						"classes": {
							"wrapperClass": "feature-hint-button",
							"imageClass": "feature-hint-image"
						},
						"visible": {
							"bindTo": "HasStateForGroup"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "FeatureDescriptionWrap",
				"parentName": "FeatureItemContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap", "feature-item-label-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FeatureDescription",
				"parentName": "FeatureDescriptionWrap",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": ["feature-item-label", "feature-description"]
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Description"}
				}
			}
		],
		methods: {
			/**
			 * Sets FeatureEnabled attribute according to actual state.
			 * @protected
			 */
			initEnabledState: function() {
				var state = this.get("ActualState");
				var enabled = (state === BPMSoft.FeatureState.ENABLED);
				this.set("FeatureEnabled", enabled);
			},

			/**
			 * Changes actual feature state handler.
			 * @private
			 * @param {Boolean} enabled FeatureEnabled attribute value.
			 */
			onStateChanged: function(enabled) {
				var state = enabled ? BPMSoft.FeatureState.ENABLED : BPMSoft.FeatureState.DISABLED;
				if (state !== this.get("ActualState")) {
					this.set("ActualState", state);
					this.set("IsChangedFeature", !this.get("IsChangedFeature"));
					this.fireEvent("changeFeatureState");
				}
			},

			/**
			 * Returns caption for the hint button.
			 * @private
			 * @return {String} Formatted caption depends on feature state.
			 */
			getTipCaption: function() {
				var hasGroupState = this.get("HasStateForGroup");
				var result = null;
				if (hasGroupState) {
					var state = this.get("GroupState");
					var enabled = (state === BPMSoft.FeatureState.ENABLED);
					var template = this.get("Resources.Strings.FeatureNameTipCaption");
					var stateCaption = enabled ? this.get("Resources.Strings.EnabledCaption")
							: this.get("Resources.Strings.DisabledCaption");
					result = Ext.String.format(template, stateCaption);
				}
				return result;
			},

			/**
			 * Initializes features view model class.
			 * @protected
			 */
			init: function() {
				this.initEnabledState();
				this.addEvents(
						/**
						 * @event
						 * Change feature state event.
						 * @param {BPMSoft.FeatureItemViewModel} viewModel View model of feature item.
						 */
						"changeFeatureState"
				);
				this.callParent(arguments);
			}
		}
	};
});
