define("UserProfilePage", ["BPMSoft", "UserProfilePageResources", "ConfigurationConstants", "UserPageV2", "UserPageV2Resources", "NotificationsSettingsSchema", "SysAdminUnit", "DesktopPopupNotification", "StorageUtilities", "LookupUtilities", 'ContactPageV2Resources',
		"BaseSchemaModuleV2", "ContextHelpMixin", "ProfileSchemaMixin", "CommunicationSynchronizerMixin", "CommunicationOptionsMixin", "css!ProfileModule", "css!UserProfileCSS", "css!UsrProfilePageV2CSS", "MainMenuUtilities"],
	function (BPMSoft, Resources, ConfigurationConstants, UserPageV2, UserPageV2Resources, NotificationsSettingsSchema, SysAdminUnit, DesktopPopupNotification, StorageUtilities, LookupUtilities, ContactPageV2Resources) {
		return {
			entitySchemaName: 'Contact',
			mixins: {
				ContextHelpMixin: "BPMSoft.ContextHelpMixin",
				ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin",
				CommunicationSynchronizerMixin: "BPMSoft.CommunicationSynchronizerMixin",
				CommunicationOptionsMixin: "BPMSoft.CommunicationOptionsMixin"
			},
			details: {},
			modules: {
				"PopupsStateFlag": {
					"config": {
						"schemaName": "NotificationsSettings",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								masterColumnName: "PopupsStateFlag"
							}
						}
					}
				},

				"IsNotificationsEnable": {
					"config": {
						"schemaName": "CenterNotificationSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								masterColumnName: "IsNotificationsEnable"
							}
						}
					}
				},
			},
			messages: {
				"UpdateSectionGrid": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				"SyncCommunication": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"GetCommunicationsSynchronizedByDetail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"CallCustomer": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"BackHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"NeedHeaderCaption": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"InitDataViews": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"ChangeCommandList": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				"DefMobilePhone": {
					name: "DefMobilePhone",
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.DataValueType.VIRTUAL_COLUMN,
				},
				"UserLogin": {
					name: "UserLogin",
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.DataValueType.VIRTUAL_COLUMN,
				},
				"defUserLogin": {
					name: "defUserLogin",
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.DataValueType.VIRTUAL_COLUMN,
				},
				"Birthdate": {
					name: "Birthdate",
					dataValueType: this.BPMSoft.DataValueType.DATE,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},
				"DefBirthdate": {
					name: "DefBirthdate",
					dataValueType: this.BPMSoft.DataValueType.DATE,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},
				"DefPhoto": {
					name: "DefPhoto",
					dataValueType: this.BPMSoft.DataValueType.IMAGELOOKUP,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},
				"PopupsStateFlag": {
					name: "PopupsStateFlag",
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				},
				"IsNotificationsEnable": {
					name: "IsNotificationsEnable",
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"connectionParamsConfig": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},
				Culture: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isRequired: true
				},
				DefCulture: {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				DateTimeFormat: {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				DefDateTimeFormat: {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				TimeZone: {
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				TimeZoneId: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				DefTimeZoneId: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				VisibleByBuildType: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				IsSSP: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN
				},
				SysCultureList: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				DateTimeFormatList: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				TimeZoneList: {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					autocomplete: false,
				},
				HeaderCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				changeCallCentreSetupTitle: {
					dataValueType: BPMSoft.DataValueType.TEXT
				}
			},
			methods: {
				//region Methods: Private

				/**
				 * Initializes culture.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 */
				initCulture: function (callback, scope) {
					this.callService({
						serviceName: "CurrentUserService",
						methodName: "GetCurrentUserCulture"
					}, function onCultureInitialized(response, success) {
						if (!success || !response || !response.cultureInfo) {
							callback.call(scope);
							return;
						}
						const cultureInfo = response.cultureInfo;
						this.onCurrentUserCultureInfoLoaded(cultureInfo);
						callback.call(scope);
					}, this);
				},

				/**
				 * Handles the GetCurrentUserCulture request finished.
				 * @private
				 * @param {Object} cultureInfo Current user's culture info.
				 */
				onCurrentUserCultureInfoLoaded: function (cultureInfo) {
					this.initSysCultureInfo(cultureInfo);
					this.initDateTimeFormatInfo(cultureInfo);
					this.initTimeZoneInfo(cultureInfo);
				},

				/**
				 * Initializes system culture info.
				 * @private
				 * @param {Object} cultureInfo Current user's culture info.
				 */
				initSysCultureInfo: function (cultureInfo) {
					const culture = {
						value: cultureInfo.cultureId,
						displayValue: cultureInfo.cultureLanguage
					};
					this.set("Culture", culture);
					this.set("DefCulture", culture);
				},

				/**
				 * Initializes system date and time format info.
				 * @private
				 * @param {Object} cultureInfo Current user's culture info.
				 */
				initDateTimeFormatInfo: function (cultureInfo) {
					const dateTimeFormat = {
						value: cultureInfo.dateTimeFormatId,
						displayValue: cultureInfo.dateTimeFormatName
					};
					this.set("DateTimeFormat", dateTimeFormat);
					this.set("DefDateTimeFormat", dateTimeFormat);
				},

				/**
				 * Initializes time zone info.
				 * @private
				 * @param {Object} cultureInfo Current user's culture info.
				 */
				initTimeZoneInfo: function (cultureInfo) {
					const timeZoneCode = cultureInfo.timeZoneCode;
					const timeZoneId = cultureInfo.timeZoneId;
					const timeZoneName = cultureInfo.timeZoneName;
					this.set("DefTimeZoneId", timeZoneCode);
					this.set("TimeZone", {
						value: timeZoneId,
						displayValue: timeZoneName,
						code: timeZoneCode
					});
					this.set("TimeZoneId", timeZoneCode);
				},

				/**
				 * Calls CommandLineService web-method.
				 * @private
				 * @param {String} methodName Method name.
				 * @param {Function} callback Callback function.
				 * @param {Object} data Method data.
				 */
				callCommandLineServiceMethod: function (methodName, callback, data) {
					const config = {
						serviceName: "CommandLineService",
						methodName: methodName,
						data: data || {}
					};
					this.callService(config, callback, this);
				},

				/**
				 * Checks if culture is changed.
				 * @private
				 * @param {Object} culture Culture.
				 * @return {Boolean}
				 */
				isCultureChanged: function (culture) {
					var defCulture = this.get("DefCulture");
					var defCultureValue = defCulture && defCulture.value;
					var cultureValue = culture && culture.value;
					return (cultureValue !== defCultureValue);
				},

				/**
				 * Checks if date and time format is changed.
				 * @private
				 * @param {Object} dateTimeFormat Date and time format.
				 * @return {Boolean}
				 */
				isDateTimeFormatChanged: function (dateTimeFormat) {
					var defDateTimeFormat = this.get("DefDateTimeFormat");
					var defDateTimeFormatValue = defDateTimeFormat && defDateTimeFormat.value;
					var dateTimeFormatValue = dateTimeFormat && dateTimeFormat.value;
					return (dateTimeFormatValue !== defDateTimeFormatValue);
				},

				/**
				 * Checks if time zone is changed.
				 * @private
				 * @param {Object} timeZone Time zone.
				 * @return {Boolean}
				 */
				isTimeZoneChanged: function (timeZone) {
					var currentTimeZoneCode = timeZone && timeZone.code;
					return (currentTimeZoneCode !== this.get("DefTimeZoneId"));
				},

				/**
				 * Create data views.
				 * @private
				 * @return {BPMSoft.Collection}
				 */
				createDataViews: function () {
					return this.Ext.create(BPMSoft.Collection);
				},

				/**
				 * Handles successful flush of system profile data.
				 * @private
				 * @param {String} returnCode Message box buttons return code.
				 */
				onProfileFlushed: function (returnCode) {
					if (returnCode === BPMSoft.MessageBoxButtons.CLOSE.returnCode) {
						this.reloadPage();
					}
				},

				/**
				 * Reloads page.
				 * @private
				 */
				reloadPage: function () {
					window.location.reload();
				},

				/**
				 * Prepares configuration for update user profile.
				 * @private
				 * @param {Object} changedColumns Changed columns.
				 * @return {Object}
				 */
				prepareUpdateUserProfileConfig: function (changedColumns) {
					return {
						serviceName: "UserProfileEditService",
						methodName: "UpdateUserProfile",
						scope: this,
						data: { 
							updateUser: changedColumns
						}
					};
				},

				/**
				 * @private
				 */
				_requestLogout: function (callback, scope) {
					const message = this.get("Resources.Strings.NeedRestartMessage");
					const logoutButtonCaption = this.get("Resources.Strings.LogoutButtonCaption");
					const logoutButton = {
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						caption: logoutButtonCaption,
						markerValue: logoutButtonCaption,
						returnCode: "logout"
					};
					const closeButtonCaption = BPMSoft.Resources.Controls.MessageBox.ButtonCaptionClose;
					const closeButton = {
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
						caption: closeButtonCaption,
						markerValue: closeButtonCaption,
						returnCode: BPMSoft.MessageBoxButtons.CLOSE.returnCode
					};
					this.showConfirmationDialog(message, function (returnCode) {
						callback.call(scope, returnCode === logoutButton.returnCode);
					}, [logoutButton, closeButton], {
						defaultButton: 0
					});
				},

				/**
				 * Save callback.
				 * @private
				 * @param {Object} response Response.
				 */
				saveCallback: function (response) {
					response.message = response.UpdateUserProfileResult || response.UpdateOrCreateUserResult;
					response.success = this.Ext.isEmpty(response.message);
					if (response.success) {
						this._requestLogout(async function (result) {
							if (result) {
								await BPMSoft.MainMenuUtilities.logout();
							} else {
								this.onCancelClick();
							}
						}, this);
					} else {
						let message = response.message != null && response.message != "" ? response.message : this.get("Resources.Strings.SaveExceptionMessage");
						this.showInformationDialog(message);
						throw new BPMSoft.InvalidOperationException({
							message: response.message
						});
					}
				},

				/**
				 * Handles flush confirmation dialog callback.
				 * @private
				 * @param {String} returnCode Message box buttons return code.
				 */
				flushConfirmationDialogCallback: function (returnCode) {
					if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
						var query = this.createSysProfileDataDeleteQuery();
						query.execute(this.processFlushResponse, this);
					}
				},

				/**
				 * Prepares config for macros modal box.
				 * @private
				 * @return {Object}
				 */
				prepareMacrosModalBoxConfig: function () {
					var scope = this;
					return {
						entitySchemaName: "Macros",
						mode: "editMode",
						multiSelect: true,
						columnName: "Name",
						filters: this.createContactFilter(),
						cardCustomConfig: {
							cardSchema: "MacrosPageModule"
						},
						showButtonConfig: {
							addButtonInActionsMenu: true,
							addButton: false,
							mainActionButtonCaption: Resources.localizableStrings.AddCaption
						},
						methods: {
							onDeleted: function () {
								scope.callCommandLineServiceMethod("ClearCache", function () {
									StorageUtilities.clearStorage(
										StorageUtilities.ClearStorageModes.GROUP, "CommandLineStorage");
									scope.sandbox.publish("ChangeCommandList");
								}, {
									"cacheArray": ["VwCommandActionCache", "CommandParamsCache"]
								});
							}
						}
					};
				},

				/**
				 * Creates filter group for current contact.
				 * @private
				 * @return {BPMSoft.FilterGroup}
				 */
				createContactFilter: function () {
					var contactFilter = BPMSoft.createFilterGroup();
					contactFilter.name = "contactFilter";
					var filter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "CreatedBy",
						BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
					contactFilter.addItem(filter);
					return contactFilter;
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc
				 * @overridden
				 */
				init: function (callback, scope) {
					this.callParent([function () {
						this.initContextHelp();
						this.subscribeSandboxEvents();
						this.set("TimeZone", null);
						this.set("TimeZoneId", null);
						this.set("HeaderCaption", this.getHeader());
						this.set("SysCultureList", this.Ext.create(BPMSoft.Collection));
						this.set("DateTimeFormatList", this.Ext.create(BPMSoft.Collection));
						this.set("TimeZoneList", this.Ext.create(BPMSoft.Collection));
						this.set("isNotificationsSupported", DesktopPopupNotification.getIsNotificationSupported());
						this.set("IsSSP", BPMSoft.isCurrentUserSsp());
						this.getConctactParams();
						this.initLoginInfo();
						this.initTabs();
						this.initPopupsState();
						this.initCulture(function () {
							this.initSysSettings();
							callback.call(scope);
						}, this);
					}, this]);
					this.loadCallCentreModule();
				},

				/**
				 * Initializes system settings.
				 * @protected
				 * @virtual
				 */
				initSysSettings: function () {
					BPMSoft.SysSettings.querySysSettingsItem("ShowDemoLinks", function (value) {
						this.set("VisibleByBuildType", !value);
					}, this);
				},
				
				/**
				 * Subscribes to sandbox events.
				 * @protected
				 * @virtual
				 */
				subscribeSandboxEvents: function () {
					this.sandbox.subscribe("NeedHeaderCaption", this.onNeedHeaderCaption, this);
				},

				/**
				 * Handles "NeedHeaderCaption" event.
				 * @protected
				 * @virtual
				 */
				onNeedHeaderCaption: function () {
					this.sandbox.publish("InitDataViews", {
						caption: this.get("HeaderCaption")
					});
				},

				/**
				 * Gets header caption.
				 * @protected
				 * @virtual
				 * @return {String}
				 */
				getHeader: function () {
					return this.get("Resources.Strings.HeaderCaption");
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
				 * @overridden
				 */
				onRender: function () {
					this.hideBodyMask();
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: this.get("HeaderCaption"),
						dataViews: this.createDataViews()
					});
					
					this.removeTabsBySecure();
				},

				removeTabsBySecure: function () {
					if (!this.isCallCentreSettingsVisible()) this.removeTabs("callCentreSetupTab");
					if (!this.isMailboxConfigSettingsVisible()) this.removeTabs("MailboxesTab");
				},

				removeTabs: function (tabNameForRemove) {
					const tabsCollection = this.get("TabsCollection");
					const tabForRemove = tabsCollection.find(tabNameForRemove);

					tabsCollection.remove(tabForRemove);
				},

				getChangeCallCentreSetupTitle: function() {
					var headerCaption = this.BPMSoft.SysValue.CTI.setupPageName;
					if (headerCaption) this.set("changeCallCentreSetupTitle", headerCaption);
				},

				loadCallCentreModule: function () {
					this.sandbox.loadModule("SetupTelephonyParametersPageModule", { isAsync: true });
				},

				/**
				 * Processes system profile data flush response.
				 * @param {Object} response Response.
				 */
				processFlushResponse: function (response) {
					var callback;
					var message;
					if (response && response.success) {
						message = this.get("Resources.Strings.FlushSuccessful");
						callback = this.onProfileFlushed;
					} else {
						message = this.get("Resources.Strings.OnFlushError");
						callback = BPMSoft.emptyFn;
					}
					this.showConfirmationDialog(message, callback);
				},

				/**
				 * Gets system culture display value.
				 * @protected
				 * @virtual
				 * @param {Object} item System culture.
				 * @return {String}
				 */
				getSysCultureDisplayValue: function (item) {
					return item.get("Code");
				},

				/**
				 * @inheritdoc BPMSoft.ContextHelpMixin#getContextHelpId
				 * @overridden
				 */
				getContextHelpId: function () {
					return "1012";
				},

				/**
				 * Prepares culture list item.
				 * @protected
				 * @virtual
				 * @param {Object} item Culture list item.
				 * @return {Object}
				 */
				prepareSysCultureListItem: function (item) {
					return {
						value: item.get("Id"),
						displayValue: this.getSysCultureDisplayValue(item)
					};
				},

				/**
				 * Prepares date and time format list item.
				 * @protected
				 * @virtual
				 * @param {Object} item Date and time format list item.
				 * @return {Object}
				 */
				prepareDateTimeFormatListItem: function (item) {
					return {
						value: item.get("Id"),
						displayValue: item.get("Name")
					};
				},

				/**
				 * Prepares time zone list item.
				 * @protected
				 * @virtual
				 * @param {Object} item Time zone list item.
				 * @return {Object}
				 */
				prepareTimeZoneListItem: function (item) {
					return {
						value: item.get("Id"),
						displayValue: item.get("Name"),
						code: item.get("Code")
					};
				},

				/**
				 * Initializes system culture query filters.
				 * @protected
				 * @virtual
				 */
				initSysCultureQueryFilters: BPMSoft.emptyFn,

				/**
				 * Initializes system culture query columns.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initSysCultureQueryColumns: function (esq) {
					esq.addColumn("Id");
					esq.addColumn("Name", "Code");
				},

				/**
				 * Initializes date and time format query columns.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initDateTimeFormatQueryColumns: function (esq) {
					esq.addColumn("Id");
					var nameColumn = esq.addColumn("Name");
					nameColumn.orderPosition = 0;
					nameColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				},

				/**
				 * Initializes time zone query columns.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initTimeZoneQueryColumns: function (esq) {
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("Code");
				},

				/**
				 * Creates culture entity schema query.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				createSysCultureQuery: function () {
					var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {
						rootSchemaName: "SysCulture"
					});
					this.initSysCultureQueryColumns(esq);
					this.initSysCultureQueryFilters(esq);
					return esq;
				},

				/**
				 * Creates date and time format info entity schema query.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				createDateTimeFormatQuery: function () {
					var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {
						rootSchemaName: "SysLanguage"
					});
					this.initDateTimeFormatQueryColumns(esq);
					return esq;
				},

				/**
				 * Creates TimeZone entity schema query.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				createTimeZoneQuery: function () {
					var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {
						rootSchemaName: "TimeZone"
					});
					this.initTimeZoneQueryColumns(esq);
					return esq;
				},

				/**
				 * Creates SysProfileData delete query.
				 * @protected
				 * @return {BPMSoft.DeleteQuery}
				 */
				createSysProfileDataDeleteQuery: function () {
					var query = this.Ext.create(BPMSoft.DeleteQuery, {
						rootSchemaName: "SysProfileData"
					});
					var currentUserContactId = BPMSoft.SysValue.CURRENT_USER_CONTACT.value;
					var filter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Contact", currentUserContactId);
					query.filters.addItem(filter);
					return query;
				},

				savePopupsState: function () {
					if (DesktopPopupNotification.getPermissionLevel() !== DesktopPopupNotification.PermissionType.GRANTED) {
						DesktopPopupNotification.requestPermission(this.setPopupsState, this);
					} else {
						this.setPopupsState();
					}
				},

				/**
				 * Sets state of popups.
				 * @private
				 */
				setPopupsState: function () {
					var state = this.get("PopupsStateFlag");
					DesktopPopupNotification.setNotificationsState(state, this.goBack.bind(this));
				},

				goBack: function () {
					console.log('save success')
				},

				/**
				 * Initialize state of popups.
				 * @private
				 */
				initPopupsState: function () {
					DesktopPopupNotification.getNotificationsState(function (enabled) {
						this.set("PopupsStateFlag", enabled);
						this.set("IsNotificationsEnable", enabled);
					}, this);
				},

				isPopUpCheckBoxChanged: function (value) {
					var currentPopUpCheckBoxValue = value;
					return (currentPopUpCheckBoxValue !== this.get("IsNotificationsEnable"));
				},

				isNameChanged: function (value) {
					var currentName = value;
					return (currentName !== this.get("Owner").displayValue)
				},

				isUerLoginChanged: function (value) {
					var currentUserLogin = value;
					return (currentUserLogin !== this.get("DefUserLogin"))
				},

				isBirthDateChanged: function () {
					return (this.Ext.Date.isEqual(this.get("BirthDate"), this.get("DefBirthDate")))
				},

				isMobilePhoneChanged: function (value) {
					var currentMobilePhone = Number(value);
					return (currentMobilePhone !== Number(this.get("DefMobilePhone")))
				},

				isPhotoChanged: function (value) {
					var currentPhotoValue = value
					return currentPhotoValue !== this.get("DefPhoto").value;
				},

				/**
				 * Handles save button click.
				 */
				onSaveClick: function () {
					if (!this.validate()) {
						return;
					}

					var culture = this.get("Culture");
					var cultureChanged = this.isCultureChanged(culture);
					var dateTimeFormat = this.get("DateTimeFormat");
					var dateTimeFormatChanged = this.isDateTimeFormatChanged(dateTimeFormat);
					var timeZone = this.get("TimeZone");
					var timeZoneChanged = this.isTimeZoneChanged(timeZone)
					var userLogin = this.get("UserLogin");
					var userLoginChanged = this.isUerLoginChanged(userLogin)
					var popUpCheckBox = this.get("PopupsStateFlag");
					var popUpCheckBoxChanged = this.isPopUpCheckBoxChanged(popUpCheckBox);
					var nameValue = this.get("Name");
					var nameCheckChanged = this.isNameChanged(nameValue);
					var BirthDate = this.get("BirthDate")
					var BirthDateChanged = this.isBirthDateChanged()
					var MobilePhone = this.get("MobilePhone");
					var MobilePhoneChanged = this.isMobilePhoneChanged(MobilePhone);
					var Photo = this.get("Photo").value
					var PhotoChanged = this.isPhotoChanged(Photo)
					var changedColumns = {};
					var changeContactColumns = {};


					if (nameCheckChanged) {
						changeContactColumns.Name = nameValue;
					}
					if (MobilePhoneChanged) {
						changeContactColumns.MobilePhone = MobilePhone
					}
					if (!BirthDateChanged) {
						changeContactColumns.BirthDate = BirthDate
					}
					if (popUpCheckBoxChanged) {
						changeContactColumns.popUpCheckBox = popUpCheckBox
						this.savePopupsState();
					}

					if (cultureChanged) {
						changedColumns.SysCulture = culture.value;
					}
					if (userLoginChanged) {
						changedColumns.Name = userLogin
					}
					if (dateTimeFormatChanged) {
						changedColumns.DateTimeFormat = (dateTimeFormat && dateTimeFormat.value) ? dateTimeFormat.value : BPMSoft.GUID_EMPTY;
					}
					if (timeZoneChanged) {
						changedColumns.TimeZone = (timeZone && timeZone.value) ? timeZone.value : BPMSoft.GUID_EMPTY;
					}
					if (PhotoChanged) {
						changeContactColumns.Photo = Photo.value
					}
	
					if (BPMSoft.isEmptyObject(changedColumns) && BPMSoft.isEmptyObject(changeContactColumns)) {
						this.showInformationDialog(this.get('Resources.Strings.NoChangesCaption'))

					} else {
							this.updateGeneralInfoValues(changeContactColumns);
							var config = this.prepareUpdateUserProfileConfig(changedColumns);
							this.callService(config, this.saveCallback, this);			
					}
				},


				updateGeneralInfoValues: function (changeContactColumns) {
					var update = this.getUpdateGeneralInfo(changeContactColumns);
					update.execute(function (result) {
						if (!(result && result.success)) {
							throw new BPMSoft.UnknownException({
								message: result.errorInfo.message
							});
						}
						// callback.call(scope || this);
					}, this);
				},

				getUpdateGeneralInfo: function (changeContactColumns) {
					var nameKey = changeContactColumns.hasOwnProperty('Name');
					var BirthDate = changeContactColumns.hasOwnProperty('BirthDate');
					var MobilePhone = changeContactColumns.hasOwnProperty('MobilePhone');
					var Photo = changeContactColumns.hasOwnProperty('Photo');
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Contact"
					});
					var filters = update.filters;
					var contactId = this.get("Id");
					var idFilter = update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"Id", contactId);
					filters.add("IdFilter", idFilter);
					if (nameKey) update.setParameterValue("Name", this.get("Name"), this.BPMSoft.DataValueType.TEXT);
					if (BirthDate) update.setParameterValue("BirthDate", this.get("BirthDate"), this.BPMSoft.DataValueType.DATE);
					if (MobilePhone) update.setParameterValue("MobilePhone", this.get("MobilePhone"), this.BPMSoft.DataValueType.TEXT);
					if (Photo) update.setParameterValue("Photo", this.get("Photo").value, this.BPMSoft.DataValueType.IMAGELOOKUP);
					return update;
				},

				/**
				 * Handles cancel button click.
				 */
				 onCancelClick: function () {
					var router = BPMSoft.router.Router;
					var history = router.context.history;
					var hasHistory = history.length > 1;
					if (hasHistory) {
						this.sandbox.publish("BackHistoryState");
					}
				},

				/**
				 * Handles password settings button click.
				 */
				onPasswordSettingsClick: function () {
					this.sandbox.publish("PushHistoryState", {
						hash: "ChangePasswordModule"
					});
				},

				/**
				 * Handles mail settings button click.
				 */
				onMailSettingsClick: function () {
					var mailModule = "MailboxSynchronizationSettingsModule";
					this.sandbox.publish("PushHistoryState", {
						hash: mailModule
					});
				},

				/**
				 * Handles social accounts button click.
				 */
				onSocialAccountsClick: function () {
					var socialModule = "SocialAccountModule";
					this.sandbox.publish("PushHistoryState", {
						hash: socialModule
					});
				},

				/**
				 * Handles notification settings button click.
				 */
				onNotificationsSettingsClick: function () {
					var notificationsSettingsModule = "NotificationsSettingsModule";
					this.sandbox.publish("PushHistoryState", {
						hash: notificationsSettingsModule
					});
				},

				/**
				 * Opens setup call centre parameters page.
				 */
				 setupCallCentreParameters: function() {
					var callCentreParametersModule = "SetupTelephonyParametersPageModule";
					this.sandbox.publish("PushHistoryState", {hash: callCentreParametersModule});
				},

				/**
				 * Determines if call centre settings button is visible.
				 * @return {Boolean}
				 */
				isCallCentreSettingsVisible: function() {
					return !this.get("IsSSP");
				},

				/**
				 * Determines if mailbox config settings button is visible.
				 * @return {Boolean}
				 */
				isMailboxConfigSettingsVisible: function() {
					return !this.get("IsSSP");
				},

				/**
				 * Checks if default settings button visible.
				 * @return {Boolean}
				 */
				isDefaultSettingsButtonVisible: function () {
					return !this.get("IsSSP");
				},

				/**
				 * Checks if command line settings visible.
				 * @return {Boolean}
				 */
				isCommandLineSettingsVisible: function () {
					return !this.get("IsSSP");
				},

				/**
				 * Checks if user can change login.
				 * @return {Boolean}
				 */
				isUserLoginFieldEnabled: function () {
					return !this.get("IsSSP");
				},

				/**
				 * Checks if sync settings visible.
				 * @return {Boolean}
				 */
				isSyncSettingsVisible: function () {
					return (this.get("VisibleByBuildType") && !this.get("IsSSP"));
				},

				/**
				 * Checks if notifications settings visible.
				 * @return {Boolean}
				 */
				isNotificationsSettingsVisible: function () {
					return (this.get("isNotificationsSupported") && !this.get("IsSSP"));
				},

				/**
				 * Event handler for prepare list event of system culture lookup.
				 */
				onPrepareSysCultureList: function () {
					var esq = this.createSysCultureQuery();
					esq.getEntityCollection(function (response) {
						if (!response || !response.success) {
							return;
						}
						var list = this.get("SysCultureList");
						var columnList = {};
						response.collection.each(function (item) {
							// if (item.get("Id") === 'a5420246-0a8e-e111-84a3-00155d054c03') return
							columnList[item.get("Id")] = this.prepareSysCultureListItem(item);
						}, this);
						list.clear();
						list.loadAll(columnList);
					}, this);
				},

				/**
				 * Event handler for prepare list event of date and time format lookup.
				 */
				onPrepareDateTimeFormatList: function () {
					var esq = this.createDateTimeFormatQuery();
					esq.getEntityCollection(function (response) {
						if (!response || !response.success) {
							return;
						}
						var list = this.get("DateTimeFormatList");
						var columnList = {};
						response.collection.each(function (item) {
							columnList[item.get("Id")] = this.prepareDateTimeFormatListItem(item);
						}, this);
						list.clear();
						list.loadAll(columnList);
					}, this);
				},

				/**
				 * Event handler for prepare list event of time zone lookup.
				 */
				onPrepareTimeZoneList: function () {
					var esq = this.createTimeZoneQuery();
					esq.getEntityCollection(function (response) {
						if (!response || !response.success) {
							return;
						}
						var list = this.get("TimeZoneList");
						var columnList = {};
						response.collection.each(function (item) {
							columnList[item.get("Id")] = this.prepareTimeZoneListItem(item);
						}, this);
						list.clear();
						list.loadAll(columnList);
					}, this);
				},

				/**
				 * Flushes system profile data to default.
				 */
				flushToDefault: function () {
					this.showConfirmationDialog(this.get("Resources.Strings.OnFlushWarning"),
						this.flushConfirmationDialogCallback, ["yes", "no"]);
				},

				/**
				 * Opens command line settings.
				 */
				openCommandsGrid: function () {
					LookupUtilities.Open(this.sandbox, this.prepareMacrosModalBoxConfig(), BPMSoft.emptyFn, this);
				},

				successRedirect: function () {
					var location = window.location;
					var origin = location.origin || location.protocol + "//" + location.host + location.hash;
					var url = Ext.String.format("{0}{1}{2}", origin, location.pathname, location.hash);
					this.changeUrl(url);
				},

				/**
				 * Sets url to native window.location.url.
				 * @private
				 * @param {String} url Url to set.
				 */
				changeUrl: function (url) {
					window.location.href = url;
					location.reload();
				},

				getPhotoSrcMethod: function () {
					var primaryImageColumnValue = this.get(this.primaryImageColumnName);
					if (primaryImageColumnValue) {
						return this.getSchemaImageUrl(primaryImageColumnValue);
					}
					return this.getUserDefaultImageURL();
				},


				getUserDefaultImageURL: function () {
					if (this.get("Resources.Images.DefaultPhoto") === undefined) {
						return this.BPMSoft.ImageUrlBuilder.getUrl(ContactPageV2Resources.localizableImages.DefaultPhoto)
					} else {
						return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultPhoto"))
					}
				},

				onPhotoChange: function (photo) {
					if (!photo) {
						this.set(this.primaryImageColumnName, null);
						return;
					}
					BPMSoft.ImageApi.upload({
						file: photo,
						onComplete: this.onPhotoUploaded,
						onError: this.onPhotoChangeError,
						scope: this
					});
				},

				onPhotoChangeError: function (imageId, error, xhr) {
					if (xhr.response) {
						var response = BPMSoft.decode(xhr.response);
						if (response.error) {
							BPMSoft.showMessage(response.error);
						}
					}
				},

				onPhotoUploaded: function (imageId) {
					var imageData = {
						value: imageId,
						displayValue: "Photo"
					};
					this.set(this.primaryImageColumnName, imageData);
				},

				getConctactParams: function () {
					var contactId = BPMSoft.SysValue.CURRENT_USER_CONTACT.value
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Contact"
					});
					esq.addColumn("MobilePhone", "MobilePhone");
					esq.addColumn("Account", "Account");
					esq.addColumn("Name", "Name");
					esq.addColumn("Email", "Email");
					esq.addColumn("Photo", "Photo");
					esq.addColumn("BirthDate", "BirthDate");

					esq.getEntity(contactId, function (result) {
						if (!result.success) {
							this.showInformationDialog("Ошибка запроса данных");
							return;
						}
						this.set("MobilePhone", result.entity.get("MobilePhone"));
						this.set("Id", contactId);
						this.set("Account", result.entity.get("Account"));
						this.set("Name", result.entity.get("Name"));
						this.set("Owner", { 
							"displayValue": result.entity.get("Name"),
							"value": contactId
						});
						this.set("Email", result.entity.get("Email"));
						this.set("Photo", result.entity.get("Photo"));
						this.set("DefPhoto", result.entity.get("Photo"));
						this.set("BirthDate", result.entity.get("BirthDate"));
						this.set("DefBirthDate", result.entity.get("BirthDate"));
						this.set("DefMobilePhone", result.entity.get("MobilePhone"));
					}, this);
				},

				initLoginInfo: function () {
					if(!this.get("IsSSP"))
						this.initNonSspLoginInfo();
				},

				initNonSspLoginInfo: function() {
					var userId = BPMSoft.SysValue.CURRENT_USER.value
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysAdminUnit"
					});
					esq.addColumn("Contact", "Contact");
					esq.addColumn("Name", "UserLogin");
					esq.getEntity(userId, function (result) {
						if (!result.success) {
							this.showInformationDialog("Ошибка запроса данных");
							return;
						}
						this.set("UserLogin", result.entity.get("UserLogin"));
						this.set("DefUserLogin", result.entity.get("UserLogin"));
					}, this);
				},

				getTabsContainerVisible: function () {
					return !(this.get("TabsCollection").isEmpty());
				},

				activeTabChange: function (activeTab) {
					var activeTabName = activeTab.get("Name");
					var tabsCollection = this.get("TabsCollection");
					tabsCollection.eachKey(function (tabName, tab) {
						var tabContainerVisibleBinding = tab.get("Name");
						this.set(tabContainerVisibleBinding, false);
					}, this);
					this.set(activeTabName, true);
					if (activeTabName === "GeneralInfoTab") {
						this.$AutomationInfoTabInitialized = true;
					}
					if (activeTabName === 'callCentreSetupTab') {
						this.getChangeCallCentreSetupTitle();			
					}
				},


				initTabs: function () {
					var activeTabName = "GeneralInfoTab";
					this.set("ActiveTabName", activeTabName);
					this.set(activeTabName, true);
				},


				onCallClick: function (number) {
					return this.callContact(number, this.$Id, this.$Account);
				},

				isRequiredFieldsVisible: function () {
					return true;
				},

				getBirthDateValidator: function () {
					return {
						invalidMessage: this.get("BirthDate") > new Date()
							? this.get("Resources.Strings.ValidateBirthDateMessage")
							: null
					};
				},

				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("BirthDate", this.getBirthDateValidator);
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [


				{
					"operation": "insert",
					"name": "profileModuleTopContainer",
					"values": {
						"id": "profileModuleTopContainer",
						"selectors": {
							wrapEl: "#profileModuleTopContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["profile-module"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "buttonsMenu",
					"parentName": "profileModuleTopContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"id": "buttonsMenu",
						"selectors": {
							wrapEl: "#buttonsMenu"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["buttons-menu-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SaveButton",
					"parentName": "buttonsMenu",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.SaveButtonCaption"
						},
						"click": {
							"bindTo": "onSaveClick"
						},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": "profile-save-button"
						},
						"visible": {
							"bindTo": "IsSaved",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "buttonsMenu",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.CancelButtonCaption"
						},
						"click": {
							"bindTo": "onCancelClick"
						}
					}
				},

				{
					"operation": "insert",
					"name": "myCommands",
					"parentName": "buttonsMenu",
					"propertyName": "items",
					"index": 3,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.MyCommandsCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {
							"bindTo": "openCommandsGrid"
						},
						"classes": {
							"textClass": "profile-button"
						},
						"tag": "myCommands",
						"visible": {
							"bindTo": "isCommandLineSettingsVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "profileModuleTopContainer",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "Photo",
					"values": {
						"getSrcMethod": "getPhotoSrcMethod",
						"onPhotoChange": "onPhotoChange",
						"beforeFileSelected": "beforeFileSelected",
						"readonly": false,
						"defaultImage": {
							"bindTo": "getUserDefaultImageURL"
						},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "AccountName",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Name"
						},
						"classes": {
							"labelClass": [
								"accountName-label"
							]
						},
					}
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "RightInfoContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},

				{
					"operation": "insert",
					"name": "AccountMobilePhone",
					"parentName": "RightInfoContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "MobilePhone"
						},
						"classes": {
							"labelClass": [
								"mainPhone-label"
							]
						},
					}
				},
				{
					"operation": "insert",
					"name": "AccountEmail",
					"parentName": "RightInfoContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Email"
						},
						"classes": {
							"labelClass": [
								"mainEmail-label"
							]
						},
					}
				},
				{
					"operation": "insert",
					"name": "TabsContainer",
					"parentName": "profileModuleTopContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "getTabsContainerVisible"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Tabs",
					"parentName": "TabsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TAB_PANEL,
						"activeTabChange": {
							"bindTo": "activeTabChange"
						},
						"activeTabName": "GeneralInfoTab",
						"classes": {
							"wrapClass": ["tab-panel-top-portal"]
						},
						"collection": {
							"bindTo": "TabsCollection"
						},
						"isScrollVisible": false,
						"tabs": []
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": Resources.localizableStrings.AccountSettings,
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "ContactGeneralInfoBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TextHeaderLabel",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label"
							]
						},
						"caption": Resources.localizableStrings.AccountDetails
					}
				},

				{
					"operation": "insert",
					"parentName": "ContactGeneralInfoBlock",
					"propertyName": "items",
					"name": "AccountNameTabContent",
					"values": {
						"id": "account-username",
						"bindTo": "Name",
						"contentType": BPMSoft.ContentType.LOOKUP,
						"isRequired": false,
					}
				},

				{
					"operation": "insert",
					"parentName": "ContactGeneralInfoBlock",
					"propertyName": "items",
					"name": "UserLogin",
					"values": {
						"caption": Resources.localizableStrings.UserLogin,
						"contentType": BPMSoft.ContentType.LOOKUP,
						"bindTo": "UserLogin",
						"enabled": {
							"bindTo": "isUserLoginFieldEnabled"
						},
						"visible": true
					}
				},
				{
					"operation": "insert",
					"parentName": "ContactGeneralInfoBlock",
					"propertyName": "items",
					"name": "AccountMobilePhoneTabContent",
					"values": {
						// "enabled": false,
						"className": "BPMSoft.PhoneEdit",
						"bindTo": "MobilePhone",
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"autocomplete": BPMSoft.generateGUID(),
						}
					},
				},
				{
					"operation": "insert",
					"parentName": "ContactGeneralInfoBlock",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"enabled": false,
						"caption": Resources.localizableStrings.Contact,
					}
				},

				{
					"operation": "insert",
					"parentName": "ContactGeneralInfoBlock",
					"propertyName": "items",
					"name": "BirthDate",
					"values": {
						"bindTo": "BirthDate",
						"contentType": BPMSoft.ContentType.DATE,
						// "enabled": false,
						"isRequired": false,
					}
				},
				{
					"operation": "insert",
					"name": "callCentreSetupTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1,
					"values": {
						"caption": Resources.localizableStrings.callCentreSetupTab,
						// "visible": true - не рабочий механизм,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "callCentreSetupTab",
					"propertyName": "items",
					"name": "callCentreSetupBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TextLabel",
					"parentName": "callCentreSetupBlock",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label"
							]
						},
						"caption": {"bindTo": "changeCallCentreSetupTitle"}
					}
				},
				{
					"operation": "insert",
					"parentName": "callCentreSetupTab",
					"propertyName": "items",
					"name": "SetupTelephonyParametersPageModule",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "SetupTelephonyParametersPageModule",
						"visible": {
							"bindTo": "isCallCentreSettingsVisible"
						},
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "MailboxesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2,
					"values": {
						"caption": Resources.localizableStrings.MailboxesCaption,
						// "visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "MailboxesTab",
					"propertyName": "items",
					"name": "MailboxesTabInfoBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TextLabel",
					"parentName": "MailboxesTabInfoBlock",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label", "emailModule-header"
							]
						},
						"caption": Resources.localizableStrings.MailServicesTitle,
					}
				},
				{
					"operation": "insert",
					"parentName": "MailboxesTabInfoBlock",
					"propertyName": "items",
					"name": "MailboxSynchronizationSettingsModule",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "MailboxSynchronizationSettingsModule",
						"visible": true,
						"items": [],
					}
				},
				{
					"operation": "remove",
					"name": "SocialAccountsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3,
					"values": {
						"caption": Resources.localizableStrings.SocialNetworkAccountsCaption, 
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "remove",
					"parentName": "SocialAccountsTab",
					"propertyName": "items",
					"name": "SocialAccountsTabInfoBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "remove",
					"name": "TextLabel",
					"parentName": "SocialAccountsTabInfoBlock",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label", "socilaAccounts-header"
							]
						},
						"caption": Resources.localizableStrings.AccountsTitle, 
					}
				},
				{
					"operation": "remove",
					"parentName": "SocialAccountsTabInfoBlock",
					"propertyName": "items",
					"name": "SocialAccountModule",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "SocialAccountModule",
						"visible": true,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "SysSettingsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4,
					"values": {
						"caption": Resources.localizableStrings.SysSettings, 
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SysSettingsTab",
					"propertyName": "items",
					"name": "SysSettingsTabInfoBlock",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TextLabel",
					"parentName": "SysSettingsTabInfoBlock",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label"
							]
						},
						"caption": Resources.localizableStrings.SysSettings
					}
				},
				{
					"operation": "insert",
					"parentName": "SysSettingsTabInfoBlock",
					"propertyName": "items",
					"name": "languageDateTimeZoneContainer",
					"values": {
						"id": "languageDateTimeZoneContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"parentName": "languageDateTimeZoneContainer",
					"propertyName": "items",
					"name": "LanguageSettingsContainer",
					"values": {
						"id": "LanguageSettingsContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "LanguageCaption",
					"parentName": "LanguageSettingsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.LanguageCaption"
						},
						"classes": {
							"labelClass": ["controlCaption"]
						},
						"markerValue": "culture-value"
					}
				},
				{
					"operation": "insert",
					"name": "Culture",
					"parentName": "LanguageSettingsContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "Culture",
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareSysCultureList"
							},
							"list": {
								"bindTo": "SysCultureList"
							},
							"classes": ["combo-box-edit-wrap"]
						},
						"markerValue": "Culture"
					}
				},
				{
					"operation": "insert",
					"parentName": "languageDateTimeZoneContainer",
					"propertyName": "items",
					"name": "DateTimeFormatContainer",
					"values": {
						"id": "DateTimeFormatContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeFormatCaption",
					"parentName": "DateTimeFormatContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.DateTimeFormatCaption"
						},
						"classes": {
							"labelClass": ["controlCaption"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeFormat",
					"parentName": "DateTimeFormatContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "DateTimeFormat",
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareDateTimeFormatList"
							},
							"list": {
								"bindTo": "DateTimeFormatList"
							},
							"classes": ["combo-box-edit-wrap"]
						},
						"markerValue": "DateTimeFormat"
					}
				},
				{
					"operation": "insert",
					"parentName": "languageDateTimeZoneContainer",
					"propertyName": "items",
					"name": "TimeZoneContainer",
					"values": {
						"id": "TimeZoneContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TimeZoneCaption",
					"parentName": "TimeZoneContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": SysAdminUnit.columns.TimeZoneId.caption,
						"classes": {
							"labelClass": ["controlCaption"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "TimeZone",
					"parentName": "TimeZoneContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "TimeZone",
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN,
							"prepareList": {
								"bindTo": "onPrepareTimeZoneList"
							},
							"list": {
								"bindTo": "TimeZoneList"
							},
							"classes": ["combo-box-edit-wrap"],
						},
						"markerValue": "time-zone-value"
					}
				},
				{
					"operation": "remove",
					"name": "leftTopGroupContainer",
					"parentName": "leftContainer",
					"propertyName": "items",
					"values": {
						"id": "leftTopGroupContainer",
						"selectors": {
							wrapEl: "#leftTopGroupContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["profile-module-left-container-bottom-border"],
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "password",
					"parentName": "leftTopGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.ChangePasswordCaption"
						},
						"click": {
							"bindTo": "onPasswordSettingsClick"
						},
						"classes": {
							"textClass": "profile-button"
						},
						"tag": "password"
					}
				},
				{
					"operation": "insert",
					"name": "PopupsStateCheckBoxContainer",
					"parentName": "SysSettingsTabInfoBlock",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["check-box-container", "stateflag-container"],
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "PopupsStateCheckBoxContainer",
					"propertyName": "items",
					"name": "PopupsStateCheckBox",
					"classes": ["t-checkboxedit"],
					"wrapClass": ["t-checkboxedit"],
					"values": {
						"bindTo": "PopupsStateFlag",
						"labelConfig": {
							"caption": Resources.localizableStrings.Popups
						}
					}
				},
				{
					"operation": "insert",
					"name": "ChangePasswordTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 5,
					"values": {
						"caption": Resources.localizableStrings.ChangePasswordCaption,
						"visible": true,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ChangePasswordTab",
					"propertyName": "items",
					"name": "ChangePasswordTabInfoBlock",
					"values": {
						"id": "ChangePasswordTabInfoBlock",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
					}
				},
				{
					"operation": "insert",
					"name": "TextLabel",
					"parentName": "ChangePasswordTabInfoBlock",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": [
								"mainHeader-label", "socilaAccounts-header"
							]
						},
						"caption": Resources.localizableStrings.ChangePasswordCaption
					}
				},
				{
					"operation": "insert",
					"parentName": "ChangePasswordTabInfoBlock",
					"propertyName": "items",
					"name": "ChangePasswordModule",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "ChangePasswordModule",
						"visible": true,
						"items": [],
					}
				},
				{
					"operation": "remove",
					"name": "leftMiddleGroupContainer",
					"parentName": "leftContainer",
					"propertyName": "items",
					"values": {
						"id": "leftMiddleGroupContainer",
						"selectors": {
							wrapEl: "#leftMiddleGroupContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["profile-module-left-container-bottom-border"],
						"visible": {
							"bindTo": "isSyncSettingsVisible"
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "Mailboxes",
					"parentName": "leftMiddleGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.MailboxesCaption"
						},
						"click": {
							"bindTo": "onMailSettingsClick"
						},
						"classes": {
							"textClass": "profile-button"
						}
					}
				},
				{
					"operation": "remove",
					"name": "SocialNetworkAccounts",
					"parentName": "leftMiddleGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.SocialNetworkAccountsCaption"
						},
						"click": {
							"bindTo": "onSocialAccountsClick"
						},
						"classes": {
							"textClass": "profile-button"
						},
						"markerValue": "SocialAccountsButton"
					}
				},
				{
					"operation": "remove",
					"name": "notificationGroupContainer",
					"parentName": "leftContainer",
					"propertyName": "items",
					"values": {
						"id": "notificationGroupContainer",
						"selectors": {
							wrapEl: "#notificationGroupContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["profile-module-left-container-bottom-border"],
						"visible": {
							"bindTo": "isNotificationsSettingsVisible"
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "NotificationButton",
					"parentName": "notificationGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.NotificationsSettingsCaption"
						},
						"click": {
							"bindTo": "onNotificationsSettingsClick"
						},
						"classes": {
							"textClass": "profile-button"
						}
					}
				},
				{
					"operation": "insert",
					"name": "DefaultSettings",
					"parentName": "SysSettingsTabInfoBlock",
					"propertyName": "items",
					"values": {
						"id": "DefaultSettingsButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {
							"bindTo": "Resources.Strings.DefaultSettingsCaption"
						},
						"imageConfig": {"bindTo": "Resources.Images.RevertImage"},
						"iconAlign": BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
						"click": {
							"bindTo": "flushToDefault"
						},
						"classes": {
							"textClass": "profile-button",
							"imageClass": ["t-btn-image t-btn-image-left proc-btn-img-top t-btn-restore-settings"],
						},
						"tag": "default",
						"visible": {
							"bindTo": "isDefaultSettingsButtonVisible"
						}
					}
				}

			] /**SCHEMA_DIFF*/
		};
	}
);