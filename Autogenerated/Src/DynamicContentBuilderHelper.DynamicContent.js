define("DynamicContentBuilderHelper", ["ContentBuilderHelper", "DynamicContentBlockViewModel",
	"DynamicContentMjBlockViewModel", "DynamicContentBlockGroupViewModel"], function() {

	/**
	 * @class BPMSoft.ContentExporters.DynamicContentBuilderHelper
	 */
	Ext.define("BPMSoft.ContentExporters.DynamicContentBuilderHelper", {
		extend: "BPMSoft.ContentBuilderHelper",
		alternateClassName: "BPMSoft.DynamicContentBuilderHelper",

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#blockGroupVmName
		 * @override
		 */
		blockGroupVmName: "BPMSoft.DynamicContentBlockGroupViewModel",

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#blockElementVmName
		 * @override
		 */
		blockElementVmName: "BPMSoft.DynamicContentBlockViewModel",

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#mjBlockElementVmName
		 * @override
		 */
		mjBlockElementVmName: "BPMSoft.DynamicContentMjBlockViewModel",

		/**
		 * List of parameters used in dynamic content for sheet.
		 * @protected
		 * @virtual
		 * @type {String[]}
		 */
		sheetElementDCProperties: ["Attributes"],

		/**
		 * List of parameters used in dynamic content for group of blocks.
		 * @protected
		 * @virtual
		 * @type {String[]}
		 */
		blockGroupDCProperties: ["Index"],

		/**
		 * List of parameters used in dynamic content for block.
		 * @protected
		 * @virtual
		 * @type {String[]}
		 */
		blockElementDCProperties: ["Index", "IsDefault", "Priority", "Caption", "Attributes"],

		/**
		 * Checks whether content block dynamic or not.
		 */
		_isDynamicBlock: function(blockConfig) {
			return blockConfig.Priority
				&& (blockConfig.IsDefault || (blockConfig.Attributes && blockConfig.Attributes.length > 0));
		},

		/**
		 * Initializes properties of content builder elements.
		 */
		initElementProperties: function() {
			this.sheetElementProperties = this.sheetElementProperties.concat(this.sheetElementDCProperties);
			this.blockGroupProperties = this.blockGroupProperties.concat(this.blockGroupDCProperties);
			this.blockElementProperties = this.blockElementProperties.concat(this.blockElementDCProperties);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initElementProperties();
		},

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#blockToViewModel
		 * @override
		 */
		blockToViewModel: function(config) {
			if (!this._isDynamicBlock(config)) {
				config.Caption = null;
			}
			var viewModel = this.callParent(arguments);
			return viewModel;
		},

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#mjBlockToViewModel
		 * @override
		 */
		mjBlockToViewModel: function(config) {
			if (!this._isDynamicBlock(config)) {
				config.Caption = null;
			}
			var viewModel = this.callParent(arguments);
			return viewModel;
		},

		/**
		 * @inheritdoc BPMSoft.ContentBuilderHelper#blockGroupToViewModel
		 * @override
		 */
		blockGroupToViewModel: function(config) {
			var viewModel = this.callParent(arguments);
			var items = viewModel.$Items;
			var blocks = items.getItems();
			var minPriority = blocks.reduce(function(min, block) {
				return block.$Priority < min ? block.$Priority : min;
			}, blocks[0].$Priority);
			BPMSoft.each(items, function(block) {
				block.set("IsActive", !Ext.isEmpty(block.$Priority) && block.$Priority === minPriority);
			}, this);
			return viewModel;
		}
	});
});
