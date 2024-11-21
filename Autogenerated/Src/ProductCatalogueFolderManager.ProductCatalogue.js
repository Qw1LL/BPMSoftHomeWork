define("ProductCatalogueFolderManager", ["BaseFolderManager", "ProductCatalogueFolderManagerViewModelConfigGenerator",
	"ProductCatalogueFolderManagerViewModel", "css!ProductCatalogueFolderManager"
], function() {
	return Ext.define("BPMSoft.configuration.ProductCatalogueFolderManager", {
		alternateClassName: "BPMSoft.ProductCatalogueFolderManager",
		extend: "BPMSoft.BaseFolderManager",

		messages: {
			/**
			 * @message FolderInfo
			 * Requests configuration for group module initialization.
			 */
			"FolderInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message AddFolderActionFired
			 * Triggers, when new folder group added.
			 */

			"AddFolderActionFired": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateFavoritesMenu
			 * Triggers on "Favorites" menu update.
			 */
			"UpdateFavoritesMenu": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ResultSelectedFolders
			 * Requests selected folder groups.
			 */
			"ResultSelectedFolders": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message BackHistoryState
			 * Back history state message.
			 */
			"BackHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message PushHistoryState
			 * Push history state message.
			 */
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CustomFilterExtendedMode
			 * Triggers, when user filtration type has been changed.
			 */
			"CustomFilterExtendedMode": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateCustomFilterMenu
			 * Triggers, when user filtration menu has been updated.
			 */
			"UpdateCustomFilterMenu": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetRecordInfo
			 * Get record info message.
			 */
			"GetRecordInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetHistoryState
			 * Get current history state message.
			 */
			"GetHistoryState": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message HideFolderTree
			 * Triggers when folder tree has been hidden.
			 */
			"HideFolderTree": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ResultFolderFilter
			 * Requests result folder filter collection.
			 */
			"ResultFolderFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateFilter
			 * Applies folder group filters.
			 */
			"UpdateFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message LookupInfo
			 * Allows to work with lookup module.
			 */
			"LookupInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ResultSelectedRows
			 * Gets selected groups.
			 */
			"ResultSelectedRows": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateCatalogueFilter
			 * Applies catalogue filters.
			 */
			"UpdateCatalogueFilter": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CloseExtendCatalogueFilter
			 * Triggers on extended filtration module closure.
			 */
			"CloseExtendCatalogueFilter": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetExtendCatalogueFilterInfo
			 * Gets config for extended filtration module.
			 */
			"GetExtendCatalogueFilterInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateExtendCatalogueFilter
			 * Applies extended filtration module filters.
			 */
			"UpdateExtendCatalogueFilter": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetSectionFilterModuleId
			 * UpdateFilter subscription.
			 */
			"GetSectionFilterModuleId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		init: function() {
			this.sandbox.registerMessages(this.messages);
			this.callParent(arguments);
		}
	});
});
