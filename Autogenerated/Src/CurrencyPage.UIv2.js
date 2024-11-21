define("CurrencyPage", ["CurrencyPageResources", "css!CurrencyCommonCSS", "CurrencyRateServiceRequest",
	"MoneyUtilsMixin"],
	function() {
		return {
			entitySchemaName: "Currency",
			attributes: {},
			mixins: {
				MoneyUtilsMixin: "BPMSoft.MoneyUtilsMixin"
			},
			details: /**SCHEMA_DETAILS*/{
				"CurrencyRate": {
					"schemaName": "CurrencyRateDetail",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Currency"
					}
				}
			}/**SCHEMA_DETAILS*/,

			messages: {
				/**
				 * @message EditPageClosed
				 * Closes edit page.
				 */
				"EditPageClosed": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				"GetCurrencyDivision": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},

			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#initActionButtonMenu
				 * @overriden
				 */
				initActionButtonMenu: function() {
					this.callParent(arguments);
					this.set("ActionsButtonVisible", false);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#subscribeSandboxEvents
				 * @overriden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetCurrencyDivision", this.getCurrencyDivision, this);
				},

				/**
				 * Returns currency division.
				 * @protected
				 */
				getCurrencyDivision: function() {
					return this.get("Division") || 0;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#loadEntity
				 * @overriden
				 */
				loadEntity: function(primaryColumnValue, callback, scope) {
					var initRateCallback = this.initRate.bind(this, callback, scope);
					this.callParent([primaryColumnValue, initRateCallback, scope]);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onCloseClick
				 * @overriden
				 */
				onCloseClick: function() {
					this.callParent(arguments);
					this.sandbox.publish("EditPageClosed", null);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#saveEntityInChain
				 * @overriden
				 */
				saveEntityInChain: function(next) {
					var rateColumn = this.columns.Rate || {};
					rateColumn.columnPath = "Rate";
					this.BPMSoft.EntitySchemaQuery.clearCache("CurrencyRateListItem");
					this.callParent([next]);
				},

				/**
				 * Returns initialized CurrencyRateServiceRequest object.
				 * @protected
				 * @return {BPMSoft.CurrencyRateServiceRequest} returns initialized CurrencyRateServiceRequest object.
				 */
				getCurrencyRateServiceRequest: function() {
					var currencyId = this.get("PrimaryColumnValue") || this.get("Id");
					return this.Ext.create("BPMSoft.CurrencyRateServiceRequest", {
						currencyId: currencyId
					});
				},

				/**
				 * Initializes rate for currency.
				 * @param {Function} callback Callback f-n.
				 * @param {BPMSoft.BaseViewModel} scope Callback scope.
				 * @protected
				 */
				initRate: function(callback, scope) {
					var request = this.getCurrencyRateServiceRequest();
					request.getActualCurrencyRates(function(result) {
						if (result) {
							this.setRateFromEntity(result);
							delete this.changedValues.Rate;
						}
						if (callback) {
							callback.call(scope);
						}
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDetailChanged
				 * @overridden
				 */
				onDetailChanged: function() {
					this.callParent(arguments);
					this.initRate();
				},

				/**
				 * @inheritDoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Division", this.divisionValidator);
					this.addColumnValidator("Rate", this.rateValidator);
				},

				/**
				 * @inheritDoc BPMSoft.BaseViewModel#getSaveQuery
				 * @overridden
				 */
				getSaveQuery: function() {
					var query = this.callParent(arguments);
					var division = this.getCurrencyDivision();
					var rateValue = this.get("Rate");
					query = this.formCurrencyRateSaveQuery({
						rate: rateValue,
						division: division,
						query: query
					});
					return query;
				},

				/**
				 * Validates Division field.
				 * @protected
				 * @virtual
				 * @return {Object} Validation error messages config.
				 */
				divisionValidator: function() {
					var invalidMessage = "";
					var division = this.getCurrencyDivision();
					if (division < 1 || division > 10000) {
						invalidMessage = this.get("Resources.Strings.InvalidDivisionValue");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * Validates Rate field.
				 * @protected
				 * @virtual
				 * @return {Object} Validation error messages config.
				 */
				rateValidator: function() {
					var invalidMessage = "";
					var rate = this.get("Rate");
					if (rate < 0) {
						invalidMessage = this.get("Resources.Strings.InvalidRateValue");
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * Sets rate column with rate info.
				 * @param {Object} currencyRateInfo Currency rate info.
				 * @param {Number} currencyRateInfo.Rate Currency rate.
				 * @param {Number} currencyRateInfo.RateMantissa Rate's mantissa.
				 */
				setRateFromEntity: function(currencyRateInfo) {
					currencyRateInfo = currencyRateInfo || {};
					var rate = currencyRateInfo.Rate || 0;
					var division = this.getCurrencyDivision();
					var rateMantissa = currencyRateInfo.RateMantissa || 0;
					if (rate) {
						const precision = this.getColumnPrecision("Rate");
						rate = this.calculateRate(division, rate, rateMantissa, precision);
					}
					this.set("Rate", rate);
				}
			},

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Name",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 0,
							"row": 0
						}
					}
				},
				{
					"operation": "insert",
					"name": "Code",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 0,
							"row": 1
						}
					}
				},
				{
					"operation": "insert",
					"name": "ShortName",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 0,
							"row": 2
						}
					}
				},
				{
					"operation": "insert",
					"name": "Symbol",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 0,
							"row": 3
						}
					}
				},
				{
					"operation": "insert",
					"name": "Rate",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 7,
							"row": 0
						},
						"wrapClass": ["alignable-currency-items"]
					}
				},
				{
					"operation": "insert",
					"name": "Division",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 6,
							"column": 7,
							"row": 1
						},
						"wrapClass": ["alignable-currency-items"]
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"name": "SymbolPositionLabel",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SymbolPositionLabel"},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"layout": {"column": 7, "row": 2, "colSpan": 6},
						"classes": {
							"labelClass": ["alignable-currency-items", "symbol-position-label"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"name": "CurrecySymbolPosition",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "CurrecySymbolPosition"},
						"items": [],
						"layout": {"column": 7, "row": 3, "colSpan": 6, "rowSpan": 2},
						"wrapClass": ["alignable-currency-items"]
					}
				},
				{
					"operation": "insert",
					"parentName": "CurrecySymbolPosition",
					"propertyName": "items",
					"name": "ShowOnLeft",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CurrecySymbolPositionLeft"},
						"value": 0
					}
				},
				{
					"operation": "insert",
					"parentName": "CurrecySymbolPosition",
					"propertyName": "items",
					"name": "ShowOnRight",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CurrecySymbolPositionRight"},
						"value": 1
					}
				},
				{
					"operation": "merge",
					"name": "Description",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 11,
							"column": 0,
							"row": 5
						}
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "CurrencyRate",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				}
			]/**SCHEMA_DIFF*/
		};
	});
