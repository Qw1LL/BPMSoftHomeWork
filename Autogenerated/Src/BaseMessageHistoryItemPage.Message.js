define("BaseMessageHistoryItemPage", ["FormatUtils", "NetworkUtilities", "MaskHelper", "MessageConstants",
		"VanillaboxMin", "css!VanillaboxCSS", "css!MessageHistoryStyle", "MultilineLabel", "css!MultilineLabel",
		"MultilineFileLabel", "SelectionHandlerMultilineLabel", "MessageHistorySelectionHandler"],
	function(FormatUtils, NetworkUtilities, MaskHelper, MessageConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			messages: {
				"PushHistoryState": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Files refs.
				 */
				"FilesText": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: ""
				},
				/**
				 * Files detail visibility.
				 */
				"FilesDetailVisible": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				/**
				 * Count of files.
				 */
				"FilesCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				/**
				 * Email actions menu items collection.
				 */
				"EmailActionsMenuCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION
				},
				/**
				 * Highlighted text from message history.
				 */
				"HighlightedHistoryMessage": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				},

				/**
				 * Caption with count of loaded files.
				 */
				"FilesCountCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: ""
				},
				/**
				 * History schema name provided from MessageHistoryUtilities.
				 */
				"HistorySchemaName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT
				},

				/**
				 * Expandable container visibility.
				 */
				"IsExpandableContainerVisible": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			properties: {
				/**
				 * Files preview button link template.
				 */
				hrefTplFormat: "<a href='" + BPMSoft.getConfigurationWebServiceBaseUrl() +
					"/rest/FileService/GetFile/{0}/{1}' vngrop='{2}'>{3}</a>",

				/**
				 * Files group identifier.
				 */
				_groupId: null,

				/**
				 * Vanillabox options config.
				 * @protected
				 * It can contains such values
				 * {
					 *   animation: 'none',
					 *   closeButton: true,
					 *   keyboard: true,
					 *   loop: true,
					 *   preferredWidth: 800,
					 *   preferredHeight: 600,
					 *   repositionOnScroll: true,
					 *   type: 'image',
					 *   adjustToWindow: 'both',
					 *   grouping: true
					 * }
				 * for more information visit https://cocopon.me/app/vanillabox/
				 */
				vanillaboxDefaultConfig: {
					closeButton: false,
					loop: true,
					repositionOnScroll: true
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * Gets container, where MessageHistoryFiles detail should be rendered.
				 * @protected
				 * @virtual
				 * @return {String} Id of detail container.
				 */
				getHistoryMessageFilesContainer: this.BPMSoft.emptyFn,

				/**
				 * Gets identifier of MessageHistoryFiles.
				 * @protected
				 * @virtual
				 * @return {String} Identifier of detail.
				 */
				getHistoryMessageFilesDetailId: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseEntityPage#getDetailId
				 * @override
				 */
				getDetailId: function() {
					var detailId = this.callParent(arguments);
					return this.Ext.String.format("{0}_{1}", detailId, this.get("RecordId"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseEntityPage#getDetailInfo
				 * @override
				 */
				getDetailInfo: function() {
					var detailInfo = this.callParent(arguments);
					detailInfo.detailElementsPrefix = this.sandbox.id + this.get("RecordId");
					return detailInfo;
				},

				/**
				 * Loads DetailModuleV2 into historyMessageFiles container.
				 * @public
				 */
				loadDetailModule: function() {
					var detailInstanceId = this.getHistoryMessageFilesDetailId();
					var detailContainerId = this.getHistoryMessageFilesContainer();
					var detailContainer = this.Ext.get(detailContainerId);
					this.sandbox.loadModule("DetailModuleV2", {
						renderTo: detailContainer,
						id: detailInstanceId
					});
				},

				/**
				 * Returns group identifier for grouping files from the message.
				 * @returns {Guid} Files group identifier.
				 * @private
				 */
				_getMessageFilesGroupId: function() {
					if (this._groupId === null) {
						this._groupId = this.BPMSoft.generateGUID("N");
					}
					return this._groupId;
				},

				/**
				 * Return true if message has at least one img tag.
				 * @param {String} message Message to check.
				 * @private
				 * @return {Boolean} Message has img tag.
				 */
				_hasImageTag: function(message) {
					return message.search(/<img\b/) >= 0;
				},

				/**
				 * Generates action button menu items collection.
				 * @protected
				 * @virtual
				 */
				initEmailActionsMenuCollection: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.setFilesText();
					if (this.Ext.isFunction(callback)) {
						this.Ext.callback(callback, scope || this);
					}
					this.initEmailActionsMenuCollection();
				},

				/**
				 * Modifies message history query.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Message history query.
				 */
				historyMessageEsqApply: this.BPMSoft.emptyFn,

				/**
				 * Add additional filters to message history query.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Message history query.
				 * @param {object} config Config for filters.
				 */
				addAdditionalFilters: this.BPMSoft.emptyFn,

				/**
				 * Returns an image of the author.
				 * @protected
				 * @return {String} Image of the author.
				 */
				getCreatedByImage: function() {
						return this.getImageUrlByEntity(this.get("CreatedBy"));
				},

				/**
				 * Sets refs into files text control.
				 * @protected
				 * @virtual
				 */
				setFilesText: function() {
					this.getHistoryFiles(this.onHistoryFilesLoaded, this);
				},

				/**
				 * Gets history message files. Must be overridden in a sub-classes, that supports file attachments.
				 * @protected
				 * @virtual
				 */
				getHistoryFiles: this.BPMSoft.emptyFn,

				/**
				 * Returns the information about the current record.
				 * @protected
				 * @virtual
				 * @return {Object} Information about the current record.
				 */
				getRecordInfo: function() {
					return this.sandbox.publish("GetRecordInfo", null, [this.sandbox.id]);
				},

				/**
				 * Build file item ref for file text control.
				 * @protected
				 * @virtual
				 * @param {Object} configs Configurations for build files text.
				 */
				onHistoryFilesLoaded: function(configs) {
					this.set("FilesText", this.buildFilesText(configs));
					this.set("FilesDetailVisible", !this.Ext.isEmpty(this.$FilesText));
					this.applyVanillaLogic();
				},

				/**
				 * Build file item ref for file text control.
				 * @protected
				 * @virtual
				 * @param {Object} config Configurations for file item ref.
				 * @return {String} File item text.
				 */
				getFileItem: function(config) {
					var fileItem = "";
					if (this.isImageFile(config.Name)) {
						fileItem = this.getImageFileItemUrl(config);
					} else {
						fileItem = this.getFileItemUrl(config);
					}
					fileItem = this.Ext.String.format(MessageConstants.FileDisplayTemplate,
						fileItem);
					return fileItem;
				},

				/**
				 * Build url for files, except images.
				 * @protected
				 * @virtual
				 * @param {Object} config Configurations for file item ref.
				 * @return {String} File item text.
				 */
				getFileItemUrl: function(config) {
					return this.Ext.String.format(MessageConstants.UrlTemplate.FileUrlTemplate,
						config.SchemaUId, config.Id, config.Name);
				},

				/**
				 * Build url for image files.
				 * @protected
				 * @virtual
				 * @param {Object} config Configurations for file item ref.
				 * @return {String} File item text.
				 */
				getImageFileItemUrl: function(config) {
					return this.Ext.String.format(this.hrefTplFormat,
						config.SchemaUId, config.Id, this._getMessageFilesGroupId(), config.Name);
				},

				/**
				 * Builds file refs for file text control.
				 * @protected
				 * @virtual
				 * @param {Array} configs Configurations for files refs.
				 * @return {String} File text.
				 */
				buildFilesText: function(configs) {
					if (!configs || configs.length === 0) {
						return "";
					}
					this.set("FilesCount", configs.length);
					var hrefs = [];
					this.BPMSoft.each(configs, function(config) {
						hrefs.push(this.getFileItem(config));
					}, this);
					return hrefs.join(", ");
				},

				/**
				 * Returns caption of files detail with count of files.
				 * @return {String} Files detail caption.
				 */
				getFilesCountCaption: function () {
					return this.Ext.String.format(this.get("Resources.Strings.FilesCaption"),
						this.get("FilesCount"));
				},

				/**
				 * Checks if file type is image.
				 * @param name
				 * @returns {boolean}
				 */
				isImageFile: function(name) {
					return Boolean(name.match(/.+\.(jpg|png|gif|tif|bmp|jpeg|svg)$/gi));
				},

				/**
				 * Gets vanillabox config.
				 * @returns {Object} Config.
				 */
				getVanillaboxConfig: function() {
					return this.Ext.apply({}, this.vanillaboxDefaultConfig);
				},

				/**
				 * Applies vanillabox config.
				 */
				applyVanillaLogic: function() {
					var selector = this.Ext.String.format("a[vngrop='{0}']", this._getMessageFilesGroupId());
					var $ = window.jQuery || window.$ || undefined;
					if (!$) {
						return;
					}
					var links = $(selector);
					if (links.length) {
						links.vanillabox(this.getVanillaboxConfig());
					}
				},

				/**
				 * Returns image url by entity.
				 * @private
				 * @param {Object} entity Entity for getting image.
				 * @return {String} Image url.
				 */
				getImageUrlByEntity: function(entity) {
					var imageValue = null;
					if (entity) {
						var image = entity.primaryImageValue || entity.Image;
						if (this.Ext.isObject(image) || this.BPMSoft.isGUID(image)) {
							imageValue = image.value || image;
						} else {
							return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultCreatedBy"));
						}
					}
					return this.getImageUrlById(imageValue);
				},

				/**
				 * Returns image url by id.
				 * @private
				 * @param {String} imageId Image id.
				 * @return {String} Image url.
				 */
				getImageUrlById: function(imageId) {
					if (!imageId) {
						return null;
					}
					return this.BPMSoft.ImageUrlBuilder.getUrl({
						source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
						params: {
							schemaName: "SysImage",
							columnName: "Data",
							primaryColumnValue: imageId
						}
					});
				},

				/**
				 * Checks if message from history is empty.
				 * @protected
				 * @virtual
				 * @param {String} message Message from history
				 * @return {Object} Is message empty.
				 */
				isHistoryMessageEmpty: function(message) {
					return this.Ext.isEmpty(message) || this.Ext.isEmpty(message.trim());
				},

				/**
				 * Opens "Created by" page.
				 * @protected
				 */
				openCreatedByPage: function() {
					var createdBy = this.get("CreatedBy");
					if (!this.Ext.isEmpty(createdBy) && createdBy.value !== BPMSoft.GUID_EMPTY) {
						MaskHelper.ShowBodyMask();
						var hash = NetworkUtilities.getEntityUrl("Contact", createdBy.value);
						this.sandbox.publish("PushHistoryState", {hash: hash});
					}
				},

				/**
				 * Returns created by url.
				 * @return {String} Created by url.
				 */
				getCreatedByUrl: function() {
					var createdBy = this.get("CreatedBy");
					var hash = NetworkUtilities.getEntityUrl("Contact", createdBy.value);
					return this.get("Resources.Strings.ViewModuleUrl") + hash;
				},

				/**
				 * Returns author name.
				 * @protected
				 * @return {String} Author name.
				 */
				getCreatedByName: function() {
					var createdBy = this.get("CreatedBy");
					return createdBy.displayValue;
				},

				/**
				 * Returns message creation date.
				 * @private
				 * @return {String} Message creation date.
				 */
				getCreatedOn: function() {
					var dateConfig = {
						dateValue: this.get("CreatedOn"),
						hasTimezoneOffset: true
					};
					return FormatUtils.smartFormatDate(dateConfig);
				},

				/**
				 * Returns information about creating message.
				 * @protected
				 * @return {String} Information about creating message.
				 */
				getCreationInfo: function() {
					var formatedDate = this.getCreatedOn();
					var messageNotifier = this.get("MessageNotifier.Description");
					return formatedDate + " " + messageNotifier;
				},

				/**
				 * Returns actions button icon.
				 * @protected
				 * @virtual
				 * @return {Object} Actions button icon.
				 */
				getActionsButtonImage: function() {
					return this.get("Resources.Images.ActionsButtonImage");
				},

				/**
				 * Returns actions button marker value.
				 * @protected
				 * @virtual
				 * @return {String} Actions button marker value.
				 */
				getActionsButtonMarkerValue: function() {
					return "emailAction";
				},

				/**
				 * Set action button visibility.
				 * @protected
				 * @virtual
				 * @returns {Boolean} Is button visible.
				 */
				isHistoryActionVisible: function() {
					return false;
				},

				/**
				 * Check that passed value is not empty.
				 * @param {Boolean} value Value to check.
				 * @return {Boolean} True if value is not empty, otherwise false.
				 */
				isNotEmptyValue: function(value) {
					return !this.Ext.isEmpty(value);
				},

				/**
				 * Sets highlighted text in attributes.
				 * @param {String} text Text, highlited in control.
				 * @virtual
				 * @protected
				 */
				onSelectedTextChanged: function(text) {
					this.set("HighlightedHistoryMessage", text);
				},

				/**
				 * Handler for selected text handler button click.
				 * @protected
				 */
				onSelectedTextButtonClick: this.BPMSoft.emptyFn,

				/**
				 * Get icon image for channel.
				 * @protected
				 * @virtual
				 * @return {String} Url of icon image.
				 */
				getChannelIcon: this.BPMSoft.emptyFn,

				/**
				 * Changes opacity for message text.
				 * @protected
				 * @virtual
				 * @return {Number} Opacity mode for text.
				 */
				getOpacityMode: this.BPMSoft.emptyFn,

				isMessageTextNotEmptyConverter: function(message) {
					if (!Ext.isString(message)) {
						return false;
					}
					if (message.length > 2500) {
						return true;
					}
					return this._hasImageTag(message) ||
						this.BPMSoft.utils.string.removeHtmlTags(message).trim() !== "";
				},

				/**
				 * Gets url of "File" icon.
				 * @return {String} Icon url.
				 * @protected
				 */
				getFilesIcon: function () {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.FilesIcon"));
				},

				/**
				 * Sets files block visibility.
				 * @protected
				 */
				setFilesVisibility: function () {
					this.set("FilesDetailVisible", !this.get("FilesDetailVisible"));
				},

				/**
				 * Check if author has photo to show.
				 * @return {Boolean} True if there is image, otherwise false.
				 */
				isPhotoExist: function() {
					const imageUrl = this.getCreatedByImage();
					return imageUrl && imageUrl !==
						this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultCreatedBy"));
				},

				/**
				 * Check if author has no photo to show.
				 * @return {Boolean} True if there is no photo, otherwise false.
				 */
				isPhotoNotExist: function() {
					return !this.isPhotoExist();
				},

				/**
				 * Gets author initials.
				 * @return {String} Short author name.
				 * @protected
				 */
				getAuthorInitials: function() {
					return this.generateContactInitials(this.getCreatedByName());
				},

				/**
				 * Generates initials of a contact using its name.
				 * @protected
				 * @param {String} name Full name of contact.
				 * @return {String} First letters of first two words in contact full name.
				 */
				generateContactInitials: function(name) {
					if (!name) {
						return "";
					}
					const fullName = name.replace(/\s+/g, " ").trim();
					return fullName.split(" ", 2).map(function(value) {
						return value.substr(0, 1).toUpperCase();
					}).join("");
				},

				/**
				 * Returns true if container with files visible, otherwise - false.
				 * @protected
				 * @returns {boolean} Is container with files visible.
				 */
				isFileDetailContainerVisible: function () {
					return false;
				},

				/**
				 * Returns container attributes.
				 * @return {Object}
				 */
				getContainerAttributes: function() {
					return {
						"is-colored": this.getIsNeedToColor()
					};
				},

				/**
				 * Returns sign of need to mark message by color.
				 * @protected
				 * @return {Boolean} True if need to color.
				 */
				getIsNeedToColor: function() {
					return false;
				},

				/**
				 * @private
				 */
				_replaceHeightInTable: function(message) {
					const pattern = /(<table[^>]*)(height\s*=\s*"100%")(.*)/gmi;
					return message.replace(pattern, 
						function(fullMessage, leftExpression, expressionToReplace, rightExpression) {
							return String(String(leftExpression) + String(rightExpression));
					})
				},

				/**
				 * Validates content.
				 * @protected
				 * @param {String} message Source string.
				 * @return {String} Modified string.
				 */
				validateMessage: function(message) {
					if (message && this.Ext.isString(message)) {
						var bodyPattern = /(<style[^>]*>[^>]*)(\bbody\b[^}]*\})([^<]*<\/style>)/gmi;
						message = message.replace(bodyPattern,
							function(fullMessage, leftExpression, expressionToReplace, rightExpression) {
								return String(String(leftExpression) + String(rightExpression));
							});
						message = this._replaceHeightInTable(message);
						message = message.replace(/<base[^>]*>/gi, "");
						message = message.replace(/<pre[^>]*>/gi, "<p>");
						message = message.replace("</pre>","</p>");
					}
					return message;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "HistoryV1Container",
					"propertyName": "items",
					"values": {
						"id": "HistoryV1Container",
						"markerValue": "HistoryV1Container",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["historyContainerV1Wrap"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HistoryMessageWrapContainer",
					"parentName": "HistoryV1Container",
					"propertyName": "items",
					"values": {
						"id": "HistoryMessageWrapContainer",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"markerValue": "HistoryMessageWrapContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["historyMessageWrap"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CreatedByImage",
					"parentName": "HistoryMessageWrapContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getCreatedByImage",
						"onPhotoChange": this.BPMSoft.emptyFn,
						"readonly": true,
						"classes": {
							"wrapClass": ["createdByImage"]
						},
						"markerValue": "CreatedByImage",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onImageClick": {
							"bindTo": "openCreatedByPage"
						},
						"visible": true
					}
				},
				{
					"operation": "insert",
					"name": "MessageContentContainer",
					"parentName": "HistoryMessageWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "MessageContentContainer",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"markerValue": "MessageContentContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["messageContent"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MessageHeaderContainer",
					"parentName": "MessageContentContainer",
					"propertyName": "items",
					"values": {
						"id": "MessageHeaderContainer",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"afterrerender": {
							"bindTo": "applyVanillaLogic"
						},
						"afterrender": {
							"bindTo": "applyVanillaLogic"
						},
						"markerValue": "MessageHeaderContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["messageHeader"],
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "MessageBodyContainer",
					"parentName": "MessageContentContainer",
					"propertyName": "items",
					"values": {
						"id": "MessageBodyContainer",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"markerValue": "MessageBodyContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["messageBody"],
						"items": []
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "MessageText",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.SelectionHandlerMultilineLabel",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message"
								},
								"showLinks": true,
								"selectedTextChanged": {"bindTo": "onSelectedTextChanged"},
								"selectedTextHandlerButtonClick": {"bindTo": "onSelectedTextButtonClick"}
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "MessageFiles",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "FilesText",
								"markerValue": "FilesText",
								"className": "BPMSoft.MultilineFileLabel",
								"classes": {
									"multilineLabelClass": ["message_files"]
								},
								"caption": {
									"bindTo": "FilesText"
								},
								"filesCount": {
									"bindTo": "FilesCount"
								},
								"showLinks": true
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "EmailAction",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"id": "EmailAction",
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {
							"bindTo": "getActionsButtonImage"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"items": [],
						"markerValue": {
							"bindTo": "getActionsButtonMarkerValue"
						},
						"visible": {
							"bindTo": "isHistoryActionVisible"
						},
						"controlConfig": {
							"menu": {
								"items": {"bindTo": "EmailActionsMenuCollection"}
							}
						},
						"classes": {
							wrapperClass: ["email-message-actions-button-wrapper"],
							menuClass: ["email-message-actions-button-menu"]
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"id": "HistoryV2Container",
						"markerValue": "HistoryV2Container",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["historyV2-container-wrap"],
						"domAttributes": {"bindTo": "getContainerAttributes"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "HistoryV2GroupCaptionContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["historyV2-group-caption-container"]
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "GroupCaption",
							"bindConfig": {
								"converter": "isNotEmptyValue"
							}
						},
						"items": [{
							"name": "GroupCaption",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "GroupCaption"
							},
							"markerValue": {
								"bindTo": "GroupCaption"
							},
							"classes": {
								"labelClass": ["historyV2GroupCaption"]
							}
						}]
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageHeaderContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"markerValue": "HistoryV2MessageHeaderContainer",
						"classes": {
							"wrapClassName": ["historyV2-message-header-container"]
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "MessagesSplitLine",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["messages-split-line"]
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"index": 99
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageHeaderCenterContainer",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["inline-container", "message-header-center-container"],
						"items": []
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "HeaderCenterContainerTopLine",
					"parentName": "HistoryV2MessageHeaderCenterContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["center-container-top-line"]
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HeaderCenterContainerBottomLine",
					"parentName": "HistoryV2MessageHeaderCenterContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageHeaderRightContainer",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["message-header-right-container"],
						"items": []
					},
					"index": 4
				},
				{
					"operation": "insert",
					"name": "MessageHeaderContainerFloatClear",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["float-clear-container"],
						"items": []
					},
					"index": 99
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageFooterContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["historyV2-message-footer-container"],
						"items": []
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "HistoryFilesCountContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": {"bindTo": "isFileDetailContainerVisible"},
						"wrapClass": ["history-files-count-container"]
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "HistoryFilesCountContainer",
					"propertyName": "items",
					"name": "HistoryFilesIcon",
					"values": {
						"getSrcMethod": "getFilesIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["icon16"]}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryFilesCountLabel",
					"parentName": "HistoryFilesCountContainer",
					"propertyName": "items",
					"values": {
						"labelClass": ["icon16-label history-files-count-label"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getFilesCountCaption"},
						"click": {"bindTo": "setFilesVisibility"}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageContentContainer",
					"parentName": "HistoryV2Container",
					"propertyName": "items",
					"values": {
						"markerValue": "HistoryV2MessageContentContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["messageContent", "speech-bubble"],
						"items": []
					},
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ChannelIcon",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.ImageEdit",
						"readonly": true,
						"classes": {"wrapClass": ["channelIcon"]},
						"onPhotoChange": "emptyFn",
						"getSrcMethod": "getChannelIcon",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByImage",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getCreatedByImage",
						"onPhotoChange": this.BPMSoft.emptyFn,
						"readonly": true,
						"classes": {
							"wrapClass": ["created-by-image"]
						},
						"markerValue": "CreatedByImage",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onImageClick": {
							"bindTo": "openCreatedByPage"
						},
						"visible": {
							"bindTo": "isPhotoExist"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2AuthorInitials",
					"parentName": "HistoryV2MessageHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"visible": {
							"bindTo": "isPhotoNotExist"
						},
						"click": {
							"bindTo": "openCreatedByPage"
						},
						"labelClass": ["author-initials"],
						"markerValue": "AuthorInitials"
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageText",
					"parentName": "HistoryV2MessageContentContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.MessageHistorySelectionHandler",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "Message"
								},
								"showLinks": true,
								"selectedTextChanged": {"bindTo": "onSelectedTextChanged"},
								"selectedTextHandlerButtonClick": {"bindTo": "onSelectedTextButtonClick"}
							};
						},
						"visible": {
							"bindTo": "MessageText",
							"bindConfig": {
								"converter": "isMessageTextNotEmptyConverter"
							}
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreationInfo",
					"parentName": "HeaderCenterContainerBottomLine",
					"propertyName": "items",
					"values": {
						"id": "CreationInfo",
						"labelClass": ["creationInfoLabel"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedOn"
						}
					},
					"index": 7
				},
				{
					"operation": "insert",
					"name": "HistoryV2MessageHeaderExpandableContainer",
					"parentName": "HeaderCenterContainerBottomLine",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"classes": {
							"wrapClassName": ["historyV2-message-header-expandable"]
						},
						"visible": {
							"bindTo": "IsExpandableContainerVisible"
						}
					},
					"index": 10
				},
				{
					"operation": "insert",
					"name": "HistoryV2FileDetailContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"index": 1
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
