define("SectionActionsDashboard", ["SectionActionsDashboardResources"],
	function() {
		return {
			attributes: {},
			messages: {
				/**
				 * @message SaveMasterEntity
				 * Message of saving the listener card.
				 */
				"SaveMasterEntity": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message GetListenerRecordInfo
				 * Message of getting the listener record information.
				 */
				"GetListenerRecordInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				/**
				 * Returns array of publishers by section identifier.
				 * @protected
				 * @return {Array} Section's publishers
				 */
				getSectionPublishers: function() {
					var publishers = [];
					return publishers;
				},

				/**
				 * Returns tab name using publisher name.
				 * @protected
				 * @param {String} name Publisher name.
				 * @return {String} Tab's name.
				 */
				getPublisherNameByTabName: function(name) {
					if (!name) {
						return;
					}
					return name.replace("MessageTab", "");
				},

				/**
				 * Returns true if tab name is publisher type tab.
				 * @protected
				 * @param {String} name Tab's name
				 * @return {Boolean} Is publisher tab
				 */
				isPublisherTab: function(name) {
					return this.Ext.String.endsWith(name, "MessageTab");
				},

				/**
				 * Returns identifier of message publisher module.
				 * @protected
				 * @virtual
				 * @return {Array} Identifiers of message publishers module.
				 */
				getMessagePublishersModuleIds: function() {
					var publishers = this.getSectionPublishers();
					var messagePublishersSandboxIds = [];
					var sandboxId = this.sandbox.id;
					this.BPMSoft.each(publishers, function(item) {
						messagePublishersSandboxIds.push(sandboxId + "_" + item + "MessagePublisherModule");
					}, this);
					return messagePublishersSandboxIds;
				},

				/**
				 * @inheritdoc BPMSoft.BaseActionsDashboard#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetListenerRecordInfo", this.onGetRecordInfoForPublisher, this, [this.sandbox.id]);
					this.sandbox.subscribe("SaveMasterEntity", this.saveMasterEntity, this, this.getMessagePublishersModuleIds());
				},

				/**
				 * Returns information about record for subscriber message module.
				 * @protected
				 * @virtual
				 * @return {Object} Record information.
				 */
				onGetRecordInfoForPublisher: function() {
					var activityConfig = this.getDashboardItemsConfig("Activity");
					var relationColumnName = activityConfig.referenceColumnName;
					var relationSchemaName = activityConfig.referenceColumnSchemaName || relationColumnName;
					var relationSchemaUId = this.BPMSoft.configuration.ModuleStructure[relationSchemaName].entitySchemaUId;
					var relationSchemaRecordId = this.getMasterEntityParameterValue(activityConfig.masterColumnName);
					var relationSchemaOperation = this.getMasterEntityParameterValue("Operation");
					return {
						relationColumnName: relationColumnName,
						relationSchemaName: relationSchemaName,
						relationSchemaUId: relationSchemaUId,
						relationSchemaRecordId: relationSchemaRecordId,
						relationSchemaOperation: relationSchemaOperation,
						additionalInfo: {}
					};
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
