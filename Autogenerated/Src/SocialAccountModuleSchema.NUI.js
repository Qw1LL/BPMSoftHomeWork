﻿define("SocialAccountModuleSchema", ["SocialAccountModuleResources", "ConfigurationConstants", "ConfigurationEnums",
		"SocialAccountAuthUtilities", "SocialAccount", "Contact", "RightUtilities", "FacebookClientUtilities",
		"GoogleClientConnector", "SystemOperationsPermissionsMixin", "SyncSettingsMixin"],
	function(resources, ConfigurationConstants, ConfigurationEnums, SocialAccountAuthUtilities, SocialAccount,
			Contact, RightUtilities) {
		return {
			entitySchemaName: "SocialAccount",
			mixins: {
				FacebookClientUtilities: "BPMSoft.FacebookClientUtilities",
				SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin",
				SyncSettingsMixin: "BPMSoft.SyncSettingsMixin"
			},
			attributes: {
				ActionsMenuItems: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				GridData: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				activeRowId: {
					dataValueType: BPMSoft.DataValueType.GUID,
					value: ""
				},
				GridSortColumnIndex: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				IsGridEmpty: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				}
			},
			methods: {

				/**
				 * Initialize query columns.
				 * @protected
				 * @param {Object} esq Entity schema query.
				 */
				initQueryColumns: function(esq) {
					esq.addColumn("Id");
					esq.addColumn("Login");
					esq.addColumn("Public");
					esq.addColumn("Type");
					esq.addColumn("User");
					esq.addColumn("User.Contact");
					esq.addColumn("SocialId");
				},

				/**
				 * Initialize query filters.
				 * @protected
				 * @param {Object} esq Entity schema query.
				 */
				initQueryFilters: function(esq) {
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "User", this.BPMSoft.SysValue.CURRENT_USER.value));
				},

				/**
				 * Initialize query sorting.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initQuerySorting: function(esq) {
					var typeColumn = esq.columns.get("Type");
					typeColumn.orderPosition = 0;
					typeColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				},

				/**
				 * Subscribe query events.
				 * @protected
				 * @param {Object} esq Entity schema query.
				 */
				initQueryEvents: function(esq) {
					esq.on("createviewmodel", this.createSocialAccountViewModel, this);
				},

				/**
				 * Unsubscribe query events.
				 * @protected
				 * @param {Object} esq Entity schema query.
				 */
				destroyQueryEvents: function(esq) {
					esq.un("createviewmodel", this.createSocialAccountViewModel, this);
				},

				/**
				 * Initializes view model instance.
				 * @private
				 * @param {Object} config View model config.
				 * @param {Object} config.rawData Column values.
				 * @param {Object} config.rowConfig Column types.
				 * @param {Object} config.viewModel View model.
				 */
				createSocialAccountViewModel: function(config) {
					var socialAccountViewModelClassName = this.getSocialAccountViewModelClassName();
					var socialAccountViewModelConfig = this.getSocialAccountViewModelConfig(config);
					var viewModel = this.Ext.create(socialAccountViewModelClassName, socialAccountViewModelConfig);
					viewModel.getSocialLink = function() {
						var type = this.get("Type");
						if (type.value === ConfigurationConstants.CommunicationTypes.Facebook) {
							var socialLinkTemplate = "https://www.facebook.com/{id}";
							var id = this.get("SocialId");
							var login = this.get("Login");
							return {
								title: login,
								url: socialLinkTemplate.replace("{id}", id),
								target: "_blank"
							};
						}
					};
					config.viewModel = viewModel;
				},

				/**
				 * Returns view model class.
				 * @protected
				 * @return {String} View model class.
				 */
				getSocialAccountViewModelClassName: function() {
					return "BPMSoft.BaseViewModel";
				},

				/**
				 * Returns view model config.
				 * @protected
				 * @param {Object} config View model config.
				 * @param {Object} config.rawData Column values.
				 * @param {Object} config.rowConfig Column types.
				 * @return {Object} View model config.
				 */
				getSocialAccountViewModelConfig: function(config) {
					return {
						entitySchema: SocialAccount,
						rowConfig: config.rowConfig,
						values: config.rawData,
						isNew: false,
						isDeleted: false
					};
				},

				/**
				 * Load social accounts.
				 * @private
				 */
				loadSocialAccounts: function() {
					var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchema: SocialAccount,
						rowViewModelClassName: this.getSocialAccountViewModelClassName()
					});
					this.initQueryColumns(select);
					this.initQueryFilters(select);
					this.initQuerySorting(select);
					this.initQueryEvents(select);
					select.getEntityCollection(function(response) {
						this.destroyQueryEvents(select);
						this.onGridDataLoaded(response);
					}, this);
				},

				/**
				 * Data load event. When the server returns data.
				 * @protected
				 * @param {Object} response Server response.
				 * @param {Boolean} response.success Server response status.
				 * @param {BPMSoft.Collection} response.collection Entity collection.
				 */
				onGridDataLoaded: function(response) {
					if (response && response.success) {
						var collection = response.collection;
						this.prepareResponseCollection(collection);
						var gridData = this.get("GridData");
						gridData.clear();
						this.set("IsGridEmpty", collection.isEmpty());
						gridData.loadAll(collection);
					}
				},

				/**
				 * Authenticate current user to selected social network.
				 * @private
				 * @param {String} socialNetwork Social network name.
				 */
				authenticate: function(socialNetwork) {
					var consumerKeySetting = socialNetwork + "ConsumerKey";
					var consumerSecretSetting = socialNetwork + "ConsumerSecret";
					var useSharedApplicationSetting = "Use" + socialNetwork + "SharedApplication";
					var arrayToQuery = [consumerKeySetting, consumerSecretSetting, useSharedApplicationSetting];
					this.BPMSoft.SysSettings.querySysSettings(arrayToQuery, function(values) {
						var socialAccountOptions = {
							consumerKey: values[consumerKeySetting],
							consumerSecret: values[consumerSecretSetting],
							useSharedApplication: values[useSharedApplicationSetting],
							socialNetwork: socialNetwork,
							sandbox: this.sandbox,
							callAfter: function(data, login, socialNetworkId) {
								var communicationTypeId = socialNetworkId;
								var socialMediaId = data.socialId;
								if (socialNetwork === "Google") {
									communicationTypeId = ConfigurationConstants.CommunicationTypes.Email;
								}
								if (communicationTypeId && !Ext.isEmpty(login) && !Ext.isEmpty(socialMediaId)) {
									this.addContactCommunication(communicationTypeId, login, socialMediaId,
										this.loadSocialAccounts, this);
								}
							}.bind(this)
						};
						var isValid = SocialAccountAuthUtilities.checkSettingsAndOpenWindow(socialAccountOptions);
						if (!isValid) {
							this.BPMSoft.utils.showInformation(resources.localizableStrings.QueryAdministartor +
								socialNetwork, Ext.emptyfn, this);
						}
					}, this);
				},

				/**
				 * Check can add social account.
				 * @private
				 * @param {String} socialNetworkType Social account type.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				isSocialNetworkAllowed: function(socialNetworkType, callback, scope) {
					var gridData = this.get("GridData");
					var items = gridData.getItems();
					var socialNetworkName = "";
					var hasAccount = items.some(function(item) {
						var type = item.get("Type");
						var isPublic = item.get("Public");
						var check = ((type.value === socialNetworkType) && !isPublic);
						if (check) {
							socialNetworkName = type.displayValue;
							return true;
						}
					});
					if (hasAccount) {
						var message = this.Ext.String.format(
							resources.localizableStrings.OnlyOneSocialNetworkAllowedCaption, socialNetworkName);
						BPMSoft.utils.showInformation(message, null, null, {buttons: ["ok"]});
					} else if (callback) {
						callback.call(scope || this);
					}
				},

				/**
				 * Add Facebook social account.
				 * @private
				 */
				onFacebookMenuItemClick: function() {
					this.isSocialNetworkAllowed(ConfigurationConstants.CommunicationTypes.Facebook, function() {
						this.createFacebookSocialAccount(function() {
							this.loadSocialAccounts();
						}, this);
					}, this);
				},

				/**
				 * Add LinkedId social account.
				 * @private
				 */
				onLinkedInMenuItemClick: function() {
					this.authenticate("LinkedIn");
				},

				/**
				 * Add Twitter social account.
				 * @private
				 */
				onTwitterMenuItemClick: function() {
					this.authenticate("Twitter");
				},

				/**
				 * Add Google social account.
				 * @private
				 */
				onGoogleMenuItemClick: function() {
					this.canUserChangeCalendar(BPMSoft.emptyString, function() {
						this.authenticate("Google");
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.SyncSettingsMixin#canUserChangeCalendarCallback
				 * @overridden
				 */
				canUserChangeCalendarCallback: function(canAddCalendar, callback, scope) {
					if (canAddCalendar) {
						Ext.callback(callback, scope);
					} else {
						this.showActiveCalendarDialog();
					}
				},

				/**
				 * @inheritdoc BPMSoft.SyncSettingsMixin#getSyncSettingsSchemaName
				 * @overridden
				 */
				getSyncSettingsSchemaName: function() {
					return "ActivitySyncSettings";
				},

				/**
				 * Removes social account.
				 * @protected
				 */
				onDeleteButtonClick: function() {
					var recordId = this.get("activeRowId");
					if (!recordId) {
						return;
					}
					var config = {
						style: BPMSoft.MessageBoxStyles.ORANGE
					};
					this.showConfirmationDialog(resources.localizableStrings.DeleteConfirmation, function(returnCode) {
						if (returnCode !== BPMSoft.MessageBoxButtons.YES.returnCode) {
							return;
						}
						this.showBodyMask();
						this.set("activeRowId", "");
						var gridData = this.get("GridData");
						var socialAccount = gridData.get(recordId);
						socialAccount.deleteEntity(function() {
							var number = socialAccount.get("Login");
							var communicationTypeId = socialAccount.get("Type").value;
							var socialMediaId = socialAccount.get("SocialId");
							if (communicationTypeId === ConfigurationConstants.CommunicationTypes.Google) {
								communicationTypeId = ConfigurationConstants.CommunicationTypes.Email;
							}
							this.deleteContactCommunication(communicationTypeId, number, socialMediaId, function() {
								this.hideBodyMask();
								gridData.removeByKey(recordId);
								this.set("IsGridEmpty", gridData.isEmpty());
							}, this);
						}, this);
					}, ["yes", "no"], config);
				},

				/**
				 * Check contact communication exists.
				 * @param {String} communicationTypeId Communication type.
				 * @param {String} number User login in external resource.
				 * @param {Function} callbackSuccess Callback function on success.
				 * @param {Function} callbackFail Callback function on fail.
				 * @param {Object} scope Callback function context.
				 */
				checkContactCommunicationExists: function(communicationTypeId, number, callbackSuccess, callbackFail, scope) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ContactCommunication"
					});
					esq.addColumn("CommunicationType");
					esq.addColumn("Number");
					esq.addColumn("Contact");
					esq.filters.add("TypeFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"CommunicationType", communicationTypeId));
					esq.filters.add("ValueFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"Number", number));
					esq.filters.add("UserFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"Contact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
					esq.getEntityCollection(function(result) {
						if (result.success) {
							if (result.collection.getCount() === 0) {
								callbackSuccess.call(scope);
							} else {
								callbackFail.call(scope);
							}
						}
					}, this);
				},

				/**
				 * Add contact communication.
				 * @private
				 * @param {String} communicationTypeId Communication type.
				 * @param {String} number User login in external resource.
				 * @param {String} socialMediaId User Id in external resource.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				addContactCommunication: function(communicationTypeId, number, socialMediaId, callback, scope) {
					this.checkContactCommunicationExists(communicationTypeId, number, function() {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ContactCommunication"
						});
						var id = BPMSoft.utils.generateGUID();
						insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
						insert.setParameterValue("CommunicationType", communicationTypeId,
							BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Contact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
							BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Number", number, BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("SocialMediaId", socialMediaId, BPMSoft.DataValueType.TEXT);
						insert.execute(callback, scope);
					}, callback, this);
				},

				/**
				 * Removes contact communication.
				 * @private
				 * @param {String} communicationTypeId Communication type.
				 * @param {String} number User login in external resource.
				 * @param {String} socialMediaId User Id in external resource.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				deleteContactCommunication: function(communicationTypeId, number, socialMediaId, callback, scope) {
					if (communicationTypeId !== ConfigurationConstants.CommunicationTypes.Email) {
						var del = this.Ext.create("BPMSoft.DeleteQuery", {
							rootSchemaName: "ContactCommunication"
						});
						del.filters.add("ContactFilter",
							del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Contact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
						del.filters.add("CommunicationTypeFilter",
							del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"CommunicationType", communicationTypeId));
						del.filters.add("NumberFilter",
							del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Number", number));
						del.filters.add("SocialMediaIdFilter",
							del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"SocialMediaId", socialMediaId));
						del.execute(callback, scope);
					} else {
						callback.call(scope);
					}
				},

				/**
				 * Checks can user add LinkedIn account.
				 * @return {Boolean} Result.
				 */
				getLinkedInMenuItemVisible: function() {
					return (Contact.columns.LinkedIn.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initCollections();
					this.initActionsMenuItems();
					this.loadSocialAccounts();
				},

				initCollections: function() {
					this.set("ActionsMenuItems", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.set("GridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				},

				/**
				 * Initializes actions button menu items.
				 * @private
				 */
				initActionsMenuItems: function() {
					var actionsMenuItems = this.get("ActionsMenuItems");
					actionsMenuItems.addItem(this.getButtonMenuItem({
						Caption: this.get("Resources.Strings.ConvertToPublic"),
						Click: {"bindTo": "convertToPublic"},
						Visible: {bindTo: "getConvertToPublicMenuItemVisible"}
					}));
					actionsMenuItems.addItem(this.getButtonMenuItem({
						Caption: this.get("Resources.Strings.ConvertToPrivate"),
						Click: {"bindTo": "convertToPrivate"},
						Visible: {bindTo: "getConvertToPrivateMenuItemVisible"}
					}));
					actionsMenuItems.addItem(this.getButtonMenuSeparator());
					actionsMenuItems.addItem(this.getButtonMenuItem({
						Caption: this.get("Resources.Strings.DeleteButtonCaption"),
						Click: {"bindTo": "onDeleteButtonClick"},
						Enabled: {"bindTo": "getDeleteButtonEnabled"}
					}));
				},

				/**
				 * Converts social account to public.
				 * @private
				 */
				convertToPublic: function() {
					this.checkCanManageSharedSocialAccounts(function() {
						var config = {
							message: resources.localizableStrings.ConfirmConvertToPublic,
							isPublic: true
						};
						this.promptChangeSocialAccountType(config, function() {
							this.changeSocialAccountType(config);
						}, this);
					}, this);
				},

				/**
				 * Converts social account to private.
				 * @private
				 */
				convertToPrivate: function() {
					this.checkCanManageSharedSocialAccounts(function() {
						var config = {
							message: resources.localizableStrings.ConfirmConvertToPrivate,
							isPublic: false
						};
						this.promptChangeSocialAccountType(config, function() {
							this.changeSocialAccountType(config);
						}, this);
					}, this);
				},

				/**
				 * Ask a question the user for change social account type.
				 * @private
				 * @param {Object} config Change params.
				 * @param {String} config.message Message.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				promptChangeSocialAccountType: function(config, callback, scope) {
					this.showConfirmationDialog(config.message, function(result) {
						if (result !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
							return;
						}
						callback.call(scope);
					}, ["yes", "no"]);
				},

				/**
				 * Changes social account type.
				 * @private
				 * @param {Object} config Change params.
				 * @param {Boolean} config.isPublic Type.
				 */
				changeSocialAccountType: function(config) {
					var activeRow = this.findActiveRow();
					activeRow.set("Public", config.isPublic);
					activeRow.saveEntity(function(response) {
						if (!response.success) {
							throw new BPMSoft.UnknownException({
								message: response.errorInfo.message
							});
						}
						this.set("activeRowId", "");
					}, this);
				},

				/**
				 * Check view model type.
				 * @private
				 * @param {BPMSoft.BaseViewModel} viewModel View model.
				 * @return {Boolean} Result.
				 */
				getIsFacebook: function(viewModel) {
					var type = viewModel.get("Type");
					return (type.value === ConfigurationConstants.CommunicationTypes.Facebook);
				},

				/**
				 * Returns value of view model attribute "Public".
				 * @private
				 * @param {BPMSoft.BaseViewModel} viewModel View model.
				 * @return {Boolean} Value of attribute "Public".
				 */
				getIsPublic: function(viewModel) {
					return viewModel.get("Public");
				},

				/**
				 * Returns the value of property Visible for Make public menu item.
				 * @return {Boolean} Value of property Visible for Make public menu item.
				 */
				getConvertToPublicMenuItemVisible: function() {
					var activeRow = this.findActiveRow();
					if (!activeRow) {
						return false;
					}
					var isFacebook = this.getIsFacebook(activeRow);
					var isPublic = this.getIsPublic(activeRow);
					return (isFacebook && !isPublic);
				},

				/**
				 * Returns the value of property Visible for Make private menu item.
				 * @return {Boolean} Value of property Visible for Make private menu item.
				 */
				getConvertToPrivateMenuItemVisible: function() {
					var activeRow = this.findActiveRow();
					if (!activeRow) {
						return false;
					}
					var isFacebook = this.getIsFacebook(activeRow);
					var isPublic = this.getIsPublic(activeRow);
					return (isFacebook && isPublic);
				},

				/**
				 * Returns the value of property Enabled for Delete menu item.
				 * @return {Boolean} Value of property Enabled for Delete menu item.
				 */
				getDeleteButtonEnabled: function() {
					var activeRow = this.findActiveRow();
					return !this.Ext.isEmpty(activeRow);
				},

				/**
				 * Returns active row view model.
				 * @private
				 * @return {BPMSoft.BaseViewModel} Active row view model.
				 */
				findActiveRow: function() {
					var primaryColumnValue = this.get("activeRowId");
					var gridData = this.get("GridData");
					return gridData.find(primaryColumnValue);
				},

				/**
				 * Check current user's right to administrated operation "Accessing the management of shared
				 * user accounts in external resources".
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				checkCanManageSharedSocialAccounts: function(callback, scope) {
					this.getCanManageSharedSocialAccounts(function(operationValue) {
						if (operationValue) {
							return callback.call(scope);
						}
						this.showPermissionsErrorMessage("CanManageSharedSocialAccounts");
					}, this);
				},

				/**
				 * Returns current user's right to administrated operation "Accessing the management of shared
				 * user accounts in external resources".
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function context.
				 */
				getCanManageSharedSocialAccounts: function(callback, scope) {
					var operationName = "CanManageSharedSocialAccounts";
					var operationValue = this.get(operationName);
					if (!this.Ext.isEmpty(operationValue)) {
						return callback.call(scope, operationValue);
					}
					RightUtilities.checkCanExecuteOperation({operation: operationName}, function(result) {
						callback.call(scope, result);
					}, this);
				},

				/**
				 * Applies default column properties.
				 * @private
				 * @param {Object} column Column.
				 */
				applyColumnDefaults: function(column) {
					if (this.Ext.isNumber(column.type)) {
						return;
					}
					var type = this.BPMSoft.ViewModelColumnType;
					column.type = this.Ext.isEmpty(column.columnPath) ? type.VIRTUAL_COLUMN : type.ENTITY_COLUMN;
				},

				/**
				 * Modifies grid data collection before loading to grid.
				 * @private
				 * @param {Object} collection Grid data collection.
				 */
				prepareResponseCollection: function(collection) {
					collection.each(function(item) {
						this.BPMSoft.each(item.columns, function(column) {
							this.applyColumnDefaults(column);
						}, this);
					}, this);
				},

				/**
				 * Close current page.
				 */
				onCloseButtonClick: function() {
					this.sandbox.publish("BackHistoryState");
				},

				onRender: function() {
					this.callParent(arguments);
				},

				initMainHeaderCaption: function() {
					var mainHeaderConfig = {
						caption: this.get("Resources.Strings.ModuleCaption"),
						dataViews: false
					};
					this.sandbox.publish("InitDataViews", mainHeaderConfig);
					this.sandbox.subscribe("NeedHeaderCaption", function() {
						this.sandbox.publish("InitDataViews", mainHeaderConfig);
					}, this);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "SocialAccountModuleContainer",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							wrapClassName: ["social-accounts-module"]
						},
						"markerValue": {bindTo: "Resources.Strings.ModuleCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialAccountModuleHeaderContainer",
					"propertyName": "items",
					"parentName": "SocialAccountModuleContainer",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							wrapClassName: ["container-spacing", "top-buttons"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SocialAccountModuleHeaderContainer",
					"name": "AddRecordButton",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"caption": {bindTo: "Resources.Strings.AddButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"markerValue": "AddRecordButton",
						"classes": {"textClass": "AddRecord-social-account-button"},
						"menu": {
							items: [
								{
									className: "BPMSoft.MenuItem",
									caption: {bindTo: "Resources.Strings.LinkedInMenuItemCaption"},
									click: {
										bindTo: "onLinkedInMenuItemClick"
									},
									visible: {
										bindTo: "getLinkedInMenuItemVisible"
									}
								},
								{
									className: "BPMSoft.MenuItem",
									caption: {bindTo: "Resources.Strings.GoogleMenuItemCaption"},
									click: {
										bindTo: "onGoogleMenuItemClick"
									}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SocialAccountModuleHeaderContainer",
					"name": "ActionsButton",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"caption": {bindTo: "Resources.Strings.ActionsButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"markerValue": "ActionsButton",
						"classes": {"textClass": "actions-social-account-button"},
						"menu": {
							items: {
								bindTo: "ActionsMenuItems"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SocialAccountModuleHeaderContainer",
					"name": "CloseButton",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"caption": {bindTo: "Resources.Strings.CloseButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"markerValue": "CloseButton",
						"classes": {"textClass": "close-social-account-button"},
						click: {
							bindTo: "onCloseButtonClick"
						}
					}
				},
				{
					"operation": "insert",
					"name": "SocialAccountModuleMainContainer",
					"propertyName": "items",
					"parentName": "SocialAccountModuleContainer",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							wrapClassName: ["container-spacing"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DataGrid",
					"propertyName": "items",
					"parentName": "SocialAccountModuleMainContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID,
						"type": "listed",
						"listedZebra": true,
						"activeRow": {"bindTo": "activeRowId"},
						"collection": {"bindTo": "GridData"},
						"isEmpty": {"bindTo": "IsGridEmpty"},
						"primaryColumnName": "Id",
						"sortColumnIndex": {"bindTo": "GridSortColumnIndex"},
						"rowDataItemMarkerColumnName": "Type",
						"captionsConfig": [
							{
								cols: 4,
								name: resources.localizableStrings.TypeColName
							},
							{
								cols: 12,
								name: resources.localizableStrings.LoginColCaption
							},
							{
								cols: 6,
								name: resources.localizableStrings.UserColName
							},
							{
								cols: 2,
								name: resources.localizableStrings.PublicColName
							}
						],
						"columnsConfig": [
							{
								cols: 4,
								key: [
									{
										name: {
											bindTo: "Type"
										}
									}
								]
							},
							{
								cols: 12,
								key: [
									{
										name: {
											bindTo: "Login"
										}
									}
								],
								link: {
									"bindTo": "getSocialLink"
								}
							},
							{
								cols: 6,
								key: [
									{
										name: {
											bindTo: "User"
										}
									}
								]
							},
							{
								cols: 2,
								key: [
									{
										name: {
											bindTo: "Public"
										}
									}
								]
							}
						]
					}
				}
			]
		};
	});
