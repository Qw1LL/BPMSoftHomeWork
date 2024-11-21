define("CampaignSchemaManager", ["SysAdminUnit", "MarketingEnums", "CampaignSchemaManagerItem"],
		function(SysAdminUnit, MarketingEnums) {
	/**
	 * @class BPMSoft.manager.CampaignSchemaManager
	 */
	Ext.define("BPMSoft.manager.CampaignSchemaManager", {
		extend: "BPMSoft.BaseProcessSchemaManager",
		alternateClassName: "BPMSoft.CampaignSchemaManager",
		singleton: true,

		/**
		 * @inheritdoc BPMSoft.BaseManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.CampaignSchemaManagerItem",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#managerName
		 * @overridden
		 */
		managerName: "CampaignSchemaManager",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			Ext.apply(this.propertyColumnNames, {
				entityId: "EntityId",
				entitySchemaUId: "EntitySchemaUId"
			});
		},

		// #region Methods: Private

		/**
		 * Sets default time zone for campaign schema.
		 * Uses current user's time zone if it is defined.
		 * Otherwise check sys settings.
		 * If it is not existed sets UTC time zone.
		 * @private
		 * @param {BPMSoft.CampaignSchema} schema Instance of campaign schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback execution context.
		 */
		_setCurrentUserTimeZone: function(schema, callback, scope) {
			var userTimeZoneCode;
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchema: SysAdminUnit});
			esq.addColumn("TimeZoneId", "TimeZoneCode");
			esq.getEntity(BPMSoft.SysValue.CURRENT_USER.value, function(result) {
				if (result.entity) {
					userTimeZoneCode = result.entity.get("TimeZoneCode");
					if (userTimeZoneCode) {
						schema.timeZoneCode = userTimeZoneCode;
						callback.call(scope);
					} else {
						this._setDefaultTimeZone(schema, callback, scope);
					}
				} else {
					this._setDefaultTimeZone(schema, callback, scope);
				}
			}, this);
		},

		/**
		 * Sets default time zone for campaign schema.
		 * Checks if default sys settings time zone is specified uses it.
		 * Otherwise sets UTC time zone.
		 * @private
		 * @param {BPMSoft.CampaignSchema} schema Instance of campaign schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback execution context.
		 */
		_setDefaultTimeZone: function(schema, callback, scope) {
			var utcTimeZoneCode = "UTC";
			var sysSettingsTimeZoneCode;
			var sysSettingsTimeZone = BPMSoft.SysSettings.getCachedSysSetting("DefaultTimeZone");
			if (sysSettingsTimeZone && sysSettingsTimeZone.value) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "TimeZone"
				});
				esq.addColumn("Code", "TimeZoneCode");
				esq.getEntity(sysSettingsTimeZone.value, function(result) {
					if (result.entity) {
						sysSettingsTimeZoneCode = result.entity.get("TimeZoneCode");
					}
					schema.timeZoneCode = sysSettingsTimeZoneCode || utcTimeZoneCode;
					callback.call(scope);
				}, this);
			} else {
				schema.timeZoneCode = utcTimeZoneCode;
				callback.call(scope);
			}
		},

		// #endregion

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#createSchema
		 * @override
		 */
		createSchema: function() {
			var schema = this.callParent(arguments);
			schema.name = "";
			schema.parentSchemaUId = "371c5d61-06ed-4bda-a905-c00ea6d19551";
			schema.isCreatedInSvg = true;
			schema.serializeToDB = true;
			schema.tag = "Campaign";
			return schema;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#createSchemaInstance
		 * @override
		 */
		createSchemaInstance: function(schemaUId, packageUId, callback, scope) {
			var self = this;
			var callbackFn = function(schema) {
				var args = arguments;
				BPMSoft.chain(
					function(next) {
						schema.defaultCampaignFirePeriod =
							MarketingEnums.CampaignFirePeriod.ONE_HOUR.Value;
						this._setCurrentUserTimeZone(schema, next, scope);
					},
					function() {
						Ext.callback(callback, scope, args);
					}, self
				);
			};
			this.callParent([schemaUId, packageUId, callbackFn, scope]);
		}
	});
	return BPMSoft.CampaignSchemaManager;
});
