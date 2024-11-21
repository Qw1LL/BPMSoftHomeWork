define("BaseReportFilterPage", ["ConfigurationServiceProvider", "FastReportService", "css!BaseReportFilterPageCSS"], function() {
	return {
		messages: {
			"BackHistoryState": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.BROADCAST
			},
			"GetReportConfig": {
				"direction": BPMSoft.MessageDirectionType.PUBLISH,
				"mode": BPMSoft.MessageMode.PTP
			}
		},
		
		methods: {

			// region Methods: Private

			/**
			 * @private
			 * @return {Object}
			 */
			_getGenerationConfig: function() {
				const reportConfig = this.publishGetReportConfigMessage();
				const filters = this.getFilters();
				if (!filters) {
					throw new Ext.create("BPMSoft.NullOrEmptyException");
				}
				return {
					templateId: reportConfig.reportId,
					caption: reportConfig.caption,
					entitySchemaName: reportConfig.sectionEntitySchemaName,
					filters: filters
				};
			},

			_getGoogleTag: function(printForm) {
				const reportType = printForm.ReportType;
				return reportType + " isPdf";
			},

			_getGoogleTagManagerData: function (tag) {
				const sandbox = this.sandbox;
				return {
					action: tag,
					schemaName: this.name,
					moduleName: sandbox.moduleName,
					virtualUrl: this.BPMSoft.workspaceBaseUrl + "/" + sandbox.id
				};
			},

			_sendAnalytics: function (printForm) {
				const isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
				if (!isGoogleTagManagerEnabled) {
					return;
				}
				const tag = this._getGoogleTag(printForm);
				const data = this._getGoogleTagManagerData(tag);
				BPMSoft.GoogleTagManagerUtilities.actionModule(data);
			},
			
			// endregion

			// region Methods: Protected

			/**
			 * @protected
			 * @return {Object}
			 */
			publishGetReportConfigMessage: function() {
				return this.sandbox.publish("GetReportConfig", null, ["GetReportConfigKey"]);
			},

			/**
			 * Returns report filter.
			 * @protected
			 * @abstract
			 * @return {BPMSoft.FilterGroup}
			 */
			getFilters: BPMSoft.abstractFn,

			// endregion

			// region Methods: Public

			/**
			 * Returns report filter page caption.
			 * @public
			 * @return {String}
			 */
			getReportCaption: function() {
				const reportConfig = this.publishGetReportConfigMessage();
				return reportConfig.caption;
			},

			/**
			 * Generates and downloads report.
			 * @public
			 */
			createReport: function() {
				const fastReportService = Ext.create("BPMSoft.FastReportService");
				const reportConfig = this._getGenerationConfig();
				this._sendAnalytics(reportConfig);
				fastReportService.generateReport(reportConfig);
			},

			/**
			 * Closes report filter page.
			 * @public
			 */
			closePage: function() {
				this.sandbox.publish("BackHistoryState");
			}

			// endregion

		},

		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,

		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,

		diff: /**SCHEMA_DIFF*/[{
			"operation": "insert",
			"name": "MainContainer",
			"values": {
				"id": "MainContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["section-wrap", "report-filter-page-main-container"],
				"items": []
			}
		}, 
		{
			"operation": "insert",
			"name": "ActionButtonsContainer",
			"parentName": "MainContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"id": "ActionButtonsContainer",
				"selectors": {"wrapEl": "#ActionButtonsContainer"},
				"wrapClass": ["action-buttons-container-wrapClass"],
				"items": []
			}
		},
		{
			"operation": "insert",
			"name": "SectionHeaderContainer",
			"parentName": "ActionButtonsContainer",
			"propertyName": "items",
			"index": 0,
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"id": "SectionHeaderContainer",
				"selectors": {"wrapEl": "#SectionHeaderContainer"},
				"wrapClass": ["report-section-header-container-wrapClass"],
				"items": []
			}
		},
		{
			"operation": "insert",
			"name": "ReportCaptionLabel",
			"parentName": "SectionHeaderContainer",
			"propertyName": "items",
			"values": {
				"id": "ReportCaptionLabel",
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {"bindTo": "getReportCaption"},
				"classes": {
					"labelClass": ["report-filter-page-caption"]
				}
			}
		}, 
		{
			"operation": "insert",
			"name": "SeparateModeActionsButtonContainer",
			"parentName": "ActionButtonsContainer",
			"propertyName": "items",
			"values": {
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"id": "SeparateModeActionsButtonContainer",
				"selectors": {"wrapEl": "#SeparateModeActionsButtonContainer"},
				"wrapClass": ["report-section-separate-container-wrapClass"],
				"items": []
			}
		},
		{
			"operation": "insert",
			"name": "CreateReportButton",
			"parentName": "SeparateModeActionsButtonContainer",
			"propertyName": "items",
			"values": {
				"id": "CreateReportButton",
				"itemType": BPMSoft.ViewItemType.BUTTON,
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"caption": {"bindTo": "Resources.Strings.CreateReportButtonCaption"},
				"click": {"bindTo": "createReport"}
			}
		}, 
		{
			"operation": "insert",
			"name": "CancelButton",
			"parentName": "SeparateModeActionsButtonContainer",
			"propertyName": "items",
			"values": {
				"id": "CancelButton",
				"itemType": BPMSoft.ViewItemType.BUTTON,
				"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
				"click": {"bindTo": "closePage"}
			}
		}, 
		{
			"operation": "insert",
			"name": "FilterContainer",
			"parentName": "MainContainer",
			"propertyName": "items",
			"values": {
				"id": "FilterContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"items": [],
				"wrapClass": ["report-filter-page-filter-container"],
			}
		}]/**SCHEMA_DIFF*/
	};
});
