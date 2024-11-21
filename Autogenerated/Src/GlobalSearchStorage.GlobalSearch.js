/**
 * @class BPMSoft.configuration.GlobalSearchStorage
 * Class that provides the ability to retrieve and save global search states.
 */
define("GlobalSearchStorage", [], function() {
	Ext.define("BPMSoft.configuration.GlobalSearchStorage", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.GlobalSearchStorage",

		singleton: true,

		/**
		 * Key of the local store.
		 * @private
		 * @type String
		 */
		_storeName: "GlobalSearch",

		/**
		 * Key of the search params.
		 * @private
		 * @type String
		 */
		_searchParamsKey: "SearchParams",

		/**
		 * Local store instance.
		 * @private
		 * @type BPMSoft.LocalStore
		 */
		_localStore: null,

		/**
		 * @override
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 */
		constructor: function() {
			this.callParent(arguments);
			this._localStore = Ext.create("BPMSoft.LocalStore", {
				storeName: this._storeName,
				isCache: true
			});
		},

		/**
		 * Returns search config of the global search.
		 * @return {Object} Search config of the global search.
		 */
		getSearchConfig: function() {
			return this._localStore.getItem(this._searchParamsKey);
		},

		/**
		 * Save
		 * @param {Object} searchParams
		 */
		setSearchConfig: function(searchParams) {
			this._localStore.setItem(this._searchParamsKey, searchParams);
		}
	});
	return {};
});
