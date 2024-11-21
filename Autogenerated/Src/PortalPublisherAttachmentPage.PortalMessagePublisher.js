define("PortalPublisherAttachmentPage", [],
	function() {
		return {
			entitySchemaName: "PortalMessageFile",
			attributes: {},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePublisherAttachmentPage#deleteAttachment
				 * @override
				 */
				deleteAttachment: function(callback) {
					this.BPMSoft.Features.getIsEnabled("SecurePortalMessageFileInHistory")
						? this.deleteAttachmentViaService()
							.then(this._deleteAttachFromViewModel.bind(this))
							.catch(this._showErrorInfo.bind(this))
							.finally(this.Ext.callback.bind(this, callback))
						: this.callParent(arguments);
				},

				/**
				 * @private
				 */
				_getServiceConfig: function () {
					return {
						"serviceName": "PortalMessageFileService",
						"methodName": "DeletePortalMessageFile",
						"data": {
							"portalMessageFileId": this.$Id
						}
					};
				},

				/**
				 * Delete attachments via PortalMessageFileService
				 * @protected
				 */
				deleteAttachmentViaService: function() {
					return new Promise(function(resolve, reject) {
						const serviceConfig = this._getServiceConfig();
						this.callService(serviceConfig, function(response) {
							if (response && response.DeletePortalMessageFileResult) {
								resolve();
							} else if (response.errorInfo) {
								reject(response.errorInfo.message);
							}
						}, this);
					}.bind(this));
				},

				/**
				 * Delete viewmodel from filesList which is corresponded to list of files defined as Collection in
				 * PortalMesagePublisherPage view model
				 * @private
				 */
				_deleteAttachFromViewModel: function() {
					const filesListItems = this.values.filesList;
					filesListItems.remove(filesListItems.collection.getByKey(this.$Id));
				},

				/**
				 * @private
				 * @param {String} msg Error message string.
				 */
				_showErrorInfo: function(msg) {
					return Promise.resolve(this.BPMSoft.showErrorMessage(msg));
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
