define("EditableContainerListMixin", ["ext-base", "BPMSoft", "EditableContainerListItemViewModel",
	"EditableContainerList"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.configuration.EditableContainerListMixin", {
			alternateClassName: "BPMSoft.EditableContainerListMixin",

			/**
			 * Returns container list items. Calls every time when container list need to update it`s items.
			 * @protected
			 * @abstract
			 * @param {String} moduleId Container list module id.
			 * @returns {BPMSoft.Collection} EditableContainerListItemViewModel items collection.
			 */
			getEditableContainerListItems: Ext.emptyFn,

			/**
			 * Sends update container list items when container list items are changed.
			 * @protected
			 * @abstract
			 * @param {Object} config On change config.
			 * @param {String} config.moduleId Container list module id.
			 * @param {BPMSoft.Collection} config.items Container list items.
			 */
			onContainerListItemsChange: Ext.emptyFn,

			/**
			 * Sends update container list items when container list items are changed.
			 * @protected
			 * @abstract
			 * @returns {Object} Module config.
			 * @returns {BPMSoft.Collection} items Container list items.
			 * @returns {Function} customGetViewConfig Custom function for item view config generator.
			 */
			getInitEditableContainerListItems: Ext.emptyFn,

			/**
			 * Register container list messages.
			 * @protected
			 */
			initContainerListMixin: function() {
				this.sandbox.registerMessages({
					/**
					 * @message InitEditableContainerListItems
					 * On module init, gets items collection.
					 * @param {String} Publisher module id.
					 */
					"InitEditableContainerListItems": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message SetEditableContainerListItems
					 * On module init, gets items collection.
					 * @param {BPMSoft.Collection} Collection of container list items.
					 */
					"SetEditableContainerListItems": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message OnSelectedItemsChange
					 * Sends new container list items collection, when it changes.
					 * @param {BPMSoft.Collection} Collection of container list items.
					 */
					"OnSelectedItemsChange": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message OnRightIconClick
					 * On container list item clear icon click.
					 */
					"OnActionClick": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				});
			},

			/**
			 * Subscribes for all container list event at once.
			 * @protected
			 * @param {String} moduleId Container list module id on which subscription will be made.
			 */
			subscribeForContainerListEvents: function(moduleId) {
				this.sandbox.subscribe("InitEditableContainerListItems", this.getInitEditableContainerListItems, this,
					[moduleId]);
				this.sandbox.subscribe("OnSelectedItemsChange", this.onContainerListItemsChange, this, [moduleId]);
			},

			/**
			 * Updates container list items using getEditableContainerListItems override.
			 * @protected
			 * @param {String} moduleId Container list module id on which subscription will be made.
			 */
			updateEditableContainerListItems: function(moduleId) {
				var items =  this.getEditableContainerListItems(moduleId);
				this.sandbox.publish("SetEditableContainerListItems", items, [moduleId]);
			},

			/**
			 * Creates container list item with given parameters.
			 * @param {BPMSoft.DataValueType.GUID} id Item id.
			 * @param {String} caption Item caption.
			 * @param {Boolean} selected Indicated is item selected.
			 * @param {Object} persistentObject Custom user object inside container list item. Store any extra needed
			 * info for item here.
			 * @param {String} moduleId Container list module id owner of the item.
			 * @returns {BPMSoft.EditableContainerListItemViewModel} Container list item.
			 */
			createContainerListItem: function(id, caption, selected, persistentObject, moduleId) {
				var item = Ext.create("BPMSoft.EditableContainerListItemViewModel");
				item.setAttributes(id, caption, selected, persistentObject, moduleId);
				return item;
			}
		});
		return BPMSoft.configuration.EditableContainerListMixin;
	}
);
