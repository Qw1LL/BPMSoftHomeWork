/**
 * @class BPMSoft.configuration.NavigationServiceUtility
 * The NavigationServiceUtility class is designed to form the path to the section card.
*/
define("NavigationServiceUtility", ["ext-base", "BPMSoft"], function (Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.NavigationServiceUtility", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.NavigationServiceUtility",
		singleton: true,

		// #region Fields: Private

		/**
		 * Template for calling the navigation service.
		 * @private
		 * @type {String}
		 */
		_linkHrefTpl: "{0}Navigation/Navigation.aspx?schemaName={1}&recordId={2}",

		// #endregion

		// #region Methods: Private

		/**
		 * Return base url path.
		 * @private
		 * @return {String} Base url.
		 */
		_getBaseUrl: function() {
			let loaderPath = BPMSoft.loaderBaseUrl;
			if (!Ext.String.endsWith(loaderPath, "/")) {
				loaderPath = loaderPath.concat("/");
			}
			return loaderPath;
		},

		// #endregion

		// #region Methods: Public

		/**
		 * Returns the generated link to the section card.
		 * @public
		 * @param {String} schemaName Entity schema name.
		 * @param {Guid} recordId Entity record id.
		 * @return {String} Generated link to the section card.
		 */
		getEntitySchemaRecordUrl: function(schemaName, recordId) {
			const baseUrl = this._getBaseUrl();
			const linkHref = Ext.String.format(this._linkHrefTpl, baseUrl, schemaName, recordId);
			return linkHref;
		}

		// #endregion

	});
	return BPMSoft.NavigationServiceUtility;
});
