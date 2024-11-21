define("ActivityMiniPage", [], function() {
	return {
		entitySchemaName: "Activity",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {
			/**
			 * Returns sign of visibility.
			 * @return {Boolean} True if is not SSP user.
			 */
			getOpenCurrentEntityPageVisible: function() {
				return !this.BPMSoft.isCurrentUserSsp();
			},

			/**
			 * @inheritDoc BPMSoft.EntityConnectionLinksUtilities#loadEntityConnectionsByESQ
			 * @override
			 */
			loadEntityConnectionsByESQ: function (esq) {
				if (this.BPMSoft.isCurrentUserSsp()) {
					this._removeUnnecessaryFiltersFromQuery(esq);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.EntityConnectionLinksUtilities#addEntityConnectionsColumns
			 * @override
			 */
			addEntityConnectionsColumns: function(esq) {
				this.callParent(arguments);
				if (this.BPMSoft.isCurrentUserSsp()) {
					esq.columns.removeByKey("SysSchemaName");
					esq.addParameterColumn(this.entitySchemaName, this.BPMSoft.DataValueType.TEXT, "SysSchemaName");
				}
			},

			/**
			 * @inheritDoc BPMSoft.EntityConnectionLinksUtilities#processEntityConnectionsResponse
			 * @override
			 */
			processEntityConnectionsResponse: function(collection) {
				if (this.BPMSoft.isCurrentUserSsp()) {
					const filtered = collection.filterByFn(function(entityConnection) {
						const schemaName = entityConnection.$ReferenceSchema && entityConnection.$ReferenceSchema.name;
						return schemaName && this.isNotEmpty(this.getEntityStructure(schemaName));
					}, this);
					collection.reloadAll(filtered);
				}
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_removeUnnecessaryFiltersFromQuery: function(esq) {
				esq.filters.removeByKey("EntitySchema");
				esq.filters.removeByKey("SysWorkspace");
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "OpenCurrentEntityPage",
				"values": {
					"visible": {
						"bindTo": "getOpenCurrentEntityPageVisible"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
