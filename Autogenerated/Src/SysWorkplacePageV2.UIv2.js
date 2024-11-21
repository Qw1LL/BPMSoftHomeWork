define("SysWorkplacePageV2", ["ServiceHelper", "SystemOperationsPermissionsMixinResources", "SectionServiceMixin", "css!SysWorkplacePageV2Styles"],
	function(serviceHelper, resources) {
		return {
			entitySchemaName: "SysWorkplace",
			messages: {
				/**
				 * @message UpdateWorkplaceType
				 * Calls workplace type update for page and detail.
				 */
				"UpdateWorkplaceType": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message RefreshWorkplace
				 * Calls refresh workplace structure.
				 */
				"RefreshWorkplace": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {
				/**
				 * @class SectionServiceMixin
				 * Section service mixin.
				 */
				SectionServiceMixin: BPMSoft.SectionServiceMixin
			},

			attributes: {
				/**
				 * Sign that current workplace is portal.
				 */
				"IsCurrentWorkplaceSSP": {
					dataValue: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Section types enum.
				 * @protected
				 */
				"SectionTypes": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Workplace type.
				 */
				"Type": {
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						"columns": ["Code"]
					}
				},

				/**
				 * Home page lookup.
				 */
				HomePageLookup: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Available home pages.
				 */
				AvailableHomePages: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				CanEnableEditButton: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			properties: {
				_isAddNewHomePage: false,
				_isCopyHomePage: false
			},

			details: /**SCHEMA_DETAILS*/{
				SysAdminUnit: {
					schemaName: "SysAdminUnitInWorkplaceDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysWorkplace"
					},
					defaultValues: {
						SysWorkplace: {
							masterColumn: "Id"
						}
					}
				},
				SysModule: {
					schemaName: "SysModuleInWorkplaceDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysWorkplace"
					},
					defaultValues: {
						SysWorkplace: {
							masterColumn: "Id"
						},
						IsCurrentWorkplaceSSP: {
							masterColumn: "IsCurrentWorkplaceSSP"
						},
						SectionTypes: {
							masterColumn: "SectionTypes"
						}
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				//region Methods: Private

				/**
				 * Updates card state after workplace saved using workplace API.
				 * @private
				 * @param {Object} result Save workplace result.
				 */
				_updateCardState: function(result) {
					const workplaceId = result.CreateWorkplaceResult;
					this.$Id = workplaceId;
					this.$PrimaryColumnValue = workplaceId;
					this.isNew = false;
					this.updateDetails();
				},

				/**
				 * Set workplace type from defaultValues.
				 * @private
				 */
				_applyWorkplaceTypeValues: function() {
					if (this.getIsFeatureDisabled("UseTypedWorkplaces")) {
						return;
					}
					const type = this.getDefaultValueByName("Type");
					const code = this.getDefaultValueByName("Code");
					this.$Type = type ? {value: type} : this.$Type;
					this.$TypeCode = BPMSoft.isNotEmpty(code) ? code : this.$TypeCode;
				},

				/**
				 * @private
				 */
				_getHomePageEsq: function() {
					const baseSchemaUId = "0c5cfb7a-1ed9-41b8-905e-9a38c6915550";
					const esqAngularHomePages = new BPMSoft.EntitySchemaQuery({
						rootSchemaName: "SysSchema",
						isDistinct: true
					});
					esqAngularHomePages.addColumn("UId");
					esqAngularHomePages.addColumn("ModifiedOn");
					esqAngularHomePages.addColumn("Name");
					esqAngularHomePages.addColumn(
						"=[VwSysSchemaExtending:BaseSchemaId:Id].[SysSchema:Id:TopExtendingSchemaId].Caption",
						"Caption");
					esqAngularHomePages.addParameterColumn(true, BPMSoft.DataValueType.BOOLEAN,
						"isHomePage");
					const filterName = BPMSoft.createColumnFilterWithParameter(
						"[SysSchemaProperty:SysSchema:Id].Name", "SchemaType");
					const filterType = BPMSoft.createColumnFilterWithParameter(
						"[SysSchemaProperty:SysSchema:Id].Value", "AngularSchema");
					esqAngularHomePages.filters.add("SchemaPropertyNameFilter", filterName);
					esqAngularHomePages.filters.add("SchemaPropertyTypeFilter", filterType);
					const baseSchemaFilter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "UId", baseSchemaUId);
					esqAngularHomePages.filters.add("BaseSchemaFilter", baseSchemaFilter);
					return esqAngularHomePages;
				},

				/**
				 * @private
				 */
				_getMainPageEsq: function() {
					const esqMainPages = new BPMSoft.EntitySchemaQuery({
						rootSchemaName: "ApplicationMainMenu",
						isDistinct: true
					});
					esqMainPages.addColumn("IntroPageUId", "UId");
					esqMainPages.addColumn("[SysSchema:UId:IntroPageUId].Caption", "Caption");
					esqMainPages.addColumn("ModifiedOn");
					esqMainPages.addColumn("Name");
					return esqMainPages;
				},

				/**
				 * @private
				 */
				_initAvailableHomePages: function(callback, scope) {
					if (this.canSetHomePageForWorkplace()) {
						const batch = Ext.create("BPMSoft.BatchQuery");
						batch.add(this._getHomePageEsq());
						batch.add(this._getMainPageEsq());
						batch.execute((response) => {
							this.$AvailableHomePages = new BPMSoft.Collection();
							for (const queryResult of response.queryResults) {
								if (queryResult.success) {
									queryResult.rows.forEach(function(item) {
										this.$AvailableHomePages.add(item.UId, {
											uId: item.UId,
											caption: item.Caption,
											modifiedOn: item.ModifiedOn,
											isHomePage: item.isHomePage,
											name: item.Name
										});
									}, this);
								}
							}
							this.$AvailableHomePages.sortByFn((item1, item2) => Date.parse(item2.modifiedOn) - Date.parse(item1.modifiedOn));
							Ext.callback(callback, scope);
						});
					} else {
						Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_prepareHomePageList: function(filter, list) {
					const result = {};
					BPMSoft.each(this.$AvailableHomePages, function({uId, caption}) {
						result[uId] = {
							value: uId,
							displayValue: caption
						};
					}, this);
					list.reloadAll(result);
				},

				/**
				 * @private
				 */
				_onServerMessage: function(channel, message) {
					if (message && message.event === "HomePageDesignerSaved") {
						this._initAvailableHomePages(() => {
							if ((!this.$HomePageUId && this._isAddNewHomePage) || this._isCopyHomePage) {
								const schemaName = message.name;
								const item = this.$AvailableHomePages.findByFn((item) => item.name === schemaName);
								this.$HomePageUId = item.uId;
								this._isAddNewHomePage = false;
								this._isCopyHomePage = false;
								this.onItemFocused();
							}
							this._initHomePageLookup();
						});
					}
				},

				/**
				 * @private
				 */
				_initHomePageLookup: function() {
					if (this.canSetHomePageForWorkplace()) {
						this.$HomePageLookup = {
							value: this.$HomePageUId,
							displayValue: this._findHomePageCaption()
						};
					}
				},

				/**
				 * @private
				 */
				_findHomePageCaption: function() {
					if (!this.$HomePageUId) {
						return "";
					}
					const homePage = this.$AvailableHomePages?.find(this.$HomePageUId);
					if (!homePage?.caption) {
						const message = this.get("Resources.Strings.HomepageWithUIdNotFound");
						this.showInformationDialog(message);
						this.error(message);
					}
					return homePage?.caption || this.$HomePageUId;
				},

				//endregion

				//region Methods: Protected

				/**
				 * ############## ####### ######### ########
				 * @protected
				 */
				initHeaderCaption: function() {
					const caption = this.get("Resources.Strings.HeaderCaption");
					this.set("NewRecordPageCaption", caption);
				},

				/**
				 * ########## ###### ######### ######## ########
				 * @override
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########
				 */
				getActions: function() {
					const actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					return actionMenuItems;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([
						function() {
							this._applyWorkplaceTypeValues();
							BPMSoft.chain(
								this.initSectionTypes.bind(this),
								this._initAvailableHomePages.bind(this),
								() => {
									this._initHomePageLookup();
									this.on("change:HomePageLookup", () => {
										this.$HomePageUId = this.$HomePageLookup?.value;
										this._setCanEnableEditButton();
									}, this);
									this._setCanEnableEditButton();
									BPMSoft.ServerChannel.on(BPMSoft.ServerChannelSender.BROADCAST_MESSAGE,
										this._onServerMessage, this);
									Ext.callback(callback, scope);
								}
							);
						}, this
					]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#reloadEntity
				 * @overridden
				 */
				reloadEntity: function(callback, scope) {
					this.callParent([
						() => {
							BPMSoft.chain(
								(next) => {
									if (this.$AvailableHomePages) {
										next();
									} else {
										this._initAvailableHomePages(next, this);
									}
								},
								() => {
									this._initHomePageLookup();
									Ext.callback(callback, scope);
								}
							);
						}, this
					]);
				},


				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
				 * @overridden
				 */
				onDiscardChangesClick: function(callback, scope) {
					this.callParent([
						() => {
							this._initHomePageLookup();
							this.Ext.callback(callback, scope);
						}
					]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("UpdateWorkplaceType", this.updateWorkplaceType, this);
				},

				/**
				 * Updates workplace type for page and section.
				 * @protected.
				 */
				updateWorkplaceType: function() {
					this.initCurrentWorkspaceType(this.$SectionTypes, function() {
						const detailId = this.getDetailId("SysModule");
						this.sandbox.publish("UpdateWorkplaceType", this.$IsCurrentWorkplaceSSP, [detailId]);
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.getIsFeatureEnabled("UseTypedWorkplaces") && this.isEditMode()) {
						this.$TypeCode = this.$Type && this.$Type.Code;
						this.initCurrentWorkspaceType();
					}
				},

				/**
				 * Sets "SectionTypes" attribute.
				 * @overridden
				 * @param {Object} result Section types enum (values: "General" or "SSP").
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				processedSectionTypes: function(result, callback, scope) {
					const sectionTypes = JSON.parse(result.GetSectionTypesResult);
					this.$SectionTypes = sectionTypes;
					this.initCurrentWorkspaceType(sectionTypes, callback, scope);
				},

				/**
				 * Initializes "IsCurrentWorkplaceSSP" attribute.
				 * @protected
				 * @param {Object} sectionTypes Section types enum (values: "General" or "SSP").
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				initCurrentWorkspaceType: function(sectionTypes, callback, scope) {
					if (this.getIsFeatureEnabled("UseTypedWorkplaces") && !this.BPMSoft.isNull(this.$TypeCode)) {
						this.$IsCurrentWorkplaceSSP = Boolean(this.$TypeCode);
						this.Ext.callback(callback, scope || this);
						return;
					}
					const config = {
						data: {
							"type": sectionTypes.SSP
						},
						serviceName: "WorkplaceService",
						methodName: "GetWorkplacesByType"
					};
					this.callService(config, function(result) {
						const workplacesByType = result.GetWorkplacesByTypeResult;
						if (workplacesByType) {
							const currentWorkplaceSSP = Ext.Array.findBy(workplacesByType, function(item) {
								return JSON.parse(item).Id === this.$PrimaryColumnValue;
							}, this);
							this.$IsCurrentWorkplaceSSP = !Ext.isEmpty(currentWorkplaceSSP);
						}
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseEntityPage#save
				 * @override
				 */
				save: function(config) {
					var name = this.$Name;
					if(this.Ext.isEmpty(name))
					{
						this.showInformationDialog(this.get("Resources.Strings.CaptionValidation"),
											this.informationDialogButtonHandler);
											return;
					}
				if (!this.isAddMode()) {
					this.callParent(arguments);
					return;
				}
				this.saveUsingApi(config);			
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 */
				onSaved: function() {
					if (this.canSetHomePageForWorkplace()) {
						serviceHelper.callService("WorkplaceService", "ResetScriptCache", () => {
							this.sandbox.publish("RefreshWorkplace");
						});
					}
					this.callParent(arguments);
				},

				/**
				 * Saves new workplace using workplace API.
				 * @protected
				 * @param {Object} config Save card config.
				 */
				saveUsingApi: function(config) {
					const sectionTypes = this.$SectionTypes || {};
					const type = this.getIsFeatureEnabled("UseTypedWorkplaces")
						? this.$TypeCode
						: sectionTypes.GENERAL;
					const serviceConfig = {
						data: {
							name: this.$Name,
							type,
							homePageUId: this.$HomePageUId
						},
						serviceName: "WorkplaceService",
						methodName: "CreateWorkplace"
					};
					this.callService(serviceConfig, function(result) {
						if (result.CreateWorkplaceResult.success) {
							this._updateCardState(result);
							this.BPMSoft.chain(this.saveDetailsInChain, function () {
								this.onSaved({ success: true }, config);
							}, this);
						}
						else
							this.BPMSoft.showInformation(result.CreateWorkplaceResult.errorInfo.message)
					}, this);
				},

				/**
				 * Determines whenever user can set the home page for workplace.
				 * @protected
				 */
				canSetHomePageForWorkplace: function() {
					return !this.$IsCurrentWorkplaceSSP && BPMSoft.Features.getIsDisabled("DisableHomePageInWorkplace");
				},

				/**
				 * @private
				 */
				_setCanEnableEditButton: function() {
					let canShow = true;
					if (this.$HomePageUId && this.$AvailableHomePages) {
						const item = this.$AvailableHomePages.findByFn((item) => item.uId === this.$HomePageUId);
						canShow = item && item.isHomePage;
					}
					this.$CanEnableEditButton = this.canSetHomePageForWorkplace() && canShow;
				},

				/**
				 * @protected
				 */
				getHomePageDesignerButtonImage: function() {
					const imageName = this.$HomePageUId ? "OpenButtonImage" : "AddButtonImage";
					return this.get("Resources.Images." + imageName);
				},

				/**
				 * Returned edit home button page hint.
				 * @protected
				 * @return {String}
				 */
				getHomePageDesignerButtonHint: function() {
					let stringName;
					if (this.$CanEnableEditButton) {
						stringName = this.$HomePageUId
							? "OpenHomePageDesignerButtonHintCaption"
							: "AddNewHomePageButtonHintCaption";
					} else {
						stringName = "CannotEditPageHintCaption";
					}
					return this.get("Resources.Strings." + stringName);
				},

				/**
				 * Returned copy home button page hint.
				 * @protected
				 * @return {String}
				 */
				getCopyHomePageDesignerButtonHint: function() {
					const stringName = this.getCopyButtonEnabled()
						? "CopyHomePageDesignerButtonHintCaption"
						: "CannotCopyPageHintCaption";
					return this.get("Resources.Strings." + stringName);
				},

				/**
				 * @private
				 */
				_getHomePageDesignerUrl: function(homePageUId, operation, caption) {
					let url = BPMSoft.workspaceBaseUrl + "/ClientApp/#/HomePageDesigner";
					if (operation) {
						url += "/" + operation;
					}
					if (homePageUId) {
						url += "/" + homePageUId;
					}
					if (caption && !homePageUId) {
						const captionParam = new URLSearchParams();
						captionParam.set("workplace", caption);
						url += "?" + captionParam.toString();
					}
					return url;
				},

				/**
				 * @private
				 */
				_showCanNotChangeAdminOperationMessage: function() {
					const localizableStrings = resources.localizableStrings;
					let message = localizableStrings.RightsErrorMessage;
					message += Ext.String.format(localizableStrings.CanNotChangeAdminOperationMessage, "CanManageSolution");
					BPMSoft.showInformation(message);
				},

				_getGoogleAction: function(action) {
					let tag = "HomePageDesigner_OpenFromWorkplace";
					if (action) {
						tag += "_" + action;
					}
					return tag;
				},

				_getGoogleTagData: function(tag) {
					const sandbox = this.sandbox;
					return {
						action: tag,
						schemaName: this.name,
						moduleName: sandbox.moduleName,
						virtualUrl: BPMSoft.workspaceBaseUrl + "/" + sandbox.id
					};
				},

				_sendGoogleAnalytics: function(action) {
					const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
					if (!isGoogleTagManagerEnabled) {
						return;
					}
					const tag = this._getGoogleAction(action);
					const data = this._getGoogleTagData(tag);
					BPMSoft.GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * @protected
				 */
				openHomePageDesigner: function() {
					if (!this.$CanDesignPage) {
						return this._showCanNotChangeAdminOperationMessage();
					}
					this._isAddNewHomePage = !this.$HomePageUId;
					const operation = this._isAddNewHomePage ? "add": "edit";
					const url = this._isAddNewHomePage
						? this._getHomePageDesignerUrl(this.$HomePageUId, operation, this.$Name)
						: this._getHomePageDesignerUrl(this.$HomePageUId);
					this._sendGoogleAnalytics(operation);
					window.open(url, "_blank");
				},

				/**
				 * @protected
				 */
				copyHomePageDesigner: function() {
					this.save({
						isSilent: true,
						callback: ({success}) => {
							if (!success) {
								return;
							}
							if (!this.$CanDesignPage) {
								return this._showCanNotChangeAdminOperationMessage();
							}
							this._isCopyHomePage = true;
							const operation = "copy";
							const url = this._getHomePageDesignerUrl(this.$HomePageUId, operation);
							this._sendGoogleAnalytics(operation);
							window.open(url, "_blank");
						},
						scope: this
					});
				},

				/**
				 * Returns flag that indicates when to enable copy button
				 * @protected
				 */
				getCopyButtonEnabled: function() {
					return this.$AvailableHomePages?.findByFn((item) => item.uId === this.$HomePageUId)?.isHomePage;
				},

				/**
				 * @inheritdoc WizardUtilities#initCanDesignPage
				 * @override
				 */
				initCanDesignPage: function(callback, scope) {
					this.canUseWizard(function(result) {
						this.set("CanDesignPage", result);
						this.Ext.callback(callback, scope || this);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#destroy
				 * @overridden
				 */
				destroy: function() {
					this.callParent(arguments);
					BPMSoft.ServerChannel.un(BPMSoft.ServerChannelSender.BROADCAST_MESSAGE, this._onServerMessage,
						this);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"bindTo": "Name",
						"layout": {"column": 0, "row": 0, "colSpan": 11}
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "HomePageLookup",
					"values": {
						"caption": "$Resources.Strings.HomePageCaption",
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": "$_prepareHomePageList"
						},
						"visible": {
							"bindTo": "canSetHomePageForWorkplace"
						},
						"layout": {"column": 13, "row": 0, "colSpan": 10}
					}
				}, {
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "HomePageButtonContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["home-page-button-container"],
						"layout": {"column": 23, "row": 0, "colSpan": 1},
						"visible": {
							"bindTo": "canSetHomePageForWorkplace"
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"name": "OpenHomePageDesignerButton",
					"parentName": "HomePageButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"hint": {
							"bindTo": "getHomePageDesignerButtonHint"
						},
						"imageConfig": {
							"bindTo": "getHomePageDesignerButtonImage"
						},
						"classes": {
							"wrapperClass": ["open-home-page-designer-button"]
						},
						"click": {"bindTo": "openHomePageDesigner"},
						"enabled": {
							"bindTo": "CanEnableEditButton"
						}
					}
				}, {
					"operation": "insert",
					"name": "copyHomePageDesignerButton",
					"parentName": "HomePageButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"hint": {
							"bindTo": "getCopyHomePageDesignerButtonHint"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.CopyButtonImage"
						},
						"classes": {
							"wrapperClass": ["open-home-page-designer-button"]
						},
						"click": {"bindTo": "copyHomePageDesigner"},
						"enabled": {
							"bindTo": "HomePageUId",
							"bindConfig": {
								"converter": "getCopyButtonEnabled"
							}
						}
					}
				}, {
					"operation": "insert",
					"name": "SettingsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {bindTo: "Resources.Strings.SettingsTabCaption"},
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "SysModule",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}, {
					"operation": "insert",
					"parentName": "SettingsTab",
					"propertyName": "items",
					"name": "SysAdminUnit",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}, {
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "remove",
					"name": "NewRecordPageCaption",
					"parentName": "HeaderCaptionContainer",
				}
			]/**SCHEMA_DIFF*/
		};
	});
