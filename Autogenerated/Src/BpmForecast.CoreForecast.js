define("BpmForecast",  ["BaseForecast"], function() {
	/**
	 * Component for rendering bpm-forecast web components
	 */
	Ext.define("BPMSoft.control.BpmForecast", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.BpmForecast",

		domAttributes: [],

		styles: {},
		parentComponent: Ext.emptyString,
		mixins: {
			"BaseForecast": "BPMSoft.BaseForecast"
		},

		/**
		 * Wait timespan from resize.
		 * @type {Number}
		 * @private
		 */
		_wait: 250,

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\" style=\"{styles}\">',
			'<ts-forecast id=\"{id}\" ' +
			'class="ts-forecast-component" ' +
			'forecast-id = \"{forecastId}\" command = \"{command}\" ',
			'base-url = \"{baseUrl}\" periods-id=\"{periodsId}\" images=\"{imagesList}\" ',
			'max-displayed-records="{maxDisplayedRecords}" ' +
			'max-allowed-container-height="{maxAllowedContainerHeight}"' +
			'>',
			'</ts-forecast>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				bpmForecastEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"commandFinished",
				"addColumnClicked",
				"editColumnClicked",
				"rowActionClicked",
				"innerException",
				"setupColumnsClick",
				"cellSelected",
				"goToSectionClick"
			);
			this.updateDirection(this.name);
			this.setStyles();
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.bpmForecastEl;
			if (el) {
				el.on("commandFinished", this.onCommandFinished, this);
				el.on("addColumnClick", this.handleAddColumnClick, this);
				el.on("editColumnClick", this.handleEditColumnClick, this);
				el.on("rowActionClick", this.handleRowActionClicked, this);
				el.on("innerException", this.handleInnerException, this);
				el.on("setupColumnsClicked", this.handleSetupColumnsClicked, this);
				el.on("cellSelected", this.handleCellSelected, this);
				el.on("goToSectionClicked", this.goToSectionClicked, this);
			}
			this.debounceWindowResize = BPMSoft.debounce(this.updateWrapHeight, this._wait);
			Ext.EventManager.addListener(window, "resize", this.debounceWindowResize, this);
		},

		/**
		 * Handles go to section action click.
		 * @param {Object} event Go to section data.
		 */
		goToSectionClicked: function(event) {
			const actionData = event.browserEvent.detail;
			this.fireEvent("goToSectionClick", actionData);
		},

		/**
		 * Handles cell selected action click.
		 * @param {Object} event Cell selected action data.
		 */
		handleCellSelected: function(event) {
			const actionData = event.browserEvent.detail;
			this.fireEvent("cellSelected", actionData);
		},

		/**
		 * Handles row action click.
		 * @param {Object} event Row action data.
		 */
		handleRowActionClicked: function(event) {
			const actionData = event.browserEvent.detail;
			this.fireEvent("rowActionClicked", actionData);
		},

		/**
		 * Handles inner exception event.
		 * @param {Object} event Exception info.
		 */
		handleInnerException: function(event) {
			const info = event.browserEvent.detail;
			this.fireEvent("innerException", info);
		},

		/**
		 * Handles clicking on "add column" button.
		 * @param {Object} event Event data.
		 * @protected
		 */
		handleAddColumnClick: function(event) {
			this.fireEvent("addColumnClicked", event);
		},

		/**
		 * Handles clicking on "edit column" button.
		 * @param {Object} event Event data.
		 * @protected
		 */
		handleEditColumnClick: function(event) {
			const columnData = event.browserEvent.detail.column;
			this.fireEvent("editColumnClicked", event, columnData);
		},

		/**
		 * Handles clicking on cell
		 * @param {Object} event Event data
		 * @protected
		 */
		handleSetupColumnsClicked: function(event) {
			const data = {
				entitySchemaName: event.browserEvent.detail.entitySchemaName,
				columnId: event.browserEvent.detail.columnId,
				forecastId: this.forecastId
			};
			this.fireEvent("setupColumnsClick", data);
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.bpmForecastEl;
			if (el) {
				el.un("commandFinished", this.onCommandFinished, this);
				el.un("addColumnClick", this.handleAddColumnClick, this);
				el.un("editColumnClick", this.handleEditColumnClick, this);
				el.un("rowActionClick", this.handleRowActionClicked, this);
				el.un("innerException", this.handleInnerException, this);
				el.un("setupColumnsClick", this.handleInnerException, this);
			}
			Ext.EventManager.removeListener(window, "resize", this.debounceWindowResize, this);
		},

		/**
		 * Handler of command finished.
		 * @protected
		 */
		onCommandFinished: function(event) {
			this.fireEvent("commandFinished", event);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const forecastTplData = {
				forecastId: this.forecastId,
				command: this.command,
				periodsId: this.periodsId,
				baseUrl: this.baseUrl,
				imagesList: this.imagesList,
				styles: this.styles,
				maxDisplayedRecords: this.maxDisplayedRecords,
				maxAllowedContainerHeight: this.maxAllowedContainerHeight
			};
			Ext.apply(tplData, forecastTplData);
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const forecastBindConfig = {
				forecastId: {
					changeMethod: "setForecastId"
				},
				command: {
					changeMethod: "setCommand"
				},
				periodsId: {
					changeMethod: "setPeriodsId"
				},
				baseUrl: {
					changeMethod: "setBaseUrl"
				},
				imagesList: {
					changeMethod: "setImagesList"
				},
				maxDisplayedRecords: {
					changeMethod: "setMaxDisplayedRecords"
				}
			};
			Ext.apply(forecastBindConfig, bindConfig);
			return forecastBindConfig;
		},
	});

	return BPMSoft.BpmForecast;

});
