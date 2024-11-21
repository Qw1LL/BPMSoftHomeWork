define("PortalMessagePublisherPage", ["PortalMessagePublisherPageResources",  "ConfigurationConstants",
		"ExtendedHtmlEditModuleUtilities", "ExtendedHtmlEditModule", "MessagePublisherAttachmentUtilities",
		"SchemaBuilderV2"],
		function(resources, ConfigurationConstants) {
			return {
				entitySchemaName: "PortalMessage",
				mixins: {
					ExtendedHtmlEditModuleUtilities: "BPMSoft.ExtendedHtmlEditModuleUtilities",
					MessagePublisherAttachmentUtilities: "BPMSoft.MessagePublisherAttachmentUtilities",
					/**
					 * @class BPMSoft.EmailImageMixin
					 * Mixin for inserting images.
					 */
					EmailImageMixin: "BPMSoft.EmailImageMixin",
				},
				attributes: {
					/**
					 * Entities list.
					 */
					entitiesList: {
						"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"PortalEditControlHintText": {
						dataValueType: this.BPMSoft.DataValueType.TEXT
					},
					"Message": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						"value": ""
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.set("entitiesList", this.Ext.create("BPMSoft.Collection"));
						this.initDefaultValues();
						this.initAttachmentsViewData();
						this.initCollection();
						this.mixins.MessagePublisherAttachmentUtilities.init.call(this);
						this.initImageUrlTpl();
						if (!this.get("Images")) {
							this.set("Images", this.Ext.create("BPMSoft.BaseViewModelCollection"));
						}
					},

					/**
					 * @inheritdoc BPMSoft.MessagePublisherAttachmentUtilities#getAttachments
					 * @overridden
					 */
					getAttachments: function(callback, scope) {
						if (this.BPMSoft.Features.getIsEnabled("SecurePortalMessageFileInHistory")) {
							const config = this._getServiceConfig();
							this.callService(config, function(response) {
								if (response && response.GetPortalMessageFilesResult) {
									this._loadResponseToList(response.GetPortalMessageFilesResult.PortalMessageFiles);
									Ext.callback(callback, scope);
								}
							}, this);
						} else {
							this.mixins.MessagePublisherAttachmentUtilities.getAttachments.call(this, callback);
						}
					},

					/**
					 * @private
					 */
					_loadResponseToList: function(files) {
						const viewModels = Ext.create("BPMSoft.Collection");
						BPMSoft.each(files, function (file) {
							file.filesList = this.get("FilesList");
							const viewModelConfig = {
								values: file,
								Ext: this.Ext,
								BPMSoft: this.BPMSoft,
								sandbox: this.sandbox
							};
							const viewModel = this.Ext.create(this.get("AttachmentViewModelClass"),
								viewModelConfig);
							viewModels.addIfNotExists(file.Id, viewModel);
						}, this);
						this.get("FilesList").reloadAll(viewModels);
					},

					/**
					 * @private
					 */
					_getServiceConfig: function () {
						return {
							"serviceName": "PortalMessageFileService",
							"methodName": "GetPortalMessageFiles",
							"data": {
								"portalMessageId": this.get("PrimaryColumnValue"),
								"readingOptions": {
									"rowCount": 50,
									"lastValue": BPMSoft.GUID_EMPTY
								}
							}
						};
					},


					/**
					 * Initializes attachments view data (viewModelClass and viewConfig).
					 * @private
					 */
					initAttachmentsViewData: function() {
						var schemaName = "PortalPublisherAttachmentPage";
						var builderConfig = {
							schemaName: schemaName,
							entitySchemaName: null,
							profileKey: schemaName
						};
						var schemaBuilder = this.Ext.create("BPMSoft.SchemaBuilder");
						schemaBuilder.build(builderConfig, function(viewModelClass, viewConfig) {
							this.set("AttachmentViewModelClass", viewModelClass);
							this.set("AttachmentViewConfig", viewConfig);
						}, this);
					},

					/**
					 * Initializes collection.
					 * @private
					 */
					initCollection: function() {
						var collectionName = "FilesList";
						var collection = this.get(collectionName);
						if (!collection) {
							collection = this.Ext.create("BPMSoft.Collection");
							this.set(collectionName, collection);
						} else {
							collection.clear();
						}
					},

					/**
					 * Initializes default values.
					 * @protected
					 */
					initDefaultValues: function() {
						this.set("isToolbarVisible", false);
						var isSspUser = this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP;
						this.set(
							"PortalEditControlHintText", isSspUser
								? resources.localizableStrings.WritePortalPostHintOnPortal
								: resources.localizableStrings.WritePortalPostHint
						);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getServiceConfig
					 * @overridden
					 */
					getServiceConfig: function() {
						return {
							className: "BPMSoft.Configuration.PortalMessagePublisher"
						};
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#publishMessage
					 * @overridden
					 */
					publishMessage: function() {
						var complainMessage = arguments[0] && arguments[0].Message;
						var message = this.get("Message") || complainMessage;
						if (this.Ext.isEmpty(message)) {
							this.showInformationDialog(this.get("Resources.Strings.EmptyMessageError"));
							return;
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onPublished
					 * @overridden
					 */
					onPublished: function() {
						this.callParent(arguments);
						this.set("Message", "");
						var listItems = this.get("FilesList");
						listItems.clear();
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishMaskCaption
					 * @overridden
					 */
					getPublishMaskCaption: function() {
						return this.get("Resources.Strings.PortalMaskCaption");
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#getPublishData
					 * @overridden
					 */
					getPublishData: function() {
						var publishData = this.callParent(arguments);
						var message = this.get("Message");
						publishData.push({"Key": "Message", "Value": message});
						return publishData;
					},

					/**
					 * @private
					 */
					_getInsertQuery: function() {
						const insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: this.entitySchemaName
						});
						insert.setParameterValue("Id", this.get("PrimaryColumnValue"),
							this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("EntitySchemaUId", BPMSoft.GUID_EMPTY,
							this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("EntityId", BPMSoft.GUID_EMPTY,
							this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Message", this.get("Resources.Strings.DraftBodyMessage"),
							this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("IsNotPublished", true,
							this.BPMSoft.DataValueType.BOOLEAN);
						return insert;
					},
					
					/**
					 * @private
					 */
					_isMasterRecordValid: function(masterRecordId) {
						var config = this.getListenerRecordData();
						if (!config) {
							return true;
						}
						return config.relationSchemaRecordId === masterRecordId;
					},

					/**
					 * Inserts entity.
					 * @private
					 */
					insertEntity: function() {
						const insert = this._getInsertQuery();
						insert.execute(function(response) {
							if (response && response.success) {
								this.set("IsInserted", response.success);
								this.uploadFile();
							}
						}, this);
					},

					/**
					 * Returns attachment view config.
					 * @protected
					 * @virtual
					 * @param {Object} itemConfig Attachment config.
					 * @param {Object} file loaded file data.
					 */
					getItemViewConfig: function(itemConfig, file) {
						var fullViewConfig = this.get("AttachmentViewConfig");
						if (fullViewConfig.length > 0) {
							var attachmentWrapContainerIndex = 0;
							for (var i = 0; i < fullViewConfig.length; i++) {
								if (fullViewConfig[i].id === "AttachmentWrapContainer") {
									attachmentWrapContainerIndex = i;
									break;
								}
							}
							itemConfig.config = fullViewConfig[attachmentWrapContainerIndex];
						}
						this.addImage(file);
					},

					/**
					 * Add uploaded image to images collection.
					 * @protected
					 * @virtual
					 * @param {Object} file loaded file data.
					 */
					addImage: function (file) {
						if (file) {
							const fileName = file.get("Name");
							const fileTypes = this.get("FileTypes");
							if (!fileTypes) {
								return;
							}
							if (fileTypes[fileName] && fileTypes[fileName].match(/^image/)) {
								const image = this.Ext.create("BPMSoft.BaseViewModel", {
									values: {
										fileName: fileName,
										url: "../rest/FileService/GetFile/" +
											ConfigurationConstants.SysSchema.PortalMessageFile + "/" + file.get("Id")
									}
								});
								const imagesCollection = this.get("Images");
								if (imagesCollection) {
									imagesCollection.add(imagesCollection.getUniqueKey(), image);
								}
							}
						}
					},

					/**
					 * @inheritDoc BPMSoft.BaseMessagePublisherPage#onNewCardSaved
					 * @overridden
					 */
					onNewCardSaved: function(masterData) {
						if (masterData && !this._isMasterRecordValid(masterData.masterRecordId)) {
							return;
						}
						if (!this.get("Message")) {
							return;
						}
						this.publishMessage();
					},

					/**
					 * Image pasted event handler. Pasts to message body image pasted from buffer.
					 * @public
					 * @param {Object} item Pasted from buffer file config object.
					 */
					onImagePasted: function(item) {
						let file;
						if (item && this.Ext.isFunction(item.getAsFile)) {
							file = item.getAsFile();
						}
						const args = [file, this.get("PrimaryColumnValue"), this.onComplete.bind(this), this];
						if (this.get("IsInserted")) {
							this.insertImageFromBuffer(args);
							return;
						}
						const insert = this._getInsertQuery();
						insert.execute(function(response) {
							if (response && response.success) {
								this.set("IsInserted", true);
								this.insertImageFromBuffer(args);
							}
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.MessagePublisherAttachmentUtilities#onComplete
					 * @overridden
					 */
					onComplete: function() {
						this.mixins.MessagePublisherAttachmentUtilities.onComplete.call(this);
						this.onDropzoneHover(false);
					},

					/**
					 * @inheritdoc BPMSoft.EmailImageMixin#getFileEntitySchemaName
					 * @overridden
					 */
					getFileEntitySchemaName: function() {
						return "PortalMessageFile";
					},

					/**
					 * @inheritdoc BPMSoft.EmailImageMixin#getFileEntityMasterColumnName
					 * @overridden
					 */
					getFileEntityMasterColumnName: function() {
						return "PortalMessage";
					},

					/**
					 * @inheritdoc BPMSoft.EmailImageMixin#getFileSchemaUId
					 * @overridden
					 */
					getFileSchemaUId: function() {
						return ConfigurationConstants.SysSchema.PortalMessageFile;
					},

					/**
					 * @inheritDoc BPMSoft.BaseMessagePublisherPage#isNeedToBePublished
					 * @overridden
					 */
					isNeedToBePublished: function() {
						return Boolean(this.get("Message"));
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "PortalMessageBody",
						"values": {
							"bindTo": "Message",
							"contentType": this.BPMSoft.ContentType.RICH_TEXT,
							"generator": "InlineTextEditViewGenerator.generate",
							"labelConfig": {
								"visible": true
							},
							"markerValue": "PortalMessageBody",
							"placeholder": {
								"bindTo": "PortalEditControlHintText"
							},
							"controlConfig": {
								"inlineTextControlConfig": {
									"ckeditorDefaultConfig": {
										"allowedContent": true,
										"removeButtons": "bpmcrmmacros",
									}
								},
								"images": {
									"bindTo": "Images"
								},
								"imagePasted": {
									"bindTo": "onImagePasted"
								}
							}
						},
						"parentName": "BodyContainer",
						"propertyName": "items"
					},
					{
						"operation": "insert",
						"name": "AttachFileButton",
						"propertyName": "items",
						"parentName": "PublisherBottomContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
							"iconAlign": this.BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
							"imageConfig": {
								"bindTo": "getAttachFileButtonImageConfig"
							},
							"tag": "attachFileButton",
							"fileUpload": true,
							"filesSelected": {"bindTo": "onAttachFileSelected"},
							"click": {
								"bindTo": "onAttachFileButtonClick"
							},
							"enabled": {
								"bindTo": "IsPublishButtonEnabled"
							},
							"classes": {
								"imageClass": ["attachFileButtonImage"]
							},
							"markerValue": "AttachFileButton"
						}
					},
					{
						"operation": "insert",
						"name": "FilesList",
						"parentName": "ModulePageContainer",
						"propertyName": "items",
						"values": {
							"generateId": false,
							"generator": "ConfigurationItemGenerator.generateContainerList",
							"idProperty": "Id",
							"collection": "FilesList",
							"onGetItemConfig": "getItemViewConfig",
							"isAsync": true
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
