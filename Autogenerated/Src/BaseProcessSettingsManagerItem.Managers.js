define("BaseProcessSettingsManagerItem", [], function() {
	Ext.define("BPMSoft.BaseProcessSettingsManagerItem", {
		extend: "BPMSoft.ObjectManagerItem",
		alternateClassName: "BPMSoft.BaseProcessSettingsManagerItem",

		/**
		 * Position.
		 * @private
		 * @type {Number}
		 */
		position: null,

		/**
		 * Workplace.
		 * @private
		 * @type {Object}
		 */
		processUId: null,

		/**
		 * Process parameter.
		 * @private
		 * @type {Object}
		 */
		parameterUId: null,

		/**
		 * Process caption.
		 * @private
		 * @type {String}
		 */
		processCaption: null,

		/**
		 * Returns process runner id.
		 * @abstract
		 */
		getProcessRunnerId: BPMSoft.abstractFn,

		/**
		 * Sets process runner id.
		 * @abstract
		 */
		setProcessRunnerId: BPMSoft.abstractFn,

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManagerItem#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			var viewModel = this.dataManagerItem.viewModel;
			viewModel.validationConfig = null;
		},

		/**
		 * Returns process caption.
		 * @returns {String} Process caption.
		 */
		getProcessCaption: function() {
			return this.getPropertyValue("processCaption");
		},

		/**
		 * Sets process caption.
		 * @param value {String} Process caption.
		 */
		setProcessCaption: function(value) {
			this.setPropertyValue("processCaption", value);
		},

		/**
		 * Returns position.
		 * @return {Number} Position.
		 */
		getPosition: function() {
			return this.getPropertyValue("position");
		},

		/**
		 * Sets position.
		 * @param {Number} value New position.
		 */
		setPosition: function(value) {
			this.setPropertyValue("position", value);
		},

		/**
		 * Returns process uId.
		 * @return {String} Process uId.
		 */
		getProcessUId: function() {
			return this.getPropertyValue("processUId");
		},

		/**
		 * Sets process uId.
		 * @param {String} value Process uId.
		 */
		setProcessUId: function(value) {
			this.setPropertyValue("processUId", value);
		},

		/**
		 * Returns process parameter uId.
		 * @return {String} Process parameter uId.
		 */
		getParameterUId: function() {
			return this.getPropertyValue("parameterUId");
		},

		/**
		 * Sets process parameter uId
		 * @param {String} value Process parameter uId.
		 */
		setParameterUId: function(value) {
			this.setPropertyValue("parameterUId", value);
		}
	});
	return BPMSoft.BaseProcessSettingsManagerItem;
});
