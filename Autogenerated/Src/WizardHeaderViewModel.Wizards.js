define("WizardHeaderViewModel", ["BPMSoft", "WizardHeaderViewModelResources"], function(BPMSoft, resources) {
	/**
	 * The view model class of the module top panel of the wizard.
	 */
	Ext.define("BPMSoft.configuration.WizardHeaderViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.WizardHeaderViewModel",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * @protected
		 */
		getMessages: function() {
			return {
				/**
				 * Subscribe to messages for updating the top bar.
				 */
				"UpdateConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * Subscribe to messages for confirming current step change.
				 */
				"ConfirmCurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * The publication of the message before current step change.
				 */
				"BeforeCurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message to send the current step.
				 */
				"CurrentStepChange": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message clicks on the current step.
				 */
				"CurrentStepClick": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message clicks on the header of the designer.
				 */
				"HeaderCaptionClick": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message for obtaining configuration information of the top panel.
				 */
				"GetConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message of preservation masters.
				 */
				"SaveWizard": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * The publication of the message cancel the wizard.
				 */
				"CancelWizard": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				
				"NextStepButtonEnabled": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			};
		},

		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * @private
		 */
		_onCurrentStepChangeConfirmed: function(clickedStep) {
			this.set("currentStep", clickedStep);
			this.sandbox.publish("CurrentStepChange", clickedStep, [this.sandbox.id]);
		},

		/**
		 * ############## ###### ########## ######## ## ####### ########.
		 * @protected
		 * @virtual
		 * @param {Object} resourcesObj ###### ########.
		 */
		initResourcesValues: function(resourcesObj) {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * ######### ############ ######### ######, ########### ########## # #####
		 * @protected
		 * @virtual
		 */
		registerMessages: function() {
			this.sandbox.registerMessages(this.getMessages());
		},

		/**
		 * ############## ######### ######## ######.
		 * @protected
		 * @virtual
		 * @param {Function} callback #######, ####### ##### ####### ## ##########.
		 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
		 */
		init: function(callback, scope) {
			this.registerMessages();
			this.subscribeMessages();
			this.initStepCollection();
			this.on("change:currentStep", this.selectStep, this);
			var sandbox = this.sandbox;
			var config = sandbox.publish("GetConfig", null, [this.sandbox.id]);
			if (config) {
				this.onUpdateHeader(config);
			}
			callback.call(scope);
		},

		/**
		 * ############# ## #########.
		 * @protected
		 * @virtual
		 */
		subscribeMessages: function() {
			var sandbox = this.sandbox;
			sandbox.subscribe("UpdateConfig", function(headerConfig) {
				if (headerConfig) {
					this.onUpdateHeader(headerConfig);
				}
			}, this, [sandbox.id]);
			sandbox.subscribe("NextStepButtonEnabled",  this.onArrowRightEnabled, this);
		},

		onArrowRightEnabled: function(enabledResult){
			this.set("arrowRightEnabled", enabledResult);
		},

		/**
		 * ############ ######### ################ ########## ## #######.
		 * @protected
		 * @virtual
		 * @param {Object} config ################ ###### #######.
		 */
		onUpdateHeader: function(config) {
			if (!config) {
				return;
			}
			config = BPMSoft.deepClone(config);
			if (config.steps && this.isNeedLoadSteps(config.steps)) {
				this.loadSteps(config.steps);
			}
			delete config.steps;
			this.updateHeader(config);
			this.selectStep();
		},

		/**
		 * ######### ####.
		 * @protected
		 * @virtual
		 * @param {Object} config ################ ###### #######.
		 */
		updateHeader: function(config) {
			BPMSoft.each(config, function(value, name) {
				this.set(name, value);
			}, this);
		},

		/**
		 * ######### #### # #########.
		 * @protected
		 * @virtual
		 * @param {Array} steps ###### #####.
		 */
		loadSteps: function(steps) {
			var stepCollection = this.get("StepCollection");
			stepCollection.clear();
			var tempCollection = this.getStepCollection(steps);
			stepCollection.loadAll(tempCollection);
		},

		/**
		 * Checks the need load new steps.
		 * @protected
		 * @param {Array} newSteps Array with new steps for load.
		 * @return {Boolean} True, if need load new steps, otherwise false.
		 */
		isNeedLoadSteps: function(newSteps) {
			var stepCollection = this.get("StepCollection");
			var newStepKeys = [];
			newSteps.forEach(function(step) {
				newStepKeys.push(step.name);
			},this);
			var oldStepKeys = stepCollection.getKeys();
			return !BPMSoft.areArraysEqual(newStepKeys,oldStepKeys);
		},

		/**
		 * ####### ### ### ####### #########.
		 * @protected
		 * @virtual
		 * @param {Object} config ################ ###### ####.
		 */
		createCollectionItem: function(config) {
			var stepCollection = this.get("StepCollection");
			return stepCollection.createItem(config);
		},

		/**
		 * ########## ######### #####.
		 * @protected
		 * @virtual
		 * @param {Object[]} steps ###### #####.
		 * @param {String} groupName ### ######.
		 */
		getStepCollection: function(steps, groupName) {
			var tempCollection = Ext.isEmpty(groupName)
				? this.Ext.create("BPMSoft.Collection")
				: this.Ext.create("BPMSoft.WizardStepCollection");
			var filteredArray = Ext.Array.filter(steps, function(item) {
				return (item.groupName === groupName) ||
					(Ext.isEmpty(item.groupName) && Ext.isEmpty(groupName));
			}, this);
			filteredArray.forEach(function(item) {
				var itemKey = item.name;
				item = Ext.apply({}, item, {
					"Id": itemKey,
					"Caption": item.caption,
					"ImageConfig": item.imageConfig,
					"Tag": itemKey,
					"Click": {bindTo: "click"}
				});
				var subItems = this.getStepCollection(steps, itemKey);
				Ext.apply(item, {
					StepCollection: subItems
				});
				var collectionItem = this.createCollectionItem(item);
				collectionItem.sandbox = this.sandbox;
				tempCollection.add(itemKey, collectionItem);
			}, this);
			return tempCollection;
		},

		/**
		 * ############# ######### #####.
		 * @protected
		 * @virtual
		 */
		initStepCollection: function() {
			var stepCollection = this.Ext.create("BPMSoft.WizardStepCollection");
			stepCollection.on("itemClick", this.itemClick, this);
			stepCollection.on("itemSelect", this.onItemSelect, this);
			this.set("StepCollection", stepCollection);
		},

		/**
		 * ############# ######### ###.
		 * @protected
		 * @virtual
		 */
		selectStep: function() {
			var stepCollection = this.get("StepCollection");
			var selectedItemName = this.get("currentStep");
			var selectedItem = null;
			if (selectedItemName) {
				if (stepCollection.contains(selectedItemName)) {
					selectedItem = stepCollection.get(selectedItemName);
				} else {
					stepCollection.each(function(item) {
						var stepCollection = item.get("StepCollection");
						if (stepCollection &&
							!stepCollection.isEmpty() &&
							stepCollection.contains(selectedItemName)) {
							selectedItem = item;
							return false;
						}
					}, this);
				}
			} else {
				selectedItem = stepCollection.getByIndex(0);
			}
			if (selectedItem) {
				selectedItem.select();
			}
		},

		/**
		 * ############ ####### ## ###### ##########.
		 * @protected
		 * @virtual
		 */
		previous: function() {
			var stepCollection = this.get("StepCollection");
			stepCollection.previous();
		},

		/**
		 * ############ ####### ## ###### #########.
		 * @protected
		 * @virtual
		 */
		next: function() {
			var stepCollection = this.get("StepCollection");
			stepCollection.next();
		},

		/**
		 * ############ ####### ## ###### ####.
		 * @protected
		 * @virtual
		 * @param {String} clickedStep ### ######## ####.
		 */
		itemClick: function(clickedStep) {
			const currentStep = this.get("currentStep");
			if (currentStep === clickedStep) {
				this.sandbox.publish("CurrentStepClick");
			} else {
				this.sandbox.subscribe("ConfirmCurrentStepChange", () => {
					this._onCurrentStepChangeConfirmed(clickedStep);
				}, this, [this.sandbox.id]);
				this.sandbox.publish("BeforeCurrentStepChange", clickedStep, [this.sandbox.id]);
			}
		},

		/**
		 * ############ ####### ######### ####.
		 * @protected
		 * @virtual
		 * @param {String} selectedItemName ### ########## ####.
		 */
		onItemSelect: function(selectedItemName) {
			var stepCollection = this.get("StepCollection");
			stepCollection.each(function(step) {
				if (step.get("name") !== selectedItemName) {
					step.unSelect();
				}
			}, this);
			this.setArrowsState();
		},

		/**
		 * ############# ######### ###### ########## # #########.
		 * @protected
		 * @virtual
		 */
		setArrowsState: function() {
			var stepCollection = this.get("StepCollection");
			var index = stepCollection.getCurrentItemIndex();
			var previousItem = stepCollection.findPreviousItem(index);
			this.set("arrowLeftEnabled", Boolean(previousItem));
			var nextItem = stepCollection.findNextItem(index);
			this.set("arrowRightEnabled", Boolean(nextItem));
			this.set("arrowRightVisible", Boolean(nextItem));
		},

		/**
		 * ############ ####### ## ###### #########. ######### #########.
		 * @protected
		 * @virtual
		 */
		saveButtonClick: function() {
			this.sandbox.publish("SaveWizard", null, [this.sandbox.id]);
		},

		/**
		 * ############ ####### ## ###### ########. ######### #########.
		 * @protected
		 * @virtual
		 */
		cancelButtonClick: function() {
			this.sandbox.publish("CancelWizard", null, [this.sandbox.id]);
		},

		/**
		 * ########## ####### ###.
		 * @protected
		 * @virtual
		 * @return {Object} ################ ###### ####.
		 */
		getCurrentStep: function() {
			var stepCollection = this.get("StepCollection");
			var currentItemId = this.get("currentStep");
			var currentItem = null;
			if (currentItemId) {
				if (stepCollection.contains(currentItemId)) {
					currentItem = stepCollection.get(currentItemId);
				} else {
					stepCollection.each(function(item) {
						var stepCollection = item.get("StepCollection");
						if (stepCollection && !stepCollection.isEmpty() &&
							stepCollection.contains(currentItemId)) {
							currentItem = item;
							return false;
						}
					}, this);
				}
			}
			return currentItem;
		},

		/**
		 * ######### ########### ######## ##### ############ #############.
		 * @protected
		 * @virtual
		 */
		onRender: BPMSoft.emptyFn,

		/**
		 * Handles header caption click.
		 * @protected
		 */
		onHeaderCaptionClick: function() {
			this.sandbox.publish("HeaderCaptionClick");
		},

		/**
		 * ########## ######.
		 * @private
		 */
		destroy: function() {
			const messages = this.getMessages();
			if (messages) {
				const messagesKey = BPMSoft.keys(this.messages);
				this.sandbox.unRegisterMessages(messagesKey);
			}
			this.callParent(arguments);
		},

		/**
		 * Return flag that indicates whether CancelButton is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		isCancelButtonVisible: function() {
			return false;
		},

		/**
		 * Return flag that indicates whether SaveButton is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		isSaveButtonVisible: function() {
			return false;
		},

		/**
		 * Return flag that indicates whether UtilsFooter is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		 isUtilsFooterVisible: function() {
			return true;
		},

		/**
		 * Return flag that indicates whether CancelButtonFooter is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		 isCancelButtonFooterVisible: function() {
			return true;
		},

		/**
		 * Return flag that indicates whether SaveButtonFooter is visible or not.
		 * @protected
		 * @return {Boolean}
		 */
		 isSaveButtonFooterVisible: function() {
			return true;
		}
	});

	return BPMSoft.WizardHeaderViewModel;
});
