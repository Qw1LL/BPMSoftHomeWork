define("BaseModalBoxPage", ["css!BaseModalBoxPageCss"],
	function() {
		return {
			messages: {
				/**
				 * @message HistoryStateChanged
				 * Will close modal window if history state changes.
				 */
				"HistoryStateChanged": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ModalBoxClosing
				 * Fires when modal box is closing.
				 */
				"ModalBoxClosing": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * Updates size of current modal box.
				 * @protected
				 * @param {Object} [size] New size. If empty, modal box will be resized to match its content.
				 * @param {Number} size.width New width.
				 * @param {Number} size.height New height.
				 */
				resize: function(size) {
					size = size || {};
					this.updateSize(size.width, size.height);
				},

				/**
				 * Returns parameters on page close.
				 * @virtual
				 */
				getModalClosingMessageArgs: BPMSoft.emptyFn,

				/**
				 * Unloads current modal box module.
				 * @protected
				 * @virtual
				 */
				close: function() {
					this.destroyModule();
				},

				/**
				 * Returns header caption from resources.
				 * @protected
				 * @virtual
				 * @return {String} Header caption.
				 */
				getHeader: function() {
					return this.get("Resources.Strings.HeaderCaption");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfileKey
				 * @override
				 */
				getProfileKey: function() {
					return this.name;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("HistoryStateChanged", this.close, this);
				},

				//endregion

				//region Methods: Public

				/**
				 * Returns modal window initial config.
				 * @virtual
				 * @return {Object}
				 * @return {Object} [return.modalBoxConfig] Modal box parameters.
				 * @return {Object} [return.initialSize] Modal box initial size.
				 * @return {Number} return.initialSize.width Initial width.
				 * @return {Number} return.initialSize.height Initial height.
				 */
				getModalBoxInitialConfig: BPMSoft.emptyFn,

				/**
				 * Fires ModalBoxClosing message.
				 */
				beforeModalBoxClosing: function() {
					this.sandbox.publish("ModalBoxClosing", this.getModalClosingMessageArgs(), [this.sandbox.id]);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/ [{
					"operation": "insert",
					"index": 0,
					"name": "CardContentWrapper",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["modal-box-card-content-wrap"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "CardContentWrapper",
					"propertyName": "items",
					"name": "CardContentContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["modal-box-card-content-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HeaderContainer",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header", "modal-box-page-header-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "CloseButtonContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["close-btn-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "CloseButtonContainer",
					"propertyName": "items",
					"values": {
						"click": {
							"bindTo": "close"
						},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"hint": {
							"bindTo": "Resources.Strings.CloseButtonHint"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.CloseButtonImage"
						},
						"markerValue": "CloseIconButton",
						"classes": {
							"wrapperClass": ["close-btn"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "HeaderCaptionContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header-name-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderCaptionContainer",
					"propertyName": "items",
					"name": "HeaderCaption",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"markerValue": {
							"bindTo": "getHeader"
						},
						"caption": {
							"bindTo": "getHeader"
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
