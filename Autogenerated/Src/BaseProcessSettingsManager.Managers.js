define("BaseProcessSettingsManager", ["BaseProcessSettingsManagerItem"], function() {
	Ext.define("BPMSoft.BaseProcessSettingsManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.BaseProcessSettingsManager",

		/**
		 * Prepares uId to valid caption string.
		 * @private
		 * @param {String} uId UId.
		 * @returns {String} Valid uId caption.
		 */
		_prepareUIdToCaption: function(uId) {
			return uId.replace(/-/g, "");
		},

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnNames
		 * @overridden
		 */
		propertyColumnNames: {
			processCaption: "ProcessName",
			position: "Position",
			processUId: "SysSchemaUId",
			parameterUId: "ParameterUId"
		},

		/**
		 * @inheritdoc BPMSoft.ObjectManager#propertyColumnConfig
		 * @overridden
		 */
		propertyColumnConfig: {
			processCaption: {
				columnDataValueType: BPMSoft.DataValueType.TEXT,
				columnPath: "[VwProcessLib:VersionParentUId:SysSchemaUId].Caption"
			}
		},

		/**
		 * Returns schema data name for autog generated data.
		 * @protected
		 * @abstract
		 */
		getSchemaDataName: BPMSoft.abstractFn,

		/**
		 * Additional column names.
		 * @protected
		 * @virtual
		 * @type {Object} additionalColumnNames
		 */
		additionalColumnNames: null,

		/**
		 * @inheritdoc BPMSoft.ObjectManager#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.propertyColumnNames = Ext.apply(this.propertyColumnNames, this.additionalColumnNames);
		},

		/**
		 * @inheritdoc BPMSoft.ObjectManager#createItem
		 * @overridden
		 */
		createItem: function(config, callback, scope) {
			this.callParent([config, function(item) {
				item.setPosition(config.position);
				item.setProcessUId(config.processUId);
				item.setParameterUId(config.parameterUId);
				callback.call(scope, item);
			}, this]);
		},

		/**
		 * Returns all existing items.
		 * @returns {BPMSoft.Collection} Not deleted manager items.
		 */
		getActiveItems: function() {
			var items = this.getItems();
			return items.filterByFn(function(item) {
				return !item.isDeleted;
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.ObjectManager#updatePackageSchemaData
		 * @overridden
		 */
		updatePackageSchemaData: function(packageUId, items, callback, scope) {
			var managerItems = this.getItems();
			var itemsIds = managerItems.getKeys();
			var baseDataName = this.getSchemaDataName();
			var dataName = Ext.String.format("{0}_{1}", baseDataName, this._prepareUIdToCaption(packageUId));
			var config = {
				entitySchemaName: this.entitySchemaName,
				recordList: itemsIds,
				packageUId: packageUId,
				packageSchemaDataName: dataName
			};
			var request = Ext.create("BPMSoft.UpdatePackageSchemaDataRequest", config);
			request.execute(function(response) {
				if (response && response.success) {
					callback.call(scope);
				} else {
					throw new BPMSoft.InvalidOperationException({
						message: response.errorInfo.toString()
					});
				}
			}, this);
		}
	});
	return BPMSoft.BaseProcessSettingsManager;
});
