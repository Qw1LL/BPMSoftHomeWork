define("AnalyticsManager", ["GoogleTagManagerMixin"], function() {

	/**
	 * @class BPMSoft.AnalyticsManager
	 * @abstract
	 */
	Ext.define("BPMSoft.manager.AnalyticsManager", {
		extend: "BPMSoft.manager.ObjectManager",
		alternateClassName: "BPMSoft.AnalyticsManager",
		mixins: {
			/**
			 * @class GoogleTagManagerMixin Used to work with google analytics.
			 */
			GoogleTagManagerMixin: "BPMSoft.GoogleTagManagerMixin"
		},

		//region Methods: Private

		/**
		 * Gets modified items.
		 * @private
		 * @return {BPMSoft.ObjectManagerItem[]} Array items filtered by filterFn.
		 */
		_getModifiedItems: function() {
			return this.filterByFn(function(item) {
				return item.getIsNew() || item.getIsChanged() ||item.getIsDeleted();
			}, this);
		},

		/**
		 * Send GTM data to google analytics.
		 */
		_sendToGoogleAnalytics: function() {
			const modifiedItemsString = this.getModifiedItemsString();
			if (BPMSoft.isEmpty(modifiedItemsString)) {
				return;
			}
			const data = this.getGoogleTagManagerData({
				moduleName: "SectionPageWizard",
				description: modifiedItemsString,
				action: this.entitySchemaName
			});
			this.sendGoogleTagManagerData(data);
		},

		// endregion

		//region Methods: Protected

		/**
		 * Gets names of modified items for all groups.
		 * @protected
		 * @return {String} Formatted string with names of modified items for all groups.
		 */
		getModifiedItemsString: function() {
			const modifiedItems = this._getModifiedItems();
			const modifiedItemsArr = [];
			modifiedItems.each(function(item) {
				modifiedItemsArr.push(item.getModifiedString());
			}, this);
			return BPMSoft.isEmpty(modifiedItemsArr)
				? BPMSoft.emptyString
				: Ext.String.format("[{0}: {1}]", this.entitySchemaName, modifiedItemsArr.join(","));
		},

		// endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.ObjectManager#initializeManager
		 * @override
		 */
		initializeManager: function(callback, scope) {
			this.initGoogleTagManager();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ObjectManager#save
		 * @override
		 */
		save: function(callback, scope) {
			if (this.getGoogleTagManagerEnabled()) {
				this._sendToGoogleAnalytics();
			}
			this.callParent(arguments);
		}

		// endregion

	});

	return BPMSoft.PortalColumnAccessListManager;
});
