/**
 * @extends ContentItemPropertiesPage
  */
define("BaseContentItemStructurePage", ["ContentItemPropertiesPage", "css!BaseContentItemStructurePageCSS",
		"BaseContentStructureItemViewModel", "ContentStructureMixin"],
function() {
	return {
		mixins: {
			structure: "BPMSoft.ContentStructureMixin"
		},
		messages: {
			/**
			 * @message ContentItemAction
			 * Acts on item action.
			 */
			"ContentStructureItemAction": {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.PTP
			}
		},
		attributes: {
			/**
			 * Collection of structure list items' view models.
			 * @type {BPMSoft.BaseViewModelCollection}
			 */
			StructureItems: {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: Ext.create("BPMSoft.BaseViewModelCollection")
			},
			/**
			 * Flag to indicate add new structure item availability.
			 * @type {Boolean}
			 */
			CanAddStructureItem: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			/**
			 * Actual content item styles.
			 * @type {String}
			 */
			Styles: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				onChange: "onStylesChanged"
			}
		},
		properties: {
			/**
			 * Structure item view model names dictionary.
			 * @type {Object.<string, string>}
			 * @abstract
			 */
			itemViewModelNames: BPMSoft.abstractFn,
			/**
			 * Unique sandbox identifier.
			 * @type {String}
			 * @virtual
			 */
			sandboxId: null,
			/**
			 * Maximum number of structure items allowed to add. Null = unlimited.
			 * @type {Number}
			 * @virtual
			 */
			maxAllowedStructureItems: null
		},
		methods: {

			/**
			 * Actualizes structure list items in config.
			 * @protected
			 */
			refreshConfigItems: function() {
				this.$Config.Items = this.$StructureItems.mapArray(function(item) {
					return item.$Config;
				});
				this.sandbox.publish("ContentItemConfigChanged", this.$Config, ["ItemPanel"]);
			},

			/**
			 * Publishes message into the sheet to operate with new structure item.
			 * @protected
			 * @returns {Object} Child item object or any other config.
			 */
			publishItemAction: function(action, data) {
				var result = this.sandbox.publish("ContentStructureItemAction", {
					action: action,
					data: data
				}, [this.sandboxId]);
				return result;
			},

			/**
			 * Prepares config of changes with 3 arrays.
			 * @param {Array} itemsToAdd Array of new structure items that have to be added.
			 * @param {Array} itemsToDelete Array of structure items that have to be deleted.
			 * @param {Array} itemsToUpdate Array of actual structure items that been changed.
			 * @returns {{add: *, update: *, delete: *}}
			 */
			getChangesConfig: function(itemsToAdd, itemsToDelete, itemsToUpdate) {
				return {
					add: itemsToAdd,
					delete: itemsToDelete,
					update: itemsToUpdate
				};
			},

			/**
			 * Returns item values config for view model.
			 * @protected
			 * @param {Object} item Structure item config.
			 * @returns {Object} Structure item view model values config.
			 */
			prepareItemValues: function(item) {
				return this.mixins.structure.prepareItemValues.apply(this, arguments);
			},

			/**
			 * Inits structure list collection.
			 * @protected
			 * @param {Boolean} isReverse Is reverse order applied.
			 */
			initStructureItems: function(isReverse) {
				this.mixins.structure.initStructureItems.apply(this, [isReverse]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.mixins.structure.initEvents.apply(this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.mixins.structure.onDestroy.apply(this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this.$Config = config;
					this.initStructureItems();
					this.$CanAddStructureItem = this.canAddStructureItem();
					config.Styles = config.Styles || {};
					this.$Styles = JSON.stringify(config.Styles, null, "\t");
				}
			},

			/**
			 * Saves content item style.
			 * @protected
			 */
			onStylesChanged: function() {
				var styles = Ext.JSON.decode(this.$Styles, true);
				Ext.apply(this.$Config, { Styles: styles });
			},

			/**
			 * Handler for select structure item action.
			 * @protected
			 * @param {String} itemId Identifier of structure item to select.
			 */
			onStructureItemSelect: function(itemId) {
				this.publishItemAction("select", itemId);
			},

			/**
			 * Defines if structure item can be added.
			 * @protected
			 * @returns {Boolean}
			 */
			canAddStructureItem: function() {
				if (!this.maxAllowedStructureItems) {
					return true;
				}
				return this.$StructureItems.getCount() < this.maxAllowedStructureItems;
			},

			/**
			 * Adds new structure item.
			 * @protected
			 * @param {String} itemType Child structure item type.
			 * @param {Object} options Adding options.
			 * @returns {Object} Returns created structure item view model or undefined when can't create new item.
			 */
			addStructureItem: function(itemType, options) {
				if (!this.canAddStructureItem()) {
					return undefined;
				}
				var newItem = this.getDefaultStructureItemConfig(itemType);
				var newItemViewModel = this.createStructureItemViewModel(newItem);
				if (options && Number.isInteger(options.position)) {
					this.$StructureItems.insert(options.position, newItem.Id, newItemViewModel);
				} else {
					this.$StructureItems.add(newItem.Id, newItemViewModel);
				}
				this.onStructureItemAdded(newItemViewModel);
				return newItemViewModel;
			},

			/**
			 * Publishes message into the sheet.
			 * @protected
			 * @param {Object} item New structure item view model.
			 */
			onStructureItemAdded: function(item) {
				this.refreshConfigItems();
				var changesConfig = this.getChangesConfig([ item.$Config ], null, null);
				this.publishItemAction("structureChanged", changesConfig);
			},

			/**
			 * Removes structure item and publishes a message into the ContentBuilder.
			 * @protected
			 * @param {String} itemId Identifier of structure item to remove.
			 */
			onStructureItemRemove: function(itemId, skipListActualization) {
				if (!skipListActualization) {
					var viewModelToRemove = this.$StructureItems.get(itemId);
					this.$StructureItems.remove(viewModelToRemove);
					this.refreshConfigItems();
				}
				var itemToDelete = {
					Id: itemId
				};
				var changesConfig = this.getChangesConfig(null, [ itemToDelete ], null);
				this.publishItemAction("structureChanged", changesConfig);
			},

			/**
			 * Handler for structure collection items count change action.
			 * @protected
			 */
			onStructureItemCollectionChanged: function() {
				this.$CanAddStructureItem = this.canAddStructureItem();
				var isItemRemovable = this.$StructureItems.getCount() > 1;
				BPMSoft.each(this.$StructureItems, function(structureItem) {
					structureItem.$IsRemovable = isItemRemovable;
				}, this);
				this.refreshStructureItemCaptions();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentBlockStructureContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-block-structure-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "StructureItemsContainer",
				"propertyName": "items",
				"parentName": "ContentBlockStructureContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["section-constructor-container"]
				}
			},
			{
				"operation": "insert",
				"name": "StructureItemsListLabel",
				"parentName": "StructureItemsContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.StructureItemConstructorLabelCaption",
					"classes": {
						"labelClass": ["t-title-label-content-block"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "InlineStructureContainer",
				"parentName": "StructureItemsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["structure-inline-container"]
				}
			},
			{
				"operation": "insert",
				"name": "StructureItemListContainer",
				"parentName": "StructureItemsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"className": "BPMSoft.ContainerList",
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "StructureItems",
					"onGetItemConfig": "getStructureItemViewConfig",
					"itemPrefix": "sectionItem",
					"classes": {
						"wrapClassName": ["structure-list-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ActionsStructureWrapContainer",
				"parentName": "StructureItemsContainer",
				"propertyName": "items",
				"values": {
					"items": [],
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["structure-inline-container"]
				}
			},
			{
				"operation": "insert",
				"name": "ActionsStructureContainer",
				"parentName": "ActionsStructureWrapContainer",
				"propertyName": "items",
				"values": {
					"items": [],
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["structure-actions-grid"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BlockStylesContainer",
				"propertyName": "items",
				"parentName": "ContentBlockStructureContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["block-styles-container"]
				}
			}
		]
	};
});
