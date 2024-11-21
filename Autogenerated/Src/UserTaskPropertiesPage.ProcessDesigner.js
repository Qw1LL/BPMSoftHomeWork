/**
 * Parent: SubProcessPropertiesPage
 */
define("UserTaskPropertiesPage", ["BPMSoft", "UserTaskPropertiesPageResources", "ProcessModuleUtilities"],
		function(BPMSoft, resources, Utilities) {
	return {
		properties: {
			/**
			 * @inheritdoc RootUserTaskPropertiesPage.properties#schemaManagerName
			 * @override
			 */
			schemaManagerName: "ProcessUserTaskSchemaManager"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc SubProcessPropertiesPage#initSchema
			 * @override
			 */
			initSchema: function(element, callback, scope) {
				this.on("change:Schema", this.onBeforeSchemaChanged, this);
				var schemaUId = element.schemaUId;
				if (BPMSoft.isEmpty(schemaUId)) {
					callback.call(scope);
					return;
				}
				this.getSchemaByUId(schemaUId, function(schema) {
					this.set("Schema", schema, {silent: true});
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaListFilter
			 * @override
			 */
			getSchemaListFilter: function(callback) {
				this.callParent([function(filter) {
					var esq = new BPMSoft.EntitySchemaQuery("SysProcessUserTask");
					esq.addColumn("SysUserTaskSchemaUId");
					esq.getEntityCollection(function(result) {
						var collection = result.collection;
						if (collection && collection.getCount() > 0) {
							var excludedSchemas = filter.ExcludedSchemas;
							collection.each(function(row) {
								excludedSchemas.push(row.get("SysUserTaskSchemaUId"));
							}, this);
							callback(filter);
						}
					}, this);
				}]);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaList
			 * @override
			 */
			getSchemaList: function(callback, scope) {
				scope = scope || this;
				this.getSchemaListFilter(function(filter) {
					Utilities.getSchemasByFilter(filter, callback, scope);
				});
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#onOpenSchemaDesignerButtonClick
			 * @override
			 */
			onOpenSchemaDesignerButtonClick: function() {
				var schemaUId = this.get("Schema").value;
				Utilities.showUserTaskSchemaDesigner(schemaUId);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#synchronizeParameters
			 * @override
			 */
			synchronizeParameters: function(processElement, userTaskSchema) {
				this.callParent(arguments);
				this.initIsAfterActivitySaveScriptEditVisible(userTaskSchema, BPMSoft.emptyFn, this);
			},

			/**
			 * @inheritdoc SubProcessPropertiesPage#getSchemaInstance
			 * @override
			 */
			getSubProcessSchemaInstance: function(schemaUId, callback, scope) {
				if (BPMSoft.isEmpty(schemaUId)) {
					Ext.callback(callback, scope);
				} else {
					BPMSoft.ProcessUserTaskSchemaManager.forceGetInstanceByUId(schemaUId, callback, scope);
				}
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/[
			{
			"operation": "merge",
			"name": "OpenSchemaDesignerButton",
			"values": {
					"hint": {"bindTo": "Resources.Strings.OpenSchemaButtonHintCaption"},
					"imageConfig": {"bindTo": "Resources.Images.OpenButtonImage"},
					"enabled": {"bindTo": "Schema"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
