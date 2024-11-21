define("BasePageV2", ["FastReportService"], function() {
	return {
		methods: {

			_createReportGenerationConfig: function(printForm) {
				return {
					templateId: printForm.$SysReportSchemaUId,
					caption: printForm.$Caption,
					entitySchemaName: this.entitySchema.name,
					filters: this.getReportFilters()
				};
			},

			_generateFastReportPrintFrom: function(printForm, callback, scope) {
				const fastReportService = Ext.create("BPMSoft.FastReportService");
				fastReportService.generateReport(this._createReportGenerationConfig(printForm), callback, scope);
			},

			generatePrintForm: function(printForm) {
				if (printForm.$PrintFormType === "FastReport") {
					this.showBodyMask();
					this._generateFastReportPrintFrom(printForm, function() {
						this.hideBodyMask();
					}, this);
				} else {
					return this.callParent(arguments);
				}
			},

			getAdditionalSupportedReportTypes: function() {
				return ["FastReport"];
			}

		}
	};
});
