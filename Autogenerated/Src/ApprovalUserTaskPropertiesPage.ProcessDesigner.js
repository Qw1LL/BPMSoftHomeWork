﻿/**
 * Parent: ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("ApprovalUserTaskPropertiesPage", ["ProcessUserTaskConstants", "ApprovalUserTaskPropertiesPageResources",
	"NetworkUtilities", "EmailTemplateMLangContentBuilderEnumsModule", "ConfigurationConstants",
	"ContentBuilderHelper", "SectionManager", "SysModuleEntityManager", "SysModuleVisaManager"
], function(ProcessUserTaskConstants, resources, NetworkUtilities, EmailTemplateMLangContentBuilderEnumsModule,
            ConfigurationConstants) {
	return {
		attributes: {
			/**
			 * Approval purpose.
			 */
			Purpose: {
				dataValueType: BPMSoft.DataValueType.MAPPING,
				parameterBindConfig: {
					onInit: "initPurpose",
					onSave: "saveParameter"
				}
			},
			/**
			 * Approval object identifier.
			 */
			EntitySchemaUId: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Current package entity schema list.
			 */
			EntitySchemaList: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Approval section identifier.
			 */
			SectionId: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Approval section.
			 */
			SectionSelect: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				isRequired: true
			},
			/**
			 * Flag that indicates whether field SectionSelect is enabled or not.
			 */
			IsSectionSelectReadonly: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Record identifier.
			 */
			RecordId: {
				dataValueType: BPMSoft.DataValueType.MAPPING,
				isRequired: true,
				parameterBindConfig: {
					onSave: "saveParameter"
				}
			},
			/**
			 * Approver type.
			 */
			ApproverType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				isRequired: true,
				parameterBindConfig: {
					onInit: "_initApproverType",
					onSave: "saveParameter"
				}
			},
			/**
			 * Approver type enum config object.
			 */
			ApproverTypeEnum: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: {
					Employee: {
						value: ProcessUserTaskConstants.APPROVER_TYPE.Employee,
						displayValue: resources.localizableStrings.EmployeeCaption
					},
					EmployeeManager: {
						value: ProcessUserTaskConstants.APPROVER_TYPE.EmployeeManager,
						displayValue: resources.localizableStrings.EmployeeManagerCaption
					},
					Role: {
						value: ProcessUserTaskConstants.APPROVER_TYPE.Role,
						displayValue: resources.localizableStrings.RoleCaption
					}
				}
			},
			/**
			 * Approver employee.
			 */
			EmployeeId: {
				dataValueType: BPMSoft.DataValueType.MAPPING,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Approver role identifier.
			 */
			RoleId: {
				dataValueType: BPMSoft.DataValueType.MAPPING,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Approval may be delegated.
			 */
			IsAllowedToDelegate: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Flag that indicates visibility of button SectionSelectInfoButton.
			 */
			IsSectionSelectInfoButtonVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Send email to the approvers.
			 */
			IsSendEmailToApprovers: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Email template for the approver.
			 */
			ApproverEmailTemplate: {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				},
				mappingWindowConfig: {
					filterMethod: "getEmailTemplateFilter"
				}
			},
			/**
			 * Send email to the author.
			 */
			IsSendEmailToAuthor: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},
			/**
			 * Email template for the author.
			 */
			AuthorEmailTemplate: {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				},
				mappingWindowConfig: {
					filterMethod: "getEmailTemplateFilter"
				}
			},

			/**
			 * Flag that indicates if is ignore errors.
			 */
			IgnoreEmailErrors: {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				parameterBindConfig: {
					onInit: "initProperty",
					onSave: "saveParameter"
				}
			},

			/**
			 * Author email address.
			 */
			AuthorEmailAddress: {
				dataValueType: this.BPMSoft.DataValueType.MAPPING,
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				parameterBindConfig: {
					onSave: "saveAuthorEmailAddress"
				}
			},

			/**
			 * Flag that indicate add email template button was clicked.
			 */
			AddEmailTemplateButtomClicked: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Init ApproverType attribute.
			 * @private
			 * @param {BPMSoft.manager.ProcessSchemaParameter} parameter Process parameter.
			 */
			_initApproverType: function(parameter) {
				var source = parameter.getValueSource();
				if (source !== BPMSoft.ProcessSchemaParameterValueSource.None) {
					var enumConfig = this.get("ApproverTypeEnum");
					var value = parameter.getValue();
					var item = BPMSoft.findWhere(enumConfig, {value: value});
					this.set("ApproverType", item);
				}
			},

			/**
			 * Clears value for attribute RecordId.
			 * @private
			 */
			_clearRecordId: function() {
				var recordId = {
					value: null,
					displayValue: null,
					source: BPMSoft.ProcessSchemaParameterValueSource.None,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					referenceSchemaUId: this.get("EntitySchemaUId")
				};
				this.set("RecordId", recordId);
				var element = this.get("ProcessElement");
				var parameter = element.getParameterByName("RecordId");
				parameter.referenceSchemaUId = this.get("EntitySchemaUId");
			},

			/**
			 * Validates RecordId attribute.
			 * @private
			 * @return {Object} Validation info
			 * @return {Object} return.isValid Validation result.
			 * @return {Object} return.invalidMessage Validation message.
			 */
			_validateRecordId: function() {
				var isValid = true;
				var invalidMessage = "";
				var recordId = this.get("RecordId");
				if (BPMSoft.isEmptyObject(recordId) || Ext.isEmpty(recordId.value)) {
					isValid = false;
					invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
				}
				this.setValidationInfo("RecordId", isValid, invalidMessage);
				return {
					isValid: isValid,
					invalidMessage: invalidMessage
				};
			},

			/**
			 * Returns attribute name for validate approval.
			 * @private
			 * @return {String}
			 */
			_getValidateApprovalAttributeName: function() {
				var approverType = this.get("ApproverType");
				return approverType.value === ProcessUserTaskConstants.APPROVER_TYPE.Role ? "RoleId" : "EmployeeId";
			},

			/**
			 * Validates approval.
			 * @private
			 * @return {Object} Validation info
			 * @return {Object} return.isValid Validation result.
			 * @return {Object} return.invalidMessage Validation message.
			 */
			_validateApproval: function() {
				var isValid, invalidMessage;
				var attributeName = this._getValidateApprovalAttributeName();
				var attribute = this.get(attributeName);
				if (BPMSoft.isEmptyObject(attribute) || Ext.isEmpty(attribute.value)) {
					isValid = false;
					invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
				} else {
					isValid = true;
					invalidMessage = "";
				}
				this.setValidationInfo(attributeName, isValid, invalidMessage);
				return {
					isValid: isValid,
					invalidMessage: invalidMessage
				};
			},

			/**
			 * Validates email template.
			 * @param {String} mainAttributeName Main attribute name.
			 * @param {String} dependentAttributeName Depended attribute name.
			 * @private
			 * @return {Object} Validation info
			 * @return {Object} return.isValid Validation result.
			 * @return {Object} return.invalidMessage Validation message.
			 */
			_validateEmailTemplate: function(mainAttributeName, dependentAttributeName) {
				var isValid = true;
				var invalidMessage = "";
				var template = this.get(dependentAttributeName);
				var mainAttribute = this.get(mainAttributeName);
				if (mainAttribute && (BPMSoft.isEmptyObject(template) || Ext.isEmpty(template.value))) {
					isValid = false;
					invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
				}
				this.setValidationInfo(dependentAttributeName, isValid, invalidMessage);
				return {
					isValid: isValid,
					invalidMessage: invalidMessage
				};
			},

			/**
			 * @private
			 */
			_loadSectionList: function(list) {
				list.clear();
				var sectionList = this._getSectionList();
				list.loadAll(sectionList);
				if (Ext.Object.isEmpty(sectionList)) {
					this.set("IsSectionSelectInfoButtonVisible", true);
					this.set("IsSectionSelectReadonly", true);
				}
			},

			/**
			 * Cleans attribute mapping value.
			 * @private
			 * @param {String} attributeName Attribute name.
			 */
			_cleanMappingValue: function(attributeName) {
				var attribute = this.get(attributeName);
				attribute.value = null;
				attribute.displayValue = null;
				attribute.source = BPMSoft.ProcessSchemaParameterValueSource.None;
				this.set(attribute, attributeName);
			},

			/**
			 * Cleans author email address.
			 * @private
			 */
			_cleanAuthorEmailAddress: function() {
				this.setMappingEditValue("AuthorEmailAddress", {
					referenceSchemaUId: null,
					displayValue: null,
					value: null,
					source: BPMSoft.ProcessSchemaParameterValueSource.None
				});
			},

			/**
			 * Cleans attributes depends on ApproverType value.
			 * @private
			 */
			_cleanAttributesByApproverType: function() {
				var approverType = this.get("ApproverType") || {};
				var type = ProcessUserTaskConstants.APPROVER_TYPE;
				if (approverType.value !== type.Employee && approverType.value !== type.EmployeeManager) {
					this._cleanMappingValue("EmployeeId");
				}
				if (approverType.value !== type.Role) {
					this._cleanMappingValue("RoleId");
				}
			},

			/**
			 * Cleans attributes.
			 * @private
			 */
			_cleanAttributes: function() {
				this._cleanAttributesByApproverType();
				if (!this.get("IsSendEmailToApprovers")) {
					this._cleanMappingValue("ApproverEmailTemplate");
				}
				if (!this.get("IsSendEmailToAuthor")) {
					this._cleanMappingValue("AuthorEmailTemplate");
					this._cleanAuthorEmailAddress();
				}
			},

			/**
			 * Saves ApprovalSchemaUId parameter.
			 * @private
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 * @param {BPMSoft.manager.SysModuleVisaManagerItem} sysModuleVisa Current visa manager item.
			 */
			_saveApprovalSchemaUId: function(element, sysModuleVisa) {
				var parameter = element.getParameterByName("ApprovalSchemaUId");
				if (sysModuleVisa) {
					parameter.setMappingValue({
						value: sysModuleVisa.getVisaSchemaUId(),
						source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
					});
				} else {
					parameter.setMappingValue({});
				}
			},
			/**
			 * Saves ApprovalSchemaUId parameter.
			 * @private
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 * @param {BPMSoft.manager.SysModuleVisaManagerItem} sysModuleVisa Current visa manager item.
			 */
			_saveMasterColumnUId: function(element, sysModuleVisa) {
				var parameter = element.getParameterByName("MasterColumnUId");
				if (sysModuleVisa) {
					parameter.setMappingValue({
						value: sysModuleVisa.getMasterColumnUId(),
						source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
					});
				} else {
					parameter.setMappingValue({});
				}
			},

			/**
			 * Saves to parameters data of SysModuleVisa.
			 * @private
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 */
			_saveSysModuleVisaParameters: function(element) {
				var sectionId = this.get("SectionId");
				var sysModuleVisa = this.findSysModuleVisa(sectionId);
				this._saveApprovalSchemaUId(element, sysModuleVisa);
				this._saveMasterColumnUId(element, sysModuleVisa);
			},

			/**
			 * @private
			 */
			_initManagers: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						BPMSoft.SysModuleEntityManager.initialize(next);
					},
					function(next) {
						BPMSoft.SectionManager.initialize(next);
					},
					function(next) {
						BPMSoft.SysModuleVisaManager.initialize(next);
					},
					function(next) {
						var packageUId = this.get("packageUId");
						BPMSoft.EntitySchemaManager.findPackageItems(packageUId, next, this);
					},
					function(next, schemaItems) {
						this.set("EntitySchemaList", schemaItems);
						callback.call(scope);
					},
					this
				);
			},

			/**
			 * Returns config for author email address.
			 * @protected
			 * @return {Object}
			 */
			_getAuthorEmailAddressParameterConfig: function() {
				var processElement = this.get("ProcessElement");
				var parentSchema = processElement.parentSchema;
				var processSchemaUId = parentSchema.uId;
				var caption = this.get("Resources.Strings.RecipientCaption");
				return {
					uId: BPMSoft.generateGUID(),
					caption: Ext.create("BPMSoft.LocalizableString", {
						cultureValues: caption
					}),
					createdInSchemaUId: processSchemaUId,
					modifiedInSchemaUId: processSchemaUId,
					name: "AuthorEmailAddress",
					dataValueType: BPMSoft.DataValueType.MAXSIZE_TEXT,
					sourceValue: {
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					}
				};
			},

			/**
			 * Creates author email address parameter.
			 * @private
			 * @return {BPMSoft.DynamicProcessSchemaParameter}
			 */
			_createAuthorEmailAddressParameter: function() {
				var processElement = this.get("ProcessElement");
				var parameterMetaData = this._getAuthorEmailAddressParameterConfig();
				var elementParameter = Ext.create("BPMSoft.DynamicProcessSchemaParameter", parameterMetaData);
				elementParameter.processFlowElementSchema = processElement;
				processElement.parameters.add(elementParameter.uId, elementParameter);
				return elementParameter;
			},

			/**
			 * @private
			 */
			_getSectionList: function() {
				var enttitySchemaList = this.get("EntitySchemaList");
				var sectionItems = BPMSoft.SectionManager.filterByFn(function(item) {
					var sysModuleVisaId = item.getSysModuleVisaId();
					var sysModuleEntityId = item.getSysModuleEntityId();
					if (sysModuleVisaId && sysModuleEntityId) {
						var sysModuleEntity = BPMSoft.SysModuleEntityManager.getItem(sysModuleEntityId);
						var entitySchemaUId = sysModuleEntity.getEntitySchemaUId();
						return enttitySchemaList.contains(entitySchemaUId);
					}
				}, this);
				sectionItems.sort("caption", BPMSoft.OrderDirection.ASC);
				var resultConfig = {};
				sectionItems.each(function(item) {
					var sectionId = item.getId();
					resultConfig[sectionId] = {
						value: sectionId,
						displayValue: item.getCaption(),
						name: item.getCode()
					};
				}, this);
				return resultConfig;
			},

			/**
			 * @private
			 */
			_getSectionByEntitySchema: function(entitySchemaUId, callback, scope) {
				BPMSoft.SysModuleEntityManager.findItemsByEntitySchemaUId(entitySchemaUId, function(items) {
					var section;
					var item = items.first();
					if (item) {
						var sysModuleEntityId = item.getId();
						section = BPMSoft.SectionManager.getItems().findByFn(function(foundItem) {
							return foundItem.getSysModuleEntityId() === sysModuleEntityId;
						}, this);
					}
					callback.call(scope, section);
				}, this);
			},

			/**
			 * @private
			 */
			_getEntitySchemaBySection: function(sectionId) {
				if (sectionId) {
					var section = BPMSoft.SectionManager.getItem(sectionId);
					var sysModuleEntityId = section.getSysModuleEntityId();
					if (sysModuleEntityId) {
						var sysModuleEntity = BPMSoft.SysModuleEntityManager.getItem(sysModuleEntityId);
						var entitySchemaUId = sysModuleEntity.getEntitySchemaUId();
						return entitySchemaUId;
					}
				}
			},

			/**
			 * @private
			 */
			_getVisaSchemaUId: function() {
				var sectionId = this.get("SectionId");
				var sysModuleVisa = this.findSysModuleVisa(sectionId);
				return sysModuleVisa ? sysModuleVisa.getVisaSchemaUId() : null;
			},

			/**
			 * @private
			 */
			_setApproverEmailTemplate: function(emailTemplateId) {
				const emailTemplateSchemaUId = ConfigurationConstants.SysSchema.EmailTemplate;
				const valueMacros = BPMSoft.FormulaMacros.prepareLookupValue(emailTemplateSchemaUId, emailTemplateId);
				const value = BPMSoft.ProcessSchemaDesignerUtilities.addParameterMask(valueMacros.getBody());
				const processSchema = this.get("ProcessElement").parentSchema;
				BPMSoft.FormulaParserUtils.getFormulaDisplayValue(value, processSchema, function(displayValue) {
					this.applyParameterMappingEditValue("ApproverEmailTemplate", {
						value: value,
						displayValue: displayValue,
						source: BPMSoft.ProcessSchemaParameterValueSource.Script
					});
				}, this);
			},

			/**
			 * @private
			 */
			_onBroadcastServerMessage: function(channel, message) {
				const event = message && message.event;
				if (event === "EmailTemplatePageSaved" && this.get("AddEmailTemplateButtomClicked")) {
					this.set("AddEmailTemplateButtomClicked", false);
					BPMSoft.defer(function() {
						this._setApproverEmailTemplate(message.id);
					}, this);
				}
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
			 * @override
			 */
			getParameterReferenceSchemaUId: function(elementParameter) {
				return elementParameter ? elementParameter.referenceSchemaUId : null;
			},

			/**
			 * Returns current SysModuleVisa manager item.
			 * @protected
			 * @return {BPMSoft.manager.SysModuleVisaManagerItem}
			 */
			findSysModuleVisa: function(sectionId) {
				if (sectionId) {
					var section = BPMSoft.SectionManager.getItem(sectionId);
					var sysModuleVisaId = section.getSysModuleVisaId();
					var sysModuleVisa = BPMSoft.SysModuleVisaManager.findItem(sysModuleVisaId);
					return sysModuleVisa;
				}
			},

			/**
			 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
			 * @override
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					BPMSoft.chain(
						this._initManagers,
						this.initSection,
						function() {
							this.initRecordId();
							BPMSoft.ServerChannel.on(BPMSoft.ServerChannelSender.BROADCAST_MESSAGE,
								this._onBroadcastServerMessage, this);
							callback.call(scope);
						}, this
					);
				}, this]);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#customValidator
			 * @override
			 */
			customValidator: function() {
				this._validateRecordId();
				this._validateApproval();
				this._validateEmailTemplate("IsSendEmailToApprovers", "ApproverEmailTemplate");
				this._validateEmailTemplate("IsSendEmailToAuthor", "AuthorEmailTemplate");
				this._validateEmailTemplate("IsSendEmailToAuthor", "AuthorEmailAddress");
				return {
					invalidMessage: ""
				};
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
			 * @override
			 */
			getResultParameterAllValues: function(callback, scope) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VisaStatus"
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "IsFinal", true);
				esq.filters.addItem(filter);
				esq.getEntityCollection(function(response) {
					var resultValues = {};
					if (response.success) {
						response.collection.each(function(item) {
							var id = item.get("Id");
							var name = item.get("Name");
							resultValues[id] = name;
						}, this);
					}
					callback.call(scope, resultValues);
				}, this);
			},

			/**
			 * Handler for prepareList of SectionSelect control.
			 * @protected
			 */
			prepareSectionList: function(filter, list) {
				if (list === null) {
					return;
				}
				this._loadSectionList(list);
			},

			/**
			 * Handler of SectionSelect change.
			 * @protected
			 */
			onSectionSelectChanged: function() {
				var section = this.get("SectionSelect");
				var sectionId = this.Ext.isObject(section) ? section.value : section;
				this.set("SectionId", sectionId);
				var entitySchemaUId = this._getEntitySchemaBySection(sectionId);
				this.set("EntitySchemaUId", entitySchemaUId);
				this._clearRecordId();
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
			 * @override
			 */
			saveValues: function() {
				this._cleanAttributes();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
			 * @override
			 */
			saveParameters: function(element) {
				this._saveSysModuleVisaParameters(element);
				this.callParent(arguments);
			},

			/**
			 * The event handler for preparing of the data drop-down period.
			 * @protected
			 * @param {Object} filter Filters for data preparation.
			 * @param {BPMSoft.Collection} list The data for the drop-down list.
			 */
			onPrepareApproverTypeList: function(filter, list) {
				if (BPMSoft.isEmptyObject(list)) {
					return;
				}
				var enumConfig = this.get("ApproverTypeEnum");
				list.clear();
				list.loadAll(enumConfig);
			},

			/**
			 * Returns flag that indicate whether EmployeeId field is visible or not.
			 * @protected
			 * @return {Boolean}
			 */
			getIsEmployeeVisible: function() {
				var approverType = this.get("ApproverType");
				if (!approverType) {
					return false;
				}
				var type = ProcessUserTaskConstants.APPROVER_TYPE;
				return Ext.Array.contains([type.Employee, type.EmployeeManager], approverType.value);
			},

			/**
			 * Returns flag that indicate whether RoleId field is visible or not.
			 * @protected
			 * @return {Boolean}
			 */
			getIsRoleVisible: function() {
				var approverType = this.get("ApproverType");
				return Boolean(approverType && approverType.value === ProcessUserTaskConstants.APPROVER_TYPE.Role);
			},

			/**
			 * Returns flag that indicate whether RecordId field is visible or not.
			 * @protected
			 * @return {Boolean}
			 */
			getIsRecordIdVisible: function() {
				var entitySchemaUId = this.get("EntitySchemaUId");
				return Boolean(entitySchemaUId);
			},

			/**
			 * Returns flag that indicate whether eIgnoreEmailErrors field is visible or not.
			 * @protected
			 * @return {Boolean}
			 */
			getIsVisibleIgnoreEmailErrors: function() {
				return this.get("IsSendEmailToApprovers") || this.get("IsSendEmailToAuthor");
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
			 * @override
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				var parameter = element.findParameterByName("AuthorEmailAddress") ||
					this._createAuthorEmailAddressParameter();
				this.initProperty(parameter);
			},

			/**
			 * Saves author email address.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			saveAuthorEmailAddress: function(parameter) {
				var authorEmailAddress = this.get("AuthorEmailAddress");
				parameter.dataValueType = authorEmailAddress.dataValueType;
				this.saveParameter(parameter);
			},

			/**
			 * Initialization RecordId parameter value.
			 * @protected
			 */
			initRecordId: function() {
				var element = this.get("ProcessElement");
				var parameter = element.findParameterByName("RecordId");
				parameter.dataValueType = BPMSoft.DataValueType.LOOKUP;
				parameter.referenceSchemaUId = this.get("EntitySchemaUId");
				var recordId = this.getParameterValue(parameter);
				this.set("RecordId", recordId);
			},

			/**
			 * Handles open email template click. Opens email template designer in new window if exists,
			 * otherwise opens email template add page.
			 * @protected
			 * @param {String} tag Email template attribute.
			 */
			onOpenEmailTemplateButtonClick: function(a1, a2, a3, tag) {
				var template = this.get(tag);
				var value = template && template.value;
				if (value && BPMSoft.FormulaParserUtils.getIsLookupMappingMacros(value)) {
					var recordId = BPMSoft.FormulaParserUtils.getLookupValue(value);
					if (BPMSoft.Features.getIsEnabled("MultiLanguageContentBuilderEnabled")) {
						this.openMultilingualContentBuilder(recordId);
					} else {
						NetworkUtilities.openCardWindow({
							cardSchemaName: "EmailTemplatePageMultilingual",
							operation: "edit",
							primaryColumnValue: recordId
						});
					}
				} else {
					this.set("AddEmailTemplateButtomClicked", true);
					const visaSchemaUId = this._getVisaSchemaUId();
					NetworkUtilities.openCardWindow({
						cardSchemaName: "EmailTemplatePageMultilingual",
						operation: "add",
						primaryColumnValue: visaSchemaUId
					});
				}
			},

			/**
			 * Returns filter for email template mapping window.
			 * @protected
			 * @return {BPMSoft.FilterGroup|null}
			 */
			getEmailTemplateFilter: function() {
				var visaSchemaUId = this._getVisaSchemaUId();
				var filters = null;
				if (visaSchemaUId) {
					filters = Ext.create("BPMSoft.FilterGroup");
					filters.addItem(BPMSoft.createColumnFilterWithParameter("Object.Id", visaSchemaUId));
				}
				return filters;
			},

			/**
			 * Initialization Purpose parameter value.
			 * @protected
			 */
			initPurpose: function(parameter) {
				if (!parameter.hasValue()) {
					parameter.setMappingValue({
						value: this.get("Resources.Strings.DefaultPurpose"),
						source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
					});
				}
				this.initProperty(parameter);
			},

			/**
			 * Open multilingual content builder for template.
			 * @param recordId {String} Id of template.
			 * @protected
			 */
			openMultilingualContentBuilder: function(recordId) {
				var mode = EmailTemplateMLangContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATE;
				var url = EmailTemplateMLangContentBuilderEnumsModule.getContentBuilderUrl(mode, recordId);
				window.open(url);
			},

			// endregion

			// region Methods: Public

			/**
			 * Returns open or add button hint.
			 * @param {Object} mapping Parameter mapping.
			 */
			getOpenEmailTemplateButtonHint: function(mapping) {
				if (mapping && mapping.value) {
					return this.get("Resources.Strings.OpenTemplateHint");
				} else {
					return this.get("Resources.Strings.AddTemplateHint");
				}
			},

			/**
			 * Returns open or add button image.
			 * @param {Object} mapping Parameter mapping.
			 */
			getOpenEmailTemplateButtonImageConfig: function(mapping) {
				if (mapping && mapping.value) {
					return this.get("Resources.Images.OpenButtonImage");
				} else {
					return this.get("Resources.Images.AddButtonImage32");
				}
			},

			/**
			 * Handles settings info button click. Opens SysSettings edit card in new window
			 * @param {Object} sender Event sender.
			 * @param {String} tag SysSetting code.
			 */
			onSettingsInfoButtonLinkClick: function(sender, tag) {
				BPMSoft.SysSettings.querySysSettingsRaw([tag], function(result) {
					var row = result.values[tag];
					NetworkUtilities.openCardWindow({
						cardSchemaName: "SysSettingPage",
						primaryColumnValue: row.id,
						operation: "edit"
					});
				}, this);
				return false;
			},

			/**
			 * Initializes attributes SectionId and SectionSelect.
			 * @protected
			 */
			initSection: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						var sectionId = this.get("SectionId");
						var entitySchemaUId = this.get("EntitySchemaUId");
						if (!sectionId && entitySchemaUId) {
							this._getSectionByEntitySchema(entitySchemaUId, next, this);
						} else {
							var section = sectionId && BPMSoft.SectionManager.findItem(sectionId);
							next(section);
						}
					},
					function(next, section) {
						if (section) {
							this.set("SectionId", section.getId());
							this.set("SectionSelect", {
								value: section.getId(),
								displayValue: section.getCaption(),
								name: section.getCode()
							});
						} else {
							this.set("SectionId", null);
							this.set("SectionSelect", null);
						}
						this.on("change:SectionSelect", this.onSectionSelectChanged, this);
						this.setValidationInfo("SectionSelect", true, null);
						callback.call(scope);
					}, this
				);
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "EditorsContainer",
				"name": "UserTaskContainer",
				"propertyName": "items",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"name": "PurposeContainer",
				"propertyName": "items",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "PurposeContainer",
				"name": "PurposeLabel",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.PurposeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PurposeContainer",
				"name": "Purpose",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"name": "ApprovalObjectContainer",
				"propertyName": "items",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ApprovalObjectContainer",
				"name": "ApprovalObjectLabel",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.ApprovalObjectCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApprovalObjectContainer",
				"name": "SectionContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"items": [],
					"wrapClass": ["label-info-button-container-wrapClass"]
				}
			},
			{
				"operation": "insert",
				"parentName": "SectionContainer",
				"name": "SectionSelect",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control", "entity-schema-select-control"],
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareSectionList"
						},
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN,
						"readonly": {
							"bindTo": "IsSectionSelectReadonly"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SectionContainer",
				"name": "SectionSelectInfoButton",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {
						"bindTo": "Resources.Strings.SectionSelectInfoButtonCaption"
					},
					"controlConfig": {
						"classes": {
							"wrapperClass": "entity-schema-select-info-button"
						},
						"visible": {
							"bindTo": "IsSectionSelectInfoButtonVisible"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApprovalObjectContainer",
				"name": "RecordId",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.RecordIdCaption"
					},
					"visible": {
						"bindTo": "SectionSelect",
						"bindConfig": {"converter": "getIsRecordIdVisible"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "UserTaskContainer",
				"name": "ApproverContainer",
				"propertyName": "items",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "ApproverLabel",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.ApproverCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "ApproverType",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareApproverTypeList"
						}
					},
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "EmployeeId",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.EmployeeIdCaption"
					},
					"visible": {
						"bindTo": "ApproverType",
						"bindConfig": {"converter": "getIsEmployeeVisible"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "RoleId",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.RoleIdCaption"
					},
					"visible": {
						"bindTo": "ApproverType",
						"bindConfig": {"converter": "getIsRoleVisible"}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "IsAllowedToDelegate",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 4, "colSpan": 24},
					"caption": {
						"bindTo": "Resources.Strings.IsAllowedToDelegateCaption"
					},
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"name": "SendEmailLabelContainer",
				"parentName": "ApproverContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 24
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SendEmailLabelContainer",
				"name": "SendEmailLabel",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": [
							"t-title-label-proc",
							"t-title-label-info-button-proc"
						]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SendEmailCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SendEmailLabelContainer",
				"propertyName": "items",
				"name": "VisaMailboxSettingsInfoButton",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {
						"bindTo": "Resources.Strings.VisaMailboxSettings"
					},
					"linkClicked": {
						"bindTo": "onSettingsInfoButtonLinkClick"
					},
					"tag": "VisaMailboxSettings",
					"controlConfig": {
						"classes": {
							"wrapperClass": "visa-mailbox-settings-info-button"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "IsSendEmailToApprovers",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 6, "colSpan": 24},
					"caption": {
						"bindTo": "Resources.Strings.IsSendEmailToApproversCaption"
					},
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "ApproverEmailTemplate",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 7, "colSpan": 22},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.EmailTemplateCaption"
					},
					"visible": {
						"bindTo": "IsSendEmailToApprovers"
					}
				}
			},
			{
				"operation": "insert",
				"name": "OpenApproverEmailTemplate",
				"parentName": "ApproverContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"layout": {"column": 22, "row": 7, "colSpan": 2},
					"hint": {
						"bindTo": "ApproverEmailTemplate",
						"bindConfig": {
							"converter": "getOpenEmailTemplateButtonHint"
						}
					},
					"imageConfig": {
						"bindTo": "ApproverEmailTemplate",
						"bindConfig": {
							"converter": "getOpenEmailTemplateButtonImageConfig"
						}
					},
					"classes": {
						"wrapperClass": ["open-email-template-tool-button"]
					},
					"click": {
						"bindTo": "onOpenEmailTemplateButtonClick"
					},
					"visible": {
						"bindTo": "IsSendEmailToApprovers"
					},
					"tag": "ApproverEmailTemplate"
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "IsSendEmailToAuthor",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 8, "colSpan": 24},
					"caption": {
						"bindTo": "Resources.Strings.IsSendEmailToAuthorCaption"
					},
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "AuthorEmailAddress",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 9, "colSpan": 24},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.RecipientCaption"
					},
					"visible": {
						"bindTo": "IsSendEmailToAuthor"
					},
					"tag": {
						"attributeName": "AuthorEmailAddress",
						"typeMappingMenu": BPMSoft.process.constants.TypeMappingMenu.EmailRecipientType
					},
					"controlConfig": {
						"allowInlineEditing": true,
						"change": {
							"bindTo": "onRecipientValueChanged"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ApproverContainer",
				"name": "AuthorEmailTemplate",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 10, "colSpan": 22},
					"wrapClass": ["top-caption-control"],
					"caption": {
						"bindTo": "Resources.Strings.EmailTemplateCaption"
					},
					"visible": {
						"bindTo": "IsSendEmailToAuthor"
					}
				}
			},
			{
				"operation": "insert",
				"name": "OpenAuthorEmailTemplate",
				"parentName": "ApproverContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"layout": {"column": 22, "row": 10, "colSpan": 2},
					"hint": {
						"bindTo": "AuthorEmailTemplate",
						"bindConfig": {
							"converter": "getOpenEmailTemplateButtonHint"
						}
					},
					"imageConfig": {
						"bindTo": "AuthorEmailTemplate",
						"bindConfig": {
							"converter": "getOpenEmailTemplateButtonImageConfig"
						}
					},
					"classes": {"wrapperClass": ["open-email-template-tool-button"]},
					"click": {
						"bindTo": "onOpenEmailTemplateButtonClick"
					},
					"visible": {
						"bindTo": "IsSendEmailToAuthor"
					},
					"tag": "AuthorEmailTemplate"
				}
			},
			{
				"operation": "insert",
				"name": "IgnoreEmailErrors",
				"parentName": "ApproverContainer",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 11, "colSpan": 24},
					"caption": {
						"bindTo": "Resources.Strings.IgnoreEmailErrorsCaption"
					},
					"wrapClass": ["t-checkbox-control"],
					"visible": {
						"bindTo": "getIsVisibleIgnoreEmailErrors"
					}
				}
			},
			{
				"operation": "insert",
				"name": "useBackgroundMode",
				"parentName": "ApproverContainer",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 12, "colSpan": 24},
					"visible": {
						"bindTo": "canUseBackgroundProcessMode"
					},
					"wrapClass": ["t-checkbox-control"]
				}
			}
		]
	};
});
