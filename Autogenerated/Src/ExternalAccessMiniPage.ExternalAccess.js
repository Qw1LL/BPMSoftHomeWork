define("ExternalAccessMiniPage", ["ExternalAccessMiniPageResources", "BaseFiltersGenerateModule",
	"css!ExternalAccessMiniPageCSS"],
		function(resources, BaseFiltersGenerateModule) {
	return {
		entitySchemaName: "ExternalAccess",
		attributes: {
			/**
			 * Contains access info label caption with academy url.
			 * @type {String}
			 */
			"AccessInfoCaption": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: resources.localizableStrings.InfoLabelCaption
			},

			/**
			 * Grantor column.
			 * @type {Object}
			 */
			"Grantor": {
				"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"lookupListConfig": {
					"filter": BaseFiltersGenerateModule.OwnerFilter
				}
			},

			/**
			 * Indicates that user can provide external access on behalf of another user.
			 * @type {Boolean}
			 */
			"CanDelegateExternalAccess": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Indicates that 'ExternalAccessClient' control is visible.
			 * @type {Boolean}
			 */
			"IsAccessClientVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Indicates that 'Data isolation' control is visible.
			 * @type {Boolean}
			 */
			"IsDataIsolationVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		properties: {
			/**
			 * @private
			 */
			_contextHelpId: 2016
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			/**
			 * @private
			 */
			_checkRequiredSettings: function() {
				BPMSoft.SysSettings.querySysSettings(["IdentityServerUrl", "IdentityServerClientId"],
						function(sysSettings) {
					const emptySettings = BPMSoft.filterObjectList(sysSettings, function(value, key) {
						return BPMSoft.isEmpty(value);
					}, this);
					const emptySettingsCodes = BPMSoft.keys(emptySettings);
					if (emptySettingsCodes.length > 0) {
						const template = resources.localizableStrings.EmptySettingsMessage;
						const message = Ext.String.format(template, emptySettingsCodes.join(", "));
						BPMSoft.utils.showMessage({
							caption: message,
							handler: function() {
								this.close();
							},
							buttons: [BPMSoft.MessageBoxButtons.OK.returnCode],
							defaultButton: 0,
							scope: this
						});
					}
				}, this);
			},
			/**
			 * @private
			 */
			_setDueDate: function() {
				BPMSoft.SysSettings.querySysSettingsItem("DefaultExternalAccessDurationDays",
						function(defaultDurationDays) {
					const currentDate = BPMSoft.clearTime(new Date());
					this.$DueDate = BPMSoft.addDays(currentDate, defaultDurationDays);
				}, this);
			},
			/**
			 * @private
			 */
			_setDataIsolationVisibility: function () {
				BPMSoft.SysSettings.querySysSettingsItem("ForceExternalAccessDataIsolation",
					function(forceExternalAccessDataIsolation) {
						this.$IsDataIsolationVisible = !forceExternalAccessDataIsolation;
					}, this);
			},
			/**
			 * @private
			 * @param {Function} callback Callback-function.
			 * @param {Object} scope Execution context.
			 */
			_setupAcademyUrl: function(callback, scope) {
				BPMSoft.AcademyUtilities.getUrl({
					contextHelpId: this._contextHelpId,
					scope: this,
					callback: function(url) {
						const template = resources.localizableStrings.InfoLabelCaption;
						this.$AccessInfoCaption = Ext.String.format(template, url);
						Ext.callback(callback, scope);
					}
				});
			},
			/**
			 * @private
			 */
			_initExternalAccessClient: function(callback, scope) {
				this._getExternalAccessClientsCount(function(count) {
					this.set("IsAccessClientVisible", count !== 1 || Ext.isEmpty(this.$ExternalAccessClient));
					callback.call(scope);
				}, scope);
			},
			/**
			 * @private
			 */
			_getExternalAccessClientsCount: function(callback, scope) {
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "ExternalAccessClient",
					clientESQCacheParameters: {
						cacheItemName: "ExternalAccessClient_Count"
					}
				});
				esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "Count");
				esq.getEntityCollection(function(response) {
					const clientsCount = response.collection.first().get("Count");
					callback.call(scope, clientsCount);
				});

			},
			/**
			 * @inheritdoc BPMSoft.BaseMiniPage#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						this.checkCanExecuteOperation("CanDelegateExternalAccess", function() {
							this._setupAcademyUrl(callback, scope || this);
						}, this);
					}, this
				]);
				if (this.$Mode === this.BPMSoft.ConfigurationEnums.CardOperation.ADD) {
					this._checkRequiredSettings();
					this._setDueDate();
					this._setDataIsolationVisibility();
				}
			},

			/**
			 * @inheritdoc BaseMiniPage#onEntityInitialized
			 * @protected
			 * @override
			 */
			onEntityInitialized: function(callback, scope) {
				this.callParent([
					function() {
						this._initExternalAccessClient(callback, scope);
					}, this
				]);
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "HeaderContainer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "MiniPage",
				"values": {
					"classes": {
						"wrapClassName": ["external-access-mini-page-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "HeaderColumnContainer",
				"values": {
					"itemType": 6,
					"caption": {
						"bindTo": "getPrimaryDisplayColumnValue"
					},
					"labelClass": [
						"label-in-header-container"
					],
					"visible": {
						"bindTo": "isNotAddMode"
					}
				},
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccessInfoContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "MiniPage"
					},
					"wrapClass": ["info-label", "t-label"]
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "AccessInfo",
				"values": {
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.HtmlControl",
					"htmlContent": {"bindTo": "AccessInfoCaption"}
				},
				"parentName": "AccessInfoContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "AccessReason",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "MiniPage"
					},
					"isMiniPageModelItem": true,
					"visible": {
						"bindTo": "isAddMode"
					},
					"bindTo": "AccessReason"
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ExternalAccessClient",
				"parentName": "MiniPage",
				"propertyName": "items",
				"values": {
					"layout": {
						"colSpan": 24,
						"column": 0,
						"row": 3,
						"layoutName": "MiniPage"
					},
					"visible": {
						"bindTo": "IsAccessClientVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "DueDate",
				"values": {
					"layout": {
						"column": 0,
						"row": 4,
						"layoutName": "MiniPage"
					},
					"isMiniPageModelItem": true,
					"visible": {
						"bindTo": "isAddMode"
					},
					"caption": {"bindTo": "Resources.Strings.DueDateCaption"},
					"tip": {
						"content": {"bindTo": "Resources.Strings.DueDateTip"}
					}
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Grantor",
				"values": {
					"layout": {
						"column": 13,
						"row": 4,
						"layoutName": "MiniPage"
					},
					"isMiniPageModelItem": true,
					"visible": {
						"bindTo": "isAddMode"
					},
					"enabled": {
						"bindTo": "CanDelegateExternalAccess"
					}
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsDataIsolationEnabled",
				"values": {
					"layout": {
						"column": 0,
						"row": 5,
						"layoutName": "MiniPage"
					},
					"classes": {
						"wrapClassName": ["single-row-boolean-wrap"]
					},
					"isMiniPageModelItem": true,
					"visible": {
						"bindTo": "IsDataIsolationVisible"
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.IsDataIsolationEnabledTip"}
					}
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsSystemOperationsRestricted",
				"values": {
					"layout": {
						"column": 13,
						"row": 5,
						"layoutName": "MiniPage"
					},
					"classes": {
						"wrapClassName": ["single-row-boolean-wrap"]
					},
					"isMiniPageModelItem": true,
					"tip": {
						"content": {"bindTo": "Resources.Strings.IsSystemOperationsRestrictedTip"}
					}
				},
				"parentName": "MiniPage",
				"propertyName": "items"
			}
		]/**SCHEMA_DIFF*/
	};
});

