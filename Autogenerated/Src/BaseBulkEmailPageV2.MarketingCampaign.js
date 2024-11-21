define("BaseBulkEmailPageV2", ["BaseBulkEmailPageV2Resources", "InformationButtonResources", "ConfigurationEnums", "BusinessRuleModule",
			"MarketingEnums", "CampaignEnums", "BulkEmailHelper", "EmailHelperModule", "LookupUtilities",
			"AcademyUtilities", "BulkEmailContentBuilderEnumsModule", "BaseFiltersGenerateModule",
			"BulkEmailTemplateHelper", "InformationButtonResources", "BulkEmailHyperlinkCorrector",
			"MacroUtils", "BulkEmailSenderValidator", "MacrosModule", "MacrosUtilities", "BpmCrmCloudServiceApi",
			"MultilineLabel", "BulkEmailAnalytics", "EntityHelper", "DCTemplateReplicaRepository",
			"css!BaseBulkEmailPageV2Styles", "css!DetailModuleV2", "BulkEmailTemplateEntriesMixin",
			"BulkEmailTemplateValidator", "ContentExporterFactory", "BulkEmailAudienceDetail",
			"SendTestEmailContentSchema", "css!SendTestEmailContentSchemaCSS", "CronExpressionPageMixin",
			"ThrottlingModeExtendedTip", "css!ThrottlingModeExtendedTip"],
		/*jshint maxparams: 16 */
		function(resources, informationButtonResources, Enums, BusinessRuleModule, MarketingEnums, CampaignEnums, BulkEmailHelper,
				EmailHelperModule, LookupUtilities, AcademyUtilities, BulkEmailContentBuilderEnumsModule,
				BaseFiltersGenerateModule, BulkEmailTemplateHelper, informationButtonResources,
				BulkEmailHyperlinkCorrector, MacroUtils, BulkEmailSenderValidator) {
			return {
				entitySchemaName: "BulkEmail",
				mixins: {
					Analytics: "BPMSoft.BulkEmailAnalytics",
					EntityHelper: "BPMSoft.EntityHelper",
					MacrosUtilities: "BPMSoft.MacrosUtilities",
					BulkEmailTemplateEntriesMixin: "BPMSoft.BulkEmailTemplateEntriesMixin",
					cronExpressionPageMixin : "BPMSoft.CronExpressionPageMixin"
				},
				modules: /**SCHEMA_MODULES*/{
					"DCClickHeatmap": {
						"config": {
							"schemaName": "DCClickHeatmapSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false
						}
					},
					"DCTemplateViewer": {
						"config": {
							"schemaName": "DCTemplateViewerSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false
						}
					},
					"TestEmail": {
						"config": {
							"schemaName": "SendTestEmailContentSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									"BulkEmail": {
										"attributeValue": "Id"
									},
									"ReplicaMask": {
										"getValueMethod": "_getReplicaMask"
									},
									"ReplicaCount": {
										"getValueMethod": "_getReplicaCount"
									}
								}
							}
						}
					}
				}/**SCHEMA_MODULES*/,
				details: /**SCHEMA_DETAILS*/{
					VwMandrillRecipient: {
						schemaName: "VwMandrillRecipientDetailV2",
						entitySchemaName: "VwMandrillRecipient",
						filter: {
							masterColumn: "Id",
							detailColumn: "BulkEmail"
						},
						defaultValues: {
							BulkEmail: {
								masterColumn: "Id"
							}
						}
					},
					BulkEmailAudience: {
						schemaName: "BulkEmailAudienceDetail",
						entitySchemaName: "VwBulkEmailAudience",
						filter: {
							masterColumn: "Id",
							detailColumn: "BulkEmail"
						},
						defaultValues: {
							BulkEmail: {
								masterColumn: "Id"
							}
						}
					},
					Files: {
						schemaName: "FileDetailV2",
						entitySchemaName: "BulkEmailFile",
						filter: {
							masterColumn: "Id",
							detailColumn: "BulkEmail"
						}
					},
					BulkEmailHyperlink: {
						schemaName: "BulkEmailHyperlinkDetailV2",
						entitySchemaName: "BulkEmailHyperlink",
						filter: {
							masterColumn: "Id",
							detailColumn: "BulkEmail"
						}
					},
					BulkEmailEventLogDetail: {
						schemaName: "BulkEmailEventLogDetail",
						entitySchemaName: "BulkEmailEventLog",
						filter: {
							detailColumn: "BulkEmail",
							masterColumn: "Id"
						}
					}
				}/**SCHEMA_DETAILS*/,
				attributes: {
					"StoppedRecipientsCount": {
						dataValueType: BPMSoft.DataValueType.INTEGER,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"PreparingToSendRecipientsCount": {
						dataValueType: BPMSoft.DataValueType.INTEGER,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"SendingRecipientsCount": {
						dataValueType: BPMSoft.DataValueType.INTEGER,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"ReceivedInitialResponseCount": {
						dataValueType: BPMSoft.DataValueType.INTEGER,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"TemplateSubjectInsertBuffer": {
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					"MacrosInsertEventSource": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: null
					},
					"SubjectSelectedMacros": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: ""
					},
					"IsUtmCheckBoxEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["UseUtm"],
								methodName: "processStatusColumn"
							}
						]
					},
					"BusinessTimeEndInfoButtonContent": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["BusinessTimeEnd", "BusinessTimeStart", "DeliverySchedule", "TimeZone"],
								methodName: "setBusinessTimeEndInfoButtonCaption"
							}
						]
					},
					"TimeZone": {
						lookupListConfig: {
							columns: ["Offset", "Code"]
						}
					},
					"IsUtmEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["UseUtm"],
								methodName: "processStatusColumn"
							}
						]
					},
					"IsRunEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						]
					},
					"IsLaunchOptionEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					"IsBreakEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						]
					},
					"IsAudienceEditable": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						]
					},
					"IsAnalysisVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						]
					},

					"IsOppAudienceVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						],
						value: true
					},
					"IsBlankSlatesAudienceVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "processStatusColumn"
							}
						]
					},
					"Status": {
						dependencies: [
							{
								columns: ["StartDate"],
								methodName: "processStartDateColumn"
							}
						]
					},
					"IsTemplateDataCollapsed": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					"IsBulkEmailTypeEnabled": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: true
					},
					"IsSendScheduled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["LaunchOption"],
								methodName: "processLaunchOptionColumn"
							}
						]
					},
					"SendMailingActionCaption": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["LaunchOption"],
								methodName: "processLaunchOptionColumn"
							}
						]
					},
					"ThrottlingSchedulesList": {
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
					},
					"EditTemplateActionCaption": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["LaunchOption"],
								methodName: "processLaunchOptionColumn"
							}
						]
					},
					"SendTestEmailActionCaption": {
						dataValueType: BPMSoft.DataValueType.TEXT,
						dependencies: [
							{
								columns: ["LaunchOption"],
								methodName: "processLaunchOptionColumn"
							}
						]
					},
					"LaunchOption": {
						lookupListConfig: {
							filter: function() {
								return BPMSoft.createColumnInFilterWithParameters("Category", [
									this.get("Category").value
								]);
							}
						},
						"isRequired": true
					},
					"CampaignStatus": {
						type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						columnPath: "Campaign.CampaignStatus",
						dataValueType: BPMSoft.DataValueType.LOOKUP
					},
					/**
					 * Url #######.
					 */
					"HelpUrl": {
						"value": "",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Responsible.
					 */
					"Owner": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter},
						isRequired: true
					},
					/**
					 * Indicates that this build is public demo version.
					 */
					"IsPublicDemoBuild": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Trial version registration url.
					 */
					"TrialUrl": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: ""
					},
					/**
					 * Determines that value of the current provider is connected.
					 */
					"IsProviderConnected": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: true
					},
					/**
					 * Determines that value of the SenderEmail field are valid.
					 */
					"IsSenderEmailValid": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: true
					},
					/**
					 * Determines that SenderEmailInfoButton message are visible.
					 */
					"IsSenderEmailInfoMessageVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Image config for the SenderEmailInfoButton.
					 */
					"SenderEmailInfoButtonImageConfig": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					},
					/**
					 * Content of the SenderEmailInfoButton.
					 */
					"SenderEmailInfoButtonContent": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT
					},
					/**
					 * Style of the SenderEmailInfoButton.
					 */
					"SenderEmailInfoButtonStyle": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: BPMSoft.TipStyle.WHITE
					},
					/**
					 * Repository for loading and storing email template replicas.
					 */
					"ReplicaRepository": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					},
					/**
					 * Determines that DCTemplateViewer is visible.
					 */
					"isDCTemplateViewerVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * State of dynamic content functionality.
					 */
					"DynamicContentEnabled": {
						"dataValueType": BPMSoft.core.enums.DataValueType.BOOLEAN,
						"type": BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
						"value": false
					},

					/**
					 * Indicates MarketingContentBuilderWizard feature state.
					 */
					"IsMarketingContentBuilderWizardEnabled": {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Indicates FromEmailFromNameMacros feature state.
					 */
					"IsFromEmailFromNameMacroFeatureEnabled": {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN
					},

					/**
					 * Indicates SendTestEmail visibility state.
					 */
					"IsSendTestEmailVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						dependencies: [
							{
								columns: ["Status"],
								methodName: "_setSendTestEmailVisible"
							}
						]
					},

					/**
					 * Current content exporter factory.
					 */
					"ContentExporterFactory": {
						dataValueType: BPMSoft.core.enums.DataValueType.CUSTOM_OBJECT,
						type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
						value: Ext.create("BPMSoft.ContentExporterFactory")
					},

					/**
					 * Defines visibility of test email container.
					 */
					"IsTestEmailVisible": {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Flag to indicate that field Audience schema is editable.
					 * @type {Boolean}
					 */
					"IsAudienceSchemaEnabled": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					/**
					 * Cron expression object.
					 * @private
					 * @type {Object}
					 */
					"CronExpression": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT
					},
					
					/**
					 * Values collection of lookup for ProviderName.
					 */
					"ProvidersCollection": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: Ext.create("BPMSoft.Collection")
					},

					/**
					 * Content of the ProviderInfoButton.
					 */
					"ProviderInfoButtonContent": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT
					},

					/**
					 * Determines that ProviderInfoButton message is visible.
					 */
					"ProviderInfoButtonTipVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},

					/**
					 * Style of the SenderEmailInfoButton.
					 */
					"ProviderInfoButtonStyle": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: BPMSoft.TipStyle.WHITE
					},

					/**
					 * Determines that SenderEmailInfoButton is visible.
					 */
					"ProviderInfoButtonVisible": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						value: false
					},

					/**
					 * Image config for the SenderEmailInfoButton.
					 */
					"ProviderInfoButtonImageConfig": {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					},
					
					"ProviderNameLookupValue": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				messages: {
					/**
					 * @message MacroSelected.
					 * Transfers selected macros.
					 */
					"MacroSelected": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GetBulkEmail
					 * Gets current bulk email.
					 * @return (Object) bulk email.
					 */
					"GetBulkEmail": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetIndicatorConfig
					 * Transfers current user configuration to indicator`s module.
					 */
					"GetIndicatorConfig": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GenerateIndicator
					 * ########## ######### # ########### ########## ####### ###########
					 */
					"GenerateIndicator": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message GetIsRunnable
					 * ######## ######### ######## ## ######### ########.
					 * @return (Boolean) ########## true, #### ######## ######### ########, ##### false.
					 */
					"GetIsRunnable": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetIsAudienceEditable
					 * ######## ######### ######## ## ############# #########.
					 * @return (Boolean) ########## true, #### ######## #############, ##### false.
					 */
					"GetIsAudienceEditable": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message RunMailing
					 * ############## ###### ########.
					 */
					"RunMailing": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message breakMailing
					 * ########## ######### ########.
					 */
					"BreakMailing": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetClicksMapConfig
					 * ############## ######### ###### ##### ######.
					 */
					"GetClicksMapConfig": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetEmailCategory
					 * ########## ######### Email.
					 */
					"GetEmailCategory": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetEmailStatus
					 * ########## ###### Email.
					 */
					"GetEmailStatus": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetEmailCreatedOn
					 * ########## #### ######## Email.
					 */
					"GetEmailCreatedOn": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					* @message GetProviderName 
					* Returns the current provider name.
					*/
					"GetProviderName": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetReplicaRepository
					 * Returns the instance of replica repository.
					 */
					"GetReplicaRepository": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message ChooseTemplateFromLookup
					 * Opens lookup window to select template.
					 */
					"ChooseTemplateFromLookup": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message EditTemplate
					 * Opens content builder to edit template.
					 */
					"EditTemplate": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message BulkEmailTemplateSaved
					 * Notify about bulk email template saved.
					 */
					"BulkEmailTemplateSaved": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message SendTestEmail
					 * Opens modal view for sending test message.
					 */
					"SendTestEmail": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetBulkEmailImportAudienceData
					 * Returns bulk email data for audience import.
					 */
					"GetBulkEmailImportAudienceData": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message SaveBeforeAction
					 * Tries to save bulk email before audience import.
					 */
					"SaveBeforeAction": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message CloseTestEmail
					 * Message will be fired when test email container is closing.
					 */
					"CloseTestEmail": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetActiveReplicaMask
					 * Requests active replica mask value.
					 */
					"GetActiveReplicaMask": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message ResetAudienceSchema
					 */
					"ResetAudienceSchema": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetCronExpression Gets cron expression for delivery scheduled days.
					 */
					"GetCronExpression": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message WeekDayCronEditableChanged Indicates if cron expression could be changed.
					 */
					"WeekDayCronEditableChanged": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message CronExpressionChanged
					 * Notifies if cron expression is changed.
					 */
					"CronExpressionChanged": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				methods: {
					/**
					 * @private
					 */
					_asyncLoadPageItems: function() {
						BPMSoft.chain(
							function(next) {
								this.loadTimeZone(function(timeZone) {
									this.$CurrentUserTimeZone = timeZone;
									this.setDefaultTimeZone();
									this.setBusinessTimeEndInfoButtonCaption();	
									next();
								});
							},
							function(next) {
								this.processStatusColumn();
								next();
							}, this);
					},

					/**
					 * Returns image config for the ProviderInfoButton depending on the enabled state.
					 * @private
					 * @param {Boolean} isConnected Determines state of the button and what image has to be returned.
					 * @return {Object} Image config.
					 */
					_getProviderInfoButtonImageConfig: function(isConnected) {
						var imageName = isConnected ? "DefaultIcon" : "WarningIcon";
						return informationButtonResources.localizableImages[imageName];
					},

					/**
					 * Handles change of the "ProviderNameLookupValue" property.
					 * @private
					 */
					_onProvidersLookupChanged: function(model, value) {
						if(!Ext.isEmpty(value)) {
							let newValue = value.displayValue;
							this.set("ProviderName", newValue);
							this._updateProviderInfoButton(value.isConnected);
						}
					},

					/**
					 * @private
					 */
					_initProviderNamesLookup: function() {
						var serviceConfig = {
							serviceName: "MailingService",
							methodName: "GetAvailableProviders",
							data: null
						}
						this.on("change:ProviderNameLookupValue", this._onProvidersLookupChanged, this);
						this.callService(serviceConfig, function(response) {
							if(response && response.availableProviders) {
								let resultCollection = Ext.create("BPMSoft.Collection");
								let defaultProvider;
								BPMSoft.each(response.availableProviders, function(item) {
									resultCollection.add(item.providerName, {
										value: item.providerName,
										displayValue: item.providerName,
										imageConfig: item.isConnected 
											? resources.localizableImages.GreenIndicatorImage
											: resources.localizableImages.RedIndicatorImage,
										isConnected: item.isConnected,
									});
									if (item.isDefault) {
										defaultProvider = resultCollection.get(item.providerName);
									}
								}, this);
								this.$ProvidersCollection.reloadAll(resultCollection);
								let currentProvider = this.Ext.isEmpty(this.$ProviderName) 
									? ""
									: this.$ProvidersCollection.get(this.$ProviderName);
								let isStarted = this._getEmailStarted();
								let currentValue = isStarted 
										? currentProvider 
										: currentProvider || defaultProvider;
								this.set("ProviderNameLookupValue", currentValue);
							}
						}, this);
					},
					
					/**
					 * Loads values into grouping mode combobox.
					 * @protected
					 * @param {Object} filter ComboboxEdit value.
					 * @param {BPMSoft.Collection} list List of comboboxEdit values.
					 */
					onPrepareProvidersLookup: function(filter, list) {
						list.reloadAll(this.$ProvidersCollection);
					},
					
					/**
					 * @private
					 */
					_getReplicaMask: function() {
						return this.sandbox.publish("GetActiveReplicaMask");
					},

					/**
					 * @private
					 */
					_getReplicaCount: function() {
						var replicas = this.$ReplicaRepository.getAllReplicasRequestData();
						if (replicas && replicas.results) {
							return replicas.results.length;
						}
						return 0;
					},

					/**
					 * @private
					 */
					_openTestEmailContainer: function() {
						this.runActionAfterSave(function() {
							this.getReplicaRepository();
							this.set("IsTestEmailVisible", true);
							this.sandbox.subscribe("CloseTestEmail", this._closeTestEmailContainer, this,
								[this.getSendTestEmailContentSchemaId()]);
							this.hideBodyMask();
						});
					},

					/**
					 * @private
					 */
					_closeTestEmailContainer: function() {
						this.sandbox.unsubscribePtp("CloseTestEmail", [this.getSendTestEmailContentSchemaId()]);
						this.set("IsTestEmailVisible", false);
					},

					/**
					 * Set selected macro to page attribute.
					 * @private
					 * @param {Object} scope scope.
					 * @param {Object} macro selected macro.
					 */
					_setSeletedMacroToAtribute: function(config, macro) {
						var macroValue = this.formatMacrosColumn(macro.leftExpressionColumnPath);
						this.set(config.attributeName, null);
						this.set(config.attributeName, macroValue);
					},

					/**
					 * Subject macro button click handler.
					 * @private
					 */
					_onTemplateSubjectSelectMacroButtonClick: function() {
						var config = {
							attributeName: "TemplateSubjectInsertBuffer"
						};
						this.openMacrosColumnsPageWithCustomConfig(this, this._setSeletedMacroToAtribute, config);
					},

					/**
					 * Sender name macro button click handler.
					 * @private
					 */
					_onTemplateSenderNameSelectMacroButtonClick: function() {
						var config = {
							attributeName: "SenderName"
						};
						this.openMacrosColumnsPageWithCustomConfig(this, this._setSeletedMacroToAtribute, config);
					},

					/**
					 * Sender email macro button click handler.
					 * @private
					 */
					_onTemplateSenderEmailSelectMacroButtonClick: function() {
						var config = {
							attributeName: "SenderEmail"
						};
						this.openMacrosColumnsPageWithCustomConfig(this, this._setSeletedMacroToAtribute, config);
					},

					/**
					 * Subject macro button click handler.
					 * @private
					 */
					_onSubjectMacroClicked: function(macrosType) {
						this.set("MacrosInsertEventSource", "Subject");
						this.onMacroButtonClicked(macrosType);
					},

					/**
					 * Sender name macro button click handler.
					 * @private
					 */
					_onSenderNameMacroClicked: function(macrosType) {
						this.set("MacrosInsertEventSource", "SenderName");
						this.onMacroButtonClicked(macrosType);
					},

					/**
					 * Sender email macro button click handler.
					 * @private
					 */
					_onSenderEmailMacroClicked: function(macrosType) {
						this.set("MacrosInsertEventSource", "SenderEmail");
						this.onMacroButtonClicked(macrosType);
					},

					_getStatusButtonInfoVisible: function() {
						return Boolean(this.$IsMarketingContentBuilderWizardEnabled
							&& this.$Status
							&& this.$Status.value === MarketingEnums.BulkEmailStatus.DRAFT);
					},

					/**
					 * Returns True when DCTemplateViewer module can be visualized.
					 * @private
					 * @returns {Boolean} Visibility state.
					 */
					_getDCTemplateViewerVisibility: function() {
						return Boolean(this.$isDCTemplateViewerVisible && this.getPrimaryColumnValue());
					},

					/**
					 * @private
					 */
					_setSendTestEmailVisible: function() {
						this.$IsSendTestEmailVisible = this.$IsMarketingContentBuilderWizardEnabled
							&& this.$Status.value !== MarketingEnums.BulkEmailStatus.DRAFT;
					},

					/**
					 * @private
					 */
					_updateStatusByFeatureMarketingContentBuilderWizard: function() {
						const isDraftStatus = this.$Status.value === MarketingEnums.BulkEmailStatus.DRAFT;
						if (isDraftStatus && !this.$IsMarketingContentBuilderWizardEnabled) {
							this.loadLookupDisplayValue("Status", MarketingEnums.BulkEmailStatus.PLANNED);
						}
					},

					_getIsThrottlingQueueVisible: function() {
						var throttlingMode = this.$ThrottlingMode && this.$ThrottlingMode.value;
						return throttlingMode === MarketingEnums.ThrottlingMode.WARMUP_COLD_AUDIENCE;
					},
					
					_getIsThrottlingModeInfoButtonVisible: function() {
						return this._getIsThrottlingQueueVisible() || this._getIsManualLimitsVisible();
					},

					_getThrottlingModeInfoButtonCaption: function() {
						if (this._getIsManualLimitsVisible()) {
							return this.get("Resources.Strings.ManualLimitThrottlingModeInfoButtonCaption");
						}
						return this.get("Resources.Strings.WarmUpThrottlingModeInfoButtonCaption");
					},

					_getIsManualLimitsVisible: function() {
						if (!BPMSoft.Features.getIsEnabled("ManualLimitThrottlingQueue")) {
							return false;
						}
						var throttlingMode = this.$ThrottlingMode && this.$ThrottlingMode.value;
						return throttlingMode === MarketingEnums.ThrottlingMode.MANUAL_LIMIT;
					},

					_getDeliveryScheduleDaysVisible: function() {
						var deliverySchedule = this.$DeliverySchedule && this.$DeliverySchedule.value;
						return deliverySchedule === MarketingEnums.DeliverySchedule.DAYS_OF_WEEK;
					},

					_getStringCronExpression: function() {
						var cronExpression = this.$DeliveryScheduleDays;
						return cronExpression && cronExpression.toString();
					},

					/**
					 * @private
					 */
					_getIsManualLimitChanged: function() {
						return this.changedValues.DailyLimit || this.changedValues.DelayBetweenEmail;
					},

					/**
					 * @private
					 */
					_getIsEmailScheduleChanged: function() {
						return this.changedValues.Priority ||
							this.changedValues.ExpirationDate ||
							this.changedValues.DeliveryScheduleDays ||
							this.changedValues.BusinessTimeStart ||
							this.changedValues.BusinessTimeEnd ||
							this.changedValues.TimeZone;
					},

					/**
					 * @private
					 */
					_getUpdateManualLimitServiceConfig: function() {
						return {
							serviceName: "MailingService",
							methodName: "UpdateThrottlingSchedule",
							data: {
								data: {
									"email_id": this.getPrimaryColumnValue(),
									"strategy_id": 3,
									"schedule": [{
										"day": 1,
										"delay_per_email": this.$DelayBetweenEmail,
										"emails_per_day": this.$DailyLimit
									}]
								}}
						};
					},

					/**
					 * @private
					 */
					_getUpdateEmailScheduleServiceConfig: function() {
						return {
							serviceName: "MailingService",
							methodName: "UpdateEmailSchedule",
							data: {
								data: {
									"business_time_end": this._convertTimestampToWCFFormat(this.$BusinessTimeEnd),
									"business_time_start": this._convertTimestampToWCFFormat(this.$BusinessTimeStart),
									"delivery_schedule_days": this.$DeliveryScheduleDays,
									"email_id": this.getPrimaryColumnValue(),
									"expiration_date": this._convertDateTimeToWCFFormat(this.$ExpirationDate),
									"priority_id": this.$Priority.value,
									"target_time_zone_id": this.$TimeZone.value,
								}}
						};
					},

					/**
					 * @private
					 */
					_updateManualLimitsIfChanged: function(next) {
						if (!this._getIsManualLimitChanged()) {
							next();
							return;
						}
						var config = this._getUpdateManualLimitServiceConfig();
						this.callService(config, function(response) {
							if (!response.success) {
								this.showInformationDialog(this.get("Resources.Strings.EmailColumnsEditCloudFailMessage"));
							} else {
								next();
							}
						}, this);
					},

					/**
					 * @private
					 */
					_updateEmailScheduleIfChanged: function(next) {
						if (!this._getIsEmailScheduleChanged()) {
							next();
							return;
						}
						var config = this._getUpdateEmailScheduleServiceConfig();
						this.callService(config, function(response) {
							if (!response.success) {
								this.showInformationDialog(this.get("Resources.Strings.EmailColumnsEditCloudFailMessage"));
							} else {
								next();
							}
						}, this);
					},

					/**
					 * @protected
					 */
					showAudienceSchema: function() {
						if (!BPMSoft.Features.getIsEnabled("BulkEmailExtendedMacro")) {
							return false;
						}
						this.$IsAudienceSchemaEnabled = !this.$IsAudienceInited && this.$RecipientCount === 0;
						return true;
					},

					/**
					 * ######### ####### ## ######## # #########.
					 * @private
					 * @returns {Boolean} ########## true, #### ######## ####### # #########, ##### false.
					 */
					isAssignedWithCampaign: function() {
						var campaign = this.get("Campaign");
						return !Ext.isEmpty(campaign);
					},

					/**
					 * ######### #### ############## #########.
					 * @private
					 */
					_editTemplateAction: function() {
						BPMSoft.chain(
							function (next) {
								this.asyncValidate(function(validationResult) {
									if (validationResult) {
										next();
									}
								}, this);
							},
							function () {
								var contentBuilderMode = BulkEmailContentBuilderEnumsModule.BulkEmailContentBuilderMode.BULKEMAIL;
								var recordId = this.getPrimaryColumnValue();
								var contentBuilderUrl = BulkEmailContentBuilderEnumsModule.getContentBuilderUrl(contentBuilderMode,
									recordId);
								var config = {
									callback: function () {
										window.open(contentBuilderUrl);
									},
									isSilent: true
								};
								this.save(config);
							},
							this);
					},

					/**
					 * ######### #### ###### ## ########### ######## #########.
					 * @private
					 */
					_chooseTemplateFromLookupAction: function() {
						BPMSoft.chain(this.asyncValidate,
							function(next, validationResult) {
								if (validationResult) {
									next();
								}
							},
							function(next) {
								if (this.isNewMode()) {
									var config = {
										callback: function () {
											next();
										},
										isSilent: true
									};
									this.save(config);
								} else {
									next();
								}
							},
							function() {
								var config = {
									entitySchemaName: "EmailTemplate",
									enableMultiSelect: false
								};
								LookupUtilities.Open(this.sandbox, config, this.insertTemplateFromLookup, this,
									null, false, false);
							},
							this);
					},

					/**
					 * Shows cpnfirmation window for action.
					 * @private
					 */
					_executeWithConfirmation: function(message, action) {
						var config = {
							style: BPMSoft.MessageBoxStyles.ORANGE
						};
						this.showConfirmationDialog(message,
							function(returnCode) {
								if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
									action.call(this);
								}
							}, ["yes", "cancel"], config);
					},

					/**
					 * ######### ######## ## ########.
					 * @private
					 * @returns {Boolean} ########## true, #### ######## ########, ##### false.
					 */
					isLaunchedCampaign: function() {
						var campaignStatus = this.get("CampaignStatus");
						return (campaignStatus &&
							(campaignStatus.value === MarketingEnums.CampaignStatus.STARTED ||
								campaignStatus.value === MarketingEnums.CampaignStatus.SCHEDULED));
					},

					/**
					 * ######### ######### ##### ####### ########.
					 * @private
					 */
					processLaunchOptionColumn: BPMSoft.emptyFn,

					/**
					 * ####### ######### ######### #####.
					 * @private
					 * @param {String} name ######## ####.
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmValidator: function(name) {
						var invalidMessage = "";
						var patternUtmLabel = /^[A-Za-z0-9_-]+$/;
						var utmLabel = this.get(name);
						var useUtm = this.get("UseUtm");
						if (!this.Ext.isEmpty(utmLabel) && !patternUtmLabel.test(utmLabel) && useUtm) {
							invalidMessage = this.get("Resources.Strings.UtmIncorrectMessage");
						}
						return this._getValidationResult(invalidMessage);
					},

					/**
					 * Function to validate email by field name.
					 * @private
					 * @return {Object} Returns validation result.
					 */
					_checkSenderEmail: function(email) {
						var validationMessage = "";
						if (!EmailHelperModule.isEmailValid(email)) {
							validationMessage = this.get("Resources.Strings.IncorrectEmailMessage");
							this.updateSenderEmailInfoButton(false, validationMessage, false);
						} else {
							this.asyncValidateSenderDomain();
						}
						return this._getValidationResult(validationMessage);

					},

					/**
					 * Returns true if feature BulkEmailUXEnabled is enabled.
					 * @private
					 * @return {Boolean}.
					 */
					getIsBulkEmailUXEnabled: function() {
						return this.BPMSoft.Features.getIsEnabled("BulkEmailUX");
					},

					/**
					 * Click handler for the provider name information button.
					 * @private
					 * @returns {boolean}
					 */
					_onProviderInfoButtonClick: function() {
						this._openBpmCrmCloudIntegrationPage();
						return false;
					},

					/**
					 * Opens Bpmcrm Cloud Integration settings page.
					 */
					_openBpmCrmCloudIntegrationPage: function() {
						var pageName = "BpCloudIntegrationPageV2";
						var integrationPageUrl = Ext.String.format("{0}{1}/{2}/",
							BPMSoft.workspaceBaseUrl,
							"/Nui/ViewModule.aspx#CardModuleV2",
							pageName);
						window.open(integrationPageUrl);
					},

					/**
					 * Sets attributes to render provider name info button.
					 * @param {boolean} isConnected Indicates weather domain successfully validated
					 * @private
					 */
					_updateProviderInfoButton: function(isConnected) {
						var buttonVisible = !!this.$ProviderName && !isConnected;
						this.$ProviderInfoButtonVisible = buttonVisible;
						if (!buttonVisible) {
							return;
						}
						this.$IsProviderConnected = isConnected;
						this.$ProviderInfoButtonImageConfig = this._getProviderInfoButtonImageConfig(isConnected);
						if (!isConnected) {
							this.$ProviderInfoButtonContent = this.get("Resources.Strings.NotConnectedProviderMessage");
							this.$ProviderInfoButtonStyle = BPMSoft.TipStyle.RED;
							this.$ProviderInfoButtonTipVisible = true;
						}
					},

					/**
					 * Function to validate sender name.
					 * @private
					 * @return {Object} Returns validation result.
					 */
					_senderNameValidator: function() {
						var validationMessage = "";
						var senderName = this.$SenderName;
						if (Ext.isEmpty(senderName)) {
							validationMessage = this.get("Resources.Strings.FieldEmptyValidationMessage");
							return this._getValidationResult(validationMessage);
						}
						if (this.$IsFromEmailFromNameMacroFeatureEnabled
								&& MacroUtils.isStringContainsMacro(senderName)
								&& !MacroUtils.isValueMacro(senderName)) {
							validationMessage = this.get("Resources.Strings.SenderMacroValidationMessage");
							return this._getValidationResult(validationMessage);
						}
						return this._getValidationResult(validationMessage);
					},

					/**
					 * Validates sender email.
					 * @private
					 * @return {Object} Returns validation result.
					 */
					_senderEmailValidator: function() {
						var validationMessage = "";
						var senderEmail = this.$SenderEmail;
						if (Ext.isEmpty(senderEmail)) {
							validationMessage = this.get("Resources.Strings.FieldEmptyValidationMessage");
							return this._getValidationResult(validationMessage);
						}
						if (!this.$IsFromEmailFromNameMacroFeatureEnabled
								|| !MacroUtils.isStringContainsMacro(senderEmail)) {
							return this._checkSenderEmail(senderEmail);
						}
						if (MacroUtils.isValueMacro(senderEmail)) {
							validationMessage = this.get("Resources.Strings.SenderMacroInfoMessage");
							this.updateSenderEmailInfoButton(true, validationMessage, true);
							return this._getValidationResult("");
						}
						validationMessage = this.get("Resources.Strings.SenderMacroValidationMessage");
						return this._getValidationResult(validationMessage);
					},

					/**
					 * Function to validate template subject.
					 * @private
					 * @return {Object} Returns validation result.
					 */
					_templateSubjectValidator: function() {
						var validationMessage = "";
						var templateSubject = this.$TemplateSubject;
						if (Ext.isEmpty(templateSubject)) {
							validationMessage = this.get("Resources.Strings.FieldEmptyValidationMessage");
						}
						return this._getValidationResult(validationMessage);
					},

					/**
					 * @private
					 */
					_throttlingQueueValidator: function() {
						var validationMessage = "";
						var isCorrectValue = this.$ThrottlingQueue && this.$ThrottlingQueue.value;
						if (this._getIsThrottlingQueueVisible() && !isCorrectValue) {
							validationMessage = this.get("Resources.Strings.ThrottlingQueueEmptyValidationMessage");
						}
						return this._getValidationResult(validationMessage);
					},

					/**
					 * @private
					 */
					_manualLimitValueValidator: function(validatedValue, dependsOnColumn, messageCode) {
						var dependsOnValue = this.get(dependsOnColumn);
						var secondsInTimeRange = (this.$BusinessTimeEnd - this.$BusinessTimeStart) / 1000;
						var maxValue = dependsOnValue > 0 ?
							secondsInTimeRange / dependsOnValue : secondsInTimeRange;
						maxValue = Math.trunc(maxValue);
						var validationMessage = ""
						if (validatedValue > maxValue) {
							var valueMessageTemplate = this.get(messageCode);
							validationMessage =	Ext.String.format(valueMessageTemplate, dependsOnValue,
								maxValue);
						}
						if (!validationMessage) {
							var validationOptions = {skipValidation: true};
							this.validateColumn(dependsOnColumn, validationOptions);
						}
						return this._getValidationResult(validationMessage);
					},

					/**
					 * @private
					 */
					_dailyLimitValidator: function() {
						const defaultDailyLimit = 1;
						var throttlingMode = this.$ThrottlingMode && this.$ThrottlingMode.value;
						if (throttlingMode !== MarketingEnums.ThrottlingMode.MANUAL_LIMIT 
							&& this.$DailyLimit !== defaultDailyLimit) {
							this.$DailyLimit = defaultDailyLimit;
							return this._getValidationResult();
						}
						if (this.$DailyLimit < defaultDailyLimit) {
							var message = this.get("Resources.Strings.DailyLimitRangeValidationMessage");
							return this._getValidationResult(message);
						}
						return this._manualLimitValueValidator(this.$DailyLimit, "DelayBetweenEmail", 
							"Resources.Strings.DailyLimitValueValidationMessage");
					},

					/**
					 * @private
					 */
					_delayBetweenEmailValidator: function() {
						var throttlingMode = this.$ThrottlingMode && this.$ThrottlingMode.value;
						if (throttlingMode !== MarketingEnums.ThrottlingMode.MANUAL_LIMIT
								&& this.$DelayBetweenEmail !== 0) {
							this.$DelayBetweenEmail = 0;
							return this._getValidationResult();
						}
						if (this.$DelayBetweenEmail < 0 || this.$DelayBetweenEmail > 3600) {
							var message = this.get("Resources.Strings.DelayBetweenEmailRangeValidationMessage");
							return this._getValidationResult(message);
						}
						return this._manualLimitValueValidator(this.$DelayBetweenEmail, "DailyLimit",
							"Resources.Strings.DelayBetweenEmailsValueValidationMessage");
					},

					/**
					 * @private
					 */
					_getValidationResult: function(shortMessage, fullMessage) {
						return {
							fullInvalidMessage: shortMessage,
							invalidMessage: fullMessage ? fullMessage : shortMessage
						};
					},

					/**
					 * @private
					 */
					_checkIfBrowserSupported: function() {
						if (this.$IsMarketingContentBuilderWizardEnabled && Ext.isIE) {
							var ieNotSuppoertedMessage = this.get("Resources.Strings.IENotSupportedMessage");
							this.showInformationDialog(ieNotSuppoertedMessage);
							return false;
						}
						return true;
					},

					/**
					 * ####### ######### ######### ##### UtmCampaign.
					 * @private
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmCampaignValidator: function() {
						return this.checkUtmValidator("UtmCampaign");
					},

					/**
					 * ####### ######### ######### ##### UtmMedium.
					 * @private
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmMediumValidator: function() {
						return this.checkUtmValidator("UtmMedium");
					},

					/**
					 * ####### ######### ######### ##### UtmSource.
					 * @private
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmSourceValidator: function() {
						return this.checkUtmValidator("UtmSource");
					},

					/**
					 * ####### ######### ######### ##### UtmTerm.
					 * @private
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmTermValidator: function() {
						return this.checkUtmValidator("UtmTerm");
					},

					/**
					 * ####### ######### ######### ##### UtmContent.
					 * @private
					 * @return {Object} ########## ######### #########.
					 */
					checkUtmContentValidator: function() {
						return this.checkUtmValidator("UtmContent");
					},
					
					_checkMinExpirationValidator: function() {
						if (!BulkEmailHelper.GetIsRunnable(this.$Status.value)) {
							return this._getValidationResult("");
						}
						var invalidMessage = "";
						var expirationDate = this.$ExpirationDate;
						var currentDate = new Date();
						if (expirationDate && expirationDate < currentDate) {
							invalidMessage = this.get("Resources.Strings.IncorrectExpirationDateMessage");
						}
						return this._getValidationResult(invalidMessage);
					},

					/**
					 * Returns config for the SaveBulkEmailTemplate method of BulkEmailTemplateService.
					 * @private
					 * @return {Object} Config.
					 */
					getSaveBulkEmailTemplateConfigData: function() {
						var requiredColumnValues = {
							Name: this.get("Name"),
							SenderName: this.get("SenderName"),
							SenderEmail: this.get("SenderEmail")
						};
						return {
							bulkEmailId: this.getPrimaryColumnValue(),
							emailTemplateId: null,
							requiredColumnValues: this.Ext.encode(requiredColumnValues),
							body: null
						};
					},

					/**
					 * ######### ### ######## ######### ######## ######## isNotHtmlView. ######### ### ########.
					 * @private
					 */
					getIsNoHtmlView: function(isHtmlView) {
						return !isHtmlView;
					},

					/**
					 * ############# ######## ######### IsBulkEmailTypeEnabled # ########### ## ####### ########
					 * # ####### ###########.
					 * @private
					 * @param {Boolean} value ######## ######### IsBulkEmailTypeEnabled.
					 */
					setBulkEmailTypeEnabled: function(value) {
						if (this.isNewMode() || this.isCopyMode()) {
							return;
						}
						var statusId = this.get("Status").value;
						if (statusId === MarketingEnums.BulkEmailStatus.STARTED ||
								statusId === MarketingEnums.BulkEmailStatus.STARTING ||
								statusId === MarketingEnums.BulkEmailStatus.BREAKING ||
								statusId === MarketingEnums.BulkEmailStatus.COMPLETED) {
							this.set("IsBulkEmailTypeEnabled", false);
							return;
						}
						if (!Ext.isEmpty(value)) {
							this.set("IsBulkEmailTypeEnabled", value);
							return;
						}
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "VwBulkEmailAudience"});
						esq.rowCount = 1;
						esq.addColumn("Id");
						esq.filters.add("filterMassMailing", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "BulkEmail", this.get("Id")));
						esq.getEntityCollection(function(result) {
							var isEmpty = result.success && result.collection.isEmpty();
							this.set("IsBulkEmailTypeEnabled", isEmpty);
						}, this);
					},

					/**
					 * ########## URL ########### ### ######### ######## ####### # ############## #######.
					 * @private
					 * @return {String} URL ###########.
					 */
					getEmptyChartDataImage: function() {
						var iconId = this.get("Resources.Strings.ChartEmptyDataImageId");
						return this.getSysImageUrl(iconId);
					},

					/**
					 * Initializes content by default for the SenderEmailInfoButton.
					 * @private
					 */
					initSenderEmailInfoButton: function() {
						var lczValue = this.get("Resources.Strings.DefaultSenderDomainMessage");
						this.set("SenderEmailInfoButtonContent", lczValue);
						this.set("SenderEmailInfoButtonStyle", this.BPMSoft.TipStyle.WHITE);
						this.set("IsSenderEmailValid", true);
						this.initSenderEmailInfoButtonDefaultImage();
					},

					/**
					 * Initializes default image for the SenderEmailInfoButton.
					 * @private
					 */
					initSenderEmailInfoButtonDefaultImage: function() {
						var imageConfig = this.getSenderEmailInfoButtonImageConfig(true);
						this.set("SenderEmailInfoButtonImageConfig", imageConfig);
					},

					/**
					 * Initializes Academy link.
					 * @private
					 */
					initHelpUrl: function() {
						var config = {
							contextHelpCode: "BulkEmailPageV2",
							contextHelpId: "1008",
							scope: this
						};
						config.callback = function(url) {
							this.set("HelpUrl", url);
						};
						AcademyUtilities.getUrl(config);
					},

					/**
					 * ########## ##### ###### # ######## ###### # ######
					 * ## ###### # ########.
					 * @param {String} text ##### ###### # ########.
					 * @returns {String} ##### ######.
					 * @private
					 */
					getGuideText: function(text) {
						var url = this.get("HelpUrl");
						var startTag = "";
						var finishTag = "";
						if (!Ext.isEmpty(url)) {
							startTag = "<a target=\"_blank\" href=\"" + url + "\">";
							finishTag = "</a>";
						}
						text = Ext.String.format(text, startTag, finishTag);
						return text;
					},

					/**
					 * Gets caption for not delivered responses chart replacing image.
					 * @private
					 */
					getNotDeliveredBlankSlatesCaption: function() {
						var caption = this.get("Resources.Strings.NotDeliveredChartEmptyImageCaption");
						return caption;
					},

					getNotDeliveredBlankStatesText: function(){
						var caption = this.get("Resources.Strings.NotDeliveredChartEmptyImageText");
						return caption;
					},

					/**
					 * Gets caption for canceled responses chart replacing image.
					 * @private
					 */
					getCanceledBlankSlatesCaption: function() {
						var caption = this.get("Resources.Strings.CanceledChartEmptyImageCaption");
						return caption;
					},

					getCanceledBlankSlatesText: function(){
						var caption = this.get("Resources.Strings.CanceledChartEmptyImageText");
						return caption;
					},

					/**
					 * Sets state of features functionality.
					 * @private
					 */
					_setWizardFeature: function() {
						this.$IsMarketingContentBuilderWizardEnabled = this.getIsFeatureEnabled("MarketingContentBuilderWizard");
					},

					/**
					 * Sets state of FromEmailFromName features functionality.
					 * @private
					 */
					_setFromNameFromEmailFeature: function() {
						this.$IsFromEmailFromNameMacroFeatureEnabled = this.getIsFeatureEnabled("FromEmailFromNameMacros");
					},

					/**
					 * @protected
					 */
					getIsThrottlingQueueFeatureEnabled: function() {
						return this.getIsFeatureEnabled("BulkEmailThrottlingQueue");
					},

					/**
					 * @protected
					 */
					getIsESPSelectionFeatureEnabled: function() {
						return this.getIsFeatureEnabled("ESPSelection");
					},

					/**
					 * Disables IE9+ feature which wraps email and text links into html tags.
					 * @private
					 */
					disableAutoUrlDetection: function() {
						try {
							document.execCommand("AutoUrlDetect", false, false);
						} catch(err) {}
					},

					/**
					 * @private
					 */
					_onCronExpressionChanged: function() {
						this.$IsChanged = true;
					},

					/**
					 * Returns SendTestEmailContentSchema identifier for ModalBoxSchemaModule.
					 * @protected
					 */
					getSendTestEmailContentSchemaId: function() {
						return this.sandbox.id + "_module_TestEmail";
					},

					/**
					 * Subscribes to events.
					 * @protected
					 * @virtual
					 */
					subscribeMessages: function() {
						var macrosModuleId = this.getMacrosModuleId();
						this.sandbox.subscribe("MacroSelected", this.onGetMacros, this,
							[macrosModuleId]);
						this.sandbox.subscribe("SendTestEmail", this._openTestEmailContainer, this);
						this.sandbox.subscribe("ResetAudienceSchema", this.resetAudienceSchema, this);
						this.sandbox.subscribe("CronExpressionChanged", this._onCronExpressionChanged, this);
					},

					/**
					 * Handles macros receiving.
					 * @protected
					 * @virtual
					 * @param {String} macros Macros.
					 */
					onGetMacros: function(macros) {
						var macrosInsertEventSource = this.get("MacrosInsertEventSource");
						switch(macrosInsertEventSource) {
							case "Subject":
								this.set("SubjectSelectedMacros", macros);
								break;
							case "SenderName":
								this.set("SenderName", macros);
								break;
							case "SenderEmail":
								this.set("SenderEmail", macros);
								var message = this.get("Resources.Strings.SenderMacroInfoMessage");
								this.updateSenderEmailInfoButton(true, message, true);
								break;
							default:
								break;
						}
					},

					/**
					 * ##### ########## ###### "#######".
					 * @protected
					 * @overridden
					 */
					onCloseClick: function() {
						var bulkEmailId = this.get("Id");
						this.sandbox.publish("CardModuleResponse", {primaryColumnValue: bulkEmailId}, [this.sandbox.id]);
						this.callParent(arguments);
					},

					/**
					 * ############## ######## ## ######### ####### ########.
					 * @protected
					 * @overridden
					 */
					initCardActionHandler: function() {
						this.callParent(arguments);
						var propertyNames = [
							"IsRunEnabled",
							"IsRunDisplayed",
							"IsBreakEnabled",
							"SendMailingActionCaption",
							"EditTemplateActionCaption",
							"SendTestEmailActionCaption",
							"IsTemplateEditable",
							"IsSendTestEmailVisible",
							"IsMarketingContentBuilderWizardEnabled"
						];
						BPMSoft.each(propertyNames, function(propertyName) {
							this.on("change:" + propertyName, function(model, value) {
								this.sandbox.publish("CardChanged", {
									key: propertyName,
									value: value
								}, [this.sandbox.id]);
							}, this);
						}, this);
					},
					
					_getEmailStarted: function() {
						var status = this.get("Status");
						return status.value !== MarketingEnums.BulkEmailStatus.PLANNED
							&& status.value !== MarketingEnums.BulkEmailStatus.DRAFT
							&& status.value !== MarketingEnums.BulkEmailStatus.START_SCHEDULED;
					},
					
					_getEmailLimitsAndScheduleFieldsEditable: function() {
						var status = this.get("Status");
						if (!status) {
							return false;
						}
						return status.value === MarketingEnums.BulkEmailStatus.PLANNED
							|| status.value === MarketingEnums.BulkEmailStatus.DRAFT
							|| status.value === MarketingEnums.BulkEmailStatus.START_SCHEDULED
							|| status.value === MarketingEnums.BulkEmailStatus.QUEUED
							|| status.value === MarketingEnums.BulkEmailStatus.ACTIVE
							|| status.value === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND
							|| status.value === MarketingEnums.BulkEmailStatus.STARTING
							|| status.value === MarketingEnums.BulkEmailStatus.STARTED
							|| status.value === MarketingEnums.BulkEmailStatus.STOPPED;
					},

					/**
					 * ###### ######### ####### (## ### ####### ########## ###### "######### ########").
					 * @protected
					 * @virtual
					 */
					processStatusColumn: function() {
						var isAnalysisVisible = this._getEmailStarted();
						var isAssignedWithCampaign = this.isAssignedWithCampaign();
						var status = this.get("Status");
						var config = {
							status: status.value,
							isConnectWithCampaign: isAssignedWithCampaign
						};
						var isAudienceEditable = BulkEmailHelper.GetIsAudienceEditable(config);
						this.set("IsAnalysisVisible", isAnalysisVisible);
						this.set("IsAudienceEditable", isAudienceEditable);
					},

					/**
					 * Sets template viewer visibility.
					 * @protected
					 */
					setDCTemplateViewerVisible: function() {
						this.$isDCTemplateViewerVisible = this.getIsFeatureEnabled("DynamicContentClickHeatmap");
					},

					/**
					 * Sets state of dynamic content functionality.
					 * @protected
					 */
					setDynamicContentEnabled: function() {
						this.$DynamicContentEnabled = this.getIsFeatureEnabled("BulkEmailDynamicContentBuilder");
					},

					/**
					 * ########## ######### ######## ######## ### ######## "###########/##########".
					 * @protected
					 * @virtual
					 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########.
					 */
					getActions: function() {
						var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
						if (!this.$isDCTemplateViewerVisible) {
							actionMenuItems.addItem(this.getButtonMenuItem({
								"Tag": "sendTestEmail",
								"Click": {"bindTo": "sendTestEmail"},
								"Caption": {"bindTo": "Resources.Strings.SendTestEmailActionCaption"}
							}));
							actionMenuItems.addItem(this.getButtonMenuItem({
								"Tag": "sendTestEmail",
								"Type": "BPMSoft.MenuSeparator"
							}));
						}
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Tag": "goToSplitTestsCaption",
							"Click": {"bindTo": "goToSplitTestsCaption"},
							"Caption": {"bindTo": "Resources.Strings.GoToSplitTestsCaption"}
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Type": "BPMSoft.MenuSeparator"
						}));
						var parentActionMenuItems = this.callParent(arguments);
						parentActionMenuItems.each(function(item) {
							actionMenuItems.addItem(item);
						}, this);
						return actionMenuItems;
					},

					/**
					 * Sets default template.
					 * @protected
					 * @virtual
					 */
					setDefaultTemplate: function() {
						var defaultTextTemplate = this.get("Resources.Strings.DefaultTemplate");
						var defaultConfigTemplate = BPMSoft.decode(defaultTextTemplate);
						var emailContentExporter = this.$ContentExporterFactory.getExporter(defaultConfigTemplate);
						var displayHtml = emailContentExporter.exportData(defaultConfigTemplate);
						this.set("TemplateConfig", defaultTextTemplate);
						this.set("TemplateBody", displayHtml);
					},

					/**
					 * Sets default settings.
					 * @protected
					 * @virtual
					 */
					setDefaultEmailValues: function() {
						this.set("UseUtm", false);
						var sysSettings = ["UtmSourceDefault", "UtmMediumDefault", "UtmCampaignDefault",
							"UtmTermDefault", "UtmContentDefault", "GoogleAnalyticsTrackingDomains"];
						BPMSoft.SysSettings.querySysSettings(sysSettings, function(settings) {
							this.set("UtmSource", settings.UtmSourceDefault);
							this.set("UtmMedium", settings.UtmMediumDefault);
							this.set("UtmCampaign", settings.UtmCampaignDefault);
							this.set("UtmTerm", settings.UtmTermDefault);
							this.set("UtmContent", settings.UtmContentDefault);
							this.set("Domains", settings.GoogleAnalyticsTrackingDomains);
						}, this);
						if (this.isAddMode() && !this.$isDCTemplateViewerVisible) {
							this.setDefaultTemplate();
						}
					},

					/**
					 * @inheritdoc BasePageV2#onEntityInitialized
					 * @override
					 */
					onEntityInitialized: function() {
						this._setSendTestEmailVisible();
						this._updateStatusByFeatureMarketingContentBuilderWizard();
						this.clearReplicaRepository();
						this.callParent(arguments);
						this._senderEmailValidator();
						if (this.isAddMode() || this.isCopyMode()) {
							this.setDefaultEmailValues();
							this.set("SendMailingActionCaption",
								this.get("Resources.Strings.RunMandrillMassMailingActionCaption"));
							if (this.isCopyMode()) {
								var defaultStatus = this.$Status.value === MarketingEnums.BulkEmailStatus.DRAFT
									&& this.$IsMarketingContentBuilderWizardEnabled
									? MarketingEnums.BulkEmailStatus.DRAFT
									: MarketingEnums.BulkEmailStatus.PLANNED;
								this.$Status.value = defaultStatus;
								this.loadLookupDisplayValue("Status", this.$Status.value);
							}
						}
						this.set("SendTestEmailActionCaption",
							this.get("Resources.Strings.SendTestEmailCaption"));
						this.set("EditTemplateActionCaption",
							this.get("Resources.Strings.EditTemplateCaption"));
						this.loadAnalyticsTabContent();
						this.loadClicksAnalysisTabContent();
						this.setBulkEmailTypeEnabled();
						BulkEmailHelper.UpdateStatistic(this);
						this.updateSendProcessDiagram();
						this.loadInProgressRepositoryValues(this.onSendingRepositoryDataLoaded);
						this.setWarmUpThrottlingModeCaption();
						this._asyncLoadPageItems();
						if (this.getIsESPSelectionFeatureEnabled()) {
							this._initProviderNamesLookup();
						}
					},

					/**
					 * HAndles event of loading sending progress values
					 * @protected
					 */
					onSendingRepositoryDataLoaded: function() {
						this.loadSendingProgressTabContent();
						this.loadSendProcessDiagram();
					},

					/**
					 * Loads values of SendingEmailProgress table
					 * @protected
					 */
					loadInProgressRepositoryValues: function(callback) {
						var esq = this.getSendingEmailProgressQuery();
						esq.getEntityCollection(function(response) {
							var collection = response.collection;
							if (response.success && collection.collection.length > 0) {
								var sendingRepo = collection.getItems()[0];
								this.set("PreparingToSendRecipientsCount",
									this.get("RecipientCount") - sendingRepo.get("PreparedRecipientsCount"));
								this.set("SendingRecipientsCount",
									sendingRepo.get("ProcessedRecipientCount")
									- sendingRepo.get("ReceivedInitialResponseCount"));
								this.set("ReceivedInitialResponseCount",
									sendingRepo.get("ReceivedInitialResponseCount") - this.get("CanceledCount")
									- this.get("StoppedSummaryCount") - this.get("ExpiredSummaryCount"));
								callback.call(this);
							}
						}, this);
					},

					/**
					 * ########## ######## # ##### # ####### ##### ##### ####### # ######### ########.
					 * @protected
					 */
					calculateDurationBulkEmail: function() {
						var sendStartDate = this.get("SendStartDate");
						var sendDueDate = this.get("SendDueDate");
						if ((!Ext.isDate(sendStartDate) || !Ext.isDate(sendDueDate)) || (sendDueDate < sendStartDate)) {
							return "";
						}
						var millisecondsInMinute = 1000 * 60;
						var durationInMinute = Ext.Date.getElapsed(sendDueDate, sendStartDate) / millisecondsInMinute;
						var hours = Math.floor(durationInMinute / 60);
						var minutes = Math.floor(durationInMinute - (hours * 60));
						var result;
						if (hours === 0 && minutes === 0) {
							result = this.get("Resources.Strings.DurationBulkEmailLessMinute");
						} else {
							result = Ext.String.format(this.get("Resources.Strings.DurationBulkEmailValueFormat"), hours,
								Ext.String.leftPad(minutes.toString(), 2, "0"));
						}
						return result;
					},

					/**
					 * Handler for 'SaveBeforeAction' received message.
					 * @protected
					 */
					trySaveBeforeAction: function(config) {
						this.runActionAfterSave(config.action);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
					 * @override
					 */
					subscribeSandboxEvents: function() {
						this.callParent(arguments);
						var sandbox = this.sandbox;
						var subscribersIds = this.getSaveRecordMessagePublishers();
						sandbox.subscribe("GetIsRunnable", function() {
							return this.get("IsRunEnabled");
						}, this, subscribersIds);
						sandbox.subscribe("GetIsAudienceEditable", function() {
							return this.get("IsAudienceEditable");
						}, this, subscribersIds);
						sandbox.subscribe("GetEmailCategory", function() {
							return this.get("Category");
						}, this, subscribersIds);
						sandbox.subscribe("GetEmailStatus", function() {
							return this.get("Status");
						}, this, subscribersIds);
						sandbox.subscribe("GetEmailCreatedOn", function() {
							return this.get("CreatedOn");
						}, this, subscribersIds);
						sandbox.subscribe("RunMailing", function() {
							this.runMandrillMassMailing();
						}, this, [sandbox.id]);
						sandbox.subscribe("BreakMailing", function() {
							this.breakMailingAction();
						}, this, [this.sandbox.id]);
						sandbox.subscribe("GetBulkEmailImportAudienceData", function() {
							var audienceSchema = this.$IsAudienceInited ? this.$AudienceSchema : null;
							return {
								audienceSchemaId: audienceSchema && audienceSchema.value,
								bulkEmailName: this.$Name
							};
						}, this);
						sandbox.subscribe("SaveBeforeAction", this.trySaveBeforeAction, this);
						this.subscribeGetReplicaRepository();
						this.subscribeDcTemplateViewer();
						this.subscribeGetProviderName();
					},

					/**
					 * ######### #### ###### ## ########### ######## #########.
					 * @protected
					 */
					chooseTemplateFromLookup: function() {
						var status = this.get("Status");
						if (status.value === MarketingEnums.BulkEmailStatus.ACTIVE) {
							var message = this.get("Resources.Strings.EditTemplateConfirmation");
							this._executeWithConfirmation(message,
								this._chooseTemplateFromLookupAction);
						} else if (!this.Ext.isEmpty(this.$TemplateBody)) {
							this._executeWithConfirmation(this.get("Resources.Strings.ReplaceTemplateConfirmation"),
								this._chooseTemplateFromLookupAction);
						} else {
							this._chooseTemplateFromLookupAction();
						}
					},

					/**
					 * Handles the EditTemplate button click.
					 * @protected
					 */
					editTemplate: function() {
						if(!this._checkIfBrowserSupported()) {
							return;
						}
						var status = this.get("Status");
						if (status.value === MarketingEnums.BulkEmailStatus.ACTIVE) {
							var message = this.get("Resources.Strings.EditTemplateConfirmation");
							this._executeWithConfirmation(message,
								this._editTemplateAction);
						} else {
							this._editTemplateAction();
						}
					},

					/**
					 * ########## ###### ####### ## ########### ######## #########.
					 * @protected
					 * @param {Object} config ############ ######### ######.
					 */
					insertTemplateFromLookup: function(config) {
						var selectedRows = config.selectedRows;
						if (selectedRows.getCount() <= 0) {
							return;
						}
						var template = selectedRows.getByIndex(0);
						this.prepareBulkEmailTemplate(template.Id);
						this.set("IsTemplateDataCollapsed", false);
					},

					/**
					 * Creates content builder helper.
					 * @protected
					 * @deprecated
					 * @return {BPMSoft.DynamicContentBuilderHelper} Content builder helper instance.
					 */
					createContentBuilderHelper: function() {
						var contentBuilderHelper = Ext.create("BPMSoft.DynamicContentBuilderHelper", {
							sandbox: {
								subscribe: BPMSoft.emptyFn
							}});
						contentBuilderHelper.sheetElementProperties.push("PreHeaderText");
						return contentBuilderHelper;
					},

					/**
					 * Returns JSON object by view model instance.
					 * @protected
					 * @param {BPMSoft.BaseViewModel} viewModel View model instance.
					 * @return {Object} JSON object.
					 */
					getContentBuilderConfig: function(viewModel) {
						var contentBuilderHelper = this.createContentBuilderHelper();
						return contentBuilderHelper.toJSON(viewModel);
					},

					/**
					 * Returns view model instance by template configuration.
					 * @protected
					 * @param {Object} templateConfig Template configuration.
					 * @return {BPMSoft.BaseModel} Content builder view model.
					 */
					getContentBuilderViewModel: function(templateConfig) {
						var contentBuilderHelper = this.createContentBuilderHelper();
						var viewModelConfig = contentBuilderHelper.toViewModel(templateConfig);
						return Ext.create("BPMSoft.BaseModel", {
							values: viewModelConfig
						});
					},

					/**
					 * Returns instance of BulkEmailTemplateValidator.
					 * @protected
					 * @return {BPMSoft.BulkEmailTemplateValidator} Instance of BulkEmailTemplateValidator.
					 */
					createTemplateValidator: function() {
						return Ext.create("BPMSoft.BulkEmailTemplateValidator");
					},

					/**
					 * Validates template configuration.
					 * @param {Object} templateConfig Template configuration.
					 * @param {Function} successCallbackFn Callback function for success validation.
					 * @param {Function} rejectCallbackFn Callback function for reject validation.
					 * @param {Object} scope Callback execution context.
					 */
					validateTemplateConfig: function(templateConfig, successCallbackFn, rejectCallbackFn, scope) {
						if (this.$DynamicContentEnabled) {
							var validator = this.createTemplateValidator();
							var validatorConfig = {
								bulkEmailId: this.get("Id"),
								templateConfig: templateConfig
							};
							validator.validate(validatorConfig, successCallbackFn, rejectCallbackFn, scope);
						} else {
							Ext.callback(successCallbackFn, scope);
						}
					},

					/**
					 * Applies BpmTrackId to Hyperlinks.
					 * @param {Object} templateConfig Template configuration.
					 */
					applyBpmTrackIdToHyperlinks: function(templateConfig) {
						if (this.$DynamicContentEnabled) {
							var viewModel = this.getContentBuilderViewModel(templateConfig);
							BulkEmailHyperlinkCorrector.applyBpmTrackIdToHyperlinks(viewModel);
							templateConfig = this.getContentBuilderConfig(viewModel);
						}
						return templateConfig;
					},

					/**
					 * Prepare template for service method.
					 * @protected
					 * @param {Guid} templateId EmailTemplate record uniqueidentifier.
					 */
					prepareBulkEmailTemplate: function(templateId) {
						var dataSend = {
							emailTemplateId: templateId
						};
						var config = {
							serviceName: "BulkEmailTemplateService",
							methodName: "GetEmailTemplateConfig",
							data: dataSend
						};
						this.showBodyMask();
						this.callService(config, function(response) {
							var result = response.GetEmailTemplateConfigResult;
							var templateConfigText = result.TemplateConfig;
							var templateConfigJson = Ext.isEmpty(templateConfigText)
								? BulkEmailTemplateHelper.htmlToSheetConfig(result.TemplateBody)
								: BPMSoft.decode(templateConfigText);
							templateConfigJson = this.applyBpmTrackIdToHyperlinks(templateConfigJson);
							BulkEmailTemplateHelper.applyUnsubscribeLink(templateConfigJson,
								function(templateConfig, html, applied) {
									this.validateTemplateConfig(templateConfigJson, function() {
										this.saveBulkEmailTemplate(templateId, html,
											JSON.stringify(templateConfig), applied);
									}, this.BPMSoft.emptyFn, this);
								}, this);
						});
					},

					/**
					 * Save template by service method.
					 * @protected
					 * @param {Guid} templateId EmailTemplate record uniqueidentifier.
					 * @param {String} body Body of template.
					 * @param {String} templateConfig Template config.
					 * @param {Boolean} isUnsubscribeApplied Unsubscribe link applied flag.
					 */
					saveBulkEmailTemplate: function(templateId, body, templateConfig, isUnsubscribeApplied) {
						if (!BulkEmailTemplateHelper.validateTemplateSize(body.length)) {
							this.hideBodyMask();
							return;
						}
						var configData = this.getSaveBulkEmailTemplateConfigData();
						var config = {
							serviceName: "BulkEmailTemplateService",
							methodName: "SaveBulkEmailTemplate",
							data: configData
						};
						configData.body = body;
						configData.emailTemplateId = templateId;
						configData.config = templateConfig || null;
						this.callService(config, function(response) {
							this.onBulkEmailTemplateSaved(response, isUnsubscribeApplied);
						});
					},

					/**
					 * ######## URL ########### ## ########### ##############.
					 * @param {Object} sysImageId ########## ############# ###########.
					 * @protected
					 * @return {String} URL ###########.
					 */
					getSysImageUrl: function(sysImageId) {
						var imageConfig = {
							source: BPMSoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: sysImageId
							}
						};
						return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
					},

					/**
					 * ######### ####### # ###### #####-######.
					 * @protected
					 */
					goToSplitTestsCaption: function() {
						this.sandbox.publish("PushHistoryState", {
							hash: Ext.String.format("{0}/{1}",
								"SectionModuleV2", "BulkEmailSplitSectionV2")
						});
					},

					/**
					 * Notify about bulk email template saved.
					 * @protected
					 */
					reloadTemplateViewer: function() {
						this.sandbox.publish("BulkEmailTemplateSaved", null, [this.getModuleId("DCTemplateViewer")]);
					},

					/**
					 * Handles event when macros button has been clicked.
					 * @protected
					 */
					onMacroButtonClicked: function(macrosType) {
						switch (macrosType) {
							case "macros":
								this.openMacrosPage();
								break;
							case "column":
								this.openMacrosColumnsPage();
								break;
							default:
								throw Ext.create("BPMSoft.UnsupportedTypeException " + macrosType);
						}
					},

					/**
					 * Opens macros columns dialog with callback function and custom parameters.
					 * @protected
					 * @param {Object} scope scope.
					 * @param {Function} handler callback function.
					 * @param {Object} config config with custom parameters.
					 */
					openMacrosColumnsPageWithCustomConfig: function(scope, handler, config) {
						var macrosEntity = "VwMandrillRecipientV2";
						BPMSoft.StructureExplorerUtilities.open({
							scope: scope,
							handlerMethod: function(macros) {
								handler.call(scope, config, macros);
							},
							moduleConfig: {
								useBackwards: false,
								schemaName: macrosEntity
							}
						});
					},

					/**
					 * Open entity structure explorer module for select column macros.
					 * @protected
					 * @virtual
					 */
					openMacrosColumnsPage: function() {
						var macrosEntity = "VwMandrillRecipientV2";
						BPMSoft.StructureExplorerUtilities.open({
							scope: this,
							handlerMethod: this.onMacrosColumnSelected,
							moduleConfig: {
								useBackwards: false,
								schemaName: macrosEntity
							}
						});
					},

					/**
					 * Loads system settings.
					 * @protected
					 */
					loadSysSettings: function() {
						var sysSettings = ["BuildType"];
						BPMSoft.SysSettings.querySysSettings(sysSettings, function(settings) {
							var isPublicDemo = (settings.BuildType.value === MarketingEnums.BuildType.DEMO_PUBLIC);
							this.set("IsPublicDemoBuild", isPublicDemo);
							this.set("TrialUrl", "");
						}, this);
					},

					/**
					 * Handles the message server communications channel.
					 * @protected
					 * @param {BPMSoft.ServerChannel} channel BPMCRM server communication channel.
					 * @param {Object} message Message object.
					 */
					onChannelMessage: function(channel, message) {
						if (!this.Ext.isObject(message)) {
							return;
						}
						var header = message.Header;
						if (header.Sender !== BulkEmailContentBuilderEnumsModule.BulkEmailContentBuilderMode.BULKEMAIL) {
							return;
						}
						var messageObject = this.BPMSoft.decode(message.Body || "{}");
						var primaryColumnValue = this.getPrimaryColumnValue();
						if (messageObject.recordId !== primaryColumnValue) {
							return;
						}
						this.clearReplicaRepository();
						this.refreshColumns(["TemplateBody", "TemplateConfig", "Status"],
							this.reloadTemplateViewer, this, {silent: false});
					},

					/**
					 * Returns visibility value for DCClickHeatmap container.
					 * @protected
					 */
					isDCClickHeatmapVisible: function() {
						return this.get("IsAnalysisVisible") &&
							this.getIsFeatureEnabled("DynamicContentClickHeatmap");
					},

					/**
					 * Returns the current provider name.
					 * @protected
					 * @return the current provider name.
					 */
					getProviderName: function() {
						return this.$ProviderName;
					},

					/**
					 * Initializes the instance of replica repository if it is not initialized yet and
					 * returns this instance. If page is not in edit mode, returns null.
					 * @protected
					 * @return {BPMSoft.DCTemplateReplicaRepository | null} Instance of replica repository.
					 */
					getReplicaRepository: function() {
						if (this.destroyed ||
							this.$Operation !== this.BPMSoft.ConfigurationEnums.CardOperation.EDIT) {
							return null;
						}
						var repository = this.$ReplicaRepository;
						if (!repository) {
							repository = this.Ext.create("BPMSoft.DCTemplateReplicaRepository");
							repository.init(this.getPrimaryColumnValue());
							this.$ReplicaRepository = repository;
						}
						return repository;
					},

					/**
					 * Clears replica repository.
					 * @protected
					 */
					clearReplicaRepository: function() {
						if (this.$ReplicaRepository) {
							this.$ReplicaRepository.destroy();
							this.$ReplicaRepository = null;
						}
					},

					/**
					 * Subscribes on message that requests the current provider name.
					 * @protected
					 */
					subscribeGetProviderName: function() {
						var moduleId = this.getModuleId("DCTemplateViewer");
						this.sandbox.subscribe("GetProviderName", this.getProviderName,
							this, moduleId);
					},

					/**
					 * Subscribes on message that requests the instance of replica repository.
					 * @protected
					 */
					subscribeGetReplicaRepository: function() {
						var sandboxIdsToSubscribe = [
							this.getModuleId("DCClickHeatmap"),
							this.getModuleId("DCTemplateViewer"),
							this.getDetailId("BulkEmailHyperlink")
						];
						this.sandbox.subscribe("GetReplicaRepository", this.getReplicaRepository,
							this, sandboxIdsToSubscribe);
					},

					/**
					 * Subscribes on messages from template viewer.
					 * @protected
					 */
					subscribeDcTemplateViewer: function() {
						var moduleId = this.getModuleId("DCTemplateViewer");
						this.sandbox.subscribe("ChooseTemplateFromLookup", this.chooseTemplateFromLookup,
							this, [moduleId]);
						this.sandbox.subscribe("EditTemplate", this.editTemplate,
							this, [this.sandbox.id, moduleId]);
					},

					/**
					 * ########## ####### ## ########### #######.
					 * @param {Boolean} value
					 * @returns {Boolean}
					 */
					isAnalysisUnvisible: function(value) {
						return (value !== true);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getHeader
					 * @overridden
					 */
					getHeader: function() {
						return this.get("Category").displayValue;
					},

					/**
					 * ####### ########## #### ####### ########.
					 * @returns {Boolean}
					 */
					isTemplateBodyFilled: function() {
						var template = this.get("TemplateBody") || "";
						return (template.trim().length > 0);
					},

					updateStatusFromDb: function(callback) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "BulkEmail"
						});
						esq.addColumn("Status");
						esq.getEntity(this.$Id, function(result) {
							var entity = result.entity;
							var status = entity.get("Status");
							this.set("Status", status);
							callback();
						}, this);
					},

					/**
					 * ######### ##### action ##### ########## ########.
					 * @param {Function} action #####.
					 */
					runActionAfterSave: function(action) {
						this.showBodyMask({ caption: resources.localizableStrings.SavingCaption, timeout: 0});
						BPMSoft.chain(
							this.saveCheckCanEditRight,
							function(next) {
								if (this.isNew) {
									next();
								} else {
									this.updateStatusFromDb(next);
								}
							},
							this.saveAsyncValidate,
							function(next) {
								this.save({
									callback: next,
									isSilent: true
								});
							},
							function(next) {
								this.saveEntity(function(response) {
									if (this.validateResponse(response)) {
										this.cardSaveResponse = response;
										next();
									}
								}, this);
							},
							function(next) {
								this.showBodyMask({ caption: resources.localizableStrings.SavingCaption, timeout: 0});
								this.saveDetails(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								if (this.$DynamicContentEnabled
									|| BulkEmailHelper.ValidateTemplateBody(this)) {
									next();
								} else {
									BPMSoft.showInformation(resources.localizableStrings.EmptyTemplateBodyMessage);
								}
							},
							function() {
								this.hideBodyMask();
								action.call(this);
								this.cardSaveResponse = null;
								delete this.cardSaveResponse;
							},
						this);
					},

					_saveCronExpression: function() {
						if (!this._getDeliveryScheduleDaysVisible()) {
							this.$DeliveryScheduleDays = "";
						} else {
							var sectionId = this.sandbox.id + "_module_BaseSchemaModuleV2";;
							var cronExpression = this.sandbox.publish("GetCronExpression", null, [sectionId]);
							var cron = BPMSoft.CronExpression.from(cronExpression);
							cron.setParameter(BPMSoft.cron.Parameters.Seconds, "0");
							cron.setParameter(BPMSoft.cron.Parameters.Minutes, "*");
							cron.setParameter(BPMSoft.cron.Parameters.Hours, "*");
							if (cron.isValid()) {
								var normalizedCron = cron.normalize();
								this.$DeliveryScheduleDays = normalizedCron.toString();
							}
						}
					},

					/**
					 * Converts date(timestamp field) to default microsoft json format.
					 * @returns {string}
					 * @private
					 */
					_convertTimestampToWCFFormat: function(date) {
						if (date) {
							let convertedDate = new Date(date);
							let currentDate = new Date();
							convertedDate.setFullYear(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate());
							return this._convertDateTimeToWCFFormat(convertedDate);
						}
						return date;
					},

					/**
					 * Converts date to default microsoft json format.
					 * @returns {string}
					 * @private
					 */
					_convertDateTimeToWCFFormat: function(date) {
						if (date) {
							return "\/Date(" + date.getTime() + "-0000)\/";
						}
						return date;
					},

					/**
					 * Gets config to call service MailingService/GetEmailFirstScheduledDate
					 * @private
					 */
					_getEmailFirstScheduledDateConfig: function() {
						var convertedBusinessTimeStart = this._getConvertedDate(this.$BusinessTimeStart);
						var convertedBusinessTimeEnd = this._getConvertedDate(this.$BusinessTimeEnd);
						const defaultWeekSchedule = "0 * * ? * 1,2,3,4,5,6,7 *";
						return {
							serviceName: "MailingService",
							methodName: "GetEmailFirstScheduledDate",
							data: {
								data: {
									"TimeZoneId": BPMSoft.SysValue.CURRENT_USER_TIMEZONE_CODE,
									"BusinessTimeStart": this._convertTimestampToWCFFormat(convertedBusinessTimeStart),
									"BusinessTimeEnd": this._convertTimestampToWCFFormat(convertedBusinessTimeEnd),
									"CronExpression": this.$DeliveryScheduleDays || defaultWeekSchedule
								}}
						};
					},

					/**
					 * Gets config to call service MailingService/GetThrottlingSchedules
					 * @private
					 */
					_getThrottlingSchedulesConfig: function() {
						return {
							serviceName: "MailingService",
							methodName: "GetThrottlingSchedules",
							data: {
								getThrottlingScheduleRequest: {
									key: "",
									strategy_id: 1
								}
							}
						};
					},

					/**
					 * Checks if compared date greater then check date. If not - returns validation message.
					 * @private
					 */
					_checkDateGreaterThen: function(comparedDate, checkDate, validationLczCode) {
						if (!BulkEmailHelper.GetIsRunnable(this.$Status.value)) {
							return this._getValidationResult("");
						}
						var invalidMessage = "";
						if (comparedDate && comparedDate < checkDate) {
							invalidMessage = this.get(validationLczCode);
						}
						return this._getValidationResult(invalidMessage);
					},

					/**
					 * ######### ########.
					 * @override
					 */
					save: function() {
						this._saveCronExpression();
						if (!this._getEmailStarted()) {
							this.callParent(arguments);
							return;
						}
						if (!this._getIsManualLimitChanged() && !this._getIsEmailScheduleChanged()) {
							this.callParent(arguments);
							return;
						}
						var parentMethod = this.getParentMethod(this, arguments);
						BPMSoft.chain(
							this._updateManualLimitsIfChanged,
							this._updateEmailScheduleIfChanged,
							function(next) {
								parentMethod();
								next();
							}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseEntityPage#saveEntityInChain
					 * @override
					 */
					saveEntityInChain: function(callback, scope) {
						var callbackFn = function() {
							var templateConfig = BPMSoft.decode(this.$TemplateConfig || "{}");
							if (this.isCopyMode() && this.$DynamicContentEnabled &&
									!this.Ext.Object.isEmpty(templateConfig)) {
								var saveConfig = {
									sourceBulkEmailId: this.$SourceEntityPrimaryColumnValue,
									bulkEmailId: this.getPrimaryColumnValue(),
									templateConfig: templateConfig
								};
								this.saveTemplateParts(saveConfig, callback, scope);
							} else {
								callback.call(scope);
							}
						};
						this.callParent([callbackFn, this]);
					},

					/**
					 * ######### ###### ######## c ########## #########.
					 * @abstract
					 */
					runMandrillMassMailing: BPMSoft.emptyFn,

					/**
					 * ######### ######### ########.
					 * @abstract
					 */
					breakMailingAction: BPMSoft.emptyFn,

					stopEmailSending: function(config) {
						const bulkEmailId = this.get("Id");
						BulkEmailHelper.ReloadCard.call(this, bulkEmailId, function() {
							if (this.$Status.value === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND) {
								BulkEmailHelper.PauseMailing.call(this, bulkEmailId);
							} else if (this.$Status.value === MarketingEnums.BulkEmailStatus.STOPPED_MANUALLY || 
										this.$Status.value === MarketingEnums.BulkEmailStatus.BREAKING) {
								this.showInformationDialog(this.get("Resources.Strings.MandrillMassMailingAlreadyStoppedMessage"));
							} else {
								BulkEmailHelper.BreakMailing(bulkEmailId, this, config.confirmationMessage);
							}
						});
					},

					/**
					 * ########## ######## ###### TestBulkEmailModule.
					 */
					sendTestEmail: function() {
						this.runActionAfterSave(function() {
							var bulkEmailId = this.get("Id");
							var bulkEmailName = this.get("Name");
							BulkEmailHelper.OpenSendTestBulkEmail(bulkEmailId, bulkEmailName, this);
							this.hideBodyMask();
						});
					},

					/**
					 * ###### ######### #### "######" (## #### ####### ######## #### "######").
					 */
					processStartDateColumn: function() {
						var startDate = this.get("StartDate");
						var status = this.get("Status");
						if (status.value === MarketingEnums.BulkEmailStatus.START_SCHEDULED && startDate == null) {
							this.loadLookupDisplayValue("Status", MarketingEnums.BulkEmailStatus.PLANNED);
						}
					},

					/**
					 * Validates domain from the "SenderEmail" field and updates validationInfo of the filed when
					 * domain is not valid.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					asyncValidateSenderDomain: function(callback, scope) {
						if (this.getIsBulkEmailUXEnabled()) {
							var domain = this.getSenderDomain();
							var validationConfig = {
								emailId: this.get("Id"),
								senderDomains: [domain],
								providerName: this.$ProviderName
							};
							BulkEmailSenderValidator.validateDomains(validationConfig, function(result) {
								var isValid = result.Domains && result.Domains.length > 0 
									? result.Domains[0].IsValid
									: false;
								this.updateSenderEmailInfoButton(isValid, null, true);
								this.Ext.callback(callback, (scope || this), [isValid]);
							}, this);
						}
					},

					/**
					 * Returns domain of the sender email.
					 * @return {String} domain.
					 */
					getSenderDomain: function() {
						var email = this.get("SenderEmail") || "";
						return email.replace(/^.*@/, "");
					},

					/**
					 * Adds view model columns validators.
					 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig.
					 * @override
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("TimeZone", this.validateTimeZone);
						if (!this.getIsFeatureEnabled("MarketingContentBuilderWizard")) {
							this.addColumnValidator("SenderName", this._senderNameValidator);
							this.addColumnValidator("SenderEmail", this._senderEmailValidator);
							this.addColumnValidator("TemplateSubject", this._templateSubjectValidator);
						}
						if (this.getIsFeatureEnabled("ManualLimitThrottlingQueue")) {
							this.addColumnValidator("DailyLimit", this._dailyLimitValidator);
							this.addColumnValidator("DelayBetweenEmail", this._delayBetweenEmailValidator);
						}
						this.addColumnValidator("ThrottlingQueue", this._throttlingQueueValidator);
						this.addColumnValidator("UtmCampaign", this.checkUtmCampaignValidator);
						this.addColumnValidator("UtmMedium", this.checkUtmMediumValidator);
						this.addColumnValidator("UtmSource", this.checkUtmSourceValidator);
						this.addColumnValidator("UtmTerm", this.checkUtmTermValidator);
						this.addColumnValidator("UtmContent", this.checkUtmContentValidator);
					},

					/**
					 * ######### ######### ## #### "#### ######".
					 * @param {Object} callback ####### ######### ######.
					 * @param {Object} scope ######## ######### ####### ######### ######.
					 */
					validateStartDate: function(callback, scope) {
						var result = {
							success: true
						};
						var startDate = this.get("StartDate");
						var launchOption = this.get("LaunchOption");
						if (launchOption &&
								(launchOption.value === MarketingEnums.BulkEmailLaunchOption.MASS_MAILING_SCHEDULED ||
								launchOption.value === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED) &&
								Ext.isEmpty(startDate)) {
							result.message = this.get("Resources.Strings.EmptyStartDateMessage");
							result.success = false;
						}
						callback.call(scope || this, result);
					},
					
					_formatLocaleDateTimeWithTimeZone: function(date) {
						var stringDate = date
							.toLocaleString(BPMSoft.SysValue.CURRENT_USER_CULTURE.displayValue);
						stringDate = stringDate + Ext.String.format(" ({0})", this.$CurrentUserTimeZone.Offset)
						return stringDate;
					},
					
					_validateEmailDate: function(date, checkDate, validationLczCode) {
						var validationResult = this._checkDateGreaterThen(date,	checkDate, validationLczCode);
						var validationMessage = validationResult.fullInvalidMessage;
						if (validationMessage) {
							var stringDate =  this._formatLocaleDateTimeWithTimeZone(checkDate);
							validationMessage = Ext.String.format(validationMessage, stringDate);
							this.showInformationDialog(validationMessage);
							this.hideBodyMask();
							return false;
						}
						return true;
					},

					validateTimeZone: function() {
						var validationMessage = "";
						var isValid = true;
						var timeZone = this.get("TimeZone");
			 			isValid = Ext.isEmpty(timeZone.Code) 
						if (isValid) {
							validationMessage = this.get("Resources.Strings.FieldEmptyValidationMessage");
								 return {
										invalidMessage: validationMessage
									};
						}
						return this._getValidationResult(validationMessage)
					},

					/**
					 * @inheritdoc BaseBulkEmailPageV2#asyncValidate
					 * @override
					 */
					asyncValidate: function(callback, scope) {
						this.callParent([
							function(response) {
								if (!this.validateResponse(response)) {
									return;
								}
								BPMSoft.chain(
									function(next) {
										var templateBody = this.get("TemplateBody");
										if (!templateBody || BulkEmailTemplateHelper.validateTemplateSize(templateBody.length)) {
											next();
										}
									},
									function(next) {
										this.validateStartDate(function(resultResponse) {
											if (this.validateResponse(resultResponse)) {
												next();
											}
										}, this);
									},
									function(next) {
										var launchOption = this.get("LaunchOption");
										var validateLaunchOption = MarketingEnums.BulkEmailLaunchOption.MASS_MAILING_SCHEDULED;
										if(!launchOption || launchOption.value !== validateLaunchOption) {
											next();
										} else if (this._validateEmailDate(this.$ExpirationDate, this.$StartDate,
											"Resources.Strings.IncorrectExpirationOrStartDateMessage")) {
											next();
										}
									},
									function(next) {
										if (this._validateEmailDate(this.$StartDate, new Date(),
											"Resources.Strings.IncorrectStartDateMessage")) {
											next();
										}
									},
									function(next) {
										if (this._validateEmailDate(this.$ExpirationDate, new Date(),
											"Resources.Strings.IncorrectExpirationDateMessage")) {
											next();
										}
									},
									function(next) {
										if(!this.getIsThrottlingQueueFeatureEnabled) {
											next();
										}
										var config = this._getEmailFirstScheduledDateConfig();
										this.callService(config, function(response) {
											var responseDate = response.firstLaunchDate;
											var firstScheduledDate = new Date(parseInt(responseDate.substr(6)));
											var dateValidationResult = this._checkDateGreaterThen(this.$ExpirationDate,
												firstScheduledDate,"Resources.Strings.ExpirationDateScheduleValidationMessage");
											var validationMessage = dateValidationResult.fullInvalidMessage
											if (validationMessage) {
												var stringDate = this._formatLocaleDateTimeWithTimeZone(firstScheduledDate);
												this.showInformationDialog(
													Ext.String.format(validationMessage, stringDate));
												this.hideBodyMask();
											} else {
												next();
											}
										}, this);
									},
									function(next) {
										callback.call(scope, response);
										next();
									}, this);
							}, this
						]);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#activeTabChange
					 * @override
					 */
					activeTabChange: function(activeTab) {
						this.callParent(arguments);
						var activeTabName = activeTab.get("Name");
						this.set("ActiveTabName", activeTabName);
						this.loadClicksAnalysisTabContent();
						this.loadAnalyticsTabContent();
					},

					/**
					 * Executes methods after saving dynamic content entries.
					 * @protected
					 */
					afterSaveDynamicContentEntries: function() {
						this.clearReplicaRepository();
						this.reloadTemplateViewer();
					},

					/**
					 * Handles response of the BulkEmailTemplateSaved method of BulkEmailTemplateService.
					 * @param {Object} response The service response.
					 * @param {Boolean} isUnsubscribeApplied Indicates if unsubscribe link was applied.
					 */
					onBulkEmailTemplateSaved: function(response, isUnsubscribeApplied) {
						this.hideBodyMask();
						var result = this.Ext.isObject(response) && response.SaveBulkEmailTemplateResult;
						if (result) {
							if (result.Success === true) {
								this.set("TemplateSubject", result.TemplateSubject);
								this.set("TemplateBody", result.TemplateBody);
								this.set("TemplateConfig", result.TemplateConfig);
								this.set("Operation", Enums.CardStateV2.EDIT);
								this.isNew = false;
								if (isUnsubscribeApplied) {
									BPMSoft.utils.showMessage({
										caption: resources.localizableStrings.UnsubscribeLinkAppliedMessage,
										buttons: ["Ok"]
									});
								}
								var templateJson = BPMSoft.decode(result.TemplateConfig, templateJson);
								if (this.$DynamicContentEnabled) {
									this.saveTemplateEntries(this.getPrimaryColumnValue(), templateJson,
										this.afterSaveDynamicContentEntries, this);
								} else {
									this.Ext.callback(this.afterSaveDynamicContentEntries, this);
								}
							} else {
								this.showInformationDialog(result.Message);
							}
						} else {
							this.showInformationDialog(resources.localizableStrings.OnSaveTemplateServiceErrorMessage);
						}
					},

					/**
					 * Cheks whether start sending tooltip is enabled.
					 * @return {boolean} True if start sending tooltip is enabled, otherwise false.
					 */
					isTooltipEnabled: function() {
						var returnValue = false;
						var category = this.get("Category");
						var status = this.get("Status");
						if (category && status) {
							returnValue = BulkEmailHelper.GetIsPlannedTriggeredEmail.call(this, category.value,
								status.value);
						}
						return returnValue;
					},

					getBlankSlatesImage: function() {
						var iconId = this.get("Resources.Strings.CatIconId");
						return this.getSysImageUrl(iconId);
					},
					
					loadTimeZone: function(callback, timeZoneId) {
						if (!timeZoneId) {
							callback.call(this, {});
						}

						var config = {
							serviceName: "MailingService",
							methodName: "GetTimeZoneInfo",
							data: {
									timeZoneId: timeZoneId
								}
						};
						this.callService(config, function(currentTimeZone) {
							var resultTimeZone = {
									value: currentTimeZone.id,
									displayValue: currentTimeZone.displayValue,
									Offset: currentTimeZone.gmtOffset,
									OffsetValue: currentTimeZone.offsetValue,
									Code: currentTimeZone.timeZoneId
								};
								callback.call(this, resultTimeZone);
						}, this);
					},

					setDefaultTimeZone: function() {
						if (this.isAddMode() || this.isCopyMode() && this.getIsThrottlingQueueFeatureEnabled()) {
							this.$TimeZone = this.$CurrentUserTimeZone;
						}
					},

					getSendTimeDeliveryScheduleMessage: function() {
						var deliverySchedule = this.$DeliverySchedule && this.$DeliverySchedule.value;
						var scheduleMessage = this.get("Resources.Strings.DeliveryScheduleEveryDayMessage");
						if (deliverySchedule === MarketingEnums.DeliverySchedule.DAYS_OF_WEEK) {
							scheduleMessage = this.get("Resources.Strings.DeliveryScheduleSpecifiedDaysMessage");
						}
						return scheduleMessage;
					},

					getFormattedTime: function(dateTime) {
						var formatted = Ext.Date.format(dateTime, BPMSoft.Resources.CultureSettings.timeFormat);
						return formatted;
					},

					/**
					 * Converts date from Email's timezone to current users's time zone.
					 * @private
					 */
					_getConvertedDate: function(dateTime) {
						var emailTimeZone = this.$TimeZone && this.$TimeZone.Offset;
						return BPMSoft.convertToTimeZone(dateTime, emailTimeZone,
							this.$CurrentUserTimeZone.OffsetValue);
					},

					getFormattedScheduleItem: function(dateTime) {
						var converted = this._getConvertedDate(dateTime);
						var formatted = this.getFormattedTime(converted);
						return formatted;
					},

					setBusinessTimeEndInfoButtonCaption: function() {
						this.loadTimeZone(function(timeZone) {
							this.set("TimeZone", timeZone,  { silent: true });
							var infoButtonLczMessage = this.get("Resources.Strings.BusinessTimeEndInfoButtonCaption");
							var sendTimeMessage = this.getSendTimeDeliveryScheduleMessage();
							var currentUserTimeZone = this.$CurrentUserTimeZone && this.$CurrentUserTimeZone.displayValue;
							var fromDate = this.$BusinessTimeStart || BPMSoft.startOfDay(new Date());
							var toDate = this.$BusinessTimeEnd || BPMSoft.endOfDay(new Date());
							var fromDateConverted = this.getFormattedScheduleItem(fromDate);
							var toDateConverted = this.getFormattedScheduleItem(this.$BusinessTimeEnd);
							var emailTimeZone = this.$TimeZone && this.$TimeZone.displayValue
								|| BPMSoft.SysValue.CURRENT_USER_TIMEZONE_CODE;
							this.$BusinessTimeEndInfoButtonContent = Ext.String.format(infoButtonLczMessage, 
								sendTimeMessage, fromDateConverted, toDateConverted, currentUserTimeZone,
								this.getFormattedTime(fromDate), this.getFormattedTime(toDate), emailTimeZone);
						}, this.$TimeZone.Code);
						
					},

					setWarmUpThrottlingModeCaption: function() {
						var config = this._getThrottlingSchedulesConfig();
						this.callService(config, function (response) {
							if(!response.GetThrottlingSchedulesResult) {
								return;
							};
							this.set("ThrottlingSchedulesList", response.GetThrottlingSchedulesResult.throttlingSchedulesList);
						}, this);
					},

					/**
					 * @inheritdoc BasePageV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.setDCTemplateViewerVisible();
						this.callParent([function() {
							this.disableAutoUrlDetection();
							this.setDynamicContentEnabled();
							this._setFromNameFromEmailFeature();
							this.initHelpUrl();
							BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
							this.loadSysSettings();
							this.subscribeMessages();
							this._setWizardFeature();
							if (callback) {
								callback.call(scope);
							}
						}, this]);
					},

					/**
					 * @inheritdoc BPMSoft.BaseObject#destroy
					 * @override
					 */
					destroy: function() {
						BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE,
							this.onChannelMessage, this);
						this.callParent(arguments);
					},

					getAnalyticsBlankSlatesCaption: function(){
						var caption = this.get("Resources.Strings.AnalyticsBlankSlatesCaption");
						return this.getGuideText(caption);
					},

					getClicksAnalysisBlankSlatesCaption: function() {
						var caption = this.get("Resources.Strings.ClicksAnalysisBlankSlatesCaption");
						return this.getGuideText(caption);
					},

					getLabelAnalysisBlankSlatesCaption: function(){
						var caption = this.get("Resources.Strings.LabelAnalysisBlankSlatesCaption");
						return this.getGuideText(caption);
					},

					getClickAnalyticsBlankStatesText: function() {
						var caption = this.get("Resources.Strings.ClickAnalyticsBlankStatesText");
						return this.getGuideText(caption);
					},

					getAudienceBlankSlatesCaption: function() {
						var caption = this.get("Resources.Strings.AudienceBlankSlatesCaption");
						return this.getGuideText(caption);
					},

					/**
					 * Returns image config for the SenderEmailInfoButton depending on the enabled state.
					 * @param {Boolean} isValid Determines state of the button and what image has to be returned.
					 * @return {Object} Image config.
					 */
					getSenderEmailInfoButtonImageConfig: function(isValid) {
						var imageName = isValid ? "DefaultIcon" : "WarningIcon";
						return informationButtonResources.localizableImages[imageName];
					},

					updateSenderEmailInfoButton: function(isValid, message, forceShowToolTip) {
						if (this.get("IsSenderEmailValid") !== isValid || forceShowToolTip) {
							this.set("IsSenderEmailInfoMessageVisible", true);
						}
						this.set("IsSenderEmailValid", isValid);
						var imageConfig = this.getSenderEmailInfoButtonImageConfig(isValid);
						this.set("SenderEmailInfoButtonImageConfig", imageConfig);
						var content;
						var style;
						if (isValid) {
							content = message ? message : this.get("Resources.Strings.ValidSenderDomainMessage");
							style = this.BPMSoft.TipStyle.WHITE;
						} else {
							content = message ? message : this.get("Resources.Strings.InvalidSenderDomainMessage");
							style = this.BPMSoft.TipStyle.RED;
						}
						this.set("SenderEmailInfoButtonContent", content);
						this.set("SenderEmailInfoButtonStyle", style);
					},

					/**
					 * Opens Bpmcrm Cloud Integration settings page.
					 */
					openBpmCrmCloudIntegrationPage: function() {
						var pageName = "BpCloudIntegrationPageV2";
						this.openCardInChain({
							moduleId: this.sandbox.id + "_" + pageName,
							schemaName: pageName
						});
					},

					/**
					 * Handles click on the SenderEmailInfoButton.
					 * @return {Boolean}.
					 */

					onSenderEmailInfoButtonClick: function() {
						this.openBpmCrmCloudIntegrationPage();
						return false;
					},

					/**
					 * Returns visibility value for BulkEmailClicksMap control group.
					 */
					isBulkEmailClicksMapVisible: function() {
						return this.get("IsAnalysisVisible") && !this.isDCClickHeatmapVisible();
					},

					/**
					 * Returns visibility value for BulkEmailHyperlinksClicksChart control group.
					 */
					isBulkEmailHyperlinksClicksChartVisible: function() {
						return this.get("IsAnalysisVisible") &&
							this.getIsFeatureEnabled("BulkEmailHyperlinksClicksChart");
					},

					/**
					 * Returns visibility value for SenderFieldsMacroGridLayout.
					 */
					isSenderFieldsMacroVisible: function() {
						return !this.$IsMarketingContentBuilderWizardEnabled &&
							this.$IsFromEmailFromNameMacroFeatureEnabled;
					},

					/**
					 * Returns visibility value for MandrillPageGeneralInfoGridLayout.
					 */
					isSenderFieldsWithoutMacroVisible: function() {
						return !(this.$IsMarketingContentBuilderWizardEnabled ||
							this.$IsFromEmailFromNameMacroFeatureEnabled);
					},

					/**
					 * Returns visibility for send process diagram.
					 * @protected
					 * @returns {Boolean}
					 */
					isSendProcessDiagramVisible: function() {
						var status = this.$Status && this.$Status.value;
						return status !== MarketingEnums.BulkEmailStatus.DRAFT
							&& status !== MarketingEnums.BulkEmailStatus.PLANNED
							&& status !== MarketingEnums.BulkEmailStatus.STARTING;
					},

					/**
					 * Handler on reset audience schema message.
					 * @protected
					 */
					resetAudienceSchema: function() {
						this.$IsAudienceSchemaEnabled = true;
						this.$IsAudienceInited = false;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "SaveButton",
						"values": {
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE
						}
					},
					{
						"operation": "insert",
						"name": "Name",
						"values": {
							"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1}
						},
						"parentName": "Header",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "LaunchOption",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 0, "row": 1, "colSpan": 5, "rowSpan": 1},
							"caption": {bindTo: "Resources.Strings.SendPeriodCaption"},
							"markerValue": {bindTo: "Resources.Strings.SendPeriodCaption"},
							"controlConfig": {"enabled": {bindTo: "IsLaunchOptionEnabled"}},
							"labelConfig": {"isRequired": false}
						},
						"parentName": "Header",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "RecipientCount",
						"values": {
							"layout": {"colSpan": 5, "rowSpan": 1, "column": 19, "row": 0, "layoutName": "Header"},
							"bindTo": "RecipientCount",
							"enabled": false
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 5
					},
					{
						"operation": "insert",
						"name": "Status",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 13, "row": 0, "colSpan": 4, "rowSpan": 1},
							"labelConfig": {"isRequired": false},
							"controlConfig": {"enabled": false}
						},
						"parentName": "Header",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "StatusButtonInfo",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content":  {bindTo: "Resources.Strings.StatusButtonInfoToolTip"},
							"style": BPMSoft.TipStyle.WHITE,
							"behaviour": {
								"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
							},
							"layout": {"column": 17, "row": 0, "colSpan": 1, "rowSpan": 1},
							"controlConfig": {
								"visible":  {bindTo: "_getStatusButtonInfoVisible"},
								"imageConfig": informationButtonResources.localizableImages.InfoStatusIcon
							}
						},
						"parentName": "Header",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "StartDate",
						"values": {
							"layout": {"column": 6, "row": 1, "colSpan": 5, "rowSpan": 1},
							"labelConfig": {"visible": false},
							"controlConfig": {
								"setValidationInfo": BPMSoft.emptyFn,
								"visible": {"bindTo": "IsSendScheduled"}
							}
						},
						"parentName": "Header",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "BulkEmailInfoContainer",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 2
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "SendProcessDiagramContainer",
						"parentName": "BulkEmailInfoContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"id": "SendProcessDiagramContainer",
							"selectors": {
								"el": "#SendProcessDiagramContainer",
								"wrapEl": "#SendProcessDiagramContainer"
							},
							"items": [],
							"afterrerender": {"bindTo": "loadSendProcessDiagram"},
							"afterrender": {"bindTo": "loadSendProcessDiagram"},
							"visible": "$isSendProcessDiagramVisible"
						}
					},
					{
						"operation": "insert",
						"name": "BulkEmailQueueTasksContainer",
						"parentName": "BulkEmailInfoContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"visible": {
								"bindTo": "$isSendProcessDiagramVisible",
								"bindConfig": {"converter": "invertBooleanValue"}
							},
							"wrapClass": ["bulk-email-queue-tasks-wrap"]
						}
					},
					{
						"operation": "insert",
						"name": "GeneralInfoTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.GeneralInfoTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "SendingTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {bindTo: "Resources.Strings.SendingTabCaption"},
							"items": []
						},
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "SendingTabContainer",
						"propertyName": "items",
						"name": "BulkEmailAudience",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL,
							"visible": "$IsOppAudienceVisible"
						}
					},
					{
						"operation": "insert",
						"name": "MandrillPageGeneralInfoGridLayout",
						"parentName": "GeneralInfoTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"visible": {
								"bindTo": "isSenderFieldsWithoutMacroVisible"
							}
						}
					},
					{
						"operation": "insert",
						"name": "SenderEmail",
						"parentName": "MandrillPageGeneralInfoGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 10,
								"rowSpan": 1
							},
							"controlConfig": {
								"enabled": {bindTo: "IsRunEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "SenderName",
						"parentName": "MandrillPageGeneralInfoGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"column": 13,
								"rowSpan": 1
							},
							"controlConfig": {
								"enabled": {bindTo: "IsRunEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "SenderEmailInfoButton",
						"parentName": "MandrillPageGeneralInfoGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "SenderEmailInfoButtonContent"},
							"visible": {"bindTo": "IsSenderEmailInfoMessageVisible"},
							"linkClicked": {"bindTo": "onSenderEmailInfoButtonClick"},
							"style": {"bindTo": "SenderEmailInfoButtonStyle"},
							"behaviour": {
								"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
							},
							"layout": {
								"column": 23,
								"row": 0,
								"colSpan": 1,
								"rowSpan": 1
							},
							"controlConfig": {
								"visible": {"bindTo": "getIsBulkEmailUXEnabled"},
								"imageConfig": {"bindTo": "SenderEmailInfoButtonImageConfig"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSubject",
						"parentName": "MandrillPageGeneralInfoGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 22,
								"rowSpan": 1
							},
							"controlConfig": {
								"enabled": {bindTo: "IsRunEnabled"},
								"macrobuttonclicked": {bindTo: "_onSubjectMacroClicked"},
								"selectedText": {bindTo: "SubjectSelectedMacros"},
								"preventEnterPress": true,
								"ckeditorDefaultConfig": {
									"allowedContent": true,
									"removeButtons": "Underline,JustifyCenter,JustifyLeft,JustifyRight,Font,Link" +
									",FontSize,JustifyBlock,NumberedList,BulletedList,Bold,Italic,TextColor,Undo" +
									",Redo,Indent,Outdent,bpmcrmsource,lineheight,letterspacing,lineheightpanel," +
									"letterspacingpanel,bpmcrmemailtemplatelink,indentpanel",
									"forcePasteAsPlainText": true,
									"basicEntities": false
								}
							},
							"className": "BPMSoft.InlineTextEdit",
							"wrapClass": ["macro-input"]
						}
					},
					{
						"operation": "insert",
						"name": "SenderFieldsMacroGridLayout",
						"parentName": "GeneralInfoTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"visible": {
								"bindTo": "isSenderFieldsMacroVisible"
							}
						}
					},
					{
						"operation": "insert",
						"name": "SenderNameMacro",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"column": 13,
								"rowSpan": 1
							},
							"controlConfig": {
								"enabled": {bindTo: "IsRunEnabled"}
							},
							"bindTo": "SenderName",
							"visible": {
								"bindTo": "IsFromEmailFromNameMacroFeatureEnabled",
								"enabled": {bindTo: "IsRunEnabled"}
							},
							"wrapClass": ["macro-input"]
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSenderNameMacroSelectMacroButton",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"click": "$_onTemplateSenderNameSelectMacroButtonClick",
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 1,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "IsRunEnabled"
							},
							"imageConfig": "$Resources.Images.BpmCrmMacrosIcon"
						}
					},
					{
						"operation": "insert",
						"name": "SenderEmailMacro",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 9,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "IsFromEmailFromNameMacroFeatureEnabled"
							},
							"controlConfig": {
								"enabled": {bindTo: "IsRunEnabled"}
							},
							"bindTo": "SenderEmail",
							"wrapClass": ["macro-input"]
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSenderEmailMacroSelectMacroButton",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"click": "$_onTemplateSenderEmailSelectMacroButtonClick",
							"layout": {
								"column": 23,
								"row": 0,
								"colSpan": 1,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "IsRunEnabled"
							},
							"imageConfig": "$Resources.Images.BpmCrmMacrosIcon"
						}
					},
					{
						"operation": "insert",
						"name": "SenderEmailInfoButtonMacroGrid",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "SenderEmailInfoButtonContent"},
							"visible": {"bindTo": "IsSenderEmailInfoMessageVisible"},
							"linkClicked": {"bindTo": "onSenderEmailInfoButtonClick"},
							"style": {"bindTo": "SenderEmailInfoButtonStyle"},
							"behaviour": {
								"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
							},
							"layout": {
								"column": 22,
								"row": 0,
								"colSpan": 1,
								"rowSpan": 1
							},
							"controlConfig": {
								"visible": {"bindTo": "getIsBulkEmailUXEnabled"},
								"imageConfig": {"bindTo": "SenderEmailInfoButtonImageConfig"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSubjectMacro",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 23,
								"rowSpan": 1
							},
							"controlConfig": {
								"injectionValue":  "$TemplateSubjectInsertBuffer",
								"enabled": {bindTo: "IsRunEnabled"}
							},
							"bindTo": "TemplateSubject",
							"wrapClass": ["macro-input"]
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSubjectMacroSelectMacroButton",
						"parentName": "SenderFieldsMacroGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"click": "$_onTemplateSubjectSelectMacroButtonClick",
							"layout": {
								"column": 23,
								"row": 1,
								"colSpan": 1,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "IsRunEnabled"
							},
							"imageConfig": "$Resources.Images.BpmCrmMacrosIcon"
						}
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoTab",
						"name": "TemplateControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {bindTo: "Resources.Strings.TemplateControlGroupCaption"},
							"tools": [],
							"items": [],
							"controlConfig": {
								"collapsed": {"bindTo": "IsTemplateDataCollapsed"},
								"classes": ["detail bulk-email-template-control-group"]
							},
							"visible": {
								"bindTo": "isDCTemplateViewerVisible",
								"bindConfig": {"converter": "invertBooleanValue"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSwitchViewContaner",
						"parentName": "TemplateControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "TemplateHtmlGridContainer",
						"parentName": "TemplateControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "TemplateHtmlGridContainer",
						"name": "TemplateHtmlGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "TemplateHtmlContainer",
						"parentName": "TemplateHtmlGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"layout": {"column": 0, "row": 0, "rowSpan": 6, "colSpan": 24},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "TemplateHtml",
						"parentName": "TemplateHtmlContainer",
						"propertyName": "items",
						"values": {
							"generator": function() {
								return {
									"className": "BPMSoft.IframeControl",
									"id": "preview-content-iframe",
									"iframeContent": {"bindTo": "TemplateBody"}
								};
							}
						}
					},
					{
						"operation": "insert",
						"name": "InsertTemplateFromLookupMenuItem",
						"parentName": "TemplateControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"caption": {"bindTo": "Resources.Strings.InsertTemplateFromLookupMenuItemCaption"},
							"click": {"bindTo": "chooseTemplateFromLookup"},
							"enabled": {bindTo: "IsTemplateEditable"}
						}
					},
					{
						"operation": "insert",
						"name": "EditTemplate",
						"parentName": "TemplateControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"caption": {"bindTo": "Resources.Strings.EditTemplateCaption"},
							"click": {"bindTo": "editTemplate"},
							"enabled": {bindTo: "IsTemplateEditable"}
						}
					},
					{
						"operation": "insert",
						"name": "NotesAndFilesTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 6,
						"values": {
							"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesAndFilesTab",
						"name": "NotesAndFilesTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"controlConfig": {
								"collapsed": false
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesAndFilesTabContainer",
						"propertyName": "items",
						"name": "NotesAndFilesInformationBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesAndFilesTab",
						"propertyName": "items",
						"name": "Files",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"name": "NotesControlGroup",
						"parentName": "NotesAndFilesTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
							"controlConfig": {
								"collapsed": false
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesControlGroup",
						"propertyName": "items",
						"name": "Notes",
						"values": {
							"contentType": BPMSoft.ContentType.RICH_TEXT,
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"labelConfig": {
								"visible": false
							},
							"controlConfig": {
								"imageLoaded": {
									"bindTo": "insertImagesToNotes"
								},
								"images": {
									"bindTo": "NotesImagesCollection"
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "ClicksAnalysisTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.ClicksAnalysisTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "DCClickHeatmap",
						"parentName": "ClicksAnalysisTab",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.MODULE,
							"visible": {
								"bindTo": "isDCClickHeatmapVisible"
							}
						}
					},
					{
						"operation": "insert",
						"name": "DCTemplateViewer",
						"parentName": "GeneralInfoTab",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.MODULE,
							"visible": "$_getDCTemplateViewerVisibility"
						}
					},
					{
						"operation": "insert",
						"parentName": "ClicksAnalysisTab",
						"name": "BulkEmailClicksMapControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.ClickHeatmapCaption"},
							"items": [],
							"collapsedchanged": {"bindTo": "clicksMapControlGroupCollapsedChanged"},
							"controlConfig": {
								"collapsed": false,
								"visible": {
									"bindTo": "isBulkEmailClicksMapVisible"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailClicksMapControlGroup",
						"propertyName": "items",
						"name": "BulkEmailClicksMapContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"id": "BulkEmailClicksMapContainer",
							"selectors": {
								"el": "#BulkEmailClicksMapContainer",
								"wrapEl": "#BulkEmailClicksMapContainer"
							},
							"afterrerender": {"bindTo": "loadClicksMap"},
							"afterrender": {"bindTo": "loadClicksMap"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailClicksMapContainer",
						"propertyName": "items",
						"name": "BulkEmailClicksMapModule",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["clicks-map-container"]
							}
						},
						"index": 0
					},
					{
						"operation": "insert",
						"name": "SendingProgressTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.SendingProgressTabTabCaption"
							},
							"items": [],
							"order": 3
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 3
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressTab",
						"propertyName": "items",
						"name": "SendingProgressIndicators",
						"values": {
							"markerValue": "SendingProgressIndicators",
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"afterrerender": {"bindTo": "loadIndicatorsModules"},
							"afterrender": {"bindTo": "loadIndicatorsModules"},
							"caption": "",
							"items": [],
							"controlConfig": {
								"collapsed": false,
								"visible": true
							}
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorRecipient",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorPreparingToSendRecipients",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorSendingRecipients",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 2
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorReceivedInitialResponse",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 3
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorStoppedRecipients",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 4
					},
					{
						"operation": "insert",
						"parentName": "SendingProgressIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorCanceled",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 5
					},
					{
						"operation": "insert",
						"name": "SendingDurationGroup",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.SendingDurationGroupGroupCaption"
							},
							"itemType": 15,
							"items": []
						},
						"parentName": "SendingProgressTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "SendingProgressTabGridLayout",
						"values": {
							"itemType": 0,
							"items": []
						},
						"parentName": "SendingDurationGroup",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "SendStartDate",
						"values": {
							"layout": {
								"colSpan": 11,
								"rowSpan": 1,
								"column": 0,
								"row": 0,
								"layoutName": "SendingProgressTabGridLayout"
							},
							"bindTo": "SendStartDate",
							"enabled": false
						},
						"parentName": "SendingProgressTabGridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "SendDueDate",
						"values": {
							"layout": {
								"colSpan": 11,
								"rowSpan": 1,
								"column": 0,
								"row": 1,
								"layoutName": "SendingProgressTabGridLayout"
							},
							"bindTo": "SendDueDate",
							"enabled": false
						},
						"parentName": "SendingProgressTabGridLayout",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "DurationBulkEmail",
						"values": {
							"caption": {bindTo: "Resources.Strings.DurationBulkEmailCaption"},
							"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1},
							"enabled": false,
							"value": {
								bindTo: "calculateDurationBulkEmail"
							},
							dataValueType: BPMSoft.DataValueType.TEXT
						},
						"parentName": "SendingProgressTabGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "BulkEmailEventLogDetail",
						"values": {
							"itemType": 2,
							"markerValue": "added-detail"
						},
						"parentName": "SendingProgressTab",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "AnalyticsTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.AnalyticsTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 5
					},
					{
						"operation": "insert",
						"parentName": "AnalyticsTab",
						"propertyName": "items",
						"name": "BulkEmailIndicators",
						"values": {
							"markerValue": "BulkEmailIndicators",
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"afterrerender": {"bindTo": "loadIndicatorsModules"},
							"afterrender": {"bindTo": "loadIndicatorsModules"},
							"caption": "",
							"items": [],
							"controlConfig": {
								"collapsed": false,
								"visible": {
									"bindTo": "IsAnalysisVisible"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "AnalyticsTab",
						"name": "BulkEmailOpensClicksChartControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.OpensClicksChartGroupCaption"},
							"items": [],
							"collapsedchanged": {"bindTo": "openClicksGroupCollapsedChanged"},
							"controlConfig": {
								"collapsed": false,
								"visible": {
									"bindTo": "IsAnalysisVisible"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "ClicksAnalysisTab",
						"name": "BulkEmailHyperlinksClicksChartControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.HyperlinksClicksChartControlGroupCaption"},
							"items": [],
							"collapsedchanged": {"bindTo": "hyperlinksClicksGroupCollapsedChanged"},
							"controlConfig": {
								"collapsed": false,
								"visible": {
									"bindTo": "isBulkEmailHyperlinksClicksChartVisible"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "AnalyticsTab",
						"name": "BulkEmailNotDeliveredChartControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.NotDeliveredChartGroupCaption"},
							"items": [],
							"collapsedchanged": {"bindTo": "notDeliveredChartGroupCollapsedChanged"},
							"controlConfig": {
								"collapsed": false,
								"visible": {
									"bindTo": "IsAnalysisVisible"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailNotDeliveredChartControlGroup",
						"propertyName": "items",
						"name": "BulkEmailNotDeliveredChartGridLayout",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailNotDeliveredChartGridLayout",
						"propertyName": "items",
						"name": "BulkEmailCanceledChartContainer",
						"values": {
							"id": "BulkEmailCanceledChartContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"selectors": {
								"el": "#BulkEmailCanceledChartContainer",
								"wrapEl": "#BulkEmailCanceledChartContainer"
							},
							"afterrerender": {"bindTo": "_loadCanceledChart"},
							"afterrender": {"bindTo": "_loadCanceledChart"},
							"items": [],
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailCanceledChartContainer",
						"propertyName": "items",
						"name": "BulkEmailCanceledChartEmptyDataGridLayout",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"classes": {
								"wrapClassName": ["no-data-image"]
							},
							"visible": {bindTo: "isCanceledChartEmpty"}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailCanceledChartEmptyDataGridLayout",
						"propertyName": "items",
						"name": "BulkEmailCanceledChartContainerImage",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getEmptyChartDataImage"
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailCanceledChartEmptyDataGridLayout",
						"name": "BulkEmailCanceledChartEmptyDataImageLabel",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getCanceledBlankSlatesCaption"
							},
							"classes": {
								"multilineLabelClass": ["caption-label"],
								"wrapClass": ["caption-container"]
							},
							"contentVisible": true
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailCanceledChartEmptyDataGridLayout",
						"name": "BulkEmailCanceledChartEmptyDataImageLabelText",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							},
							"caption": {
								"bindTo": "getCanceledBlankSlatesText"
							},
							"contentVisible": true
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailNotDeliveredChartGridLayout",
						"propertyName": "items",
						"name": "BulkEmailNotDeliveredChartContainer",
						"values": {
							"id": "BulkEmailNotDeliveredChartContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"selectors": {
								"el": "#BulkEmailNotDeliveredChartContainer",
								"wrapEl": "#BulkEmailNotDeliveredChartContainer"
							},
							"afterrerender": {"bindTo": "_loadNotDeliveredChart"},
							"afterrender": {"bindTo": "_loadNotDeliveredChart"},
							"items": [],
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailNotDeliveredChartContainer",
						"propertyName": "items",
						"name": "BulkEmailNotDeliveredChartEmptyDataGridLayout",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"classes": {
								"wrapClassName": ["no-data-image"]
							},
							"visible": {bindTo: "isNotDeliveredChartEmpty"}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailNotDeliveredChartEmptyDataGridLayout",
						"propertyName": "items",
						"name": "BulkEmailNotDeliveredChartContainerImage",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getEmptyChartDataImage"
						}
					},
					{
						"operation": "insert",
						"name": "BulkEmailNotDeliveredChartControlGroupLabel",
						"parentName": "BulkEmailNotDeliveredChartEmptyDataGridLayout",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getNotDeliveredBlankSlatesCaption"
							},
							"classes": {
								"multilineLabelClass": ["caption-label"],
								"wrapClass": ["caption-container"]
							},
							"contentVisible": true
						}
					},
					{
						"operation": "insert",
						"name": "BulkEmailNotDeliveredChartControlGroupLabelText",
						"parentName": "BulkEmailNotDeliveredChartEmptyDataGridLayout",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getNotDeliveredBlankStatesText"
							},
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							},
							"contentVisible": true
						}
					},
					{
						"operation": "insert",
						"name": "AudienceBlankSlatesLayout",
						"parentName": "SendingTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"visible": {
								"bindTo": "IsBlankSlatesAudienceVisible"
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "AudienceBlankSlatesLayout",
						"name": "AudienceBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"markerValue": "AudienceBlankSlatesContainer",
							"id": "AudienceBlankSlatesContainer",
							"selectors": {"wrapEl": "#AudienceBlankSlatesContainer"},
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["bulk-email-blank-slates-container"],
							"layout": {"column": 0, "row": 0, "rowSpan": 6, "colSpan": 24},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "AudienceBlankSlatesImage",
						"parentName": "AudienceBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getBlankSlatesImage",
							"classes": {
								"wrapClass": ["not-selected-image"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "AudienceBlankSlatesLabel",
						"parentName": "AudienceBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getAudienceBlankSlatesCaption"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "ClicksAnalysisBlankSlatesLayout",
						"parentName": "ClicksAnalysisTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"visible": {
								"bindTo": "IsAnalysisVisible",
								"bindConfig": {"converter": "isAnalysisUnvisible"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "ClicksAnalysisBlankSlatesLayout",
						"name": "ClicksAnalysisBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"markerValue": "ClicksAnalysisBlankSlatesContainer",
							"id": "ClicksAnalysisBlankSlatesContainer",
							"selectors": {"wrapEl": "#ClicksAnalysisBlankSlatesContainer"},
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"layout": {"column": 0, "row": 0, "rowSpan": 6, "colSpan": 24},
							"wrapClass": ["bulk-email-blank-slates-container"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ClicksAnalysisBlankSlatesImage",
						"parentName": "ClicksAnalysisBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getBlankSlatesImage",
							"classes": {
								"wrapClass": ["not-selected-image"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "ClicksAnalysisBlankSlatesLabel",
						"parentName": "ClicksAnalysisBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getAnalysisBlankSlatesCaption"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "LabelAnalysisBlankSlatesCaption",
						"parentName": "ClicksAnalysisBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getLabelAnalysisBlankSlatesCaption"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["caption-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "ClicksAnalysisBlankSlatesLabel",
						"parentName": "ClicksAnalysisBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getClicksAnalysisBlankSlatesCaption"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "AnalyticsBlankSlatesLayout",
						"parentName": "AnalyticsTab",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"visible": {
								"bindTo": "IsAnalysisVisible",
								"bindConfig": {"converter": "isAnalysisUnvisible"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "AnalyticsBlankSlatesLayout",
						"name": "AnalyticsBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"markerValue": "AnalyticsBlankSlatesContainer",
							"id": "AnalyticsBlankSlatesContainer",
							"selectors": {"wrapEl": "#AnalyticsBlankSlatesContainer"},
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"layout": {"column": 0, "row": 0, "rowSpan": 6, "colSpan": 24},
							"wrapClass": ["bulk-email-blank-slates-container"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "AnalyticsBlankSlatesImage",
						"parentName": "AnalyticsBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"onPhotoChange": BPMSoft.emptyFn,
							"getSrcMethod": "getBlankSlatesImage",
							"classes": {
								"wrapClass": ["not-selected-image"]
							}
						}
					},
										{
						"operation": "insert",
						"name": "AnalyticsBlankSlatesCaption",
						"parentName": "AnalyticsBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getAnalyticsBlankSlatesCaption"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["caption-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "AnalyticsBlankSlatesLabel",
						"parentName": "AnalyticsBlankSlatesContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "getClickAnalyticsBlankStatesText"
							},
							"contentVisible": true,
							"classes": {
								"multilineLabelClass": ["description-label"],
								"wrapClass": ["description-container"]
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "ClicksAnalysisTab",
						"propertyName": "items",
						"name": "BulkEmailHyperlink",
						"values": {
							itemType: this.BPMSoft.ViewItemType.DETAIL,
							"visible": {
								"bindTo": "IsAnalysisVisible"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailHyperlinksClicksChartControlGroup",
						"propertyName": "items",
						"name": "BulkEmailHyperlinkClicksChartContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"id": "BulkEmailHyperlinkClicksChartContainer",
							"selectors": {
								"el": "#BulkEmailHyperlinkClicksChartContainer",
								"wrapEl": "#BulkEmailHyperlinkClicksChartContainer"
							},
							"afterrerender": {"bindTo": "loadHyperlinksClicksChart"},
							"afterrender": {"bindTo": "loadHyperlinksClicksChart"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailOpensClicksChartControlGroup",
						"propertyName": "items",
						"name": "BulkEmailOpensClicksChartContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"id": "BulkEmailOpensClicksChartContainer",
							"selectors": {
								"el": "#BulkEmailOpensClicksChartContainer",
								"wrapEl": "#BulkEmailOpensClicksChartContainer"
							},
							"afterrerender": {"bindTo": "loadOpensClicksChart"},
							"afterrender": {"bindTo": "loadOpensClicksChart"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorDelivered",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorOpens",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorClicks",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 2
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorUnsubscribe",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 3
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailIndicators",
						"propertyName": "items",
						"name": "BulkEmailIndicatorSpam",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": ["indicator-container"]
							}
						},
						"index": 4
					},
					{
						"operation": "insert",
						"name": "BulkEmailActionButtons",
						"parentName": "LeftContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {
								"wrapClassName": ["email-action-buttons"]
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailActionButtons",
						"index": 1,
						"propertyName": "items",
						"name": "EditTemplateButton",
						"values": {
							itemType: this.BPMSoft.ViewItemType.BUTTON,
							caption: {bindTo: "EditTemplateActionCaption"},
							classes: {textClass: "actions-button-margin-right"},
							click: {bindTo: "editTemplate"},
							enabled: {bindTo: "IsTemplateEditable"},
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							visible: {bindTo: "IsMarketingContentBuilderWizardEnabled"},
							markerValue: "EditTemplate"
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailActionButtons",
						"index": 2,
						"propertyName": "items",
						"name": "SendTestEmail",
						"values": {
							itemType: BPMSoft.ViewItemType.BUTTON,
							caption: {bindTo: "SendTestEmailActionCaption"},
							classes: {textClass: "actions-button-margin-right"},
							click: {bindTo: "_openTestEmailContainer"},
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
							visible: {bindTo: "IsSendTestEmailVisible"}
						}
					},
					{
						"operation": "insert",
						"parentName": "BulkEmailActionButtons",
						"index": 3,
						"propertyName": "items",
						"name": "SendButton",
						"values": {
							itemType: BPMSoft.ViewItemType.BUTTON,
							caption: {bindTo: "SendMailingActionCaption"},
							classes: {textClass: "actions-button-margin-right"},
							click: {bindTo: "runMandrillMassMailing"},
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							visible: {bindTo: "IsRunDisplayed"},
							tips: []
						}
					},
					{
						"operation": "insert",
						"parentName": "SendButton",
						"propertyName": "tips",
						"name": "SendMailingActionHint",
						"values": {
							"content": {"bindTo": "Resources.Strings.SendMailingActionHint"},
							"enabled": {"bindTo": "isTooltipEnabled"},
							"tools": []
						}
					},
					{
						"operation": "insert",
						"parentName": "LeftContainer",
						"propertyName": "items",
						"name": "BreakButton",
						"values": {
							itemType: BPMSoft.ViewItemType.BUTTON,
							caption: {bindTo: "Resources.Strings.BreakMandrillMassMailingActionCaption"},
							classes: {textClass: "actions-button-margin-right"},
							click: {bindTo: "breakMailingAction"},
							style: BPMSoft.controls.ButtonEnums.style.RED,
							visible: {bindTo: "IsBreakEnabled"}
						}
					},
					{
						"operation": "insert",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"name": "SettingsTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.SettingsTabCaption"
							},
							"items": []
						},
						"index": 2
					},
					{
						"operation": "insert",
						"parentName": "SettingsTab",
						"name": "SettingsTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "SettingsTabContainer",
						"name": "CommonSettingsContainerGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "CommonSettingsContainerGroup",
						"name": "CommonSettingsGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "Type",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
							"enabled": {"bindTo": "IsBulkEmailTypeEnabled"}
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "Owner",
						"values": {
							"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1},
							"controlConfig": {
								"enabled": {bindTo: "IsTemplateEditable"}
							}
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "ExpirationDateContainer",
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"layout": { "column": 0, "row": 2, "colSpan": 11, "rowSpan": 1 },
							"classes": {
								"wrapClassName": ["expiration-date-container"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "ExpirationDate",
						"values": {
							"bindTo": "ExpirationDate",
							"visible": "$getIsThrottlingQueueFeatureEnabled",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable",
							"tip" : {
								"content": {"bindTo": "Resources.Strings.ExpirationDateInfoButtonCaption"},
							},
							"controlConfig": {
								"visible": "$getIsThrottlingQueueFeatureEnabled",
							},
						},
						"parentName": "ExpirationDateContainer",
						"propertyName": "items",
					},
					{
						"operation": "remove",
						"name": "ExpirationDateInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.ExpirationDateInfoButtonCaption"},
							"controlConfig": {
								"visible": "$getIsThrottlingQueueFeatureEnabled",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							},
							"classes": {
								"wrapperClass": ["expiration-date-info-button"]
							}
						},
						"parentName": "ExpirationDateContainer",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "Priority",
						"values": {
							"layout": { "column": 13, "row": 2, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "Priority",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable",
							"labelConfig": {"isRequired": true},
							"visible":"$getIsThrottlingQueueFeatureEnabled",
							"tip" : {
								"content": {"bindTo": "Resources.Strings.PriorityInfoButtonCaption"},
							},
							"controlConfig": {
								"visible": "$getIsThrottlingQueueFeatureEnabled",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "remove",
						"name": "PriorityInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.PriorityInfoButtonCaption"},
							"layout": { "column": 23, "row": 2, "colSpan": 1, "rowSpan": 1 },
							"controlConfig": {
								"visible": "$getIsThrottlingQueueFeatureEnabled",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "Campaign",
						"values": {
							"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1},
							"controlConfig": {
								"enabled": false
							}
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"parentName": "SettingsTabContainer",
						"name": "SendingPreferencesControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {bindTo: "Resources.Strings.SendingPreferencesTabGroupCaption"},
							"items": [],
							"tools": [],
							"visible": "$getIsESPSelectionFeatureEnabled",
						}
					},
					{
						"operation": "insert",
						"parentName": "SendingPreferencesControlGroup",
						"name": "SendingPreferencesGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ProviderNameLookupValue",
						"values": {
							"contentType": this.BPMSoft.ContentType.ENUM,
							"layout": { "column": 0, "row": 0, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "ProviderNameLookupValue",
							"caption": {bindTo: "Resources.Strings.ESPCaption"},
							"enabled": {bindTo: "IsTemplateEditable"},
							"controlConfig": {
								"prepareList": "$onPrepareProvidersLookup"
							}
						},
						"parentName": "SendingPreferencesGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "ProviderInfoButton",
						"parentName": "SendingPreferencesGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": "$ProviderInfoButtonContent",
							"visible": "$ProviderInfoButtonTipVisible",
							"linkClicked": "$_onProviderInfoButtonClick",
							"style": "$ProviderInfoButtonStyle",
							"behaviour": {
								"displayEvent": this.BPMSoft.TipDisplayEvent.CLICK
							},
							"controlConfig": {
								"visible": "$ProviderInfoButtonVisible",
								"imageConfig": "$ProviderInfoButtonImageConfig"
							},
							"layout": {
								"column": 1,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "SettingsTabContainer",
						"name": "ThrottlingSettingsControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {bindTo: "Resources.Strings.ThrottlingSettingsTabGroupCaption"},
							"items": [],
							"tools": [],
							"visible":"$getIsThrottlingQueueFeatureEnabled"
						}
					},
					{
						"operation": "insert",
						"name": "ThrottlingSettingsInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.ThrottlingSettingsInfoButton"},
							"behaviour": {
								"displayEvent": BPMSoft.TipDisplayEvent.HOVER
							},
							"controlConfig": {
								"classes": {
									"wrapperClass": "info-button-detail",
								}
							}
						},
						"parentName": "ThrottlingSettingsControlGroup",
						"propertyName": "tools",
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "ThrottlingSettingsControlGroup",
						"name": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"collapseEmptyRow": true
						}
					},
					{
						"operation": "insert",
						"name": "ThrottlingMode",
						"values": {
							"layout": { "column": 0, "row": 0, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "ThrottlingMode",
							"enabled": {bindTo: "IsTemplateEditable"},
							"labelConfig": {"isRequired": true}
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "WarmUpThrottlingModeInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": "$_getThrottlingModeInfoButtonCaption",
							"layout": { "column": 11, "row": 0, "colSpan": 1, "rowSpan": 1 },
							"className": "BPMSoft.ThrottlingModeExtendedTip",
							"customToolTipClass": "warmup-schedule-info-button",
							"throttlingSchedulesList": { "bindTo": "ThrottlingSchedulesList"},
							"controlConfig": {
								"visible": "$_getIsThrottlingModeInfoButtonVisible",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "ThrottlingQueue",
						"values": {
							"layout": { "column": 13, "row": 0, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "ThrottlingQueue",
							"visible": "$_getIsThrottlingQueueVisible",
							"enabled": {bindTo: "IsTemplateEditable"},
							"labelConfig": {"isRequired": true}
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "WarmUpThrottlingQueueInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.WarmUpThrottlingQueueInfoButtonCaption"},
							"layout": { "column": 23, "row": 0, "colSpan": 1, "rowSpan": 1 },
							"controlConfig": {
								"visible": "$_getIsThrottlingQueueVisible",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "DailyLimit",
						"values": {
							"layout": { "column": 0, "row": 1, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "DailyLimit",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable",
							"isRequired": "$_getIsManualLimitsVisible",
							"visible": "$_getIsManualLimitsVisible"
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "DelayBetweenEmail",
						"values": {
							"layout": { "column": 13, "row": 1, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "DelayBetweenEmail",
							"visible": "$_getIsManualLimitsVisible",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable"
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "DelayBetweenEmailInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.DelayBetweenEmailInfoButtonCaption"},
							"layout": { "column": 23, "row": 1, "colSpan": 1, "rowSpan": 1 },
							"controlConfig": {
								"visible": "$_getIsManualLimitsVisible",
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "ThrottlingSettingsGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"parentName": "SettingsTabContainer",
						"name": "DeliveryScheduleControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {bindTo: "Resources.Strings.DeliveryScheduleTabGroupCaption"},
							"items": [],
							"tools": [],
							"visible":"$getIsThrottlingQueueFeatureEnabled"
						}
					},
					{
						"operation": "insert",
						"name": "DeliveryScheduleInfoButton",
						"values": {
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "Resources.Strings.DeliveryScheduleInfoButtonCaption"},
							"behaviour": {
								"displayEvent": BPMSoft.TipDisplayEvent.HOVER
							},
							"controlConfig": {
								"classes": {
									"wrapperClass": "info-button-detail",
								}
							}
						},
						"parentName": "DeliveryScheduleControlGroup",
						"propertyName": "tools",
						"index": 1
					},
					{
						"operation": "insert",
						"parentName": "DeliveryScheduleControlGroup",
						"name": "DeliveryScheduleGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"collapseEmptyRow": true
						}
					},
					{
						"operation": "insert",
						"name": "DeliverySchedule",
						"values": {
							"layout": { "column": 0, "row": 0, "colSpan": 11, "rowSpan": 1 },
							"bindTo": "DeliverySchedule",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable",
							"labelConfig": {"isRequired": true}
						},
						"parentName": "DeliveryScheduleGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "BusinessPeriodContainer",
						"parentName": "DeliveryScheduleGridLayout",
						"propertyName": "items",
						"values": {
							"layout": { "column": 13, "row": 0, "colSpan": 11, "rowSpan": 1 },
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"wrapClass": ["period-container"],
							"labelConfig": {
								"isRequired": true,
								"caption": {
									"bindTo": "Resources.Strings.DeliveryTimeRangeLabelCaption"
								}
							},
							"tip" : {
								"content": {"bindTo": "BusinessTimeEndInfoButtonContent"},
							},
							"controlConfig": {
								"visible": "$getIsThrottlingQueueFeatureEnabled",
							},
						}
					},
					// {
					// 	"operation": "insert",
					// 	"name": "BusinessTimeRangeLabelCaption",
					// 	"parentName": "BusinessTimeRangeLabelContainer",
					// 	"propertyName": "items",
					// 	"values": {
					// 		"itemType": this.BPMSoft.ViewItemType.LABEL,
					// 		"labelClass": ["delivery-time-range-label"],
					// 		"labelConfig": {
					// 			"isRequired": true,
					// 			"caption": {
					// 				"bindTo": "Resources.Strings.DeliveryTimeRangeLabelCaption"
					// 			}
					// 		}
					// 	}
					// },
					// {
					// 	"operation": "insert",
					// 	"name": "BusinessTimeStartLabelContainer",
					// 	"parentName": "BusinessPeriodContainer",
					// 	"propertyName": "items",
					// 	"values": {
					// 		"layout": { "column": 15, "row": 0, "colSpan": 1, "rowSpan": 1 },
					// 		"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					// 		"items": [],
					// 		"wrapClass": ["short-label"]
					// 	}
					// },
					{
						"operation": "insert",
						"name": "BusinessTimeStartLabelCaption",
						"parentName": "BusinessPeriodContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"labelClass": ["delivery-time-range-label"],
							// "labelConfig": {
								"caption": {
									"bindTo": "Resources.Strings.BusinessTimeStartLabelCaption"
								}
							// }
						}
					},
					{
						"operation": "insert",
						"name": "BusinessTimeStart",
						"values": {
							// "layout": {
							// 	"column": 16, "row": 0, "colSpan": 3, "rowSpan": 1
							// },
							"labelConfig": {
								"visible": false,
							},
							"bindTo": "BusinessTimeStart",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable"
						},
						"parentName": "BusinessPeriodContainer",
						"propertyName": "items"
					},
					// {
					// 	"operation": "insert",
					// 	"name": "BusinessTimeEndLabelContainer",
					// 	"parentName": "DeliveryScheduleGridLayout",
					// 	"propertyName": "items",
					// 	"values": {
					// 		"layout": { "column": 19, "row": 0, "colSpan": 1, "rowSpan": 1 },
					// 		"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					// 		"items": [],
					// 		"wrapClass": ["short-label"]
					// 	}
					// },
					{
						"operation": "insert",
						"name": "BusinessTimeEndLabelCaption",
						"parentName": "BusinessPeriodContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"labelClass": ["delivery-time-range-label"],
							// "labelConfig": {
								"caption": {
									"bindTo": "Resources.Strings.BusinessTimeEndLabelCaption"
								}
							// }
						}
					},
					{
						"operation": "insert",
						"name": "BusinessTimeEnd",
						"values": {
							// "layout": {
							// 	"column": 20, "row": 0, "colSpan": 3, "rowSpan": 1
							// },
							"labelConfig": {
								"visible": false,
							},
							"bindTo": "BusinessTimeEnd",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable"
						},
						"parentName": "BusinessPeriodContainer",
						"propertyName": "items"
					},
					{
						"operation": "remove",
						"name": "BusinessTimeEndInfoButton",
						"values": {
							"layout": {
								"column": 23, "row": 0, "colSpan": 1, "rowSpan": 1
							},
							"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
							"content": {"bindTo": "BusinessTimeEndInfoButtonContent"},
							"controlConfig": {
								"imageConfig": informationButtonResources.localizableImages.InfoButtonElementIcon
							}
						},
						"parentName": "DeliveryScheduleGridLayout",
						"propertyName": "items",
					},
					{
						"operation": "insert",
						"name": "DeliveryScheduleDaysContainer",
						"parentName": "DeliveryScheduleGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1
							},
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"wrapClass": [],
							"visible": "$_getDeliveryScheduleDaysVisible"
						}
					},
					{
						"operation": "insert",
						"name": "DeliveryScheduleDays",
						"parentName": "DeliveryScheduleDaysContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.MODULE,
							"moduleName": "BaseSchemaModuleV2",
							"instanceConfig": {
								"isSchemaConfigInitialized": true,
								"schemaName": "WeekCronExpressionModule",
								"useHistoryState": false,
								"parameters": {
									"viewModelConfig": {
										"CronExpression": {
											"getValueMethod": "_getStringCronExpression"
										},
										"IsEditable": {
											"attributeValue": "_getEmailLimitsAndScheduleFieldsEditable"
										}
									}
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "TimeZone",
						"values": {
							"layout": {
								"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1
							},
							"bindTo": "TimeZone",
							"enabled": "$_getEmailLimitsAndScheduleFieldsEditable",
							"labelConfig": {"isRequired": true}
						},
						"parentName": "DeliveryScheduleGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"parentName": "SettingsTabContainer",
						"name": "UtmTabContainerGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {bindTo: "Resources.Strings.UtmGroupCaption"},
							items: []
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmTabContainerGroup",
						"name": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UseUtm",
						"values": {
							"bindTo": "UseUtm",
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmCheckBoxEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "Domains",
						"values": {
							"layout": {"column": 0, "row": 1, "colSpan": 24},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.DomainsHint"},
								"displayMode": BPMSoft.controls.TipEnums.displayMode.WIDE
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UtmSource",
						"values": {
							"layout": {"column": 0, "row": 2, "colSpan": 11},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UtmTerm",
						"values": {
							"layout": {"column": 13, "row": 2, "colSpan": 11},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UtmCampaign",
						"values": {
							"layout": {"column": 0, "row": 3, "colSpan": 11},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UtmContent",
						"values": {
							"layout": {"column": 13, "row": 3, "colSpan": 11},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "UtmSettingPageGridLayout",
						"propertyName": "items",
						"name": "UtmMedium",
						"values": {
							"layout": {"column": 0, "row": 4, "colSpan": 11},
							"controlConfig": {
								"enabled": {bindTo: "IsUtmEnabled"}
							}
						}
					},
					{
						"operation": "insert",
						"name": "SplitTest",
						"values": {
							"layout": {"column": 13, "row": 1, "colSpan": 11, "rowSpan": 1},
							"controlConfig": {
								"enabled": false
							},
							dataValueType: BPMSoft.DataValueType.LOOKUP
						},
						"parentName": "CommonSettingsGridLayout",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "TestEmailMaskContainer",
						"propertyName": "items",
						"values": {
							"id": "TestEmailMask",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"visible": {"bindTo": "IsTestEmailVisible"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "TestEmail",
						"values": {
							"id": "TestEmail",
							"itemType": BPMSoft.ViewItemType.MODULE,
							"classes": {
								"wrapClassName": "send-test-email-content-schema-body"
							},
							"visible": {"bindTo": "IsTestEmailVisible"}
						}
					},
					{
						"operation": "insert",
						"name": "AudienceSchema",
						"values": {
							"contentType": BPMSoft.ContentType.ENUM,
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"caption": "$Resources.Strings.AudienceSchemaCaption",
							"markerValue": "$Resources.Strings.AudienceSchemaCaption",
							"controlConfig": {
								"enabled": "$IsAudienceSchemaEnabled"
							},
							"visible": "$showAudienceSchema",
							"labelConfig": {
								"isRequired": false
							}
						},
						"parentName": "Header",
						"propertyName": "items"
					}
				]/**SCHEMA_DIFF*/,
				rules: {
					"Domains": {
						"BindParameterRequiredUtmDomains": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [
								{
									leftExpression: {
										type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										attribute: "UseUtm"
									},
									comparisonType: BPMSoft.core.enums.ComparisonType.EQUAL,
									rightExpression: {
										type: BusinessRuleModule.enums.ValueType.CONSTANT,
										value: true
									}
								}
							]
						}
					},
					"UtmSource": {
						"BindParameterRequiredUtmSource": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [
								{
									leftExpression: {
										type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										attribute: "UseUtm"
									},
									comparisonType: BPMSoft.core.enums.ComparisonType.EQUAL,
									rightExpression: {
										type: BusinessRuleModule.enums.ValueType.CONSTANT,
										value: true
									}
								}
							]
						}
					},
					"UtmMedium": {
						"BindParameterRequiredUtmMedium": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [
								{
									leftExpression: {
										type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										attribute: "UseUtm"
									},
									comparisonType: BPMSoft.core.enums.ComparisonType.EQUAL,
									rightExpression: {
										type: BusinessRuleModule.enums.ValueType.CONSTANT,
										value: true
									}
								}
							]
						}
					},
					"UtmCampaign": {
						"BindParameterRequiredUtmCampaign": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [
								{
									leftExpression: {
										type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										attribute: "UseUtm"
									},
									comparisonType: BPMSoft.core.enums.ComparisonType.EQUAL,
									rightExpression: {
										type: BusinessRuleModule.enums.ValueType.CONSTANT,
										value: true
									}
								}
							]
						}
					}
				}
			};
		});
