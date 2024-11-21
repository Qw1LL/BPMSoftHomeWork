define("BaseStylePropertyModule", function() {
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
				value: "Styles"
			}
		},
		properties: {
			_isLoaded: false,

			/**
			 * Array of applicable style attributes.
			 */
			workStyles: []
		},
		messages: {
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
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * Updates content item config state.
			 * @param {Object} config Content item config.
			 */
			_onContentItemChanged: function(config) {
				this._isLoaded = false;
				this.$Config = config;
				this.initProperty();
				this._isLoaded = true;
			},

			/**
			 * Gets content item property value.
			 * @return {Object} value Value of the changed property.
			 */
			getPropertyValue: BPMSoft.emptyFn,

			/**
			 * Gets changed properties config.
			 * @return {Object} config Content item config.
			 */
			getChangesConfig: function() {
				var propertyValue = this.getPropertyValue();
				if (this.$PropertyName) {
					var config = {};
					config[this.$PropertyName] = propertyValue;
					return config;
				}
				return {};
			},

			/**
			 * Sends current config to content item.
			 */
			save: function() {
				if (this._isLoaded) {
					this.validateConfigValues(function(result) {
						if (result.valid) {
							BPMSoft.defer(function() {
								var config = this.getChangesConfig();
								this.sandbox.publish("UpdateContentItemConfig", {
										config: config,
										stylesFilter: this.workStyles,
										propertyName: this.$PropertyName
									}, ["PropertyModule"]);
							}, this);
						}
					}, this);
				}
			},

			/**
			 * Performs validation of item config values.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope.
			 */
			validateConfigValues: function(callback, scope) {
				Ext.callback(callback, scope, [{valid: true}]);
			},

			/**
			 * Performs item property initialization.
			 */
			initProperty: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.sandbox.subscribe("ContentItemConfigChanged", this._onContentItemChanged,
						this, ["PropertiesPage"]);
					this._isLoaded = false;
					this.initProperty();
					this._isLoaded = true;
					Ext.callback(callback, scope);
				}, this]);
			}
		},
		diff: []
	};
});
