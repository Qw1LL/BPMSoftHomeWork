/**
 * Parent BaseModalBoxPage
 */
define("WizardErrorModalBoxPage", ["RightUtilities", "NetworkUtilities", "css!WizardErrorModalBoxPageCss"],
	function(RightUtilities, NetworkUtilities) {
		return {
			messages: {
				/**
				 * @message NavigateToAllowedStep
				 */
				"NavigateToAllowedStep": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Error message.
				 */
				"ErrorMessageText": {
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
						this.set("ErrorMessageText", moduleInfo.errorMessageText);
						this.updateSize(1, 1);
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.ModalBoxSchemaModule#onRender.
				 * @override
				 */
				onRender: function() {
					this.callParent(arguments);
					this.updateSize();
				},

				/**
				 * Opens "Current Package" system setting page.
				 * @protected
				 */
				openSystemSettings: function() {
					BPMSoft.SysSettings.querySysSettingsRaw(["CurrentPackageId"], function(result) {
						const row = result.values.CurrentPackageId;
						NetworkUtilities.openCardWindow({
							cardSchemaName: "SysSettingPage",
							primaryColumnValue: row.id,
							operation: "edit"
						});
					}, this);
				},

				/**
				 * Opens configuration if current user has sufficient rights.
				 * @protected
				 */
				openAdvancedSettings: function() {
					window.open("../ClientApp/#/WorkspaceExplorer");
				},

				/**
				 * Handler for the "OK" button.
				 * @protected
				 */
				closeButtonClick: function() {
					this.sandbox.publish("NavigateToAllowedStep", null, [this.sandbox.id]);
					this.close();
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
					"name": "ErrorMessageText",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"markerValue": "ErrorMessageText",
						"caption": {"bindTo": "ErrorMessageText"},
						"isMultiline": true
					}
				},
				{
					"operation": "insert",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"name": "ButtonContainer",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["error-modal-box-btn-container"]
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "ButtonContainer",
					"propertyName": "items",
					"values": {
						"click": {"bindTo": "closeButtonClick"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"markerValue": "CloseButton",
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "ChangeCurrentPackage",
					"parentName": "ButtonContainer",
					"propertyName": "items",
					"values": {
						"click": {"bindTo": "openSystemSettings"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"markerValue": "ChangeCurrentPackageButton",
						"caption": {"bindTo": "Resources.Strings.ChangeCurrentPackageMessage"}
					}
				},
				{
					"operation": "insert",
					"name": "OpenAdvancedSettings",
					"parentName": "ButtonContainer",
					"propertyName": "items",
					"values": {
						"click": {"bindTo": "openAdvancedSettings"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"markerValue": "OpenAdvancedSettingsButton",
						"caption": {"bindTo": "Resources.Strings.OpenAdvancedSettingsMessage"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
