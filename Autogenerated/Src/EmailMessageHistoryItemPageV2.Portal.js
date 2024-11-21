define("EmailMessageHistoryItemPageV2", ["ConfigurationConstants", "css!EmailMessageHistoryItemPageV2CSS"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			messages: {
				/**
				 * @message DeleteMessageFromHistory
				 * Informs that need to delete message from the loaded history.
				 */
				"DeleteMessageFromHistory": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
				},

				/**
				 * @message MultiDeleteFinished
				 * Notification that the delete process has been finished.
				 */
				"MultiDeleteFinished": {
					"mode": this.BPMSoft.MessageMode.BROADCAST,
					"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message MultiDeleteStart
				 * Notification that the delete process has been started.
				 */
				"MultiDeleteStart": {
					"mode": this.BPMSoft.MessageMode.BROADCAST,
					"direction": this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * Return url of actual visibility icon link.
				 * @return {String} Url of current actual icon.
				 * @protected
				 */
				getVisibilityIcon: function() {
					if(this.isDraftLabelVisible()) {
						return this.BPMSoft.ImageUrlBuilder.getUrl(this.get(
							"Resources.Images.ShowOnPortal")
						);
					}
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get(
						"Resources.Images." +
						(this.isHideEmailOnPortalLabelVisible() ? "HideOnPortal" : "ShowOnPortal")
					));
				},

				/**
				 * Return url of delete email icon link.
				 * @return {String} Url of delete email icon.
				 * @protected
				 */
				getDeleteEmailIcon: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get(
						"Resources.Images.DeleteEmailButtonImage"));
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessageHistoryItemPage#isShowEmailOnPortalLabelVisible
				 * @overridden
				 */
				isShowEmailOnPortalLabelVisible: function() {
					return this.callParent(arguments) && !this.isDraftLabelVisible();
				},

				/**
				 * @inheritdoc BPMSoft.EmailMessageHistoryItemPage#isHideEmailOnPortalLabelVisible
				 * @overridden
				 */
				isHideEmailOnPortalLabelVisible: function() {
					return this.callParent(arguments) && !this.isDraftLabelVisible();
				},

				/**
				 * Returns config for GridUtilitiesService service.
				 * @param {Array} primaryColumnValues Collection of the primary values to be delete.
				 * @param {Object} paramsJSON Extra parameters to the service.
				 * @returns {Object} Service config.
				 */
				getDeleteServiceConfig: function(primaryColumnValues, paramsJSON) {
					return {
						serviceName: "GridUtilitiesService",
						methodName: "DeleteRecordsAsync",
						data: {
							primaryColumnValues: primaryColumnValues,
							rootSchema: "Activity",
							parameters: paramsJSON,
							filtersConfig: null
						}
					};
				},

				/**
				 * Handles delete button click.
				 * public
				 */
				onDeleteEmail: function() {
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteEmailMessage"),
						function(result) {
							if(result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								this.deleteActivity();
							}
						},
						["yes", "no"]);
				},

				/**
				 * Deletes activity.
				 * @protected
				 */
				deleteActivity: function() {
					var operationKey = BPMSoft.generateGUID();
					var params = {
						operationKey: operationKey
					};
					var primaryColumnValues = [this.get("RecordId")];
					this.beforeDeleteHandler(operationKey);
					var paramsJSON = Ext.JSON.encode(params);
					var config = this.getDeleteServiceConfig(primaryColumnValues, paramsJSON);
					this.callService(config, this.deleteActivityCallback, this);
				},

				/**
				 * Configs delete process.
				 * @protected
				 * @param {String} [operationKey] Delete operation key
				 */
				beforeDeleteHandler: function(operationKey) {
					localStorage.setItem(ConfigurationConstants.MultiDelete.MultiDeleteLocalStorageKey,
						operationKey);
					this.sandbox.subscribe("MultiDeleteFinished", this.afterDeleteHandler, this);
					this._loadMultiDeleteResultModule();
					this.sandbox.publish("MultiDeleteStart", {operationKey: operationKey});
				},

				/**
				 * Calls when delete process is finished
				 * @protected
				 * @param {Object} [result] Callback parameter.
				 */
				afterDeleteHandler: function(result) {
					if(result.success) {
						this.deleteMessageFromHistory();
						this.sandbox.unRegisterMessages(["MultiDeleteFinished"]);
						this._registerMultiDeleteMessages();
					}
				},

				/**
				 * Callback for deleteActivity method.
				 * @protected
				 * @param {Object} [responseObject] Service response.
				 */
				deleteActivityCallback: function(responseObject) {
					if(!responseObject || !responseObject.DeleteRecordsAsyncResult) {
						this.hideBodyMask();
						throw new BPMSoft.UnknownException();
					}
					var result = this.BPMSoft.decode(responseObject.DeleteRecordsAsyncResult);
					var success = result.Success;
					if(!success) {
						this.hideBodyMask();
						this.showInformationDialog(this.get("Resources.Strings.DeleteEmailErrorMessage"));
					}
				},

				/**
				 * Registers multidelete messages
				 * @private
				 */
				_registerMultiDeleteMessages: function() {
					var messages = {
						"MultiDeleteStart": {
							"mode": BPMSoft.MessageMode.BROADCAST,
							"direction": BPMSoft.MessageDirectionType.PUBLISH
						},
						"MultiDeleteFinished": {
							"mode": BPMSoft.MessageMode.BROADCAST,
							"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
						}
					};
					this.sandbox.registerMessages(messages);
				},

				/**
				 * Loads multidelete result module.
				 * @private
				 */
				_loadMultiDeleteResultModule: function() {
					if(BPMSoft.MultiDeleteResultSchemaViewModel) {
						this.sandbox.loadModule("BaseSchemaModuleV2", {
							id: this.sandbox.id + "_multiDeleteResultModule",
							instanceConfig: {
								generateViewContainerId: false,
								useHistoryState: false,
								schemaName: "MultiDeleteResultSchema",
								isSchemaConfigInitialized: true
							},
							keepAlive: true
						});
					}
				},

				/**
				 * Deletes message form the history.
				 * @protected
				 */
				deleteMessageFromHistory: function() {
					var recordInfo = this.getRecordInfo();
					var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: recordInfo.historySchemaName
					});
					deleteQuery.filters.add(deleteQuery.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", this.get("Id")));
					deleteQuery.execute(function(response) {
						if(response && response.success) {
							this.sandbox.publish("DeleteMessageFromHistory", this.get("Id"));
						}
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "HistoryV2PortalEmailMessageVisibilityContainer",
					"parentName": "HistoryV2MessageFooterContainer",
					"propertyName": "items",
					"values": {
						"id": "PortalEmailMessageVisibilityContainer",
						"markerValue": "HistoryV2PortalEmailMessageVisibilityContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["visibilityContainer"],
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "HistoryV2PortalEmailMessageVisibilityContainer",
					"propertyName": "items",
					"name": "VisibilityIcon",
					"values": {
						"getSrcMethod": "getVisibilityIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["visibilityIcon"]}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"parentName": "HistoryV2PortalEmailMessageVisibilityContainer",
					"propertyName": "items",
					"name": "DeleteEmailImageButton",
					"values": {
						"getSrcMethod": "getDeleteEmailIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {"wrapClass": ["delete-email-icon"]},
						"markerValue": "DeleteDraftEmail",
						"onImageClick": {
							"bindTo": "onDeleteEmail"
						},
						"visible": {
							"bindTo": "isDraftLabelVisible"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "HistoryV2HideEmailOnPortalLabel",
					"parentName": "HistoryV2PortalEmailMessageVisibilityContainer",
					"propertyName": "items",
					"values": {
						"id": "HideEmailOnPortalLabel",
						"labelClass": ["portalEmailMessageVisibilityLabel"],
						"markerValue": "HideEmailOnPortalLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.HideEmailOnPortalString"
						},
						"visible": {
							"bindTo": "isHideEmailOnPortalLabelVisible"
						},
						"click": {
							"bindTo": "hideEmailMessageOnPortal"
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ShowEmailOnPortalLabel",
					"parentName": "HistoryV2PortalEmailMessageVisibilityContainer",
					"propertyName": "items",
					"values": {
						"id": "ShowEmailOnPortalLabel",
						"labelClass": ["portalEmailMessageVisibilityLabel"],
						"markerValue": "ShowEmailOnPortalLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ShowEmailOnPortalString"
						},
						"visible": {
							"bindTo": "isShowEmailOnPortalLabelVisible"
						},
						"click": {
							"bindTo": "showEmailMessageOnPortal"
						}
					},
					"index": 2
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
