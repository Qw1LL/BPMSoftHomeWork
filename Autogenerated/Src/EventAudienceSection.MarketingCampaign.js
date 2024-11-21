 define("EventAudienceSection", ["EventAudienceSectionResources"],
	function() {
		return {
			entitySchemaName: "EventTarget",
			properties: {
				masterRecordEntitySchemaName: "Event",
				rowsLimitForQuickQueue: 20
			},
			methods: {
				/**
				 * Returns specific config for event audience service to provide remove audience action.
				 * @protected
				 * @param {Number} sourceType Source type for remove action.
				 * @param {Array} sourceCollection Source data collection to remove.
				 * @param {Number} estimatedCount Estimated records count to remove.
				 * @param {String} esqSerialized Serialized esq to filter records for remove.
				 * @returns {Object}
				 */
				getRemoveAudienceConfig: function(sourceType, sourceCollection, estimatedCount, esqSerialized) {
					return {
						serviceName: "EventAudience",
						methodName: "Remove",
						data: {
							EventId: this.$RecordId,
							SourceCollection: sourceCollection || [],
							EstimatedEntitiesCount: estimatedCount || 0,
							SourceType: sourceType,
							EsqSerialized: esqSerialized
						}
					};
				},

				/**
				 * Handler on WebSocket channel message received event.
				 * @inheritdoc BPMSoft.BaseManageAudienceSection#onChannelMessageReceived
				 * @override
				 */
				onChannelMessageReceived: function(channel, message) {
					if (message.Header.Sender !== "EventQueueMessageNotifier") {
						return;
					}
					var messageBody = BPMSoft.decode(message.Body);
					if (messageBody.EventId === this.$RecordId) {
						this.updateSection();
					}
				}
			},
			diff: []
		};
	}
);
