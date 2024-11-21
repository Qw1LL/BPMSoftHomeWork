define("SectionMiniPageSettings", ["ViewModelSchemaDesignerUtils",
	"SectionMiniPageSettingsResources", "ApplicationStructureWizardUtils", "MiniPageDesignerViewGenerator",
	"SectionSettingsMixin", "SchemaBuilderV2", "SectionMiniPageWizard"
], function() {
	return {
		mixins: {
			"SectionSettingsMixin": "BPMSoft.SectionSettingsMixin"
		},
		messages: {
			"SaveSectionMiniPageSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"PageSettingsChanged": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"SaveSectionVisaSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Flag that indicates whether mini page in section is available in add mode.
			 */
			"MiniPageAddMode": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag that indicates whether mini page in section is available in edit mode.
			 */
			"MiniPageEditMode": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag that indicates whether mini page in section is available in view mode.
			 */
			"MiniPageViewMode": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * MiniPage schema UId.
			 */
			"MiniPageSchemaUId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				value: null
			},
			/**
			 * Old MiniPage schema UId. Stores schema UId when un-check MiniPageChecked.
			 */
			"OldMiniPageSchemaUId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				value: null
			},
			/**
			 * Flag that indicates whether exists registered module edit or not.
			 */
			"HasModuleEdits": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				values: false
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_saveChanges: function(callback, scope) {
				let pageSettingsChanged = false;
				BPMSoft.chain(
					function(next) {
						const hasCheckedModes = this.get("MiniPageAddMode") ||
							this.get("MiniPageEditMode") ||
							this.get("MiniPageViewMode");
						if (hasCheckedModes && !this.get("MiniPageSchemaUId")) {
							pageSettingsChanged = true;
							this._createMiniPage(next, this);
						} else {
							next();
						}
					},
					function(next) {
						this._updatePages(next, this);
					},
					function() {
						callback.call(scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_getModuleEntitySchemaName: function() {
				const entitySchema = this.getModuleEntitySchema();
				return entitySchema.getPropertyValue("name");
			},

			/**
			 * @private
			 */
			_getMiniPageSchemaName: function() {
				const entitySchemaName = this._getModuleEntitySchemaName();
				const template = BPMSoft.ApplicationStructureWizardUtils.getEntityFullName(
					entitySchemaName, "{0}MiniPage");
				const schemaName = BPMSoft.ClientUnitSchemaManager.getUniqueNameByTemplate(template);
				return schemaName;
			},

			/**
			 * @private
			 */
			_createMiniPage: function(callback, scope) {
				const schemaName = this._getMiniPageSchemaName();
				const schemaType = BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA;
				const bodyTemplate = BPMSoft.ClientUnitSchemaBodyTemplate[schemaType];
				const entitySchemaName = this.getModuleEntitySchema().getPropertyValue("name");
				const body = Ext.String.format(bodyTemplate, schemaName, entitySchemaName);
				const config = {
					uId: BPMSoft.generateGUID(),
					name: schemaName,
					packageUId: this.get("PackageUId"),
					caption: new BPMSoft.LocalizableString(schemaName),
					body: body,
					schemaType: schemaType,
					parentSchemaUId: BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_MINI_PAGE,
					extendParent: false
				};
				const schema = BPMSoft.ClientUnitSchemaManager.createSchema(config);
				BPMSoft.ClientUnitSchemaManager.addSchema(schema);
				this.set("MiniPageSchemaUId", schema.uId);
				this._addHeaderPrimaryDisplayValue(schema);
				schema.define(callback, scope);
			},

			/**
			 * Appends header with label to display primary display column value.
			 * @private
			 * @param schema {BPMSoft.manager.ClientUnitSchema} Mini page client unit schema.
			 */
			_addHeaderPrimaryDisplayValue: function(schema) {
				const oldDiffStr = schema.getSchemaDiff();
				const oldDiff = JSON.parse(oldDiffStr);
				const headerColumnDiff = this._getHeaderColumnDiff();
				const diff = oldDiff.concat(headerColumnDiff);
				schema.setSchemaDiff(diff);
			},

			/**
			 * @private
			 */
			_getHeaderColumnDiff: function() {
				return [
					{
						"operation": "insert",
						"parentName": "HeaderContainer",
						"propertyName": "items",
						"index": 1,
						"name": "HeaderColumnContainer",
						"values": {
							"itemType": "#BPMSoft.ViewItemType.LABEL#",
							"caption": {"bindTo": "getPrimaryDisplayColumnValue"},
							"labelClass": ["label-in-header-container"],
							"visible": {"bindTo": "isNotAddMode"}
						}
					}
				];
			},

			/**
			 * @private
			 */
			_updatePages: function(callback, scope) {
				const miniPageSchemaUId = this.get("MiniPageSchemaUId");
				this.getActiveSysModuleEditManagerItemsChain(function(moduleEdits) {
					moduleEdits.each(function(moduleEdit) {
						moduleEdit.setMiniPageSchemaUId(miniPageSchemaUId);
						const modes = [
							this.get("MiniPageAddMode") ? BPMSoft.ConfigurationEnums.CardOperation.ADD : "",
							this.get("MiniPageEditMode") ? BPMSoft.ConfigurationEnums.CardOperation.EDIT : "",
							this.get("MiniPageViewMode") ? BPMSoft.ConfigurationEnums.CardOperation.VIEW : ""
						].join(";");
						moduleEdit.setMiniPageModes(modes);
						moduleEdit.setForceUpdateColumns(["MiniPageModes"]);
					}, this);
					callback.call(scope);
				}, this);
			},

			/**
			 * @private
			 */
			_subscribeSandboxEvents: function() {
				this.sandbox.subscribe("SaveSectionMiniPageSettings", this.onSaveMiniPageSettings, this,
					[this.sandbox.id]);
				this.mixins.SectionSettingsMixin.subscribeSandboxEvents.call(this);
			},

			/**
			 * @private
			 */
			_pageSettingsChanged: function() {
				this.sandbox.publish("PageSettingsChanged", null, [this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_getSchemaViewModelClass: function(schemaUId, callback, scope) {
				BPMSoft.ClientUnitSchemaManager.getItemByUId(schemaUId, function(item) {
					var builder = new BPMSoft.SchemaBuilder({
						viewGeneratorClassName: "BPMSoft.MiniPageDesignerViewGenerator"
					});
					builder.build({schemaName: item.name}, function(viewModelClass) {
						callback.call(scope, viewModelClass);
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_getMiniPageModes: function(miniPage, callback, scope) {
				let modes = miniPage.getMiniPageModes();
				modes = modes && modes.split(";");
				if (BPMSoft.isEmpty(modes)) {
					this._getOldMiniPageModes(miniPage, callback, scope);
				} else {
					Ext.callback(callback, scope, [modes]);
				}
			},

			/**
			 * @private
			 */
			_getOldMiniPageModes: function(miniPage, callback, scope) {
				let modes;
				BPMSoft.chain(
					function(next) {
						this._getSchemaViewModelClass(miniPage.miniPageSchemaUId, next, this);
					},
					function(next, viewModelClass) {
						const miniPageModes = viewModelClass.prototype.getColumnByName("MiniPageModes");
						modes = (miniPageModes && miniPageModes.value) || [];
						const entitySchemaName = this._getModuleEntitySchemaName();
						const sysSettingName = BPMSoft.getFormattedString("Has{0}MiniPageAddMode", entitySchemaName);
						BPMSoft.SysSettings.querySysSettingsItem(sysSettingName, next, this);
					},
					function(next, hasAddMode) {
						const addMode = BPMSoft.ConfigurationEnums.CardOperation.ADD;
						if (!_.contains(modes, addMode) && hasAddMode) {
							modes.push(addMode);
						} else if (_.contains(modes, addMode) && !hasAddMode) {
							modes = _.without(modes, addMode);
						}
						Ext.callback(callback, scope, [modes]);
					}, this
				);
			},

			/**
			 * @private
			 */
			_subscribeOnChangeMiniPageMode: function() {
				this.on("change:MiniPageAddMode", this.onChangeMiniPageMode, this);
				this.on("change:MiniPageEditMode", this.onChangeMiniPageMode, this);
				this.on("change:MiniPageViewMode", this.onChangeMiniPageMode, this);
			},

			/**
			 * @private
			 */
			_unSubscribeOnChangeMiniPageMode: function() {
				this.un("change:MiniPageAddMode", this.onChangeMiniPageMode, this);
				this.un("change:MiniPageEditMode", this.onChangeMiniPageMode, this);
				this.un("change:MiniPageViewMode", this.onChangeMiniPageMode, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#initLookupQuickAddMixin
			 * @override
			 */
			initLookupQuickAddMixin: function(next, scope) {
				Ext.callback(next, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.set("IsInitialized", false);
				this._subscribeSandboxEvents();
				this.callParent([function() {
					this.mixins.SectionSettingsMixin.init.call(this);
					BPMSoft.ClientUnitSchemaManager.initialize(function() {
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#getInitializedMessageName
			 * @override
			 */
			getInitializedMessageName: function() {
				return "MiniPageModuleSettingsInitialized";
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#initModuleSettings
			 * @override
			 */
			initModuleSettings: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.getActiveSysModuleEditManagerItemsChain(next, this);
					},
					function(next, moduleEdits) {
						this.set("HasModuleEdits", moduleEdits.getCount() > 0);
						const miniPages = moduleEdits.filterByFn(function(moduleEdit) {
							return moduleEdit.getMiniPageSchemaUId();
						}, this);
						const miniPage = miniPages.first();
						if (miniPage) {
							this.set("MiniPageSchemaUId", miniPage.miniPageSchemaUId);
							this._getMiniPageModes(miniPage, next, this);
						} else {
							next();
						}
					},
					function(next, modes) {
						this.set("MiniPageAddMode", _.contains(modes, BPMSoft.ConfigurationEnums.CardOperation.ADD));
						this.set("MiniPageEditMode", _.contains(modes, BPMSoft.ConfigurationEnums.CardOperation.EDIT));
						this.set("MiniPageViewMode", _.contains(modes, BPMSoft.ConfigurationEnums.CardOperation.VIEW));
						this._subscribeOnChangeMiniPageMode();
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @inheritdoc BPMSoft.SectionSettingsMixin#canEdit
			 * @override
			 */
			canEdit: function() {
				const isCanEdit = this.mixins.SectionSettingsMixin.canEdit.call(this);
				return isCanEdit && this.get("HasModuleEdits");
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this._unSubscribeOnChangeMiniPageMode();
				this.callParent(arguments);
			},

			/**
			 * Handler for MiniPageChecked attribute change.
			 * @protected
			 */
			onChangeMiniPageMode: function() {
				this.showBodyMask({selector: "#" + this.renderTo});
				this.isSaving = true;
				this._saveChanges(function() {
					this.hideBodyMask();
					this.isSaving = false;
					Ext.callback(this.savingCallback);
				}, this);
			},

			/**
			 * Handler for onSaveMiniPageSettings message.
			 * @protected
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback function context.
			 */
			onSaveMiniPageSettings: function(callback) {
				if (this.isSaving) {
					this.savingCallback = callback;
				} else {
					this._saveChanges(function() {
						Ext.callback(callback);
					}, this);
				}
			},

			/**
			 * @protected
			 */
			isSinglePageContainerVisible: function() {
				const miniPageSchemaUId = this.get("MiniPageSchemaUId");
				return Boolean(miniPageSchemaUId);
			},

			/**
			 * Opens page wizard for minipage.
			 * @protected
			 * @param {Function} [callback] The callback function.
			 * @param {Object} [scope] The scope of callback function.
			 */
			onSinglePageButtonClick: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.sandbox.publish("SaveSectionVisaSettings", next);
					},
					function() {
						const url = [
							BPMSoft.workspaceBaseUrl,
							BPMSoft.DesignTimeEnums.WizardUrl.SECTION_MINIPAGE_WIZARD_URL,
							[
								BPMSoft.SectionWizardEnums.PageName.PAGE_DESIGNER,
								this.get("SectionManagerItem").id,
								this.get("MiniPageSchemaUId")
							].join("/")
						].join("");
						this.sandbox.publish("PushHistoryState", {hash: url});
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @protected
			 */
			getSinglePageButtonHint: function() {
				let result = null;
				if (!this.canEdit()) {
					result = this.get("Resources.Strings.RequiredSetupSectionPage");
				} else if (!this.get("MiniPageSchemaUId")) {
					result = this.get("Resources.Strings.RequiredSelectModes");
				}
				return result;
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "MiniPageSettingsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [
						{
							"name": "TopControlGroupTextContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {"wrapClassName": ["section-settings-label-container"]},
							"items": [
								{
									"name": "MiniPageLabel",
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {"bindTo": "Resources.Strings.MiniPageSettingsCaption"},
									"labelClass": ["section-settings-label"]
								}
							]
						},
						{
							"name": "MiniPageModesContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["modes-container"],
							"items": [
								{
									"name": "MiniPageModesLabel",
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {"bindTo": "Resources.Strings.MiniPageModesCaption"},
									"labelClass": ["t-label modes-label"]
								},
								{
									"name": "MiniPageModesInnerContainer",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["modes-inner-container"],
									"items": [
										{
											"name": "MiniPageAddMode",
											"caption": {"bindTo": "Resources.Strings.AvailableMiniPageAddModeCaption"},
											"enabled": {"bindTo": "canEdit"},
											"wrapClass": ["t-checkbox-control"]
										},
										{
											"name": "MiniPageEditMode",
											"caption": {"bindTo": "Resources.Strings.AvailableMiniPageEditModeCaption"},
											"enabled": {"bindTo": "canEdit"},
											"wrapClass": ["t-checkbox-control"]
										},
										{
											"name": "MiniPageViewMode",
											"caption": {"bindTo": "Resources.Strings.AvailableMiniPageViewModeCaption"},
											"enabled": {"bindTo": "canEdit"},
											"wrapClass": ["t-checkbox-control"]
										}
									]
								},
								{
									"name": "SinglePageContainer",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"classes": {"wrapClassName": ["single-page-container"]},
									"items": [
										{
											"name": "SetupMiniPageButton",
											"itemType": BPMSoft.ViewItemType.BUTTON,
											"caption": {"bindTo": "Resources.Strings.SetupMiniPageButtonCaption"},
											"click": {"bindTo": "onSinglePageButtonClick"},
											"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
											"enabled": {
												"bindTo": "MiniPageSchemaUId",
												"bindConfig": {"converter": "toBoolean"}
											},
											"hint": {"bindTo": "getSinglePageButtonHint"}
										}
									]
								}
							]
						}
					]
				}
			}
		]
	};
});
