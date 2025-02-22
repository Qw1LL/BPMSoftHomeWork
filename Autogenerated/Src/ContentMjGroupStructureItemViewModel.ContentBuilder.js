﻿/**
 * View model for content mjgroup structure item in container list.
 */
define("ContentMjGroupStructureItemViewModel", ["ContentMjGroupStructureItemViewModelResources",
		"BaseContentStructureItemViewModel", "ContentStructureMixin"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ContentMjGroupStructureItemViewModel
		 */
		Ext.define("BPMSoft.configuration.ContentMjGroupStructureItemViewModel", {
			extend: "BPMSoft.BaseContentStructureItemViewModel",
			alternateClassName: "BPMSoft.ContentMjGroupStructureItemViewModel",
			mixins: {
				structure: "BPMSoft.ContentStructureMixin"
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
				}
			},
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePrefix
			 * @override
			 */
			markerValuePrefix: "mjgroup-item",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePostfix
			 * @override
			 */
			markerValuePostfix: "mjgroup-item-container",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#itemType
			 * @override
			 */
			itemType: "mjgroup",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#wrapClassNames
			 * @override
			 */
			wrapClassNames: {
				container: "mjgroup-item-container",
				item: "mjgroup-item",
				caption: "mjgroup-caption",
				width: "mjgroup-width",
				widthContainer: "mjgroup-width-container",
				innerItemsContainer: "mjgroup-structure-items",
				border: "mjgroup-structure-items-border"
			},
			columns: {
				"Width": {
					dataValueType: BPMSoft.DataValueType.FLOAT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			itemViewModelNames: {
				column: "BPMSoft.ContentSectionStructureItemViewModel"
			},

			/**
			 * Returns marker value for the input control of the column width.
			 * @private
			 */
			_getWidthInputMarkerValue: function() {
				return "width-" + this.getLabelMarkerValue();
			},

			/**
			 * @private
			 */
			_getWidthControlConfig: function() {
				return {
					id: "mjgroup-width-container",
					className: "BPMSoft.Container",
					classes: { wrapClassName: [this.wrapClassNames.widthContainer] },
					items: [
						{
							className: "BPMSoft.IntegerEdit",
							value: "$Width",
							enabled: "$CanChangeWidth",
							blur: "$onColumnWidthChanged",
							enterkeypressed: "$onColumnWidthChanged",
							markerValue: "$_getWidthInputMarkerValue"
						},
						{
							className: "BPMSoft.Label",
							caption: "%",
							enabled: "$CanChangeWidth"
						}
					]
				};
			},

			/**
			 * @private
			 */
			_getGroupWidth: function() {
				var width = this.$StructureItems
					.mapArray(function(item) {
						return item.$Width;
					})
					.reduce(function(a, b) {
						return a + b;
					});
				return Math.floor(10000 * width) / 10000;
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
				this.initStructureItems();
				this.mixins.structure.initEvents.apply(this);
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
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.mixins.structure.onDestroy.apply(this);
				this.un("columnwidthchanged", this.onColumnWidthChanged, this);
				this.callParent(arguments);
			},

			/**
			 * Handler on structure item remove action.
			 * @protected
			 * @param {String} id Identifier of structure item to remove.
			 */
			onStructureItemRemove: function(id) {
				var viewModelToRemove = this.$StructureItems.get(id);
				this.$StructureItems.remove(viewModelToRemove);
				if (this.$StructureItems.getCount() === 1) {
					var firstItem = this.$StructureItems.first();
					this.parentViewModel.replaceGroupWithColumn(this.$Id, firstItem.$Config);
				}
				this.parentViewModel.refreshConfigItems();
				this.parentViewModel.onStructureItemRemove(id, true);
			},

			/**
			 * Handler on structure item select action.
			 * @protected
			 * @param {String} id Identifier of structure item to select.
			 */
			onStructureItemSelect: function(id) {
				this.parentViewModel.onStructureItemSelect(id);
			},

			/**
			 * Handler on structure items collection changed event.
			 * @protected
			 */
			onStructureItemCollectionChanged: function() {
				this.parentViewModel.onStructureItemCollectionChanged();
			},

			/**
			 * Recalculates columns width when any column been changed manually.
			 * @protected
			 * @param {BPMSoft.ContentSectionStructureItemViewModel} changedItem Changed item view model.
			 */
			onColumnWidthChanged: function(changedItem) {
				this.parentViewModel.onColumnWidthChanged(changedItem);
			},

			/**
			 * @inheritDoc BaseContentItemStructurePage#prepareItemValues
			 * @override
			 */
			prepareItemValues: function(item) {
				var config = this.mixins.structure.prepareItemValues.apply(this, arguments);
				config.Width = item.Width || 100;
				if (config.Width === 100) {
					config.IsRemovable = false;
					config.CanChangeWidth = false;
				}
				return config;
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#setCaption
			 * @override
			 */
			setCaption: function(index) {
				var title = resources.localizableStrings.BaseStructureItemTitle;
				this.callParent([index, title]);
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#getBaseStructureItemViewConfig
			 * @override
			 */
			getBaseStructureItemViewConfig: function() {
				return {
					id: "structure-item",
					className: "BPMSoft.Container",
					markerValue: this.getContainerMarkerValue(),
					classes: { wrapClassName: [this.wrapClassNames.item] },
					items: [
						{
							className: "BPMSoft.Label",
							caption: "$Caption",
							markerValue: "$getLabelMarkerValue",
							classes: { wrapperClass: [this.wrapClassNames.caption] }
						}
					]
				};
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#getViewConfig
			 * @override
			 */
			getViewConfig: function() {
				var innerItemViewConfig = this.getBaseStructureItemViewConfig();
				return {
					id: "structure-item-wrap",
					className: "BPMSoft.Container",
					markerValue: this.getContainerMarkerValue(),
					classes: { wrapClassName: [this.wrapClassNames.container] },
					items: [
						innerItemViewConfig,
						{
							className: "BPMSoft.ContainerList",
							idProperty: "Id",
							itemPrefix: "mjgroup-column",
							collection: {bindTo: "StructureItems"},
							onGetItemConfig: {bindTo: "getStructureItemViewConfig"},
							classes: { wrapClassName: [this.wrapClassNames.innerItemsContainer] }
						},
						{
							id: "structure-item-border",
							className: "BPMSoft.Container",
							classes: { wrapClassName: [this.wrapClassNames.border] },
							items: []
						}
					]
				};
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#getStructureItemConfig
			 * @override
			 */
			getStructureItemConfig: function () {
				var config = this.callParent(arguments);
				config.Items = this.getStructureItems();
				config.Width = this.$Width;
				return config;
			},

			/**
			 * Recalculates group width and relative width of structure items.
			 */
			actualizeWidth: function() {
				var groupWidth = this._getGroupWidth();
				this.$Width = groupWidth;
				BPMSoft.each(this.$StructureItems, function(column) {
					var relativeWidth = 100 * column.$Width / groupWidth;
					column.$RelativeWidth = Math.floor(10000 * relativeWidth) / 10000;
				}, this);
			}
		});
	}
);
