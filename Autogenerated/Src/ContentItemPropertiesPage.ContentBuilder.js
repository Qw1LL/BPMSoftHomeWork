define("ContentItemPropertiesPage", ["css!ContentItemPropertiesPageCSS"], function() {
	return {
		attributes: {

			/**
			 * Content item config.
			 */
			Config: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * @type {BPMSoft.ContentBuilderState}
			 */
			ContentBuilderState: {
				dataValueType: BPMSoft.DataValueType.INTEGER
			}
		},
		properties: {
			sandboxId: "ContentItemPropertiesPage",
			workStyles: [],
			_isLoaded: false
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
			 * @message IsEmailMacroAvailable.
			 * Defines visibility of macro buttons.
			 */
			IsEmailMacroAvailable: {
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
			 * @message ContentBuilderStateChanged
			 * Receives actual content builder state on change.
			*/
			ContentBuilderStateChanged: {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Save initial config state.
			 * @param {Object} config Content item config.
			 * @private
			 */
			_onContentItemChanged: function(config) {
				this._isLoaded = false;
				this.setConfig(config);
				this.onContentItemConfigChanged(this.$Config);
				this._isLoaded = true;
			},

			// endregion

			// region Methods: Protected

			/**
			 * Handles change of content item config.
			 * @virtual
			 * @protected
			 */
			onContentItemConfigChanged: BPMSoft.emptyFn,

			// endregion

			// region Methods: Public

			/**
			 * Gets properties config.
			 * @param {String} propertyName Name of the changed property.
			 * @return {Object} config Content item config.
			 */
			getConfig: function(propertyName) {
				if (propertyName) {
					var config = {};
					config[propertyName] = this.$Config[propertyName];
					return config;
				}
				return this.$Config;
			},

			/**
			 * Sets config state.
			 * @param {Object} config Content item config.
			 */
			setConfig: function(config) {
				this.$Config = config;
			},

			/**
			 * @puplic
			 * @param {Object} previousValue.
			 * @param {Object} currentValue.
			 * @return {Boolean} previous value is changed.
			 */
			isChanged: function(previousValue, currentValue) {
				return !(Ext.isEmpty(previousValue) && Ext.isEmpty(currentValue)) &&
						!BPMSoft.isEqual(previousValue, currentValue);
			},

			/**
			 * Sends current config to content item.
			 * @param {Array} filter List of applicable parameters.
			 * @param {String} propertyName Name of the changed property.
			 */
			save: function(filter, propertyName) {
				if (this._isLoaded) {
					this.validateConfig(function(result) {
						if (result.valid) {
							BPMSoft.defer(function() {
								this.sandbox.publish("UpdateContentItemConfig", {
										config: this.getConfig(propertyName),
										stylesFilter: filter || this.workStyles,
										propertyName: propertyName
									},
									[this.sandboxId]);
							}, this);
						}
					}, this);
				}
			},

			/**
			 * Performs validation of item config.
			 * @virtual
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope.
			 */
			validateConfig: function(callback, scope) {
				Ext.callback(callback, scope, [{valid: true}]);
			},

			/**
			 * Handler on content builder state changed message.
			 * @protected
			 * @param {BPMSoft.ContentBuilderState} state Content builder state.
			 */
			onContentBuilderStateChanged: function(state) {
				this.$ContentBuilderState = state;
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this._onContentItemChanged(this.$Config);
					this.sandbox.subscribe("ContentItemConfigChanged", this._onContentItemChanged, this,
						["PropertiesPage"]);
					this.sandbox.subscribe("ContentBuilderStateChanged", this.onContentBuilderStateChanged, this);
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * Defines visibility of macro button depends on opened content builder type.
			 * @protected
			 */
			isMacroButtonVisible: function() {
				var isMacroAvailable = this.sandbox.publish("IsEmailMacroAvailable");
				return !!isMacroAvailable;
			}

			// endregion

		}
	};
});
