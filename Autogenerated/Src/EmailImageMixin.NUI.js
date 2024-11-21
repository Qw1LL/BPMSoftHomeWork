define("EmailImageMixin", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		/**
		 * @class BPMSoft.configuration.mixins.EmailImageMixin
		 * Email image mixin.
		 */
		Ext.define("BPMSoft.configuration.mixins.EmailImageMixin", {
			alternateClassName: "BPMSoft.EmailImageMixin",

			/**
			 * Image type pattern.
			 */
			//jscs:disable
			/*jshint maxlen:400 */
			imageRegexPattern: /^(?:image\/bmp|image\/cis\-cod|image\/gif|image\/ief|image\/jpeg|image\/jpg|image\/pipeg|image\/png|image\/svg\+xml|image\/tiff|image\/x\-cmu\-raster|image\/x\-cmx|image\/x\-icon|image\/x\-portable\-anymap|image\/x\-portable\-bitmap|image\/x\-portable\-graymap|image\/x\-portable\-pixmap|image\/x\-rgb|image\/x\-xbitmap|image\/x\-xpixmap|image\/x\-xwindowdump)$/i,
			/*jshint maxlen:120 */
			//jscs:enable

			//region Methods: Protected

			/**
			 * After image inserted handler.
			 * @protected
			 */
			afterImageInserted: BPMSoft.emptyFn,

			/**
			 * Returns sign if only RTF text pasted to editor.
			 * @protected
			 * @param {Object[]} clipboardDataTypes Clipboard data types.
			 * @return Sign that only RTF text pasted to editor.
			 */
			isPasteExcelCell: function(clipboardDataTypes) {
				const checkMethodName = this._getClipboardTypeCheckMethodName(clipboardDataTypes);
				return clipboardDataTypes.length === 4
					&& this._checkClipboardType(clipboardDataTypes, checkMethodName, "text/plain")
					&& this._checkClipboardType(clipboardDataTypes, checkMethodName, "text/html")
					&& this._checkClipboardType(clipboardDataTypes, checkMethodName, "text/rtf")
					&& this._checkClipboardType(clipboardDataTypes, checkMethodName, "Files");
			},

			/**
			 * Check clipboard data type.
			 * @private
			 * @param {Object[]} clipboardDataTypes Clipboard data types.
			 * @param {String} methodName Check data type method name.
			 * @param {String} type Checked data type.
			 * @return {Boolean} True, if type exist in clipboardDataTypes array.
			 */
			_checkClipboardType: function(clipboardDataTypes, methodName, type) {
				if (BPMSoft.isEmpty(methodName)) {
					return false;
				}
				const checkMethod = clipboardDataTypes[methodName];
				return checkMethod.call(clipboardDataTypes,type);
			},

			/**
			 * Gets check data type method name.
			 * @private
			 * @param {Object[]} clipboardDataTypes Clipboard data types.
			 * @return {String} Check data type method name.
			 */
			_getClipboardTypeCheckMethodName: function(clipboardDataTypes) {
				const containsMethod = clipboardDataTypes.includes || clipboardDataTypes.contains;
				return typeof containsMethod  == 'function' ? containsMethod.name : BPMSoft.emptyString;
			},

			/**
			 * Returns new FileReader instance.
			 * @protected
			 * @virtual
			 * @return {FileReader} FileReader instance.
			 */
			getFileReader: function() {
				return new FileReader();
			},

			/**
			 * Checks current model state before images will be inserted.
			 * @protected
			 * @virtual
			 * @param {Object[]} args Arguments.
			 * @param {Function} callback Callback function.
			 */
			validateBeforeInsert: function(args, callback) {
				this.Ext.callback(callback, this, [args]);
			},

			/**
			 * Uploades single file, selected in ckeditor.
			 * @protected
			 * @param {Object} file File to upload.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback context.
			 */
			uploadSingleFile: function(file, callback, scope) {
				var newItemId = BPMSoft.generateGUID();
				var onComplete = function() {
					var imagesCollection = this.get("Images");
					if (Ext.isEmpty(imagesCollection)) {
						return;
					}
					var fileId = newItemId;
					var entityFileSchemaUId = this.getFileSchemaUId();
					var image = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							fileName: file.name,
							url: Ext.String.format(this.get("ImageUrlTpl"), entityFileSchemaUId, fileId)
						}
					});
					imagesCollection.add(imagesCollection.getUniqueKey(), image);
					Ext.callback(callback, scope || this);
				}.bind(this);
				var config = {
						scope: this,
						onComplete: onComplete,
						entitySchemaName: this.getFileEntitySchemaName(),
						columnName: "Data",
						parentColumnName: this.getFileEntityMasterColumnName(),
						parentColumnValue: this.get("Id") || this.get("PrimaryColumnValue"),
						files: [file],
						isChunkedUpload: true,
						additionalParams: {
							Inline: true
						},
						data: {
							fileId: newItemId
						}
					};
				this.uploadFileToBPM(config);
			},

			/**
			 * Calls {@link BPMSoft.core.FileHelper#uploadFile} method.
			 * @protected
			 * @param {Object} data File parameters.
			 */
			uploadFileToBPM: function(data) {
				this.BPMSoft.ConfigurationFileApi.upload(data);
			},

			//endregion

			//region Methods: Public

			/**
			 * Sets image entity resource url template.
			 */
			initImageUrlTpl: function() {
				this.set("ImageUrlTpl", "../rest/FileService/GetFile/{0}/{1}");
			},

			/**
			 * Image loaded event handler. Pasts to email body loaded image.
			 * @param {Object} fileNames Inserted files names.
			 */
			onImageLoaded: function(fileNames) {
				var args = [fileNames, this];
				this.validateBeforeInsert(args, this.insertImages);
			},

			/**
			 * Saves images in db.
			 * @param {Object[]} args Arguments.
			 * @param {Object[]} args[0] Files to upload.
			 * @param {Object} args[1] Upload function execution scope.
			 */
			insertImages: function(args) {
				var rawFiles = args[0];
				var files = [];
				this.BPMSoft.each(Ext.Object.getKeys(rawFiles), function(key) {
					files.push(rawFiles[key]);
				});
				var scope = args[1];
				this.BPMSoft.each(files, function(file) {
					this.uploadSingleFile(file);
				}, scope);
			},

			/**
			 * Image pasted event handler.
			 * @param {Object[]} args Arguments.
			 */
			insertImageFromBuffer: function(args) {
				var file = args[0];
				var callback = args[2];
				var scope = args[3];
				var fileTypeParts = file.type.split("/");
				var imageExtension = (fileTypeParts.length > 1) ? fileTypeParts[1] : fileTypeParts[0];
				file.name = "Image." + imageExtension;
				this.uploadSingleFile(file, callback, scope);
			},

			/**
			 * Returns file entity name.
			 * @virtual
			 * @return {String} File entity name.
			 */
			getFileEntitySchemaName: function() {
				return "ActivityFile";
			},

			/**
			 * Returns master record relation column name for file entity.
			 * @virtual
			 */
			getFileEntityMasterColumnName: function() {
				return "Activity";
			},

			/**
			 * Returns file entity UId.
			 * @virtual
			 * @return {Guid} File entity UId.
			 */
			getFileSchemaUId: function() {
				return ConfigurationConstants.SysSchema.ActivityFile;
			},

			/**
			 * Event handler for MemoEdit "paste" event.
			 * @param {Object} Control event.
			 */
			onPaste: function(event) {
				var editor = event.listenerData && event.listenerData.editor;
				var $event = event.data.$;
				var clipboardData = $event.clipboardData;
				var imageType = /^image/;
				if (!clipboardData || clipboardData.mozCursor === "auto") {
					return;
				}
				var types = clipboardData.types;
				if (this.isPasteExcelCell(types)) {
					return;
				}
				if (types.length === 2 && types[0] === "text/html" && types[1] === "Files") {
					$event.preventDefault();
					event.stop();
				}
				BPMSoft.each(types, function(type, i) {
					var item = clipboardData.items[i];
					if (!item) {
						return true;
					}
					if (type.match(imageType) || item.type.match(imageType)) {
						this.fireEvent("imagePasted", item, editor);
						return false;
					}
				}, this);
			},

			/**
			 * Handles event "dataLoaded" image collection.
			 * @param {BPMSoft.Collection} collection Image list.
			 */
			onImagesLoaded: function(collection) {
				this.images = collection;
				if (this.images === null) {
					return;
				}
				this.images.eachKey(function(key, item, index) {
					this.onAddImage(item, index, key, true);
				}, this);
			},

			/**
			 * Handles event "add" image collection.
			 * @param {BPMSoft.BaseViewModel} Image.
			 */
			onAddImage: function(item) {
				if (this.editor && this.editor.document) {
					var imageElement = this.editor.document.createElement("img");
					imageElement.setAttribute("alt", item.get("fileName"));
					imageElement.setAttribute("src", item.get("url"));
					this.editor.insertElement(imageElement);
					this.afterImageInserted();
				}
			},

			/**
			 * Image pasted event handler. Inserts image from buffer to rich text edit body.
			 * @param {Object} item Pasted from buffer file config object.
			 */
			onImagePasted: function(item) {
				var file = null;
				if (item && typeof item.getAsFile === "function") {
					file = item.getAsFile();
				}
				var args = [file, this.get("Id"), BPMSoft.emptyFn, this];
				this.validateBeforeInsert(args, this.insertImageFromBuffer);
			}

			//endregion

		});
	});
