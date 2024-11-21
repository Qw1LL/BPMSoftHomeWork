define("QueryCancellationMixin", [], function() {
	/**
	 * @class BPMSoft.configuration.mixins.QueryCancellationMixin
	 * Helps to cancel running queries.
	 */
	Ext.define("BPMSoft.configuration.mixins.QueryCancellationMixin", {
		alternateClassName: "BPMSoft.QueryCancellationMixin",

		/**
		 * Module-wide {Object} that stores last sent queries by their keys.
		 * @private
		 * @type {Object}
		 **/
		_sentQueries: null,

		/**
		* Returns a module-wide {Object} that stores last sent queries by their keys.
		* @private
		* @return {Object} An object with sent queries.
		**/
		_getSentQueries: function() {
			return this._sentQueries || (this._sentQueries = {});
		},

		/**
		 * Registers sent queries in a module-wide object by their keys.
		 * Cancels previously sent query with the same key.
		 * @param {String} key A string to uniquely identify the query.
		 * @param {BPMSoft.BaseQuery} query A Query to be registered.
		 **/
		registerSentQuery: function(key, query) {
			if (key && query) {
				var sentQueries = this._getSentQueries();
				var previousQuery = sentQueries[key];
				if (previousQuery && previousQuery.abortQuery) {
					previousQuery.abortQuery();
				}
				sentQueries[key] = query;
			}
		},
		
		/**
		 * Cancels all module registered queries.
		 */
		abortRegisteredQueries: function() {
			var sentQueries = this._getSentQueries();
			BPMSoft.each(sentQueries, function(query, queryKey) {
				if (query && query.abortQuery) {
					query.abortQuery();
					delete sentQueries[queryKey];
				}
			}, this);
		}

	});
	return Ext.create("BPMSoft.QueryCancellationMixin");
});
