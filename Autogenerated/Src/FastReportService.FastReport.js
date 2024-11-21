define("FastReportService", ["ext-base","ConfigurationServiceProvider","FastReportServiceResources"], function (Ext,provider,resources) {

	Ext.define("BPMSoft.configuration.FastReportService", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.FastReportService",

		// region Fields: Private

		/**
		 * @type {Number}
		 */
		_reportDownloadTimeout: 20 * 60 * 1000,

		// endregion

		// region Methods: Private

		/**
		 * @private
		 * @param {Object} generationConfig
		 * @param {String} generationConfig.templateId
		 * @param {String} generationConfig.caption
		 * @param {String} generationConfig.entitySchemaName
		 * @param {BPMSoft.FilterGroup} generationConfig.filters
		 * @return {Object}
		 */
		_createFastReportServiceRequest: function (generationConfig) {
			return {
				serviceName: "FastReportService",
				methodName: "CreateReport",
				data: {
					reportTemplateId: generationConfig.templateId,
					reportCaption: generationConfig.caption,
					reportSchemaName: generationConfig.entitySchemaName,
					reportFilters: generationConfig.filters.serialize()
				},
				timeout: this._reportDownloadTimeout
			};
		},

		/**
		 * @private
		 * @param {String} caption
		 * @param {String} key
		 */
		_downloadReport: function (caption, key) {
			const report = document.createElement("a");
			report.href = "../rest/FastReportService/GetReportFile/" + key;
			report.download = caption + ".pdf";
			if (Ext.isIE) {
				report.target = "_blank";
			}
			document.body.appendChild(report);
			report.click();
			document.body.removeChild(report);
		},

		_getInnerException: function (exception) {
			if(BPMSoft.appFramework==='NETCOREAPP') {
				return exception?.ExceptionDetail?.inner_exception;
			} else {
				return exception?.ExceptionDetail?.InnerException
			}
		},

		//endregion

		// region Methods: Public

		/**
		 * Generates and downloads report by schema UId and filters.
		 * @public
		 * @param {Object} generationConfig
		 * @param {String} generationConfig.templateId
		 * @param {String} generationConfig.caption
		 * @param {String} generationConfig.entitySchemaName
		 * @param {BPMSoft.FilterGroup} generationConfig.filters
		 * @param {Function} callback
		 * @param {Object} scope
		 */
		generateReport: function (generationConfig, callback, scope) {
			const request = this._createFastReportServiceRequest(generationConfig);
			BPMSoft.ConfigurationServiceProvider.callService(request, function (responseObject,response) {
				if (response && response.status===500) {
					if(response.responseText) {
						const exception=BPMSoft.decode(response.responseText);
						const innerException = this._getInnerException(exception);
						if(innerException) {
							BPMSoft.showInformation(resources.localizableStrings.FastReportGenerationByNotExistingFontMessage);
						}
					}
				}
				else{
					this._downloadReport(generationConfig.caption, responseObject.CreateReportResult);
				}
				Ext.callback(callback, scope);
			}, this);
		},

		//endregion
	});

	return BPMSoft.FastReportService;
});
