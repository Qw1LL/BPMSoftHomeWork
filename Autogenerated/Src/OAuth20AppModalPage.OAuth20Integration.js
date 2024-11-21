define("OAuth20AppModalPage", function() {
	return {
		messages: {
			/**
			 * @message CloseOAuth20AppPage
			 * Close application page.
			 */
			"CloseOAuth20AppPage": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_close: function() {
				const isEdit = this.$Operation === BPMSoft.ConfigurationEnums.CardOperation.EDIT;
				this.sandbox.publish("CloseOAuth20AppPage", isEdit ? this.$Id : null);
				BPMSoft.utils.dom.setAttributeToBody("hide-scroll", false);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
			 * @overridden
			 */
			getPageHeaderCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#updatePageHeaderCaption
			 * @overridden
			 */
			updatePageHeaderCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#clearPageHeaderCaption
			 * @overridden
			 */
			clearPageHeaderCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#initHeader
			 * @overridden
			 */
			initHeader: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#resetBodyAttributes
			 * @overridden
			 */
			resetBodyAttributes: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#initRunProcessButtonMenu
			 * @overridden
			 */
			initRunProcessButtonMenu: Ext.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#getDefaultValues
			 * @override
			 */
			getDefaultValues: function() {
				return [];
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onSaved
			 * @override
			 */
			onSaved: function(response, config) {
				this.callParent(arguments);
				if (!(config && config.isSilent)) {
					this._close();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
			 * @override
			 */
			onDiscardChangesClick: function() {
				this._close();
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
			 * @override
			 */
			onCloseClick: function() {
				this._close();
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.set("DefaultTabName", "OAuthSettingsTab");
				BPMSoft.utils.dom.setAttributeToBody("hide-scroll", true);
				this.$IsActionDashboardContainerVisible = false;
				this.callParent(arguments);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "OAuthAppPageWrapper",
				"values": {
					"id": "OAuthAppPageWrapper",
					"selectors": {"wrapEl": "#OAuthAppPageWrapper"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["card-content-container", "oauth20-header-container"],
					"items": []
				},
				index: 0
			},
			{
				"operation": "insert",
				"name": "OAuthAppPageContentContainer",
				"parentName": "OAuthAppPageWrapper",
				"propertyName": "items",
				"values": {
					"id": "OAuthPageContentContainer",
					"selectors": {"wrapEl": "#OAuthPageContentContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["web-service-method-page-center-main-container", "center-main-container"],
					"items": [],
					"markerValue": "CenterMainContainer"
				}
			},
			{
				"operation": "insert",
				"name": "ActionContainer",
				"parentName": "OAuthAppPageContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["web-service-method-action-container"],
					"items": []
				},
				index: 0
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "OKButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"visible": {"bindTo": "ShowSaveButton"},
					"click": {"bindTo": "save"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"tag": "ok",
					"markerValue": "ok"
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "DiscardChangesButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onDiscardChangesClick"},
					"visible": {"bindTo": "ShowDiscardButton"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "CloseButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onCloseClick"},
					"visible": {"bindTo": "ShowCloseButton"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "CloseIcon",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["web-service-method-page-close-btn"]},
					"click": {"bindTo": "onDiscardChangesClick"}
				}
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"id": "CardContentWrapperModalPage",
					"selectors": {"wrapEl": "#CardContentWrapperModalPage"},
					"wrapClass": ["card-content-container", "oauth20app-card-content-wrapper"]
				}
			},
			{
				"operation": "merge",
				"name": "CardContentContainer",
				"values": {
					"selectors": {"wrapEl": "#CardContentContainerModalPage"},
					"id": "CardContentContainerModalPage"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
