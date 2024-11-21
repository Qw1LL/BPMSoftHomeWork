define("EntityHelper", function() {
	var entityHelperClass = Ext.define("BPMSoft.configuration.mixins.EntityHelper", {

		alternateClassName: "BPMSoft.EntityHelper",

		/**
		 * Reads column values.
		 * @param {String} schemaName Name of the entity schema.
		 * @param {String} recordId Unique identifier of the entity schema record.
		 * @param {Array} columns Column names.
		 * @param {Function} callback Callback function.
		 */
		readEntity: function(schemaName, recordId, columns, callback) {
			if (recordId === BPMSoft.GUID_EMPTY) {
				if (callback) {
					callback.call(this);
				}
				return;
			}
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: schemaName
			});
			BPMSoft.each(columns, function(columnName) {
				esq.addColumn(columnName);
			});
			esq.getEntity(recordId, function(result) {
				if (callback) {
					callback.call(this, result.entity);
				}
			}, this);
		},

		/**
		 * Refreshes column values.
		 * @param {Array} columns Column names.
		 * @param {Function} callback Callback function.
		 * @param {BPMSoft.BaseModel} model Instance of the BaseModel.
		 * @param {Object} config Config.
		 */
		refreshColumns: function(columns, callback, model, config) {
			config = config || {};
			if (!config.hasOwnProperty("silent")) {
				config.silent = true;
			}
			if (!model) {
				model = this;
			}
			var primaryColumnValue = this.getPrimaryColumnValue();
			var entitySchemaName = this.entitySchemaName;
			this.readEntity(entitySchemaName, primaryColumnValue, columns, function(entity) {
				BPMSoft.each(entity.values, function(column, columnName) {
					model.setColumnValue(columnName, column, config);
				}, model);
				if (callback) {
					callback.call(this, entity);
				}
			});
		}

	});
	return entityHelperClass;
});
