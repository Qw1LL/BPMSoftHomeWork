define("BaseSocialPage", ["css!SocialSearch"], function() {
	return {
		messages: {

			/**
			 * ######### # ############# ######### ###### ## ########## #####.
			 */
			"GetSocialNetworkData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ########## ## ######### ######## ###### ## ########## #####.
			 */
			"SocialNetworkDataLoaded": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("GetSocialNetworkData", this.getSocialNetworkData, this);
			},

			/**
			 * ########## ####### ######## ###### ## ########## #####.
			 * @protected
			 * @return {Object} ######## ##### ## ########## #####.
			 */
			getSocialNetworkData: function() {
				return this.get("SocialCommunications");
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initSocialPage();
					callback.call(scope);
				}, this]);
			},

			/**
			 * ############## ######### ######### ######## ########## ###### ## ###. #####.
			 * @private
			 */
			initSocialPage: function() {
				this.set("ContactImages", Ext.create("BPMSoft.Collection"));
				this.set("IsChanged", true);
				this.set("CaptionName", this.entitySchema.caption);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.loadSocialProfileInfo();
			},

			/**
			 * ######### ########## ## ########## #####.
			 * @protected
			 * @virtual
			 */
			loadSocialProfileInfo: this.BPMSoft.emptyFn,

			/**
			 * ############ ###### ######## ########## ## ########## #####.
			 * @protected
			 * @virtual
			 */
			socialProfileInfoLoaded: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getHeader
			 * @overridden
			 */
			getHeader: function() {
				return this.get("Resources.Strings.HeaderCaption");
			},

			/**
			 * ############# ######## ########### ###### #########, ###### # #######.
			 * @private
			 */
			updateButtonsVisibility: function() {
				this.set("ShowCloseButton", false);
				this.set("ShowSaveButton", true);
				this.set("ShowDiscardButton", true);
				this.set("ActionsButtonVisible", false);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
			 * @overridden
			 */
			onDiscardChangesClick: function() {
				this.onCloseClick();
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onSaved
			 * @overridden
			 */
			onSaved: function() {
				this.callParent(arguments);
				this.onCloseClick();
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "RightContainer"
			},
			{
				"operation": "remove",
				"name": "TabsContainer"
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "HeaderMessage",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.SelectValuesFieldsOrFillFieldsByHand"},
					"labelConfig": {
						"classes": ["header-container-margin-bottom", "width-auto"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
