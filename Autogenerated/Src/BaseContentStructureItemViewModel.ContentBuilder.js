﻿/**
 * View model for content structure item in container list.
 */
define("BaseContentStructureItemViewModel", ["BaseContentStructureItemViewModelResources"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.BaseContentStructureItemViewModel
		 */
		Ext.define("BPMSoft.configuration.BaseContentStructureItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.BaseContentStructureItemViewModel",
			/**
			 * Prefix for control marker value.
			 * @type {String}
			 * @virtual
			 */
			markerValuePrefix: "base-structure-item",
			/**
			 * Postfix for container marker value.
			 * @type {String}
			 * @virtual
			 */
			markerValuePostfix: "base-structure-item-container",
			/**
			 * Wrap classes.
			 * @type {Object}
			 * @virtual
			 */
			wrapClassNames: {
				container: "structure-item-container",
				item: "structure-item",
				caption: "structure-caption"
			},
			/**
			 * View model item type
			 * @type {String}
			 * @abstract
			 */
			itemType: BPMSoft.abstractFn,
			/**
			 * Parent structure item page.
			 * @type {BPMSoft.BaseContentItemStructurePage}
			 */
			parentViewModel: null,

			attributes: {
				/**
				 * Structure item caption.
				 * @type {String}
				 */
				"Caption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Structure item name.
				 * @type {String}
				 */
				"Name": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Structure item identifier.
				 * @type {String}
				 */
				"Id": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Flag to indicate remove action posibility.
				 * @type {Boolean}
				 */
				"IsRemovable": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Structure item position.
				 * @type {Number}
				 */
				"Position": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Initializes model with resources.
			 * @protected
			 * @param {Object} resourcesObj Resources object.
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
			 * Returns control marker value.
			 * @protected
			 * @returns {String} Marker value.
			 */
			getControlMarkerValue: function() {
				return this.markerValuePrefix + "-" + this.$Name;
			},

			/**
			 * Returns control identifier.
			 * @protected
			 * @returns {String} Control identifier.
			 */
			getControlId: function() {
				return this.$Name;
			},

			/**
			 * Returns container marker value.
			 * @protected
			 * @returns {String} Marker value.
			 */
			getContainerMarkerValue: function() {
				return this.$Name + "-" + this.markerValuePostfix;
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * Handler for structure item remove button click.
			 * @protected
			 */
			onRemoveStructureItemClick: function() {
				this.parentViewModel.fireEvent("removestructureitem", this.$Id);
			},

			/**
			 * Handler for structure item selected event.
			 * @protected
			 */
			onSelectStructureItemClick: function() {
				this.parentViewModel.fireEvent("selectstructureitem", this.$Id);
			},

			/**
			 * Sets caption for current structure item.
			 * @protected
			 * @param {Number} index Identifier for structure item.
			 * @param {String} itemTitle Item title (optional parameter).
			 */
			setCaption: function(index, itemTitle) {
				var title = itemTitle || resources.localizableStrings.BaseStructureItemTitle;
				var caption = Ext.String.format("{0}{1}", title, index);
				this.set("Caption", caption);
				this.set("Position", index);
			},

			/**
			 * Returns marker value for clickable item label.
			 * @protected
			 * @returns {String} Label marker value.
			 */
			getLabelMarkerValue: function() {
				return this.get("Name") + this.get("Position");
			},

			/**
			 * Returns base structure item view config to display.
			 * @protected
			 * @returns {Object} Item view config.
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
							click: "$onSelectStructureItemClick",
							classes: { wrapperClass: [this.wrapClassNames.caption] }
						}
					]
				};
			},

			/**
			 * Returns config of current item view.
			 * @returns {Object} View config.
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
							className: "BPMSoft.Button",
							markerValue: "remove-" + this.$Name + "-btn",
							classes: { wrapperClass: ["structure-item-remove-btn"] },
							style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
							imageConfig: "$Resources.Images.RemoveIcon",
							click: "$onRemoveStructureItemClick",
							visible: "$IsRemovable"
						}
					]
				};
			},

			/**
			 * Returns config for the structure item.
			 * @returns {Object} Config for the structure item.
			 */
			getStructureItemConfig: function () {
				return {
					ItemType: this.itemType,
					Id: this.$Id
				};
			}
		});
		return BPMSoft.BaseContentStructureItemViewModel;
	}
);
