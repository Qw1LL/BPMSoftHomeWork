define("ProfileSchemaMixin", [], function() {
	/**
	 * @class BPMSoft.configuration.mixins.ProfileSchemaMixin
	 * Profile mixin.
	 */
	Ext.define("BPMSoft.configuration.mixins.ProfileSchemaMixin", {

		alternateClassName: "BPMSoft.ProfileSchemaMixin",

		/**
		 * Returns profile icon url.
		 * @protected
		 * @return {String} Profile icon url.
		 */
		getProfileIcon: function() {
			var primaryImageColumnValue = this.get(this.primaryImageColumnName);
			if (primaryImageColumnValue) {
				return this.getSchemaImageUrl(primaryImageColumnValue);
			}
			return this.getDefaultProfileIcon();
		},

		/**
		 * Returns default photo image url.
		 * @protected
		 * @return {String} Photo image url.
		 */
		getDefaultProfileIcon: function() {
			return this.getImageUrlByResourceKey("Resources.Images.ProfileIcon");
		},

		/**
		 * Returns Image url.
		 * @param {String} key Image key of resources.
		 * @return {String} Image url.
		 */
		getImageUrlByResourceKey: function(key) {
			var resourceImage = this.get(key);
			return this.BPMSoft.ImageUrlBuilder.getUrl(resourceImage);
		}
	});

	return BPMSoft.ProfileSchemaMixin;
});
