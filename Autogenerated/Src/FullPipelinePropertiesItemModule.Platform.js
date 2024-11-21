 define("FullPipelinePropertiesItemModule", ["css!FullPipelinePropertiesItemModule"], function() {
	 Ext.define("BPMSoft.configuration.FullPipelinePropertiesItemModule", {
		 extend: "BPMSoft.BaseSchemaModule",
		 alternateClassName: "BPMSoft.FullPipelinePropertiesItemModule",

		 /**
		  * Schema name.
		  */
		 schemaName: "FullPipelineDesignerPropertiesItem",

		 /**
		  * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		  * @override
		  */
		 useHistoryState: false,

		 /**
		  * @inheritDoc BPMSoft.BaseSchemaModule#isSchemaConfigInitialized
		  * @override
		  */
		 isSchemaConfigInitialized: true,

		 /**
		  * @inheritDoc BPMSoft.BaseSchemaModule#getViewContainerId
		  * @override
		  */
		 getViewContainerId: function() {
			 var id = this.callParent(arguments);
			 var entitySchemaName = this._getEntitySchemaName();
			 return entitySchemaName + id;
		 },

		 /**
		  * @inheritDoc BPMSoft.BaseSchemaModule#getElementsPrefix
		  * @override
		  */
		 getElementsPrefix: function() {
			 return this._getEntitySchemaName();
		 },

		 /**
		  * Returns entity schema name.
		  * @return {String} Entity schema name.
		  * @private
		  */
		 _getEntitySchemaName: function() {
			 return this.parameters.viewModelConfig.SchemaName;
		 }

	 });

	 return BPMSoft.FullPipelinePropertiesItemModule;

 });
