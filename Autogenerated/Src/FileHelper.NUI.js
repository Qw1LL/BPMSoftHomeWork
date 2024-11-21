define("FileHelper", ["ext-base", "BPMSoft", "FileHelperResources", "ConfigurationConstants", "MaskHelper"],
	function(Ext, BPMSoft, resources, ConfigurationConstants, MaskHelper) {
		return {

			// region Methods: Public

			/**
			 * Returns basic parameters.
			 * @public
			 * @param {Object} file.
			 * @return {Object} parameters.
			 */
			getBasicFileParameters: function(file) {
				const parameters = {};
				parameters.Id = {
					value: BPMSoft.generateGUID(),
					type: BPMSoft.DataValueType.GUID
				};
				parameters.CreatedOn = {
					value: BPMSoft.SysValue.CURRENT_DATE_TIME,
					type: BPMSoft.DataValueType.DATE_TIME
				};
				parameters.CreatedBy = {
					value: BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
					type: BPMSoft.DataValueType.GUID
				};
				parameters.Name = {
					value: file.name,
					type: BPMSoft.DataValueType.TEXT
				};
				parameters.Version = {
					value: 1,
					type: BPMSoft.DataValueType.INTEGER
				};
				parameters.Size = {
					value: file.size,
					type: BPMSoft.DataValueType.INTEGER
				};
				parameters.Type = {
					value: ConfigurationConstants.FileType.File,
					type: BPMSoft.DataValueType.GUID
				};
				return parameters;
			},

			/**
			 * On File selected handler.
			 * @public
			 * @param {Array} files file array.
			 * @param {String} schemaName schema name.
			 * @param {String} filterPath filter path.
			 * @param {String} filterValue filter value.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The callback execution context.
			 */
			onFileSelect: function(files, schemaName, filterPath, filterValue, callback, scope) {
				scope = scope || this;
				MaskHelper.ShowBodyMask();
				const file = files[0];
				const parameters = this.getBasicFileParameters(file);
				parameters[filterPath] = {
					value: filterValue,
					type: BPMSoft.DataValueType.GUID
				};
				const data = {
					entityName: schemaName,
					fileFieldName: "Data",
					file: file,
					parameters: parameters
				};
				BPMSoft.FileHelper.uploadFile(BPMSoft.QueryOperationType.INSERT, data, function() {
					MaskHelper.HideBodyMask();
					arguments[arguments.length] = filterValue;
					arguments.length++;
					callback.apply(scope, arguments);
				}, this);
			},

			/**
			 * File button config.
			 * @public
			 */
			addFileButtonConfig: {
				className: "BPMSoft.Button",
				style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
				caption: resources.localizableStrings.AddFileButtonCaption,
				classes: {
					textClass: ["file-add-button"]
				},
				fileUpload: true,
				filesSelected: {
					bindTo: "onFileSelect"
				}
			},

			/**
			 * Returns file icon by file name.
			 * @public
			 * @param {String} fileName file size.
			 * @return {String} converted size value.
			 */
			getFileIconByFileName: function(fileName) {
				const arr = /^.*\.([A-z]{2,4})$/g.exec(fileName);
				let fileIcon;
				if (!arr || arr.length < 2) {
					fileIcon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AllIcon);
				} else {
					const fileType = arr[1].toLocaleLowerCase();
					switch (fileType) {
						case "doc":
						case "docx":
							fileIcon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DocIcon);
							break;
						case "pdf":
							fileIcon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.PdfIcon);
							break;
						case "ppt":
							fileIcon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.PptIcon);
							break;
						default:
							fileIcon = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AllIcon);
							break;
					}
				}
				return fileIcon;
			},

			/**
			 * Returns file size with file size metrics in kb.
			 * @public
			 * @param {Number} value file size.
			 * @return {String} converted size value.
			 */
			sizeConverter: function(value) {
				return Math.round(value / 1024) + resources.localizableStrings.FileSizeMetrics;
			}

			// endregion

		};
	});
