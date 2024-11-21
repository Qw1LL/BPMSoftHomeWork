define("BasePageV2", ["BPMSoft", "ServiceHelper"],
	function(BPMSoft, ServiceHelper) {
		return {
			messages: {

				/**
				 * @message QueueItemPostponed
				 * ########### ##### ######### ######## ########## ## ######### ######## #######.
				 */
				"QueueItemPostponed": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message CloseQueueItemEdit
				 * ########### ### ######## ######## ###### ######## #######.
				 */
				"CloseQueueItemEdit": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message PostponeProcessExecution
				 * ######## ## ############# ######## ########## #### ######## ######## #######.
				 */
				"PostponeProcessExecution": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * ############# ######## ####### ####### ####.
				 * @type {String}
				 */
				"QueueItemId": {
					"dataValueType": this.BPMSoft.DataValueType.GUID,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * ####### ####, ### ######## #### ####### ######### ######### ####### ####### ####.
				 * @type {Boolean}
				 */
				"IsQueueProcessMode": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				}
			},
			methods: {

				/**
				 * ######### ##### ############## ######## ####### ## ############## ########## ########### ########.
				 * @private
				 * @param {String} processId ############# ########## ########### ########.
				 * @param {Function} callback ####### ######### ######.
				 * @param {String} callback.queueItemId (optional) ############# ########## ######## #######.
				 */
				findQueueItemId: function(processId, callback) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "QueueItem"
					});
					esq.addColumn("Id");
					esq.filters.addItem(esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"SysProcessDataId", processId, this.BPMSoft.DataValueType.GUID));
					esq.getEntityCollection(function(result) {
						if (!result.success) {
							callback();
							return;
						}
						var entities = result.collection;
						var queueItemsCount = entities.getCount();
						if (queueItemsCount === 0) {
							callback();
							return;
						} else if (queueItemsCount > 1) {
							this.error(this.get("Resources.Strings.MultipleQueueItemsFoundError"));
							callback();
							return;
						}
						var entity = entities.getByIndex(0);
						var queueItemId = entity.get("Id");
						callback(queueItemId);
					}, this);
				},

				/**
				 * ########### (########## # #######) ####### #######.
				 * @private
				 * @param {String} queueItemId ############# ######## #######.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Boolean} callback.success ####### ######### ########## ########.
				 */
				postponeQueueItem: function(queueItemId, callback) {
					var serviceCallBack = function(response, success) {
						if (!success) {
							var errorMessage =
								this.Ext.String.format(this.get("Resources.Strings.PostponeQueueItemError"),
									response.responseText);
							this.error(errorMessage);
							if (callback) {
								callback(false);
							}
							return;
						}
						if (callback) {
							callback(response === 1);
						}

					};
					ServiceHelper.callService({
						serviceName: "QueuesService",
						methodName: "PostponeQueueItem",
						data: {
							queueItemId: queueItemId
						},
						callback: serviceCallBack,
						scope: this
					});
				},

				/**
				 * @inheritDoc
				 * @overridden
				 */
				init: function(callback, scope) {
					let isProcessMode;
					if (BPMSoft.Features.getIsEnabled("LoadQueueInfoOnInit")) {
						return this.callParent([function() {
							isProcessMode = this.get("IsProcessMode");
							if (!isProcessMode) {
								return Ext.callback(callback, scope || this);
							}
							this.initQueueInfo(callback.bind(scope || this));
						}, this]);
					}
					this.callParent(arguments);
					isProcessMode = this.get("IsProcessMode");
					if (isProcessMode) {
						this.initQueueInfo();
					}
				},

				/**
				 * Initializes information about the Single Window queue item associated with the current process.
				 * @param {Function} callback Callback function.
				 */
				initQueueInfo: function(callback) {
					var processData = this.get("ProcessData");
					if (!processData || !processData.processId) {
						return Ext.callback(callback, this);
					}
					var processId = processData.processId;
					this.findQueueItemId(processId, function(queueItemId) {
						if (!queueItemId) {
							return Ext.callback(callback, this);
						}
						this.set("QueueItemId", queueItemId);
						this.set("IsQueueProcessMode", true);
						this.sandbox.subscribe("QueueItemPostponed", function() {
							this.onQueueItemPostponed();
						}, this);

						this.sandbox.subscribe("CloseQueueItemEdit", this.closeQueueItemEdit, this,
							[this.getQueueItemEditModuleId()]);
						Ext.callback(callback, this);
						this.onQueueInfoFinded();
					}.bind(this));
				},

				/**
				 * Processing after loading the queue information.
				 * @protected
				 */
				onQueueInfoFinded: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.DelayExecutionUtilities#getDelayExecutionButtonVisible
				 * @overridden
				 */
				getDelayExecutionButtonVisible: function() {
					return this.callParent(arguments) && !this.get("IsQueueProcessMode");
				},

				/**
				 * ########## ############# ###### ######### ###### ######## #######.
				 * @protected
				 * @returns {String}
				 */
				getQueueItemEditModuleId: function() {
					return this.sandbox.id + "_OpenQueueItemEditPage";
				},

				/**
				 * ######### ###### ######### ###### ######## #######.
				 * @protected
				 * @param {String} queueItemId ############# ######## #######.
				 */
				loadQueueItemEditPageModule: function(queueItemId) {
					this.showBodyMask();
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						renderTo: "DelayExecutionModuleContainer",
						id: this.getQueueItemEditModuleId(),
						keepAlive: false,
						instanceConfig: {
							parameters: {
								viewModelConfig: {
									PrimaryColumnValue: queueItemId
								}
							},
							schemaName: "QueueItemEditPage",
							entitySchemaName: "QueueItem",
							isSchemaConfigInitialized: true,
							useHistoryState: false
						}
					});
				},

				/**
				 * ######### ###### ######### ###### ######## #######.
				 * @param {String} moduleId ############# ######.
				 * @protected
				 */
				closeQueueItemEdit: function(moduleId) {
					this.set("DelayExecutionModuleContainerVisible", false);
					this.sandbox.unloadModule(moduleId);
				},

				/**
				 * ############ ############ ########## #### ######## ######## #######.
				 * @private
				 */
				onQueueItemPostponed: function() {
					this.sandbox.publish("PostponeProcessExecution");
				},

				/**
				 * ############ ####### ## ###### ############# ## ####.
				 * @private
				 */
				onChangeQueueItemDateButtonClick: function() {
					var queueItemId = this.get("QueueItemId");
					if (!queueItemId) {
						this.error(this.get("Resources.Strings.QueueItemIsEmptyError"));
						return;
					}
					this.get("DelayExecutionModuleContainerVisible");
					this.set("DelayExecutionModuleContainerVisible", true);
					this.loadQueueItemEditPageModule(queueItemId);
				},

				/**
				 * ############ ####### ## ###### ####### # #######.
				 * @private
				 */
				onPostponeQueueItemButtonClick: function() {
					var queueItemId = this.get("QueueItemId");
					if (!queueItemId) {
						this.error(this.get("Resources.Strings.QueueItemIsEmptyError"));
						return;
					}
					this.postponeQueueItem(queueItemId, function(success) {
						var messageString = (success)
							? "QueueItemPostponeSucceedMessage"
							: "QueueItemPostponeFailedMessage";
						var message = this.get("Resources.Strings." + messageString);
						this.showInformationDialog(message, function() {
							if (success) {
								this.onQueueItemPostponed();
							}
						}.bind(this));
					}.bind(this));
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "ChangeQueueItemDateButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ChangeQueueItemDateButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onChangeQueueItemDateButtonClick"},
						"visible": {"bindTo": "IsQueueProcessMode"}
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "PostponeQueueItemButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.PostponeQueueItemButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onPostponeQueueItemButtonClick"},
						"visible": {"bindTo": "IsQueueProcessMode"}
					},
					"index": 3
				}
			]/**SCHEMA_DIFF*/
		};
	});
