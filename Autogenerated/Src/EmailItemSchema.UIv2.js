define("EmailItemSchema", ["EmailItemSchemaResources", "NetworkUtilities", "FormatUtils",
		"EmailConstants", "ConfigurationEnums", "ConfigurationConstants", "ProcessModuleUtilities", "RightUtilities",
		"BusinessRuleModule", "EmailUtilitiesV2", "NavigationServiceUtility", "LookupQuickAddMixin", "EntityConnectionLinksPanelItemUtilities",
		"EntityConnectionLinksUtilities", "EmailRelationsMixin", "RelatedEmailsMixin"],
	function(resources, NetworkUtilities, FormatUtils, EmailConstants, ConfigurationEnums,
			ConfigurationConstants, ProcessModuleUtilities, RightUtilities, BusinessRuleModule, EmailUtilities) {
		return {
			entitySchemaName: EmailConstants.entitySchemaName,
			mixins: {
				/**
				 * @class LookupQuickAddMixin provides adding new record from lookup.
				 */
				LookupQuickAddMixin: "BPMSoft.LookupQuickAddMixin",

				/**
				 * @class EntityConnectionLinksPanelItemUtilities Entity connection panel item mixin.
				 */
				EntityConnectionLinksPanelItemUtilities: "BPMSoft.EntityConnectionLinksPanelItemUtilities",

				/**
				 * @class BPMSoft.EntityConnectionLinksUtilities
				 * Mixin for obtain entity connection lookup columns.
				 */
				EntityConnectionLinksUtilities: BPMSoft.EntityConnectionLinksUtilities,

				/**
				 * @class BPMSoft.EmailRelationsMixin
				 * Email relations mixin.
				 */
				EmailRelationsMixin: BPMSoft.EmailRelationsMixin,

				/**
				 * @class BPMSoft.RelatedEmailsMixin
				 * Related emails methods mixin.
				 */
				RelatedEmailsMixin: BPMSoft.RelatedEmailsMixin
			},
			messages: {

				/**
				 * @message PushHistoryState
				 * Set next history state message.
				 */
				"PushHistoryState": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetHistoryState
				 * Get current history state message.
				 */
				"GetHistoryState": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message BackHistoryState
				 * Reverts history state message.
				 */
				"BackHistoryState": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ReloadCard
				 * Reload page data message.
				 */
				"ReloadCard": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message ShowRelatedEmails
				 * Loads related emails to email panel.
				 */
				"ShowRelatedEmails": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
				}
			},
			attributes: {

				/**
				 * Mask element selector.
				 * @type {String}
				 */
				"MaskSelector": {
					datavalueType: BPMSoft.DataValueType.TEXT,
					value: ".right-panel-modules-container"
				},

				/**
				 * Email title.
				 * @type {String}
				 */
				"MailTitleText": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * Sender name and address parse regexp.
				 * @type {String}
				 */
				"SenderInfoRegExp": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "(.+) <(.+)>"
				},

				/**
				 * Action button menu items.
				 * @Type {BPMSoft.BaseViewModelCollection}
				 */
				"ActionsMenuCollection": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * Avaliable emails process list.
				 * @Type {Array}
				 */
				"ProcessParametersArray": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Email relations columns list.
				 * @Type {Array}
				 */
				"EntityConnectionColumnList": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Default email relations columns list.
				 * @Type {Array}
				 */
				"DefaultEntityConnectionColumns": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * ####### ######### ########### ####.
				 */
				"IsLookupVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * ############ ####### ####### #####.
				 */
				"CurrentColumnName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * ######## # ####### ####### #####.
				 */
				"CurrentColumnValue": {
					dataValueType: BPMSoft.DataValueType.VIRTUAL_COLUMN,
					isLookup: true
				},

				/**
				 * ###### ######### ######## ### ############## #### #####.
				 */
				"CurrentRelationItemsList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * ########## ############ ######## ### ############## #### #####.
				 */
				"CurrentRelationRowCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					value: 5
				},

				/**
				 * #######, ######### ### ########### ######.
				 */
				"SenderContact": {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},

				/**
				 * #######, #################### ## ########.
				 */
				"IsEntityInitialized": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Flag, is short contact exists.
				 */
				"IsShortContact": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				/**
				 * ####### ########### #### ########## ##### #####.
				 */
				"IsAddNewRelationVisible": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Sender name.
				 */
				"SenderName": {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Short sender name.
				 */
				"ShortSenderName": {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * ##### ###########.
				 */
				"SenderEmail": {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * ####### ####### ######## ###########.
				 */
				"HasContact": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Is need reload item in panel.
				 */
				"IsNeedReload": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * Email sender contact.
				 */
				"EmailAuthor": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					dependencies: [
						{
							columns: ["Author", "SenderContact"],
							methodName: "setEmailAuthor"
						}
					]
				},

				/**
				 * Email entity relation column name.
				 */
				"EntityRelationColumnName": {
					dataValueType: this.BPMSoft.DataValueType.TEXT
				},

				/**
				 * Avaliable mailboxes unique identifiers array.
				 * @Type {Array}
				 */
				"Mailboxes": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Email has attachments flag.
				 * @Type {Boolean}
				 */
				"HasAttachments": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {

				/**
				 * Initializes starter values.
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.initParameters();
					this.initActionsMenuCollection();
					this.initSenderInfo();
					this.subscribeSandboxEvents();
					this.isNew = false;
					this.addEvents(
						/**
						 * @event
						 * Email item deleted event.
						 * @param {Object} viewModel Email item view model.
						 */
						"emailDeleted",

						/**
						 * @event
						 * Email item saved event.
						 * @param {Object} viewModel Email item view model.
						 */
						"entitySaved",

						/**
						 * @event
						 * Email item sender contact set event
						 * @param {Object} Email sender contact parameters.
						 */
						"senderSet"
					);
					this.callParent(arguments);
				},

				/**
				 * Subscribes mail model on sandbox messages.
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("BackHistoryState", this.onBackHistoryState, this);
				},

				/**
				 * Clears new email relation field, if realtion card closed using cancel button.
				 */
				onBackHistoryState: function() {
					var isCardOpened = this.get("IsCardOpened");
					if (isCardOpened) {
						this.set("CurrentColumnValue", null);
						this.set("IsCardOpened", false);
					}
				},

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#openPageForNewEntity
				 * @overriden
				 */
				openPageForNewEntity: function(columnName, displayColumnName, displayColumnValue) {
					var isCardOpened = this.get("IsCardOpened");
					var historyState = this.sandbox.publish("GetHistoryState");
					var state = historyState.state || {};
					var moduleId = state.moduleId;
					if (isCardOpened || moduleId.indexOf(columnName) > 0) {
						var defValues = [{
							name: displayColumnName,
							value: displayColumnValue
						}];
						this.sandbox.publish("ReloadCard", defValues);
					} else {
						this.set("IsCardOpened", true);
						this.mixins.LookupQuickAddMixin.openPageForNewEntity.apply(this, arguments);
					}
				},

				/**
				 * Initializes starter parameters.
				 */
				initParameters: function() {
					this.set("MailTitleText", this.getMailTitleText());
					this.set("MailDateText", this.getMailDate());
					this.set("IsProcessingButtonEnabled", true);
					this.initDefaultColumnName();
				},

				/**
				 * ####### ######## ##### ## ##### #######.
				 * @param {String} columnName ############ #######.
				 */
				clearColumn: function(columnName) {
					this.initDefaultColumnName();
					this.set(columnName, null);
					this.onSaveEntity();
				},

				/**
				 * Initializes the collection of the action button menu items.
				 */
				initActionsMenuCollection: function() {
					var actions = this.get("ActionsMenuCollection");
					var collection = this.getActionMenuCollection(actions);
					this.set("ActionsMenuCollection", collection);
				},

				/**
				 * Returns the collection of the action button menu items.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} collection Item menu collection.
				 * @virtual
				 * @return {BPMSoft.BaseViewModelCollection}
				 */
				getActionMenuCollection: function(collection) {
					if (this.isEmpty(collection)) {
						collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					}
					var processParams = this.get("ProcessParametersArray");
					if (this.isNotEmpty(processParams)) {
						var separator = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								"Id": BPMSoft.generateGUID(),
								"Type": "BPMSoft.MenuSeparator",
								"Caption": this.get("Resources.Strings.RunProcessMenuSeparator"),
								"MarkerValue": "RunProcess"
							}
						});
						collection.addItem(separator);
						this.BPMSoft.each(processParams, function(processParam) {
							var item = this.Ext.create("BPMSoft.BaseViewModel", {
								values: this.Ext.apply(processParam, {"Id": BPMSoft.generateGUID()})
							});
							collection.addItem(item);
						}, this);
					}
					if (this.getIsFeatureEnabled("EmailRelationAddingEnabled")) {
						this.addRelationItemsToActionMenu(collection);
					}
					var deleteSeparator = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"Id": BPMSoft.generateGUID(),
							"Type": "BPMSoft.MenuSeparator"
						}
					});
					collection.addItem(deleteSeparator);
					var deleteCaption = this.get("Resources.Strings.Delete");
					var deleteItem = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"Id": BPMSoft.generateGUID(),
							"Caption": deleteCaption,
							"Click": {bindTo: "onDeleteEmail"},
							"MarkerValue": deleteCaption
						}
					});
					collection.addItem(deleteItem);
					this.addRelatedEmailsAction(collection);
					return collection;
				},

				/**
				 * Adds related emails action to actions menu.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} collection Item menu collection.
				 */
				addRelatedEmailsAction: function(collection) {
					var relatedEmailsSeparator = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"Id": BPMSoft.generateGUID(),
							"Type": "BPMSoft.MenuSeparator"
						}
					});
					collection.addItem(relatedEmailsSeparator);
					var relatedEmailsCaption =  this.get("Resources.Strings.ShowRelatedEmails");
					var relatedEmailsItem = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							"Id": BPMSoft.generateGUID(),
							"Caption": relatedEmailsCaption,
							"Click": {bindTo: "onShowRelatedEmails"},
							"MarkerValue": relatedEmailsCaption
						}
					});
					collection.addItem(relatedEmailsItem);
				},

				/**
				 * Loads related to current email emails to panel.
				 * @protected
				 */
				onShowRelatedEmails: function() {
					this.sandbox.publish("ShowRelatedEmails", this.$Id);
				},

				/**
				 * Adds menu items to action menu relation.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} collection Action menu item collection.
				 */
				addRelationItemsToActionMenu: function(collection) {
					var relationColumnNames = this.get("EntityConnectionColumnList");
					if (relationColumnNames && relationColumnNames.length > 0) {
						var relationItemSeparator = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								"Id": BPMSoft.generateGUID(),
								"Type": "BPMSoft.MenuSeparator"
							}
						});
						collection.addItem(relationItemSeparator);
						var addRelationColumnCollection = this.getRelationCollection(relationColumnNames,
							"addEmailRelation");
						var addRelationItem = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								"Id": BPMSoft.generateGUID(),
								"Caption": this.get("Resources.Strings.AddRelationColumnCollectionCaption"),
								"MarkerValue": "CreateNewRelation",
								"Items": addRelationColumnCollection
							}
						});
						collection.addItem(addRelationItem);
						var linkRelationColumnCollection = this.getRelationCollection(relationColumnNames,
							"linkEmailRelation");
						var linkRelationItem = this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								"Id": BPMSoft.generateGUID(),
								"Caption": this.get("Resources.Strings.LinkRelationColumnCollectionCaption"),
								"MarkerValue": "LinkRelation",
								"Items": linkRelationColumnCollection
							}
						});
						collection.addItem(linkRelationItem);
					}
				},

				/**
				 * Returns tge second level relation menu.
				 * @protected
				 * @param {String[]} relationColumnNames Email relations columns list.
				 * @return {String} onClickMetodName OnClick relation item handler method name.
				 */
				getRelationCollection: function(relationColumnNames, onClickMetodName) {
					var relationColumnCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.BPMSoft.each(relationColumnNames, function(columnName) {
						var column = this.entitySchema.getColumnByName(columnName);
						var values = this.generateRelationMenuItemConfig(column);
						values = this.Ext.apply(values, {
							"Id": BPMSoft.generateGUID(),
							"Click": {"bindTo": onClickMetodName}
						});
						relationColumnCollection.addItem(
							this.Ext.create("BPMSoft.BaseViewModel", {
								values: values
							})
						);
					}, this);
					return relationColumnCollection;
				},

				/**
				 * Returns relation menu item config.
				 * @protected
				 * @param {Object} column Connection column.
				 * @return {Object} Menu item.
				 */
				generateRelationMenuItemConfig: function(column) {
					var imageConfig = this.getRelationImageConfig(column.name);
					var config = {
						"Caption": column.caption,
						"ImageConfig": imageConfig,
						"Tag": column.name,
						"MarkerValue": "relationMenuItems " + column.caption
					};
					return config;
				},

				/**
				 * Handles "Add relation" menu item click.
				 * @protected
				 * @param {String} columnName Connection column name.
				 */
				addEmailRelation: function(columnName) {
					this.set("EntityRelationColumnName", columnName);
					var moduleStructure = this.BPMSoft.configuration.ModuleStructure;
					var schemaName = this.getSchemaNameByRelationColumnName(columnName);
					var schemaModuleStructure = moduleStructure[schemaName];
					var schemaPages = schemaModuleStructure.pages;
					var cardSchema = schemaModuleStructure.cardSchema;
					var defaultValues = this.getRelationValuePairs(columnName, schemaName);
					if (this.Ext.isArray(schemaPages)) {
						var cardInfo = this.BPMSoft.findWhere(schemaPages, {name: schemaName});
						cardSchema = cardInfo.cardSchema;
						if (schemaModuleStructure.attribute && cardInfo.UId) {
							defaultValues.push({
								name: schemaModuleStructure.attribute,
								value: cardInfo.UId
							});
						}
					}
					var moduleId = "AddEmailRelation_" + cardSchema + this.BPMSoft.generateGUID();
					this.sandbox.subscribe("CardModuleResponse", this.cardModuleResponseHandler, this,
						[moduleId]);
					var openCardConfig = {
						schemaName: cardSchema,
						operation: this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						moduleId: moduleId,
						defaultValues: defaultValues,
						renderTo: "centerPanel",
						keepAlive: true
					};
					this.openCardInChain(openCardConfig);
				},

				/**
				 * Handles "CardModuleResponse" event response.
				 * @protected
				 * @param {Object} args "CardModuleResponse" event response arguments.
				 * @param {String} args.primaryColumnValue Relation entity identifier.
				 * @param {String} args.primaryDisplayColumnValue Relation entity primary display column value.
				 * @param {String} args.primaryDisplayColumnName Relation entity primary display column name.
				 */
				cardModuleResponseHandler: function(args) {
					var primaryColumnValue = args.primaryColumnValue;
					var primaryDisplayColumnValue = args.primaryDisplayColumnValue;
					var entityRelation = {
						Id: primaryColumnValue,
						value: primaryColumnValue
					};
					if (primaryDisplayColumnValue) {
						entityRelation.displayValue = primaryDisplayColumnValue;
						entityRelation[args.primaryDisplayColumnName] = primaryDisplayColumnValue;
						this.updateEmailRecordByRelation(entityRelation);
					} else {
						this.getSelectedResultsSelectQuery(args, entityRelation);
					}
				},

				/**
				 * Executes connection schema query and updates email relation.
				 * @protected
				 * @param {Object} args "CardModuleResponse" event response arguments.
				 * @param {String} args.primaryDisplayColumnName Relation entity primary display column name.
				 * @param {Object} entityRelation Entity relation.
				 * @param {String} entityRelation.value Relation entity identifier.
				 */
				getSelectedResultsSelectQuery: function(args, entityRelation) {
					var schemaName = this.getSchemaNameByRelationColumnName(this.get("EntityRelationColumnName"));
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: schemaName
					});
					select.addColumn(args.primaryDisplayColumnName);
					select.filters.addItem(
						this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Id", entityRelation.value));
					select.getEntityCollection(function(response) {
						var collection = response.collection;
						if (collection.getCount() === 1) {
							var item = collection.getByIndex(0);
							var primaryDisplayColumnValue = item.get(args.primaryDisplayColumnName);
							entityRelation.displayValue = primaryDisplayColumnValue;
							entityRelation[args.primaryDisplayColumnName] = primaryDisplayColumnValue;
						}
						this.updateEmailRecordByRelation(entityRelation);
					}, this);
					return select;
				},

				/**
				 * Returns default value array for relation entity.
				 * @protected
				 * @param {String} columnName Connection column name.
				 * @param {String} schemaName Connection schema name.
				 * @return {Object[]} Default value array for relation entity. Array element contains
				 * column name and its value.
				 */
				getRelationValuePairs: function(columnName, schemaName) {
					var contact;
					var valuePairs = [];
					var entitySchema = this.entitySchema;
					if (entitySchema.name === schemaName) {
						valuePairs.push({
							name: entitySchema.primaryDisplayColumnName,
							value: this.get("MailTitleText")
						});
					}
					if (this.get("Contact")) {
						contact = this.get("Contact");
						if (this.get("Account")) {
							contact.Account = {
								value: this.get("Account").value,
								displayValue: this.get("Account").displayValue
							};
						}
					}
					var account = this.get("Account");
					if (!contact && account) {
						valuePairs.push({
							name: "Account",
							value: this.getEntityDefaultValueColumnValue(schemaName, account)
						});
						return valuePairs;
					}
					if (!contact) {
						contact = this.get("SenderContact");
					}
					if (contact && contact.value) {
						valuePairs.push({
							name: this.getSchemaDefaultValueColumnName("Contact", schemaName),
							value:  this.getEntityDefaultValueColumnValue(schemaName, contact)
						});
						var senderAccount = contact.Account;
						if (senderAccount) {
							valuePairs.push({
								name: this.getSchemaDefaultValueColumnName("Account", schemaName),
								value: this.getEntityDefaultValueColumnValue(schemaName, senderAccount)
							});
						}
					}
					if (columnName === "Contact" && this.isAutoBindingContactEmailNeeded()) {
						this.addSenderInfo(valuePairs);
					}
					return valuePairs;
				},

				/**
				 * Returns schema default value column name.
				 * @protected
				 * @param {String} columnName Connection column name.
				 * @param {String} schemaName Connection schema name.
				 * @return {String} Schema default value column name.
				 */
				getSchemaDefaultValueColumnName: function(columnName, schemaName) {
					if (schemaName === "Account" && columnName === "Contact") {
						return "PrimaryContact";
					}
					return columnName;
				},

				/**
				 * Returns entity default value.
				 * @protected
				 * @param {String} schemaName Connection schema name.
				 * @param {Object} entity Entity instance.
				 * @return {String} Entity default value.
				 */
				getEntityDefaultValueColumnValue: function(schemaName, entity) {
					return entity.value;
				},

				/**
				 * Handles "Link relation" menu item click.
				 * @protected
				 * @param {String} columnName Connection column name.
				 */
				linkEmailRelation: function(columnName) {
					var schemaName = this.getSchemaNameByRelationColumnName(columnName);
					var lookupListConfig = this.getLookupListConfig(columnName);
					var args = {
						searchValue: "",
						schemaName: schemaName,
						multiSelect: false,
						columns: lookupListConfig ? lookupListConfig.columns : []
					};
					var config = this.getLookupPageConfig(args, columnName);
					if (schemaName === "Activity") {
						var filter = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, "Type",
							ConfigurationConstants.Activity.Type.Email);
						config.filters.addItem(filter);
					}
					config.hideActions = true;
					this.set("EntityRelationColumnName", columnName);
					this.openLookup(config, this.onExistingRelationSelected, this);
				},

				/**
				 * Returns schema name depends on relation column name.
				 * @protected
				 * @param {String} columnName Connection column name.
				 * @return {String} Relation schema name.
				 */
				getSchemaNameByRelationColumnName: function(columnName) {
					var column = this.entitySchema.getColumnByName(columnName);
					return column.referenceSchemaName;
				},

				/**
				 * Handles lookup module response after selecting existing relation.
				 * @param {Object} args Arguments that contain information about selected record.
				 * @protected
				 */
				onExistingRelationSelected: function(args) {
					if (!args || !args.selectedRows || args.selectedRows.isEmpty()) {
						return;
					}
					var selectedRow = args.selectedRows.getByIndex(0);
					this.updateEmailRecordByRelation(selectedRow);
				},

				/**
				 * Updates email record relation column by selected value.
				 * @param {Object} emailRelation Email relation object (value and display value).
				 * @protected
				 */
				updateEmailRecordByRelation: function(emailRelation) {
					var columnName = this.get("EntityRelationColumnName");
					this.set(columnName, emailRelation);
					this.initDefaultColumnName();
					if (columnName === "Contact" && emailRelation && emailRelation.value &&
							this.isAutoBindingContactEmailNeeded()) {
						this.set("IsNeedReload", true);
						this.actualizeSenderRelation(emailRelation.value,
							this._saveAndUpdateChain.bind(this, columnName, emailRelation), this);
					}
					else {
						this._saveAndUpdateChain(columnName, emailRelation);
					}
				},

				/**
				 * ######## ###### ######## ### ####### #####.
				 * @return {String} markerValue ######### ########.
				 * @param {String} columnName ###### # html ######.
				 */
				getEditContainerMarkerValue: function(columnName) {
					var currentColumnName = columnName || this.get("CurrentColumnName");
					if (Ext.isEmpty(currentColumnName)) {
						return;
					}
					var column = this.entitySchema.getColumnByName(currentColumnName);
					var markerValue = "";
					if (!this.Ext.isEmpty(columnName) && !this.isColumnFilled(columnName)) {
						markerValue = "InputEditNotVisible";
					} else {
						markerValue = this.Ext.String.format("{0} {1}", column.name, column.caption);
					}
					return markerValue;
				},

				/**
				 * Handles "Delete" menu item click.
				 */
				onDeleteEmail: function() {
					var recordId = this.get("Id");
					var config = {
						schemaName: this.entitySchema.name,
						primaryColumnValue: recordId
					};
					RightUtilities.checkCanDelete(config, this.onCheckCanDeleteResponse, this);
				},

				/**
				 * ############ ######### ######## ########### ######## ######### #######.
				 * @param {String} rightsErrorMessage ##### #######.
				 */
				onCheckCanDeleteResponse: function(rightsErrorMessage) {
					if (rightsErrorMessage) {
						var message = this.get("Resources.Strings." + rightsErrorMessage);
						message = message || rightsErrorMessage;
						this.showInformationDialog(message);
						return;
					}
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
						function(returnCode) {
							this.onDelete(returnCode);
						},
						[this.BPMSoft.MessageBoxButtons.YES.returnCode,
							this.BPMSoft.MessageBoxButtons.NO.returnCode]);
				},

				/**
				 * Processes user response of delete data.
				 * @param {String} returnCode Selected button code.
				 */
				onDelete: function(returnCode) {
					if (returnCode !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
						return;
					}
					this.showBodyMask({
						selector: this.get("MaskSelector"),
						timeout: 0
					});
					this.callService({
						serviceName: "GridUtilitiesService",
						methodName: "DeleteRecords",
						data: {
							primaryColumnValues: [this.get("Id")],
							rootSchema: this.entitySchema.name
						}
					}, function(responseObject) {
						var result = this.Ext.decode(responseObject.DeleteRecordsResult);
						var success = result.Success;
						this.removeEmailFromPanel();
						this.hideBodyMask({selector: this.get("MaskSelector")});
						if (!success) {
							this.showDeleteExceptionMessage(result);
						}
					}, this);
				},

				/**
				 * ########## ####### ######## ######## ## ###### ######.
				 */
				removeEmailFromPanel: function() {
					this.fireEvent("emailDeleted", this);
				},

				/**
				 * ########## ######### ## ######, ############ ## ##### ########.
				 * @protected
				 * @param {Object} result ##### #######
				 */
				showDeleteExceptionMessage: function(result) {
					var message = "";
					if (result.IsDbOperationException) {
						message = this.get("Resources.Strings.DependencyWarningMessage");
					} else if (result.IsSecurityException) {
						message = this.get("Resources.Strings.RightLevelWarningMessage");
					} else {
						message = result.ExceptionMessage;
					}
					this.showInformationDialog(message);
				},

				/**
				 * Set email author contact.
				 * @protected
				 */
				setEmailAuthor: function() {
					var senderContact = this.get("SenderContact");
					this.set("EmailAuthor", senderContact);
				},

				/**
				 * Sets short sender name.
				 * @protected
				 * @param {String} fullName Full user name.
				 */
				setShortSenderName: function(fullName) {
					var shortSenderName = "";
					if (!this.Ext.isEmpty(fullName)) {
						fullName = fullName.replace("\t", " ");
						var names = fullName.split(" ");
						this.BPMSoft.each(names, function(item) {
							if (item !== " " && item !== "") {
								shortSenderName += item[0];
								if (shortSenderName.length === 2) {
									return false;
								}
							}
						}, this);
					}
					this.set("ShortSenderName", shortSenderName);
				},

				/**
				 * ######### ### ########### ######### #########.
				 * @return {String} ### ########### ######### #########.
				 */
				getSenderName: function() {
					var author = this.get("Author");
					var senderInfoRegExp = this.get("SenderInfoRegExp");
					var senderContact = this.get("SenderContact");
					var sender = this.get("Sender");
					if (!this.Ext.isEmpty(senderContact)) {
						return senderContact.displayValue;
					}
					if (this.Ext.isEmpty(sender)) {
						sender = author ? author.displayValue : "";
						return sender;
					}
					var regExp = new RegExp(senderInfoRegExp);
					var senderInfo = sender.match(regExp);
					var senderName = senderInfo ? senderInfo[1] : "";
					if (senderInfo && senderName) {
						return senderName;
					}
					return "";
				},

				/**
				 * ######### email ##### ########### ######### #########.
				 * @return {String} Email ##### ########### ######### #########.
				 */
				getSenderEmail: function() {
					var sender = this.get("Sender");
					var senderInfoRegExp = this.get("SenderInfoRegExp");
					var regExp = new RegExp(senderInfoRegExp);
					var senderInfo = sender.match(regExp);
					var senderEmail = senderInfo ? senderInfo[2] : "";
					if (senderInfo && senderEmail) {
						return senderEmail;
					}
					return sender.replace(/^<|>$/g, '');
				},

				/**
				 * Opens contact page if email has sender participant.
				 */
				openContactPage: function() {
					var contact = null;
					var primaryColumn;
					var history = this.sandbox.publish("GetHistoryState");
					if (!this.Ext.isEmpty(history.state)) {
						primaryColumn = history.state.primaryColumnValue;
					}
					contact = this.get("SenderContact");
					if (this.Ext.isEmpty(contact)) {
						return;
					}
					var contactId = contact.value;
					if (primaryColumn !== contactId) {
						RightUtilities.checkCanReadRecords({
							schemaName: "Contact",
							primaryColumnValues: [contactId]
						}, this.onCheckContactReadRightsResponse, this);
					}
					return false;
				},

				/**
				 * ############ ######### ####### #### ## ###### ########.
				 * @param {Array} result ######### ####### ####.
				 */
				onCheckContactReadRightsResponse: function(result) {
					var response = this.Ext.isEmpty(result) ? false : result[0];
					if (response && response.Value) {
						this.onUrlClick("Contact", response.Key);
					} else {
						var message = this.get("Resources.Strings.ReadRightLevelWarningMessage");
						this.showInformationDialog(message);
					}
				},

				/**
				 * ######### #### ######### #########.
				 * @return {String} ##### #### ######### #########.
				 */
				getMailTitleText: function() {
					var title = this.get("Title");
					return title ? title : "";
				},

				/**
				 * ######### ##### ######### #########.
				 * @return {String} ##### ######### #########.
				 */
				getMailBody: function() {
					const numberBodySymbols = EmailConstants.NumberBodySymbols;
					let body = this.getIsFeatureEnabled("ActivityPreview") ? this.get("Preview") : this.get("Body");
					let textMail = "";
					if (!Ext.isEmpty(body)) {
						textMail = this.removeHtmlTags(body);
					}
					if (textMail.length > numberBodySymbols) {
						textMail = textMail.substr(0, numberBodySymbols - 1);
					}
					return textMail;
				},

				/**
				 * Message title click handler.
				 */
				onTitleClick: function() {
					const typeColumnName = this.get("TypeColumnName") || "Type";
					const type = this.get(typeColumnName);
					const typeid = type ? type.value : null;
					this.onUrlClick(EmailConstants.entitySchemaName, this.get("Id"), typeid);
				},

				/**
				 * @inheritdoc BPMSoft.baseSchemaViewModel#getLookupEntitySchemaName
				 * @overridden
				 */
				onLinkClick: function(url, columnName) {
					var column = this.getColumnByName(columnName);
					var entitySchemaName = column.referenceSchemaName;
					var moduleStructure = this.getModuleStructure(entitySchemaName);
					var attribute = moduleStructure.attribute;
					var typeColumnValue;
					if (!this.Ext.isEmpty(attribute)) {
						var typeColumn = this.get(columnName + "." + attribute);
						typeColumnValue = !this.Ext.isEmpty(typeColumn) ? typeColumn.value : null;
					}
					var primaryColumn = this.get(columnName);
					var primaryColumnValue = primaryColumn.value;
					this.onUrlClick(entitySchemaName, primaryColumnValue, typeColumnValue);
				},

				/**
				 * Creates unique module id for entity card module.
				 * @protected
				 * @param {Guid} primaryColumnValue Entity primary column value.
				 * @return {String} Unique card module id.
				 */
				generateCardModuleId: function(primaryColumnValue) {
					return this.Ext.String.format("{0}_CardModuleV2_{1}_{2}", this.sandbox.id, primaryColumnValue,
						this.BPMSoft.utils.guid.generateGUID());
				},

				/**
				 * Label url click handler.
				 */
				onUrlClick: function(entitySchemaName, primaryColumnValue, typeColumnValue) {
					var config = this._getOpenPageConfig(entitySchemaName, primaryColumnValue, typeColumnValue);
					this._openCardInChain(config);
				},

				/**
				 * Opens email page on attachments tab.
				 * @protected
				 */
				onAttachIconClick: function() {
					const typeColumnName = this.get("TypeColumnName") || "Type";
					const type = this.get(typeColumnName);
					const typeid = type ? type.value : null;
					const config = this._getOpenPageConfig(EmailConstants.entitySchemaName, this.get("Id"), typeid);
					const valuePairs = config.valuePairs = config.valuePairs || [];
					valuePairs.push({
						name: "DefaultTabName",
						value: "EmailAttachingTab"
					});
					this._openCardInChain(config);
				},

				/**
				 * ######## ######## #####.
				 * @private
				 * @param {String} columnName ############ ####### #####.
				 * @return {Object} ######## #####.
				 */
				getColumnValue: function(columnName) {
					var currentLookupValue = this.get(columnName);
					return currentLookupValue;
				},

				/**
				 * ####### html #### ## ######.
				 * @private
				 * @param {String} value ###### # html ######.
				 * @return {String} ###### ### html #####.
				 */
				removeHtmlTags: function(value) {
					return EmailUtilities.removeHtmlTags(value);
				},

				/**
				 * Saves email and starts update all email realtions in chain sequence.
				 * @private
				 * @param {String} currentColumnName Changed column name.
				 * @param {Object} columnValue Column value.
				 */
				_saveAndUpdateChain: function(currentColumnName, columnValue) {
					this.onSaveEntity(function(error) {
						if (this.isEmpty(error)) {
							this._startEmailsInChainUpdate(currentColumnName, columnValue);
						}
					}, this);
				},

				/**
				 * Starts update all email realtions in chain sequence.
				 * @private
				 * @param {String} currentColumnName Changed column name.
				 * @param {Object} columnValue Column value.
				 */
				_startEmailsInChainUpdate: function(currentColumnName, columnValue) {
					if (this.isEmpty(this.$SendDate) || this.isEmpty(columnValue)) {
						return;
					}
					var activityId = this.$Id;
					this.getConversationId(activityId, function(conversationId) {
						if (this.isEmpty(conversationId) || this.BPMSoft.isEmptyGUID(conversationId)) {
							return;
						}
						this.showConfirmationDialog(this.get("Resources.Strings.ConfirmUpdateAllInChain"),
							function(returnCode) {
								if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this._updateAllEmailsInChain(currentColumnName, columnValue, conversationId);
									
								}
								if (returnCode === "showRelated") {
									this.onShowRelatedEmails();
								}
							},
							[this.BPMSoft.MessageBoxButtons.YES.returnCode,
								this.BPMSoft.MessageBoxButtons.NO.returnCode, {
									caption: this.get("Resources.Strings.ShowRelatedEmails"),
									className: "BPMSoft.Button",
									markerValue: "Show Related",
									returnCode: "showRelated"
								}], {
									"customWrapClass": "update-related-emails"
								});
					}, this);
				},

				/**
				 * Updates all email realtions in chain sequence.
				 * @private
				 * @param {String} currentColumnName Changed column name.
				 * @param {Object} columnValue Column value.
				 * @param {String} conversationId Conversation identifier.
				 */
				_updateAllEmailsInChain: function(currentColumnName, columnValue, conversationId) {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Activity"
					});
					this.setEmailsByConversationFilters(update.filters, conversationId);
					update.setParameterValue(currentColumnName, columnValue.value,
						this.BPMSoft.DataValueType.LOOKUP);
					var maskSelector = this.get("MaskSelector");
					this.showBodyMask({
						selector: maskSelector,
						timeout: 0
					});
					update.execute(function(result) {
						this.hideBodyMask({selector: maskSelector});
						var succssTpl = this.get("Resources.Strings.UpdateAllInChainOk");
						var failMsg = this.get("Resources.Strings.UpdateAllInChainFail");
						var msg = result.success ? Ext.String.format(succssTpl, result.rowsAffected) : failMsg;
						this.showInformationDialog(msg);
					}, this);
				},

				/**
				 * Creates email author profile image url.
				 * @return {String} Email author profile image url.
				 */
				getAuthorImageSrc: function() {
					var defaultAuthorImageSrc =
						this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.ContactDefaultIcon"));
					var contact = this.get("SenderContact");
					if (this.isEmpty(contact)) {
						return defaultAuthorImageSrc;
					}
					if (this.isEmpty(contact) || this.isEmpty(contact.primaryImageValue) ||
						this.BPMSoft.isEmptyGUID(contact.primaryImageValue)) {
						this.set("IsShortContact", true);
						return "";
					}
					this.set("IsShortContact", false);
					return this.getImageSrc(contact.primaryImageValue);
				},

				/**
				 * Checks email author has profile image.
				 * @return {Boolean} True if email author has profile image, false otherwise.
				 */
				isAuthorImageUrlExist: function() {
					var authorImageUrl = this.getAuthorImageSrc();
					if (this.isEmpty(authorImageUrl)) {
						return false;
					}
					return true;
				},

				/**
				 * Creates image url by image unique identifier.
				 * @param {String} imageId Image unique identifier.
				 * @private
				 * @return {String} Image url.
				 */
				getImageSrc: function(imageId) {
					return this.BPMSoft.ImageUrlBuilder.getUrl({
						source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
						params: {
							schemaName: "SysImage",
							columnName: "Data",
							primaryColumnValue: imageId
						}
					});
				},

				/**
				 * Handle response of save entity request.
				 * @private
				 * @param {Object} [response] Response of save entity request.
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback function scope.
				 */
				_handleSaveRequestResponse: function(response, callback, scope) {
					if (response && response.success) {
						this.fireEvent("entitySaved", this);
						this.set("CurrentColumnValue", null);
					}
					this.Ext.callback(callback, scope);
				},

				/**
				 * Set IsNeedProcess to false.
				 * @private
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback function scope.
				 */
				_onSetIsNeedProcessFalse: function(callback, scope) {
					this.saveEntity(function(response) {
						this._handleSaveRequestResponse(response, callback, scope);
					}, this);
				},

				/**
				 * Creates open page config for record.
				 * @private
				 * @param {String} entitySchemaName Entity schema name.
				 * @param {String} primaryColumnValue Record identifier.
				 * @param {String} typeColumnValue Record type identifier.
				 * @returns {Object} Open page config.
				 */
				_getOpenPageConfig: function(entitySchemaName, primaryColumnValue, typeColumnValue) {
					var historyState = this.sandbox.publish("GetHistoryState");
					var moduleId = this.generateCardModuleId(primaryColumnValue);
					return {
						sandbox: this.sandbox,
						entitySchemaName: entitySchemaName,
						primaryColumnValue: primaryColumnValue,
						operation: ConfigurationEnums.CardStateV2.EDIT,
						historyState: historyState,
						typeId: typeColumnValue,
						moduleId: moduleId
					};
				},

				/**
				 * Opens card in chain.
				 * @private
				 * @param {Object} config Open page config.
				 */
				_openCardInChain: function(config) {
					NetworkUtilities.openCardInChain(config);
				},

				/**
				 * Creates send date display value.
				 * @return {String} Send date display value.
				 */
				getMailDate: function() {
					var mailDate = this.get("SendDate");
					if (Ext.isEmpty(mailDate)) {
						mailDate = this.get("ModifiedOn");
					}
					var smartDate = null;
					var dateDiff = FormatUtils.dateDiffDays(mailDate, new Date());
					switch (dateDiff) {
						case 0:
							smartDate = BPMSoft.utils.string.getTypedStringValue(mailDate, BPMSoft.DataValueType.DATE) + " " + BPMSoft.utils.string.getTypedStringValue(mailDate, BPMSoft.DataValueType.TIME);
							break;
						case 1:
							smartDate = this.get("Resources.Strings.Yesterday");
							break;
						default:
							smartDate = BPMSoft.utils.string.getTypedStringValue(mailDate, BPMSoft.DataValueType.DATE);
							break;
					}
					return smartDate;
				},

				/**
				 * Creates process execution parameters object.
				 * @param {Guid} processId Process unique identifier.
				 * @return {Object} Process execution parameters.
				 */
				getProcessExecuteConfig: function(processId) {
					var emailId = this.get("Id");
					var config = {
						sysProcessId: processId,
						parameters: {
							RecordId: emailId
						}
					};
					return config;
				},

				/**
				 * Calls process execute.
				 * @param {Guid} processId Process unique identifier.
				 */
				runProcess: function(processId) {
					var config = this.getProcessExecuteConfig(processId);
					ProcessModuleUtilities.executeProcess(config);
				},

				/**
				 * Returns message container data item marker value.
				 * @return {String} message container data item marker value.
				 */
				getEmailMarkerValue: function() {
					return this.get("MailTitleText");
				},

				/**
				 * Sets and saves IsNeedProcess value for message.
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback function scope.
				 */
				setIsNeedProcessFalse: function(callback, scope) {
					this.set("IsProcessingButtonEnabled", false);
					var chain = [];
					chain.push(this.updateIsNeedProcess);
					chain.push(this._onSetIsNeedProcessFalse, function() {
						this.Ext.callback(callback, scope);
					});

					this.set("IsNeedProcess", false);
					this.BPMSoft.chain.apply(this, chain);
				},

				/**
				 * Creates update query for IsNeedProcess column.
				 * @protected
				 * @return {BPMSoft.UpdateQuery} Update query for IsNeedProcess column.
				 */
				getIsNeedProcessUpdate: function() {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "EmailMessageData"
					});
					var filters = update.filters;
					var activityId = this.get("Id");
					if (this.Ext.isEmpty(activityId) || this.BPMSoft.utils.guid.isEmptyGUID(activityId)) {
						return null;
					}
					var activityIdFilter = update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Activity", activityId);
					filters.add("activityIdFilter", activityIdFilter);
					var mailboxesFilterGroup = this.BPMSoft.createFilterGroup();
					mailboxesFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var mailboxesFilter = this.BPMSoft.createColumnInFilterWithParameters(
						"MailboxSyncSettings", this.$Mailboxes);
					mailboxesFilterGroup.add("avaliableMailboxesFilter", mailboxesFilter);
					var draftFilter = this.BPMSoft.createIsNullFilter(this.Ext.create("BPMSoft.ColumnExpression",
						{columnPath: "MailboxSyncSettings"}));
					mailboxesFilterGroup.add("draftsFilter", draftFilter);	
					filters.add("mailboxesFilter", mailboxesFilterGroup);
					update.setParameterValue("IsNeedProcess", this.get("IsNeedProcess"),
						this.BPMSoft.DataValueType.BOOLEAN);
					return update;
				},

				/**
				 * Updates IsNeedProcess value for current user EmailMessageData instances.
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback function scope.
				 */
				updateIsNeedProcess: function(callback, scope) {
					var update = this.getIsNeedProcessUpdate();
					if (this.Ext.isEmpty(update)) {
						this.Ext.callback(callback, scope);
						return;
					}
					update.execute(function() {
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Save entity.
				 * @protected
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback function scope.
				 */
				onSaveEntity: function(callback, scope) {
					if (!this.validate()) {
						let message = this.getValidationMessage();
						this.showInformationDialog(message);
						this.$IsNeedReload = true;
						this.fireEvent("entitySaved", this);
						return this.Ext.callback(callback, scope || this, [message]);
					}
					this.showBodyMask({
						selector: this.get("MaskSelector"),
						timeout: 0
					});
					this.saveEntity(function(response) {
						this.hideBodyMask({selector: this.get("MaskSelector")});
						this._handleSaveRequestResponse(response, callback, scope);
					}, this);
				},

				/**
				 * ######### ######### ###### ##### ### ######### #######.
				 * @param {String} columnName ######## #######.
				 * @return {boolean} ######### ###### ##### ### ######### #######.
				 */
				getEmailRelationButtonVisible: function(columnName) {
					var isVisible = false;
					var DefaultEntityConnectionColumns = this.get("DefaultEntityConnectionColumns");
					if (this.Ext.Array.contains(DefaultEntityConnectionColumns, columnName)) {
						isVisible = true;
					} else {
						isVisible = this.isColumnFilled(columnName);
					}
					return isVisible;
				},

				/**
				 * Opens lookup page.
				 * @protected
				 * @param {Object} args Arguments.
				 * @param {String} columnName Column name.
				 */
				loadVocabulary: function(args, columnName) {
					var currentColumnName = this.get("CurrentColumnName");
					if (!this.Ext.isEmpty(columnName)) {
						currentColumnName = columnName;
					}
					var config = this.getLookupPageConfig(args, currentColumnName);
					if (currentColumnName === "Contact" && this.isAutoBindingContactEmailNeeded()) {
						config.valuePairs = config.valuePairs || [];
						this.addSenderInfo(config.valuePairs);
					}
					this.openLookup(config, this.onLookupSelected, this);
				},

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#getLookupPageConfig
				 * @protected
				 * @overridden
				 * @deprecated 7.8 Use mixin's method.
				 */
				getLookupPageConfig: function() {
					return this.mixins.LookupQuickAddMixin.getLookupPageConfig.apply(this, arguments);
				},

				/**
				 * ######### ###### ############## ####### ### ###### ## ###########.
				 * @param {String} entitySchemaName ######## ##### ########### ####.
				 * @return {Array} ###### ############## #######.
				 */
				getAdditionalColumns: function(entitySchemaName) {
					var secondLevelBindingsConfig = this.get("SecondLevelBindingsConfig");
					var entityColumsBinding = secondLevelBindingsConfig[entitySchemaName];
					var result = [];
					BPMSoft.each(entityColumsBinding, function(item) {
						if (result.indexOf(item.childColumn) === -1) {
							result.push(item.childColumn);
						}
					}, this);
					return result;
				},

				/**
				 * @inheritdoc BPMSoft.EntityConnectionLinksPanelItemUtilities#getLookupEntitySchemaName
				 * @overridden
				 */
				getLookupEntitySchemaName: function(args, columnName) {
					var entityColumn = this.entitySchema.getColumnByName(columnName);
					return args.schemaName || entityColumn.referenceSchemaName;
				},

				/**
				 * @inheritdoc BPMSoft.LookupQuickAddMixin#getLookupListConfig
				 * @protected
				 * @overridden
				 * @deprecated 7.8 Use mixin's method.
				 */
				getLookupListConfig: function() {
					return this.mixins.LookupQuickAddMixin.getLookupListConfig.apply(this, arguments);
				},

				/**
				 * Changes the value of the entity columns when the data in the reference field changes.
				 * @param {String} value New connection value.
				 * @param {String} columnName Name of the communication column.
				 */
				onColumnValueChange: function(value, columnName) {
					var currentColumnName = this.get("CurrentColumnName");
					if (!this.Ext.isEmpty(columnName)) {
						currentColumnName = columnName;
					}
					if (this.Ext.isEmpty(currentColumnName)) {
						return;
					}
					var prevValue = this.get(currentColumnName);
					if (prevValue === value) {
						return;
					}
					if (value && value.value === BPMSoft.GUID_EMPTY) {
						value.isNewValue = true;
						this.mixins.LookupQuickAddMixin.onLookupChange.call(this, value, currentColumnName);
					} else {
						this.set(currentColumnName, value);
						this.initDefaultColumnName();
						if (currentColumnName === "Contact" && value && value.value &&
								this.isAutoBindingContactEmailNeeded()) {
							this.set("IsNeedReload", true);
							this.actualizeSenderRelation(value.value,
								this._saveAndUpdateChain.bind(this, currentColumnName, value), this);
						}
						else {
							this._saveAndUpdateChain(currentColumnName, value);
						}
					}
				},

				/**
				 * ####### ###### ######## ###########.
				 * @overridden
				 * @param {Object} config ######### ###### ###### ###### ## ###########.
				 * @param {BPMSoft.Collection} config.selectedRows ######### ######### ######.
				 * @param {String} config.columnName ### #######, ### ####### ############# #####.
				 */
				onLookupResult: function(config) {
					var columnName = config.columnName;
					var selectedRows = config.selectedRows;
					if (!selectedRows.isEmpty()) {
						var value = selectedRows.getByIndex(0);
						this.set(columnName, value);
						this.initDefaultColumnName();
						this.onSaveEntity();
					}
					this.set("CurrentColumnValue", null);
				},

				/**
				 * ########## ####### ###### ######## ##### # LookupPage-#. ############# ######## # ###### #############.
				 * @param {Object} lookupPageResult ######### ###### # #### ######.
				 */
				onLookupSelected: function(lookupPageResult) {
					var selectedRows = lookupPageResult.selectedRows;
					if (selectedRows.getCount() > 0) {
						var selectedValue = selectedRows.getByIndex(0);
						this.onColumnValueChange(selectedValue, lookupPageResult.columnName);
					}
				},

				/**
				 * ######### ###### ################# ###### ### ########### ####.
				 * @protected
				 * @param {Object} inputString ######### ###### # ########## ####.
				 */
				onPrepareRelationLookupList: function(inputString) {
					var list = this.Ext.create("BPMSoft.Collection");
					if (Ext.isEmpty(inputString) || (inputString.length < 3)) {
						return;
					}
					list.clear();
					var selectItemSettings = this.getPrepareQuery(inputString);
					selectItemSettings.getEntityCollection(function(result) {
						if (!result.success) {
							return;
						}
						var collection = result.collection;
						var columns = {};
						var currentColumnName = this.get("CurrentColumnName");
						var config = {
							collection: collection,
							filterValue: inputString,
							objects: columns,
							columnName: currentColumnName,
							isLookupEdit: true
						};
						if (collection && !collection.isEmpty()) {
							var column = this.columns[currentColumnName];
							collection.each(function(item) {
								var itemId = item.get("Id");
								var lookupValue = {
									displayValue: item.get("displayValue"),
									value: itemId
								};
								var dependentColumns = this.getDependentColumns(column);
								if (dependentColumns) {
									this.BPMSoft.each(dependentColumns, function(column) {
										lookupValue[column] = item.get(column);
									}, this);
								}
								if (!list.contains(itemId)) {
									columns[itemId] = lookupValue;
								}
							}, this);
						}
						this.mixins.LookupQuickAddMixin.onLookupDataLoaded.call(this, config);
						list.loadAll(columns);
						this.set("CurrentRelationItemsList", list);
					}, this);
				},

				/**
				 * Returns query for lookup column (adds primary and primary display columns and specific filters).
				 * @protected
				 * @param {String} inputString Input string from lookup column.
				 * @return {BPMSoft.EntitySchemaQuery} Query for lookup column.
				 */
				getPrepareQuery: function(inputString) {
					var rowCount = this.get("CurrentRelationRowCount");
					var currentColumnName = this.get("CurrentColumnName");
					var column = this.columns[currentColumnName];
					var referenceSchemaName = column.referenceSchemaName;
					var referenceSchema = column.referenceSchema;
					var currentValue = this.getColumnValue(currentColumnName);
					var currentId = currentValue ? currentValue.value : null;
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: referenceSchemaName
					});
					esq.addColumn("Id");
					esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "displayValue");
					var dependentColumns = this.getDependentColumns(column);
					if (dependentColumns) {
						this.BPMSoft.each(dependentColumns, function(column) {
							esq.addColumn(column);
						}, this);
					}
					if (currentColumnName === "ActivityConnection") {
						var currentEmailId = this.get("Id");
						esq.filters.addItem(esq.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL, referenceSchema.primaryColumnName,
							currentEmailId));
					}
					esq.filters.addItem(esq.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, referenceSchema.primaryColumnName, currentId));
					var comparsionType = this.getStringColumnComparisonType();
					esq.filters.add("startFilter", BPMSoft.createColumnFilterWithParameter(comparsionType,
						referenceSchema.primaryDisplayColumnName, inputString));
					esq.rowCount = rowCount;
					esq.filters.addItem(this.getLookupQueryFilters(currentColumnName));
					return esq;
				},

				/**
				 * Returns columns related to entity from lookupListConfig
				 * @param column Entity column
				 * @return {Array} Array of column names or null
				 */
				getDependentColumns: function(column) {
					var lookupListConfig = column.lookupListConfig;
					if (lookupListConfig && lookupListConfig.columns && lookupListConfig.columns.length > 0) {
						return lookupListConfig.columns;
					}
					return null;
				},

				/**
				 * Returns is page opened in copy mode.
				 * @private
				 * @return {Boolean} Is page opened in copy mode.
				 */
				isCopyMode: function() {
					return false;
				},

				/**
				 * Fills email sender parameters.
				 * @param {Object} senderContact Sender contact parameters.
				 */
				initSenderInfo: function(senderContact) {
					if (!this.Ext.isEmpty(senderContact)) {
						this.set("SenderContact", senderContact);
					}
					var name = this.getSenderName();
					this.setShortSenderName(name);
					this.setEmailAuthor();
					var email = this.getSenderEmail();
					if (this.Ext.isEmpty(name)) {
						name = email;
						email = "";
					}
					var contact = this.get("SenderContact");
					var hasContact = !this.Ext.isEmpty(contact);
					this.set("SenderName", name);
					this.set("SenderEmail", email);
					this.set("HasContact", hasContact);
				},

				/**
				 * Creates email url.
				 * @return {String} Email url.
				 */
				getEmailHref: function() {
					const schemaName = EmailConstants.entitySchemaName;
					const recordId = this.get("Id");
					return BPMSoft.NavigationServiceUtility.getEntitySchemaRecordUrl(schemaName, recordId);
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#setColumnValues
				 * @overridden
				 */
				setColumnValues: function(entity) {
					this.callParent(arguments);
					this.set("ActivityConnection.Type", entity.get("ActivityConnection.Type"));
				},

				/**
				 * "Process message" button visibility value converter.
				 * @param {Boolean} value New raw visibility value.
				 * @return {Boolean} "Process message" button visibility.
				 */
				getProcessButtonVisible: function(value) {
					return value || !this.get("IsProcessingButtonEnabled");
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "EmailHeader",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						classes: {wrapClassName: ["messageHeader"]},
						items: []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailHeader",
					"propertyName": "items",
					"name": "EmailAuthorImageContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						classes: {wrapClassName: ["emailAuthorImageContainer"]},
						items: []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailAuthorImageContainer",
					"propertyName": "items",
					"name": "EmailAuthorImage",
					"values": {
						"getSrcMethod": "getAuthorImageSrc",
						"onPhotoChange": BPMSoft.emptyFn,
						"readonly": true,
						"classes": {"wrapClass": ["author-image-container"]},
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onImageClick": {bindTo: "openContactPage"},
						"visible": {bindTo: "isAuthorImageUrlExist"}
					}
				},
				{
					"operation": "insert",
					"name": "EmailAuthorContainer",
					"parentName": "EmailHeader",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						classes: {wrapClassName: ["createdBy"]},
						items: []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailAuthorContainer",
					"propertyName": "items",
					"name": "EmailAuthor",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {bindTo: "SenderName"},
						"classes": {
							"hyperlinkClass": ["t-label", "label-link", "label-url"]
						},
						"click": {bindTo: "openContactPage"},
						"markerValue": {bindTo: "SenderName"},
						"visible": {bindTo: "HasContact"},
						"linkMouseOver": {bindTo: "linkMouseOver"},
						"tag": {
							"columnName": "EmailAuthor",
							"referenceSchemaName": "Contact"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailAuthorContainer",
					"propertyName": "items",
					"name": "EmailAuthorAddress",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {bindTo: "SenderName"},
						"classes": {
							"labelClass": ["t-label"]
						},
						"markerValue": {bindTo: "SenderName"},
						"visible": {
							bindTo: "HasContact",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "EmailInformation",
					"parentName": "EmailHeader",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						classes: {wrapClassName: ["emailInformation"]},
						items: []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailInformation",
					"propertyName": "items",
					"name": "EmailDate",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["message-date-text"]
						},
						"caption": {bindTo: "MailDateText"},
						"markerValue": {bindTo: "MailDateText"}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailInformation",
					"propertyName": "items",
					"name": "AuthorEmailAddress",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {bindTo: "SenderEmail"},
						"classes": {
							"labelClass": ["t-label", "createdByAddress"]
						},
						"markerValue": {bindTo: "SenderEmail"},
						"visible": {
							bindTo: "HasContact",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailAuthorImageContainer",
					"propertyName": "items",
					"name": "ShortSenderName",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {bindTo: "ShortSenderName"},
						"classes": {
							"hyperlinkClass": ["t-label", "label-link", "label-url"]
						},
						"click": {bindTo: "openContactPage"},
						"markerValue": "ShortSenderName",
						"visible": {bindTo: "IsShortContact"},
						"linkMouseOver": {bindTo: "linkMouseOver"},
						"tag": {
							"columnName": "EmailAuthor",
							"referenceSchemaName": "Contact"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailHeader",
					"propertyName": "items",
					"name": "ActionsButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.ActionsButtonImage"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							wrapperClass: ["email-actions-button-wrapper"],
							menuClass: ["email-actions-button-menu"]
						},
						"controlConfig": {
							"menu": {
								"items": {"bindTo": "ActionsMenuCollection"}
							}
						},
						"markerValue": "EmailActionsButton"
					}
				},
				{
					"operation": "insert",
					"name": "EmailMessage",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["message-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TitleContainer",
					"parentName": "EmailMessage",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["title-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "TitleContainer",
					"propertyName": "items",
					"name": "EmailTitleText",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["link", "message-title", "label-url", "label-link"]
						},
						"caption": {bindTo: "MailTitleText"},
						"href": {bindTo: "getEmailHref"},
						"click": {bindTo: "onTitleClick"},
						"markerValue": {bindTo: "MailTitleText"}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailMessage",
					"propertyName": "items",
					"name": "AttachButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.AttachmentsIcon"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							wrapperClass: ["attachments-btn-wrapper"]
						},
						"visible": { "bindTo": "HasAttachments" },
						"click": {bindTo: "onAttachIconClick"},
						"markerValue": "EmailAttachmentsButton"
					}
				},
				{
					"operation": "insert",
					"name": "EmailMessageText",
					"parentName": "EmailMessage",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["message-text-container"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailMessageText",
					"propertyName": "items",
					"name": "EmailText",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["message-email-text"]
						},
						"caption": {bindTo: "getMailBody"}
					}
				}
			],
			rules: {
				"ActivityConnection": {
					"FiltrationActivityConnectionByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					},
					"FiltrationActivityConnectiontByContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Contact",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Contact"
					},
					"FiltrationWithoutCurrenttActivity": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": false,
						"autoClean": false,
						"baseAttributePatch": "Id",
						"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Id"
					},
					"AutocompleteActivityConnectionType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Type",
						"comparisonType": BPMSoft.ComparisonType.IS_NOT_NULL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "ActivityConnection.Type"
					},
					"FiltrationActivityConnectionByActivityType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"baseAttributePatch": "Type",
						"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": ConfigurationConstants.Activity.Type.Email
					}
				},
				"SenderEnum": {
					"BindParameterEnabledSenderEnumToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"Recepient": {
					"BindParameterEnabledRecepientToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"CopyRecepient": {
					"BindParameterEnabledCopyRecepientToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"BlindCopyRecepient": {
					"BindParameterEnabledBlindCopyRecepientToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"Title": {
					"BindParameterEnabledTitleToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"Body": {
					"BindParameterEnabledBodyToEmailSendStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "EmailSendStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.Activity.EmailSendStatus.Sended
								}
							}
						]
					}
				},
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			}
		};
	});
