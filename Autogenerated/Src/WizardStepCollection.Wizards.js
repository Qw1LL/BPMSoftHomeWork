/**
 * @class BPMSoft.configuration.WizardStepCollection
 * ##### ###### ############# ######### ##### #######.
 */
Ext.define("BPMSoft.configuration.WizardStepCollection", {
	extend: "BPMSoft.BaseViewModelCollection",
	alternateClassName: "BPMSoft.WizardStepCollection",

	/**
	 * ### ###### ############# ####.
	 */
	itemViewModelName: "BPMSoft.WizardStep",

	constructor: function() {
		this.callParent(arguments);
		this.addEvents(
			"itemClick",
			"itemSelect"
		);
	},

	/**
	 * ########### ####### ######### ######## #########.
	 * @param {BPMSoft.WizardStep} item ####### #########.
	 */
	subscribeItemEvent: function(item) {
		this.callParent(arguments);
		item.on("click", this.onItemClick, this);
		item.on("select", this.onItemSelect, this);
	},

	/**
	 * ########## ####### ######### ######## #########.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.WizardStep} item ####### #########.
	 */
	unsubscribeItemEvent: function(item) {
		this.callParent(arguments);
		item.un("click", this.onItemClick, this);
		item.un("select", this.onItemSelect, this);
	},

	/**
	 * ############ ####### ## ###### ####.
	 * @protected
	 * @virtual
	 * @param {String} clickedItemName ### ####.
	 */
	onItemClick: function(clickedItemName) {
		this.fireEvent("itemClick", clickedItemName);
	},

	/**
	 * ############ ######### ####.
	 * @protected
	 * @virtual
	 * @param {String} selectedItemName ### ########### ####.
	 */
	onItemSelect: function(selectedItemName) {
		this.fireEvent("itemSelect", selectedItemName);
	},

	/**
	 * ####### ########## ########### ####.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.WizardStep} item ####### #########.
	 * @return {BPMSoft.WizardStep} ########## ###.
	 */
	selectedFilterFn: function(item) {
		return item.isSelected();
	},

	/**
	 * ########## ###### ######## ####.
	 * @protected
	 * @virtual
	 * @return {Number} ###### ######## ####.
	 */
	getCurrentItemIndex: function() {
		var currentItem = this.getCurrentItem();
		return this.indexOf(currentItem);
	},

	/**
	 * ########## ####### ###.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.WizardStep} ####### ###.
	 */
	getCurrentItem: function() {
		var currentItem = null;
		this.each(function(item, key) {
			var result = this.selectedFilterFn(item, key);
			if (result) {
				currentItem = item;
			}
			return !result;
		}, this);
		return currentItem;
	},

	/**
	 * ########## ########## ### ## ######### ##### # ########.
	 * @protected
	 * @virtual
	 */
	previous: function() {
		var index = this.getCurrentItemIndex();
		var item = this.findPreviousItem(index);
		if (item) {
			item.click();
		}
	},

	/**
	 * Finds previous item.
	 * @param {int} index Index of collection.
	 * @return {BPMSoft.WizardStep|null}
	 */
	findPreviousItem: function(index) {
		var item = null;
		if (index > 0) {
			index--;
			item = this.getByIndex(index);
			if (!item.canUseStep()) {
				item = this.findPreviousItem(index);
			}
		}
		return item;
	},

	/**
	 * Finds next item.
	 * @param {int} index Index of collection.
	 * @return {BPMSoft.WizardStep|null}
	 */
	findNextItem: function(index) {
		var item = null;
		if (index < (this.getCount() -3)) {
			index++;
			item = this.getByIndex(index);
			if (!item.canUseStep()) {
				item = this.findNextItem(index);
			}
		}
		return item;
	},

	/**
	 * ########## ######### ### ## ######### ##### # ########.
	 * @protected
	 * @virtual
	 */
	next: function() {
		var index = this.getCurrentItemIndex();
		var item = this.findNextItem(index);
		if (item) {
			item.click();
		}
	},

	/**
	 * ####### ###### ############# ####.
	 * @protected
	 * @virtual
	 * @param {Object} columnValues ################ ###### ####.
	 */
	createItem: function(columnValues) {
		var config = columnValues.config;
		var stepViewModelClassName = config && config.viewModelClassName || this.itemViewModelName;
		var item = Ext.create(stepViewModelClassName, {
			values: columnValues,
			rowConfig: this.rowConfig
		});
		item.init();
		return item;
	}
});
