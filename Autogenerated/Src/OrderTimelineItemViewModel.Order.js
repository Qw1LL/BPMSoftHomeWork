define("OrderTimelineItemViewModel", ["OrderTimelineItemViewModelResources", "BaseTimelineItemViewModel"],
	function() {
		/**
		 * @class BPMSoft.configuration.OrderTimelineItemViewModel
		 * Order timeline item view model class.
		 */
		Ext.define("BPMSoft.configuration.OrderTimelineItemViewModel", {
			alternateClassName: "BPMSoft.OrderTimelineItemViewModel",
			extend: "BPMSoft.BaseTimelineItemViewModel",

			// region Methods: Protected

			/**
			 * Sets primary currency symbol. Callback function.
			 * @protected
			 * @param {Object} response Response object for esq request.
			 */
			setPrimaryCurrencySymbolCallback: function(response) {
				if (response && response.success) {
					this.set("PrimaryCurrencySymbol", response.entity.get("Symbol"));
				}
			},

			/**
			 * Sets primary currency symbol.
			 * @protected
			 * @param {String} currency lookup value.
			 */
			setPrimaryCurrencySymbol: function(currency) {
				if (!Ext.isEmpty(currency)) {
					var currencyId = currency.value;
					var cacheItemName = "TimelinePrimaryCurrencySymbol_" + currencyId;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Currency"
					});
					esq.clientESQCacheParameters = {cacheItemName: cacheItemName};
					esq.serverESQCacheParameters = {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "Timeline",
						cacheItemName: cacheItemName
					};
					esq.addColumn("Symbol");
					esq.getEntity(currencyId, this.setPrimaryCurrencySymbolCallback, this);
				}
			},

			/**
			 * Returns caption with currency symbol.
			 * @protected
			 * @param {String} caption Field caption.
			 * @param {String} currencySymbol Symbol of currency.
 			 * @return {String} Amount caption text with currency symbol suffix.
			 */
			getCaptionWithCurrencySymbol: function(caption, currencySymbol) {
				return currencySymbol
					? caption + ", " + currencySymbol
					: caption;
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemViewModel#initDefaultValues
			 * @override
			 */
			initDefaultValues: function() {
				BPMSoft.SysSettings.querySysSettingsItem("PrimaryCurrency", this.setPrimaryCurrencySymbol, this);
				this.callParent(arguments);
			},

			// endregion

			// region Methods: Public

			/**
			 * Concatenates amount caption text with current currency symbol.
			 * @return {String} Amount caption text with currency symbol suffix.
			 */
			getAmountWithCurrencyCaption: function() {
				var amountCaption = this.get("Resources.Strings.AmountLabel");
				var currencySymbol = this.get("PrimaryCurrencySymbol");
				return amountCaption
					? this.getCaptionWithCurrencySymbol(amountCaption, currencySymbol)
					: "";
			},

			/**
			 * Concatenates payment amount caption text with current currency symbol.
			 * @return {String} Amount caption text with currency symbol suffix.
			 */
			getPaymentAmountWithCurrencyCaption: function() {
				var paymentAmountCaption = this.get("Resources.Strings.PaymentAmountLabel");
				var currencySymbol = this.get("PrimaryCurrencySymbol");
				return paymentAmountCaption
					? this.getCaptionWithCurrencySymbol(paymentAmountCaption, currencySymbol)
					: "";
			}

			// endregion
		});
	});
