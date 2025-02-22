﻿define("OAuth20Utilities", [], function() {
	Ext.define("BPMSoft.OAuth20Utilities", {
		singleton: true,

		// region Methods: Public

		/**
		 * Adds filters to show only created in section applications
		 * @param {Collection} filters Filters collection.
		 * @public
		 */
		addCustomApplicationFilters: function(filters) {
			filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.IS_NULL,
					"AppClassName",
					BPMSoft.DataValueType.TEXT));
			filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.IS_NULL,
					"ClientClassName",
					BPMSoft.DataValueType.TEXT));
		},

		/**
		 * Checks if user can login in specific OAuth application.
		 * @param {String} userId User id.
		 * @param {String} appId OAuth application id.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Scope.
		 * @public
		 */
		canLoginOAuthUser: function(userId, appId, callback, scope) {
			var userExistsQuery = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "VwOAuthAppUser"
			});
			userExistsQuery.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "IdCOUNT");
			userExistsQuery.filters.addItem(
				BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "SysUser", userId));
			userExistsQuery.filters.addItem(
				BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "OAuthApp", appId));
			userExistsQuery.getEntityCollection(function(response) {
				if (response.success) {
					var result = response.collection.getByIndex(0);
					Ext.callback(callback, scope, [result.get("IdCOUNT") === 0]);
				}
			}, this);
		}

		// endregion

	});

	return BPMSoft.OAuth20Utilities;

});
