define("SocialCommunicationDetail", ["ConfigurationConstants", "BaseCommunicationDetail",
		"SocialCommunicationViewModel"], function(ConfigurationConstants) {
	return {
		attributes: {

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#IsNewItemFocused
			 * @overridden
			 */
			"IsNewItemFocused": {
				value: false
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#getCommunicationItemViewConfig
			 * @overridden
			 */
			getCommunicationItemViewConfig: function() {
				var itemViewConfig = this.callParent(arguments);
				var checkBoxEditConfig = this.getCheckBoxEditConfig();
				itemViewConfig.items.splice(0, 0, checkBoxEditConfig);
				return itemViewConfig;
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#getIconTypeButtonConfig
			 * @overridden
			 */
			getIconTypeButtonConfig: function() {
				var iconTypeButtonConfig = this.callParent(arguments);
				iconTypeButtonConfig.enabled = false;
				return iconTypeButtonConfig;
			},

			/**
			 * Gets checkbox edit configuration.
			 * @protected
			 * @return {Object}
			 */
			getCheckBoxEditConfig: function() {
				return {
					className: "BPMSoft.CheckBoxEdit",
					checkedchanged: {bindTo: "onSelectItem"},
					checked: true,
					markerValue: {
						bindTo: "getCheckBoxEditMarkerValue"
					}
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#save
			 * @overridden
			 */
			save: function() {
				var collection = this.get("Collection");
				var deletedItems = this.get("DeletedItems");
				collection.each(function(item) {
					if (!item.isDeleted) {
						return;
					}
					collection.removeByKey(item.get(item.primaryColumnName));
					deletedItems.addItem(item);
				}, this);
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#initQueryFilters
			 * @overridden
			 */
			initQueryFilters: function(esq) {
				this.callParent(arguments);
				var notSocialNetworkCommunicationFilter = this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.NOT_EQUAL,
					"[ComTypebyCommunication:CommunicationType:CommunicationType].Communication",
					ConfigurationConstants.Communication.SocialNetwork);
				esq.filters.addItem(notSocialNetworkCommunicationFilter);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#getCommunicationViewModelClassName
			 * @overridden
			 */
			getCommunicationViewModelClassName: function() {
				return "BPMSoft.SocialCommunicationViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#addDeleteMenuItem
			 * @overridden
			 */
			addDeleteMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#initDetailOptions
			 * @overridden
			 */
			initDetailOptions: function() {
				this.callParent(arguments);
				this.set("IsDetailCollapsed", false);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#getTypeButtonConfig
			 * @overridden
			 */
			getTypeButtonConfig: function() {
				var typeButtonConfig = this.callParent(arguments);
				typeButtonConfig.style = {
					bindTo: "getTypeButtonStyle"
				};
				return typeButtonConfig;
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#getItemsToValidate
			 * @overridden
			 */
			getItemsToValidate: function() {
				var collection = this.get("Collection");
				return collection.filter(function(item) {
					return !item.isDeleted;
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#syncDetailWithMasterEntity
			 * @overridden
			 */
			syncDetailWithMasterEntity: BPMSoft.emptyFn

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "AddButton"
			},
			{
				"operation": "remove",
				"name": "SocialNetworksContainer"
			}
		]/**SCHEMA_DIFF*/
	};
});
