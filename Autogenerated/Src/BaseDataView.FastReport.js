define("BaseDataView", ["BaseSchemaModuleV2", "FastReportService"], function() {
	return {
		properties: {
			fastReportType: "FastReport"
		},
		methods: {

			_createReportGenerationConfig: function(printForm, filters) {
				return {
					templateId: printForm.$SysReportSchemaUId,
					caption: printForm.$Caption,
					entitySchemaName: this.entitySchema.name,
					filters: filters
				};
			},

			_generateReport: function(printForm, filters) {
				this.showBodyMask();
				const fastReportService = Ext.create("BPMSoft.FastReportService");
				fastReportService.generateReport(this._createReportGenerationConfig(printForm, filters), function() {
					this.hideBodyMask();
				}, this);
			},

			_refreshHistoryState: function() {
				const historyState = this.sandbox.publish("GetHistoryState");
				const moduleState = Ext.apply({hash: historyState.hash.historyState}, {});
				this.sandbox.publish("PushHistoryState", moduleState);
			},

			_showReportFilterPage: function(reportFilterPageSchemaName) {
				this._refreshHistoryState();
				this.sandbox.loadModule("BaseSchemaModuleV2", {
					id: "ReportFilterPage",
					renderTo: this.renderTo,
					keepAlive: true,
					instanceConfig: {
						useHistoryState: false,
						isSchemaConfigInitialized: true,
						schemaName: reportFilterPageSchemaName
					}
				});
			},

			_generateReportUsingReportFilterPage: function(printForm) {
				this.set("CurrentReportId", printForm.$Id);
				this._showReportFilterPage(printForm.$OptionSchemaName);
			},

			_generateReportUsingSectionFilters: function(printForm) {
				const filters = this.getFilters();
				if (filters.getIsEnabled()) {
					this._generateReport(printForm, filters);
				} else {
					const message = this.get("Resources.Strings.GenerateReportWithoutFiltersConfirmationMessage");
					this.showConfirmationDialog(message, function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							this._generateReport(printForm, filters);
						}
					}, [BPMSoft.MessageBoxButtons.YES.returnCode, BPMSoft.MessageBoxButtons.NO.returnCode]);
				}
			},

			generatePrintForm: function(printForm) {
				if (printForm.$PrintFormType === this.fastReportType) {
					const filters = this.getReportFilters();
					this._generateReport(printForm, filters);
				} else {
					return this.callParent(arguments);
				}
			},

			getAdditionalSupportedReportTypes: function() {
				return [this.fastReportType];
			},

			processReportItem: function(entity) {
				this.callParent(arguments);
				if (entity.$PrintFormType === this.fastReportType) {
					entity.set("Click", {"bindTo": "generateFrReport"});
					entity.$SysReportSchemaUId = entity.$SysSchemaUId;
				}
			},

			generateFrReport: function(tag) {
				const moduleReportsCollection = this.get(this.moduleReportsCollectionName);
				const printForm = moduleReportsCollection.get(tag);
				if (printForm.$OptionSchemaName) {
					this._generateReportUsingReportFilterPage(printForm);
				} else {
					this._generateReportUsingSectionFilters(printForm);
				}
			}

		}
	};
});
