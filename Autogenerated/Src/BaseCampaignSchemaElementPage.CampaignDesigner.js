/**
 * BaseCampaignSchemaElementPage edit page schema.
 * Parent: BaseProcessSchemaElementPropertiesPage.
 */
define("BaseCampaignSchemaElementPage", ["LookupUtilities", "AcademyUtilities",
		"CampaignElementTemplateMixin", "ContainerReadOnlyControlsMixin"], function(LookupUtilities) {
	return {
		mixins: {
			elementTemplateMixin: "BPMSoft.CampaignElementTemplateMixin",
			readOnlyControls: "BPMSoft.ContainerReadOnlyControlsMixin"
		},
		messages: {
			/**
			 * @message IsDesignerReadOnlyMode
			 */
			"IsDesignerReadOnlyMode": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Flag to indicate that element can save properties.
			 * @type {Boolean}
			 */
			"CanSaveElementConfig": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},

			/**
			 * Url of the academy page.
			 */
			"AcademyUrl": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Flag to indicate readonly state of designer.
			 */
			"IsReadOnly": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			}
		},
		properties: {
			/**
			 * The container identifier for campaign element properties.
			 * @protected
			 * @virtual
			 * @type {String}
			 */
			propertiesContainerSelector: "#schema-designer-properties-ct",
			/**
			 * Unique identifier of page editors container.
			 * @type {String}
			 */
			editorsContainerId: "BaseCampaignSchemaElementPage_ReadOnlyContainerId"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.$IsReadOnly = this.sandbox.publish("IsDesignerReadOnlyMode");
				this.initAcademyUrl(this.onAcademyUrlInitialized, this);
			},

			/**
			 * Initializes campaign element page parameters async.
			 * @protected
			 * @param {CampaignBaseElementSchema} element Campaign element.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			initPageAsync: function(element, callback, scope) {
				callback.call(scope);
			},

			/**
			 * @inheritdoc BPMSoft.ProcessSchemaElementEditable#onElementDataLoad
			 * @override
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					BPMSoft.chain(
						function(next) {
							this.initPageAsync(element, next, this);
						},
						function(next) {
							this.initElementProperties(element, next, this);
						},
						function() {
							callback.call(scope);
							if (this.$IsReadOnly) {
								this.setControlsReadOnly(this.$IsReadOnly, this.editorsContainerId);
							}
						},
						this
					);
				}, this]);
			},

			/**
			 * Handler for academy URL initialized event.
			 * @protected
			 */
			onAcademyUrlInitialized: function() {
				this.initInfoText();
			},

			/**
			 * Initializes information text.
			 * @private
			 */
			initInfoText: function() {
				var academyUrl = this.get("AcademyUrl");
				var informationText = this.get("Resources.Strings.ProcessInformationText");
				informationText = this.Ext.String.format(informationText, academyUrl);
				this.set("Resources.Strings.ProcessInformationText", informationText);
			},

			/**
			 * Returns code of the context help.
			 * @return {String}
			 * @protected
			 */
			getContextHelpCode: this.Ext.emptyFn,

			/**
			 * Initializes url to the academy.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The callback execution context.
			 * @private
			 */
			initAcademyUrl: function(callback, scope) {
				BPMSoft.AcademyUtilities.getUrl({
					contextHelpCode: this.getContextHelpCode(),
					callback: function(academyUrl) {
						this.set("AcademyUrl", academyUrl);
						this.Ext.callback(callback, scope);
					},
					scope: this
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#getValidationResultModel
			 * @override
			 */
			getValidationResultModel: function(validationResult) {
				var validationType = validationResult.validationType || BPMSoft.ValidationType.ERROR;
				return {
					validationType: validationType,
					message: validationResult.fullInvalidMessage || validationResult.invalidMessage,
					propertyName: validationResult.propertyName,
					isCustomMessage: validationResult.isCustomMessage
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#setValidationState
			 * @override
			 */
			setValidationState: function(isElementValid) {
				var element = this.$ProcessElement;
				element.setPropertyValue("isValidateExecuted", true, {
					silent: true
				});
				element.setPropertyValue("isValid", isElementValid, {
					silent: !isElementValid
				});
			},

			/**
			 * Returns lookup config for open lookup.
			 * @return {Object} lookupConfig Resut config for open lookup.
			 * @protected
			 */
			getLookupConfig: function() {
				var config = {
					hideActions: true,
					settingsButtonVisible: false,
					multiSelect: false
				};
				return config;
			},

			/**
			 * Displays default messageBox with specific message content.
			 * @protected
			 * @param {String} caption Caption of MeaasgeBox.
			 * @param {String} message Message that displays inside message block.
			 * @param {Array} currentButtons Collection of MessageBox buttons to display.
			 * @param {Function} handler Callback function to call when messageBox will be closed.
			 * @param {Object} scope Context.
			 */
			showMessageBox: function(caption, message, currentButtons, handler, scope) {
				BPMSoft.ProcessSchemaDesignerUtilities.showProcessMessageBox({
					caption: caption,
					message: message,
					buttons: currentButtons,
					defaultButton: 0,
					handler: handler,
					scope: scope
				});
			},

			/**
			 * Loads element properties page mask.
			 * @protected
			 */
			loadPropertiesPageMask: function() {
				return this.showBodyMask({
					selector: this.propertiesContainerSelector,
					opacity: 0.5,
					showHidden: true,
					clearMasks: true
				});
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getLookupPageConfig
			 * @overridden
			 */
			getLookupPageConfig: function() {
				var config = this.callParent(arguments);
				config.hideActions = true;
				config.settingsButtonVisible = false;
				return config;
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getIsSerializeToDBVisible
			 * @overridden
			 */
			getIsSerializeToDBVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getIsLoggingVisible
			 * @overridden
			 */
			getIsLoggingVisible: function() {
				return false;
			},

			/**
			 * Handles element properties loaded event.
			 * @param {String} elementConfig Serialized config of campaign element.
			 */
			onElementConfigLoaded: function(elementConfig) {
				element = JSON.parse(elementConfig);
				this.initElementProperties(element, BPMSoft.emptyFn, this);
			},

			/**
			 * Initializes campaign element properties async.
			 * @protected
			 * @param {CampaignBaseElementSchema} element Campaign element.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			initElementProperties: function(element, callback, scope) {
				callback.call(scope);
			},

			/**
			 * Handles click on Select from lookup element properties button.
			 * @protected
			 */
			onSelectElementConfigClick: function() {
				var config = this.getElementLookupConfig();
				LookupUtilities.Open(this.sandbox, config, this.onElementConfigSelected, this, null, false, false);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues.
			 * @override
			 */
			saveValues: function() {
				var element = this.get("ProcessElement");
				this.set("description", element.description && element.description.toString());
				this.callParent(arguments);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "TopContainer",
				"parentName": "HeaderContainer",
				"values": {
					"wrapClass": ["top-container-wrapClass", "control-width-15"]
				}
			},
			{
				"operation": "remove",
				"parentName": "ToolsContainer",
				"name": "ToolsButton"
			},
			{
				"operation": "merge",
				"parentName": "PropertiesContainer",
				"propertyName": "items",
				"name": "EditorsContainer",
				"values": {
					"id": "BaseCampaignSchemaElementPage_ReadOnlyContainerId"
				}
			},
			{
				"operation": "insert",
				"name": "ActionsContainer",
				"propertyName": "items",
				"parentName": "EditorsContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"visible": "$getCanSaveElementConfig",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ElementConfigContainer",
				"parentName": "ActionsContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"colSpan": 24,
						"row": 0
					},
					"id": "ElementSettingsContainer",
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ElementConfigTextLabel",
				"parentName": "ElementConfigContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.ElementConfigCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc", "element-settings-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ElementConfigHint",
				"parentName": "ElementConfigContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.ElementConfigHintText",
					"controlConfig": {
						"classes": {
							"wrapperClass": "information-button"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "ElementConfigActionsContainer",
				"parentName": "ActionsContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"colSpan": 24,
						"row": 1
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["element-properties-actions-wrap"]
				}
			},
			{
				"operation": "insert",
				"name": "SelectElementConfigButton",
				"parentName": "ElementConfigActionsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": "$Resources.Strings.SelectFromLookupButtonText",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"click": "$onSelectElementConfigClick",
					"classes": {
						wrapperClass: ["action-button-control"]
					}
				}
			},
			{
				"operation": "merge",
				"parentName": "TitleContainer",
				"name": "caption",
				"values": {
					"enabled": {
						bindTo: "IsReadOnly",
						bindConfig: {converter: "invertBooleanValue"}
					},
					"wrapClass": ["campaign-properties-title-wrap"]
				}
			},
			{
				"operation": "merge",
				"parentName": "ToolsContainer",
				"propertyName": "items",
				"name": "InfoButton",
				"values": {
					"controlConfig": {
						"imageConfig": {
							"bindTo": "Resources.Images.InfoButtonImageWhite"
						}
					},
				}
			},
			{
				"operation": "insert",
				"name": "ActionsBottomContainer",
				"propertyName": "items",
				"parentName": "EditorsContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"index": 10,
				"values": {
					"layout": {
						"row": 10
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"visible": "$getCanSaveElementConfig",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ElementConfigActionsBottomContainer",
				"parentName": "ActionsBottomContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"colSpan": 24,
						"row": 1
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["element-properties-actions-wrap"]
				}
			},
			{
				"operation": "insert",
				"name": "SaveElementConfigButton",
				"parentName": "ElementConfigActionsBottomContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": "$Resources.Strings.SaveTemplateButtonText",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"click": "$onSaveElementConfigClick",
					"classes": {
						wrapperClass: ["action-button-control"]
					}
				}
			},
		]/**SCHEMA_DIFF*/
	};
});
