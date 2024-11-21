Ext.define("BPMSoft.configuration.mixins.SelectableItemListMixin", {
	alternateClassName: "BPMSoft.SelectableItemListMixin",

	/**
	 * Finds selected item.
	 * @private
	 * @param {string} collectionName Name of binded collection
	 * @return {BPMSoft.BaseViewModel} Selected item.
	 */
	_findSelectedItem: function(collectionName) {
		var collection = this.get(collectionName);
		if (!Ext.isEmpty(collection)) {
			var checkedItems = collection.filter(function(item) {
				return item.get("Value");
			});
			return checkedItems.first();
		}
		return null;
	},

	/**
	 * The handler of the "change" event of the item.
	 * @private
	 * @param {string} collectionName Name of binded collection
	 * @param {BPMSoft.BaseViewModel} changedItem Changed item
	 */
	_onItemChanged: function(collectionName, changedItem) {
		changedItem = changedItem || this._findSelectedItem(collectionName);
		if (changedItem && changedItem.get("Value")) {
			this._resetItems(collectionName, changedItem);
		}
	},

	/**
	 * Resets all items except changed one.
	 * @private
	 * @param {string} collectionName Name of binded collection
	 * @param {BPMSoft.BaseViewModel} changedItem Changed item
	 */
	_resetItems: function(collectionName, changedItem) {
		var collection = this.get(collectionName);
		collection.each(function(item) {
			if (item !== changedItem)  {
				item.set("Value", false);
			}
		});
	},

	/**
	 * Subscribes on events.
	 * @private
	 */
	_subscribeCollectionEvents: function(collectionName, collection) {
		collection.on("itemChanged", this._onItemChanged.bind(this, collectionName), this);
	},

	/**
	 * Updates items collection with selected values
	 * @param {string} collectionName name of binded collection
	 * @param {array} selectedItems array of selected items
	 */
	updateItemsCollection: function(collectionName, selectedItems) {
		var collection = this.get(collectionName);
		collection.each(function(item) {
			item.set("Value", selectedItems.indexOf(item.$Id) > -1);
		});
	},

	/**
	 * Initializes items collection with selected values
	 * @param {string} collectionName name of binded collection
	 * @param {array} items array of items from lookup
	 * @param {array} selectedItems array of selected items
	 * @param {boolean} allowMultiselect Allow to select multiple items sign
	 * @protected
	 * @return {collection} inited collection of items
	 */
	initItemsCollection: function(collectionName, items, selectedItems, allowMultiselect) {
		var viewModelCollection = Ext.create("BPMSoft.BaseViewModelCollection");
		this.BPMSoft.each(items, function(item) {
			var value;
			if (allowMultiselect) {
				value = selectedItems.indexOf(item.value) > -1;
			} else {
				value = selectedItems === item.value;
			}
			var viewModelItem = this.Ext.create("BPMSoft.BaseViewModel", {
				values: {
					Title: item.name,
					Id: item.value,
					Value: value
				}
			});
			viewModelItem.sandbox = this.sandbox;
			viewModelCollection.add(item.value, viewModelItem);
		}, this);
		if (!allowMultiselect) {
			this._subscribeCollectionEvents(collectionName, viewModelCollection);
		}
		this.set(collectionName, viewModelCollection);
	},

	/**
	 * Returns view configuration for items.
	 * @param {Object} itemConfig Item configuration.
	 * @protected
	 */
	getItemViewConfig: function(itemConfig) {
		var radioButtonId = BPMSoft.Component.generateId();
		var config = {
			className: "BPMSoft.Container",
			classes: {
				wrapClassName: ["radio-button-container"]
			},
			items: [
				{
					id: radioButtonId,
					className: "BPMSoft.RadioButton",
					tag: true,
					checked: {bindTo: "Value"}
				},
				{
					inputId: radioButtonId,
					className: "BPMSoft.Label",
					caption: {bindTo: "Title"}
				}
			]
		};
		itemConfig.config =  config;
	},

	/**
	 * Returns view configuration for multiselect items.
	 * @param {Object} itemConfig Item configuration.
	 * @protected
	 */
	getMultiselectItemViewConfig: function(itemConfig) {
		var checkboxId = BPMSoft.Component.generateId();
		var config = {
			className: "BPMSoft.Container",
			classes: {
				wrapClassName: ["responses-grid-row"]
			},
			items: [
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["response-control-wrap"]
					},
					items: [
						{
							id: checkboxId,
							className: "BPMSoft.CheckBoxEdit",
							classes: {wrapClass: ["t-checkbox-control"]},
							checked: {bindTo: "Value"}
						}
					]
				},
				{
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["response-label-wrap"]
					},
					items: [
						{
							inputId: checkboxId,
							className: "BPMSoft.Label",
							caption: {bindTo: "Title"}
						}
					]
				}
			]
		};
		itemConfig.config =  config;
	},

	/**
	 * Returns array of values of selected items
	 * @param {string} collectionName Name of binded collection
	 * @protected
	 * @return {array} array of values of the selected items
	 */
	getSelectedOptions: function(collectionName) {
		var items = [];
		var collection = this.get(collectionName);
		if (!Ext.isEmpty(collection)) {
			items = collection
					.filter(function(item) {
						return item.get("Value");
					})
					.getItems()
					.map(function(item) {
						return item.values.Id;
					});
		}
		return items;
	}
});
