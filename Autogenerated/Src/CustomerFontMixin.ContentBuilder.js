define("CustomerFontMixin", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.mixins.CustomerFontMixin", {
		alternateClassName: "BPMSoft.CustomerFontMixin",

		/**
		 * Creates CustomerFont entity schema query.
		 * @return {BPMSoft.EntitySchemaQuery} Instance of the entity schema query.
		 */
		createCustomerFontQuery: function() {
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "ContentBuilderCustomerFont"
			});
			esq.addColumn("Name");
			esq.addColumn("Url");
			esq.serverESQCacheParameters = {
				cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
				cacheGroup: "ContentBuilder",
				cacheItemName: "CustomerFontList"
			};
			return esq;
		},

		/**
		 * Gets CustomerFont entity collection.
		 */
		getCustomerFonts: function(callback, scope) {
			var esq = this.createCustomerFontQuery();
			esq.getEntityCollection(function(response) {
				if (!response || !response.success) {
					return;
				}
				Ext.callback(callback, scope, [response.collection]);
			}, scope);
		},
		
		/**
		 * Adds custom fonts to web page.
		 */
		applyCustomerFonts: function() {
			var customFonts = document.createElement('style');
			customFonts.type = "text/css";
			customFonts.innerText = "";
			this.getCustomerFonts(function(collection) {
				if (collection.isEmpty()) {
					return;
				}
				collection.each(function(item) {
					customFonts.innerText += "@import url(" + item.get("Url") + ");";
				}, this);
				document.head.appendChild(customFonts);
			}, this);
		}
	});
});
