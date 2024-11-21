define("BaseDashboardItemViewConfig", ["ImageCustomGeneratorV2", "ViewGeneratorV2", "DcmConstants",
	"ActionsDashboardItemContainer"
], function(ImageCustomGeneratorV2) {
	Ext.define("BPMSoft.configuration.BaseDashboardItemViewConfig", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.BaseDashboardItemViewConfig",
		viewGeneratorClass: "BPMSoft.ViewGenerator",
		Ext: null,

		/**
		 * Creates instance of BPMSoft.ViewGenerator class.
		 * @return {BPMSoft.ViewGenerator} Returns object BPMSoft.ViewGenerator.
		 */
		createViewGenerator: function() {
			var viewGenerator = this.Ext.create(this.viewGeneratorClass, {
				customGenerators: {
					"IconContainer": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			});
			viewGenerator.setGeneratorsByModule("ImageCustomGeneratorV2", ImageCustomGeneratorV2);
			return viewGenerator;
		},

		/**
		 * Returns the view configuration of the module.
		 * @return {Object} The view configuration of the module.
		 */
		generate: function() {
			var viewConfig = this.getViewConfig();
			var viewGenerator = this.createViewGenerator();
			var view = viewGenerator.generateView(viewConfig);
			return view[0];
		},

		/**
		 * Returns config for the view.
		 * @return {Array} Config.
		 */
		getViewConfig: function() {
			return [
				{
					"name": "Item",
					"className": "BPMSoft.ActionsDashboardItemContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [
						this.getContainerViewConfig(),
						this.getFooterViewConfig(),
						this.getActionsViewConfig()
					]
				}
			];
		},

			// region Methods: Protected

		/**
		 * Returns actions config for the view.
		 * @protected
		 * @return {Object} Config.
		 */
		getActionsViewConfig: function() {
			return {
				"name": "Actions",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {wrapClassName: ["dashboard-item-actions on-hover-visible"]},
				"items": [
					{
						"name": "Cancel",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "CancelButtonCaption"},
						"click": {"bindTo": "onCancelButtonClick"},
						"classes": {
							"textClass": "dashboard-item-right"
						},
						"visible": {"bindTo": "CancelButtonVisible"}
					},
					{
						"name": "Execute",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "ExecuteButtonCaption"},
						"click": {"bindTo": "onExecuteButtonClick"},
						"classes": {
							"textClass": "dashboard-item-right"
						},
						"visible": {"bindTo": "ExecuteButtonVisible"}
					}
				]
			};
		},

		/**
		 * Returns container config for the view.
		 * @protected
		 * @return {Object} Config.
		 */
		getContainerViewConfig: function() {
			return {
				"name": "Content",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {wrapClassName: ["dashboard-item-content"]},
				"items": [
					{
						"name": "Caption",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Caption"},
						"markerValue": {"bindTo": "Caption"},
						"click": {"bindTo": "onCaptionClick"},
						"isRequired": {"bindTo": "IsRequired"},
						"classes": {
							"labelClass": ["dashboard-item", "dashboard-item-clickable"]
						},
						"tips": [{
							"content": {"bindTo": "Caption"},
							"markerValue": {"bindTo": "Caption"}
						}]
					}
				]
			};
		},

		/**
		 * Returns footer config for the view.
		 * @protected
		 * @return {Object} Config.
		 */
		getFooterViewConfig: function() {
			return {
				"name": "Footer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {wrapClassName: ["dashboard-item-footer"]},
				"items": [
					{
						"name": "Date",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "DateText"}
					},
					{
						"name": "Owner",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getOwnerName"},
						"classes": {
							"labelClass": ["dashboard-footer-item-border-left"]
						}
					},
					{
						"name": "IconContainer",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["dashboard-item-icon dashboard-item-right on-hover-hidden"]
						},
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getIconSrc",
						"items": []
					}
				]
			};
		}

		// endregion

	});
});
