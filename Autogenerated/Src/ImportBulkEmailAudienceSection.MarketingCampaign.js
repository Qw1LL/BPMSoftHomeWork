define("ImportBulkEmailAudienceSection", ["ImportBulkEmailAudienceSectionResources"],
	function() {
		return {
			methods: {
				/**
				 * Returns specific config for bulk email audience service to provide import action.
				 * @protected
				 * @param {Number} sourceType Source type for import action.
				 * @param {Array} sourceCollection Source data collection to import.
				 * @param {Number} estimatedCount Estimated records count to import.
				 * @param {String} esqSerialized Serialized esq to filter records for import.
				 * @returns {Object}
				 */
				getImportConfig: function(sourceType, sourceCollection, estimatedCount, esqSerialized) {
					return {
						serviceName: "BulkEmailAudience",
						methodName: "Import",
						data: {
							BulkEmailId: this.$RecordId,
							SourceCollection: sourceCollection || [],
							EstimatedEntitiesCount: estimatedCount || 0,
							SourceType: sourceType,
							AudienceSchemaId: this.audienceSchemaId,
							EsqSerialized: esqSerialized
						}
					};
				}
			},
			diff: []
		};
	}
);
