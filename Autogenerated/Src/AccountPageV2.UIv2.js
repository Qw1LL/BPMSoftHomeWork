define("AccountPageV2", ["BaseFiltersGenerateModule", "ConfigurationEnums", "ConfigurationConstants", "BusinessRuleModule",
			"AccountPageV2Resources", "CommunicationSynchronizerMixin", "AccountPageMixin", "CommunicationOptionsMixin"],
		function(BaseFiltersGenerateModule, Enums, ConfigurationConstants, BusinessRuleModule) {
			return {
				entitySchemaName: "Account",
				messages: {
					/**
					 * @message UpdateRelationshipDiagram
					 * Reloads relationship diagram.
					 */
					"UpdateRelationshipDiagram": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message SetInitialisationData
					 * Sets initial values for search in social networks.
					 */
					"SetInitialisationData": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message ResultSelectedRows
					 * Returs selected rows in reference.
					 */
					"ResultSelectedRows": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetCommunicationsList
					 * Requests communications list.
					 */
					"GetCommunicationsList": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message SyncCommunication
					 * Synchronizes communications.
					 */
					"SyncCommunication": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message GetCommunicationsSynchronizedByDetail
					 * Requests communications synchronized by detail.
					 */
					"GetCommunicationsSynchronizedByDetail": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message CallCustomer
					 * Starts phone call in CTI panel.
					 */
					"CallCustomer": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
					"Owner": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
					},
					"AnnualRevenue": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							orders: [{columnPath: "FromBaseCurrency"}]
						}
					},
					"EmployeesNumber": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							orders: [{columnPath: "Position"}]
						}
					},
					"canUseSocialFeaturesByBuildType": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Account communication detail name.
					 */
					"CommunicationDetailName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: "Communications"
					},
					/**
					 * Account phone.
					 */
					"Phone": {
						"dependencies": [
							{
								"columns": ["Phone"],
								"methodName": "syncEntityWithCommunicationDetail"
							}
						]
					},
					/**
					 * Account additional phone.
					 */
					"AdditionalPhone": {
						"dependencies": [
							{
								"columns": ["AdditionalPhone"],
								"methodName": "syncEntityWithCommunicationDetail"
							}
						]
					},
					/**
					 * Account fax.
					 */
					"Fax": {
						"dependencies": [
							{
								"columns": ["Fax"],
								"methodName": "syncEntityWithCommunicationDetail"
							}
						]
					},
					/**
					 * Account web.
					 */
					"Web": {
						"dependencies": [
							{
								"columns": ["Web"],
								"methodName": "syncEntityWithCommunicationDetail"
							}
						]
					},
					"Email": {
						"dependencies": [
							{
								"columns": ["Email"],
								"methodName": "syncEntityWithCommunicationDetail"
							}
						]
					}
				},
				rules: {
					"Region": {
						"FiltrationRegionByCountry": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Country",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Country"
						}
					},
					"City": {
						"FiltrationCityByCountry": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Country",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Country"
						},
						"FiltrationCityByRegion": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							autoClean: true,
							baseAttributePatch: "Region",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Region"
						}
					}
				},
				details: /**SCHEMA_DETAILS*/{
					Communications: {
						schemaName: "AccountCommunicationDetail",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					Activities: {
						schemaName: "ActivityDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						},
						useRelationship: true

					},
					AccountBillingInfo: {
						schemaName: "AccountBillingInfoDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					AccountOrganizationChart: {
						schemaName: "AccountOrganizationChartDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					AccountContacts: {
						schemaName: "AccountContactsDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						},
						useRelationship: true,
						filterMethod: "_getContactCareerFilter"
					},
					Files: {
						schemaName: "FileDetailV2",
						entitySchemaName: "AccountFile",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					AccountAddress: {
						schemaName: "AccountAddressDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					AccountAnniversary: {
						schemaName: "AccountAnniversaryDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						}
					},
					Relationships: {
						schemaName: "AccountRelationshipDetailV2",
						filterMethod: "relationshipDetailFilter",
						defaultValues: {
							AccountA: {
								masterColumn: "Id"
							}
						}
					},
					EmailDetailV2: {
						schemaName: "EmailDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Account"
						},
						filterMethod: "emailDetailFilter"
					}
				}/**SCHEMA_DETAILS*/,
				modules: /**SCHEMA_MODULES*/{
					"ContactProfile": {
						"config": {
							"schemaName": "ContactProfileSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									"masterColumnName": "PrimaryContact",
									"profileColumnName": "Account"
								}
							}
						}
					},
					"ActionsDashboardModule": {
						"config": {
							"isSchemaConfigInitialized": true,
							"schemaName": "SectionActionsDashboard",
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									"entitySchemaName": "Account",
									"dashboardConfig": {
										"Activity": {
											"masterColumnName": "Id",
											"referenceColumnName": "Account"
										}
									}
								}
							}
						}
					}
				}/**SCHEMA_MODULES*/,
				/**
				 * Current schema mixins
				 */
				mixins: {
					/**
					 * @class CommunicationSynchronizerMixin Mixin, used for sync communications.
					 */
					CommunicationSynchronizerMixin: "BPMSoft.CommunicationSynchronizerMixin",
					/**
					 * @class AccountPageMixin Mixin, implements common business logic for Account.
					 */
					AccountPageMixin: "BPMSoft.AccountPageMixin",
					/**
					 * @class CommunicationOptionsMixin Mixin, implements communication options usage methods.
					 */
					CommunicationOptionsMixin: "BPMSoft.CommunicationOptionsMixin"
				},
				methods: {

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.initSyncMailboxCount();
						var sysSettings = ["BuildType"];
						BPMSoft.SysSettings.querySysSettings(sysSettings, function() {
							var buildType = BPMSoft.SysSettings.cachedSettings.BuildType &&
									BPMSoft.SysSettings.cachedSettings.BuildType.value;
							this.set("canUseSocialFeaturesByBuildType", buildType !==
									ConfigurationConstants.BuildType.Public);
						}, this);
					},

					/**
					 * @obsolete
					 */
					findContactsInSocialNetworks: function() {
						var activeRowId = this.get("Id");
						if (activeRowId !== undefined) {
							var recordName = this.get("Name");
							var config = {
								entitySchemaName: "Account",
								mode: "search",
								recordId: activeRowId,
								recordName: recordName
							};
							var historyState = this.sandbox.publish("GetHistoryState");
							this.sandbox.publish("PushHistoryState", {
								hash: historyState.hash.historyState,
								silent: true
							}, this);
							this.sandbox.loadModule("FindContactsInSocialNetworksModule", {
								renderTo: "centerPanel",
								id: this.sandbox.id + "_FindContactsInSocialNetworksModule",
								keepAlive: true
							});
							this.sandbox.subscribe("ResultSelectedRows", function(args) {
								this.set("Number", args.name);
								this.set("SocialMediaId", args.id);
							}, this, [this.sandbox.id + "_FindContactsInSocialNetworksModule"]);
							this.sandbox.subscribe("SetInitialisationData", function() {
								return config;
							}, [this.sandbox.id + "_FindContactsInSocialNetworksModule"]);
						}
					},

					/**
					 * Returns filters for relationship detail.
					 * @protected
					 * @return {BPMSoft.FilterGroup} Filters for detail.
					 */
					relationshipDetailFilter: function() {
						var recordId = this.get("Id");
						var filterGroup = new this.BPMSoft.createFilterGroup();
						filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
						filterGroup.add("AccountAFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Account", recordId));
						return filterGroup;
					},

					/**
					 * Returns filters for email detail.
					 * @protected
					 * @return {BPMSoft.FilterGroup} Filters for detail.
					 */
					emailDetailFilter: function() {
						var recordId = this.get("Id");
						var filterGroup = new this.BPMSoft.createFilterGroup();
						filterGroup.add("AccountNotNull", this.BPMSoft.createColumnIsNotNullFilter("Account"));
						filterGroup.add("AccountConnection", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Account", recordId));
						filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
						return filterGroup;
					},

					/**
					 * Creates filters for History detail.
					 * @protected
					 * @return {BPMSoft.FilterGroup} Filters for detail.
					 */
					historyDetailFilter: function() {
						var filterGroup = new this.BPMSoft.createFilterGroup();
						filterGroup.add("AccountFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"Account", this.get("Id")));
						filterGroup.add("sysWorkspacedetailFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL,
								"SysEntity.SysWorkspace", this.BPMSoft.SysValue.CURRENT_WORKSPACE.value));
						return filterGroup;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#asyncValidate
					 * @overridden
					 */
					asyncValidate: function() {
						if (this.changedValues && this.changedValues.PrimaryContact) {
							this.set("PrimaryContactChanged", true);
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#save
					 * @overridden
					 */
					save: function() {
						this.clearChangedValuesSynchronizedByDetail();
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onSaved
					 * @overridden
					 */
					onSaved: function(response, config) {
						if ((config && config.isSilent) || this.get("PrimaryContactAdded") ||
								(!this.isAddMode() && Ext.isEmpty(this.get("PrimaryContact"))) ||
								(config && config.callParent === true)) {
							if (this.get("PrimaryContactChanged")) {
								this.onUpdateContactAccount(function () {
									config = config || {};
									config.callParent = true;
									this.onSaved(response, config);
								}, this);
								return;
							}
							this.callParent(arguments);
							if (!this.get("IsInChain")) {
								this.updateDetail({detail: "Relationships"});
							} else {
								this.sandbox.publish("UpdateRelationshipDiagram", null, [this.sandbox.id]);
							}
						} else if (this.isAddMode() && Ext.isEmpty(this.get("PrimaryContact"))) {
							this.showConfirmationDialog(this.get("Resources.Strings.AddPrimaryContact"), function(result) {
								if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.addPrimaryContact();
									this.set("Operation", Enums.CardStateV2.EDIT);
									this.set("IsChanged", this.isChanged());
									this.updateButtonsVisibility(false);
								} else {
									config = config || {};
									config.callParent = true;
									this.onSaved(response, config);
								}
							}, ["yes", "no"]);
						} else {
							this.onUpdateContactAccount(function () {
								config = config || {};
								config.callParent = true;
								this.onSaved(response, config);
							}, this);
						}
					},

					/**
					 * Executes when view was rendered.
					 * @overridden
					 * @protected
					 */
					onRender: function() {
						this.callParent(arguments);
						if (this.get("Restored") && this.get("PrimaryContactAdded")) {
							this.onSaved({
								success: true
							});
						}
					},

					/**
					 * @private
					 */
					_getCurrentContactCareerEsq: function(primaryContactId) {
						var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {
							rootSchemaName: "ContactCareer"
						});
						esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						esq.addColumn("Account");
						esq.addColumn("Primary");
						esq.addColumn("Current");
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Contact",
							primaryContactId));
						filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Current",
							1));
						esq.filters = filters;
						return esq;
					},

					/**
					 * Updates primary contact career.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					onUpdateContactAccount: function(callback, scope) {
						this.getPrimaryContactAccount(function(account) {
							var recordId = this.get("Id");
							var primaryContact = this.get("PrimaryContact");
							var primaryContactId = primaryContact.value;
							var primaryContactAccountId = account ? account.value : null;
							var isPrimaryContactChanged = this.get("PrimaryContactChanged");
							this.set("PrimaryContactChanged", false);
							if (!isPrimaryContactChanged || recordId === primaryContactAccountId) {
								callback.call(scope);
								return;
							}
							var accountName = this.get("Name");
							var careerConfig = {
								contactId: primaryContactId,
								isPrimary: true,
								isCurrent: true
							};
							var esq = this._getCurrentContactCareerEsq(primaryContactId);
							esq.execute(function(response) {
								if (response.success) {
									if (response.collection.getCount() > 0) {
										var isPrimary = false;
										response.collection.each(function(career) {
											if (career.get("Account") === recordId) {
												callback.call(scope, response);
												return;
											}
											if (career.get("Primary")) {
												isPrimary = true;
											}
										});
										var setMsg = this.Ext.String.format(
											this.get("Resources.Strings.SetAccountPrimaryCareer"),
											accountName, primaryContact.displayValue);
										this.showConfirmationDialog(setMsg, function(result) {
											if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
												if (isPrimary) {
													var updateCareerConfig = {
														contactId: primaryContact.value,
														isPrimary: false,
														dueDate: new Date()
													};
													this.updateContactCareer(function() {
														this.addContactCareer(callback, careerConfig, this);
													}, updateCareerConfig);
												} else {
													this.addContactCareer(callback, careerConfig, this);
												}
											} else {
												careerConfig.isPrimary = false;
												this.addContactCareer(callback, careerConfig, this);
											}
										}, ["yes", "no"]);
									} else {
										this.updateContactAccount(function() {
											this.addContactCareer(callback, careerConfig, this);
										}, primaryContact.value);
									}
								}
							}, this);
						}, this);
					},

					/**
					 * Creates filters for contact career.
					 * @private
					 * @return {BPMSoft.FilterGroup} Filter group for contact career.
					 */
					_getContactCareerFilter: function() {
						var primaryColumnValue = this.get(this.primaryColumnName);
						var careerFilterGroup = this.BPMSoft.createFilterGroup();
						careerFilterGroup.add("ByAccount", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "[ContactCareer:Contact:Id].Account",
							primaryColumnValue));
						careerFilterGroup.add("CurrentIsTrue", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "[ContactCareer:Contact:Id].Current", 1));
						var contactAccountAndCareerFilter = this.BPMSoft.createFilterGroup();
						contactAccountAndCareerFilter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
						contactAccountAndCareerFilter.add("ContactAccount",
							this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Account", primaryColumnValue));
						contactAccountAndCareerFilter.add("ContactCareer", careerFilterGroup);
						return contactAccountAndCareerFilter;
					},

					/**
					 * Sets value for contact career list.
					 * @protected
					 * @param {Function} [callback] Callback function.
					 * @param {Object} data Update data.
					 */
					updateContactCareer: function(callback, data) {
						var update = Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "ContactCareer"
						});
						var filters = update.filters;
						var contactIdFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Contact", data.contactId);
						var isCurrentFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Current", true);
						var isPrimaryFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Primary", true);
						filters.add("contactIdFilter", contactIdFilter);
						filters.add("isCurrentFilter", isCurrentFilter);
						filters.add("isPrimaryFilter", isPrimaryFilter);
						if (data.hasOwnProperty("isPrimary")) {
							update.setParameterValue("Primary", data.isPrimary, BPMSoft.DataValueType.BOOLEAN);
						}
						if (data.hasOwnProperty("isCurrent")) {
							update.setParameterValue("Current", data.isPrimary, BPMSoft.DataValueType.BOOLEAN);
						}
						if (data.hasOwnProperty("dueDate")) {
							update.setParameterValue("DueDate", data.dueDate, BPMSoft.DataValueType.DATE);
						}
						update.execute(function(result) {
							callback.call(this, result);
						}, this);
					},

					/**
					 * Updates account id for contact.
					 * @protected
					 * @param {Function} [callback] Callback function.
					 * @param {Guid} [contactId] Contact id.
					 */
					updateContactAccount: function(callback, contactId) {
						var recordId = this.get("Id");
						var update = Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "Contact"
						});
						var filters = update.filters;
						var contactIdFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Id", contactId);
						filters.add("contactIdFilter", contactIdFilter);
						update.setParameterValue("Account", recordId, BPMSoft.DataValueType.GUID);
						update.execute(function(result) {
							callback.call(this, result);
						}, this);
					},

					/**
					 * Adds main contact for account.
					 * @protected
					 */
					addPrimaryContact: function() {
						var recordId = this.get("Id");
						this.set("PrimaryContactAdded", true);
						var config = BPMSoft.configuration.ModuleStructure.Contact;
						this.openCardInChain({
							schemaName: config.cardSchema,
							operation: "add",
							primaryColumnValue: null,
							moduleId: this.sandbox.id + "_AddPrimaryContact",
							defaultValues: [{
								name: ["Account", "PrimaryContactAdd"],
								value: [recordId, true]
							}]
						});
					},

					/**
					 * Returns default values, that will be sent into new record of lookup column
					 * @overridden
					 * @param {String} columnName Column name.
					 * @return {Array} Array of default values.
					 */
					getLookupValuePairs: function(columnName) {
						var valuePairs = [];
						var column = this.getColumnByName(columnName);
						if (!this.Ext.isEmpty(column) && !this.Ext.isEmpty(column.referenceSchemaName) &&
								column.referenceSchemaName === "Contact") {
							var accountId = this.get("Id");
							if (this.isEditMode()) {
								valuePairs.push({
									name: "Account",
									value: accountId
								});
							}
						}
						return valuePairs;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#subscribeDetailEvents
					 */
					subscribeDetailEvents: function(detailConfig, detailName) {
						this.callParent(arguments);
						var detailId = this.getDetailId(detailName);
						this.sandbox.subscribe("GetLookupValuePairs", this.getLookupValuePairs, this, [detailId]);
					},

					/**
					 * Returns account logo url.
					 * @private
					 * @return {String} Account logo url.
					 */
					getAccountLogo: function() {
						var primaryImageColumnValue = this.get(this.primaryImageColumnName);
						if (primaryImageColumnValue) {
							return this.getSchemaImageUrl(primaryImageColumnValue);
						}
						return this.getAccountDefaultLogo();
					},

					/**
					 * Returns default account logo url.
					 * @private
					 * @return {String} Default account logo url.
					 */
					getAccountDefaultLogo: function() {
						return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultLogo"));
					},

					/**
					 * Image-edit control image changed handler.
					 * @private
					 * @param {File} photo Logo file.
					 */
					onLogoChange: function(photo) {
						if (!photo) {
							this.set(this.primaryImageColumnName, null);
							return;
						}
						this.BPMSoft.ImageApi.upload({
							file: photo,
							onComplete: this.onLogoUploaded,
							onError: this.onLogoUploadError,
							scope: this
						});
					},

					/**
					 * On logo uploaded handler.
					 * @protected
					 * @param {String} imageId Logo image id.
					 */
					onLogoUploaded: function(imageId) {
						const primaryImageColumnName = this.primaryImageColumnName;
						if (!primaryImageColumnName) {
							return;
						}
						
						this.set(primaryImageColumnName, {
							value: imageId,
							displayValue: "Photo"
						});
					},

					onLogoUploadError: function(imageId, error, xhr) {
						if (xhr.response) {
							var response = BPMSoft.decode(xhr.response);
							if (response.error) {
								BPMSoft.showMessage(response.error);
							}
						}
					},

					/**
					 * Starts call in CTI panel.
					 * @param {String} number Phone number to call.
					 * @return {Boolean} False, to stop click event propagation.
					 */
					onCallClick: function(number) {
						return this.callAccount(number, this.$Id, this.$PrimaryContact);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ActionsDashboardModule",
						"parentName": "ActionDashboardContainer",
						"propertyName": "items",
						"values": {
							"classes": {wrapClassName: ["actions-dashboard-module"]},
							"itemType": BPMSoft.ViewItemType.MODULE
						}
					},
					{
						"operation": "insert",
						"parentName": "LeftModulesContainer",
						"propertyName": "items",
						"name": "ContactProfile",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE
						}
					},
					{
						"operation": "insert",
						"name": "AccountPageGeneralTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0,
						"values": {
							"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ContactsAndStructureTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1,
						"values": {
							"caption": {"bindTo": "Resources.Strings.ContactsAndStructureTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "RelationshipTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 2,
						"values": {
							"caption": {"bindTo": "Resources.Strings.RelationshipTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "HistoryTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 3,
						"values": {
							"caption": {"bindTo": "Resources.Strings.HistoryTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "NotesTabContainer",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 4,
						"values": {
							"caption": {"bindTo": "Resources.Strings.NotesTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "CommonControlGroup",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "AccountPageGeneralInfoBlock",
						"parentName": "CommonControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"caption": {"bindTo": "Resources.Strings.AccountPageGeneralDetailCaption"},
							"controlConfig": {"collapsed": false}
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPageGeneralInfoBlock",
						"propertyName": "items",
						"name": "AccountPageGeneralContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
						}
					},
					{
						"operation": "insert",
						"name": "AccountPhotoContainer",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["image-edit-container", "profile-image-container"],
							"items": [],
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPhotoContainer",
						"propertyName": "items",
						"name": "Photo",
						"values": {
							"getSrcMethod": "getAccountLogo",
							"onPhotoChange": "onLogoChange",
							"width": "100%",
							"height": "100%",
							"readonly": false,
							"defaultImage": {
								"bindTo": "getAccountDefaultLogo"
							},
							"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
						}
					},
					{
						"operation": "insert",
						"name": "AccountName",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Name",
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24
							}
						},
						"alias": {
							"name": "Name",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AccountType",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Type",
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 24
							},
							"contentType": BPMSoft.ContentType.ENUM
						},
						"alias": {
							"name": "Type",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AccountOwner",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Owner",
							"layout": {
								"column": 0,
								"row": 5,
								"colSpan": 24
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.OwnerTip"}
							}
						},
						"alias": {
							"name": "Owner",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AccountWeb",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Web",
							"showValueAsLink": true,
							"href":  {
								"bindTo": "Web",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "openNewTab"
							},
							"layout": {
								"column": 0,
								"row": 6,
								"colSpan": 24
							}
						},
						"alias": {
							"name": "Web",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AccountPhone",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.PhoneEdit",
							"bindTo": "Phone",
							"showValueAsLink": {"bindTo": "isTelephonyEnabled"},
							"href":  {
								"bindTo": "Phone",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "onCallClick"
							},
							"layout": {
								"column": 0,
								"row": 7,
								"colSpan": 24
							}
						},
						"alias": {
							"name": "Phone",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "NewAccountCategory",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "AccountCategory",
							"layout": {
								"column": 0,
								"row": 8,
								"colSpan": 24
							},
							"contentType": BPMSoft.ContentType.ENUM
						},
						"alias": {
							"name": "AccountCategory",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AccountIndustry",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Industry",
							"layout": {
								"column": 0,
								"row": 9,
								"colSpan": 24
							}
						},
						"alias": {
							"name": "Industry",
							"excludeProperties": ["layout"],
							"excludeOperations": ["remove", "move"]
						}
					},
					{
						"operation": "insert",
						"name": "AlternativeName",
						"parentName": "AccountPageGeneralContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "AlternativeName",
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Code",
						"parentName": "AccountPageGeneralContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Code",
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "insert",
						"name": "CategoriesControlGroup",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.CategoriesGroupCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"name": "Communications",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"name": "AccountAddress",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "RelationshipTabContainer",
						"propertyName": "items",
						"name": "Relationships",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"name": "CategoriesControlGroupContainer",
						"parentName": "CategoriesControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "EmployeesNumber",
						"parentName": "CategoriesControlGroupContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "EmployeesNumber",
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "Ownership",
						"parentName": "CategoriesControlGroupContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Ownership",
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "AnnualRevenue",
						"parentName": "CategoriesControlGroupContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "AnnualRevenue",
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTabContainer",
						"propertyName": "items",
						"name": "Activities",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTabContainer",
						"propertyName": "items",
						"name": "EmailDetailV2",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"name": "AccountBillingInfo",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "AccountPageGeneralTabContainer",
						"propertyName": "items",
						"name": "AccountAnniversary",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ContactsAndStructureTabContainer",
						"propertyName": "items",
						"name": "AccountOrganizationChart",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ContactsAndStructureTabContainer",
						"propertyName": "items",
						"name": "AccountContacts",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesTabContainer",
						"propertyName": "items",
						"name": "Files",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"name": "NotesControlGroup",
						"parentName": "NotesTabContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"}
						}
					},
					{
						"operation": "insert",
						"parentName": "NotesControlGroup",
						"propertyName": "items",
						"name": "Notes",
						"values": {
							"contentType": BPMSoft.ContentType.RICH_TEXT,
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"labelConfig": {
								"visible": false
							},
							"controlConfig": {
								"imageLoaded": {
									"bindTo": "insertImagesToNotes"
								},
								"images": {
									"bindTo": "NotesImagesCollection"
								}
							}
						}
					},
					{
						"operation": "move",
						"name": "Header",
						"parentName": "LeftModulesContainer",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "merge",
						"name": "Header",
						"parentName": "LeftModulesContainer",
						"values": {
							"classes": {
								"wrapClassName": ["profile-container", "autofill-layout"]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
