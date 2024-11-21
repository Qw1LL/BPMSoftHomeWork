define("BulkEmailSplitSectionV2", ["BulkEmailSplitSectionV2Resources", "GridUtilitiesV2", "WizardStepsControl",
		"css!WizardStepsControl"],
	function(resources) {
		return {
			entitySchemaName: "BulkEmailSplit",
			contextHelpId: "1001",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "SeparateModeActionsButton"
				},
				{
					"operation": "remove",
					"name": "CombinedModeActionsButton"
				},
				{
					"operation": "remove",
					"name": "CombinedModeViewOptionsButton"
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
				{
					"operation": "insert",
					"name": "RunSplitTestButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "RunTestButtontCaption"},
						"click": {"bindTo": "onRunTestClick"}
					}
				},
				{
					"operation": "remove",
					"name": "WizardSteps",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"className": "BPMSoft.WizardStepsControl",
						"wizardSteps": [
							{
								caption: resources.localizableStrings.TestParametersCaption
							},
							{
								caption: resources.localizableStrings.AudienceTestCaption
							},
							{
								caption: resources.localizableStrings.RunTestCaption
							},
							{
								caption: resources.localizableStrings.TestResultsCaption
							}
						],
						"currentStep": {"bindTo": "CurrentWizardStep"},
						"passedStep": {"bindTo": "PassedWizardStep"},
						"afterStepChange": {"bindTo": "afterStepChange"}
					},
					"parentName": "CombinedModeActionButtonsCardRightContainer",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/,
			messages: {
				/**
				 * @message SetPassedStepInHeader
				 * ############# ########## ### # #######.
				 */
				"SetPassedStepInHeader": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetCurrentStepInHeader
				 * ############# ####### ### # #######.
				 */
				"SetCurrentStepInHeader": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetRunTestButtontVisible
				 * ############# ######### ###### ####### #####.
				 */
				"SetRunTestButtontVisible": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetRunTestButtontCaption
				 * ############# ####### ###### ########## ###### {###### #####|########## ####}.
				 */
				"SetRunTestButtontCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message CurrentStepInHeaderChanged
				 * ########## ## ######### ######## #### # #######.
				 */
				"CurrentStepInHeaderChanged": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ReloadCard
				 * ########## # ####### ## ###### ######### ####.
				 */
				"OnRunTestClick": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ReloadRecordInSection
				 * ########## # ####### ## ###### ######### ####.
				 */
				"ReloadRecordInSection": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}

			},
			methods: {

				/**
				 * ######## ##### #### "####### ###### #######".
				 * @inheritdoc BaseSectionV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BasePageV2#openCard
				 * @overriden
				 */
				openCard: function() {
					this.set("CurrentWizardStep", -1);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#getDefaultDataViews
				 * @overriden
				 */
				getDefaultDataViews: function() {
					var gridDataView = {
						name: this.get("GridDataViewName"),
						caption: this.getDefaultGridDataViewCaption(),
						icon: this.getDefaultGridDataViewIcon()
					};
					return {
						"GridDataView": gridDataView
					};
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("SetCurrentStepInHeader", function(clientStepIndex) {
						this.set("CurrentWizardStep", clientStepIndex);
					}, this, [this.getCardModuleSandboxId()]);
					this.sandbox.subscribe("SetPassedStepInHeader", function(value) {
						this.set("PassedWizardStep", value);
					}, this, [this.getCardModuleSandboxId()]);
					this.sandbox.subscribe("SetRunTestButtontCaption", function(value) {
						this.set("RunTestButtontCaption", value);
					}, this, [this.getCardModuleSandboxId()]);
					this.sandbox.subscribe("ReloadRecordInSection", this.reloadRecordInSection,
						this, [this.getCardModuleSandboxId()]);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#changeSelectedSideBarMenu
				 * @overriden
				 */
				changeSelectedSideBarMenu: function() {
					var moduleName = "BulkEmail";
					var moduleConfig = BPMSoft.configuration.ModuleStructure[moduleName];
					if (moduleConfig) {
						var sectionSchema = moduleConfig.sectionSchema;
						var config = moduleConfig.sectionModule + "/";
						if (sectionSchema) {
							config += moduleConfig.sectionSchema + "/";
						}
						this.sandbox.publish("SelectedSideBarItemChanged", config, ["sectionMenuModule"]);
					}
				},

				/**
				 * ######## ######### # ######## #### ######### ######## #### # #######.
				 * @protected
				 * @param {Number} clientStepIndex ##### ######## #### # #######.
				 */
				afterStepChange: function(clientStepIndex) {
					if (clientStepIndex) {
						this.sandbox.publish("CurrentStepInHeaderChanged", clientStepIndex,
							[this.getCardModuleSandboxId()]);
					}
				},

				/**
				 * ######## ######### # ######## ##### ####### ## ###### ######### ####.
				 * @protected
				 */
				onRunTestClick: function() {
					this.sandbox.publish("OnRunTestClick", null,
						[this.getCardModuleSandboxId()]);
				},

				/**
				 * ######### ########## ###### # ####### #######.
				 * @param {string} bulkEmailSplitId ########## ############# ######## #####-#####.
				 * @private                       `
				 */
				reloadRecordInSection: function(bulkEmailSplitId) {
					var gridData = this.get("GridData");
					if (gridData) {
						var record = gridData.get(bulkEmailSplitId);
						if (record) {
							record.loadEntity(bulkEmailSplitId);
						}
					}
				}

			},
			attributes: {
				/**
				 * ####### ### # #######.
				 */
				"CurrentWizardStep": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},

				/**
				 * ########## ### #  #######.
				 */
				"PassedWizardStep": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				},

				/**
				 * ####### ###### ########## ###### {###### #####|########## ####}.
				 */
				"RunTestButtontCaption": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.TEXT
				}
			}
		};
	});
