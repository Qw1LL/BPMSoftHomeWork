define("EmptyPropertiesPage", ["ext-base", "BPMSoft", "EmptyPropertiesPageResources", "AcademyUtilities",
		"HtmlControlGeneratorV2"],
	function(Ext, BPMSoft, resources, AcademyUtilities) {
		return {
			mixins: {
				editable: "BPMSoft.ProcessSchemaElementEditable"
			},
			messages: {
				"HidePropertyPage": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {
				"AcademyMessage": {
					dataValueType: BPMSoft.DataValueType.TEXT
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Init AcademyMessage attribute with help URL by DcmSchemaDesigner.
				 * @private
				 */
				initAcademyMessage: function() {
					var config = {
						contextHelpCode: "DcmSchemaDesigner",
						callback: this.onGetAcademyUrlCallback,
						scope: this
					};
					AcademyUtilities.getUrl(config);
				},

				/**
				 * Handler for getUrl callback of AcademyUtilities.
				 * @private
				 * @param {String} url Help academy url.
				 */
				onGetAcademyUrlCallback: function(url) {
					var description = this.get("Resources.Strings.AcademyMessage");
					var startTagPart = "";
					var endTagPart = "";
					if (!Ext.isEmpty(url)) {
						startTagPart = "<a target=\"_blank\" href=\"" + url + "\">";
						endTagPart = "</a>";
					}
					var academyMessage = Ext.String.format(description, startTagPart, endTagPart);
					this.set("AcademyMessage", academyMessage);
				},

				/**
				 * The method of obtaining the image url.
				 * @private
				 * @return {String}
				 */
				getNotSelectImage: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.EmptyImage);
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.initAcademyMessage();
					callback.call(scope);
				},

				/**
				 * The event handler clicking on the close button.
				 * @protected
				 */
				onHidePropertyPage: function() {
					this.sandbox.publish("HidePropertyPage");
				},

				/**
				 * @inheritdoc BPMSoft.BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.mixins.editable.onDestroy.call(this);
					this.callParent(arguments);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "EmptyPropertiesContainer",
					"values": {
						"id": "EmptyPropertiesContainer",
						"selectors": {"wrapEl": "#EmptyPropertiesContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["empty-properties-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmptyPropertiesContainer",
					"propertyName": "items",
					"name": "ToolsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["tools-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ToolsContainer",
					"propertyName": "items",
					"name": "CloseButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"imageClass": ["button-background-no-repeat"],
							"wrapperClass": ["close-button-wrapClass"]
						},
						"click": {
							"bindTo": "onHidePropertyPage"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.CloseButtonImage"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmptyPropertiesContainer",
					"propertyName": "items",
					"name": "ImageContainer",
					"values": {
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onPhotoChange": BPMSoft.emptyFn,
						"getSrcMethod": "getNotSelectImage",
						"classes": {
							"wrapClass": ["image-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmptyPropertiesContainer",
					"propertyName": "items",
					"name": "DescriptionHeader",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EmptyPageHeader"
						},
						"classes": {
							"labelClass": [
								"description-header"
							],
							"wrapClass": [
								"description-wrap"
							]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmptyPropertiesContainer",
					"propertyName": "items",
					"name": "DescriptionLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.EmptyPageCaption"
						},
						"classes": {
							"labelClass": [
								"description-label"
							],
							"wrapClass": [
								"description-wrap"
							]
						}
					}
				},
				{
					"operation": "remove",
					"parentName": "EmptyPropertiesContainer",
					"propertyName": "items",
					"name": "AcademyMessageContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["academy-message-container"],
						"items": []
					}
				},
				{
					"operation": "remove",
					"parentName": "AcademyMessageContainer",
					"propertyName": "items",
					"name": "AcademyMessageHtmlControl",
					"values": {
						"generator": "HtmlControlGeneratorV2.generateHtmlControl",
						"htmlContent": {
							"bindTo": "AcademyMessage"
						},
						"classes": {
							"wrapClass": ["t-label"]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
