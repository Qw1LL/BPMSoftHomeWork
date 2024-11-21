define("SectionSettingsMixin", ["BPMSoft"], function(BPMSoft) {

	/**
	 * Mixin for section settings.
	 */
	Ext.define("BPMSoft.configuration.mixins.SectionSettingsMixin", {
		alternateClassName: "BPMSoft.SectionSettingsMixin",

		//region Methods: Protected

		/**
		 * Module settings change event suspent.
		 * @protected
		 */
		moduleSettingsChangeEventsSuspend: function() {
			this.set("isModuleSettingsChange", true);
		},

		/**
		 * Module settings change event resume.
		 * @protected
		 */
		moduleSettingsChangeEventsResume: function() {
			this.set("isModuleSettingsChange", false);
		},

		/**
		 * Returns IsModuleSettingsChange suspended flag.
		 * @protected
		 * @return {Boolean} True - if suspended, false - if not suspended.
		 */
		isSettingsChangeEventsSuspended: function() {
			return this.get("isModuleSettingsChange");
		},

		/**
		 * Returns module entity schema.
		 * @protected
		 * @return {BPMSoft.manager.EntitySchema} Module entity schema.
		 */
		getModuleEntitySchema: function() {
			return this.get("ModuleEntitySchema");
		},

		/**
		 * Returns object of messages
		 * @protected
		 * @return {Object}
		 */
		getMessages: function() {
			var messages = {
				"ChangeModuleSettings": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"GetSysModuleSettings": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"GetEntitySchemaInstance": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			};
			const initializedMessageName = this.getInitializedMessageName();
			if (initializedMessageName) {
				messages[initializedMessageName] = {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				};
			}
			return messages;
		},

		/**
		 * Subscribes on messages of the sandbox.
		 * @protected
		 */
		subscribeSandboxEvents: function() {
			this.sandbox.registerMessages(this.getMessages());
			this.sandbox.subscribe("ChangeModuleSettings", this.onChangeModuleSettings, this, [this.sandbox.id]);
		},

		/**
		 * Initialize mixin
		 * @protected
		 */
		init: function() {
			this._requireSysModuleEntitySettingsChain();
		},

		/**
		 * Returns can edit flag.
		 * @protected
		 * @return {Boolean} True - if can, false - if can't.
		 */
		canEdit: function() {
			var item = this.get("SysModuleEntityManagerItem");
			var schema = this.getModuleEntitySchema();
			return !Ext.isEmpty(item) && !Ext.isEmpty(schema);
		},

		/**
		 * Returns active edit page manager items
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		getActiveSysModuleEditManagerItemsChain: function(callback, scope) {
			scope = scope || this;
			var item = this.get("SysModuleEntityManagerItem");
			if (!item) {
				callback.call(scope, new BPMSoft.Collection());
				return;
			}
			item.getSysModuleEditManagerItems(function(items) {
				var activeItems = items.filterByFn(function(item) {
					return !item.isDeleted;
				});
				callback.call(scope, activeItems);
			}, this);
		},

		/**
		 * Clear model.
		 */
		clearModel: function() {
			this.set("SysModuleEntityUId", null);
			this.set("ModuleEntitySchema", null);
			this.set("PackageUId", null);
			this.set("EntitySchemaUId", null);
			this.set("SysModuleEntityManagerItem", null);
			this.set("EntitySchemaManagerItem", null);
		},

		/**
		 * Handler for ChangeModuleSettings message
		 * @protected
		 * @param {Object} settings Settings.
		 * @param {String} settings.sysModuleEntityUId Current sysModuleEntityUId.
		 * @param {String} settings.packageUId Current packageUId.
		 */
		onChangeModuleSettings: function(settings) {
			this.moduleSettingsChangeEventsSuspend();
			this.clearModel();
			this.set("IsInitialized", false);
			this.set("Settings", settings);
			var onInvalidHandler = this._onInvalidChangeModuleSettings.bind(this);
			BPMSoft.chain(
				this._validateSettingsChain,
				function(next, isValid) {
					this._onValidateSettingsChain(next, isValid, onInvalidHandler);
				},
				function(next) {
					this._applySettingsToModelChain(next, onInvalidHandler);
				},
				this._getEntitySchemaInstanceChain,
				this.initModuleSettings,
				function() {
					this.set("IsInitialized", true);
					var initializedMessageName = this.getInitializedMessageName();
					this.sandbox.publish(initializedMessageName, null, [this.sandbox.id]);
					this.moduleSettingsChangeEventsResume();
				}, this
			);
		},

		/**
		 * Init module settings.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initModuleSettings: function(callback, scope) {
			Ext.callback(callback, scope);
		},

		/**
		 * Returns initialized message name.
		 * @abstract
		 * @protected
		 */
		getInitializedMessageName: BPMSoft.abstractFn,

		/**
		 * @inheritdoc BPMSoft.BaseObject#destroy
		 * @overridden
		 */
		destroy: function() {
			const messages = _.keys(this.getMessages());
			this.sandbox.unRegisterMessages(messages);
			this.callParent(arguments);
		},

		//endregion

		//region Methods: Private

		/**
		 * Method validate settings.
		 * @private
		 * @param {Function} next Callback method.
		 */
		_validateSettingsChain: function(next) {
			var settings = this.get("Settings");
			var isValid = true;
			if (!settings || !BPMSoft.isGUID(settings.sysModuleEntityUId)) {
				isValid = false;
			}
			next(isValid);
		},

		/**
		 * Apply valid settings to model.
		 * @private
		 * @param {Function} next Callback method.
		 * @param {Function} onInvalidHandler Invalid settings method.
		 */
		_applySettingsToModelChain: function(next, onInvalidHandler) {
			var settings = this.get("Settings");
			var sectionManagerItemId = settings.sectionManagerItemId;
			var sysModuleEntityUId = settings.sysModuleEntityUId;
			var packageUId = settings.packageUId;
			var sysModuleEntityManagerItem = BPMSoft.SysModuleEntityManager.findItem(sysModuleEntityUId);
			var successApply = false;
			var entitySchemaManagerItem = null;
			if (sysModuleEntityManagerItem) {
				var entitySchemaUId = sysModuleEntityManagerItem.getEntitySchemaUId();
				entitySchemaManagerItem = BPMSoft.EntitySchemaManager.findItem(entitySchemaUId);
				if (entitySchemaManagerItem) {
					this.set("SysModuleEntityUId", sysModuleEntityUId);
					this.set("PackageUId", packageUId);
					this.set("EntitySchemaUId", entitySchemaUId);
					this.set("SysModuleEntityManagerItem", sysModuleEntityManagerItem);
					this.set("EntitySchemaManagerItem", entitySchemaManagerItem);
					if (BPMSoft.SectionManager.contains(sectionManagerItemId)) {
						var item = BPMSoft.SectionManager.getItem(sectionManagerItemId);
						this.set("SectionManagerItem", item);
					}
					successApply = true;
				}
			}
			if (successApply) {
				next(entitySchemaManagerItem);
			} else {
				onInvalidHandler();
			}
		},

		/**
		 * Require module initialize settings.
		 * @private
		 */
		_requireSysModuleEntitySettingsChain: function() {
			var sandboxId = this.sandbox.id;
			this.sandbox.publish("GetSysModuleSettings", sandboxId, [sandboxId]);
		},

		/**
		 * Method preparate validate settings response.
		 * @private
		 * @param {Function} next Callback method.
		 * @param {boolean} isValid True - if valid, False - if not valid.
		 */
		_onValidateSettingsChain: function(next, isValid) {
			if (isValid) {
				next();
			} else {
				this._onInvalidChangeModuleSettings();
			}
		},

		/**
		 * On settings is not valid
		 * @private
		 */
		_onInvalidChangeModuleSettings: function() {
			this.moduleSettingsChangeEventsSuspend();
			this.clearModel();
			this.moduleSettingsChangeEventsResume();
			var initializedMessageName = this.getInitializedMessageName();
			this.sandbox.publish(initializedMessageName, null, [this.sandbox.id]);
		},

		/**
		 * Method return instance of EntitySchemaManagerItem.
		 * @private
		 * @param {Function} next Callback method.
		 */
		_getEntitySchemaInstanceChain: function(next) {
			const entitySchema = this.sandbox.publish("GetEntitySchemaInstance", null, [this.sandbox.id]);
			this.set("ModuleEntitySchema", entitySchema);
			next();
		}

		//endregion

	});
	return Ext.create("BPMSoft.SectionSettingsMixin");
});
