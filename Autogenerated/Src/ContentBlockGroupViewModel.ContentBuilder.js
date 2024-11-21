define("ContentBlockGroupViewModel", ["BaseContentBlockViewModel", "ContentMjBlockViewModel",
		"ContentHtmlBlockViewModel", "ContentHtmlBlock"], function() {

	/**
	 * Class for ContentBlockGroupViewModel.
	 */
	Ext.define("BPMSoft.controls.ContentBlockGroupViewModel", {
		extend: "BPMSoft.controls.BaseContentBlockViewModel",
		alternateClassName: "BPMSoft.ContentBlockGroupViewModel",

		/**
		 * Name of the view class.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentBlockGroup",

		/**
		 * @inheritDoc BaseContentSerializableViewModelMixin#childItemTypes
		 */
		childItemTypes: {
			mjblock: "BPMSoft.ContentMjBlockViewModel",
			htmlblock: "BPMSoft.ContentHtmlBlockViewModel"
		},

		/**
		 * @inheritDoc BaseContentItemViewModel#getPreparedConfigBeforeCreate
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = this.callParent(arguments);
			if (Ext.isEmpty(config.Items)) {
				var childItems = [{
					ItemType: "mjblock",
					Items: [{
							ItemType: "section",
							Styles: {
								direction: "ltr"
							}
					}]
				}];
				changedConfig = BPMSoft.deepClone(config);
				changedConfig.Items = childItems;
			}
			return changedConfig;
		},

		/**
		 * Generates configuration object of element view.
		 * @return {Object} Configuration object of element view.
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"isSelectable": true,
				"selected": "$Selected",
				"groupName": ["ContentBlank"],
				"getDraggableConfig": this.getDraggableConfig,
				"ondragover": "$onDragOver",
				"ondragdrop": "$onDragDrop",
				"oninvaliddrop": "$onInvalidDrop",
				"tools": this.getToolsConfig()
			});
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getToolsConfig
		 * @override
		 */
		getToolsConfig: function() {
			var config = this.callParent();
			var block = this.getActiveBlock();
			if (block && block.$ItemType === "htmlblock") {
				return [];
			}
			if (block && block.$ItemType === "block") {
				config.push({
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					markerValue: "block-edit-button",
					imageConfig: "$Resources.Images.ContentBlockEdit",
					classes: {wrapperClass: "content-block-edit-button"},
					click: "$onEditButtonClick"
				});
			}
			return config;
		},

		/**
		 * Returns current active block.
		 * @public
		 * @virtual
		 * @return {BPMSoft.ContentBlockViewModel} Active content block.
		 */
		getActiveBlock: function() {
			return this.$Items.first();
		}

	});

	return BPMSoft.ContentBlockGroupViewModel;
});
