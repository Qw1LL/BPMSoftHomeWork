/**
 * Parent: BaseSectionV2
 */
define("WebServiceV2Section", ["ConfigurationEnums", "RightUtilities", "WebServiceV2SectionResources",
	"ServiceDesignerUtilities", "WebServiceWizardWebComponent", "css!ServiceDesignerStyles"
], function() {
	return {
		entitySchemaName: "VwWebServiceV2",
		attributes: {
			/**
			 * The name of the operation to which user has access.
			 */
			"SecurityOperationName": {
				dataValueType: BPMSoft.DataValueType.STRING,
				value: "CanManageSolution"
			},

			/**
			 * The Uri to pass to edit page.
			 */
			"WizardUri": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * The data from the wizard service page.
			 */
			"WizardServiceData": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * The service type to pass to edit page.
			 */
			"ServiceType": {
				dataValueType: BPMSoft.DataValueType.ENUM,
				value: BPMSoft.services.enums.ServiceType.REST
			}
		},
		properties: {
			customEvent: Ext.create("BPMSoft.mixins.CustomEventDomMixin"),
			restServiceTypeId: "4e8e8584-e388-4cef-8518-c1df4d1b3bb5",
			soapServiceTypeId: "4e1f56e1-79fd-4a30-8cb0-02813c634c88",
			restServiceEditSchemaName: "RestWebServiceV2Page",
			soapServiceEditSchemaName: "SoapWebServiceV2Page",
			openWebServiceWizardEventName: "OpenWebServiceWizard",
			webServicesCreatedEventName: "WebServicesCreated"
		},
		methods: {

			// region Methods: Private

			/**
			 * Gets is column clickable.
			 * @param {String} column Column to find
			 * @return {Boolean}
			 * @private
			 */
			_isClickableColumn: function(column) {
				var clickableColumns = ["Caption"];
				return this.Ext.Array.contains(clickableColumns, column);
			},

			/**
			 * @private
			 */
			_openServiceWizard: function(type ,callback, scope) {
				BPMSoft.showInputBox(null, function(buttonCode, values) {
					if (buttonCode === "ok") {
						this.$WizardUri = values.uri.value;
						this.$ServiceType = type;
						Ext.callback(callback, scope);
					}
				}, ["ok", "cancel"], this, {
					uri: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						value: "",
						caption: this.get("Resources.Strings.MiniCardUriCaption"),
						customConfig: {
							focused: true,
							classes: {wrapClass: "service-mini-card-uri"}
						}
					}
				});
			},

			/**
			 * @private
			 */
			_applyWizardUri: function(config) {
				if (config.instanceConfig) {
					config.instanceConfig.parameters = {
						viewModelConfig: {
							"wizardUri": this.$WizardUri,
							"serviceType": this.$ServiceType,
							"wizardServiceData": this.$WizardServiceData,
						}}
				}
				this.$WizardUri = "";
				this.$WizardServiceData = "";
			},

			_createEditPageItemViewModel: function(serviceTypeId) {
				return new BPMSoft.BaseViewModel({
					values: {
						Id: serviceTypeId,
						Click: {bindTo: "addRecord"},
						Tag: serviceTypeId,
						SchemaName: this._getEditPageSchemaNameByServiceTypeId(serviceTypeId)
					}
				});
			},

			_getEditPageSchemaNameByServiceTypeId: function(serviceTypeId) {
				if (serviceTypeId === this.restServiceTypeId) {
					return this.restServiceEditSchemaName;
				}
				return this.soapServiceEditSchemaName;
			},

			getWebServiceTranslation: function() {
				return {
					"SoapWizardCaption": this.get("Resources.Strings.SoapWizardCaption"),
					"SkipWizardButtonCaption": this.get("Resources.Strings.SkipWizardButtonCaption"),
					"WsdlFilePromptCaption": this.get("Resources.Strings.WsdlFilePromptCaption"),
					"WsdlUploadButtonCaption": this.get("Resources.Strings.WsdlUploadButtonCaption"),
					"WsdlParsingError": this.get("Resources.Strings.WsdlParsingError"),
					"WizardNext": this.get("Resources.Strings.WizardNext"),
					"WizardBack": this.get("Resources.Strings.WizardBack"),
					"WizardSave": this.get("Resources.Strings.WizardSave"),
					"SelectSoapService": this.get("Resources.Strings.SelectSoapService"),
					"SoapWizardServiceSelectedCaption": this.get("Resources.Strings.SoapWizardServiceSelectedCaption"),
					"WizardActionCaption": this.get("Resources.Strings.WizardActionCaption"),
					"WizardResponseActionCaption": this.get("Resources.Strings.WizardResponseActionCaption"),
					"WizardResponseParametersCaption": this.get("Resources.Strings.WizardResponseParametersCaption"),
					"WizardRequestParametersCaption": this.get("Resources.Strings.WizardRequestParametersCaption"),
					"WizardMethodCaption": this.get("Resources.Strings.WizardMethodCaption"),
					"SchemaDocumentFileNotFoundError": this.get("Resources.Strings.SchemaDocumentFileNotFoundError"),
					"WsdlLinkPlaceholderText": this.get("Resources.Strings.WsdlLinkPlaceholderText"),
					"WsdlFileAndUrlPromptCaption": this.get("Resources.Strings.WsdlFileAndUrlPromptCaption"),
					"DownloadXmlSchemaError": this.get("Resources.Strings.DownloadXmlSchemaError"),
				};
			},
			
			_initCustomEvent: function() {
				this.customEvent.init();
				this.customEvent.subscribe(this.webServicesCreatedEventName)
					.subscribe((wizardResult) => this._onWizardResultReceived(wizardResult));
				const translation = this.getWebServiceTranslation();
				this.customEvent.publish("GetWebServiceTranslation", translation);
			},

			_onWizardResultReceived: function(wizardResult) {
				switch (wizardResult.resultCode) {
					case "Skip":
						this.addRecord(BPMSoft.services.enums.ServiceType.SOAP12);
						return;
					case "Close":
						return;
					case "Success":
						this.$WizardServiceData = this._getWizardServiceData(wizardResult.services || []);
						this.$ServiceType = this.$WizardServiceData.type;
						this.addRecord(this.$WizardServiceData.type);
						return;
					case "Error":
						return;
				}
			},

			_getWizardServiceData: function(services) {
				let service = services.find((service) => service.type === BPMSoft.services.enums.ServiceType.SOAP12);
				return service ? service : services[0];
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init.
			 * @override
			 */
			init: function(callback, scope) {
				this._initCustomEvent();
				this.callParent([function() {
					BPMSoft.ServiceSchemaManager.initialize(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.mixins.GridUtilitiesV2#getGridDataColumns.
			 * @override
			 */
			getGridDataColumns: function() {
				let defColumnsConfig = this.callParent(arguments);
				return Object.assign({}, defColumnsConfig, { "TypeName": {
						path: "TypeName"
					}
				});
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.customEvent.destroy();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2
			 * @override
			 */
			initAddRecordButtonParameters: function() {
				var caption = this.get("Resources.Strings.AddRecordButtonCaption");
				this.callParent();
				this.set("AddRecordButtonCaption", caption);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#isMultiSelectVisible
			 * @override
			 */
			isMultiSelectVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2
			 * @override
			 */
			getModuleCaption: function() {
				return this.get("Resources.Strings.Caption");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSection#getSectionCode.
			 * @override
			 */
			getSectionCode: function() {
				return "WebServiceV2";
			},

			/**
			 * @inheritdoc BPMSoft.ContextHelpMixin#getContextHelpConfig.
			 * @override
			 */
			getContextHelpConfig: function() {
				return {
					contextHelpId: "1862",
					contextHelpCode: "WebServiceV2Section"
				};
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#deleteRecords.
			 * @override
			 */
			onMultiDeleteAccept: function() {
				var items = this.getSelectedItems();
				if (!Ext.isEmpty(items)) {
					BPMSoft.ServiceSchemaManager.getItems()
						.filterByFn(function(item) {
							return BPMSoft.contains(items, item.uId);
						}, this)
						.each(function(item) {
							item.remove();
						});
					this.showBodyMask();
					BPMSoft.ServiceSchemaManager.save(function(response) {
						this.hideBodyMask();
						if (response.success) {
							this.reloadGridData();
						} else {
							this.showInformationDialog(response.errorInfo.toString());
						}
					}, this);
				}
			},

			/**
			 * @inheritodoc BaseSectionV2#getDefaultDataViews
			 * @override
			 */
			getDefaultDataViews: function() {
				var dataViews = this.callParent(arguments);
				delete dataViews.AnalyticsDataView;
				return dataViews;
			},

			/**
			 * @inheritdoc GridUtilitiesV2#addColumnLink
			 * @override
			 */
			addColumnLink: function(item, column) {
				const columnPath = column.columnPath;
				if (!this._isClickableColumn(columnPath)) {
					return;
				}
				const onColumnLinkClickHandler = "on" + columnPath + "LinkClick";
				const scope = this;
				item[onColumnLinkClickHandler] = function() {
					return scope.createLink("VwWebServiceV2", columnPath, item.get(columnPath), item);
				};
			},

			/**
			 * @inheritdoc GridUtilitiesV2#createLink
			 * @override
			 */
			createLink: function(entitySchemaName, columnPath, displayValue, item) {
				const serviceTypeId = this.getTypeColumnValue(item);
				const editPageSchemaName = this._getEditPageSchemaNameByServiceTypeId(serviceTypeId);
				const link = BPMSoft.workspaceBaseUrl +
					"/Nui/ViewModule.aspx#" +
					["CardModuleV2", editPageSchemaName, "edit", item.$Id].join("/");
				return {
					caption: displayValue,
					target: "_self",
					title: displayValue,
					url: link
				};
			},

			/**
			 * @inheritdoc GridUtilitiesV2#checkCanDelete
			 * @override
			 */
			checkCanDelete: function(items, callback, scope) {
				var activeRow = this.$ActiveRow;
				BPMSoft.chain(
					function(next) {
						BPMSoft.ServiceSchemaManager.getInstanceByUId(activeRow, next, this);
					},
					function(next, instance) {
						BPMSoft.ServiceDesignerUtilities.canEditSchema(instance, function(result) {
							callback.call(scope, result ? null : "RightLevelWarningMessage");
						}, scope);
					}, this);
			},

			/**
			 * @inheritdoc BaseSectionV2#getExportToFileActionVisibility
			 * @override
			 */
			getExportToFileActionVisibility: function() {
				return false;
			},

			getEditPagesCollection: function() {
				const collection = new BPMSoft.BaseViewModelCollection();
				const editPageItems = [
					this._createEditPageItemViewModel(this.restServiceTypeId),
					this._createEditPageItemViewModel(this.soapServiceTypeId)
				];
				editPageItems.forEach(function(item) {
					collection.add(item.$Id, item);
				});
				return collection;
			},

			getEditPageIdByServiceType: function(serviceType) {
				if (serviceType === BPMSoft.services.enums.ServiceType.REST) {
					return this.restServiceTypeId;
				}
				return this.soapServiceTypeId;
			},

			getTypeColumnValue: function(activeRow) {
				const serviceTypeName = activeRow.$TypeName;
				if (serviceTypeName === "REST") {
					return this.restServiceTypeId;
				}
				return this.soapServiceTypeId;
			},

			/**
			 * @inheritdoc BaseSectionV2#openCardInChain
			 * @override
			 */
			openCardInChain: function(config) {
				this._applyWizardUri(config);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#addRecord
			 * @override
			 */
			addRecord: function(serviceType) {
				serviceType = serviceType || BPMSoft.services.enums.ServiceType.REST;
				this.$ServiceType = serviceType
				const serviceTypeId = this.getEditPageIdByServiceType(serviceType);
				const parentMethod = this.getParentMethod(this, [serviceTypeId]);
				if (serviceType !== BPMSoft.services.enums.ServiceType.REST) {
					Ext.callback(parentMethod, this);
				} else {
					this._openServiceWizard(serviceType, parentMethod, this);
				}
			},

			addSoapService: function() {
				if (BPMSoft.Features.getIsEnabled("DontUseWsdlWizard")) {
					this.addRecord(BPMSoft.services.enums.ServiceType.SOAP12);
				} else {
					this.customEvent.publish(this.openWebServiceWizardEventName);
				}
			},

			/**
			 * Return button menu items.
			 * @return {BPMSoft.Collection}
			 */
			getMenuItems: function() {
				if (BPMSoft.Features.getIsEnabled("DontUseSoap")) {
					return null;
				}
				let menuItems = null;
				menuItems = Ext.create("BPMSoft.Collection");
				menuItems.add(this.getButtonMenuItem({
					Caption: {bindTo: "Resources.Strings.AddRestCaption"},
					Click: {bindTo: "addRecord"},
					Tag: BPMSoft.services.enums.ServiceType.REST
				}));
				menuItems.add(this.getButtonMenuItem({
					Caption: {bindTo: "Resources.Strings.AddSoapCaption"},
					Click: {bindTo: "addSoapService"},
					Tag: BPMSoft.services.enums.ServiceType.SOAP12
				}));
				return menuItems;
			},

			/**
			 * Returns separate mode actions button visibility.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			isSeparateModeActionsButtonVisible: function() {
				return !BPMSoft.Features.getIsEnabled("DontUseSoap");
			},
			/**
			 * Returns separate add record actions button visibility.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			isSeparateModeAddRecordButtonVisible: function() {
				return !this.isSeparateModeActionsButtonVisible();
			},

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
				 "visible": {"bindTo": "isSeparateModeAddRecordButtonVisible"},
					"controlConfig": {
						"menu": {
							"items": {
								"bindTo": "getMenuItems"
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "SeparateModeActionsButton",
				"values": {
					"caption": {"bindTo":  "Resources.Strings.AddRecordButtonCaption" },
					"menu": {
						"items": {
							"bindTo": "getMenuItems"
						}
					},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE
				}
			},
			{
				"operation": "merge",
				"name": "SaveRecordButton",
				"values": {"style": BPMSoft.controls.ButtonEnums.style.ORANGE}
			},
			{
				"operation": "remove",
				"name": "CombinedModeActionsButton"
			},
			{
				"operation": "insert",
				"name": "NgWebServiceWizardWebComponent",
				"parentName": "SectionContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.WebServiceWizardWebComponent"
				}
			},
		]/**SCHEMA_DIFF*/
	};
});
