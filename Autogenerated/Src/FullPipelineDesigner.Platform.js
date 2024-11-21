define("FullPipelineDesigner", ["DashboardEnums"], function() {
	return {
		messages: {

			/**
			 * @message GetChartConfig
			 * Message of parameter preparing for widget module.
			 */
			"GetChartConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message PostItemConfig
			 * Message of parameters changes.
			 */
			"PostItemConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message RefreshFullPipelineWidget
			 * Message of refresh pipe line widget.
			 */
			"RefreshFullPipelineWidget": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Style color of full pipeline widget.
			 */
			"StyleColor": {
				"value": BPMSoft.DashboardEnums.WidgetColor["widget-orange"],
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Entities for widget.
			 */
			"entities": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Collection of entities configuration.
			 */
			"EntityCollection": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {
			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#getWidgetRefreshMessage
			 * @override
			 */
			getWidgetRefreshMessage: function() {
				return "RefreshFullPipelineWidget";
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#getWidgetModuleName
			 * @override
			 */
			getWidgetModuleName: function() {
				return "FullPipelineModule";
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#getWidgetConfigMessage
			 * @override
			 */
			getWidgetConfigMessage: function() {
				return "GetChartConfig";
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#getWidgetModulePropertiesTranslator
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				var properties = this.callParent(arguments);
				this.Ext.apply(properties, {
					"StyleColor": "styleColor",
					"entities": "entities"
				});
				return properties;
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#setWidgetModuleProperties
			 * @override
			 */
			setWidgetModuleProperties: function(widgetConfig, callback, scope) {
				this.callParent([
					widgetConfig, function() {
						if (this.Ext.isEmpty(this.$entities)) {
							this.$entities = this._getDefaultEntities();
						}
						this.fillEntityCollection();
						this.set("moduleLoaded", true);
						this.Ext.callback(callback, scope || this);
					}, scope || this
				]);
			},

			/**
			 * Fills the entity collection.
			 * @protected
			 */
			fillEntityCollection: function() {
				this.$EntityCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.BPMSoft.each(this.$entities, function(item) {
					const schemaName = item.schemaName;
					const id = "FullPipelinePropertiesItemModule" + schemaName;
					const model = this.Ext.create("BPMSoft.BaseViewModel", {
						values: item
					});
					model.Ext = this.Ext;
					model.BPMSoft = this.BPMSoft;
					model.sandbox = this.sandbox;
					model.id = id;
					model.renderPropertiesItem = this.renderPropertiesItem;
					this.$EntityCollection.add(schemaName, model);
					this.subscribePostItemConfigItems([id]);
				}, this);
			},

			/**
			 * Subscribes on item parameters changes message.
			 * @param {String[]} tags Tags for filtering messages
			 */
			subscribePostItemConfigItems: function(tags) {
				this.sandbox.subscribe("PostItemConfig", function(config) {
					this._applyItemFilters(config);
				}, this, tags);
			},

			/**
			 * Applies item filters.
			 * @param {Object} config Changed config.
			 * @private
			 */
			_applyItemFilters: function(config) {
				const entities = this.BPMSoft.deepClone(this.$entities);
				const findResult = this.BPMSoft.findItem(entities, {
					schemaName: config.schemaName
				});
				const foundItem = findResult && findResult.item;
				foundItem.filters = config.serializedFilter;
				this.set("entities", entities);
			},

			/**
			 * @private
			 */
			_getDefaultEntities: function() {
				return [
					{
						"schemaName": "Lead",
						"connectedWith": null,
						"calculatedOperations": [{"operation": "Amount", "targetColumnName": "Budget"}],
						"filters": null
					},
					{
						"schemaName": "Opportunity",
						"calculatedOperations": [{"operation": "Amount", "targetColumnName": "Budget"}],
						"connectedWith": {
							"type": 0,
							"schemaName": "Lead",
							"connectionSchemaName": "Lead",
							"parentSchemaColumnName": "Opportunity",
							"childSchemaColumnName": "Id"
						},
						"filters": null
					}
				];
			},

			/**
			 * Returns item view config.
			 * @param {Object} itemConfig Item config.
			 * @return {Object} Item view config.
			 */
			getItemViewConfig: function(itemConfig) {
				itemConfig.config = {
					id: "Item",
					className: "BPMSoft.Container",
					items: [],
					afterrender: {bindTo: "renderPropertiesItem"}
				};
				return itemConfig;
			},

			/**
			 * Renders properties item.
			 */
			renderPropertiesItem: function() {
				var schemaName = this.$schemaName;
				var renderTo =  this.Ext.String.format("Item-{0}-{1}", schemaName, this.sandbox.id);
				this.sandbox.loadModule("FullPipelinePropertiesItemModule", {
					renderTo: renderTo,
					id: this.id,
					instanceConfig: {
						parameters: {
							viewModelConfig: {
								SchemaName: schemaName,
								Filters: this.$filters
							}
						}
					}
				});
			}

		},
		diff: [
			{
				"operation": "insert",
				"name": "EntitiesContainer",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["widget-properties-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EntitiesList",
				"parentName": "EntitiesContainer",
				"propertyName": "items",
				"values": {
					"visible": BPMSoft.Features.getIsEnabled("FullPipelineDesigner"),
					"idProperty": "schemaName",
					"dataItemIdPrefix": "schema-properties",
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"collection": "EntityCollection",
					"onGetItemConfig": "getItemViewConfig"
				}
			}
		]
	};
});
