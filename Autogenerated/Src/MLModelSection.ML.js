define("MLModelSection", ["SupportEmailHelper", "MLModelPageResources", "ControlGridModule", "GridUtilitiesV2",
		"MLModelStateProgressBarUtils", "GoogleTagManagerUtilities", "css!MLModelStateProgressBarUtils",
		"css!MLModelSectionCSS"],
	function(SupportEmailHelper, modelPageResources) {
		return {
			entitySchemaName: "MLModel",
			messages: {
				/**
				 * @message TrainButtonConfigUpdated
				 * Subscribes on information about current Train button's configuration.
				 */
				"TrainButtonConfigUpdated": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Train button's caption.
				 */
				"TrainButtonCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT
				},
				/**
				 * Indicates that train button is enabled.
				 */
				"IsTrainButtonEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN
				}
			},
			properties: {
				shouldShowConsultationProfileKey: "shouldShowConsultation",
				sectionShowedCountProfileKey: "sectionShowedCount"
			},
			methods: {

				/**
				 * Sends Google tag manager data.
				 * Note. This approach is slightly different from the standard one, because:
				 *  - BPMSoft.BasePageV2#sendGoogleTagManagerData is overridden as empty function;
				 *  - This approach does not require synthetic property for custom action tag.
				 * @param {String} modelActionTag Custom action tag.
				 * @private
				 */
				_sendGoogleTagManagerDataML: function(modelActionTag) {
					const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
					if (!isGoogleTagManagerEnabled) {
						return;
					}
					const data = this.getGoogleTagManagerData(modelActionTag);
					BPMSoft.GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData
				 * @param action {String} action tag to send.
				 * @protected
				 * @override
				 */
				getGoogleTagManagerData: function(action) {
					const data = this.callParent();
					this.Ext.apply(data, {
						action: action
					});
					return data;
				},

				/**
				 * Loads value from profile by the given key.
				 * @param {String} key Profile key.
				 * @param {*} defaultValue Value will be returned if not data in profile.
				 */
				loadValueFromProfile: function (key, defaultValue) {
					const profile = this.getProfile() || {};
					const value = profile[key];
					return Ext.isEmpty(value) ? defaultValue : value;
				},

				/**
				 * Loads indicator that consultation dialog should be shown from profile.
				 */
				getIsConsultationDialogShouldBeShown: function () {
					const shouldShowConsultation = this.loadValueFromProfile(this.shouldShowConsultationProfileKey,
						true);
					const sectionShowedCount = this.loadValueFromProfile(this.sectionShowedCountProfileKey, 0) + 1;
					return shouldShowConsultation && sectionShowedCount >= 2;
				},

				/**
				 * Saves value to profile by the given key.
				 * @private
				 * @param {String} key Profile key.
				 * @param {*} value Value to save.
				 */
				saveProfileKeyValue: function (key, value) {
					const profileData = this.getProfile() || {};
					profileData[key] = value;
					BPMSoft.utils.saveUserProfile(this.getProfileKey(), profileData, false, function() {
						this.set("Profile", profileData);
					}, this);
				},

				/**
				 * Saves counter of section visits.
				 * @private
				 */
				saveSectionVisit: function () {
					const sectionShowedCount = this.loadValueFromProfile(this.sectionShowedCountProfileKey, 0);
					this.saveProfileKeyValue(this.sectionShowedCountProfileKey, sectionShowedCount + 1);
				},

				/**
				 * Shows consultation dialog on the first visit to the section.
				 * @private
				 */
				showConsultationDialog: function () {
					if (this.getIsFeatureEnabled("DisableMLConsultationDialog")) {
						return;
					}
					const shouldShowConsultation = this.getIsConsultationDialogShouldBeShown();
					if (!shouldShowConsultation) {
						return;
					}
					const buttons = [
						{
							className: "BPMSoft.Button",
							returnCode: "ask",
							style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
							caption: this.get("Resources.Strings.AskForConsultationButtonCaption")
						},
						{
							className: "BPMSoft.Button",
							returnCode: "remindLater",
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: this.get("Resources.Strings.RemindLaterButtonCaption")
						}
					];
					const url = modelPageResources.localizableStrings.PredictiveAnalysisAcademyUrl;
					const message = Ext.String.format(this.get("Resources.Strings.ConsultationDialogCaption"), url);
					this.showConfirmationDialog(message, function (returnCode) {
						this.saveProfileKeyValue(this.shouldShowConsultationProfileKey, false);
						this._sendGoogleTagManagerDataML("MLConsultationDialog_" + returnCode);
						if (returnCode !== "ask") {
							return;
						}
						SupportEmailHelper.callMailTo({
							sandbox: this.sandbox,
							mailSettingCode: "SupportEmailDef"
						});
					}, buttons, {
						useHtmlContent: true,
						customWrapClass: "ML"
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @override
				 */
				init: function (callback, scope) {
					this.callParent([function () {
						this.showConsultationDialog();
						this.saveSectionVisit();
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				 * @override
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.ExecuteJobActionCaption"
						},
						"Click": {
							bindTo: "executeMLTrainerJob"
						}
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Caption": {
							"bindTo": "Resources.Strings.OpenMLProblemTypeLookup"
						},
						"Click": {
							bindTo: "openMLProblemTypeLookup"
						}
					}));
					return actionMenuItems;
				},

				/**
				 * Executes machine learning training job.
				 */
				executeMLTrainerJob: function() {
					this.callService({
						serviceName: "MLTrainerService",
						methodName: "ExecuteModelTrainerJob"
					}, function() {
						this.showInformationDialog(this.get("Resources.Strings.ExecuteJobActionMessage"));
					});
				},

				/**
				 * Opens MLProblemType lookup.
				 */
				openMLProblemTypeLookup: function() {
					this.showBodyMask();
					this.set("IgnoreFilterUpdate", true);
					this.saveCardScroll();
					this.scrollCardTop();
					var newHash = this.BPMSoft.combinePath("LookupSectionModule", "BaseLookupConfigurationSection");
					this.sandbox.publish("PushHistoryState", {
						hash: newHash,
						silent: true,
						stateObj: {
							caption: this.get("Resources.Strings.MLProblemTypeLookupCaption"),
							entitySchemaName: "MLProblemType"
						}
					});
					this.sandbox.loadModule("LookupSectionModule", {
						renderTo: this.renderTo,
						id: this.sandbox.id + "_BaseLookupConfigurationSection",
						keepAlive: true
					});
				},

				/**
				 * @inheritdoc BaseSectionV2#subscribeSandboxEvents
				 * @protected
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("TrainButtonConfigUpdated",
						function(config) {
							this.$TrainButtonCaption = config.caption;
							this.$IsTrainButtonEnabled = config.enabled;
						}, this, this.getCardModuleSandboxIdentifiers());
					this.callParent(arguments);
				},

				/**
				 * Passes indicator config by reference.
				 * @param {Object} control Configuration object.
				 * @override
				 */
				applyControlConfig: function(control) {
					control.config = {
						className: "BPMSoft.BaseProgressBar",
						value: {
							"bindTo": "State",
							"bindConfig": {"converter": "getStateValue"}
						},
						width: "158px"
					};
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#addColumnLink
				 * @override
				 */
				addColumnLink: function(item) {
					item.getStateValue = function(state) {
						return BPMSoft.MLModelStateProgressBarUtils.getStateProgressBarValue(state);
					};
					return this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"name": "TrainButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.core.enums.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "TrainButtonCaption"},
						"enabled": {"bindTo": "IsTrainButtonEnabled"},
						"click": {"bindTo": "onCardAction"},
						"tag": "queryModelTraining",
						"markerValue": "TrainButton"
					}
				}, {
					"name": "DataGrid",
					"operation": "merge",
					"values": {
						"className": "BPMSoft.ControlGrid",
						"controlColumnName": "State",
						"applyControlConfig": {"bindTo": "applyControlConfig"}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
