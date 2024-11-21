define("HistoryForecast", ["BaseForecast"], function() {
	/**
	 * Component for rendering history-forecast web components
	 */
	Ext.define("BPMSoft.control.HistoryForecast", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.HistoryForecast",

		snapshotId: null,
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
			'<ts-history-forecast id=\"{id}\" ' +
			'class="ts-forecast-component" ' +
			'forecast-id = \"{forecastId}\"  snapshot-id = \"{snapshotId}\" ' +
			'command = \"{command}\"',
			'base-url = \"{baseUrl}\" periods-id=\"{periodsId}\" images=\"{imagesList}\"',
			'max-displayed-records="{maxDisplayedRecords}">',
			'</ts-historyforecast>',
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
			}

			this.debounceWindowResize = BPMSoft.debounce(this.updateWrapHeight, this._wait);
			Ext.EventManager.addListener(window, "resize", this.debounceWindowResize, this);
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
				snapshotId: this.snapshotId,
				baseUrl: this.baseUrl,
				imagesList: this.imagesList,
				styles: this.styles,
				maxDisplayedRecords: this.maxDisplayedRecords
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
				snapshotId: {
					changeMethod: "setSnapshotId"
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

		/**
		 * Sets snapshot id.
		 * @param {String} snapshotId Periods identifiers.
		 */
		setSnapshotId: function(snapshotId) {
			if (this.snapshotId === snapshotId) {
				return;
			}
			this.snapshotId = snapshotId;
			this.setAttribute("snapshot-id", this.snapshotId);
		},
	});

	return BPMSoft.HistoryForecast;

});
