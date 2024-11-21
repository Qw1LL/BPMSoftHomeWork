define("PRMportalLevelSchema", ["PRMEnums"], function() {
	return {
		entitySchemaName: "Partnership",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		attributes: {
			/**
			 * Partnership current level.
			 * @type {Integer}
			 */
			"CurrentLevel": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partnership max current level.
			 * @type {Integer}
			 */
			"MaxCurrentLevel": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"value": 0
			},
			/**
			 * Partner type.
			 * @type: {BPMSoft.DataValueType.LOOKUP}
			 */
			"PartnerType": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP
			},
			/**
			 * Partner level.
			 * @type: {BPMSoft.DataValueType.LOOKUP}
			 */
			"PartnerLevel": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP
			}
		},
		methods: {

			/**
			 * Creates ESQ instance.
			 * @private
			 * @param {String} Schema name.
			 * @return {BPMSoft.EntitySchemaQuery} esq.
			 */
			createESQ: function(schemaName) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: schemaName
				});
				return esq;
			},

			/**
			 * Handles entitySchemaQuery.getEntityCollection getCurrentValues query response.
			 * @private
			 * @param {Object} response entitySchemaQuery response.
			 */
			getCurrentValuesHandler: function(response) {
				if (response && response.success) {
					var collection = response.collection;
					if (collection && collection.getCount() > 0) {
						var currentRecord = collection.getByIndex(0);
						this.set("PartnerType", currentRecord.get("PartnerType"));
						this.set("PartnerLevel", currentRecord.get("PartnerLevel"));
						this.setCurrentLevels(currentRecord.get("Number"));
					}
				}
			},

			/**
			 * Handles entitySchemaQuery.getEntityCollection PartnerLevel query response.
			 * @private
			 * @param {Int} Current level.
			 * @param {Object} response entitySchemaQuery response.
			 */
			getPartnerLevelHandler: function(currentLevel, response) {
				if (response && response.success) {
					var collection = response.collection;
					if (collection && collection.getCount() > 0) {
						var maxLevel = collection.getByIndex(0).get("MaxNumber");
						this.set("MaxCurrentLevel", maxLevel);
						this.set("CurrentLevel", currentLevel);
					}
				}
			},

			/**
			 * Gets current value for round bar.
			 * @protected
			 */
			getCurrentValues: function() {
				var esq = this.createESQ("Partnership");
				this.addQueryColumns(esq);
				esq.filters = this.getQueryFilters();
				esq.getEntityCollection(this.getCurrentValuesHandler, this);
			},

			/**
			 * Sets max available partnership level.
			 * @protected
			 * @param {Object} esq query.
			 */
			addQueryColumns: function(esq) {
				esq.addColumn("PartnerLevel.Number", "Number");
				esq.addColumn("PartnerLevel.PartnerType", "PartnerType");
				esq.addColumn("PartnerLevel");
			},

			/**
			 * Get filters for esq query
			 * @protected
			 */
			getQueryFilters: function() {
				var filterGroup = this.BPMSoft.createFilterGroup();
				filterGroup.add("ActiveFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "IsActive", true));
				return filterGroup;
			},

			/**
			 * Sets max and current partnership level.
			 * @protected
			 * @param {Int} Current level.
			 */
			setCurrentLevels: function(currentLevel) {
				var partnerType = this.get("PartnerType");
				if (partnerType) {
					var esq = this.createESQ("PartnerLevel");
					esq.addAggregationSchemaColumn("Number", BPMSoft.AggregationType.MAX, "MaxNumber");
					var typeFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"PartnerType", partnerType.value);
					esq.filters.addItem(typeFilter);
					esq.getEntityCollection(function(response) {
						this.getPartnerLevelHandler(currentLevel, response);
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.getCurrentValues();
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "MainMetricsContainer",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["main-widget-metrics-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainMetricsContainer",
				"propertyName": "items",
				"name": "MetricsContainer",
				"values": {
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["widget-metrics-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MetricsContainer",
				"propertyName": "items",
				"name": "CurrentLevelContainer",
				"values": {
					"items": [],
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["widget-metric-item", "widget-days-in-funnel-container"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "CurrentLevelContainer",
				"propertyName": "items",
				"name": "CurrentLevelValue",
				"values": {
					"generator": "ConfigurationRoundProgressBarGenerator.generateProgressBar",
					"controlConfig": {
						"captionSuffix": "",
						"value": {"bindTo": "CurrentLevel"},
						"maxValue": {"bindTo": "MaxCurrentLevel"},
						"size": 105,
						"clockwise" : true,
						"borderWidth": 4,
						"classes": ["ts-font-light"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CurrentLevelContainer",
				"propertyName": "items",
				"name": "CurrentLevelCaptionContainer",
				"values": {
					"items": [],
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["widget-metric-item", "widget-days-in-funnel-container"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "CurrentLevelCaptionContainer",
				"propertyName": "items",
				"name": "CurrentLevelCaption",
				"values": {
					"caption": {"bindTo": "Resources.Strings.CurrentLevelCaption"},
					"classes": {"labelClass": ["widget-metric-item-caption"]},
					"itemType": BPMSoft.ViewItemType.LABEL
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {}
	};
});
