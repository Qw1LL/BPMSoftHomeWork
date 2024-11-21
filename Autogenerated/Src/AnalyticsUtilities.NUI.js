define("AnalyticsUtilities", ["BPMSoft", "LocalizationUtilities", "SysModuleAnalyticsReport",
	"AnalyticsUtilitiesResources", "AnalyticsGridRowViewModel"],
	function(BPMSoft, LocalizationUtilities, SysModuleAnalyticsReport) {
		var AnalyticsUtilitiesClass = Ext.define("BPMSoft.configuration.mixins.AnalyticsUtilities", {

			alternateClassName: "BPMSoft.AnalyticsUtilities",

			/**
			 * ######### ###### ### ######### ###### #######.
			 * @protected
			 * @param moduleSchemaName ### ##### #######.
			 * @return {BPMSoft.EntitySchemaQuery|*} ############# ######.
			 */
			getPrintFormsSelectQuery: function(moduleSchemaName) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: SysModuleAnalyticsReport
				});
				LocalizationUtilities.addLocalizableColumn(esq, "Caption");
				esq.addColumn("SysSchemaUId");
				esq.addColumn("[VwSysSchemaInWorkspace:UId:SysOptionsPageSchemaUId].Name", "OptionSchemaName");
				var filters = Ext.create("BPMSoft.FilterGroup");
				filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ModuleSchemaName", moduleSchemaName));
				var workspaceIdFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"[VwSysSchemaInWorkspace:UId:SysOptionsPageSchemaUId].SysWorkspace.Id",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value);
				filters.add("workspaceIdFilter", workspaceIdFilter);
				esq.filters = filters;
				return esq;
			},

			/**
			 * ######## ###### ######### ####### ### ########## #######.
			 * @protected
			 * @param moduleSchemaName ### ##### #######.
			 */
			getCurrentModuleReports: function(moduleSchemaName) {
				if (!this.get("ReportGridData").isEmpty()) {
					this.set("ReportActiveRow", null);
					return;
				}
				var esq = this.getPrintFormsSelectQuery(moduleSchemaName);
				esq.getEntityCollection(function(response) {
					var collection = this.get("ReportGridData");
					var entities = response.collection;
					if (response.success && !entities.isEmpty()) {
						var getLookupImageUrl = function() {
							var primaryImageColumnValue = this.get("Logo");
							if (!primaryImageColumnValue) {
								return null;
							}
							return this.getSchemaImageUrl();
						};
						entities.each(function(entity) {
							if (entity) {
								entity.getLookupImageUrl = getLookupImageUrl;
								entity.set("Click", {"bindTo": "loadReportModule"});
								entity.set("Tag", entity.get("Id"));
							}
						}, this);
						collection.loadAll(entities);
					}
					this.set("IsEmptyReports", collection.isEmpty());
				}, this);
			},

			/**
			 * ######### ###### #######.
			 * @protected
			 * @param key ############# ######.
			 */
			loadReportModule: function(key) {
				var grid = this.get("ReportGridData");
				var activeReport = grid.get(key);
				var reportConfig = {
					id: activeReport.get("Id"),
					caption: activeReport.get("Caption"),
					reportId: activeReport.get("SysSchemaUId"),
					sysSchemaName: activeReport.get("OptionSchemaName"),
					sectionUId: this.entitySchema.uId,
					activeRow: this.get("ActiveRow"),
					selectedRows: this.get("SelectedRows"),
					type: "DevExpress",
					parentModuleSandboxId: this.sandbox.id
				};
				var reportModuleId = this.sandbox.id + "_ReportModule";
				this.sandbox.subscribe("GetReportId", function() {
					return key;
				}, [reportModuleId]);
				this.sandbox.subscribe("GetReportConfig", function() {
					return reportConfig;
				}, ["GetReportConfigKey"]);
				var historyState = this.sandbox.publish("GetHistoryState");
				var moduleState = Ext.apply({ hash: historyState.hash.historyState }, {});
				this.sandbox.publish("PushHistoryState", moduleState);
				var reportRenderTo = "centerPanel";
				this.sandbox.loadModule("ReportModule", {
					id: reportModuleId,
					renderTo: reportRenderTo,
					keepAlive: true
				});
			},

			/**
			 * ############## ######### ####### ###### ########.
			 * @protected
			 */
			initAnalyticsGridData: function() {
				this.set("AnalyticsGridData", this.Ext.create("BPMSoft.Collection"));
			},

			/**
			 * ############## ######### ####### ###### #######.
			 * @protected
			 */
			initReportGridData: function() {
				this.set("ReportGridData", this.Ext.create("BPMSoft.Collection"));
				this.getCurrentModuleReports(this.entitySchema.name);
			},

			/**
			 * ########## ######### ############# ####### ## #########.
			 * @protected
			 * @return {String} ########## ######### ############# ####### ## #########.
			 */
			getDefaultAnalyticsDataViewCaption: function() {
				var moduleStructure = BPMSoft.configuration.ModuleStructure[this.entitySchemaName];
				return moduleStructure.moduleCaption;
			},

			/**
			 * ########## ###### ############# ####### ## #########.
			 * @protected
			 */
			getDefaultAnalyticsDataViewIcon: function() {
				return this.get("Resources.Images.AnalyticsDataViewIcon");
			}

		});
		return Ext.create(AnalyticsUtilitiesClass);
	});
