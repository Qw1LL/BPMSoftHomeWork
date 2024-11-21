 define("ContentMacroButtonModule", [], function() {
	return {
		attributes: {

			/**
			 * Content item config.
			 */
			Config: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Name of property to work with.
			 */
			PropertyName: {
				dataValueType: BPMSoft.core.enums.DataValueType.STRING,
				type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			}
		},
		messages: {

			/**
			 * @message OpenMacrosDialog
			 */
			OpenMacrosDialog: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateContentItemConfig.
			 * Sets actual content item config.
			 */
			UpdateContentItemConfig: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ContentItemConfigChanged.
			 * Actualize current config.
			 */
			ContentItemConfigChanged: {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
			},

			/**
			 * @message GetActualContentItemConfig.
			 * Returns actual item config.
			 */
			GetActualContentItemConfig: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			/**
			 * @private
			 */
			_onMacroSelected: function(column) {
				if (!column) {
					return;
				}
				var macroValue = Ext.String.format("[#{0}#]", column.leftExpressionColumnPath);
				var propertyName = this.$PropertyName;
				var config =  this.sandbox.publish("GetActualContentItemConfig", null, ["ItemPanel"]);
				config[propertyName] = macroValue;
				var diff = {};
				diff[propertyName] = macroValue;
				var updateConfig = {
					config: diff,
					stylesFilter: null,
					propertyName: propertyName
				};
				this.sandbox.publish("UpdateContentItemConfig", updateConfig, ["PropertyModule"]);
				this.sandbox.publish("ContentItemConfigChanged", config, ["PropertiesPage"]);
			},

			/**
			 * Handler on macro button click. Fires message into content builder.
			 * @protected
			 */
			onMacroButtonClick: function() {
				var messageConfig = {
					macroSelectedHandler: this._onMacroSelected.bind(this)
				};
				this.sandbox.publish("OpenMacrosDialog", messageConfig);
			}
		},
		diff: [{
				"operation": "insert",
				"name": "MacrosButtonLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["macro-button-layout"]
				}
			},
			{
				"operation": "insert",
				"name": "MacrosButton",
				"parentName": "MacroButtonLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$onMacroButtonClick",
					"imageConfig": "$Resources.Images.MacrosIcon"
				}
			}]
	};
});
