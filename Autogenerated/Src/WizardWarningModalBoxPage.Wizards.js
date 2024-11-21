/**
 * Parent BaseModalBoxPage
 */
define("WizardWarningModalBoxPage", ["CollapsibleContainer", "css!WizardWarningModalBoxPageCss"],
	function() {
		return {
			attributes: {
				/**
				 * Error message.
				 */
				"MessageText": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					size: 500,
					value: ""
				},
				/**
				 * Additional info to show in collapsible container.
				 */
				"AdditionalInfo": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					size: 500,
					value: ""
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.ModalBoxSchemaModule#init.
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						const moduleInfo = this.get("moduleInfo");
						this.set("MessageText", moduleInfo.messageText);
						this.set("AdditionalInfo", moduleInfo.additionalInfo);
						this.updateSize(1, 1);
						this.subscribeOnColumnChange("IsCollapsed", this.onCollapsedChanged, this);
						callback.call(scope);
					}, this]);
				},

				/**
				 * Handles item expand/collapse event.
				 * @protected
				 */
				onCollapsedChanged: function() {
					this.updateSize();
				},

				/**
				 * @inheritdoc BPMSoft.core.BaseObject#onDestroy.
				 * @override
				 */
				onDestroy: function() {
					this.unsubscribeOnColumnChange("IsCollapsed", this.onCollapsedChanged, this);
					this.callParent(arguments);
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "HeaderContainer"
				},
				{
					"operation": "insert",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"name": "WarningBodyContainer",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["wizard-warning-body-container"]
					}
				},
				{
					"operation": "insert",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"name": "WarningButtonContainer",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["warning-modal-box-btn-container"]
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "WarningButtonContainer",
					"propertyName": "items",
					"values": {
						"click": {"bindTo": "close"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"markerValue": "CloseButton",
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "WarningBodyContainer",
					"propertyName": "items",
					"name": "MessageText",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"isMultiline": true,
						"markerValue": "MessageText",
						"caption": {"bindTo": "MessageText"}
					}
				},
				{
					"operation": "insert",
					"parentName": "WarningBodyContainer",
					"propertyName": "items",
					"name": "MessageContainer",
					"values": {
						"className": "BPMSoft.CollapsibleContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"controlConfig": {
							"auto": true,
							"visibilityHeight": 0,
							"collapsed": {
								"bindTo": "IsCollapsed"
							}
						},
						"items": [
							{
								"name": "AdditionalInfo",
								"itemType": BPMSoft.ViewItemType.LABEL,
								"caption": {
									"bindTo": "AdditionalInfo"
								},
								"isMultiline": true
							}
						]
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
