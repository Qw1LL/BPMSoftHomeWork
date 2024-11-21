define("BaseSectionGridRowViewModel", ["ext-base", "BaseSectionGridRowViewModelResources", "ProcessHelper",
		"BaseGridRowViewModel"],
	function(Ext, resources) {

		/**
		 * @class BPMSoft.configuration.BaseSectionGridRowViewModel
		 */
		Ext.define("BPMSoft.configuration.BaseSectionGridRowViewModel", {
			extend: "BPMSoft.BaseGridRowViewModel",
			alternateClassName: "BPMSoft.BaseSectionGridRowViewModel",

			//region Properties: Protected

			/**
			 * Process listeners column name.
			 */
			processListenersColumnName: "ProcessListeners",

			//endregion

			//region Methods: Protected

			/**
			 * Gets visibility of process entry point button in grid row.
			 * @return {Boolean}
			 */
			getProcessEntryPointGridRowButtonVisible: function() {
				return (this.get("EntryPointsCount") > 0);
			},

			/**
			 * Gets visibility of print button in grid row.
			 * @return {Boolean}
			 */
			getPrintButtonVisible: function() {
				return this.get("PrintButtonVisible") || false;
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#initResources
			 * @overridden
			 */
			initResources: function(strings) {
				strings = strings || {};
				var localizableStrings = Ext.apply(BPMSoft.deepClone(strings), resources.localizableStrings);
				this.callParent([localizableStrings]);
			},

			/**
			 * Determines if record can be deleted.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			canDeleteRecords: function() {
				return true;
			},

			/**
			 * Run the business process with parameters.
			 * @param {Object} tag Confuguration object.
			 * @param {Object} tag.sysProcessUId UId schema of the business process.
			 * @param {Array} tag.parameters Process parameters.
			 */
			runProcessWithParameters: function(tag) {
				BPMSoft.ProcessModuleUtilities.runProcessWithParameters(tag);
			}

			//endregion
		});

		return BPMSoft.BaseSectionGridRowViewModel;
	});
