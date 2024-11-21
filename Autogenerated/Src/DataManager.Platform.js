define("DataManager", ["ext-base", "BPMSoft", "sandbox"],
		function() {

	var DataManager = Ext.define("BPMSoft.configuration.DataManager", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.DataManager",

		/**
		 * #### ########## ######### ######
		 * @private
		 * {String}
		 */
		storageKey: "DataManager",

		/**
		 * ######### ######### ######
		 * @private
		 * {BPMSoft.MemoryStore}
		 */
		storage: BPMSoft.DomainCache,

		/**
		 * ###### #########
		 * @private
		 * {BPMSoft.Collection}
		 */
		data: null,

		getEntitySchemaData: function(entitySchemaName) {
			var entitySchemaData = this.data.find(entitySchemaName);
			if (!entitySchemaData) {
				entitySchemaData = new BPMSoft.Collection();
				this.data.add(entitySchemaName, entitySchemaData);
			}
			return entitySchemaData;
		},

		getEntitySchemaColumnInfo: function(entitySchemaName, callback, scope) {
			this.getEntitySchemaInfo(entitySchemaName, function(schema) {
				callback.call(scope, schema.columns);
			}, this);
		},

		getEntitySchemaInfo: function(entitySchemaName, callback, scope) {
			var entitySchema = BPMSoft[entitySchemaName];
			if (entitySchema) {
				callback.call(scope, entitySchema);
			} else {
				BPMSoft.require([entitySchemaName], function(schema) {
					callback.call(scope, schema);
				}, this);
			}
		},

		/**
		 * ####### ######### #######
		 * @param {Object} config ################ ######
		 */
		constructor: function(config) {
			this.callParent(config);
			this.loadDataFromStorage();
			DM = this;
		},

		/**
		 * ######### ###### # ########## #########
		 * @private
		 */
		loadDataFromStorage: function() {
			this.data = this.storage.getItem(this.storageKey) || new BPMSoft.Collection();
		},

		/**
		 * ######### ###### # ######### #########
		 * @private
		 */
		saveDataToStorage: function() {
			this.data = this.storage.setItem(this.storageKey, this.data);
		},

		getEntity: function(entitySchemaName, primaryColumnValue, callback, scope) {
			var entitySchemaData = this.getEntitySchemaData(entitySchemaName);
			var entity = entitySchemaData.find(primaryColumnValue);
			if (entity) {
				callback.call(scope, entity);
			} else {
				this.getEntitySchemaColumnInfo(entitySchemaName, function(entitySchemaColumnInfo) {
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: entitySchemaName
					});
					BPMSoft.each(entitySchemaColumnInfo, function(column, columnName) {
						select.addColumn(columnName);
					});
					var primaryDisplayColumnName = BPMSoft[entitySchemaName].primaryColumnName;
					select.filters.add("primaryColumnValue", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, primaryDisplayColumnName, primaryColumnValue));
					select.getEntityCollection(function(responce) {
						var responceArray = [];
						responce.collection.each(function(item) {
							entitySchemaData.add(item.values.get(primaryDisplayColumnName), item.values);
						});
						callback(schemaData);
					});
				}, this);
			}
		}

	});

	return Ext.create(DataManager);

});
