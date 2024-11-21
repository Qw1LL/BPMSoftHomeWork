define("BaseWizardModule", ["ext-base", "BPMSoft", "BaseWizardModuleResources", "BaseViewModule",
	"css!BaseWizardModule"
], function(Ext, BPMSoft, resources) {

	/**
	 * Base class of wizard module
	 */
	Ext.define("BPMSoft.configuration.BaseWizardModule", {
		extend: "BPMSoft.configuration.BaseViewModule",
		alternateClassName: "BPMSoft.BaseWizardModule",

		//region Properties: Protected

		/**
		 * Sign of asynchronous module
		 * @protected
		 * @type {Boolean}
		 */
		isAsync: true,

		/**
		 * Current step
		 * @protected
		 * @type {String}
		 */
		currentStep: null,

		/**
		 * Saving status of wizard
		 * @protected
		 * @type {Boolean}
		 */
		isSavingWizard: false,

		/**
		 * Save wizard config.
		 * @protected
		 * @type {Object}
		 */
		saveWizardConfig: null,

		// endregion

		//region Properties: Public

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#diff
		 * @override
		 */
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "wizardContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["wizard-container"],
					"id": "wizardContainer",
					"selectors": {"wrapEl": "#wizardContainer"},
					"markerValue": "Wizard",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "wizardHeaderContainer",
				"parentName": "wizardContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["wizard-header-container", "fixed"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "wizardHeader",
				"parentName": "wizardHeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"moduleName": "WizardHeaderModule",
					"classes": {
						"wrapClassName": ["wizard-header"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "centerPanelContainer",
				"parentName": "wizardContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["center-panel"],
					"id": "centerPanelContainer",
					"selectors": {"wrapEl": "#centerPanelContainer"},
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "centerPanel",
				"parentName": "centerPanelContainer",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/,

		//endregion

		//region Methods: Protected

		/**
		 * Returns object of configuration
		 * @protected
		 * @type {Function}
		 */
		onGetConfig: BPMSoft.abstractFn,

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#initHomePage
		 * @override
		 */
		initHomePage: function(callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * Publishes current step of change
		 * @protected
		 * @type {Function}
		 */
		onCurrentStepChange: BPMSoft.abstractFn,

		/**
		 * Returns object of messages
		 * @override
		 * @return {Object}
		 */
		getMessages: function() {
			const messages = {
				"GetConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"BeforeCurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"ConfirmCurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"CurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"SaveWizard": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"CancelWizard": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"UpdateConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			};
			return Ext.apply(messages, this.callParent(arguments));
		},

		/**
		 * Registers messages
		 * @protected
		 */
		registerMessages: function() {
			this.sandbox.registerMessages(this.getMessages());
		},

		/**
		 * Close window which had been opened by it
		 * @protected
		 */
		closeWindow: function() {
			window.close();
		},

		/**
		 * Returns localizable string from resources.
		 * @protected
		 * @param {String} key Key of resource string.
		 * @return {String}
		 */
		getLocalizableString: function(key) {
			return resources.localizableStrings[key] || "";
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#subscribeMessages
		 * @override
		 */
		subscribeMessages: function() {
			this.callParent(arguments);
			const sandbox = this.sandbox;
			const headerId = this.getWizardHeaderId();
			sandbox.subscribe("GetConfig", this.onGetConfig, this, [headerId]);
			sandbox.subscribe("BeforeCurrentStepChange", this.onBeforeCurrentStepChange, this, [headerId]);
			sandbox.subscribe("CurrentStepChange", this.onCurrentStepChange, this, [headerId]);
			sandbox.subscribe("SaveWizard", this.onSaveWizard, this, [headerId]);
			sandbox.subscribe("CancelWizard", this.onCancelWizard, this, [headerId]);
		},

		/**
		 * Handler before current step change
		 * @protected
		 * @type {Function}
		 */
		onBeforeCurrentStepChange: function() {
			this.sandbox.publish("ConfirmCurrentStepChange", null, [this.getWizardHeaderId()]);
		},

		/**
		 * Handler on save wizard
		 * @protected
		 */
		onSaveWizard: function(saveWizardConfig) {
			if (this.isSavingWizard) {
				return;
			}
			this.saveWizardConfig = saveWizardConfig || {};
			this.isSavingWizard = true;
			this.onCurrentStepChange(this.currentStep);
		},

		/**
		 * Handler on cancel wizard
		 * @protected
		 */
		onCancelWizard: function() {
			const message = resources.localizableStrings.CancelButtonClickCaption;
			BPMSoft.showConfirmation(message, this.onCancellationWindowButtonClick, ["yes", "no"], this);
		},

		/**
		 * Handler click by cancellation button
		 * @protected
		 * @param {String} returnCode Buttons code
		 */
		onCancellationWindowButtonClick: function(returnCode) {
			if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
				this.closeWindow();
			}
		},

		/**
		 * Return wizard header id
		 * @protected
		 * @return {String}
		 */
		getWizardHeaderId: function() {
			return "ViewModule_WizardHeaderModule";
		},

		/**
		 * Shows wizard error
		 * @protected
		 * @param {String} message Text of message
		 */
		showWizardError: function(message) {
			BPMSoft.showInformation(message, this.closeWindow, this);
		},

		/**
		 * Shows WizardHeader shadow while scrolling.
		 * @protected
		 */
		showScrollShadow: function() {
			const wizardHeader = Ext.get("wizardHeader");
			if (!wizardHeader) {
				return;
			}
			const body = Ext.getBody();
			const scrollTop = body.getScrollTop();
			if (scrollTop > 0) {
				wizardHeader.addCls("wizard-header-shadow");
			} else {
				wizardHeader.removeCls("wizard-header-shadow");
			}
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#render
		 * @override
		 */
		render: function(renderTo) {
			renderTo.addCls("section-designer-shown");
			this.callParent(arguments);
			window.onscroll = this.showScrollShadow;
		}

		//endregion

	});

	return BPMSoft.BaseWizardModule;
});
