define("ProcessCardModuleMixin", ["ConfigurationEnumsV2"],
	function() {
		Ext.define("BPMSoft.configuration.mixins.ProcessCardModuleMixin", {
			alternateClassName: "BPMSoft.ProcessCardModuleMixin",

			/**
			 * Module name for process card showing.
			 * @private
			 * @type {String}
			 */
			processCardModuleName: "ProcessCardModuleV2",

			/**
			 * Indicates that conditions satisfy for trying to show process card for the current entity.
			 * @param {Object} historyHash History state hash.
			 * @return {Boolean} True if process card could try to show for the current entity.
			 */
			getCanTryShowProcessCard: function(historyHash) {
				if (historyHash.operationType === BPMSoft.ConfigurationEnums.CardOperation.COPY) {
					return false;
				}
				const entityName = historyHash.entityName;
				return (entityName === "ActivityPageV2" || entityName === "EmailPageV2") &&
					historyHash.recordId && !BPMSoft.isEmptyGUID(historyHash.recordId) &&
					historyHash.moduleName !== this.processCardModuleName;
			},

			/**
			 * Tries to show process card for the current entity.
			 * @param {Object} config Execution config.
			 * @param {String} config.recordId Entity primary column value.
			 * @param {Function} callback The callback function.
			 * @param {Boolean} callback.isRedirected Indicates that browser was redirected to a process card page.
			 */
			tryShowProcessCard: function(config, callback) {
				var recordId = config.recordId;
				if (!recordId) {
					callback(false);
					return;
				}
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "Activity"
				});
				esq.addColumn("ProcessElementId");
				esq.enablePrimaryColumnFilter(recordId);
				esq.execute(function(response) {
					if (response.success && !response.collection.isEmpty()) {
						var entity = response.collection.getByIndex(0);
						var processElementId = entity.get("ProcessElementId");
						if (processElementId) {
							var messages = {
								"ProcessExecDataChanged": {
									"mode": BPMSoft.MessageMode.PTP,
									"direction": BPMSoft.MessageDirectionType.PUBLISH
								}
							};
							this.sandbox.registerMessages(messages);
							this.sandbox.publish("ProcessExecDataChanged", {
								procElUId: processElementId,
								recordId: recordId,
								forceReplaceHistoryState: true
							});
							callback(true);
							return;
						}
					}
					callback(false);
				}, this);
			}
		});
	});
