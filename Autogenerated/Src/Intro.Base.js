define("Intro", ["BPMSoft", "DriverJs", "css!DriverCSS"], function(BPMSoft, Driver) {
	/**
	 * Class provides functionality of introduction tour step.
	 */
	Ext.define("BPMSoft.IntroStep", {
		driver: null,
		element : "",
		popover: {},
		onNext: null,
		onPrevious: null,
		onHighlightStarted: BPMSoft.emptyFn,
		onHighlighted: BPMSoft.emptyFn,
		onDeselected: BPMSoft.emptyFn,

		/**
		 * Constructor for IntroStep.
		 * @param {Object} config Step config.
		 */
		constructor: function(config) {
			Ext.apply(this, config);
		},

		/**
		 * Returns step with binded handlers.
		 * @protected
		 * @param {Object} driver Instance of driver.
		 */
		getStep: function(driver) {
			var step = {
				element : this.element,
				popover: this.popover,
				stageBackground: this.stageBackground,
				onHighlightStarted: this.onHighlightStarted,
				onHighlighted: this.onHighlighted,
				onDeselected: this.onDeselected,
				driver: driver
			};
			if (this.onPrevious) {
				step.onPrevious = function() {
					driver.preventMove();
					this.onPrevious(function() {
						driver.movePrevious();
					});
				}.bind(this);
			}
			if (this.onNext) {
				step.onNext = function() {
					driver.preventMove();
					var nextStep = driver.currentStep + 1;
					var next = function() {
						if (driver.isActivated) {
							driver.moveNext();
						} else {
							driver.start(nextStep);
						}
					};
					this.onNext(driver, next);
				}.bind(this);
			}
			return step;
		}
	});

	/**
	 * Class provides introduction tour feature.
	 */
	Ext.define("BPMSoft.Intro", {
		/**
		 * Instance of intro driver.
		 * @type {Object}
		 */
		driver: null,
		/**
		 * An array of BPMSoft.IntroStep.
		 * @type {Array}
		 **/
		steps: [],
		/**
		 * Index of step to display.
		 * @type {Number}
		 */
		currentStep: 0,
		/**
		 * Unique key for current tour.
		 * @type {String}
		 */
		uniqueKey: null,

		/**
		 * Initializes array of steps.
		 * @param config {Object} An introduction tour config.
		 */
		constructor: function(config) {
			this.callParent(arguments);
			this.driver = new Driver(config.options);
			this.uniqueKey = config.uniqueKey;
			if (config && Array.isArray(config.steps)) {
				this.steps = Array.from(config.steps);
				this.steps = this.steps.map(function(x) {
					return x.getStep(this.driver);
				}, this);
			}
		},

		/**
		 * Returns tour user profile key if tour unique key is specified.
		 * @protected
		 * @returns {String}
		 */
		getTourProfileKey: function() {
			if (this.uniqueKey) {
				return "IntroTour_" + this.uniqueKey;
			}
			return null;
		},

		/**
		 * Refreshes user profile data for current tour.
		 * Increases views count when tour unique key is specified.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Context.
		 */
		updateUserProfile: function(callback, scope) {
			var tourProfileKey = this.getTourProfileKey();
			if (!tourProfileKey) {
				callback.call(scope);
				return;
			}
			this.getNumberOfViews(function(numberOfViews) {
				var data = { numberOfViews: numberOfViews + 1 };
				BPMSoft.utils.saveUserProfile(tourProfileKey, data, false, callback, scope);
			}, this);
		},

		/**
		 * Highlights current step.
		 * @protected
		 * @param {BPMSoft.IntroStep} step Current step.
		 */
		highlight: function(step) {
			this.driver.highlight(step);
			if (!this.driver.overlay.highlightedElement) {
				this.driver.reset();
			}
		},

		/**
		 * Waits for element visibility by specified time intervals.
		 * @protected
		 * @param {String} selector Element selector.
		 * @param {Function} callback Callback function.
		 * @param {Number} time
		 * @param {Number} intervals
		 * @param {Number} doneIntervals
		 */
		waitForElementToDisplay: function(selector, callback, time, intervals, doneIntervals) {
			var element = document.querySelector(selector);
			if (element !== null && element.style.display !== "none") {
				callback.call(null, true);
			} else {
				var self = this;
				var d = doneIntervals || 1;
				var t = time || 500;
				var i = intervals || 10;
				if (d >= i) {
					callback.call(null, false);
					return;
				}
				setTimeout(function() {
					d++;
					self.waitForElementToDisplay(selector, callback, t, i, d);
				}, t);
			}
		},

		/**
		 * Starts playing the tour.
		 */
		start: function() {
			this.updateUserProfile(function() {
				this.driver.defineSteps(this.steps);
				this.driver.start();
			}, this);
		},

		/**
		 * Returns number of views for tour by current user async.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Context.
		 */
		getNumberOfViews: function(callback, scope) {
			var tourProfileKey = this.getTourProfileKey();
			if (!tourProfileKey) {
				callback.call(scope, 0);
				return;
			}
			var config = {
				schemaName: tourProfileKey,
				profileKey: tourProfileKey
			};
			BPMSoft.ProfileUtilities.getProfile(config, function(profile) {
				var viewsCount = profile.numberOfViews || 0;
				callback.call(scope, viewsCount);
			}, this);
		}
	});
	return BPMSoft.Intro;
});
