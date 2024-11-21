define("MappingMenuBuilder", ["MappingMenuBuilderResources", "SysSchemaUIdEnums", "MappingEnums",
		"MappingMenuItemConfigBuilder"], function(resources) {
	Ext.define("BPMSoft.configuration.MappingMenuBuilder", {
		extend: "BPMSoft.ObjectBuilder",
		alternateClassName: "BPMSoft.MappingMenuBuilder",

		//region Properties: private

		/**
		 * True when menu is builded for Process Designer.
		 * @private
		 * @type {Boolean}
		 */
		_isProcessDesigner: null,

		/**
		 * Data value type of mapping invoker.
		 * @private
		 * @type {BPMSoft.DataValueType}
		 */
		_dataValueType: null,

		/**
		 * Date time type of mapping invoker.
		 * @private
		 * @type {Number}
		 */
		_dateTimeValueType: null,

		/**
		 * Reference schema uid of the mapping invoker.
		 * @private
		 * @type {String}
		 */
		_referenceSchemaUId: null,

		/**
		 * Source columns.
		 * @private
		 * @type {BPMSoft.Collection}
		 */
		_sourceColumns: null,
		
		/**
		 * Flag indicates whether main record mapping is enabled.
		 * @private
		 * @type {Object}
		 */
		_mainRecordMappingConfig: null,

		//endregion

		//region Methods: private

		constructor: function(config) {
			this.callParent(arguments);
			this._mainRecordMappingConfig = config._mainRecordMappingConfig || {};
			this._isProcessDesigner = config._isProcessDesigner;
			this._dataValueType = config._dataValueType;
			this._dateTimeValueType = config._dateTimeValueType;
			this._referenceSchemaUId = config._referenceSchemaUId || null;
			this._sourceColumns = config._sourceColumns || null;
		},

		/**
		 * Returns true if parameter item is enabled.
		 * @private
		 * @return {Boolean} Flag of parameter item activity.
		 */
		isParameterItemEnabled: function() {
			return true;
		},

		/**
		 * Returns true if main record column item is enabled.
		 * @private
		 * @return {Boolean} Flag of main record column item activity.
		 */
		isMainRecordColumnsItemEnabled: function() {
			return this._mainRecordMappingConfig.enabled;
		},

		/**
		 * Returns true if boolean item is enabled.
		 * @private
		 * @return {Boolean} Flag of boolean item activity.
		 */
		isBooleanItemEnabled: function() {
			return BPMSoft.isBooleanDataValueType(this._dataValueType);
		},

		/**
		 * Returns true if lookup item is enabled.
		 * @private
		 * @return {Boolean} Flag of lookup item activity.
		 */
		isLookupItemEnabled: function() {
			return BPMSoft.isLookupValidator(this._dataValueType);
		},

		/**
		 * Returns true if sys variable item is enabled.
		 * @private
		 * @return {Boolean} Flag of sys variable item activity.
		 */
		isSysVariableItemEnabled: function() {
			return this.isLookupItemEnabled() && !Ext.isEmpty(this._referenceSchemaUId);
		},

		/**
		 * Returns true if contact variable item is enabled.
		 * @private
		 * @return {Boolean} Flag of contact variable item activity.
		 */
		isContactVariableItemEnabled: function() {
			var sysSchemaEnums = BPMSoft.SysSchemaUIdEnums.SysVariablesSchemaUIds;
			return this._referenceSchemaUId === sysSchemaEnums.CONTACT_SCHEMA_UID;
		},

		/**
		 * Returns true if admin variable item is enabled.
		 * @private
		 * @return {Boolean} Flag of admin variable item activity.
		 */
		isAdminUnitVariableItemEnabled: function() {
			var sysSchemaEnums = BPMSoft.SysSchemaUIdEnums.SysVariablesSchemaUIds;
			return Ext.Array.contains([
				sysSchemaEnums.ADMIN_UNIT_SCHEMA_UID,
				sysSchemaEnums.USER_SCHEMA_UID
			], this._referenceSchemaUId);
		},

		/**
		 * Returns true if account variable item is enabled.
		 * @private
		 * @return {Boolean} Flag of account variable item activity.
		 */
		isAccountVariableItemEnabled: function() {
			var sysSchemaEnums = BPMSoft.SysSchemaUIdEnums.SysVariablesSchemaUIds;
			return this._referenceSchemaUId === sysSchemaEnums.ACCOUNT_SCHEMA_UID;
		},

		/**
		 * Returns true if date time variable item is enabled.
		 * @private
		 * @return {Boolean} Flag of date time variable item activity.
		 */
		isDateTimeItemEnabled: function() {
			return BPMSoft.isDateDataValueType(this._dataValueType);
		},

		/**
		 * Returns true if date sub item is enabled.
		 * @private
		 * @return {Boolean} Flag of date sub item activity.
		 */
		isDateSubItemEnabled: function() {
			return BPMSoft.isValidForMappingOnDateDataValueType(this._dateTimeValueType);
		},

		/**
		 * Returns true if time sub item is enabled.
		 * @private
		 * @return {Boolean} Flag of time sub item activity.
		 */
		isTimeSubItemEnabled: function() {
			return BPMSoft.isValidForMappingOnTimeDataValueType(this._dateTimeValueType);
		},

		/**
		 * Returns true if sys settings item is enabled.
		 * @private
		 * @return {Boolean} Flag of sys settings item activity.
		 */
		isSysSettingsItemEnabled: function() {
			var result = BPMSoft.isLookupDataValueType(this._dataValueType);
			result = result || BPMSoft.isDateDataValueType(this._dataValueType);
			result = result || BPMSoft.isTextDataValueType(this._dataValueType);
			result = result || BPMSoft.isBooleanDataValueType(this._dataValueType);
			result = result || BPMSoft.isNumberDataValueType(this._dataValueType);
			return result;
		},

		/**
		 * Return true if source columns item is enabled.
		 * @private
		 * @return {boolean} Flag of source columns item is enabled.
		 */
		isSourceColumnsEnabled: function() {
			return this._sourceColumns !== null;
		},

		/**
		 * Builds boolean menu item with sub menus.
		 * @private
		 */
		buildBooleanItem: function() {
			this.start(this.isBooleanItemEnabled()).collection(this.getBooleanMenuItem());
			this.lazyAdd(this.getTrueBooleanSubmenuItem, this);
			this.lazyAdd(this.getFalseBooleanSubmenuItem, this);
			this.end();
		},

		/**
		 * Builds sys variable menu item.
		 * @private
		 */
		buildSysVariableItem: function() {
			if (!this.isSysVariableItemEnabled()) {
				return;
			}
			this.start(this.isContactVariableItemEnabled()).lazyAdd(this.getContactSysVariableMenuItem, this);
			this.start(this.isAdminUnitVariableItemEnabled()).lazyAdd(this.getAdminUnitSysVariableMenuItem, this);
			this.start(this.isAccountVariableItemEnabled()).lazyAdd(this.getAccountUnitSysVariableMenuItem, this);
		},

		/**
		 * Builds date time menu item with sub menus.
		 * @private
		 */
		buildDateTimeItem: function() {
			var isDateSubItemEnabled = this.isDateSubItemEnabled();
			var isTimeSubItemEnabled = this.isTimeSubItemEnabled();
			this.start(this.isDateTimeItemEnabled()).collection(this.getDateTimeMenuItem());
			this.start(isDateSubItemEnabled).lazyAdd(this.getDateSubmenuItem, this);
			this.start(isTimeSubItemEnabled).lazyAdd(this.getTimeSubmenuItem, this);
			this.lazyAdd(this.getDateTimeSubmenuItem, this);
			this.start(isDateSubItemEnabled).lazyAdd(this.getCurrentDateSubmenuItem, this);
			this.start(isTimeSubItemEnabled).lazyAdd(this.getCurrentTimeSubmenuItem, this);
			this.lazyAdd(this.getCurrentDateTimeSubmenuItem, this);
			this.end();
		},

		/**
		 * Builds source column menu item with sub menus.
		 * @private
		 */
		buildSourceColumnItem: function() {
			if (!this.isSourceColumnsEnabled()) {
				return;
			}
			this.start().collection(this.getSourceColumnMenuItem());
			this.buildSourceColumnSubItems();
			this.end();
		},

		/**
		 * Builds source column menu sub items.
		 * @private
		 */
		buildSourceColumnSubItems: function() {
			this._sourceColumns.each(function(column) {
				var caption = column.caption;
				var tag = column.id;
				var markerValue = "SourceColumn-" + column.caption;
				this.add(this.getSourceColumnMenuSubItem(caption, tag, markerValue));
			}, this);
		},

		/**
		 * Adds node to builder if ignore condition is not null, otherwise dont call config function.
		 * @private
		 * @param {Function} configFn Get config function.
		 */
		lazyAdd: function(configFn, scope) {
			if (this.condition) {
				return;
			}
			var config = configFn.call(scope);
			return this.add(config);
		},

		/**
		 * Returns parameters menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} customTag Tag info.
		 * @return {BPMSoft.BaseViewModel} Parameters menu item.
		 */
		getParametersMenuItem: function(onClick, customTag) {
			onClick = onClick || this.getBaseMenuItemOnClickBind();
			var tag = {
				mappingType: this.getParametersMenuItemMappingType()
			};
			Ext.apply(tag, customTag);
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(this.getParametersMenuItemCaption());
			config.addTag(tag);
			config.addIcon(this.getProcessParameterIcon());
			config.addOnClick(onClick);
			return this.getMenuItem(config);
		},

		/**
		 * Returns parameters menu item caption.
		 * @private
		 * @returns {String} Menu item caption.
		 */
		getParametersMenuItemCaption: function() {
			var strings = resources.localizableStrings;
			return this._isProcessDesigner
				? strings.ProcessParametersItemCaption
				: strings.DcmParametersItemCaption;
		},

		/**
		 * Returns paramters menu item mapping type.
		 * @private
		 * @returns {BPMSoft.MappingEnums.MappingType} Menu item mapping type.
		 */
		getParametersMenuItemMappingType: function() {
			return this._isProcessDesigner
				? BPMSoft.MappingEnums.MappingUnion.PROCESS_AND_ELEMENT_PARAMETERS
				: BPMSoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS;
		},

		/**
		 * Returns main record columns menu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Main record columns menu item.
		 */
		getMainRecordColumnsMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.RecordColumnsDisplayValueCaption);
			config.addOnClick("openMacrosPage");
			if (!this._mainRecordMappingConfig.hideIcon) {
				config.addIcon(this.getNoTypeIcon());
			}
			return this.getMenuItem(config);
		},

		/**
		 * Returns boolean menu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Boolean menu item.
		 */
		getBooleanMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.BooleanItemCaption);
			config.addIcon(this.getBooleanIcon());
			return this.getMenuItem(config);
		},

		/**
		 * Returns true boolean submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} True boolean submenu item.
		 */
		getTrueBooleanSubmenuItem: function() {
			var constants = BPMSoft.process.constants;
			var caption = resources.localizableStrings.TrueBooleanSubItemCaption;
			var displayValue = resources.localizableStrings.TrueBooleanDisplayValueCaption;
			return this.getBaseBooleanSubmenuItem(caption, constants.BOOLEAN_MACROS_TRUE_VALUE, displayValue);
		},

		/**
		 * Returns false boolean submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} False boolean submenu item.
		 */
		getFalseBooleanSubmenuItem: function() {
			var constants = BPMSoft.process.constants;
			var caption = resources.localizableStrings.FalseBooleanSubItemCaption;
			var displayValue = resources.localizableStrings.FalseBooleanDisplayValueCaption;
			return this.getBaseBooleanSubmenuItem(caption, constants.BOOLEAN_MACROS_FALSE_VALUE, displayValue);
		},

		/**
		 * Returns false boolean submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} False boolean submenu item.
		 */
		getBaseBooleanSubmenuItem: function(caption, value, displayValue) {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			var valueMacros = BPMSoft.FormulaMacros.prepareBooleanValue(value);
			var tag = {
				value: valueMacros.toString(),
				displayValue: displayValue
			};
			config.addCaption(caption);
			config.addTag(tag);
			config.addOnClick(this.getBaseSubMenuItemOnClickBind());
			return this.getMenuItem(config);
		},

		/**
		 * Returns lookup menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} customTag Tag info.
		 * @return {BPMSoft.BaseViewModel} Lookup menu item.
		 */
		getLookupMenuItem: function(onClick, customTag) {
			onClick = onClick || this.getBaseMenuItemOnClickBind();
			var tag = {
				mappingType: BPMSoft.MappingEnums.MappingType.LOOKUP
			};
			Ext.apply(tag, customTag);
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.LookupItemCaption);
			config.addTag(tag);
			config.addIcon(this.getLookupIcon());
			config.addOnClick(onClick);
			return this.getMenuItem(config);
		},

		/**
		 * Returns base sys variable menu item.
		 * @private
		 * @param {Object} baseConfig Base sys variable menu item config.
		 * @param {String} baseConfig.caption Item caption.
		 * @param {String} baseConfig.value Item value.
		 * @param {String} baseConfig.displayValue Item display value.
		 * @param {Object} baseConfig.icon Icon of sys variable item.
		 * @param {String=} baseConfig.onClick On click method.
		 * @param {Object=} baseConfig.customTag Custom tag object.
		 * @return {BPMSoft.BaseViewModel} Base sys variable item.
		 */
		getBaseSysVariableMenuItem: function(baseConfig) {
			var onClick = baseConfig.onClick || this.getBaseMacrosMenuItemOnClickBind();
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			var valueMacros = BPMSoft.FormulaMacros.prepareSysVariableValue(baseConfig.value);
			var displayValueMacros = BPMSoft.FormulaMacros.prepareSysVariableDisplayValue(baseConfig.displayValue);
			var tag = {
				value: valueMacros.getBody(),
				displayValue: displayValueMacros.toString()
			};
			Ext.apply(tag, baseConfig.customTag);
			config.addCaption(baseConfig.caption);
			config.addTag(tag);
			config.addIcon(baseConfig.icon);
			config.addOnClick(onClick);
			return this.getMenuItem(config);
		},

		/**
		 * Returns contact sys variable menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} tag Tag info.
		 * @return {BPMSoft.BaseViewModel} Contact sys variable menu item.
		 */
		getContactSysVariableMenuItem: function(onClick, tag) {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			return this.getBaseSysVariableMenuItem({
				caption: resources.localizableStrings.CurrentUserContactCaption,
				value: BPMSoft.SystemValueType.CURRENT_USER_CONTACT,
				displayValue: sysVariableDisplayValues.CurrentUserContact,
				icon: resources.localizableImages.ContactIcon,
				onClick: onClick,
				customTag: tag
			});
		},

		/**
		 * Returns admin unit sys variable menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @return {BPMSoft.BaseViewModel} Admin unit sys variable menu item.
		 */
		getAdminUnitSysVariableMenuItem: function(onClick) {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			return this.getBaseSysVariableMenuItem({
				caption: resources.localizableStrings.CurrentUserCaption,
				value: BPMSoft.SystemValueType.CURRENT_USER,
				displayValue: sysVariableDisplayValues.CurrentUser,
				icon: resources.localizableImages.ContactIcon,
				onClick: onClick
			});
		},

		/**
		 * Returns account sys variable menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} tag Tag info.
		 * @return {BPMSoft.BaseViewModel} Account sys variable menu item.
		 */
		getAccountUnitSysVariableMenuItem: function(onClick, tag) {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			return this.getBaseSysVariableMenuItem({
				caption: resources.localizableStrings.CurrentUserAccountCaption,
				value: BPMSoft.SystemValueType.CURRENT_USER_ACCOUNT,
				displayValue: sysVariableDisplayValues.CurrentUserAccount,
				icon: resources.localizableImages.AccountIcon,
				onClick: onClick,
				customTag: tag
			});
		},

		/**
		 * Returns system setting menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} customTag Tag info.
		 * @return {BPMSoft.BaseViewModel} System setting menu item.
		 */
		getSysSettingsMenuItem: function(onClick, customTag) {
			onClick = onClick || this.getBaseMenuItemOnClickBind();
			var tag = {
				mappingType: BPMSoft.MappingEnums.MappingType.SYSTEM_SETTINGS
			};
			Ext.apply(tag, customTag);
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.SystemSettingsCaption);
			config.addTag(tag);
			config.addIcon(this.getSystemSettingsIcon());
			config.addOnClick(onClick);
			return this.getMenuItem(config);
		},

		/**
		 * Returns date time submenu items on click bind.
		 * @private
		 * @return {String} On click bind.
		 */
		getDateTimeSubmenuItemsOnClickBind: function() {
			return "onDateTimeSubItemClick";
		},

		/**
		 * Returns date time menu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Date time menu item.
		 */
		getDateTimeMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.DateTimeItemCaption);
			config.addTag(BPMSoft.MappingEnums.MappingType.DATE_TIME);
			config.addIcon(this.getDateTimeIcon());
			return this.getMenuItem(config);
		},

		/**
		 * Returns date submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Date submenu item.
		 */
		getDateSubmenuItem: function() {
			var caption = resources.localizableStrings.SelectionDateCaption;
			var dataValueType = BPMSoft.DataValueType.DATE;
			return this.getBaseDateTimeSubmenuItem(caption, dataValueType);
		},

		/**
		 * Returns time submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Time submenu item.
		 */
		getTimeSubmenuItem: function() {
			var caption = resources.localizableStrings.SelectionTimeCaption;
			var dataValueType = BPMSoft.DataValueType.TIME;
			return this.getBaseDateTimeSubmenuItem(caption, dataValueType);
		},

		/**
		 * Returns date time submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Date time submenu item.
		 */
		getDateTimeSubmenuItem: function() {
			var caption = resources.localizableStrings.SelectionDateAndTimeCaption;
			var dataValueType = BPMSoft.DataValueType.DATE_TIME;
			return this.getBaseDateTimeSubmenuItem(caption, dataValueType);
		},

		/**
		 * Returns base date time submenu item.
		 * @param {String} caption item caption.
		 * @param {BPMSoft.DataValueType} dataValueType Item data value type.
		 * @return {BPMSoft.BaseViewModel} Base date time submenu item.
		 */
		getBaseDateTimeSubmenuItem: function(caption, dataValueType) {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(caption);
			config.addTag(dataValueType);
			config.addOnClick(this.getDateTimeSubmenuItemsOnClickBind());
			return this.getMenuItem(config);
		},

		/**
		 * Returns current date submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Current date submenu item.
		 */
		getCurrentDateSubmenuItem: function() {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			var caption = resources.localizableStrings.CurrentDateSubMenuItemCaption;
			var value = BPMSoft.SystemValueType.CURRENT_DATE;
			var displayValue = sysVariableDisplayValues.CurrentDate;
			return this.getBaseCurrentDateTimeSubmenuItem(caption, value, displayValue);
		},

		/**
		 * Returns current time submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Current time submenu item.
		 */
		getCurrentTimeSubmenuItem: function() {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			var caption = resources.localizableStrings.CurrentTimeSubMenuItemCaption;
			var value = BPMSoft.SystemValueType.CURRENT_TIME;
			var displayValue = sysVariableDisplayValues.CurrentTime;
			return this.getBaseCurrentDateTimeSubmenuItem(caption, value, displayValue);
		},

		/**
		 * Returns current date time submenu item.
		 * @private
		 * @return {BPMSoft.BaseViewModel} Current date time submenu item.
		 */
		getCurrentDateTimeSubmenuItem: function() {
			var sysVariableDisplayValues = BPMSoft.Resources.SystemValueCaptions;
			var caption = resources.localizableStrings.CurrentTimeAndDateSubMenuItemCaption;
			var value = BPMSoft.SystemValueType.CURRENT_DATE_TIME;
			var displayValue = sysVariableDisplayValues.CurrentDateTime;
			return this.getBaseCurrentDateTimeSubmenuItem(caption, value, displayValue);
		},

		/**
		 * Returns base date time submenu item.
		 * @param {String} caption item caption.
		 * @param {String} value Item value.
		 * @param {String} displayValue Item display value.
		 * @return {BPMSoft.BaseViewModel} Base current date time submenu item.
		 */
		getBaseCurrentDateTimeSubmenuItem: function(caption, value, displayValue) {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			var valueMacros = BPMSoft.FormulaMacros.prepareSysVariableValue(value);
			var displayValueMacros = BPMSoft.FormulaMacros.prepareSysVariableDisplayValue(displayValue);
			var tag = {
				value: valueMacros.getBody(),
				displayValue: displayValueMacros.toString()
			};
			config.addCaption(caption);
			config.addTag(tag);
			config.addOnClick(this.getBaseMacrosMenuItemOnClickBind());
			return this.getMenuItem(config);
		},

		/**
		 * Returns formula menu item.
		 * @private
		 * @param {String=} onClick On click method.
		 * @param {Object=} customTag Tag info.
		 * @return {BPMSoft.BaseViewModel} Formula menu item.
		 */
		getFormulaMenuItem: function(onClick, customTag) {
			onClick = onClick || this.getBaseMenuItemOnClickBind();
			var tag = {
				mappingType: BPMSoft.MappingEnums.MappingType.ALL
			};
			Ext.apply(tag, customTag);
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.FormulaItemCaption);
			config.addTag(tag);
			config.addMarkerValue("FormulaMenuItem");
			config.addIcon(this.getFormulaIcon());
			config.addOnClick(onClick);
			return this.getMenuItem(config);
		},

		/**
		 * Returns source column menu item.
		 * @return {BPMSoft.BaseViewModel} Source column item view module.
		 */
		getSourceColumnMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.SourceColumnMenuCaption);
			config.addTag(this._dataValueType);
			config.addIcon(this.getNoTypeIcon());
			config.addMarkerValue("setSourceColumn");
			return this.getMenuItem(config);
		},

		/**
		 * Returns source columns menu sub items.
		 * @param {String} caption Sub item caption.
		 * @param {Object} tag Sub item tag.
		 * @param {String} markerValue Sub item marker value.
		 * @return {BPMSoft.BaseViewModel} Source column item view module.
		 */
		getSourceColumnMenuSubItem: function(caption, tag, markerValue) {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(caption);
			config.addTag(tag);
			config.addOnClick("onSourceColumnMenuItemClick");
			config.addMarkerValue(markerValue);
			return this.getMenuItem(config);
		},

		/**
		 * Returns menu item view model.
		 * @private
		 * @param {BPMSoft.MappingMenuItemConfigBuilder} configBuilder Config builder.
		 * @return {BPMSoft.BaseViewModel} Item view model.
		 */
		getMenuItem: function(configBuilder) {
			var config = configBuilder.getResult();
			return this.getMenuItemViewModel(config);
		},

		/**
		 * Returns menu item view model.
		 * @private
		 * @param {Object} config Menu item view model config.
		 * @return {BPMSoft.BaseViewModel} View model.
		 */
		getMenuItemViewModel: function(config) {
			var viewModelId = {Id: BPMSoft.generateGUID()};
			var viewModelValues = Ext.apply({}, config, viewModelId);
			return Ext.create("BPMSoft.BaseViewModel", {
				values: viewModelValues
			});
		},

		/**
		 * Returns base menu item on click bind.
		 * @private
		 * @return {string} Base menu item on click bind.
		 */
		getBaseMenuItemOnClickBind: function() {
			return "onMenuItemClick";
		},

		/**
		 * Returns base macros menu item on click bind.
		 * @private
		 * @return {String} On click bind.
		 */
		getBaseMacrosMenuItemOnClickBind: function() {
			return "onMacrosMenuItemClick";
		},

		/**
		 * Returns base sub menu item on click bind.
		 * @private
		 * @return {string} Base sub menu item on click bind.
		 */
		getBaseSubMenuItemOnClickBind: function() {
			return "onBaseSubMenuItemClick";
		},

		/**
		 * Returns process paramter icon.
		 * @private
		 * @return {Object} Process paramter icon.
		 */
		getProcessParameterIcon: function() {
			return resources.localizableImages.ProcessParameterIcon;
		},

		/**
		 * Returns boolean icon.
		 * @private
		 * @return {Object} Boolean icon.
		 */
		getBooleanIcon: function() {
			return resources.localizableImages.BooleanIcon;
		},

		/**
		 * Returns lookup icon.
		 * @return {Object} Lookup icon.
		 */
		getLookupIcon: function() {
			return resources.localizableImages.LookupIcon;
		},

		/**
		 * Returns system settings icon.
		 * @private
		 * @return {Object} Date time icon.
		 */
		getSystemSettingsIcon: function() {
			return resources.localizableImages.SystemSettingIcon;
		},

		/**
		 * Returns date time icon.
		 * @private
		 * @return {Object} Date time icon.
		 */
		getDateTimeIcon: function() {
			return resources.localizableImages.DateAndTimeIcon;
		},

		/**
		 * Returns no type icon.
		 * @private
		 * @return {Object} No type icon.
		 */
		getNoTypeIcon: function() {
			return resources.localizableImages.NoTypeIcon;
		},

		/**
		 * Returns formula icon.
		 * @private
		 * @return {Object} Formual icon;
		 */
		getFormulaIcon: function() {
			return resources.localizableImages.FormulaIcon;
		},

		/**
		 * Adds result to collection.
		 * @private
		 * @param {Object} token Current token.
		 */
		createResultCollection: function(token) {
			var newCollection = Ext.create("BPMSoft.BaseViewModelCollection");
			this.result = newCollection;
			token.value = newCollection;
			this.enterContext(token);
		},

		/**
		 * Adds node to collection.
		 * @private
		 * @param {Object} token Current token.
		 * @param {Object} context Current context.
		 */
		addNodeToCollection: function(token, context) {
			var node = token.args[0];
			var collection = context.value;
			token.value = node;
			collection.addItem(node);
		},

		/**
		 * Adds collection to new node.
		 * @private
		 * @param {Object} token Current token.
		 * @param {Object} context Current context.
		 */
		addCollection: function(token, context) {
			var newCollection = Ext.create("BPMSoft.BaseViewModelCollection");
			var newNode = token.args[0];
			newNode.set("Items", newCollection);
			var contextCollection = context.value;
			contextCollection.addItem(newNode);
			token.value = newCollection;
			this.enterContext(token);
		},

		/**
		 * Created base view model token.
		 * @private
		 */
		createBaseViewModelCollection: function() {
			this.addToken("collection", arguments);
			return this;
		},

		/**
		 * Builds mapping menu collection.
		 * @return {BPMSoft.BaseViewModelCollection} Menu items collection.
		 * @private
		 */
		buildDefaultMenu: function() {
			this.start().collection();
			this.start(this.isMainRecordColumnsItemEnabled()).lazyAdd(this.getMainRecordColumnsMenuItem, this);
			this.start(this.isParameterItemEnabled()).lazyAdd(this.getParametersMenuItem, this);
			this.buildBooleanItem();
			this.start(this.isLookupItemEnabled()).lazyAdd(this.getLookupMenuItem, this);
			this.buildSysVariableItem();
			this.buildDateTimeItem();
			this.start(this.isSysSettingsItemEnabled()).lazyAdd(this.getSysSettingsMenuItem, this);
			this.lazyAdd(this.getFormulaMenuItem, this);
			this.buildSourceColumnItem();
			this.end();
			return this.getResult();
		},

		/**
		 * Builds mapping menu for recipients parameters.
		 * @private
		 * @return {BPMSoft.BaseViewModelCollection} Menu items collection.
		 */
		buildEmailRecipientItemsMenu: function() {
			this.start().collection();
			this.start(this.isMainRecordColumnsItemEnabled()).lazyAdd(this.getMainRecordColumnsMenuItem, this);
			this.buildContactMenu();
			this.buildAccountMenu();
			this.buildEmailAddressMenu();
			this.end();
			return this.getResult();
		},

		/**
		 * Builds mapping menu for source column parameters.
		 * @private
		 * @return {BPMSoft.BaseViewModelCollection} Menu items collection.
		 */
		buildSourceColumnMenu: function() {
			this.start().collection();
			this.buildSourceColumnItem();
			this.end();
			return this.getResult();
		},

		/**
		 * Returns contant menu items.
		 * @private
		 * @returns {BPMSoft.BaseViewModel} Contant menu items.
		 */
		getContactMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.ContactMenuItemCaption);
			config.addAvailability("getIsContactEnabled");
			return this.getMenuItem(config);
		},

		/**
		 * Returns account menu items.
		 * @private
		 * @returns {BPMSoft.BaseViewModel} Contant menu items.
		 */
		getAccountMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.AccountMenuItemCaption);
			config.addAvailability("getIsAccountEnabled");
			return this.getMenuItem(config);
		},

		/**
		 * Returns email adress menu items.
		 * @private
		 * @returns {BPMSoft.BaseViewModel} Contant menu items.
		 */
		getEmailAddressMenuItem: function() {
			var config = Ext.create("BPMSoft.MappingMenuItemConfigBuilder");
			config.addCaption(resources.localizableStrings.EmailAddressMenuItemCaption);
			config.addAvailability("getIsEmailEnabled");
			return this.getMenuItem(config);
		},

		/**
		 * Builds recipient`s contact menu.
		 * @private
		 */
		buildContactMenu: function() {
			var baseContactOnClick = "onRecipientMenuItemClick";
			var tagConfig = { invokerItemType: "Contact" };
			this.start().collection(this.getContactMenuItem());
			this.add(this.getParametersMenuItem(baseContactOnClick, tagConfig));
			this.add(this.getLookupMenuItem(baseContactOnClick, tagConfig));
			this.add(this.getContactSysVariableMenuItem("onRecipientMacrosItemClick", tagConfig));
			this.add(this.getSysSettingsMenuItem(baseContactOnClick, tagConfig));
			this.add(this.getFormulaMenuItem("onRecipientFormulaItemClick", tagConfig));
			this.end();
		},

		/**
		 * Builds recipient`s account menu.
		 * @private
		 */
		buildAccountMenu: function() {
			var baseAccountOnClick = "onRecipientMenuItemClick";
			var tagConfig = { invokerItemType: "Account" };
			this.start().collection(this.getAccountMenuItem());
			this.add(this.getParametersMenuItem(baseAccountOnClick, tagConfig));
			this.add(this.getLookupMenuItem(baseAccountOnClick, tagConfig));
			this.add(this.getAccountUnitSysVariableMenuItem("onRecipientMacrosItemClick", tagConfig));
			this.add(this.getSysSettingsMenuItem(baseAccountOnClick, tagConfig));
			this.add(this.getFormulaMenuItem("onRecipientFormulaItemClick", tagConfig));
			this.end();
		},

		/**
		 * Builds recipient`s email address menu.
		 * @private
		 */
		buildEmailAddressMenu: function() {
			var baseEmailOnClick = "onRecipientMenuItemClick";
			var tagConfig = { invokerItemType: "Email" };
			this.start().collection(this.getEmailAddressMenuItem());
			this.add(this.getParametersMenuItem(baseEmailOnClick, tagConfig));
			this.add(this.getSysSettingsMenuItem(baseEmailOnClick, tagConfig));
			this.add(this.getFormulaMenuItem("onRecipientFormulaItemClick", tagConfig));
			this.end();
		},

		//endregion

		//region Methods: protected

		/**
		 * @inheritdoc BPMSoft.ObjectBuilder#getStartChainCallConfig
		 * @overridden
		 */
		getStartChainCallConfig: function() {
			return {
				collection: this.createBaseViewModelCollection,
				add: this.add,
				end: this.end,
				lazyAdd: this.lazyAdd
			};
		},

		/**
		 * @inheritdoc BPMSoft.ObjectBuilder#initTypes
		 * @overridden
		 */
		initTypes: function() {
			this.registerTokenType("end");
			this.registerTokenType("node");
			this.registerTokenType("collection");
			this.registerContextType("collection");
		},

		/**
		 * @inheritdoc BPMSoft.ObjectBuilder#initHandlers
		 * @overridden
		 */
		initHandlers: function() {
			this.registerHandler(this.throwError, 0);
			this.registerHandler(this.createResultCollection, 1);
			this.registerHandler(this.addNodeToCollection, 2);
			this.registerHandler(this.addCollection, 3);
			this.registerHandler(this.exitContext, 4);
		},

		/**
		 * @inheritdoc BPMSoft.ObjectBuilder#initProcessingRules
		 * @overridden
		 */
		initRules: function() {
			var initialState = this.getStartSymbol();
			this.registerRule("collection", initialState, 1);
			this.registerRule("node", "collection", 2);
			this.registerRule("collection", "collection", 3);
			this.registerRule("end", "collection", 4);
			this.registerRule("end", initialState, 4);
		},

		//endregion

		//region Methods: public

		/**
		 * Builds mapping menu.
		 * @param {BPMSoft.process.constants.TypeMappingMenu} typeMappingMenu Type mapping menu.
		 * @return {BPMSoft.BaseViewModelCollection} Menu items collection.
		 */
		buildMenu: function(typeMappingMenu) {
			var resultItems;
			if (typeMappingMenu === BPMSoft.process.constants.TypeMappingMenu.EmailRecipientType
				|| typeMappingMenu === "EmailRecipientItem") {
				resultItems = this.buildEmailRecipientItemsMenu();
			} else if (typeMappingMenu === "SourceColumnItem") {
				resultItems = this.buildSourceColumnMenu();				
			} else {
				resultItems = this.buildDefaultMenu();
			}
			return resultItems;
		}

		//endregion

	});
	return BPMSoft.MappingMenuBuilder;
});
