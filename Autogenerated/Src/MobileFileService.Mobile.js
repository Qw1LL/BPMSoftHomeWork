/**
 * @class BPMSoft.FileService
 */
Ext.define("BPMSoft.configuration.FileService", {
	alternateClassName: "BPMSoft.FileService",
	singleton: true,

	/**
	 * @private
	 */
	getFileSize: function(filePath, callback) {
		BPMSoft.File.open({
			name: BPMSoft.util.toRelativeUrl(filePath),
			success: function(file) {
				var fileEntry = file.getFileSystemEntry();
				fileEntry.getMetadata(function(metadata) {
					Ext.callback(callback, this, [metadata.size]);
				}.bind(this));
			},
			failure: function() {
				Ext.callback(callback, this, [0]);
			},
			scope: this
		});
	},

	/**
	 * Called on failure.
	 * @protected
	 * @virtual
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Scope of callback function.
	 * @param {BPMSoft.Exception} exception Exception.
	 */
	onFailure: function(callback, scope, exception) {
		if (exception instanceof BPMSoft.FileTransferException) {
			var response = exception.getResponse();
			if (response) {
				var parser = Ext.create("BPMSoft.ServiceResponseParser", response);
				var parsedException = parser.getServiceFailureException();
				parsedException.setInnerException(exception);
				exception = parsedException;
			}
		}
		Ext.callback(callback, scope, [exception]);
	},

	/**
	 * Gets upload url.
	 * @protected
	 * @virtual
	 * @param {Object} config Configuration object for upload.
	 * @return {String} Url.
	 */
	getUploadServiceUrl: function(config) {
		var serviceUrl = BPMSoft.ServiceHelper.getServiceUrl("FileApiService", "Upload");
		var fileRecord = config.fileRecord;
		var fileType = fileRecord.get("Type");
		if (fileType instanceof BPMSoft.model.BaseModel) {
			fileType = fileType.getPrimaryColumnValue();
		}
		var queryParams = {
			totalFileLength: config.totalFileLength,
			fileId: fileRecord.getId(),
			columnName: config.fileColumnName,
			fileName: fileRecord.get("Name"),
			fileTypeId: fileType,
			entitySchemaName: fileRecord.self.modelName
		};
		return Ext.urlAppend(serviceUrl, Ext.Object.toQueryString(queryParams));
	},

	/**
	 * Gets download url.
	 * @protected
	 * @virtual
	 * @param {Object} config Configuration object for download.
	 * @param {Object} schemaUId UId of schema.
	 * @return {String} Url.
	 */
	getDownloadServiceUrl: function(config, schemaUId) {
		var serviceUrl = BPMSoft.ServiceHelper.getServiceUrl("FileService", "GetFile");
		return Ext.String.format("{0}/{1}/{2}", serviceUrl, schemaUId, config.fileRecord.getId());
	},

	/**
	 * Uploads file.
	 * @param {Object} config Configuration object:
	 * @param {BPMSoft.BaseModel} config.fileRecord Instance of model.
	 * @param {String} config.fileColumnName Name of file column of record.
	 * @param {Boolean} config.isCancelable If true, request is cancelable.
	 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
	 * @param {Boolean} config.suppressRequestEvents If true, suppress request events.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	upload: function(config) {
		config.path = config.fileRecord.get(config.fileColumnName);
		this.getFileSize(config.path, function(size) {
			if (size === 0) {
				var exception = Ext.create("BPMSoft.FileSystemException", {
					message: BPMSoft.LS["Sys.Exception.FileSystem.NotFound"]
				});
				Ext.callback(config.failure, config.scope, [exception]);
				return;
			}
			config.totalFileLength = size;
			config.url = this.getUploadServiceUrl(config);
			var failure = config.failure;
			config.failure = function(exception) {
				this.onFailure(failure, config.scope, exception);
			}.bind(this);
			config.headers = BPMSoft.RequestManager.getDefaultHeaders();
			config.headers["Content-Range"] = Ext.String.format("bytes 0-{0}/{1}", size - 1, size);
			config.httpMethod = "POST";
			BPMSoft.Cookie.getCSRF(function(value) {
				config.headers[BPMSoft.CookieName.CSRF] = value;
				BPMSoft.RequestManager.issueRequest({
					requestFn: BPMSoft.FileTransfer.upload,
					requestFnConfig: config,
					responseToStatusCodeFn: BPMSoft.FileTransfer.getStatusCodeFromException,
					loginFailure: function(exception) {
						Ext.callback(config.failure, config.scope, [exception]);
					},
					suppressRequestEvents: config.suppressRequestEvents,
					scope: BPMSoft.FileTransfer
				});
			}, this);
		});

	},

	/**
	 * Downloads file.
	 * @param {BPMSoft.BaseModel} config.fileRecord Instance of model.
	 * @param {String} config.fileColumnName Name of file column of record.
	 * @param {Boolean} config.isCancelable If true, request is cancelable.	 *
	 * @param {String} config.cancellationId Cancellation id. If parameter is set, operation can be cancelled.
	 * @param {Boolean} config.suppressRequestEvents If true, suppress request events.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Function} config.progress Called on progress.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	download: function(config) {
		var fileRecord = config.fileRecord;
		BPMSoft.CFUtils.loadSysSchemaUIdByName({
			modelName: fileRecord.self.modelName,
			cancellationId: config.cancellationId,
			success: function(schemaUId) {
				config.url = this.getDownloadServiceUrl(config, schemaUId);
				var failure = config.failure;
				config.failure = function(exception) {
					this.onFailure(failure, config.scope, exception);
				}.bind(this);
				config.headers = BPMSoft.RequestManager.getDefaultHeaders();
				BPMSoft.RequestManager.issueRequest({
					requestFn: BPMSoft.FileTransfer.download,
					requestFnConfig: config,
					responseToStatusCodeFn: BPMSoft.FileTransfer.getStatusCodeFromException,
					loginFailure: function(exception) {
						Ext.callback(config.failure, config.scope, [exception]);
					},
					suppressRequestEvents: config.suppressRequestEvents,
					scope: BPMSoft.FileTransfer
				});
			},
			failure: function(exception) {
				Ext.callback(config.failure, config.scope, [exception]);
			},
			scope: this
		});
	}

});
