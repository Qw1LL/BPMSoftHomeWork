define("FavoriteTabsDecorator", ["DashboardManager", "DashboardManagerItem"], function () {
	Ext.define("BPMSoft.FavoriteTabsDecorator", {
		extend: "BPMSoft.BaseObject",

		/**
		 * @protected
		 * @property {String} User profile key of the favorite tabs state.
		 */
		userProfileKey: null,

		/**
		 * @private
		 */
		_favoriteProfileTabs: null,

		/**
		 * Initialize instance state.
		 * @return {Promise}
		 */
		init: function() {
			return this._loadProfile();
		},

		/**
		 * Gets tabs with favorite tag.
		 * @param {BPMSoft.Collection<BPMSoft.DashboardManagerItem>} dashboardItems
		 * @return {Array<{Id: String, Caption: String, IsFavorite: Boolean, SortPosition: Number}>}
		 */
		getTabs: function (dashboardItems) {
			const dashboardTabs = dashboardItems.getItems();
			return dashboardTabs.map(function (dashboardTab) {
				const id = dashboardTab.getId();
				const caption = dashboardTab.getCaption();
				const profileTab = BPMSoft.findWhere(this._favoriteProfileTabs, {id: id}) || {};
				const isFavorite = Boolean(profileTab.isFavorite);
				const sortPosition = Ext.isDefined(profileTab.sortPosition) ? profileTab.sortPosition : null;
				return {
					Id: id,
					Caption: caption,
					IsFavorite: isFavorite,
					SortPosition: sortPosition
				};
			}, this);
		},

		/**
		 * Update profile state of the tabs.
		 * @param {Object} profileState Current state of the profile.
		 * @param {BPMSoft.Collection<BPMSoft.DashboardManagerItem>} dashboardItems
		 * @param {{id: String, isFavorite: Boolean}} [favoriteTabChanged]
		 * @return {Promise} Resolve when the state was updated.
		 */
		updateTabsState: function(profileState, dashboardItems, favoriteTabChanged) {
			const favoriteTabs = this.getTabs(dashboardItems);
			if (favoriteTabChanged) {
				const isFavorite = Boolean(favoriteTabChanged.isFavorite);
				const findTabChanged = BPMSoft.findWhere(favoriteTabs, {Id: favoriteTabChanged.id});
				Ext.apply(findTabChanged, {
					IsFavorite: isFavorite,
					SortPosition: isFavorite ? -1 : null
				});
			}
			this._favoriteProfileTabs = favoriteTabs
				.filter(function(tab) {
					return tab.IsFavorite;
				})
				.map(function(tab) {
					return {
						id: tab.Id,
						isFavorite: tab.IsFavorite,
						sortPosition: tab.SortPosition,
					};
				});
			const state = Ext.apply(profileState, { tabs: this._favoriteProfileTabs });
			return this._saveProfile(state);
		},

		/**
		 * @private
		 * @param {Object} state State of the profile.
		 * @return {Promise}
		 */
		_saveProfile: function(state) {
			return new Promise(function(resolve) {
				BPMSoft.saveUserProfile(this.userProfileKey, state, false, resolve);
			}.bind(this));
		},

		/**
		 * @private
		 * @return {Promise}
		 */
		_loadProfile: function() {
			return new Promise(function (resolve) {
				const profileKey = "profile!" + this.userProfileKey;
				BPMSoft.require([profileKey], function (profile) {
					this._favoriteProfileTabs = profile.tabs || [];
					resolve();
				}, this);
			}.bind(this));
		},
	});
	return {};
});
