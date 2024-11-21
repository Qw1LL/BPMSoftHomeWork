define("BaseModulePageV2", ["TimelineManager"],
	function() {
		return {
			methods: {

				// region Methods: Private

				/**
				 * Hides Timeline tab from page tabs collection.
				 * @private
				 */
				_removeTimelineTab: function() {
					var tabs = this.get("TabsCollection");
					tabs.removeByKey("TimelineTab");
				},

				// endregion

				// region Methods: Protected

				/**
				 * Checks if timeline config for current page exists.
				 * @protected
				 * @return {Boolean} True if timeline config for current page is defined, otherwise false.
				 */
				hasTimelineConfig: function() {
					var timelinePageConfig = this.BPMSoft.TimelineManager.getTimelinePageConfig(this.name);
					return !this.isEmpty(timelinePageConfig);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#initTabs
				 * @override
				 */
				initTabs: function() {
					if (!this.hasTimelineConfig()) {
						this._removeTimelineTab();
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function(callback, scope) {
					var parentInitMethod = this.getParentMethod();
					this.BPMSoft.TimelineManager.initialize(function() {
						parentInitMethod.call(this, callback, scope);
					}, this);
				}

				// endregion

			},
			modules: /**SCHEMA_MODULES*/ {
				"Timeline": {
					"config": {
						"schemaName": "TimelineSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"CardSchemaName": {
									"propertyValue": "name"
								},
								"ReferenceSchemaName": {
									"propertyValue": "entitySchemaName"
								},
								"InitialConfig": {
									"entities": []
								}
							}
						}
					}
				}
			} /**SCHEMA_MODULES*/,
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "TimelineTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.TimelineTabCaption"
					},
					"items": [],
					"order": 3
				}
			}, {
				"operation": "insert",
				"parentName": "TimelineTab",
				"name": "TimelineTabContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "TimelineTabContainer",
				"propertyName": "items",
				"name": "Timeline",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.MODULE
				}
			}] /**SCHEMA_DIFF*/
		};
	});
