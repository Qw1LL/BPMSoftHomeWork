define("BaseMacroListItemViewModel", ["BaseMacroListItemViewModelResources"], function(resources) {
	/**
	 * @class BPMSoft.configuration.BaseMacroListItemViewModel
	 */
	Ext.define("BPMSoft.configuration.BaseMacroListItemViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.BaseMacroListItemViewModel",

		attributes: {
			/**
			 * Macro identifier.
			 * @type {Object}
			 */
			"Id": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value.
			 * @type {Object}
			 */
			"Value": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Text representation of macro value.
			 */
			"DisplayValue": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro value type.
			 * @type {Number}
			 */
			"DataValueType": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Description of the macro.
			 * @type {String}
			 */
			"Description": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Macro name.
			 * @type {String}
			 */
			"Name": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Flag to indicate selected item.
			 * @type {Boolean}
			 */
			"Selected": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		/**
		 * External sandbox.
		 * @protected
		 */
		sandbox: null,

		/**
		 * Flag to indicate if email macro button is visible.
		 * @protected
		 */
		isEmailMacroButtonVisible: true,

		/**
		 * Prefix for control marker value.
		 * @type {String}
		 */
		markerValuePrefix: "macro-value",
		/**
		 * Postfix for container marker value.
		 * @type {String}
		 */
		markerValuePostfix: "macro-container",

		/**
		 * @private
		 */
		_escapeHtmlTags: function(text) {
			return text.replace(/<[^>]*>/gm, "");
		},

		/**
		 * Handles change event of display value.
		 * @protected
		 * @param {Object} model View model of macro.
		 * @param {String} value New display value.
		 */
		onDisplayValueChanged: function(model, value) {
			if (Ext.isEmpty(value)) {
				this.$Value = "";
			} else {
				this.$Value = this._escapeHtmlTags(value);
			}
		},

		/**
		 * Initializes display value of macro.
		 * @protected
		 * @param {Object} config Macro values config.
		 */
		initDisplayValue: function(config) {
			config.DisplayValue = config.Value;
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function(config) {
			config && config.values && this.initDisplayValue(config.values);
			this.sandbox = config.sandbox;
			this.callParent(arguments);
			this.on("change:DisplayValue", this.onDisplayValueChanged, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:DisplayValue", this.onDisplayValueChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Returns container marker value.
		 * @protected
		 * @returns {String} Marker value.
		 */
		getContainerMarkerValue: function() {
			return this.$Id + "-" + this.markerValuePostfix;
		},

		/**
		 * Returns control marker value.
		 * @protected
		 * @returns {String} Marker value.
		 */
		getControlMarkerValue: function() {
			return this.markerValuePrefix + "-" + this.$Id;
		},

		/**
		 * Returns visibility value for macro information.
		 * @protected
		 * @returns {Boolean} Marker value.
		 */
		getMacroInfoVisible: function() {
			return Boolean(this.$Description);
		},

		/**
		 * Returns config of macro value.
		 * @protected
		 * @returns {Object} Macro  config.
		 */
		getMacroConfig: function() {
			return {
				Id: this.$Id,
				DataValueType: this.$DataValueType,
				Name: this.$Name,
				Value: this.$Value,
				Description: this.$Description
			};
		},

		/**
		 * Returns config of macro label view.
		 * @protected
		 * @returns {Object} Macro label view config.
		 */
		getMacroLabelConfig: function() {
			var config = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["macro-label-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						caption: "$Name",
						classes: {
							labelClass: ["inline-label"]
						}
					},
					{
						className: "BPMSoft.InformationButton",
						visible: this.getMacroInfoVisible(),
						tips: [
							{
								tip: {
									content: "$Description",
									style: BPMSoft.controls.TipEnums.style.WHITE,
									showDelay: 200,
									initialAlignType: BPMSoft.AlignType.LEFT
								},
								settings: {
									displayEvent: BPMSoft.TipDisplayEvent.HOVER
								}
							}
						]
					}
				]
			};
			var isEmailMacroAvailable = this.sandbox.publish("IsEmailMacroAvailable");
			if (isEmailMacroAvailable && this.isEmailMacroButtonVisible) {
				config.items.push({
					className: "BPMSoft.Button",
					markerValue: "EmailMacroButton",
					classes: {wrapperClass: "email-macro-button"},
					click: "$onMacroButtonClick",
					imageConfig: resources.localizableImages.MacrosIcon
				});
			}
			return config;
		},

		/**
		 * @private
		 */
		_onMacroSelected: function(column) {
			if (!column) {
				return;
			}
			var macroValue = Ext.String.format("[#{0}#]", column.leftExpressionColumnPath);
			this.$DisplayValue = macroValue;
			this.$Value = macroValue;
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
		},

		/**
		 * Returns config of macro input view.
		 * @protected
		 * @returns {Array[Object]} Macro input view config.
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "BPMSoft.TextEdit",
					value: "$DisplayValue",
					markerValue: this.getControlMarkerValue()
				}
			];
		},

		/**
		 * Returns config of current item view.
		 * @public
		 * @returns {Object} View config.
		 */
		getViewConfig: function() {
			return {
				id: "macro",
				className: "BPMSoft.Container",
				markerValue: this.getContainerMarkerValue(),
				classes: {
					wrapClassName: ["macro-item-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["macro-input-container"]
						},
						items: this.getMacroInputConfig()
					}
				]
			};
		}
	});
	return BPMSoft.BaseMacroListItemViewModel;
});
