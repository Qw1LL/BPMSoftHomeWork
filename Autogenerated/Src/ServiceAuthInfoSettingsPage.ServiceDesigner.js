define("ServiceAuthInfoSettingsPage", ["ServiceAuthInfoSettingsPageResources", "ServiceEnums",
	"ServiceDesignerUtilities"], function() {
	return {
		modules: {
			BasicServiceAuthInfoValuesPageModule: {
				moduleId: "BasicServiceAuthInfoValuesPageModule",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "BasicServiceAuthInfoValuesPage",
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							ServiceSchemaUId: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					}
				}
			},
			OAuth20ServiceAuthInfoValuesPageModule: {
				moduleId: "OAuth20ServiceAuthInfoValuesPageModule",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "OAuth20ServiceAuthInfoValuesPage",
					useHistoryState: false,
					parameters: {
						viewModelConfig: {
							ServiceSchemaUid: {
								attributeValue: "ServiceSchemaUId"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					}
				}
			}
		},
		attributes: {

			/**
			 *Service authentication type.
			 */
			AuthTypeLookup: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onAuthTypeLookupChange",
				isRequired: true
			},

			/**
			 * Authentication info.
			 */
			AuthInfo: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Service schema.
			 */
			ServiceSchema: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * UId of service schema.
			 */
			ServiceSchemaUId: {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Authentication type.
			 */
			AuthType: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * Is allow edit schema.
			 */
			CanEditSchema: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},
		methods: {

			// region Methods: Public

			/**
			 * @private
			 */
			_initAuth: function() {
				this.$AuthInfo = this.$ServiceSchema.authInfo;
				var authType = this.$AuthInfo.authType;
				this.$AuthType = authType;
				this.$AuthTypeLookup = {
					value: authType,
					displayValue: BPMSoft.services.enums.AuthTypeCaption[authType]
				};
			},

			/**
			 * @private
			 */
			_prepareAuthTypeList: function(filter, list) {
				var result = {};
				BPMSoft.each(BPMSoft.services.enums.AuthType, function(value) {
					if (value === BPMSoft.services.enums.AuthType.Digest && !(BPMSoft.isDebug ||
						this.getIsFeatureEnabled("WebServiceDigestAuth"))) {
						return;
					}
					if (value === BPMSoft.services.enums.AuthType.OAuth20 && !(BPMSoft.isDebug ||
						this.getIsFeatureEnabled("WebServiceOAuth20Auth"))) {
						return;
					}
					result[value] = {
						value: value,
						displayValue: BPMSoft.services.enums.AuthTypeCaption[value]
					};
				}, this);
				list.reloadAll(result);
			},

			/**
			 * @private
			 */
			_onAuthTypeLookupChange: function(model, authType) {
				var defaultType = {
					value: BPMSoft.services.enums.AuthType.None
				};
				authType = authType && authType.value ? authType : defaultType;
				if (this.$AuthInfo.authType !== authType.value) {
					this.$AuthInfo.values.clear();
					this.$ServiceSchema.methods.each(function(method) {
						method.setPropertyValue("useAuthInfo",
								authType.value !== BPMSoft.services.enums.AuthType.None);
					});
				}
				this.$AuthType = authType.value;
				this.$AuthInfo.setPropertyValue("authType", authType.value);
			},

			// endregion

			// region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.ServiceSchemaManager.initialize(function() {
						BPMSoft.ServiceSchemaManager.getInstanceByUId(this.$ServiceSchemaUId, function(instance) {
							this.$ServiceSchema = instance;
							this._initAuth();
							this.$ServiceSchema.on("changed", this._initAuth, this);
							BPMSoft.ServiceDesignerUtilities.canEditSchema(instance, function(canEditSchema) {
								this.$CanEditSchema = canEditSchema;
							}, this);
							Ext.callback(callback, scope);
						}, this);
					}, this);
				}, this]);
			},

			/**
			 * Is basic or digest auth visible.
			 * @return {boolean}
			 */
			isBasicOrDigestAuthVisible: function(authType) {
				return authType === BPMSoft.services.enums.AuthType.Basic ||
					authType === BPMSoft.services.enums.AuthType.Digest;
			},

			/**
			 * Indicates if current AuthType is OAuth20.
			 * @return {boolean}
			 */
			isOAuth20Type: function(authType) {
				return authType === BPMSoft.services.enums.AuthType.OAuth20;
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				if (this.$ServiceSchema) {
					this.$ServiceSchema.un("changed", this._initAuth, this);
				}
			}

			// endregion

		},
		diff: [
			{
				operation: "insert",
				name: "AuthInfoSetup",
				values: {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					items: []
				}
			},
			{
				"operation": "insert",
				"name": "AuthInfoSetupContainer",
				"parentName": "AuthInfoSetup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				operation: "insert",
				name: "AuthTypeLookup",
				parentName: "AuthInfoSetupContainer",
				propertyName: "items",
				index: 0,
				values: {
					caption: "$Resources.Strings.AuthCaption",
					dataValueType: BPMSoft.DataValueType.ENUM,
					"layout": {"column": 0, "row": 0, "colSpan": 11},
					controlConfig: {
						className: "BPMSoft.ComboBoxEdit",
						prepareList: "$_prepareAuthTypeList",
						enabled: "$CanEditSchema"
					},
					"wrapClass": ["service-parameter-value-source"]
				}
			},
			{
				operation: "insert",
				name: "BasicServiceAuthInfoValuesPageModule",
				parentName: "AuthInfoSetupContainer",
				propertyName: "items",
				index: 1,
				values: {
					itemType: BPMSoft.ViewItemType.MODULE,
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					visible: {
						bindTo: "AuthType",
						bindConfig: {
							converter: "isBasicOrDigestAuthVisible"
						}
					}
				}
			},
			{
				operation: "insert",
				name: "OAuth20ServiceAuthInfoValuesPageModule",
				parentName: "AuthInfoSetupContainer",
				propertyName: "items",
				index: 1,
				values: {
					itemType: BPMSoft.ViewItemType.MODULE,
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					visible: {
						bindTo: "AuthType",
						bindConfig: {
							converter: "isOAuth20Type"
						}
					}
				}
			}
		]
	};
});
