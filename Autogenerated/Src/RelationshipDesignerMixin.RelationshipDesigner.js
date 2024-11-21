define("RelationshipDesignerMixin", [
		"BPMSoft",
		"RelationshipDesignerModule",
		"css!RelationshipDesignerMixin"], function() {
	Ext.define("BPMSoft.configuration.mixins.RelationshipDesignerMixin", {
		alternateClassName: "BPMSoft.RelationshipDesignerMixin",

		// region Methods: Private
		
		_hasRelationshipContainer: function() {
			const isRelationshipContainer = Ext.get("RelationshipContainer");
			return !!isRelationshipContainer;
		},

		_updateRelationshipDesigner: function() {
			if (!Ext.isEmpty(this.$EntityInfo) && this.$EntityInfo.primaryColumnValue === this.$Id) {
				return false;
			}
			this.$EntityInfo = {
				primaryColumnValue: this.$Id,
				entitySchemaName: this.entitySchemaName
			};
			const moduleId = this.getRelationshipDesignerModuleSandboxId();
			return this.sandbox.publish("UpdateRelationshipDesigner", this.$EntityInfo, [moduleId]);
		},

		_isNeedShowRelationshipDesigner: function() {
			const useRelationshipDesigner = BPMSoft.Features.getIsEnabled("UseRelationshipDesigner");
			if (!useRelationshipDesigner || this.isNewMode() || (!this.$PrimaryColumnValue && !this.$Id)) {
				return false;
			}
			return true;
		},

		// endregion

		// region Methods: Public

		/**
		 * Subscribe sandbox events.
		 */
		subscribeSandboxEvents: function() {
			this.subscribeModuleEvents(null, "RelationshipDesigner");
		},

		/**
		 * Returns realtionship designer module sandbox id.
		 */
		getRelationshipDesignerModuleSandboxId: function() {
			return this.sandbox.id + "_RelationshipDesigner";
		},
		
		isNeedLoadRelationshipDesignerModule: function() {
			return this._isNeedShowRelationshipDesigner() &&
				!this._updateRelationshipDesigner() &&
				this._hasRelationshipContainer();
		},

		/**
		 * Load relationship module.
		 */
		loadRelationshipDesignerModule: function() {
			if(!this.isNeedLoadRelationshipDesignerModule()) {
				return;
			}
			const moduleId = this.getRelationshipDesignerModuleSandboxId();
			this.sandbox.loadModule("RelationshipDesignerModule", {
				id: moduleId,
				renderTo: "RelationshipContainer"
			});
		}

		// endregion
	});
});
