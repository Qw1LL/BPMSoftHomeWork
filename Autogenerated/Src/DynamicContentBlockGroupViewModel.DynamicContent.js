﻿define("DynamicContentBlockGroupViewModel", ["DynamicContentBlockGroupViewModelResources",
		"ContentBlockGroupViewModel", "DynamicContentBlock", "DynamicContentMjBlock", "DynamicContentBlockGroup",
		"DynamicContentBlockViewModel", "DynamicContentMjBlockViewModel", "DynamicContentHtmlBlockViewModel",
		"css!DynamicContentBlockGroupViewModelCSS", "DynamicContentHtmlBlock"],
	function(resources) {
	/**
	 * @class BPMSoft.controls.DynamicContentBlockGroupViewModel
	 */
	Ext.define("BPMSoft.DynamicContentBlockGroupViewModel", {
		extend: "BPMSoft.ContentBlockGroupViewModel",

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#className
		 * @override
		 */
		className: "BPMSoft.DynamicContentBlockGroup",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "Index"],

		/**
		 * Maximum value of the dynamic block priority.
		 * @type {Number}
		 */
		maxBlockPriority: 999,

		/**
		 * @private
		 */
		_initBlocksAfterCreate: function() {
			var blocks = this.$Items.getItems();
			if (blocks.length > 0) {
				var minPriority = blocks.reduce(function (min, block) {
					return block.$Priority < min ? block.$Priority : min;
				}, blocks[0].$Priority);
				this.$Items.each(function (block) {
					block.set("GroupId", this.$Id);
					block.set("IsActive", !Ext.isEmpty(block.$Priority) && block.$Priority === minPriority);
				}, this);
			}
		},

		/**
		 * Constructor call parent logic and prepares blocks for used in dynamic content group.
		 * @param config Contains values property for create view model instance with defined values properties.
		 */
		constructor: function(config) {
			this.callParent(arguments);
			this._initBlocksAfterCreate();
		},

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#initResourcesValues
		 * @override
		 */
		initResourcesValues: function(resourcesObj) {
			Ext.apply(resourcesObj.localizableImages, resources.localizableImages);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#onItemChanged
		 * @override
		 */
		onItemChanged: Ext.emptyFn,

		/**
		 * Returns maximum value of block priority.
		 * @protected
		 * @return {Number} Maximum priority value.
		 */
		getMaxPriority: function() {
			return BPMSoft.reduce(this.$Items.getItems(), function(result, value) {
				return value.$Priority > result && value.$Priority < this.maxBlockPriority
					? value.$Priority
					: result;
			}, 0, this);
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.ContentBlockGroupViewModel#getActiveBlock
		 * @override
		 */
		getActiveBlock: function() {
			return this.$Items.findByFn(function(block) {
				return block.$IsActive !== false;
			});
		},

		/**
		 * Makes selected block active.
		 * @public
		 * @param {String} blockId Identifier of activated block.
		 * @return {BPMSoft.DynamicContentBlockViewModel} Active content block.
		 */
		setActiveBlock: function(blockId) {
			var activeBlock = null;
			var blocks = this.$Items;
			blocks.each(function(block) {
				if (block.$Id !== blockId) {
					block.set("IsActive", false);
				} else {
					block.set("IsActive", true);
					activeBlock = block;
				}
			}, this);
			return activeBlock;
		},

		/**
		 * Adds block to group.
		 * @public
		 * @param {BPMSoft.DynamicContentBlockViewModel} block Content block.
		 */
		addBlock: function(block) {
			block.set("IsActive", true);
			if (!block.$IsDefault) {
				block.$Priority = this.getMaxPriority() + 1;
			}
			this.setActiveBlock();
			this.$Items.add(block.$Id, block);
		},

		/**
		 * Checks existence of default segment in group.
		 * @public
		 * @return {Boolean} True when group has default segment.
		 */
		hasDefaultSegment: function() {
			var segment = this.$Items.findByFn(function(item) {
				return item.$IsDefault;
			});
			return Boolean(segment);
		},

		/**
		 * @inheritdoc BaseContentItemViewModel#extendChildrenItemTypes
		 */
		extendChildrenItemTypes: function() {
			Ext.apply(this.childItemTypes, {
				block: "BPMSoft.DynamicContentBlockViewModel",
				mjblock: "BPMSoft.DynamicContentMjBlockViewModel",
				htmlblock: "BPMSoft.DynamicContentHtmlBlockViewModel"
			});
		}

		//endregion

	});

	return BPMSoft.DynamicContentBlockGroupViewModel;
});
