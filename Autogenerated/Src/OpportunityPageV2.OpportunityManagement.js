define("OpportunityPageV2", ["ProcessModuleUtilities", "OppManagementMigrationUtils"],
		function(ProcessModuleUtilities) {
	return {
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		mixins: {
			"OppManagementMigrationUtils": "BPMSoft.OppManagementMigrationUtils"
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.OpportunityPageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initOldProcessUsageState(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.OpportunityPageV2#getActions
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.OpportunityManagementItemCaption"},
					"Enabled": {"bindTo": "canEntityBeOperated"},
					"Tag": "runOpportunityManagementProcess"
				}));
				return actionMenuItems;
			},

			/**
			 * @obsolete
			 * @protected
			 */
			OpportunityManagement: function() {
				this.log(this.Ext.String.format(this.BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
					"OpportunityManagement", "runOpportunityManagementProcess"));
				this.runOpportunityManagementProcess.apply(this, arguments);
			},

			/**
			 * Runs the business-process OpportunityManagement.
			 * @protected
			 */
			runOpportunityManagementProcess: function() {
				var sysSettingName = "OpportunityManagementProcess";
				var currentOpportunityId = this.get("Id");
				if (!currentOpportunityId) {
					var invalidMessage = this.get("Resources.Strings.CurrentOpportunityNotFound");
					this.BPMSoft.showInformation(invalidMessage);
					return;
				}
				var useOldProcess = this.isOldProcessEnabled();
				if (useOldProcess) {
					BPMSoft.SysSettings.querySysSettings([sysSettingName],
						function(result) {
							var processId = result[sysSettingName];
							this.runOldOpportunityManagementProcess(currentOpportunityId, processId,
								this.Ext.emptyFn, this);
						}, this);
				} else {
					this.runOpportunityManagement78Process(this.Ext.emptyFn, this);
				}
			},

			/**
			 * Returns true if there is ability to start sales process.
			 * @private
			 * @return {Boolean}
			 */
			canStartOpportunityManagementProcess: function() {
				var processListenersCount = this.get("ProcessListeners");
				if (Number(processListenersCount) === 0) {
					return true;
				}
				var byProcess = this.get("ByProcess");
				return !Boolean(byProcess);
			},

			/**
			 * Starts new opportunity management process.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			runOpportunityManagement78Process: function(callback, scope) {
				if (this.canStartOpportunityManagementProcess()) {
					this.set("ByProcess", true);
					this.save({
						scope: this,
						isSilent: true,
						callback: this.onOpportunityManagementProcessStarted.bind(this, callback, scope)
					});
				} else {
					var message = this.get("Resources.Strings.ProcessAlreadyRunning");
					this.BPMSoft.showInformation(message);
				}
			},

			/**
			 * Reloads record after opportunity management process was started.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			onOpportunityManagementProcessStarted: function(callback, scope) {
				this.reloadEntity(function() {
					this.reloadActionsDashboardItems(callback, scope);
				}, this);
			},

			/**
			 * Returns {@link BPMSoft.EntitySchemaQuery} for active process.
			 * @private
			 * @param {String} processIdValue Id column.
			 * @return {BPMSoft.EntitySchemaQuery}
			 */
			getActiveProcessCountEsq: function(processIdValue) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysProcessEntity"
				});
				esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "EntityId", this.get("Id")));
				esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[SysProcessData:Id:SysProcess].SysSchema.UId", processIdValue));
				return esq;
			},

			/**
			 * Returns {@link BPMSoft.ProcessModuleUtilities} class.
			 * @private
			 * @return {BPMSoft.ProcessModuleUtilities}.
			 */
			getProcessModuleUtils: function() {
				return ProcessModuleUtilities;
			},

			/**
			 * Starts Opportunity management process with record id parameter.
			 * @private
			 * @param {String} processIdValue Id of process.
			 * @param {String} currentOpportunityId Current record id.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			runOpportunityManagementProcessById: function(processIdValue, currentOpportunityId, callback, scope) {
				var processModuleUtilities = this.getProcessModuleUtils();
				processModuleUtilities.executeProcess({
					sysProcessId: processIdValue,
					parameters: {
						CurrentOpportunity: currentOpportunityId
					},
					callback: function() {
						this.reloadActionsDashboardItems();
						this.Ext.callback(callback, scope);
					},
					scope: this
				});
			},

			/**
			 * Starts old opportunity management process.
			 * @private
			 * @param {String} currentOpportunityId Current record id column value.
			 * @param {String} processId Old process schema id.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			runOldOpportunityManagementProcess: function(currentOpportunityId, processId, callback, scope) {
				if (this.Ext.isEmpty(processId)) {
					var invalidMessage = this.get("Resources.Strings.ProcessNotFound");
					this.BPMSoft.showInformation(invalidMessage);
					return;
				}
				var processIdValue = this.Ext.isObject(processId) ? processId.value : processId;
				var esq = this.getActiveProcessCountEsq(processIdValue);
				esq.getEntityCollection(function(response) {
					var allowExecuteProcess = false;
					if (response.success) {
						var collection = response.collection;
						if (collection && collection.getCount() > 0) {
							if (collection.getByIndex(0).get("Count") === 0) {
								allowExecuteProcess = true;
							}
						}
					}
					if (allowExecuteProcess === true) {
						this.runOpportunityManagementProcessById(processIdValue, currentOpportunityId,
							callback, scope);
					} else {
						var message = this.get("Resources.Strings.ProcessAlreadyRunning");
						this.BPMSoft.showInformation(message);
						this.Ext.callback(callback, scope);
					}
				}, this);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});