define("SupervisorSingleWindowSectionV2", ["ProcessModuleUtilities", "ModuleUtils", "QueueClientNotificationUtilities",
	"NetworkUtilities", "ServiceHelper"],
		function(ProcessModuleUtilities, moduleUtils, QueueClientNotificationUtilities, NetworkUtilities,
				ServiceHelper) {
			return {
				entitySchemaName: "Queue",
				queueItemEntitySchemaName: "QueueItem",
				attributes: {
					/**
					 * Queues module name.
					 * @type {String}
					 */
					"QueuesModuleName": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"value": "QueueItemSection"
					},

					/**
					 * Queues view name.
					 * @type {String}
					 */
					"QueuesDataViewName": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"value": "QueuesDataView"
					}
				},
				methods: {

					//region Methods: Private

					/**
					 * ######### ########## ######## ########.
					 * @private
					 */
					openQueueObjectLookupPage: function() {
						if (this.getIsFeatureDisabled("NewQueueSortingUI")) {
							const select = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "VwSysSchemaInfo",
								rowCount: 1
							});
							select.isDistinct = true;
							select.addColumn("UId");
							const filterCollection = BPMSoft.createFilterGroup();
							filterCollection.add("SysWorkspaceFilter", BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "SysWorkspace", BPMSoft.SysValue.CURRENT_WORKSPACE.value));
							filterCollection.add("ExtendParentFilter", BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "ExtendParent", false));
							filterCollection.add("NameFilter", BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Name", "QueueObjectLookupPage"));
							select.filters.add(filterCollection);
							select.getEntityCollection(function(result) {
								if (!result.success) {
									return;
								}
								const collection = result.collection;
								if (collection.getCount() > 0) {
									const item = collection.first();
									const url = Ext.String.format("{0}/ViewPage.aspx?Id={1}&editMode=true", 
										BPMSoft.workspaceBaseUrl, item.get("UId"));
									this.openWindow(url, "_blank");
								}
							}, this);
						} else {
							NetworkUtilities.openSectionInNewUI({
								entitySchemaName: "QueueSorting"
							});
						}
					},

					/**
					 * ######### ####### ########## ######## ####### ####.
					 * @private
					 */
					updateQueues: function() {
						this.showBodyMask();
						ServiceHelper.callService({
							"serviceName": "QueuesUpdateService",
							"methodName": "ScheduleQueuesUpdateProcess",
							"callback": function(response) {
								this.hideBodyMask();
								const message = response
									? this.get("Resources.Strings.QueuesUpdateProcessStarted")
									: this.get("Resources.Strings.QueuesUpdateProcessAlreadyStarted");
								this.showInformationDialog(message);
							},
							"scope": this
						});
						
					},

					//endregion

					//region Methods: Protected

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([function() {
							QueueClientNotificationUtilities.subscribeForQueuesNotifications();
							callback.call(scope);
						}, this]);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultGridDataViewCaption
					 * @overridden
					 */
					getDefaultGridDataViewCaption: function() {
						return this.get("Resources.Strings.GridDataViewCaption");
					},

					/**
					 * Calls window.open function with parameters.
					 * @protected
					 * @param {String} url Url to open.
					 * @param {String} target Target to open url.
					 */
					openWindow: function(url, target) {
						window.open(url, target);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
					 * @overridden
					 */
					getSectionActions: function() {
						var actionMenuItems = this.callParent(arguments);
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Click": {"bindTo": "openQueueObjectLookupPage"},
							"Caption": {"bindTo": "Resources.Strings.OpenQueueObjectLookupPageActionCaption"}
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							"Click": {"bindTo": "updateQueues"},
							"Caption": {"bindTo": "Resources.Strings.UpdateQueuesActionCaption"}
						}));
						return actionMenuItems;
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultAnalyticsDataViewCaption
					 * @overridden
					 */
					getDefaultAnalyticsDataViewCaption: function() {
						return this.get("Resources.Strings.AnalyticsDataViewCaption");
					},

					/**
					 * @inheritdoc BaseSectionV2#getDefaultDataViews
					 * @overridden
					 */
					getDefaultDataViews: function() {
						var gridDataViews = this.callParent();
						var defaultGridDataViewCaption = this.getDefaultGridDataViewCaption();
						var queueDataViewCaption = this.get("Resources.Strings.QueueDataViewCaption");
						gridDataViews.QueuesDataView = {
							"index": 0,
							"name": this.get("QueuesDataViewName"),
							"icon": this.getDefaultGridDataViewIcon(),
							"hint": queueDataViewCaption,
							"markerValue": queueDataViewCaption
						};
						Ext.apply(gridDataViews.GridDataView, {
							"index": 1,
							"active": true,
							"icon": this.get("Resources.Images.QueuesSettingsDataViewIcon"),
							"hint": defaultGridDataViewCaption,
							"markerValue": defaultGridDataViewCaption
						});
						Ext.apply(gridDataViews.AnalyticsDataView, {
							"index": 2
						});
						return gridDataViews;
					},

					/**
					 * @inheritdoc BaseSectionV2#changeDataView
					 * @overridden
					 */
					changeDataView: function(view) {
						if (view.tag !== this.get("GridDataViewName")) {
							this.loadQueuesDataView(view.tag);
						} else {
							this.callParent(arguments);
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#initContextHelp
					 * @overridden
					 */
					initContextHelp: function() {
						this.set("ContextHelpId", 1073);
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#getModuleStructure
					 * @overridden
					 */
					getModuleStructure: function(moduleName) {
						return moduleUtils.getModuleStructureByName(moduleName || this.queueItemEntitySchemaName);
					},

					/**
					 * Gets queue active view name.
					 * @param {String} viewName View name.
					 * @return {String} Active view name.
					 */
					getQueueViewName: function(viewName) {
						return viewName === this.get("QueuesDataViewName")
								? this.get("GridDataViewName")
								: this.get("AnalyticsDataViewName");
					},

					/**
					 * Loads queues settings view.
					 * @protected
					 * @param {String} viewName View name.
					 */
					loadQueuesDataView: function(viewName) {
						var queuesViewName = this.getQueueViewName(viewName);
						var queuesModuleName = this.get("QueuesModuleName");
						this.sandbox.publish("PushHistoryState", {
							hash: this.BPMSoft.combinePath("SectionModuleV2", queuesModuleName),
							stateObj: {
								module: "SectionModuleV2",
								schemas: [queuesModuleName],
								ActiveViewName: queuesViewName
							}
						});
					}

					//endregion

				},
				diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
			};
		});
