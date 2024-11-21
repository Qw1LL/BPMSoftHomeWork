define("AccountPageV2", ["RelationshipDesignerMixin"], function() {
	return {
		attributes: {
			"UseRelationshipDesigner": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": BPMSoft.Features.getIsEnabled("UseRelationshipDesigner")
			}
		},
		messages: {
			"UpdateRelationshipDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			RelationshipDesignerMixin: "BPMSoft.RelationshipDesignerMixin"
		},
		methods: {

			// region Methods: Protected

			/**
			 * @override BPMSoft.BasePageV2#subscribeSandboxEvents
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.mixins.RelationshipDesignerMixin.subscribeSandboxEvents.apply(this, arguments);
			},

			/**
			 * @override BPMSoft.BaseSchemaViewModel#getModuleId
			 */
			getModuleId: function(moduleName) {
				if (moduleName === "RelationshipDesigner") {
					return this.mixins.RelationshipDesignerMixin.getRelationshipDesignerModuleSandboxId.apply(this);
				}
				return this.callParent(arguments);
			},

			/**
			 * @override BPMSoft.BaseEntityPage#updateDetails
			 */
			updateDetails: function() {
				this.callParent(arguments);
				this.loadRelationshipDesignerModule();
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "TabsContainer",
				"values": {
					"wrapClass": ["tabs-container"]
				}
			},
			{
				"operation": "merge",
				"name": "Relationships",
				"values": {
					"visible": {
						"bindTo": "UseRelationshipDesigner",
						"bindConfig": { "converter": "invertBooleanValue" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "RelationshipContainer",
				"parentName": "RelationshipTabContainer",
				"propertyName": "items",
				"values": {
					"id": "RelationshipContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"afterrerender": { "bindTo": "loadRelationshipDesignerModule" },
					"afterrender": { "bindTo": "loadRelationshipDesignerModule" },
					"visible": {
						"bindTo": "UseRelationshipDesigner"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
