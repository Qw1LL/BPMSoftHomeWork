define("ContentBlockViewModel", ["ContentBlockViewModelResources", "BaseContentBlockViewModel"], function() {

	/**
	 * @class BPMSoft.controls.ContentBlockViewModel
	 */
	Ext.define("BPMSoft.ContentBlockViewModel", {
		extend: "BPMSoft.BaseContentBlockViewModel",

		/**
		 * Name of the view class.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.controls.ContentBlock",

		/**
		 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getViewConfig
		 * @override
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"isSelectable": this.checkIsSelectable(),
				"selected": "$Selected",
				"elementSelectedChange": "$onElementSelected",
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
			config.push({
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				markerValue: "block-edit-button",
				imageConfig: "$Resources.Images.ContentBlockEdit",
				classes: {wrapperClass: "content-block-edit-button"},
				click: "$onEditButtonClick"
			});
			return config;
		}

	});

	return BPMSoft.ContentBlockViewModel;
});
