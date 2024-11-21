/**
 * Page to select DCAttribute item from available atribute variants.
 */
define("ContentUserBlockEditPage", ["ContentUserBlockEditPageResources", "css!ContentUserBlockEditPageCSS",
		"ImageView"],
	function() {
		return {
			properties: {
				/**
				 * Maximum length for block name field.
				 */
				blockNameMaximumLength: 230
			},
			messages: {

				/**
				 * @message BlockSaved
				 * Message indicates need save current mj-block.
				 */
				"BlockSaved": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SaveBlockCancel
				 * Message for canceling mj-block saving process.
				 */
				"SaveBlockCancel": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {

				/**
				 * Block identifier.
				 * @type {Guid}
				 */
				"BlockId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Block name.
				 * @type {String}
				 */
				"BlockName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Block preview image url string.
				 * @type {String}
				 */
				"PreviewImage" : {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				/**
				 * Removes all iframes from block to fix html2canvas issue.
				 * @private
				 */
				_removeAllIframes: function(clonedBlock, sourceBlock) {
					var sourceElement = sourceBlock;
					clonedBlock.querySelectorAll("iframe").forEach(function(iframe) {
						var iframes = sourceElement.query("#" + iframe.id);
						if (iframes.length === 0) {
							return;
						}
						var sourceIframe = iframes[0];
						iframe.parentNode.innerHTML = sourceIframe.contentDocument.body.innerHTML; 
					}, this);
				},

				/**
				 * @private
				 */
				_createPreviewScreenshot: function() {
					this.$PreviewImage = this.get("Resources.Strings.BlockPreviewScreenshotImage");
					var block = Ext.get(this.$BlockId + "-content-mjblock");
					if (block && !Ext.isIE) {
						var parent = block.parent();
						var clonedBlock = block.dom.cloneNode(true);
						this._removeAllIframes(clonedBlock, block);
						block.hide();
						parent.dom.insertBefore(clonedBlock, block.dom);
						BPMSoft.convertElementToCanvas(block.id, {
							scale: 0.75,
							allowTaint: true,
							useCORS: true,
							ignoreElements: function (element) {
								return element.classList.contains("content-block-tools-wrap")
									|| element.classList.contains("placeholder-image");
							}
						},
						function(canvas) {
							var image = canvas.toDataURL();
							if (image) {
								this.$PreviewImage = image;
							}
							clonedBlock.remove();
							block.show();
						}, this);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this._createPreviewScreenshot();
				},

				/**
				 * Handler for listen when  block screenshot made.
				 * @protected
				 */
				onMjBlockScreenshotMade: function(result) {
					if (this.$BlockId !== result.blockId || !result.image ) {
						return;
					}
					var config = {
						source: BPMSoft.ImageSources.URL,
						url: result.image
					};
					this.$PreviewImage = BPMSoft.ImageUrlBuilder.getUrl(config);
				},

				/**
				 * Handler on save button pressed.
				 * Sends message BlockSaved to ContentBuilder.
				 * @protected
				 */
				onSaveButtonClick: function() {
					if (this.$BlockName && this.$BlockName !== BPMSoft.emptyString) {
						this.sandbox.publish("BlockSaved", {
							blockName: this.$BlockName.substring(0, this.blockNameMaximumLength),
							previewImage: this.$PreviewImage
						}, [this.sandbox.id]);
					}
				},

				/**
				 * Handler on cancel button pressed.
				 * Sends message SaveBlockCancel to ContentBuilder.
				 * @protected
				 */
				onCancelButtonClick: function() {
					this.sandbox.publish("SaveBlockCancel", null, [this.sandbox.id]);
				},

				/**
				 * Decides when save button enabled.
				 * @protected
				 * @returns {boolean} Returns true when PreviewImage is loaded and BlockName typed.
				 */
				getIsSaveButtonEnabled: function () {
					return this.$PreviewImage;
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SaveBlockPageContainer",
					"propertyName": "items",
					"values": {
						"id": "SaveBlockPageContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["close-button"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": "$Resources.Images.CloseIcon",
						"click": "$onCancelButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"name": "EditPageCaption",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"markerValue": "EditPageCaption",
						"caption": "$Resources.Strings.TitleCaption",
						"classes": {
							"labelClass": ["t-title-label-user-block-edit-page"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "BlockNameInputCaption",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"id": "BlockNameInputCaption",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.BlockNameLabel",
						"classes": {
							"labelClass": ["t-label t-label-is-required"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "BlockName",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"wrapClass": ["style-input"],
						"isRequired": true,
						"focused": true,
						"markerValue": "BlockName",
						"labelConfig": {
							"visible": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "PreviewImageContainer",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"values": {
						"id": "PreviewImageContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["user-block-edit-page-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "PreviewImage",
					"parentName": "PreviewImageContainer",
					"propertyName": "items",
					"values": {
						"id": "PreviewImage",
						"itemType": this.BPMSoft.ViewItemType.COMPONENT,
						"wrapClasses": ["user-block-edit-page-preview-image"],
						"selectors": {
							"wrapEl": "#previewImage"
						},
						"className": "BPMSoft.ImageView",
						"imageSrc": "$PreviewImage",
						"tag": "PreviewImage"
					}
				},
				{
					"operation": "insert",
					"name": "EditButtonsContainer",
					"parentName": "SaveBlockPageContainer",
					"propertyName": "items",
					"values": {
						"id": "EditButtonsContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["user-block-edit-page-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SaveButton",
					"parentName": "EditButtonsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.SaveButtonCaption",
						"click": "$onSaveButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"enabled": "$getIsSaveButtonEnabled"
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "EditButtonsContainer",
					"propertyName": "items",
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.CancelButtonCaption",
						"click": "$onCancelButtonClick",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				}
			]
		};
	});
