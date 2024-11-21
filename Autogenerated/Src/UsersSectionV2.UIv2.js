define("UsersSectionV2", [
	"ConfigurationConstants", "ConfigurationEnums", "PortalRoleFilterUtilities", "RightUtilities",
	"ServiceHelper", "UsersSectionV2Resources", "GridUtilitiesV2", "css!AdministrationCSSV2", "ActualizationUtilities"
], function(ConfigurationConstants, ConfigurationEnums, PortalRoleFilterUtilities, RightUtilities, ServiceHelper) {
	return {
		entitySchemaName: "SysAdminUnit",
		contextHelpId: "259",
		diff: [
			{
				"operation": "merge",
				"name": "SectionWrapContainer",
				"values": {
					"wrapClass": ["UsersSectionV2", "section-wrap"]
				}
			},
			{
				"operation": "insert",
				"name": "DeleteButton",
				"parentName": "CombinedModeActionButtonsCardLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.DeleteRecordButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onDeleteClick"}
				}
			},
			{
				"operation": "insert",
				"name": "UserUnblockButton",
				"parentName": "UserUnblockButtonRightSectionContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.UnblockUserButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onUnblockClick"},
					"visible": {"bindTo": false},
					"hint": {"bindTo": "Resources.Strings.BlockedUserLabelCaption"}
				}
			},
			{
				"operation": "insert",
				"parentName": "CombinedModeActionButtonsSectionContainer",
				"propertyName": "items",
				"name": "CombinedModeAddOnlyEmployeeButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.AddRecordButtonCaption"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {"bindTo": "ShowAddOnlyEmployee"},
					"click": {"bindTo": "onAddOurCompanyUser"}
				}
			},
			{
				"operation": "merge",
				"parentName": "CombinedModeActionButtonsSectionContainer",
				"propertyName": "items",
				"name": "CombinedModeAddRecordButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.AddRecordButtonCaption"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"menu": [],
					"controlConfig": {},
					"visible": {"bindTo": "ShowAddPortalUser"}
				}
			},
			{
				"operation": "insert",
				"name": "CombinedModeAddPortalUser",
				"parentName": "CombinedModeAddRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddPortalUserButtonCaption"},
					"click": {"bindTo": "onAddPortalUser"}
				}
			},
			{
				"operation": "insert",
				"name": "CombinedModeAddOurCompanyUser",
				"parentName": "CombinedModeAddRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddOurCompanyUserButtonCaption"},
					"click": {"bindTo": "onAddOurCompanyUser"}
				}
			},
			{
				"operation": "insert",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"name": "SeparateModeAddOnlyEmployeeButton",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.AddRecordButtonCaption"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {"bindTo": "ShowAddOnlyEmployee"},
					"click": {"bindTo": "onAddOurCompanyUser"}
				}
			},
			{
				"operation": "merge",
				"parentName": "CombinedModeActionButtonsSectionContainer",
				"propertyName": "items",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.AddRecordButtonCaption"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"menu": [],
					"controlConfig": {},
					"visible": {"bindTo": "ShowAddPortalUser"}
				}
			},
			{
				"operation": "insert",
				"name": "SeparateModeAddPortalUser",
				"parentName": "SeparateModeAddRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddPortalUserButtonCaption"},
					"click": {"bindTo": "onAddPortalUser"}
				}
			},
			{
				"operation": "insert",
				"name": "SeparateModeAddOurCompanyUser",
				"parentName": "SeparateModeAddRecordButton",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.AddOurCompanyUserButtonCaption"},
					"click": {"bindTo": "onAddOurCompanyUser"}
				}
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "remove",
				"name": "CombinedModeActionsButton"
			},
			{
				"operation": "remove",
				"name": "CombinedModeViewOptionsButton"
			},
			{
				"operation": "insert",
				"parentName": "CombinedModeActionButtonsSectionContainer",
				"propertyName": "items",
				"name": "ActionsButtonCombinedMode",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.ActionsButtonCaption"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"menu": [],
					"controlConfig": {},
					"visible": {
						"bindTo": "CombinedModeActionsButtonVisible"
					}
				}
			},
			{
				"operation": "insert",
				"name": "CombinedModeActualize",
				"parentName": "ActionsButtonCombinedMode",
				"propertyName": "menu",
				"values": {
					"caption": {"bindTo": "Resources.Strings.ActualizeOrgStructureButtonCaption"},
					"click": {"bindTo": "onActualizeAdminUnitInRole"}
				}
			}
		],
		attributes: {
			/**
			 * ������� ������������� ������ ������������ ������ � ���� ��� ���������� �������������.
			 */
			"ShowAddPortalUser": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * ������� ������������� ������ ������������ ������ ������ ��� ���������� ����������� ��������.
			 */
			"ShowAddOnlyEmployee": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Flag indicates to show action of licenses distribution.
			 */
			"ShowLicensesDistribution": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * ��� sysOperation, �� �������� ����� ������������� �������� ���� ������� � �������
			 */
			"SecurityOperationName": {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanManageUsers"
			},

			"IsUserBlocked": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		messages: {
			/**
			 * �������� ���������� � �������� � ���� ��� ������.
			 */
			"SetRecordInformation": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"UnblockUser": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"SetIsUserBlocked": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"DeleteUser": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"UserDeletedSuccessfully": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			ActualizationUtilities: "BPMSoft.ActualizationUtilities"
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.subscribeEvents();
				this.updateAddButtonVisibility();
				this.setLicDistributionButtonVisibility();
				this.setTotpStatus();
			},

			/**
			 * ��������� �������� �� ���������� ������ ������������ �������. ���� ������ �������, �� �����
			 * ���������� ������ ��� ���������� ������������� ������� � ����������� ��������. ���� ���, �� �����
			 * �������� ������ ������ ��� ���������� ���������� ��������.
			 * @protected
			 */
			updateAddButtonVisibility: function() {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysAdminUnit"
				});
				esq.addColumn("Id");
				esq.filters.add("PortalFilter", PortalRoleFilterUtilities.getPortalFilterGroup());
				esq.getEntityCollection(this.handleUpdateAddButtonVisibilityResponse, this);
			},

			/**
			* Sets licenses distribution button visibility.
			* @protected
			*/
			setLicDistributionButtonVisibility: function() {
				const operationCode = "CanManageLicUsers";
				RightUtilities.checkCanExecuteOperations([operationCode], function(result) {
					this.$ShowLicensesDistribution = result && result[operationCode];
				}, this);
			},

			/**
			 * ��������� �������� ������ �������. ���� ������ ���� �������, �� ����� ���������� ������ ���
			 * ���������� ������������� ������� � ����������� ��������. ���� ���, �� ����� �������� ������ ������
			 * ��� ���������� ���������� ��������.
			 * @param {Object} response ������, ���������� ����� �������.
			 * @protected
			 */
			handleUpdateAddButtonVisibilityResponse: function(response) {
				if (response && response.success) {
					var propertyName = response.collection.isEmpty() ? "ShowAddOnlyEmployee" : "ShowAddPortalUser";
					this.set(propertyName, this.$IsAddRecordButtonVisible);
				}
			},

			/**
			 * @inheritdoc BaseDataView#onMultiSelectChange
			 * @overridden
			 */
			onMultiSelectChange: function() {
				this.callParent(arguments);
				this.updateAddButtonVisibility();
			},

			/**
			 * @inheritdoc GridUtilitiesV2#getGridDataColumns
			 * @overridden
			 */
			getGridDataColumns: function() {
				var config = this.callParent(arguments);
				config.ConnectionType = {path: "ConnectionType"};
				return config;
			},

			/**
			 * Performs messages subscriptions.
			 * @private
			 */
			subscribeEvents: function() {
				this.sandbox.subscribe("SetRecordInformation", function() {
					var targetParent = this.get("TargetParent");
					if (this.Ext.isEmpty(targetParent)) {
						return;
					}
					return {
						parent: targetParent,
						defaultValues: this.get("defaultValues")
					};
				}, this, [
					this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY),
					this.getCardModuleSandboxId()
				]);
				this.sandbox.subscribe("SetIsUserBlocked", function(args) {
					this.set("IsUserBlocked", args.IsUserBlocked);
				}, this);
				this.sandbox.subscribe("UserDeletedSuccessfully", function() {
					var activeRow = this.get("ActiveRow");
					this.removeGridRecords([activeRow]);
				}, this);
			},

			/**
			 * Calls callback function with flag that of  at least one of selected users is inactive.
			 */
			_isSelectedAnyInactiveUser: function(userIds, callback, scope) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysAdminUnit",
					rowCount: 1
				});
				esq.filters.addItem(BPMSoft.createColumnInFilterWithParameters("Id", userIds));
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Active", false));
				esq.getEntityCollection(function(response) {
					Ext.callback(callback, scope, [response.collection.getCount() > 0]);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#addItemsToGridData
			 * @overridden
			 */
			addItemsToGridData: function() {
				this.callParent(arguments);
				this.setActiveRowsForViewFromHistoryState();
			},

			/**
			 * �������� �� ������� �������� ������ � �������� ������������� � ����������� �� ��� �������� �������.
			 * @protected
			 */
			setActiveRowsForViewFromHistoryState: function() {
				var state = this.sandbox.publish("GetHistoryState").state;
				this.set("ActiveRow", state.UsersActiveRow);
				this.set("FuncRolesActiveRow", state.FuncRolesActiveRow);
				this.set("OrganizationalRolesActiveRow", state.OrgRolesActiveRow);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getDefaultDataViews
			 * @overridden
			 */
			getDefaultDataViews: function() {
				var baseDataViews = this.callParent(arguments);
				baseDataViews = {
					GridDataView: {
						index: 0,
						name: "GridDataView",
						caption: this.get("Resources.Strings.UsersHeader"),
						icon: this.get("Resources.Images.UsersDataViewIcon"),
						hint: this.get("Resources.Strings.UsersDataViewHint")
					},
					OrganizationalRolesDataView: {
						index: 1,
						name: "OrganizationalRolesDataView",
						caption: this.get("Resources.Strings.OrganizationalRolesHeader"),
						icon: this.get("Resources.Images.OrgRolesIcon"),
						hint: this.get("Resources.Strings.OrganizationalStructureDataViewHint")
					},
					FuncRolesDataView: {
						index: 2,
						name: "FuncRolesDataView",
						caption: this.get("Resources.Strings.FunctionalRolesHeader"),
						icon: this.get("Resources.Images.FuncRolesIcon"),
						hint: this.get("Resources.Strings.FunctionalRolesDataViewHint")
					}
				};
				return baseDataViews;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#changeDataView
			 * @overridden
			 */
			changeDataView: function(view) {
				if (view.tag !== "GridDataView") {
					this.moveToRolesSection(view.tag);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Performs move to functional or organizational roles section depending on selected view.
			 * @param {String} viewName ��� �������������.
			 * @protected
			 */
			moveToRolesSection: function(viewName) {
				var pageName = this.getPageNameForRoles(viewName);
				var primaryColumnValue = this.getPrimaryColumnValueForRoles(viewName);
				this.sandbox.publish("PushHistoryState", {
					hash: this.BPMSoft.combinePath("SectionModuleV2", "SysAdminUnitSectionV2",
						pageName, "edit", primaryColumnValue),
					stateObj: {
						module: "SectionModuleV2",
						operation: "edit",
						primaryColumnValue: primaryColumnValue,
						schemas: [
							"SysAdminUnitSectionV2",
							pageName
						],
						workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
						moduleId: this.sandbox.id,
						UsersActiveRow: this.get("ActiveRow"),
						FuncRolesActiveRow: this.get("FuncRolesActiveRow"),
						OrgRolesActiveRow: this.get("OrganizationalRolesActiveRow")
					}
				});
			},

			/**
			 * ���������� ��� �������� �������������� ��� ��������� �������������.
			 * @param {String} viewName ��� �������������.
			 * @return {String} ��� �������� ��������������.
			 * @protected
			 */
			getPageNameForRoles: function(viewName) {
				return viewName === "OrganizationalRolesDataView"
					? "SysAdminUnitPageV2"
					: "SysAdminUnitFuncRolePageV2";
			},

			/**
			 * ���������� ������������� ����, ������� ���� ������� � ������������� �����.
			 * @param {String} viewName ��� �������������.
			 * @return {String} ������������� ��������� ����. ���� ����� �� ���� ������� �����-���� ����, �����
			 * �� ��������� ����� ������� ���� "��� ���������� ��������".
			 * @protected
			 */
			getPrimaryColumnValueForRoles: function(viewName) {
				var id;
				if (viewName === "OrganizationalRolesDataView") {
					id = this.get("OrganizationalRolesActiveRow");
				} else {
					id = this.get("FuncRolesActiveRow");
				}
				return id || ConfigurationConstants.SysAdminUnit.Id.AllEmployees;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var filters = this.callParent(arguments);
				filters.add("UsersFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue", ConfigurationConstants.SysAdminUnit.Type.User));
				return filters;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getEditPageSchemaName
			 * @overridden
			 */
			getEditPageSchemaName: function() {
				return "UserPageV2";
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addRecord
			 * @overridden
			 */
			addRecord: function() {
				return false;
			},

			/**
			 * ��������� �������� ���������� ������ ������������ �������.
			 * @protected
			 */
			onAddPortalUser: function() {
				this.addNewRecord(ConfigurationConstants.SysAdminUnit.Id.PortalUsers,
					ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers);
			},

			/**
			 * ��������� �������� ���������� ������ ���������� ��������.
			 * @protected
			 */
			onAddOurCompanyUser: function() {
				this.addNewRecord(ConfigurationConstants.SysAdminUnit.Id.AllEmployees,
					ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees);
			},

			/**
			 * ��������� �������� ���������� ������ ������������.
			 * @param {String} parentId ������������� ������, � ������� �� ����� ��������� ������������.
			 * @param {Number} connectionType ��� ����������� ������������.
			 * @protected
			 */
			addNewRecord: function(parentId, connectionType) {
				this.set("TargetParent", parentId);
				var defaultValues = [{
					name: "ConnectionType",
					value: connectionType
				}];
				this.set("defaultValues", defaultValues);
				this.openCardInChain({
					schemaName: "UserPageV2",
					operation: ConfigurationEnums.CardStateV2.ADD,
					moduleId: this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY),
					defaultValues: defaultValues
				});
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#onDeleteAccept
			 * @overridden
			 */
			onDeleteAccept: function() {
				var activeRow = this.get("ActiveRow");
				var dataSend = {userId: activeRow};
				var config = {
					serviceName: "AdministrationService",
					methodName: this.getOnDeleteAcceptMethodName(),
					data: dataSend
				};
				this.showBodyMask();
				this.callService(config, this.onDeleteUserResponseHandler.bind(this, activeRow), this);
			},

			/**
			 * Returns delete user method name.
			 * @protected
			 * @return {String} Method name.
			 */
			getOnDeleteAcceptMethodName: function() {
				return "DeleteUser";
			},

			/**
			 * ��������� � ���������� �������� ������������ � ������ ������, � ������ �������� ���������� ��������
			 * ������� ������� �� �������.
			 * @param {String} activeRow ������������� �������, ��� �������� ����������� ��������.
			 * @param {Object} response ����� �������.
			 * @protected
			 */
			onDeleteUserResponseHandler: function(activeRow, response) {
				var message = this.get("Resources.Strings.DeleteErrorMessage");
				var responseResult = response[this.getOnDeleteAcceptMethodName() + "Result"];
				this.validateServiceResponse(responseResult, message,
					this.afterUserDeleted.bind(this, activeRow), this);
			},

			/**
			 * ��������� ����� ������� � ��������� ������������ � ������ ������� ������.
			 * @param {string} response ������������ ����� �������.
			 * @param {string} message ��������� � ������ ������.
			 * @param {Function} callback ������� ��������� ������ � ������ ���������� �������.
			 * @param {Object} scope  �������� ������� ��������� ������.
			 * @protected
			 */
			validateServiceResponse: function(response, message, callback, scope) {
				this.hideBodyMask();
				var result = this.Ext.decode(response);
				var isSuccess = result && result.Success;
				if (isSuccess) {
					callback.call(scope);
				} else if (result.IsSecurityException) {
					this.showInformationDialog(result.ExceptionMessage);
				} else {
					this.showInformationDialog(message);
				}
			},

			/**
			 * ��������, ����������� ����� �������� ������������.
			 * @param {String} activeRow ������������� �������, ��� �������� ����������� ��������.
			 * @protected
			 */
			afterUserDeleted: function(activeRow) {
				this.removeGridRecords([activeRow]);
				this.hideBodyMask();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
			 * @overridden
			 */
			getSectionActions: function() {
				var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.addLicDistributionActions(actionMenuItems);
				actionMenuItems.addItem(this.getExportToFileMenuItem());
				actionMenuItems.addItem(this.getExportToExcelFileMenuItem());
				actionMenuItems.addItem(this.getActualizeAdminUnitInRoleButton());
				actionMenuItems.addItem(this.getDisableTotpMenuItem());
				return actionMenuItems;
			},

			/**
			 * Adds actions necessary for mass distribution of licenses.
			 * @protected
			 * @param {BPMSoft.BaseViewModelCollection} actionMenuItems Collection of section actions.
			 */
			addLicDistributionActions: function(actionMenuItems) {
				if (this.getIsFeatureDisabled("BulkLicenseDistribution")) {
					return;
				}
				actionMenuItems.addItem(this.createSelectMultipleRecordsButton());
				actionMenuItems.addItem(this.createSelectOneRecordButton());
				actionMenuItems.addItem(this.createLicDistributionButton());
				actionMenuItems.addItem(this.createLicRecallButton());
				actionMenuItems.addItem(this.createLicUploadButton());
				actionMenuItems.addItem(this.createLicRequestButton());
				actionMenuItems.addItem(this.getButtonMenuSeparator());
			},

			/**
			 * Creates licenses distribution button.
			 * @protected
			 */
			createLicDistributionButton: function() {
				return this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.LicensesDistributionButtonCaption"},
					"Click": {"bindTo": "onLicDistribution"},
					"Visible": {"bindTo": "ShowLicensesDistribution"},
					"Enabled": {"bindTo": "isLicDistributionEnabled"},
					"IsEnabledForSelectedAll": true
				});
			},

			/**
			 * Creates licenses recall button.
			 * @protected
			 */
			createLicRecallButton: function() {
				return this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.LicensesRecallButtonCaption"},
					"Click": {"bindTo": "onLicRecall"},
					"Visible": {"bindTo": "ShowLicensesDistribution"},
					"Enabled": {"bindTo": "isAnySelected"},
					"IsEnabledForSelectedAll": true
				});
			},

			/**
			 * Creates licenses upload button.
			 * @protected
			 */
			createLicUploadButton: function() {
				return this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.UploadLicensesButtonCaption"},
					"Visible": {"bindTo": "ShowLicensesDistribution"},
					"fileUpload": true,
					"fileTypeFilter": [".tls"],
					"filesSelected": {"bindTo": "onLicensesUpload"},
					"fileUploadMultiSelect": false,
					"IsEnabledForSelectedAll": true
				});
			},

			/**
			 * Creates licenses request button.
			 * @protected
			 */
			createLicRequestButton: function() {
				return this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.LicensesRequestButtonCaption"},
					"Visible": {"bindTo": "ShowLicensesDistribution"},
					"Click": {"bindTo": "onLicRequest"},
					"IsEnabledForSelectedAll": true
				});
			},

			getDisableTotpMenuItem: function() {
				return this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.Reset2FAButtonCaption"},
					"Click": {"bindTo": "disableTotpForUser"},
					"Visible": {"bindTo": "isTotpEnabled"},
					"Enabled": {"bindTo": "isSingleSelected"},
					"IsEnabledForSelectedAll": true
				});
			},

			/**
			 * Calls the web service method of licenses distribution.
			 * @protected
			 * @param {Array} userIds Array of users identifiers.
			 * @param {Array} packageIds Array of license package identifiers.
			 */
			distributeLicenses: function(userIds, packageIds) {
				this.callLicenseService({
					methodName: "AddUsersPackages",
					data: {
						"userIds": userIds,
						"packageIds": packageIds
					},
					message: this.get("Resources.Strings.GrantLicensesCompleteMessage")
				});
			},

			/**
			 * Calls the web service method of licenses recall.
			 * @protected
			 * @param {Array} userIds Array of users identifiers.
			 * @param {Array} packageIds Array of license package identifiers.
			 */
			recallLicenses: function(userIds, packageIds) {
				this.callLicenseService({
					methodName: "DeleteUsersPackages",
					data: {
						"userIds": userIds,
						"packageIds": packageIds
					},
					message: this.get("Resources.Strings.RecallLicensesCompleteMessage")
				});
			},

			/**
			 * Indicates license distribution enabled.
			 */
			isLicDistributionEnabled: function() {
				if (!this.$MultiSelect) {
					const activeRow = this.getActiveRow();
					return activeRow && activeRow.$Active;
				}
				return this.isAnySelected();
			},

			/**
			 * Handles click on license request menu item.
			 */
			onLicRequest: function() {
				const requestFile = document.createElement("a");
				requestFile.href = "../ServiceModel/LicenseService.svc/CreateLicenseRequest";
				if (this.Ext.isIE) {
					requestFile.target = "_blank";
				}
				requestFile.download = "LicenseRequest.tlr";
				document.body.appendChild(requestFile);
				requestFile.click();
				document.body.removeChild(requestFile);
			},

			/**
			 * Returns identifiers of all users that matches current filter criteria.
			 * @protected
			 * @param {Object} filtersConfig Filters configuration.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution scope for callback function.
			 */
			getAllUserIds: function(filtersConfig, callback, scope) {
				this.callService({
					serviceName: "AdministrationService",
					methodName: "GetUserIds",
					data: {
						filtersConfig: filtersConfig
					}
				}, function(response) {
					var result = Ext.decode(response && response.GetUserIdsResult);
					if (result && result.Success) {
						this.Ext.callback(callback, scope, [result.UserIds]);
					} else {
						this.showInformationDialog(result && result.ExceptionMessage);
					}
				}, this);
			},

			/**
			 * Receives license packages used by specified users.
			 * @param {Array} userIds Users identifiers.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution scope for callback function.
			 */
			getUsersLicPackages: function(userIds, callback, scope) {
				ServiceHelper.callCoreService({
					serviceName: "LicenseService",
					methodName: "GetUsersPackages",
					data: userIds
				}, function(response) {
					var errorInfo = response.errorInfo;
					if (!this.Ext.isEmpty(errorInfo)) {
						this.showInformationDialog(errorInfo.message);
					} else {
						this.Ext.callback(callback, scope, [response.packageIds]);
					}
				}, this);
			},

			/**
			 * Returns identifiers of selected users.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution scope for callback function.
			 */
			getUserIds: function(callback, scope) {
				const selectedRecordsConfig = this.getSelectedRecordsConfig();
				if (selectedRecordsConfig.selectAllMode) {
					this.getAllUserIds(selectedRecordsConfig.filtersConfig, function(userIds) {
						this.Ext.callback(callback, scope, [userIds]);
					}, this);
				} else {
					this.Ext.callback(callback, scope, [selectedRecordsConfig.selectedItems]);
				}
			},

			/**
			 * Receives and passes to the callback function identifiers of selected users and license packages
			 * used by this users.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution scope for callback function.
			 */
			getUsersWithLicPackages: function(callback, scope) {
				this.showBodyMask();
				this.getUserIds(function(userIds) {
					this.getUsersLicPackages(userIds, function(licPackageIds) {
						this.hideBodyMask();
						this.Ext.callback(callback, scope, [userIds, licPackageIds]);
					}, this);
				}, this);
			},

			/**
			 * Returns lookup page config for licenses distribution.
			 * @protected
			 * @return {Object} Lookup page config.
			 */
			getLicDistributionLookupConfig: function() {
				var now = new Date();
				const filters = this.BPMSoft.createFilterGroup();
				filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.GREATER_OR_EQUAL,
					"[SysLic:SysLicPackage:Id].DueDate",
					this.BPMSoft.endOfDay(now)));
				filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.LESS_OR_EQUAL,
					"[SysLic:SysLicPackage:Id].StartDate",
					this.BPMSoft.endOfDay(now)));
				return {
					entitySchemaName: "SysLicPackage",
					multiSelect: true,
					filters: filters,
					columnName: "Name",
					hideActions: true
				};
			},

			/**
			 * Returns lookup page config for licenses recall.
			 * @protected
			 * @param {Array} licPackageIds Identifiers of packages to show in lookup page.
			 * @return {Object} Lookup page config.
			 */
			getLicRecallLookupConfig: function(licPackageIds) {
				var filters = licPackageIds.length > 0
					? this.BPMSoft.createColumnInFilterWithParameters("Id", licPackageIds)
					: this.BPMSoft.createColumnIsNullFilter("Id");
				return {
					entitySchemaName: "SysLicPackage",
					multiSelect: true,
					filters: filters,
					columnName: "Name",
					hideActions: true
				};
			},

			/**
			 * Uploads file of licenses to server.
			 * @protected
			 * @param {Object} data Data of selected file.
			 */
			licensesUpload: function(data) {
				if (data.type === "load") {
					this.callLicenseService({
						methodName: "UploadLicenses",
						data: {"licData": data.result},
						message: this.get("Resources.Strings.UploadLicensesCompleteMessage"),
						errorMessage: this.get("Resources.Strings.UploadLicensesErrorMessage")
					});
				}
			},

			/**
			 * Calls "LicenseService" method by config.
			 * @protected
			 * @param {config} config Config for service method call.
			 */
			callLicenseService: function(config) {
				this.showBodyMask();
				ServiceHelper.callCoreService({
					serviceName: "LicenseService",
					methodName: config.methodName,
					data: config.data
				}, function(response) {
					this.hideBodyMask();
					var errorInfo = response.errorInfo;
					var infoMessage = this.Ext.isEmpty(errorInfo) && response.success
						? config.message
						: config.errorMessage
						? config.errorMessage
						: errorInfo.message;
					this.showInformationDialog(infoMessage);
				}, this);
			},

			// endregion

			// region Methods: Public

			/**
			 * Handles event to process packages selected to grant licenses.
			 * @param {Object} args Lookup arguments.
			 * @param {BPMSoft.collection} args.selectedItems Lookup selected items.
			 */
			onPackagesToGrantSelected: function(args) {
				var packageIds = args.selectedRows.getKeys();
				if (!packageIds.length) {
					return;
				}
				this.getUserIds(function(userIds) {
					this.distributeLicenses(userIds, packageIds);
				}, this);
			},

			/**
			 * Handles event to process packages selected to recall licenses.
			 * @param {Array} userIds Users identifiers.
			 * @param {Object} args Lookup arguments.
			 * @param {BPMSoft.collection} args.selectedItems Lookup selected items.
			 */
			onPackagesToRecallSelected: function(userIds, args) {
				var packageIds = args.selectedRows.getKeys();
				if (packageIds.length > 0) {
					this.recallLicenses(userIds, packageIds);
				}
			},

			/**
			 * Uploads tls file.
			 * @param {Array} files File of licenses.
			 */
			onLicensesUpload: function(files) {
				if (Ext.isArray(files)) {
					FileAPI.readAsBinaryString(files[0], this.licensesUpload.bind(this));
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getViewOptions
			 * @overridden
			 */
			getViewOptions: function() {
				var viewOptions = this.Ext.create("BPMSoft.BaseViewModelCollection");
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.OpenSummarySettingsModuleButtonCaption"},
					"Click": {"bindTo": "openSummarySettings"},
					"Visible": {"bindTo": "IsSummarySettingsVisible"},
					"ImageConfig": this.get("Resources.Images.SummariesIcon")
				}));
				viewOptions.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.OpenGridSettingsCaption"},
					"Click": {"bindTo": "openGridSettings"},
					"ImageConfig": this.get("Resources.Images.GridSettingsIcon")
				}));
				return viewOptions;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getSectionCode
			 * @override
			 */
			getSectionCode: function() {
				return "SystemUsers";
			},

			/**
			 * Handles licenses distribution menu select.
			 */
			onLicDistribution: function() {
				if (!this.$MultiSelect) {
					this.openLicensesToDistribute();
					return;
				}
				this.getUserIds(function(userIds) {
					const maxQueryParamCount = 2000;
					if (userIds.length > maxQueryParamCount) {
						this.confirmLicDistribution(this.get("Resources.Strings.ToManyUsersLicDistributionConfirm"));
						return;
					}
					this._isSelectedAnyInactiveUser(userIds, function(result) {
						if (!result) {
							this.openLicensesToDistribute();
							return;
						}
						this.confirmLicDistribution(this.get("Resources.Strings.LicDistributionConfirmation"));
					}, this);
				}, this);
			},

			/**
			 * Shows confirmation dialog for distribution licenses.
			 * @param {String} confirmationMessage Confirmation message.
			 */
			confirmLicDistribution: function(confirmationMessage) {
				this.showConfirmationDialog(confirmationMessage,
					function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							this.openLicensesToDistribute();
						}
					},
					[BPMSoft.MessageBoxButtons.YES.returnCode,
						BPMSoft.MessageBoxButtons.NO.returnCode], null
				);
			},

			/**
			 * Opens lookup window for select available licences.
			 */
			openLicensesToDistribute: function() {
				var config = this.getLicDistributionLookupConfig();
				this.openLookup(config, this.onPackagesToGrantSelected, this);
			},

			/**
			 * Handles licenses recall menu select.
			 */
			onLicRecall: function() {
				this.getUsersWithLicPackages(function(userIds, licPackageIds) {
					var config = this.getLicRecallLookupConfig(licPackageIds);
					this.openLookup(config, this.onPackagesToRecallSelected.bind(this, userIds), this);
				}, this);
			},

			onUnblockClick: function() {
				this.sandbox.publish("UnblockUser");
			},

			onDeleteClick: function() {
				this.sandbox.publish("DeleteUser");
			},

			disableTotpForUser: function() {
				BPMSoft.MaskHelper.showBodyMask();
				var data = {
					sysAdminUnitId: this.getSelectedSysAdminUnitId()
				};
				BPMSoft.AjaxProvider.request({
					url: BPMSoft.workspaceBaseUrl +
						"/ServiceModel/TotpResetService.svc/ResetTotp",
					method: "POST",
					jsonData: data,
					callback: function(options, result, response) {
						BPMSoft.MaskHelper.hideBodyMask();
						var responseObject = BPMSoft.decode(response.responseText);
						if (responseObject && responseObject.ResetTotpResult && responseObject.ResetTotpResult.isSuccess) {
							this.showInformationDialog(this.get("Resources.Strings.Reset2FAIsSuccessful"));
						} else {
							this.log(responseObject.ResetTotpResult.message);
							this.showInformationDialog(responseObject.ResetTotpResult.message);
						}
					},
					scope: this
				});
			},

			getSelectedSysAdminUnitId: function() {
				var activeRow = this.getActiveRow();
				if (activeRow && activeRow.values) {
					return activeRow.values.Id;
				}
				throw new Error(this.get("Resources.Strings.SysAdminUnitValueDoesNotExists"));
			},

			setTotpStatus: function() {
				let appFramework = BPMSoft.appFramework;
				BPMSoft.AjaxProvider.request({
					url: BPMSoft.workspaceBaseUrl +
						"/../ServiceModel/TotpSetupService.svc/GetTotpInfo",
					method: "POST",
					jsonData: null,
					callback: function(options, result, response) {
						var responseObject = BPMSoft.decode(response.responseText);
						var isTotpEnabled = appFramework === "NETFRAMEWORK" ? responseObject.GetTotpInfoResult.isTotpEnabled : responseObject.isTotpEnabled;
						this.set("IsTotpEnabled", isTotpEnabled);
					},
					scope: this
				});
			},

			isTotpEnabled : function() {
				return this.get("IsTotpEnabled");
			}

			// endregion

		}
	};
});
