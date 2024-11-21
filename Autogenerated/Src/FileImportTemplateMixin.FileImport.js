define("FileImportTemplateMixin", [], function() {
	/**
	 * FileImportTemplateMixin mixin class.
	 * @class BPMSoft.FileImportMixin
	 */
	Ext.define("BPMSoft.FileImportTemplateMixin", {
		alternateClassName: "BPMSoft.configuration.mixins.FileImportTemplateMixin",

		// region Methods: Public

		isUseFileImportTemplate: function() {
			return this.getIsFeatureEnabled("UseFileImportTemplate");
		},

		loadImportTemplateId: function(importSessionId, callback, scope) {
			this.callImportTemplateService({
				methodName: "GetImportTemplateId",
				data: {importSessionId: importSessionId},
				callback: function(response) {
					this.Ext.callback(callback, scope || this, [response.importTemplateId]);
				},
				scope: this
			});
		},

		saveImportTemplateId: function(request, callback, scope) {
			request.importTemplateId = request.importTemplateId || this.BPMSoft.GUID_EMPTY;
			this.callImportTemplateService({
				"methodName": "SetImportTemplateId",
				"data": {
					"request": request
				},
				"callback": function() {
					this.Ext.callback(callback, scope || this);
				},
				"scope": this
			});
		},

		callImportTemplateService: function(requestConfig) {
			var methodName = requestConfig.methodName;
			var resultKey = methodName + "Result";
			this.callService({
				serviceName: "FileImportTemplateService",
				methodName: methodName,
				data: requestConfig.data
			}, function(response) {
				var responseData = response && response[resultKey] || {};
				if (responseData.success) {
					this.Ext.callback(requestConfig.callback, requestConfig.scope, [responseData]);
				}
			}, this);
		},

		loadImportTemplateAdditionalData: function(importTemplateId, callback, scope) {
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "FileImportTemplate"
			});
			esq.addColumn("Name");
			esq.addColumn("EntitySchemaUId");
			esq.getEntity(importTemplateId, function(result) {
				if (result && result.success) {
					var entity = result.entity;
					this.Ext.callback(callback, scope || this, [entity.get('Name'), entity.get('EntitySchemaUId')]);
				} else {
					this.Ext.callback(callback, scope || this);
				}
			}, this);
		},

		// endregion

	});
});
 