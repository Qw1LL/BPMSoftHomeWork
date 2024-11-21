define("SysOperationAuditArchiveSectionV2", ["BaseFiltersGenerateModule", "SysOperationAuditArch",
	"RightUtilities"],
function(BaseFiltersGenerateModule, SysOperationAuditArch, RightUtilities) {
	return {
		entitySchemaName: "SysOperationAuditArch",
		attributes: {
			/**
			 * Can manage audit log system operation name.
			 */
			"SecurityOperationName": {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanViewSysOperationAudit"
			}
		},
		methods: {
			/**
			 * @inheritdoc Configuration.BasePageV2#initContextHelp
			 * @override
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1260);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BaseSectionV2#isMultiSelectVisible
			 * @override
			 */
			isMultiSelectVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BaseSectionV2#getExportToFileActionVisibility
			 * @override
			 */
			getExportToFileActionVisibility: function() {
				return false;
			},

			/**
			 * @override
			 * @inheritDoc BaseSectionV2#initFixedFiltersConfig
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: SysOperationAuditArch,
					filters: [
						{
							name: "PeriodFilter",
							caption: this.get("Resources.Strings.PeriodFilterCaption"),
							dataValueType: this.BPMSoft.DataValueType.DATE,
							columnName: "Date",
							startDate: {},
							dueDate: {}
						},
						{
							name: "Owner",
							caption: this.get("Resources.Strings.OwnerFilterCaption"),
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							filter: BaseFiltersGenerateModule.OwnerFilter,
							columnName: "Owner"
						}
					]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			},

			/**
			 * @override
			 * @inheritDoc BaseViewModule#init
			 */
			init: function() {
				this.initCanManageSysOperationAudit();
				this.callParent(arguments);
			},

			/**
			 * Initialize Can manage audit log system operation.
			 * @protected
			 */
			initCanManageSysOperationAudit: function() {
				RightUtilities.checkCanExecuteOperation({
					operation: "CanManageSysOperationAudit"
				}, function(result) {
					this.set("canManageSysAuditOperationsSection", result);
				}, this);
			},

			/**
			 * @override
			 * @inheritDoc BaseSectionV2#getDefaultGridDataViewCaption
			 */
			getDefaultGridDataViewCaption: function() {
				return this.get("Resources.Strings.ArchiveSectionViewCaption");
			},

			/**
			 * Returns audit log caption.
			 * @protected
			 * @return {string} Audit log caption.
			 */
			getSysOperationAuditViewCaption: function() {
				return this.get("Resources.Strings.AuditSectionViewCaption");
			},

			/**
			 * Returns archive audit log icon.
			 * @protected
			 * @return {object} Archive audit log icon.
			 */
			getSysOperationAuditArchViewIcon: function() {
				return this.get("Resources.Images.SysOperationAuditArchViewIcon");
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				dataViews.GridDataView.hint = dataViews.GridDataView.caption = this.getDefaultGridDataViewCaption();
				dataViews.GridDataView.index = 1;
				dataViews.GridDataView.active = true;
				dataViews.GridDataView.icon = this.getSysOperationAuditArchViewIcon();
				var auditCaption = this.getSysOperationAuditViewCaption();
				var auditGridDataView = {
					index: 0,
					name: "AuditGridDataView",
					caption: auditCaption,
					icon: this.getDefaultGridDataViewIcon(),
					hint: auditCaption
				};
				return {
					"AuditGridDataView": auditGridDataView,
					"GridDataView": dataViews.GridDataView
				};
			},

			/**
			 * Move to audit log section.
			 * @protected
			 */
			moveToAuditSection: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: this.BPMSoft.combinePath("SectionModuleV2", "SysOperationAuditSectionV2"),
					stateObj: {
						module: "SectionModuleV2",
						schemas: ["SysOperationAuditSectionV2"]
					}
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSection#changeDataView
			 * @override
			 */
			changeDataView: function(viewConfig) {
				if (viewConfig.tag === "AuditGridDataView") {
					this.moveToAuditSection();
				} else {
					this.callParent(arguments);
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowOpenAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowDeleteAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "remove",
				"name": "CombinedModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "SeparateModeActionsButton"
			},
			{
				"operation": "remove",
				"name": "DeleteRecordMenuItem"
			}
		]/**SCHEMA_DIFF*/
	};
});
