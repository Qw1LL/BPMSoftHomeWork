define("SspPageDesignerSchema", [], function() {
	return {
		attributes: {},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.Ext.callback(callback, scope);
					this.$DataModels.get("Elements").$IsPageElementsVisible = false;
					this.$DataModels.removeByKey("Parameters");
					this.$SupportParametersDataModel = false;
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#saveDesignData
			 * @override
			 */
			saveDesignData: function () {
				this.set("IsSspSection", true);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#getDetailEntitySchema
			 * @override
			 */
			getDetailEntitySchema: function() {
				const firstDataModel = this.dataModelCollection.first();
				return firstDataModel && firstDataModel.designSchema;
			},

			/**
			* @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#onAfterSave
			* @override
			*/
			onAfterSave: function () {
				this.callParent(arguments);
				this.callService(this.getSspSchemaAccessServiceConfig(), BPMSoft.emptyFn, this);
			},

			/**
			 * Returns service config.
			 * @protected
			 * @returns {Object} Service config.
			 */
			getSspSchemaAccessServiceConfig: function () {
				return {
					data: {
						"entitySchemaUId": this.getDetailEntitySchema().parentUId,
						"cardSchemaUId": this.$PageSchema.parentSchemaUId
					},
					serviceName: "SspSchemaAccessService",
					methodName: "AllowRelatedEntitiesOnSsp"
				};
			}

		},
		diff: /**SCHEMA_DIFF*/[
		]/**SCHEMA_DIFF*/
	};
});
