﻿define("MoneyModule", ["ext-base", "BPMSoft", "MoneyUtilsMixin"],
	function(Ext, BPMSoft) {
		var moneyModule = {
			alternateClassName: "BPMSoft.MoneyModule",
			/**
			 * MoneyUtilsMixin
			 * @type {BPMSoft.MoneyUtilsMixin}
			 */
			MoneyUtils: null,

			/**
			 * Returns CurrencyRate ESQ.
			 * @returns {BPMSoft.EntitySchemaQuery}
			 * @private
			 */
			getCurrencyESQ: function() {
				return Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "CurrencyRate"
				});
			}
		};

		/**
		 * Link to myself (for unit test ability)
		 * @type {{MoneyUtils: BPMSoft.MoneyUtilsMixin, getCurrencyESQ: moneyModule.getCurrencyESQ}}
		 */
		moneyModule.self = moneyModule;

		/**
		 * Loads currency rate and call foundCallback if currency rate isn't empty, otherwise calls notFoundCallback.
		 * @param {UId} CurrencyId - Currency Id.
		 * @param {Date} startDate - Currency start date.
		 * @param {Function} foundCallback - Calls if currency rate founded.
		 * @param {Function} notFoundCallback - Calls if currency rate not founded.
		 */
		moneyModule.onLoadCurrencyRate = function(CurrencyId, startDate, foundCallback, notFoundCallback) {
			var esq = moneyModule.self.getCurrencyESQ();
			esq.rowCount = 1;
			esq.addColumn("Id");
			esq.addColumn("Rate");
			esq.addColumn("Currency.Division", "Division");
			esq.addColumn("RateMantissa", "RateMantissa");
			var startDateColumn = esq.addColumn("StartDate");
			startDateColumn.orderDirection = BPMSoft.OrderDirection.DESC;
			startDateColumn.orderPosition = 0;
			var createdOnColumn = esq.addColumn("CreatedOn");
			createdOnColumn.orderDirection = BPMSoft.OrderDirection.DESC;
			createdOnColumn.orderPosition = 1;
			var filters = esq.filters;
			var filterNameCurrencyId = "FilterCurrencyRate";
			var filterCurrencyId = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"Currency", CurrencyId);
			filters.add(filterNameCurrencyId, filterCurrencyId);
			if (Ext.isDate(startDate)) {
				var filterNameStartDate = "FilterStartDate";
				var filterStartDate = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.LESS_OR_EQUAL,
					"StartDate", startDate);
				filters.add(filterNameStartDate, filterStartDate);
			}
			esq.getEntityCollection(function(response) {
				if (response && response.success) {
					var collection = response.collection;
					if (collection && !collection.isEmpty()) {
						var item = collection.getByIndex(0);
						item.values.Rate = moneyModule.self.MoneyUtils.applyMantissaConversion(item.values.Rate,
							item.values.RateMantissa);
						foundCallback.call(this, item.values);
					} else {
						notFoundCallback.call(this);
					}
				} else {
					notFoundCallback.call(this);
				}
			}, this);
		};

		/**
		 * Calls onLoadCurrencyRate and sets specified currencyRateAttribute if currencyAttribute isn't empty.
		 * @param currencyAttribute - Currency attribute.
		 * @param currencyRateAttribute - Currency rate attribute.
		 * @param startDate - Currency start date.
		 * @param {function} callback
		 */
		moneyModule.LoadCurrencyRate = function(currencyAttribute, currencyRateAttribute, startDate, callback) {
			var currency = this.get(currencyAttribute);
			if (Ext.isEmpty(currency)) {
				return;
			}
			moneyModule.self.onLoadCurrencyRate.call(this, currency.value, startDate,
				function(item) {
					this.set(currencyRateAttribute, item.Rate);
					if (callback) {
						callback.call(this);
					}
				}, function() {
					this.set(currencyRateAttribute, 1);
				});
		};

		/**
		 * Calculates currency value.
		 * @param currencyRateAttribute - Currency rate attribute.
		 * @param currencyValueAttribute - Currency value attribute.
		 * @param baseValueAttribute - Base value attribute.
		 * @param currencyDivision - Currency division.
		 * @constructor
		 */
		moneyModule.RecalcCurrencyValue = function(currencyRateAttribute, currencyValueAttribute,
				baseValueAttribute, currencyDivision) {
			moneyModule.self.MoneyUtils.recalculateValue(currencyValueAttribute, {
				primaryValueAttribute: baseValueAttribute,
				currencyRateAttribute: currencyRateAttribute,
				currencyDivision: currencyDivision,
				modelInstance: this
			});
		};

		/**
		 * Calculates primary value.
		 * @param currencyRateAttribute - Currency rate attribute.
		 * @param currencyValueAttribute - Currency value attribute.
		 * @param baseValueAttribute - Base value attribute.
		 * @param currencyDivision - Currency division.
		 * @constructor
		 */
		moneyModule.RecalcBaseValue = function(currencyRateAttribute, currencyValueAttribute,
				baseValueAttribute, currencyDivision) {
			moneyModule.self.MoneyUtils.recalculatePrimaryValue(currencyValueAttribute, {
				primaryValueAttribute: baseValueAttribute,
				currencyRateAttribute: currencyRateAttribute,
				currencyDivision: currencyDivision,
				modelInstance: this
			});
		};

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor.
		 * @protected
		 * @overridden
		 */
		moneyModule.constructor = function() {
			this.callParent(arguments);
			this.self.MoneyUtils =  Ext.create("BPMSoft.MoneyUtilsMixin");
		};

		/**
		 * @class BPMSoft.configuration.MoneyModule.
		 */
		Ext.define("BPMSoft.configuration.MoneyModule", moneyModule);
		return Ext.create("BPMSoft.configuration.MoneyModule");
	});
