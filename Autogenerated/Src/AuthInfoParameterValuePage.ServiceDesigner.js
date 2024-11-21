define("AuthInfoParameterValuePage", ["ServiceEnums", "ServiceDesignerUtilities"],
	function() {
	return {
		properties: {

			//region Properties: Private

			/**
			 * @private
			 */
			_serviceSchema: null,

			//endregion

			//region Properties: Protected

			/**
			 * Service auth info value.
			 * @protected
			 * @type{BPMSoft.ServiceParameterValue}
			 */
			authInfoValue: null

			//endregion

		},
		attributes: {
			AuthInfoPropertyName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			ServiceSchemaUid: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_onServiceSchemaChanged: function(changedValues) {
				if (changedValues.hasOwnProperty("authType")) {
					this._initAuthInfoValue();
				} else {
					if (changedValues.hasOwnProperty("authInfoValues")) {
						this.authInfoValue = this._serviceSchema.authInfo.values.find(this.$AuthInfoPropertyName);
						if (this.authInfoValue) {
							this.$Source = this.authInfoValue.source;
							this.$Value = this.authInfoValue.value;
							this._setSpecifiedValue();
							this.updateAuth();
						}
					}
				}
			},

			/**
			 * @private
			 */
			_initAuthInfoValue: function() {
				this.authInfoValue = this._serviceSchema.authInfo.values.find(this.$AuthInfoPropertyName);
				if (!this.authInfoValue) {
					this.authInfoValue = new BPMSoft.ServiceParameterValue({
						_serviceSchema: this._serviceSchema,
						source: BPMSoft.services.enums.ServiceParameterValueSource.SYS_SETTING,
						value: ""
					});
					this._serviceSchema.authInfo.values.add(this.$AuthInfoPropertyName, this.authInfoValue);
				}
				this.$Source = this.authInfoValue.source;
				if (this.isSysSettingSource()) {
					this.$SysSettingValue = BPMSoft.ServiceDesignerUtilities.getFormattedValue(this.authInfoValue);
				} else {
					this.$Value = this.authInfoValue.value;
				}
			},

			/**
			 * @private
			 */
			_initServiceSchema: function(callback, scope) {
				BPMSoft.ServiceSchemaManager.getInstanceByUId(this.$ServiceSchemaUid, function(instance) {
					this._serviceSchema = instance;
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_setSpecifiedValue: function() {
				if (this.$Source === BPMSoft.services.enums.ServiceParameterValueSource.CONST) {
					this.$TextValue = this.$Value;
					this.$SysSettingValue = null;
				}
				if (this.$Source === BPMSoft.services.enums.ServiceParameterValueSource.SYS_SETTING) {
					this.$TextValue = null;
					if (this.$Value) {
						this.$SysSettingValue = BPMSoft.ServiceDesignerUtilities.getFormattedValue({
							value: this.$Value,
							source: this.$Source
						});
					}
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterValuePage#updateMetaItemValue
			 * @override
			 */
			updateMetaItemValue: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterValuePage#getValueCaption
			 * @override
			 */
			getValueCaption: function() {
				var resourcesName = Ext.String.format("Resources.Strings.{0}Caption",
					Ext.String.capitalize(this.$AuthInfoPropertyName));
				return this.get(resourcesName);
			},

			/**
			 * Updates view model when auth info changed.
			 * @virtual
			 */
			updateAuth: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseServiceParameterValuePage#onValueChanged
			 * @override
			 */
			onValueChanged: function() {
				this._setSpecifiedValue();
				this.authInfoValue.setPropertyValue("value", this.$Value);
			},

			/**
			 * @inheritdoc BaseServiceParameterValuePage#onSourceChanged
			 * @override
			 */
			onSourceChanged: function() {
				this._setSpecifiedValue();
				this.authInfoValue.setPropertyValue("source", this.$Source);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.chain(
						function(next) {
							BPMSoft.ServiceSchemaManager.initialize(next, this);
						},
						function(next) {
							this._initServiceSchema(next, this);
						},
						function() {
							this._initAuthInfoValue();
							this._serviceSchema.on("changed", this._onServiceSchemaChanged, this);
							Ext.callback(callback, scope);
						}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterValuePage#getSourcesMenuItems
			 * @override
			 */
			getSourcesMenuItems: function() {
				var sources = this.callParent(arguments);
				if (!this.canUseConstants()) {
					sources = sources.filter(function(item) {
						return item.$Tag !== BPMSoft.services.enums.ServiceParameterValueSource.CONST;
					});
				}
				return sources;
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				if (this._serviceSchema) {
					this._serviceSchema.un("changed", this._onServiceSchemaChanged, this);
				}
			},

			/**
			 * Is allow to use constants as a source.
			 * @return {Boolean}
			 */
			canUseConstants: function() {
				return BPMSoft.isDebug || BPMSoft.Features.getIsEnabled("AuthInfoAllowUseConstants");
			}

			//endregion

		},
		diff: [{
			operation: "merge",
			name: "Source",
			values: {
				markerValue: "$AuthInfoPropertyName",
				enabled: "$canUseConstants"
			}
		}]
	};
});
