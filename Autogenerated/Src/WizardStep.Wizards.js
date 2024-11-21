define("WizardStep", ["BPMSoft", "WizardUtilities"], function(BPMSoft) {
	/**
	 * @class BPMSoft.configuration.WizardStep
	 * ##### ###### ############# ####.
	 */
	Ext.define("BPMSoft.configuration.WizardStep", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.WizardStep",

		mixins: {
			WizardUtilities: "BPMSoft.WizardUtilities"
		},

		/**
		 * ### ######## ########### ####.
		 * @type {String}
		 */
		selectedPropertyName: "Selected",

		/**
		 * Name of the attribute that determines whether can use a step.
		 * @type {String}
		 */
		canUseStepPropertyName: "CanUseStep",

		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"click",
				"select"
			);
			this.set(this.selectedPropertyName, false);
		},

		/**
		 * Initializes section wizard step.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		init: function(callback, scope) {
			this.initCanUseStep(callback, scope);
		},

		/**
		 * Init user permissions.
		 * @protected
		 * @param {Function} callback Callback method.
		 * @param {Object} scope Callback method context.
		 */
		initCanUseStep: function(callback, scope) {
			this.canUseWizard(function(allow) {
				this.set(this.canUseStepPropertyName, allow);
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * ############ ####### ## ###.
		 */
		click: function(tag) {
			var stepCollection = this.get("StepCollection");
			var stepName;
			if (tag && !stepCollection.isEmpty()) {
				var item = stepCollection.get(tag);
				stepName = item.get("name");
				this.fireEvent("click", stepName);
			} else if (!stepCollection || stepCollection.isEmpty()) {
				stepName = this.get("name");
				this.fireEvent("click", stepName);
			} else {
				return false;
			}
		},

		/**
		 * ############ ######### ####.
		 */
		select: function() {
			if (!this.get(this.selectedPropertyName)) {
				this.set(this.selectedPropertyName, true);
				var stepName = this.get("name");
				this.fireEvent("select", stepName);
			}
		},

		/**
		 * ############ ###### ######### ####.
		 */
		unSelect: function() {
			this.set(this.selectedPropertyName, false);
		},

		/**
		 * ########## ####### ####### ## ####.
		 * @return ########## ####### ####### ## ####.
		 */
		isSelected: function() {
			return this.get(this.selectedPropertyName);
		},

		/**
		 * Returns flag that indicates whether can use step.
		 * @return {Boolean}
		 */
		canUseStep: function() {
			return this.get(this.canUseStepPropertyName);
		}

	});

	return BPMSoft.DcmWizardStep;
});

