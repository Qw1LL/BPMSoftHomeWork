 define("ProductCatalogueUtilities", function() {
	 Ext.define("BPMSoft.configuration.ProductCatalogueUtilities", {
		 extend: "BPMSoft.BaseObject",
		 alternateClassName: "BPMSoft.ProductCatalogueUtilities",

		 //region Methods: Private

		 /**
		  * @private
		  */
		 _getEntitySchemaByName: function(entitySchemaName, callback, scope) {
			 let schema = BPMSoft[entitySchemaName];
			 if (schema) {
				 callback.call(scope || this, schema);
			 } else {
				 BPMSoft.require([entitySchemaName], function(schema) {
					 if (schema) {
						 callback.call(scope || this, schema);
					 }
				 });
			 }
		 },

		 //endregion

		 //region Methods: Public

		 /**
		  * Loads display column name for reference entity of catalogue level.
		  * @param {BPMSoft.Collection} catalogueFolderLevels Collection of catalogue levels.
		  * @param {Function} callback Callback function.
		  * @param {Object} scope Scope of invoke.
		  */
		 loadReferenceDisplayColumnNames: function(catalogueFolderLevels, callback, scope) {
			 const chainAction = [];
			 BPMSoft.each(catalogueFolderLevels, function(item) {
				 chainAction.push(function(next) {
					 this._getEntitySchemaByName(item.$ReferenceSchemaName, next, this);
				 });
				 chainAction.push(function(next, schema) {
					 item.set("ReferenceDisplayColumnName", schema.primaryDisplayColumn.name);
					 next();
				 });
			 }, this);
			 chainAction.push(function() {
				 Ext.callback(callback, scope || this);
			 });
			 BPMSoft.chain.apply(this, chainAction);
		 }

		 //endregion

	 });

	 return Ext.create("BPMSoft.ProductCatalogueUtilities");

 });
