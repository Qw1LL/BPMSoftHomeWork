/**
 * Parent: BaseModulePageV2
 */
define("BaseVwProcessLibPageV2", ["BaseVwProcessLibPageV2Resources", "GeneralDetails", "InformationButtonResources",
	"css!BaseVwProcessLibPageV2CSS"
], function(resources, GeneralDetails, InformationButtonResources) {
	return {
		entitySchemaName: "VwProcessLib",
		rules: {},
		userCode: {},
		details: /**SCHEMA_DETAILS*/{
			Files: {
				schemaName: "FileDetailV2",
				entitySchemaName: "VwProcessLibFile",
				filter: {
					masterColumn: "Id",
					detailColumn: "VwProcessLibFileId"
				}
			},
			ProcessInModules: {
				schemaName: "ProcessInModulesDetailV2",
				filter: {
					masterColumn: "VersionParentUId",
					detailColumn: "SysSchemaUId"
				}
			},
			ProcessInDetails: {
				schemaName: "ProcessInDetailsDetailV2",
				filter: {
					masterColumn: "VersionParentUId",
					detailColumn: "SysSchemaUId"
				}
			},
			SubProcessInProcess: {
				captionName: "SubProcessInProcessDetailCaption",
				profileKey: "VwProcessLibPageV2SubProcessInProcessDetail",
				schemaName: "BaseProcessSettingDetailV2",
				entitySchemaName: "VwSubProcessInProcess",
				filter: {
					masterColumn: "VersionParentUId",
					detailColumn: "ParentSubProcess"
				}
			},
			SubProcesses: {
				captionName: "SubProcessDetailCaption",
				profileKey: "VwProcessLibPageV2SubProcessDetail",
				schemaName: "SubProcessDetail",
				entitySchemaName: "VwSubProcessInProcess",
				filter: {
					masterColumn: "UId",
					detailColumn: "HostProcess"
				}
			},
			ProcessTimerScheduleDetail: {
				captionName: "TimerScheduleDetailCaption",
				profileKey: "VwProcessLibPageV2ProcessTimerScheduleDetailV2",
				schemaName: "ProcessTimerScheduleDetail"
			},
			ProcessStartEventDetail: {
				captionName: "ProcessStartEventCaption",
				profileKey: "VwProcessLibPageV2ProcessStartEventDetail",
				schemaName: "ProcessStartEventDetail",
				entitySchemaName: "VwProcessStartEvent",
				filter: {
					masterColumn: "UId",
					detailColumn: "ProcessUId"
				}
			},
			ProcessLog: {
				schemaName: "ProcessLogDetail",
				entitySchemaName: "VwSysProcessLog",
				filterMethod: "processLogDetailFilter"
			}
		}/**SCHEMA_DETAILS*/,
		messages: {
			/**
			 * @message ResetStartProcessMenuItems
			 * The message that you need to update the menu items of the button "Run the process"
			 */
			"ResetStartProcessMenuItems": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"LoadedItemsStartProcessMenu": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * The name of the operation access to which the user should have access to use the page.
			 */
			SecurityOperationName: {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanManageProcessDesign"
			},
			/**
			 * Tag for events on the process.
			 */
			ProcessActionTag: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			/**
			 * Process tracing active.
			 */
			IsTracing: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				onChange: "onIsTracingChanged",
				value: false
			},
			/**
			 * Process tracing info active.
			 */
			IsTracingInfoVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						this.set("IsSubscribed", false);
						Ext.callback(callback, scope);
					}, this
				]);
				this.sandbox.subscribe("LoadedItemsStartProcessMenu", function() {
					BPMSoft.ProcessModuleUtilities.hideBodyMask();
				});
				this.Ext.defer(this.warmUpProcessSchema, 0, this);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			initCardActionHandler: function() {
				this.callParent(arguments);
				this.on("change:Enabled", function(model, value) {
					this.sandbox.publish("CardChanged", {
						key: "Enabled",
						value: value
					}, [this.sandbox.id]);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
			 * @override
			 */
			onDiscardChangesClick: function() {
				const parentMethod = this.getParentMethod();
				const args = arguments;
				this.initTracingAttribute(function() {
					Ext.callback(parentMethod, this, args);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#getEntitySchemaQuery
			 * @override
			 */
			getEntitySchemaQuery: function() {
				const esq = this.callParent(arguments);
				const filterName = "WorkspaceFilter";
				const filters = esq.filters;
				if (filters.contains(filterName)) {
					return esq;
				}
				filters.add(filterName, BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
				const enablePrimaryColumnFilter = esq.enablePrimaryColumnFilter;
				esq.enablePrimaryColumnFilter = function() {
					enablePrimaryColumnFilter.apply(esq, arguments);
					const workspaceFilter = esq.filters.get(filterName);
					workspaceFilter.isEnabled = true;
				};
				return esq;
			},

			/**
			 * Returns details visible (toggling).
			 * @return {Boolean}
			 */
			getProcessInDetailsVisible: function() {
				return BPMSoft.ProcessEntryPointUtilities.getCanRunProcessFromSection();
			},

			/**
			 * @inheritdoc BasePageV2#addSectionDesignerViewOptions
			 * @override
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getActions
			 * @override
			 */
			getActions: function() {
				const actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": this.get("Resources.Strings.RunProcessActionCaption"),
					"Tag": "executeProcess",
					"Visible": {"bindTo": "Enabled"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.ProcessPropertiesDisableProcess"},
					"Visible": {"bindTo": "Enabled"},
					"Tag": "onDisableProcessPageClick"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.ProcessPropertiesEnableProcess"},
					"Visible": {
						"bindTo": "Enabled",
						"bindConfig": {
							"converter": function(value) {
								return value === false;
							}
						}
					},
					"Tag": "onEnableProcessPageClick"
				}));
				return actionMenuItems;
			},

			/**
			 * Deactivates the process.
			 */
			onDisableProcessPageClick: function() {
				const sysSchemaId = this.get("SysSchemaId");
				BPMSoft.ProcessModuleUtilities.disableProcess(sysSchemaId, this, this.onEnabledUpdated);
			},

			/**
			 * Activate process.
			 */
			onEnableProcessPageClick: function() {
				const sysSchemaId = this.get("SysSchemaId");
				BPMSoft.ProcessModuleUtilities.enableProcess(sysSchemaId, this, this.onEnabledUpdated);
			},

			/**
			 * Updates the card after performing an operation to activate / deactivate the process.
			 */
			onEnabledUpdated: function() {
				this.reloadEntity();
				this.sendSaveCardModuleResponse(true);
			},

			/**
			 * Opens the process designer.
			 * @protected
			 */
			onOpenProcessDesignerButtonClick: function() {
				const schemaUId = this.get(this.primaryColumnName);
				BPMSoft.ProcessModuleUtilities.showProcessSchemaDesigner(schemaUId);
				this.set("ProcessActionTag", "OpenProcess");
				this.sendGoogleTagManagerData();
			},

			/**
			 * Runs the business process for execution.
			 * @private
			 */
			executeProcess: function() {
				const processId = this.get(this.primaryColumnName);
				BPMSoft.ProcessModuleUtilities.executeProcess({
					"sysProcessId": processId
				});
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function(callback, scope) {
				this.callParent(arguments);
				if (this.isAddMode() || this.isCopyMode()) {
					this.set("Enabled", true);
					this.set("UId", this.get(this.primaryColumnName));
				}
				this.initTracingAttribute(callback, scope);
			},

			/**
			 * Performs a warmup of the process schema.
			 * @protected
			 */
			warmUpProcessSchema: function() {
				BPMSoft.chain(
					function(next) {
						BPMSoft.ProcessFlowElementSchemaManager.initialize(next, this);
					},
					function(next) {
						BPMSoft.ProcessSchemaManager.initialize(next, this);
					},
					function() {
						BPMSoft.ProcessSchemaManager.forceGetInstanceByUId(
							this.get("PrimaryColumnValue"),
							BPMSoft.emptyFn,
							this
						);
					},
					this
				);
			},

			/**
			 * Initializes a tracing attribute.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 * @protected
			 */
			initTracingAttribute: function(callback, scope) {
				BPMSoft.SysUserPropertyHelper.getProperty({
					schemaId: this.get("VersionParentId"),
					propertyName: "IsTracing",
					managerName: "ProcessSchemaManager"
				}, function(response) {
					if (response.success) {
						this.set("IsTracing", Boolean(JSON.parse(response.value || false)));
					} else {
						const message = this.get("Resources.Strings.TracingInitException");
						BPMSoft.showInformation(message);
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * Process the select event of the Publish process menu item.
			 * @private
			 */
			publish: function() {
				if (BPMSoft.ProcessModuleUtilities.getIsDemoMode(this)) {
					return;
				}
				BPMSoft.ProcessModuleUtilities.publish();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#onEntityInitialized
			 * @override
			 */
			getSubscribeButtonVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BPMSoft.BasePrintFormViewModel#initCardPrintForms
			 * @override
			 */
			initCardPrintForms: function(callback, scope) {
				const printMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.set(this.moduleCardPrintFormsCollectionName, printMenuItems);
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * @param callback
			 * @param scope
			 * @private
			 */
			_saveIsTracing: function(callback, scope) {
				if (this.isAttributeChanged("IsTracing")) {
					BPMSoft.SysUserPropertyHelper.setProperty({
						schemaId: this.get("VersionParentId"),
						propertyName: "IsTracing",
						propertyValue: this.get("IsTracing"),
						managerName: "ProcessSchemaManager"
					}, function(response) {
						if (!response.success) {
							const message = this.get("Resources.Strings.TracingSaveException");
							BPMSoft.showInformation(message);
						}
						Ext.callback(callback, scope);
					}, this);
				} else {
					Ext.callback(callback, scope);
				}
			},

			/**
			 * @param callback
			 * @param scope
			 * @private
			 */
			_saveRunButtonProcessList: function(callback, scope) {
				this.updateRunButtonProcessList(function(response) {
					this.sendSaveCardModuleResponse(response.success);
					if (response && response.success) {
						this.sandbox.publish("ResetStartProcessMenuItems");
					} else {
						BPMSoft.MaskHelper.HideBodyMask();
					}
					this.updateButtonsVisibility(false, {force: true});
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#save
			 * @override
			 */
			save: function(callback, scope) {
				BPMSoft.MaskHelper.ShowBodyMask();
				BPMSoft.chain(
					this._saveIsTracing,
					this._saveRunButtonProcessList,
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * Updates the information what processes to display in the menu items of the button "Start the process"
			 * @private
			 */
			updateRunButtonProcessList: function(callback, scope) {
				const entitySchemaName = "RunButtonProcessList";
				const deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: entitySchemaName
				});
				deleteQuery.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "SysSchemaUId", this.get("UId")));
				deleteQuery.execute(function(response) {
					if (this.get("AddToRunButton")) {
						var insert = Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: entitySchemaName
						});
						insert.setParameterValue("Id", BPMSoft.utils.generateGUID(),
							BPMSoft.DataValueType.GUID);
						insert.setParameterValue("SysSchemaUId", this.get("UId"), BPMSoft.DataValueType.GUID);
						insert.execute(callback, this);
						return;
					}
					callback.call(scope, response);
				}, this);
			},

			/**
			 * On tracing changed.
			 * @param {Object} model Model.
			 * @param {Boolean} isTracing New value.
			 */
			onIsTracingChanged: function(model, isTracing) {
				this.set("IsTracingInfoVisible", isTracing);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData.
			 * @override
			 */
			getGoogleTagManagerData: function() {
				const data = this.callParent(arguments);
				const processActionTag = this.get("ProcessActionTag");
				if (!this.Ext.isEmpty(processActionTag)) {
					this.Ext.apply(data, {
						action: processActionTag
					});
				}
				return data;
			},

			/**
			 * Creates filters for processLog detail.
			 */
			processLogDetailFilter: function() {
				return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"[VwProcessLib:SysSchemaId:SysSchemaId].VersionParentUId", this.get("VersionParentUId"));
			},

			/**
			 * Returns is tracing info button image config.
			 * @returns {Object} Image config.
			 */
			getTracingInfoButtonImageConfig: function() {
				const imageName = "TracingInfoButton";
				return InformationButtonResources.localizableImages[imageName];
			},

			/**
			 * Returns is tracing info button tip style.
			 * @returns {BPMSoft.TipStyle} Info button tip style.
			 */
			getTracingInfoTipStyle: function() {
				return this.get("IsTracing") ? BPMSoft.TipStyle.RED : BPMSoft.TipStyle.WHITE;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Caption",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Caption",
					"caption": {
						"bindTo": "Resources.Strings.CaptionCaption"
					},
					"textSize": "Default",
					"contentType": 1,
					"isRequired": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Name",
					"caption": {
						"bindTo": "Resources.Strings.NameCaption"
					},
					"textSize": "Default",
					"contentType": 1,
					"isRequired": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Enabled",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					},
					"bindTo": "Enabled",
					"caption": {
						"bindTo": "Resources.Strings.EnabledCaption"
					},
					"textSize": "Default"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "IsTracingContainer",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 6,
						"rowSpan": 1
					},
					"classes": {
						"wrapClassName": ["tracing-process-property-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsTracing",
				"parentName": "IsTracingContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "IsTracing",
					"caption": {"bindTo": "Resources.Strings.IsTracingCaption"},
					"labelConfig": {"markerValue": "IsTracingLabel"},
					"textSize": "Default",
					"classes": {
						"wrapClassName": ["checkbox-control-list-item"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsTracingInfo",
				"parentName": "IsTracingContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"behaviour": {"displayEvent": BPMSoft.TipDisplayEvent.CLICK},
					"visible": {"bindTo": "IsTracingInfoVisible"},
					"content": {"bindTo": "Resources.Strings.IsTracingInfo"},
					"style": {"bindTo": "getTracingInfoTipStyle"},
					"controlConfig": {
						"imageConfig": {"bindTo": "getTracingInfoButtonImageConfig"},
						"classes": {
							"wrapperClass": ["tracing-info-button"]
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "SysPackage",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "SysPackage",
					"caption": {
						"bindTo": "Resources.Strings.SysPackageCaption"
					},
					"textSize": "Default",
					"contentType": 3,
					"isRequired": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ModulesTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.RunningProcessesTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SubProcessesTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.SubProcessTabCaption"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ProcessLogTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.ProcessLogTabCaption"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ProcessLogTab",
				"propertyName": "items",
				"name": "ProcessLog",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "SubProcessesTab",
				"propertyName": "items",
				"name": "SubProcesses",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "remove",
				"name": "ESNTab"
			},
			{
				"operation": "insert",
				"parentName": "ModulesTab",
				"propertyName": "items",
				"name": "ProcessInModules",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "ModulesTab",
				"propertyName": "items",
				"name": "ProcessInDetails",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"visible": {"bindTo": "getProcessInDetailsVisible"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ModulesTab",
				"propertyName": "items",
				"name": "SubProcessInProcess",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "ModulesTab",
				"propertyName": "items",
				"name": "ProcessTimerScheduleDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "ModulesTab",
				"propertyName": "items",
				"name": "ProcessStartEventDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "OpenProcessDesignerButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
					"caption": {"bindTo": "Resources.Strings.OpenInDesignerButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onOpenProcessDesignerButtonClick"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
