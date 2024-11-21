define("BusinessRuleSection", ["AcademyUtilities", "BusinessRuleModule", "css!BusinessRuleSectionCSS", "BaseWizardStepSchemaMixin",
	"css!SectionModuleV2", "EmptyGridMessageConfigBuilder", "BusinessRuleSchemaManager"
], function(AcademyUtilities, BusinessRuleModule) {

	return {
		messages: {
			/**
			 * Subscribing on message for section parameters request.
			 */
			"GetModuleConfigResultDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * Subscribing on message for section parameters request.
			 */
			"GetModuleConfigDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Publishing message for unload designer module.
			 */
			"CloseBusinessRuleDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			BaseWizardStepSchemaMixin: "BPMSoft.BaseWizardStepSchemaMixin"
		},
		attributes: {
			/**
			 * Business rule designer visible.
			 */
			"BusinessRuleDesignerVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Is new business rule flag.
			 */
			"isNewBusinessRule": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag indicating that the module entity contains many edit pages.
			 */
			"IsMultiPage": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Academy url.
			 */
			"AcademyUrl": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			/**
			 * Academy help id.
			 */
			"HelpId": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 1680
			},
			"IsValid": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Subscribes sandbox to messages.
			 * @private
			 */
			subscribeMessages: function() {
				var schemaDesignerId = this.getSchemaDesignerSandboxId();
				this.sandbox.subscribe("GetModuleConfigDesigner", this.onGetModuleConfigDesigner, this, [schemaDesignerId]);
				this.sandbox.subscribe("CloseBusinessRuleDesigner", this.onCloseBusinessRuleSchemaDesigner,
					this, [schemaDesignerId]);
			},

			/**
			 * Returns business rule schema designer id.
			 * @private
			 * @return {String} Business rule schema designer id.
			 */
			getSchemaDesignerSandboxId: function() {
				return this.sandbox.id + "_BusinessRuleSchemaDesigner";
			},

			/**
			 * Loads business rule designer.
			 * @private
			 */
			loadDesigner: function() {
				this.sandbox.loadModule("BaseSchemaModuleV2", {
					"id": this.getSchemaDesignerSandboxId(),
					"renderTo": "BusinessRuleWrapDesignerContainer",
					"keepAlive": true,
					"instanceConfig": {
						"useHistoryState": false,
						"isSchemaConfigInitialized": true,
						"schemaName": "BusinessRuleSchemaDesigner"
					}
				});
			},

			_getCanEdit: function() {
				const itemManager = this.getManagerItemByActiveRow();
				const viewModelClass = BPMSoft.BusinessRuleSchemaManager.viewModelClassCollection.get(itemManager.clientUnitSchemaUId);
				let businessRule;
				BPMSoft.each(viewModelClass.prototype.rules, function(rule) {
					if (rule[itemManager.name]) {
						businessRule = rule[itemManager.name];
					}
				}, this);
				return businessRule && businessRule.ruleType === BusinessRuleModule.enums.RuleType.POPULATE_ATTRIBUTE ?
					!this.Ext.isIEOrEdge :
					true;
			},

			/**
			 *
			 * @param {Object} config
			 * @param {String} config.clientUnitSchemaUId
			 * @param {String} config.sysModuleEntityId
			 * @param {String} config.currentPackageUId
			 * @param {Function} callback
			 * @param {Object} scope
			 * @private
			 */
			_validateSchemaBusinessRulesBlock: function(config, callback, scope) {
				let isValid = true;
				let errorMessage;
				BPMSoft.chain(
					function(next) {
						if (config.clientUnitSchemaUId) {
							next([config.clientUnitSchemaUId]);
						} else {
							const sysModuleEntity = BPMSoft.SysModuleEntityManager.getItem(config.sysModuleEntityId);
							sysModuleEntity.getSysModuleEditManagerItems(function(sysModuleEditItems) {
								const clientUnitSchemaUIds = [];
								sysModuleEditItems.each(function(item) {
									const cardSchemaUId = item.getCardSchemaUId();
									if (!item.isDeleted && cardSchemaUId) {
										clientUnitSchemaUIds.push(cardSchemaUId);
									}
								}, this);
								next(clientUnitSchemaUIds);
							}, this);
						}
					},
					function(next, clientUnitSchemaUIds) {
						BPMSoft.eachAsync(
							clientUnitSchemaUIds,
							function(clientUnitSchemaUId, iterate, options) {
								BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance({
									schemaUId: clientUnitSchemaUId,
									packageUId: config.currentPackageUId
								}, function(clientUnitSchema) {
									if (!clientUnitSchema.areAllSchemaBusinessRulesValid()) {
										isValid = false;
										errorMessage = Ext.String.format(
											this.get("Resources.Strings.InvalidBusinessRuleSectionLabel"),
											clientUnitSchema.getCaption());
										options.break();
									}
									iterate();
								}, this);
							},
							next,
							this
						);
					},
					function() {
						callback.call(scope, {isValid: isValid, errorMessage: errorMessage});
					},
					this
				);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onValidate
			 * @override
			 */
			onValidate: function() {
				this.publishValidationResult(this.validate());
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.set("BusinessRuleDesignerVisible", false);
					this.subscribeMessages();
					BPMSoft.chain(
						this.mixins.BaseWizardStepSchemaMixin.init,
						function(next) {
							const config = {
								clientUnitSchemaUId: this.get("ClientUnitSchemaUId"),
								sysModuleEntityId: this.get("SysModuleEntityId"),
								currentPackageUId: this.get("PackageUId")
							};
							this._validateSchemaBusinessRulesBlock(config, function(validationResult) {
								if (validationResult.isValid) {
									this.set("IsValid", true);
									next();
								} else {
									this.set("IsValid", false);
									this.set("InvalidBusinessRuleSectionMessage", validationResult.errorMessage);
									this.hideBodyMask();
									callback.call(scope);
								}
							}, this);
						},
						this.initBusinessRuleSchemaManager,
						function(next) {
							this.setIsMultiPage();
							this.createBusinessRuleGridProfile();
							this.loadGridData();
							this.initHelpUrl(next, this);
						},
						function() {
							this.hideBodyMask();
							callback.call(scope);
						},
						this
					);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				var gridData = this.get("GridData");
				this.set("IsGridEmpty", gridData.isEmpty());
				this.reloadGridColumnsConfig(true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config, callback, scope) {
				this.set("PackageUId", config.packageUId);
				var structureItem = config.applicationStructureItem;
				var clientUnitSchemaUId = config.clientUnitSchemaUId;
				BPMSoft.chain(
					function(next) {
						if (structureItem && structureItem.getSysModuleEntityManagerItem) {
							structureItem.getSysModuleEntityManagerItem(next, this);
						} else {
							next();
						}
					},
					function(next, sysModuleEntity) {
						if (!sysModuleEntity && !clientUnitSchemaUId) {
							throw new BPMSoft.UnsupportedTypeException();
						}
						if (sysModuleEntity) {
							this.set("SysModuleEntityId", sysModuleEntity.getId());
						}
						if (clientUnitSchemaUId) {
							this.set("ClientUnitSchemaUId", clientUnitSchemaUId);
						}
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseViewModel#validate
			 * @override
			 */
			validate: function() {
				var result = this.callParent(arguments);
				return result;
			},

			/**
			 * @inheritdoc BPMSoft.configuration.ViewModelCollectionGridSchemaV2#onAddButtonClick
			 * @override
			 */
			onAddButtonClick: function() {
				this.set("isNewBusinessRule", true);
				this.set("BusinessRuleDesignerVisible", true);
				this.loadDesigner();
			},

			/**
			 * @inheritdoc BPMSoft.configuration.ViewModelCollectionGridSchemaV2#editRecord
			 * @override
			 */
			editRecord: function() {
				const canEdit = this._getCanEdit();
				if (canEdit) {
					this.set("BusinessRuleDesignerVisible", true);
					this.loadDesigner();
				} else {
					const message = this.get("Resources.Strings.CantEditMessageText");
					this.showInformationDialog(message);
				}
			},

			/**
			 * @inheritdoc BPMSoft.configuration.ViewModelCollectionGridSchemaV2#disableRecord
			 * @override
			 */
			disableRecord: function() {
				var rule = this.getManagerItemByActiveRow();
				rule.getInstance(function(instance) {
					var enabled = instance.getPropertyValue("enabled");
					instance.setPropertyValue("enabled", !enabled);
					this.updateActiveRowEnabledState(!enabled);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.ViewModelCollectionGridSchemaV2#removeRecord
			 * @override
			 */
			removeRecord: function() {
				this.confirmRemoveBusinessRule();
			},

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onSave
			 * @override
			 */
			onSave: function() {
				this.showBodyMask();
				BPMSoft.BusinessRuleSchemaManager.saveToClientUnitSchemaManager(function(response) {
					this.hideBodyMask();
					if (response && response.success) {
						this.publishSavingResult();
					} else {
						const message = response.errorInfo.toString();
						BPMSoft.showErrorMessage(message, null, this);
					}
				}, this);
			},

			/**
			 * Sets IsMultiPage value.
			 * @protected
			 */
			setIsMultiPage: function() {
				const entitySchemaId = this.get("SysModuleEntityId");
				const clientUnitSchemaUId = this.get("ClientUnitSchemaUId");
				if (entitySchemaId && !clientUnitSchemaUId) {
					const moduleEntityManagerItem = BPMSoft.SysModuleEntityManager.getItem(entitySchemaId);
					const typeColumnUId = moduleEntityManagerItem.getTypeColumnUId();
					if (typeColumnUId && BPMSoft.isGUID(typeColumnUId)) {
						this.set("IsMultiPage", true);
					}
				}
			},

			/**
			 * Loads grid data.
			 * @protected
			 */
			loadGridData: function() {
				var gridData = this.get("GridData");
				var businessRules = BPMSoft.BusinessRuleSchemaManager.getItems();
				businessRules.each(function(businessRuleItem) {
					var removed = businessRuleItem.getRemoved();
					if (!removed) {
						var rowItem = this.createBusinessRuleItemRow(businessRuleItem);
						this.setDisableButtonCaption(rowItem);
						gridData.add(businessRuleItem.getUId(), rowItem);
					}
				}, this);
				this.set("IsGridEmpty", gridData.isEmpty());
			},

			/**
			 * Creates a configuration element that will be shown if there are no elements in the list.
			 * @protected
			 * @param {Object} config Preconfigured options.
			 */
			prepareEmptyGridMessageConfig: function(config) {
				var academyUrl = this.get("AcademyUrl");
				var newConfig = BPMSoft.EmptyGridMessageConfigBuilder.getDefaultWizardSectionConfig(academyUrl);
				Ext.apply(config, newConfig);
			},

			/**
			 * Initialize academy link url.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope
			 */
			initHelpUrl: function(callback, scope) {
				AcademyUtilities.getUrl({
					scope: this,
					contextHelpId: this.get("HelpId"),
					callback: function(url) {
						this.set("AcademyUrl", url);
						Ext.callback(callback, scope);
					}
				});
			},

			/**
			 * Returns listed config.
			 * @protected
			 * @return {Object} Listed config.
			 */
			getListedConfig: function() {
				var isMultiPage = this.get("IsMultiPage");
				var additionalCol = isMultiPage ? 0 : 3;
				var listedConfig = {
					"items": [{
						"bindTo": "Name",
						"caption": this.get("Resources.Strings.BusinessRuleGridNameCaption"),
						"position": {
							"column": 0,
							"colSpan": 11 + additionalCol,
							"row": 1
						},
						"captionConfig": {"visible": true},
						"dataValueType": BPMSoft.core.enums.DataValueType.TEXT,
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}, {
						"bindTo": "EnabledText",
						"caption": this.get("Resources.Strings.BusinessRuleGridEnabledCaption"),
						"position": {
							"column": 0,
							"colSpan": 7 + additionalCol,
							"row": 1
						},
						"captionConfig": {"visible": true},
						"dataValueType": BPMSoft.core.enums.DataValueType.TEXT,
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}]
				};
				if (isMultiPage) {
					listedConfig.items.push({
						"bindTo": "Page",
						"caption": this.get("Resources.Strings.BusinessRuleGridPageCaption"),
						"position": {
							"column": 0,
							"colSpan": 6,
							"row": 1
						},
						"captionConfig": {"visible": true},
						"dataValueType": BPMSoft.core.enums.DataValueType.TEXT,
						"contentType": BPMSoft.ContentType.LONG_TEXT
					});
				}
				return listedConfig;
			},

			/**
			 * Sets grid profile.
			 * @protected
			 */
			createBusinessRuleGridProfile: function() {
				var listedConfig = this.getListedConfig();
				var profileKey = "BusinessRuleDataGridProfileKey";
				var profile = {
					"key": profileKey,
					"DataGrid": {
						"tiledConfig": "{}",
						"listedConfig": BPMSoft.encode(listedConfig),
						"key": profileKey,
						"isTiled": false,
						"type": BPMSoft.GridType.LISTED
					}
				};
				var currentProfile = this.get("Profile");
				if (!currentProfile) {
					this.set("Profile", profile);
				} else {
					Ext.apply(currentProfile, profile);
				}
			},

			/**
			 * Updates active row view model.
			 * @protected
			 * @param {BPMSoft.BusinessRuleSchemaManagerItem} item Business rule schema manger item.
			 */
			updateActiveRowViewModel: function(item) {
				if (item.isModified()) {
					var activeRow = this.getActiveRow();
					var itemCaption = item.getCaption();
					var ruleName = itemCaption.getValue() || item.getName();
					activeRow.set("Name", ruleName);
					activeRow.set("Page", this.getFullPageCaption(item));
				}
			},

			/**
			 * Processes section business rule on close business rule manager.
			 * @protected
			 * @param {Object} businessRuleManagerItem Business rule schema manger item.
			 */
			onCloseBusinessRuleSchemaDesigner: function(businessRuleManagerItem) {
				this.sandbox.unloadModule(this.sandbox.id + "_BusinessRuleSchemaDesigner");
				this.set("BusinessRuleDesignerVisible", false);
				if (!businessRuleManagerItem) {
					this.set("isNewBusinessRule", false);
					return;
				}
				if (this.get("isNewBusinessRule")) {
					BPMSoft.BusinessRuleSchemaManager.addItem(businessRuleManagerItem);
					var gridData = this.get("GridData");
					var rowItem = this.createBusinessRuleItemRow(businessRuleManagerItem);
					this.setDisableButtonCaption(rowItem);
					var managerItemUId = businessRuleManagerItem.getUId();
					gridData.add(managerItemUId, rowItem, 0);
					this.set("IsGridEmpty", gridData.isEmpty());
					this.set("isNewBusinessRule", false);
					this.set("ActiveRow", managerItemUId);
					this.reloadGridColumnsConfig(true);
				} else {
					this.updateActiveRowViewModel(businessRuleManagerItem);
				}
			},

			/**
			 * Creates business rule row item.
			 * @protected
			 * @param {BPMSoft.BusinessRuleSchemaManagerItem} item Business rule schema manger item.
			 * @return {BPMSoft.model.BaseViewModel} Business rule item row.
			 */
			createBusinessRuleItemRow: function(item) {
				var itemCaption = item.getCaption();
				var ruleName = (itemCaption && itemCaption.getValue()) || item.getName();
				var enabled = item.getEnabled();
				var invalid = item.getInvalid();
				if (invalid) {
					ruleName += " " + this.get("Resources.Strings.InvalidRulePrefix");
				}
				var page = this.get("IsMultiPage") ? this.getFullPageCaption(item) : null;
				var config = {
					"id": item.getUId(),
					"name": ruleName,
					"enabledText": this.getEnableText(enabled),
					"valid": !invalid,
					"enabled": enabled,
					"page": page
				};
				return this.createRowViewModel(config);
			},

			/**
			 * Creates row view model.
			 * @protected
			 * @param {Object} config Configuration object.
			 * @param {String} config.id Business rule uId.
			 * @param {String} config.name Business rule caption.
			 * @param {String} config.enabledText Enabled text value.
			 * @param {String} config.page Page caption.
			 * @param {Boolean} config.valid Is business rule valid.
			 * @param {Boolean} config.enabled Is business rule enabled.
			 * @return {BPMSoft.model.BaseViewModel} Row view model.
			 */
			createRowViewModel: function(config) {
				return Ext.create("BPMSoft.model.BaseViewModel", {
					primaryColumnName: "Name",
					values: {
						Enabled: config.enabled,
						OpenButtonCaption: this.get("Resources.Strings.OpenButtonCaption"),
						DisableButtonCaption: this.get("Resources.Strings.DisableButtonCaption"),
						DeleteButtonCaption: this.get("Resources.Strings.DeleteButtonCaption")
					},
					methods: {
						onNameLinkClick: BPMSoft.emptyFn,
						onEnabledTextLinkClick: BPMSoft.emptyFn,
						onValidTextLinkClick: BPMSoft.emptyFn,
						onPageTextLinkClick: BPMSoft.emptyFn,
						onPageLinkClick: BPMSoft.emptyFn
					},
					columns: {
						Id: {
							type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
							caption: "Id",
							dataValueType: BPMSoft.core.enums.DataValueType.GUID,
							value: config.id
						},
						Name: {
							type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
							caption: "Name",
							dataValueType: BPMSoft.core.enums.DataValueType.TEXT,
							value: config.name
						},
						EnabledText: {
							type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
							caption: "Enabled",
							dataValueType: BPMSoft.core.enums.DataValueType.TEXT,
							value: config.enabledText
						},
						Valid: {
							type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
							caption: "Valid",
							dataValueType: BPMSoft.core.enums.DataValueType.BOOLEAN,
							value: config.valid
						},
						Page: {
							type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
							caption: "Page",
							dataValueType: BPMSoft.core.enums.DataValueType.TEXT,
							value: config.page
						}
					}
				});
			},

			/**
			 * Returns full page caption.
			 * @protected
			 * @param {BPMSoft.BusinessRuleSchemaManagerItem} item Business rule schema manger item.
			 * @return {String} Full page caption.
			 */
			getFullPageCaption: function(item) {
				var schemaUId = item.getClientUnitSchemaUId();
				var items = BPMSoft.SysModuleEditManager.filterByFn(function(managerItem) {
					return managerItem.getCardSchemaUId() === schemaUId;
				}, this);
				var captionArray = items.mapArray(function(editManagerItem) {
					return editManagerItem.getPageCaption();
				}, this);
				return captionArray.join(", ");
			},

			/**
			 * Initializes business rule manager.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			initBusinessRuleSchemaManager: function(callback, scope) {
				var config = {
					entitySchemaId: this.get("SysModuleEntityId"),
					pageSchemaUId: this.get("ClientUnitSchemaUId")
				};
				BPMSoft.BusinessRuleSchemaManager.clear();
				BPMSoft.BusinessRuleSchemaManager.initializeRules(config, callback, scope);
			},

			/**
			 * Processes getting module designer configuration.
			 * @protected
			 */
			onGetModuleConfigDesigner: function() {
				var config = this.getModuleDesignerConfig();
				var schemaDesignerId = this.getSchemaDesignerSandboxId();
				this.sandbox.publish("GetModuleConfigResultDesigner", config, [schemaDesignerId]);
			},

			/**
			 * Returns module designer configuration.
			 * @protected
			 * @returns {Object} Module designer configuration
			 */
			getModuleDesignerConfig: function() {
				return {
					businessRuleItem: this.get("isNewBusinessRule")
						? BPMSoft.BusinessRuleSchemaManager.createNewManagerItem()
						: BPMSoft.BusinessRuleSchemaManager.getItem(this.get("ActiveRow")),
					entitySchemaId: this.get("SysModuleEntityId"),
					isMultiPage: this.get("IsMultiPage"),
					isNew: this.get("isNewBusinessRule"),
					packageUId: this.get("PackageUId")
				};
			},

			/**
			 * Returns business rule item.
			 * @protected
			 * @return {BPMSoft.BusinessRuleSchemaManagerItem} Business rule item.
			 */
			getManagerItemByActiveRow: function() {
				var rowId = this.get("ActiveRow");
				return BPMSoft.BusinessRuleSchemaManager.getItem(rowId);
			},

			/**
			 * Shows confiramtion to remove business rule.
			 * @protected
			 */
			confirmRemoveBusinessRule: function() {
				var message = this.get("Resources.Strings.ConfirmRemoveBusinessRuleMessage");
				BPMSoft.showConfirmation(message, this.removeBusinessRuleConfirmationHandler,
					["yes", "no"], this, {defaultButton: 0});
			},

			/**
			 * Removes business rule.
			 * @protected
			 * @param {String} buttonCode Button code.
			 */
			removeBusinessRuleConfirmationHandler: function(buttonCode) {
				if (buttonCode === "yes") {
					var rule = this.getManagerItemByActiveRow();
					rule.getInstance(function(instance) {
						instance.setPropertyValue("removed", true);
						this.removeActiveRow();
						var gridData = this.get("GridData");
						this.set("IsGridEmpty", gridData.isEmpty());
					}, this);
				}
			},

			/**
			 * Sets disable button caption.
			 * @protected
			 * @param {Boolean} enabled Enabled sate.
			 */
			updateActiveRowEnabledState: function(enabled) {
				var row = this.getActiveRow();
				row.set("Enabled", enabled);
				this.setDisableButtonCaption(row);
				this.setRowEnabledText(row);
			},

			/**
			 * Sets disable button caption.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} row View model item.
			 */
			setDisableButtonCaption: function(row) {
				var caption = row.get("Enabled")
					? this.get("Resources.Strings.DisableButtonCaption")
					: this.get("Resources.Strings.EnableButtonCaption");
				row.set("DisableButtonCaption", caption);
			},

			/**
			 * Sets enabled item text.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} row View model item.
			 */
			setRowEnabledText: function(row) {
				var enabled = row.get("Enabled");
				var enabledText = this.getEnableText(enabled);
				row.set("EnabledText", enabledText);
			},

			/**
			 * Returns enabled item text.
			 * @protected
			 * @param {Boolean} enabled Is item enabled.
			 * @return {String} Enable text.
			 */
			getEnableText: function(enabled) {
				return enabled
					? this.get("Resources.Strings.BusinessRuleGridEnabledText")
					: this.get("Resources.Strings.BusinessRuleGridDisabledText");
			},

			getSectionLabelText: function() {
				return this.get("Resources.Strings.BusinessRuleListLabel")
			},

			/**
			 * Gets business rule designer visibility.
			 * @return {Boolean} Business rule designer visibility.
			 */
			isBusinessRuleDesignerViewVisible: function() {
				return this.get("IsValid") && this.get("BusinessRuleDesignerVisible");
			},

			/**
			 * Gets business rule section visibility.
			 * @return {Boolean} Business rule section visibility.
			 */
			isBusinessRuleSectionViewVisible: function() {
				return this.get("IsValid") && !this.get("BusinessRuleDesignerVisible");
			},

			/**
			 * Returns invalid business rule section image uri.
			 * @return {String} Invalid business rule section image uri.
			 */
			getInvalidBusinessRuleSectionImageSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.InvalidBusinessRuleSectionImage"));
			}

			// endregion

		},

		diff: /**SCHEMA_DIFF*/[{
			"operation": "merge",
			"name": "DataGridContainer",
			"values": {
				"visible": {"bindTo": "isBusinessRuleSectionViewVisible"}
			}
		},
			{
				"operation": "insert",
				"name": "SectionLabel",
				"parentName": "DataGridContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"id": "sectionLabel",
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": [
							"section-label"
						]
					},
					"caption": {"bindTo": "getSectionLabelText"}
				}
			},
			{
			"operation": "merge",
			"name": "DataGridAddNewRecordButton",
			"values": {
				"caption": {"bindTo": "Resources.Strings.AddNewRuleButtonCaption"},
				"classes": {
					"wrapperClass": ["add-new-business-rule"]
				}
			}
		}, {
			"operation": "merge",
			"name": "DataGrid",
			"values": {
				"getEmptyMessageConfig": {"bindTo": "prepareEmptyGridMessageConfig"}
			}
		}, {
			"operation": "insert",
			"name": "BusinessRuleDesigner",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"id": "BusinessRuleWrapDesignerContainer",
				"wrapClass": ["business-rule-designer-container-wrapClass"],
				"visible": {"bindTo": "isBusinessRuleDesignerViewVisible"},
				"items": []
			}
		}, {
			"operation": "merge",
			"name": "DataGridActiveRowOpenAction",
			"values": {
				"visible": {
					"bindTo": "Valid"
				}
			}
		}, {
			"operation": "merge",
			"name": "DataGridActiveRowDisableAction",
			"values": {
				"visible": {
					"bindTo": "Valid"
				}
			}
		}, {
			"operation": "insert",
			"name": "InvalidBusinessRuleSectionContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["invalid-business-rule-section-container"],
				"visible": {
					"bindTo": "IsValid",
					"bindConfig": {"converter": "invertBooleanValue"}
				},
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "InvalidBusinessRuleSectionImage",
			"parentName": "InvalidBusinessRuleSectionContainer",
			"propertyName": "items",
			"values": {
				"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
				"onPhotoChange": BPMSoft.emptyFn,
				"getSrcMethod": "getInvalidBusinessRuleSectionImageSrc"
			}
		}, {
			"operation": "insert",
			"name": "InvalidBusinessRuleSectionLabelContainer",
			"parentName": "InvalidBusinessRuleSectionContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["invalid-business-rule-section-label-container"],
				"items": []
			}
		}, {
			"operation": "insert",
			"name": "InvalidBusinessRuleSectionLabel",
			"parentName": "InvalidBusinessRuleSectionLabelContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {"bindTo": "InvalidBusinessRuleSectionMessage"}
			}
		}]/**SCHEMA_DIFF*/
	};
});
