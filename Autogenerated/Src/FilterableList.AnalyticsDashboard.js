define("FilterableList", ["FilterableListResources", "AnalyticsDashboard", "css!FilterableList"],
		function(resources) {
	/**
	 * Component for rendering pivot-table web components
	 */
	Ext.define("BPMSoft.controls.FilterableList", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.FilterableList",

		mixins: {
			customEvent: "BPMSoft.mixins.CustomEventDomMixin"
		},

		// region Fields: Private

		_itemSelectedEventName: "itemSelected",
		_favoriteStateChangedEventName: "favoriteStateChanged",

		// endregion

		// region Fields: Protected

		/**
		 * @property {[{id: String, caption: String}]}
		 * The list of items for filtering.
		 * @protected
		 */
		items: null,

		/**
		 * @property {{value: String, property: String}}
		 * The filter that will be applied to the array.
		 * @protected
		 */
		filter: null,

		/**
		 * The control resources receive event name.
		 * @protected
		 */
		getControlResourcesEventName: "getFilterableListResources",

		/**
		 * The control resources send event name.
		 * @protected
		 */
		setControlResourcesEventName: "setFilterableListResources",

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="ts-filterable-list-wrapper">',
			'<ts-filterable-list id="{id}" class="filterable-list" data-qa="filterable-list">',
			'</ts-filterable-list>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		// endregion

		// region Methods: Private

		/**
		 * @private
		 */
		_initControlResources: function() {
			const customEvent = this.mixins.customEvent;
			customEvent.init();
			customEvent
				.subscribe(this.getControlResourcesEventName)
				.subscribe(function() {
					this.mixins.customEvent.publish(this.setControlResourcesEventName, resources);
				}.bind(this));
		},

		/**
		 * @private
		 */
		_initItemSelectedEventListeners: function() {
			const el = this.filterableListEl;
			if (el) {
				el.on("itemSelected", this.handleItemSelected, this);
			}
		},

		/**
		 * @private
		 */
		_clearItemSelectedEventListeners: function() {
			const el = this.filterableListEl;
			if (el) {
				el.un("itemSelected", this.handleItemSelected, this);
			}
		},


		/**
		 * @private
		 */
		_initFavoriteStateChangedEventListeners: function() {
			const el = this.filterableListEl;
			if (el) {
				el.on("favoriteStateChanged", this.handleFavoriteStateChanged, this);
			}
		},

		/**
		 * @private
		 */
		_clearFavoriteStateChangedEventListeners: function() {
			const el = this.filterableListEl;
			if (el) {
				el.un("favoriteStateChanged", this.handleFavoriteStateChanged, this);
			}
		},

		/**
		 * @private
		 */
		_setItemsToDomElement: function() {
			this.filterableListEl.dom.items = this.items;
		},

		/**
		 * @private
		 */
		_setFilterToDomElement: function() {
			this.filterableListEl.dom.filter = this.filter;
		},

		// endregion

		// region Methods: Protected

		/**
		 * Handles the event of selecting an item in a list.
		 * @protected
		 * @param {Event} event Browser event object.
		 */
		handleItemSelected: function(event) {
			const selectedItem = event.browserEvent.detail;
			this.fireEvent(this._itemSelectedEventName, selectedItem);
		},

		/**
		 * Handles the event of favorite item changed.
		 * @protected
		 * @param {Event} event Browser event object.
		 */
		handleFavoriteStateChanged: function(event) {
			const favoriteItem = event.browserEvent.detail;
			this.fireEvent(this._favoriteStateChangedEventName, favoriteItem);
		},

		/**
		 * Sets a list of filterable items.
		 * @protected
		 * @param {Object[]} items The list of items for filtering.
		 */
		setItems: function(items) {
			this.items = items;
			if (this.rendered) {
				this._setItemsToDomElement();
			}
		},

		/**
		 * Sets a filter.
		 * @protected
		 * @param {Object} filter The instance of filter.
		 * @param {String} filter.value The target value used in filtering.
		 * @param {String} filter.property Optional. The name of the property to be filtered. Default value is 'caption'.
		 */
		setFilter: function(filter) {
			this.filter = filter;
			if (this.rendered) {
				this._setFilterToDomElement();
			}
		},

		/**
		 * Initializes the element options.
		 * @protected
		 */
		initElementOptions: function() {
			this._setItemsToDomElement();
			this._setFilterToDomElement();
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritDoc
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(this._itemSelectedEventName);
			this.addEvents(this._favoriteStateChangedEventName);
			this._initControlResources();
		},

		/**
		 * @inheritDoc BPMSoft.Component#onAfterRender
		 * @override
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			this.initElementOptions();
		},

		/**
		 * @inheritDoc BPMSoft.Component#onAfterReRender
		 * @override
		 */
		onAfterReRender: function () {
			this.callParent(arguments);
			this.initElementOptions();
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		onDestroy: function() {
			this.mixins.customEvent.destroy();
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			this._initItemSelectedEventListeners();
			this._initFavoriteStateChangedEventListeners();
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			this._clearItemSelectedEventListeners();
			this._clearFavoriteStateChangedEventListeners();
		},

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				filterableListEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			this.selectors = this.getSelectors();
			const tplData = this.callParent(arguments);
			const filterableListTplData = {
				items: this.items,
				filter: this.filter
			};
			Ext.apply(tplData, filterableListTplData);
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const filterableListBindConfig = {
				items: {
					changeMethod: "setItems"
				},
				filter: {
					changeMethod: "setFilter"
				}
			};
			Ext.apply(filterableListBindConfig, bindConfig);
			return filterableListBindConfig;
		}

		// endregion

	});

	return BPMSoft.FilterableList;

});
