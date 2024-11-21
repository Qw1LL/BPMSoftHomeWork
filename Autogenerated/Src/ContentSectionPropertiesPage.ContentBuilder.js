/**
 * @extends BaseContentItemStructurePage
 */
define("ContentSectionPropertiesPage", ["BaseContentItemStructurePage",
		"ContentSectionStructureItemViewModel", "ContentMjGroupStructureItemViewModel"], function() {
	return {
		properties: {
			/**
			 * @inheritdoc BaseContentItemStructurePage#itemViewModelNames
			 * @override
			 */
			itemViewModelNames: {
				column: "BPMSoft.ContentSectionStructureItemViewModel",
				mjgroup: "BPMSoft.ContentMjGroupStructureItemViewModel"
			},
			/**
			 * @inheritdoc BaseContentItemStructurePage#sandboxId
			 * @override
			 */
			sandboxId: "ContentSectionPropertiesPage",
			/**
			 * @inheritdoc BaseContentItemStructurePage#maxAllowedStructureItems
			 * @override
			 */
			maxAllowedStructureItems: 6
		},
		attributes: {
			/**
			 * Flag to indicate add all columns have equal width.
			 * @type {Boolean}
			 */
			IsEqualized: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false,
				onChange: "onEqualizedChange"
			},

			/**
			 * Flag to indicate add all columns are recalculating now.
			 * @type {Boolean}
			 */
			IsInUpdateMode: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Allow use reverse columns direction.
			 */
			ReverseColumnsDirection: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onReverseColumnsDirection"
			}
		},
		methods: {
			/**
			 * @private
			 */
			_onReverseColumnsDirection: function(model, value) {
				var styles = {};
				styles.direction = value ? "rtl" : "ltr";
				if (this._isLoaded) {
					BPMSoft.defer(function() {
						this.publishItemAction("reverseItemsOrder", styles);
					}, this);
				}
			},

			/**
			 * @private
			 */
			_initReverseColumnsDirection: function(styles) {
				if (styles && styles.hasOwnProperty("direction")) {
					this.$ReverseColumnsDirection = styles.direction === "rtl";
				}
			},

			/**
			 * Rounds number to the lower with 3 decimal digits.
			 * @private
			 * @param {Number} value
			 * @returns {Number}
			 */
			_roundNumber: function(value) {
				return Math.floor(value * 10000) / 10000;
			},

			/**
			 * Finds recursively and returns list of all columns in section.
			 * @private
			 * @param {BPMSoft.BaseViewModelCollection} items Structure items of section.
			 * @returns {BPMSoft.Collection} Collection of all columns in section.
			 */
			_getAllColumns: function(items) {
				var columns = new BPMSoft.Collection();
				BPMSoft.each(items, function(item) {
					if (item.$Config.ItemType === "column") {
						columns.add(item.$Id, item);
						return;
					}
					columns.loadAll(this._getAllColumns(item.$StructureItems));
				}, this);
				return columns;
			},

			/**
			 * Returns count of all columns in section.
			 * @private
			 * @param {BPMSoft.BaseViewModelCollection} items Structure items of section.
			 * @returns {Number} Count of columns.
			 */
			_getColumnsCount: function(items) {
				var columns = this._getAllColumns(items);
				return columns.getCount();
			},

			/**
			 * Sets equal column width recursively.
			 * @private
			 * @param {BPMSoft.BaseViewModelCollection} items Structure items of section.
			 * @param {Number} width Width to set.
			 * @param {Boolean} canChangeWidth Flag to indicate property change state.
			 */
			_setEqualColumnWidth: function(items, width, canChangeWidth) {
				BPMSoft.each(items, function(item) {
					if (item.$Config.ItemType === "mjgroup") {
						this._setEqualColumnWidth(item.$StructureItems, width, canChangeWidth);
					} else {
						item.set("Width", width);
						item.set("CanChangeWidth", canChangeWidth);
					}
				}, this);
			},

			/**
			 * Equalizes width of all columns.
			 * @private
			 */
			_equalizeColumnsWidth: function() {
				var count = this._getColumnsCount(this.$StructureItems);
				var width = count > 1 ? this._roundNumber(100 / count) : 100;
				this._setEqualColumnWidth(this.$StructureItems, width, this._getCanChangeWidth());
			},

			/**
			 * Defines if width can be changed manually.
			 * @private
			 * @returns {Boolean}
			 */
			_getCanChangeWidth: function () {
				var columns = this._getAllColumns(this.$StructureItems);
				return !this.$IsEqualized && columns.getCount() > 1;
			},

			/**
			 * Adjusts items width to fill 100%.
			 * @private
			 * @param {Array} itemsToResize Sorted columns to resize.
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem Modified or added column.
			 * @param {Number} fixedWidth Width that should not to be resized.
			 * @param {Number} difference Width to expand or reduce columns for.
			 */
			_adjustColumnsWidth: function(itemsToResize, changedItem, fixedWidth, difference) {
				var newItemWidth = changedItem ? changedItem.get("Width") : 0;
				var totalWidthToResize = 100 - (newItemWidth - difference) - fixedWidth;
				BPMSoft.each(itemsToResize, function(item) {
					var width = Number(item.get("Width"));
					var delta = (difference / totalWidthToResize) * width;
					item.set("Width", this._roundNumber(width - delta));
				}, this);
			},

			/**
			 * Finds nearest item to the target item.
			 * @private
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} targetItem Item to start search from.
			 * @returns {BPMSoft.ContentSectionStructureItemViewModel}
			 */
			_findNearestItem: function(targetItem) {
				var columns = this._getAllColumns(this.$StructureItems);
				var itemsCount = columns.getCount();
				var nearestItem = columns.findByIndex(itemsCount - 2);
				for (var i = itemsCount - 1; i >= 0; i--) {
					var item = columns.getByIndex(i);
					if (item.get("Id") === targetItem.get("Id")) {
						break;
					}
					nearestItem = item;
				}
				return nearestItem;
			},

			/**
			 * Calculates total available width for the changed and the nearest items.
			 * @private
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} nearestItem
			 * @returns {number} Total available width.
			 */
			_getTotalAvailableWidth: function (changedItem, nearestItem) {
				var totalWidth = 100;
				var allColumns = this._getAllColumns(this.$StructureItems);
				BPMSoft.each(allColumns, function(item) {
					if (item.$Id !== changedItem.get("Id") && item.$Id !== nearestItem.get("Id")) {
						totalWidth -= item.$Width;
					}
				}, this);
				return totalWidth;
			},

			/**
			 * Resizes only two nearest structure items according to the changed item.
			 * @private
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem Modified item.
			 * @returns {Boolean} True if item width been changed.
			 */
			_recalculateNearestItemsWidth: function(changedItem) {
				var nearestItem = this._findNearestItem(changedItem);
				var totalWidth = this._getTotalAvailableWidth(changedItem, nearestItem);
				var itemWidth = Number(changedItem.get("Width"));
				var maxItemWidth = totalWidth - nearestItem.get("MinWidth");
				var newItemWidth = Math.max(Math.min(itemWidth, maxItemWidth), changedItem.get("MinWidth"));
				var newNearestItemWidth = totalWidth - newItemWidth;
				if (itemWidth === newItemWidth && nearestItem.get("Width") === newNearestItemWidth) {
					return false;
				}
				nearestItem.set("Width", newNearestItemWidth);
				changedItem.set("Width", newItemWidth);
				return true;
			},

			/**
			 * Resizes structure items according to changed item.
			 * @private
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem Added or modified item.
			 * @returns {Boolean} True, if any items been changed.
			 */
			_recalculateItemsProportionalWidth: function(changedItem) {
				var itemsToResize;
				var fixedWidth = 0;
				var totalWidth = 0;
				var columns = this._getAllColumns(this.$StructureItems);
				BPMSoft.each(columns, function(el) {
					totalWidth += Number(el.$Width);
					el.set("CanChangeWidth", this._getCanChangeWidth());
				}, this);
				var difference = totalWidth - 100;
				itemsToResize = columns.filterByFn(function(item) {
					var isWidthMinimal = item.get("Width") <= item.get("MinWidth");
					if (isWidthMinimal) {
						fixedWidth += item.get("Width");
					}
					var isItemGreaterThanMinWidth = difference < 0 || !isWidthMinimal;
					if (!changedItem) {
						return isItemGreaterThanMinWidth;
					}
					var isItemChanged = item.$Id === changedItem.$Id;
					return isItemGreaterThanMinWidth && !isItemChanged;
				});
				this._adjustColumnsWidth(itemsToResize, changedItem, fixedWidth, difference);
				return itemsToResize.getCount() > 0;
			},

			/**
			 * Updates structure items on sheet, publishing the structureChanged message.
			 * @private
			 */
			_publishMessageToUpdateItemsOnSheet: function() {
				var itemsToUpdate = this.getStructureItems();
				var changesConfig = this.getChangesConfig(null, null, itemsToUpdate);
				this.publishItemAction("structureChanged", changesConfig);
			},

			/**
			 * Actualizes structure items' relative width.
			 * @private
			 */
			_actualizeRelativeWidth: function() {
				BPMSoft.each(this.$StructureItems, function(item) {
					if (item.$Config.ItemType === "mjgroup") {
						item.actualizeWidth();
					} else {
						item.set("RelativeWidth", item.get("Width"));
					}
				}, this);
			},

			/**
			 * Resizes structure items according to changed item and equalization rules. Updates items on sheet.
			 * @private
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} addedModifiedItem Added, modified item or empty.
			 * @param {Boolean} isNearestAffected Defines if only nearest item have to be affected.
			 */
			_updateItemsWidth: function (addedModifiedItem, isNearestAffected) {
				this.$IsInUpdateMode = true;
				var isAnyItemChanged = false;
				if (this.$IsEqualized) {
					this._equalizeColumnsWidth();
					isAnyItemChanged = true;
				} else {
					isAnyItemChanged = isNearestAffected
						? this._recalculateNearestItemsWidth(addedModifiedItem)
						: this._recalculateItemsProportionalWidth(addedModifiedItem);
				}
				this._actualizeRelativeWidth();
				if (isAnyItemChanged) {
					this._publishMessageToUpdateItemsOnSheet();
				}
				this.$IsInUpdateMode = false;
			},

			/**
			 * Replaces group structure item with column structure item.
			 * @protected
			 * @param {String} groupId Identifier of group structure item to replace.
			 * @param {Object} itemConfig Config of column.
			 */
			replaceGroupWithColumn: function(groupId, itemConfig) {
				var index = this.$StructureItems.indexOfKey(groupId);
				this.$StructureItems.removeByKey(groupId);
				var column = this.createStructureItemViewModel(itemConfig);
				this.$StructureItems.insert(index, column.$Id, column);
			},

			/**
			 * @inheritDoc BPMSoft.BaseContentItemStructurePage#prepareItemValues
			 * @override
			 */
			prepareItemValues: function(item) {
				var config = this.callParent(arguments);
				config.Width = item.Width || 100;
				if (config.Width === 100) {
					config.IsRemovable = false;
					config.CanChangeWidth = false;
				}
				return config;
			},

			/**
			 * Inits structure list collection.
			 * @protected
			 */
			initStructureItems: function() {
				this.callParent([this.$ReverseColumnsDirection]);
			},

			/**
			 * @inheritDoc BPMSoft.BaseContentItemStructurePage#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.addEvents(
					/**
					 * @event columnwidthchanged
					 * Event for all columns width recalculation.
					 */
					"columnwidthchanged"
				);
				this.on("columnwidthchanged", this.onColumnWidthChanged, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentItemStructurePage#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.un("columnwidthchanged", this.onColumnWidthChanged, this);
				this.callParent(arguments);
			},

			/**
			 * Recalculates columns width when any column been changed manually.
			 * @protected
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem Changed item view model.
			 */
			onColumnWidthChanged: function(changedItem) {
				this._updateItemsWidth(changedItem, true);
			},

			/**
			 * Equalizes width of columns and publishes message.
			 * @protected
			 */
			onEqualizedChange: function() {
				this._updateItemsWidth();
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentItemStructurePage#onStructureItemAdded
			 * @override
			 */
			onStructureItemAdded: function(item) {
				this.callParent(arguments);
				var viewModelToAdd = this.$StructureItems.get(item.$Id);
				this._updateItemsWidth(viewModelToAdd);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentItemStructurePage#onStructureItemRemove
			 * @override
			 */
			onStructureItemRemove: function(itemId) {
				this.callParent(arguments);
				this._updateItemsWidth();
			},

			/**
			 * @inheritdoc BPMSoft.ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				if (config) {
					var styles = config.Styles;
					this._initReverseColumnsDirection(styles);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentItemStructurePage#canAddStructureItem
			 * @override
			 */
			canAddStructureItem: function() {
				if (!this.maxAllowedStructureItems) {
					return true;
				}
				var columns = this._getAllColumns(this.$StructureItems);
				return columns.getCount() < this.maxAllowedStructureItems;
			},

			/**
			 * Applies changes to structure item.
			 */
			applyChanges: function(item, changes) {
				BPMSoft.each(changes, function(value, prop) {
					item.set(prop, value);
				}, this);
			},

			/**
			 * Returns default config for the structure item.
			 * @override
			 * @returns {Object} Default config for the structure item.
			 */
			getDefaultStructureItemConfig: function (itemType) {
				var config = this.callParent(arguments);
				config.Width = 16;
				return config;
			},

			/**
			 * Handler for add column item action.
			 * @protected
			 */
			onAddColumnItemClick: function() {
				var options = {
					position: this.$ReverseColumnsDirection ? 0 : undefined
				};
				this.addStructureItem("column", options);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "EqualizeColumnsWidthContainer",
				"parentName": "ActionsStructureWrapContainer",
				"propertyName": "items",
				"values": {
					"items": [],
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-editor-wrapper", "disable-input-label",
						"main-checkbox-wrap", "equalize-columns-container"
					]
				}
			},
			{
				"operation": "insert",
				"name": "EqualizeColumnsWidthButton",
				"parentName": "EqualizeColumnsWidthContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checked": "$IsEqualized"
					},
					"markerValue": "EqualizeColumnsWidthCheckbox",
					"caption": "$Resources.Strings.EqualizeColumnsWidthBtnCaption",
					"wrapClass": ["checkbox-control-item", "style-input"]
				}
			},
			{
				"operation": "insert",
				"name": "EqualizeColumnsWidthLabel",
				"parentName": "EqualizeColumnsWidthContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.EqualizeColumnsWidthBtnCaption",
					"classes": {
						"labelClass": ["checkbox-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ColumnsDirectionCheckboxContainer",
				"parentName": "BlockStylesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper", "disable-input-label", "main-checkbox-wrap"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ColumnsDirectionCheckboxContainer",
				"propertyName": "items",
				"name": "ReverseColumnsDirection",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checked": "$ReverseColumnsDirection"
					},
					"markerValue": "ReverseDirectionCheckbox",
					"caption": "$Resources.Strings.ReverseDirection",
					"wrapClass": ["checkbox-control-item", "style-input"]
				}
			},
			{
				"operation": "insert",
				"name": "ReverseColumnsDirectionLabel",
				"parentName": "ColumnsDirectionCheckboxContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.ReverseDirection",
					"classes": {
						"labelClass": ["checkbox-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddColumnItemButton",
				"parentName": "ActionsStructureContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					},
					"imageConfig": "$Resources.Images.AddButtonIcon",
					"caption": "$Resources.Strings.AddStructureItemBtnCaption",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": "$onAddColumnItemClick",
					"enabled": "$CanAddStructureItem",
					"classes": {
						wrapperClass: ["structure-button-control"]
					}
				}
			}
		]
	};
});
