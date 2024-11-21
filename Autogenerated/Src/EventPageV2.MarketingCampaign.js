define("EventPageV2", ["BPMSoft", "BaseFiltersGenerateModule", "ConfigurationConstants", "css!EventPageV2CSS"],
function(BPMSoft, BaseFiltersGenerateModule, ConfigurationConstants) {
	return {
		entitySchemaName: "Event",
		attributes: {
			"Owner": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter},
				isRequired: true
			},
			"StartDate": {
				dataValueType: BPMSoft.DataValueType.DATE
			},
			/**
			 * Caption with actual marketing event queue info.
			 * @type {String}
			 */
			"QueueTasksCaption": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Marketing event queue is empty for current email.
			 * @type {Array}
			 */
			"IsQueueEmpty": {
				type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		messages: {
			/**
			 * @message GetEventImportAudienceData
			 * Returns event data for audience import.
			 */
			"GetEventImportAudienceData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message SaveBeforeAction
			 * Tries to save event before action.
			 */
			"SaveBeforeAction": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message ReloadEventQueueState
			 */
			"ReloadEventQueueState": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			/**
			 * @inheritDoc BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.reloadEventQueueTasks();
			},

			/**
			 * @inheritdoc BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
					if (callback) {
						callback.call(scope);
					}
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#destroy
			 * @override
			 */
			destroy: function() {
				BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE,
					this.onChannelMessage, this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getHeader
			 * @overridden
			 */
			getHeader: function() {
				return this.entitySchema.caption;
			},

			/**
			 * ########## ######## ###### #############.
			 * @protected
			 * @overridden
			 * @return {Boolean} ########## ######### #########.
			 */
			validate: function() {
				var isValid = this.callParent(arguments);
				var startDate  = this.get("StartDate");
				var endDate = this.get("EndDate");
				if (!Ext.isEmpty(startDate) && !Ext.isEmpty(endDate) && (startDate > endDate)) {
					this.showInformationDialog(this.get("Resources.Strings.WarningWrongDate"));
					return false;
				} else {
					return isValid;
				}
			},
			/**
			 * ####### ######## ######## ###### email.
			 * @protected
			 * @return {createFilterGroup}
			 */
			emailDetailFilter: function() {
				var recordId = this.get("Id");
				var filterGroup = new BPMSoft.createFilterGroup();
				filterGroup.add("Event", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Event", recordId));
				var emailType = ConfigurationConstants.Activity.Type.Email;
				filterGroup.add("ActivityType", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Type", emailType));
				return filterGroup;
			},

			/**
			 * Handler for 'SaveBeforeAction' received message.
			 * @protected
			 */
			trySaveBeforeAction: function(config) {
				BPMSoft.chain(
					this.saveCheckCanEditRight,
					this.saveAsyncValidate,
					function(next) {
						this.save({
							callback: next,
							isSilent: true
						});
					},
					function(next) {
						this.saveEntity(function(response) {
							if (this.validateResponse(response)) {
								this.cardSaveResponse = response;
								next();
							}
						}, this);
					},
					function(next) {
						this.saveDetails(function(response) {
							if (this.validateResponse(response)) {
								next();
							}
						}, this);
					},
					function() {
						config.action.call(this);
						this.cardSaveResponse = null;
						delete this.cardSaveResponse;
					},
				this);
			},

			/**
			 * Handles the message server communications channel.
			 * @protected
			 * @param {BPMSoft.ServerChannel} channel BPMCRM server communication channel.
			 * @param {Object} message Message object.
			 */
			onChannelMessage: function(channel, message) {
				if (!this.Ext.isObject(message)) {
					return;
				}
				if (message.Header.Sender === "EventQueueMessageNotifier") {
					this.reloadEventQueueTasks();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("GetEventImportAudienceData", function() {
					return { recordName: this.$Name };
				}, this);
				this.sandbox.subscribe("SaveBeforeAction", this.trySaveBeforeAction, this);
				this.sandbox.subscribe("ReloadEventQueueState", this.reloadEventQueueTasks, this);
			},

			/**
			 * Returns caption with actual event queue state info.
			 * @protected
			 * @param {Object} estimation Estimation for current event queue tasks processing.
			 * @returns {String}
			 */
			getQueueTasksCaption: function(estimation) {
				var estimatedTimeInMinutes = Math.round(estimation.EstimatedTime / 60);
				var tasksCaptionTemplate = this.get("Resources.Strings.QueueTasksLabelText");
				return Ext.String.format(tasksCaptionTemplate, estimatedTimeInMinutes);
			},

			/**
			 * Calls service to load actual event queue tasks.
			 * @protected
			 */
			reloadEventQueueTasks: BPMSoft.debounce(function() {
				var config = {
					serviceName: "EventAudience",
					methodName: "EstimateTaskExecution",
					data: {
						eventId: this.getPrimaryColumnValue()
					}
				};
				this.callService(config, function(response) {
					var result = response.EstimateTaskExecutionResult;
					if (result.Success && result.Position > 0) {
						this.$IsQueueEmpty = false;
						this.$QueueTasksCaption = this.getQueueTasksCaption(result);
						this.maskId = BPMSoft.Mask.show({
							caption: "",
							frameVisible: false,
							selector: "#queue-task-spinner"
						});
						return;
					}
					this.$IsQueueEmpty = true;
					this.$QueueTasksCaption = "";
					BPMSoft.Mask.hide(this.maskId);
				}, this);
			}, 2000)
		},
		details: /**SCHEMA_DETAILS*/{
			Files: {
				schemaName: "FileDetailV2",
				entitySchemaName: "EventFile",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				}
			},
			EventTarget: {
				schemaName: "EventTargetDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				},
				defaultValues: {
					Event: {
						masterColumn: "Id"
					}
				}
			},
			Activities: {
				schemaName: "ActivityDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				},
				defaultValues: {
					Interaction: {
						masterColumn: "Id"
					}
				}
			},
			EventProduct: {
				schemaName: "EventProductDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				},
				defaultValues: {
					Event: {
						masterColumn: "Id"
					}
				}
			},
			EventTeam: {
				schemaName: "EventTeamDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				},
				defaultValues: {
					Event: {
						masterColumn: "Id"
					}
				}
			},
			Email: {
				schemaName: "EmailDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				},
				defaultValues: {
					Event: {
						masterColumn: "Id"
					}
				},
				filterMethod: "emailDetailFilter"
			},
			EventCampaign: {
				schemaName: "CampaignWithEventDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Event"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Type",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Type",
					"caption": {
						"bindTo": "Resources.Strings.EventTypeCaption"
					},
					"textSize": 0,
					"contentType": 3,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Owner",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Owner",
					"caption": {
						"bindTo": "Resources.Strings.OwnerCaption"
					},
					"textSize": 0,
					"contentType": 5,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Status",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Status",
					"caption": {
						"bindTo": "Resources.Strings.EventStatusCaption"
					},
					"textSize": 0,
					"contentType": 3,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "EventInfoContainer",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 11,
						"rowSpan": 1
					},
					"items" : []
				},
				"index": 4
			},
			{
				"operation": "insert",
				"name": "EventQueueTasksContainer",
				"parentName": "EventInfoContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items" : [],
					"wrapClass": ["event-queue-tasks-wrap"]
				},
			},
			{
				"operation": "insert",
				"name": "EventQueueTasks",
				"parentName": "EventQueueTasksContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$QueueTasksCaption",
					"classes": {"labelClass": ["queue-tasks-label"]},
					"markerValue": "EventQueueTasksLabel"
				}
			},
			{
				"operation": "insert",
				"name": "EventQueueTasksSpinner",
				"parentName": "EventQueueTasksContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"propertyName": "items",
				"values": {
					"id": "queue-task-spinner",
					"wrapClass": ["queue-task-spinner"]
				}
			},
			{
				"operation": "insert",
				"name": "GeneralInfoTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.GeneralInfoTabCaption"
					},
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "group",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.groupCaption"
					},
					"items": [],
					"controlConfig": {
						"collapsed": false
					}
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "group_gridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "group",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "EndDate",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "EndDate",
					"caption": {
						"bindTo": "Resources.Strings.EndDateCaption"
					},
					"textSize": 0,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Goal",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Goal",
					"caption": {
						"bindTo": "Resources.Strings.GoalCaption"
					},
					"textSize": 0,
					"contentType": 1,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Territory",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Territory",
					"caption": {
						"bindTo": "Resources.Strings.TerritoryCaption"
					},
					"textSize": 0,
					"contentType": 5,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "StartDate",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "StartDate",
					"caption": {
						"bindTo": "Resources.Strings.StartDateCaption"
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Industry",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Industry",
					"caption": {
						"bindTo": "Resources.Strings.IndustryCaption"
					},
					"textSize": 0,
					"contentType": 5,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ActualResponse",
				"values": {
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "ActualResponse",
					"caption": {
						"bindTo": "Resources.Strings.ActualResponseCaption"
					},
					"textSize": 0,
					"contentType": 1,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group_gridLayout",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "group1",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.group1Caption"
					},
					"items": [],
					"controlConfig": {
						"collapsed": false
					}
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "group1_gridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "group1",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PrimaryBudgetedCost",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "PrimaryBudgetedCost",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryBudgetedCostCaption"
					},
					"textSize": 0,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group1_gridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PrimaryExpectedRevenue",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "PrimaryExpectedRevenue",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryExpectedRevenueCaption"
					},
					"textSize": 0,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group1_gridLayout",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "PrimaryActualCost",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "PrimaryActualCost",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryActualCostCaption"
					},
					"textSize": 0,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group1_gridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "PrimaryActualRevenue",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "PrimaryActualRevenue",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryActualRevenueCaption"
					},
					"enabled": true,
					"textSize": 0,
					"labelConfig": {
						"visible": true
					}
				},
				"parentName": "group1_gridLayout",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "EventPage3Tab",
				"values": {
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.EventPage3TabCaption"
					}
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "EventPage4Tab",
				"values": {
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.EventPage4TabCaption"
					}
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "EventPage5Tab",
				"values": {
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.EventPage5TabCaption"
					}
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 3
			},
			{
				"operation": "insert",
				"parentName": "EventPage5Tab",
				"propertyName": "items",
				"name": "Files",
				"values": {
					itemType: BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"parentName": "EventPage5Tab",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"}
				}
			},
			{
				"operation": "insert",
				"parentName": "NotesControlGroup",
				"propertyName": "items",
				"name": "Notes",
				"values": {
					contentType: BPMSoft.ContentType.RICH_TEXT,
					layout: {column: 0, row: 0, colSpan: 24},
					labelConfig: {
						visible: false
					},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "insertImagesToNotes"
						},
						"images": {
							"bindTo": "NotesImagesCollection"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "EventPage3Tab",
				"propertyName": "items",
				"name": "EventTarget",
				"values": {
					itemType: this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "EventPage4Tab",
				"propertyName": "items",
				"name": "Activities",
				"values": {
					itemType: BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "EventPage4Tab",
				"propertyName": "items",
				"name": "EventProduct",
				"values": {
					itemType: this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "EventPage4Tab",
				"propertyName": "items",
				"name": "Email",
				"values": {
					itemType: this.BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "EventPage4Tab",
				"propertyName": "items",
				"name": "EventCampaign",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"name": "EventTeam",
				"values": {
					itemType: BPMSoft.ViewItemType.DETAIL
				}
			}
		]/**SCHEMA_DIFF*/,
		userCode: {}
	};
});
