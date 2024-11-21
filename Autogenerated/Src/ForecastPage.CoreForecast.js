define("ForecastPage", ["ForecastPageResources"],
	function(resources) {
		return {
			entitySchemaName: "Forecast",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.NameTip"}
						},
						"bindTo": "Name",
						"isRequired": true
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "PeriodType",
					"values": {
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.PeriodTypeTip"}
						},
						"bindTo": "PeriodType",
						"enabled": {"bindTo": "isNewMode"},
						"contentType": BPMSoft.ContentType.ENUM,
						"isRequired": true
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Dimension",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.DimensionTip"}
						},
						"bindTo": "Dimension",
						"enabled": {"bindTo": "isNewMode"},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {"bindTo": "prepareDimensionList"},
							"list": {"bindTo": "DimensionList"}
						}
					}
				},
				{
					"operation": "remove",
					"name": "actions"
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				 * Forecast dimension.
				 */
				"Dimension": {
					caption: resources.localizableStrings.DimensionFieldCaption,
					referenceSchemaName: "Dimension",
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isLookup: true,
					isRequired: true
				}
			},
			messages: {
				"SetForecastResult": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				* @inheritDoc BasePageV2#init
				* @protected
				* @overridden
				*/
				init: function(callback, scope) {
					const collection = Ext.create("BPMSoft.Collection");
					this.set("DimensionList", collection);
					this.callParent(arguments);
				},

				/**
				 * @private
				 */
				_initForecastColumnReferenceSchema: function(callback, scope) {
					const forecastEntitySchemaName = this.get("EntitySchemaName");
					this.BPMSoft.require([forecastEntitySchemaName], function(schema) {
						 this.set("ForecastColumnReferenceSchema", schema);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Returns mapping collection between dimension id and forecast entity in cell schema uid.
				 * @protected
				 * @virtual
				 * @return {Array} Mapping collection.
				 */
				getDimensionsSchemaMapping: function() {
					return [
						{
							dimensionId: "EB3F047A-8A99-4F21-A9C9-89263F51AD24",
							forecastEntityInCellUId: "74900C50-B7E7-452A-83D9-F98707756D6C" //AccountForecast
						},
						{
							dimensionId: "2650BF13-0D82-463B-B343-827DC41D2257",
							forecastEntityInCellUId: "367C714A-8BB9-4A02-B357-03C87FE7076C"	//ContactForecast
						},
						{
							dimensionId: "E92F945F-535E-4F80-A2CA-7243D5AB7673",
							forecastEntityInCellUId: "DBA8758C-3F3E-4DF2-83C7-DEC4EF8E22D5"	//LeadTypeForecast
						},
						{
							dimensionId: "51644F65-CA39-4699-AB1C-880268923D18",
							forecastEntityInCellUId: "C88D3CDA-460F-4C2C-A194-D7857DF830AF"	//OpportunityDepartmentForecast
						}
					];
				},

				/**
				 * Forms ForecastColumn Settings column value.
				 * @protected
				 * @param {BPMSoft.EntitySchema} schema ForecastColumn reference schema.
				 * @return {Object} Settings column value.
				 */
				formForecastColumnSettingValue: function(schema) {
					const dimension = this.get("Dimension");
					const periodColumn = this._getSchemaColumnByName(schema, "DueDate");
					const refColumn = this._getSchemaColumnByName(schema, dimension.Path);
					const config = {
						sourceUId: schema.uId,
						periodColumn: periodColumn && periodColumn.uId || "",
						refColumnId: refColumn && refColumn.uId || ""
					};
					return JSON.stringify(config);
				},

				/**
				 * @private
				 */
				_getSchemaColumnByName: function(schema, name) {
					return this.BPMSoft.findWhere(schema.columns, {"name": name});
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this._initForecastColumnReferenceSchema(function() {
						this.set("IsChanged", true);
						this.set("IsEntityInitialized", true);
						if (this.isAddMode()) {
							this.hideBodyMask();
							return;
						}
						const forecastId = (this.isCopyMode())
							? this.get("SourceEntityPrimaryColumnValue")
							: this.get("Id");
						if (this.isEmpty(forecastId)) {
							this.hideBodyMask();
							return;
						}
						if (this.getIsFeatureEnabled("ForecastV2")) {
							this.initDimensionFromForecastEntity();
						} else {
							this.initDimensionFromForecastDimension(forecastId);
						}
					}, this);
				},

				/**
				 * Initializes Dimension column from forecast settings.
				 * @protected
				 */
				initDimensionFromForecastEntity: function() {
					const forecastEntity = this.get("ForecastEntity");
					if (this.isEmpty(forecastEntity)) {
						this.hideBodyMask();
						return;
					}
					const esq = this.getDimensionQueryByForecastEntityId(forecastEntity.value);
					esq.getEntityCollection(this._processDimensionQueryByForecastEntityId, this);
				},

				/**
				 * @private
				 */
				_processDimensionQueryByForecastEntityId: function(queryResult) {
					if (queryResult.success && queryResult.collection && queryResult.collection.getCount() > 0) {
						const dimensionItem = queryResult.collection.first();
						const dimensionDisplayValue = {
							value: dimensionItem.get("Id"),
							displayValue: dimensionItem.get("Name"),
							EntitySchemaUId: dimensionItem.get("EntitySchemaUId"),
							EntitySchemaName: dimensionItem.get("EntitySchemaName"),
							Path: dimensionItem.get("Path")
						};
						this.set("Dimension", dimensionDisplayValue);
					}
					this.hideBodyMask();
				},

				/**
				 * Forms Dimension query filtering by column path.
				 * @protected
				 * @virtual
				 * @param {String} forecastEntityId Dimension entity id.
				 * @return {BPMSoft.EntitySchemaQuery} Dimension esq.
				 */
				getDimensionQueryByForecastEntityId: function(forecastEntityId) {
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Dimension"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("EntitySchemaUId");
					esq.addColumn("Path");
					esq.addColumn("[SysSchema:UId:EntitySchemaUId].Name", "EntitySchemaName");
					esq.filters.add(
						esq.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"EntitySchemaUId",
							forecastEntityId));
					return esq;
				},

				/**
				 * Forms ForecastDimension query filtering by forecast identifier.
				 * @protected
				 * @virtual
				 * @param {Guid} forecastId Forecast identifier.
				 * @return {BPMSoft.EntitySchemaQuery} Dimension esq.
				 */
				getForecastDimensionQueryByForecastId: function(forecastId) {
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ForecastDimension",
						rowCount: 1
					});
					esq.addColumn("Id");
					esq.addColumn("Dimension");
					esq.filters.add("ForecastFilter", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Forecast", forecastId));
					return esq;
				},

				/**
				 * Initializes Dimension column from ForecastDimension.
				 * @protected
				 * @param {Guid} forecastId Forecast identifier.
				 */
				initDimensionFromForecastDimension: function(forecastId) {
					const esq = this.getForecastDimensionQueryByForecastId(forecastId);
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							const collection = response.collection;
							if (collection.getCount() > 0) {
								const collectionItems = collection.getItems();
								const dimensionItem = collectionItems[0];
								const dimension = dimensionItem.get("Dimension");
								this.set("Dimension", dimension);
							}
						}
						this.hideBodyMask();
					}, this);
				},

				/**
				 * Fills Dimension collection.
				 * @protected
				 * @virtual
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.Collection} list List to fill.
				 */
				prepareDimensionList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Dimension"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					esq.addColumn("Path");
					esq.addColumn("EntitySchemaUId");
					esq.addColumn("[SysSchema:UId:EntitySchemaUId].Name", "EntitySchemaName");
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							return;
						}
						const collectionItems = result.collection.getItems();
						const columns = {};
						if (collectionItems.length > 0) {
							BPMSoft.each(collectionItems, function(item) {
								const itemId = item.get("Id");
								const itemName = item.get("Name");
								const columnPath = item.get("Path");
								const entitySchemaUId = item.get("EntitySchemaUId");
								const entitySchemaName = item.get("EntitySchemaName");
								if (!list.contains(itemId)) {
									columns[itemId] = {
										displayValue: itemName,
										value: itemId,
										Path: columnPath,
										EntitySchemaUId: entitySchemaUId,
										EntitySchemaName: entitySchemaName
									};
								}
							}, this);
							list.loadAll(columns);
						}
					}, this);
				},

				/**
				 * Binds chosen dimension to current forecast.
				 */
				addDimension: function() {
					const forecastId = this.get("Id");
					const dimension = this.get("Dimension");
					if (!dimension) {
						return;
					}
					const dataSend = {
						forecastId: forecastId,
						dimensionId: dimension.value,
						level: 1
					};
					const config = {
						serviceName: "ForecastService",
						methodName: "AddDimensionToForecast",
						data: dataSend
					};
					this.callService(config, BPMSoft.emptyFn, this);
				},

				/**
				 * Adds forecast columns.
				 * @param {function} callback Callback function.
				 * @private
				 */
				_addForecastColumns: function(callback) {
					this.loadForecastIndicators(function(indicators) {
						if (indicators.success) {
							var batch = this.getInsertForecastColumnBatch(indicators.collection);
							batch.execute(function(response) {
								if (response.success) {
									Ext.callback(callback, this);
								}
							}, this);
						}
					});
				},

				/**
				 * Loads forecast indicators.
				 * @param {function} callback Callback.
				 * @protected
				 */
				loadForecastIndicators: function(callback) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ForecastIndicator"
					});
					esq.addColumn("Id");
					const sortColumn = esq.addColumn("Position");
					sortColumn.orderPosition = 0;
					sortColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
					esq.getEntityCollection(function(response) {
						Ext.callback(callback, this, [response]);
					}, this);
				},

				/**
				 * Returns batch query of forecast column insert.
				 * @param {BPMSoft.Collection} indicators Forecast indicators.
				 * @return {BPMSoft.BatchQuery} Batch query of forecast column insert.
				 * @protected
				 */
				getInsertForecastColumnBatch: function(indicators) {
					const referenceSchema = this.get("ForecastColumnReferenceSchema");
					const forecastColumnSettingValue = this.formForecastColumnSettingValue(referenceSchema);
					const batchQuery = Ext.create("BPMSoft.BatchQuery");
					indicators.each(function(indicator) {
						const insertEsq = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ForecastColumn"
						});
						insertEsq.setParameterValue("Sheet", this.$Id, BPMSoft.DataValueType.GUID);
						insertEsq.setParameterValue("Indicator", indicator.$Id, BPMSoft.DataValueType.GUID);
						insertEsq.setParameterValue("Position", indicator.$Position, BPMSoft.DataValueType.INTEGER);
						insertEsq.setParameterValue("Settings", forecastColumnSettingValue,
							BPMSoft.DataValueType.TEXT);
						batchQuery.add(insertEsq);
					}, this);
					return batchQuery;
				},

				/**
				 * @inheritDoc BPMSoft.BasePage#save
				 * @override
				 */
				save: function() {
					if (this.getIsFeatureEnabled("ForecastV2")) {
						this.initReferencedSchemaValues();
					}
					this.callParent(arguments);
				},

				/**
				 * Initializes forecast settings according to chosen values.
				 * @protected
				 */
				initReferencedSchemaValues: function(){
					const dimension = this.get("Dimension");
					this.set("ForecastEntity", {
						value: dimension.EntitySchemaUId,
						displayValue: dimension.EntitySchemaName
					});
					const mappingCollection = this.getDimensionsSchemaMapping();
					const foundItem = this.BPMSoft.findItem(mappingCollection,
						{dimensionId: dimension.value.toUpperCase()}) || {};
					const mappingItem = foundItem.item || {};
					this.set("ForecastEntityInCellUId", mappingItem.forecastEntityInCellUId);
				},

				/**
				 * @inheritdoc BPMSoft.BasePage#onSaved
				 * @override
				 */
				onSaved: function(response) {
					if (response.success) {
						if (!this.isEditMode()) {
							if (this.getIsFeatureEnabled("ForecastV2")) {
								this._addForecastColumns(function() {
									this._publishSetForecastResult();
									this.onCloseCardButtonClick();
									this.hideBodyMask();
								});
								return;
							} else {
								this.addDimension();
							}
						}
						this._publishSetForecastResult();
					}
					this.onCloseCardButtonClick();
					this.hideBodyMask();
				},

				/**
				 * Publishs forecast result.
				 * @private
				 */
				_publishSetForecastResult: function() {
					const result = {
						forecastId: this.get("Id"),
						forecastName: this.get("Name")
					};
					if (this.getIsFeatureEnabled("ForecastV2")) {
						const forecastEntity = this.$ForecastEntity;
						result.forecastForecastEntityInCellUId = this.get("ForecastEntityInCellUId");
						result.forecastEntityId = forecastEntity.value;
						result.forecastEntityName = forecastEntity.displayValue;
					}
					this.sandbox.publish("SetForecastResult", result, [this.sandbox.id]);
				},

				/**
				 * @inheritDoc BasePageV2#onDiscardChangesClick
				 * @protected
				 * @overridden
				 */
				onDiscardChangesClick: function() {
					this.sandbox.publish("BackHistoryState");
				}
			},
			rules: {},
			userCode: {}
		};
	});
