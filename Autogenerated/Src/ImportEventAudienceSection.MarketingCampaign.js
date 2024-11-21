define("ImportEventAudienceSection", ["ImportEventAudienceSectionResources"],
	function() {
		return {
			entitySchemaName: "Contact",
			properties: {
				rowsLimitForQuickQueue: 20
			},
			methods: {
				/**
				 * Returns specific config for event audience service to provide import action.
				 * @protected
				 * @param {Number} sourceType Source type for import action.
				 * @param {Array} sourceCollection Source data collection to import.
				 * @param {Number} estimatedCount Estimated records count to import.
				 * @param {String} esqSerialized Serialized esq to filter records for import.
				 * @returns {Object}
				 */
				getImportConfig: function(sourceType, sourceCollection, estimatedCount, esqSerialized) {
					return {
						serviceName: "EventAudience",
						methodName: "Import",
						data: {
							EventId: this.$RecordId,
							SourceCollection: sourceCollection || [],
							EstimatedEntitiesCount: estimatedCount || 0,
							SourceType: sourceType,
							EsqSerialized: esqSerialized
						}
					};
				}
			},
			diff: []
		};
	}
);
