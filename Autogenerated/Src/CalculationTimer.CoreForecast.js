define("CalculationTimer", ["ForecastComponent"], function() {
	Ext.define("BPMSoft.control.CalculationTimer", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.CalculationTimer",

		/**
		 * Last date time.
		 * @type {Date}
		 */
		lastDateTime: null,

		/**
		 * Next date time.
		 * @type {Date}
		 */
		nextDateTime: null,

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\" style=\"{styles}\">',
			'<ts-calculation-timer id=\"{id}\"',
			' last-date-time = \"{lastDateTime}\" next-date-time = \"{nextDateTime}\"',
			'</ts-calculation-timer>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const forecastTplData = {
				nextDateTime: this.nextDateTime,
				lastDateTime: this.lastDateTime,
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
			const config = {
				nextDateTime: {
					changeMethod: "setNextDateTime"
				},
				lastDateTime: {
					changeMethod: "setLastDateTime"
				},
				setVisible: {
					changeMethod: "setVisible"
				}
			};
			Ext.apply(config, bindConfig);
			return config;
		},

		/**
		 * Sets next date time.
		 * @param {string} nextDateTime Next date time.
		 */
		setNextDateTime: function(nextDateTime) {
			if (this.nextDateTime === nextDateTime) {
				return;
			}
			this.nextDateTime = nextDateTime;
			this._setAttribute("next-date-time", this.nextDateTime);
		},

		/**
		 * Sets last date time.
		 * @param {string} lastDateTime Last date time.
		 */
		setLastDateTime: function(lastDateTime) {
			if (this.lastDateTime === lastDateTime || Ext.isEmpty(lastDateTime)) {
				return;
			}
			this.lastDateTime = lastDateTime;
			this._setAttribute("last-date-time", this.lastDateTime);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				timerEl: "#" + this.id
			};
		},

		/**
		 * @private
		 */
		_setAttribute: function(name, value) {
			if (this.rendered) {
				this.timerEl.dom.setAttribute(name, value);
			}
		}

	});
});
