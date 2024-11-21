define("PivotDashboardGridModule", ["DashboardGridModule", "css!DashboardGridModule",
		"PivotTableViewModel", "PivotTableUtilities"],
	function() {

		/**
		 * @class BPMSoft.configuration.PivotDashboardGridModule
		 * Class of dashboard grid module.
		 */
		Ext.define("BPMSoft.configuration.PivotDashboardGridModule", {
			extend: "BPMSoft.DashboardGridModule",
			alternateClassName: "BPMSoft.PivotDashboardGridModule",

			/**
			 * @inheritDoc BPMSoft.BaseModule#init
			 * @override
			 */
			init: function() {
				this.sandbox.registerMessages({
					"GetDashboardGridConfig": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"GenerateDashboardGrid": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"UpdateFilter": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"GetFiltersCollection": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					"GetSectionFilterModuleId": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				});
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initConfig: function() {
				this.callParent(arguments);
				if (!this.canRenderPivotTable()) {
					return;
				}
				this.viewModelClassName = "BPMSoft.PivotTableViewModel";
				this.viewConfigClassName = "BPMSoft.PivotTableViewConfig";
			},

			/**
			 * Checks can render pivot table component.
			 * @protected
			 */
			canRenderPivotTable: function() {
				const pivotTableConfig = JSON.parse(this.moduleConfig.pivotTableConfig || "{}");
				const isValidPivotConfig = BPMSoft.PivotTableUtilities
						.validatePivotConfig(pivotTableConfig);
				const isEnabledPivotTable = BPMSoft.PivotTableUtilities.isEnabledPivotTable();
				return isValidPivotConfig && isEnabledPivotTable;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initViewConfig: function() {
				if (!this.canRenderPivotTable()) {
					this.callParent(arguments);
					return;
				}
				const parentMethod = this.getParentMethod();
				const parentMethodArgs = arguments;
				this._requirePivotViewConfig(parentMethod, this, parentMethodArgs);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values = config.values || {};
				config.values.TableId = this.renderToId;
				return config;
			},

			_requirePivotViewConfig: function(callback, scope, callbackArgs) {
				BPMSoft.require(["PivotTableViewConfig"], function() {
					Ext.callback(callback, scope || this, callbackArgs);
				}, this);
			}
		});

		return BPMSoft.PivotDashboardGridModule;
	});
