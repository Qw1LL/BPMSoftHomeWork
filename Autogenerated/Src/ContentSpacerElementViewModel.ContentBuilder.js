﻿define("ContentSpacerElementViewModel", ["ContentSpacerElementViewModelResources", "ContentElementBaseViewModel"],
		function(resources) {
	Ext.define("BPMSoft.ContentBuilder.ContentSpacerElementViewModel", {
		extend: "BPMSoft.ContentElementBaseViewModel",
		alternateClassName: "BPMSoft.ContentSpacerElementViewModel",

		/**
		 * View model element class name.
		 * @protected
		 * @type {String}
		 */
		className: "BPMSoft.ContentSpacerElement",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Styles"],

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
			changedConfig.Styles = config.Styles || {
				height: "30px"
			};
			return changedConfig;
		},

		/**
		 * @inheritdoc BPMSoft.ContentElementBaseViewModel#initDefaultStyles
		 * @overridden
		 */
		initDefaultStyles: BPMSoft.emptyFn,

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
				ElementInfo: {
					Type: this.$ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentSpacerPropertiesPage",
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
		}

	});
});
