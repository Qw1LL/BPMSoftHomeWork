define("FullPipelineDesignerPropertiesItem", [], function() {
	return {
		messages: {

			/**
			 * @message GetFilterModuleConfig
			 * Returns settings for the filter unit.
			 */
			"GetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message OnFiltersChanged
			 * Subscription for the filter unit modification event.
			 */
			"OnFiltersChanged": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetFilterModuleConfig
			 * Publishes filter config to filter module.
			 */
			"SetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message PostItemConfig
			 * Message of parameters changes.
			 */
			"PostItemConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Schema name
			 */
			"SchemaName": {
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},

			/**
			 * Filters
			 */
			"Filters": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * Loads filter module.
			 * @param {Object} viewConfig View config.
			 */
			loadFilterModule: function(viewConfig) {
				var moduleId = this.getFilterEditModuleId();
				this.sandbox.subscribe("OnFiltersChanged", this.publishFiltersChanged, this, [moduleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", this.getFilterModuleConfig, this, [moduleId]);
				this.sandbox.loadModule("FilterEditModule", {
					renderTo: viewConfig.containerId,
					id: moduleId
				});
			},

			/**
			 * Returns filter module config.
			 * @return {Object} Filter config.
			 */
			getFilterModuleConfig: function() {
				return {
					rootSchemaName: this.$SchemaName,
					filters: this.$Filters
				};
			},

			/**
			 * Publishes filters changed.
			 * @param args
			 */
			publishFiltersChanged: function(args) {
				this.$Filters = args.filter.serialize();
				this.sandbox.publish("PostItemConfig", {
					schemaName: this.$SchemaName,
					serializedFilter: args.serializedFilter
				}, [this.sandbox.id]);
			},

			/**
			 * Returns filter module identifier.
			 * @return {String} Filter module identifier.
			 * @protected
			 */
			getFilterEditModuleId: function() {
				return this.sandbox.id + "_ExtendedFilterEditModule";
			},

			/**
			 * Returns filter group caption.
			 * @return {String} Filter group caption.
			 */
			getFilterGroupCaption: function() {
				const captionTemplate = this.get("Resources.Strings.FilterPropertiesLabel");
				const module = BPMSoft.ModuleUtils.getModuleStructureByName(this.$SchemaName);
				const schemaCaption = module.moduleCaption;
				return this.Ext.String.format(captionTemplate, schemaCaption.toLowerCase());
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "FullPipelineDesignerItem",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FilterPropertiesGroup",
				"parentName": "FullPipelineDesignerItem",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "getFilterGroupCaption"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FilterProperties",
				"parentName": "FilterPropertiesGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"makeUniqueId": true,
					"itemType": BPMSoft.ViewItemType.MODULE,
					"afterrender": {"bindTo": "loadFilterModule"},
					"items": []
				}
			}
		]
	};
});
