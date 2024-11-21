define("NewColumnGridLayoutEditItemModel", ["ColumnGridLayoutEditItemModel"], function() {

	Ext.define("BPMSoft.configuration.NewColumnGridLayoutEditItemModel", {
		extend: "BPMSoft.ColumnGridLayoutEditItemModel",
		alternateClassName: "BPMSoft.NewColumnGridLayoutEditItemModel",

		// region Methods: Private

		/**
		 * @private
		 */
		_getNamePrefix: function() {
			var schemaNamePrefix = BPMSoft.ClientUnitSchemaManager.schemaNamePrefix;
			var columnName = Ext.String.capitalize(this.column.name.toLowerCase());
			var prefix = schemaNamePrefix ? (schemaNamePrefix + columnName) : columnName;
			return prefix;
		},

		/**
		 * @private
		 */
		_generateName: function(designerSchema) {
			var names = [];
			var dataModels = designerSchema.$DataModels;
			dataModels.each(function(dataModel) {
				var schema = dataModel.get("Schema");
				var datModelColumnNames = schema.columns.mapArray(function(column) {
					return column.name.toLowerCase();
				}, this);
				BPMSoft.append(names, datModelColumnNames);
			}, this);
			var prefix = this._getNamePrefix();
			return BPMSoft.getUniqueValue(names, prefix);
		},

		/**
		 * @private
		 */
		_generateCaption: function(name) {
			var prefix = this._getNamePrefix();
			var nameSuffix = name.substr(prefix.length);
			var sourceCaption = this.column.caption;
			var caption = new sourceCaption.self();
			BPMSoft.each(sourceCaption.cultureValues, function(value, culture) {
				caption.setCultureValue(culture, value + " " + nameSuffix);
			}, this);
			return caption;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ColumnGridLayoutEditItemModel#getDesignSchemaColumn
		 * @override
		 * @param {BPMSoft.ViewModelSchemaDesignerSchema} designSchema Design schema.
		 */
		getDesignEntitySchemaColumn: function(designSchema) {
			var column = this.column;
			var uId = BPMSoft.generateGUID();
			var name = this._generateName(designSchema);
			var caption = this._generateCaption(name);
			const columnConfig = {
				uId: uId,
				caption: caption,
				name: name,
				dataValueType: column.dataValueType,
				status: BPMSoft.ModificationStatus.NEW
			};
			if (column.hasOwnProperty("isValueCloneable")) {
				columnConfig.isValueCloneable = column.isValueCloneable;
			}
			return new column.self(columnConfig);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#addToDesignSchema
		 * @override
		 */
		addToDesignSchema: function(config) {
			var designSchema = this.designSchema;
			designSchema.set("ActionLayoutName", config.layoutName);
			designSchema.set("ActionLayoutItem", this);
			designSchema.set("ActionLayoutCreate", true);
			this.openDesigner();
		}

		// endregion

	});

	return BPMSoft.NewColumnGridLayoutEditItemModel;
});
