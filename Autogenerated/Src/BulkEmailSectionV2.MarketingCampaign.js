define("BulkEmailSectionV2", ["BulkEmailSectionV2Resources", "MarketingEnums", "BulkEmailHelper",
		"GridUtilitiesV2"],
	function(resources, MarketingEnums, BulkEmailHelper) {
		return {
			entitySchemaName: "BulkEmail",
			attributes: {
				"CanManageBpmCrmCloudIntegrationSettings": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			messages: {
				/**
				 * @message GetBulkEmail
				 * Gets currents email.
				 * @return (Object) Email.
				 */
				"GetBulkEmail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message RunMailing
				 * Initiate the start of the mailing.
				 */
				"RunMailing": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message RunMailing
				 * Initiate the start of the Send Test Email.
				 */
				"SendTestEmail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message RunMailing
				 * Initiate the start of the Edit Template.
				 */
				"EditTemplate": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message BreakMailing
				 * Initiate a mailing stop.
				 */
				"BreakMailing": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * Initiate the opening of the TestBulkEmailModule.
				 */
				sendTestEmail: function() {
					var activeRow = this.getActiveRow();
					var bulkEmailId = activeRow.get("Id");
					var bulkEmailName = activeRow.get("Name");
					BulkEmailHelper.OpenSendTestBulkEmail(bulkEmailId, bulkEmailName, this);
				},

				/**
				 * Runs the mailing.
				 * @protected
				 */
				runMandrillMassMailing: function() {
					this.sandbox.publish("RunMailing", {}, [this.getCardModuleSandboxId()]);
				},

				/**
				 * Handles the EditTemplate button click.
				 * @protected
				 */
				onEditTemplateActionClick: function() {
					this.sandbox.publish("EditTemplate", this, [this.getCardModuleSandboxId()]);
				},

				/**
				 * Handles the SendTestEmail button click.
				 * @protected
				 */
				onSendTestEmailActionClick: function() {
					this.sandbox.publish("SendTestEmail", this);
				},

				/**
				 * Stops the mailing.
				 * @protected
				 */
				breakMandrillMassMailing: function() {
					this.sandbox.publish("BreakMailing", {}, [this.getCardModuleSandboxId()]);
				},

				/**
				 * Returns the activity of the menu item "Send test message".
				 * @return (Boolean) Returns true, if one row selected, otherwise false.
				 */
				isSendTestBulkEmailEnabled: function() {
					return (this.isSingleSelected() && !this.get("MultiSelect"));
				},

				/**
				 * Returns columns that are always selected by the query.
				 * @protected
				 * @overriden
				 * @return {Object} Returns an array of column configuration objects.
				 */
				getGridDataColumns: function() {
					var defColumnsConfig = this.callParent(arguments);
					defColumnsConfig.StartDate = {path: "StartDate"};
					defColumnsConfig.Status = {path: "Status"};
					defColumnsConfig.LaunchOption = {path: "LaunchOption"};
					defColumnsConfig.Category = {path: "Category"};
					defColumnsConfig.SendStartDate = defColumnsConfig.SendStartDate || {path: "SendStartDate"};
					defColumnsConfig.StatisticDate = defColumnsConfig.StatisticDate || {path: "StatisticDate"};
					defColumnsConfig.ResponseProcessingCompleted = {path: "ResponseProcessingCompleted"};
					return defColumnsConfig;
				},

				/**
				 * Cheks whether start sending tooltip is enabled.
				 * @returns {boolean} True if start sending tooltip is enabled, otherwise false.
				 */
				isTooltipEnabled: function() {
					var returnValue = false;
					if (this.isSingleSelected() && !this.get("MultiSelect")) {
						var activeRow = this.getActiveRow();
						var category = activeRow.get("Category");
						var status = activeRow.get("Status");
						if (category && status) {
							returnValue = BulkEmailHelper.GetIsPlannedTriggeredEmail.call(this, category.value, status.value);
						}
					}
					return returnValue;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#deleteRecords
				 * @overriden
				 */
				checkCanDelete: function (items) {
					var isPlanned = true;
					for (var i = 0; i < items.length; i++) {
						var currentRow = this.getGridDataRow(items[i]);
						var status = currentRow.get("Status");
						isPlanned = (status && (status.value === MarketingEnums.BulkEmailStatus.PLANNED ||
							status.value === MarketingEnums.BulkEmailStatus.DRAFT));
						if (!isPlanned) {
							BPMSoft.showInformation(this.get("Resources.Strings.CantDeleteMessageCaption"));
							return false;
						}
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getSectionActions
				 * @overriden
				 */
				getSectionActions: function() {
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						Click: {bindTo: "goToSplitTestsCaption"},
						Caption: {bindTo: "Resources.Strings.GoToSplitTestsCaption"}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator"
					}));
					var parentActionMenuItems = this.callParent(arguments);
					parentActionMenuItems.get("Item7").values.Visible = false;
					parentActionMenuItems.each(function(item) {
						actionMenuItems.addItem(item);
					}, this);
					actionMenuItems.addItem(this.createOpenBpmCrmCloudIntegrationPageMenuItem());
					actionMenuItems.addItem(this.createOpenBulkEmailEventLogMenuItem());
					return actionMenuItems;
				},

				/**
				 * Returns true if feature BulkEmailUXEnabled is enabled.
				 * @private
				 * @returns {Boolean} True if feature BulkEmailUXEnabled is enabled.
				 */
				getIsBulkEmailUXEnabled: function() {
					return this.BPMSoft.Features.getIsEnabled("BulkEmailUX");
				},

				/**
				 * Creates "OpenBpmCrmCloudIntegrationPage" menu item.
				 * @return {BPMSoft.BaseViewModel} Menu item.
				 */
				createOpenBpmCrmCloudIntegrationPageMenuItem: function() {
					var captionStringName = "Resources.Strings.GoToBpmCrmCloudIntegrationCaption";
					if (this.getIsBulkEmailUXEnabled()) {
						captionStringName = "Resources.Strings.GoToBpmCrmCloudIntegrationCaptionV2";
					}
					return this.getButtonMenuItem({
						Click: {bindTo: "openBpmCrmCloudIntegrationPage"},
						Caption: {bindTo: captionStringName},
						Visible: {bindTo: "CanManageBpmCrmCloudIntegrationSettings"}
					});
				},

				/**
				 * Creates "OpenBulkEmailEventLog" menu item.
				 * @return {BPMSoft.BaseViewModel} Menu item.
				 */
				createOpenBulkEmailEventLogMenuItem: function() {
					return this.getButtonMenuItem({
						Click: {bindTo: "openBulkEmailEventLog"},
						Caption: {bindTo: "Resources.Strings.OpenBulkEmailEventLogCaption"},
						Visible: {bindTo: "getIsBulkEmailUXEnabled"}
					});
				},

				/**
				 * Opens mailing log.
				 */
				openBulkEmailEventLog: function() {
					this.sandbox.publish("PushHistoryState", {hash: "SectionModuleV2/BulkEmailEventLogSectionV2"});
				},

				/**
				 * Initializes "initCanManageBpmCrmCloudIntegrationSettings" property.
				 * @private
				 */
				initCanManageBpmCrmCloudIntegrationSettings: function() {
					this.checkCanExecuteOperation("CanManageBpmCrmCloudIntegrationSettings",
						this.setCanManageBpmCrmCloudIntegrationSettings, this);
				},

				/**
				 * Sets value of the "CanManageBpmCrmCloudIntegrationSettings" property.
				 * @private
				 * @param {Boolean} value.
				 */
				setCanManageBpmCrmCloudIntegrationSettings: function(value) {
					this.set("CanManageBpmCrmCloudIntegrationSettings", value);
				},

				/**
				 * Opens Bpmcrm Cloud Integration settings page.
				 */
				openBpmCrmCloudIntegrationPage: function() {
					this.sandbox.publish("PushHistoryState", {hash: "CardModuleV2/BpCloudIntegrationPageV2"});
				},

				/**
				 * Opens the split-test section.
				 * @protected
				 */
				goToSplitTestsCaption: function() {
					this.sandbox.publish("PushHistoryState", {
						hash: Ext.String.format("{0}/{1}",
							"SectionModuleV2", "BulkEmailSplitSectionV2")
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initCanManageBpmCrmCloudIntegrationSettings();
				},

				/**
				 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getIsDeduplicationEnable
				 * @override
				 */
				getIsDeduplicationEnable: function() {
					return false;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "EditTemplate",
					"values": {
						itemType: BPMSoft.ViewItemType.BUTTON,
						caption: {bindTo: "EditTemplateActionCaption"},
						classes: {textClass: "actions-button-margin-right"},
						click: {bindTo: "onEditTemplateActionClick"},
						enabled: {bindTo: "IsTemplateEditable"},
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						visible: {bindTo: "IsMarketingContentBuilderWizardEnabled"}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "SendTestEmail",
					"values": {
						itemType: BPMSoft.ViewItemType.BUTTON,
						caption: {bindTo: "SendTestEmailActionCaption"},
						classes: {textClass: "actions-button-margin-right"},
						click: {bindTo: "onSendTestEmailActionClick"},
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						visible: {bindTo: "IsSendTestEmailVisible"}
					}
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "SendButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {bindTo: "SendMailingActionCaption"},
						"classes": {textClass: "actions-button-margin-right"},
						"click": {bindTo: "runMandrillMassMailing"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"visible": {bindTo: "IsRunDisplayed"},
						"tips": []
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
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "BreakButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.BreakButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "breakMandrillMassMailing"},
						"style": BPMSoft.controls.ButtonEnums.style.RED,
						"visible": {"bindTo": "IsBreakEnabled"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
