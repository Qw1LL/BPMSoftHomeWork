define("RelationshipDesignerModule", ["BaseModule", "RelationshipDesignerComponent"], function() {
	Ext.define("BPMSoft.RelationshipDesignerModule", {
		extend: "BPMSoft.configuration.BaseModule",

		messages: {
			"GetColumnsValues": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetEntityInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"UpdateRelationshipDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},

		// region Methods: Private

		_getMasterEntityInfo: function() {
			return this.sandbox.publish("GetEntityInfo", null, [this.sandbox.id]);
		},

		_subscribeUpdateDesignerMessage: function() {
			this.sandbox.subscribe(
				"UpdateRelationshipDesigner", this._onUpdateRelationshipDesigner, this, [this.sandbox.id]);
		},

		_onUpdateRelationshipDesigner: function(entityInfo) {
			if (!this.relationshipComponent || this.relationshipComponent.destroyed) {
				return false;
			}
			return this.relationshipComponent.setDiagramData({
				selectedRecordId: entityInfo.primaryColumnValue,
				schemaName: entityInfo.entitySchemaName
			});
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseModule#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages(this.messages);
			this._subscribeUpdateDesignerMessage();
		},

		/**
		 * Render designer.
		 * @param {Ext.Element} renderTo Container to render designer.
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this.relationshipComponent = this.Ext.create("BPMSoft.RelationshipDesignerComponent", {
				id: "relationship-designer-component",
				classes: {
					wrapClassName: ["diagram", "ts-box-sizing"]
				}
			});
			const diagramContainer = this.Ext.create("BPMSoft.Container", {
				id: "relationship-designer-ct",
				classes: {
					wrapClassName: ["schema-designer", "ts-box-sizing"]
				},
				items: [this.relationshipComponent]
			});
			const masterEntityInfo = this._getMasterEntityInfo();
			this.relationshipComponent.setDiagramData({
				selectedRecordId: masterEntityInfo.primaryColumnValue,
				schemaName: masterEntityInfo.entitySchemaName
			});
			diagramContainer.render(renderTo);
		},

		/**
		 * @inheritDoc BPMSoft.BaseModule#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			if (this.relationshipComponent) {
				this.relationshipComponent = null;
			}
			this.callParent(arguments);
		}

		// endregion

	});

	return BPMSoft.RelationshipDesignerModule;
});
