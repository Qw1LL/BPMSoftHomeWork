define("DynamicContentMjBlockViewModel", ["DynamicContentMjBlockViewModelResources", "ContentMjBlockViewModel",
		"DynamicContentGroupMenu"],
	function(resources) {

		/**
		 * @class BPMSoft.controls.DynamicContentMjBlockViewModel
		 */
		Ext.define("BPMSoft.DynamicContentMjBlockViewModel", {
			extend: "BPMSoft.ContentMjBlockViewModel",

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#className
			 * @override
			 */
			className: "BPMSoft.DynamicContentMjBlock",
			/**
			 * @inheritdoc BPMSoft.ContentElementBaseViewModel#sanitizedProperties
			 * @overridde
			 */
			 sanitizedProperties: ["Caption"],
			/**
			 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
			 * @override
			 */
			serializableSlicePropertiesCollection: ["ItemType", "Styles", "Index", "IsDefault", "Priority",
				"Caption", "Attributes"],

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#initResourcesValues
			 * @override
			 */
			initResourcesValues: function(resourcesObj) {
				Ext.apply(resourcesObj.localizableImages, resources.localizableImages);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseContentBlockViewModel#getViewConfig
			 * @override
			 */
			getViewConfig: function() {
				var viewConfig = this.callParent();
				Ext.apply(viewConfig, {
					"isActive": "$IsActive",
					"caption": "$Caption",
					"groupMenu": this.getGroupMenuConfig()
				});
				return viewConfig;
			},

			/**
			 * Returns group menu config.
			 * @protected
			 * @return {Object} Group menu properties.
			 */
			getGroupMenuConfig: function() {
				return {
					className: "BPMSoft.Button",
					id: this.$Id + "-groupmenu-el",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					markerValue: "group-menu-button",
					imageConfig: "$Resources.Images.DynamicContent",
					classes: {wrapperClass: "block-group-menu-button"},
					menuClass: "BPMSoft.DynamicContentGroupMenu",
					menu: {"items": {"bindTo": "getMenuItems"}}
				};
			},

			/**
			 * Returns instance of group menu item.
			 * @protected
			 * @param {BPMSoft.ContentBlock} block The instance of content block.
			 * @return {BPMSoft.BaseViewModel} Group menu item.
			 */
			getDynamicContentMenuItem: function(block) {
				var menuItem = Ext.create("BPMSoft.BaseViewModel", {
					"values": {
						"Id": block.$Id,
						"Type": "BPMSoft.MenuItem",
						"Caption": block.$Caption,
						"Priority": block.$Priority,
						"Enabled": block.$Id !== this.$Id,
						"Handler": this.onBlockGroupMenuItemClick.bind(this)
					}
				});
				return menuItem;
			},

			/**
			 * Returns collection of group menu items.
			 * @protected
			 * @return {BPMSoft.BaseViewModelCollection} Group menu items.
			 */
			getMenuItems: function() {
				var collection = Ext.create("BPMSoft.BaseViewModelCollection");
				if (this.$GroupId) {
					BPMSoft.each(this.parentCollection, function(block) {
						var item = this.getDynamicContentMenuItem(block);
						collection.addItem(item, item.$Id);
					}, this);
					collection.sort("$Priority", BPMSoft.OrderDirection.ASC);
				}
				return collection;
			},

			/**
			 * Handles click on item of block group menu.
			 * @protected
			 * @param {BPMSoft.Menu} menu The instance of menu.
			 * @param {BPMSoft.MenuItem} item The instance of clicked menu item.
			 */
			onBlockGroupMenuItemClick: function(menu, item) {
				this.fireEvent("change", this, {
					event: "dynamicblockchanged",
					arguments: {Id: item.id, GroupId: this.$GroupId}
				});
			}
		});

		return BPMSoft.DynamicContentMjBlockViewModel;
	}
);
