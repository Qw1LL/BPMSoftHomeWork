define("ContentNavbarElementViewModel", ["ContentNavbarElementViewModelResources", "ContentElementBaseViewModel",
		"ContentNavbarLinkViewModel"], function(resources) {
	Ext.define("BPMSoft.ContentBuilder.ContentNavbarElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentNavbarElementViewModel",

		/**
		 * View model element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentNavbarElement",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles", "IsHamburger", "IconStyles"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableChildrenCollectionSource
		 * @override
		 */
		serializableChildrenCollectionSource: "Items",

		childItemTypes: {
			navbarlink: "BPMSoft.ContentNavbarLinkViewModel"
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
		 * @inheritDoc BaseContentItemViewModel#getPreparedConfigBeforeCreate
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = this.callParent(arguments);
			if (Ext.isEmpty(changedConfig.Items)) {
				changedConfig.Items = [{
					ItemType: "navbarlink"
				},{
					ItemType: "navbarlink"
				}];
			}
			changedConfig.Styles = config.Styles || {
				"text-align": BPMSoft.Align.CENTER
			};
			changedConfig.IconStyles = config.IconStyles || {
				"text-align": BPMSoft.Align.CENTER
			};
			return changedConfig;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#initDefaultStyles
		 * @overridden
		 */
		initDefaultStyles: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"items": "$Items",
				"elementSelectedChange": "$onElementSelected"
			});
			return config;
		},

		/**
		 * Returns config object of view model edit page.
		 * @protected
		 * @override
		 * @returns {Object} Full edit page config.
		 */
		getEditConfig: function() {
			var config =  {
				ItemType: this.$ItemType,
				Styles: this.$Styles,
				IsHamburger: this.$IsHamburger,
				IconStyles: this.$IconStyles,
				Items: [],
				ElementInfo: {
					Type: this.$ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentNavbarPropertiesPage",
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				}
			};
			BPMSoft.each(this.$Items, function(item) {
				config.Items.push(this.getItemEditConfig(item));
			}, this);
			return config;
		},

		/**
		 * Returns config object of navbar item edit.
		 * @protected
		 * @virtual
		 * @returns {Object} Navbar item edit config.
		 */
		getItemEditConfig: function(item) {
			return {
				Id: item.$Id,
				ItemType: item.$ItemType
			};
		},

		/**
		 * Element click handler.
		 * @protected
		 */
		onElementSelected: function(elementId) {
			this.fireEvent("change", this, {
				event: "elementSelected",
				arguments: {
					id: elementId
				}
			});
		}

	});
});
